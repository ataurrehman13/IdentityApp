## Tutorial Reference
---

> [Step-by-Step: Implementing ASP.NET Core Identity with Angular (JWT, Email confirmation)](https://www.youtube.com/watch?v=sCWwHtZyVMg)

> [Kind Cluster With Ingress Nginx Controller](https://www.youtube.com/watch?v=1Jbmtdjxhjs)

### Application Architecture

##### Solution Architecture
![System Architecture](Assets/architecture-diagram.png "System Architecture")

### Run This Project on New System
- Update appsettings.json file
- Run new powershell window as Admistrator and run below command. This will create environment variable SECRET.
```bash
# set security key for json token by running below command
setx SECRET "CodeMazeSecretKey" /M
```

### Setup Project
#### Setup Git with Project
```bash
# Create .gitignore file by running below command:
dotnet new gitignore

# Initialize Git, make sure you have created a blank git repository
git init
git add .
git commit -m "Api project created"
git branch -M main
git remote add origin https://github.com/ataurrehman13/IdentityApp.git
git push -u origin main

```

#### 0.1 Configure Git With Project



##### 0.2 Create, Build & Run Project

```dotnet

# create Blazor server project
dotnet new blazor -int Server -au individual
dotnet new blazor -o SmartSchool.Web -int Server

# run below command to set production environment
export ASPNETCORE_ENVIRONMENT=Production

# run below command to set development environment
export ASPNETCORE_ENVIRONMENT=Development

// Add/Remove project(s) to solution
dotnet sln add **/*.csproj
dotnet sln remove **/*.csproj

// Build & run project
dotnet build
func start

// Run the project with hot reload
func watch
```

##### 1. Run Cosmos DB Emulator Docker Container

```docker

```

##### 2. Add Dependencies

```dotnet
// Install below packages for this project

dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.3
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.3
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.3
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.3
dotnet add package System.IdentityModel.Tokens.Jwt --version 7.5.0
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.3

```

##### 3. Create Secrets

```dotnet
dotnet user-secrets init
dotnet user-secrets set "UserId" "sa"
```

##### 3. Database Migrations

```dotnet
# run database migration in Package Manager Console
add-migration AddingUserToDatabase -o Data/Migrations
update-database


// Go to project CompanyEmployees80 and run below commands. Make sure
// MS SQL Server Docker container is running.

dotnet ef migrations add "InitialMigration" --startup-project ./SohatNotebook.Api/

dotnet ef migrations add InitialMigration
dotnet ef database update

or 

// Run below command in Visual Studio 2022 Package Manager console:

Add-Migration AddNameRoleToAppUser

Add-Migration -o Data/Migrations (provide the output folder)

Update-Database

// To remove the migration, run below command in Package Manager console:
Remove-Migration

// to apply the migration to database run below command in package manager console:
Update-Database

// Go to folder CompanyEmployees.WebApi & run below command to create and apply existing migrations
dotnet ef database update

// Remove migrations
dotnet ef migrations remove
```

##### 4. Build Docker Image
```docker
# build docker image
docker build -t ataurrehman/platformservice .

# push image to docker hub
docker push ataurrehman/platformservice

# run docker container
docker run -p 8080:80 -d ataurrehman/platformservice

# misc. docker commands
docker ps
docker stop <container id>
docker start <container id>
```

##### 5. Kubernetes
```bash
kubectl apply -f platform-depl.yaml
kubectl apply -f platform-np-srv.yaml

# Test in browder with Cluster IP and NodePort port number
curl http://172.18.0.3:30476/api/platforms

# Forward host port 8080 to port 80 of the service running in kubernetes
kubectl port-forward service/platformnpservice-srv 8089:80


## --- Misc commands --- ##

# Create deployment
kubectl create deployment nginx-deployment --image=nginx --replicas=2
# Create service / Expose deployment
kubectl expose deployment nginx-deployment --type=NodePort --name=nginx-service --port 80

# Get IP address of the worker node by running below command
kubectl get nodes -o wide

# Get the internal port on which service is running
kubectl get svc

# Run below command to access the service, e.g. http://172.18.0.3:32363
curl http://<IP from above step>:<NodePort port>

```

##### 6. KinD Kubernetes Cluster

```yml

# Create ingress nginx controller compliant kind cluster, use below config file
kind create cluster --config=KindCluster/with-ingress-config.yaml

#Configuration file for creating Ingress Nginx controller compliant Kind cluster with 2 nodes

kind: Cluster
apiVersion: kind.x-k8s.io/v1alpha4
nodes:
  - role: control-plane
    kubeadmConfigPatches:
      - |
        kind: InitConfiguration
        nodeRegistration:
          kubeletExtraArgs:
            node-labels: "ingress-ready=true"
    extraPortMappings:
      - containerPort: 80
        hostPort: 80
        protocol: TCP
      - containerPort: 443
        hostPort: 443
        protocol: TCP
  - role: worker

# Deploy ingress nginx controller on the kind cluster
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/main/deploy/static/provider/kind/deploy.yaml

```

##### 7. VS Code Plugins
```
# Database
1. Database Client By Weijan Chen
2. SQl Server Client(mssql) By Weijan Chen
3. SQL Server (mssql) By Microsoft

# Add below extension in the VS Code to manage the solution
vscode-solution-explorer By Fernando Escolar
```

##### 8. Misc Commands
```
# Generate New Guid in terminal by running below command

uuidgen

# Create Wallets documents' records/items by opening Cosmos DB emulator and storing below 2 json objects:

{
    "id": "b56383b6-bec9-4a7e-8165-086329cd2224",
    "type": "Bank",
    "bankName": "Bank X",
    "iban": "9999999999999",
    "swift": "ACBB0XCHG",
    "accountType": "Savings",
    "userId": "userId",
    "balance": 569,
    "currency": "USD"
}


{
    "id": "43faf9c5-51c3-45c2-a60c-d9c29ba73212",
    "type": "PayPal",zxcv bnm,
    "username": "paypal.user",
    "userId": "userId",
    "currency": "USD",
    "balance": 0
}
```

---

## Angular Client App

### Misc. Angular Commands

```bash

# Create module, this will create module in new folder
ng g m account 

# Create module in the current folder and do not create new folder
ng g m account-routing --flat

# Create angular component under app folder
ng g c navbar --skip-tests
ng g c footer --skip-tests
ng g c home --skip-tests

# Create angular service
ng g s account --skip-tests

# Create component inside Account module
ng g c login --skip-tests
ng g c register --skip-tests



```

### Install themes

1. Visit https://bootswatch.com/
2. Select the theme and copy the name of the theme from that site
3. Open angular.json file from project
4. Add below line under the styles section and replace the theme name e.g. darkly in below case, in the path:
    "./node_modules/bootswatch/dist/darkly/bootstrap.css",

---

##### Continue from 1:57:49


"ConnectionStrings": {
    "sqlConnection": "Data Source=localhost;Initial Catalog=CompanyEmployee;persist security info=True;TrustServerCertificate=True;User ID=sa;Password=MyStrongP@ssword123"
  },        


  
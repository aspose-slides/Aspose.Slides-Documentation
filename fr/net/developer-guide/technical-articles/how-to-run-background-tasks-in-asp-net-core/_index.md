---
title: Comment exécuter des tâches en arrière-plan dans ASP.NET Core
type: docs
weight: 300
url: /net/how-to-run-background-tasks-in-asp-net-core/
---

## **Aperçu**
Le traitement de fichiers (ex. : exportation de présentation en PDF) est une tâche typique côté serveur. Le traitement simple de fichiers à l'intérieur du gestionnaire de requêtes (lorsque le client attend pendant que le serveur effectue le travail) présente les inconvénients suivants :

- *Mauvaise interface utilisateur*. La page se fige et l'utilisateur doit attendre le résultat. Le rechargement de la page annulera la tâche.
- *Délai d'expiration de l'opération*. Nous ne pouvons pas garantir que le traitement est terminé dans une période de temps fixe, ce qui signifie que l'utilisateur verra "délai d'expiration de l'opération" tôt ou tard.  
- *Faible débit et évolutivité*. ASP.NET Core est conçu pour traiter de nombreuses requêtes de manière asynchrone. Les tâches longues à fort engagement CPU bloquent les threads et réduisent le débit du serveur.  
- *Mauvaise tolérance aux pannes*. Lorsque quelque chose ne va pas au milieu d'une tâche longue (par ex. : problème de connectivité), le traitement échoue simplement et nous devons relancer le traitement depuis le début une fois de plus.

Une[ meilleure approche](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests) est de planifier le travail de manière asynchrone d'abord, de le terminer en arrière-plan ensuite et de retourner le résultat du traitement enfin.

Dans ce cas, l'utilisateur peut voir le statut réel (et même quitter ou recharger la page), les ressources serveur peuvent être efficacement mises à l'échelle et ajustées de manière flexible. De plus, une politique de réessai peut être utilisée.

Ainsi, la solution typique de traitement en arrière-plan comprend les parties suivantes :
1. API pour planifier le travail.
2. API pour suivre le statut du travail.
3. Le travailleur en arrière-plan pour traiter les tâches planifiées.
4. API pour stocker/obtenir le résultat.

## **Exemple de Tâche en Arrière-Plan**
Pour démontrer cette approche, considérons le[ **exemple d'application web ASP.NET Core 3.1**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1). L'application web contient une page web où l'utilisateur peut télécharger une présentation, appuyer sur le bouton "Exporter en PDF", puis la présentation sera téléchargée et convertie en format PDF par un travailleur en arrière-plan.
## **Application Web**
L'application web exemple (*Projet BackgroundJobDemo*) comprend :

- Page de téléchargement de fichiers (page razor Upload).
- Page de progression (page razor Progress avec quelques fonctions JavaScript vérifiant et affichant le statut).
- Contrôleur (JobStatusController) fournissant le statut de traitement (api/status/{jobId}).
- Contrôleur (JobResultController) retournant le fichier PDF exporté (api/result/{id}).
- Travailleur en arrière-plan basé sur le service d'hébergement ASP.NET Core (voir classe WorkerService).

Les pages Razor, contrôleurs et le travailleur en arrière-plan délèguent tout le travail réel via des interfaces définies dans le projet *BackgroundJobDemo.Common*. Les implémentations concrètes de la gestion et du traitement des tâches sont définies dans des projets séparés (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* etc.) et peuvent être facilement remplacées dans la méthode Startup.ConfigureServices.

À des fins de démonstration, la page "Upload" utilise le binding de modèle en mémoire tampon, mais pour le téléchargement de grands fichiers, le streaming non tamponné est [recommandé](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Pour un déploiement en production, les [aspects de sécurité](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) doivent être pris en compte. La page "Progress" interroge le statut de la tâche planifiée via JavaScript toutes les 2 secondes (la période peut être modifiée). L'interrogation de statut est un comportement typique, mais pour des cas avancés, des notifications en temps réel (les communications en temps réel sont hors du scope de cet article) via WebSocket peuvent être requises. [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) est un outil simple mais puissant pour les communications en temps réel.

L'hébergement du travailleur en arrière-plan dans le processus serveur est pratique pour des applications simples, mais présente des[ inconvénients](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). La solution plus robuste et évolutive est de déployer le travailleur dans un processus séparé (voir par exemple l'application console *BackgroundJobDemo.Worker*).
## **Implémentation de Base**
Le projet *BackgroundJobDemo.Local* contient une implémentation simple de gestion des tâches avec une base de données SQLite (le chemin vers le fichier de base de données est spécifié via LocalConfig.DbFilePath, voir dans Startup.ConfigureServices). Les fichiers téléchargés et traités sont stockés sur le système de fichiers (le chemin vers le dossier de stockage est spécifié via LocalConfig.FileStorageFolderPath, voir dans Startup.ConfigureServices). Pour une meilleure tolérance aux pannes et des performances dans les applications réelles, la planification des tâches doit être mise en œuvre via des files d'attente de messages (ex. : RabbitMQ, AWS SQS, Azure Storage Queue).
## **Implémentation Distribuée Basée sur Amazon Web Services**
Le projet *BackgroundJobDemo.Aws* implémente le traitement des tâches via Amazon Web Services et démontre l'architecture distribuée qui peut être évoluée horizontalement. Il comprend les composants suivants :

- Application web - interagit avec l'utilisateur et planifie les tâches d'exportation PPTX en PDF, etc.
- Travailleur - traite l'exportation (en processus, hors processus ou Amazon Lambda).
- File d'attente de messages - stocke les tâches à traiter (Amazon SQS).
- Stockage de fichiers - conserve les fichiers téléchargés et traités (Amazon S3).
- Stockage clé-valeur - fournit le statut de traitement des tâches (Amazon DynamoDB). 

L'architecture distribuée typique est basée sur [les files d'attente de messages](https://aws.amazon.com/message-queue/) : l'application web met les tâches d'arrière-plan dans la file d'attente, le travailleur en arrière-plan récupère la tâche de la file d'attente et effectue le travail requis. Ainsi, les composants du système (application web et travailleur en arrière-plan) sont découplés et le traitement est asynchrone et fiable. La file d'attente garantit que tous les messages (tâches) sont livrés aux travailleurs. Les messages de file d'attente ont un *délai de visibilité* - lorsque un travailleur reçoit le message pour le traitement, le message devient invisible pour d'autres travailleurs et seul le travailleur traitant le message le retire de la file d'attente. Si le traitement n'est pas terminé pendant le délai de visibilité (ex. : échec ou problème de réseau) - le message non traité redevient visible pour les travailleurs.

Notre implémentation utilise [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) - des files d'attente de messages entièrement gérées pour les microservices, les systèmes distribués et les applications sans serveur.

Les files d'attente de messages sont conçues pour des messages légers (ex. : la limite de taille de message SQS est de 256 Ko), donc elle doit contenir uniquement la description de la tâche. Toutes les données lourdes (ex. : fichiers à traiter) doivent être placées dans un stockage séparé et être référencées depuis le message. [Amazon S3](https://aws.amazon.com/s3/) est un stockage d'objets construit pour stocker et récupérer n'importe quelle quantité de données de n'importe où. Ce service est utilisé pour stocker les fichiers téléchargés et traités.

Le stockage clé-valeur est requis pour stocker et récupérer le résultat du traitement des tâches par ID. [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) (service de base de données NoSQL rapide et flexible pour n'importe quelle échelle) a été utilisé dans l'exemple.

Pour exécuter l'application de démonstration avec Amazon Web Services :

1. Créer et configurer dans la même région AWS :
   1. File d'attente SQS,
   1. Bucket S3,
   1. Table DynamoDB.
1. Connecter l'application web aux services créés avec la méthode d'extension AddAws (URL de la file d'attente SQS, nom du bucket S3, nom de la table DynamoDB et région AWS) depuis Startup.ConfigureServices. 
## **Références**
- Meilleures pratiques de performance ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- Télécharger des fichiers dans ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- ASP.NET en temps réel avec SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- Files d'attente de messages <https://aws.amazon.com/message-queue/>
- Amazon Simple Queue Service <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>
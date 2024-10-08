---
title: Comment exécuter des exemples
type: docs
weight: 130
url: /fr/net/how-to-run-examples/
---

## **Exigences Logicielles**
Avant de télécharger et d'exécuter les exemples, veuillez vérifier et confirmer que votre configuration répond à ces exigences :

- Visual Studio 2010 ou supérieur.
- Gestionnaire de packages NuGet installé dans Visual Studio. Vérifiez que la dernière version de l'API NuGet est installée dans Visual Studio.

Pour des instructions sur l'installation du gestionnaire de paquets NuGet, allez sur cette page : https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Allez dans **Outils** > **Options** > **Gestionnaire de paquets NuGet**.

1. Développez **Gestionnaire de paquets NuGet** (en double-cliquant dessus) et sélectionnez **Sources de paquets**.

1. Vérifiez et confirmez que le paramètre nuget.org est sélectionné.

   Le projet d'exemple utilise la fonctionnalité de restauration automatique des paquets NuGet, donc vous devez avoir une connexion Internet active.

   Si vous n'avez pas de connexion Internet active sur la machine où vous prévoyez d'exécuter les exemples, veuillez consulter [Installation](https://docs.aspose.com/slides/net/installation/) et (manuellement) ajouter une référence à Aspose.Slides.dll dans le projet d'exemple.
## **Télécharger depuis GitHub**
Tous les exemples Aspose.Slides pour .NET sont hébergés sur [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Vous pouvez soit cloner le dépôt en utilisant votre client GitHub préféré, soit télécharger le fichier ZIP [ici](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Si vous téléchargez le fichier ZIP, vous devez extraire son contenu dans un dossier sur votre ordinateur.

Tous les exemples sont stockés dans le dossier **Exemples**.

Il y a un fichier de solution C# Visual Studio. Les projets sont créés dans Visual Studio 2013, mais les fichiers de solution sont compatibles avec Visual Studio 2010 SP1 et supérieur.

2. Ouvrez le fichier de solution dans Visual Studio et créez le projet.

   Lors de la première exécution, les dépendances sont automatiquement téléchargées via NuGet.

Le dossier **Données** à la racine du dossier **Exemples** contient des fichiers d'entrée utilisés dans les exemples C#. Vous devez télécharger le dossier **Données** en même temps que le projet d'exemples.

3. Ouvrez le fichier RunExamples.cs. Tous les exemples sont appelés depuis ici.

4. Décommentez les exemples que vous souhaitez exécuter dans le projet.

N'hésitez pas à nous contacter via nos forums si vous avez des problèmes pour configurer les choses ou exécuter les exemples.
## **Contribuer**
Vous pouvez contribuer au projet en ajoutant ou en améliorant un exemple. Tous les exemples et projets de démonstration dans le dépôt sont open-source, donc vous (et d'autres personnes) pouvez les utiliser librement dans des applications.

Pour contribuer, vous pouvez forker le dépôt, modifier le code source et créer une demande de fusion. Nous examinerons les modifications. Si nous les trouvons utiles, nous les ajouterons au dépôt.
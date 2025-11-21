---
title: Comment exécuter les exemples
type: docs
weight: 130
url: /fr/net/how-to-run-examples/
keywords:
- exemples
- exigences logicielles
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Exécutez rapidement les exemples d'Aspose.Slides pour .NET: clonez le dépôt, restaurez les packages, puis compilez et testez les fonctionnalités pour PPT, PPTX et ODP."
---

## **Exigences logicielles**
Avant de télécharger et d'exécuter les exemples, veuillez vérifier et confirmer que votre configuration répond à ces exigences :

- Visual Studio 2010 ou supérieur.
- Gestionnaire de packages NuGet installé dans Visual Studio. Vérifiez que la dernière version de l'API NuGet est installée dans Visual Studio.

Pour les instructions d'installation du gestionnaire de packages NuGet, consultez cette page : https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Accédez à **Tools** > **Options** > **NuGet Package Manager**.

1. Développez **NuGet Package Manager** (en double-cliquant dessus) puis sélectionnez **Package Sources**.

1. Vérifiez et confirmez que le paramètre nuget.org est sélectionné.

   Le projet d'exemple utilise la fonctionnalité de restauration automatique des packages NuGet, vous devez donc disposer d'une connexion Internet active.

   Si vous n'avez pas de connexion Internet active sur la machine où vous prévoyez d'exécuter les exemples, veuillez consulter [Installation](https://docs.aspose.com/slides/net/installation/) et ajouter (manuellement) une référence à Aspose.Slides.dll dans le projet d'exemple.

## **Télécharger depuis GitHub**
Tous les exemples Aspose.Slides pour .NET sont hébergés sur [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Vous pouvez soit cloner le dépôt avec votre client GitHub préféré, soit télécharger le fichier ZIP [ici](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Si vous téléchargez le fichier ZIP, vous devez extraire son contenu dans un dossier sur votre ordinateur.

Tous les exemples sont stockés dans le dossier **Examples**.

Il existe un fichier de solution Visual Studio C#. Les projets ont été créés dans Visual Studio 2013, mais les fichiers de solution sont compatibles avec Visual Studio 2010 SP1 et versions ultérieures.

2. Ouvrez le fichier de solution dans Visual Studio et construisez le projet.

   Lors de la première exécution, les dépendances sont téléchargées automatiquement via NuGet.

Le dossier **Data** à la racine du dossier **Examples** contient les fichiers d'entrée utilisés dans les exemples C#. Vous devez télécharger le dossier **Data** avec le projet d'exemples.

3. Ouvrez le fichier RunExamples.cs. Tous les exemples sont appelés depuis cet endroit.

4. Décommentez les exemples que vous souhaitez exécuter dans le projet.

N'hésitez pas à nous contacter via nos forums si vous avez des problèmes pour installer ou exécuter les exemples.

## **Contribuer**
Vous pouvez contribuer au projet en ajoutant ou en améliorant un exemple. Tous les exemples et projets de démonstration du dépôt sont open source, vous (et d'autres personnes) pouvez donc les utiliser librement dans vos applications.

Pour contribuer, vous pouvez forker le dépôt, modifier le code source et créer une pull request. Nous examinerons les modifications. Si nous les trouvons utiles, nous les ajouterons au dépôt.
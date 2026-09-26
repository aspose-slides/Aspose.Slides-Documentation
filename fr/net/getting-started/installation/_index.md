---
title: Installation
type: docs
weight: 70
url: /fr/net/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation d'Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Installez Aspose.Slides pour .NET depuis NuGet sur Windows, Linux et macOS : choisissez entre les deux packages, ajoutez‑en un avec la CLI .NET ou Visual Studio, et installez les prérequis Linux."
---
## **Vue d’ensemble**

Cet article explique comment ajouter Aspose.Slides for .NET à un projet sous Windows, Linux et macOS. Aspose.Slides est distribué via NuGet. Vous pouvez l’ajouter avec la CLI .NET sur n’importe quel système d’exploitation, ou avec le Gestionnaire de packages NuGet ou la console du Gestionnaire de packages dans Visual Studio sous Windows. L’article explique également lequel des deux packages NuGet choisir et ce dont Linux a besoin en supplément.

Avant l’installation, consultez les systèmes d’exploitation pris en charge, les implémentations .NET et les dépendances supplémentaires dans [Exigences du système](/slides/fr/net/system-requirements/).

## **Choisir un package**

Aspose.Slides for .NET est publié sous deux packages NuGet. Les deux offrent les mêmes espaces de noms et classes Aspose.Slides, de sorte que votre code ne change pas lorsque vous passez de l’un à l’autre ; seule la référence du package et les exigences de plateforme diffèrent.

| Package | Utilisation | Exigences supplémentaires |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Applications Windows et .NET Framework | Sous Linux et macOS : la bibliothèque `libgdiplus` et le commutateur `System.Drawing.EnableUnixSupport` activé au démarrage de l’application |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 ou version ultérieure sous Windows, Linux et macOS | Sous Linux : la bibliothèque `fontconfig`, si elle n’est pas déjà installée |

Si vous n’êtes pas sûr, utilisez Aspose.Slides.NET sous Windows et Aspose.Slides.NET6.CrossPlatform sous Linux et macOS. Sous Alpine Linux, ainsi que sur les systèmes Linux dont la glibc est antérieure à 2.23 (x64) ou 2.39 (ARM64), utilisez Aspose.Slides.NET à la place. [Exigences du système](/slides/fr/net/system-requirements/) répertorie les plateformes prises en charge pour chaque package.

## **Installer avec la CLI .NET**

Ces étapes fonctionnent sous Windows, Linux et macOS avec le SDK .NET 6 ou supérieur. Créez une application console :

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ajoutez ensuite le package correspondant à votre plateforme. N’ajoutez qu’un seul des deux packages à un projet.

- Sur Windows : `dotnet add package Aspose.Slides.NET`
- Sur Linux et macOS : `dotnet add package Aspose.Slides.NET6.CrossPlatform` (sur Linux, installez d’abord son prérequis ; voir [Linux](#linux))

Pour vérifier que le package fonctionne, remplacez le contenu de *Program.cs* par le premier exemple de [Créer des présentations](/slides/fr/net/create-presentation/) et exécutez `dotnet run`. Il enregistre *hello.pptx* dans le dossier du projet.

## **Windows**

### **Méthode 1 : Installer ou mettre à jour Aspose.Slides depuis le Gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio.
2. Créez une application console ou ouvrez un projet existant.
3. Dans **Solution Explorer**, cliquez avec le bouton droit sur le projet et sélectionnez **Manage NuGet Packages** (ou allez dans **Project** > **Manage NuGet Packages**).
4. Sous **Browse**, recherchez *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Cliquez sur **Aspose.Slides.NET** puis cliquez sur **Install**.
   * Si vous avez déjà installé Aspose.Slides et que vous souhaitez le mettre à jour, cliquez sur **Update** à la place.

Le package est téléchargé et référencé dans votre projet.

### **Méthode 2 : Installer ou mettre à jour Aspose.Slides via la console du Gestionnaire de packages**

Voici comment référencer le [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) via la console du Gestionnaire de packages :

1. Ouvrez Microsoft Visual Studio.
2. Créez une application console ou ouvrez un projet existant.
3. Allez dans **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Ouverture de la console du Gestionnaire de packages](installation_2.png)
4. Exécutez cette commande : `Install-Package Aspose.Slides.NET`
![Exécution de la commande Install-Package](installation_3.png)
La dernière version est installée dans votre projet.

Le message **Installing Aspose.Slides.NET** apparaît en bas de la fenêtre.
![Progression de l’installation dans la console du Gestionnaire de packages](installation_4.png)

Lorsque le téléchargement est terminé, des messages de confirmation s’affichent. Le package est distribué sous la [Aspose EULA](https://about.aspose.com/legal/eula).
![Messages de confirmation d’installation](installation_5.png)

Aspose.Slides est désormais ajouté à votre projet et référencé.
![Aspose.Slides référencé dans le projet](installation_6.png)

Pour mettre à jour le package, exécutez `Update-Package Aspose.Slides.NET` dans la console du Gestionnaire de packages.

## **Linux**

Utilisez les étapes de la CLI .NET ci‑dessus. Choisissez le package et installez son prérequis avec le gestionnaire de paquets de votre distribution. Sur Debian et Ubuntu :

- **Aspose.Slides.NET6.CrossPlatform** : installez `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
```

- **Aspose.Slides.NET** : installez `libgdiplus` et activez le support Unix pour System.Drawing avant que votre application n’utilise Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
```

Ajoutez cette instruction au démarrage de votre application, avant tout appel à Aspose.Slides. Dans un *Program.cs* avec des instructions de niveau supérieur, placez‑la après les directives `using` :

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

Utilisez ce package sur Alpine Linux, ainsi que sur les systèmes dont la glibc est trop ancienne pour Aspose.Slides.NET6.CrossPlatform.

Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent être installées sur le système pour que le texte s’affiche correctement. [Exigences du système](/slides/fr/net/system-requirements/) décrit les packages requis par Aspose.Slides.NET sur Alpine Linux, y compris les polices.

## **macOS**

Utilisez les étapes de la CLI .NET ci‑dessus avec le package **Aspose.Slides.NET6.CrossPlatform**, qui prend en charge les Mac Intel (x86_64) et Apple silicon (ARM64) :

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui. Sans licence, Aspose.Slides s’exécute en mode évaluation : il ajoute un filigrane d’évaluation à chaque diapositive enregistrée et tronque le texte lu depuis les présentations. Pour supprimer ces limitations, appliquez une [licence](/slides/fr/net/licensing/).
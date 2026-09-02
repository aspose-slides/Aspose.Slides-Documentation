---
title: Installation
type: docs
weight: 70
url: /fr/net/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à installer rapidement Aspose.Slides pour .NET. Guide étape par étape, exigences du système et exemples de code — commencez à travailler avec des présentations PowerPoint dès aujourd'hui!"
---
## **Vue d’ensemble**

Cet article explique comment installer Aspose.Slides pour .NET sur Windows, Linux et macOS. Il se concentre sur l’installation via NuGet et montre comment ajouter la bibliothèque via le Gestionnaire de packages NuGet ou la Console du gestionnaire de packages sous Windows, à un projet .NET sous Linux, et à un projet Visual Studio sur macOS. Il décrit également comment mettre à jour le package et installer des versions préliminaires lorsque cela est nécessaire.

Avant l’installation, consultez les systèmes d’exploitation pris en charge, les implémentations .NET et les dépendances supplémentaires dans [Exigences du système](/slides/fr/net/system-requirements/).

## **Windows**
NuGet offre le moyen le plus simple de télécharger et d’installer les API Aspose pour .NET sur les PC. 

### **Méthode 1 : Installer ou mettre à jour Aspose.Slides via le Gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Accédez à **Tools** > **NuGet package manager**.  
4. Sous **Browse**, recherchez *Aspose Slides* dans le champ texte.  
{{% image img="installation_1.png" alt="Installation d'Aspose.Slides via le Gestionnaire de packages NuGet – 1" %}}
5. Cliquez sur **Aspose.Slides.NET** puis sur **Install**.  
   * Si vous souhaitez mettre à jour Aspose.Slides—en supposant qu’il soit déjà installé—cliquez sur **Update** à la place.  

L’API sélectionnée est téléchargée et référencée dans votre projet.

### **Méthode 2 : Installer ou mettre à jour Aspose.Slides via la Console du gestionnaire de packages**

Voici comment référencer l’[API Aspose.Slides](https://www.nuget.org/packages/Aspose.Slides.NET/) via la console du gestionnaire de packages :

1. Ouvrez Microsoft Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Accédez à **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Exécutez cette commande : `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
La dernière version complète est installée dans votre application.  

* Vous pouvez également ajouter le suffixe `-prerelease` à la commande pour spécifier que la version la plus récente (correctifs inclus) doit être installée.

L’info-bulle **Installing Aspose.Slides.NET** apparaît en bas de la fenêtre.  
![todo:image_alt_text](installation_4.png)

Lorsque le téléchargement est terminé, vous verrez plusieurs messages de confirmation.  

Si vous n’êtes pas familier avec l’[EULA d’Aspose](https://about.aspose.com/legal/eula), vous pouvez consulter la licence indiquée dans l’URL.  
![todo:image_alt_text](installation_5.png)

Dans votre application, vous constaterez qu’Aspose.Slides a été ajouté et référencé avec succès.  
![todo:image_alt_text](installation_6.png)

Dans la Console du gestionnaire de packages, vous pouvez exécuter la commande `Update-Package Aspose.Slides.NET` pour rechercher les mises à jour du package Aspose.Slides. Les mises à jour (le cas échéant) sont installées automatiquement. Vous pouvez également utiliser le suffixe `-prerelease` pour mettre à jour la dernière version.

#### **Considérations lors de l’exécution dans un environnement serveur partagé**
Nous vous recommandons fortement d’exécuter tous les composants Aspose .NET avec le jeu d’autorisations **Full Trust**, car les composants Aspose doivent parfois accéder aux paramètres du registre et aux fichiers situés en dehors du répertoire virtuel—par exemple, lorsqu’ils doivent lire des polices.

De plus, les composants Aspose.NET sont basés sur les classes système fondamentales de .NET — et certaines de ces classes requièrent également l’autorisation Full Trust dans certains cas.

Les fournisseurs d’accès Internet, qui hébergent plusieurs applications provenant de différentes entreprises, appliquent généralement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, ce niveau de sécurité peut entraîner des contraintes qui affectent les opérations d’Aspose.Slides :

- **RegistryPermission** n’est pas disponible. Vous ne pouvez donc pas accéder au registre, ce qui est nécessaire pour l’énumération des polices installées lors du rendu de documents.  
- **FileIOPermission** est restreint. Vous ne pouvez accéder qu’aux fichiers de la hiérarchie du répertoire virtuel de votre application. Cela peut également empêcher la lecture des polices lors des opérations d’exportation.  

Pour les raisons ci‑dessus, nous vous recommandons vivement d’exécuter Aspose.Slides avec les autorisations **Full Trust**. Si vous utilisez **Medium trust**, vous pourriez rencontrer des incohérences — certaines fonctionnalités de la bibliothèque (par exemple le rendu) pourraient ne pas fonctionner lors de certaines tâches.  

## **Linux**

NuGet offre le moyen le plus simple de télécharger et d’installer Aspose.Slides pour .NET sur Linux. Ajoutez le package [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) à votre projet .NET.

## **macOS**

NuGet offre le moyen le plus simple de télécharger et d’installer Aspose.Slides pour .NET sur les Mac.

### **Installer Aspose.Slides**

1. Ouvrez Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Accédez à **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Saisissez *Aspose.Slides* dans le champ texte.  
5. Cliquez sur **Aspose.Slides for .NET** puis sur **Add Package**.  
6. Ajoutez un extrait de code simple.  
   * Vous pouvez copier le code sur [cette page](/slides/fr/net/create-presentation/).  
7. Exécutez l’application.  
8. Ouvrez le *folder/bin/Debug/presentation_file_name* de votre projet.  

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui, par défaut, Aspose.Slides s’exécute en mode évaluation, ce qui ajoute des filigranes et peut comporter d’autres limitations. Pour supprimer ces restrictions, vous devez appliquer une [licence](/slides/fr/net/licensing/) valide.
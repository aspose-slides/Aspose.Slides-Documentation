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
description: "Apprenez à installer rapidement Aspose.Slides pour .NET. Guide étape par étape, exigences système et exemples de code — commencez dès aujourd'hui à travailler avec des présentations PowerPoint!"
---

## **Windows**
NuGet offre le moyen le plus simple de télécharger et d’installer les API Aspose pour .NET sur PC. 

### **Méthode 1 : Installer ou mettre à jour Aspose.Slides depuis le gestionnaire de paquets NuGet**

1. Ouvrez Microsoft Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Passez par **Tools** > **NuGet package manager**.  
4. Sous **Browse**, recherchez *Aspose Slides* dans le champ de texte.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Cliquez sur **Aspose.Slides.NET** puis cliquez sur **Install**.  
   * Si vous souhaitez mettre à jour Aspose.Slides—en supposant qu’il soit déjà installé—cliquez sur **Update** à la place.  

L’API sélectionnée est téléchargée et référencée dans votre projet.

### **Méthode 2 : Installer ou mettre à jour Aspose.Slides via la console du gestionnaire de paquets**

Voici comment référencer [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via la console du gestionnaire de paquets :

1. Ouvrez Microsoft Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Passez par **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Exécutez cette commande : `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
La dernière version complète est installée dans votre application.  

* Vous pouvez également ajouter le suffixe `-prerelease` à la commande pour spécifier que la version la plus récente (correctifs inclus) doit être installée.

 L’astuce **Installing Aspose.Slides.NET** apparaît en bas de la fenêtre.  
![todo:image_alt_text](installation_4.png)

Une fois le téléchargement terminé, vous verrez des messages de confirmation. 

Si vous n’êtes pas familier avec [Aspose EULA](https://about.aspose.com/legal/eula), vous pouvez lire la licence référencée dans l’URL.  
![todo:image_alt_text](installation_5.png)

Dans votre application, vous verrez qu’Aspose.Slides a été ajouté et référencé avec succès.  
![todo:image_alt_text](installation_6.png)

Dans la console du gestionnaire de paquets, vous pouvez exécuter la commande `Update-Package Aspose.Slides.NET` pour vérifier les mises à jour du package Aspose.Slides. Les mises à jour (si elles existent) sont installées automatiquement. Vous pouvez également utiliser le suffixe `-prerelease` pour mettre à jour vers la version la plus récente.  
#### **Considérations lors de l’exécution sur un serveur partagé**
Nous recommandons vivement d’exécuter tous les composants Aspose .NET avec le jeu d’autorisations **Full Trust** car les composants Aspose doivent parfois accéder aux paramètres du registre et à des fichiers situés en dehors du répertoire virtuel—par exemple, lorsque les composants Aspose doivent lire des polices.  

De plus, les composants Aspose.NET sont basés sur les classes système cœur de .NET—et certaines de ces classes requièrent également l’autorisation Full Trust pour certaines opérations.  

Les fournisseurs d’accès à Internet, qui hébergent plusieurs applications de différentes entreprises, imposent généralement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, ce niveau de sécurité peut entraîner des restrictions affectant les opérations d’Aspose.Slides :

- **RegistryPermission** n’est pas disponible. Vous ne pouvez donc pas accéder au registre, ce qui est nécessaire pour répertorier les polices installées lors du rendu de documents.  
- **FileIOPermission** est limité. Vous ne pouvez accéder qu’aux fichiers de la hiérarchie du répertoire virtuel de votre application. Cela peut également empêcher la lecture des polices lors des exportations.  

Pour les raisons ci‑dessus, nous recommandons fortement d’exécuter Aspose.Slides avec les autorisations **Full Trust**. Si vous utilisez **Medium trust**, vous pourriez rencontrer des incohérences—certaines fonctionnalités de la bibliothèque (rendu, par exemple) pourraient ne pas fonctionner lors de certaines tâches.  

## **macOS**

NuGet offre le moyen le plus simple de télécharger et d’installer Aspose.Slides pour .NET sur Mac. 

**Installer les prérequis**

L’espace de noms `System.Drawing` fonctionne différemment sous macOS, vous devez donc installer mono-libgdiplus.  

> Dans .NET 5 et les versions précédentes, le package NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) fonctionne sous Windows, Linux et macOS. Cependant, il existe des différences de plateforme. Sous Linux et macOS, la fonctionnalité GDI+ est implémentée par la bibliothèque [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). Cette bibliothèque n’est pas installée par défaut dans la plupart des distributions Linux et ne prend pas en charge toutes les fonctionnalités de GDI+ sous Windows et macOS. Certaines plateformes n’offrent même pas libgdiplus. Pour utiliser les types du package System.Drawing.Common sous Linux et macOS, vous devez installer libgdiplus séparément. Pour plus d’informations, consultez [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) ou [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).  

Pour installer mono-libgdiplus séparément sur votre Mac, consultez [cet article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentation .NET.  

### **Installer Aspose.Slides**

1. Ouvrez Visual Studio.  
2. Créez une application console simple ou ouvrez un projet existant.  
3. Passez par **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Saisissez *Aspose.Slides* dans le champ de texte.  
5. Cliquez sur **Aspose.Slides for .NET** puis cliquez sur **Add Package**.  
6. Ajoutez un extrait de code simple.  
   * Vous pouvez copier le code sur [this page](/slides/fr/net/create-presentation/).  
7. Exécutez l’application.  
8. Ouvrez le *folder/bin/Debug/presentation_file_name* de votre projet.  

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui, par défaut, Aspose.Slides fonctionne en mode d’évaluation, ce qui ajoute des filigranes et peut imposer d’autres limitations. Pour supprimer ces restrictions, vous devez appliquer une [license](/slides/fr/net/licensing/) valide.
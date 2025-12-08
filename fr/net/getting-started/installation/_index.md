---
title: Installation
type: docs
weight: 70
url: /fr/net/installation/
keywords: "Télécharger Aspose.Slides, Installer Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, .NET"
description: "Installer Aspose.Slides pour .NET sous Windows ou macOS"
---

## **Windows**
NuGet offre le moyen le plus simple de télécharger et d'installer les API Aspose pour .NET sur les PC. 

### **Méthode 1 : Installer ou Mettre à jour Aspose.Slides depuis le Gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio. 
2. Créez une application console simple ou ouvrez un projet existant. 
3. Passez par **Outils** > **Gestionnaire de packages NuGet**.
4. Sous **Parcourir**, recherchez *Aspose Slides* dans le champ de texte. 
{{% image img="installation_1.png" alt="Installation d'Aspose.Slides depuis le Gestionnaire de packages NuGet - 1" %}}
5. Cliquez sur **Aspose.Slides.NET** puis cliquez sur **Installer**. 
   * Si vous souhaitez mettre à jour Aspose.Slides—en supposant que vous l’avez déjà installé—cliquez sur **Mettre à jour** à la place. 

L’API sélectionnée est téléchargée et référencée dans votre projet.

### **Méthode 2 : Installer ou Mettre à jour Aspose.Slides via la console du Gestionnaire de packages**

Voici comment référencer [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) via la console du gestionnaire de packages :

1. Ouvrez Microsoft Visual Studio. 
2. Créez une application console simple ou ouvrez un projet existant. 
3. Passez par **Outils** > **Gestionnaire de bibliothèques** > **Console du Gestionnaire de packages**. 
![todo:image_alt_text](installation_2.png)
4. Exécutez cette commande : `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
La dernière version complète est installée dans votre application. 

* Vous pouvez également ajouter le suffixe `-prerelease` à la commande pour indiquer que la dernière version (correctifs inclus) doit également être installée.

L’info-bulle **Installing Aspose.Slides.NET** apparaît près du bas de la fenêtre. 
![todo:image_alt_text](installation_4.png)

Une fois le téléchargement terminé, vous devriez voir quelques messages de confirmation. 

Si vous n'êtes pas familiarisé avec la [EULA d'Aspose](https://about.aspose.com/legal/eula), vous voudrez peut-être lire la licence référencée dans l'URL. 
![todo:image_alt_text](installation_5.png)

Dans votre application, vous devriez voir qu'Aspose.Slides a été ajouté et référencé avec succès. 
![todo:image_alt_text](installation_6.png)

Dans la Console du Gestionnaire de packages, vous pouvez exécuter la commande `Update-Package Aspose.Slides.NET` pour vérifier les mises à jour du package Aspose.Slides. Les mises à jour (si trouvées) sont installées automatiquement. Vous pouvez également utiliser le suffixe `-prerelease` pour mettre à jour la dernière version.
#### **Considérations lors de l'exécution sur un environnement serveur partagé**
Nous vous recommandons fortement d'exécuter tous les composants Aspose .NET avec le jeu d'autorisations **Full Trust** car les composants Aspose ont parfois besoin d'accéder aux paramètres du registre et aux fichiers situés en dehors du répertoire virtuel—par exemple, lorsque les composants Aspose doivent lire les polices. 

De plus, les composants Aspose.NET sont basés sur les classes système .NET de base—et certaines de ces classes exigent également l'autorisation **Full Trust** pour certaines opérations. 

Les fournisseurs d'accès à Internet, qui hébergent plusieurs applications de différentes sociétés, imposent généralement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, ce niveau de sécurité peut entraîner des contraintes affectant les opérations d'Aspose.Slides :

- **RegistryPermission** n’est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre, ce qui est nécessaire pour lister les polices installées lors du rendu des documents. 
- **FileIOPermission** est restreint. Cela signifie que vous ne pouvez accéder qu'aux fichiers dans la hiérarchie du répertoire virtuel de votre application. Cela implique également que les polices ne puissent être lues lors des opérations d'exportation. 

Pour les raisons ci‑dessus, nous recommandons fortement d'exécuter Aspose.Slides avec les autorisations **Full Trust**. Si vous utilisez **Medium Trust**, vous pourriez rencontrer des incohérences—certaines fonctionnalités de la bibliothèque (rendu, par exemple) pourraient ne pas fonctionner lors de certaines tâches. 

## **macOS**

NuGet offre le moyen le plus simple de télécharger et d'installer Aspose.Slides pour .NET sur les Mac. 

**Pré‑requis d'installation**

L'espace de noms `System.Drawing` fonctionne différemment sous macOS, vous devez donc installer mono-libgdiplus. 

> In .NET 5 and previous versions, the [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet package works on Windows, Linux, and macOS. However, there are some platform differences. On Linux and macOS, the GDI+ functionality is implemented by the [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) library. This library is not installed by default in most Linux distributions and doesn't support all the functionality of GDI+ on Windows and macOS. There are also platforms where libgdiplus is not available at all. To use types from the System.Drawing.Common package on Linux and macOS, you must install libgdiplus separately. For more information, see [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) or [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

Pour installer mono-libgdiplus séparément sur votre Mac, consultez [cet article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentation .NET. 

### **Installer Aspose.Slides**

1. Ouvrez Visual Studio. 
2. Créez une application console simple ou ouvrez un projet existant.
3. Passez par **Projet** > **Gérer les packages NuGet...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Tapez *Aspose.Slides* dans le champ de texte. 
5. Cliquez sur **Aspose.Slides for .NET** puis cliquez sur **Ajouter le package**. 
6. Ajoutez un extrait de code simple.
   * Vous pouvez copier le code sur [cette page](/slides/fr/net/create-presentation/).
7. Exécutez l’application.
8. Ouvrez *folder/bin/Debug/presentation_file_name* de votre projet.

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui, par défaut, Aspose.Slides fonctionne en mode évaluation, ce qui ajoute des filigranes et peut comporter d'autres limitations. Pour supprimer les restrictions, vous devez appliquer une [licence](/slides/fr/net/licensing/) valide.
---
title: Installation
type: docs
weight: 70
url: /net/installation/
keywords: "Télécharger Aspose.Slides, Installer Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, .NET"
description: "Installer Aspose.Slides pour .NET sur Windows ou macOS"
---

## **Windows**
NuGet fournit le moyen le plus simple de télécharger et d'installer les API Aspose pour .NET sur PC.

### **Méthode 1 : Installer ou mettre à jour Aspose.Slides depuis le Gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio.
2. Créez une application console simple ou ouvrez un projet existant.
3. Allez dans **Outils** > **Gestionnaire de packages NuGet**.
4. Sous **Parcourir**, recherchez *Aspose Slides* dans le champ de texte.
{{% image img="installation_1.png" alt="Installation d'Aspose.Slides depuis le Gestionnaire de packages NuGet - 1" %}}
5. Cliquez sur **Aspose.Slides.NET** et cliquez ensuite sur **Installer**.
   * Si vous souhaitez mettre à jour Aspose.Slides—en supposant que vous l'ayez déjà installé—cliquez plutôt sur **Mettre à jour**.

L'API sélectionnée est téléchargée et référencée dans votre projet.

### **Méthode 2 : Installer ou mettre à jour Aspose.Slides via la Console du Gestionnaire de packages**

Voici comment référencer [l'API Aspose.Slides](https://www.nuget.org/packages/Aspose.Slides.NET/) via la console du gestionnaire de packages :

1. Ouvrez Microsoft Visual Studio.
2. Créez une application console simple ou ouvrez un projet existant.
3. Allez dans **Outils** > **Gestionnaire de packages bibliothèque** > **Console du Gestionnaire de packages**.
![todo:image_alt_text](installation_2.png)
4. Exécutez cette commande : `Install-Package Aspose.Slides.NET`
![todo:image_alt_text](installation_3.png)
La dernière version complète est installée dans votre application.

* Alternativement, vous pouvez ajouter le suffixe `-prerelease` à la commande pour spécifier que la dernière version (y compris les correctifs) doit également être installée.

Le conseil **Installation d'Aspose.Slides.NET** apparaît en bas de la fenêtre.
![todo:image_alt_text](installation_4.png)

Une fois le téléchargement terminé, vous devriez voir des messages de confirmation.

Si vous n'êtes pas familier avec [l'EULA d'Aspose](https://about.aspose.com/legal/eula), vous voudrez peut-être lire la licence référencée dans l'URL.
![todo:image_alt_text](installation_5.png)

Dans votre application, vous devriez voir qu'Aspose.Slides a été ajouté et référencé avec succès.
![todo:image_alt_text](installation_6.png)

Dans la Console du Gestionnaire de packages, vous pouvez exécuter la commande `Update-Package Aspose.Slides.NET` pour vérifier les mises à jour du package Aspose.Slides. Les mises à jour (si elles sont trouvées) sont installées automatiquement. Vous pouvez également utiliser le suffixe `-prerelease` pour mettre à jour la dernière version.
#### **Considérations lors de l'exécution dans un environnement de serveur partagé**
Nous vous recommandons fortement d'exécuter tous les composants Aspose .NET avec le paramètre de permission **Full Trust** car les composants Aspose ont parfois besoin d'accéder aux paramètres du registre et aux fichiers situés dans des endroits autres que le répertoire virtuel—par exemple, lorsque les composants Aspose doivent lire des polices.

De plus, les composants Aspose.NET sont basés sur les classes de système .NET de base—et certaines de ces classes nécessitent également des permissions Full Trust pour des opérations dans certains cas.

Les fournisseurs de services Internet, qui hébergent plusieurs applications de différentes entreprises, appliquent principalement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, un tel niveau de sécurité peut entraîner des contraintes qui affectent les opérations d'Aspose.Slides :

- **RegistryPermission** n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre, ce qui est nécessaire pour énumérer les polices installées lors du rendu de documents.
- **FileIOPermission** est restreint. Cela signifie que vous ne pouvez accéder qu'aux fichiers de la hiérarchie de répertoires virtuels de votre application. Cela signifie également qu'il se peut que les polices ne puissent pas être lues lors des opérations d'exportation.

Pour les raisons ci-dessus, nous vous recommandons fortement d'exécuter Aspose.Slides avec des permissions **Full Trust**. Si vous utilisez **Medium trust,** vous pourriez rencontrer des incohérences—certaines fonctionnalités de la bibliothèque (rendu, par exemple) pourraient ne pas fonctionner lorsque vous effectuez certaines tâches.

## **macOS**

NuGet fournit le moyen le plus simple de télécharger et d'installer Aspose.Slides pour .NET sur les Macs.

**Installer le Prérequis**

L'espace de noms `System.Drawing` fonctionne différemment sur macOS, donc vous devez installer mono-libgdiplus.

> Dans .NET 5 et les versions antérieures, le package NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) fonctionne sur Windows, Linux et macOS. Cependant, il y a quelques différences de plateforme. Sur Linux et macOS, la fonctionnalité GDI+ est implémentée par la bibliothèque [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Cette bibliothèque n'est pas installée par défaut dans la plupart des distributions Linux et ne prend pas en charge toutes les fonctionnalités de GDI+ sur Windows et macOS. Il existe également des plateformes où libgdiplus n'est pas disponible du tout. Pour utiliser des types du package System.Drawing.Common sur Linux et macOS, vous devez installer libgdiplus séparément. Pour plus d'informations, voir [Installer .NET sur Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) ou [Installer .NET sur macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

Pour installer mono-libgdiplus séparément sur votre Mac, voir [cet article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentation .NET.

### **Installer Aspose.Slides**

1. Ouvrez Visual Studio.
2. Créez une application console simple ou ouvrez un projet existant.
3. Allez dans **Projet** > **Gérer les packages NuGet...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Tapez *Aspose.Slides* dans le champ de texte.
5. Cliquez sur **Aspose.Slides pour .NET** et cliquez ensuite sur **Ajouter le package.**
6. Ajoutez un extrait de code simple.
   * Vous pouvez copier le code sur [cette page](/slides/net/create-presentation/).
7. Exécutez l'application.
8. Ouvrez le dossier de votre projet *folder/bin/Debug/presentation_file_name*.
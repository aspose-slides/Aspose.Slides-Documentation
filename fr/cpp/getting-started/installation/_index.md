---
title: Installation
type: docs
weight: 70
url: /fr/cpp/installation/
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
- C++
- Aspose.Slides
description: "Découvrez comment installer rapidement Aspose.Slides pour C++. Guide pas à pas, exigences système et exemples de code - commencez à travailler avec des présentations PowerPoint dès aujourd'hui!"
---

## **Windows**
NuGet offre le moyen le plus simple pour télécharger et installer les API Aspose pour C++ sur les PC. 

### **Option 1 : Installer ou mettre à jour Aspose.Slides pour C++ depuis le gestionnaire de packages NuGet**

1. Ouvrez Microsoft Visual Studio.  
2. Créez une application console simple. Vous pouvez également ouvrir votre projet préféré.  
3. Accédez à **Tools** > **NuGet package manager**.  
4. Sous **Browse**, tapez *Aspose.Slides.Cpp* dans le champ de texte.  

![todo:image_alt_text](installation_1.png)

3. Cliquez sur la version dont vous avez besoin **Aspose.Slides.Cpp** puis cliquez sur **Install**.  
   * Si vous souhaitez mettre à jour Aspose.Slides — ce qui signifie qu'il est déjà installé — cliquez sur **Update**.  

L'API sélectionnée est téléchargée et référencée dans votre projet.

### **Option 2 : Installer ou mettre à jour Aspose.Slides via la console du gestionnaire de packages**

Pour référencer l'API Aspose.Slides via la console du gestionnaire de packages, procédez ainsi :

1. Ouvrez votre solution/projet dans Visual Studio.  

1. Accédez à **Tools** > **NuGet Package Manager** > **Package Manager Console**.  

   La console du gestionnaire de packages s'ouvre.  

![todo:image_alt_text](installation_2.png)

4. Tapez cette commande : `Install-Package Aspose.Slides.Cpp`  
> Si vous voulez installer la version x86, utilisez le package Aspose.Slides.Cpp.x86 : `Install-Package Aspose.Slides.Cpp.x86`

5. Appuyez sur la touche Entrée.  

   La dernière version complète est installée dans votre application.  

   * Alternativement, vous pouvez ajouter le suffixe `-prerelease` à la commande pour indiquer que la dernière version (y compris les correctifs) doit également être installée.  

![todo:image_alt_text](installation_3.png)

​	Une fois le téléchargement terminé, vous devriez voir quelques messages de confirmation.  

![todo:image_alt_text](installation_4.png)

Si vous ne connaissez pas le contrat de licence Aspose (EULA), vous voudrez peut-être lire la licence référencée dans l’URL.  

Dans la console du gestionnaire de packages, vous pouvez exécuter la commande `Update-Package Aspose.Slides.Cpp` pour vérifier les mises à jour du package Aspose.Slides. Les mises à jour (si trouvées) sont installées automatiquement. Vous pouvez également utiliser le suffixe `-prerelease` pour mettre à jour la dernière version.

### **Utilisation des dossiers Include et lib**
1. [Download](https://downloads.aspose.com/slides/cpp) la dernière version d'Aspose.Slides pour C++.  
1. Décompressez le dossier dans l'environnement de production.  
1. Pour utiliser Aspose.Slides pour C++, référencez les dossiers Include et lib dans votre projet  

## **FAQ**

**Existe-t-il une version gratuite ou une limitation d'essai ?**

Oui, par défaut, Aspose.Slides fonctionne en mode d'évaluation, ce qui ajoute des filigranes et peut comporter d'autres limitations. Pour supprimer ces restrictions, vous devez appliquer une [license](/slides/fr/cpp/licensing/).
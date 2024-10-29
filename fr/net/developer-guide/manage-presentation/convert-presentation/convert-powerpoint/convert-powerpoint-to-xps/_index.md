---
title: Convertir PowerPoint en XPS 
type: docs
weight: 70
url: /fr/net/convert-powerpoint-to-xps
keywords: "Convertir Présentation PowerPoint, PowerPoint en XPS, PPT en XPS, PPTX en XPS, Conversion, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir la présentation PowerPoint en XPS en C# ou .NET."
---

## **À propos de XPS**
Microsoft a développé [XPS](https://docs.fileformat.com/page-description-language/xps/) comme une alternative au [PDF](https://docs.fileformat.com/pdf/). Il vous permet d'imprimer du contenu en produisant un fichier très similaire à un PDF. Le format XPS est basé sur XML. La mise en page ou la structure d'un fichier XPS reste la même sur tous les systèmes d'exploitation et toutes les imprimantes. 

## Quand utiliser le format Microsoft XPS

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit une présentation PPT ou PPTX en format XPS, vous pouvez consulter [cette application de conversion en ligne gratuite](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si vous souhaitez réduire les coûts de stockage, vous pouvez convertir votre présentation Microsoft PowerPoint en format XPS. De cette manière, vous trouverez plus facile de sauvegarder, partager et imprimer vos documents. 

Microsoft continue à mettre en œuvre un fort soutien pour XPS dans Windows (même dans Windows 10), donc vous pouvez envisager de sauvegarder des fichiers dans ce format. Si vous utilisez Windows 8.1, Windows 8, Windows 7 et Windows Vista, alors XPS pourrait en fait être votre meilleure option pour certaines opérations. 

- **Windows 8** utilise le format OXPS (Open XPS) pour les fichiers XPS. OXPS est une version standardisée du format XPS original. Windows 8 offre un meilleur support pour les fichiers XPS que pour les fichiers PDF. 
  - **XPS :** Visionneuse/lecteur XPS intégré et fonctionnalité d'impression vers XPS disponible. 
  - **PDF** : Lecteur PDF disponible mais pas de fonctionnalité d'impression vers PDF. 

- **Windows 7 et Windows Vista** utilisent le format XPS original. Ces systèmes d'exploitation offrent également un meilleur support pour les fichiers XPS que pour les PDF. 
  - **XPS :** Visionneuse XPS intégrée et fonctionnalité d'impression vers XPS disponible. 
  - **PDF :** Pas de lecteur PDF. Pas de fonctionnalité d'impression vers PDF. 

|<p>**Entrée PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Sortie XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft a finalement mis en œuvre le support des opérations d'impression en PDF grâce à la fonctionnalité Imprimer en PDF dans Windows 10. Auparavant, les utilisateurs étaient censés imprimer des documents via le format XPS. 

## Conversion XPS avec Aspose.Slides

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/) pour .NET, vous pouvez utiliser la méthode [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour convertir l'ensemble de la présentation en document XPS. 

Lors de la conversion d'une présentation en XPS, vous devez enregistrer la présentation en utilisant l'un de ces paramètres :

- Paramètres par défaut (sans [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Paramètres personnalisés (avec [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Conversion de Présentations en XPS en Utilisant les Paramètres par Défaut**

Ce code exemple en C# vous montre comment convertir une présentation en document XPS en utilisant des paramètres standard :

```c#
// Instancier un objet Presentation représentant un fichier de présentation
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Sauvegarder la présentation dans un document XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Conversion de Présentations en XPS en Utilisant des Paramètres Personnalisés**
Ce code exemple vous montre comment convertir une présentation en document XPS en utilisant des paramètres personnalisés en C# :

```c#
// Instancier un objet Presentation représentant un fichier de présentation
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instancier la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Sauvegarder les MetaFiles en tant que PNG
    options.SaveMetafilesAsPng = true;

    // Sauvegarder la présentation dans un document XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```
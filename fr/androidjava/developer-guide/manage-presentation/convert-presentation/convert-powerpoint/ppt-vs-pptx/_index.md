---
title: PPT vs PPTX
type: docs
weight: 10
url: /fr/androidjava/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lisez les différences entre PPT et PPTX dans Aspose.Slides."
---


## **Qu'est-ce que le PPT ?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) est un format de fichier binaire, c'est-à-dire qu'il est impossible de visualiser son contenu sans outils spéciaux. Les premières versions de PowerPoint 97-2003 fonctionnaient avec le format de fichier PPT, cependant son extensibilité est limitée.
## **Qu'est-ce que le PPTX ?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) est un nouveau format de fichier de présentation, basé sur la norme Office Open XML (ISO 29500:2008-2016, ECMA-376). Le PPTX est un ensemble archivé de fichiers XML et de fichiers multimédias. Le format PPTX est facilement extensible. Par exemple, il est facile d’ajouter le support d’un nouveau type de graphique ou d’un nouveau type de forme, sans changer le format PPTX à chaque nouvelle version de PowerPoint. Le format PPTX est utilisé à partir de PowerPoint 2007.
## **PPT vs PPTX**
Bien que le PPTX offre des fonctionnalités beaucoup plus larges, le PPT reste assez populaire. La nécessité de convertir de PPT à PPTX et vice versa est très demandée.

Cependant, la conversion entre l'ancien format PPT et le nouveau format PPTX est le défi le plus compliqué parmi les autres formats de Microsoft Office. Bien que la spécification du format PPT soit ouverte, il est difficile de travailler avec. PowerPoint peut créer des parties spéciales (MetroBlob) dans les fichiers PPT pour stocker des informations provenant de PPTX qui ne sont pas supportées par le format PPT et ne peuvent pas être affichées dans les anciennes versions de PowerPoint. Ces informations peuvent être récupérées lorsqu'un fichier PPT est chargé dans une version moderne de PowerPoint ou converti en format PPTX.

Aspose.Slides fournit une interface commune pour travailler avec tous les formats de présentation. Il permet de convertir de PPT à PPTX et de PPTX à PPT de manière très simple. Aspose.Slides prend en charge la conversion complète de PPT à PPTX et prend également en charge la conversion de PPTX à PPT avec certaines restrictions. Nous recommandons d'utiliser le format PPTX autant que possible.

{{% alert color="primary" %}} 

Vérifiez la qualité des conversions de PPT en PPTX et de PPTX en PPT avec l'application de conversion en ligne [**Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Sauvegarder la présentation PPT au format PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Lisez plus [**Comment convertir des présentations PPT en PPTX**.](/slides/fr/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 
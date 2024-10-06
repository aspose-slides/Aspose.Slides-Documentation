---
title: PPT vs PPTX
type: docs
weight: 10
url: /python-net/ppt-vs-pptx/
keywords: "PPT vs PPTX, PPT ou PPTX, Présentation PowerPoint, format, Python"
description: "À propos des formats de présentation PowerPoint. PPT vs PPTX. Différences en Python"
---


## **Qu'est-ce que PPT ?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) est un format de fichier binaire, c'est-à-dire qu'il est impossible de visualiser son contenu sans outils spéciaux. Les premières versions de PowerPoint 97-2003 fonctionnaient avec le format de fichier PPT, cependant son extensibilité est limitée. 
## **Qu'est-ce que PPTX ?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) est un nouveau format de fichier de présentation, basé sur la norme Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX est un ensemble archivé de fichiers XML et de fichiers multimédia. Le format PPTX est facilement extensible. Par exemple, il est facile d'ajouter un support pour un nouveau type de graphique ou un type de forme, sans changer le format PPTX à chaque nouvelle version de PowerPoint. Le format PPTX est utilisé à partir de PowerPoint 2007.

## **PPT vs PPTX**
Bien que PPTX offre une fonctionnalié beaucoup plus large, PPT reste assez populaire. La nécessité de convertir de PPT à PPTX et vice versa est fortement demandée.

Cependant, la conversion entre le vieux format PPT et le nouveau format PPTX est le défi le plus compliqué parmi les autres formats de Microsoft Office. Bien que la spécification du format PPT soit ouverte, il est difficile de travailler avec. PowerPoint peut créer des parties spéciales (MetroBlob) dans les fichiers PPT pour stocker des informations à partir de PPTX qui ne sont pas prises en charge par le format PPT et ne peuvent pas être affichées dans les anciennes versions de PowerPoint. Ces informations peuvent être restaurées lorsque un fichier PPT est chargé dans une version moderne de PowerPoint ou converti en format PPTX.

Aspose.Slides fournit une interface commune pour travailler avec tous les formats de présentation. Il permet de convertir de PPT à PPTX et de PPTX à PPT de manière très simple. Aspose.Slides prend complètement en charge la conversion de PPT à PPTX et prend également en charge la conversion de PPTX à PPT avec certaines restrictions. Nous recommandons d'utiliser le format PPTX autant que possible.

{{% alert color="primary" %}} 

Vérifiez la qualité des conversions de PPT à PPTX et de PPTX à PPT avec l'application de conversion en ligne [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Enregistrer la présentation PPTX au format PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Lisez plus sur [**Comment convertir des présentations PPT en PPTX**.](/slides/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 
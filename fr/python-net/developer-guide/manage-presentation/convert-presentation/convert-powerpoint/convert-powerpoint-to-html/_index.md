---
title: Convertir des présentations en HTML avec Python
linktitle: Présentation en HTML
type: docs
weight: 30
url: /fr/python-net/convert-powerpoint-to-html/
keywords:
  - convertir PowerPoint
  - convertir présentation
  - convertir diapositive
  - PowerPoint en HTML
  - présentation en HTML
  - diapositive en HTML
  - PPT en HTML
  - PPTX en HTML
  - ODP en HTML
  - exportation HTML
  - HTML réactif
  - PowerPoint
  - OpenDocument
  - présentation
  - Python
  - Aspose.Slides
description: "Convertissez facilement les présentations PowerPoint et OpenDocument en HTML avec Aspose.Slides for Python via .NET. Préservez parfaitement la mise en page et le style."
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant Python. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML avec Python
- Convertir PPT en HTML avec Python
- Convertir PPTX en HTML avec Python
- Convertir ODP en HTML avec Python
- Convertir une diapositive PowerPoint en HTML avec Python

## **Python PowerPoint en HTML**

Pour obtenir un exemple de code Python pour convertir PowerPoint en HTML, veuillez consulter la section ci-dessous, c'est-à-dire [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans un objet Présentation et l'enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides pour Python via .NET**](https://products.aspose.com/slides/python-net/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** offre de nombreuses options (principalement à partir de la classe [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) qui définissent le processus de conversion de PowerPoint en HTML :

* Convertir une présentation PowerPoint entière en HTML.
* Convertir une diapositive spécifique d'une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML responsive.
* Convertir une présentation PowerPoint en HTML avec les notes du présentateur incluses ou exclues.
* Convertir une présentation PowerPoint en HTML avec les commentaires inclus ou exclus.
* Convertir une présentation PowerPoint en HTML avec les polices originales ou intégrées.
* Convertir une présentation PowerPoint en HTML tout en utilisant le nouveau style CSS.

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) gratuits : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez également consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge ces opérations de conversion impliquant le format HTML :

* [HTML en image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Convertir PowerPoint en HTML**
En utilisant Aspose.Slides, vous pouvez convertir une présentation PowerPoint entière en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Utilisez la méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour enregistrer l'objet en tant que fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML avec Python :

```python
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Enregistrer la présentation en HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convertir PowerPoint en HTML responsive**

Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) qui permet de générer des fichiers HTML adaptatifs. Ce code vous montre comment convertir une présentation PowerPoint en HTML responsive avec Python :

```py
# Instancier un objet Presentation qui représente un fichier de présentation
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Enregistrer la présentation en HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convertir PowerPoint en HTML avec notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec des notes en Python :

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convertir PowerPoint en HTML avec les polices d'origine**
Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) qui permet d'intégrer toutes les polices dans une présentation lors de la conversion de la présentation en HTML.

Pour empêcher l'intégration de certaines polices, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Les polices populaires, comme Calibri ou Arial, lorsqu'elles sont utilisées dans une présentation, n'ont pas besoin d'être intégrées car la plupart des systèmes contiennent déjà de telles polices. Lorsque ces polices sont intégrées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) prend en charge l'héritage et fournit la méthode `WriteFont`, qui est destinée à être écrasée.

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclure les polices par défaut de la présentation
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convertir une diapositive en HTML**
Convertir une diapositive de présentation séparée en HTML. Pour cela, utilisez la même méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui est utilisée pour convertir la présentation entière PPT(X) en document HTML. La classe [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) peut également être utilisée pour définir les options de conversion supplémentaires :

```py
# [TODO[not_supported_yet]: implémentation python de l'interface .net]
```

## **Enregistrer CSS et images lors de l'exportation vers HTML**
En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement changer le style du fichier HTML résultant du processus de conversion de PowerPoint en HTML.

Le code python dans cet exemple vous montre comment utiliser des méthodes remplaçables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

## **Lier toutes les polices lors de la conversion de la présentation en HTML**
Si vous ne souhaitez pas intégrer les polices (pour éviter d'augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version `LinkAllFontsHtmlController`.

Ce code python vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent déjà dans le système) :

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

## **Support de la propriété SVG responsive**
L'exemple de code ci-dessous montre comment exporter une présentation PPT(X) en HTML avec la mise en page responsive :

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Exporter les fichiers multimédias vers le fichier HTML**
En utilisant Aspose.Slides pour Python, vous pouvez exporter des fichiers multimédias de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive.
1. Ajoutez une vidéo à la diapositive.
1. Écrivez la présentation en tant que fichier HTML.

Ce code python vous montre comment ajouter une vidéo à la présentation puis l'enregistrer en tant que HTML :

```py
import aspose.slides as slides

# Chargement d'une présentation
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```
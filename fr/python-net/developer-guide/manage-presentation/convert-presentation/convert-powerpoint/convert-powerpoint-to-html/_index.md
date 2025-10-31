---
title: Convertir les présentations PowerPoint en HTML avec Python
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/python-net/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- enregistrer PowerPoint comme HTML
- enregistrer présentation comme HTML
- enregistrer diapositive comme HTML
- enregistrer PPT comme HTML
- enregistrer PPTX comme HTML
- Python
- Aspose.Slides
description: "Convertissez les présentations PowerPoint en HTML responsive avec Python. Conservez la mise en page, les liens et les images grâce au guide de conversion Aspose.Slides pour des résultats rapides et impeccables."
---

## **Vue d’ensemble**

Cet article explique comment convertir une présentation PowerPoint au format HTML à l’aide de Python. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML avec Python
- Convertir PPT en HTML avec Python
- Convertir PPTX en HTML avec Python
- Convertir ODP en HTML avec Python
- Convertir une diapositive PowerPoint en HTML avec Python

## **Python PowerPoint en HTML**

Pour le code d’exemple Python permettant de convertir PowerPoint en HTML, consultez la section ci‑dessous, à savoir [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans l’objet Presentation et l’enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**. 

**Aspose.Slides** propose de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) qui définissent le processus de conversion PowerPoint vers HTML :

* Convertir une présentation PowerPoint complète en HTML.
* Convertir une diapositive spécifique d’une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML responsive. 
* Convertir une présentation PowerPoint en HTML avec ou sans les notes du présentateur. 
* Convertir une présentation PowerPoint en HTML avec ou sans les commentaires. 
* Convertir une présentation PowerPoint en HTML avec les polices d’origine ou incorporées. 
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS. 

{{% alert color="primary" %}} 

Grâce à sa propre API, Aspose a développé des convertisseurs gratuits [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez également consulter les autres [convertisseurs gratuits d’Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge les opérations de conversion impliquant le format HTML : 

* [HTML en image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Convertir PowerPoint en HTML**
Avec Aspose.Slides, vous pouvez convertir une présentation PowerPoint complète en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour enregistrer l’objet sous forme de fichier HTML.

Ce code montre comment convertir un PowerPoint en HTML avec Python :

```python
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Enregistrement de la présentation au format HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convertir PowerPoint en HTML responsive**

Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) qui permet de générer des fichiers HTML responsive. Ce code montre comment convertir une présentation PowerPoint en HTML responsive avec Python :

```py
# Instancier un objet Presentation qui représente un fichier de présentation
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Enregistrement de la présentation au format HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convertir PowerPoint en HTML avec notes**
Ce code montre comment convertir un PowerPoint en HTML avec les notes en Python :

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convertir PowerPoint en HTML avec les polices d’origine**
Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) qui permet d’incorporer toutes les polices d’une présentation lors de la conversion en HTML.

Pour empêcher l’incorporation de certaines polices, vous pouvez transmettre un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Les polices populaires, comme Calibri ou Arial, lorsqu’elles sont utilisées dans une présentation, n’ont pas besoin d’être incorporées car la plupart des systèmes les possèdent déjà. Lorsqu’elles sont incorporées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) prend en charge l’héritage et fournit la méthode `WriteFont`, destinée à être réécrite. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclure les polices par défaut de la présentation
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(
    slides.export.EmbedAllFontsHtmlController(fontNameExcludeList)
)

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convertir une diapositive en HTML**
Convertissez une diapositive distincte en HTML. Pour cela, utilisez la même méthode [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sert à convertir la présentation PPT(X) entière en document HTML. La classe [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) peut également être utilisée pour définir des options de conversion supplémentaires :

```py
# [TODO[not_supported_yet]: implémentation python de l'interface .net]
```

## **Enregistrer CSS et images lors de l’exportation en HTML**
Grâce aux nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion PowerPoint en HTML. 

Le code Python de cet exemple montre comment utiliser des méthodes sur‑définissables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

## **Lier toutes les polices lors de la conversion d’une présentation en HTML**
Si vous ne souhaitez pas incorporer les polices (pour éviter d’augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`. 

Ce code Python montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant « Calibri » et « Arial » (puisqu’elles existent déjà dans le système) :

```py
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

## **Prise en charge de la propriété responsive SVG**
L’exemple de code ci‑dessous montre comment exporter une présentation PPT(X) en HTML avec une mise en page responsive :

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Exporter les fichiers multimédias vers un fichier HTML**
Avec Aspose.Slides pour Python, vous pouvez exporter les fichiers multimédias de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive.
3. Ajoutez une vidéo à la diapositive.
4. Enregistrez la présentation sous forme de fichier HTML.

Ce code Python montre comment ajouter une vidéo à la présentation puis l’enregistrer en HTML :

```py
import aspose.slides as slides

# Chargement d’une présentation
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

## FAQ

### **Comment convertir une présentation PowerPoint en HTML avec Python ?**

Vous pouvez utiliser la bibliothèque Aspose.Slides for Python via .NET pour charger des fichiers PPT, PPTX ou ODP et les convertir en HTML à l’aide de la méthode `save()` avec `SaveFormat.HTML`.

### **Aspose.Slides prend‑il en charge la conversion de diapositives PowerPoint individuelles en HTML ?**

Oui, Aspose.Slides permet de convertir soit la présentation entière, soit des diapositives spécifiques en HTML en configurant `HtmlOptions` en conséquence.

### **Puis‑je générer du HTML responsive à partir de présentations PowerPoint ?**

Oui, avec la classe `ResponsiveHtmlController`, vous pouvez exporter votre présentation vers une mise en page HTML responsive qui s’adapte aux différentes tailles d’écran.

### **Est‑il possible d’inclure les notes du présentateur ou les commentaires dans le HTML exporté ?**

Oui, vous pouvez configurer `HtmlOptions` pour inclure ou exclure les notes du présentateur et les commentaires lors de l’exportation des présentations PowerPoint vers HTML.

### **Puis‑je incorporer les polices lors de la conversion d’une présentation en HTML ?**

Oui, Aspose.Slides fournit la classe `EmbedAllFontsHtmlController`, qui permet d’incorporer les polices ou d’exclure certaines polices afin de réduire la taille du fichier de sortie.

### **La conversion PowerPoint en HTML prend‑elle en charge les fichiers multimédias comme les vidéos et l’audio ?**

Oui, Aspose.Slides permet d’exporter le contenu multimédia intégré aux diapositives vers HTML en utilisant `VideoPlayerHtmlController` et les classes de configuration associées.

### **Quels formats de fichiers sont pris en charge pour la conversion vers HTML ?**

Aspose.Slides prend en charge la conversion des formats de présentation PPT, PPTX et ODP vers HTML. Il permet également d’enregistrer le contenu des diapositives au format SVG et d’exporter les actifs multimédias.

### **Puis‑je éviter d’incorporer les polices pour réduire la taille du HTML de sortie ?**

Oui, vous pouvez lier les polices système couramment disponibles comme Arial ou Calibri au lieu de les incorporer, en utilisant une implémentation personnalisée du `HtmlController`.

### **Existe‑t‑il un outil en ligne pour convertir PowerPoint en HTML ?**

Oui, vous pouvez essayer les outils web gratuits d’Aspose tels que [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html) ou [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html) pour convertir des présentations directement dans votre navigateur sans écrire de code.

### **Puis‑je utiliser des styles CSS personnalisés dans le fichier HTML exporté ?**

Oui, Aspose.Slides permet de lier des fichiers CSS externes pendant la conversion, vous offrant ainsi une personnalisation complète de l’apparence du contenu HTML résultant.
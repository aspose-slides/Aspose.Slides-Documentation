---
title: Gérer les objets d'encre de présentation en Python via Java
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/python-java/manage-ink/
keywords:
- encre
- objet d'encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- exportation d'encre
- rendu d'encre
- masquer l'encre
- InkOptions
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Gérez les objets d'encre PowerPoint, modifiez les traces et les propriétés des pinceaux, et contrôlez l'apparence de l'encre lors de l'exportation PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour Python via Java."
---
## **Introduction**

PowerPoint propose une fonctionnalité d’encre qui vous permet de dessiner des traits libres. L’encre peut être utilisée pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive.

Aspose.Slides fournit les types nécessaires pour travailler avec les objets d’encre. Par exemple, la classe [Encre](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ink/) représente un objet d’encre sur une diapositive.

## **Différences entre les objets normaux et les objets d’encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l’objet lui‑-même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l’arrière‑plan. Pour plus d’informations, consultez [Format de mise en page des formes](/slides/fr/python-java/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint gère un objet d’encre, il ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les méthodes standard [Shape.getWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getWidth) et [Shape.getHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getHeight) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d’encre**

Une trace d’encre est un élément de base utilisé pour enregistrer la trajectoire d’un stylet lorsqu’un utilisateur écrit de l’encre numérique. Une trace stocke une séquence de points connectés.

La forme la plus simple d’encodage spécifie les coordonnées X et Y de chaque point d’échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés de pinceau pour le dessin**

Un pinceau est utilisé pour tracer des lignes qui relient les points d’une trace d’encre. Le pinceau possède sa propre couleur et sa propre taille, représentées par les méthodes [InkBrush.getColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkbrush/#getColor) et [InkBrush.getSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkbrush/#getSize).

### **Définir la couleur du pinceau d’encre**

Ce code Python montre comment définir la couleur d’un pinceau d’encre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Définir la taille du pinceau d’encre**

Ce code Python montre comment définir la taille d’un pinceau d’encre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

En général, la largeur et la hauteur d’un pinceau ne sont pas identiques, de sorte que PowerPoint n’affiche pas la taille du pinceau (la section de données correspondante est grisée). Lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille ainsi :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet d’encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir l’image précédente).

Ainsi, pour déterminer la zone visible de l’ensemble de l’objet d’encre, il faut prendre en compte la taille du pinceau de ses traces. Ici, l’objet cible (la trace du texte manuscrit) a été mis à l’échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l’apparence de l’encre lors de l’exportation et du rendu**

Aspose.Slides fournit la classe [InkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/) pour contrôler la façon dont les objets d’encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer complètement l’encre ou modifier la façon dont les opérations de masque du pinceau d’encre sont interprétées.

Les options d’encre sont accessibles via les options d’exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d’encre |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Image de diapositive | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Les méthodes suivantes de [InkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/) exposent les mêmes deux réglages :

- [getHideInk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#getHideInk) détermine si les objets d’encre sont inclus dans la sortie. Sa valeur par défaut est `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) détermine si une opération de masque est interprétée comme opacité lors du rendu d’un pinceau d’encre. Sa valeur par défaut est `True` ; appelez [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) avec `False` pour utiliser l’opération ROP à la place.

### **Masquer les objets d’encre dans la sortie PDF**

Par défaut, les objets d’encre restent visibles lors de l’exportation. Pour créer une sortie épurée sans annotations manuscrites ou autre contenu d’encre, appelez [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#setHideInk) avec `True`.

L’exemple Python suivant exporte une présentation en PDF tout en masquant tous les objets d’encre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Masquer les objets d’encre lors du rendu d’une diapositive en image**

Pour masquer les objets d’encre lors du rendu des diapositives en images bitmap, configurez [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/#getInkOptions) et transmettez les options de rendu à [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage).

L’exemple Python suivant rend la première diapositive en image PNG sans objets d’encre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Contrôler le rendu du masque d’encre**

Le réglage [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d’encre. La valeur par défaut est `True`, ce qui utilise l’opacité. Pour utiliser l’opération ROP à la place, appelez [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) avec `False`.

L’exemple Python suivant exporte une diapositive en SVG et utilise le rendu basé sur ROP pour les opérations de masque d’encre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Le même réglage peut être appliqué via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#getInkOptions) lors de l’exportation d’une présentation ou du rendu d’une diapositive en TIFF.

### **Choisir de masquer ou de conserver l’encre**

Lorsque vous avez besoin d’une version propre d’une présentation annotée à distribuer sans marques de révision, appelez [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#setHideInk) avec `True` pendant l’exportation.

Laissez [InkOptions.getHideInk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#getHideInk) à sa valeur par défaut `False` lorsque les annotations d’encre font partie du contenu prévu, par exemple des commentaires de révision, des notes manuscrites, des surlignages ou des dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des versions de révision et finales séparées à partir de la même présentation sans modifier les objets d’encre sources.

## **FAQ**

**Puis‑je modifier la couleur ou la taille d’un trait d’encre existant ?**

Oui. Récupérez la trace avec [Ink.getTraces](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ink/#getTraces), puis modifiez son [InkTrace.getBrush](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inktrace/#getBrush). Appelez [InkBrush.setColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkbrush/#setColor) ou [InkBrush.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkbrush/#setSize) pour changer le pinceau.

**Le masquage de l’encre modifie‑t‑il la présentation source ?**

Non. L’appel à [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/python-java/aspose.slides/inkoptions/#setHideInk) n’affecte que le résultat rendu ou exporté ; il ne supprime pas et ne modifie pas les objets d’encre dans la présentation source.

**Quels formats d’exportation prennent en charge les options d’encre ?**

Vous pouvez configurer les options d’encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d’exportation ou de rendu correspondantes présentées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](/slides/fr/python-java/powerpoint-shapes/).
* Pour plus d’informations sur les valeurs effectives, voir [Shape Effective Properties](/slides/fr/python-java/shape-effective-properties/#get-effective-font-height-value).
* Pour les détails de l’exportation PDF, voir [Convert PPT and PPTX to PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/).
* Pour les détails de l’exportation HTML, voir [Convert PowerPoint Presentations to HTML](/slides/fr/python-java/convert-powerpoint-to-html/).
* Pour les détails de l’exportation SVG, voir [Render Presentation Slides as SVG Images](/slides/fr/python-java/render-a-slide-as-an-svg-image/).
* Pour les détails de l’exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](/slides/fr/python-java/convert-powerpoint-to-tiff/).
* Pour les détails du rendu diapositive‑vers‑image, voir [Convert Presentation Slides to Images](/slides/fr/python-java/convert-slide/).
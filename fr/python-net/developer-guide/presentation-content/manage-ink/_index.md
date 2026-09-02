---
title: Gérer les objets d'encre de présentation en Python
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/python-net/manage-ink/
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
- Aspose.Slides
description: "Gérer les objets d'encre PowerPoint, modifier les traces et les propriétés des pinceaux, et contrôler l'apparence de l'encre lors de l'exportation PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour Python via .NET."
---
## **Introduction**

PowerPoint propose une fonctionnalité d’encre qui vous permet de dessiner des traits libres. L’encre peut être utilisée pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive.

Le espace de noms [aspose.slides.ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/) contient les classes nécessaires pour travailler avec les objets encre. Par exemple, la classe [Ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/ink/) représente un objet encre sur une diapositive.

## **Différences entre les objets classiques et les objets encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l’objet lui‑même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l’arrière‑plan. Pour plus d’informations, consultez [Shape Layout Format](https://docs.aspose.com/slides/fr/python-net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu’une diapositive PowerPoint gère un objet encre, il ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les propriétés standards [Ink.width](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/ink/width/) et [Ink.height](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/ink/height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d’encre**

Une trace d’encre est un élément de base utilisé pour enregistrer la trajectoire d’un stylet lorsqu’un utilisateur écrit de l’encre numérique. Une trace stocke une séquence de points connectés.

La forme d’encodage la plus simple spécifie les coordonnées X et Y de chaque point d’échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau est utilisé pour tracer des lignes qui relient les points d’une trace d’encre. Ses [InkBrush.color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/inkbrush/color/) et [InkBrush.size](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/inkbrush/size/) contrôlent respectivement sa couleur et sa taille.

### **Définir la couleur du pinceau d’encre**

Ce code Python montre comment définir la couleur d’un pinceau d’encre :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Définir la taille du pinceau d’encre**

Ce code Python montre comment définir la taille d’un pinceau d’encre :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

En général, la largeur et la hauteur d’un pinceau ne correspondent pas, de sorte que PowerPoint n’affiche pas la taille du pinceau (la section de données correspondante est grisée). Lorsque la largeur et la hauteur du pinceau sont identiques, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir l’image précédente).

Par conséquent, pour déterminer la zone visible de l’ensemble de l’objet encre, la taille du pinceau de ses traces doit être prise en compte. Ici, l’objet cible (la trace du texte manuscrit) a été mis à l’échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l’apparence de l’encre lors de l’exportation et du rendu**

Aspose.Slides fournit la classe [InkOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/) pour contrôler l’apparence des objets encre dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer totalement l’encre ou modifier la façon dont les opérations de masque du pinceau d’encre sont interprétées.

Les options d’encre sont disponibles via les options d’exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d’encre |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Les deux mêmes paramètres sont disponibles via ces propriétés :

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/hide_ink/) détermine si les objets encre sont inclus dans la sortie. Sa valeur par défaut est `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) détermine si une opération de masque est interprétée comme une opacité lors du rendu d’un pinceau d’encre. Sa valeur par défaut est `True` ; définissez‑la sur `False` pour utiliser l’opération ROP à la place.

### **Masquer les objets encre dans la sortie PDF**

Par défaut, les objets encre restent visibles pendant l’exportation. Réglez [InkOptions.hide_ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/hide_ink/) sur `True` lorsque vous avez besoin d’une sortie épurée sans annotations manuscrites ou autre contenu encre.

L’exemple Python suivant exporte une présentation au format PDF tout en masquant tous les objets encre :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Masquer les objets encre lors du rendu d’une diapositive en image**

Pour masquer les objets encre lors du rendu des diapositives en images bitmap, configurez [RenderingOptions.ink_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/ink_options/) et passez les options de rendu à la méthode [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/).

L’exemple Python suivant rend la première diapositive en image PNG sans objets encre :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Contrôler le rendu du masque d’encre**

La propriété [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d’encre. La valeur par défaut est `True`, ce qui utilise l’opacité. Définissez la propriété sur `False` pour utiliser l’opération ROP à la place.

L’exemple Python suivant exporte une diapositive au format SVG et utilise le rendu basé sur ROP pour les opérations de masque d’encre :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Le même paramètre peut être appliqué via [TiffOptions.ink_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/ink_options/) lors de l’exportation d’une présentation ou du rendu d’une diapositive au format TIFF.

### **Choisir de masquer ou de préserver l’encre**

Réglez [InkOptions.hide_ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/hide_ink/) sur `True` lorsque le fichier exporté doit être une version épurée d’une présentation annotée, par exemple, une copie finale destinée à la diffusion sans marques de révision.

Laissez [InkOptions.hide_ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/hide_ink/) à sa valeur par défaut `False` lorsque les annotations encre font partie du contenu prévu, comme les commentaires de révision, les notes manuscrites, les surlignages ou les dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales distinctes à partir de la même présentation sans modifier les objets encre sources.

## **FAQ**

**Puis-je modifier la couleur ou la taille d’un trait d’encre existant ?**

Oui. Récupérez la trace via [Ink.traces](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/ink/traces/), puis modifiez son [InkTrace.brush](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/inktrace/brush/). Vous pouvez définir les propriétés [InkBrush.color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/inkbrush/color/) et [InkBrush.size](https://reference.aspose.com/slides/fr/python-net/aspose.slides.ink/inkbrush/size/) du pinceau.

**Masquer l’encre modifie‑t‑elle la présentation source ?**

Non. [InkOptions.hide_ink](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/inkoptions/hide_ink/) n’affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets encre dans la présentation source.

**Quels formats d’exportation prennent en charge les options d’encre ?**

Vous pouvez configurer les options d’encre pour les formats PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d’exportation ou de rendu correspondantes présentées ci‑dessus.

**Lecture complémentaire**

* Pour en savoir plus sur les formes en général, voir la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/python-net/powerpoint-shapes/).
* Pour plus d’informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/fr/python-net/shape-effective-properties/#get-effective-font-height-value).
* Pour plus de détails sur l’exportation PDF, voir [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/python-net/convert-powerpoint-to-pdf/).
* Pour plus de détails sur l’exportation HTML, voir [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/python-net/convert-powerpoint-to-html/).
* Pour plus de détails sur l’exportation SVG, voir [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/python-net/render-a-slide-as-an-svg-image/).
* Pour plus de détails sur l’exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/python-net/convert-powerpoint-to-tiff/).
* Pour plus de détails sur le rendu diapositive‑vers‑image, voir [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/python-net/convert-slide/).
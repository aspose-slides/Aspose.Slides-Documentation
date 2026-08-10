---
title: Gérer les objets d'encre de présentation dans .NET
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/net/manage-ink/
keywords:
- encre
- objet encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- exportation d'encre
- rendu d'encre
- masquer l'encre
- IInkOptions
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les objets d'encre PowerPoint, modifiez les traces et les propriétés de pinceau, et contrôlez l'apparence de l'encre lors de l'exportation en PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour .NET."
---
## **Introduction**

PowerPoint fournit une fonction d’encre qui vous permet de dessiner des traits libres. L’encre peut être utilisée pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive.

L’espace de noms [Aspose.Slides.Ink](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/) contient les classes et interfaces nécessaires pour travailler avec les objets encre. Par exemple, l’interface [IInk](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iink/) représente un objet encre sur une diapositive.

## **Différences entre les objets ordinaires et les objets encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l’objet lui‑-même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l’arrière‑plan. Pour plus d’informations, consultez [Shape Layout Format](https://docs.aspose.com/slides/fr/net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint gère un objet encre, il ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les propriétés standards [IShape.Width](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/width/) et [IShape.Height](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d’encre**

Une trace d’encre est un élément de base utilisé pour enregistrer la trajectoire d’un stylet lorsqu’un utilisateur écrit de l’encre numérique. Une trace stocke une séquence de points connectés.

La forme d’encodage la plus simple spécifie les coordonnées X et Y de chaque point d’échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau est utilisé pour tracer des lignes qui relient les points d’une trace d’encre. Le pinceau possède sa propre couleur et taille, représentées par les propriétés [IInkBrush.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iinkbrush/color/) et [IInkBrush.Size](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iinkbrush/size/) .

### **Définir la couleur du pinceau d’encre**

Ce code C# montre comment définir la couleur d’un pinceau d’encre :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Définir la taille du pinceau d’encre**

Ce code C# montre comment définir la taille d’un pinceau d’encre :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

En général, la largeur et la hauteur d’un pinceau ne correspondent pas, de sorte que PowerPoint n’affiche pas la taille du pinceau (la section de données correspondante est grisées). Lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille ainsi :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet encre et passons en revue les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir l’image précédente).

Par conséquent, pour déterminer la zone visible de l’ensemble de l’objet encre, il faut prendre en compte la taille du pinceau de ses traces. Ici, l’objet cible (la trace de texte manuscrit) a été mis à l’échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l’apparence de l’encre lors de l’exportation et du rendu**

Aspose.Slides fournit l’interface [IInkOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/) permettant de contrôler la façon dont les objets encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer complètement l’encre ou modifier la manière dont les opérations de masque de pinceau d’encre sont interprétées.

Les options d’encre sont disponibles via les options d’exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d’encre |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Image de diapositive | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/renderingoptions/inkoptions/) |

Les deux mêmes paramètres sont disponibles via ces propriétés :

- [`HideInk`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/hideink/) détermine si les objets encre sont inclus dans la sortie. Sa valeur par défaut est `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) détermine si une opération de masque est interprétée comme une opacité lors du rendu d’un pinceau d’encre. Sa valeur par défaut est `true` ; définissez‑la sur `false` pour utiliser l’opération ROP à la place.

### **Masquer les objets encre dans la sortie PDF**

Par défaut, les objets encre restent visibles lors de l’exportation. Réglez [IInkOptions.HideInk](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/hideink/) sur `true` lorsque vous avez besoin d’une sortie propre sans annotations manuscrites ou autre contenu encre.

L’exemple C# suivant exporte une présentation au format PDF tout en masquant tous les objets encre :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Masquer les objets encre lors du rendu d’une diapositive en image**

Pour masquer les objets encre lors du rendu des diapositives en images bitmap, configurez [RenderingOptions.InkOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/renderingoptions/inkoptions/) et transmettez les options de rendu à la méthode [ISlide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/) .

L’exemple C# suivant rend la première diapositive en image PNG sans objets encre :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Contrôler le rendu du masque d’encre**

La propriété [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d’encre. La valeur par défaut est `true`, ce qui utilise l’opacité. Définissez la propriété sur `false` pour utiliser l’opération ROP à la place.

L’exemple C# suivant exporte une diapositive au format SVG et utilise le rendu basé sur ROP pour les opérations de masque d’encre :

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Le même paramètre peut être appliqué via [TiffOptions.InkOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/inkoptions/) lors de l’exportation d’une présentation ou du rendu d’une diapositive en TIFF.

### **Choisir de masquer ou de conserver l’encre**

Utilisez [IInkOptions.HideInk](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/hideink/) réglé sur `true` lorsque le fichier exporté doit être une version propre d’une présentation annotée, par exemple une copie finale destinée à la diffusion sans marques de révision.

Laissez [IInkOptions.HideInk](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/hideink/) à sa valeur par défaut `false` lorsque les annotations encre font partie du contenu attendu, comme des commentaires de révision, des notes manuscrites, des surlignages ou des dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales séparées à partir de la même présentation sans modifier les objets encre source.

## **FAQ**

**Puis‑je modifier la couleur ou la taille d’un trait d’encre existant ?**

Oui. Récupérez la trace via [IInk.Traces](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iink/traces/), puis modifiez son [IInkTrace.Brush](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iinktrace/brush/). Vous pouvez définir les propriétés [IInkBrush.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iinkbrush/color/) et [IInkBrush.Size](https://reference.aspose.com/slides/fr/net/aspose.slides.ink/iinkbrush/size/) du pinceau.

**Le masquage de l’encre modifie‑t‑il la présentation source ?**

Non. [IInkOptions.HideInk](https://reference.aspose.com/slides/fr/net/aspose.slides.export/iinkoptions/hideink/) n’affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets encre dans la présentation source.

**Quels formats d’exportation prennent en charge les options d’encre ?**

Vous pouvez configurer les options d’encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d’exportation ou de rendu correspondantes indiquées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/net/powerpoint-shapes/) .
* Pour plus d’informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/fr/net/shape-effective-properties/#get-effective-font-height-value) .
* Pour les détails sur l’exportation PDF, voir [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/net/convert-powerpoint-to-pdf/) .
* Pour les détails sur l’exportation HTML, voir [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/net/convert-powerpoint-to-html/) .
* Pour les détails sur l’exportation SVG, voir [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/net/render-a-slide-as-an-svg-image/) .
* Pour les détails sur l’exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/net/convert-powerpoint-to-tiff/) .
* Pour les détails sur le rendu de diapositive en image, voir [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/net/convert-slide/) .
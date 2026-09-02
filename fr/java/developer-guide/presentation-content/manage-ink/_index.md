---
title: Gérer les objets d'encre de présentation en Java
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/java/manage-ink/
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
- IInkOptions
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérez les objets d'encre PowerPoint, modifiez les traces et les propriétés du pinceau, et contrôlez l'apparence de l'encre lors de l'exportation PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour Java."
---
## **Introduction**

PowerPoint propose une fonctionnalité d'encre qui vous permet de dessiner des traits libres. L'encre peut être utilisée pour mettre en surbrillance d'autres objets, afficher des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

Aspose.Slides fournit les types nécessaires pour travailler avec les objets d'encre. Par exemple, l'interface [IInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iink/) représente un objet d'encre sur une diapositive.

## **Différences entre les objets classiques et les objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l'objet lui‑même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l'arrière‑plan. Pour plus d'informations, consultez [Format de disposition de forme](https://docs.aspose.com/slides/fr/java/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu PowerPoint gère un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les méthodes standard [IShape.getWidth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getWidth--) et [IShape.getHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'encre**

Une trace d'encre est un élément de base utilisé pour enregistrer la trajectoire d'un stylet lorsqu'un utilisateur écrit de l'encre numérique. Une trace stocke une séquence de points connectés.

La forme la plus simple d'encodage spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau est utilisé pour tracer des lignes qui relient les points d'une trace d'encre. Le pinceau possède sa propre couleur et taille, représentées par les méthodes [IInkBrush.getColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkbrush/#getColor--) et [IInkBrush.getSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Définir la couleur du pinceau d'encre**

Ce code Java montre comment définir la couleur d'un pinceau d'encre :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Définir la taille du pinceau d'encre**

Ce code Java montre comment définir la taille d'un pinceau d'encre :

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, ainsi PowerPoint n'affiche pas la taille du pinceau (la section de données correspondante est grisée). Lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l'épaisseur de la ligne est nulle (voir l'image précédente).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, il faut prendre en compte la taille du pinceau de ses traces. Ici, l'objet cible (la trace de texte manuscrit) a été mis à l'échelle de la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l'apparence de l'encre lors de l'exportation et du rendu**

Aspose.Slides fournit l'interface [IInkOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/) pour contrôler la façon dont les objets d'encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer complètement l'encre ou modifier la manière dont les opérations de masque du pinceau d'encre sont interprétées.

Les options d'encre sont disponibles via les options d'exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d'encre |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Image de diapositive | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Les méthodes suivantes de [IInkOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/) exposent les mêmes deux paramètres :

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#getHideInk--) détermine si les objets d'encre sont inclus dans la sortie. Sa valeur par défaut est `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) détermine si une opération de masque est interprétée comme opacité lors du rendu d'un pinceau d'encre. Sa valeur par défaut est `true` ; appelez [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) avec `false` pour utiliser l'opération ROP à la place.

### **Masquer les objets d'encre dans la sortie PDF**

Par défaut, les objets d'encre restent visibles pendant l'exportation. Pour créer une sortie épurée sans annotations manuscrites ni autre contenu d'encre, appelez [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) avec `true`.

L'exemple Java suivant exporte une présentation au format PDF tout en masquant tous les objets d'encre :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Masquer les objets d'encre lors du rendu d'une diapositive en tant qu'image**

Pour masquer les objets d'encre lors du rendu de diapositives en images bitmap, configurez [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/renderingoptions/#getInkOptions--) et transmettez les options de rendu à [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

L'exemple Java suivant rend la première diapositive en image PNG sans objets d'encre :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Contrôler le rendu du masque d'encre**

Le paramètre [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d'encre. La valeur par défaut est `true`, ce qui utilise l'opacité. Pour utiliser l'opération ROP à la place, appelez [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) avec `false`.

L'exemple Java suivant exporte une diapositive au format SVG et utilise le rendu basé sur ROP pour les opérations de masque d'encre :

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Le même paramètre peut être appliqué via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/#getInkOptions--) lors de l'exportation d'une présentation ou du rendu d'une diapositive au format TIFF.

### **Choisir de masquer ou de préserver l'encre**

Lorsque vous avez besoin d'une version épurée d'une présentation annotée à distribuer sans marques de révision, appelez [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) avec `true` lors de l'exportation.

Laissez [IInkOptions.getHideInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#getHideInk--) à sa valeur par défaut `false` lorsque les annotations d'encre font partie du contenu prévu, comme les commentaires de révision, les notes manuscrites, les surbrillances ou les dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales séparées à partir de la même présentation sans modifier les objets d'encre source.

## **FAQ**

**Puis-je modifier la couleur ou la taille d'un trait d'encre existant ?**

Oui. Récupérez la trace avec [IInk.getTraces](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iink/#getTraces--), puis modifiez son [IInkTrace.getBrush](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinktrace/#getBrush--). Appelez [IInkBrush.setColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) ou [IInkBrush.setSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) pour changer le pinceau.

**Masquer l'encre modifie‑t‑il la présentation source ?**

Non. L'appel à [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) n'affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets d'encre dans la présentation source.

**Quels formats d'exportation prennent en charge les options d'encre ?**

Vous pouvez configurer les options d'encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d'exportation ou de rendu correspondantes présentées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/java/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/fr/java/shape-effective-properties/#get-effective-font-height-value).
* Pour les détails sur l'exportation PDF, voir [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/java/convert-powerpoint-to-pdf/).
* Pour les détails sur l'exportation HTML, voir [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/java/convert-powerpoint-to-html/).
* Pour les détails sur l'exportation SVG, voir [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/java/render-a-slide-as-an-svg-image/).
* Pour les détails sur l'exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/java/convert-powerpoint-to-tiff/).
* Pour les détails sur le rendu diapositive‑vers‑image, voir [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/java/convert-slide/).
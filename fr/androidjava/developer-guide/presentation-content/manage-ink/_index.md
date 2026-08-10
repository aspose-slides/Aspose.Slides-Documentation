---
title: Gérer les objets d'encre de la présentation sur Android
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/androidjava/manage-ink/
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
- Android
- Java
- Aspose.Slides
description: "Gérer les objets d'encre PowerPoint, modifier les traces et les propriétés du pinceau, et contrôler l'apparence de l'encre lors de l'exportation en PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour Android."
---
## **Introduction**

PowerPoint propose une fonctionnalité d’encre qui vous permet de dessiner des traits libres. L’encre peut être utilisée pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive.

Aspose.Slides fournit les types nécessaires pour travailler avec les objets d’encre. Par exemple, l’interface [IInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iink/) représente un objet d’encre sur une diapositive.

## **Différences entre les objets classiques et les objets d’encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets forme. Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l’objet lui‑même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l’arrière‑plan. Pour plus d’informations, consultez le [Format de mise en page de forme](https://docs.aspose.com/slides/fr/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu PowerPoint gère un objet d’encre, il ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les méthodes standard [IShape.getWidth](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getWidth--) et [IShape.getHeight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d’encre**

Une trace d’encre est un élément de base utilisé pour enregistrer la trajectoire d’un stylet lorsqu’un utilisateur écrit de l’encre numérique. Une trace stocke une séquence de points reliés.

La forme la plus simple d’encodage spécifie les coordonnées X et Y de chaque point d’échantillonnage. Lorsque tous les points reliés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau sert à tracer des lignes qui relient les points d’une trace d’encre. Le pinceau possède sa propre couleur et sa propre taille, représentées par les méthodes [IInkBrush.getColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkbrush/#getColor--) et [IInkBrush.getSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Définir la couleur du pinceau d’encre**

Ce code Java montre comment définir la couleur d’un pinceau d’encre :

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Définir la taille du pinceau d’encre**

Ce code Java montre comment définir la taille d’un pinceau d’encre :

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

En général, la largeur et la hauteur d’un pinceau ne correspondent pas, si bien que PowerPoint n’affiche pas la taille du pinceau (la section de données correspondante est grisée). Lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille ainsi :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet d’encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir l’image précédente).

Par conséquent, pour déterminer la zone visible de l’ensemble de l’objet d’encre, il faut prendre en compte la taille du pinceau de ses traces. Ici, l’objet cible (la trace de texte manuscrit) a été mis à l’échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilise un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l’apparence de l’encre lors de l’exportation et du rendu**

Aspose.Slides fournit l’interface [IInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/) pour contrôler la façon dont les objets d’encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer complètement l’encre ou modifier la façon dont les opérations de masque du pinceau d’encre sont interprétées.

Les options d’encre sont disponibles via les options d’exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d’encre |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Image de diapositive | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Les méthodes [IInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/) suivantes exposent les mêmes deux paramètres :

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) détermine si les objets d’encre sont inclus dans la sortie. Sa valeur par défaut est `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) détermine si une opération de masque est interprétée comme une opacité lors du rendu d’un pinceau d’encre. Sa valeur par défaut est `true` ; appelez [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) avec `false` pour utiliser l’opération ROP à la place.

### **Masquer les objets d’encre dans la sortie PDF**

Par défaut, les objets d’encre restent visibles lors de l’exportation. Pour créer une sortie propre sans annotations manuscrites ni autre contenu d’encre, appelez [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) avec `true`.

L’exemple Java suivant exporte une présentation en PDF tout en masquant tous les objets d’encre :

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

### **Masquer les objets d’encre lors du rendu d’une diapositive en image**

Pour masquer les objets d’encre lors du rendu des diapositives sous forme d’images bitmap, configurez [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) et transmettez les options de rendu à [ISlide.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) .

L’exemple Java suivant rend la première diapositive en image PNG sans objets d’encre :

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

### **Contrôler le rendu du masque d’encre**

Le paramètre [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d’encre. La valeur par défaut est `true`, ce qui utilise l’opacité. Pour utiliser l’opération ROP à la place, appelez [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) avec `false`.

L’exemple Java suivant exporte une diapositive au format SVG et utilise le rendu basé sur ROP pour les opérations de masque d’encre :

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Le même paramètre peut être appliqué via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) lors de l’exportation d’une présentation ou du rendu d’une diapositive en TIFF.

### **Choisir de masquer ou de conserver l’encre**

Lorsque vous avez besoin d’une version épurée d’une présentation annotée pour la distribution sans marques de révision, appelez [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) avec `true` pendant l’exportation.

Laissez [IInkOptions.getHideInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) à sa valeur par défaut `false` lorsque les annotations d’encre font partie du contenu prévu, comme les commentaires de révision, les notes manuscrites, les surlignages ou les dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales séparées à partir de la même présentation sans modifier les objets d’encre source.

## **FAQ**

**Puis-je modifier la couleur ou la taille d’un trait d’encre existant ?**

Oui. Récupérez la trace via [IInk.getTraces](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iink/#getTraces--), puis modifiez son [IInkTrace.getBrush](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinktrace/#getBrush--). Appelez [IInkBrush.setColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) ou [IInkBrush.setSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) pour changer le pinceau.

**Le masquage de l’encre modifie‑t‑il la présentation source ?**

Non. L’appel à [IInkOptions.setHideInk](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) n’affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets d’encre dans la présentation source.

**Quels formats d’exportation prennent en charge les options d’encre ?**

Vous pouvez configurer les options d’encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositive via les options d’exportation ou de rendu correspondantes indiquées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/androidjava/powerpoint-shapes/).
* Pour plus d’informations sur les valeurs effectives, consultez [Shape Effective Properties](https://docs.aspose.com/slides/fr/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Pour les détails de l’exportation PDF, voyez [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/androidjava/convert-powerpoint-to-pdf/).
* Pour les détails de l’exportation HTML, voyez [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/androidjava/convert-powerpoint-to-html/).
* Pour les détails de l’exportation SVG, voyez [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/androidjava/render-a-slide-as-an-svg-image/).
* Pour les détails de l’exportation TIFF, voyez [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/androidjava/convert-powerpoint-to-tiff/).
* Pour les détails du rendu diapositive‑vers‑image, voyez [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/androidjava/convert-slide/).
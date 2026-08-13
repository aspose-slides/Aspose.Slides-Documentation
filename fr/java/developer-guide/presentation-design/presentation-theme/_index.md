---
title: Gérer les thèmes de présentation en Java
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/java/presentation-theme/
keywords:
- Thème PowerPoint
- Thème de présentation
- Thème de diapositive
- Définir le thème
- Modifier le thème
- Gérer le thème
- Couleur du thème
- Palette supplémentaire
- Police du thème
- Style du thème
- Effet du thème
- PowerPoint
- OpenDocument
- Présentation
- Java
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d’éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/java/powerpoint-fonts/), [styles d’arrière-plan](/slides/fr/java/presentation-background/), et des effets.

![theme-constituents](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments d’une diapositive. Si vous n’aimez pas les couleurs, vous les modifiez en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs dans l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SchemeColor).

Ce code Java vous montre comment changer la couleur d’accent d’un thème :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Vous pouvez déterminer la valeur effective de la couleur résultante de cette façon :
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Pour illustrer davantage l’opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d’accent (provenant de l’opération initiale). Ensuite, nous changeons la couleur dans le thème :
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la couleur du thème à partir d’une palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème(1), des couleurs provenant de la palette supplémentaire(2) sont créées. Vous pouvez alors définir et récupérer ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1** - Couleurs principales du thème  
**2** - Couleurs de la palette supplémentaire.

Ce code Java démontre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème, puis utilisées dans des formes :
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, plus clair 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, plus clair 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, plus clair 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, plus sombre 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, plus sombre 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapper `SchemeColor` aux couleurs `IColorScheme`**

Lorsque vous travaillez avec [SchemeColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/schemecolor/), vous pouvez remarquer qu’il contient les valeurs de couleur de thème suivantes :
`Background1`, `Background2`, `Text1`, and `Text2`.

Toutefois, `Presentation.getMasterTheme().getColorScheme()` renvoie [IColorScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icolorscheme/), qui expose les couleurs correspondantes sous forme de :
`Dark1`, `Dark2`, `Light1`, and `Light2`.

Cette différence ne concerne que la dénomination. Ces valeurs correspondent aux mêmes emplacements de couleur de thème et le mappage est fixe :
* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il n’y a aucune conversion dynamique entre `Text`/`Background` et `Dark`/`Light`. Ce ne sont que des noms alternatifs pour les mêmes couleurs de thème.

Cette différence de dénomination provient de la terminologie de Microsoft Office. Les anciennes versions d’Office utilisaient `Dark 1`, `Light 1`, `Dark 2` et `Light 2`, tandis que les versions plus récentes de l’interface affichent les mêmes emplacements sous les noms `Text 1`, `Background 1`, `Text 2` et `Background 2`.

## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et à d’autres fins, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :
* **+mn-lt** - Police du corps Latin (Minor Latin Font)
* **+mj-lt** - Police du titre Latin (Major Latin Font)
* **+mn-ea** - Police du corps Asie orientale (Minor East Asian Font)
* **+mj-ea** - Police du corps Asie orientale (Major East Asian Font)

Ce code Java vous montre comment attribuer la police Latin à un élément du thème :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Ce code Java vous montre comment modifier la police du thème de la présentation :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

La police dans toutes les zones de texte sera mise à jour.

{{% alert color="info" title="TIP" %}} 
Vous voudrez peut-être consulter les [polices PowerPoint](/slides/fr/java/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière-plan du thème**

Par défaut, l’application PowerPoint propose 12 arrière-plans prédéfinis mais seuls 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique.

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l’application PowerPoint, vous pouvez exécuter ce code Java pour connaître le nombre d’arrière-plans prédéfinis dans la présentation :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) de la classe [FormatScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme), vous pouvez ajouter ou accéder au style d’arrière-plan dans un thème PowerPoint. 
{{% /alert %}} 

Ce code Java vous montre comment définir l’arrière-plan d’une présentation :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Guide d’index** : 0 correspond à aucun remplissage. L’index commence à 1.

{{% alert color="info" title="TIP" %}} 
Vous voudrez peut-être voir l'[Arrière‑plan PowerPoint](/slides/fr/java/presentation-background/).
{{% /alert %}}

## **Modifier l’effet du thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de style. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme#getEffectStyles--)) de la classe [FormatScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FormatScheme), vous pouvez modifier les éléments d’un thème (de façon encore plus flexible que les options de PowerPoint).

Ce code Java vous montre comment modifier un effet de thème en changeant des parties d’éléments :
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Les changements résultants dans la couleur de remplissage, le type de remplissage, l’effet d’ombre, etc. :
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Puis‑je appliquer un thème à une seule diapositive sans modifier le maître ?

Oui. Aspose.Slides prend en charge les remplacements de thème au niveau de la diapositive, de sorte que vous pouvez appliquer un thème local à cette diapositive uniquement tout en conservant le thème maître intact (via le [SlideThemeManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidethememanager/)).

### Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?

[Cloner les diapositives](/slides/fr/java/clone-slides/) avec leur maître dans la présentation cible. Cela préserve le maître original, les mises en page, et le thème associé afin que l’apparence reste cohérente.

### Comment puis‑je voir les valeurs « effectives » après toute héritage et tous les remplacements ?

Utilisez les [vues « effectives »](/slides/fr/java/shape-effective-properties/) pour le thème/couleur/police/effet. Elles renvoient les propriétés résolues et finales après l’application du maître ainsi que les éventuels remplacements locaux.
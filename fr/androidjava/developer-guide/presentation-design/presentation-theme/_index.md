---
title: Thème de Présentation
type: docs
weight: 10
url: /androidjava/presentation-theme/
keywords: "Thème, thème PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Thème de présentation PowerPoint en Java"
---

Un thème de présentation définit les propriétés des éléments de design. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème se compose de couleurs, [polices](/slides/androidjava/powerpoint-fonts/), [styles d'arrière-plan](/slides/androidjava/presentation-background/), et effets.

![theme-constituents](theme-constituents.png)

## **Changer la Couleur du Théme**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments sur une diapositive. Si vous n'aimez pas les couleurs, vous pouvez les changer en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs sous l'énumération [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

Ce code Java montre comment changer la couleur d'accent pour un thème :

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Vous pouvez déterminer la valeur efficace de la couleur résultante de cette manière :

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Couleur [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Pour démontrer davantage l'opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d'accent (de l'opération initiale). Ensuite, nous changeons la couleur dans le thème :

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la Couleur du Thème à Partir de la Palette Supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème (1), des couleurs de la palette supplémentaire (2) sont formées. Vous pouvez ensuite définir et obtenir ces couleurs de thème. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Couleurs principales du thème

**2** - Couleurs de la palette supplémentaire.

Ce code Java démontre une opération où des couleurs de palette supplémentaire sont obtenues à partir de la couleur principale du thème et ensuite utilisées dans des formes :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, Plus clair 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Plus clair 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Plus clair 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Plus foncé 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Plus foncé 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Changer la Police du Thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d'autres raisons, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du Corps Latin (Police Mineure Latin)
* **+mj-lt** - Police de Titre Latin (Police Majeure Latin)
* **+mn-ea** - Police du Corps Est-Aisan (Police Mineure Est-Asiatique)
* **+mj-ea** - Police de Corps Est-Asiatique (Police Majeure Est-Asiatique)

Ce code Java montre comment attribuer la police latine à un élément de thème :

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Format de texte du thème");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Ce code Java montre comment changer la police du thème de présentation :

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

La police dans toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="ASTUCE" %}} 

Vous voudrez peut-être voir [les polices PowerPoint](/slides/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Changer le Style d'Arrière-plan du Thème**

Par défaut, l'application PowerPoint fournit 12 arrière-plans prédéfinis, mais seulement 3 de ces 12 arrière-plans sont sauvegardés dans une présentation typique. 

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l'application PowerPoint, vous pouvez exécuter ce code Java pour découvrir le nombre d'arrière-plans prédéfinis dans la présentation :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Le nombre de styles de remplissage d'arrière-plan pour le thème est de " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) de la classe [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), vous pouvez ajouter ou accéder au style d'arrière-plan dans un thème PowerPoint.

{{% /alert %}} 

Ce code Java montre comment définir l'arrière-plan pour une présentation :

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guide d'index** : 0 est utilisé pour aucun remplissage. L'index commence à 1.

{{% alert color="primary" title="ASTUCE" %}} 

Vous voudrez peut-être voir [l'Arrière-plan PowerPoint](/slides/androidjava/presentation-background/).

{{% /alert %}}

## **Changer l'Effet du Thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) de la classe [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), vous pouvez changer les éléments d'un thème (encore plus flexiblement que les options dans PowerPoint).

Ce code Java montre comment changer un effet de thème en modifiant des parties des éléments :

```java
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

Les changements résultants dans la couleur de remplissage, le type de remplissage, l'effet d'ombre, etc. :

![todo:image_alt_text](presentation-design_11.png)
---
title: Gérer les thèmes de présentation sur Android
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/androidjava/presentation-theme/
keywords:
- Thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- changer le thème
- gérer le thème
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Maîtriser les thèmes de présentation dans Aspose.Slides pour Android via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---

Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d’éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/androidjava/powerpoint-fonts/), [styles d’arrière-plan](/slides/fr/androidjava/presentation-background/), et des effets.

![theme-constituents](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments d’une diapositive. Si les couleurs ne vous plaisent pas, vous les modifiez en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs dans l’énumération [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

Ce code Java montre comment modifier la couleur d’accent d’un thème :
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


Vous pouvez déterminer la valeur effective de la couleur résultante de cette façon :
```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Pour illustrer davantage l’opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d’accent (de l’opération initiale). Ensuite, nous modifions la couleur dans le thème :
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


La nouvelle couleur est appliquée automatiquement sur les deux éléments.

### **Définir la couleur du thème à partir d’une palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème (1), des couleurs provenant de la palette supplémentaire (2) sont générées. Vous pouvez alors définir et obtenir ces couleurs de thème. 

![additional-palette-colors](additional-palette-colors.png)

**1** – Couleurs principales du thème

**2** – Couleurs de la palette supplémentaire.

Ce code Java montre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème, puis utilisées dans des formes :
```java
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et à d’autres fins, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du corps Latin (Police Latin mineure)
* **+mj-lt** - Police du titre Latin (Police Latin majeure)
* **+mn-ea** - Police du corps Asie de l’Est (Police Asie de l’Est mineure)
* **+mj-ea** - Police du titre Asie de l’Est (Police Asie de l’Est majeure)

Ce code Java montre comment affecter la police Latin à un élément du thème :
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


Ce code Java montre comment changer la police du thème de la présentation :
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


La police de toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="ASTUCE" %}} 
Vous voudrez peut-être consulter les [polices PowerPoint](/slides/fr/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière-plan du thème**

Par défaut, l'application PowerPoint propose 12 arrière-plans prédéfinis, mais seuls 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique. 

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l'application PowerPoint, vous pouvez exécuter ce code Java pour connaître le nombre d’arrière-plans prédéfinis dans la présentation :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) de la classe [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), vous pouvez ajouter ou accéder au style d’arrière-plan dans un thème PowerPoint.
{{% /alert %}} 

Ce code Java montre comment définir l’arrière‑plan d’une présentation :
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


Guide d’index : 0 correspond à aucun remplissage. L’index commence à 1.

{{% alert color="primary" title="ASTUCE" %}} 
Vous voudrez peut-être consulter le [fond PowerPoint](/slides/fr/androidjava/presentation-background/).
{{% /alert %}}

## **Modifier l’effet du thème**

Un thème PowerPoint comporte généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant les 3 propriétés ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) de la classe [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), vous pouvez modifier les éléments d’un thème (de façon encore plus flexible que les options de PowerPoint).

Ce code Java montre comment changer un effet de thème en modifiant certaines parties des éléments :
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


Les changements résultants de la couleur de remplissage, du type de remplissage, de l’effet d’ombre, etc. :

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans modifier le maître ?**

Oui. Aspose.Slides prend en charge les surcharges de thème au niveau de la diapositive, vous permettant d’appliquer un thème local uniquement à cette diapositive tout en conservant le thème maître intact (via le [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/)).

**Quelle est la méthode la plus sûre pour transférer un thème d’une présentation à une autre ?**

[Cloner les diapositives](/slides/fr/androidjava/clone-slides/) avec leur maître dans la présentation cible. Cela préserve le maître, les mises en page et le thème associé afin que l’apparence reste cohérente.

**Comment puis‑je voir les valeurs « effectives » après toute l’héritage et les surcharges ?**

Utilisez les vues « effective » de l’API pour le thème/couleur/police/effet. Elles renvoient les propriétés résolues et finales après l’application du maître ainsi que toutes les surcharges locales.
---
title: Obtenir les propriétés effectives des formes à partir de présentations en Java
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- rig d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Java calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de mise en forme spécifique, tel que :

1. Propriétés de portion sur une diapositive.
1. Styles de texte de forme prototype sur une diapositive de disposition ou maître, lorsque la forme du cadre de texte de la portion en possède un.
1. Paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n'importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final « tel qu'affiché », il résout la chaîne d'héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `getEffective` sur l'objet de format local.

L'exemple suivant montre comment obtenir les valeurs effectives. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) avec un cadre de texte et au moins une portion.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Les données de formatage effectif représentent le formatage calculé actuel après l'application de l'héritage. Dans l'implémentation actuelle, certains objets de données effectives, tels que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPortionFormatEffectiveData), peuvent être mis en cache en interne. Appeler de nouveau `getEffective` après avoir modifié le formatage parent ou hérité peut actualiser le cache, et un objet obtenu précédemment peut ne plus représenter l'état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, telles que la hauteur de police, la couleur de remplissage, le style de police ou l'alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d’une caméra**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'une caméra. L'interface [ICameraEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICameraEffectiveData) représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICameraEffectiveData) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormatEffectiveData), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormat).

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la caméra. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un dispositif d’éclairage**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'un dispositif d'éclairage. L'interface [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ILightRigEffectiveData) représente un objet immuable contenant les propriétés effectives du dispositif d'éclairage. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ILightRigEffectiveData) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormatEffectiveData), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormat).

L'exemple de code suivant montre comment obtenir les propriétés effectives pour le dispositif d'éclairage. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’une forme biseautée**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'un biseau de forme. L'interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeBevelEffectiveData) représente un objet immuable contenant les propriétés de relief de face effectives d'une forme. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeBevelEffectiveData) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormatEffectiveData), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IThreeDFormat).

L'exemple de code suivant montre comment obtenir les propriétés effectives du biseau supérieur d'une forme. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un cadre de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un cadre de texte. L'interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormatEffectiveData) contient les propriétés de formatage effectif du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) avec un cadre de texte.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un style de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un style de texte. L'interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextStyleEffectiveData) contient les propriétés effectives du style de texte.

L'exemple de code suivant montre comment obtenir les propriétés effectives du style de texte. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) avec un cadre de texte.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir la valeur effective de la hauteur de police**

Avec Aspose.Slides, vous pouvez obtenir la hauteur de police effective. Le code suivant montre comment la hauteur de police effective d'une portion change après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir le format de remplissage effectif d’un tableau**

Avec Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d'un tableau. L'interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IFillFormatEffectiveData) contient les propriétés de format de remplissage effectif. Le format de cellule a une priorité supérieure à celui de la ligne, le format de ligne a une priorité supérieure à celui de la colonne, et le format de colonne a une priorité supérieure à celui du tableau entier.

En conséquence, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICellFormatEffectiveData) sont utilisées pour dessiner la cellule du tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est un [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` renvoie-t-il un instantané ?**

Pas toujours. Les données effectives représentent le formatage calculé après l'application de l'héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel `getEffective` ultérieur peut recalculer le formatage et rafraîchir le cache, de sorte qu'un objet obtenu précédemment ne doit pas être considéré comme un instantané durable.

**Quand dois‑je relire les propriétés effectives ?**

Appelez `getEffective` de nouveau après avoir modifié le formatage local, les styles parents, le formatage de la disposition, le formatage du maître ou les paramètres par défaut au niveau de la présentation. L'appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

**La modification ou la suppression d’une diapositive de disposition/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais le changement ne se reflète qu'au prochain appel `getEffective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives obtenues précédemment peuvent être obsolètes. Dès qu'`getEffective` est appelé de nouveau, Aspose.Slides réévalue l'arbre de formatage et les polices, couleurs, tailles ou autres valeurs résultantes peuvent changer.

**Puis‑je modifier des valeurs via les objets de données effectives ?**

Non. Les objets de données effectives exposent les valeurs calculées. Modifiez les objets de formatage locaux, puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la disposition/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut, qui comprend les valeurs par défaut de PowerPoint et d'Aspose.Slides. Cette valeur résolue fait partie des données effectives actuelles.

**À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?**

Pas directement. Les données effectives renvoient la valeur finale. Pour connaître la source, vérifiez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte et des styles de texte à la disposition, au maître et à la présentation afin de voir où apparaît la première définition explicite.

**Pourquoi les valeurs effectives sont parfois identiques aux valeurs locales ?**

Parce que la valeur locale s'est avérée finale (aucune héritage de niveau supérieur n'était nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand dois‑je utiliser les propriétés effectives et quand travailler uniquement avec les propriétés locales ?**

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu'affiché » après l'application de tout l'héritage, par exemple pour aligner les couleurs, les retraits ou les tailles. Si vous devez conserver ces valeurs indépendamment des modifications de formatage ultérieures, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.
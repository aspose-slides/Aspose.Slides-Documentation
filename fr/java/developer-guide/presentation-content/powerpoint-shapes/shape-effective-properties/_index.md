---
title: Obtenir les propriétés effectives des formes à partir des présentations en Java
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- rig d'éclairage
- forme biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Java calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---

Dans ce sujet, nous allons aborder les propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou maître (si la forme du cadre de texte de la portion en possède un) ;
1. Dans les paramètres de texte globaux de la présentation ;

ces valeurs sont appelées valeurs **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi doit ressembler la portion, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

Cet exemple de code montre comment obtenir les valeurs effectives :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get Effective Properties of a Camera**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cet effet, l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) représente un objet immutable qui contient les propriétés de caméra effectives. Une instance de l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Cet exemple de code montre comment obtenir les propriétés effectives de la caméra :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get Effective Properties of a Light Rig**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives du dispositif d’éclairage. À cet effet, l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) représente un objet immutable qui contient les propriétés de dispositif d’éclairage effectives. Une instance de l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Cet exemple de code montre comment obtenir les propriétés effectives du dispositif d’éclairage :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives de la forme biseau. À cet effet, l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L’interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) représente un objet immutable qui contient les propriétés de relief de forme biseau effectives. Une instance de l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) , qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Cet exemple de code montre comment obtenir les propriétés effectives de la forme biseau :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get Effective Properties of a Text Frame**
Avec Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives d’un cadre de texte. À cet effet, l’interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage de cadre de texte effectives.

Cet exemple de code montre comment obtenir les propriétés de formatage de cadre de texte effectives :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get Effective Properties of a Text Style**
Avec Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives du style de texte. À cet effet, l’interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de style de texte effectives.

Cet exemple de code montre comment obtenir les propriétés de style de texte effectives :
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get the Effective Font Height Value**
Avec Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Vous trouverez ici un exemple de code montrant la valeur de hauteur de police effective d’une portion qui change après que des valeurs de hauteur de police locales ont été définies à différents niveaux de la structure de la présentation :
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Get the Effective Fill Format for a Table**
Avec Aspose.Slides for Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cet effet, l’interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de remplissage effectives. Veuillez noter : le format de cellule a toujours la priorité sur le format de ligne ; la ligne a priorité sur la colonne ; et la colonne a priorité sur le tableau entier.
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

Les objets EffectiveData sont des instantanés immutables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour ; il faut le demander de nouveau après avoir modifié la mise en page ou le maître.

**Can I modify values through EffectiveData?**

Non. EffectiveData est en lecture seule. Effectuez les modifications dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue fait partie de l’instantané EffectiveData.

**From an effective font value, can I tell which level provided the size or typeface?**

Pas directement. EffectiveData renvoie la valeur finale. Pour identifier la source, vérifiez les valeurs locales au niveau de la portion/du paragraphe/du cadre de texte et les styles de texte au niveau de la mise en page/du maître/de la présentation pour voir où la première définition explicite apparaît.

**Why do EffectiveData values sometimes look identical to the local ones?**

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’était nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

**When should I use effective properties, and when should I work only with local ones?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après l’application de toute l’héritage (par ex. pour aligner les couleurs, retraits ou tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.
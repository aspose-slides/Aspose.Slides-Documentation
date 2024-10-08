---
title: Propriétés Efficaces de Forme
type: docs
weight: 50
url: /fr/androidjava/shape-effective-properties/
---

Dans ce sujet, nous allons discuter des **propriétés** **efficaces** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux :

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou de maître (si la forme du cadre de texte de la portion en a un) ;
1. Dans les paramètres de texte globaux de la présentation ;

ces valeurs sont appelées valeurs **locales**. À n'importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsque l'application a besoin de savoir à quoi la portion doit ressembler, elle utilise les valeurs **efficaces**. Vous pouvez obtenir les valeurs efficaces en utilisant la méthode **getEffective()** du format local.

Ce code d'exemple vous montre comment obtenir des valeurs efficaces :

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

## **Obtention des Propriétés Efficaces de la Caméra**
Aspose.Slides pour Android via Java permet aux développeurs d'obtenir les propriétés efficaces de la caméra. À cette fin, l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) représente un objet immuable qui contient les propriétés efficaces de la caméra. Une instance de l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Ce code d'exemple montre comment obtenir les propriétés efficaces pour la caméra :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propriétés efficaces de la caméra =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Champ de vision: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention des Propriétés Efficaces du Rig de Lumière**
Aspose.Slides pour Android via Java permet aux développeurs d'obtenir les propriétés efficaces du Rig de Lumière. À cette fin, l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) représente un objet immuable qui contient les propriétés efficaces du rig de lumière. Une instance de l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Ce code d'exemple montre comment obtenir les propriétés efficaces du Rig de Lumière :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propriétés efficaces du rig de lumière =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention des Propriétés Efficaces de la Forme Biseautée**
Aspose.Slides pour Android via Java permet aux développeurs d'obtenir les propriétés efficaces de la Forme Biseautée. À cette fin, l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L'interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) représente un objet immuable qui contient les propriétés de relief de la face de la forme. Une instance de l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Ce code d'exemple montre comment obtenir les propriétés efficaces pour la Forme Biseautée :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propriétés efficaces de la face supérieure de la forme =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Largeur: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Hauteur: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention des Propriétés Efficaces d'un Cadre de Texte**
En utilisant Aspose.Slides pour Android via Java, vous pouvez obtenir les propriétés efficaces d'un Cadre de Texte. À cette fin, l'interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient des propriétés de formatage de cadre de texte efficaces.

Ce code d'exemple montre comment obtenir les propriétés de formatage du cadre de texte efficace :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Type d'ancrage: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Type d'ajustement automatique: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Type de texte vertical: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Marges");
    System.out.println("   Gauche: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Haut: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Droite: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bas: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention des Propriétés Efficaces d'un Style de Texte**
En utilisant Aspose.Slides pour Android via Java, vous pouvez obtenir les propriétés efficaces d'un Style de Texte. À cette fin, l'interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient des propriétés de style de texte efficaces.

Ce code d'exemple montre comment obtenir les propriétés de style de texte efficaces :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Formatage de paragraphe efficace pour le niveau de style #" + i + " =");

        System.out.println("Profondeur: " + effectiveStyleLevel.getDepth());
        System.out.println("Indentation: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignement: " + effectiveStyleLevel.getAlignment());
        System.out.println("Alignement de police: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention de la Valeur de Hauteur de Police Efficace**
En utilisant Aspose.Slides pour Android via Java, vous pouvez obtenir les propriétés efficaces de la Hauteur de Police. Ici, nous fournissons un code qui montre la valeur de hauteur de police efficace de la portion changeant après que des valeurs de hauteur de police locales soient définies à différents niveaux de structure de présentation :

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Texte d'exemple avec la première portion");
    IPortion portion1 = new Portion(" et la deuxième portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Hauteur de police efficace juste après la création :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police par défaut de toute la présentation :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police par défaut du paragraphe :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police de la portion #0 :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police de la portion #1 :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtention du Format de Remplissage Efficace pour le Tableau**
En utilisant Aspose.Slides pour Android via Java, vous pouvez obtenir le format de remplissage efficace pour différentes parties logiques du tableau. À cette fin, l'interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient des propriétés de formatage de remplissage efficaces. Veuillez noter ceci : le formatage des cellules a toujours la priorité sur le formatage des lignes ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur l'ensemble du tableau.

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
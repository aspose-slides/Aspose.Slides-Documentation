---
title: Propriétés Efficaces de Forme
type: docs
weight: 50
url: /java/shape-effective-properties/
---

Dans ce sujet, nous allons discuter des propriétés **efficaces** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou la diapositive maître (si le cadre de texte de la forme de portion en a un) ;
1. Dans les paramètres de texte globaux de la présentation ;

ces valeurs sont appelées valeurs **locales**. À tout niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsque une application a besoin de savoir à quoi la portion devrait ressembler, elle utilise les valeurs **efficaces**. Vous pouvez obtenir les valeurs efficaces en utilisant la méthode **getEffective()** à partir du format local.

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

## **Obtenir les Propriétés Efficaces de la Caméra**
Aspose.Slides pour Java permet aux développeurs d'obtenir les propriétés efficaces de la caméra. Pour ce faire, l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) représente un objet immutable qui contient les propriétés efficaces de la caméra. Une instance de l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir les propriétés efficaces de la caméra :

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

## **Obtenir les Propriétés Efficaces de la Rig de Lumière**
Aspose.Slides pour Java permet aux développeurs d'obtenir les propriétés efficaces de la Rig de Lumière. Pour ce faire, l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) représente un objet immutable qui contient les propriétés efficaces de la rig de lumière. Une instance de l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) est utilisée comme partie de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir les propriétés efficaces de la Rig de Lumière :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propriétés efficaces de la rig de lumière =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les Propriétés Efficaces de la Forme de Biseau**
Aspose.Slides pour Java permet aux développeurs d'obtenir les propriétés efficaces de la Forme de Biseau. Pour ce faire, l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L'interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) représente un objet immutable qui contient les propriétés de relief de face de la forme. Une instance de l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir les propriétés efficaces pour la Forme de Biseau :

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propriétés efficaces du relief supérieur de la forme =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Largeur: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Hauteur: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les Propriétés Efficaces d'un Cadre de Texte**
En utilisant Aspose.Slides pour Java, vous pouvez obtenir les propriétés efficaces d'un Cadre de Texte. Pour ce faire, l'interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage efficace du cadre de texte.

Ce code d'exemple vous montre comment obtenir les propriétés de formatage efficace du cadre de texte :

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
    System.out.println("   Droit: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bas: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les Propriétés Efficaces d'un Style de Texte**
En utilisant Aspose.Slides pour Java, vous pouvez obtenir les propriétés efficaces d'un Style de Texte. Pour ce faire, l'interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés efficaces de style de texte.

Ce code d'exemple vous montre comment obtenir les propriétés efficaces de style de texte :

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
        System.out.println("Alignement de la police: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir la Valeur Efficace de la Hauteur de Police**
En utilisant Aspose.Slides pour Java, vous pouvez obtenir les propriétés efficaces de la Hauteur de Police. Ici, nous fournissons un code qui montre la valeur efficace de la hauteur de police d'une portion changeant après que des valeurs de hauteur de police locales soient définies à différents niveaux de structure de présentation :

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
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police par défaut de l'ensemble de la présentation :");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Hauteur de police efficace après avoir défini la hauteur de police par défaut de paragraphe :");
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

## **Obtenir le Format de Remplissage Efficace pour un Tableau**
En utilisant Aspose.Slides pour Java, vous pouvez obtenir le formatage de remplissage efficace pour différentes parties logiques d'un tableau. Pour ce faire, l'interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) a été ajoutée dans Aspose.Slides. Elle contient les propriétés de formatage de remplissage efficace. Veuillez noter ceci : le formatage des cellules a toujours priorité sur le formatage des lignes ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur l'ensemble du tableau.

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
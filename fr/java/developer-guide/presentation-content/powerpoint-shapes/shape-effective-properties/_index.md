---
title: Obtenir les propriétés effectives des formes dans les présentations Java
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

Dans ce sujet, nous aborderons les propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de partie sur la diapositive de la partie ;
1. Dans le style de texte de forme prototype sur la diapositive de disposition ou maître (si la forme du cadre de texte de la partie en possède un) ;
1. Dans les paramètres de texte globaux de la présentation ;

Ces valeurs sont appelées valeurs **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi doit ressembler la partie, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

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


## **Obtenir les propriétés effectives d’une caméra**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cette fin, l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

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


## **Obtenir les propriétés effectives d’un Light Rig**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives du Light Rig. À cette fin, l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) représente un objet immuable qui contient les propriétés effectives du Light Rig. Une instance de l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Cet exemple de code montre comment obtenir les propriétés effectives du Light Rig :
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


## **Obtenir les propriétés effectives d’une Bevel Shape**
Aspose.Slides for Java permet aux développeurs d’obtenir les propriétés effectives d’une forme à biseau. À cette fin, l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L’interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) représente un objet immuable qui contient les propriétés effectives du relief de la forme. Une instance de l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) est utilisée comme partie de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Cet exemple de code montre comment obtenir les propriétés effectives de la Bevel Shape :
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


## **Obtenir les propriétés effectives d’un cadre de texte**
En utilisant Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives d’un cadre de texte. À cette fin, l’interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage effectif du cadre de texte.

Cet exemple de code montre comment obtenir les propriétés de formatage effectif du cadre de texte :
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


## **Obtenir les propriétés effectives d’un style de texte**
En utilisant Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives d’un style de texte. À cette fin, l’interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives du style de texte.

Cet exemple de code montre comment obtenir les propriétés effectives du style de texte :
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


## **Obtenir la valeur effective de la hauteur de police**
En utilisant Aspose.Slides for Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Voici un exemple de code qui montre la valeur effective de la hauteur de police de la partie changer après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation :
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


## **Obtenir le format de remplissage effectif d’un tableau**
En utilisant Aspose.Slides for Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cette fin, l’interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de format de remplissage effectif. Veuillez noter : le format de cellule a toujours la priorité sur le format de ligne ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur le tableau entier.
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

**Comment savoir si j’ai obtenu un « instantané » plutôt qu’un « objet vivant », et quand devrais‑je relire les propriétés effectives ?**  
Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**Le fait de modifier la diapositive de disposition/maître affecte‑t‑il les propriétés effectives déjà récupérées ?**  
Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour — il faut le demander à nouveau après avoir modifié la disposition ou le maître.

**Puis‑je modifier des valeurs via EffectiveData ?**  
Non. EffectiveData est en lecture seule. Apportez les modifications aux objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la disposition/maître, ni dans les paramètres globaux ?**  
La valeur effective est déterminée par le mécanisme par défaut (les valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je savoir quel niveau a fourni la taille ou la police ?**  
Pas directement. EffectiveData renvoie la valeur finale. Pour identifier la source, examinez les valeurs locales au niveau de la partie/du paragraphe/du cadre de texte et les styles de texte au niveau de la disposition/du maître/de la présentation afin de voir où apparaît la première définition explicite.

**Pourquoi les valeurs EffectiveData sont parfois identiques aux valeurs locales ?**  
Parce que la valeur locale devient finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand dois‑je utiliser les propriétés effectives et quand travailler uniquement avec les propriétés locales ?**  
Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’affiché » après l’application de tout l’héritage (par ex., pour aligner les couleurs, les retraits ou les tailles). Si vous devez modifier le formatage à un niveau précis, modifiez les propriétés locales et, si nécessaire, relisez EffectiveData pour vérifier le résultat.
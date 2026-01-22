---
title: Obtenir les propriétés effectives des formes à partir des présentations en JavaScript
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/nodejs-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- rig d'éclairage
- forme biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Node.js via Java calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---

Dans ce sujet, nous discuterons des propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou maître (si la forme de cadre de texte de la portion en possède une) ;
1. Dans les paramètres globaux de texte de la présentation ;

Ces valeurs sont appelées valeurs **locales**. À n’importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi doit ressembler la portion, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

Ce code d’exemple montre comment obtenir des valeurs effectives :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés effectives de la caméra**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cet effet, la classe **CameraEffectiveData** a été ajoutée à Aspose.Slides. La classe **CameraEffectiveData** représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives de la caméra :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés effectives du Light Rig**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives du Light Rig. À cet effet, la classe **LightRigEffectiveData** a été ajoutée à Aspose.Slides. La classe **LightRigEffectiveData** représente un objet immuable contenant les propriétés effectives du dispositif d’éclairage. Une instance de la classe **LightRigEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives du Light Rig :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés effectives de la forme biseau**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives de la forme biseau. À cet effet, la classe **ShapeBevelEffectiveData** a été ajoutée à Aspose.Slides. La classe **ShapeBevelEffectiveData** représente un objet immuable contenant les propriétés effectives du soulagement de face de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives de la forme biseau :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés effectives d’un cadre de texte**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives d’un cadre de texte. À cet effet, la classe **TextFrameFormatEffectiveData** a été ajoutée à Aspose.Slides. Elle contient les propriétés de mise en forme effectives du cadre de texte.

Ce code d’exemple montre comment obtenir les propriétés de mise en forme effectives du cadre de texte :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés effectives d’un style de texte**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives d’un style de texte. À cet effet, la classe **TextStyleEffectiveData** a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives du style de texte.

Ce code d’exemple montre comment obtenir les propriétés effectives du style de texte :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir la valeur effective de la hauteur de police**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Ici, nous fournissons un code qui montre la valeur effective de la hauteur de police de la portion changer après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir le format de remplissage effectif pour le tableau**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cet effet, la classe **CellFormatEffectiveData** a été ajoutée dans Aspose.Slides. Elle contient les propriétés de format de remplissage effectives. Veuillez noter : le format de cellule a toujours priorité sur le format de ligne ; la ligne a priorité sur la colonne ; et la colonne a priorité sur le tableau entier.
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment savoir si j’ai obtenu un « instantané » plutôt qu’un « objet en direct », et quand devrais‑je relire les propriétés effectives ?**  
Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**Le fait de modifier la diapositive de mise en page/maître affecte‑t‑il les propriétés effectives déjà récupérées ?**  
Oui, mais seulement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour — il faut le demander de nouveau après avoir modifié la mise en page ou le maître.

**Puis‑je modifier les valeurs via EffectiveData ?**  
Non. EffectiveData est en lecture seule. Apportez les modifications dans les objets de mise en forme locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**  
La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?**  
Pas directement. EffectiveData renvoie la valeur finale. Pour en identifier la source, examinez les valeurs locales au niveau de la portion/paragraphe/cadre de texte et les styles de texte au niveau de la mise en page/maître/présentation pour voir où la première définition explicite apparaît.

**Pourquoi les valeurs EffectiveData sont parfois identiques aux valeurs locales ?**  
Parce que la valeur locale s’avère finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand faut‑il utiliser les propriétés effectives, et quand travailler uniquement avec les propriétés locales ?**  
Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il est rendu » après l’application de tous les héritages (par ex. pour aligner les couleurs, les retraits ou les tailles). Si vous devez modifier la mise en forme à un niveau précis, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.
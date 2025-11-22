---
title: Propriétés effectives de la forme
type: docs
weight: 50
url: /fr/nodejs-java/shape-effective-properties/
---

Dans ce sujet, nous aborderons les propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou maître (si la forme de zone de texte de la portion en possède une) ;
1. Dans les paramètres globaux du texte de la présentation ;

ces valeurs sont appelées valeurs **locales**. À n’importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi doit ressembler la portion, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

Ce code d’exemple montre comment obtenir les valeurs effectives :
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


## **Obtention des propriétés effectives de la caméra**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cette fin, la classe [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) a été ajoutée à Aspose.Slides. La classe [CameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) représente un objet immutable qui contient les propriétés effectives de la caméra. Une instance de la classe [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) est utilisée comme partie de la classe [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

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


## **Obtention des propriétés effectives du dispositif d’éclairage**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives du dispositif d’éclairage. À cette fin, la classe [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) a été ajoutée à Aspose.Slides. La classe [LightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) représente un objet immutable qui contient les propriétés effectives du dispositif d’éclairage. Une instance de la classe [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) est utilisée comme partie de la classe [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives du dispositif d’éclairage :
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


## **Obtention des propriétés effectives de la forme biseau**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir les propriétés effectives de la forme biseau. À cette fin, la classe [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. La classe [ShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) représente un objet immutable qui contient les propriétés effectives du relief de la forme. Une instance de la classe [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) est utilisée comme partie de la classe [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)) qui constitue une paire de [valeurs effectives](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

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


## **Obtention des propriétés effectives d’un cadre de texte**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives d’un cadre de texte. À cette fin, la classe [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage effectives du cadre de texte.

Ce code d’exemple montre comment obtenir les propriétés de formatage effectives du cadre de texte :
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
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


## **Obtention des propriétés effectives d’un style de texte**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives d’un style de texte. À cette fin, la classe [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives du style de texte.

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


## **Obtention de la valeur effective de la hauteur de police**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Ici, nous fournissons un code qui montre la valeur effective de la hauteur de police d’une portion changeant après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation :
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


## **Obtention du format de remplissage effectif pour un tableau**
En utilisant Aspose.Slides for Node.js via Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cette fin, la classe [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de format de remplissage effectives. Notez ce qui suit : le format de cellule a toujours la priorité sur le format de ligne ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur le tableau entier.
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

**Comment savoir si j’ai obtenu un « instantané » plutôt qu’un « objet vivant », et quand dois‑je relire les propriétés effectives ?**

Les objets EffectiveData sont des instantanés immutables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**La modification de la diapositive de mise en page/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais seulement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour — il faut le requérir à nouveau après avoir changé la mise en page ou le maître.

**Puis‑je modifier des valeurs via EffectiveData ?**

Non. EffectiveData est en lecture seule. Apportez les changements dans les objets de formatage locaux (forme/texte/3D, etc.) puis récupérez de nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je savoir quel niveau a fourni la taille ou la police ?**

Pas directement. EffectiveData renvoie la valeur finale. Pour en connaître la source, examinez les valeurs locales au niveau de la portion/paragraphe/cadre de texte et les styles de texte au niveau de la mise en page/maître/présentation afin de voir où la première définition explicite apparaît.

**Pourquoi les valeurs EffectiveData ressemblent parfois aux valeurs locales ?**

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand faut‑il utiliser les propriétés effectives et quand travailler uniquement avec les locales ?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après l’application de toute l’héritage (par ex., pour aligner les couleurs, retraits ou tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si besoin, relisez EffectiveData pour vérifier le résultat.
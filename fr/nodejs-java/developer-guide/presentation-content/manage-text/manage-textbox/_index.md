---
title: Gérer les zones de texte dans les présentations avec JavaScript
linktitle: Gérer une zone de texte
type: docs
weight: 20
url: /fr/nodejs-java/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides pour Node.js facilite la création, la modification et le clonage des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi votre automatisation de présentations."
---
## **Introduction**

Les textes sur les diapositives sont généralement placés dans des zones de texte ou des formes. Ainsi, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis y placer du texte. Aspose.Slides pour Node.js via Java fournit la classe [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AutoShape) qui permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également la classe [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape) qui permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via la classe `Shape` ne peuvent pas contenir de texte. En revanche, les formes ajoutées via la classe [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AutoShape) peuvent contenir du texte.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez une forme à laquelle vous souhaitez ajouter du texte, il peut être utile de vérifier qu’elle a été castée via la classe `AutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrame), qui est une propriété de `AutoShape`. Consultez la section [Update Text](https://docs.aspose.com/slides/fr/nodejs-java/manage-textbox/#update-text) de cette page.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AutoShape) avec [ShapeType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l’objet `AutoShape` nouvellement ajouté.
4. Ajoutez une propriété `TextFrame` à l’objet `AutoShape` qui contiendra du texte. Dans l’exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`. 

Ce code JavaScript — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie la présentation
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive de la présentation
    var sld = pres.getSlides().get_Item(0);
    // Ajoute une AutoShape avec le type défini sur Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Ajoute un TextFrame au rectangle
    ashp.addTextFrame(" ");
    // Accède au text frame
    var txtFrame = ashp.getTextFrame();
    // Crée l’objet Paragraph pour le text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crée un objet Portion pour le paragraphe
    var portion = para.getPortions().get_Item(0);
    // Définit le texte
    portion.setText("Aspose TextBox");
    // Enregistre la présentation sur le disque
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vérifier la forme de zone de texte**

Aspose.Slides fournit la méthode [isTextBox](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#isTextBox) de la classe [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) qui vous permet d’examiner les formes et d’identifier les zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code JavaScript montre comment vérifier si une forme a été créée en tant que zone de texte :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Notez que si vous ajoutez simplement une autoshape à l’aide de la méthode `addAutoShape` de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/) , la méthode `isTextBox` de l’autoshape renverra `false`. En revanche, après avoir ajouté du texte à l’autoshape avec la méthode `addTextFrame` ou la méthode `setText`, la propriété `isTextBox` renverra `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() renvoie false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() renvoie true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() renvoie false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() renvoie true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() renvoie false
shape3.addTextFrame("");
// shape3.isTextBox() renvoie false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() renvoie false
shape4.getTextFrame().setText("");
// shape4.isTextBox() renvoie false
```

## **Trouver la forme qui possède un TextFrame**

Dans un code générique de traitement du texte, vous pouvez recevoir un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) sans connaître à l’avance quel objet de présentation le contient. Utilisez la méthode [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape--) pour revenir à la [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) propriétaire.

Pour un text‑frame appartenant à une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) ou à une autre forme contenant du texte, [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape--) renvoie le propriétaire et [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentCell--) renvoie `null`. Les deux méthodes offrent une navigation en lecture seule, de sorte que les appeler ne modifie pas la propriété. Vérifiez toujours que la valeur renvoyée n’est pas `null` avant d’accéder à la forme.

Pour un exemple complet identifiant les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, voir [Recherche et remplacement de texte](/slides/fr/nodejs-java/search-and-replace-text/).

## **Ajouter une colonne dans la zone de texte**

Aspose.Slides propose les méthodes [setColumnCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) et [setColumnSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrameFormat) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement en points entre les colonnes.

Ce code JavaScript démontre l’opération décrite :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajoute une AutoShape avec le type défini sur Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ajoute un TextFrame au rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Obtient le format du texte du TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Spécifie le nombre de colonnes dans le TextFrame
    format.setColumnCount(3);
    // Spécifie l'espacement entre les colonnes
    format.setColumnSpacing(10);
    // Enregistre la présentation
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ajouter une colonne dans le TextFrame**

Aspose.Slides pour Node.js via Java fournit la méthode [setColumnCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrameFormat) qui permet d’ajouter des colonnes dans les text frames. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un text frame.

Ce code JavaScript montre comment ajouter une colonne à l’intérieur d’un text frame :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // L'espacement des colonnes n'a jamais été défini, il est donc indiqué comme NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes d’une présentation. 

Ce code JavaScript démontre une opération où tous les textes d’une présentation sont mis à jour ou modifiés :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Vérifie si la forme supporte un texte (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Parcourt les paragraphes du cadre de texte
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Parcourt chaque portion du paragraphe
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Modifie le texte
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Modifie le formatage
                    }
                }
            }
        }
    }
    // Enregistre la présentation modifiée
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ajouter une zone de texte avec hyperlien** 

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifique sur la diapositive et obtenez la référence de l’objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l’objet `AutoShape` et définissez le texte de sa première portion. Dans l’exemple ci‑dessus, nous avons utilisé ce texte : *Aspose.Slides*
5. Obtenez le `HyperlinkManager` de cette portion via son `PortionFormat`.
6. Appelez `setExternalHyperlinkClick` sur le `HyperlinkManager` pour attacher le lien à la portion.
7. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`. 

Ce code JavaScript — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie une classe Presentation qui représente un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajoute un objet AutoShape avec le type défini sur Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Convertit la forme en AutoShape
    var pptxAutoShape = shape;
    // Accède à la propriété ITextFrame associée à l'AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Ajoute du texte au cadre
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Définit le hyperlien pour le texte de la portion
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Enregistre la présentation PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lors de la manipulation des diapos maîtres ?**

Un [placeholder](/slides/fr/nodejs-java/manage-placeholder/) hérite du style et de la position du [master](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/), tandis qu’une zone de texte classique est un objet indépendant sur une diapositive précise et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans la présentation sans toucher le texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑shapes contenant des cadres de texte et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.
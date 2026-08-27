---
title: Beheer tekstvakken in presentaties met JavaScript
linktitle: Beheer Tekstvak
type: docs
weight: 20
url: /nl/nodejs-java/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides voor Node.js maakt het eenvoudig om tekstvakken te maken, bewerken en dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentaties-automatisering wordt verbeterd."
---
## **Introductie**

Teksten op dia’s bestaan meestal in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens wat tekst in het tekstvak plaatsen. Aspose.Slides for Node.js via Java biedt de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) klasse die je in staat stelt een vorm toe te voegen die tekst bevat.

{{% alert title="Info" color="info" %}}

Aspose.Slides biedt ook de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape) klasse die je toestaat vormen aan dia's toe te voegen. Echter, niet alle vormen die via de `Shape`-klasse worden toegevoegd, kunnen tekst bevatten. Vormen die via de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) klasse worden toegevoegd, kunnen wel tekst bevatten.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Daarom, wanneer je werkt met een vorm waaraan je tekst wilt toevoegen, wil je mogelijk controleren en bevestigen dat deze is gecast via de `AutoShape`-klasse. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame), dat een eigenschap is van `AutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/nodejs-java/manage-textbox/#update-text) op deze pagina.

{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak op een dia te maken, doorloop je de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) object toe met [ShapeType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `AutoShape`-object.
4. Voeg een `TextFrame`-eigenschap toe aan het `AutoShape`-object die tekst zal bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox*
5. Schrijf tenslotte het PPTX‑bestand via het `Presentation`‑object. 

Deze JavaScript‑code—een implementatie van de bovenstaande stappen—toont hoe je tekst aan een dia kunt toevoegen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieert Presentatie
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op uit de presentatie
    var sld = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe met type ingesteld op Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Voegt TextFrame toe aan de Rectangle
    ashp.addTextFrame(" ");
    // Benadert het tekstframe
    var txtFrame = ashp.getTextFrame();
    // Maakt het Paragraph-object voor het tekstframe
    var para = txtFrame.getParagraphs().get_Item(0);
    // Maakt een Portion-object voor de alinea
    var portion = para.getPortions().get_Item(0);
    // Stelt tekst in
    portion.setText("Aspose TextBox");
    // Slaat de presentatie op op schijf
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Controleren op tekstvakvorm**

Aspose.Slides biedt de [isTextBox](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#isTextBox) methode van de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) klasse, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Text box and shape](istextbox.png)

Deze JavaScript‑code laat zien hoe je kunt controleren of een vorm als tekstvak is aangemaakt:

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

Merk op dat als je simpelweg een autoshape toevoegt met de `addAutoShape`‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/) klasse, de `isTextBox`‑methode van de autoshape `false` retourneert. Nadat je echter tekst aan de autoshape hebt toegevoegd met de `addTextFrame`‑methode of de `setText`‑methode, geeft de `isTextBox`‑eigenschap `true` terug.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() retourneert false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() retourneert true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() retourneert false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() retourneert true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() retourneert false
shape3.addTextFrame("");
// shape3.isTextBox() retourneert false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() retourneert false
shape4.getTextFrame().setText("");
// shape4.isTextBox() retourneert false
```

## **Vind de vorm die een tekstframe bezit**

In generieke tekstverwerkingscode kun je een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) ontvangen zonder al te weten welk presentatie‑object het bevat. Gebruik de [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape--) methode om terug te navigeren naar de eigenaar, de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/).

Voor een tekstframe dat behoort tot een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) of een andere tekst‑behorende vorm, retourneert [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape--) de eigenaar en [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) `null`. Beide methoden bieden alleen‑lezen navigatie, dus aanroepen verandert de eigendom niet. Controleer altijd of de geretourneerde waarde `null` is voordat je toegang krijgt tot de vorm.

Voor een volledig voorbeeld dat vorm‑ en tabelcel‑eigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/nodejs-java/search-and-replace-text/).

## **Kolom toevoegen in tekstvak**

Aspose.Slides biedt de [setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) en [setColumnSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) methoden van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat) klasse die je in staat stellen kolommen aan tekstvakken toe te voegen. Je kunt het aantal kolommen in een tekstvak specificeren en de afstand in punten tussen kolommen instellen.

Deze JavaScript‑code demonstreert de beschreven bewerking: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op uit de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voeg een AutoShape toe met type ingesteld op Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Voeg TextFrame toe aan de Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Haalt het tekstformaat van TextFrame op
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Stelt het aantal kolommen in TextFrame in
    format.setColumnCount(3);
    // Stelt de afstand tussen kolommen in
    format.setColumnSpacing(10);
    // Slaat de presentatie op
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kolom toevoegen in tekstframe**

Aspose.Slides for Node.js via Java biedt de [setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat) klasse die je in staat stelt kolommen in tekstframes toe te voegen. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe instellen.

Deze JavaScript‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

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
        // De kolomafstand werd nooit ingesteld, dus wordt gerapporteerd als NaN.
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

## **Tekst bijwerken**

Aspose.Slides maakt het mogelijk om de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken.

Deze JavaScript‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of gewijzigd:

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
            // Controleert of vorm een tekstframe ondersteunt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Doorloopt alinea's in het tekstframe
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Doorloopt elke portion in de alinea
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Verandert tekst
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Verandert opmaak
                    }
                }
            }
        }
    }
    // Slaat gewijzigde presentatie op
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekstvak met hyperlink toevoegen** 

Je kunt een koppeling invoegen in een tekstvak. Wanneer op het tekstvak wordt geklikt, wordt de gebruiker doorgestuurd naar de link. 

Om een tekstvak met een link toe te voegen, doorloop je de volgende stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object en stel de tekst van het eerste segment in. In het onderstaande voorbeeld hebben we deze tekst gebruikt: *Aspose.Slides*
5. Verkrijg de `HyperlinkManager` van dat segment via zijn `PortionFormat`.
6. Roep `setExternalHyperlinkClick` aan op de `HyperlinkManager` om de link aan het segment toe te voegen.
7. Schrijf tenslotte het PPTX‑bestand via het `Presentation`‑object. 

Deze JavaScript‑code—een implementatie van de bovenstaande stappen—toont hoe je een tekstvak met een hyperlink aan een dia kunt toevoegen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op uit de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape-object toe met type ingesteld op Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Cast de vorm naar AutoShape
    var pptxAutoShape = shape;
    // Benadert de ITextFrame-eigenschap die bij de AutoShape hoort
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Voegt wat tekst toe aan het frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Stelt de hyperlink in voor de portion-tekst
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Slaat de PPTX-presentatie op
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/nodejs-java/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) en kan overschreven worden op [layouts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren door de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot auto‑shapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/)) uit door hun collecties apart te doorlopen of die objecttypen over te slaan.
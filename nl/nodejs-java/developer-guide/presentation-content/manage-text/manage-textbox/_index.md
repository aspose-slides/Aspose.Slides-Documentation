---
title: Beheer tekstvakken in presentaties met JavaScript
linktitle: Beheer tekstvak
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
description: "Aspose.Slides for Node.js maakt het eenvoudig om tekstvakken te maken, bewerken en dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia's staan doorgaans in tekstvakken of vormen. Daarom moet je om tekst toe te voegen aan een dia eerst een tekstvak toevoegen en vervolgens tekst in dat vak plaatsen. Aspose.Slides for Node.js via Java biedt de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape)-klasse die je in staat stelt een vorm met tekst toe te voegen.

{{% alert title="Info" color="info" %}}
Aspose.Slides biedt ook de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape)-klasse waarmee je vormen aan dia's kunt toevoegen. Niet alle vormen die via de `Shape`-klasse worden toegevoegd, kunnen tekst bevatten. Vormen die via de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape)-klasse worden toegevoegd, kunnen wel tekst bevatten.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daarom is het, wanneer je met een vorm werkt waaraan je tekst wilt toevoegen, verstandig om te controleren of deze via de `AutoShape`-klasse is aangemaakt. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame), een eigenschap van `AutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/nodejs-java/manage-textbox/#update-text) op deze pagina.
{{% /alert %}}

## **Tekstvak maken op dia**

Om een tekstvak op een dia te maken, doorloop je de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse.
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape)-object toe met [ShapeType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `AutoShape`-object.
4. Voeg een `TextFrame`-eigenschap toe aan het `AutoShape`-object die tekst bevat. In het onderstaande voorbeeld hebben we de volgende tekst toegevoegd: *Aspose TextBox*
5. Schrijf ten slotte het PPTX‑bestand via het `Presentation`-object. 

Deze JavaScript‑code—een implementatie van de bovenstaande stappen—laat zien hoe je tekst aan een dia toevoegt:

```javascript
// Instantieert de presentatie
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op in de presentatie
    var sld = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe met type ingesteld op Rechthoek
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Voegt een TextFrame toe aan de Rechthoek
    ashp.addTextFrame(" ");
    // Benadert het tekstframe
    var txtFrame = ashp.getTextFrame();
    // Creëert het Paragraph-object voor het tekstframe
    var para = txtFrame.getParagraphs().get_Item(0);
    // Creëert een Portion-object voor de alinea
    var portion = para.getPortions().get_Item(0);
    // Stelt de tekst in
    portion.setText("Aspose TextBox");
    // Slaat de presentatie op naar schijf
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Controleren op tekstvakvorm**

Aspose.Slides biedt de [isTextBox](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#isTextBox)-methode van de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/)‑klasse, waarmee je vormen kunt analyseren en tekstvakken kunt identificeren.

![Text box and shape](istextbox.png)

Deze JavaScript‑code toont hoe je controleert of een vorm als tekstvak is aangemaakt:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Merk op dat wanneer je simpelweg een autoshape toevoegt met de `addAutoShape`‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/)‑klasse, de `isTextBox`‑methode van de autoshape `false` retourneert. Nadat je echter tekst aan de autoshape hebt toegevoegd met de `addTextFrame`‑methode of de `setText`‑methode, geeft de `isTextBox`‑eigenschap `true` terug.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() geeft false terug
shape1.addTextFrame("shape 1");
// shape1.isTextBox() geeft true terug

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() geeft false terug
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() geeft true terug

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() geeft false terug
shape3.addTextFrame("");
// shape3.isTextBox() geeft false terug

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() geeft false terug
shape4.getTextFrame().setText("");
// shape4.isTextBox() geeft false terug
```

## **Kolom toevoegen in tekstvak**

Aspose.Slides biedt de [setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) en [setColumnSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) methoden van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)-klasse die je in staat stellen kolommen toe te voegen aan tekstvakken. Je kunt het aantal kolommen in een tekstvak opgeven en de afstand tussen kolommen in punten instellen.

Deze JavaScript‑code demonstreert de beschreven bewerking: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op in de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape toe met type ingesteld op Rechthoek
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Voegt een TextFrame toe aan de Rechthoek
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // Haalt het tekstopmaak op van TextFrame
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

Aspose.Slides for Node.js via Java biedt de [setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)-klasse die je toelaat kolommen toe te voegen in tekstframes. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven.

Deze JavaScript‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Deze JavaScript‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of veranderd:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Controleert of vorm tekstframe ondersteunt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Itereert door alinea's in het tekstframe
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Itereert door elke portie in de alinea
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Wijzigt tekst
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Wijzigt opmaak
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

## **Tekstvak toevoegen met hyperlink** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer het tekstvak wordt aangeklikt, wordt de gebruiker naar de koppeling geleid. 

Om een tekstvak met een koppeling toe te voegen, doorloop je de volgende stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object dat *Aspose TextBox* als standaardtekst bevat. 
5. Instantieer de `HyperlinkManager`‑klasse. 
6. Wijs het `HyperlinkManager`‑object toe aan de [HyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getHyperlinkClick--)‑eigenschap die bij het gewenste deel van het `TextFrame` hoort.
7. Schrijf ten slotte het PPTX‑bestand via het `Presentation`‑object. 

Deze JavaScript‑code—een implementatie van de bovenstaande stappen—laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```javascript
// Instantieert een Presentation-klasse die een PPTX representeert
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op in de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voegt een AutoShape-object toe met type ingesteld op Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Zet de vorm om naar AutoShape
    var pptxAutoShape = shape;
    // Toegang tot de ITextFrame-eigenschap die bij de AutoShape hoort
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Voeg wat tekst toe aan het frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Stel de hyperlink in voor de tekst van de portie
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

Een [placeholder](/slides/nl/nodejs-java/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) en kan worden overschreven op [lay-outs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object op een specifieke dia is en niet verandert wanneer je van lay-out wisselt.

**Hoe kan ik een massale tekstvervanging uitvoeren in de volledige presentatie zonder tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot auto‑shapes die tekstframes bevatten en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/)) uit door hun collecties apart te doorlopen of deze objecttypen over te slaan.
---
title: Beheer SmartArt-vormknopen in presentaties met JavaScript
linktitle: SmartArt-vormknoop
type: docs
weight: 30
url: /nl/nodejs-java/manage-smartart-shape-node/
keywords:
- SmartArt-knoop
- subknoop
- knoop toevoegen
- knooppositie
- knoop benaderen
- knoop verwijderen
- aangepaste positie
- assistentknoop
- vulformaat
- knoop renderen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer SmartArt-vormknopen in PPT en PPTX met Aspose.Slides for Node.js. Krijg duidelijke JavaScript-codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑afbeeldingen in PowerPoint‑presentaties worden georganiseerd via knopen die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatically met deze SmartArt‑knopen te werken: nieuwe knopen en sub‑knopen toe te voegen, sub‑knopen op een specifieke positie in te voegen, bestaande knopen te benaderen en hun tekst, niveau en positie te lezen.

Dit artikel legt uit hoe u SmartArt‑vormknopen beheert. Het toont hoe u knopen verwijdert, met sub‑knopen werkt op basis van index of positie, een assistent‑knoop verandert in een gewone knoop, de positie, grootte en rotatie van SmartArt‑knoopvormen aanpast, vul­formaten voor knopen instelt, en een miniatuurafbeelding genereert voor een SmartArt‑sub‑knoop.

## **SmartArt‑knoop toevoegen in PowerPoint‑presentatie met JavaScript**
Aspose.Slides for Node.js via Java biedt de eenvoudigste API om de SmartArt‑vormen op de makkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knoop en sub‑knoop binnen een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. [Voeg een nieuwe knoop toe](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) in de SmartArt‑vorm [**NodeCollection**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) en stel de tekst in het TextFrame in.
1. Voeg nu een [**sub‑knoop**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) toe aan de nieuw toegevoegde [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑knoop en stel de tekst in het TextFrame in.
1. Sla de presentatie op.

```javascript
// Laad de gewenste presentatie
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Loop door elke vorm op de eerste dia
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleer of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Cast de vorm naar SmartArt
            var smart = shape;
            // Een nieuwe SmartArt‑knoop toevoegen
            var TemNode = smart.getAllNodes().addNode();
            // Tekst toevoegen
            TemNode.getTextFrame().setText("Test");
            // Een nieuwe subknoop toevoegen aan de bovenliggende knoop. Deze wordt aan het einde van de collectie toegevoegd
            var newNode = TemNode.getChildNodes().addNode();
            // Tekst toevoegen
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Presentatie opslaan
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑knoop toevoegen op specifieke positie**
In de onderstaande voorbeeldcode hebben we uitgelegd hoe u sub‑knopen die bij respectieve knopen van een SmartArt‑vorm horen op een bepaalde positie kunt toevoegen.

1. Maak een instantie van de Presentation‑klasse.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList)-type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑vorm toe aan de geraadpleegde dia.
1. Benader de eerste knoop in de toegevoegde SmartArt‑vorm.
1. Voeg nu de [**sub‑knoop**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) toe voor de geselecteerde [**knoop**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode) op positie 2 en stel de tekst in.
1. Sla de presentatie op.

```javascript
// Een presentatie‑instantie maken
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de presentatiedia
    var slide = pres.getSlides().get_Item(0);
    // Smart Art IShape toevoegen
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Toegang tot de SmartArt‑knoop op index 0
    var node = smart.getAllNodes().get_Item(0);
    // Nieuwe sub‑knoop toevoegen op positie 2 in de bovenliggende knoop
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Tekst toevoegen
    chNode.getTextFrame().setText("Sample Text Added");
    // Presentatie opslaan
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑knoop benaderen in PowerPoint‑presentatie met JavaScript**
De onderstaande voorbeeldcode helpt bij het benaderen van knopen binnen een SmartArt‑vorm. Let op: u kunt het LayoutType van de SmartArt niet wijzigen, omdat deze alleen-lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van de SmartArt‑knoop.

```javascript
// Presentatie‑klasse instantieren
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Eerste dia ophalen
    var slide = pres.getSlides().get_Item(0);
    // Door alle vormen op de eerste dia lopen
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Controleren of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Vorm casten naar SmartArt
            var smart = shape;
            // Door alle knopen binnen SmartArt lopen
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Toegang tot SmartArt‑knoop op index i
                var node = smart.getAllNodes().get_Item(j);
                // De parameters van de SmartArt‑knoop afdrukken
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑sub‑knoop benaderen**
De onderstaande voorbeeldcode helpt bij het benaderen van de sub‑knopen die bij respectieve knopen van een SmartArt‑vorm horen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. Loop door alle [**Nodes**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) binnen de SmartArt‑vorm.
1. Voor elke geselecteerde SmartArt‑vorm [**Node**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode), loop door alle [**Child Nodes**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) binnen de betreffende knoop.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Presentatie-klasse instantieren
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Eerste dia ophalen
    var slide = pres.getSlides().get_Item(0);
    // Door alle vormen op de eerste dia lopen
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Controleren of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Vorm casten naar SmartArt
            var smart = shape;
            // Door alle knopen binnen SmartArt lopen
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Toegang tot SmartArt-knoop op index i
                var node0 = smart.getAllNodes().get_Item(i);
                // Door de sub-knopen in SmartArt-knoop op index i lopen
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Toegang tot de sub-knoop in SmartArt-knoop
                    var node = node0.getChildNodes().get_Item(j);
                    // De parameters van de SmartArt-sub-knoop afdrukken
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑sub‑knoop benaderen op specifieke positie**
In dit voorbeeld leren we de sub‑knopen te benaderen op een bepaalde positie die bij respectieve knopen van een SmartArt‑vorm horen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Voeg een [**StackedList**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList)-type SmartArt‑vorm toe.
1. Benader de toegevoegde SmartArt‑vorm.
1. Benader de knoop met index 0 voor de geraadpleegde SmartArt‑vorm.
1. Toegang nu tot de [**Child Node**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) op positie 1 voor de geraadpleegde SmartArt‑knoop met de **get_Item()**‑methode.
1. Benader en toon informatie zoals de positie, het niveau en de tekst van de [**Child Node**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Instantie van de presentatie maken
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // SmartArt-vorm toevoegen op de eerste dia
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Toegang tot SmartArt-knoop op index 0
    var node = smart.getAllNodes().get_Item(0);
    // Toegang tot sub‑knoop op positie 1 in bovenliggende knoop
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // De parameters van de SmartArt-sub‑knoop afdrukken
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑knoop verwijderen in PowerPoint‑presentatie met JavaScript**
In dit voorbeeld leren we hoe we knopen binnen een SmartArt‑vorm kunnen verwijderen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. Controleer of de [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) meer dan 0 knopen heeft.
1. Selecteer de SmartArt‑knoop die verwijderd moet worden.
1. Verwijder nu de geselecteerde knoop met behulp van de [**RemoveNode**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-)‑methode.
1. Sla de presentatie op.

```javascript
// Laad de gewenste presentatie
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Door alle vormen op de eerste dia lopen
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleren of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Vorm casten naar SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Toegang tot SmartArt-knoop op index 0
                var node = smart.getAllNodes().get_Item(0);
                // De geselecteerde knoop verwijderen
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Presentatie opslaan
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑knoop verwijderen op specifieke positie**
In dit voorbeeld leren we knopen binnen een SmartArt‑vorm te verwijderen op een bepaalde positie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de eerste dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. Selecteer de SmartArt‑vormknoop op index 0.
1. Controleer nu of de geselecteerde SmartArt‑knoop meer dan 2 sub‑knopen heeft.
1. Verwijder nu de knoop op **Positie 1** met de [**RemoveNode**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-)‑methode.
1. Sla de presentatie op.

```javascript
// Laad de gewenste presentatie
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Door alle vormen op de eerste dia lopen
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleren of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Vorm casten naar SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Toegang tot SmartArt-knoop op index 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // De subknoop op positie 1 verwijderen
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Presentatie opslaan
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aangepaste positie instellen voor sub‑knoop in SmartArt**
Nu ondersteunt Aspose.Slides for Node.js via Java het instellen van de [SmartArtShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtShape)‑eigenschappen [X](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setX-float-) en [Y](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setY-float-). De onderstaande codefragment toont hoe u een aangepaste positie, grootte en rotatie voor een SmartArtShape instelt; let ook op dat het toevoegen van nieuwe knopen een herberekening van de posities en groottes van alle knopen veroorzaakt. Met aangepaste positiebepalingen kan de gebruiker de knopen naar wens instellen.

```javascript
// Instantie van de presentatieklasse maken
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // SmartArt-vorm naar nieuwe positie verplaatsen
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Breedte van de SmartArt-vorm wijzigen
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Hoogte van de SmartArt-vorm wijzigen
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Rotatie van de SmartArt-vorm wijzigen
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Assistent‑knoop controleren**
{{% alert color="primary" %}} 

In dit artikel onderzoeken we verder de functies van SmartArt‑vormen die programmatisch aan presentatiedia's zijn toegevoegd met Aspose.Slides for Node.js via Java.

{{% /alert %}} 

We gebruiken de volgende bron‑SmartArt‑vorm voor ons onderzoek in verschillende secties van dit artikel.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm in dia**|

In de onderstaande voorbeeldcode onderzoeken we hoe we **Assistent‑knopen** in de SmartArt‑knooppencollectie kunnen identificeren en aanpassen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.
1. Haal de referentie van de tweede dia op met behulp van de index.
1. Loop door alle vormen op de eerste dia.
1. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) als het SmartArt is.
1. Loop door alle knopen binnen de SmartArt‑vorm en controleer of ze [**Assistant Nodes**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) zijn.
1. Verander de status van de Assistent‑knoop naar een normale knoop.
1. Sla de presentatie op.

```javascript
// Presentatie‑instantie maken
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Door alle vormen op de eerste dia lopen
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleren of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Vorm casten naar SmartArt
            var smart = shape;
            // Door alle knopen van de SmartArt‑vorm lopen
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Controleren of de knoop een assistentknoop is
                if (node.isAssistant()) {
                    // Assistentknoop uitschakelen en een normale knoop maken
                    node.isAssistant();
                }
            }
        }
    }
    // Presentatie opslaan
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figuur: Assistent‑knopen gewijzigd in SmartArt‑vorm binnen dia**|

## **Vul­formaat van knoop instellen**
Aspose.Slides for Node.js via Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vul­formaat in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt en benadert en hun vul­formaat instelt met Aspose.Slides for Node.js via Java.

Volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Haal de referentie van een dia op met behulp van de index.
1. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑vorm toe door zijn [**LayoutType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) in te stellen.
1. Stel de [**FillFormat**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getFillFormat--) in voor de knopen van de SmartArt‑vorm.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```javascript
// Instantiate the presentation
var pres = new aspose.slides.Presentation();
try {
    // Accessing the slide
    var slide = pres.getSlides().get_Item(0);
    // Adding SmartArt shape and nodes
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Setting node fill color
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Save the presentation
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Miniatuur van SmartArt‑sub‑knoop genereren**
Ontwikkelaars kunnen een miniatuur van een sub‑knoop van een SmartArt genereren door de onderstaande stappen te volgen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. [Voeg SmartArt toe](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Haal de referentie van een knoop op met behulp van de index
1. Haal de miniatuurafbeelding op.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

```javascript
// Instantie van de Presentation-klasse die het PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // SmartArt toevoegen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Referentie van een knoop verkrijgen via de index
    var node = smart.getNodes().get_Item(1);
    // Miniatuur ophalen
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Miniatuur opslaan
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Wordt SmartArt‑animatie ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, dus u kunt [standaardanimaties toepassen](/slides/nl/nodejs-java/shape-animation/) (invoer, uitgang, nadruk, bewegingspaden) en de timing aanpassen. U kunt ook vormen binnen SmartArt‑knopen animeren wanneer dat nodig is.

**Hoe kan ik een specifieke SmartArt op een dia betrouwbaar vinden als de interne ID onbekend is?**

Ken een [alternatieve tekst](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getalternativetext/) toe en zoek daarop. Het instellen van een onderscheidende AltText op de SmartArt maakt het mogelijk deze te vinden zonder gebruik te maken van interne identifiers.

**Blijft de SmartArt‑weergave behouden bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met hoge visuele getrouwheid tijdens de [PDF‑export](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), waardoor lay-out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de gehele SmartArt extraheren (voor voorbeelden of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) of naar [SVG](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) voor schaalbare vectoroutput, waardoor het geschikt is voor miniaturen, rapporten of webgebruik.
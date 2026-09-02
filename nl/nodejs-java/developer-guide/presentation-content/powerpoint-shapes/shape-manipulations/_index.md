---
title: Beheer presentatievormen in JavaScript
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm zoeken
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interopvorm-ID ophalen
- alternatieve tekst van vorm
- vorm lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, klonen, verwijderen, verbergen, opnieuw rangschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java vertegenwoordigt de vormen op een dia als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm die het verst achterin staat, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren, daarna wordt getoond hoe je vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die je werkstroom vereist.

## **Identificeren en Vinden van Vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifieren. Het toevoegen, verwijderen of opnieuw ordenen van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getname/) is nuttig voor door ontwikkelaars gecontroleerde sjablonen en is gemakkelijk te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getalternativetext/) is bruikbaar wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilletjes als een databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) is een alleen-lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die door PowerPoint‑interop wordt gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt zijn eigen ID.

De verwante [getUniqueId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getuniqueid/)‑methode retourneert een identifier met presentatiescope, maar die identifier is bedoeld voor add‑ins en kan worden hergebruikt. Het moet niet worden behandeld als een permanente externe sleutel. Als een langetermijnidentiteit essentieel is, bewaar dan de mapping in toepassingsdata en controleer of de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en meldt de interop‑ID die scoped is op de dia. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Wanneer een bewerking specifiek is voor een type vorm, controleer dan de runtime‑klasse voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst alleen bij als het benoemde object een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) is.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **De Vormcollectie Wijzigen**

De methoden add, clone, remove en reorder werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen verandert, vertrouw dan niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Een Vorm Klonen**

[addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/insertclone/) maakt ook een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doel­dia, kloont een gelabelde rechthoek naar de voorgrond en voegt een tweede kloon toe achterin. Wijzigingen aan één van de klonen wijzigen de brondvorm niet.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Ken nieuwe logische identifieren toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Vormen Verwijderen**

[remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomende vormen tijdens een geïndexeerde iteratie verwijdert, loop dan van achteren naar voren zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een bepaalde naam. Het leest de vorm op de huidige index en gaat niet uit van een specifiek vormtype.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Na het verwijderen veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Denk ook aan connectors, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer dan alleen het uiterlijk van de dia veranderen.

### **Een Vorm Verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/sethidden/) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later kunnen worden hersteld.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en onzichtbaar gemaakt door een gebruiker of door code, en het blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑order Wijzigen**

Overlapende vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doelindex zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De rechthoek wordt eerst aangemaakt en staat aanvankelijk achter de ellips. Verplaatsing naar de laatste index zet deze ervoor. Finaliseer de z‑order nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of plaatsen ze in, waardoor de beoogde stapel kan veranderen.

## **Vormen Inspecteren op Layout‑dia's**

Normale dia’s, layout‑dia’s en master‑dia’s hebben afzonderlijke vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een soortgelijke vorm op een normale dia. Inspecteer layout‑vormen wanneer je de opmaak wilt begrijpen of wijzigen die door een layout wordt geleverd.

Het volgende voorbeeld leest voor elke layout‑vorm de [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getfillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getlineformat/) zonder ervan uit te gaan dat elke vorm een `AutoShape` is.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Het bewerken van een layout kan meerdere dia’s die deze gebruiken beïnvloeden. Controleer vóór het wijzigen van een layout‑vorm of een normale dia het object overerft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een Vorm Exporteren naar SVG**

[writeAsSvg](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Houd de presentatie geopend tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Vormen Uitlijnen**

De overloads van [SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/alignshapes/) lijnen of alle vormen uit of een geselecteerde reeks indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapesalignmenttype/) specificeert de rand, middenlijn of distributiemodus. Stel `alignToSlide` in op `true` om de randen van de dia te gebruiken; stel het in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. De geretourneerde vorm‑referenties worden direct vóór uitlijning omgezet naar hun huidige indexen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaal gezien minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een Vorm Spiegelen**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden `getFlipH` en `getFlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongespecificeerde/standaardstaat.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/setframe/) het volledige frame vervangt.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld, terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor kortstondige verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor gemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk scoped op de dia.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, opnieuw geordend, bewerkt of opnieuw zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm vóór een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorzijde van de z‑order is. Gebruik `insertClone` om de initiële index te kiezen of `reorder` na het toevoegen van alle vormen.
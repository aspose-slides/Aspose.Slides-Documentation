---
title: Beheer presentatievormen in JavaScript
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm zoeken
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- vooraf ingestelde vormaanpassing
- vormgeometrie
- vorm-lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, opnieuw ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt de vormen op een dia voor als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/). De collectie is zowel de plaats waar u vormen vindt en bewerkt als de bron van hun stapelvolgorde: index `0` is de achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe u een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten kunt wijzigen, en toont vervolgens hoe u vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat u alleen de bewerkingen kunt gebruiken die uw workflow vereist.

## **Identificeren en Vinden van Vormen**

Collectie‑indexen zijn praktisch bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Het toevoegen, verwijderen of opnieuw ordenen van een vorm kan de index wijzigen. Kies een identificator op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getname/) is handig voor door ontwikkelaars beheerde sjablonen en is eenvoudig te inspecteren in het Selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getalternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan gelokaliseerd of herschreven worden voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilletjes als een databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) is een alleen‑lezen‑identificator die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer u integreert met PowerPoint of wanneer u een ondubbelzinnige referentie nodig heeft gedurende de levensduur van een vorm. Een gekloonde of opnieuw gemaakte vorm is een andere vorm en krijgt een eigen ID.

De verwante [getUniqueId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getuniqueid/)‑methode geeft een identificator met presentatiescope terug, maar die identificator is bedoeld voor add‑ins en kan opnieuw toegewezen worden. Hij mag niet behandeld worden als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in toepassingsdata en controleer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de interop‑ID met diascoping. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een type vorm, controleer dan de runtime‑klasse voordat u type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het genoemde object een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) is.

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

## **Identificeren en Wijzigen van Vooraf Ingestelde Vormenaanpassingen**

Vooraf ingestelde geometrievormen kunnen aanpassingspunten blootleggen die kenmerken zoals hoekgrootte, pijlpuntverhoudingen of booghoeken regelen. Benader ze via de alleen‑lezen‑[GeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/geometryshape/)‑collectie. De collectie zelf wordt door de vorm geleverd, maar elke [AdjustValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/adjustvalue/) bevat een waarde die kan worden gewijzigd.

Betrouw niet uitsluitend op een vaste collectie‑index. Doorloop de aanpassingen en inspecteer de alleen‑lezen‑[getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/adjustvalue/)‑methode, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen‑[getName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/adjustvalue/getname/)‑methode geeft extra identificatie‑informatie en is vooral handig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die bij de betekenis van de aanpassing past:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [setRawValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Dikte van een pijpstaart | `setRawValue` |
| `ArrowheadLength` | Lengte van een pijpkop | `setRawValue` |
| `ArrowheadWidth` | Breedte van een pijpkop | `setRawValue` |
| `StartAngle` | Starthoek van een taart of boog | [setAngleValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Eindhoek van een taart of boog | `setAngleValue` |

`getType` en `getName` geven alleen‑lezen‑informatie terug. `getRawValue` en `setRawValue` werken met een geheel getal in de native eenheden van de preset‑geometrie, terwijl `getAngleValue` en `setAngleValue` werken met een hoek in graden. Het aantal, de volgorde, betekenis en geldige bereik van aanpassingen hangen af van de preset‑[GeometryShape.getShapeType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/geometryshape/). Een waarde die geldig is voor de ene preset kan ongeldig of met een ander effect zijn voor een andere.

Wanneer `getType` `ShapeAdjustmentType.Custom` retourneert, herkent de API geen standaard semantische betekenis. Inspecteer `getName`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan één keer voorkomt voordat u een waarde selecteert. Het artikel [Connector](/slides/nl/nodejs-java/connector/) toont deze situatie met buig‑aanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert de naam en het type, wijzigt grootte‑gerelateerde waarden via `setRawValue`, wijzigt hoeken via `setAngleValue` en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont het aangepaste afgeronde rechthoek, de vierweg‑pijl en de taart.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Voegt kopteksten toe voor de standaard- en aangepaste vormkolommen.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Door het semantische type te controleren vóór het wijzigen van een waarde, maakt de code haar intentie expliciet en voorkomt men te veronderstellen dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **Wijzigen van de Vormcollectie**

De add‑, clone‑, remove‑ en reorder‑methoden werken onmiddellijk op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Klonen van een Vorm**

[addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/insertclone/) maakt ook een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar voren, en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan één van de klonen wijzigen de brond vorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Ken nieuwe logische identificatoren toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Verwijderen van Vormen**

[remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer u meerdere overeenkomsten tijdens een geordende iteratie wilt verwijderen, doorloop de collectie dan van achteren zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest de vorm op de huidige index en gaat niet uit van een specifiek type vorm.

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

Na verwijdering veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook connectoren, animaties en andere presentatiefuncties in gedachten die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Verbergen van een Vorm**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/sethidden/) op `true` houdt de vorm in de collectie maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en zichtbaar gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **Wijzigen van de Z‑order**

Overschikkende vormen worden getekend in de volgorde van de collectie. [reorder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doelindex zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en staat aanvankelijk achter de ellips. Door deze naar de laatste index te verplaatsen komt hij naar voren. Finaliseer de z‑order nadat u alle gerelateerde vormen heeft toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of wijzigen de stapelvolgorde.

## **Inspecteren van Vormen op Lay‑outdia’s**

Normale dia’s, lay‑outdia’s en masterdia’s hebben afzonderlijke vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer u de opmaak die door een lay‑out wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest elk lay‑outvorm‑[FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getfillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getlineformat/) zonder ervan uit te gaan dat elke vorm een `AutoShape` is.

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

Het bewerken van een lay‑out kan invloed hebben op meerdere dia’s die deze gebruiken. Bepaal voordat u een lay‑outvorm wijzigt of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteren van een Vorm naar SVG**

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als u de volledige compositie nodig heeft, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Uitlijnen van Vormen**

De overloads van [SlideUtil.alignShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/alignshapes/) kunnen ofwel alle vormen of geselecteerde collectie‑indexen uitlijnen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapesalignmenttype/) specificeert de rand, middellijn of distributiemodus. Zet `alignToSlide` op `true` om de dia‑randen te gebruiken; zet op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. De teruggegeven vormreferenties worden direct vóór het uitlijnen omgezet naar hun huidige indexen.

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

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist doorgaans minimaal twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de tussenruimte te definiëren. Herbereken indexen als u de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegelen van een Vorm**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden `getFlipH` en `getFlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongedefinieerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/setframe/) het volledige frame vervangt.

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

De opgeslagen vorm is horizontaal en verticaal gespiegeld, terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identificator?**

Alleen voor kortstondige verwerking wanneer de collectie niet zal veranderen vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor aangemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk op diascoping.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, opnieuw geordend, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `insertClone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en de collectie‑lay‑out. Geef de voorkeur aan itereren door `GeometryShape.getAdjustments` en controleer `AdjustValue.getType`; gebruik `AdjustValue.getName` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.
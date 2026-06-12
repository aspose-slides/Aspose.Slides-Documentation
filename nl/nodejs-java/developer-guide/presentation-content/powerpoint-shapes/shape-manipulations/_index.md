---
title: Beheer presentatievormen in JavaScript
linktitle: Vormenmanipulatie
type: docs
weight: 40
url: /nl/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- interop vorm-ID
- alternatieve tekst van vorm
- lay-outformaten van vorm
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer vormen maken, bewerken en optimaliseren met JavaScript en Aspose.Slides voor Node.js via Java en lever hoogpresterende PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je met vormen in presentaties kunt werken met Aspose.Slides. Het toont hoe je een vorm op een dia kunt vinden, klonen, verwijderen, verbergen, de volgorde kunt wijzigen, de Interop‑vorm‑ID kunt ophalen en alternatieve tekst kunt instellen voor identificatie en verdere verwerking.

Het behandelt ook hoe je lay-outformaten voor vormen kunt benaderen, een vorm als SVG kunt renderen, vormen op een dia kunt uitlijnen en spiegel‑eigenschappen voor horizontale en verticale reflectie kunt gebruiken. Bovendien bevat het een korte FAQ over het combineren van vormen, stapelvolgorde en het vergrendelen van vormen.

## **Vorm vinden in dia**
Dit onderwerp beschrijft een eenvoudige techniek die het voor ontwikkelaars makkelijker maakt om een specifieke vorm op een dia te vinden zonder de interne Id te gebruiken. Het is belangrijk te weten dat PowerPoint‑presentatiebestanden geen andere manier hebben om vormen op een dia te identificeren dan een interne unieke Id. Het blijkt moeilijk voor ontwikkelaars om een vorm via die interne unieke Id te vinden. Alle toegevoegde vormen hebben enige Alt‑tekst. Wij raden ontwikkelaars aan alternatieve tekst te gebruiken om een specifieke vorm te vinden. Je kunt in MS PowerPoint de alternatieve tekst definiëren voor objecten die je later wilt wijzigen.

Nadat je de alternatieve tekst van een gewenste vorm hebt ingesteld, kun je die presentatie openen met Aspose.Slides voor Node.js via Java en door alle vormen op een dia itereren. Tijdens elke iteratie kun je de alternatieve tekst van de vorm controleren; de vorm met de overeenkomende alternatieve tekst is de door jou gewenste vorm. Om deze techniek beter te demonstreren, hebben we een methode, [findShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) gemaakt die het vinden van een specifieke vorm in een dia afhandelt en vervolgens die vorm retourneert.

```javascript
// Maak een instantie van de Presentation‑klasse die het presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Alternatieve tekst van de te vinden vorm
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Vorm klonen**
Om een vorm naar een dia te klonen met Aspose.Slides voor Node.js via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg de referentie van een dia door de index te gebruiken.
1. Benader de vormverzameling van de bron‑dia.
1. Voeg een nieuwe dia toe aan de presentatie.
1. Kloon vormen van de bron‑dia‑verzameling naar de nieuwe dia.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepvorm toe aan een dia.

```javascript
// Instantieer Presentation-klasse
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Schrijf het PPTX-bestand naar schijf
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vorm verwijderen**
Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat elke vorm te verwijderen. Volg onderstaande stappen om de vorm van een dia te verwijderen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met een specifieke AlternativeText.
1. Verwijder de vorm.
1. Sla het bestand op schijf.

```javascript
// Maak Presentation-object
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een autovorm van het type rechthoek toe
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Sla de presentatie op schijf
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vorm verbergen**
Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat elke vorm te verbergen. Volg onderstaande stappen om de vorm van een dia te verbergen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met een specifieke AlternativeText.
1. Verberg de vorm.
1. Sla het bestand op schijf.

```javascript
// Instantieer Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een autovorm van het type rechthoek toe
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Sla de presentatie op schijf
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Volgorde van vormen wijzigen**
Aspose.Slides voor Node.js via Java laat ontwikkelaars de volgorde van vormen herschikken. Het herschikken van vormen bepaalt welke vorm zich voor of achter een andere bevindt. Volg onderstaande stappen om de volgorde van vormen op een dia aan te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Voeg een vorm toe.
1. Voeg tekst toe in het tekstkader van de vorm.
1. Voeg een andere vorm toe met dezelfde coördinaten.
1. Herschik de vormen.
1. Sla het bestand op schijf.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Interop‑vorm‑ID ophalen**
Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat een unieke vorm‑identificatie binnen de dia‑scope te verkrijgen, in tegenstelling tot de [getUniqueId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getUniqueId--)‑methode die een unieke identifier in presentatie‑scope oplevert. De methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) is toegevoegd aan de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape)‑klasse. De waarde die door [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) wordt geretourneerd, komt overeen met de Id‑waarde van het Microsoft.Office.Interop.PowerPoint.Shape‑object. Hieronder staat een voorbeeldcode.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Unieke vormidentificatie ophalen binnen de dia-scope
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alternatieve tekst voor vorm instellen**
Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat de AlternateText van elke vorm in te stellen.
Vormen in een presentatie kunnen worden onderscheiden via de [AlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) of [Shape Name](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setName-java.lang.String-)‑methode.
De methoden [setAlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) en [getAlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getAlternativeText--) kunnen zowel met Aspose.Slides als met Microsoft PowerPoint gelezen of ingesteld worden.
Met deze methode kun je een vorm taggen en verschillende bewerkingen uitvoeren zoals het verwijderen, verbergen of herschikken van vormen op een dia.
Om de AlternateText van een vorm in te stellen, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Benader de eerste dia.
1. Voeg een willekeurige vorm toe aan de dia.
1. Werk met de nieuw toegevoegde vorm.
1. Doorloop de vormen om een specifieke vorm te vinden.
1. Stel de AlternativeText in.
1. Sla het bestand op schijf.

```javascript
// Instantieer Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een autovorm van het type rechthoek toe
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Sla de presentatie op schijf
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lay‑outformaten voor vorm benaderen**
Aspose.Slides voor Node.js via Java biedt een eenvoudige API om lay‑outformaten voor een vorm te benaderen. Dit artikel demonstreert hoe je lay‑outformaten kunt benaderen.

Hieronder staat voorbeeldcode.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vorm renderen als SVG**
Nu ondersteunt Aspose.Slides voor Node.js via Java het renderen van een vorm als SVG. De methode [writeAsSvg](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (en de overload) is toegevoegd aan de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape)‑klasse. Deze methode maakt het mogelijk de inhoud van de vorm op te slaan als een SVG‑bestand. De onderstaande codefragment laat zien hoe je de vorm van een dia exporteert naar een SVG‑bestand.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vormuitlijning**
Aspose.Slides maakt het mogelijk vormen uit te lijnen ten opzichte van de dia‑marges of ten opzichte van elkaar. Hiervoor is de overladen methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) toegevoegd. De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapesAlignmentType) definieert de mogelijke uitlijningsopties.

**Voorbeeld 1**

De onderstaande broncode lijnt vormen met indices 1, 2 en 4 uit langs de bovenrand van de dia.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Voorbeeld 2**

Het volgende voorbeeld toont hoe je de volledige collectie van vormen uitlijnt ten opzichte van de onderste vorm in de collectie.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Flip‑eigenschappen**

In Aspose.Slides biedt de [ShapeFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapeframe/)‑klasse controle over horizontale en verticale spiegeling van vormen via de eigenschappen `flipH` en `flipV`. Beide eigenschappen hebben het type `byte` en kunnen de waarden `1` (spiegel), `0` (geen spiegel) of `-1` (standaardgedrag) aannemen. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getFrame) van een vorm.

Om de flip‑instellingen te wijzigen, wordt een nieuw [ShapeFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapeframe/)‑object gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `flipH` en `flipV` en de rotatiehoek. Het toewijzen van dit object aan het [Frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getFrame) van de vorm en het opslaan van de presentatie past de spiegeltransformaties toe en schrijft ze naar het uitvoerbestand.

Stel dat we een bestand sample.pptx hebben waarin de eerste dia één vorm bevat met standaard flip‑instellingen, zoals hieronder weergegeven.

![The shape to be flipped](shape_to_be_flipped.png)

Het volgende code‑voorbeeld haalt de huidige flip‑eigenschappen van de vorm op en spiegelt deze zowel horizontaal als verticaal.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Haalt de horizontale flip‑eigenschap van de vorm op.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Haalt de verticale flip‑eigenschap van de vorm op.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Horizontaal spiegelen.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Verticaal spiegelen.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan ik vormen (union/intersect/subtract) op een dia combineren zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. Je kunt een benadering maken door zelf de gewenste omtrek te construeren — bijvoorbeeld door de resulterende geometrie (via [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/geometrypath/)) te berekenen en een nieuwe vorm met dat contour te maken, eventueel de originelen te verwijderen.

**Hoe kan ik de stapelvolgorde (z‑order) bepalen zodat een vorm altijd “bovenop” blijft?**

Wijzig de invoeg‑/verplaatsvolgorde binnen de [shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getShapes)‑collectie van de dia. Voor voorspelbare resultaten, finaliseer de z‑order nadat alle andere dia‑aanpassingen zijn uitgevoerd.

**Kan ik een vorm “vergrendelen” zodat gebruikers deze niet kunnen bewerken in PowerPoint?**

Ja. Stel vorm‑specifieke beschermingsvlaggen in (bijv. selectie, verplaatsing, grootte wijzigen, tekstbewerking blokkeren). Indien nodig, kun je vergelijkbare beperkingen op het master‑ of lay‑out‑niveau toepassen. Let op: dit is bescherming op UI‑niveau, geen veiligheidsfunctie; voor sterkere bescherming combineer je dit met bestands‑niveau restricties zoals [read‑only aanbevelingen of wachtwoorden](/slides/nl/nodejs-java/password-protected-presentation/).
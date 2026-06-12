---
title: Lijnvormen toevoegen aan presentaties in JavaScript
linktitle: Lijn
type: docs
weight: 50
url: /nl/nodejs-java/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- streepjesstijl
- pijlkop
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u de opmaak van lijnen in PowerPoint-presentaties kan manipuleren met JavaScript en Aspose.Slides voor Node.js. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijngrafische vormen toe te voegen aan PowerPoint‑dia's via code. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn kunt aanpassen zodat deze als een pijl verschijnt.

U leert hoe u een lijngrafische vorm aan een dia toevoegt, het uiterlijk aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijnopmaakinstellingen zoals stijl, breedte, streepjespatroon, pijlhoofdopties en opvulkleur.

## **Eenvoudige lijn maken**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Lijn toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) die wordt aangeboden door het object [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```javascript
// Instantieer de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type lijn toe
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Schrijf de PPTX naar schijf
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lijn met pijlvorm**

Aspose.Slides voor Node.js via Java laat ontwikkelaars ook toe enkele eigenschappen van de lijn te configureren zodat deze er aantrekkelijker uitziet. Laten we een paar eigenschappen van een lijn configureren zodat deze eruitziet als een pijl. Volg de onderstaande stappen om dit te doen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Lijn toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) die wordt aangeboden door het object [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).
- Stel de [Line Style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineStyle) in op een van de stijlen die door Aspose.Slides voor Node.js via Java worden aangeboden.
- Stel de Breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineDashStyle) van de lijn in op een van de stijlen die door Aspose.Slides voor Node.js via Java worden aangeboden.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineArrowheadLength) van het startpunt van de lijn in.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LineArrowheadLength) van het eindpunt van de lijn in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```javascript
// Instantieer de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type lijn toe
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Pas wat opmaak toe op de lijn
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Schrijf de PPTX naar schijf
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten in een connector zodat deze 'klikt' op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapetype/)) wordt niet automatisch een connector. Om de lijn op vormen te laten klikken, gebruikt u het specifieke [Connector](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/connector/) type en de [corresponding APIs](/slides/nl/nodejs-java/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn worden geërfd van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Read the effective properties](/slides/nl/nodejs-java/shape-effective-properties/) via de klassen `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`—deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, grootte wijzigen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/getautoshapelock/) waarmee u bewerkingsacties kunt verbieden.
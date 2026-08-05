---
title: Lijnvormen toevoegen aan presentaties op Android
linktitle: Lijn
type: docs
weight: 50
url: /nl/androidjava/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- streepjesstijl
- pijlpunt
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u de opmaak van lijnen in PowerPoint-presentaties kunt manipuleren met Aspose.Slides for Android. Ontdek eigenschappen, methoden en Java-voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen programmatically toe te voegen aan PowerPoint‑dia’s. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn aanpast zodat deze eruitziet als een pijl.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijn‑opmaakinstellingen zoals stijl, breedte, stippellijnpatroon, pijlpuntopties en vulkleur.

## **Een eenvoudige lijn maken**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Line toe met de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```java
// Maak een instantie van de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voeg een AutoShape van het type lijn toe
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schrijf de PPTX naar de schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een pijlvormige lijn maken**

Aspose.Slides for Android via Java maakt het ook mogelijk om enkele eigenschappen van de lijn te configureren zodat hij er aantrekkelijker uitziet. Laten we enkele eigenschappen van een lijn instellen zodat hij eruitziet als een pijl. Volg hiervoor de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Line toe met de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) object.
- Stel de [Line Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineStyle) in op een van de stijlen die door Aspose.Slides for Android via Java worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineDashStyle) van de lijn in op een van de stijlen die door Aspose.Slides for Android via Java worden aangeboden.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadStyle) en de [Length](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadLength) van het startpunt van de lijn in.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadStyle) en de [Length](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadLength) van het eindpunt van de lijn in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
// Maak een instantie van de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type lijn toe
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Pas wat opmaak toe op de lijn
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Schrijf de PPTX naar de schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten in een connector zodat hij “vastklikt” op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapetype/)) wordt niet automatisch een connector. Gebruik het speciale [Connector](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/connector/)‑type en de [corresponding APIs](/slides/nl/androidjava/connector/) om verbindingen te maken.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Lees de effectieve eigenschappen](/slides/nl/androidjava/shape-effective-properties/) via de interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — deze houden al rekening met erfelijkheid en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, vergroten/verkleinen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) die u kunt gebruiken om bewerking te verhinderen.
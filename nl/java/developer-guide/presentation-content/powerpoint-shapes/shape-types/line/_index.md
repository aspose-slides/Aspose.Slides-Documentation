---
title: Lijnvormen toevoegen aan presentaties in Java
linktitle: Lijn
type: docs
weight: 50
url: /nl/java/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- streepstijl
- pijlpunt
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u de lijnopmaak in PowerPoint‑presentaties kunt bewerken met Aspose.Slides voor Java. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen programmeer­matig toe te voegen aan PowerPoint‑dia’s. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn kunt aanpassen zodat deze eruitziet als een pijl.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijnopmaakinstellingen zoals stijl, breedte, streeppatroon, pijlkoptopties en vulkleur.

## **Maak een eenvoudige lijn**

Om een eenvoudige lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van type Lijn toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) die wordt aangeboden door het object [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection).
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```java
// Instantieer de PresentationEx-klasse die het PPTX-bestand voorstelt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voeg een AutoShape van type lijn toe
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schrijf de PPTX naar schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Maak een pijlvormige lijn**

Aspose.Slides for Java stelt ontwikkelaars ook in staat om enkele eigenschappen van de lijn te configureren zodat deze er aantrekkelijker uitziet. Laten we een paar eigenschappen van een lijn configureren zodat deze eruitziet als een pijl. Volg de onderstaande stappen om dit te doen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van type Lijn toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) die wordt aangeboden door het object [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection).
- Stel de [Line Style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineStyle) in op een van de stijlen die door Aspose.Slides for Java worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineDashStyle) van de lijn in op een van de stijlen die door Aspose.Slides for Java worden aangeboden.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineArrowheadLength) van het startpunt van de lijn in.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LineArrowheadLength) van het eindpunt van de lijn in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
// Instantieer de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van type lijn toe
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

    // Schrijf de PPTX naar schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten naar een connector zodat deze 'vastklikt' op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) van type [Line](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapetype/)) wordt niet automatisch een connector. Om deze op vormen te laten 'vastklikken', gebruikt u het speciale [Connector](https://reference.aspose.com/slides/nl/java/com.aspose.slides/connector/) type en de [corresponding APIs](/slides/nl/java/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het moeilijk is om de uiteindelijke waarden te bepalen?**

[Lees de effectieve eigenschappen](/slides/nl/java/shape-effective-properties/) via de interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinefillformateffectivedata/) — deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, formaat wijzigen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/#getAutoShapeLock--) waarmee u [bewerkingsacties kunt verbieden](/slides/nl/java/applying-protection-to-presentation/) kunt uitvoeren.
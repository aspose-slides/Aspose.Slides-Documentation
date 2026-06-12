---
title: Lijnvormen toevoegen aan presentaties op Android
linktitle: Lijn
type: docs
weight: 50
url: /nl/androidjava/Line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- stippellijnstijl
- pijlkop
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u de lijnopmaak in PowerPoint-presentaties kunt manipuleren met Aspose.Slides voor Android. Ontdek eigenschappen, methoden en Java-voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen programmatisch aan PowerPoint‑dia’s toe te voegen. Dit artikel laat zien hoe u een simpele lijn maakt en hoe u een lijn aanpast zodat deze als een pijl verschijnt.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk ervan aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische opmaakeigenschappen van lijnen zoals stijl, breedte, stippellijnpatroon, pijlkopopties en vulkleur.

## **Maak een eenvoudige lijn**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door zijn index te gebruiken.
- Voeg een AutoShape van het type Lijn toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection)‑object.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```java
// Instantieer de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voeg een AutoShape van het type lijn toe
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Maak een pijlvormige lijn**

Aspose.Slides for Android via Java stelt ontwikkelaars ook in staat enkele eigenschappen van de lijn te configureren zodat deze er aantrekkelijker uitziet. Laten we een paar eigenschappen van een lijn aanpassen zodat deze eruitziet als een pijl. Volg hiervoor de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door zijn index te gebruiken.
- Voeg een AutoShape van het type Lijn toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection)‑object.
- Stel de [Line Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineStyle) in op een van de stijlen die door Aspose.Slides for Android via Java worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineDashStyle) van de lijn in op een van de door Aspose.Slides for Android via Java aangeboden stijlen.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadLength) van het startpunt van de lijn in.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LineArrowheadLength) van het eindpunt van de lijn in.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```java
// Instantieer de PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type lijn toe
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Pas enige opmaak toe op de lijn
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Schrijf het PPTX-bestand naar schijf
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten naar een connector zodat deze "klikt" op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapetype/)) wordt niet automatisch een connector. Om de lijn op vormen te laten klikken, gebruikt u het speciale [Connector](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/connector/)‑type en de [corresponding APIs](/slides/nl/androidjava/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Read the effective properties](/slides/nl/androidjava/shape-effective-properties/) via de [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinefillformateffectivedata/) interfaces — deze houden reeds rekening met overerving en thema‑stijlen.

**Kan ik een lijn vergrendelen tegen bewerking (verplaatsen, grootte wijzigen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) waarmee u bewerkingsacties kunt verhinderen.
---
title: Lijnvormen toevoegen aan presentaties in .NET
linktitle: Lijn
type: docs
weight: 50
url: /nl/net/Line/
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
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u lijnopmaak in PowerPoint-presentaties kunt manipuleren met Aspose.Slides voor .NET. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen programmatisch aan PowerPoint‑dia’s toe te voegen. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn aanpast zodat deze eruitziet als een pijl.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk ervan aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijn‑opmaakinstellingen zoals stijl, breedte, stippellijnpatroon, pijlkopopties en vulkleur.

## **Maak een eenvoudige lijn**
Om een eenvoudige rechte lijn aan een geselecteerde dia van de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de index.
- Voeg een AutoShape van het type Lijn toe met de [AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/methods/addautoshape/index)‑methode van het Shapes‑object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```c#
 // Een instantie van de PresentationEx‑klasse die het PPTX‑bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type lijn toe
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Schrijf de PPTX naar schijf
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Maak een pijlvormige lijn**
Aspose.Slides voor .NET stelt ontwikkelaars ook in staat om enkele eigenschappen van de lijn te configureren zodat deze aantrekkelijker wordt. Laten we een paar eigenschappen van een lijn instellen zodat deze eruitziet als een pijl. Volg hiervoor de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/nl/aspose.slides/)[](http://www.aspose.com/api/net/slides/nl/aspose.slides/).
- Verkrijg de referentie van een dia door gebruik te maken van de index.
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode van het Shapes‑object.
- Stel de Lijnstijl in op een van de stijlen die door Aspose.Slides voor .NET worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/net/aspose.slides/linedashstyle) van de lijn in op een van de door Aspose.Slides voor .NET aangeboden stijlen.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/net/aspose.slides/linearrowheadstyle) en lengte van het startpunt van de lijn in.
- Stel de pijlkopstijl en lengte van het eindpunt van de lijn in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```c#
 // Een instantie van de PresentationEx-klasse die het PPTX‑bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type lijn toe
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Pas wat opmaak toe op de lijn
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Schrijf de PPTX naar schijf
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten naar een connector zodat hij “vastklikt” op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype/)) wordt niet automatisch een connector. Gebruik het speciale [Connector](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/)‑type en de [bijbehorende API's](/slides/nl/net/connector/) om verbindingen te maken.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het lastig is om de eindwaarden te bepalen?**

[Lees de effectieve eigenschappen](/slides/nl/net/shape-effective-properties/) via de interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilinefillformateffectivedata/); deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerking (verplaatsen, grootte wijzigen)?**

Ja. Shapes bieden [lock‑objecten](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/autoshapelock/) waarmee u [bewerkingsacties kunt verbieden](/slides/nl/net/applying-protection-to-presentation/).
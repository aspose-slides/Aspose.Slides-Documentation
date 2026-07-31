---
title: Lijnvormen toevoegen aan presentaties in .NET
linktitle: Lijn
type: docs
weight: 50
url: /nl/net/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- streepstijl
- pijlkop
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u de lijnopmaak in PowerPoint-presentaties kunt bewerken met Aspose.Slides voor .NET. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen programmatisch toe te voegen aan PowerPoint‑dia's. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn kunt aanpassen zodat deze eruitziet als een pijl.

U leert hoe u een lijnvorm aan een dia toevoegt, de visuele weergave aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijnopmaakinstellingen zoals stijl, breedte, stippelpatroon, pijlkopopties en vulkleur.

## **Maak een eenvoudige lijn**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een AutoShape van het type Lijn toe met behulp van de [AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/methods/addautoshape/index)‑methode die wordt blootgesteld door het Shapes‑object.
- Schrijf de aangepaste presentatie naar een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```c#
// Instantieer PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
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

Aspose.Slides voor .NET stelt ontwikkelaars bovendien in staat om enkele eigenschappen van de lijn te configureren zodat deze er aantrekkelijker uitziet. Laten we een paar eigenschappen van een lijn configureren zodat deze eruitziet als een pijl. Volg de onderstaande stappen om dit te doen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode die door het Shapes‑object wordt blootgesteld.
- Stel de lijntstijl in op één van de stijlen die door Aspose.Slides voor .NET worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/net/aspose.slides/linedashstyle) van de lijn in op één van de stijlen die door Aspose.Slides voor .NET worden aangeboden.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/net/aspose.slides/linearrowheadstyle) en de lengte van het startpunt van de lijn in.
- Stel de pijlkopstijl en de lengte van het eindpunt van de lijn in.
- Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```c#
// Instantieer PresentationEx-klasse die het PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type lijn toe
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Pas enige opmaak toe op de lijn
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Schrijf de PPTX naar schijf
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik een gewone lijn omzetten in een connector zodat deze “klikt” op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype/)) wordt niet automatisch een connector. Om deze aan vormen te laten klikken, gebruikt u het speciale [Connector](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/)-type en de [bijbehorende API’s](/slides/nl/net/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn zijn geërfd van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Lees de effectieve eigenschappen](/slides/nl/net/shape-effective-properties/) via de [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilinefillformateffectivedata/) interfaces—deze houden al rekening met erfelijkheid en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, aanpassen van grootte)?**

Ja. Shapes bieden [lock‑objecten](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/autoshapelock/) waarmee u [bewerkingsacties kunt verhinderen](/slides/nl/net/applying-protection-to-presentation/).
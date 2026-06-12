---
title: Rechthoeken toevoegen aan presentaties in .NET
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/net/rectangle/
keywords:
- add rectangle
- create rectangle
- rectangle shape
- simple rectangle
- formatted rectangle
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Verbeter uw PowerPoint‑presentaties door rechthoeken toe te voegen met Aspose.Slides voor .NET—ontwerp en wijzig vormen eenvoudig programmatic​h."
---
## **Overzicht**

Dit artikel laat zien hoe u rechthoekige vormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een geformatteerde rechthoek en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

U ziet ook hoe u basisopmaak voor rechthoeken toepast, zoals een effen vulkleur, lijnkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingenvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen.

## **Eenvoudige rechthoek maken**
Net als eerdere onderwerpen gaat dit ook over het toevoegen van een vorm en dit keer is de vorm waar we het over hebben een Rectangle. In dit onderwerp hebben we beschreven hoe ontwikkelaars eenvoudige of geformatteerde rechthoeken aan hun dia's kunnen toevoegen met Aspose.Slides voor .NET. Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
2. Verkrijg de referentie van een dia door zijn Index te gebruiken.
3. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode die wordt blootgesteld door het IShapes‑object.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```c#
// Instantieer de Prseetation-klasse die de PPTX vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type rechthoek toe
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Schrijf het PPTX-bestand naar schijf
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Geformatteerde rechthoek maken**
Om een geformatteerde rechthoek aan een dia toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
2. Verkrijg de referentie van een dia door zijn Index te gebruiken.
3. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode die wordt blootgesteld door het IShapes‑object.
4. Stel het vultype van de rechthoek in op Solid.
5. Stel de kleur van de rechthoek in via de SolidFillColor.Color‑eigenschap die wordt blootgesteld door het FillFormat‑object dat aan het IShape‑object is gekoppeld.
6. Stel de kleur van de lijnen van de rechthoek in.
7. Stel de breedte van de lijnen van de rechthoek in.
8. Schrijf de gewijzigde presentatie weg als PPTX‑bestand.
   
De bovenstaande stappen zijn geïmplementeerd in het voorbeeld hieronder gegeven.

```c#
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type rechthoek toe
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Pas enige opmaak toe op de rechthoekvorm
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Pas enige opmaak toe op de lijn van de rechthoek
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Schrijf het PPTX-bestand naar schijf
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik de afgeronde‑hoek [shape type](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype/) en pas de hoekradius aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het afbeelding [fill type](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/), geef de afbeeldingsbron op, en configureer de [stretching/tiling modes](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillmode/).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/net/shape-effect/) is beschikbaar met aanpasbare parameters.

**Kan ik een rechthoek omvormen tot een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/net/manage-hyperlinks/) aan de klik op de vorm (ga naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

[Use shape locks](/slides/nl/net/applying-protection-to-presentation/): u kunt verplaatsen, formaat wijzigen, selectie of tekstbewerking verbieden om de lay-out te behouden.

**Kan ik een rechthoek omzetten naar een rasterafbeelding of SVG?**

Ja. U kunt de vorm [render the shape](http://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/) naar een afbeelding met een opgegeven grootte/schaal of [export it as SVG](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/) voor vectorgebruik.

**Hoe krijg ik snel de werkelijke (effectieve) eigenschappen van een rechthoek, rekening houdend met thema en overerving?**

[Use the shape’s effective properties](/slides/nl/net/shape-effective-properties/): de API retourneert berekende waarden die rekening houden met themastijlen, lay‑out en lokale instellingen, waardoor de opmaakanalyse wordt vereenvoudigd.
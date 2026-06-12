---
title: Beheer SmartArt‑graphics in presentaties in .NET
linktitle: SmartArt‑graphics
type: docs
weight: 20
url: /nl/net/manage-smartart-shape/
keywords:
- SmartArt‑object
- SmartArt‑grafiek
- SmartArt‑stijl
- SmartArt‑kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt‑lay-outtype
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Automatiseer het maken, bewerken en stylen van PowerPoint SmartArt in .NET met Aspose.Slides, met beknopte code‑voorbeelden en prestatiegerichte richtlijnen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om programmatisch SmartArt‑grafieken te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia kunt toevoegen, bestaande SmartArt‑vormen kunt benaderen, SmartArt kunt vinden op basis van een specifiek lay-outtype, en het visuele uiterlijk kunt bijwerken door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden tonen hoe u met SmartArt‑vormen werkt via de vormverzameling van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen ervan wijzigt of inspecteert.

## **Maak een SmartArt‑vorm**

Aspose.Slides voor .NET maakt het nu mogelijk om vanaf nul aangepaste SmartArt‑vormen aan hun dia's toe te voegen. Aspose.Slides voor .NET biedt de simpelste API om SmartArt‑vormen op de eenvoudigste manier te maken. Volg de onderstaande stappen om een SmartArt‑vorm op een dia te maken:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een SmartArt‑vorm toe door de LayoutType in te stellen.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```c#
// Instantieer de presentatie
using (Presentation pres = new Presentation())
{
    // Benader de presentatiedia
    ISlide slide = pres.Slides[0];

    // Voeg SmartArt‑vorm toe
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Opslaan van presentatie
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Een SmartArt‑vorm op een dia benaderen**

De volgende code wordt gebruikt om de SmartArt‑vormen die aan een presentatiedia zijn toegevoegd te benaderen. In de voorbeeldcode lopen we door elke vorm in de dia en controleren we of het een SmartArt‑vorm is. Als de vorm van het type SmartArt is, casten we deze naar een SmartArt‑instance.

```c#
// Laad de gewenste presentatie
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{
    // Doorloop elke vorm in de eerste dia
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape is ISmartArt)
        {
            // Typecast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);
        }
    }
}
```

## **Een SmartArt‑vorm met een bepaald lay-outtype benaderen**

De volgende voorbeeldcode helpt om de SmartArt‑vorm met een specifiek LayoutType te benaderen. Let op: u kunt het LayoutType van de SmartArt niet wijzigen, omdat het alleen‑lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia door zijn Index te gebruiken.
- Loop door elke vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en typecast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
- Controleer de SmartArt‑vorm met het specifieke LayoutType en voer daarna de benodigde handelingen uit.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Doorloop elke vorm in de eerste dia
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape is ISmartArt)
        {
            // Typecast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Controleren van de SmartArt‑lay-out
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **SmartArt‑vormstijl wijzigen**

De volgende voorbeeldcode helpt om de SmartArt‑vorm met een bepaald LayoutType te benaderen.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia door zijn Index te gebruiken.
- Loop door elke vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en typecast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
- Zoek de SmartArt‑vorm met een specifieke stijl.
- Stel de nieuwe stijl in voor de SmartArt‑vorm.
- Sla de presentatie op.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Doorloop elke vorm in de eerste dia
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape is ISmartArt)
        {
            // Typecast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Controleren van de SmartArt‑stijl
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt‑stijl wijzigen
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Presentatie opslaan
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Kleurstijl van een SmartArt‑vorm wijzigen**

In dit voorbeeld leren we de kleurstijl van een SmartArt‑vorm te wijzigen. In de volgende voorbeeldcode wordt de SmartArt‑vorm met een specifieke kleurstijl benaderd en wordt de stijl aangepast.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia door zijn Index te gebruiken.
- Loop door elke vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en typecast de geselecteerde vorm naar SmartArt wanneer dat het geval is.
- Zoek de SmartArt‑vorm met een specifieke kleurstijl.
- Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.
- Sla de presentatie op.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Doorloop elke vorm in de eerste dia
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape is ISmartArt)
        {
            // Typecast vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Controleren van het SmartArt‑kleurtype
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt‑kleurtype wijzigen
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Presentatie opslaan
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik SmartArt als één object animeren?**

Ja. SmartArt is een vorm, dus u kunt [standaardanimaties](/slides/nl/net/powerpoint-animation/) toepassen via de animatie‑API (intrede, vertrek, nadruk, bewegingspaden) net zoals bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de Alternatieve Tekst (AltText) in en gebruik deze om te zoeken naar de vorm op basis van die waarde — dit is een aanbevolen manier om de doelvorm te vinden.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de [groep manipuleren](/slides/nl/net/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijv. voor een preview of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/net/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Blijft het uiterlijk van SmartArt behouden bij het converteren van de hele presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwe weergave bij [PDF‑export](/slides/nl/net/convert-powerpoint-to-pdf/), met een scala aan kwaliteits‑ en compatibiliteitsopties.
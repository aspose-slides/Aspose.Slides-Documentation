---
title: Diaformaat van de presentatie wijzigen in .NET
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/net/slide-size/
keywords:
- diaformaat
- beeldverhouding
- standaard
- breedbeeld
- 4:3
- 16:9
- diaformaat instellen
- diaformaat wijzigen
- aangepast diaformaat
- speciaal diaformaat
- uniek diaformaat
- volledig diaformaat
- schermtype
- niet schalen
- passend maken
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u snel dia's kunt wijzigen in PPT-, PPTX- en ODP-bestanden met .NET en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides voor .NET biedt uitgebreide tools om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, essentieel voor zowel afdrukken als weergave op scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (4:3‑beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9‑beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw presentatie, aangezien één diaformaat en beeldverhouding op alle dia's van toepassing is. Voor optimale resultaten stelt u de afmetingen van uw dia's in aan het begin van het maakproces van uw presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3‑beeldverhouding.
{{% /alert %}}

## **Hoe de diaformaat in een presentatie wijzigen**

Dit voorbeeld toont hoe u het diaformaat van een presentatie wijzigt met Aspose.Slides in C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Aangepaste diaformaten specificeren**

Aanpassen van het diaformaat aan uw specifieke behoeften, bijvoorbeeld voor unieke papieren lay‑outs of schermspecificaties, kan voordelig zijn. Hieronder leest u hoe u een aangepast diaformaat instelt met Aspose.Slides voor .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia‑inhoud behandelen na het aanpassen van de grootte**

Na het aanpassen kan de inhoud van de dia vervormen. U kunt bepalen hoe Aspose.Slides dit schalen beheert:

- **`DoNotScale`**: Houd objecten op hun oorspronkelijke grootte om schalen te vermijden.
- **`EnsureFit`**: Schaal objecten zodat ze op kleinere dia's passen, waardoor inhoudverlies wordt voorkomen.
- **`Maximize`**: Vergroot objecten zodat ze passen bij grotere dia's voor esthetische consistentie.

Voorbeeld van het gebruik van de `Maximize`‑instelling voor het aanpassen van het diaformaat:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Kan ik een aangepast diaformaat instellen met een ander eenheid dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (bijvoorbeeld millimeters of centimeters) naar punten omrekenen en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Heeft een zeer groot aangepast diaformaat invloed op de prestaties en het geheugenverbruik tijdens het renderen?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere renderingschaal leiden tot een toename van het geheugenverbruik en langere verwerkingstijd. Mik op een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's samenvoegen uit presentaties met verschillende formaten?**

U kunt geen [presentaties samenvoegen](/slides/nl/net/merge-presentation/) terwijl ze verschillende diaformaten hebben — resize eerst één presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/)-optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en houden deze rekening met het nieuwe diaformaat?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente framing en geometrie gegarandeerd is.
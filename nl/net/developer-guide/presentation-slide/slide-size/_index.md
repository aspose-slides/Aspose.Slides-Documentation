---
title: Wijzig het diaformaat van de presentatie in .NET
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
- volledige dia
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
description: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met .NET en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides for .NET biedt uitgebreide hulpmiddelen om het diaformaat en de beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is zowel voor afdrukken als voor weergave op het scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie in de hele presentatie, aangezien één diaformaat en beeldverhouding voor alle dia's geldt. Voor optimale resultaten stelt u de dia‑afmetingen in aan het begin van het aanmaakproces van uw presentatie om complicaties te vermijden.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Hoe u het diaformaat in een presentatie wijzigt**

Dit voorbeeld laat zien hoe u het diaformaat van een presentatie wijzigt met Aspose.Slides in C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specificeer aangepaste diaformaten**

Het aanpassen van het diaformaat aan uw specifieke behoeften, bijvoorbeeld voor unieke papierformaten of schermspecificaties, kan nuttig zijn. Hieronder ziet u hoe u een aangepast diaformaat instelt met Aspose.Slides for .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia-inhoud verwerken na het wijzigen van de grootte**

Na het wijzigen van de grootte kan de dia-inhoud vervormen. U kunt bepalen hoe Aspose.Slides dit schalen afhandelt:

- **`DoNotScale`**: Houd objecten op hun oorspronkelijke grootte om schalen te voorkomen.
- **`EnsureFit`**: Schaal objecten om kleinere dia's te laten passen, waardoor verlies van inhoud wordt voorkomen.
- **`Maximize`**: Vergroot objecten zodat ze bij grotere dia's passen voor esthetische consistentie.

Voorbeeld van het gebruik van de `Maximize`‑instelling voor het aanpassen van het diaformaat:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Veelgestelde vragen**

### Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) naar punten omrekenen en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

### Zal een zeer groot aangepast diaformaat de prestaties en het geheugengebruik tijdens het renderen beïnvloeden?

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere renderingschaal leiden tot een hoger geheugengebruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

### Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's samenvoegen uit presentaties met verschillende formaten?

U kunt geen [presentaties samenvoegen](/slides/nl/net/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst moet u één presentatie aanpassen zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/)-optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

### Kan ik miniaturen genereren voor individuele vormen of specifieke delen van een dia, en zullen ze het nieuwe diaformaat respecteren?

Ja. Aspose.Slides kan miniaturen renderen voor [hele dia's](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente indeling en geometrie wordt gegarandeerd.
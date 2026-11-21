---
title: Wijzig de dia-grootte van de presentatie in .NET
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/net/slide-size/
keywords:
- dia-grootte
- beeldverhouding
- standaard
- breedbeeld
- 4:3
- 16:9
- dia-grootte instellen
- dia-grootte wijzigen
- aangepaste dia-grootte
- bijzondere dia-grootte
- unieke dia-grootte
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
description: "Leer hoe u snel dia's kunt wijzigen in PPT, PPTX en ODP-bestanden met .NET en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides for .NET biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie gedurende uw presentatie, aangezien één dia‑grootte en beeldverhouding voor alle dia's gelden. Voor optimale resultaten stelt u de dia‑afmetingen in het begin van het maakproces van uw presentatie in om complicaties te voorkomen.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

Notitie‑ en hand‑out‑pagina's hebben andere afmetingen dan reguliere dia's. Zie [Notes Page Size](/slides/nl/net/notes-size/) om hun grootte en oriëntatie te wijzigen.

## **Hoe de dia‑grootte in een presentatie wijzigen**

Dit voorbeeld toont hoe u de dia‑grootte van een presentatie wijzigt met Aspose.Slides in C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Aangepaste dia‑groottes opgeven**

Het aanpassen van de dia‑grootte aan uw specifieke wensen, bijvoorbeeld voor unieke papierlay-outs of schermspecificaties, kan nuttig zijn. Hieronder ziet u hoe u een aangepaste dia‑grootte instelt met Aspose.Slides voor .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia‑inhoud na het wijzigen van de grootte verwerken**

Na het wijzigen van de grootte kan de dia‑inhoud vervormen. U kunt bepalen hoe Aspose.Slides dit herschalen beheert:

- **`DoNotScale`**: Houd objecten op de oorspronkelijke grootte om schalen te vermijden.
- **`EnsureFit`**: Schaal objecten zodat ze op kleinere dia's passen, waardoor verlies van inhoud wordt voorkomen.
- **`Maximize`**: Vergroot objecten zodat ze passen bij grotere dia's voor esthetische consistentie.

Voorbeeld van het gebruik van de `Maximize`‑instelling voor het aanpassen van de dia‑grootte:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) naar punten omrekenen en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

### Heeft een zeer grote aangepaste dia‑grootte invloed op de prestaties en het geheugenverbruik tijdens het renderen?

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer nodig om de gewenste uitvoerkwaliteit te bereiken.

### Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia's samenvoegen uit presentaties met verschillende groottes?

U kunt geen [presentaties samenvoegen](/slides/nl/net/merge-presentation/) als ze verschillende dia‑groottes hebben — eerst moet u één presentatie aanpassen zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/)‑optie. Nadat de groottes zijn afgestemd, kunt u dia's samenvoegen en de opmaak behouden.

### Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en zullen ze de nieuwe dia‑grootte respecteren?

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor consistente kadrering en geometrie gewaarborgd zijn.
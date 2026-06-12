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
descriptions: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met .NET en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides for .NET biedt uitgebreide tools om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is zowel voor afdrukken als weergave op het scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie gedurende uw presentatie, aangezien één diaformaat en beeldverhouding op alle dia's van toepassing zijn. Voor optimale resultaten stelt u de afmetingen van de dia's in aan het begin van het creatieproces van uw presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Hoe de diaformaat in een presentatie te wijzigen**

Dit voorbeeld toont hoe u het diaformaat van een presentatie wijzigt met Aspose.Slides in C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Aangepaste diaformaten opgeven**

Het diaformaat aanpassen aan uw specifieke behoeften, bijvoorbeeld voor unieke papierindelingen of schermspecificaties, kan nuttig zijn. Hieronder ziet u hoe u een aangepast diaformaat instelt met Aspose.Slides voor .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papierformaat
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia-inhoud beheren na het wijzigen van de grootte**

Na het wijzigen van de grootte kan de dia-inhoud vervormen. U kunt bepalen hoe Aspose.Slides dit herschalen beheert:

- **`DoNotScale`**: Houd objecten op hun oorspronkelijke grootte om schalen te voorkomen.
- **`EnsureFit`**: Schaal objecten zodat ze passen op kleinere dia's, waardoor verlies van inhoud wordt voorkomen.
- **`Maximize`**: Vergroot objecten zodat ze passen op grotere dia's voor esthetische consistentie.

Voorbeeld van het gebruik van de instelling `Maximize` voor het aanpassen van het diaformaat:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) naar punten converteren en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere rendementschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en daarna dia's samenvoegen uit presentaties die verschillende formaten hebben?**

U kunt geen [presentaties samenvoegen](/slides/nl/net/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst één presentatie aanpassen zodat het formaat overeenkomt. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt verwerkt via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/) optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniatuurafbeeldingen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren die de nieuwe diaformaat?**

Ja. Aspose.Slides kan miniaturen renderen voor [gehele dia's](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen de huidige diaformaat en beeldverhouding, wat zorgt voor consistente kadrering en geometrie.
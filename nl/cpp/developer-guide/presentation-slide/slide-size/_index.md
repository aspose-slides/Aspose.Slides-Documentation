---
title: Diaformaat van de presentatie wijzigen in C++
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/cpp/slide-size/
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
- C++
- Aspose.Slides
description: "Leer hoe u snel dia's kunt wijzigen in PPT-, PPTX- en ODP-bestanden met C++ en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide tools om de dia‑afmeting en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm.

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie gedurende uw presentatie, aangezien één diaformaat en beeldverhouding van toepassing zijn op alle dia's. Voor optimale resultaten stelt u de afmetingen van uw dia's in aan het begin van het aanmaken van de presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie kunt wijzigen in C++ met behulp van Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Aangepaste diaformaten specificeren in presentaties**

Als u de gangbare diaformaten (4:3 en 16:9) ongeschikt vindt voor uw werk, kunt u besluiten een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia's uit uw presentatie af te drukken op een aangepaste paginalay-out of als u uw presentatie op bepaalde schermtypen wilt weergeven, zult u waarschijnlijk profiteren van het gebruiken van een aangepaste grootte‑instelling voor uw presentatie.

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor C++ kunt gebruiken om een aangepast diaformaat voor een presentatie in C++ te specificeren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-papierformaat
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Dia‑inhoud verwerken na het wijzigen van de grootte**

Na het wijzigen van het diaformaat voor een presentatie kunnen de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch geschaald zodat ze passen bij het nieuwe diaformaat. Bij het wijzigen van het diaformaat kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides met de inhoud op de dia's omgaat.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden geschaald, gebruik dan deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat u inhoud niet verliest), gebruik dan deze instelling.

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig zijn met het nieuwe diaformaat, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van de grootte van een dia in een presentatie:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Veelgestelde vragen**

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern points, waarbij 1 point gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar points en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugengebruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in points) in combinatie met een hogere render‑schaal leiden tot een hoger geheugengebruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te behalen.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's van presentaties met verschillende formaten samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/cpp/merge-presentation/) terwijl ze verschillende diaformaten hebben — resize eerst één presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/) optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke regio's van een dia, en houden ze rekening met het nieuwe diaformaat?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/getimage/) en voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen de huidige dia‑afmeting en beeldverhouding, waardoor een consistente framing en geometrie wordt gegarandeerd.
---
title: Verander de Dia-grootte van de Presentatie in C++
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/cpp/slide-size/
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
- speciale dia-grootte
- unieke dia-grootte
- dia op volledige grootte
- schermtype
- niet schalen
- passen waarborgen
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u snel dia's kunt verkleinen in PPT-, PPTX- en ODP-bestanden met C++ en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide tools om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm. 

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie in uw hele presentatie, aangezien één dia‑grootte en beeldverhouding voor alle dia's geldt. Voor optimale resultaten stelt u de afmetingen van de dia's in het begin van het creatieproces van de presentatie in om complicaties te vermijden.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Dia‑grootte wijzigen in presentaties**

Deze voorbeeldcode toont hoe u de dia‑grootte in een presentatie wijzigt in C++ met behulp van Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Aangepaste dia‑groottes specificeren in presentaties**

Als u de gangbare dia‑groottes (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u besluiten een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld, als u van plan bent full‑size dia's af te drukken vanuit uw presentatie op een aangepast paginalayout, of als u uw presentatie wilt weergeven op bepaalde schermtypes, zult u waarschijnlijk profiteren van een aangepaste grootte‑instelling voor uw presentatie. 

Deze voorbeeldcode toont hoe u Aspose.Slides voor C++ gebruikt om een aangepaste dia‑grootte voor een presentatie op te geven in C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-papierformaat
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Dia‑inhoud verwerken na het wijzigen van de grootte**

Nadat u de dia‑grootte van een presentatie wijzigt, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast om bij de nieuwe dia‑grootte te passen. Wanneer u echter de dia‑grootte van een presentatie wijzigt, kunt u een instelling specificeren die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale` : Als u NIET wilt dat de objecten op de dia's worden aangepast, gebruik dan deze instelling.

- `EnsureFit` : Als u wilt schalen naar een kleinere dia‑grootte en u wilt dat Aspose.Slides de objecten op de dia's verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruik dan deze instelling. 

- `Maximize` : Als u wilt schalen naar een grotere dia‑grootte en u wilt dat Aspose.Slides de objecten op de dia's vergroot zodat ze evenredig zijn aan de nieuwe dia‑grootte, gebruik dan deze instelling. 

Deze voorbeeldcode toont hoe u de instelling `Maximize` gebruikt bij het wijzigen van de grootte van de dia van een presentatie:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgerekende waarden gebruiken om de breedte en hoogte van de dia te definiëren.

### Heeft een zeer grote aangepaste dia‑grootte invloed op de prestaties en het geheugenverbruik tijdens het renderen?

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere renderschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de renderschaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te bereiken.

### Kan ik één niet‑standaard dia‑grootte definiëren en daarna dia's uit presentaties met verschillende groottes samenvoegen?

U kunt geen [presentaties samenvoegen](/slides/nl/cpp/merge-presentation/) terwijl ze verschillende dia‑groottes hebben — eerst moet u één presentatie aanpassen aan de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de optie [SlideSizeScaleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/). Nadat de groottes zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

### Kan ik miniaturen genereren voor afzonderlijke vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑grootte?

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente framing en geometrie wordt gegarandeerd.
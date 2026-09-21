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
description: "Leer hoe u snel dia's kunt herschalen in PPT-, PPTX- en ODP-bestanden met C++ en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (beeldverhouding 4:3)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (beeldverhouding 16:9)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie gedurende uw presentatie, aangezien één enkele diaformaat en beeldverhouding op alle dia's van toepassing is. Voor optimale resultaten stelt u de afmetingen van de dia's in aan het begin van het aanmaakproces van uw presentatie om complicaties te voorkomen.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard beeldverhouding 4:3.
{{% /alert %}}

Notitie‑ en handouts‑pagina's hebben andere afmetingen dan gewone dia's. Zie [Notes Page Size](/slides/nl/cpp/notes-size/) om hun grootte en oriëntatie aan te passen.

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie kunt wijzigen in C++ met behulp van Aspose.Slides:

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

## **Aangepaste diaformaten opgeven in presentaties**

Als de gangbare diaformaten (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u ervoor kiezen een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia's af te drukken vanuit uw presentatie op een aangepast paginaplan of als u uw presentatie op bepaalde schermtypes wilt weergeven, kunt u profiteren van een aangepaste formaatinstelling voor uw presentatie. 

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor C++ kunt gebruiken om een aangepast diaformaat voor een presentatie op te geven in C++:

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

## **Dia‑inhoud afhandelen na het wijzigen van het formaat**

Na het wijzigen van het diaformaat van een presentatie kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch herschaald om op het nieuwe diaformaat te passen. Bij het wijzigen van het diaformaat van een presentatie kunt u echter een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia's omgaat.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden herschaald, gebruikt u deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten op de dia's verkleint zodat ze allemaal op de dia's passen (zodat u inhoud niet verliest), gebruikt u deze instelling. 

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten op de dia's vergroot zodat ze evenredig zijn aan het nieuwe diaformaat, gebruikt u deze instelling. 

Deze voorbeeldcode laat zien hoe u de instelling `Maximize` gebruikt bij het wijzigen van het formaat van een dia in een presentatie:

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

### Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgerekende waarden gebruiken om de breedte en hoogte van de dia te definiëren.

### Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?

Ja. Grotere dia‑afmetingen (in punten) gecombineerd met een hogere renderingschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

### Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's van presentaties met verschillende formaten samenvoegen?

U kunt geen [presentaties samenvoegen](/slides/nl/cpp/merge-presentation/) uitvoeren terwijl ze verschillende diaformaten hebben — eerst moet u één presentatie herschalen zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/)‑optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

### Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en zullen deze het nieuwe diaformaat respecteren?

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente compositie en geometrie wordt gegarandeerd.
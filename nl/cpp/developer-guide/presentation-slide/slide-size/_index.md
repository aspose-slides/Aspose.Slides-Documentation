---
title: Dia-grootte van de presentatie wijzigen in C++
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
- volledige dia-grootte
- schermtype
- niet schalen
- passend maken
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
descriptions: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met C++ en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia-grootte en beeldverhouding in PowerPoint-presentaties aan te passen, zowel voor afdrukken als weergave op scherm. 

Populaire dia-groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie gedurende uw presentatie, aangezien één dia-grootte en beeldverhouding voor alle dia’s gelden. Voor optimale resultaten stelt u de afmetingen van de dia’s in aan het begin van het maken van de presentatie om complicaties te vermijden.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Dia-grootte wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u de dia-grootte in een presentatie kunt wijzigen in C++ met Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Aangepaste dia-groottes specificeren in presentaties**

Als de gebruikelijke dia-groottes (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u besluiten een specifieke of unieke dia-grootte te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia’s af te drukken vanuit uw presentatie op een aangepaste paginavorm, of als u uw presentatie wilt weergeven op bepaalde schermtypen, kunt u profiteren van een aangepaste grootte-instelling voor uw presentatie. 

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor C++ kunt gebruiken om een aangepaste dia-grootte voor een presentatie te specificeren in C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-papierformaat
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Dia-inhoud afhandelen na het herschalen**

Nadat u de dia-grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch herschaald zodat ze passen bij de nieuwe dia-grootte. Wanneer u de dia-grootte van een presentatie wijzigt, kunt u echter een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia’s worden herschaald, gebruikt u deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleinere dia-grootte en u wilt dat Aspose.Slides de objecten op de dia’s verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling. 

- `Maximize`

  Als u wilt schalen naar een grotere dia-grootte en u wilt dat Aspose.Slides de objecten op de dia’s vergroot zodat ze proportioneel zijn aan de nieuwe dia-grootte, gebruikt u deze instelling. 

Deze voorbeeldcode laat zien hoe u de instelling `Maximize` gebruikt bij het wijzigen van de grootte van een dia in een presentatie:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Kan ik een aangepaste dia-grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer grote aangepaste dia-grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia-afmetingen (in punten) in combinatie met een hogere render-schaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia-grootte en pas de render-schaal alleen aan wanneer dat nodig is om de gewenste output-kwaliteit te bereiken.

**Kan ik één niet-standaard dia-grootte definiëren en vervolgens dia’s uit presentaties met verschillende groottes samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/cpp/merge-presentation/) terwijl ze verschillende dia-groottes hebben — eerst de grootte van één presentatie aanpassen zodat deze overeenkomt met de andere. Bij het wijzigen van de dia-grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de optie [SlideSizeScaleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/). Nadat de groottes zijn afgestemd, kunt u dia’s samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke regio’s van een dia, en respecteren deze de nieuwe dia-grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [complete dia’s](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/getimage/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/). De resulterende afbeeldingen weerspiegelen de huidige dia-grootte en beeldverhouding, waardoor een consistente kadering en geometrie gewaarborgd blijft.
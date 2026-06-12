---
title: Diaformaat van de presentatie wijzigen in PHP
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/php-java/slide-size/
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
- passen garanderen
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
descriptions: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met PHP en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑afmeting en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie door uw hele presentatie: één diaformaat en beeldverhouding gelden voor alle dia’s. Voor optimale resultaten stelt u de dia‑afmetingen in aan het begin van het maken van de presentatie om complicaties te vermijden.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides worden aangemaakt de 4:3‑beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie wijzigt met Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aangepaste diaformaten opgeven in presentaties**

Als de gangbare diaformaten (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u een specifiek of uniek diaformaat gebruiken. Bijvoorbeeld wanneer u volledige dia’s wilt afdrukken op een aangepast paginalay‑out of wanneer u de presentatie wilt weergeven op bepaalde schermtypen, kan een aangepaste afmeting nuttig zijn. 

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor PHP via Java gebruikt om een aangepast diaformaat voor een presentatie op te geven:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4-papierformaat

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dia-inhoud behandelen na het aanpassen van het formaat**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (afbeeldingen of objecten, bijvoorbeeld) vervormd raken. Standaard worden objecten automatisch verkleind of vergroot zodat ze passen bij het nieuwe diaformaat. Bij het wijzigen van het diaformaat kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia’s.

Afhankelijk van wat u wilt bereiken, kunt u één van de volgende instellingen gebruiken:

- `DoNotScale`

  Als u **NIET** wilt dat de objecten op de dia’s worden geschaald, gebruikt u deze instelling.

- `EnsureFit`

  Als u naar een kleiner diaformaat wilt schalen en Aspose.Slides de objecten moet verkleinen zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling. 

- `Maximize`

  Als u naar een groter diaformaat wilt schalen en Aspose.Slides de objecten moet vergroten zodat ze evenredig blijven aan het nieuwe diaformaat, gebruikt u deze instelling. 

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van het diaformaat van een presentatie:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik een aangepast diaformaat instellen met eenheden anders dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en deze waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot meer geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste kwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia’s uit presentaties met verschillende formaten samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/php-java/merge-presentation/) terwijl ze verschillende diaformaten hebben – resize eerst één presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/)‑optie. Nadat de formaten zijn afgestemd, kunt u dia’s samenvoegen met behoud van opmaak.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑afmeting?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) én voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen de huidige dia‑afmeting en beeldverhouding, waardoor een consistente framing en geometrie wordt gegarandeerd.
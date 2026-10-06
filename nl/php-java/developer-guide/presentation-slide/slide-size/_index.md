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
- passend maken
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u snel dia's kunt aanpassen in PPT, PPTX en ODP-bestanden met PHP en Aspose.Slides, en presentaties kunt optimaliseren voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide tools om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm.

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw presentatie, want één dia‑grootte en beeldverhouding geldt voor alle dia's. Voor optimale resultaten stelt u de afmetingen van de dia's in aan het begin van het aanmaakproces van uw presentatie om complicaties te voorkomen.

{{% alert color="info" title="Note" %}}
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

Notitie‑ en handoutpagina's hebben andere afmetingen dan gewone dia's. Zie [Grootte van notitiepagina](/slides/nl/php-java/notes-size/) om hun grootte en oriëntatie te wijzigen.

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

Als u de gangbare diaformaten (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u ervoor kiezen een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia's uit uw presentatie af te drukken op een aangepaste paginalay-out, of als u de presentatie wilt weergeven op bepaalde schermtypes, dan profiteert u waarschijnlijk van een aangepaste formaatinstelling voor uw presentatie.

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

## **Dia-inhoud behandelen na het wijzigen van het formaat**

Nadat u het diaformaat van een presentatie wijzigt, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast om in het nieuwe diaformaat te passen. Bij het wijzigen van het diaformaat kunt u echter een instelling specificeren die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u de objecten op de dia's NIET wilt laten schalen, gebruikt u deze instelling.

- `EnsureFit`

  Als u naar een kleiner diaformaat wilt schalen en u wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- `Maximize`

  Als u naar een groter diaformaat wilt schalen en u wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig zijn aan het nieuwe diaformaat, gebruikt u deze instelling.

Deze voorbeeldcode laat zien hoe u de instelling `Maximize` gebruikt bij het wijzigen van het diaformaat van een presentatie:

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

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgerekende waarden gebruiken om de dia-breedte en -hoogte te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens renderen beïnvloeden?**

Ja. Grotere dia-afmetingen (in punten) in combinatie met een hogere renderingsschaal leiden tot meer geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingsschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet-standaard diaformaat definiëren en vervolgens dia's uit presentaties met verschillende groottes samenvoegen?**

U kunt niet [presentaties samenvoegen](/slides/nl/php-java/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst past u één presentatie aan zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/) optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen met behoud van de opmaak.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑afmeting?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) en voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑afmeting en beeldverhouding, waardoor een consistente compositie en geometrie gewaarborgd zijn.
---
title: Wijzig de dia‑grootte van de presentatie in PHP
linktitle: Dia‑grootte
type: docs
weight: 70
url: /nl/php-java/slide-size/
keywords:
- dia‑grootte
- beeldverhouding
- standaard
- breedbeeld
- 4:3
- 16:9
- dia‑grootte instellen
- dia‑grootte wijzigen
- aangepaste dia‑grootte
- bijzondere dia‑grootte
- unieke dia‑grootte
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
description: "Leer hoe u snel dia's kunt herschalen in PPT-, PPTX- en ODP-bestanden met PHP en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op beeldschermen.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectors en displays.

Zorg voor consistentie in je hele presentatie, want één enkele dia‑grootte en beeldverhouding geldt voor alle dia’s. Voor optimale resultaten stel je de dia‑afmetingen in aan het begin van het maken van je presentatie om complicaties te vermijden.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides worden aangemaakt de 4:3‑beeldverhouding.  
{{% /alert %}}

## **Dia‑grootte wijzigen in presentaties**

 Deze voorbeeldcode toont hoe je de dia‑grootte in een presentatie wijzigt met Aspose.Slides:

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

## **Aangepaste dia‑groottes opgeven in presentaties**

Als de gangbare dia‑groottes (4:3 en 16:9) niet passen bij jouw werk, kun je besluiten een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld wanneer je volledige dia’s wilt afdrukken op een aangepaste paginalay‑out of wanneer je de presentatie wilt weergeven op bepaalde schermtypen, profiteer je van een aangepaste grootte‑instelling voor je presentatie.

Deze voorbeeldcode laat zien hoe je Aspose.Slides for PHP via Java gebruikt om een aangepaste dia‑grootte voor een presentatie op te geven:

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

## **Dia‑inhoud verwerken na herschalen**

Na het wijzigen van de dia‑grootte van een presentatie kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch herschaald om in de nieuwe dia‑grootte te passen. Wanneer je de dia‑grootte van een presentatie wijzigt, kun je echter een instelling specificeren die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia’s.

Afhankelijk van wat je wilt bereiken, kun je een van de volgende instellingen gebruiken:

- `DoNotScale`

  Gebruik deze instelling als je **NIET** wilt dat de objecten op de dia’s worden herschaald.

- `EnsureFit`

  Gebruik deze instelling als je naar een kleinere dia‑grootte wilt schalen en wilt dat Aspose.Slides de objecten verlaagt zodat ze allemaal op de dia passen (zodat er geen inhoud verloren gaat).

- `Maximize`

  Gebruik deze instelling als je naar een grotere dia‑grootte wilt schalen en wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig blijven met de nieuwe dia‑grootte.

Deze voorbeeldcode laat zien hoe je de `Maximize`‑instelling gebruikt wanneer je de grootte van de dia’s van een presentatie wijzigt:

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

**Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. Je kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgerekenen waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste output‑kwaliteit te behalen.

**Kan ik één niet‑standaard dia‑grootte definiëren en daarna dia’s uit presentaties met verschillende groottes samenvoegen?**

Je kunt niet [presentaties samenvoegen](/slides/nl/php-java/merge-presentation/) terwijl ze verschillende dia‑groottes hebben — eerst moet je één presentatie herschalen zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kun je kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/)-optie. Nadat de groottes zijn afgestemd, kun je dia’s samenvoegen en de opmaak behouden.

**Kan ik thumbnails genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan thumbnails renderen voor [volledige dia’s](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente kadrering en geometrie gegarandeerd zijn.
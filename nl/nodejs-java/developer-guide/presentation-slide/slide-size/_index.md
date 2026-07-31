---
title: Diaformaat van de presentatie wijzigen in JavaScript
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/nodejs-java/slide-size/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u snel dia's kunt schalen in PPT-, PPTX- en ODP-bestanden met Node.js en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide tools om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm. 

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw gehele presentatie, aangezien één diaformaat en beeldverhouding voor alle dia's geldt. Voor optimale resultaten stelt u de afmetingen van de dia's in het begin van het maken van de presentatie in om complicaties te vermijden.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides worden aangemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode toont hoe u het diaformaat in een presentatie in JavaScript kunt wijzigen met Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aangepaste diaformaten specificeren in presentaties**

Als u de gangbare diaformaten (4:3 en 16:9) ongeschikt vindt voor uw werk, kunt u ervoor kiezen een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia's uit uw presentatie af te drukken op een aangepaste paginalay-out of als u uw presentatie wilt weergeven op bepaalde schermtypen, dan profiteert u waarschijnlijk van het instellen van een aangepast formaat voor uw presentatie. 

Deze voorbeeldcode toont hoe u Aspose.Slides voor Node.js via Java kunt gebruiken om een aangepast diaformaat voor een presentatie in JavaScript te specificeren:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Omgaan met problemen bij het wijzigen van de diaformaat in presentaties**

Nadat u het diaformaat voor een presentatie wijzigt, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast aan het nieuwe diaformaat. Wanneer u echter het diaformaat van een presentatie wijzigt, kunt u een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden geschaald, gebruik dan deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten op de dia's verkleint zodat ze allemaal passen (zodat u geen inhoud verliest), gebruik dan deze instelling. 

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten op de dia's vergroot zodat ze evenredig zijn aan het nieuwe diaformaat, gebruik dan deze instelling. 

Deze voorbeeldcode toont hoe u de instelling `Maximize` gebruikt bij het wijzigen van het diaformaat van een presentatie:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgerekende waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere renderingschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's uit presentaties die verschillende formaten hebben samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/nodejs-java/merge-presentation/) wanneer ze verschillende diaformaten hebben — eerst moet u één presentatie aanpassen aan het formaat van de andere. Bij het wijzigen van het diaformaat kunt u via de optie [SlideSizeScaleType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/) kiezen hoe bestaande inhoud wordt behandeld. Nadat de formaten op elkaar zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik thumbnails genereren voor individuele vormen of specifieke gebieden van een dia, en zullen ze het nieuwe diaformaat respecteren?**

Ja. Aspose.Slides kan thumbnails renderen voor [gehele dia's](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) en voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente kadering en geometrie gegarandeerd is.
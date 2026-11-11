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
- volledig diaformaat
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
description: "Leer hoe u snel dia's kunt vergroten/verkleinen in PPT-, PPTX- en ODP-bestanden met Node.js en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om het diaformaat en de beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op het scherm. 

Populaire diaformaten en beeldverhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie gedurende uw presentatie, aangezien één diaformaat en beeldverhouding voor alle dia's geldt. Voor optimale resultaten stelt u de afmetingen van de dia in aan het begin van het maken van uw presentatie om complicaties te vermijden.

{{% alert color="info" title="Note" %}}
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

Notitie- en uitdeelpaginadimensies zijn gescheiden van gewone dia's. Zie [Notes Page Size](/slides/nl/nodejs-java/notes-size/) om hun grootte en oriëntatie te wijzigen.

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie kunt wijzigen met JavaScript via Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Aangepaste diaformaten opgeven in presentaties**

Als u de gangbare diaformaten (4:3 en 16:9) ongeschikt vindt voor uw werk, kunt u kiezen voor een specifiek of uniek diaformaat. Bijvoorbeeld wanneer u van plan bent volledige dia's van uw presentatie af te drukken op een aangepaste paginavormgeving of wanneer u uw presentatie wilt weergeven op bepaalde schermtypen, dan heeft u waarschijnlijk baat bij een aangepaste formaatinstelling voor uw presentatie. 

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor Node.js via Java kunt gebruiken om een aangepast diaformaat voor een presentatie in JavaScript te specificeren:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Omgaan met problemen bij het wijzigen van het diaformaat in presentaties**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast aan het nieuwe diaformaat. Wanneer u echter het diaformaat van een presentatie wijzigt, kunt u een instelling specificeren die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden aangepast, gebruik dan deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten van de dia's verkleint zodat ze allemaal op de dia passen (op deze manier voorkomt u het verlies van inhoud), gebruik dan deze instelling. 

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten van de dia's vergroot zodat ze evenredig blijven aan het nieuwe diaformaat, gebruik dan deze instelling. 

Deze voorbeeldcode laat zien hoe u de instelling `Maximize` gebruikt bij het wijzigen van het diaformaat van een presentatie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere diademensies (in punten) in combinatie met een hogere renderingschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijd. Streef naar een praktische diagrootte en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te behalen.

**Kan ik één niet-standaard diaformaat definiëren en vervolgens dia's uit presentaties met verschillende formaten samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/nodejs-java/merge-presentation/) zolang ze verschillende diaformaten hebben — eerst moet u één presentatie aanpassen aan het andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt verwerkt via de optie [SlideSizeScaleType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/). Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik thumbnails genereren voor individuele vormen of specifieke gebieden van een dia, en houden ze rekening met het nieuwe diaformaat?**

Ja. Aspose.Slides kan thumbnails renderen voor [hele dia's](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage). De gegenereerde afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente framing en geometrie behouden blijft.
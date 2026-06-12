---
title: Wijzigen van de diaformaat van de presentatie in JavaScript
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
- dia op volledige grootte
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
descriptions: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met Node.js en Aspose.Slides, optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm.  

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.  

Zorg voor consistentie in uw presentatie, aangezien één enkele diaformaat en beeldverhouding van toepassing zijn op alle dia's. Voor optimale resultaten stelt u de afmetingen van uw dia's in het begin van het creatieproces van de presentatie in om complicaties te voorkomen.  

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie in JavaScript kunt wijzigen met Aspose.Slides:

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

## **Aangepaste diaformaten opgeven in presentaties**

Als u de gangbare diaformaten (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u besluiten een specifieke of unieke diaformaat te gebruiken. Bijvoorbeeld wanneer u van plan bent volledige dia's uit uw presentatie af te drukken op een aangepaste paginalay‑out of wanneer u uw presentatie op bepaalde schermtypes wilt weergeven, dan kunt u profiteren van een aangepaste formaatinstelling voor uw presentatie.  

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor Node.js via Java kunt gebruiken om een aangepast diaformaat voor een presentatie in JavaScript op te geven:

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

## **Omgaan met problemen bij het wijzigen van het diaformaat in presentaties**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast om in het nieuwe diaformaat te passen. Bij het wijzigen van het diaformaat van een presentatie kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.  

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden aangepast, gebruik dan deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten van de dia's verkleint zodat ze allemaal op de dia's passen (op deze manier voorkomt u verlies van inhoud), gebruik dan deze instelling.

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten van de dia's vergroot zodat ze evenredig zijn aan het nieuwe diaformaat, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van het diaformaat van een presentatie:

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

**Kan ik een aangepast diaformaat instellen met een eenheid anders dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere renderingschaal leiden tot een hoger geheugengebruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's samenvoegen uit presentaties die verschillende afmetingen hebben?**

U kunt niet [presentaties samenvoegen](/slides/nl/nodejs-java/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst moet u één presentatie aanpassen zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/) optie kiezen hoe bestaande inhoud wordt behandeld. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen met behoud van de opmaak.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑afmeting?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen de huidige dia‑afmeting en beeldverhouding, waardoor een consistente framing en geometrie wordt gegarandeerd.
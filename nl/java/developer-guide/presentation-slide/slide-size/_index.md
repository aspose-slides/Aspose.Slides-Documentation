---
title: Dia‑grootte van presentatie wijzigen in Java
linktitle: Dia‑grootte
type: docs
weight: 70
url: /nl/java/slide-size/
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
- speciale dia‑grootte
- unieke dia‑grootte
- volledige dia
- schermtype
- niet schalen
- passend maken
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u snel dia’s kunt herschalen in PPT-, PPTX- en ODP‑bestanden met Java en Aspose.Slides, en presentaties voor elk scherm kunt optimaliseren zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide tools om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, cruciaal voor zowel afdrukken als weergave op scherm. 

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in je hele presentatie, want één dia‑grootte en beeldverhouding geldt voor alle dia’s. Voor optimale resultaten stel je de afmetingen van je dia’s in aan het begin van het maken van de presentatie om complicaties te vermijden.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3‑beeldverhouding.
{{% /alert %}}

## **Dia‑grootte wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe je de dia‑grootte in een presentatie in Java wijzigt met Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste dia‑groottes specificeren in presentaties**

Als de gangbare dia‑groottes (4:3 en 16:9) niet geschikt zijn voor jouw werk, kun je besluiten om een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld wanneer je volledige dia’s van je presentatie wilt afdrukken op een aangepast paginaplan of wanneer je de presentatie wilt weergeven op bepaalde schermtypen, profiteer je van een aangepaste instelling voor je presentatie. 

Deze voorbeeldcode laat zien hoe je Aspose.Slides voor Java gebruikt om een aangepaste dia‑grootte voor een presentatie in Java te specificeren:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑inhoud verwerken na het wijzigen van de grootte**

Nadat je de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (afbeeldingen of objecten, bijvoorbeeld) vervormd raken. Standaard worden de objecten automatisch herschaald om in de nieuwe dia‑grootte te passen. Wanneer je echter de dia‑grootte van een presentatie wijzigt, kun je een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat je wilt bereiken, kun je een van deze instellingen gebruiken:

- `DoNotScale`

  Als je **NIET** wilt dat de objecten op de dia’s worden herschaald, gebruik dan deze instelling.

- `EnsureFit`

  Als je wilt schalen naar een kleinere dia‑grootte en je wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat je geen inhoud verliest), gebruik dan deze instelling. 

- `Maximize`

  Als je wilt schalen naar een grotere dia‑grootte en je wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig blijven aan de nieuwe dia‑grootte, gebruik dan deze instelling. 

Deze voorbeeldcode laat zien hoe je de `Maximize`‑instelling gebruikt wanneer je de grootte van de dia’s in een presentatie wijzigt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. Je kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

### Heeft een zeer grote aangepaste dia‑grootte invloed op de prestaties en geheugengebruik tijdens het renderen?

Ja. Grotere dia‑afmetingen (in punten) gecombineerd met een hogere render‑schaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

### Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia’s uit presentaties met verschillende groottes samenvoegen?

Je kunt niet [presentaties samenvoegen](/slides/nl/java/merge-presentation/) terwijl ze verschillende dia‑groottes hebben — resize eerst één presentatie zodat deze overeenkomt met de andere. Wanneer je de dia‑grootte wijzigt, kun je kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/)‑optie. Na het uitlijnen van de groottes kun je dia’s samenvoegen terwijl de opmaak behouden blijft.

### Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren die de nieuwe dia‑grootte?

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia’s](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente framing en geometrie gegarandeerd is.
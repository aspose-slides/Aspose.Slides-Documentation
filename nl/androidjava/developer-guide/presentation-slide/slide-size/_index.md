---
title: Diaformaat van de presentatie wijzigen op Android
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
description: "Verklein dia's snel in PPT-, PPTX- en ODP-bestanden met Java en Aspose.Slides voor Android, optimaliseer presentaties voor elk scherm zonder kwaliteit te verliezen."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is zowel voor afdrukken als voor weergave op het scherm.

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in de hele presentatie, want één dia‑grootte en beeldverhouding gelden voor alle dia’s. Voor optimale resultaten stel je de dia‑afmetingen in aan het begin van het maakproces van je presentatie om complicaties te voorkomen.

{{% alert color="info" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de 4:3‑beeldverhouding.  
{{% /alert %}}

## **Grootte van dia's wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe je de dia‑grootte in een presentatie wijzigt in Java met Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste diaformaten opgeven in presentaties**

Als de gangbare diaformaten (4:3 en 16:9) niet passen bij jouw werk, kun je ervoor kiezen om een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld wanneer je volledige dia’s wilt afdrukken op een aangepaste paginavorm, of wanneer je de presentatie op bepaalde schermtypen wilt tonen, profiteer je van een aangepaste formateninstelling voor je presentatie.

Deze voorbeeldcode laat zien hoe je Aspose.Slides voor Android via Java gebruikt om een aangepast diaformaat voor een presentatie in Java op te geven:

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

## **Dia-inhoud verwerken na het schalen**

Nadat je de dia‑grootte van een presentatie hebt gewijzigd, kunnen de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch herschaald om te passen bij de nieuwe dia‑grootte. Bij het wijzigen van de dia‑grootte kun je echter een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat je wilt bereiken, kun je een van deze instellingen gebruiken:

- `DoNotScale`

  Als je **NIET** wilt dat de objecten op de dia’s worden geschaald, gebruik dan deze instelling.

- `EnsureFit`

  Als je wilt schalen naar een kleinere dia‑grootte en je wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat je geen inhoud verliest), gebruik dan deze instelling.

- `Maximize`

  Als je wilt schalen naar een grotere dia‑grootte en je wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig blijven met de nieuwe dia‑grootte, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe je de `Maximize`‑instelling gebruikt bij het wijzigen van de grootte van een dia in een presentatie:

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

### Kan ik een aangepast diaformaat instellen met een eenheid anders dan inches (bijvoorbeeld punten of millimeters)?

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. Je kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

### Heeft een zeer groot aangepast diaformaat invloed op de prestaties en het geheugenverbruik tijdens het renderen?

Ja. Grotere dia‑afmetingen (in punten) gecombineerd met een hogere render‑schaal leiden tot meer geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

### Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia’s uit presentaties met verschillende formaten samenvoegen?

Je kunt geen presentaties [samenvoegen](/slides/nl/androidjava/merge-presentation/) terwijl ze verschillende diaformaten hebben — pas eerst één presentatie aan zodat de formaten overeenkomen. Bij het wijzigen van de dia‑grootte kun je kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/)-optie. Na het op één lijn brengen van de formaten kun je dia’s samenvoegen met behoud van opmaak.

### Kan ik miniaturen genereren voor individuele vormen of specifieke regio’s van een dia, en houden die rekening met de nieuwe dia‑grootte?

Ja. Aspose.Slides kan miniaturen renderen voor [complete dia's](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente kadrering en geometrie wordt gegarandeerd.
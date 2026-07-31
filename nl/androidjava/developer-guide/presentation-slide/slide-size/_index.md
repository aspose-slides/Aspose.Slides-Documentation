---
title: Wijzig het diaformaat van de presentatie op Android
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
- volledige dia
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
description: "Verklein dia's snel in PPT-, PPTX- en ODP-bestanden met Java en Aspose.Slides voor Android, optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide tools om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, cruciaal zowel voor afdrukken als voor weergave op het scherm.  

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.  

Zorg voor consistentie gedurende uw presentatie, aangezien één enkele diaformaat en beeldverhouding op alle dia's van toepassing is. Voor optimale resultaten stelt u de dia‑afmetingen in het begin van het maken van uw presentatie in om complicaties te voorkomen.  

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding. 
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie in Java wijzigt met behulp van Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste diaformaten opgeven in presentaties**

Als u de gebruikelijke diaformaten (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u besluiten een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia's uit uw presentatie af te drukken op een aangepaste paginalay‑out of als u uw presentatie op bepaalde schermtypen wilt weergeven, kunt u profiteren van een aangepaste grootte‑instelling voor uw presentatie.  

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor Android via Java gebruikt om een aangepast diaformaat voor een presentatie in Java op te geven:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑inhoud verwerken na het aanpassen van het formaat**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast om in het nieuwe diaformaat te passen. Wanneer u echter het diaformaat van een presentatie wijzigt, kunt u een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia's.  

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u de objecten op de dia's NIET wilt laten schalen, gebruikt u deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten op de dia's verkleint om ervoor te zorgen dat ze allemaal op de dia's passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten op de dia's vergroot zodat ze proportioneel zijn aan het nieuwe diaformaat, gebruikt u deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van het diaformaat van een presentatie:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik een aangepast diaformaat instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern points, waarbij 1 point gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar points en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in points) in combinatie met een hogere renderingschaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's samenvoegen uit presentaties die verschillende formaten hebben?**

U kunt niet [presentaties samenvoegen](/slides/nl/androidjava/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst moet u één presentatie schalen zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/)‑optie. Na het op elkaar afstemmen van de formaten kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en houden deze rekening met het nieuwe diaformaat?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente compositie en geometrie gewaarborgd is.
---
title: Verander de dia-grootte van de presentatie in Java
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/java/slide-size/
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
description: "Leer hoe u snel dia's kunt verkleinen of vergroten in PPT-, PPTX- en ODP-bestanden met Java en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide tools om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie gedurende uw presentatie, omdat één dia‑grootte en beeldverhouding op alle dia’s van toepassing is. Voor optimale resultaten stelt u de afmetingen van de dia in aan het begin van het maken van de presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3‑beeldverhouding.
{{% /alert %}}

## **Dia‑grootte wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u de dia‑grootte in een presentatie in Java wijzigt met Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste dia‑groottes opgeven in presentaties**

Als u de standaard dia‑groottes (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u ervoor kiezen een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld, als u volledige dia’s uit uw presentatie wilt afdrukken op een aangepaste paginalay‑out of als u de presentatie wilt weergeven op bepaalde schermtypen, dan heeft u waarschijnlijk baat bij het gebruiken van een aangepaste grootte‑instelling voor uw presentatie.

Deze voorbeeldcode laat zien hoe u Aspose.Slides for Java kunt gebruiken om een aangepaste dia‑grootte voor een presentatie in Java op te geven:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑inhoud afhandelen na het herschalen**

Nadat u de dia‑grootte van een presentatie wijzigt, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast zodat ze passen bij de nieuwe dia‑grootte. Bij het wijzigen van de dia‑grootte kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia’s.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u de objecten op de dia’s NIET wilt laten schalen, gebruikt u deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleinere dia‑grootte en u wilt dat Aspose.Slides de objecten op de dia’s verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- `Maximize`

  Als u wilt schalen naar een grotere dia‑grootte en u wilt dat Aspose.Slides de objecten op de dia’s vergroot zodat ze proportioneel zijn ten opzichte van de nieuwe dia‑grootte, gebruikt u deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van de grootte van een dia in een presentatie:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer grote aangepaste dia‑grootte invloed hebben op de prestaties en het geheugenverbruik tijdens het renderen?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste output‑kwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en daarna dia’s uit presentaties met verschillende groottes samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/java/merge-presentation/) terwijl ze verschillende dia‑groottes hebben — eerst past u één presentatie aan zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/)-optie. Nadat de groottes zijn afgestemd, kunt u dia’s samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en zullen deze rekening houden met de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [gehele dia’s](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) én voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente kadering en geometrie gewaarborgd is.
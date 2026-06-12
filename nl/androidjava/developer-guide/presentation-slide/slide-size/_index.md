---
title: Dia-grootte van presentatie wijzigen op Android
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
descriptions: "Snel dia's herschalen in PPT-, PPTX- en ODP-bestanden met Java en Aspose.Slides voor Android, presentaties optimaliseren voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide gereedschappen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat essentieel is voor zowel afdrukken als weergave op het scherm.  

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in je hele presentatie: één dia‑grootte en beeldverhouding geldt voor alle dia’s. Voor optimale resultaten stel je de dia‑afmetingen in aan het begin van het maken van de presentatie om complicaties te vermijden.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides worden gemaakt de 4:3‑beeldverhouding.
{{% /alert %}}

## **Dia‑grootte wijzigen in presentaties**

 Deze voorbeeldcode laat zien hoe je de dia‑grootte in een presentatie in Java kunt wijzigen met Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste dia‑groottes specificeren in presentaties**

Als de gangbare dia‑groottes (4:3 en 16:9) niet geschikt zijn voor je werk, kun je besluiten een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld wanneer je volledige dia’s wilt afdrukken op een aangepaste paginalay‑out of wanneer je de presentatie wilt weergeven op bepaalde type schermen, kun je profiteren van een aangepaste grootte‑instelling voor je presentatie.  

Deze voorbeeldcode laat zien hoe je via Java Aspose.Slides voor Android kunt gebruiken om een aangepaste dia‑grootte voor een presentatie in Java te specificeren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑inhoud afhandelen na herschalen**

Nadat je de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch geschaald om in de nieuwe dia‑grootte te passen. Wanneer je echter de dia‑grootte wijzigt, kun je een instelling opgeven die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat je wilt bereiken, kun je een van deze instellingen gebruiken:

- `DoNotScale`

  Als je **NIET** wilt dat de objecten op de dia’s worden geschaald, gebruik dan deze instelling.

- `EnsureFit`

  Als je naar een kleinere dia‑grootte wilt schalen en je wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat je geen inhoud verliest), gebruik dan deze instelling.

- `Maximize`

  Als je naar een grotere dia‑grootte wilt schalen en je wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig worden met de nieuwe dia‑grootte, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe je de `Maximize`‑instelling gebruikt bij het wijzigen van de dia‑grootte van een presentatie:

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

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. Je kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste outputkwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en daarna dia’s uit presentaties met verschillende groottes samenvoegen?**

Je kunt geen presentaties [merge presentations](/slides/nl/androidjava/merge-presentation/) samenvoegen terwijl ze verschillende dia‑groottes hebben — pas eerst de grootte van één presentatie aan zodat deze overeenkomt met die van de andere. Bij het wijzigen van de dia‑grootte kun je kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/)‑optie. Na het uitlijnen van de groottes kun je dia’s samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [entire slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [selected shapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor consistente kadering en geometrie gewaarborgd zijn.
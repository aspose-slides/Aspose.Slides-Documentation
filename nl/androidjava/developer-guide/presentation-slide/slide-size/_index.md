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
description: "Snelle dia-grootte aanpassing in PPT, PPTX en ODP-bestanden met Java en Aspose.Slides voor Android, optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, cruciaal zowel voor afdrukken als voor weergave op het scherm.

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw gehele presentatie, omdat één diaformaat en beeldverhouding op alle dia's van toepassing is. Voor optimale resultaten stelt u de afmetingen van de dia's in het begin van het maakproces van uw presentatie in om complicaties te voorkomen.

{{% alert color="info" title="Note" %}}
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

Notitie‑ en hand‑outs‑pagina's hebben andere afmetingen dan reguliere dia's. Zie [Notes Page Size](/slides/nl/androidjava/notes-size/) om hun grootte en oriëntatie te wijzigen.

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie in Java wijzigt met Aspose.Slides:

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

Als u de gangbare diaformaten (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u besluiten een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent om volledige dia's van uw presentatie af te drukken op een aangepast paginavormaat of als u uw presentatie op bepaalde schermtypes wilt weergeven, dan heeft u waarschijnlijk voordeel bij een aangepaste formaatinstelling voor uw presentatie.

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor Android via Java gebruikt om een aangepast diaformaat voor een presentatie in Java op te geven:

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

## **Dia‑inhoud verwerken na herschalen**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast om het nieuwe diaformaat te passen. Bij het wijzigen van het diaformaat kunt u echter een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia's omgaat.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia's worden aangepast, gebruik dan deze instelling.

- `EnsureFit`

  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten op de dia's verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruik dan deze instelling.

- `Maximize`

  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten op de dia's vergroot zodat ze evenredig zijn aan het nieuwe diaformaat, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van het diaformaat van een presentatie:

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

**Kan ik een aangepast diaformaat instellen met eenheden anders dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugengebruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere rendering‑schaal leiden tot een hoger geheugengebruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de rendering‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia's samenvoegen uit presentaties die verschillende formaten hebben?**

U kunt niet [presentaties samenvoegen](/slides/nl/androidjava/merge-presentation/) terwijl ze verschillende diaformaten hebben — resize eerst één presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/)‑optie. Nadat de formaten zijn afgestemd, kunt u dia's samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en houden deze rekening met het nieuwe diaformaat?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia's](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente kadrering en geometrie wordt gegarandeerd.
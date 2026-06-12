---
title: Dia-grootte van de presentatie wijzigen in Java
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
descriptions: "Leer hoe u snel dia’s kunt aanpassen in PPT-, PPTX- en ODP-bestanden met Java en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat essentieel is voor zowel afdrukken als weergave op scherm.

Populaire diagroottes en verhoudingen:

- **Standaard (4:3‑verhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9‑verhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw presentatie; één dia‑grootte en beeldverhouding worden op alle dia’s toegepast. Voor optimale resultaten stelt u de afmetingen van de dia’s in aan het begin van het aanmaken van de presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de 4:3‑beeldverhouding.
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

## **Aangepaste diagroottes opgeven in presentaties**

Als de gangbare diagroottes (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u een specifieke of unieke dia‑grootte gebruiken. Bijvoorbeeld wanneer u volledige dia’s van uw presentatie wilt afdrukken op een aangepast paginaplan, of wanneer u de presentatie op bepaalde schermtypes wilt weergeven; dan profiteert u van een aangepaste grootte‑instelling voor uw presentatie.

Deze voorbeeldcode toont hoe u Aspose.Slides voor Java gebruikt om een aangepaste dia‑grootte voor een presentatie in Java op te geven:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papierformaat
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑inhoud afhandelen na grootte‑wijziging**

Nadat u de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast aan de nieuwe dia‑grootte. Wanneer u echter de dia‑grootte wijzigt, kunt u een instelling specificeren die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia’s.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- `DoNotScale`

  Als u NIET wilt dat de objecten op de dia’s worden geschaald, gebruikt u deze instelling.

- `EnsureFit`

  Als u naar een kleinere dia‑grootte wilt schalen en wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- `Maximize`

  Als u naar een grotere dia‑grootte wilt schalen en wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig blijven met de nieuwe dia‑grootte, gebruikt u deze instelling.

Deze voorbeeldcode laat zien hoe u de `Maximize`‑instelling gebruikt bij het wijzigen van de grootte van de dia’s in een presentatie:

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

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de geconverteerde waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

**Heeft een zeer grote aangepaste dia‑grootte invloed op de prestaties en het geheugenverbruik tijdens het renderen?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot meer geheugengebruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste output‑kwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia’s uit presentaties met verschillende groottes samenvoegen?**

U kunt geen presentaties [presentaties samenvoegen](/slides/nl/java/merge-presentation/) terwijl ze verschillende dia‑groottes hebben – schaal eerst één presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/)-optie. Nadat de groottes zijn afgestemd, kunt u dia’s samenvoegen met behoud van opmaak.

**Kan ik miniaturen genereren voor individuele vormen of specifieke regio’s van een dia, en respecteren deze de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [gehele dia’s](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-). De resulterende afbeeldingen reflecteren de huidige dia‑grootte en beeldverhouding, waardoor consistente framing en geometrie worden gegarandeerd.
---
title: Low-Code presentatietaken in Java
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/java/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in Java om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de grootte van de presentatie te verkleinen."
---
## **Overzicht**

Het [com.aspose.slides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/) package biedt statische hulpprogrammaclassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte object‑model‑werkstromen in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code‑helpers zijn het meest nuttig wanneer de bewerking van toepassing is op een volledig bestand of presentatie en de standaard workflow aan uw vereisten voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/java/com.aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia's, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Gebruik hiervoor |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstdelen. |
| [Collect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/) | Vormen uit de gehele presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het benodigde formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór het exporteren of een exportoptie moet configureren die niet door de gekozen helper wordt blootgesteld. Zie [Convert Presentation](/slides/nl/java/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) om volledige presentatiesbestanden met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's aan één resultaat moeten worden toegevoegd zonder ze individueel te selecteren of te remappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's moet samenvoegen, een bestemmings‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden of verschillende dia‑groottes wilt afstemmen. Zie [Merge Presentations](/slides/nl/java/merge-presentation/) voor die scenario's.

## **Itereren door presentatieslementen**

De [ForEach](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/)‑klasse roept een callback aan voor elk aangevraagd type presentatieslement. Het voorkomt geneste verzamelings‑lussen en is handig voor inspectie of opmaakwijzigingen over de hele presentatie.

Het volgende voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), en [ForEach.portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) om de overeenkomstige elementen te inspecteren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Standaard omvat het doorlopen van vormen en tekst over de hele presentatie normale, master‑ en lay‑out‑dia's. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia's verwerken. Gebruik directe verzamelings‑lussen wanneer de volgorde van doorlopen, vroegtijdig stoppen, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is handig wanneer dezelfde set meerdere keren gefilterd, geteld of verwerkt zal worden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Gebruik in plaats daarvan [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) wanneer elke vorm meteen kan worden afgehandeld en u het verzamelde resultaat niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) verwijdert lay‑out‑dia's die door geen normale dia worden gerefereerd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwijdert master‑dia's die niet langer worden gebruikt.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opschonen van lay‑outs niet meer wordt gerefereerd ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, lay‑outs of de volledige ingesloten lettertype‑gegevens nodig zou kunnen hebben. Voor meer details, zie [Slide Master](/slides/nl/java/slide-master/) en [Embedded Font](/slides/nl/java/embedded-font/).

## **Veelgestelde vragen**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code‑helpers wanneer een standaardbewerk ingaat op een compleet bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia's moet selecteren, de relaties tussen masters en lay‑outs moet beheren, een tussentijdse toestand moet inspecteren, of gedrag moet configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vereist invoerpresentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notitiedia's?**

[ForEach.slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) doorloopt normale presentatiedia's. [ForEach.shape], [ForEach.paragraph] en [ForEach.portion] over de hele presentatie omvatten standaard normale, master‑ en lay‑out‑dia's. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia's mee te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) om elke vorm meteen via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een doorloopbaar resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd de presentatiedatei kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, hoeven de betreffende [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑operaties het bestand niet kleiner te maken.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/)‑callback of [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/) hebt uitgevoerd, roept u [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/slides/nl/java/convert-presentation/)
- [Merge Presentations](/slides/nl/java/merge-presentation/)
- [Slide Master](/slides/nl/java/slide-master/)
- [Manage Text Box](/slides/nl/java/manage-textbox/)
- [Embedded Font](/slides/nl/java/embedded-font/)
---
title: Low-Code Presentatiebewerkingen in Java
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
- ongebruikte masters dia's verwijderen
- ongebruikte lay-out dia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in Java om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

Het [com.aspose.slides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/)‑pakket biedt statische hulpprogrammaclassen voor veelvoorkomende presentatiebewerkingen. Deze helpers verpakken vaak gebruikte object‑model‑werkstromen in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code‑helpers zijn het meest nuttig wanneer de bewerking wordt toegepast op een volledig bestand of presentatie en de standaard‑workflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides‑objectmodel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/) | Een presentatie omzetten naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/) | Vormen uit de volledige presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑data reduceren. |

## **Presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het benodigde formaat op basis van het uitvoerpad en schrijft het resultaat.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑output. Gebruik het volledige objectmodel wanneer u de presentatie moet controleren of wijzigen vóór export of een exportoptie moet configureren die door de geselecteerde helper niet wordt aangeboden. Zie [Convert Presentation](/java/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) om volledige presentatiebestanden met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's wilt samenvoegen, een bestemmings‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes wilt harmoniseren. Zie [Merge Presentations](/java/merge-presentation/) voor die scenario's.

## **Itereren door presentatie‑elementen**

De [ForEach](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/)‑klasse roept een callback aan voor elk aangevraagd type presentatiedeel. Het voorkomt geneste verzamelingslussen en is handig voor controle of opmaakwijzigingen over de gehele presentatie.

Het volgende voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) en [ForEach.portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) om de bijbehorende elementen te inspecteren:

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

Standaard omvat traverseren van vormen en tekst over de gehele presentatie normale, master‑ en lay‑out‑dia's. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia's verwerken. Gebruik directe verzamelingslussen wanneer de volgorde van traverseren, vroegtijdige exit, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is handig wanneer dezelfde set meer dan één keer wordt gefilterd, geteld of verwerkt.

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

Gebruik in plaats daarvan [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) wanneer elke vorm direct kan worden verwerkt en u het verzamelde resultaat niet hoeft te bewaren.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑data verminderen:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) verwijdert lay‑out‑dia’s die door geen normale dia worden gebruikt.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwijdert master‑dia’s die niet meer worden gebruikt.
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

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opruimen van lay‑outs niet meer wordt gerefereerd ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de oorspronkelijke masters, lay‑outs of volledige ingesloten lettertype‑data nodig heeft. Zie voor meer details [Slide Master](/java/slide-master/) en [Embedded Font](/java/embedded-font/).

## **Veelgestelde vragen**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code‑helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of een complete presentatie en er geen gedetailleerde controle over individuele elementen nodig is. Gebruik het volledige objectmodel wanneer u specifieke dia's moet selecteren, relaties tussen masters en lay‑outs moet beheersen, de tussentijdse staat moet inspecteren of gedrag moet configureren dat de helper niet biedt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vereist dat de invoer‑presentaties hetzelfde formaat hebben. Converteer eerst de invoerbestanden naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notitiedia's?**

[ForEach.slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) doorloopt normale presentatiedia's. [ForEach.shape], [ForEach.paragraph] en [ForEach.portion] over de gehele presentatie omvatten standaard normale, master‑ en lay‑out‑dia's. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia's op te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) om elke vorm direct via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een doorloopbaar resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatiedocument kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze elementen aanwezig zijn, zullen de betreffende [Compress]-operaties mogelijk de bestandsgrootte niet verkleinen.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation]-object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach]-callback of [Compress] hebt uitgevoerd, roept u [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)
---
title: Low-Code presentatiewerkzaamheden op Android
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/androidjava/low-code-presentation-operations/
keywords:
- low-code presentatiewerk API
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
- Android
- Java
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API op Android om presentaties te converteren en samen te voegen, door content te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

Het [com.aspose.slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) pakket biedt statische helperklassen voor veelvoorkomende presentatie‑bewerkingen. Deze helpers verpakken vaak gebruikte object‑modelworkflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code‑helpers zijn het meest bruikbaar wanneer de bewerking van toepassing is op een heel bestand of een hele presentatie en de standaardworkflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) wanneer u fijne controle nodig heeft over individuele dia's, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Doel |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/) | Een presentatie naar een ander formaat converteren met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstdeler. |
| [Collect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/collect/) | Vormen ophalen uit de gehele presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Converteer een presentatie**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) wanneer de bestandsextensie van de uitvoer voldoende is om het exportformaat te selecteren. De methode opent de bronpresentatie, bepaalt het vereiste formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/) klasse biedt ook specifieke methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑output. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of aanpassen vóór export of een exportoptie moet configureren die niet door de geselecteerde helper wordt blootgesteld. Zie [Presentatie converteren](/androidjava/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) om volledige presentatiebestanden met één oproep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's moet samenvoegen, een bestemmings‑master of -lay‑out moet toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes wilt harmoniseren. Zie [Presentaties samenvoegen](/androidjava/merge-presentation/) voor die scenario's.

## **Itereer door presentatie‑elementen**

De [ForEach](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/) klasse roept een callback aan voor elk aangevraagd type presentatie‑element. Het voorkomt geneste verzamelingslussen en is handig voor inspectie of opmaakwijzigingen over de gehele presentatie.

Het onderstaande voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), en [ForEach.portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) om de overeenkomstige elementen te inspecteren:

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

Standaard omvat de vorm‑ en tekstdoorloop over de gehele presentatie normale, master‑ en lay‑out‑dia's. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia's verwerken. Gebruik directe verzamelingslussen wanneer de doorloopvolgorde, vroegtijdig stoppen, filteren vóór de callback‑aanroep, of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Verzamel vormen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een collectie van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set meerdere keren gefilterd, geteld of verwerkt zal worden.

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

Gebruik in plaats daarvan [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) wanneer elke vorm direct kan worden verwerkt en u het verzamelde resultaat niet hoeft te behouden.

## **Comprimeer presentatiew inhoud**

De [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) verwijdert lay‑out‑dia's die door geen enkele normale dia worden gebruikt.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwijdert masters die niet meer worden gebruikt.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) verwijdert ongebruikte tekens uit ingesloten lettertypen.

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

Verwijder eerst ongebruikte lay-outs voordat u ongebruikte masters verwijdert, zodat een master die na het opruimen van lay-outs niet meer wordt gerefereerd ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de oorspronkelijke masters, lay-outs of de volledige ingesloten lettertype‑gegevens nodig heeft. Zie voor meer details [Slide Master](/androidjava/slide-master/) en [Embedded Font](/androidjava/embedded-font/).

## **FAQ**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code‑helpers wanneer een standaardbewerking van toepassing is op een volledig bestand of een hele presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia's moet selecteren, master‑ en lay‑outrelaties moet beheersen, de tussenliggende status moet inspecteren, of gedrag moet configureren dat de helper niet biedt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vereist dat invoer‑presentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), en voeg daarna de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notitiedia's?**

[ForEach.slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) doorloopt de normale presentatiedia's. Presentatie‑brede [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), en [ForEach.portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operaties omvatten standaard normale, master‑ en lay‑out‑dia's. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia's op te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) om elke vorm direct via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een iterabel resultaat nodig hebt dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatiebestand kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay-outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de bijbehorende [Compress]‑operaties mogelijk de bestandsgrootte niet verkleinen.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation]‑object in het geheugen. Nadat u elementen in een [ForEach]‑callback hebt gewijzigd of [Compress] hebt uitgevoerd, roept u [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/androidjava/convert-presentation/)
- [Presentaties samenvoegen](/androidjava/merge-presentation/)
- [Dia master](/androidjava/slide-master/)
- [Tekstvak beheren](/androidjava/manage-textbox/)
- [Ingesloten lettertype](/androidjava/embedded-font/)
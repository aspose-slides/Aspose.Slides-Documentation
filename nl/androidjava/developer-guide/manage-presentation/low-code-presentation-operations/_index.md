---
title: Low-Code presentatietaken op Android
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/androidjava/low-code-presentation-operations/
keywords:
- low-code presentatiewerkset API
- presentatie converteren
- presentaties samenvoegen
- "dia's itereren"
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- "onbruikte masterdia's verwijderen"
- "onbruikte lay-outdia's verwijderen"
- ingebedde lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API op Android om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

Het [com.aspose.slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) pakket levert statische hulpprogrammaklassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte objectmodel‑workflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, shapes kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low-code helpers zijn vooral handig wanneer de bewerking wordt toegepast op een volledig bestand of een volledige presentatie en de standaardworkflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) wanneer u fijne controle nodig heeft over individuele dia's, masters, lay‑outs, shapes, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Toepassing |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe file‑to‑file‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, shape, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/collect/) | Shapes ophalen uit de volledige presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingebedde lettertype‑data verkleinen. |

## **Presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te selecteren. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert]‑klasse biedt ook specifieke methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑output. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór export of een exportoptie moet configureren die niet door de geselecteerde helper wordt blootgesteld. Zie [Convert Presentation](/slides/nl/androidjava/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) om volledige presentatiebestanden met één aanroep samen te voegen. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of te remappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's moet samenvoegen, een doel‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden, of verschillende diaformaten wilt harmoniseren. Zie [Merge Presentations](/slides/nl/androidjava/merge-presentation/) voor die scenario's.

## **Itereren door presentatie‑elementen**

De [ForEach]‑klasse roept een callback aan voor elk aangevraagd type presentatie‑element. Het voorkomt geneste verzamelings‑lussen en is handig voor inspectie of opmaakwijzigingen op presentatie‑niveau.

Het volgende voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), en [ForEach.portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) om de overeenkomstige elementen te inspecteren:

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

Standaard omvat traverseren van shapes en tekst over de hele presentatie normale, master‑ en lay‑out‑dia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe collectielussen wanneer de volgorde van traverseren, vroegtijdig stoppen, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Shapes verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) wanneer u een verzameling van alle shapes in een presentatie nodig heeft in plaats van een callback voor elke shape. Dit is handig wanneer dezelfde set later gefilterd, geteld of meermaals verwerkt moet worden.

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

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) in plaats daarvan wanneer elke shape onmiddellijk kan worden verwerkt en u de verzamelde resultaten niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De [Compress]‑klasse kan ongebruikte structurele elementen verwijderen en de ingebedde lettertype‑data verkleinen:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) verwijdert lay‑out‑dia’s die door geen enkele normale dia worden gerefereerd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwijdert master‑dia’s die niet meer worden gebruikt.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) verwijdert ongebruikte tekens uit ingebedde lettertypen.

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

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opschonen van lay‑outs niet meer wordt gerefereerd, ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, lay‑outs of volledige ingebedde lettertype‑data nodig heeft. Voor meer details, zie [Slide Master](/slides/nl/androidjava/slide-master/) en [Embedded Font](/slides/nl/androidjava/embedded-font/).

## **FAQ**

**Wanneer moet ik de low-code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking wordt toegepast op een volledig bestand of een volledige presentatie en geen gedetailleerde controle over individuele elementen vereist is. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, relaties tussen master en lay‑out moet beheersen, de intermediaire status wilt inspecteren, of gedrag wilt configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process] vereist invoerpresentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master-, lay‑out- en notitiedia’s?**

[ForEach.slide] doorloopt normale presentatiedia’s. Door de hele presentatie heen omvatten [ForEach.shape], [ForEach.paragraph] en [ForEach.portion] standaard normale, master‑ en lay‑out‑dia’s. Gebruik de overloads met `includeNotes` ingesteld op `true` om notitiedia’s mee te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape] om elke shape onmiddellijk via een callback te verwerken. Gebruik [Collect.shapes] wanneer u een itereerbaar resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Vermindert Compress altijd de bestandsgrootte van de presentatie?**

Niet noodzakelijk. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingebedde lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, kunnen de bijbehorende [Compress]‑operaties de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation]‑object in het geheugen. Na het wijzigen van elementen in een [ForEach]‑callback of het uitvoeren van [Compress], roep [Presentation.save] aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/slides/nl/androidjava/convert-presentation/)
- [Presentaties samenvoegen](/slides/nl/androidjava/merge-presentation/)
- [Dia‑master](/slides/nl/androidjava/slide-master/)
- [Tekstvak beheren](/slides/nl/androidjava/manage-textbox/)
- [Ingebed lettertype](/slides/nl/androidjava/embedded-font/)
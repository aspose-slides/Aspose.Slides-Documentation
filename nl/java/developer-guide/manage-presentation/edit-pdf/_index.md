---
title: PDF-documenten bewerken in Java
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/java/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- Java
- Aspose.Slides
description: "PDF-documenten bewerken in Java door ze te importeren in Aspose.Slides, tekst te vervangen en de aangepaste presentatie terug naar PDF op te slaan."
---
## **Overzicht**

Aspose.Slides for Java stelt u in staat om PDF‑inhoud te bewerken door de pagina’s te importeren als dia’s, de presentatie aan te passen en deze weer naar PDF te exporteren. Dit artikel laat een eenvoudige tekstvervanging zien. De presentatie blijft in het geheugen, dus het opslaan van een tussen‑PPTX‑bestand is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [addFromPdf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) om de pagina’s te importeren, [replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) om de tekst bij te werken, en [save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) om het resultaat te exporteren.

Het onderstaande voorbeeld gaat ervan uit dat `input.pdf` het woord "Draft" bevat als bewerkbare tekst na import. Het vervangt dat woord door "Final" en schrijft `edited.pdf`. Het wissen van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. Het zoeken komt overeen met volledige woorden met dezelfde hoofdlettergevoeligheid; `null` betekent dat er geen result‑callback nodig is.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/java/search-and-replace-text/) en [PowerPoint naar PDF converteren](/slides/nl/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst binnen gescande afbeeldingen. De conversie kan de lay‑out en opmaak beïnvloeden, dus controleer de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.
{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als u deze ook wilt blijven bewerken in PowerPoint; zie [Presentaties opslaan](/slides/nl/java/save-presentation/).

**Waarom blijft sommige tekst onveranderd?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die als afbeelding is geïmporteerd of verdeeld over afzonderlijke tekstvakken, zal niet noodzakelijkerwijs overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.
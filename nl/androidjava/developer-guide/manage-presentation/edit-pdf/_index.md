---
title: PDF‑documenten bewerken op Android
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/androidjava/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- Android
- Java
- Aspose.Slides
description: "Bewerk PDF‑documenten op Android met Java door ze te importeren in Aspose.Slides, de tekst te vervangen en de aangepaste presentatie weer op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat PDF‑inhoud te bewerken door de pagina’s te importeren als dia’s, de presentatie aan te passen en deze weer als PDF te exporteren. Dit artikel toont een eenvoudige tekstvervanging. De presentatie blijft in het geheugen, dus het opslaan van een tussentijdse PPTX‑file is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [addFromPdf](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) om de pagina’s te importeren, [replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) om de tekst bij te werken en [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) om het resultaat te exporteren.

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

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/androidjava/search-and-replace-text/) en [PowerPoint converteren naar PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst binnen gescande afbeeldingen. De conversie kan de lay‑out en opmaak beïnvloeden, dus controleer het resultaat, vooral wanneer de vervangende tekst langer is dan het origineel.
{{% /alert %}}

## **Veelgestelde vragen**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als u deze later in PowerPoint wilt blijven bewerken; zie [Presentaties opslaan](/slides/nl/androidjava/save-presentation/).

**Waarom kan sommige tekst onveranderd blijven?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die als afbeelding is geïmporteerd of verspreid over aparte tekstkaders, komt mogelijk niet overeen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.
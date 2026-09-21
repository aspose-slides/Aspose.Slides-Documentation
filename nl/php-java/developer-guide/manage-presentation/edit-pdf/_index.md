---
title: PDF-documenten bewerken in PHP
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/php-java/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- PHP
- Aspose.Slides
description: "Bewerk PDF-documenten in PHP door ze te importeren in Aspose.Slides, tekst te vervangen en de aangepaste presentatie terug op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt u in staat om PDF‑inhoud te bewerken door de pagina's te importeren als dia's, de presentatie aan te passen en deze terug te exporteren naar PDF. Dit artikel toont een eenvoudige tekstvervanging. De presentatie blijft in het geheugen, dus het opslaan van een tussentijdse PPTX‑bestand is optioneel.

## **Vervang tekst in een PDF**

Gebruik [SlideCollection::addFromPdf](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/#addFromPdf) om de pagina's te importeren, [Presentation::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceText) om de tekst bij te werken, en [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) om het resultaat te exporteren.

In het volgende voorbeeld wordt verwacht dat `input.pdf` het woord "Draft" bevat als bewerkbare tekst na import. Het vervangt dat woord door "Final" en schrijft `edited.pdf`. Het wissen van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. Het zoeken komt overeen met volledige woorden met dezelfde hoofdlettergevoeligheid; `null` betekent dat er geen resultaatcallback nodig is.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/php-java/search-and-replace-text/) en [PowerPoint naar PDF converteren](/slides/nl/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst in gescande afbeeldingen. De conversie kan de lay‑out en opmaak beïnvloeden, dus controleer de output, vooral wanneer de vervangende tekst langer is dan de originele.
{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als u deze ook in PowerPoint wilt blijven bewerken; zie [Presentaties opslaan](/slides/nl/php-java/save-presentation/).

**Waarom blijft bepaalde tekst onveranderd?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die is geïmporteerd als afbeelding of verdeeld over afzonderlijke tekstframes zal niet noodzakelijkerwijs overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.
---
title: Redigera PDF-dokument i PHP
linktitle: Redigera PDF
type: docs
weight: 65
url: /sv/php-java/edit-pdf/
keywords:
- redigera PDF
- ersätta PDF-text
- PDF till PPTX
- PPTX till PDF
- PHP
- Aspose.Slides
description: "Redigera PDF-dokument i PHP genom att importera dem till Aspose.Slides, ersätta text och spara den modifierade presentationen tillbaka som PDF."
---
## **Översikt**

Aspose.Slides for PHP via Java låter dig redigera PDF-innehåll genom att importera dess sidor som bilder, modifiera presentationen och exportera den tillbaka till PDF. Den här artikeln visar ett enkelt textbyte. Presentationen finns i minnet, så det är valfritt att spara en mellanliggande PPTX‑fil.

## **Ersätt text i en PDF**

Använd [SlideCollection::addFromPdf](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/#addFromPdf) för att importera sidorna, [Presentation::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceText) för att uppdatera texten och [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att exportera resultatet.

Följande exempel förutsätter att `input.pdf` innehåller ordet "Draft" som redigerbar text efter import. Det ersätter det ordet med "Final" och skriver `edited.pdf`. Att rensa den ursprungliga bilden innan import förhindrar en extra tom sida i resultatet. Sökningen matchar hela ord med samma skiftläge; `null` betyder att ingen resultat‑callback behövs.

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

För fler alternativ, se [Sök och ersätt text](/slides/sv/php-java/search-and-replace-text/) och [Konvertera PowerPoint till PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Textbyte fungerar på importerad text, inte på text i skannade bilder. Konverteringen kan påverka layout och formatering, så granska resultatet, särskilt när den ersatta texten är längre än originalet.
{{% /alert %}}

## **Vanliga frågor**

**Behöver jag spara en PPTX‑fil innan jag exporterar PDF‑filen?**

Nej. Du kan redigera och exportera samma presentation i minnet. Spara en PPTX‑kopia endast om du också vill fortsätta redigera den i PowerPoint; se [Spara presentationer](/slides/sv/php-java/save-presentation/).

**Varför kan vissa texter förbli oförändrade?**

Exemplet matchar hela ordet "Draft" med exakt skiftläge. Text som importeras som en bild eller som är uppdelad i separata textramar kommer inte nödvändigtvis att matcha sökningen. Kontrollera det importerade innehållet och justera sökningen för ditt dokument.
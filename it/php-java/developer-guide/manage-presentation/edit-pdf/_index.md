---
title: Modifica documenti PDF in PHP
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/php-java/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF a PPTX
- PPTX a PDF
- PHP
- Aspose.Slides
description: "Modifica documenti PDF in PHP importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides for PHP via Java consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione ed esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è opzionale.

## **Sostituire testo in un PDF**

Usa [SlideCollection::addFromPdf](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/#addFromPdf) per importare le pagine, [Presentation::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceText) per aggiornare il testo e [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per esportare il risultato.

L'esempio seguente si aspetta che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce quella parola con "Final" e scrive `edited.pdf`. Pulire la diapositiva iniziale prima dell'importazione evita una pagina vuota extra nell'output. La ricerca corrisponde alle parole intere con la stessa distinzione tra maiuscole e minuscole; `null` indica che non è necessario un callback di risultato.

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

Per ulteriori opzioni, vedi [Cerca e sostituisci testo](/slides/it/php-java/search-and-replace-text/) e [Converti PowerPoint in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
La sostituzione del testo funziona sul testo importato, non sul testo all'interno di immagini scannerizzate. La conversione può influire sul layout e sulla formattazione, quindi verifica l'output, specialmente quando il testo sostituito è più lungo dell'originale.
{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; vedi [Salva presentazioni](/slides/it/php-java/save-presentation/).

**Perché potrebbe rimanere del testo invariato?**

L'esempio corrisponde alla parola intera "Draft" con distinzione precisa tra maiuscole e minuscole. Il testo importato come immagine o suddiviso in più riquadri di testo potrebbe non corrispondere alla ricerca. Controlla il contenuto importato e adatta la ricerca al tuo documento.
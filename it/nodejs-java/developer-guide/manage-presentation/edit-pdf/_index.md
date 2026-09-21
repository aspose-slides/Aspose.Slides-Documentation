---
title: Modifica documenti PDF in JavaScript
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/nodejs-java/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF a PPTX
- PPTX a PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Modifica i documenti PDF in JavaScript importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides for Node.js via Java consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione ed esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è facoltativo.

## **Sostituire testo in un PDF**

Utilizza [addFromPdf](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addFromPdf) per importare le pagine, [replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceText) per aggiornare il testo e [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per esportare il risultato.

L'esempio seguente presuppone che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce quella parola con "Final" e scrive `edited.pdf`. Cancellare la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con la stessa combinazione di maiuscole/minuscole; `null` indica che non è necessaria alcuna callback di risultato.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Per ulteriori opzioni, vedere [Cerca e sostituisci testo](/slides/it/nodejs-java/search-and-replace-text/) e [Converti PowerPoint in PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
La sostituzione del testo funziona sul testo importato, non sul testo contenuto in immagini scansionate. La conversione può influire sul layout e sulla formattazione, quindi controlla l'output, soprattutto quando il testo di sostituzione è più lungo dell'originale.
{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. È possibile modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; vedi [Salva presentazioni](/slides/it/nodejs-java/save-presentation/).

**Perché potrebbe rimanere del testo invariato?**

L'esempio corrisponde all'intera parola "Draft" con esatta combinazione di maiuscole/minuscole. Il testo importato come immagine o diviso in più riquadri di testo non corrisponderà necessariamente alla ricerca. Verifica il contenuto importato e adatta la ricerca per il tuo documento.
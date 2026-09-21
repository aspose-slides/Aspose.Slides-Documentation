---
title: Modifica documenti PDF in Java
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/java/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF in PPTX
- PPTX in PDF
- Java
- Aspose.Slides
description: "Modifica i documenti PDF in Java importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides per Java consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione ed esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è facoltativo.

## **Sostituire il testo in un PDF**

Utilizza [addFromPdf](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) per importare le pagine, [replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per aggiornare il testo e [save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) per esportare il risultato.

L'esempio seguente si aspetta che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce tale parola con "Final" e scrive `edited.pdf`. Cancellare la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con la stessa capitalizzazione; `null` indica che non è necessario alcun callback di risultato.

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

Per ulteriori opzioni, consulta [Ricerca e sostituzione del testo](/slides/it/java/search-and-replace-text/) e [Converti PowerPoint in PDF](/slides/it/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
La sostituzione del testo funziona sul testo importato, non sul testo all'interno di immagini scannerizzate. La conversione può influire sul layout e sulla formattazione, quindi controlla l'output, soprattutto quando il testo di sostituzione è più lungo di quello originale.
{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; consulta [Salva presentazioni](/slides/it/java/save-presentation/).

**Perché potrebbe rimanere del testo invariato?**

L'esempio corrisponde alla parola intera "Draft" con caso esatto. Il testo importato come immagine o suddiviso in più riquadri di testo non corrisponderà necessariamente alla ricerca. Controlla il contenuto importato e adatta la ricerca per il tuo documento.
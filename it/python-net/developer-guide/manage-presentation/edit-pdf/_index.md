---
title: Modifica documenti PDF in Python
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/python-net/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF a PPTX
- PPTX a PDF
- Python
- Aspose.Slides
description: "Modifica documenti PDF in Python importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides for Python via .NET ti permette di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione e quindi esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è facoltativo.

## **Sostituire il testo in un PDF**

Usa [add_from_pdf](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_from_pdf/) per importare le pagine, [replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_text/) per aggiornare il testo e [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per esportare il risultato.

L'esempio seguente presuppone che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce quella parola con "Final" e scrive `edited.pdf`. Pulire la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con la stessa capitalizzazione; `None` indica che non è necessario un callback di risultato.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Per ulteriori opzioni, vedi [Search and Replace Text](/slides/it/python-net/search-and-replace-text/) e [Convert PowerPoint to PDF](/slides/it/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

La sostituzione del testo funziona sul testo importato, non sul testo all'interno di immagini scansionate. La conversione può influire sul layout e sulla formattazione, quindi rivedi l'output, specialmente quando il testo di sostituzione è più lungo dell'originale.

{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; vedi [Save Presentations](/slides/it/python-net/save-presentation/).

**Perché parte del testo potrebbe rimanere invariato?**

L'esempio corrisponde alla parola intera "Draft" con la stessa capitalizzazione. Il testo importato come immagine o suddiviso in più caselle di testo non corrisponderà necessariamente alla ricerca. Controlla il contenuto importato e adatta la ricerca per il tuo documento.
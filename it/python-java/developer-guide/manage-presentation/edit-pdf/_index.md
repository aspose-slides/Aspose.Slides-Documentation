---
title: Modifica documenti PDF in Python via Java
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/python-java/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF in PPTX
- PPTX in PDF
- Python
- Java
- Aspose.Slides
description: "Modifica i documenti PDF in Python via Java importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides for Python via Java consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione e esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è facoltativo.

## **Sostituire il testo in un PDF**

Usa [addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromPdf) per importare le pagine, [replaceText](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#replaceText) per aggiornare il testo e [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per esportare il risultato.

L'esempio seguente presuppone che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce tale parola con "Final" e scrive `edited.pdf`. Pulire la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con la stessa capitalizzazione; `None` indica che non è necessario un callback di risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Per ulteriori opzioni, vedi [Cerca e sostituisci testo](/slides/it/python-java/search-and-replace-text/) e [Converti PowerPoint in PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
La sostituzione del testo funziona sul testo importato, non sul testo contenuto in immagini scannerizzate. La conversione può influire su layout e formattazione, quindi è consigliabile verificare l'output, specialmente quando il testo di sostituzione è più lungo dell'originale.
{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; vedi [Salva presentazioni](/slides/it/python-java/save-presentation/).

**Perché potrebbe del testo rimanere invariato?**

L'esempio corrisponde alla parola intera "Draft" con esatta maiuscola/minuscola. Il testo importato come immagine o diviso in più riquadri di testo non corrisponderà necessariamente alla ricerca. Controlla il contenuto importato e adatta la ricerca al tuo documento.
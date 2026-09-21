---
title: Modifica documenti PDF in .NET
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/net/edit-pdf/
keywords:
- Modifica PDF
- Sostituisci testo PDF
- PDF in PPTX
- PPTX in PDF
- .NET
- C#
- Aspose.Slides
description: "Modifica documenti PDF in C# importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides per .NET consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione ed esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi il salvataggio di un file PPTX intermedio è opzionale.

## **Sostituire il testo in un PDF**

Usa AddFromPdf per importare le pagine, ReplaceText per aggiornare il testo e Save per esportare il risultato.

L'esempio seguente presuppone che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce quella parola con "Final" e scrive `edited.pdf`. Cancellare la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con lo stesso caso di lettere; `null` indica che non è necessario un callback di risultato.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Per ulteriori opzioni, consulta [Ricerca e sostituzione del testo](/slides/it/net/search-and-replace-text/) e [Converti PowerPoint in PDF](/slides/it/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

La sostituzione del testo funziona sul testo importato, non sul testo presente nelle immagini scansionate. La conversione può influire sul layout e sulla formattazione, quindi verifica l'output, soprattutto quando il testo di sostituzione è più lungo dell'originale.

{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; consulta [Salva presentazioni](/slides/it/net/save-presentation/).

**Perché potrebbe rimanere del testo invariato?**

L'esempio corrisponde all'intera parola "Draft" con caso esatto. Il testo importato come immagine o suddiviso in più caselle di testo potrebbe non corrispondere alla ricerca. Controlla il contenuto importato e adatta la ricerca al tuo documento.
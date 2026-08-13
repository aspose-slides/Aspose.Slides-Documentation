---
title: Converti le presentazioni PowerPoint in documenti Word in .NET
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /it/net/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint a Word
- presentazione a Word
- diapositiva a Word
- PPT a Word
- PPTX a Word
- PowerPoint a DOCX
- presentazione a DOCX
- diapositiva a DOCX
- PPT a DOCX
- PPTX a DOCX
- PowerPoint a DOC
- presentazione a DOC
- diapositiva a DOC
- PPT a DOC
- PPTX a DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint PPT e PPTX in documenti Word modificabili in C# usando Aspose.Slides per .NET con layout preciso, immagini e formattazione preservati."
---
## **Panoramica**

Questo articolo fornisce una soluzione per gli sviluppatori per convertire presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides per .NET e Aspose.Words per .NET. La guida passo‑passo ti accompagna attraverso ogni fase del processo di conversione.

## **Convertire una presentazione in un documento Word**

Segui le istruzioni seguenti per convertire una presentazione PowerPoint o OpenDocument in un documento Word:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e caricare un file di presentazione.
2. Istanziare le classi [Document](https://reference.aspose.com/words/net/aspose.words/document/) e [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) per generare un documento Word.
3. Impostare le dimensioni della pagina del documento Word in modo che corrispondano a quelle della presentazione utilizzando la proprietà [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Impostare i margini nel documento Word utilizzando la proprietà [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Scorrere tutte le diapositive della presentazione utilizzando la proprietà [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/).
    - Generare un'immagine della diapositiva usando il metodo `GetImage` dell'interfaccia [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) e salvarla in un memory stream.
    - Aggiungere l'immagine della diapositiva al documento Word usando il metodo `InsertImage` della classe [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Salvare il documento Word in un file.

Supponiamo di avere una presentazione "sample.pptx" che appare così:

![Presentazione PowerPoint](PowerPoint.png)

Il seguente esempio di codice C# dimostra come convertire la presentazione PowerPoint in un documento Word:

```cs
using Aspose.Slides;
using Aspose.Words;

// Carica un file di presentazione.
using var presentation = new Presentation("sample.pptx");

// Crea gli oggetti Document e DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Imposta le dimensioni della pagina nel documento Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Imposta i margini nel documento Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Scorri tutte le diapositive della presentazione.
foreach (var slide in presentation.Slides)
{
    // Genera un'immagine della diapositiva e salvala in un memory stream.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Aggiungi l'immagine della diapositiva al documento Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Salva il documento Word in un file.
document.Save("output.docx");
```

Il risultato:

![Documento Word](Word.png)

{{% alert color="info" %}} 

Prova il nostro [**Convertitore online da PPT a Word**](https://products.aspose.app/slides/it/conversion/ppt-to-word) per vedere cosa puoi ottenere convertendo presentazioni PowerPoint e OpenDocument in documenti Word. 

{{% /alert %}}

## **FAQ**

### Quali componenti devono essere installati per convertire presentazioni PowerPoint e OpenDocument in documenti Word?

È sufficiente aggiungere i corrispondenti pacchetti NuGet per [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) e [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) al tuo progetto C#. Entrambe le librerie funzionano come API autonome e non è necessario avere Microsoft Office installato.

### Tutti i formati di presentazione PowerPoint e OpenDocument sono supportati?

Aspose.Slides per .NET [supporta tutti i formati di presentazione](/slides/it/net/supported-file-formats/), inclusi PPT, PPTX, ODP e altri tipi di file comuni. Questo garantisce che tu possa lavorare con presentazioni create in varie versioni di Microsoft PowerPoint.
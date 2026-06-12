---
title: Converti le presentazioni PowerPoint in documenti Word in .NET
linktitle: PowerPoint in Word
type: docs
weight: 110
url: /it/net/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in Word
- presentazione in Word
- diapositiva in Word
- PPT in Word
- PPTX in Word
- PowerPoint in DOCX
- presentazione in DOCX
- diapositiva in DOCX
- PPT in DOCX
- PPTX in DOCX
- PowerPoint in DOC
- presentazione in DOC
- diapositiva in DOC
- PPT in DOC
- PPTX in DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint PPT e PPTX in documenti Word modificabili in C# utilizzando Aspose.Slides per .NET mantenendo intatti layout, immagini e formattazione."
---
## **Panoramica**

Questo articolo fornisce una soluzione per gli sviluppatori sulla conversione di presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides per .NET e Aspose.Words per .NET. La guida passo passo ti accompagna in ogni fase del processo di conversione.

## **Convertire una presentazione in un documento Word**

Segui le istruzioni seguenti per convertire una presentazione PowerPoint o OpenDocument in un documento Word:

1. Instanziare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e caricare un file di presentazione.  
2. Instanziare le classi [Document](https://reference.aspose.com/words/net/aspose.words/document/) e [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) per generare un documento Word.  
3. Impostare la dimensione della pagina del documento Word per farla corrispondere a quella della presentazione usando la proprietà [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
4. Impostare i margini nel documento Word usando la proprietà [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
5. Scorrere tutte le diapositive della presentazione usando la proprietà [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/).  
    - Generare un’immagine della diapositiva usando il metodo `GetImage` dell’interfaccia [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) e salvarla in un flusso di memoria.  
    - Aggiungere l’immagine della diapositiva al documento Word usando il metodo `InsertImage` della classe [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) .  
6. Salvare il documento Word su file.

Supponiamo di avere una presentazione "sample.pptx" che appare così:

![Presentazione PowerPoint](PowerPoint.png)

Il seguente esempio di codice C# dimostra come convertire la presentazione PowerPoint in un documento Word:

```cs
// Carica un file di presentazione.
using var presentation = new Presentation("sample.pptx");

// Crea gli oggetti Document e DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Imposta la dimensione della pagina nel documento Word.
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
    // Genera un'immagine della diapositiva e salvala in un flusso di memoria.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Aggiungi l'immagine della diapositiva al documento Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Salva il documento Word su un file.
document.Save("output.docx");
```

Il risultato:

![Documento Word](Word.png)

{{% alert color="primary" %}} 

Prova il nostro [**Convertitore PPT in Word online**](https://products.aspose.app/slides/it/conversion/ppt-to-word) per vedere cosa potresti ottenere convertendo presentazioni PowerPoint e OpenDocument in documenti Word. 

{{% /alert %}}

## **FAQ**

**Quali componenti devono essere installati per convertire presentazioni PowerPoint e OpenDocument in documenti Word?**

È sufficiente aggiungere i rispettivi pacchetti NuGet per [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) e [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) al tuo progetto C#. Entrambe le librerie funzionano come API autonome e non è necessario avere Microsoft Office installato.

**Sono supportati tutti i formati di presentazione PowerPoint e OpenDocument?**

Aspose.Slides for .NET [supporta tutti i formati di presentazione](/slides/it/net/supported-file-formats/), inclusi PPT, PPTX, ODP e altri formati comuni. Questo garantisce che tu possa lavorare con presentazioni create in varie versioni di Microsoft PowerPoint.
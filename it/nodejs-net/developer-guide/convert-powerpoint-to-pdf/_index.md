---
title: Converti PowerPoint in PDF con Node.js via .NET
linktitle: PowerPoint in PDF
type: docs
weight: 30
url: /it/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint in PDF
- converti PowerPoint in PDF
- PPTX in PDF
- PPT in PDF
- ODP in PDF
- salva presentazione come PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PPTX, PPT e ODP in PDF con JavaScript usando Aspose.Slides per Node.js via .NET e crea file PDF/A di archivio con PdfOptions."
---
## **Panoramica**

Aspose.Slides for Node.js via .NET converte presentazioni PowerPoint e OpenDocument in PDF senza Microsoft PowerPoint. Ogni diapositiva visibile diventa una pagina PDF delle stesse dimensioni della diapositiva e il testo rimane selezionabile e ricercabile. Questo articolo mostra la conversione predefinita e una conversione in PDF/A con [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Gli esempi si aspettano una presentazione chiamata `sample.pptx` nella cartella del progetto che hai configurato in [Installation](/slides/it/nodejs-net/installation/). Qualsiasi presentazione PowerPoint va bene. Salva ogni esempio come file `.js` nella cartella del progetto ed eseguilo da quella cartella con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET non ha una propria documentazione API. Riflette l'API Aspose.Slides per .NET con nomi camelCase, quindi i collegamenti API in questo articolo puntano alle classi e ai membri corrispondenti nella [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Convertire una presentazione in PDF**

Per convertire una presentazione in PDF, segui questi passaggi:

1. Apri la presentazione passando il suo percorso al costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Lo stesso codice funziona per file PPTX, PPT e ODP.
1. Chiama il metodo [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) fornendo il percorso di destinazione e `SaveFormat.Pdf`.
1. Chiama `dispose` in un blocco `finally` per rilasciare le risorse .NET che supportano la presentazione.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Lo script scrive `sample.pdf` nella cartella del progetto. La conversione utilizza le impostazioni predefinite: ogni diapositiva non nascosta diventa una pagina, nell'ordine delle diapositive. Senza licenza, ogni pagina mostra anche una filigrana di valutazione; vedere [Licensing](/slides/it/nodejs-net/licensing/).

## **Convertire una presentazione in PDF/A**

Per controllare l'output, passa un oggetto [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) come terzo argomento di `save`. L'esempio seguente imposta la proprietà [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) su `PdfCompliance.PdfA2b`, che genera un file PDF/A-2b. PDF/A è lo standard ISO per l'archiviazione a lungo termine: tra le altre regole, richiede che tutti i caratteri usati dal documento siano incorporati nel file.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Lo script scrive `sample-pdfa.pdf` con le stesse pagine della conversione predefinita. Per verificare che un file soddisfi lo standard, controllalo con un validatore PDF/A come [veraPDF](https://verapdf.org/). Altri valori [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) selezionano altri standard, come `PdfA1b`, `PdfA2a` o `PdfUa` per l'accessibilità.

## **FAQ**

**Come includere le diapositive nascoste nel PDF?**

Le diapositive nascoste sono omesse per impostazione predefinita. Imposta la proprietà [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) di `PdfOptions` su `true` e passa le opzioni a `save`.

**Posso proteggere il PDF con una password?**

Sì. Imposta la proprietà [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) di `PdfOptions` prima di chiamare `save`. I lettori PDF richiederanno quindi quella password prima di aprire il file.

**Posso convertire solo alcune diapositive?**

Sì. Passa un array di posizioni di diapositive come quarto argomento di `save`. Le posizioni partono da 1, e il terzo argomento può essere `null` se non hai bisogno di opzioni: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` scrive un PDF con la prima e la terza diapositiva.

**Perché il testo appare diverso quando converto su Linux?**

Aspose.Slides può utilizzare solo i caratteri installati sulla macchina che esegue la conversione. Quando una presentazione usa un carattere mancante, ad esempio Calibri su un tipico server Linux, Aspose.Slides utilizza un carattere installato al suo posto, il che può modificare l'aspetto del testo e dove le linee si interrompono. Installa i caratteri utilizzati dalle tue presentazioni per ottenere lo stesso risultato di Windows.

**Posso ottenere il PDF come Buffer invece che come file?**

Sì. `presentation.saveToBuffer(SaveFormat.Pdf)` restituisce il PDF come un `Buffer` di Node.js, utile quando invii il risultato in una risposta HTTP. Accetta anche `PdfOptions` come secondo argomento.
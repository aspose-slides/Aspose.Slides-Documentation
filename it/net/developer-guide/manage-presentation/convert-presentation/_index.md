---
title: Converti presentazioni in più formati in .NET
linktitle: Converti presentazione
type: docs
weight: 70
url: /it/net/convert-presentation/
keywords:
- converti presentazione
- esporta presentazione
- PPT in PPTX
- PPTX in PPT
- ODP in PPTX
- PPT in PDF
- PPTX in PDF
- ODP in PDF
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- PPT in PNG
- PPTX in PNG
- ODP in PNG
- PPTX in JPG
- ODP in JPG
- PPT in XPS
- PPTX in XPS
- ODP in XPS
- PPT in TIFF
- PPTX in TIFF
- ODP in TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in PPTX, PDF, HTML, immagini, XPS, TIFF e altro con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET può caricare presentazioni PowerPoint e OpenDocument e salvarle o renderizzarle in molti altri formati senza Microsoft PowerPoint, OpenOffice o LibreOffice. È possibile convertire i file PPT legacy in PPTX moderni, esportare le presentazioni in documenti a layout fisso come PDF e XPS, pubblicare le diapositive come HTML o renderizzare le diapositive in file immagine per anteprime, miniature e archivi.

La maggior parte delle conversioni di documenti utilizza lo stesso flusso di lavoro generale: caricare il file di origine, scegliere il formato di output richiesto e applicare le opzioni specifiche del formato quando necessario. Per i formati immagine, ogni diapositiva viene renderizzata separatamente e quindi salvata come immagine raster o vettoriale. Gli articoli dedicati collegati di seguito forniscono i dettagli di implementazione per ciascun caso.

## **Scegli uno scenario di conversione**

Utilizza gli articoli seguenti per esempi C# completi e opzioni specifiche del formato.

| Scenario | Usalo quando hai bisogno di | Articolo |
| --- | --- | --- |
| PPT/PPTX/ODP in PPTX | Modernizzare i file PPT legacy, normalizzare i file PPTX esistenti o convertire le presentazioni OpenDocument in PowerPoint PPTX. | [Converti PPT in PPTX](/slides/it/net/convert-ppt-to-pptx/), [Converti ODP in PPTX](/slides/it/net/convert-odp-to-pptx/), [Salva presentazioni](/slides/it/net/save-presentation/) |
| PPTX to PPT | Salva una presentazione PowerPoint moderna nel formato binary PPT più vecchio per compatibilità con flussi di lavoro più datati. | [Converti PPTX in PPT](/slides/it/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Crea documenti portabili, ricercabili e a layout fisso per condivisione, stampa o archiviazione. | [Converti PowerPoint in PDF](/slides/it/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Esporta le note del relatore insieme al contenuto delle diapositive. | [Converti PowerPoint in PDF con note](/slides/it/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Pubblica le presentazioni come pagine HTML e controlla immagini, font, note e opzioni di layout responsivo. | [Converti PowerPoint in HTML](/slides/it/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Esporta le diapositive in HTML5 per visualizzazione nel browser con formattazione e interattività preservate. | [Converti presentazioni in HTML5](/slides/it/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderizza ogni diapositiva in un'immagine PNG per anteprime, miniature o output web. | [Converti PowerPoint in PNG](/slides/it/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderizza le diapositive in immagini JPG e controlla le dimensioni e la qualità dell'immagine. | [Converti PowerPoint in JPG](/slides/it/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Esporta le singole diapositive come grafica vettoriale scalabile. | [Renderizza diapositiva come SVG](/slides/it/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Genera documenti XPS a layout fisso. | [Converti PowerPoint in XPS](/slides/it/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Salva una presentazione come file TIFF multi-pagina per stampa, scansione, fax o flussi di lavoro archivistici. | [Converti PowerPoint in TIFF](/slides/it/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Salva le diapositive con note del relatore in TIFF. | [Converti PowerPoint in TIFF con note](/slides/it/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Converti le diapositive in un documento Word quando è necessario un output in stile documento. | [Converti PowerPoint in Word](/slides/it/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Estrai il contenuto della presentazione in Markdown per documentazione e flussi di lavoro basati su testo. | [Converti PowerPoint in Markdown](/slides/it/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Crea una GIF animata dalle diapositive. | [Converti PowerPoint in GIF animata](/slides/it/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Crea un flusso di lavoro di esportazione video dalle diapositive della presentazione. | [Converti PowerPoint in Video](/slides/it/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Esporta le diapositive in XAML per scenari UI .NET. | [Esporta presentazioni in XAML](/slides/it/net/export-to-xaml/) |

Per un elenco più ampio di formati di input e output, vedi [Formati di file supportati](/slides/it/net/supported-file-formats/).

## **Conversione PowerPoint e OpenDocument**

Aspose.Slides per .NET supporta la conversione da formati di presentazione comunemente usati come PPT, PPTX, PPS, PPSX, POT, POTX e ODP. La stessa API di conversione è utilizzata per i file PowerPoint e OpenDocument, quindi un flusso di lavoro che salva un file PPTX in PDF può solitamente essere applicato a un file ODP cambiando solo il file di input.

Quando si convertono file ODP, ricordare che le applicazioni PowerPoint e OpenDocument non supportano ogni caratteristica di layout e formattazione esattamente nello stesso modo. Se un file ODP è stato creato in LibreOffice o OpenOffice Impress, revisionare l'output e utilizzare le opzioni descritte in [Converti presentazioni OpenDocument](/slides/it/net/convert-openoffice-odp/) quando è necessaria una guida specifica per il formato.

## **Conversione da PPT a PPTX**

PPT è il vecchio formato binario di PowerPoint, mentre PPTX è il moderno formato Office Open XML. Aspose.Slides per .NET supporta una conversione PPT in PPTX ad alta fedeltà preservando strutture complesse di presentazione come master, layout, diapositive, grafici, forme raggruppate, segnaposto, riquadri di testo, texture e riempimenti immagine.

Per ulteriori dettagli, vedi [Converti PPT in PPTX](/slides/it/net/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/it/net/ppt-vs-pptx/).

## **Esportazione a layout fisso**

PDF, XPS e TIFF sono utili quando l'output deve apparire uguale su tutti i dispositivi e non deve essere modificato come presentazione. Usa [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/), e [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/) per controllare la conformità, le diapositive nascoste, le note, la qualità dell'immagine, la compressione, il formato pixel e le dimensioni dell'output.

## **Esportazione HTML e Immagine**

L'esportazione HTML e HTML5 è utile per la visualizzazione nel browser, la pubblicazione web e la condivisione leggera. L'esportazione di immagini è utile quando ogni diapositiva deve diventare un'anteprima, una miniatura o una risorsa raster separata. Usa gli articoli PNG, JPG e SVG per indicazioni specifiche sul rendering per ciascun formato.

## **FAQ**

**Ho bisogno di Microsoft PowerPoint per convertire le presentazioni?**

No. Aspose.Slides per .NET è una libreria autonoma e non richiede Microsoft PowerPoint o l'automazione di Office.

**Posso convertire in batch molte presentazioni?**

Sì. Carica ogni presentazione, salvala nel formato richiesto e rilascia l'oggetto `Presentation` dopo l'elaborazione. Per l'elaborazione parallela, utilizza istanze separate di presentazione e segui le indicazioni sul [multithreading](/slides/it/net/multithreading/).

**Posso esportare solo diapositive selezionate?**

Sì. Diversi metodi di esportazione consentono di passare gli indici delle diapositive o di renderizzare diapositive individuali, a seconda del formato di output. Consulta l'articolo dedicato per il formato di destinazione.

**Posso includere le diapositive nascoste durante l'esportazione in PDF o XPS?**

Sì. Usa la proprietà `ShowHiddenSlides` in [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) o [XpsOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/).

**Posso creare output PDF/A?**

Sì. Le impostazioni di conformità PDF sono disponibili tramite [PdfOptions.Compliance](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/compliance/) e [PdfCompliance](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfcompliance/).

**Come vengono gestiti i font durante la conversione?**

Aspose.Slides può utilizzare font incorporati, fallback dei font e impostazioni di sostituzione dei font. Vedi [Font incorporato](/slides/it/net/embedded-font/), [Font di fallback](/slides/it/net/fallback-font/), e [Sostituzione font](/slides/it/net/font-substitution/).
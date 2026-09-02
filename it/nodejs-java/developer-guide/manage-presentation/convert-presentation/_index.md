---
title: Converti le presentazioni in più formati in JavaScript
linktitle: Converti presentazione
type: docs
weight: 70
url: /it/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in PPTX, PDF, HTML, immagini, XPS, TIFF e altro con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides per Node.js via Java può caricare presentazioni PowerPoint e OpenDocument e salvarle o renderizzarle in molti altri formati senza Microsoft PowerPoint, OpenOffice o LibreOffice. È possibile convertire file PPT legacy in PPTX moderni, esportare presentazioni in documenti a layout fisso come PDF e XPS, pubblicare le diapositive come HTML o renderizzare le diapositive in file immagine per anteprime, miniature e archivi.

La maggior parte delle conversioni di documenti utilizza lo stesso flusso di lavoro generale: caricare il file di origine, scegliere il formato di output richiesto e applicare le opzioni specifiche del formato quando necessario. Per i formati immagine, ogni diapositiva viene renderizzata separatamente e poi salvata come immagine raster o vettoriale. Gli articoli dedicati collegati di seguito forniscono i dettagli di implementazione per ciascun caso.

## **Scegli uno scenario di conversione**

| Scenario | Usa quando devi | Articolo |
| --- | --- | --- |
| PPT/PPTX/ODP in PPTX | Modernizzare i file PPT legacy, normalizzare i file PPTX esistenti o convertire le presentazioni OpenDocument in PowerPoint PPTX. | [Converti PPT in PPTX](/slides/it/nodejs-java/convert-ppt-to-pptx/),[Converti ODP in PPTX](/slides/it/nodejs-java/convert-odp-to-pptx/),[Salva presentazioni](/slides/it/nodejs-java/save-presentation/) |
| PPTX in PPT | Salva una presentazione PowerPoint moderna nel formato binario PPT più vecchio per la compatibilità con flussi di lavoro più datati. | [Converti PPTX in PPT](/slides/it/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP in PDF | Crea documenti portatili, ricercabili e a layout fisso per la condivisione, la stampa o l'archiviazione. | [Converti PowerPoint in PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP in PDF con note | Esporta le note del relatore insieme al contenuto delle diapositive. | [Converti PowerPoint in PDF con note](/slides/it/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP in HTML | Pubblica le presentazioni come pagine HTML e controlla immagini, caratteri, note e opzioni di layout responsivo. | [Converti PowerPoint in HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP in HTML5 | Esporta le diapositive in HTML5 per la visualizzazione nel browser con formattazione e interattività preservate. | [Converti presentazioni in HTML5](/slides/it/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP in PNG | Renderizza ogni diapositiva in un'immagine PNG per anteprime, miniature o output web. | [Converti PowerPoint in PNG](/slides/it/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP in JPG | Renderizza le diapositive in immagini JPG e controlla le dimensioni e la qualità dell'immagine. | [Converti PowerPoint in JPG](/slides/it/nodejs-java/convert-powerpoint-to-jpg/) |
| Diapositiva in SVG | Esporta diapositive individuali come grafica vettoriale scalabile. | [Renderizza diapositiva come SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP in XPS | Genera documenti XPS a layout fisso. | [Converti PowerPoint in XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP in TIFF | Salva una presentazione come file TIFF multipagina per la stampa, la scansione, il fax o flussi di lavoro di archiviazione. | [Converti PowerPoint in TIFF](/slides/it/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP in TIFF con note | Salva le diapositive con le note del relatore in TIFF. | [Converti PowerPoint in TIFF con note](/slides/it/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX in Markdown | Estrai il contenuto della presentazione in Markdown per documentazione e flussi di lavoro basati su testo. | [Converti PowerPoint in Markdown](/slides/it/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP in XML | Crea una presentazione PowerPoint XML basata su testo per ispezione, confronto, risoluzione dei problemi o flussi di lavoro basati su XML. | [Converti PowerPoint in XML](/slides/it/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX in GIF animato | Crea una GIF animata dalle diapositive. | [Converti PowerPoint in GIF animato](/slides/it/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX in video | Crea un flusso di lavoro di esportazione video dalle diapositive della presentazione. | [Converti PowerPoint in video](/slides/it/nodejs-java/convert-powerpoint-to-video/) |
| Presentazione in XAML | Esporta le diapositive in XAML per scenari UI JavaScript o Java. | [Esporta presentazioni in XAML](/slides/it/nodejs-java/export-to-xaml/) |

Per una lista più ampia di formati di input e output, vedere [Formati di file supportati](/slides/it/nodejs-java/supported-file-formats/).

## **Conversione PowerPoint e OpenDocument**

Aspose.Slides per Node.js via Java supporta la conversione dai formati di presentazione più comuni come PPT, PPTX, PPS, PPSX, POT, POTX e ODP. La stessa API di conversione è usata per i file PowerPoint e OpenDocument, quindi un flusso di lavoro che salva un file PPTX in PDF può solitamente essere applicato a un file ODP modificando solo il file di input.

Durante la conversione di file ODP, ricordare che le applicazioni PowerPoint e OpenDocument non supportano ogni caratteristica di layout e formattazione nello stesso modo esatto. Se un file ODP è stato creato in LibreOffice o OpenOffice Impress, esaminare l'output e utilizzare le opzioni descritte in [Converti presentazioni OpenDocument](/slides/it/nodejs-java/convert-openoffice-odp/) quando è necessaria una guida specifica per il formato.

## **Conversione da PPT a PPTX**

PPT è il formato binario PowerPoint più vecchio, mentre PPTX è il moderno formato Office Open XML. Aspose.Slides per Node.js via Java supporta la conversione ad alta fedeltà da PPT a PPTX preservando strutture di presentazione complesse come master, layout, diapositive, grafici, forme raggruppate, segnaposti, riquadri di testo, texture e riempimenti di immagine.

Per i dettagli, vedere [Converti PPT in PPTX](/slides/it/nodejs-java/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/it/nodejs-java/ppt-vs-pptx/).

## **Esportazione a layout fisso**

PDF, XPS e TIFF sono utili quando l'output deve apparire uguale su tutti i dispositivi e non deve essere modificato come una presentazione. Gli articoli dedicati a PDF, XPS e TIFF spiegano come controllare la conformità, le diapositive nascoste, le note, la qualità dell'immagine, la compressione, il formato dei pixel e le dimensioni dell'output.

## **Esportazione HTML e Immagine**

L'esportazione HTML e HTML5 è utile per la visualizzazione in browser, la pubblicazione web e la condivisione leggera. L'esportazione di immagini è utile quando ogni diapositiva deve diventare un'anteprima, una miniatura o un asset raster separato. Utilizza gli articoli su PNG, JPG e SVG per indicazioni di rendering specifiche per il formato.

## **Domande frequenti**

**Devo avere Microsoft PowerPoint per convertire le presentazioni?**

No. Aspose.Slides per Node.js via Java è una libreria indipendente e non richiede Microsoft PowerPoint né l'automazione di Office.

**Posso convertire in batch molte presentazioni?**

Sì. Carica ogni presentazione, salvala nel formato richiesto e rilascia l'oggetto presentazione dopo l'elaborazione. Per l'elaborazione parallela, usa istanze separate di presentazione e segui le indicazioni sul [multithreading](/slides/it/nodejs-java/multithreading/).

**Posso esportare solo le diapositive selezionate?**

Sì. Diversi metodi di esportazione consentono di passare indici di diapositiva o di renderizzare diapositive individuali, a seconda del formato di output. Vedi l'articolo dedicato per il formato di destinazione.

**Posso includere le diapositive nascoste durante l'esportazione in PDF o XPS?**

Sì. Usa le impostazioni di esportazione delle diapositive nascoste descritte negli articoli di conversione [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) e [XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/).

**Posso creare output PDF/A?**

Sì. Sono disponibili impostazioni di conformità PDF per l'esportazione PDF. Vedi [Converti PowerPoint in PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) per i dettagli.

**Come vengono gestiti i caratteri durante la conversione?**

Aspose.Slides può utilizzare caratteri incorporati, fallback dei caratteri e impostazioni di sostituzione dei caratteri. Vedi [Carattere incorporato](/slides/it/nodejs-java/embedded-font/), [Carattere di fallback](/slides/it/nodejs-java/fallback-font/) e [Sostituzione dei caratteri](/slides/it/nodejs-java/font-substitution/).
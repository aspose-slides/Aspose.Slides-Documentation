---
title: Converti le Presentazioni in più Formati in PHP
linktitle: Converti Presentazione
type: docs
weight: 70
url: /it/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "Converti presentazioni PowerPoint e OpenDocument in PPTX, PDF, HTML, immagini, XPS, TIFF e altro con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides for PHP via Java può caricare presentazioni PowerPoint e OpenDocument e salvarle o renderizzarle in molti altri formati senza Microsoft PowerPoint, OpenOffice o LibreOffice. È possibile convertire i file PPT legacy in moderni PPTX, esportare le presentazioni in documenti a layout fisso come PDF e XPS, pubblicare le diapositive come HTML o renderizzare le diapositive come file immagine per anteprime, miniature e archivi.

La maggior parte delle conversioni di documenti utilizza lo stesso flusso di lavoro generale: caricare il file di origine, scegliere il formato di output richiesto e applicare le opzioni specifiche del formato quando necessario. Per i formati immagine, ogni diapositiva è renderizzata separatamente e quindi salvata come immagine raster o vettoriale. Gli articoli dedicati collegati di seguito forniscono i dettagli dell'implementazione per ciascun caso.

## **Scegli uno Scenario di Conversione**

Utilizza gli articoli seguenti per esempi PHP completi e opzioni specifiche del formato.

| Scenario | Usalo quando hai bisogno di | Articolo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizzare i file PPT legacy, normalizzare i file PPTX esistenti o convertire le presentazioni OpenDocument in PowerPoint PPTX. | [Converti PPT in PPTX](/slides/it/php-java/convert-ppt-to-pptx/), [Converti ODP in PPTX](/slides/it/php-java/convert-odp-to-pptx/), [Salva Presentazioni](/slides/it/php-java/save-presentation/) |
| PPTX a PPT | Salva una presentazione PowerPoint moderna nel vecchio formato binario PPT per compatibilità con flussi di lavoro più vecchi. | [Converti PPTX in PPT](/slides/it/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP in PDF | Crea documenti portatili, ricercabili e a layout fisso per condivisione, stampa o archiviazione. | [Converti PowerPoint in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP in PDF con note | Esporta le note del relatore insieme al contenuto delle diapositive. | [Converti PowerPoint in PDF con Note](/slides/it/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP in HTML | Pubblica le presentazioni come pagine HTML e controlla immagini, caratteri, note e opzioni di layout responsive. | [Converti PowerPoint in HTML](/slides/it/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP in HTML5 | Esporta le diapositive in HTML5 per visualizzazione basata su browser con formattazione e interattività preservate. | [Converti Presentazioni in HTML5](/slides/it/php-java/export-to-html5/) |
| PPT/PPTX/ODP in PNG | Renderizza ogni diapositiva in un'immagine PNG per anteprime, miniature o output web. | [Converti PowerPoint in PNG](/slides/it/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP in JPG | Renderizza le diapositive in immagini JPG e controlla le dimensioni e la qualità dell'immagine. | [Converti PowerPoint in JPG](/slides/it/php-java/convert-powerpoint-to-jpg/) |
| Diapositiva in SVG | Esporta diapositive individuali come grafica vettoriale scalabile. | [Renderizza Diapositiva come SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP in XPS | Genera documenti XPS a layout fisso. | [Converti PowerPoint in XPS](/slides/it/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP in TIFF | Salva una presentazione come file TIFF multipagina per stampa, scansione, fax o flussi di lavoro di archiviazione. | [Converti PowerPoint in TIFF](/slides/it/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP in TIFF con note | Salva le diapositive con le note del relatore in TIFF. | [Converti PowerPoint in TIFF con Note](/slides/it/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX in Markdown | Estrai il contenuto della presentazione in Markdown per documentazione e flussi di lavoro basati su testo. | [Converti PowerPoint in Markdown](/slides/it/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP in XML | Crea una Presentazione PowerPoint XML basata su testo per ispezione, confronto, risoluzione dei problemi o flussi di lavoro basati su XML. | [Converti PowerPoint in XML](/slides/it/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX in GIF animato | Crea una GIF animata dalle diapositive. | [Converti PowerPoint in GIF Animata](/slides/it/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX in video | Costruisci un flusso di lavoro di esportazione video dalle diapositive della presentazione. | [Converti PowerPoint in Video](/slides/it/php-java/convert-powerpoint-to-video/) |
| Presentazione in XAML | Esporta le diapositive in XAML per scenari UI PHP o Java. | [Esporta Presentazioni in XAML](/slides/it/php-java/export-to-xaml/) |

Per un elenco più ampio di formati di input e output, vedi [Formati di File Supportati](/slides/it/php-java/supported-file-formats/).

## **Conversione PowerPoint e OpenDocument**

Aspose.Slides for PHP via Java supporta la conversione da formati di presentazione comunemente usati come PPT, PPTX, PPS, PPSX, POT, POTX e ODP. La stessa API di conversione è usata per file PowerPoint e OpenDocument, quindi un flusso di lavoro che salva un file PPTX in PDF può solitamente essere applicato a un file ODP cambiando solo il file di input.

Quando si convertono file ODP, ricordare che le applicazioni PowerPoint e OpenDocument non supportano ogni caratteristica di layout e formattazione nello stesso modo esatto. Se un file ODP è stato creato in LibreOffice o OpenOffice Impress, esamina l'output e utilizza le opzioni descritte in [Converti Presentazioni OpenDocument](/slides/it/php-java/convert-openoffice-odp/) quando hai bisogno di indicazioni specifiche per il formato.

## **Conversione da PPT a PPTX**

PPT è il più vecchio formato binario di PowerPoint, mentre PPTX è il moderno formato Office Open XML. Aspose.Slides for PHP via Java supporta la conversione ad alta fedeltà da PPT a PPTX preservando strutture complesse della presentazione come master, layout, diapositive, grafici, forme raggruppate, segnaposti, riquadri di testo, texture e riempimenti di immagine.

Per i dettagli, vedi [Converti PPT in PPTX](/slides/it/php-java/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/it/php-java/ppt-vs-pptx/).

## **Esportazione a Layout Fisso**

PDF, XPS e TIFF sono utili quando l'output deve apparire uguale su tutti i dispositivi e non dovrebbe essere modificato come una presentazione. Gli articoli dedicati a PDF, XPS e TIFF spiegano come controllare la conformità, le diapositive nascoste, le note, la qualità dell'immagine, la compressione, il formato dei pixel e le dimensioni dell'output.

## **Esportazione HTML e Immagine**

L'esportazione HTML e HTML5 è utile per la visualizzazione in browser, la pubblicazione web e la condivisione leggera. L'esportazione di immagini è utile quando ogni diapositiva deve diventare un'anteprima, una miniatura o una risorsa raster separata. Utilizza gli articoli PNG, JPG e SVG per indicazioni sul rendering specifico del formato.

## **FAQ**

**Ho bisogno di Microsoft PowerPoint per convertire le presentazioni?**

No. Aspose.Slides for PHP via Java è una libreria autonoma e non richiede Microsoft PowerPoint né l'automazione di Office.

**Posso convertire in batch molte presentazioni?**

Sì. Carica ogni presentazione, salvala nel formato richiesto e libera l'oggetto presentazione dopo l'elaborazione. Per l'elaborazione in parallelo, usa istanze di presentazione separate e segui le indicazioni su [multithreading](/slides/it/php-java/multithreading/).

**Posso esportare solo diapositive selezionate?**

Sì. Diversi metodi di esportazione consentono di passare gli indici delle diapositive o di renderizzare diapositive individuali, a seconda del formato di output. Vedi l'articolo dedicato per il formato di destinazione.

**Posso includere le diapositive nascoste durante l'esportazione in PDF o XPS?**

Sì. Usa le impostazioni di esportazione delle diapositive nascoste descritte negli articoli di conversione [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) e [XPS](/slides/it/php-java/convert-powerpoint-to-xps/).

**Posso creare output PDF/A?**

Sì. Sono disponibili impostazioni di conformità PDF per l'esportazione in PDF. Vedi [Converti PowerPoint in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) per i dettagli.

**Come vengono gestiti i caratteri durante la conversione?**

Aspose.Slides può utilizzare caratteri incorporati, fallback dei caratteri e impostazioni di sostituzione dei caratteri. Vedi [Carattere Incorporato](/slides/it/php-java/embedded-font/), [Carattere di Fallback](/slides/it/php-java/fallback-font/), e [Sostituzione del Carattere](/slides/it/php-java/font-substitution/).
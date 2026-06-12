---
title: Converti presentazioni in più formati in PHP
linktitle: Converti presentazione
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
description: "Converti le presentazioni PowerPoint e OpenDocument in PPTX, PDF, HTML, immagini, XPS, TIFF e altro con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides for PHP via Java può caricare presentazioni PowerPoint e OpenDocument e salvarle o renderizzarle in molti altri formati senza Microsoft PowerPoint, OpenOffice o LibreOffice. È possibile convertire file PPT legacy in moderni PPTX, esportare presentazioni in documenti a layout fisso come PDF e XPS, pubblicare le diapositive come HTML o renderizzare le diapositive come file immagine per anteprime, miniature e archivi.

La maggior parte delle conversioni di documenti utilizza lo stesso flusso di lavoro generale: caricare il file di origine, scegliere il formato di output richiesto e applicare le opzioni specifiche del formato quando necessario. Per i formati immagine, ogni diapositiva viene renderizzata separatamente e poi salvata come immagine raster o vettoriale. Gli articoli dedicati collegati di seguito forniscono i dettagli di implementazione per ciascun caso.

## **Scegli uno scenario di conversione**

Usa gli articoli sotto per esempi PHP completi e opzioni specifiche del formato.

| Scenario | Usalo quando hai bisogno di | Articolo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizzare i file PPT legacy, normalizzare i file PPTX esistenti o convertire presentazioni OpenDocument in PowerPoint PPTX. | [Converti PPT in PPTX](/slides/it/php-java/convert-ppt-to-pptx/), [Converti ODP in PPTX](/slides/it/php-java/convert-odp-to-pptx/), [Salva presentazioni](/slides/it/php-java/save-presentation/) |
| PPTX a PPT | Salvare una presentazione PowerPoint moderna nel vecchio formato binario PPT per la compatibilità con flussi di lavoro più datati. | [Converti PPTX in PPT](/slides/it/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP a PDF | Creare documenti portabili, ricercabili e a layout fisso per la condivisione, la stampa o l'archiviazione. | [Converti PowerPoint in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP a PDF con note | Esportare le note del relatore insieme al contenuto delle diapositive. | [Converti PowerPoint in PDF con note](/slides/it/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP a HTML | Pubblicare le presentazioni come pagine HTML e controllare immagini, caratteri, note e opzioni di layout responsive. | [Converti PowerPoint in HTML](/slides/it/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP a HTML5 | Esportare le diapositive in HTML5 per visualizzazione nel browser con formattazione e interattività preservate. | [Converti presentazioni in HTML5](/slides/it/php-java/export-to-html5/) |
| PPT/PPTX/ODP a PNG | Renderizzare ogni diapositiva in un'immagine PNG per anteprime, miniature o output web. | [Converti PowerPoint in PNG](/slides/it/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP a JPG | Renderizzare le diapositive in immagini JPG e controllare le dimensioni e la qualità dell'immagine. | [Converti PowerPoint in JPG](/slides/it/php-java/convert-powerpoint-to-jpg/) |
| Diapositiva a SVG | Esportare diapositive individuali come grafica vettoriale scalabile. | [Renderizza diapositiva come SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP a XPS | Generare documenti XPS a layout fisso. | [Converti PowerPoint in XPS](/slides/it/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP a TIFF | Salvare una presentazione come file TIFF multipagina per stampa, scansione, fax o flussi di lavoro di archiviazione. | [Converti PowerPoint in TIFF](/slides/it/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP a TIFF con note | Salvare le diapositive con le note del relatore in TIFF. | [Converti PowerPoint in TIFF con note](/slides/it/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX a Markdown | Estrarre il contenuto della presentazione in Markdown per documentazione e flussi di lavoro basati su testo. | [Converti PowerPoint in Markdown](/slides/it/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX a GIF animata | Creare una GIF animata dalle diapositive. | [Converti PowerPoint in GIF animata](/slides/it/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX a video | Creare un flusso di lavoro di esportazione video dalle diapositive della presentazione. | [Converti PowerPoint in video](/slides/it/php-java/convert-powerpoint-to-video/) |
| Presentazione a XAML | Esportare le diapositive in XAML per scenari UI PHP o Java. | [Esporta presentazioni in XAML](/slides/it/php-java/export-to-xaml/) |

Per un elenco più ampio di formati di input e output, vedere [Formati di file supportati](/slides/it/php-java/supported-file-formats/).

## **Conversione PowerPoint e OpenDocument**

Aspose.Slides for PHP via Java supporta la conversione dai formati di presentazione più comunemente usati, come PPT, PPTX, PPS, PPSX, POT, POTX e ODP. La stessa API di conversione è utilizzata per i file PowerPoint e OpenDocument, quindi un flusso di lavoro che salva un file PPTX in PDF può generalmente essere applicato a un file ODP modificando solo il file di input.

Quando si convertono file ODP, ricordare che le applicazioni PowerPoint e OpenDocument non supportano ogni caratteristica di layout e formattazione esattamente allo stesso modo. Se un file ODP è stato creato in LibreOffice o OpenOffice Impress, esaminare l'output e utilizzare le opzioni descritte in [Converti presentazioni OpenDocument](/slides/it/php-java/convert-openoffice-odp/) quando è necessaria una guida specifica per il formato.

## **Conversione da PPT a PPTX**

PPT è il vecchio formato binario di PowerPoint, mentre PPTX è il moderno formato Office Open XML. Aspose.Slides for PHP via Java supporta la conversione ad alta fedeltà da PPT a PPTX preservando strutture complesse della presentazione come master, layout, diapositive, grafici, forme raggruppate, segnaposti, riquadri di testo, trame e riempimenti di immagine.

Per i dettagli, vedere [Converti PPT in PPTX](/slides/it/php-java/convert-ppt-to-pptx/) e [PPT vs PPTX](/slides/it/php-java/ppt-vs-pptx/).

## **Esportazione a layout fisso**

PDF, XPS e TIFF sono utili quando l'output deve apparire identico su tutti i dispositivi e non deve essere modificato come una presentazione. Gli articoli dedicati a PDF, XPS e TIFF spiegano come controllare la conformità, le diapositive nascoste, le note, la qualità dell'immagine, la compressione, il formato pixel e le dimensioni dell'output.

## **Esportazione HTML e Immagini**

L'esportazione in HTML e HTML5 è utile per la visualizzazione nel browser, la pubblicazione web e la condivisione leggera. L'esportazione di immagini è utile quando ogni diapositiva deve diventare un'anteprima, una miniatura o una risorsa raster separata. Utilizzare gli articoli PNG, JPG e SVG per le indicazioni di rendering specifiche per il formato.

## **FAQ**

**Ho bisogno di Microsoft PowerPoint per convertire le presentazioni?**

No. Aspose.Slides for PHP via Java è una libreria indipendente e non richiede Microsoft PowerPoint né l'automazione di Office.

**Posso convertire in batch molte presentazioni?**

Sì. Carica ogni presentazione, salvala nel formato richiesto e rilascia l'oggetto presentazione dopo l'elaborazione. Per l'elaborazione parallela, utilizza istanze separate di presentazione e segui le indicazioni sul [multithreading](/slides/it/php-java/multithreading/).

**Posso esportare solo le diapositive selezionate?**

Sì. Diverse modalità di esportazione consentono di passare gli indici delle diapositive o di renderizzare diapositive individuali, a seconda del formato di output. Vedi l'articolo dedicato per il formato di destinazione.

**Posso includere le diapositive nascoste durante l'esportazione in PDF o XPS?**

Sì. Usa le impostazioni di esportazione per le diapositive nascoste descritte negli articoli di conversione [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) e [XPS](/slides/it/php-java/convert-powerpoint-to-xps/).

**Posso creare output PDF/A?**

Sì. Sono disponibili impostazioni di conformità PDF per l'esportazione in PDF. Vedi [Converti PowerPoint in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) per i dettagli.

**Come vengono gestiti i caratteri durante la conversione?**

Aspose.Slides può utilizzare caratteri incorporati, fallback dei caratteri e impostazioni di sostituzione dei caratteri. Vedi [Carattere incorporato](/slides/it/php-java/embedded-font/), [Carattere di fallback](/slides/it/php-java/fallback-font/) e [Sostituzione del carattere](/slides/it/php-java/font-substitution/).
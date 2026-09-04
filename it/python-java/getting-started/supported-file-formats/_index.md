---
title: Formati di file supportati
type: docs
weight: 30
url: /it/python-java/supported-file-formats/
keywords:
- formati di file supportati
- formati di presentazione
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- immagini delle diapositive
- Python
- Aspose.Slides per Python via Java
description: "Esplora i formati di presentazione, documento, web e immagine che Aspose.Slides per Python via Java può caricare, importare, salvare ed esportare."
---
## **Panoramica**

Aspose.Slides per Python tramite Java legge e scrive presentazioni PowerPoint e OpenDocument. Importa anche contenuti PDF e HTML nelle diapositive ed esporta presentazioni o diapositive individuali in formati documento, web e immagine.

La tabella seguente distingue il caricamento delle presentazioni dall'importazione dei contenuti e dal rendering delle diapositive. Per una panoramica delle capacità di modifica e rendering, vedere [Panoramica delle funzionalità](/slides/it/python-java/features-overview/).

## **Versioni Microsoft PowerPoint supportate**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint per Mac
- PowerPoint per Microsoft 365 (ex Office 365)


## **Formati di file supportati**

La tabella seguente elenca i formati di input e output supportati. **Load / Import** include l'apertura di file di presentazione e l'importazione di contenuti PDF o HTML. **Save / Export** include il salvataggio delle presentazioni e il rendering delle diapositive in immagini. Un trattino indica che l'operazione corrispondente non è supportata come operazione di conversione della presentazione.

|**Formato**|**Descrizione**|**Load / Import**|**Save / Export**|**Osservazioni**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentazione PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Modello PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Show PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentazione PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modello PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Show PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentazione PowerPoint con macro abilitate|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show PowerPoint con macro abilitate|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modello PowerPoint con macro abilitate|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentazione OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Formato OpenDocument impacchettato.|
|FODP|Presentazione OpenDocument XML piatta|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Memorizza la presentazione come un singolo documento XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modello di presentazione OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato file immagine con tag|—|{{< emoticons/tick >}}|Supporta output multipagina.|
|[EMF](https://docs.fileformat.com/image/emf/)|Metafile avanzato|—|{{< emoticons/tick >}}|Esporta diapositive individuali come immagini vettoriali.|
|[PDF](https://docs.fileformat.com/pdf/)|Formato documento portatile|Import|{{< emoticons/tick >}}|Importa pagine PDF come diapositive; esporta presentazioni in PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specificazione XML Paper|—|{{< emoticons/tick >}}|Output documento a layout fisso.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Immagine JPEG|—|{{< emoticons/tick >}}|Renderizza diapositive individuali come immagini raster.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Renderizza diapositive individuali come immagini raster.|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato di interscambio grafico|—|{{< emoticons/tick >}}|Output immagine.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Immagine bitmap|—|{{< emoticons/tick >}}|Renderizza diapositive individuali come immagini raster.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Grafica vettoriale scalabile|—|{{< emoticons/tick >}}|Esporta diapositive individuali come immagini vettoriali.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Output Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Linguaggio di marcatura ipertestuale|Import|{{< emoticons/tick >}}|Importa contenuti HTML come diapositive; supporta l'esportazione in HTML e HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguaggio di marcatura di applicazioni estensibile|—|{{< emoticons/tick >}}|Esporta il contenuto della presentazione in XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Esporta il contenuto della presentazione in Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Presentazione XML PowerPoint|—|{{< emoticons/tick >}}|Output XML specifico di PowerPoint, non XML arbitrario.|

## **Note su importazione ed esportazione**

- **Importazione PDF e HTML:** Utilizzare [SlideCollection.addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addfrompdf) o [SlideCollection.addFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addfromhtml) per creare diapositive dal contenuto sorgente e aggiungerle a una presentazione.
- **Output della presentazione:** [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) elenca i formati di salvataggio delle presentazioni disponibili, includendo le opzioni di esportazione HTML e HTML5 separate.
- **Output immagine:** L'esportazione di una diapositiva in un'immagine produce una rappresentazione visiva di quella diapositiva. La colonna di input non descrive se un'immagine può essere inserita in una presentazione.

## **Domande frequenti**

**Posso convertire una presentazione PPT in PPTX o ODP?**

Sì. PPT è supportato come formato di input, e sia PPTX che ODP sono supportati come formati di output. I risultati della conversione dipendono dalle funzionalità disponibili nel formato di destinazione.

**L'importazione PDF o HTML apre la sorgente come file PowerPoint?**

No. L'importazione crea diapositive dalle pagine PDF o dal contenuto HTML. È quindi possibile salvare la presentazione risultante in un formato di presentazione supportato.

**Posso caricare un PNG o SVG esportato come presentazione modificabile?**

No. Queste esportazioni rappresentano l'aspetto della diapositiva. Conserva la presentazione originale quando devi modificare in seguito testo, forme, grafici e altri oggetti.
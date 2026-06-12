---
title: Formati di file supportati
type: docs
weight: 20
url: /it/cpp/supported-file-formats/
keywords:
- formato file
- formato supportato
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri tutti i formati di file che Aspose.Slides per C++ può aprire, salvare e convertire — inclusi PPT, PPTX e ODP — con note chiare sul supporto di import/export."
---
## **Panoramica**

Aspose.Slides supporta i file di presentazione da Microsoft PowerPoint 97 fino a Office 365, inclusi Microsoft PowerPoint per Mac. Questo articolo elenca le versioni di PowerPoint supportate dalla libreria e fornisce una tabella dei formati di file che possono essere caricati, salvati o entrambi.

L'articolo risponde anche alle domande comuni su conformità PDF, incorporamento dei font, file protetti da password, font personalizzati, fallback dei font e opzioni di esportazione XPS.

## **Versioni di Microsoft PowerPoint supportate**
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
- Office 365

## **Formati di file supportati**
Questa tabella contiene i formati di file che Aspose.Slides per C++ può caricare e salvare:

|**Formato**|**Descrizione**|**Carica**|**Salva**|**Osservazioni**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentazione PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Modello PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Spettacolo PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentazione PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modello PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Spettacolo PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentazione PowerPoint con macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Spettacolo PowerPoint con macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modello PowerPoint con macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Presentazione OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modello di presentazione OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato file immagine Tag||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Formato Metafile migliorato||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Formato documento portatile|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specificazione XML Paper||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Grafica di rete portabile||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Formato di scambio grafico||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap indipendente dal dispositivo||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Grafica vettoriale scalabile||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web piccolo||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Linguaggio di marcazione ipertestuale|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguaggio di marcatura applicativa estensibile||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown||{{< emoticons/tick >}}||
|[XML](https://docs.fileformat.com/web/xml/)|Presentazione XML PowerPoint||{{< emoticons/tick >}}||

## **Domande frequenti**

**Posso salvare presentazioni in PDF che soddisfano gli standard di archiviazione e accessibilità (PDF/A e PDF/UA)?**

Sì. Aspose.Slides supporta l'esportazione in PDF con livelli di conformità come PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, nonché PDF/UA tramite l'impostazione [compliance](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/set_compliance/) nelle [PDF export options](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/).

**La libreria supporta l'incorporamento dei font durante l'esportazione in PDF, con controllo dettagliato su cosa viene incorporato?**

Sì. È possibile controllare se i font sono completamente incorporati o sottoinsieme (solo i glifi utilizzati), specificare come vengono gestiti i font di sistema più comuni e configurare il comportamento del testo ASCII tramite le [PDF export options](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/).

**Posso rilevare se un file è protetto da password prima di caricarlo realmente?**

Sì. Utilizzando l'[factory-based inspection API](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/), è possibile interrogare un file di presentazione per determinare se è protetto da password senza aprirlo completamente.

**Esistono meccanismi di fallback dei font e supporto per font personalizzati?**

Sì. La libreria supporta il [loading](/slides/it/cpp/custom-font/) e l'[embedding](/slides/it/cpp/embedded-font/) di font personalizzati e fornisce le [fallback rules](/slides/it/cpp/fallback-font/) dei font per evitare glifi mancanti durante il rendering e la conversione.

**Posso esportare le diapositive in XPS e ci sono opzioni per regolare l'output XPS?**

Sì. [Export to XPS](/slides/it/cpp/convert-powerpoint-to-xps/) è supportato e puoi regolare le [save options](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/xpsoptions/) pertinenti per controllare la qualità e il contenuto dell'output del documento XPS.
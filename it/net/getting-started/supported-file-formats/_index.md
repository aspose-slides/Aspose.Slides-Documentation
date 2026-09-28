---
title: Formati di file supportati
type: docs
weight: 96
url: /it/net/supported-file-formats/
keywords:
- formati di file supportati
- caricare presentazione
- importare PDF
- importare HTML
- salvare presentazione
- renderizzare diapositive
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Scopri quali formati di file Aspose.Slides per .NET può caricare, importare, salvare e renderizzare, e quale API legge o scrive ciascuno di essi."
---
## **Panoramica**

Aspose.Slides per .NET apre e salva presentazioni PowerPoint e OpenDocument. Importa inoltre contenuti PDF e HTML nelle diapositive, salva le presentazioni in formati documento, web e immagine, e rende singole diapositive e forme come immagini. Questo articolo elenca ogni formato supportato e indica l’API che lo legge o lo scrive.

Entrambi i pacchetti NuGet, Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform, supportano gli stessi formati; consulta [Installazione](/slides/it/net/installation/) per scegliere tra loro. Per una panoramica delle funzionalità di modifica, vedi [Panoramica delle funzionalità](/slides/it/net/features-overview/).

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

{{% alert color="info" title="Nota" %}}

Le presentazioni salvate con PowerPoint 95 e versioni precedenti non possono essere aperte. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) riconosce un file PowerPoint 95 e restituisce `LoadFormat.Ppt95`, ma il costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) genera una [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) per esso.

{{% /alert %}}

## **Formati di file supportati**

La tabella utilizza quattro operazioni:

- **Carica**: il costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) apre il file come una presentazione modificabile.
- **Importa**: un metodo di [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) crea diapositive dal contenuto del file e le aggiunge a una presentazione esistente. Il costruttore Presentation non carica questi file come presentazioni.
- **Salva**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) scrive la presentazione su file o stream. Ogni formato, eccetto XAML, è selezionato con un valore di [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Renderizza**: un metodo di rendering disegna una diapositiva o una forma come immagine. I formati che sono solo renderizzati non hanno valori di SaveFormat.

|**Formato**|**Descrizione**|**Carica / Importa**|**Salva / Renderizza**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentazione PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modello PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentazione diapositive PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentazione PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modello PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Presentazione diapositive PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentazione PowerPoint con macro|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modello PowerPoint con macro|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Presentazione diapositive PowerPoint con macro|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentazione OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentazione OpenDocument XML piatta|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modello di presentazione OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentazione PowerPoint XML|Load|Save|`SaveFormat.Xml`; i file caricati riportano `SourceFormat.Xml` (non esiste valore `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formato documento portatile|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Linguaggio di markup ipertestuale|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specificazione XML Paper|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato file immagine taggato|—|Save, Renderizza|`SaveFormat.Tiff`; `ImageFormat.Tiff` (una diapositiva)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato di interscambio grafico|—|Save, Renderizza|`SaveFormat.Gif` (animato, tutte le diapositive); `ImageFormat.Gif` (una diapositiva)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguaggio di marcatura estensibile delle applicazioni|—|Save|`Presentation.Save(IXamlOptions)`, un file XAML per diapositiva; non è un valore `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Renderizza|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Immagine JPEG|—|Renderizza|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Immagine bitmap|—|Renderizza|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Metafile migliorato|—|Renderizza|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Grafica vettoriale scalabile|—|Renderizza|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Carica e Importa**

- **Carica:** Passa un percorso file o uno stream al costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Il formato viene rilevato dal contenuto; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) fornisce impostazioni come la password. Per verificare un file prima di aprirlo, chiama [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), che restituisce un valore di [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Restituisce `LoadFormat.Unknown` per PowerPoint XML, ma il costruttore apre comunque il file e [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) restituisce `SourceFormat.Xml`. Vedi [Aprire presentazioni](/slides/it/net/open-presentation/) e [Determinare il formato originale della presentazione](/slides/it/net/detect-presentation-source-format/).
- **Importa:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) aggiunge una diapositiva per ogni pagina PDF alla fine di una presentazione. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) aggiunge diapositive create da HTML, e [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) le inserisce in una posizione specificata. Il costruttore Presentation non importa: genera una [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) per un file PDF e non converte il markup HTML in contenuto di diapositiva. Vedi [Importare presentazioni da PDF o HTML](/slides/it/net/import-presentation/).

## **Salva e Renderizza**

- **Salva:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) scrive la presentazione nel formato indicato da un valore di [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Le overload che accettano anche un oggetto opzioni controllano l’output, ad esempio [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), e [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Le overload che accettano un array di posizioni di diapositive (a partire da 1) scrivono solo quelle diapositive; supportano PDF, XPS, TIFF, HTML, HTML5, SWF, GIF e Markdown, ma non i formati di presentazione né PowerPoint XML. XAML ha una propria overload che accetta [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Vedi [Salvare presentazioni](/slides/it/net/save-presentation/), [Convertire presentazioni](/slides/it/net/convert-presentation/), e [Esportare presentazioni in XAML](/slides/it/net/export-to-xaml/).
- **Renderizza:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) e [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) restituiscono un [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), e [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) lo scrive come PNG, JPEG, BMP, GIF o TIFF, selezionato con un valore di [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) rende tutte le diapositive o quelle selezionate in un’unica operazione. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) e [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) scrivono SVG, e [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) scrive EMF. Vedi [Convertire diapositive di presentazione in immagini](/slides/it/net/convert-slide/) e [Renderizzare una diapositiva come immagine SVG](/slides/it/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Avviso" %}}

ImageFormat contiene anche i valori `Emf`, `Wmf`, `Icon`, `Exif` e `MemoryBmp`, ma IImage.Save non produce quei formati: il file scritto contiene dati PNG. Per ottenere un’immagine EMF di una diapositiva, usa Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Posso convertire una presentazione PPT in PPTX o ODP?**

Sì. Apri il file PPT con il costruttore Presentation e salvalo con `SaveFormat.Pptx` o `SaveFormat.Odp`. Vedi [Convertire PPT in PPTX](/slides/it/net/convert-ppt-to-pptx/).

**Posso aprire un file PDF o HTML come presentazione?**

No. Crea o apri una presentazione, importa le pagine PDF o il contenuto HTML con i metodi della collezione di diapositive descritti sopra, quindi salvala in qualsiasi formato supportato.

**Posso caricare un’immagine PNG o SVG esportata come presentazione modificabile?**

No. L’output immagine registra solo l’aspetto della diapositiva, non il testo, le forme o i grafici. Conserva la presentazione originale se devi modificarla in seguito.

**Posso salvare documenti PDF/A o PDF/UA?**

Sì. Imposta [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) su un valore di [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b o PDF/UA.

**Posso verificare se un file è protetto da password prima di aprirlo?**

Sì. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) analizza un file senza creare un oggetto Presentation e la sua proprietà [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) indica se è necessaria una password. Vedi [Presentazioni protette da password](/slides/it/net/password-protected-presentation/).

**I due pacchetti NuGet supportano formati diversi?**

No. Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform hanno gli stessi valori di LoadFormat e SaveFormat e gli stessi metodi di importazione e rendering. Differiscono per le piattaforme su cui girano e per le esigenze di quelle piattaforme; consulta [Installazione](/slides/it/net/installation/).
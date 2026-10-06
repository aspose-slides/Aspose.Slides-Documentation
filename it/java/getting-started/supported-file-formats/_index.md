---
title: Formati di file supportati
type: docs
weight: 106
url: /it/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Scopri quali formati di file Aspose.Slides per Java può caricare, importare, salvare e renderizzare, e quale API legge o scrive ciascuno di essi."
---
## **Panoramica**

Aspose.Slides for Java apre e salva presentazioni PowerPoint e OpenDocument. Importa anche contenuti PDF e HTML nelle diapositive, salva le presentazioni in formati documento, web e immagine, e rende singole diapositive e forme come immagini. Questo articolo elenca ogni formato supportato e indica l’API che lo legge o lo scrive.

Per una panoramica delle funzionalità di modifica, vedere [Panoramica delle funzionalità](/slides/it/java/features-overview/).

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
- PowerPoint per Microsoft 365 (ex Office 365)

{{% alert color="info" title="Note" %}}

Le presentazioni salvate con PowerPoint 95 e versioni precedenti non possono essere aperte. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) riconosce un file PowerPoint 95 e segnala `LoadFormat.Ppt95`, ma il costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) genera [PptUnsupportedFormatException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptunsupportedformatexception/) per esso.

{{% /alert %}}

## **Formati di file supportati**

La tabella utilizza quattro operazioni:

- **Load**: il costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) apre il file come una presentazione modificabile.
- **Import**: un metodo di [SlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/) crea diapositive dal contenuto del file e le aggiunge a una presentazione esistente. Il costruttore Presentation non converte questi file in diapositive.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) scrive la presentazione su un file o stream. Ogni formato eccetto XAML è selezionato con un valore di [SaveFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/).
- **Render**: un metodo di rendering disegna una diapositiva o una forma come immagine. I formati che sono solo renderizzati non hanno valori SaveFormat.

|**Formato**|**Descrizione**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentazione PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modello PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentazione PowerPoint 97-2003 Slide Show|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentazione PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modello PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Presentazione PowerPoint Slide Show|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentazione PowerPoint con macro|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modello PowerPoint con macro|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Presentazione PowerPoint con macro Slide Show|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentazione OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentazione OpenDocument Flat XML|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modello di presentazione OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentazione PowerPoint XML|Load|Save|`SaveFormat.Xml`; i file caricati segnalano `SourceFormat.Xml` (non esiste un valore `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (una pagina per diapositiva); `ImageFormat.Tiff` (una diapositiva)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animato, tutte le diapositive); `ImageFormat.Gif` (una diapositiva)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, un file XAML per diapositiva; non è un valore `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Immagine JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Immagine Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Load e Import**

- **Load:** Passare un percorso file o uno stream al costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Il formato viene rilevato dal contenuto; [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) fornisce impostazioni come la password. Per verificare un file prima di aprirlo, chiamare [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), che restituisce un valore [LoadFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadformat/). Per PowerPoint XML restituisce `LoadFormat.Unknown`, ma il costruttore apre comunque il file e [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSourceFormat--) restituisce `SourceFormat.Xml`. Vedere [Aprire presentazioni](/slides/it/java/open-presentation/) e [Determinare il formato originale della presentazione](/slides/it/java/detect-presentation-source-format/).
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) aggiunge una diapositiva per pagina PDF alla fine della presentazione. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) aggiunge diapositive create da HTML, e [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) le inserisce in una posizione specifica. Il costruttore Presentation non importa: genera [PptUnsupportedFormatException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptunsupportedformatexception/) per un file PDF e non converte il markup HTML in contenuto di diapositiva. Vedere [Importare presentazioni da PDF o HTML](/slides/it/java/import-presentation/).

## **Save e Render**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) scrive la presentazione nel formato indicato da un valore di [SaveFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/). Le overload che accettano anche un oggetto opzioni controllano l’output, ad esempio [PdfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/tiffoptions/), e [GifOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/gifoptions/). Le overload che accettano un array di posizioni di diapositiva, a partire da 1, scrivono solo quelle diapositive; supportano PDF, XPS, TIFF, HTML, HTML5, SWF, GIF e Markdown, ma non i formati di presentazione o PowerPoint XML. XAML ha la sua overload, [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), che accetta [IXamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloptions/). Vedere [Salvare presentazioni](/slides/it/java/save-presentation/), [Convertire presentazioni](/slides/it/java/convert-presentation/), e [Esportare presentazioni in XAML](/slides/it/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-float-float-) e [Shape.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage--) restituiscono un [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/), e [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/#save-java.lang.String-int-) lo scrive come PNG, JPEG, BMP, GIF o TIFF, selezionato con un valore di [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renderizza tutte le diapositive o quelle selezionate in un’unica operazione. [Slide.writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) e [Shape.writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) scrivono SVG, e [Slide.writeAsEmf](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) scrive EMF. Vedere [Convertire diapositive di presentazione in immagini](/slides/it/java/convert-slide/) e [Renderizzare diapositive di presentazione come immagini SVG](/slides/it/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat include anche i valori `Emf`, `Wmf`, `Icon`, `Exif` e `MemoryBmp`, ma IImage.save non produce quei formati: il file scritto contiene dati PNG. Per ottenere un'immagine EMF di una diapositiva, usare Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Posso convertire una presentazione PPT in PPTX o ODP?**

Sì. Apri il file PPT con il costruttore Presentation e salvalo con `SaveFormat.Pptx` o `SaveFormat.Odp`. Vedi [Convertire PPT in PPTX](/slides/it/java/convert-ppt-to-pptx/).

**Posso aprire un file PDF o HTML come presentazione?**

No. Il costruttore Presentation genera PptUnsupportedFormatException per un file PDF e non converte il markup HTML in diapositive. Crea o apri una presentazione, importa le pagine PDF o i contenuti HTML con i metodi della collezione di diapositive descritti sopra, quindi salvala in qualsiasi formato supportato.

**Posso caricare un’immagine PNG o SVG esportata come presentazione modificabile?**

No. L’output immagine registra l’aspetto di una diapositiva, non il suo testo, forme o grafici. Conserva la presentazione originale se devi modificarla in seguito.

**Posso salvare documenti PDF/A o PDF/UA?**

Sì. Passa un valore [PdfCompliance](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfcompliance/) a [PdfOptions.setCompliance](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b o PDF/UA.

**Posso verificare se un file è protetto da password prima di aprirlo?**

Sì. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) esamina un file senza creare un oggetto Presentation, e [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) segnala se è necessaria una password. Vedi [Presentazioni protette da password](/slides/it/java/password-protected-presentation/).
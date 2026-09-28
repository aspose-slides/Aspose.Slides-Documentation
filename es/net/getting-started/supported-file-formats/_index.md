---
title: Formatos de archivo compatibles
type: docs
weight: 96
url: /es/net/supported-file-formats/
keywords:
- formatos de archivo compatibles
- cargar presentación
- importar PDF
- importar HTML
- guardar presentación
- renderizar diapositivas
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
description: "Vea qué formatos de archivo puede Aspose.Slides for .NET cargar, importar, guardar y renderizar, y qué API lee o escribe cada uno."
---
## **Resumen**

Aspose.Slides for .NET abre y guarda presentaciones PowerPoint y OpenDocument. También importa contenido PDF y HTML a diapositivas, guarda presentaciones en formatos de documento, web e imagen, y renderiza diapositivas y formas individuales como imágenes. Este artículo enumera cada formato admitido y menciona la API que lo lee o escribe.

Ambos paquetes NuGet, Aspose.Slides.NET y Aspose.Slides.NET6.CrossPlatform, soportan los mismos formatos; consulte la [Installation](/slides/es/net/installation/) para elegir entre ellos. Para obtener una visión general de las funciones de edición, vea la [Features Overview](/slides/es/net/features-overview/).

## **Versiones compatibles de Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint para Mac
- PowerPoint para Microsoft 365 (anteriormente Office 365)

{{% alert color="info" title="Nota" %}}

Las presentaciones guardadas con PowerPoint 95 y versiones anteriores no pueden abrirse. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) reconoce un archivo PowerPoint 95 y devuelve `LoadFormat.Ppt95`, pero el constructor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) lanza [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) para él.

{{% /alert %}}

## **Formatos de archivo compatibles**

La tabla utiliza cuatro operaciones:

- **Load**: el constructor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) abre el archivo como una presentación editable.
- **Import**: un método de [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) crea diapositivas a partir del contenido del archivo y las añade a una presentación existente. El constructor Presentation no carga estos archivos como presentaciones.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) escribe la presentación en un archivo o flujo. Cada formato, excepto XAML, se selecciona mediante un valor de [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Render**: un método de renderizado dibuja una diapositiva o una forma como imagen. Los formatos que solo se renderizan no son valores de SaveFormat.

|**Formato**|**Descripción**|**Cargar / Importar**|**Guardar / Renderizar**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentación de diapositivas PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Presentación de diapositivas PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación PowerPoint con macros habilitadas|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla PowerPoint con macros habilitadas|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Presentación de diapositivas PowerPoint con macros habilitadas|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentación OpenDocument XML plano|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentación PowerPoint XML|Load|Save|`SaveFormat.Xml`; los archivos cargados devuelven `SourceFormat.Xml` (no existe valor `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portable|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de Marcado de Hipertexto|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación de Papel XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de Archivo de Imagen Etiquetada|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (una diapositiva)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercambio de Gráficos|—|Save, Render|`SaveFormat.Gif` (animado, todas las diapositivas); `ImageFormat.Gif` (una diapositiva)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeño (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de Marcado de Aplicaciones Extensible|—|Save|`Presentation.Save(IXamlOptions)`, un archivo XAML por diapositiva; no es un valor `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagen JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagen Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Metarchivo Mejorado|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vectoriales Escalables|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Cargar e Importar**

- **Cargar:** Pase una ruta de archivo o un flujo al constructor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). El formato se detecta a partir del contenido; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) suministra ajustes como la contraseña. Para comprobar un archivo antes de abrirlo, llame a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), que devuelve un valor de [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Informa `LoadFormat.Unknown` para PowerPoint XML, pero el constructor abre dicho archivo y [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) devuelve `SourceFormat.Xml`. Consulte [Open Presentations](/slides/es/net/open-presentation/) y [Determine the Original Presentation Format](/slides/es/net/detect-presentation-source-format/).
- **Importar:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) añade una diapositiva por página PDF al final de una presentación. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) agrega diapositivas creadas a partir de HTML, y [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) las inserta en una posición concreta. El constructor Presentation no importa: lanza [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) para un archivo PDF y no convierte el marcado HTML en contenido de diapositiva. Vea [Import Presentations from PDF or HTML](/slides/es/net/import-presentation/).

## **Guardar y Renderizar**

- **Guardar:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) escribe la presentación con el valor de [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Las sobrecargas que también aceptan un objeto de opciones controlan la salida, por ejemplo [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), y [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Las sobrecargas que reciben una matriz de posiciones de diapositivas, empezando por 1, guardan solo esas diapositivas; aceptan PDF, XPS, TIFF, HTML, HTML5, SWF, GIF y Markdown, pero no los formatos de presentación ni PowerPoint XML. XAML tiene su propia sobrecarga que recibe [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Consulte [Save Presentations](/slides/es/net/save-presentation/), [Convert Presentations](/slides/es/net/convert-presentation/), y [Export Presentations to XAML](/slides/es/net/export-to-xaml/).
- **Renderizar:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) y [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) devuelven un [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), y [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) lo escribe como PNG, JPEG, BMP, GIF o TIFF, seleccionado mediante un valor de [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renderiza todas o las diapositivas seleccionadas de una vez. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) y [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) generan SVG, y [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) genera EMF. Consulte [Convert Presentation Slides to Images](/slides/es/net/convert-slide/) y [Render a Slide as an SVG Image](/slides/es/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Advertencia" %}}

ImageFormat también incluye los valores `Emf`, `Wmf`, `Icon`, `Exif` y `MemoryBmp`, pero IImage.Save no produce esos formatos: el archivo que escribe contiene datos PNG. Para obtener una imagen EMF de una diapositiva, use Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**¿Puedo convertir una presentación PPT a PPTX o ODP?**

Sí. Abra el archivo PPT con el constructor Presentation y guárdelo con `SaveFormat.Pptx` o `SaveFormat.Odp`. Vea [Convert PPT to PPTX](/slides/es/net/convert-ppt-to-pptx/).

**¿Puedo abrir un archivo PDF o HTML como presentación?**

No. Cree o abra una presentación, importe las páginas PDF o el contenido HTML mediante los métodos de la colección de diapositivas descritos arriba y, a continuación, guárdela en cualquier formato compatible.

**¿Puedo cargar una imagen PNG o SVG exportada como presentación editable?**

No. La salida de imagen registra cómo se ve una diapositiva, no su texto, formas o gráficos. Conserve la presentación origen si necesita editarla más adelante.

**¿Puedo guardar documentos PDF/A o PDF/UA?**

Sí. Configure [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) a un valor de [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b o PDF/UA.

**¿Puedo comprobar si un archivo está protegido con contraseña antes de abrirlo?**

Sí. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) inspecciona un archivo sin crear un objeto Presentation, y su propiedad [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) indica si se necesita una contraseña. Vea [Password-Protect Presentations](/slides/es/net/password-protected-presentation/).

**¿Los dos paquetes NuGet admiten formatos diferentes?**

No. Aspose.Slides.NET y Aspose.Slides.NET6.CrossPlatform tienen los mismos valores de LoadFormat y SaveFormat y los mismos métodos de importación y renderizado. Diferen en las plataformas en que se ejecutan y en los requisitos de esas plataformas; consulte la [Installation](/slides/es/net/installation/).
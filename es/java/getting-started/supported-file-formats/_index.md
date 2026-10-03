---
title: Formatos de archivo compatibles
type: docs
weight: 106
url: /es/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Vea qué formatos de archivo puede cargar, importar, guardar y renderizar Aspose.Slides for Java, y qué API lee o escribe cada uno."
---
## **Visión general**

Aspose.Slides for Java abre y guarda presentaciones PowerPoint y OpenDocument. También importa contenido PDF y HTML a diapositivas, guarda presentaciones en formatos de documento, web e imagen, y renderiza diapositivas y formas individuales como imágenes. Este artículo enumera cada formato compatible y nombra la API que lo lee o lo escribe.

Para una visión general de las funciones de edición, consulte [Resumen de características](/slides/es/java/features-overview/).

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
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Nota" %}}

Las presentaciones guardadas con PowerPoint 95 y versiones anteriores no pueden abrirse. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) reconoce un archivo PowerPoint 95 y devuelve `LoadFormat.Ppt95`, pero el constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) lanza [PptUnsupportedFormatException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptunsupportedformatexception/) para él.

{{% /alert %}}

## **Formatos de archivo compatibles**

La tabla utiliza cuatro operaciones:

- **Cargar**: el constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) abre el archivo como una presentación editable.
- **Importar**: un método de [SlideCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidecollection/) crea diapositivas a partir del contenido del archivo y las añade a una presentación existente. El constructor Presentation no convierte estos archivos en diapositivas.
- **Guardar**: [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) escribe la presentación en un archivo o flujo. Todos los formatos, excepto XAML, se seleccionan con un valor de [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/).
- **Renderizar**: un método de renderizado dibuja una diapositiva o una forma como imagen. Los formatos que solo se renderizan no son valores de SaveFormat.

|**Formato**|**Descripción**|**Cargar / Importar**|**Guardar / Renderizar**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|Cargar|Guardar|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|Cargar|Guardar|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Show de diapositivas PowerPoint 97-2003|Cargar|Guardar|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|Cargar|Guardar|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|Cargar|Guardar|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Show de diapositivas PowerPoint|Cargar|Guardar|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación PowerPoint con macros|Cargar|Guardar|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla PowerPoint con macros|Cargar|Guardar|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show de diapositivas PowerPoint con macros|Cargar|Guardar|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|Cargar|Guardar|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentación OpenDocument XML plana|Cargar|Guardar|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla OpenDocument|Cargar|Guardar|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentación XML de PowerPoint|Cargar|Guardar|`SaveFormat.Xml`; los archivos cargados devuelven `SourceFormat.Xml` (no existe valor `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de documento portátil|Importar|Guardar|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de marcado de hipertexto|Importar|Guardar|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación de papel XML|—|Guardar|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de archivo de imagen etiquetado|—|Guardar, Renderizar|`SaveFormat.Tiff` (una página por diapositiva); `ImageFormat.Tiff` (una diapositiva)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de intercambio de gráficos|—|Guardar, Renderizar|`SaveFormat.Gif` (animado, todas las diapositivas); `ImageFormat.Gif` (una diapositiva)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato web pequeño (Flash)|—|Guardar|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Guardar|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de marcado de aplicaciones extensible|—|Guardar|`Presentation.save(IXamlOptions)`, un archivo XAML por diapositiva; no es un valor `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de red portátiles|—|Renderizar|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagen JPEG|—|Renderizar|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagen bitmap|—|Renderizar|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Metarchivo mejorado|—|Renderizar|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos vectoriales escalables|—|Renderizar|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Cargar e Importar**

- **Cargar:** Pase una ruta de archivo o un flujo al constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). El formato se detecta a partir del contenido; [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/) permite especificar ajustes como una contraseña. Para comprobar un archivo antes de abrirlo, llame a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), que devuelve un valor de [LoadFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadformat/). Informa `LoadFormat.Unknown` para PowerPoint XML, pero el constructor abre ese tipo de archivo y [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--) devuelve entonces `SourceFormat.Xml`. Consulte [Open Presentations](/slides/es/java/open-presentation/) y [Determine the Original Presentation Format](/slides/es/java/detect-presentation-source-format/).
- **Importar:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) añade una diapositiva por página PDF al final de una presentación. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) añade diapositivas creadas a partir de HTML, y [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) las inserta en una posición determinada. El constructor Presentation no importa: lanza [PptUnsupportedFormatException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptunsupportedformatexception/) para un archivo PDF y no convierte el marcado HTML en contenido de diapositiva. Vea [Import Presentations from PDF or HTML](/slides/es/java/import-presentation/).

## **Guardar y Renderizar**

- **Guardar:** [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) escribe la presentación en el formato indicado por un valor de [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/). Las sobrecargas que también aceptan un objeto de opciones controlan la salida, por ejemplo [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/es/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/), y [GifOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/gifoptions/). Las sobrecargas que reciben una matriz de posiciones de diapositiva (empezando en 1) escriben solo esas diapositivas; aceptan PDF, XPS, TIFF, HTML, HTML5, SWF, GIF y Markdown, pero no los formatos de presentación ni PowerPoint XML. XAML tiene su propia sobrecarga, [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), que acepta [IXamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloptions/). Consulte [Save Presentations](/slides/es/java/save-presentation/), [Convert Presentations](/slides/es/java/convert-presentation/), y [Export Presentations to XAML](/slides/es/java/export-to-xaml/).
- **Renderizar:** [Slide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#getImage-float-float-) y [Shape.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getImage--) devuelven un [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/), y [IImage.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/#save-java.lang.String-int-) lo escribe como PNG, JPEG, BMP, GIF o TIFF, seleccionado mediante un valor de [ImageFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renderiza todas o varias diapositivas a la vez. [Slide.writeAsSvg](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) y [Shape.writeAsSvg](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) escriben SVG, y [Slide.writeAsEmf](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) escribe EMF. Vea [Convert Presentation Slides to Images](/slides/es/java/convert-slide/) y [Render Presentation Slides as SVG Images](/slides/es/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Advertencia" %}}

ImageFormat también incluye los valores `Emf`, `Wmf`, `Icon`, `Exif` y `MemoryBmp`, pero IImage.save no produce esos formatos: el archivo generado contiene datos PNG. Para obtener una imagen EMF de una diapositiva, utilice Slide.writeAsEmf.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo convertir una presentación PPT a PPTX o ODP?**

Sí. Abra el archivo PPT con el constructor Presentation y guárdelo con `SaveFormat.Pptx` o `SaveFormat.Odp`. Consulte [Convert PPT to PPTX](/slides/es/java/convert-ppt-to-pptx/).

**¿Puedo abrir un archivo PDF o HTML como presentación?**

No. El constructor Presentation lanza PptUnsupportedFormatException para un archivo PDF y no convierte el marcado HTML en diapositivas. Cree o abra una presentación, importe las páginas PDF o el contenido HTML con los métodos de la colección de diapositivas descritos arriba y, a continuación, guárdela en cualquier formato compatible.

**¿Puedo cargar una imagen PNG o SVG exportada como presentación editable?**

No. La salida de imagen registra cómo se ve una diapositiva, no su texto, formas o gráficos. Conserva la presentación original si necesitas editarla posteriormente.

**¿Puedo guardar documentos PDF/A o PDF/UA?**

Sí. Pase un valor de [PdfCompliance](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfcompliance/) a [PdfOptions.setCompliance](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b o PDF/UA.

**¿Puedo comprobar si un archivo está protegido con contraseña antes de abrirlo?**

Sí. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) inspecciona un archivo sin crear un objeto Presentation, y [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) indica si se necesita una contraseña. Consulte [Password‑Protect Presentations](/slides/es/java/password-protected-presentation/).
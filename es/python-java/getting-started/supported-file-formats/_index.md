---
title: Formatos de archivo compatibles
type: docs
weight: 30
url: /es/python-java/supported-file-formats/
keywords:
- formatos de archivo compatibles
- formatos de presentación
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- imágenes de diapositivas
- Python
- Aspose.Slides for Python via Java
description: "Explore los formatos de presentación, documento, web e imagen que Aspose.Slides for Python via Java puede cargar, importar, guardar y exportar."
---
## **Visión general**

Aspose.Slides for Python via Java lee y escribe presentaciones PowerPoint y OpenDocument. También importa contenido PDF y HTML a diapositivas y exporta presentaciones o diapositivas individuales a formatos de documento, web e imagen.

La tabla siguiente diferencia la carga de presentaciones de la importación de contenido y el renderizado de diapositivas. Para obtener una visión general de las capacidades de edición y renderizado, consulte [Resumen de características](/slides/es/python-java/features-overview/).

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
- PowerPoint para Microsoft 365 (anteriormente Office 365)

## **Formatos de archivo compatibles**

La tabla siguiente enumera los formatos de entrada y salida compatibles. **Load / Import** incluye abrir archivos de presentación e importar contenido PDF o HTML. **Save / Export** incluye guardar presentaciones y renderizar diapositivas a imágenes. Un guion indica que la operación correspondiente no está soportada como operación de conversión de presentación.

|**Formato**|**Descripción**|**Load / Import**|**Save / Export**|**Observaciones**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentación de diapositivas PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Show PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación de PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show con macros habilitadas PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla de PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Formato OpenDocument empaquetado.|
|FODP|Presentación OpenDocument XML plano|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Almacena la presentación como un único documento XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla de presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de archivo de imagen etiquetado|—|{{< emoticons/tick >}}|Admite salida multipágina.|
|[EMF](https://docs.fileformat.com/image/emf/)|Metarchivo mejorado|—|{{< emoticons/tick >}}|Exporta diapositivas individuales como imágenes vectoriales.|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de documento portátil|Import|{{< emoticons/tick >}}|Importa páginas PDF como diapositivas; exporta presentaciones a PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación de papel XML|—|{{< emoticons/tick >}}|Salida de documento de diseño fijo.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Imagen JPEG|—|{{< emoticons/tick >}}|Renderiza diapositivas individuales como imágenes ráster.|
|[PNG](https://docs.fileformat.com/image/png/)|Imagen PNG|—|{{< emoticons/tick >}}|Renderiza diapositivas individuales como imágenes ráster.|
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de intercambio de gráficos|—|{{< emoticons/tick >}}|Salida de imagen.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Imagen bitmap|—|{{< emoticons/tick >}}|Renderiza diapositivas individuales como imágenes ráster.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos vectoriales escalables|—|{{< emoticons/tick >}}|Exporta diapositivas individuales como imágenes vectoriales.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato web pequeño|—|{{< emoticons/tick >}}|Salida Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de marcas de hipertexto|Import|{{< emoticons/tick >}}|Importa contenido HTML como diapositivas; admite exportación a HTML y HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de marcado de aplicaciones extensible|—|{{< emoticons/tick >}}|Exporta el contenido de la presentación como XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exporta el contenido de la presentación a Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Presentación XML de PowerPoint|—|{{< emoticons/tick >}}|Salida XML específica de PowerPoint, no XML arbitrario.|

## **Notas de importación y exportación**

- **Importación de PDF y HTML:** Utilice [SlideCollection.addFromPdf](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#addfrompdf) o [SlideCollection.addFromHtml](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#addfromhtml) para crear diapositivas a partir del contenido fuente y añadirlas a una presentación.
- **Salida de presentación:** [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) enumera los formatos de guardado de presentación disponibles, incluidas opciones de exportación separadas para HTML y HTML5.
- **Salida de imagen:** Exportar una diapositiva a una imagen genera una representación visual de esa diapositiva. La columna de entrada no describe si una imagen puede insertarse en una presentación.

## **Preguntas frecuentes**

**¿Puedo convertir una presentación PPT a PPTX o ODP?**

Sí. PPT es compatible como formato de entrada, y tanto PPTX como ODP son compatibles como formatos de salida. Los resultados de la conversión dependen de las características disponibles en el formato de destino.

**¿La importación de PDF o HTML abre el origen como un archivo PowerPoint?**

No. La importación crea diapositivas a partir de páginas PDF o contenido HTML. Luego puede guardar la presentación resultante en un formato de presentación compatible.

**¿Puedo cargar un PNG o SVG exportado como una presentación editable?**

No. Estas exportaciones representan la apariencia de la diapositiva. Mantenga la presentación original cuando necesite editar su texto, formas, gráficos y demás objetos más adelante.
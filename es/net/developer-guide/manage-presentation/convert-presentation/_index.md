---
title: Convertir presentaciones a varios formatos en .NET
linktitle: Convertir presentación
type: docs
weight: 70
url: /es/net/convert-presentation/
keywords:
- convertir presentación
- exportar presentación
- PPT a PPTX
- PPTX a PPT
- ODP a PPTX
- PPT a PDF
- PPTX a PDF
- ODP a PDF
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- PPT a PNG
- PPTX a PNG
- ODP a PNG
- PPTX a JPG
- ODP a JPG
- PPT a XPS
- PPTX a XPS
- ODP a XPS
- PPT a TIFF
- PPTX a TIFF
- ODP a TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a PPTX, PDF, HTML, imágenes, XPS, TIFF y más con Aspose.Slides para .NET."
---
## **Resumen**

Aspose.Slides for .NET puede cargar presentaciones de PowerPoint y OpenDocument y guardarlas o renderizarlas en muchos otros formatos sin necesidad de Microsoft PowerPoint, OpenOffice o LibreOffice. Puede convertir archivos PPT heredados a PPTX modernos, exportar presentaciones a documentos de diseño fijo como PDF y XPS, publicar diapositivas como HTML, o renderizar diapositivas como archivos de imagen para vistas previas, miniaturas y archivos.

La mayoría de las conversiones de documentos siguen el mismo flujo de trabajo general: cargar el archivo de origen, elegir el formato de salida requerido y aplicar opciones específicas del formato cuando sea necesario. Para los formatos de imagen, cada diapositiva se renderiza por separado y luego se guarda como una imagen raster o vectorial. Los artículos dedicados enlazados a continuación proporcionan los detalles de implementación para cada caso.

## **Elija un escenario de conversión**

Utilice los artículos a continuación para obtener ejemplos completos en C# y opciones específicas de formato.

| Escenario | Úselo cuando necesite | Artículo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizar archivos PPT heredados, normalizar archivos PPTX existentes o convertir presentaciones OpenDocument a PowerPoint PPTX. | [Convertir PPT a PPTX](/slides/es/net/convert-ppt-to-pptx/), [Convertir ODP a PPTX](/slides/es/net/convert-odp-to-pptx/), [Guardar presentaciones](/slides/es/net/save-presentation/) |
| PPTX a PPT | Guardar una presentación moderna de PowerPoint en el formato binario PPT antiguo para compatibilidad con flujos de trabajo anteriores. | [Convertir PPTX a PPT](/slides/es/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP a PDF | Crear documentos portátiles, buscables y de diseño fijo para compartir, imprimir o archivar. | [Convertir PowerPoint a PDF](/slides/es/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP a PDF con notas | Exportar las notas del presentador junto con el contenido de las diapositivas. | [Convertir PowerPoint a PDF con notas](/slides/es/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP a HTML | Publicar presentaciones como páginas HTML y controlar imágenes, fuentes, notas y opciones de diseño responsivo. | [Convertir PowerPoint a HTML](/slides/es/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP a HTML5 | Exportar diapositivas a HTML5 para visualización en el navegador con formato e interactividad preservados. | [Convertir presentaciones a HTML5](/slides/es/net/export-to-html5/) |
| PPT/PPTX/ODP a PNG | Renderizar cada diapositiva a una imagen PNG para vistas previas, miniaturas o salida web. | [Convertir PowerPoint a PNG](/slides/es/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP a JPG | Renderizar diapositivas a imágenes JPG y controlar dimensiones y calidad de la imagen. | [Convertir PowerPoint a JPG](/slides/es/net/convert-powerpoint-to-jpg/) |
| Diapositiva a SVG | Exportar diapositivas individuales como gráficos vectoriales escalables. | [Renderizar diapositiva como SVG](/slides/es/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP a XPS | Generar documentos XPS de diseño fijo. | [Convertir PowerPoint a XPS](/slides/es/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP a TIFF | Guardar una presentación como archivo TIFF multipágina para impresión, escaneo, fax o flujos de trabajo de archivo. | [Convertir PowerPoint a TIFF](/slides/es/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP a TIFF con notas | Guardar diapositivas con notas del presentador en TIFF. | [Convertir PowerPoint a TIFF con notas](/slides/es/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX a Word | Convertir diapositivas a un documento Word cuando necesite una salida estilo documento. | [Convertir PowerPoint a Word](/slides/es/net/convert-powerpoint-to-word/) |
| PPT/PPTX a Markdown | Extraer el contenido de la presentación a Markdown para documentación y flujos de trabajo basados en texto. | [Convertir PowerPoint a Markdown](/slides/es/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX a GIF animado | Crear un GIF animado a partir de las diapositivas. | [Convertir PowerPoint a GIF animado](/slides/es/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX a video | Crear un flujo de exportación a video a partir de las diapositivas de la presentación. | [Convertir PowerPoint a video](/slides/es/net/convert-powerpoint-to-video/) |
| Presentación a XAML | Exportar diapositivas a XAML para escenarios de UI en .NET. | [Exportar presentaciones a XAML](/slides/es/net/export-to-xaml/) |

Para una lista más amplia de formatos de entrada y salida, vea [Formatos de archivo compatibles](/slides/es/net/supported-file-formats/).

## **Conversión de PowerPoint y OpenDocument**

Aspose.Slides for .NET admite la conversión desde formatos de presentación de uso común como PPT, PPTX, PPS, PPSX, POT, POTX y ODP. La misma API de conversión se utiliza para archivos PowerPoint y OpenDocument, por lo que un flujo de trabajo que guarda un archivo PPTX en PDF normalmente puede aplicarse a un archivo ODP cambiando solo el archivo de entrada.

Al convertir archivos ODP, recuerde que las aplicaciones PowerPoint y OpenDocument no admiten todas las características de diseño y formato de la misma manera exacta. Si un archivo ODP se creó en LibreOffice o OpenOffice Impress, revise la salida y utilice las opciones descritas en [Convertir presentaciones OpenDocument](/slides/es/net/convert-openoffice-odp/) cuando necesite orientación específica del formato.

## **Conversión de PPT a PPTX**

PPT es el formato binario antiguo de PowerPoint, mientras que PPTX es el formato moderno Office Open XML. Aspose.Slides for .NET admite la conversión de alta fidelidad de PPT a PPTX preservando estructuras de presentación complejas como maestros, diseños, diapositivas, gráficos, formas agrupadas, marcadores de posición, marcos de texto, texturas y rellenos de imagen.

Para más detalles, consulte [Convertir PPT a PPTX](/slides/es/net/convert-ppt-to-pptx/) y [PPT vs PPTX](/slides/es/net/ppt-vs-pptx/).

## **Exportación de diseño fijo**

PDF, XPS y TIFF son útiles cuando la salida debe verse igual en todos los dispositivos y no debe editarse como una presentación. Utilice [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions/) y [TiffOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/) para controlar cumplimiento, diapositivas ocultas, notas, calidad de imagen, compresión, formato de píxel y tamaño de salida.

## **Exportación a HTML e imagen**

La exportación a HTML y HTML5 es útil para visualización en navegadores, publicación web y compartir de forma ligera. La exportación de imágenes es útil cuando cada diapositiva debe convertirse en una vista previa, miniatura o recurso raster separado. Utilice los artículos de PNG, JPG y SVG para obtener directrices de renderizado específicas del formato.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint para convertir presentaciones?**

No. Aspose.Slides for .NET es una biblioteca independiente y no requiere Microsoft PowerPoint ni automatización de Office.

**¿Puedo convertir en lote muchas presentaciones?**

Sí. Cargue cada presentación, guárdela en el formato requerido y libere el objeto `Presentation` después del procesamiento. Para procesamiento paralelo, use instancias de presentación separadas y siga la guía de [multithreading](/slides/es/net/multithreading/).

**¿Puedo exportar solo diapositivas seleccionadas?**

Sí. Varios métodos de exportación le permiten pasar índices de diapositivas o renderizar diapositivas individuales, según el formato de salida. Consulte el artículo dedicado al formato objetivo.

**¿Puedo incluir diapositivas ocultas al exportar a PDF o XPS?**

Sí. Use la propiedad `ShowHiddenSlides` en [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) o [XpsOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions/).

**¿Puedo crear salida PDF/A?**

Sí. Las configuraciones de cumplimiento de PDF están disponibles a través de [PdfOptions.Compliance](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/compliance/) y [PdfCompliance](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfcompliance/).

**¿Cómo se gestionan las fuentes durante la conversión?**

Aspose.Slides puede usar fuentes incrustadas, fuentes de reserva y configuraciones de sustitución de fuentes. Vea [Fuente incrustada](/slides/es/net/embedded-font/), [Fuente de reserva](/slides/es/net/fallback-font/) y [Sustitución de fuentes](/slides/es/net/font-substitution/).
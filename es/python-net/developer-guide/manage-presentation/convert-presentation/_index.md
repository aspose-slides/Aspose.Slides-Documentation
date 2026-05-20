---
title: Convertir presentaciones a varios formatos en Python
linktitle: Convertir presentaciones
type: docs
weight: 70
url: /es/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint y OpenDocument a PPTX, PDF, HTML, imágenes, XPS, TIFF y más con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Aspose.Slides for Python via .NET puede cargar presentaciones de PowerPoint y OpenDocument y guardarlas o renderizarlas en muchos otros formatos sin Microsoft PowerPoint, OpenOffice o LibreOffice. Puede convertir archivos PPT heredados a PPTX modernos, exportar presentaciones a documentos de diseño fijo como PDF y XPS, publicar diapositivas como HTML, o renderizar diapositivas como archivos de imagen para vistas previas, miniaturas y archivos.

La mayoría de las conversiones de documentos utilizan el mismo flujo de trabajo general: cargar el archivo de origen, elegir el formato de salida requerido y aplicar opciones específicas del formato cuando sea necesario. Para los formatos de imagen, cada diapositiva se renderiza por separado y luego se guarda como una imagen raster o vectorial. Los artículos dedicados enlazados a continuación proporcionan los detalles de implementación para cada caso.

## **Elija un escenario de conversión**

Utilice los artículos a continuación para obtener ejemplos completos en Python y opciones específicas del formato.

| Escenario | Úselo cuando necesite | Artículo |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizar archivos PPT heredados, normalizar archivos PPTX existentes, o convertir presentaciones OpenDocument a PowerPoint PPTX. | [Convertir PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/), [Convertir ODP a PPTX](/slides/es/python-net/convert-odp-to-pptx/), [Guardar presentaciones](/slides/es/python-net/save-presentation/) |
| PPTX to PPT | Guardar una presentación PowerPoint moderna en el formato binario PPT más antiguo para compatibilidad con flujos de trabajo más viejos. | [Convertir PPTX a PPT](/slides/es/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Crear documentos portátiles, buscables y de diseño fijo para compartir, imprimir o archivar. | [Convertir PowerPoint a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportar las notas del orador junto con el contenido de la diapositiva. | [Convertir PowerPoint a PDF con notas](/slides/es/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publicar presentaciones como páginas HTML y controlar imágenes, fuentes, notas y opciones de diseño responsivo. | [Convertir PowerPoint a HTML](/slides/es/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportar diapositivas a HTML5 para visualización en navegador con formato e interactividad preservados. | [Convertir presentaciones a HTML5](/slides/es/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderizar cada diapositiva a una imagen PNG para vistas previas, miniaturas o salida web. | [Convertir PowerPoint a PNG](/slides/es/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderizar diapositivas a imágenes JPG y controlar dimensiones y calidad de la imagen. | [Convertir PowerPoint a JPG](/slides/es/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportar diapositivas individuales como gráficos vectoriales escalables. | [Renderizar diapositiva como SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generar documentos XPS de diseño fijo. | [Convertir PowerPoint a XPS](/slides/es/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Guardar una presentación como un archivo TIFF multipágina para impresión, escaneo, fax o flujos de archivo. | [Convertir PowerPoint a TIFF](/slides/es/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Guardar diapositivas con notas del orador en TIFF. | [Convertir PowerPoint a TIFF con notas](/slides/es/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | Convertir diapositivas a un documento Word cuando necesita una salida estilo documento. | [Convertir PowerPoint a Word](/slides/es/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | Extraer el contenido de la presentación a Markdown para documentación y flujos de trabajo basados en texto. | [Convertir PowerPoint a Markdown](/slides/es/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | Crear un GIF animado a partir de diapositivas. | [Convertir PowerPoint a GIF animado](/slides/es/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | Construir un flujo de exportación a vídeo a partir de diapositivas de la presentación. | [Convertir PowerPoint a video](/slides/es/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportar diapositivas a XAML para escenarios de UI en Python o .NET. | [Exportar presentaciones a XAML](/slides/es/python-net/export-to-xaml/) |

Para una lista más amplia de formatos de entrada y salida, consulte [Formatos de archivo compatibles](/slides/es/python-net/supported-file-formats/).

## **Conversión de PowerPoint y OpenDocument**

Aspose.Slides for Python via .NET admite la conversión desde formatos de presentación de uso frecuente como PPT, PPTX, PPS, PPSX, POT, POTX y ODP. La misma API de conversión se utiliza para archivos PowerPoint y OpenDocument, por lo que un flujo de trabajo que guarda un archivo PPTX en PDF normalmente puede aplicarse a un archivo ODP cambiando solo el archivo de entrada.

Al convertir archivos ODP, recuerde que las aplicaciones PowerPoint y OpenDocument no admiten cada característica de diseño y formato de la misma manera exacta. Si un archivo ODP se creó en LibreOffice o OpenOffice Impress, revise el resultado y utilice las opciones descritas en [Convertir presentaciones OpenDocument](/slides/es/python-net/convert-openoffice-odp/) cuando necesite orientación específica del formato.

## **Conversión de PPT a PPTX**

PPT es el formato binario más antiguo de PowerPoint, mientras que PPTX es el formato moderno Office Open XML. Aspose.Slides for Python via .NET admite una conversión de PPT a PPTX de alta fidelidad preservando estructuras complejas de la presentación como maestros, diseños, diapositivas, gráficos, formas agrupadas, marcadores de posición, marcos de texto, texturas y rellenos de imágenes.

Para más detalles, consulte [Convertir PPT a PPTX](/slides/es/python-net/convert-ppt-to-pptx/) y [PPT vs PPTX](/slides/es/python-net/ppt-vs-pptx/).

## **Exportación de diseño fijo**

PDF, XPS y TIFF son útiles cuando la salida debe verse igual en todos los dispositivos y no debe editarse como una presentación. Los artículos dedicados a PDF, XPS y TIFF explican cómo controlar el cumplimiento, diapositivas ocultas, notas, calidad de imagen, compresión, formato de píxel y tamaño de salida.

## **Exportación a HTML e Imagen**

La exportación a HTML y HTML5 es útil para la visualización en navegadores, publicación web y compartición ligera. La exportación de imágenes es útil cuando cada diapositiva debe convertirse en una vista previa, miniatura o recurso rasterizado independiente. Utilice los artículos sobre PNG, JPG y SVG para obtener orientación sobre el renderizado específico de cada formato.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint para convertir presentaciones?**

No. Aspose.Slides for Python via .NET es una biblioteca independiente y no requiere Microsoft PowerPoint ni automatización de Office.

**¿Puedo convertir en lote muchas presentaciones?**

Sí. Cargue cada presentación, guárdela en el formato requerido y libere el objeto de la presentación después del procesamiento. Para procesamiento en paralelo, utilice instancias de presentación separadas y siga la guía de [multihilo](/slides/es/python-net/multithreading/).

**¿Puedo exportar solo diapositivas seleccionadas?**

Sí. Varios métodos de exportación le permiten pasar índices de diapositivas o renderizar diapositivas individuales, según el formato de salida. Consulte el artículo dedicado al formato de destino.

**¿Puedo incluir diapositivas ocultas al exportar a PDF o XPS?**

Sí. Utilice la configuración de exportación de diapositivas ocultas descrita en los artículos de conversión de [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) y [XPS](/slides/es/python-net/convert-powerpoint-to-xps/).

**¿Puedo crear salida PDF/A?**

Sí. Las configuraciones de cumplimiento PDF están disponibles para la exportación a PDF. Consulte [Convertir PowerPoint a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) para más detalles.

**¿Cómo se gestionan las fuentes durante la conversión?**

Aspose.Slides puede usar fuentes incrustadas, fuente de reserva y configuraciones de sustitución de fuentes. Consulte [Fuente incrustada](/slides/es/python-net/embedded-font/), [Fuente de reserva](/slides/es/python-net/fallback-font/) y [Sustitución de fuentes](/slides/es/python-net/font-substitution/).
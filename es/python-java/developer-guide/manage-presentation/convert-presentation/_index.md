---
title: Convertir presentaciones a varios formatos en Python
linktitle: Convertir presentación
type: docs
weight: 70
url: /es/python-java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a PPTX, PDF, HTML, imágenes, XPS, TIFF y más con Aspose.Slides para Python via Java."
---
## **Visión general**

Aspose.Slides for Python via Java puede cargar presentaciones de PowerPoint y OpenDocument y guardarlas o renderizarlas en muchos otros formatos sin Microsoft PowerPoint, OpenOffice o LibreOffice. Puede convertir archivos PPT heredados a PPTX modernos, exportar presentaciones a documentos de diseño fijo como PDF y XPS, publicar diapositivas como HTML, o renderizar diapositivas como archivos de imagen para vistas previas, miniaturas y archivos.

La mayoría de las conversiones de documentos siguen el mismo flujo de trabajo general: cargar el archivo de origen, elegir el formato de salida requerido y aplicar opciones específicas del formato cuando sea necesario. Para los formatos de imagen, cada diapositiva se renderiza por separado y luego se guarda como una imagen raster o vectorial. Los artículos dedicados enlazados a continuación proporcionan los detalles de implementación para cada caso.

## **Elija un escenario de conversión**

Utilice los artículos a continuación para obtener ejemplos completos en Python y opciones específicas del formato.

| Escenario | Úselo cuando necesite | Artículo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizar archivos PPT heredados, normalizar archivos PPTX existentes, o convertir presentaciones OpenDocument a PowerPoint PPTX. | [Convert PPT to PPTX](/slides/es/python-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/es/python-java/convert-odp-to-pptx/), [Save Presentations](/slides/es/python-java/save-presentation/) |
| PPTX a PPT | Guardar una presentación moderna de PowerPoint en el formato binario PPT antiguo para compatibilidad con flujos de trabajo más viejos. | [Convert PPTX to PPT](/slides/es/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP a PDF | Crear documentos portátiles, buscables y de diseño fijo para compartir, imprimir o archivar. | [Convert PowerPoint to PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP a PDF con notas | Exportar las notas del orador junto con el contenido de la diapositiva. | [Convert PowerPoint to PDF with Notes](/slides/es/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP a HTML | Publicar presentaciones como páginas HTML y controlar imágenes, fuentes, notas y opciones de diseño responsivo. | [Convert PowerPoint to HTML](/slides/es/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP a HTML5 | Exportar diapositivas a HTML5 para visualización en el navegador con formato e interactividad preservados. | [Convert Presentations to HTML5](/slides/es/python-java/export-to-html5/) |
| PPT/PPTX/ODP a PNG | Renderizar cada diapositiva a una imagen PNG para vistas previas, miniaturas o salida web. | [Convert PowerPoint to PNG](/slides/es/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP a JPG | Renderizar diapositivas a imágenes JPG y controlar dimensiones y calidad. | [Convert PowerPoint to JPG](/slides/es/python-java/convert-powerpoint-to-jpg/) |
| Diapositiva a SVG | Exportar diapositivas individuales como gráficos vectoriales escalables. | [Render Slide as SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP a XPS | Generar documentos XPS de diseño fijo. | [Convert PowerPoint to XPS](/slides/es/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP a TIFF | Guardar una presentación como archivo TIFF multipágina para impresión, escaneado, fax o flujos de trabajo de archivo. | [Convert PowerPoint to TIFF](/slides/es/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP a TIFF con notas | Guardar diapositivas con notas del orador en TIFF. | [Convert PowerPoint to TIFF with Notes](/slides/es/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX a Word | Convertir diapositivas a un documento Word cuando necesite salida estilo documento. | [Convert PowerPoint to Word](/slides/es/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX a Markdown | Extraer el contenido de la presentación a Markdown para documentación y flujos de trabajo basados en texto. | [Convert PowerPoint to Markdown](/slides/es/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP a XML | Crear una presentación PowerPoint XML basada en texto para inspección, comparación, solución de problemas o flujos de trabajo basados en XML. | [Convert PowerPoint to XML](/slides/es/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX a GIF animado | Crear un GIF animado a partir de las diapositivas. | [Convert PowerPoint to Animated GIF](/slides/es/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX a video | Construir un flujo de trabajo de exportación a video a partir de diapositivas de presentación. | [Convert PowerPoint to Video](/slides/es/python-java/convert-powerpoint-to-video/) |
| Presentación a XAML | Exportar diapositivas a XAML para su uso en aplicaciones WPF. | [Export Presentations to XAML](/slides/es/python-java/export-to-xaml/) |

Para una lista más amplia de formatos de entrada y salida, consulte [Supported File Formats](/slides/es/python-java/supported-file-formats/).

## **Conversión de PowerPoint y OpenDocument**

Aspose.Slides for Python via Java admite la conversión desde formatos de presentación de uso común como PPT, PPTX, PPS, PPSX, POT, POTX y ODP. La misma API de conversión se utiliza para archivos PowerPoint y OpenDocument, de modo que un flujo de trabajo que guarda un archivo PPTX en PDF generalmente puede aplicarse a un archivo ODP cambiando solo el archivo de entrada.

Al convertir archivos ODP, recuerde que las aplicaciones PowerPoint y OpenDocument no admiten todas las características de diseño y formato de la misma manera exacta. Si un archivo ODP se creó en LibreOffice o OpenOffice Impress, revise la salida y utilice las opciones descritas en [Convert OpenDocument Presentations](/slides/es/python-java/convert-openoffice-odp/) cuando necesite orientación específica del formato.

## **Conversión de PPT a PPTX**

PPT es el formato binario antiguo de PowerPoint, mientras que PPTX es el formato moderno Office Open XML. Aspose.Slides for Python via Java admite la conversión de alta fidelidad de PPT a PPTX preservando estructuras complejas de la presentación como maestros, diseños, diapositivas, gráficos, formas agrupadas, marcadores de posición, marcos de texto, texturas y rellenos de imagen.

Para más detalles, consulte [Convert PPT to PPTX](/slides/es/python-java/convert-ppt-to-pptx/) y [PPT vs PPTX](/slides/es/python-java/ppt-vs-pptx/).

## **Exportación de diseño fijo**

PDF, XPS y TIFF son útiles cuando la salida debe verse idéntica en diferentes dispositivos y no debe editarse como una presentación. Los artículos dedicados a PDF, XPS y TIFF explican cómo controlar la conformidad, diapositivas ocultas, notas, calidad de imagen, compresión, formato de píxel y tamaño de salida.

## **Exportación a HTML e imágenes**

La exportación a HTML y HTML5 es útil para la visualización en navegadores, publicación web y uso compartido ligero. La exportación de imágenes es útil cuando cada diapositiva debe convertirse en una vista previa, miniatura o recurso raster separado. Utilice los artículos PNG, JPG y SVG para obtener guías específicas de renderizado por formato.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint para convertir presentaciones?**

No. Aspose.Slides for Python via Java es una biblioteca independiente y no requiere Microsoft PowerPoint ni automatización de Office.

**¿Puedo convertir en lote muchas presentaciones?**

Sí. Cargue cada presentación, guárdela en el formato requerido y libere el objeto de presentación después del procesamiento. Para procesamiento en paralelo, use instancias de presentación independientes y siga la guía de [multithreading](/slides/es/python-java/multithreading/).

**¿Puedo exportar solo diapositivas seleccionadas?**

Sí. Varios métodos de exportación le permiten pasar índices de diapositivas o renderizar diapositivas individuales, según el formato de salida. Consulte el artículo dedicado al formato de destino.

**¿Puedo incluir diapositivas ocultas al exportar a PDF o XPS?**

Sí. Utilice la configuración de exportación de diapositivas ocultas descrita en los artículos de conversión de [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) y [XPS](/slides/es/python-java/convert-powerpoint-to-xps/).

**¿Puedo crear salida PDF/A?**

Sí. Las configuraciones de conformidad PDF están disponibles para la exportación a PDF. Consulte [Convert PowerPoint to PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) para más detalles.

**¿Cómo se gestionan las fuentes durante la conversión?**

Aspose.Slides puede usar fuentes incrustadas, sustitución de fuentes y configuraciones de fuente alternativa. Consulte [Embedded Font](/slides/es/python-java/embedded-font/), [Fallback Font](/slides/es/python-java/fallback-font/) y [Font Substitution](/slides/es/python-java/font-substitution/).
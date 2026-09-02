---
title: Convertir presentaciones a varios formatos en Java
linktitle: Convertir presentación
type: docs
weight: 70
url: /es/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Convierta presentaciones PowerPoint y OpenDocument a PPTX, PDF, HTML, imágenes, XPS, TIFF y más con Aspose.Slides para Java."
---
## **Descripción general**

Aspose.Slides for Java puede cargar presentaciones PowerPoint y OpenDocument y guardarlas o renderizarlas a muchos otros formatos sin necesidad de Microsoft PowerPoint, OpenOffice o LibreOffice. Puede convertir archivos PPT heredados a PPTX modernos, exportar presentaciones a documentos de diseño fijo como PDF y XPS, publicar diapositivas como HTML, o renderizar diapositivas como archivos de imagen para vistas previas, miniaturas y archivos.

La mayoría de las conversiones de documentos siguen el mismo flujo de trabajo general: cargar el archivo de origen, elegir el formato de salida requerido y aplicar opciones específicas del formato cuando sea necesario. Para los formatos de imagen, cada diapositiva se renderiza por separado y luego se guarda como una imagen raster o vectorial. Los artículos dedicados enlazados a continuación proporcionan los detalles de implementación para cada caso.

## **Elija un escenario de conversión**

Use los artículos a continuación para ejemplos Java completos y opciones específicas de formato.

| Escenario | Utilícelo cuando necesite | Artículo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizar archivos PPT heredados, normalizar archivos PPTX existentes o convertir presentaciones OpenDocument a PowerPoint PPTX. | [Convertir PPT a PPTX](/slides/es/java/convert-ppt-to-pptx/), [Convertir ODP a PPTX](/slides/es/java/convert-odp-to-pptx/), [Guardar presentaciones](/slides/es/java/save-presentation/) |
| PPTX a PPT | Guardar una presentación PowerPoint moderna en el formato binario PPT antiguo para compatibilidad con flujos de trabajo más antiguos. | [Convertir PPTX a PPT](/slides/es/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP a PDF | Crear documentos portátiles, indexables y de diseño fijo para compartir, imprimir o archivar. | [Convertir PowerPoint a PDF](/slides/es/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP a PDF con notas | Exportar notas del ponente junto con el contenido de la diapositiva. | [Convertir PowerPoint a PDF con notas](/slides/es/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP a HTML | Publicar presentaciones como páginas HTML y controlar imágenes, fuentes, notas y opciones de diseño responsivo. | [Convertir PowerPoint a HTML](/slides/es/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP a HTML5 | Exportar diapositivas a HTML5 para visualización basada en navegador con formato e interactividad preservados. | [Convertir presentaciones a HTML5](/slides/es/java/export-to-html5/) |
| PPT/PPTX/ODP a PNG | Renderizar cada diapositiva a una imagen PNG para vistas previas, miniaturas o salida web. | [Convertir PowerPoint a PNG](/slides/es/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP a JPG | Renderizar diapositivas a imágenes JPG y controlar dimensiones y calidad de la imagen. | [Convertir PowerPoint a JPG](/slides/es/java/convert-powerpoint-to-jpg/) |
| Diapositiva a SVG | Exportar diapositivas individuales como gráficos vectoriales escalables. | [Renderizar diapositiva como SVG](/slides/es/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP a XPS | Generar documentos XPS de diseño fijo. | [Convertir PowerPoint a XPS](/slides/es/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP a TIFF | Guardar una presentación como un archivo TIFF multipágina para impresión, escaneo, fax o flujos de trabajo de archivado. | [Convertir PowerPoint a TIFF](/slides/es/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP a TIFF con notas | Guardar diapositivas con notas del ponente en TIFF. | [Convertir PowerPoint a TIFF con notas](/slides/es/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX a Word | Convertir diapositivas a un documento Word cuando necesite una salida de estilo documento. | [Convertir PowerPoint a Word](/slides/es/java/convert-powerpoint-to-word/) |
| PPT/PPTX a Markdown | Extraer contenido de la presentación a Markdown para documentación y flujos de trabajo basados en texto. | [Convertir PowerPoint a Markdown](/slides/es/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP a XML | Crear una presentación PowerPoint XML basada en texto para inspección, comparación, solución de problemas o flujos de trabajo basados en XML. | [Convertir PowerPoint a XML](/slides/es/java/convert-powerpoint-to-xml/) |
| PPT/PPTX a GIF animado | Crear un GIF animado a partir de las diapositivas. | [Convertir PowerPoint a GIF animado](/slides/es/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX a video | Construir un flujo de exportación de vídeo a partir de las diapositivas de la presentación. | [Convertir PowerPoint a vídeo](/slides/es/java/convert-powerpoint-to-video/) |
| Presentación a XAML | Exportar diapositivas a XAML para escenarios de UI Java. | [Exportar presentaciones a XAML](/slides/es/java/export-to-xaml/) |

Para una lista más amplia de formatos de entrada y salida, consulte [Formatos de archivo compatibles](/slides/es/java/supported-file-formats/).

## **Conversión de PowerPoint y OpenDocument**

Aspose.Slides for Java admite la conversión desde formatos de presentación de uso frecuente como PPT, PPTX, PPS, PPSX, POT, POTX y ODP. La misma API de conversión se utiliza para archivos PowerPoint y OpenDocument, por lo que un flujo de trabajo que guarda un archivo PPTX en PDF suele aplicarse a un archivo ODP cambiando solo el archivo de entrada.

Al convertir archivos ODP, recuerde que las aplicaciones PowerPoint y OpenDocument no soportan cada característica de diseño y formato de la misma manera. Si un archivo ODP fue creado en LibreOffice o OpenOffice Impress, revise la salida y utilice las opciones descritas en [Convertir presentaciones OpenDocument](/slides/es/java/convert-openoffice-odp/) cuando necesite orientación específica del formato.

## **Conversión de PPT a PPTX**

PPT es el formato binario antiguo de PowerPoint, mientras que PPTX es el formato moderno Office Open XML. Aspose.Slides for Java soporta una conversión de alta fidelidad de PPT a PPTX preservando estructuras complejas de la presentación como maestros, diseños, diapositivas, gráficos, formas agrupadas, marcadores de posición, marcos de texto, texturas y rellenos de imagen.

Para más detalles, vea [Convertir PPT a PPTX](/slides/es/java/convert-ppt-to-pptx/) y [PPT vs PPTX](/slides/es/java/ppt-vs-pptx/).

## **Exportación de diseño fijo**

PDF, XPS y TIFF son útiles cuando la salida debe verse idéntica en todos los dispositivos y no debe editarse como una presentación. Los artículos dedicados a PDF, XPS y TIFF explican cómo controlar el cumplimiento, diapositivas ocultas, notas, calidad de imagen, compresión, formato de píxeles y tamaño de salida.

## **Exportación a HTML e imagen**

La exportación a HTML y HTML5 es útil para visualización en navegadores, publicación web y uso compartido ligero. La exportación de imágenes es útil cuando cada diapositiva debe convertirse en una vista previa, miniatura o recurso raster separado. Utilice los artículos sobre PNG, JPG y SVG para obtener orientación de renderizado específica de cada formato.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint para convertir presentaciones?**

No. Aspose.Slides for Java es una biblioteca independiente y no requiere Microsoft PowerPoint ni automatización de Office.

**¿Puedo convertir en lote muchas presentaciones?**

Sí. Cargue cada presentación, guárdela en el formato requerido y deseche el objeto de presentación después del procesamiento. Para procesamiento en paralelo, use instancias de presentación separadas y siga la guía de [multihilo](/slides/es/java/multithreading/).

**¿Puedo exportar solo diapositivas seleccionadas?**

Sí. Varios métodos de exportación permiten pasar índices de diapositivas o renderizar diapositivas individuales, según el formato de salida. Consulte el artículo específico del formato de destino.

**¿Puedo incluir diapositivas ocultas al exportar a PDF o XPS?**

Sí. Utilice la configuración de exportación de diapositivas ocultas descrita en los artículos de [PDF](/slides/es/java/convert-powerpoint-to-pdf/) y [XPS](/slides/es/java/convert-powerpoint-to-xps/).

**¿Puedo crear salida PDF/A?**

Sí. Las configuraciones de cumplimiento PDF están disponibles para la exportación a PDF. Vea [Convertir PowerPoint a PDF](/slides/es/java/convert-powerpoint-to-pdf/) para más detalles.

**¿Cómo se gestionan las fuentes durante la conversión?**

Aspose.Slides puede usar fuentes incrustadas, fuentes de respaldo y configuraciones de sustitución de fuentes. Consulte [Fuente incrustada](/slides/es/java/embedded-font/), [Fuente de respaldo](/slides/es/java/fallback-font/) y [Sustitución de fuentes](/slides/es/java/font-substitution/).
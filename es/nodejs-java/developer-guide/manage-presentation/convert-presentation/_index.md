---
title: Convertir presentaciones a varios formatos en JavaScript
linktitle: Convertir presentación
type: docs
weight: 70
url: /es/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierta presentaciones PowerPoint y OpenDocument a PPTX, PDF, HTML, imágenes, XPS, TIFF y más con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Aspose.Slides for Node.js via Java puede cargar presentaciones PowerPoint y OpenDocument y guardarlas o renderizarlas a muchos otros formatos sin Microsoft PowerPoint, OpenOffice o LibreOffice. Puede convertir archivos PPT heredados a PPTX modernos, exportar presentaciones a documentos de diseño fijo como PDF y XPS, publicar diapositivas como HTML, o renderizar diapositivas como archivos de imagen para vistas preliminares, miniaturas y archivos.

La mayoría de las conversiones de documentos utilizan el mismo flujo de trabajo general: cargar el archivo de origen, elegir el formato de salida requerido y aplicar opciones específicas del formato cuando sea necesario. Para los formatos de imagen, cada diapositiva se renderiza por separado y luego se guarda como una imagen raster o vectorial. Los artículos dedicados enlazados a continuación proporcionan los detalles de implementación para cada caso.

## **Elija un escenario de conversión**

Utilice los artículos a continuación para obtener ejemplos completos de JavaScript y opciones específicas de formato.

| Escenario | Úselo cuando necesite | Artículo |
| --- | --- | --- |
| PPT/PPTX/ODP a PPTX | Modernizar archivos PPT heredados, normalizar archivos PPTX existentes o convertir presentaciones OpenDocument a PowerPoint PPTX. | [Convertir PPT a PPTX](/slides/es/nodejs-java/convert-ppt-to-pptx/), [Convertir ODP a PPTX](/slides/es/nodejs-java/convert-odp-to-pptx/), [Guardar presentaciones](/slides/es/nodejs-java/save-presentation/) |
| PPTX a PPT | Guardar una presentación PowerPoint moderna en el formato binario PPT más antiguo para compatibilidad con flujos de trabajo anteriores. | [Convertir PPTX a PPT](/slides/es/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP a PDF | Crear documentos portátiles, buscables y de diseño fijo para compartir, imprimir o archivar. | [Convertir PowerPoint a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP a PDF con notas | Exportar notas del ponente junto con el contenido de la diapositiva. | [Convertir PowerPoint a PDF con notas](/slides/es/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP a HTML | Publicar presentaciones como páginas HTML y controlar imágenes, fuentes, notas y opciones de diseño responsivo. | [Convertir PowerPoint a HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP a HTML5 | Exportar diapositivas a HTML5 para visualización en el navegador con formato e interactividad preservados. | [Convertir presentaciones a HTML5](/slides/es/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP a PNG | Renderizar cada diapositiva a una imagen PNG para vistas preliminares, miniaturas o salida web. | [Convertir PowerPoint a PNG](/slides/es/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP a JPG | Renderizar diapositivas a imágenes JPG y controlar dimensiones y calidad de la imagen. | [Convertir PowerPoint a JPG](/slides/es/nodejs-java/convert-powerpoint-to-jpg/) |
| Diapositiva a SVG | Exportar diapositivas individuales como gráficos vectoriales escalables. | [Renderizar diapositiva como SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP a XPS | Generar documentos XPS de diseño fijo. | [Convertir PowerPoint a XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP a TIFF | Guardar una presentación como un archivo TIFF multipágina para impresión, escaneo, fax o flujos de archivo. | [Convertir PowerPoint a TIFF](/slides/es/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP a TIFF con notas | Guardar diapositivas con notas del ponente en TIFF. | [Convertir PowerPoint a TIFF con notas](/slides/es/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX a Markdown | Extraer el contenido de la presentación a Markdown para documentación y flujos de trabajo basados en texto. | [Convertir PowerPoint a Markdown](/slides/es/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX a GIF animado | Crear un GIF animado a partir de diapositivas. | [Convertir PowerPoint a GIF animado](/slides/es/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX a video | Crear un flujo de exportación a vídeo a partir de diapositivas de la presentación. | [Convertir PowerPoint a video](/slides/es/nodejs-java/convert-powerpoint-to-video/) |
| Presentación a XAML | Exportar diapositivas a XAML para escenarios de UI en JavaScript o Java. | [Exportar presentaciones a XAML](/slides/es/nodejs-java/export-to-xaml/) |

Para obtener una lista más amplia de formatos de entrada y salida, consulte [Formatos de archivo compatibles](/slides/es/nodejs-java/supported-file-formats/).

## **Conversión de PowerPoint y OpenDocument**

Aspose.Slides for Node.js via Java admite la conversión desde formatos de presentación de uso común como PPT, PPTX, PPS, PPSX, POT, POTX y ODP. La misma API de conversión se utiliza para archivos PowerPoint y OpenDocument, por lo que un flujo de trabajo que guarda un archivo PPTX en PDF suele poder aplicarse a un archivo ODP cambiando solo el archivo de entrada.

Al convertir archivos ODP, recuerde que las aplicaciones PowerPoint y OpenDocument no soportan cada característica de diseño y formato de la misma manera exacta. Si un archivo ODP se creó en LibreOffice o OpenOffice Impress, revise el resultado y utilice las opciones descritas en [Convertir presentaciones OpenDocument](/slides/es/nodejs-java/convert-openoffice-odp/) cuando necesite orientación específica del formato.

## **Conversión de PPT a PPTX**

PPT es el formato binario antiguo de PowerPoint, mientras que PPTX es el formato moderno Office Open XML. Aspose.Slides for Node.js via Java admite la conversión de alta fidelidad de PPT a PPTX conservando estructuras de presentación complejas como maestros, diseños, diapositivas, gráficos, formas agrupadas, marcadores de posición, marcos de texto, texturas y rellenos de imagen.

Para más detalles, vea [Convertir PPT a PPTX](/slides/es/nodejs-java/convert-ppt-to-pptx/) y [PPT vs PPTX](/slides/es/nodejs-java/ppt-vs-pptx/).

## **Exportación de diseño fijo**

PDF, XPS y TIFF son útiles cuando la salida debe verse idéntica en todos los dispositivos y no debe editarse como una presentación. Los artículos dedicados a PDF, XPS y TIFF explican cómo controlar el cumplimiento, diapositivas ocultas, notas, calidad de imagen, compresión, formato de píxeles y tamaño de salida.

## **Exportación a HTML y a imágenes**

La exportación a HTML y HTML5 es útil para la visualización en navegadores, publicación web y uso compartido ligero. La exportación de imágenes es útil cuando cada diapositiva debe convertirse en una vista preliminar, miniatura o recurso raster separado. Utilice los artículos PNG, JPG y SVG para obtener orientación específica de renderizado de formato.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint para convertir presentaciones?**

No. Aspose.Slides for Node.js via Java es una biblioteca independiente y no requiere Microsoft PowerPoint ni automatización de Office.

**¿Puedo convertir en lote muchas presentaciones?**

Sí. Cargue cada presentación, guárdela en el formato requerido y elimine el objeto de presentación después del procesamiento. Para procesamiento paralelo, use instancias de presentación independientes y siga la guía de [multithreading](/slides/es/nodejs-java/multithreading/).

**¿Puedo exportar solo diapositivas seleccionadas?**

Sí. Varios métodos de exportación le permiten pasar índices de diapositivas o renderizar diapositivas individuales, según el formato de salida. Consulte el artículo dedicado al formato de destino.

**¿Puedo incluir diapositivas ocultas al exportar a PDF o XPS?**

Sí. Utilice la configuración de exportación de diapositivas ocultas descrita en los artículos de [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/) y [XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/).

**¿Puedo crear salida PDF/A?**

Sí. Las configuraciones de cumplimiento PDF están disponibles para la exportación a PDF. Vea [Convertir PowerPoint a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/) para más detalles.

**¿Cómo se gestionan las fuentes durante la conversión?**

Aspose.Slides puede usar fuentes incrustadas, sustitución de fuentes y configuraciones de respaldo de fuentes. Vea [Fuente incrustada](/slides/es/nodejs-java/embedded-font/), [Fuente de respaldo](/slides/es/nodejs-java/fallback-font/) y [Sustitución de fuentes](/slides/es/nodejs-java/font-substitution/).
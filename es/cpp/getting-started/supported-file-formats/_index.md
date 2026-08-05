---
title: Formatos de archivo compatibles
type: docs
weight: 20
url: /es/cpp/supported-file-formats/
keywords:
- formato de archivo
- formato compatible
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Descubra todos los formatos de archivo que Aspose.Slides para C++ puede abrir, guardar y convertir — incluidos PPT, PPTX y ODP — con notas claras de compatibilidad de importación/exportación."
---
## **Visión general**

Aspose.Slides es compatible con archivos de presentación de Microsoft PowerPoint 97 hasta Office 365, incluido Microsoft PowerPoint para Mac. Este artículo enumera las versiones de PowerPoint admitidas por la biblioteca y proporciona una tabla de formatos de archivo que pueden cargarse, guardarse o ambas cosas.

El artículo también responde a preguntas frecuentes sobre el cumplimiento de PDF, la incrustación de fuentes, archivos protegidos con contraseña, fuentes personalizadas, sustitución de fuentes y opciones de exportación a XPS.

## **Versiones de Microsoft PowerPoint compatibles**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **Formatos de archivo compatibles**
Esta tabla contiene los formatos de archivo que Aspose.Slides para C++ puede cargar y guardar:

|**Formato**|**Descripción**|**Cargar**|**Guardar**|**Observaciones**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación PowerPoint con macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Presentación PowerPoint con macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla PowerPoint con macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla de presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de archivo de imagen TIFF| |{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Formato Metarchivo Mejorado| |{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación de Papel XML| |{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Formato de imagen JPEG| |{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Formato PNG (Portable Network Graphics)| |{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercambio de Gráficos| |{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Mapa de bits independiente del dispositivo| |{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vectoriales Escalables| |{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Small Web| |{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de Marcado de Hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de Marcado de Aplicaciones Extensible| |{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}|
|[XML](https://docs.fileformat.com/web/xml/)|Presentación PowerPoint XML| |{{< emoticons/tick >}}|

## **Preguntas frecuentes**

**¿Puedo guardar presentaciones en PDF que cumplan con los estándares de archivo y accesibilidad (PDF/A y PDF/UA)?**

Sí. Aspose.Slides admite la exportación a PDF con niveles de cumplimiento como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, así como PDF/UA mediante la configuración [cumplimiento](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/set_compliance/) en las [opciones de exportación a PDF](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/).

**¿La biblioteca soporta la incrustación de fuentes al exportar a PDF, con control detallado sobre lo que se incrusta?**

Sí. Puede controlar si las fuentes se incrustan completamente o solo como subconjunto (solo los glifos utilizados), especificar cómo se tratan las fuentes del sistema y configurar el comportamiento para texto ASCII mediante las [opciones de exportación a PDF](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/).

**¿Puedo detectar si un archivo está protegido con contraseña antes de cargarlo realmente?**

Sí. Utilizando la [API de inspección basada en factoría](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/), puede consultar un archivo de presentación para determinar si está protegido con contraseña sin abrirlo completamente.

**¿Existen mecanismos de sustitución de fuentes y soporte para fuentes personalizadas?**

Sí. La biblioteca soporta la [carga](/slides/es/cpp/custom-font/) y la [incrustación](/slides/es/cpp/embedded-font/) de fuentes personalizadas y proporciona [reglas de reserva](/slides/es/cpp/fallback-font/) para evitar glifos faltantes durante la renderización y la conversión.

**¿Puedo exportar diapositivas a XPS y existen opciones para ajustar la salida XPS?**

Sí. [Exportar a XPS](/slides/es/cpp/convert-powerpoint-to-xps/) está soportado, y puede ajustar las [opciones de guardado](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/xpsoptions/) relevantes para controlar la calidad y el contenido del documento XPS.
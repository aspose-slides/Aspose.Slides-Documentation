---
title: Formatos de archivo compatibles
type: docs
weight: 30
url: /es/nodejs-java/supported-file-formats/
---

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
- Microsoft PowerPoint para MAC
- Office 365

## **Formatos de archivo compatibles**
La siguiente tabla contiene los formatos de archivo que Aspose.Slides para Node.js a través de Java puede cargar y guardar:

|**Formato**|**Descripción**|**Cargar**|**Guardar**|**Observaciones**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Show PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Show PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación de PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show de PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla de PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla de presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de archivo de imagen Tag| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Formato de Metarchivo Mejorado| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Grupo Conjunto de Expertos en Fotografía| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de Red Portátiles| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercambio de Gráficos| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Independiente del Dispositivo| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vectoriales Escalables| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeño| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de Marcado de Hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de Marcado Extensible de Aplicaciones| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Presentación PowerPoint XML| |{{< emoticons/tick >}}| |

## **Preguntas frecuentes**

**¿Puedo guardar presentaciones en PDF que cumplan con los estándares de archivo y accesibilidad (PDF/A y PDF/UA)?**

Sí. Aspose.Slides admite la exportación a PDF con niveles de cumplimiento como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, así como PDF/UA mediante la configuración [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) en [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**¿La biblioteca admite la incrustación de fuentes al exportar a PDF, con control detallado sobre lo que se incrusta?**

Sí. Puede controlar si las fuentes se incrustan completamente o de forma parcial (solo los glifos utilizados), especificar cómo se tratan las fuentes del sistema comunes y configurar el comportamiento para texto ASCII mediante [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**¿Puedo detectar si un archivo está protegido con contraseña antes de cargarlo realmente?**

Sí. Usando la [factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/), puede consultar un archivo de presentación para determinar si está protegido con contraseña sin abrirlo completamente.

**¿Existen mecanismos de reserva de fuentes y soporte para fuentes personalizadas?**

Sí. La biblioteca admite la [loading](/slides/es/nodejs-java/custom-font/) y la [embedding](/slides/es/nodejs-java/embedded-font/) de fuentes personalizadas y proporciona reglas de [fallback](/slides/es/nodejs-java/fallback-font/) de fuentes para evitar glifos faltantes durante el renderizado y la conversión.

**¿Puedo exportar diapositivas a XPS y hay opciones para ajustar la salida XPS?**

Sí. [Export to XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/) es compatible, y puede ajustar las [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) pertinentes para controlar la calidad de salida y el contenido del documento XPS.
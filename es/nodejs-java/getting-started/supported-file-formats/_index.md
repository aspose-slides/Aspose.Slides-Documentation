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
- Microsoft PowerPoint for MAC
- Office 365

## **Formatos de archivo compatibles**
Esta tabla contiene los formatos de archivo que Aspose.Slides para Node.js a través de Java puede cargar y guardar:

|**Formato**|**Descripción**|**Cargar**|**Guardar**|**Observaciones**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Plantilla PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Presentación PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Plantilla PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Presentación PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentación PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Presentación PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Plantilla PowerPoint con macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Plantilla de presentación OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de archivo de imagen Tag| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Formato de Metarchivo Mejorado| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formato de documento portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificación XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Grupo Conjunto de Expertos en Fotografía| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de red portátiles| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de intercambio de gráficos| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Mapa de bits independiente del dispositivo| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos vectoriales escalables| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web pequeño| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Lenguaje de marcado de hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Lenguaje de marcado de aplicaciones extensible| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Presentación XML de PowerPoint| |{{< emoticons/tick >}}| |

## **Preguntas frecuentes**

**¿Puedo guardar presentaciones en PDF que cumplan con los estándares de archivo y accesibilidad (PDF/A y PDF/UA)?**

Sí. Aspose.Slides admite la exportación a PDF con niveles de cumplimiento como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, así como PDF/UA mediante la configuración [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) en [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**¿La biblioteca admite la incrustación de fuentes al exportar a PDF, con control detallado sobre lo que se incrusta?**

Sí. Puedes controlar si las fuentes se incrustan completamente o de forma parcial (solo los glifos usados), especificar cómo se tratan las fuentes del sistema comunes y configurar el comportamiento para texto ASCII mediante [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**¿Puedo detectar si un archivo está protegido con contraseña antes de cargarlo?**

Sí. Usando la API de inspección basada en factories, puedes consultar un archivo de presentación para determinar si está protegido con contraseña sin abrirlo completamente.

**¿Existen mecanismos de sustitución de fuentes y soporte para fuentes personalizadas?**

Sí. La biblioteca admite [carga](/slides/es/nodejs-java/custom-font/) e [incrustación](/slides/es/nodejs-java/embedded-font/) de fuentes personalizadas y proporciona reglas de [fallback de fuentes](/slides/es/nodejs-java/fallback-font/) para evitar glifos faltantes durante la renderización y conversión.

**¿Puedo exportar diapositivas a XPS y existen opciones para ajustar la salida XPS?**

Sí. [Exportar a XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/) está soportado, y puedes ajustar las [opciones de guardado](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) relevantes para controlar la calidad y el contenido del documento XPS.
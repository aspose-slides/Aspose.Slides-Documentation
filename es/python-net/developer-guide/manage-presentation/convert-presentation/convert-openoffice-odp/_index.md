---
title: Convertir presentaciones OpenDocument en Python
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /es/python-net/convert-openoffice-odp/
keywords:
- convertir OpenDocument
- convertir ODP
- ODP a PDF
- ODP a PPT
- ODP a PPTX
- ODP a XPS
- ODP a HTML
- ODP a TIFF
- ODP a SWF
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Convertir OpenDocument ODP a PDF, PPT, PPTX, XPS, HTML, TIFF o SWF en Python con Aspose.Slides: ejemplos de código, alta fidelidad, conversión por lotes y personalización."
---

## **Convertir archivos ODP**

[**API de Aspose.Slides**](https://products.aspose.com/slides/python-net/) permite convertir presentaciones OpenOffice ODP a varios formatos. La API utilizada para convertir archivos ODP a otros formatos de documento es la misma que se usa para operaciones de conversión de PowerPoint (PPT y PPTX).

Estos ejemplos le muestran cómo convertir documentos ODP a otros formatos (simplemente cambie el archivo ODP de origen):

- [Convertir ODP a HTML](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP a PDF](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP a TIFF](/slides/es/python-net/convert-powerpoint-to-tiff/)
- [Convertir ODP a SWF Flash](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP a XPS](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP a PDF con notas](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP a TIFF con notas](/slides/es/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Por ejemplo, si necesita convertir una presentación ODP a PDF, puede hacerlo de esta manera:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**¿Puedo convertir ODP a PPTX sin instalar LibreOffice o OpenOffice?**

Sí. Aspose.Slides es una biblioteca completamente independiente que maneja tanto formatos PowerPoint como OpenOffice sin requerir aplicaciones externas.

**¿Aspose.Slides abre y guarda archivos ODP/OTP protegidos con contraseña?**

Sí. Puede [cargar presentaciones cifradas](/slides/es/python-net/password-protected-presentation/) cuando proporcione la contraseña y también puede guardar presentaciones con configuraciones de cifrado y protección.

**¿Puedo extraer archivos multimedia incrustados (audio/video) de un ODP antes de convertirlo?**

Sí. Aspose.Slides le permite acceder y extraer [audio](/slides/es/python-net/audio-frame/) y [video](/slides/es/python-net/video-frame/) incrustados de las presentaciones, lo que es útil para el procesamiento previo a la conversión o reutilización por separado.

**¿Puedo guardar el ODP convertido como Strict Office Open XML?**

Sí. Al guardar en PPTX puede habilitar Strict OOXML mediante las [opciones de guardado](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) para cumplir con requisitos de cumplimiento más estrictos.
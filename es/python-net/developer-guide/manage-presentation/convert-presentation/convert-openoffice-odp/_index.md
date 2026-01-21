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
description: "Convertir ODP OpenDocument a PDF, PPT, PPTX, XPS, HTML, TIFF o SWF en Python con Aspose.Slides: ejemplos de código, alta fidelidad, conversión por lotes y personalización."
---

## **Convertir archivos ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) permite convertir presentaciones OpenDocument (ODP) a muchos formatos (HTML, PDF, TIFF, SWF, XPS, etc.). La API utilizada para convertir archivos ODP a otros formatos de documento es la misma que se usa para las operaciones de conversión de PowerPoint (PPT y PPTX).

Por ejemplo, si necesita convertir una presentación ODP a PDF, puede hacerlo de la siguiente manera:
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **Preguntas frecuentes**

**¿Puedo convertir ODP a PPTX sin instalar LibreOffice o OpenOffice?**

Sí. Aspose.Slides es una biblioteca totalmente independiente que maneja tanto los formatos de PowerPoint como los de OpenOffice sin requerir aplicaciones externas.

**¿Aspose.Slides abre y guarda archivos ODP/OTP protegidos con contraseña?**

Sí. Puede [cargar presentaciones cifradas](/slides/es/python-net/password-protected-presentation/) cuando proporciona la contraseña y también puede guardar presentaciones con opciones de cifrado y protección.

**¿Puedo extraer archivos multimedia incrustados (audio/video) de un ODP antes de convertirlo?**

Sí. Aspose.Slides le permite acceder y extraer [audio](/slides/es/python-net/audio-frame/) y [video](/slides/es/python-net/video-frame/) incrustados de las presentaciones, lo que resulta útil para el procesamiento previo a la conversión o para reutilización separada.

**¿Puedo guardar el ODP convertido como Strict Office Open XML?**

Sí. Al guardar en PPTX puede habilitar Strict OOXML mediante las [opciones de guardado](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) para cumplir con requisitos de cumplimiento más estrictos.
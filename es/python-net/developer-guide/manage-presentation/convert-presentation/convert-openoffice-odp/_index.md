---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /python-net/convert-openoffice-odp/
keywords: "Convertir ODP a PDF, ODP a PPT, ODP a PPTX, ODP a XPS, ODP a HTML, ODP a TIFF"
description: "Convertir ODP a PDF, ODP a PPT, ODP a PPTX, ODP a HTML y otros formatos con Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) te permite convertir presentaciones OpenOffice ODP a muchos formatos. La API utilizada para convertir archivos ODP a otros formatos de documento es la misma que se utiliza para las operaciones de conversión de PowerPoint (PPT y PPTX).

Estos ejemplos te muestran cómo convertir documentos ODP a otros formatos (solo cambia el archivo ODP de origen):

- [Convertir ODP a HTML](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP a PDF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP a TIFF](/slides/python-net/convert-powerpoint-to-tiff/)
- [Convertir ODP a SWF Flash](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP a XPS](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP a PDF con Notas](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP a TIFF con Notas](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Por ejemplo, si necesitas convertir una presentación ODP a PDF, se puede hacer de esta manera:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```
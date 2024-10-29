---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /es/cpp/convert-openoffice-odp/
keywords: "Convertir ODP a PDF, ODP a HTML, ODP a TIFF"
description: "Convertir ODP a PDF, ODP a PPT, ODP a PPTX, ODP a HTML y otros formatos con Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) te permite convertir presentaciones de OpenOffice ODP a muchos formatos. La API utilizada para convertir archivos ODP a otros formatos de documento es la misma que se utiliza para las operaciones de conversión de PowerPoint (PPT y PPTX). 

Estos ejemplos te muestran cómo convertir documentos ODP a otros formatos (solo cambia el archivo ODP de origen):

- [Convertir ODP a HTML](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP a PDF](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP a TIFF](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [Convertir ODP a SWF Flash](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP a XPS](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP a PDF con Notas](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP a TIFF con Notas](/slides/es/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Por ejemplo, si necesitas convertir una presentación ODP a PDF, se puede hacer de esta manera:

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```
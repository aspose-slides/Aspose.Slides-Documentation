---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /python-net/convert-openoffice-odp/
keywords: "Convertir ODP en PDF, ODP en PPT, ODP en PPTX, ODP en XPS, ODP en HTML, ODP en TIFF"
description: "Convertir ODP en PDF, ODP en PPT, ODP en PPTX, ODP en HTML et d'autres formats avec Aspose.Slides."
---

[**API Aspose.Slides**](https://products.aspose.com/slides/python-net/) vous permet de convertir des présentations OpenOffice ODP en de nombreux formats. L'API utilisée pour convertir les fichiers ODP en d'autres formats de document est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Ces exemples vous montrent comment convertir des documents ODP en d'autres formats (il suffit de changer le fichier ODP source) :

- [Convertir ODP en HTML](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP en PDF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP en TIFF](/slides/python-net/convert-powerpoint-to-tiff/)
- [Convertir ODP en SWF Flash](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP en XPS](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP en PDF avec des notes](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP en TIFF avec des notes](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Par exemple, si vous devez convertir une présentation ODP en PDF, cela peut se faire de cette manière :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```
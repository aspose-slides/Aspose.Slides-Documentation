---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /fr/cpp/convert-openoffice-odp/
keywords: "Convertir ODP en PDF, ODP en HTML, ODP en TIFF"
description: "Convertir ODP en PDF, ODP en PPT, ODP en PPTX, ODP en HTML et d'autres formats avec Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) vous permet de convertir des présentations OpenOffice ODP en de nombreux formats. L'API utilisée pour convertir des fichiers ODP en d'autres formats de document est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Ces exemples vous montrent comment convertir des documents ODP en d'autres formats (il suffit de changer le fichier ODP source) :

- [Convertir ODP en HTML](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP en PDF](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP en TIFF](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [Convertir ODP en SWF Flash](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP en XPS](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP en PDF avec notes](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP en TIFF avec notes](/slides/fr/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Par exemple, si vous devez convertir une présentation ODP en PDF, cela peut se faire de cette manière :

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```
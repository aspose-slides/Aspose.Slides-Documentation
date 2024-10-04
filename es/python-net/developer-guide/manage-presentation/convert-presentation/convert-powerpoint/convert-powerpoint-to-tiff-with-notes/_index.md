---
title: Convertir PowerPoint a TIFF con Notas
type: docs
weight: 100
url: /python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint a TIFF con notas"
description: "Convertir PowerPoint a TIFF con notas en Aspose.Slides."
---

{{% alert title="Consejo" color="primary" %}}

Puede que desee consultar el [convertidor GRATUITO de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) de Aspose.

{{% /alert %}}

TIFF es uno de varios formatos de imagen de uso común que Aspose.Slides para Python a través de .NET admite para convertir presentaciones de PowerPoint PPT y PPTX con notas a imágenes. También puede generar miniaturas de diapositivas en la vista de Diapositivas de Notas. El método [Guardar](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase Presentation se puede utilizar para convertir toda la presentación en la vista de Diapositivas de Notas a TIFF. Guardar una presentación de Microsoft PowerPoint como TIFF con notas utilizando Aspose.Slides para Python a través de .NET es un proceso de dos líneas. Simplemente abra la presentación y guárdela como notas TIFF. También puede generar una miniatura de diapositiva en la vista de Diapositivas de Notas para diapositivas individuales. Los fragmentos de código a continuación actualizan la presentación de muestra a imágenes TIFF en la vista de Diapositivas de Notas, como se muestra a continuación:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
presentation = slides.Presentation("pres.pptx")

# Guardar la presentación en notas TIFF
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```
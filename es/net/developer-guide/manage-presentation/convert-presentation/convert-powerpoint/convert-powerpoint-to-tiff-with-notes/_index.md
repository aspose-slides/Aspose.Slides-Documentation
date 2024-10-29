---
title: Convertir PowerPoint a TIFF con Notas
type: docs
weight: 100
url: /es/net/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint a TIFF con notas"
description: "Convertir PowerPoint a TIFF con notas en Aspose.Slides."
---

{{% alert title="Consejo" color="primary" %}}

Es posible que desees consultar el [convertidor GRATUIT de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) de Aspose.

{{% /alert %}}

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET admite para convertir presentaciones de PowerPoint PPT y PPTX con notas a imágenes. También puedes generar miniaturas de diapositivas en la vista de Diapositivas de Notas. El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase Presentation se puede utilizar para convertir toda la presentación en la vista de Diapositivas de Notas a TIFF. Guardar una presentación de Microsoft PowerPoint como notas TIFF con Aspose.Slides para .NET es un proceso de dos líneas. Simplemente abres la presentación y la guardas como notas TIFF. También puedes generar una miniatura de diapositiva en la vista de Diapositivas de Notas para diapositivas individuales. Los fragmentos de código a continuación actualizan la presentación de muestra a imágenes TIFF en la vista de Diapositivas de Notas, como se muestra a continuación:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Guardando la presentación como notas TIFF
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```
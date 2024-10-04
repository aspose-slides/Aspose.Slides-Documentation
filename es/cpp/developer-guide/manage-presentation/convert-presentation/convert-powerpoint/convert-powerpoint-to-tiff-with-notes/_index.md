---
title: Convertir PowerPoint a TIFF con Notas
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint a TIFF con notas"
description: "Convertir PowerPoint a TIFF con notas en Aspose.Slides."
---

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para C++ admite para convertir presentaciones PowerPoint PPT y PPTX con notas a imágenes. También puedes generar miniaturas de diapositivas en la vista de Diapositiva de Notas. El método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la clase Presentation se puede usar para convertir toda la presentación en la vista de Diapositiva de Notas a TIFF. Guardar una presentación de Microsoft PowerPoint en notas TIFF con Aspose.Slides para C++ es un proceso de dos líneas. Simplemente abres la presentación y la guardas en notas TIFF. También puedes generar una miniatura de diapositiva en la vista de Diapositiva de Notas para diapositivas individuales. Los fragmentos de código a continuación actualizan la presentación de muestra a imágenes TIFF en la vista de Diapositiva de Notas, como se muestra a continuación:

``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// Guardar la presentación en notas TIFF
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="Tip" color="primary" %}}

Tal vez quieras consultar el [convertidor GRATUITO de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) de Aspose.

{{% /alert %}}
---
title: Convertir presentaciones de PowerPoint a SWF Flash en C++
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/cpp/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a SWF
- presentación a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint a Flash
- presentación a Flash
- diapositiva a Flash
- PPT a Flash
- PPTX a Flash
- guardar PPT como SWF
- guardar PPTX como SWF
- exportar PPT a SWF
- exportar PPTX a SWF
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en C++ con Aspose.Slides. Ejemplos de código paso a paso, salida rápida de alta calidad, sin automatización de PowerPoint."
---

## **Convertir presentaciones a Flash**

El método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) se puede usar para convertir toda la presentación en un documento SWF. También puede incluir comentarios en el SWF generado usando la clase [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) y la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF utilizando las opciones provistas por la clase SWFOptions.
``` cpp
// La ruta al directorio de documentos.
    System::String dataDir = GetDataPath();

    // Instanciar un objeto Presentation que representa un archivo de presentación
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Guardar la presentación y las páginas de notas
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **FAQ**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Use el método [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) en [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Use el método [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) y ajuste la [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'set_ViewerIncluded' y cuándo debo usarlo?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) agrega una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Desactívela si planea usar su propio reproductor o necesita un marco SWF básico sin UI.

**¿Qué ocurre si una fuente origen falta en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) en [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) para evitar una sustitución no deseada.
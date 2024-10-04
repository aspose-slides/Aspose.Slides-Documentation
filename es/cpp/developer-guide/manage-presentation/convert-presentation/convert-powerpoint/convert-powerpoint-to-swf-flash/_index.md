---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX a SWF"
description: "Convierte PowerPoint PPT, PPTX al formato SWF Flash con la API Aspose.Slides."
---

El [método Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) se puede usar para convertir toda la presentación en un documento SWF. También puedes incluir comentarios en el SWF generado utilizando la [clase SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) y la [interfaz INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF utilizando las opciones proporcionadas por la clase SWFOptions.

``` cpp
// La ruta al directorio de documentos.
    System::String dataDir = GetDataPath();

    // Instancia un objeto Presentation que representa un archivo de presentación
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Guardando presentación y páginas de notas
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```
---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /fr/cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX en SWF"
description: "Convertir PowerPoint PPT, PPTX en format SWF Flash avec l'API Aspose.Slides."
---

La méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) peut être utilisée pour convertir l'ensemble de la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.

``` cpp
// Le chemin vers le répertoire des documents.
    System::String dataDir = GetDataPath();

    // Instancier un objet Presentation qui représente un fichier de présentation
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Sauvegarder la présentation et les pages de notes
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```
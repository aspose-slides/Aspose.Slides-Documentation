---
title: PowerPoint in SWF Flash konvertieren
type: docs
weight: 80
url: /de/cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX in SWF"
description: "Konvertieren Sie PowerPoint PPT, PPTX in das SWF Flash-Format mit der Aspose.Slides API."
---

Die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse kann verwendet werden, um die gesamte Präsentation in ein SWF-Dokument zu konvertieren. Sie können auch Kommentare im generierten SWF einfügen, indem Sie die [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) Klasse und das [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) Interface verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation in ein SWF-Dokument umwandelt, unter Verwendung der Optionen, die von der SWFOptions-Klasse bereitgestellt werden.

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
    System::String dataDir = GetDataPath();

    // Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Präsentation und Notizseiten speichern
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```
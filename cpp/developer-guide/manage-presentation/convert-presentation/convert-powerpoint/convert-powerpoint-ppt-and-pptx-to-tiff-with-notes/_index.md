---
title: Convert PowerPoint PPT and PPTX to TIFF with Notes
type: docs
weight: 100
url: /cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/
keywords: "Convert PowerPoint to TIFF with notes"
description: "Convert PowerPoint to TIFF with notes in Aspose.Slides."
---

TIFF is one of several widely used image formats that Aspose.Slides for C++ supports for converting PowerPoint PPT and PPTX presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. The [Save](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by Presentation class can be used to convert the whole presentation in Notes Slide view to TIFF. Saving a Microsoft PowerPoint presentation to TIFF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to TIFF notes. You can also generate a slide thumbnail in Notes Slide view for individual slides. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// Saving the presentation to TIFF notes
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}} 
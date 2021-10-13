---
title: Convert PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /net/convert-powerpoint-to-tiff-with-notes/
keywords: "Convert PowerPoint to TIFF with notes"
description: "Convert PowerPoint to TIFF with notes in Aspose.Slides."
---

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

TIFF is one of several widely used image formats that Aspose.Slides for .NET supports for converting PowerPoint PPT and PPTX presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. The [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by Presentation class can be used to convert the whole presentation in Notes Slide view to TIFF. Saving a Microsoft PowerPoint presentation to TIFF notes with Aspose.Slides for .NET is a two-line process. You simply open the presentation and save it out to TIFF notes. You can also generate a slide thumbnail in Notes Slide view for individual slides. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Saving the presentation to TIFF notes
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```








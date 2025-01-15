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

TIFF is one of several widely used image formats that Aspose.Slides for .NET supports for converting PowerPoint presentations (PPT and PPTX) with notes to images. You can also generate slide thumbnails in the Notes Slide view.

The [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method exposed by the Presentation class can be used to convert the whole presentation in Notes Slide view to TIFF.

**Saving a Presentation with Notes to TIFF**

Saving a Microsoft PowerPoint presentation to TIFF notes with Aspose.Slides for .NET involves the following steps:

- Instantiate a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)  object: Load the PowerPoint file.

- Configure the output layout options: Use the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) class to specify how notes and comments should be displayed.

- Save the presentation to TIFF: Pass the configured options to the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method.

The code snippet below demonstrates how to convert a PowerPoint presentation to TIFF images in Notes Slide view using the [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) property.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Configure TIFF options with Notes and Comments Layouting
    TiffOptions tiffOptions = new TiffOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull, // Display notes below the slide
            CommentsPosition = CommentsPositions.Right // Display comments to the right
        }
    };

    // Saving the presentation to TIFF notes
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff, tiffOptions);
}
```









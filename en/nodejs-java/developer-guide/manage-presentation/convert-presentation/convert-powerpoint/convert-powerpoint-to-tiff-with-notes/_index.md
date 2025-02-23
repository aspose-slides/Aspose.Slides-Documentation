---
title: Convert PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords: "Convert PowerPoint to TIFF with notes"
description: "Convert PowerPoint to TIFF with notes in Aspose.Slides."
---

## **Convert PPT(X) in Notes Slide View to TIFF**
The [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method exposed by [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class can be used to convert the whole presentation in Notes Slide view to TIFF. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var opts = new aspose.slides.TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Saving the presentation to TIFF notes
    pres.save("Tiff-Notes.tiff", aspose.slides.SaveFormat.Tiff, opts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

The above code snippets update the sample presentation to TIFF images in Notes Slide view, as shown below:

|**The source presentation view with slide notes**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**The generated TIFF image in Notes Slide view**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

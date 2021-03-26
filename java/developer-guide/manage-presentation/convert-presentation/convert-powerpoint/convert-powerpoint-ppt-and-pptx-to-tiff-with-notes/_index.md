---
title: Convert PowerPoint PPT and PPTX to TIFF with Notes
type: docs
weight: 100
url: /java/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/
keywords: "Convert PowerPoint to TIFF with notes"
description: "Convert PowerPoint to TIFF with notes in Aspose.Slides."
---

## **Convert PPT(X) in Notes Slide View to TIFF**
The [Save](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method exposed by [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class can be used to convert the whole presentation in Notes Slide view to TIFF. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:

```java
//Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Saving the presentation to TIFF notes
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

The above code snippets update the sample presentation to TIFF images in Notes Slide view, as shown below:

|**The source presentation view with slide notes**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**The generated TIFF image in Notes Slide view**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |





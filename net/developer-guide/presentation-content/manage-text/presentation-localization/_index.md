---
title: Presentation Localization
type: docs
weight: 90
url: /net/presentation-localization/
---
## **Change Language for Presentation and Shape's Text**
- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

using (Presentation pres = new Presentation(dataDir+"test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save(dataDir+"test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
           
}
          
}
```


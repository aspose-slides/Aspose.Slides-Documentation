---
title: Paragraph
type: docs
weight: 10
url: /net/paragraph/
---

## **Get Paragraph and Portion Coordinates in TextFrame**
Using Aspose.Slides for .NET, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

## **Get Rectangular Coordinates of Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationOpening();

// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation(dataDir + "Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


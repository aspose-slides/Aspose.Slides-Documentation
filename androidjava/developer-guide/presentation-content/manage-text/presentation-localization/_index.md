---
title: Presentation Localization
type: docs
weight: 100
url: /androidjava/presentation-localization/
---

## **Change Language for Presentation and Shape's Text**
- Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) of [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) type to the slide.
- Add some text to the TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


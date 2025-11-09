---
title: Presentation Localization
type: docs
weight: 100
url: /net/presentation-localization/
keywords: "Change language, Spellcheck, Spell check, Spellchecker, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Change or check language in PowerPoint presentation. Spell check text in C# or .NET"
---
## **Change Language for Presentation and Shape's Text**
- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Does language ID trigger automatic text translation?**

No. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides stores the language for spell-checking and grammar proofing, but it does not translate or change the text content. It is metadata that PowerPoint understands for proofing.

**Does language ID affect hyphenation and line breaks during rendering?**

In Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) is for proofing. Hyphenation quality and line wrapping primarily depend on the availability of [proper fonts](/slides/net/powerpoint-fonts/) and layout/line-break settings for the writing system. To ensure correct rendering, make the required fonts available, configure [font substitution rules](/slides/net/font-substitution/), and/or [embed fonts](/slides/net/embedded-font/) into the presentation.

**Can I set different languages within a single paragraph?**

Yes. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) is applied at the text portion level, so a single paragraph can mix multiple languages with distinct proofing settings.

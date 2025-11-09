---
title: Automate Presentation Localization with Python
linktitle: Presentation Localization
type: docs
weight: 100
url: /python-net/presentation-localization/
keywords:
- change language
- spell check
- language id
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Automate PowerPoint and OpenDocument slide localization in Python with Aspose.Slides, using practical code samples and tips for faster global rollout."
---

## **Change Language for Presentation and Shape's Text**
- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does language ID trigger automatic text translation?**

No. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides stores the language for spell-checking and grammar proofing, but it does not translate or change the text content. It is metadata that PowerPoint understands for proofing.

**Does language ID affect hyphenation and line breaks during rendering?**

In Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) is for proofing. Hyphenation quality and line wrapping primarily depend on the availability of [proper fonts](/slides/python-net/powerpoint-fonts/) and layout/line-break settings for the writing system. To ensure correct rendering, make the required fonts available, configure [font substitution rules](/slides/python-net/font-substitution/), and/or [embed fonts](/slides/python-net/embedded-font/) into the presentation.

**Can I set different languages within a single paragraph?**

Yes. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) is applied at the text portion level, so a single paragraph can mix multiple languages with distinct proofing settings.

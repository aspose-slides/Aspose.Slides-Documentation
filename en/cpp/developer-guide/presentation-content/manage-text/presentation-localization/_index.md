---
title: Automate Presentation Localization in C++
linktitle: Presentation Localization
type: docs
weight: 100
url: /cpp/presentation-localization/
keywords:
- change language
- spell check
- language id
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Automate PowerPoint and OpenDocument slide localization in C++ with Aspose.Slides, using practical code samples and tips for faster global rollout."
---

## **Change Language for a Presentation and Shape Text**
- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Does language ID trigger automatic text translation?**

No. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) in Aspose.Slides stores the language for spell-checking and grammar proofing, but it does not translate or change the text content. It is metadata that PowerPoint understands for proofing.

**Does language ID affect hyphenation and line breaks during rendering?**

In Aspose.Slides, [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) is for proofing. Hyphenation quality and line wrapping primarily depend on the availability of [proper fonts](/slides/cpp/powerpoint-fonts/) and layout/line-break settings for the writing system. To ensure correct rendering, make the required fonts available, configure [font substitution rules](/slides/cpp/font-substitution/), and/or [embed fonts](/slides/cpp/embedded-font/) into the presentation.

**Can I set different languages within a single paragraph?**

Yes. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) is applied at the text portion level, so a single paragraph can mix multiple languages with distinct proofing settings.

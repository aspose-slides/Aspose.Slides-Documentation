---
title: Manage Superscript and Subscript in Presentations Using C++
linktitle: Superscript and Subscript
type: docs
weight: 80
url: /cpp/superscript-and-subscript/
keywords:
- superscript
- subscript
- add superscript
- add subscript
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Master superscript and subscript in Aspose.Slides for C++ and elevate your presentations with professional text formatting for maximum impact."
---

## **Manage Superscript and Subscript Text**
You can add super script and sub script text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Clear existing Paragraphs
- Create a new paragraph object for holding super script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for the portion between 0 to 100 for adding super script. (0 mean no super script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Create a new paragraph object for holding sub script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding super script. (0 mean no sub script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

Yes, Aspose.Slides properly retains superscript and subscript formatting when exporting presentations to PDF, PPT/PPTX, images, and other supported formats. The specialized formatting remains intact in all output files.

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

Yes, Aspose.Slides allows you to mix various text styles within a single portion of text. You can enable bold, italics, underline, and simultaneously apply superscript or subscript by configuring the corresponding properties in [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/).

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

Yes, Aspose.Slides supports formatting within most objects, including tables and chart elements. When working with SmartArt, you need to access the appropriate elements (such as [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)) and their text containers, and then configure the [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) properties in a similar manner.

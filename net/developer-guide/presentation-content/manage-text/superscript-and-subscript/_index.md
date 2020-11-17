---
title: Superscript and Subscript
type: docs
weight: 70
url: /net/superscript-and-subscript/
---

## **Manage Super Script and Sub Script Text**
You can add superscript and subscript text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **the Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Clear existing Paragraphs
- Create a new paragraph object for holding superscript text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for the portion between 0 to 100 for adding superscript. (0 mean no superscript)
- Set some text for Portion and then add that in portion collection of paragraph.
- Create a new paragraph object for holding subscript text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding superscript. (0 mean no subscript)
- Set some text for Portion and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cs" >}}


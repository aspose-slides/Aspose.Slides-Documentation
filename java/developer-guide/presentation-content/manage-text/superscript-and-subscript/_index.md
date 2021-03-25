---
title: Superscript and Subscript
type: docs
weight: 70
url: /java/superscript-and-subscript/
---

## **Manage Super Script and Sub Script Text**
You can add super script and sub script text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Clear existing Paragraphs
- Create a new paragraph object for holding super script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to 100 for adding super script. (0 mean no super script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Create a new paragraph object for holding sub script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding super script. (0 mean no sub script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddingSuperscriptAndSubscriptText-AddingSuperscriptAndSubscriptText.java" >}}

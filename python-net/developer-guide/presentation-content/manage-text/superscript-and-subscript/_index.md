---
title: Superscript and Subscript
type: docs
weight: 80
url: /python-net/superscript-and-subscript/
keywords: "Super script, Sub script, Add superscript text, Add subscript text, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add superscript and subscript text to PowerPoint presentations in Python"
---

## **Manage Super Script and Sub Script Text**
You can add superscript and subscript text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **the Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
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

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Get slide
    slide = presentation.slides[0]

    # Create text box
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # Create paragraph for superscript text
    superPar = slides.Paragraph()

    # Create portion with usual text
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # Create portion with superscript text
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # Create paragraph for subscript text
    paragraph2 = slides.Paragraph()

    # Create portion with usual text
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # Create portion with subscript text
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # Add paragraphs to text box
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


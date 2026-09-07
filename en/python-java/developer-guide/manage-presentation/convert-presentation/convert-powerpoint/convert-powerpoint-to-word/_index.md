---
title: Convert PowerPoint Presentations to Word Documents in Python via Java
linktitle: PowerPoint to Word
type: docs
weight: 110
url: /python-java/convert-powerpoint-to-word/
keywords:
- convert PowerPoint
- convert presentation
- PowerPoint to Word
- presentation to Word
- PPT to Word
- PPTX to Word
- ODP to Word
- PowerPoint to DOCX
- PPT to DOCX
- PPTX to DOCX
- PowerPoint to DOC
- save PPT as DOCX
- save PPTX as DOCX
- export PPT to DOCX
- export PPTX to DOCX
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument presentations to Word in Python via Java with Aspose.Slides and Aspose.Words, combining slide images with editable text."
---

## **Overview**

This article explains how to convert PowerPoint and OpenDocument presentations to Word documents using Aspose.Slides for Python via Java together with Aspose.Words for Java. Aspose.Slides renders each slide and reads its text, while Aspose.Words creates the Word document through JPype. Microsoft Office is not required.

The resulting document contains a slide image followed by editable text extracted from that slide's top-level auto shapes. The image preserves the slide's visual appearance; individual shapes, charts, and tables are not converted into editable Word objects. The extracted text does not retain the original text formatting or positioning.

## **Convert PowerPoint to Word**

1. Install [Aspose.Slides for Python via Java](/slides/python-java/installation/) and a compatible Java runtime.
2. Download [Aspose.Words for Java](https://releases.aspose.com/words/java/). Place its main JAR file in a `lib` directory beside your script and rename it to `aspose-words.jar`, or adjust the path in the example to match your downloaded file.
3. Place the input presentation, `sample.pptx`, in the working directory. The `lib/aspose-words.jar` path is also relative to that directory.
4. Run the following Python code to create `output.docx`.

The example loads the source with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) and renders slides with [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage). It uses [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) from Aspose.Words to insert the images and text into the Word document.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Fit the slide image to the text area width, preserving its aspect ratio.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Append plain text from top-level auto shapes, including text boxes.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Each slide starts on a new page. Long extracted text or unusually tall slide images can require additional pages. The code adds page breaks only between slides and releases the presentation and rendered images in `finally` blocks. The JVM remains available for subsequent conversions in the same Python process.

## **FAQ**

**Which libraries are required?**

Use Aspose.Slides for Python via Java, JPype, a compatible Java runtime, and Aspose.Words for Java. Both Aspose libraries run in the same JVM. Aspose.Slides handles the presentation; Aspose.Words writes the Word document.

**Can I convert PPT and ODP files as well as PPTX?**

Yes. Replace `sample.pptx` with a PPT or ODP file. See [Supported File Formats](/slides/python-java/supported-file-formats/) for presentation input formats.

**Is all slide content editable in Word?**

No. Each slide is inserted as a static image, with plain text from top-level auto shapes added underneath. Text inside groups, tables, SmartArt, and charts, as well as speaker notes, is not extracted by this example. Animations and transitions are not reproduced in the Word document.

**Can I save as DOC instead of DOCX?**

Yes. Change the output filename to `output.doc`. Aspose.Words selects the output format from the filename extension when using this save overload.

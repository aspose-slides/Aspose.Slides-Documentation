---
title: Convert PPTX to PPT in Python
linktitle: PPTX to PPT
type: docs
weight: 21
url: /python-java/convert-pptx-to-ppt/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPTX
- PPTX to PPT
- save PPTX as PPT
- export PPTX to PPT
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Convert PPTX to legacy PPT format in Python with Aspose.Slides for Python via Java. Includes a code example and notes on compatibility and protected files."
---

## **Overview**

Aspose.Slides for Python via Java lets you convert a PPTX presentation to the legacy PPT format used by PowerPoint 97–2003 without Microsoft PowerPoint installed. Load the PPTX file and save it with the PPT output format, as shown below.

## **Convert PPTX to PPT**

Load the source file with the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, then call [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) with the output path and [SaveFormat.Ppt](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Ppt).

The following example starts the Java virtual machine if needed and converts `template.pptx` to `output.ppt` using default options. Replace the paths with your own file names. The `finally` block releases the presentation resources even if saving fails.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Load the PPTX presentation.
presentation = Presentation("template.pptx")
try:
    # Save the presentation in PPT format.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

The [SaveFormat.Ppt](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Ppt) argument selects the output format; changing the file extension alone does not convert a presentation. Keep the original PPTX file so you can return to it if a newer feature has no equivalent in PPT.

## **Convert PPTX to Other Formats**

Aspose.Slides also supports other output formats. See the corresponding articles for format-specific options and examples:

- [Convert PowerPoint to PDF in Python](/slides/python-java/convert-powerpoint-to-pdf/)
- [Convert PowerPoint to XPS in Python](/slides/python-java/convert-powerpoint-to-xps/)
- [Convert PowerPoint to HTML in Python](/slides/python-java/convert-powerpoint-to-html/)
- [Save Presentations as ODP in Python](/slides/python-java/save-presentation/)
- [Convert PowerPoint to PNG in Python](/slides/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Do all PPTX effects and features survive conversion to PPT?**

Not always. The legacy PPT format does not support every feature available in PPTX. Some effects, objects, or behaviors may be simplified or displayed differently. Review the converted presentation in the intended viewer, especially when it contains newer PowerPoint features.

**Can I convert only selected slides to PPT?**

Saving to PPT writes the whole presentation. To convert selected slides, create a new presentation, remove its initial empty slide, clone the required slides into it, and save it as PPT. See [Clone Slides in Python](/slides/python-java/clone-slides/).

**Can I convert a password-protected PPTX file?**

Yes, if you provide the correct password when loading the source presentation. You can also configure protection for the output file. See [Password-Protected Presentations](/slides/python-java/password-protected-presentation/).

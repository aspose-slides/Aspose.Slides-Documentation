---
title: Convert ODP to PPTX in Python
linktitle: ODP to PPTX
type: docs
weight: 10
url: /python-java/convert-odp-to-pptx/
keywords:
- convert OpenDocument
- convert presentation
- convert slide
- convert ODP
- OpenDocument to PPTX
- ODP to PPTX
- save ODP as PPTX
- export ODP to PPTX
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Convert ODP presentations to PPTX with Aspose.Slides for Python via Java. Use a complete Python example without installing PowerPoint or LibreOffice."
---

## **Overview**

This article explains how to convert an OpenDocument (ODP) presentation to PowerPoint (PPTX) format using Aspose.Slides for Python via Java.

## **Convert ODP to PPTX**

The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class can load an ODP file directly. Save the loaded presentation in PPTX format using [SaveFormat](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/).

Follow the [installation instructions](/slides/python-java/installation/) before running the example. Place an ODP presentation named `AccessOpenDoc.odp` in the working directory. The following code starts the JVM if necessary, opens the ODP file, and saves it as `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Save the ODP presentation in PPTX format.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live Example**

Try the [Aspose.Slides Conversion](https://products.aspose.app/slides/conversion/) web app to see ODP to PPTX conversion powered by Aspose.Slides.

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

No. Aspose.Slides for Python via Java reads and writes presentation files without either application. You need the Python package and a compatible Java runtime.

**Are master slides, layouts, and themes preserved during conversion?**

Aspose.Slides maps the source presentation structure and formatting to PPTX. However, ODP and PPTX support different features, so some elements may look different after conversion. Make the required fonts available and review presentations with complex formatting. See [OpenDocument conversion](/slides/python-java/convert-openoffice-odp/) for compatibility considerations.

**Can I convert password-protected ODP files?**

Yes, when you provide the password required to open the file. See [password-protected presentations](/slides/python-java/password-protected-presentation/) for details on loading protected files before saving them in another format.

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

Yes. You can use Aspose.Slides for Python via Java in your backend with the required Java runtime. For a REST API, see [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/).

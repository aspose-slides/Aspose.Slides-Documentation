---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint library
- manage PowerPoint presentations in Python
- read and write PowerPoint in Python
- edit PowerPoint slides in Python
- export PowerPoint to PDF in Python
- export PowerPoint to SVG in Python
- preview slides in Python
- add audio and video to slides in Python
- PowerPoint without Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Start here: install Aspose.Slides for Python via Java, create a first presentation, and find the guides for common tasks, the API reference and support."
---

<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java is a library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in Python applications, without Microsoft PowerPoint; it runs the Aspose.Slides Java engine in your Python process through JPype.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/python-java/installation/">Installation</a></li>
<li><a href="/slides/python-java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/python-java/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/python-java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/python-java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/python-java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/python-java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/python-java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/python-java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/python-java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/python-java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/python-java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/python-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/python-java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/python-java/presentation-design/">Slide design</a></li>
<li><a href="/slides/python-java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/python-java/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Release notes</a></li>
<li><a href="/slides/python-java/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Install Python and a JDK, set `JAVA_HOME`, and create and activate a virtual environment as described in [Installation](/slides/python-java/installation/). Then install JPype and Aspose.Slides from PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Save this code as *hello.py*. It starts the Java Virtual Machine, adds a cloud shape with text to the first slide of a new presentation, and saves the presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Create a presentation with one blank slide.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a cloud shape and set its text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Run it in the same virtual environment:

```sh
python hello.py
```

The script saves *new_presentation.pptx* with one slide holding a cloud shape with the text "Hello, Aspose!". Without a license, the saved file also carries an evaluation watermark — see [Licensing](/slides/python-java/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/python-java/create-presentation/).

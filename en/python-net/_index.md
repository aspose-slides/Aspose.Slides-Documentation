---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint automation Python
- Python PPT library
- export PowerPoint to PDF Python
- export PowerPoint to SVG Python
- edit PowerPoint in Python
- Python PowerPoint without Microsoft Office
- manage PPTX with Python
- slides preview Python
- Python add audio to slides
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Start here: install Aspose.Slides for Python via .NET, create a first presentation, and find the guides for common tasks, the API reference and support."
---

<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET is a Python library for creating, reading, editing and converting PowerPoint and OpenDocument presentations, without Microsoft PowerPoint or Microsoft Office.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/python-net/installation/">Installation</a></li>
<li><a href="/slides/python-net/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/python-net/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/python-net/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/python-net/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/python-net/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/python-net/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/python-net/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/python-net/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/python-net/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/python-net/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/python-net/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/python-net/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/python-net/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/python-net/presentation-design/">Slide design</a></li>
<li><a href="/slides/python-net/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/python-net/examples/">Examples by slide element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Release notes</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Download</a></li>
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

Install the package from PyPI:

```bash
pip install aspose.slides
```

The package includes the .NET runtime it uses, so you do not need to install .NET. On Linux, also install the libgdiplus and ICU libraries, and with the system Python of Debian or Ubuntu, run the command in a virtual environment. macOS has further prerequisites, and we have not verified the installation there. See [Installation](/slides/python-net/installation/) for the commands, the macOS prerequisites, and the supported Python versions.

Save this code as *hello.py*:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto-shape of type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Run it with `python hello.py`. The script saves *new_presentation.pptx* in the current folder, with one slide holding a cloud shape that reads "Hello, Aspose!". Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/python-net/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/python-net/create-presentation/).

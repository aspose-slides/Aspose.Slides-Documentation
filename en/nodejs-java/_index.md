---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /nodejs-java/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Start here: install Aspose.Slides for Node.js via Java, create a first presentation, and find the guides for common tasks, the API reference and support."
is_root: true
---

<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java is a library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in Node.js applications, without Microsoft PowerPoint.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/nodejs-java/installation/">Installation</a></li>
<li><a href="/slides/nodejs-java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/nodejs-java/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/nodejs-java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/nodejs-java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/nodejs-java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/nodejs-java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/nodejs-java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/nodejs-java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/nodejs-java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/nodejs-java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/nodejs-java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/nodejs-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/nodejs-java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/nodejs-java/presentation-design/">Slide design</a></li>
<li><a href="/slides/nodejs-java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/nodejs-java/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Release notes</a></li>
<li><a href="/slides/nodejs-java/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Download</a></li>
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

Besides Node.js 20 or later, the package needs a Java Development Kit (JDK), Python and a C++ build toolchain, because npm compiles its `java` bridge during installation. See [Installation](/slides/nodejs-java/installation/) for the steps on each operating system. Then create a project and install the package from npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Save this code as *hello.js* in the project folder:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides runs in a Java virtual machine that keeps Node.js running, so end the process explicitly.
process.exit(0);
```

Run it with `node hello.js`. The script saves *hello.pptx* with one slide holding a text box. Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/nodejs-java/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/nodejs-java/create-presentation/).

---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /nodejs-net/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Start here: install Aspose.Slides for Node.js via .NET, create a first presentation, and find the guides for common tasks, licensing, the API reference and support."
is_root: true
---

<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET is a library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in Node.js applications, without Microsoft PowerPoint or Office Automation. It runs Aspose.Slides for .NET through the edge-js bridge, so its JavaScript API mirrors the .NET API, with camelCase member names.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/nodejs-net/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/nodejs-net/developer-guide/">Developer guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/nodejs-net/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/nodejs-net/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/nodejs-net/open-presentation/">Open and save a presentation</a></li>
<li><a href="/slides/nodejs-net/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/nodejs-net/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/nodejs-net/manage-text/">Edit text</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API reference</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Release notes</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
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

You need Node.js 22 or 24 and the .NET SDK 8 or later; Linux also needs a few system packages. [Installation](/slides/nodejs-net/installation/) lists them and the platforms that were tested. Create a project, add an override that tells npm which edge-js release to install, and install the package:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Once per machine, restore the .NET packages that the library depends on. Save the `deps.csproj` file from [Restore the .NET Dependencies](/slides/nodejs-net/installation/#restore-the-net-dependencies) in a `deps` folder inside the project folder, then run:

```sh
dotnet restore deps/deps.csproj
```

Save this code as *hello.js* in the project folder:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// A new presentation contains one empty slide.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position and size are in points (1/72 inch): x, y, width, height.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Release the .NET object that backs the presentation.
    presentation.dispose();
}
```

Run it from the project folder:

```sh
node hello.js
```

The script prints `Saved hello.pptx` and saves *hello.pptx* with one slide holding a rectangle with the text. Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/nodejs-net/licensing/). For more ways to create and fill a presentation, see [Create a Presentation](/slides/nodejs-net/create-presentation/).

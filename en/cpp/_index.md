---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /cpp/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Start here: install Aspose.Slides for C++, create a first presentation, and find the guides for common tasks, the API reference and support."
is_root: true
---

<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ is a native C++ library for creating, reading, editing and converting PowerPoint and OpenDocument presentations, without Microsoft PowerPoint or Office Automation.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/cpp/installation/">Installation</a></li>
<li><a href="/slides/cpp/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/cpp/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/cpp/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/cpp/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/cpp/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/cpp/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/cpp/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/cpp/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/cpp/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/cpp/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/cpp/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/cpp/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/cpp/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/cpp/presentation-design/">Slide design</a></li>
<li><a href="/slides/cpp/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/cpp/examples/">Examples by slide element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Release notes</a></li>
<li><a href="/slides/cpp/known-issues/">Known issues</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Download</a></li>
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

On Windows, create a C++ **Console App** project in Visual Studio and install the NuGet package in the Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

On Linux, download the Linux ZIP package and set up the CMake project described in [Installation](/slides/cpp/installation/#linux).

Then use this code as your program's main source file. It creates a presentation with one text box and saves it:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

To run it on Windows, select the **x64** platform in the toolbar and press **Ctrl+F5**. On Linux, save it as *main.cpp* in the project folder, then build and run it there:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

The program saves *hello.pptx* with one slide holding a text box. Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/cpp/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/cpp/create-presentation/).

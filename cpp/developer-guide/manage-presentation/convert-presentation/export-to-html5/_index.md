---
title: Export to HTML5
type: docs
weight: 40
url: /cpp/export-to-html5/
keywords: "PowerPoint to HTML, HTML 5, HTML export, Export presentation, Convert PowerPoint to HTML, C++, Aspose.Slides for C++"
description: "Export PowerPoint to HTML5 in C++" 
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/cpp/aspose-slides-for-cpp-21-9-release-notes/), we implemented support for HTML5 export.

{{% /alert %}} 

The export to HTML5 process here allows you to convert PowerPoint to HTML. This way, using your own templates, you can apply very flexible options that define the export process and the resulting HTML, CSS, JavaScript, and animation attributes. 

## **Export PowerPoint to HTML5**

This C++ code shows how you to export a presentation to HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

In this case, you get clean HTML. 

{{% /alert %}}

You may want to specify settings for shape animations and slide transitions this way:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Export PowerPoint to HTML**

This C++ demonstrates the standard PowerPoint to HTML process:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

In this case, the presentation content is rendered through SVG in a form like this:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

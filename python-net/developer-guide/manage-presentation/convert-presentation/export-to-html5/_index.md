---
title: Export to HTML5
type: docs
weight: 40
url: /python-net/export-to-html5/
keywords: "PowerPoint to HTML, HTML 5, HTML export, Export presentation, Convert PowerPoint to HTML, Python, Aspose.Slides for Python"
description: "Export PowerPoint to HTML5 in Python"
---

{{% alert title="Info" color="info" %}}

In **Aspose.Slides 21.9**, we implemented support for HTML5 export. However, if you prefer to export your PowerPoint to HTML using WebExtensions, see [this article](/slides/net/web-extensions/) instead. 

{{% /alert %}} 

The export to HTML5 process here allows you to convert PowerPoint to HTML without web extensions or dependencies. This way, using your own templates, you can apply very flexible options that define the export process and the resulting HTML, CSS, JavaScript, and animation attributes. 

## **Export PowerPoint to HTML5**

This python code shows how you to export a presentation to HTML5 without web extensions and dependencies:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

In this case, you get clean HTML. 

{{% /alert %}}

You may want to specify settings for shape animations and slide transitions this way:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **Export PowerPoint to HTML**

This python code demonstrates the standard PowerPoint to HTML process:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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

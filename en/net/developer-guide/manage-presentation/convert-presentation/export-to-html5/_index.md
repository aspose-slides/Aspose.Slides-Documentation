---
title: Export to HTML5
type: docs
weight: 40
url: /net/export-to-html5/
keywords:
- PowerPoint to HTML
- slides to HTML
- HTML5
- HTML export
- export presentation
- convert presentation
- convert slides
- C#
- Csharp
- Aspose.Slides for .NET
description: "Export PowerPoint to HTML5 in C# or .NET"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/net/aspose-slides-for-net-21-9-release-notes/), we implemented support for HTML5 export. However, if you prefer to export your PowerPoint to HTML using WebExtensions, see [this article](/slides/net/web-extensions/) instead. 

{{% /alert %}} 

The export to HTML5 process here allows you to convert PowerPoint to HTML without web extensions or dependencies. This way, using your own templates, you can apply very flexible options that define the export process and the resulting HTML, CSS, JavaScript, and animation attributes. 

## **Export PowerPoint to HTML5**

This C# code shows how you to export a presentation to HTML5 without web extensions and dependencies:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

In this case, you get clean HTML. 

{{% /alert %}}

You may want to specify settings for shape animations and slide transitions this way:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Export PowerPoint to HTML**

This C# demonstrates the standard PowerPoint to HTML process:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
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

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This C# code demonstrates the PowerPoint to HTML5 Slide View export process:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## Convert a Presentation to an HTML5 Document with Comments

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `NotesCommentsLayouting` property of the [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

The "output.html" document is shown in the image below.

![The comments in the output HTML5 document](two_comments_html5.png)

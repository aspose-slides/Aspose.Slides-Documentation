---
title: Extract Flash Objects from Presentations in .NET
linktitle: Flash
type: docs
weight: 10
url: /net/flash/
keywords:
- extract flash
- flash object
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to extract Flash objects from PowerPoint and OpenDocument slides in .NET with Aspose.Slides, complete C# code samples and best practices."
---

## **Extract Flash Objects from Presentations**
Aspose.Slides for .NET provides a facility for extracting flash objects from presentation. You can access the flash control by name and extract it from presentation and including store SWF object data.

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```

## **FAQ**

**What presentation formats are supported when extracting Flash content?**

[Aspose.Slides supports](/slides/net/supported-file-formats/) the main PowerPoint formats such as PPT and PPTX, since it can load these containers and access their controls, including Flash-related ActiveX elements.

**Can I convert a presentation with Flash to HTML5 and preserve Flash interactivity?**

No. Aspose.Slides does not execute SWF content or convert its interactivity. While export to [HTML](/slides/net/convert-powerpoint-to-html/)/[HTML5](/slides/net/export-to-html5/) is supported, Flash will not play in modern browsers due to end of support. The recommended path is to replace Flash with alternatives such as video or HTML5 animations before export.

**From a security perspective, does Aspose.Slides execute SWF files while reading a presentation?**

No. Aspose.Slides treats Flash as binary data embedded in the file and does not execute SWF content during processing.

**How should I handle presentations that include Flash along with other embedded files via OLE?**

Aspose.Slides supports [extracting embedded OLE objects](/slides/net/manage-ole/), so you can process all related embedded content in one pass, handling Flash controls and other OLE-embedded documents together.

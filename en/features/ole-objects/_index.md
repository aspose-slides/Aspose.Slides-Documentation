---
title: Work with embedded OLE objects
description: Embed files as OLE objects and manage their stored data.
type: docs
url: /features/ole-objects/
weight: 610
feature_id: ole-objects
feature_group: shapes
translationKey: slides-feature-ole-objects
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-ole/
---

## **Overview**

Add an OLE object to a slide to carry another file inside the presentation. You can read or replace its embedded data and supply a picture that represents the object on the slide. This is useful when a presentation needs to include an associated document.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

Download the public [sample workbook](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Shapes/book1.xlsx) as book1.xlsx in the working directory. This C# example embeds it and supplies a generated preview image. The preview represents the attachment; it is not an automatic rendering of workbook cells.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var workbook = File.ReadAllBytes("book1.xlsx");
var data = new OleEmbeddedDataInfo(workbook, "xlsx");
var frame = presentation.Slides[0].Shapes.AddOleObjectFrame(60, 60, 300, 150, data);
var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"300\" height=\"150\"><rect width=\"300\" height=\"150\" fill=\"#008000\"/><text x=\"30\" y=\"80\" fill=\"white\" font-size=\"24\">Workbook attachment</text></svg>";
var preview = presentation.Images.AddImage(new SvgImage(svg));
frame.SubstitutePictureFormat.Picture.Image = preview;
presentation.Save("ole-objects.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does embedding a file render its contents automatically?**

Use a substitute picture for its slide preview. The embedded file and the picture shown on the slide are separate parts of the object.

### **Does embedding an OLE object run the associated application?**

No. Embedding stores the object data in the presentation. It does not execute Excel or another associated application, calculate workbook formulas, or activate the object.

### **Why should I provide a preview image for the embedded object?**

The preview is what readers see on the slide before the object is activated. Provide an appropriate picture because storing an embedded file does not automatically produce an up-to-date visual preview.

## **Guides**

- [Manage OLE Objects in Presentations in .NET](/slides/net/manage-ole/)

Related feature: [Add pictures to slides](/slides/features/picture-frames/).

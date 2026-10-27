---
title: Add pictures to slides
description: Place embedded images on slides as picture frames.
type: docs
url: /features/picture-frames/
weight: 580
feature_id: picture-frames
feature_group: shapes
translationKey: slides-feature-picture-frames
feature_catalogue_version: 3
feature_guides:
- /slides/net/picture-frame/
---

## **Overview**

Add an image to the presentation and display it in a picture frame at the desired position and size. Frames let you place pictures alongside text and other slide objects. You can read the embedded image data again or adjust how it appears in the frame.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example generates a two-color SVG image in memory and places it in a picture frame. The 300 by 150 point frame matches the source’s 2:1 aspect ratio and embeds the artwork in the PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/><rect x=\"100\" width=\"100\" height=\"100\" fill=\"blue\"/></svg>";
var image = presentation.Images.AddImage(new SvgImage(svg));
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 60, 60, 300, 150, image);
picture.Name = "Two-color picture";
presentation.Save("picture-frames.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I crop a picture without replacing its source image?**

Yes. Picture-frame crop settings can change the visible area while keeping the original embedded image.

### **Can several frames reference the same embedded image?**

Yes. Add the image once to the presentation’s image collection and use that embedded image in multiple frames. Each frame still has its own position, dimensions and crop settings.

### **How do I preserve an image's aspect ratio?**

Calculate the frame width and height using the source image’s aspect ratio. If you choose a different ratio, decide whether to crop, fit or deliberately stretch the picture.

## **Guides**

- [Manage Picture Frames in Presentations in .NET](/slides/net/picture-frame/)

Related feature: [Crop images](/slides/features/crop-images/).

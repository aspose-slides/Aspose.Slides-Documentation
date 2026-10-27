---
title: Crop images
description: Adjust the visible part of an image in a picture frame.
type: docs
url: /features/crop-images/
weight: 590
feature_id: crop-images
feature_group: shapes
translationKey: slides-feature-crop-images
feature_catalogue_version: 3
feature_guides:
- /slides/net/picture-frame/
---

## **Overview**

Crop a picture from its left, right, top or bottom edge to show the part needed by the slide. Normal crop settings keep the source image in the presentation, allowing the crop to be changed later. Permanent crop removal is a separate operation.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates a red-and-blue image and crops 50 percent from its left edge. The frame displays the blue half while the original two-color image remains embedded, allowing the crop to be changed later.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/><rect x=\"100\" width=\"100\" height=\"100\" fill=\"blue\"/></svg>";
var image = presentation.Images.AddImage(new SvgImage(svg));
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 60, 60, 200, 150, image);
picture.PictureFormat.CropLeft = 50;
picture.PictureFormat.CropRight = 0;
picture.PictureFormat.CropTop = 0;
picture.PictureFormat.CropBottom = 0;
presentation.Save("crop-images.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **How can I reduce file size after cropping?**

Remove the cropped image areas when you no longer need them. This changes the stored image rather than only hiding its edges.

### **Can frames sharing the same source image have different crop settings?**

Yes. Crop settings belong to individual picture frames, so two frames can show different regions of the same embedded image.

### **How do crop percentages differ from frame dimensions?**

Crop percentages select the source image region to display. Frame dimensions define the displayed object’s size on the slide in points; changing a frame size does not by itself remove source pixels.

## **Guides**

- [Manage Picture Frames in Presentations in .NET](/slides/net/picture-frame/)

Related feature: [Compress presentations](/slides/features/compress-presentations/).

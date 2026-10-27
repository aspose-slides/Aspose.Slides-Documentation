---
title: Insert and fit images from data
description: Replace template pictures while keeping their frames and layout.
type: docs
url: /features/images-from-data/
weight: 1490
feature_id: images-from-data
feature_group: generation
translationKey: slides-feature-images-from-data
feature_catalogue_version: 3
feature_guides:
- /slides/net/picture-frame/
---

## **Overview**

Load image data and put it into an existing picture frame or a new frame on a slide. Replacing a template image can preserve the frame's position and dimensions, letting a report reuse the designer's layout while changing its visual content.

## **Usage example**

This C# example creates a named picture frame, then replaces its image with caller-supplied PNG bytes while retaining its position and size. Both images are generated inline. `images-from-data.pptx` keeps an editable picture frame, and the PNG previews the new blue image. Use crop or size calculations when real replacement images have different aspect ratios.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var oldBytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAIAAAABCAIAAAB7QOjdAAAAD0lEQVR4nGP8z8DAwMAAAAYIAQHLR3Z1AAAAAElFTkSuQmCC");
var newBytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAIAAAABCAIAAAB7QOjdAAAAD0lEQVR4nGN0zHzIwMAAAAclAY13W70YAAAAAElFTkSuQmCC");
var oldImage = presentation.Images.AddImage(oldBytes);
var frame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 60, 60, 360, 180, oldImage);
frame.Name = "ReportPicture";
var replacement = presentation.Images.AddImage(newBytes);
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IPictureFrame pictureFrame && pictureFrame.Name == "ReportPicture")
        pictureFrame.PictureFormat.Picture.Image = replacement;
}
presentation.Save("images-from-data.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("images-from-data.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Will every source image automatically fit without distortion?**

Your application chooses the fitting behavior. Compute crop or size settings when the source aspect ratio differs from the frame.

### **How can I replace an image without changing its frame position?**

Replace the image reference on the existing picture frame rather than deleting and recreating the shape. Its coordinates and dimensions remain available for your fitting calculations.

### **Can I use image bytes instead of a filesystem path?**

Yes. Add the supplied image bytes to the presentation’s image collection and assign the resulting image to the picture frame. Validate the input format before accepting arbitrary application uploads.

## **Guides**

- [Manage Picture Frames in Presentations in .NET](/slides/net/picture-frame/)

Related feature: [Crop images](/slides/features/crop-images/).

---
title: Add pictures to table cells
description: Use a picture as a table cell's fill.
type: docs
url: /features/table-cell-images/
weight: 910
feature_id: table-cell-images
feature_group: tables
translationKey: slides-feature-table-cell-images
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-cells/
---

## **Overview**

Place an image inside a table cell through its picture-fill settings. The image follows the cell when the table moves and changes size with the cell. This is useful when the picture should be part of the table rather than a separate floating frame.

## **Usage example**

This C# example creates a tiny PNG from inline bytes and uses it as the first cell’s picture fill. Stretch mode fills the cell and can change an image’s aspect ratio. It creates `table-cell-images.pptx` and a PNG preview without an external image file.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var imageBytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP4z8DAwPCfkeE/w38GBgAc+AP+/XLlFAAAAABJRU5ErkJggg==");
var picture = presentation.Images.AddImage(imageBytes);
var table = presentation.Slides[0].Shapes.AddTable(40, 40, new double[] { 180, 240 }, new double[] { 120 });
table[1, 0].TextFrame.Text = "Picture fill in the first cell";
var fill = table[0, 0].CellFormat.FillFormat;
fill.FillType = FillType.Picture;
fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
fill.PictureFillFormat.Picture.Image = picture;
presentation.Save("table-cell-images.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("table-cell-images.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can I position a small image freely within the cell?**

A picture fill occupies the cell. Use a separate picture frame if you need independent size, padding or placement.

### **Does a cell image fill create a separate picture shape?**

No. The picture is a cell background fill and remains part of the table. Use a picture frame when you need a separate shape.

### **How can I control how the image fits the cell?**

Choose picture-fill settings such as stretch or tile according to the desired result. Stretch fills the cell; use a separate picture frame for independently controlled cropping or placement.

## **Guides**

- [Manage Table Cells in Presentations in .NET](/slides/net/manage-cells/)

Related feature: [Add pictures to slides](/slides/features/picture-frames/).

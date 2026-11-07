---
title: Compress presentations
description: Reduce presentation size by compressing images and removing unused content.
type: docs
url: /features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---

## **Overview**

Compress pictures, remove cropped image areas when they are no longer needed, and choose presentation compression settings before saving. This is useful for decks with large photographs or repeated media. The amount saved depends on the content and settings you choose.

## **Usage example**

This C# example loads `input.pptx`, compresses the presentation, and saves it as `compressed.pptx`.

Use Aspose.Slides for .NET 26.11 or later. For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Is this a single whole-file optimization switch?**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), which combines unused layout/master removal, embedded-font subsetting and 150-DPI picture compression. It permanently removes cropped picture areas. For picture-only processing, use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); for finer control, see the [individual-picture compression example](/slides/net/examples/optimization-batch/compression/). These new helpers are specific to the stated .NET version; check the corresponding guide for other SDKs.

### **Does image compression change editable text or charts?**

Picture compression targets picture data, not editable text or chart data. Review the images because resizing or recompression can reduce their detail.

### **How should I choose a resolution for presentation images?**

Choose a target based on the displayed picture size and intended screen or print use. Keep more resolution for large displays, printing and detailed diagrams, and compare the rendered output before discarding the original.

## **Guides**

- [Compress the Whole Presentation in .NET](/slides/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimize Image Management in Presentations in .NET](/slides/net/image/)

Related feature: [Remove unused masters, layouts and media](/slides/features/remove-unused-content/).

## Runnable .NET examples

- [Reduce Presentation Size](/slides/net/examples/optimization-batch/compression/)

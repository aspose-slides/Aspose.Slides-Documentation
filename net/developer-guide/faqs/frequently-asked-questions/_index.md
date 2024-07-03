---
title: Frequently Asked Questions
type: docs
weight: 10
url: /net/frequently-asked-questions/
---

## **Supported File Formats**

**Q: What file formats does Aspose.Slides for .NET support?**

**A**: Aspose.Slides for .NET supports the file formats described in [Supported File Formats](/slides/net/supported-file-formats/).

## **Exceptions**

**Q: I am getting an OutOfMemoryException while importing a large PPT file with images to MemoryStream. Is there a limitation in Aspose.Slides regarding file size?**

**A** : There is no specific formula for calculating the presentation size supported by Aspose.Slides. There should be enough space to accommodate the whole presentation structure and images in memory. Normally, images in the memory occupy more space than the hard disk, especially when images have additional effects.

In general, Aspose.Slides for .NET can easily handle presentation files of around 300 MB on a server with 4 GB RAM.

## **Working with Slides**

**Q: Can I change the size of the slides in a presentation?**

**A** : You can use the `SlideSize` property exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class to define the size of the slides in a presentation.

**Q: Is there a way to define slides of different size in a presentation?**

**A**: Since the size of slides is defined at presentation level in Microsoft PowerPoint documents, there is no way to do this.

**Q: Does Aspose.Slides for .NET support previewing a slide before saving?**

**A**: You can render the presentation slides to images and can use these images for previewing the slides.

## **Working with Presentations**

**Q: Is it possible to scan text from a presentation?**

**A** : Aspose.Slides for .NET 4 and later provides the [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) class under the `Aspose.Slides.Util` namespace that provides various methods for retrieving whole text from the presentations.

## **Formatting and Images**

**Q: How can I set the color of a table border?**

**A**: You can change the color of all table borders or just the border around the entire table. For changing all borders, please use the [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/).`CellFormat` property. For the border of the entire table, you should iterate cells and change the color of the outer borders.

**Q: What measure does Aspose.Slides for .NET use to place pictures?**

**A**: The coordinates and sizes of all shapes on the slides are measured in points (72 dpi).

## **Working with Fonts**

**Q: When converting PPT to PDF or images, why are the fonts different in the output documents?**

**A**: This issue might indicate that the fonts used in the presentation are missing from the operating system on which the code was executed. You should install the fonts on the operating system or load them as external fonts using the [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) class as below:
```cs
FontsLoader.LoadExternalFonts(new string[] { "path_to_your_fonts" });
```

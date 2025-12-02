---
title: FAQ
type: docs
weight: 340
url: /python-net/faq/
keywords:
- FAQ
- presentation format
- out of memory error
- slide size
- extract text
- retrieve text
- paragraph size
- formatting tables
- font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Get answers to FAQ on Aspose.Slides for Python via .NET, covering PowerPoint and OpenDocument support, installation guidance, licensing, troubleshooting."
---

## **Supported File Formats**

**Q: What file formats does Aspose.Slides for Python via .NET support?**

**A**: Aspose.Slides for Python via .NET supports the file formats described in [Supported File Formats](/slides/python-net/supported-file-formats/).

## **Exceptions**

**Q: I am getting an out of memory exception while loading a large PPT file with images. Is there a limitation in Aspose.Slides regarding file size?**

**A**: There is no specific formula for calculating the presentation size supported by Aspose.Slides. There should be enough space to accommodate the whole presentation structure and images in memory. Normally, images in the memory occupy more space than the hard disk, especially when images have additional effects.

In general, Aspose.Slides for Python via .NET can easily handle presentation files of around 300 MB on a server with 4 GB RAM.

## **Working with Slides**

**Q: Can I change the size of the slides in a presentation?**

**A**: You can use the `slide_size` property exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to define the size of the slides in a presentation.

**Q: Is there a way to define slides of different size in a presentation?**

**A**: Since the size of slides is defined at presentation level in Microsoft PowerPoint documents, there is no way to do this.

**Q: Does Aspose.Slides for Python via .NET support previewing a slide before saving?**

**A**: You can render the presentation slides to images and can use these images for previewing the slides.

## **Working with Text**

**Q: Is it possible to retrieve all the text from a presentation?**

**A**: Aspose.Slides for Python via .NET provides the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class under the `aspose.slides.util` namespace that provides various methods for retrieving whole text from the presentations.

**Q: Why are paragraph sizes different on Windows and Linux operating systems?**

**A**: The calculation of paragraph sizes is based on the calculation of the text size representing the given paragraph. The text size calculation is based on the metrics of the font specified in the PowerPoint presentation. If the specified font is missing, it is replaced with the most similar font, but this font has metrics different from the original ones. As a result, the calculation of paragraph sizes in different systems will lead to different results depending on the set of installed fonts. To achieve the same result on different operating systems, you need to install the same fonts on the systems or load them at runtime as [external fonts](/slides/python-net/custom-font/).

## **Formatting and Images**

**Q: How can I set the color of a table border?**

**A**: You can change the color of all table borders or just the border around the entire table. For changing all borders, please use the `cell_format` property from the [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) class. For the border of the entire table, you should iterate cells and change the color of the outer borders.

**Q: What measure does Aspose.Slides for Python via .NET use to place pictures?**

**A**: The coordinates and sizes of all shapes on the slides are measured in points (72 dpi).

## **Working with Fonts**

**Q: When converting PPT to PDF or images, why are the fonts different in the output documents?**

**A**: This issue might indicate that the fonts used in the presentation are missing from the operating system on which the code was executed. You should install the fonts on the operating system or load them as external fonts using the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class as shown below:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```

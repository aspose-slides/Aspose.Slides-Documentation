---
title: Customize PowerPoint Fonts in Python
linktitle: Custom Font
type: docs
weight: 20
url: /python-net/custom-font/
keywords:
- font
- custom font
- external font
- load font
- manage fonts
- font folder
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Embed custom fonts in PowerPoint slides with Aspose.Slides for Python via .NET to keep your presentations sharp and consistent across any device."
---

## **Overview**

Aspose.Slides for Python lets you provide custom fonts at runtime so presentations render correctly even when the required fonts aren’t installed on the host system. During export to PDF or images, you can supply font folders or in-memory font data to preserve text layout, glyph metrics, and typography. This makes server-side rendering predictable across different environments, removes OS-level font dependencies, and prevents unwanted fallbacks or reflow. The article shows how to register font sources.

Aspose.Slides lets you load the following fonts using the `load_external_font` and `load_external_fonts` methods of the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class:

- TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Load Custom Fonts**

Aspose.Slides lets you load fonts for rendering presentations without installing them. The fonts are loaded from a custom directory.

1. Call the `load_external_fonts` method from [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).
1. Load the presentation to be rendered.
1. Clear the cache in the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class.

The following Python code demonstrates the font-loading process:

```python
import aspose.slides as slides

# Folders to search for fonts.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# Load fonts from the custom directories.
slides.FontsLoader.load_external_fonts(font_folders)

# Render the presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# Clear the font cache.
slides.FontsLoader.clear_cache()
```

## **Get the Custom Fonts Folder**

Aspose.Slides provides the `get_font_folders` method to retrieve font folders. It returns both the folders added through `load_external_fonts` and the system font folders.

This Python code shows how to use `get_font_folders`:

```python
import aspose.slides as slides

# This call returns the folders checked for font files.
# These include folders added via the load_external_fonts method and the system font folders.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Specify Custom Fonts for a Presentation**

Aspose.Slides provides the `document_level_font_sources` property, which lets you specify external fonts to use with a presentation.

The following Python example shows how to use `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Work with the presentation.
    # CustomFont1, CustomFont2, and fonts from the assets\fonts and global\fonts folders (and their subfolders) are available to the presentation.
    # ...
    print(len(presentation.slides))
```

## **Load External Fonts from Binary Data**

Aspose.Slides provides the `load_external_font` method to load external fonts from binary data.

The following Python example demonstrates loading a font from a byte array:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Load external fonts from byte arrays.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # External fonts are available for the lifetime of this presentation instance.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

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

Aspose.Slides allows you to load fonts used in a presentation without installing them on the system. This affects export output—such as PDF, images, and other supported formats—so the resulting documents look consistent across environments. Fonts are loaded from custom directories.

1. Specify one or more folders that contain the font files.
2. Call the static [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) method to load fonts from those folders.
3. Load and render/export the presentation.
4. Call [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) to clear the font cache.

The following code example demonstrates the font loading process:

```py
import aspose.slides as slides

# Define folders that contain custom font files.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Load custom fonts from the specified folders.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Clear the font cache after the work is finished.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) adds additional folders to the font search paths, but it does not change the font initialization order.
Fonts are initialized in this order:

1. The default operating system font path.
1. The paths loaded via [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

{{%/alert %}}

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

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/python-net/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/python-net/font-substitution/), [replacement rules](/slides/python-net/font-replacement/), and [fallback sets](/slides/python-net/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.

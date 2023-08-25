---
title: Custom PowerPoint Font in Python
linktitle: Custom Font
type: docs
weight: 20
url: /python-net/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint custom fonts in Python"
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the `load_external_fonts` method the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts that are rendered in presentations without having to install those fonts. The fonts are loaded from a custom directory. 

1. Create an instance of the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class and call the `load_external_fonts` method.
2. Load the presentation that will be rendered.
3. Clear the cache in the [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) class.

This Python code demonstrates the font loading process:

```python
import aspose.slides as slides

# The path to the documents directory.
dataDir = "C:\\"

# folders to seek fonts
folders = [ dataDir ]

# Loads the custom font directory fonts
slides.FontsLoader.load_external_fonts(folders)

# Do some work and perform presentation/slide rendering
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Clears the font Cachce
slides.FontsLoader.clear_cache()
```

## **Get Custom Fonts Folder**
Aspose.Slides provides the `get_font_folders()` method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This Python code shows you how to use `get_font_folders()`:

```python
#  This line outputs the folders that are checked for font files.
# Those are folders added through the load_external_fonts method and system font folders.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the `document_level_font_sources` property to allow you to specify external fonts that will be used with the presentation.

This Python code shows you how to use the `document_level_font_sources` property:

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # Work with the presentation
            # CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
            print(len(presentation.slides))
```

## **Manage Fonts Externally**

Aspose.Slides provides the `load_external_font`(data) method to allow you to load external fonts from binary data.

This Python code demonstrates the byte array font loading process:

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # external font loaded during the presentation lifetime
        print("processing")
finally:
    FontsLoader.clear_cache()

```


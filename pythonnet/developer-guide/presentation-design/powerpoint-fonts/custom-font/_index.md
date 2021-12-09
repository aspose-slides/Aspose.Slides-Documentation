---
title: Custom Font
type: docs
weight: 20
url: /pythonnet/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint custom fonts in Python"
---

## **Load Custom Fonts from .TTF**
Aspose.Slides lets you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them. Please follow the steps below to loading Fonts from external directories by using Aspose.Slides for Python via .NET API:

- Create an instance of FontsLoader Class and call the static method LoadExternalFonts.
- Perform render the presentation.
- Clear the cache in the FontsLoader Class.

The implementation of the above is given below.

```py
import aspose.slides as slides

# The path to the documents directory.
dataDir = "C:\\"

# folders to seek fonts
folders = [ dataDir ]

# Load the custom font directory fonts
slides.FontsLoader.load_external_fonts(folders)

# Do Some work and perform presentation/slides rendering
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Clear Font Cachce
slides.FontsLoader.clear_cache()
```

## **Get Custom Fonts Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

```py
# The following line shall return folders where font files are searched.
# Those are folders that have been added with LoadExternalFonts method as well as system font folders.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **Specify Custom Fonts Used With Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

```py
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            #work with the presentation
            #CustomFont1, CustomFont2 as well as fonts from assets\fonts
            #  & global\fonts folders and their subfolders are available to the presentation
            print(len(presentation.slides))
```


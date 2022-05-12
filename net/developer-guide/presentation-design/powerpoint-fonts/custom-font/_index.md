---
title: Custom Font - PowerPoint C# API
linktitle: Custom Font
type: docs
weight: 20
url: /net/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint custom fonts in C# or .NET"
---

## **Load Custom Fonts from .TTF**
Aspose.Slides lets you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them. Please follow the steps below to loading Fonts from external directories by using Aspose.Slides for .NET API:

- Create an instance of FontsLoader Class and call the static method LoadExternalFonts.
- Perform render the presentation.
- Clear the cache in the FontsLoader Class.

The implementation of the above is given below.

``` csharp
// The path to the documents directory.
string dataDir = "C:\\";

// folders to seek fonts
String[] folders = new String[] { dataDir };

// Load the custom font directory fonts
FontsLoader.LoadExternalFonts(folders);

// Do Some work and perform presentation/slides rendering
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Clear Font Cachce
FontsLoader.ClearCache();
```

## **Get Custom Fonts Folder**
A new property has been added that returns folders where font files are searched. Those are folders that have been added with LoadExternalFonts method as well as system font folders.

```c#
//The following line shall return folders where font files are searched.
//Those are folders that have been added with LoadExternalFonts method as well as system font folders.
string[] fontFolders = FontsLoader.GetFontFolders();

```


## **Specify Custom Fonts Used With Presentation**
A new DocumentLevelFontSources property has been added to ILoadOptions interface. It allows to specify external fonts that are used with the presentation. Sample Code is given below.

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    //work with the presentation
    //CustomFont1, CustomFont2 as well as fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
}
```


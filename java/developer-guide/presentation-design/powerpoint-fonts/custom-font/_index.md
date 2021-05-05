---
title: Custom Font
type: docs
weight: 20
url: /java/custom-font/
---

{{% alert color="primary" %}} 

Aspose.Slides let you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them.

{{% /alert %}}

## **Load Custom Fonts from .TTF**
Please follow the steps below to loading Fonts from external directories by using Aspose.Slides for Java API:

- Create an instance of [FontsLoader](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader) class and call the static method [loadExternalFonts](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#loadExternalFonts-java.lang.String:A-).
- Perform render the presentation.
- [Clear the cache](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) in the [FontsLoader](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader) class.

The implementation of the above is given below.

```java
// folders to seek fonts
String[] folders = new String[] { externalFontsDir };

// Load the custom font directory fonts
FontsLoader.loadExternalFonts(folders);

// Do Some work and perform presentation/slides rendering
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Clear Font Cachce
    FontsLoader.clearCache();
}
```

## **Get Custom Fonts Folder**
A new method has been added that returns folders where font files are searched. Those are folders that have been added with [loadExternalFonts](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#loadExternalFonts-java.lang.String:A-) method as well as system font folders.

```java
//The following line shall return folders where font files are searched.
//Those are folders that have been added with LoadExternalFonts method as well as system font folders.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used With Presentation**
A new [getDocumentLevelFontSources](https://apireference.aspose.com/slides/java/com.aspose.slides/ILoadOptions#getDocumentLevelFontSources--) method has been added to [ILoadOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ILoadOptions) interface. It allows to specify external fonts that are used with the presentation.

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    //work with the presentation
    //CustomFont1, CustomFont2 as well as fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
} finally {
    if (pres != null) pres.dispose();
}
```




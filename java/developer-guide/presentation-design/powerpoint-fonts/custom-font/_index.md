---
title: Custom Font
type: docs
weight: 20
url: /java/custom-font/
---

{{% alert color="primary" %}} 

Aspose.Slides let you load fonts for rendering in presentations without even installing them. This article shows how to load fonts without installing them.


{{% /alert %}} 
## **Load Fonts from External Directories**
Please follow the steps below to loading Fonts from external directories:

1. Call the static method [**loadExternalFonts**](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#loadExternalFonts-java.lang.String:A-) of [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class.
1. Perform renders the presentation.
1. Clear the cache in the [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class.

The implementation of the above is given below.

~~~java
// Folders to seek fonts
String[] folders = new String[] { fontsFolder };

// Load the custom font directory fonts
FontsLoader.loadExternalFonts(folders);

// Do Some work and perform presentation/slides rendering
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    ImageIO.write(pres.getSlides().get_Item(0).getThumbnail(1f, 1f), 
        "PNG", new java.io.File("outputImage.png"));
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}

// Clear Font Cache
FontsLoader.clearCache();
~~~

## **Load Fonts from Binary Data**
Also you can load fonts externally using a byte array. [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class offer, [**loadExternalFont**](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#loadExternalFont-byte:A-) method that allows to add fonts from binary data.

~~~java
// External Font Binary Data
byte[] fontData = Files.readAllBytes(Paths.get("CustomFont.ttf"));

// Load the custom font binary data
FontsLoader.loadExternalFont(fontData);

// Do Some work and perform presentation/slides rendering
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    ImageIO.write(pres.getSlides().get_Item(0).getThumbnail(1f, 1f),
        "PNG", new java.io.File("outputImage.png"));
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}

// Clear Font Cache
FontsLoader.clearCache();
~~~

## **Get Custom Fonts Folder**
Use [**getFontFolders**](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#getFontFolders--) method of [FontsLoader](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontsLoader) class to get the folders where font files are searched. Those are folders that have been added with [**loadExternalFonts**](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsLoader#loadExternalFonts-java.lang.String:A-) method as well as system font folders.

~~~java
//The following line shall return folders where font files are searched.
//Those are folders that have been added with loadExternalFonts method as well as system font folders.
String[] fontFolders = FontsLoader.getFontFolders();
~~~

## **Specify Custom Fonts Used With Presentation**
The methods [getDocumentLevelFontSources](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions#getDocumentLevelFontSources--) and [setDocumentLevelFontSources](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) of [LoadOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions) class allow to specify external fonts that are used with the presentation.

~~~java
try {
    // External Font Binary Data
    byte[] fontData1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
    byte[] fontData2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));
    
	// Use LoadOptions to specify external fonts 
    LoadOptions lo = new LoadOptions();
    lo.getDocumentLevelFontSources().setFontFolders(new String[]{"assets/fonts", "global/fonts"});
    lo.getDocumentLevelFontSources().setMemoryFonts(new byte[][]{fontData1, fontData2});
    
	// Load the presentation with external fonts
	Presentation pres = new Presentation("MyPresentation.pptx", lo);
    try {
        // Work with the presentation
        // CustomFont1, CustomFont2 as well as fonts from assets\fonts & global\fonts folders 
        // and their subfolders are available to the presentation
    } finally {
        if (pres != null) pres.dispose();
    }
} catch (IOException e) {}
~~~
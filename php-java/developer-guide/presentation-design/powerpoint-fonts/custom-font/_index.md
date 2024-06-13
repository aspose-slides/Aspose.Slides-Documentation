---
title: Custom PowerPoint Font
linktitle: Custom Font
type: docs
weight: 20
url: /php-java/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint custom fonts "
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [loadExternalFonts](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts that are rendered in presentations without having to install those fonts. The fonts are loaded from a custom directory. 

1. Create an instance of the [FontsLoader](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/) class and call the [loadExternalFonts](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method.
2. Load the presentation that will be rendered.
3. [Clear the cache](https://reference.aspose.com/slides/php-java/com.aspose.slides/FontsLoader#clearCache--) in the [FontsLoader](https://reference.aspose.com/slides/php-java/com.aspose.slides/FontsLoader) class.

This Java code demonstrates the font loading process:

```php
  // Folders to seek fonts
  $folders = new String[]{ $externalFontsDir };
  // Loads the custom font directory fonts
  FontsLoader->loadExternalFonts($folders);
  // Do Some work and perform presentation/slide rendering
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
    // Clears Font Cachce
    FontsLoader->clearCache();
  }

```

## **Get Custom Fonts Folder**
Aspose.Slides provides the [getFontFolders](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/#getFontFolders--) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This Java code shows you how to use [getFontFolders](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/#getFontFolders--):

```php
  // This line outputs folders where font files are searched.
  // Those are folders added through the LoadExternalFonts method and system font folders.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property to allow you to specify external fonts that will be used with the presentation.

This Java code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property:

```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if ($dis1 != null) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if ($dis2 != null) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(new String[]{ "assets/fonts", "global/fonts" });
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(new byte[][]{ $memoryFont1, $memoryFont2 });
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    // Work with the presentation
    // CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Manage Fonts Externally**

Aspose.Slides provides the [loadExternalFont](https://reference.aspose.com/slides/php-java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) method to allow you to load external fonts from binary data.

This Java code demonstrates the byte array font loading process:

```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))::TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if ($dis != null) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if ($dis != null) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if ($dis != null) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      // external font loaded during the presentation lifetime
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }

```


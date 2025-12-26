---
title: Customize PowerPoint Fonts in PHP
linktitle: Custom Font
type: docs
weight: 20
url: /php-java/custom-font/
keywords:
- font
- custom font
- external font
- load font
- manage fonts
- font folder
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Customize fonts in PowerPoint slides with Aspose.Slides for PHP via Java to keep your presentations sharp and consistent across any device."
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts used in a presentation without installing them on the system. This affects export output—such as PDF, images, and other supported formats—so the resulting documents look consistent across environments. Fonts are loaded from custom directories.

1. Specify one or more folders that contain the font files.
2. Call the static [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) method to load fonts from those folders.
3. Load and render/export the presentation.
4. Call [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) to clear the font cache.

The following code example demonstrates the font loading process:

```php
// Define folders that contain custom font files.
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Clear the font cache after the work is finished.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) adds additional folders to the font search paths, but it does not change the font initialization order.
Fonts are initialized in this order:

1. The default operating system font path.
1. The paths loaded via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides provides the [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This PHP code shows you how to use [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
  # This line outputs folders where font files are searched.
  # Those are folders added through the LoadExternalFonts method and system font folders.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides provides the [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property to allow you to specify external fonts that will be used with the presentation.

This PHP code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property:

```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # Work with the presentation
    # CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Manage Fonts Externally**

Aspose.Slides provides the [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) method to allow you to load external fonts from binary data.

This PHP code demonstrates the byte array font loading process:

```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # external font loaded during the presentation lifetime
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/php-java/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/php-java/font-substitution/), [replacement rules](/slides/php-java/font-replacement/), and [fallback sets](/slides/php-java/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.

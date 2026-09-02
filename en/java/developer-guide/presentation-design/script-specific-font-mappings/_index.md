---
title: Manage Script-Specific Theme Fonts in Java
linktitle: Script-Specific Theme Fonts
type: docs
weight: 15
url: /java/script-specific-font-mappings/
keywords:
- script-specific font
- theme font mapping
- multilingual presentation
- writing system
- Cyrillic font
- Arabic font
- Japanese font
- Georgian font
- Thaana font
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Inspect, add, replace, and remove script-specific font mappings in PowerPoint themes with Aspose.Slides for Java."
---

## **Overview**

A presentation theme can select different font families for different writing systems. This allows multilingual text that still uses theme fonts to follow one coordinated font scheme while using suitable fonts for Cyrillic, Arabic, Japanese, Georgian, Thaana, and other scripts.

The theme's [IFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) contains a major font collection, typically used for headings, and a minor font collection, typically used for body text. In addition to their Latin and East Asian font settings, both collections expose mappings from writing-system tags to font family names through the [IFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifonts/) interface.

This article shows how to inspect and modify those mappings in the presentation's master theme and verify that the changes survive a save-and-reload cycle.

## **Understand Script Tags**

The script font methods use four-letter BCP 47 script subtags to identify writing systems. Common values include:

| Script tag | Writing system |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

These mappings belong to the theme font scheme, not to individual text portions. A presentation may define different mappings for the major and minor collections, and it may omit mappings for some scripts.

## **Access and Inspect Script Font Mappings**

Use [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasterTheme--) to access the presentation-level theme. The [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/#getMajor--) and [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/#getMinor--) methods return the two [IFonts](https://reference.aspose.com/slides/java/com.aspose.slides/ifonts/) collections.

Call [IFonts.getScriptFontMap](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#getScriptFontMap--) to retrieve all mappings from a collection. To look up one writing system, call [IFonts.getScriptFont](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) with its script tag. `getScriptFont` returns `null` when that collection does not define the requested mapping.

## **Modify Mappings and Verify Persistence**

Use [IFonts.setScriptFont](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) to create a mapping or replace its current font family. Use [IFonts.removeScriptFont](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) to remove a mapping.

The following end-to-end example reads all existing major and minor mappings, looks up the Japanese major font, changes the Cyrillic major font, removes the Thaana minor mapping, saves the presentation, and reopens it to verify both changes. To make the removal step independent of the initial theme, the example first creates a Thaana mapping only when one is not already defined.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

The verification uses the same `null` behavior as an ordinary lookup: after the removal is saved, `getScriptFont("Thaa")` returns `null` for the minor collection.

## **Distinguish Theme Mappings from Other Font Settings**

Script-specific theme mappings participate in font selection, but they solve a different problem from direct text formatting, substitution, and fallback:

| Mechanism | Purpose | Effect of changing a theme mapping |
|---|---|---|
| Script-specific theme font mapping | Selects a major or minor theme font for a writing system. | Text that still uses the corresponding theme font can resolve to the new mapped family. |
| Font assigned explicitly to a text portion | Fixes the requested font family on that portion instead of relying on the theme. | The portion may remain unchanged because its direct formatting overrides the theme choice. |
| Font substitution | Replaces a requested font when that font is unavailable or when a substitution rule applies. | It acts after a font has been requested; it does not redefine the theme's script mapping. |
| Font fallback | Supplies glyphs that the selected font does not contain, often for specific Unicode ranges. | It fills missing glyph coverage; it does not change the stored theme mapping. |

For more information about the last two mechanisms, see [Font Substitution](/slides/java/font-substitution/) and [Fallback Fonts](/slides/java/fallback-font/).

Changing a mapping in [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasterTheme--) affects only content whose effective formatting still depends on that theme. Text can instead inherit a theme override from a master, layout, or slide, or use an explicitly assigned font. Inspect those levels when the visible result does not follow the presentation-level mapping.

## **Make Mapped Fonts Available and Validate the Result**

A script mapping stores a font family name; it does not install or load the corresponding font file. For consistent rendering and export, every mapped font must be installed in the environment or supplied to Aspose.Slides through a custom source such as [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) or [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). See [Custom Fonts](/slides/java/custom-font/) for the available loading options.

Verifying the saved mapping confirms only that the theme definition was preserved. It does not prove that the font is available, contains all required glyphs, or produces the intended layout. Render representative text for every required writing system to an image or PDF and inspect the output. This catches missing fonts, incomplete glyph coverage, fallback behavior, and layout changes before the presentation is distributed. See [Convert PowerPoint Presentations](/slides/java/convert-powerpoint/) for rendering and export examples.

## **FAQ**

**What does `getScriptFont` return when a script is not mapped?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) returns `null` when the requested script mapping is not defined in that major or minor font collection.

**Does `setScriptFont` add a second mapping when the script already exists?**

No. [IFonts.setScriptFont](https://reference.aspose.com/slides/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) creates the mapping when it is missing and replaces the mapped font family when the same script tag is already present.

**Why did changing a theme mapping not change some text?**

The text may have an explicitly assigned font, inherit a different theme through an override, or be affected by substitution or fallback during rendering. A presentation-level script mapping controls only text whose effective formatting still refers to that theme font collection.

**Is saving and reopening enough to validate multilingual output?**

No. Reopening verifies persistence of the theme data. Also render representative text from each required writing system to confirm that the mapped fonts are available and contain the necessary glyphs.

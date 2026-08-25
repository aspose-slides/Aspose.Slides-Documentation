---
title: Manage Script-Specific Theme Fonts in Python
linktitle: Script-Specific Theme Fonts
type: docs
weight: 15
url: /python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Inspect, add, replace, and remove script-specific font mappings in PowerPoint themes with Aspose.Slides for Python via .NET."
---

## **Overview**

A presentation theme can select different font families for different writing systems. This allows multilingual text that still uses theme fonts to follow one coordinated font scheme while using suitable fonts for Cyrillic, Arabic, Japanese, Georgian, Thaana, and other scripts.

The theme's [FontScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/) contains a major font collection, typically used for headings, and a minor font collection, typically used for body text. In addition to their Latin and East Asian font properties, both collections expose mappings from writing-system tags to font family names through the [Fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/) class.

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

Use [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) to access the presentation-level theme. The [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) and [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) properties return the two [Fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/) collections.

Call [Fonts.get_script_font_map](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/get_script_font_map/) to retrieve all mappings from a collection. To look up one writing system, call [Fonts.get_script_font](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/get_script_font/) with its script tag. `get_script_font` returns `None` when that collection does not define the requested mapping.

## **Modify Mappings and Verify Persistence**

Use [Fonts.set_script_font](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/set_script_font/) to create a mapping or replace its current font family. Use [Fonts.remove_script_font](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/remove_script_font/) to remove a mapping.

The following end-to-end example reads all existing major and minor mappings, looks up the Japanese major font, changes the Cyrillic major font, removes the Thaana minor mapping, saves the presentation, and reopens it to verify both changes. To make the removal step independent of the initial theme, the example first creates a Thaana mapping only when one is not already defined.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

The verification uses the same `None` behavior as an ordinary lookup: after the removal is saved, `get_script_font("Thaa")` returns `None` for the minor collection.

## **Distinguish Theme Mappings from Other Font Settings**

Script-specific theme mappings participate in font selection, but they solve a different problem from direct text formatting, substitution, and fallback:

| Mechanism | Purpose | Effect of changing a theme mapping |
|---|---|---|
| Script-specific theme font mapping | Selects a major or minor theme font for a writing system. | Text that still uses the corresponding theme font can resolve to the new mapped family. |
| Font assigned explicitly to a text portion | Fixes the requested font family on that portion instead of relying on the theme. | The portion may remain unchanged because its direct formatting overrides the theme choice. |
| Font substitution | Replaces a requested font when that font is unavailable or when a substitution rule applies. | It acts after a font has been requested; it does not redefine the theme's script mapping. |
| Font fallback | Supplies glyphs that the selected font does not contain, often for specific Unicode ranges. | It fills missing glyph coverage; it does not change the stored theme mapping. |

For more information about the last two mechanisms, see [Font Substitution](/slides/python-net/font-substitution/) and [Fallback Fonts](/slides/python-net/fallback-font/).

Changing a mapping in [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) affects only content whose effective formatting still depends on that theme. Text can instead inherit a theme override from a master, layout, or slide, or use an explicitly assigned font. Inspect those levels when the visible result does not follow the presentation-level mapping.

## **Make Mapped Fonts Available and Validate the Result**

A script mapping stores a font family name; it does not install or load the corresponding font file. For consistent rendering and export, every mapped font must be installed in the environment or supplied to Aspose.Slides through a custom source such as [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) or [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/document_level_font_sources/). See [Custom Fonts](/slides/python-net/custom-font/) for the available loading options.

Verifying the saved mapping confirms only that the theme definition was preserved. It does not prove that the font is available, contains all required glyphs, or produces the intended layout. Render representative text for every required writing system to an image or PDF and inspect the output. This catches missing fonts, incomplete glyph coverage, fallback behavior, and layout changes before the presentation is distributed. See [Convert PowerPoint Presentations](/slides/python-net/convert-powerpoint/) for rendering and export examples.

## **FAQ**

**What does `get_script_font` return when a script is not mapped?**

[Fonts.get_script_font](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/get_script_font/) returns `None` when the requested script mapping is not defined in that major or minor font collection.

**Does `set_script_font` add a second mapping when the script already exists?**

No. [Fonts.set_script_font](https://reference.aspose.com/slides/python-net/aspose.slides/fonts/set_script_font/) creates the mapping when it is missing and replaces the mapped font family when the same script tag is already present.

**Why did changing a theme mapping not change some text?**

The text may have an explicitly assigned font, inherit a different theme through an override, or be affected by substitution or fallback during rendering. A presentation-level script mapping controls only text whose effective formatting still refers to that theme font collection.

**Is saving and reopening enough to validate multilingual output?**

No. Reopening verifies persistence of the theme data. Also render representative text from each required writing system to confirm that the mapped fonts are available and contain the necessary glyphs.

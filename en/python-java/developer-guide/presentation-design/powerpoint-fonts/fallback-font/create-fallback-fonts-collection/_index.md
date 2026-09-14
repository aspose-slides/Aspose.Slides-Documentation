---
title: Configure Fallback Font Collections in Python via Java
linktitle: Fallback Font Collection
type: docs
weight: 20
url: /python-java/create-fallback-fonts-collection/
keywords:
- fallback font
- fallback rule
- font collection
- configure font
- set up font
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Set up a fallback fonts collection in Aspose.Slides for Python via Java to keep text consistent and crisp in PowerPoint and OpenDocument presentations."
---

## **Overview**

Aspose.Slides allows you to configure a collection of fallback font rules for a presentation. Each fallback rule is represented by the [FontFallBackRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/) class and can be added to a [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrulescollection/).

After creating the collection, you can assign it using the [setFontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) method of the presentation's [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/). The [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) controls fonts across the presentation, and each [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance has its own [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/).

Once the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) is initialized with the fallback font collection, the specified fallback fonts are applied during presentation rendering.

## **Apply Fallback Rules**

Instances of the [FontFallBackRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/) class can be organized into a [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrulescollection/). You can add or remove rules from the collection.

This collection can then be assigned using the [setFontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) class, which controls fonts across the presentation.

Each [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) has a [getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) method that returns its own instance of the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) class.

The following example shows how to create a fallback font rules collection and assign it to the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) of a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

After the [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) is initialized with the fallback font collection, the fallback fonts are applied during presentation rendering.

{{% alert color="info" title="Note" %}}
Read more about how to [render a presentation with a fallback font](/slides/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/python-java/font-replacement/)/[substitution](/slides/python-java/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.

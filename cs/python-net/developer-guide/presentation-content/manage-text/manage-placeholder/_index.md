---
title: Správa zástupných symbolů v prezentacích pomocí Pythonu
linktitle: Správa zástupných symbolů
type: docs
weight: 10
url: /cs/python-net/manage-placeholder/
keywords:
- zástupný symbol
- textový zástupný symbol
- obrázkový zástupný symbol
- grafový zástupný symbol
- výzva textu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše spravujte zástupné symboly v Aspose.Slides pro Python pomocí .NET: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu a OpenDocumentu."
---
## **Overview**

Aspose.Slides vám umožňuje programově spravovat zástupné symboly prezentace. Tento článek vysvětluje, jak najít zástupné symboly na snímcích a změnit jejich text, nastavit vlastní výzvu textu pro rozvržení zástupných symbolů a upravit průhlednost obrázku použitého jako pozadí zástupného symbolu. Obsahuje také stručné FAQ, které objasňuje rozdíl mezi základními zástupnými symboly a lokálními tvary, vysvětluje, jak lze změny zástupných symbolů aplikovat prostřednictvím rozvržení nebo hlavních šablon, a odkazuje na správu zástupných symbolů záhlaví a zápatí.

## **Change Text in Placeholders**

Aspose.Slides for Python vám umožňuje najít a upravit zástupné symboly na snímcích v prezentaci. Aspose.Slides umožňuje upravit text v zástupném symbolu.

**Prerequisite:** Potřebujete prezentaci, která obsahuje zástupný symbol. Takovou prezentaci můžete vytvořit v Microsoft PowerPoint.

Takto použít Aspose.Slides k nahrazení textu v zástupném symbolu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a jako argument předávejte prezentaci.
1. Získejte referenci na snímek podle jeho indexu.
1. Procházejte tvary, abyste našli zástupný symbol.
1. Změňte text pomocí [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) spojeného s [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
1. Uložte upravenou prezentaci.

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Přístup k prvnímu snímku.
    slide = presentation.slides[0]

    # Procházejte tvary a najděte zástupné symboly.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Změňte text v každém zástupném symbolu.
            shape.text_frame.text = "This is Placeholder"

    # Uložte prezentaci na disk.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Prompt Text for a Placeholder**

Standardní a předpřipravená rozvržení obsahují výzvu textu zástupného symbolu, např. **Click to add a title** nebo **Click to add a subtitle**. S Aspose.Slides můžete tyto výzvy nahradit vlastním textem v rozvrženích zástupných symbolů.

Následující příklad v Pythonu ukazuje, jak nastavit výzvu textu pro zástupný symbol:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Procházejte tvary a najděte zástupné symboly.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Image Transparency in a Placeholder**

Aspose.Slides vám umožňuje nastavit průhlednost obrázku na pozadí v textovém zástupném symbolu. Úpravou průhlednosti obrázku v tomto rámečku můžete zvýraznit buď text, nebo obrázek, v závislosti na jejich barvách.

Následující příklad v Pythonu ukazuje, jak nastavit průhlednost obrázku pozadí uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**What is a base placeholder, and how is it different from a local shape on a slide?**

Základní zástupný symbol je původní tvar v rozvržení nebo hlavní šabloně, z něhož tvar snímku dědí — typ, umístění a část formátování pochází z něj. Lokální tvar je nezávislý; pokud neexistuje základní zástupný symbol, dědičnost se neuplatní.

**How can I update all titles or captions across a presentation without iterating over every slide?**

Upravte odpovídající zástupný symbol v rozvržení nebo v hlavní šabloně. Snímky založené na těchto rozvrženích/hlavní šabloně automaticky zdědí změnu.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

Použijte správce HeaderFooter v příslušném rozsahu (normální snímky, rozvržení, hlavní šablona, poznámky/přílohy) k zapnutí nebo vypnutí těchto zástupných symbolů a k nastavení jejich obsahu.
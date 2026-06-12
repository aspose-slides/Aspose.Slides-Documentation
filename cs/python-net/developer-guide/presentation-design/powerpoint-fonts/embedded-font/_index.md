---
title: Vkládání fontů do prezentací v Pythonu
linktitle: Vkládání fontu
type: docs
weight: 40
url: /cs/python-net/embedded-font/
keywords:
- přidat font
- vložit font
- vkládání fontu
- získat vložený font
- přidat vložený font
- odebrat vložený font
- komprimovat vložený font
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vložte TrueType fonty do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET, čímž zajistíte přesné vykreslení na všech platformách."
---
## **Úvod**

**Vkládání fontů do PowerPointu** zajišťuje, že vaše prezentace si zachová zamýšlený vzhled na různých systémech. Ať už používáte unikátní fonty pro kreativitu nebo standardní, vkládání fontů zabraňuje narušení textu a rozvržení.

Pokud jste použili font třetí strany nebo nestandardní font, protože jste byli kreativní, máte ještě více důvodů k jeho vložení. V opačném případě (bez vložených fontů) se může text nebo čísla na snímcích, rozvržení, stylování atd. změnit nebo se proměnit v matoucí obdélníky. 

Využijte třídy [FontsManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontdata/), a [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) k správě vložených fontů.

## **Získání a odebrání vložených fontů**

Jednoduše načtěte nebo odeberte vložené fonty z prezentace pomocí metod [get_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a [remove_embedded_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Tento Python kód vám ukazuje, jak načíst a odebrat vložené fonty z prezentace:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Vykreslete snímek obsahující textové pole, které používá vložený font 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Získejte všechny vložené fonty.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Najděte font 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Odeberte font 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Vykreslete snímek; font 'Calibri' bude nahrazen existujícím.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Uložte prezentaci bez vloženého fontu 'Calibri' na disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Přidání vložených fontů**

Pomocí výčtu [EmbedFontCharacters](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/embedfontcharacters/) a dvou přetížení metody [add_embedded_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/add_embedded_font/) můžete zvolit preferované pravidlo (vkládání) pro vložení fontů do prezentace. Tento Python kód ukazuje, jak vložit a přidat fonty do prezentace:

```python
import aspose.slides as slides

# Načtěte prezentaci.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Uložte prezentaci na disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Komprese vložených fontů**

Optimalizujte velikost souboru kompresí vložených fontů pomocí [compress_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Příklad kódu pro kompresi:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak mohu zjistit, že konkrétní font v prezentaci bude i přesto při vykreslování nahrazen, i když je vložen?**

Zkontrolujte [informace o substituci](/slides/cs/python-net/font-substitution/) ve správci fontů a [pravidla pro záložní/substituční fonty](/slides/cs/python-net/fallback-font/): pokud font není k dispozici nebo je omezen, bude použita záložní varianta.

**Stojí za to vkládat „systémové“ fonty jako Arial nebo Calibri?**

Obvykle ne – jsou téměř vždy dostupné. Ale pro úplnou přenositelnost v „tenkých“ prostředích (Docker, Linuxový server bez předinstalovaných fontů) může vkládání systémových fontů eliminovat riziko nečekaných substitucí.
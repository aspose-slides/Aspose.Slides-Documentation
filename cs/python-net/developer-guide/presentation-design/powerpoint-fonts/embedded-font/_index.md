---
title: "Vkládání písem do prezentací pomocí Pythonu"
linktitle: "Vložená písma"
type: docs
weight: 40
url: /cs/python-net/embedded-font/
keywords:
- "přidat písmo"
- "vložit písmo"
- "vkládání písem"
- "získat vložené písmo"
- "přidat vložené písmo"
- "odstranit vložené písmo"
- "komprimovat vložené písmo"
- "PowerPoint"
- "prezentace"
- "Python"
- "Aspose.Slides"
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro Python přes .NET. Použijte Python k přidání, získání, odebrání a kompresi písem, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písma uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazovat text s těmito písmy, i když nejsou nainstalována na cílovém systému. To pomáhá zachovat zalomení řádků, mezery mezi textem a rozvržení snímků.

Aspose.Slides for Python via .NET vám umožňuje získávat, přidávat a odstraňovat vložená písma prostřednictvím vlastnosti [fonts_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/) objektu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Můžete také snížit velikost dat vloženého písma odebráním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že jeho data jsou k dispozici pro Aspose.Slides a že jeho licence umožňuje vkládání.

## **Získání a odstranění vložených písem**

Použijte [get_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) k vypsání písem uložených v prezentaci. Pro odebrání jednoho předáte písmo ze seznamu metodě [remove_embedded_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/remove_embedded_font/), poté prezentaci uložíte.

Následující příklad vypíše vložená písma v souboru `EmbeddedFonts.pptx` a odstraní Calibri, pokud je přítomen:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Odstranění vloženého písma odstraní jeho uložená data; nemění písmo přiřazené textu. Pokud je písmo nainstalováno na cílovém systému, může text stále používat ho. V opačném případě může vykreslování vyžadovat [font substitution](/slides/cs/python-net/font-substitution/), což může ovlivnit rozvržení.

## **Inspekce dat písma a oprávnění k vložení**

Použijte třídu [FontsManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/) k inspekci písem před jejich vložením. Zavolejte [get_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/) pro získání písem použitých v prezentaci. Pro každé písmo předáte objekt [FontData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontstyletype/) metodě [get_font_bytes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_font_bytes/). Metoda vrací binární data pro daný styl písma nebo `None`, pokud požadované písmo nebo styl není k dispozici. Nepředávejte výsledek `None` metodě [get_font_embedding_level](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/python-net/aspose.slides/embeddinglevel/) je výčtová značka s příznaky, která uvádí omezení vložení uložená v písmu:

- `INSTALLABLE` povoluje vkládání a trvalou instalaci na jiném systému, pokud to licence písma umožňuje.
- `RESTRICTED` zakazuje vkládání, pokud není získáno povolení od právního vlastníka písma, když je to jediný příznak oprávnění k použití.
- `PREVIEW_PRINT` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen pro čtení.
- `EDITABLE` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NO_SUBSETTING` je další omezení, které zakazuje vkládání pouze podmnožiny glifů. Vložit všechny znaky, pokud je tento příznak přítomen.
- `BITMAP_ONLY` je další omezení, které povoluje vložit jen bitmapové řezy, ne vektorová data. Pokud písmo nemá bitmapové řezy, nemůže být vloženo.

Prvních čtyři hodnoty popisují oprávnění k použití, zatímco `NO_SUBSETTING` a `BITMAP_ONLY` lze s nimi kombinovat. Zkontrolujte modifikátory pomocí bitových operací. Protože `INSTALLABLE` je nula, maskujte bity oprávnění k použití a porovnejte výsledek s `INSTALLABLE`. Aktuální písma by měla nastavit nejvýše jeden bit oprávnění k použití. Pro kompatibilitu se staršími písmy, která nastavují více než jeden, níže uvedený pomocník vybírá nejméně restriktivní oprávnění: `EDITABLE`, poté `PREVIEW_PRINT`, poté `RESTRICTED`.

Následující příklad kontroluje běžná, tučná, kurzívní a tučně‑kurzívní data dostupná pro každé písmo vrácené metodou `get_fonts`. Přeskakuje nedostupné styly, omezená písma, pouze bitmapová písma, písma omezená na náhled a tisk, protože výstup zůstává editovatelný, a písma, která jsou již vložena. Pokud má kterýkoli dostupný styl `NO_SUBSETTING`, vloží všechny znaky pro tuto rodinu písma.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Tato inspekce hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, neprokazuje, že jste písmo získali legálně, ani nenahrazuje kontrolu licenční smlouvy písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [add_embedded_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/add_embedded_font/) k vložení písma. Jeho přetížení přijímají buď objekt [FontData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontdata/) nebo pole bajtů obsahující data písma. Výčtová hodnota [EmbedFontCharacters](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/embedfontcharacters/) určuje, které znaky jsou zahrnuty:

- [ALL](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/embedfontcharacters/) vloží všechny znaky ve fontu. Použijte tuto možnost, když příjemci potřebují prezentaci upravovat a zadávat nový text.
- [ONLY_USED](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/embedfontcharacters/) vloží pouze znaky použité v prezentaci ke snížení velikosti souboru. Vyberte tuto možnost pro dokončenou prezentaci, která je primárně určena k prohlížení.

Následující příklad používá [get_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/) k získání písem použitých v souboru `Fonts.pptx` a vloží ty, které ještě nejsou vloženy. Písma k přidání musí být dostupná na počítači, na kterém se kód spouští. Existující vložená písma zachovají své aktuální sady znaků.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Komprese vložených písem**

[compress_embedded_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) snižuje data vložených písem odstraněním nepoužívaných znaků. Funguje na písmech, která jsou již vložena, takže úspora velikosti závisí na množství nepoužitých dat písma, která prezentace obsahuje.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a uloží výsledek jako samostatný soubor:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Uchovejte původní soubor, pokud příjemci mohou později potřebovat přidat text. Znaky odstraněné během komprese již nejsou k dispozici z vloženého písma, i když jste původně vložili všechny znaky.

## **FAQ**

**Jak mohu zkontrolovat, zda bude vložené písmo během vykreslování stále nahrazeno?**

Zavolejte [get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) v prostředí, ve kterém prezentaci vykreslujete, abyste zjistili, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení [font substitution](/slides/cs/python-net/font-substitution/) a pravidla [font fallback](/slides/cs/python-net/fallback-font/). Náhrada (fallback) řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vložit běžná písma, jako jsou Arial a Calibri?**

Rozhodnutí se odvíjí od cílového prostředí. Pokud jsou požadovaná písma dostupná na každém počítači, který prezentaci otevírá nebo vykresluje, může jejich vložení přidat zbytečnou velikost souboru. Pokud mohou příjemci nebo servery tato písma postrádat, může jejich vložení pomoci zachovat zamýšlený vzhled, pokud to licence povolují.
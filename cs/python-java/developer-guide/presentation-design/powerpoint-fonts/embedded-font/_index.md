---
title: "Vkládání písem do prezentací v Pythonu přes Java"
linktitle: "Vložená písma"
type: docs
weight: 40
url: /cs/python-java/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písma
- získat vložené písmo
- přidat vložené písmo
- odebrat vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro Python přes Java. Přidávejte, načítejte, odstraňujte a komprimujte písma, aby byl zachován vzhled textu a snížena velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písma do prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazit text s těmito písmy, i když nejsou nainstalována v cílovém systému. To pomáhá zachovat zalomení řádků, rozestupy textu a rozvržení snímků.

Aspose.Slides for Python via Java umožňuje získávat, přidávat i odstraňovat vložená písma pomocí třídy [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) , kterou vrací metoda [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getFontsManager). Také můžete snížit velikost dat vložených písem odstraněním znaků, které v prezentaci nejsou použity.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že jeho data jsou k dispozici pro Aspose.Slides a že jeho licence povoluje vložení.

## **Získání a odstranění vložených písem**

Použijte [getEmbeddedFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) k vypsání písem uložených v prezentaci. Chcete‑li některé odstranit, předávejte písmo z tohoto seznamu metodě [removeEmbeddedFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) a poté prezentaci uložte.

Následující příklad vypíše vložená písma v souboru `EmbeddedFonts.pptx` a odstraní Calibri, pokud je přítomno:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Odstranění vloženého písma odstraní jeho uložená data; nezmění to písmo přiřazené textu. Pokud je písmo nainstalováno v cílovém systému, může jej text i nadále používat. V opačném případě může při vykreslování dojít k substituci písma, což může ovlivnit rozvržení.

## **Kontrola dat písma a oprávnění k vkládání**

Použijte třídu [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) ke kontrole písem před jejich vložením. Zavolejte [FontsManager.getFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFonts) a získejte tak písma použitá v prezentaci. Pro každé písmo předáte objekt [FontData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontstyletype/) metodě [FontsManager.getFontBytes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFontBytes). Metoda vrací binární data pro daný styl písma, nebo `None`, pokud požadované písmo nebo styl nejsou k dispozici. Výsledek `None` nepředávejte metodě [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embeddinglevel/) je výčtová příznaková enumerace, která hlásí omezení vložení uložená v písmu:

- `Installable` umožňuje vložení a trvalou instalaci na jiném systému, pokud licence písma toto povoluje.
- `Restricted` zakazuje vložení, pokud není získáno povolení od právního vlastníka písma, a to v případě, že je to jediný příznak oprávnění k použití.
- `PreviewPrint` umožňuje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen pro čtení.
- `Editable` umožňuje dočasné použití a dovoluje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vložit jen podmnožinu glyfů. Pokud je tento příznak přítomen, vložte všechny znaky.
- `BitmapOnly` je další omezení, které povoluje vložit jen bitmapové řezy, ne vektorová data. Pokud písmo nemá bitmapové řezy, nelze jej vložit.

Prvních čtyři hodnoty popisují oprávnění k použití, zatímco `NoSubsetting` a `BitmapOnly` lze s nimi kombinovat. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` má hodnotu nula, maskujte bity oprávnění k použití a výsledek porovnávejte s `Installable` místo kontroly jako příznaku. Současná písma by měla nastavit nejvýše jeden bit oprávnění k použití. Pro kompatibilitu se staršími písmy, která nastavují více než jeden, níže uvedený pomocník vybírá nejméně restriktivní oprávnění: `Editable`, potom `PreviewPrint`, potom `Restricted`.

Následující příklad prověří běžná, tučná, kurzívní a tučně‑kurzívní data dostupná pro každé písmo vrácené metodou `getFonts`. Přeskočí nedostupné styly, omezená písma, písma jen bitmapová, písma omezena na náhled a tisk, protože výstup zůstává editovatelný, a písma, která jsou již vložena. Pokud má kterýkoli dostupný styl příznak `NoSubsetting`, vloží všechny znaky pro tuto rodinu písem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tato kontrola hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, nepotvrzuje, že jste písmo získali legálně, ani nenahrazuje kontrolu licence písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [addEmbeddedFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) k vložení písma. Jeho přetížení akceptují buď objekt [FontData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontdata/) nebo pole bajtů obsahující data písma. Výčtová hodnota [EmbedFontCharacters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embedfontcharacters/) určuje, které znaky jsou zahrnuty:

- [All](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embedfontcharacters/) vloží všechny znaky písma. Použijte tuto volbu, když příjemci potřebují prezentaci upravovat a vkládat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/embedfontcharacters/) vloží pouze znaky použité v prezentaci, aby se snížila velikost souboru. Zvolte tuto možnost pro dokončenou prezentaci, která je převážně určena k prohlížení.

Následující příklad používá [getFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFonts) k získání písem použitých v souboru `Fonts.pptx` a vloží ty, které ještě nejsou vloženy. Písma k přidání musí být dostupná na počítači, kde se kód spouští. Existující vložená písma si zachovají své aktuální sady znaků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Komprese vložených písem**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#compressEmbeddedFonts) snižuje data vložených písem odstraněním nepoužívaných znaků. Funguje na písmech, která jsou již vložena, takže míra úspory závisí na množství nevyužitých dat písma v prezentaci.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a uloží výsledek jako samostatný soubor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ponechte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odstraněné během komprese již nejsou k dispozici ve vloženém písmu, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda bude vložené písmo během vykreslování stále nahrazeno?**

Vyvolejte [getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions) v prostředí, kde prezentaci vykreslujete, a zjistěte, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení substituce písem a pravidla pro záložní písma. Záložní písmo řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vložit běžná písma jako Arial a Calibri?**

Rozhodnutí se odvíjí od cílového prostředí. Pokud jsou požadovaná písma dostupná na každém počítači, který prezentaci otevírá nebo vykresluje, může jejich vložení jen zbytečně zvětšit velikost souboru. Pokud mohou příjemci či servery tato písma postrádat, může jejich vložení pomoci zachovat zamýšlený vzhled, pokud to licence písma povoluje.
---
title: Správa skriptově specifických fontů motivu v Pythonu
linktitle: Skriptově specifické fonty motivu
type: docs
weight: 15
url: /cs/python-net/script-specific-font-mappings/
keywords:
- skriptově specifický font
- mapování fontu motivu
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- thaana písmo
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Prohlédněte, přidejte, nahraďte a odstraňte skriptově specifická mapování fontů v tématech PowerPointu s Aspose.Slides pro Python pomocí .NET."
---
## **Přehled**

Motiv prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazyčný text, který stále používá písma motivu, aby sledoval jednotné schéma písem a zároveň používal vhodná písma pro cyrilici, arabštinu, japonštinu, gruzínštinu, thaana a další písma.

Motiv obsahuje [FontScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/) s hlavní kolekcí písem, která se typicky používá pro nadpisy, a vedlejší kolekcí písem, která se typicky používá pro tělo textu. Kromě jejich latinských a východoasijských vlastností písem obě kolekce poskytují mapování od značek psacích systémů k názvům rodin písem prostřednictvím třídy [Fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/) .

Tento článek ukazuje, jak prohlédnout a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přežijí cyklus uložení a načtení.

## **Porozumění značkám skriptů**

Metody skriptových fontů používají čtyřpísmenné podznačky BCP 47 pro identifikaci psacích systémů. Časté hodnoty zahrnují:

| Značka skriptu | Systém zápisu |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

Tato mapování patří k schématu písem motivu, ne k jednotlivým částem textu. Prezentace může definovat různá mapování pro hlavní a vedlejší kolekce a může vynechat mapování pro některé skripty.

## **Přístup a prohlížení mapování skriptových fontů**

Použijte [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/) pro přístup k motivu úrovně prezentace. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/minor/) vrací dvě kolekce [Fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/) .

Zavolejte [Fonts.get_script_font_map](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/get_script_font_map/) pro získání všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [Fonts.get_script_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/get_script_font/) s jeho značkou skriptu. `get_script_font` vrací `None`, když kolekce požadované mapování nedefinuje.

## **Úprava mapování a ověření trvalosti**

Použijte [Fonts.set_script_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/set_script_font/) pro vytvoření mapování nebo nahrazení stávající rodiny písma. Použijte [Fonts.remove_script_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/remove_script_font/) pro odebrání mapování.

Následující příklad od začátku do konce načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní font pro japonštinu, změní hlavní font pro cyrilici, odebere vedlejší mapování pro Thaana, uloží prezentaci a znovu ji otevře pro ověření obou změn. Aby byl krok odstraňování nezávislý na počátečním motivu, příklad nejprve vytvoří mapování pro Thaana jen pokud ještě není definováno.

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

Ověření používá stejné chování `None` jako běžné vyhledávání: po uložení odstranění `get_script_font("Thaa")` vrací `None` pro vedlejší kolekci.

## **Rozlišení mapování motivu od ostatních nastavení písma**

Mapování motivu specifické pro skript se podílejí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a náhradní písmo:

| Mechanismus | Účel | Efekt změny mapování motivu |
|---|---|---|
| Script-specific theme font mapping | Vybere hlavní nebo vedlejší font motivu pro psací systém. | Text, který stále používá odpovídající font motivu, může být přemapován na novou rodinu. |
| Font assigned explicitly to a text portion | Upevní požadovanou rodinu písma pro tuto část místo spoléhaní se na motiv. | Část může zůstat nezměněna, protože její přímé formátování přebije volbu motivu. |
| Font substitution | Nahrazuje požadované písmo, když není k dispozici nebo když platí pravidlo substituce. | Funguje po požadavku na písmo; nepředefinuje mapování skriptu v motivu. |
| Font fallback | Poskytuje glyfy, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Doplňuje chybějící glyfy; nezmění uložené mapování motivu. |

For more information about the last two mechanisms, see [Font Substitution](/slides/cs/python-net/font-substitution/) and [Fallback Fonts](/slides/cs/python-net/fallback-font/).

Změna mapování v [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/) ovlivní pouze obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho zdědit přepsání motivu z masteru, rozložení nebo snímku, nebo použít explicitně přiřazený font. Prozkoumejte tyto úrovně, pokud viditelný výsledek neodpovídá mapování úrovně prezentace.

## **Zajistěte dostupnost mapovaných písem a ověřte výsledek**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo dodáno do Aspose.Slides přes vlastní zdroj, jako je [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsloader/load_external_fonts/) nebo [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/document_level_font_sources/). Viz [Custom Fonts](/slides/cs/python-net/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice motivu byla zachována. Neprokazuje, že je písmo dostupné, obsahuje všechny požadované glyfy nebo vytváří zamýšlené rozložení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a prohlédněte výstup. To zachytí chybějící písma, neúplné pokrytí glyfů, chování fallbacku a změny rozložení před distribucí prezentace. Viz [Convert PowerPoint Presentations](/slides/cs/python-net/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené otázky**

**Co vrací `get_script_font`, když skript není mapován?**

[Fonts.get_script_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/get_script_font/) vrací `None`, když požadované mapování skriptu není v dané hlavní nebo vedlejší kolekci písem definováno.

**Přidá `set_script_font` druhé mapování, když skript již existuje?**

Ne. [Fonts.set_script_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fonts/set_script_font/) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, když je stejná značka skriptu již přítomna.

**Proč změna mapování motivu neovlivnila některý text?**

Text může mít explicitně přiřazené písmo, zdědit jiný motiv prostřednictvím přepsání, nebo být ovlivněn substitucí či fallbackem během vykreslování. Mapování skriptu na úrovni prezentace řídí pouze text, jehož efektivní formátování stále odkazuje na tuto kolekci písem motivu.

**Je uložení a opětovné otevření dostačující k ověření vícejazyčného výstupu?**

Ne. Opětovné otevření ověřuje trvalost dat motivu. Navíc je nutné vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdilo, že mapovaná písma jsou dostupná a obsahují potřebné glyfy.
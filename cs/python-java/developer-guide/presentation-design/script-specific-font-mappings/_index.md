---
title: Spravovat písma motivu specifické pro skript v Pythonu pomocí Javy
linktitle: Písma motivu specifická pro skript
type: docs
weight: 15
url: /cs/python-java/script-specific-font-mappings/
keywords:
- písmo specifické pro skript
- mapování písem motivu
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- thaanské písmo
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Prozkoumejte, přidejte, nahraďte a odstraňte mapování písem specifických pro skript v motivech PowerPointu pomocí Aspose.Slides pro Python přes Javu."
---
## **Přehled**

Motiv prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazyčný text, který i přesto používá písma motivu, aby sledoval jednotné schéma písem při použití vhodných písem pro cyrilické, arabské, japonské, gruzínské, thaanské a další písmo.

Motiv obsahuje třídu [FontScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontscheme/), která obsahuje hlavní kolekci písem, typicky používanou pro nadpisy, a vedlejší kolekci písem, typicky používanou pro tělo textu. Kromě latinských a východoasijských nastavení písem obě kolekce vystavují mapování od značek psacích systémů k názvům rodin písem prostřednictvím třídy [Fonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/).

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přežijí cyklus uložení a načtení.

## **Pochopení značek skriptů**

Metody pro písmo skriptu používají čtyřpísmenové podznačky BCP 47 k identifikaci psacích systémů. Běžné hodnoty zahrnují:

| Tag skriptu | Písmový systém |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

Tato mapování patří k motivu fontového schématu, ne k jednotlivým částem textu. Prezentace může definovat odlišná mapování pro hlavní a vedlejší kolekce a může vynechat mapování pro některé skripty.

## **Přístup a prohlížení mapování písem skriptů**

Použijte [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasterTheme) pro získání motivu na úrovni prezentace. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontscheme/#getMajor) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontscheme/#getMinor) vrací dvě kolekce [Fonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/).

Zavolejte [Fonts.getScriptFontMap](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#getScriptFontMap) pro získání všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [Fonts.getScriptFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#getScriptFont) s jeho značkou skriptu. `getScriptFont` vrací `None`, pokud daná kolekce neobsahuje požadované mapování.

## **Úprava mapování a ověření trvalosti**

Použijte [Fonts.setScriptFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#setScriptFont) pro vytvoření mapování nebo nahrazení aktuální rodiny písem. Použijte [Fonts.removeScriptFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#removeScriptFont) pro odebrání mapování.

Následující end‑to‑end příklad načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní japonské písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování pro Thaana, uloží prezentaci a znovu ji otevře k ověření obou změn. Aby byl krok odebrání nezávislý na počátečním motivu, příklad nejprve vytvoří mapování pro Thaana pouze tehdy, pokud již není definováno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Ověření používá stejné chování `None` jako běžné vyhledávání: po uložení odebrání `getScriptFont("Thaa")` vrací `None` pro vedlejší kolekci.

## **Rozlišení mapování motivu od ostatních nastavení písem**

Mapování specifické pro skript v motivu se podílí na výběru písem, ale řeší jiný problém než přímé formátování textu, substituce a záložní písmo:

| Mechanismus | Účel | Dopad změny mapování motivu |
|---|---|---|
| Mapování písma motivu specifické pro skript | Vybere hlavní nebo vedlejší písmo motivu pro psací systém. | Text, který stále používá odpovídající písmo motivu, může být převeden na nově mapovanou rodinu. |
| Písmo přiřazené výslovně k části textu | Fixuje požadovanou rodinu písma na této části místo spoléhaní se na motiv. | Část může zůstat beze změny, protože její přímé formátování přebíjí výběr motivu. |
| Substituce písma | Nahrazuje požadované písmo, pokud není dostupné nebo když platí pravidlo substituce. | Působí po požadavku na písmo; nepředefinuje mapování skriptu v motivu. |
| Záložní písmo | Poskytuje glify, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Vyplní chybějící glify; nemění uložené mapování motivu. |

Pro více informací o posledních dvou mechanismech viz [Substituce písma](/slides/cs/python-java/font-substitution/) a [Záložní písma](/slides/cs/python-java/fallback-font/).

Změna mapování v [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasterTheme) ovlivňuje pouze obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho zdědit přepsání motivu z hlavního, rozvržení nebo snímku, nebo použít výslovně přiřazené písmo. Prozkoumejte tyto úrovně, pokud viditelný výsledek nekoresponduje s mapováním na úrovni prezentace.

## **Zajistěte dostupnost mapovaných písem a ověřte výsledek**

Mapování skriptu ukládá pouze název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo dodáno Aspose.Slides pomocí vlastního zdroje, například [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsloader/#loadExternalFonts) nebo [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Viz [Vlastní písma](/slides/cs/python-java/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice motivu byla zachována. Nepotvrzuje, že písmo je dostupné, obsahuje všechny potřebné glify nebo produkuje zamýšlené rozvržení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrazu nebo PDF a prohlédněte výstup. Tím odhalíte chybějící písma, neúplné pokrytí glyphů, chování záložního písma a změny rozvržení před distribucí prezentace. Viz [Převod PowerPoint prezentací](/slides/cs/python-java/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené otázky**

**Co vrací `getScriptFont`, když není skript mapován?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#getScriptFont) vrací `None`, když požadované mapování skriptu není definováno v dané hlavní nebo vedlejší kolekci písem.

**Přidá `setScriptFont` druhé mapování, pokud skript již existuje?**

Ne. [Fonts.setScriptFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fonts/#setScriptFont) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písem, pokud je stejná značka skriptu již přítomna.

**Proč změna mapování motivu nezměnila některý text?**

Text může mít výslovně přiřazené písmo, zdědit jiný motiv prostřednictvím přepsání nebo být ovlivněn substitucí či záložním písmem během vykreslování. Mapování skriptu na úrovni prezentace řídí pouze text, jehož efektivní formátování stále odkazuje na tuto kolekci motivu.

**Je uložení a opětovné otevření dostatečné pro ověření vícejazykového výstupu?**

Ne. Opětovné otevření ověřuje pouze trvalost dat motivu. Také je potřeba vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdila dostupnost mapovaných písem a jejich kompletní glyphové pokrytí.
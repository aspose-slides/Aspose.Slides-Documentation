---
title: Správa skriptově specifických písem motivu v .NET
linktitle: Skriptově specifická písma motivu
type: docs
weight: 15
url: /cs/net/script-specific-font-mappings/
keywords:
- skriptově specifické písmo
- mapování písma motivu
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- thaana písmo
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte, přidejte, nahraďte a odstraňte skriptově specifická mapování písem v motivu PowerPointu pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Motiv prezentace může vybrat různá písma pro různé psací systémy. To umožňuje vícejazyčný text, který stále používá písma motivu, dodržet jednotné schéma písem a zároveň využívat vhodná písma pro cyrilici, arabštinu, japonštinu, gruzínštinu, thaana a další skripty.

Motiv obsahuje rozhraní [IFontScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/ifontscheme/), které zahrnuje hlavní kolekci písem (typicky pro nadpisy) a vedlejší kolekci písem (typicky pro tělo textu). Kromě latinských a východoasijských vlastností písem obě kolekce poskytují mapování od tagů psacích systémů k názvům rodin písem prostřednictvím rozhraní [IFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/ifonts/).

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přežijí cyklus uložení a znovunačtení.

## **Porozumění tagům skriptů**

Metody pro písma skriptů používají čtyřpísmenné BCP 47 podtagy skriptů k identifikaci psacích systémů. Běžné hodnoty zahrnují:

| Tag skriptu | Systém psaní |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabské |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonské |
| `Geor` | Gruzínské |
| `Thaa` | Thaana |

Tato mapování patří k motivu písma, nikoli k jednotlivým úsekům textu. Prezentace může definovat odlišná mapování pro hlavní a vedlejší kolekce a může některá mapování vynechat.

## **Přístup a inspekce mapování písem skriptů**

Použijte [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/) k získání motivu na úrovni prezentace. Vlastnosti [FontScheme.Major](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/major/) a [FontScheme.Minor](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/fontscheme/minor/) vrací dvě kolekce [IFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/ifonts/).

Zavolejte [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/getscriptfontmap/) k načtení všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [IFonts.GetScriptFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/getscriptfont/) s jeho tagem skriptu. `GetScriptFont` vrací `null`, když daná kolekce neobsahuje požadované mapování.

## **Upravit mapování a ověřit trvalost**

Použijte [IFonts.SetScriptFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/setscriptfont/) k vytvoření mapování nebo nahrazení aktuální rodiny písem. Pomocí [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/removescriptfont/) můžete mapování odstranit.

Následující kompletní příklad načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní japonské písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování thaana, uloží prezentaci a znovu ji otevře pro ověření obou změn. Aby byl krok odstraňování nezávislý na počátečním motivu, příklad nejprve vytvoří mapování thaana pouze v případě, že ještě není definováno.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Ověření používá stejné chování `null` jako běžné vyhledávání: po uložení odstranění `GetScriptFont("Thaa")` vrací `null` pro vedlejší kolekci.

## **Rozlišování mapování motivu od ostatních nastavení písma**

Mapování motivu specifické pro skript se podílí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a fallback:

| Mechanismus | Účel | Efekt změny mapování motivu |
|---|---|---|
| Mapování motivu specifické pro skript | Vybere hlavní nebo vedlejší písmo motivu pro psací systém. | Text, který i nadále používá odpovídající písmo motivu, se může převést na novou přiřazenou rodinu. |
| Písmo přiřazené explicitně k úseku textu | Fixuje požadovanou rodinu písma na tomto úseku místo spoléhaní se na motiv. | Úsek může zůstat beze změny, protože jeho přímé formátování přebije volbu motivu. |
| Substituce písma | Nahrazuje požadované písmo, pokud není dostupné nebo platí pravidlo substituce. | Probíhá po požadavku na písmo; nepředefinuje mapování skriptu motivu. |
| Fallback písma | Dodává glify, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Doplňuje chybějící glify; nemění uložené mapování motivu. |

Další informace o posledních dvou mechanismech najdete v [Font Substitution](/slides/cs/net/font-substitution/) a [Fallback Fonts](/slides/cs/net/fallback-font/).

Změna mapování v [Presentation.MasterTheme](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/mastertheme/) ovlivní pouze obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho zdědit přepsání motivu z masteru, rozvržení nebo snímku, nebo použít explicitně přiřazené písmo. Prozkoumejte tyto úrovně, pokud viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajistit dostupnost mapovaných písem a ověřit výsledek**

Mapování skriptu ukládá název rodiny písma; nenainstaluje ani nenačte odpovídající soubor písma. Pro konzistentní vykreslení a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides pomocí vlastního zdroje, například pomocí [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) nebo [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/). Viz [Custom Fonts](/slides/cs/net/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice motivu byla zachována. Neprokazuje, že je písmo dostupné, obsahuje všechny požadované glify nebo produkuje zamýšlené rozvržení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a zkontrolujte výstup. Tím zachytíte chybějící písma, neúplné pokrytí glifů, chování fallbacku a změny rozvržení před distribucí prezentace. Viz [Convert PowerPoint Presentations](/slides/cs/net/convert-powerpoint/) pro příklady vykreslování a exportu.

## **FAQ**

**Co vrací `GetScriptFont`, když není skript mapován?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/getscriptfont/) vrací `null`, když požadované mapování skriptu není definováno v dané hlavní nebo vedlejší kolekci písem.

**Přidá `SetScriptFont` druhé mapování, pokud skript již existuje?**

Ne. [IFonts.SetScriptFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fonts/setscriptfont/) vytvoří mapování, pokud chybí, a nahradí přiřazenou rodinu písma, pokud je tag skriptu již přítomen.

**Proč změna mapování motivu neovlivnila některý text?**

Text může mít explicitně přiřazené písmo, zdědit jiný motiv přes přepsání nebo být ovlivněn substitucí či fallbackem během vykreslování. Mapování skriptu na úrovni prezentace ovlivňuje jen text, jehož efektivní formátování stále odkazuje na tuto kolekci motivu.

**Je uložení a opětovné otevření dostatečné pro ověření vícejazyčného výstupu?**

Ne. Opětovné otevření ověří persistenci dat motivu. Je také nutné vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdilo, že mapovaná písma jsou dostupná a obsahují potřebné glify.
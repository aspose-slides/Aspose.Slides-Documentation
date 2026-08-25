---
title: Správa specifických písem motivu pro skript v JavaScriptu
linktitle: Specifická písma motivu pro skript
type: docs
weight: 15
url: /cs/nodejs-java/script-specific-font-mappings/
keywords:
- specifické písmo skriptu
- mapování písem motivu
- vícejazyková prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- písmo Thaana
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Prozkoumejte, přidejte, nahraďte a odstraňte specifická mapování písem podle skriptu v motivech PowerPointu pomocí Aspose.Slides pro Node.js."
---
## **Přehled**

Prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazykový text, který stále používá písma motivu, aby sledoval jednotné schéma písem a zároveň používal vhodná písma pro cyriliku, arabštinu, japonštinu, gruzínštinu, thaana a další skripty.

Motiv obsahuje [FontScheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/), který má hlavní kolekci písem (obvykle pro nadpisy) a vedlejší kolekci písem (obvykle pro tělo textu). Kromě latinských a východoasijských nastavení písem obě kolekce poskytují mapování od značek psacích systémů k názvům rodin písem prostřednictvím třídy [Fonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/).

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přetrvají po uložení a znovu načtení.

## **Pochopení značek skriptů**

Metody písma skriptů používají čtyřpísmenné BCP 47 podznačky skriptů k identifikaci psacích systémů. Časté hodnoty zahrnují:

| Značka skriptu | Psací systém |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

Tato mapování patří k motivu písma, nikoli k jednotlivým částem textu. Prezentace může definovat odlišná mapování pro hlavní i vedlejší kolekci a může některé skripty vynechat.

## **Přístup a kontrola mapování písem skriptů**

Použijte [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/) k získání motivu na úrovni prezentace. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontscheme/) vrací dvě kolekce [Fonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/).

Zavolejte [Fonts.getScriptFontMap](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) pro získání všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [Fonts.getScriptFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) s jeho značkou skriptu. `getScriptFont` vrací `null`, když daná kolekce neobsahuje požadované mapování.

## **Upravit mapování a ověřit trvalost**

Použijte [Fonts.setScriptFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) k vytvoření mapování nebo k nahrazení aktuální rodiny písma. Použijte [Fonts.removeScriptFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) k odstranění mapování.

Následující end‑to‑end příklad přečte všechna existující hlavní a vedlejší mapování, vyhledá hlavní japonské písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování Thaana, uloží prezentaci a znovu ji otevře, aby ověřil obě změny. Aby byl krok odstraňování nezávislý na počátečním motivu, příklad nejprve vytvoří mapování Thaana pouze v případě, že ještě není definováno.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Ověření používá stejný chování `null` jako běžné vyhledávání: po uložení odstranění `getScriptFont("Thaa")` vrací `null` pro vedlejší kolekci.

## **Rozlišovat mapování motivu od ostatních nastavení písma**

Mapování motivu specifická pro skript se podílí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a fallback:

| Mechanismus | Účel | Efekt změny mapování motivu |
|---|---|---|
| Mapování písma skriptu specifické pro motiv | Vybere hlavní nebo vedlejší motivové písmo pro psací systém. | Text, který stále používá odpovídající motivové písmo, může být převeden na novou mapovanou rodinu. |
| Písmo přiřazené explicitně k části textu | Fixuje požadovanou rodinu písma na této části místo spoleh na motiv. | Část může zůstat nezměněna, protože její přímé formátování přebije volbu motivu. |
| Substituce písma | Nahrazuje požadované písmo, když není dostupné nebo když platí pravidlo substituce. | Probíhá po požadavku na písmo; nepředefinuje mapování skriptu v motivu. |
| Fallback písma | Poskytuje glyfy, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Doplňuje chybějící glyfy; nemění uložené mapování motivu. |

Pro podrobnější informace o posledních dvou mechanismech viz [Font Substitution](/slides/cs/nodejs-java/font-substitution/) a [Fallback Fonts](/slides/cs/nodejs-java/fallback-font/).

Změna mapování v [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getmastertheme/) ovlivní jen obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho dědit přepsání motivu z masteru, layoutu nebo snímku, nebo použít explicitně přiřazené písmo. Prozkoumejte tyto úrovně, když viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajistit dostupnost mapovaných písem a ověřit výsledek**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides prostřednictvím vlastního zdroje, například pomocí [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) nebo [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/). Viz [Custom Fonts](/slides/cs/nodejs-java/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice motivu byla zachována. Nepotvrzuje, že je písmo dostupné, obsahuje všechny potřebné glyfy nebo vytváří zamýšlené rozvržení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a prohlédněte výstup. Tím zachytíte chybějící písma, neúplné pokrytí glyfů, chování fallbacku a změny rozvržení před distribucí prezentace. Viz [Convert PowerPoint Presentations](/slides/cs/nodejs-java/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené otázky**

**Co vrací `getScriptFont`, když není skript mapován?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) vrací `null`, když požadované mapování skriptu není definováno v hlavní ani vedlejší kolekci písem.

**Přidá `setScriptFont` druhou mapu, když skript již existuje?**

Ne. [Fonts.setScriptFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fonts/) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, když je značka skriptu již přítomna.

**Proč změna mapování motivu neovlivnila část textu?**

Text může mít explicitně přiřazené písmo, dědit jiný motiv skrze přepsání, nebo být ovlivněn substitucí či fallbackem během vykreslování. Mapování skriptu na úrovni prezentace kontroluje jen text, jehož efektivní formátování stále odkazuje na tuto kolekci motivových písem.

**Je uložení a znovu otevření dostatečné k ověření vícejazykového výstupu?**

Ne. Otevření znovu ověřuje trvalost dat motivu. Také je třeba vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdila dostupnost mapovaných písem a jejich obsah potřebných glyfů.
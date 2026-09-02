---
title: Spravovat skriptově specifická písma motivu v Javě
linktitle: Skriptově specifická písma motivu
type: docs
weight: 15
url: /cs/java/script-specific-font-mappings/
keywords:
- skriptově specifické písmo
- mapování písma motivu
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- Thaana písmo
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte, přidejte, nahraďte a odeberte skriptově specifická mapování písem v motivech PowerPointu pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Motiv prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazyčnému textu, který stále používá písma motivu, dodržet jednotné schéma písem a zároveň použít vhodná písma pro cyrilici, arabštinu, japonštinu, gruzínštinu, thaana a další skripty.

Motiv [IFontScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/) obsahuje hlavní sbírku písem, která se typicky používá pro nadpisy, a vedlejší sbírku písem, která se typicky používá pro tělo textu. Kromě nastavení pro latinská a východospouštěnsko asijská písma obě sbírky poskytují mapování od značek psacích systémů k názvům rodin písem prostřednictvím rozhraní [IFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifonts/).

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přetrvají při cyklu uložení a načtení.

## **Pochopení značek skriptů**

Metody skriptových písem používají čtyřpísmenné podznačky skriptů BCP 47 k identifikaci psacích systémů. Časté hodnoty zahrnují:

| Značka skriptu | Psací systém |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

Tato mapování patří ke schématu písem motivu, nikoli k jednotlivým částem textu. Prezentace může definovat různá mapování pro hlavní a vedlejší sbírky a může vynechat mapování pro některé skripty.

## **Přístup a prohlížení mapování skriptových písem**

Použijte [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasterTheme--) k přístupu k motivu úrovně prezentace. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/#getMajor--) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontscheme/#getMinor--) vrací dvě sbírky [IFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifonts/).

Zavolejte [IFonts.getScriptFontMap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#getScriptFontMap--) k načtení všech mapování ze sbírky. Pro vyhledání jednoho psacího systému zavolejte [IFonts.getScriptFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) s její značkou skriptu. `getScriptFont` vrací `null`, pokud sbírka neobsahuje požadované mapování.

## **Upravit mapování a ověřit trvalost**

Použijte [IFonts.setScriptFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) k vytvoření mapování nebo nahrazení aktuální rodiny písma. Použijte [IFonts.removeScriptFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) k odebrání mapování.

Následující příklad end-to-end načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní font japonštiny, změní hlavní font cyrilice, odstraní vedlejší mapování thaana, uloží prezentaci a znovu ji otevře pro ověření obou změn. Aby byl krok odebrání nezávislý na počátečním motivu, příklad nejprve vytvoří mapování Thaana jen pokud ještě není definováno.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Ověření používá stejné chování `null` jako běžné vyhledávání: po uložení odebrání `getScriptFont("Thaa")` vrátí `null` pro vedlejší sbírku.

## **Rozlišení mapování motivu od ostatních nastavení písem**

Mapování motivu specifická pro skript se podílejí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a záložní písmo:

| Mechanismus | Účel | Dopad změny mapování motivu |
|---|---|---|
| Mapování motivu specifické pro skript | Vybere hlavní nebo vedlejší písmo motivu pro psací systém. | Text, který stále používá odpovídající písmo motivu, se může přemapovat na novou rodinu. |
| Písmo přiřazené explicitně k části textu | Upevní požadovanou rodinu písma v této části místo spoléhaní se na motiv. | Část může zůstat nezměněna, protože její přímé formátování přebije výběr motivu. |
| Substituce písma | Nahradí požadované písmo, pokud není dostupné nebo když platí pravidlo substituce. | Působí po požadavku na písmo; neredefinuje mapování skriptu motivu. |
| Záložní písmo | Poskytuje glfy, které vybrané písmo neobsahuje, často pro specifické Unicode rozsahy. | Doplní chybějící znaky; nemění uložené mapování motivu. |

Pro více informací o posledních dvou mechanismech viz [Substituce písem](/slides/cs/java/font-substitution/) a [Záložní písma](/slides/cs/java/fallback-font/).

Změna mapování v [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getMasterTheme--) ovlivní pouze obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho dědit přepsání motivu z masteru, rozvržení nebo snímku, nebo použít explicitně přiřazené písmo. Prozkoumejte tyto úrovně, když viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajistit dostupnost mapovaných písem a ověřit výsledek**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides pomocí vlastního zdroje, jako je [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) nebo [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Viz [Vlastní písma](/slides/cs/java/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice motivu byla zachována. Nepotvrzuje, že písmo je dostupné, obsahuje všechny požadované glfy, nebo že vytvoří zamýšlené rozvržení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a prohlédněte výstup. Tím zachytíte chybějící písma, neúplné pokrytí glfy, chování záložního písma a změny rozvržení před distribucí prezentace. Viz [Převod prezentací PowerPoint](/slides/cs/java/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené otázky**

**Co vrací `getScriptFont`, když skript není mapován?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) vrací `null`, když požadované mapování skriptu není v dané hlavní nebo vedlejší sbírce definováno.

**Přidá `setScriptFont` druhé mapování, pokud skript již existuje?**

Ne. [IFonts.setScriptFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, pokud je tato značka skriptu již přítomna.

**Proč změna mapování motivu neovlivnila některý text?**

Text může mít explicitně přiřazené písmo, dědit jiný motiv skrze přepsání, nebo být ovlivněn substitucí či záložním písmem během vykreslování. Mapování skriptů na úrovni prezentace řídí pouze text, jehož efektivní formátování stále odkazuje na tuto sbírku písem motivu.

**Je uložení a opětovné otevření dostatečné pro ověření vícejazyčného výstupu?**

Ne. Opětovné otevření ověřuje trvalost dat motivu. Také je potřeba vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdilo, že mapovaná písma jsou dostupná a obsahují potřebné glfy.
---
title: Spravovat skriptově specifické písma motivu na Androidu
linktitle: Skriptově specifická písma motivu
type: docs
weight: 15
url: /cs/androidjava/script-specific-font-mappings/
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
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte, přidejte, nahraďte a odstraňte skriptově specifická mapování písma v motivech PowerPointu pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Motiv prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazyčný text, který stále používá písma motivu, aby sledoval jednotné schéma písem při použití vhodných fontů pro cyrilici, arabštinu, japonštinu, gruzínštinu, thaana a další skripty.

Motiv obsahuje [IFontScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/) s hlavní kolekcí fontů, obvykle používanou pro nadpisy, a vedlejší kolekcí fontů, obvykle používanou pro tělo textu. Kromě jejich nastavení latinských a východoasijských fontů obě kolekce vystavují mapování ze štítků psacích systémů na názvy rodin písem prostřednictvím rozhraní [IFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifonts/).

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přežijí cyklus uložení a načtení.

## **Pochopení štítků skriptů**

Metody pro skriptové fonty používají čtyřpísmenné podštítky BCP 47 k identifikaci psacích systémů. Běžné hodnoty zahrnují:

| Štítek skriptu | Psaný systém |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Tato mapování patří ke schématu písma motivu, nikoli k jednotlivým částem textu. Prezentace může definovat různá mapování pro hlavní a vedlejší kolekci a může některé skripty vynechat.

## **Přístup a prohlížení mapování skriptových fontů**

Použijte [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getMasterTheme--) k přístupu k motivu na úrovni prezentace. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/#getMajor--) a [IFontScheme.getMinor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontscheme/#getMinor--) vrací dvě kolekce [IFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifonts/).

Zavolejte [IFonts.getScriptFontMap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) pro získání všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [IFonts.getScriptFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) s jeho štítkem skriptu. `getScriptFont` vrací `null`, když daná kolekce požadované mapování nedefinuje.

## **Upravit mapování a ověřit trvalost**

Použijte [IFonts.setScriptFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) pro vytvoření mapování nebo nahrazení aktuální rodiny písma. Použijte [IFonts.removeScriptFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) pro odstranění mapování.

Následující end-to-end příklad načte všechna existující hlavní a vedlejší mapování, vyhledá japonské hlavní písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování Thaana, uloží prezentaci a znovu ji otevře k ověření obou změn. Pro nezávislost kroku odstranění na počátečním motivu příklad nejprve vytvoří mapování Thaana jen v případě, že již není definováno.

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

Ověření používá stejné chování `null` jako běžné vyhledávání: po uložení odstranění `getScriptFont("Thaa")` vrací `null` pro vedlejší kolekci.

## **Rozlišování mapování motivu od ostatních nastavení písma**

Mapování písma motivu specifické pro skript se podílejí na výběru písma, ale řeší jiný problém než přímé formátování textu, náhrada a fallback:

| Mechanismus | Účel | Dopad změny mapování motivu |
|---|---|---|
| Mapování písma motivu specifické pro skript | Vybere hlavní nebo vedlejší písmo motivu pro psací systém. | Text, který stále používá odpovídající písmo motivu, může být převeden na novou mapovanou rodinu. |
| Písmo přiřazené explicitně k části textu | Určí požadovanou rodinu písma pro tuto část místo spoléhaní se na motiv. | Část může zůstat nezměněna, protože její přímé formátování přebije volbu motivu. |
| Náhrada písma | Nahrazuje požadované písmo, když není k dispozici nebo když platí pravidlo náhrady. | Působí po požádání o písmo; nepředefinuje mapování skriptu motivu. |
| Náhradní písmo | Poskytuje glify, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Vyplní chybějící glify; nemění uložené mapování motivu. |

Pro více informací o posledních dvou mechanismech viz [Font Substitution](/slides/cs/androidjava/font-substitution/) a [Fallback Fonts](/slides/cs/androidjava/fallback-font/).

Změna mapování v [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getMasterTheme--) ovlivňuje jen obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho zdědit přepsání motivu z masteru, rozvržení nebo snímku, nebo použít explicitně přiřazené písmo. Prozkoumejte tyto úrovně, když viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajistěte dostupnost mapovaných písem a ověřte výsledek**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides pomocí vlastního zdroje, jako je [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) nebo [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Viz [Custom Fonts](/slides/cs/androidjava/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje jen to, že definice motivu byla zachována. Neposkytuje důkaz, že písmo je dostupné, obsahuje všechny požadované glify nebo vytváří zamýšlené rozložení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a prohlédněte výstup. Tím zachytíte chybějící písma, neúplné pokrytí glyphů, chování fallbacku i změny rozložení před distribucí prezentace. Viz [Convert PowerPoint Presentations](/slides/cs/androidjava/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené dotazy**

**Co vrací `getScriptFont`, když skript není mapován?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) vrací `null`, když požadované mapování skriptu není v hlavní nebo vedlejší kolekci definováno.

**Přidá `setScriptFont` druhé mapování, když skript již existuje?**

Ne. [IFonts.setScriptFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, když je štítek skriptu již přítomen.

**Proč změna mapování motivu neovlivnila některý text?**

Text může mít explicitně přiřazené písmo, zdědit jiný motiv prostřednictvím přepsání, nebo být ovlivněn náhradou či fallbackem během vykreslování. Mapování skriptu na úrovni prezentace kontroluje jen text, jehož efektivní formátování stále odkazuje na tuto kolekci písma motivu.

**Je uložení a opětovné otevření dostatečné k ověření vícejazyčného výstupu?**

Ne. Opětovné otevření ověřuje trvalost dat motivu. Navíc je nutné vykreslit reprezentativní text z každého požadovaného psacího systému, aby se potvrdilo, že mapovaná písma jsou dostupná a obsahují potřebné glify.
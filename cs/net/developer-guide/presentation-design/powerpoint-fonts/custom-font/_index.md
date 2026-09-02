---
title: Přizpůsobení písem PowerPointu v .NET
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/net/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka s pímy
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro .NET, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní písma v prezentacích bez jejich instalace do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci pomocí zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Nahraná písma jsou použita při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zobrazit složky písem používané Aspose.Slides a jak po práci s externími písmy vyprázdnit mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud je nutné písmo uložit přímo v prezentaci, použijte funkce pro vložení písem výslovně.

Téma prezentace může odkazovat na různé rodiny písem pro jednotlivé psací systémy. Tato mapování ukládají názvy písem, ale neinstalují ani nenačítají soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby odkazovaná písma byla k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Poznámka" %}}
Aspose Slides umožňuje načíst tato písma pomocí metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides umožňuje načíst písma používaná v prezentaci bez jejich instalace v systému. To ovlivňuje výstup exportu – jako PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.ClearCache](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/clearcache/) pro vyprázdnění mezipaměti písem.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definujte složky, které obsahují vlastní soubory písem.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Načtěte vlastní písma ze zadaných složek.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vyprázdněte mezipaměť písem po dokončení práce.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Poznámka" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené přes [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky písem**
Aspose.Slides poskytuje metodu [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/) pro umožnění nalezení složek písem. Tato metoda vrací složky přidané metodou `LoadExternalFonts` a systémové složky písem.

Tento C# kód vám ukazuje, jak použít [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Zadání vlastních písem používaných v prezentaci**
Aspose.Slides poskytuje vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/) pro umožnění zadání externích písem, která budou použita s prezentací.

Tento C# kód vám ukazuje, jak použít vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Pracujte s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts & global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [LoadExternalFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) pro umožnění načíst externí písma z binárních dat.

Tento C# kód demonstruje proces načítání písem z pole bytů:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externí písmo načtené během životnosti prezentace
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána rendererem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/net/embedded-font/).

**Mohu kontrolovat chování při nedostatku některých glyfů ve vlastním písmu?**

Ano. Nakonfigurujte [font substitution](/slides/cs/net/font-substitution/), [replacement rules](/slides/cs/net/font-replacement/) a [fallback sets](/slides/cs/net/fallback-font/) pro přesné určení, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich instalace do celého systému?**

Ano. Odkazujte na své vlastní složky písem nebo načítejte písma z bajtových polí. Tím odstraníte jakoukoli závislost na systémových složkách písem v kontejnerovém obrazu.

> **Poznámka pro Linux/Docker**: Při volání `FontsLoader.LoadExternalFonts` zajistěte, aby každý prvek v poli `directories` obsahoval neprázdnou cestu k existujícímu adresáři. Pokud je proměnná prostředí použita pro vytvoření cesty k písmu nedefinovaná nebo prázdná, Aspose.Slides může zkusit prázdnou hodnotu vyhodnotit jako úplnou cestu, což vede k `System.ArgumentException`.

**Co licencování—mohu vložit jakékoli vlastní písmo bez omezení?**

Jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před šířením výstupů přečtěte EULA daného písma.
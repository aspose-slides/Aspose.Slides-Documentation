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
- správa písem
- složka písem
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint slidech pomocí Aspose.Slides pro .NET a zajistěte, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní písma v prezentacích bez nutnosti instalovat je v operačním systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo uvnitř samotné prezentace, použijte funkce vkládání písem explicitně.

{{% alert color="primary" %}} 
Aspose Slides umožňuje načíst tato písma pomocí metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides umožňuje načíst písma používaná v prezentaci bez jejich instalace v systému. To ovlivňuje výstup exportu — například PDF, obrázky a další podporované formáty — takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více adresářů, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) pro načtení písem z těchto adresářů.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.ClearCache](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/clearcache/) pro vyčištění mezipaměti písem.

Následující příklad kódu demonstruje proces načítání písem:

```cs
// Definujte složky, které obsahují vlastní soubory písem.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Načtěte vlastní písma ze zadaných složek.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vyčistěte mezipaměť písem po dokončení práce.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Poznámka" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem. Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta písem operačního systému.
2. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky písem**
Aspose.Slides poskytuje metodu [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/), která vám umožní najít složky s písmy. Tato metoda vrací složky přidané prostřednictvím metody `LoadExternalFonts` a systémové složky písem.

Tento C# kód ukazuje, jak použít [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané pomocí metody LoadExternalFonts a systémové složky písem.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Zadat vlastní písma používaná s prezentací**
Aspose.Slides poskytuje vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/), která vám umožní zadat externí písma, která budou použita s prezentací.

Tento C# kód ukazuje, jak použít vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Pracujte s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podadresářů jsou k dispozici prezentaci
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [LoadExternalFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), která vám umožní načíst externí písma z binárních dat.

Tento C# kód demonstruje proces načítání písma z pole bytů: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externí font načten během životnosti prezentace
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma používá vykreslovací engine ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/net/embedded-font/).

**Mohu řídit chování fallbacku, když vlastní písmo postrádá určité glyfy?**

Ano. Nakonfigurujte [font substitution](/slides/cs/net/font-substitution/), [replacement rules](/slides/cs/net/font-replacement/) a [fallback sets](/slides/cs/net/fallback-font/), abyste přesně definovali, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v Linux/Docker kontejnerech bez jejich instalace na systémové úrovni?**

Ano. Odkazujte na své vlastní složky s písmy nebo načítejte písma z polí bytů. Tím se odstraní jakákoli závislost na systémových složkách písem v obrazu kontejneru.

**Co licencování—mohu vložit libovolné vlastní písmo bez omezení?**

Za soulad s licencí písem jste odpovědní vy. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si přečtěte EULA písma před distribucí výstupů.
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
- složka písem
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte písma v slidech PowerPointu pomocí Aspose.Slides pro .NET, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Písma můžete načítat z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou použita při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá zachovat konzistentní výstup prezentace napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud je potřeba, aby písmo bylo uloženo přímo v prezentaci, použijte explicitně funkce vkládání písem.

{{% alert color="primary" %}} 
Aspose Slides vám umožňuje načíst tato písma pomocí metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci, aniž byste je instalovali v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více adresářů, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/), která načte písma z těchto adresářů.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.ClearCache](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/clearcache/), abyste vymazali mezipaměť písem.

Následující příklad kódu ukazuje proces načítání písem:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definujte složky, které obsahují soubory vlastních písem.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Načtěte vlastní písma ze zadaných složek.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vymažte mezipaměť písem po dokončení práce.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Poznámka" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro hledání písem, ale nemění pořadí inicializace písem.  
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.  
1. Cesty načtené přes [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat složky vlastních písem**

Aspose.Slides poskytuje metodu [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/), která vám umožňuje najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s písmy.

Tento kód v C# ukazuje, jak použít [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané pomocí metody LoadExternalFonts a systémové složky s písmy.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Určit vlastní písma používaná v prezentaci**

Aspose.Slides poskytuje vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/), která vám umožňuje specifikovat externí písma, která budou v prezentaci použita.

Tento kód v C# ukazuje, jak použít vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podsložek jsou k dispozici pro prezentaci
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [LoadExternalFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), která vám umožňuje načíst externí písma z binárních dat.

Tento kód v C# demonstruje proces načítání písem z pole bytů:

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

## **Často kladené dotazy**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma používá vykreslovací engine napříč všemi exportními formáty.

**Jsou vlastní písma automaticky vkládána do výsledného souboru PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo uloženo uvnitř souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/net/embedded-font/).

**Mohu řídit chování náhrad, když vlastní písmo postrádá určité glyphy?**

Ano. Nakonfigurujte [font substitution](/slides/cs/net/font-substitution/), [replacement rules](/slides/cs/net/font-replacement/) a [fallback sets](/slides/cs/net/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glyph chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich instalace v celém systému?**

Ano. Odkazujte na své vlastní složky s písmy nebo načítejte písma z bytových polí. Tím odstraníte jakoukoli závislost na systémových složkách s písmy v obrazu kontejneru.

> **Poznámka pro Linux/Docker**: Při volání `FontsLoader.LoadExternalFonts` se ujistěte, že každý prvek v poli `directories` obsahuje ne‑prázdnou cestu k existujícímu adresáři. Pokud je proměnná prostředí použita pro sestavení cesty k písmu nedefinovaná nebo prázdná, Aspose.Slides se může pokusit vyřešit prázdnou hodnotu jako úplnou cestu, což vede k `System.ArgumentException`.

**Co licenciování – mohu vložit jakékoli vlastní písmo bez omezení?**

Jste zodpovědní za dodržování licenčních podmínek písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů prostudujte licenční smlouvu (EULA) daného písma.
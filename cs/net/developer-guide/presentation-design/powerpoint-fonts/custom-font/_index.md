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

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích bez jejich instalace do operačního systému. Písma můžete načíst z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Nahraná písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak vyprázdnit mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte explicitně funkce pro vkládání písem.

{{% alert color="info" %}} 
Aspose Slides vám umožňuje načíst tato písma pomocí metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci bez jejich instalace v systému. Toto ovlivňuje výstup exportu — například PDF, obrázky a další podporované formáty — takže výsledné dokumenty vypadají stejně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Určete jednu nebo více složek, které obsahují soubory písem.
2. Volajte statickou metodu [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Volajte [FontsLoader.ClearCache](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/clearcache/) pro vyprázdnění mezipaměti písem.

Následující příklad kódu demonstruje proces načítání písem:

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

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v následujícím pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené přes [FontsLoader](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky písem**
Aspose.Slides poskytuje metodu [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/), která vám umožňuje najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento C# kód ukazuje, jak použít [GetFontFolders](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Určení vlastních písem použitých s prezentací**
Aspose.Slides poskytuje vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/), která vám umožňuje určit externí písma, která budou použita s prezentací.

Tento C# kód ukazuje, jak použít vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podsložek jsou dostupná pro prezentaci
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [LoadExternalFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), která vám umožňuje načíst externí písma z binárních dat.

Tento C# kód demonstruje proces načítání písem z pole bajtů: 

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

## **FAQ**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

**Ano.** Připojená písma jsou rendererem používána ve všech exportních formátech.

**Jsou vlastní písma automaticky vkládána do výsledného PPTX?**

**Ne.** Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitně [funkce vkládání](/slides/cs/net/embedded-font/).

**Mohu řídit chování náhradního písma, když vlastní písmo postrádá některé glify?**

**Ano.** Nakonfigurujte [náhradu písem](/slides/cs/net/font-substitution/), [pravidla nahrazování](/slides/cs/net/font-replacement/) a [sady náhradních písem](/slides/cs/net/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glif chybí.

**Mohu použít písma v kontejnerech Linux/Docker, aniž bych je instaloval systémově?**

**Ano.** Odkazujte na vlastní složky s písmy nebo načítejte písma z polí bajtů. Tím se odstraní jakákoli závislost na systémových adresářích písem v obrazu kontejneru.

> **Poznámka pro Linux/Docker**: Při volání `FontsLoader.LoadExternalFonts` se ujistěte, že každá položka v poli `directories` obsahuje neprázdnou cestu k existujícímu adresáři. Pokud je proměnná prostředí použitá k vytvoření cesty k písmu nedefinovaná nebo prázdná, Aspose.Slides může zkusit vyhodnotit prázdnou hodnotu jako úplnou cestu, což vede k `System.ArgumentException`.

**Co licence—mohu vložit jakékoli vlastní písmo bez omezení?**

**Jste zodpovědní za dodržování licencí písem.** Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si přečtěte licenční smlouvu (EULA) daného písma před distribucí výstupů.
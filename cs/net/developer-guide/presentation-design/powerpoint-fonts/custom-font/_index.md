---
title: Přizpůsobení fontů PowerPointu v .NET
linktitle: Vlastní font
type: docs
weight: 20
url: /cs/net/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte písma ve snímcích PowerPoint pomocí Aspose.Slides pro .NET, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní písmo v prezentacích bez jejich instalace do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písma na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prověřit složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce vkládání písem explicitně.

Motiv prezentace může odkazovat na různé rodiny písem pro jednotlivé psací systémy. Tyto mapování ukládají názvy písem, ale neinstalují ani nenačítají soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/net/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby byly odkazované fonty k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Note" %}}

Aspose Slides umožňuje načíst tato písma pomocí metody [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides umožňuje načíst písma použité v prezentaci bez jejich instalace v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Uveďte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) pro vymazání mezipaměti písem.

Následující ukázka kódu demonstruje proces načítání písem:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definujte složky, které obsahují vlastní soubory písem.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Načtěte vlastní písma ze specifikovaných složek.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vymažte mezipaměť písem po dokončení práce.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta operačního systému k písmům.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky písem**

Aspose.Slides poskytuje metodu [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) umožňující najít složky písem. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento C# kód ukazuje, jak použít [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specifikovat vlastní písma použité v prezentaci**

Aspose.Slides poskytuje vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) umožňující specifikovat externí písma, která budou použita s prezentací.

Tento C# kód ukazuje, jak použít vlastnost [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) umožňující načíst externí písma z binárních dat.

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

Chcete-li, aby při exportu měla odpovídající registrované písmo přednost před vloženým písmem, viz [Prefer Registered Fonts over Embedded Fonts](/slides/cs/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 nebo novější).

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána renderovacím modulem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít explicitní [vkládací funkce](/slides/cs/net/embedded-font/).

**Mohu řídit chování náhradního písma, když vlastní písmo postrádá některé glyfy?**

Ano. Nakonfigurujte [náhrada písem](/slides/cs/net/font-substitution/), [pravidla nahrazení](/slides/cs/net/font-replacement/) a [sady náhradních písem](/slides/cs/net/fallback-font/) pro přesné určení, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich systémové instalace?**

Ano. Odkazujte na své vlastní složky s písmy nebo načítejte písma z polí bytů. Tím se odstraní jakákoli závislost na systémových složkách písem v obrazu kontejneru.

> **Poznámka pro Linux/Docker**: Když voláte `FontsLoader.LoadExternalFonts`, ujistěte se, že každý prvek v poli `directories` obsahuje neprázdnou cestu k existující složce. Pokud je proměnná prostředí použita ke konstrukci cesty k písmu nedefinovaná nebo prázdná, Aspose.Slides může zkusit vyhodnotit prázdnou hodnotu jako úplnou cestu, což vede k `System.ArgumentException`.

**Jak to je s licencováním – mohu vložit jakékoli vlastní písmo bez omezení?**

Vy sami nesete odpovědnost za soulad s licencí písma. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si přečtěte EULA písma před distribucí výstupů.
---
title: Určete výchozí písma prezentace v .NET
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/net/default-font/
keywords:
- výchozí písmo
- běžné písmo
- normální písmo
- asijské písmo
- export do PDF
- export do XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro .NET, aby byla zajištěna správná konverze PowerPoint (PPT, PPTX) a OpenDocument (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides umožňuje určit výchozí písma, která se používají při vykreslování prezentace. To je užitečné při vytváření miniatur snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma se nastavují pomocí `LoadOptions` před načtením prezentace.

Vlastnost `DefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `DefaultAsianFont` určuje výchozí písmo pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí zadaných písem.

## **Použití výchozích písem při vykreslování prezentace**
Aspose.Slides umožňuje nastavit výchozí písmo pro vykreslování prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont pro použití jako výchozí písma. Postupujte podle níže uvedených kroků k načítání písem z externích adresářů pomocí Aspose.Slides pro .NET API:

1. Vytvořte instanci LoadOptions.
2. Nastavte DefaultRegularFont na požadované písmo. V následujícím příkladu jsem použil Wingdings.
3. Nastavte DefaultAsianFont na požadované písmo. V následujícím příkladu jsem použil Wingdings.
4. Načtěte prezentaci pomocí třídy Presentation a nastavením možností načítání.
5. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

Implementace výše uvedeného je uvedena níže.

```c#
 // Použijte možnosti načtení k určení výchozích běžných a asijských písem
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont — jen export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím pipeline pro všechny podporované výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/net/convert-powerpoint-to-xps/), [rastrické obrázky](/slides/cs/net/convert-powerpoint-to-png/), [HTML](/slides/cs/net/convert-powerpoint-to-html/), a [SVG](/slides/cs/net/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a řešení glyfů napříč těmito cíli.

**Použijí se výchozí písma při pouhém načtení a uložení PPTX bez jakéhokoli vykreslování?**

Ne. Výchozí písma jsou důležitá, když je třeba text změřit a vykreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma vstupují do hry během operací, které text vykreslovají nebo přetékají.

**Pokud přidám vlastní složky s písmy nebo poskytnu písma z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Vlastní zdroje písem](/slides/cs/net/custom-font/) rozšiřují katalog dostupných rodin a glyfů, které engine může použít. Výchozí písma a jakékoli [pravidla záložních písem](/slides/cs/net/fallback-font/) se nejprve řeší vůči těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí písma metriky textu (kerning, posuny) a tím i zalomení řádků a zalamování?**

Ano. Změna písma mění metriky glyfů a může ovlivnit zalomení řádků, zalamování a stránkování během vykreslování. Pro stabilitu rozvržení [vložte originální písma](/slides/cs/net/embedded-font/) nebo vyberte metricky kompatibilní výchozí a záložní rodiny.

**Má smysl nastavovat výchozí písma, pokud jsou všechna písma použita v prezentaci vložena?**

Často to není nutné, protože [vložená písma](/slides/cs/net/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma však stále pomáhají jako pojistka pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.
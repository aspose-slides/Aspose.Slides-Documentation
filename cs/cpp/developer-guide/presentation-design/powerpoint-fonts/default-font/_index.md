---
title: Určete výchozí písma prezentace v C++
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/cpp/default-font/
keywords:
- výchozí písmo
- běžné písmo
- normální písmo
- asijské písmo
- export PDF
- export XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro C++, aby byla zajištěna správná konverze PowerPoint (PPT, PPTX) a OpenDocument (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat výchozí písma, která se používají při vykreslování prezentace. To je užitečné při generování miniatur snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma jsou nakonfigurována pomocí `LoadOptions` před načtením prezentace.

Metoda `set_DefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `set_DefaultAsianFont` určuje výchozí písmo pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí určených písem.

## **Použití výchozích písem pro vykreslení prezentace**
Aspose.Slides vám umožňuje nastavit výchozí písmo pro vykreslení prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont pro použití jako výchozí písma. Postupujte podle níže uvedených kroků pro načítání písem z externích adresářů pomocí Aspose.Slides pro C++ API:

1. Vytvořte instanci třídy LoadOptions.
1. Nastavte DefaultRegularFont na požadované písmo. V následujícím příkladu jsem použil Wingdings.
1. Nastavte DefaultAsianFont na požadované písmo. V následujícím vzorku jsem použil Wingdings.
1. Načtěte prezentaci pomocí třídy Presentation a nastavením možností načtení.
1. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

Implementace výše uvedeného je uvedena níže.

```cpp
// Použijte možnosti načtení k určení výchozích běžných a asijských písem
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont — jen export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na vykreslovacím řetězci pro všechny podporované výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/), [rastrové obrázky](/slides/cs/cpp/convert-powerpoint-to-png/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), a [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a řešení glifů napříč těmito cíli.

**Používají se výchozí písma při jednoduchém načtení a uložení PPTX bez jakéhokoli vykreslení?**

Ne. Výchozí písma mají význam, když je třeba text změřit a vykreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma se uplatní během operací, které vykreslují nebo přetvářejí text.

**Pokud přidám své vlastní složky s písmy nebo poskytnu písma z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Vlastní zdroje písem](/slides/cs/cpp/custom-font/) rozšiřují katalog dostupných rodin a glifů, které engine může použít. Výchozí písma a jakákoli [pravidla pro náhradní písmo](/slides/cs/cpp/fallback-font/) se nejprve vyhodnotí vůči těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Budou výchozí písma ovlivňovat metriky textu (kerning, posuny) a tím i zalamování řádků a zalamování?**

Ano. Změna písma mění metriky glifů a může ovlivnit zalamování řádků, obalování a stránkování během vykreslování. Pro stabilitu rozvržení [vložit původní písma](/slides/cs/cpp/embedded-font/) nebo vybrat metricky kompatibilní výchozí a náhradní rodiny.

**Má smysl nastavit výchozí písma, pokud jsou všechna písma v prezentaci vložena?**

Často to není nutné, protože [vložená písma](/slides/cs/cpp/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma stále pomáhají jako bezpečnostní rezerva pro znaky, které nejsou zahrnuty ve vložené podmnožině, nebo když soubor kombinuje vložený a nevložený text.
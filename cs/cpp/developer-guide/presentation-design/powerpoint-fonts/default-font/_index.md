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

Aspose.Slides umožňuje určit výchozí písma, která jsou používána při vykreslování prezentace. To je užitečné při generování miniatur snímků nebo exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma se nastavují pomocí `LoadOptions` před načtením prezentace.

Metoda `set_DefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `set_DefaultAsianFont` určuje výchozí písmo pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí zadaných písem.

## **Použití výchozích písem při vykreslování prezentace**
Aspose.Slides vám umožňuje nastavit výchozí písmo při vykreslování prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont jako výchozí písma. Postupujte podle níže uvedených kroků pro načtení písem z externích adresářů pomocí Aspose.Slides pro C++ API:

1. Vytvořte instanci třídy LoadOptions.  
1. Nastavte DefaultRegularFont na požadované písmo. V následujícím příkladu jsem použil Wingdings.  
1. Nastavte DefaultAsianFont na požadované písmo. V následujícím příkladu jsem použil Wingdings.  
1. Načtěte prezentaci pomocí třídy Presentation a nastavených možností načítání.  
1. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.  

Implementace výše uvedeného je uvedena níže.

```cpp
// Použijte možnosti načítání k určení výchozích běžných a asijských písem
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

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont – jen export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím řetězci pro všechny podporované výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/), [rasterové obrázky](/slides/cs/cpp/convert-powerpoint-to-png/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), a [SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a rozlišení glyfů pro všechny tyto cíle.

**Použijí se výchozí písma při pouhém načtení a uložení PPTX bez jakéhokoli vykreslování?**

Ne. Výchozí písma mají význam jen tehdy, když je nutné text měřit a vykreslovat. Přímé otevření a uložení prezentace nemění uložené fontové běhy ani strukturu souboru. Výchozí písma vstupují do hry při operacích, které text vykreslují nebo přetvářejí.

**Pokud přidám své vlastní složky s písmy nebo poskytnu písma z paměti, budou zohledněny při výběru výchozích písem?**

Ano. [Vlastní zdroje písem](/slides/cs/cpp/custom-font/) rozšiřují katalog dostupných rodin a glyfů, které může engine použít. Výchozí písma a jakákoliv [pravidla záložních písem](/slides/cs/cpp/fallback-font/) se nejprve vyhodnotí proti těmto zdrojům, což poskytuje spolehlivější krytí na serverech a v kontejnerch.

**Ovlivní výchozí písma metriky textu (kerning, posuny) a tím i zalamování řádků a obalování?**

Ano. Změna písma mění metriky glyfů a může ovlivnit zalomení řádků, obalování a stránkování během vykreslování. Pro stabilitu rozložení [vložte původní písma](/slides/cs/cpp/embedded-font/) nebo zvolte metricky kompatibilní výchozí a záložní rodiny.

**Má smysl nastavovat výchozí písma, pokud jsou všechna písma použita v prezentaci vložena?**

Často to není nutné, protože [vložená písma](/slides/cs/cpp/embedded-font/) již zajišťují jednotný vzhled. Výchozí písma však stále slouží jako pojistka pro znaky, které nejsou zahrnuty ve vloženém podmnožině, nebo když soubor kombinuje vložený a nevložený text.
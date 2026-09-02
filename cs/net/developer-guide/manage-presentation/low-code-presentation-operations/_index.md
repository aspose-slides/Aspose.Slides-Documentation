---
title: Operace prezentace s nízkým kódem v .NET
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/net/low-code-presentation-operations/
keywords:
- API prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- shromáždění tvarů
- komprese prezentace
- odstranění nepoužitých mistrů snímků
- odstranění nepoužitých rozložení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v .NET k převodu a sloučení prezentací, iteraci obsahu, shromažďování tvarů a zmenšení velikosti prezentace."
---
## **Přehled**

Namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané workflow objektového modelu do zaměřených metod, takže můžete konvertovat nebo slučovat soubory, zpracovávat prvky prezentace, shromažďovat tvary a odstraňovat nepoužité položky s méně kódem.

Low‑code pomocníky jsou nejvíce užitečné, když operace platí pro celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte kompletní [Aspose.Slides objektový model](https://reference.aspose.com/slides/cs/net/aspose.slides/), když potřebujete detailní kontrolu nad jednotlivými snímky, mistry, rozloženími, tvary, nastaveními exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | Použijte pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/) | Konverzi prezentace do jiného formátu přímým voláním soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/) | Kombinaci kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/) | Provedení akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných mistrů a rozložení a zmenšení vložených dat fontů. |

## **Konverze prezentace**

Použijte [Convert.AutoByExtension](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/autobyextension/) když je přípona výstupního souboru dostačující k výběru formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/) také poskytuje vyhrazené metody pro výstup PDF, SVG, JPEG, PNG a TIFF. Použijte úplný objektový model, když potřebujete před exportem prohlédnout nebo upravit prezentaci nebo nastavit volbu exportu, která není pomocníkem zpřístupněna. Viz [Convert Presentation](/slides/cs/net/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger.Process](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/process/) pro kombinaci kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte úplný objektový model, když potřebujete sloučit vybrané snímky, použít cílový mistr nebo rozložení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/net/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/) volá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám sbírek a je pohodlná pro kontrolu nebo změny formátování v celé prezentaci.

Následující příklad používá [ForEach.Slide](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/paragraph/) a [ForEach.Portion](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/portion/) k prozkoumání odpovídajících prvků:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Ve výchozím nastavení zahrnuje průchod tvary a text v celé prezentaci normální, mistr a layout snímky. Přetížení s parametrem `includeNotes` může zpracovávat i snímky poznámek. Použijte přímé smyčky sbírek, když je důležitý pořadí průchodu, předčasný výstup, filtrování před voláním zpětné funkce nebo podrobná kontrola rodič‑dítě.

## **Shromažďování tvarů**

Použijte [Collect.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/shapes/) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, pokud bude stejná sada filtrována, počítána nebo zpracována vícekrát.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Použijte místo toho [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/) pokud lze každý tvar zpracovat okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) může odstranit nepoužívané strukturální prvky a zmenšit vložená data fontů:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) odstraňuje layout snímky, na které neodkazuje žádný normální snímek.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) odstraňuje mistr snímky, které už nejsou používány.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/compressembeddedfonts/) odstraňuje nepoužívané znaky z vložených fontů.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Odstraňujte nejprve nepoužívaná rozložení a až potom nepoužívané mistry, aby mohl být mistr, který se po úklidu rozložení stane nepřipojeným, také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud můžete později potřebovat původní mistry, rozložení nebo kompletní data vložených fontů. Pro podrobnosti viz [Slide Master](/slides/cs/net/slide-master/) a [Embedded Font](/slides/cs/net/embedded-font/).

## **Často kladené otázky**

**Kdy mám použít low‑code API místo úplného objektového modelu?**

Používejte low‑code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte úplný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy mistr‑layout, prověřit mezistav nebo nastavit chování, které pomocník neodhaluje.

**Může Merger sloučit prezentace v různých formátech souborů?**

Ne. [Merger.Process](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/process/) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.AutoByExtension](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/autobyextension/), a pak sloučte převedené soubory.

**Zpracovává ForEach mistry, layouty a snímky poznámek?**

[ForEach.Slide](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/slide/) iteruje přes normální snímky prezentace. Operace [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/paragraph/) a [ForEach.Portion](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/portion/) zahrnují ve výchozím nastavení normální, mistr a layout snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby zahrnovaly i snímky poznámek.

**Jaký je rozdíl mezi ForEach.Shape a Collect.Shapes?**

Použijte [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/) k okamžitému zpracování každého tvaru pomocí zpětného volání. Použijte [Collect.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/shapes/) když potřebujete výsledek jako enumerable, který můžete uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozložení, nepoužívané mistry nebo vložené fonty s nepoužívanými znaky. Pokud žádné z těchto položek chybí, příslušné operace [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) nemusí velikost souboru snížit.

**Ukládají se změny provedené pomocníky ForEach nebo Compress automaticky?**

Ne. Tyto pomocníky pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) v paměti. Po změně prvků v zpětném volání [ForEach](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) zavolejte [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/), abyste výsledek zapsali.

## **Související články**

- [Convert Presentation](/slides/cs/net/convert-presentation/)
- [Merge Presentations](/slides/cs/net/merge-presentation/)
- [Slide Master](/slides/cs/net/slide-master/)
- [Manage Text Box](/slides/cs/net/manage-textbox/)
- [Embedded Font](/slides/cs/net/embedded-font/)
---
title: Operace prezentací s nízkým kódem v .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/net/low-code-presentation-operations/
keywords:
- Low-Code API pro prezentace
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- shromáždění tvarů
- komprese prezentace
- odstranění nepoužívaných master snímků
- odstranění nepoužívaných rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v .NET k převodu a sloučení prezentací, iteraci obsahu, shromažďování tvarů a snížení velikosti prezentace."
---
## **Přehled**

Jmenný prostor [Aspose.Slides.LowCode] poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouštějí často používané pracovní postupy objektového modelu do cílených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, shromažďovat tvary a odstraňovat nepoužitý obsah s menším množstvím kódu.

Pomocníky low-code jsou nejužitečnější, když se operace vztahuje na celý soubor nebo prezentaci a výchozí pracovní postup odpovídá vašim požadavkům. Použijte celý objektový model [Aspose.Slides] když potřebujete jemnozrnné řízení jednotlivých snímků, masterů, rozvržení, tvarů, nastavení exportu nebo vztahů mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | Kdy použít |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných masterů a rozvržení a snížení vložených dat fontů. |

## **Převést prezentaci**

Použijte [Convert.AutoByExtension](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/autobyextension/) když je přípona výstupního souboru dostatečná k výběru exportního formátu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert] třída také poskytuje specializované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte celý objektový model, když potřebujete před exportem prezentaci zkontrolovat nebo upravit nebo nakonfigurovat exportní možnost, která není vybraným pomocníkem zpřístupněna. Viz [Convert Presentation](/net/convert-presentation/) pro pracovní postupy a možnosti specifické pro formáty.

## **Sloučit prezentace**

Použijte [Merger.Process](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/process/) k propojení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte celý objektový model, když potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/net/merge-presentation/) pro tyto scénáře.

## **Iterovat přes prvky prezentace**

Třída [ForEach] vyvolá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným cyklům kolekcí a je vhodná pro celoprezentační kontrolu nebo změny formátování.

Následující příklad používá [ForEach.Slide](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/paragraph/), a [ForEach.Portion](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/portion/) k prozkoumání odpovídajících prvků:

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

Ve výchozím nastavení procházení tvarů a textu v celé prezentaci zahrnuje normální, master a rozvržení snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé cykly kolekcí, když je důležitý pořadí procházení, předčasný odchod, filtrování před vyvoláním zpětného volání nebo podrobná kontrola rodič‑potomek.

## **Shromažďovat tvary**

Použijte [Collect.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/shapes/) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, když bude stejné množství filtrované, počítané nebo zpracovávané vícekrát.

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

Použijte místo toho [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/), když může být každý tvar zpracován okamžitě a nepotřebujete uchovat shromážděný výsledek.

## **Komprimovat obsah prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) může odstranit nepoužívané strukturální prvky a snížit vložená data fontů:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) odstraňuje rozvržení snímků, na které neodkazuje žádný normální snímek.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) odstraňuje master snímky, které již nejsou používány.
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

Odstraňte nejprve nepoužívaná rozvržení před nepoužívanými mastery, aby master, který se po vyčištění rozvržení stane nepoužívaným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat původní mastery, rozvržení nebo kompletní vložená data fontů. Podrobnější informace najdete v [Slide Master](/net/slide-master/) a [Embedded Font](/net/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo kompletního objektového modelu?**

Používejte low-code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje podrobnou kontrolu jednotlivých prvků. Použijte kompletní objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy masterů a rozvržení, zkontrolovat mezistav nebo nakonfigurovat chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.Process](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/merger/process/) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.AutoByExtension](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/convert/autobyextension/), a pak sloučte převedené soubory.

**Zpracovává ForEach master, rozvržení a poznámkové snímky?**

[ForEach.Slide](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/slide/) iteruje přes normální snímky prezentace. Celoprezentační operace [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/paragraph/), a [ForEach.Portion](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/portion/) zahrnují standardní, master a rozvržení snímky ve výchozím nastavení. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby byly zahrnuty i poznámkové snímky.

**Jaký je rozdíl mezi ForEach.Shape a Collect.Shapes?**

Použijte [ForEach.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/shape/) k okamžitému zpracování každého tvaru pomocí zpětného volání. Použijte [Collect.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/collect/shapes/) když potřebujete výsledek v podobě IEnumerable, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Není to nutně pravda. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané mastery nebo vložené fonty s nepoužitými znaky. Pokud žádné z těchto položek nejsou přítomny, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tito pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) v paměti. Po úpravě prvků v zpětném volání [ForEach](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/), zavolejte [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/), aby byl výsledek zapsán.

## **Související články**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)
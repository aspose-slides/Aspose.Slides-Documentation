---
title: Upravit PDF dokumenty v .NET
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/net/edit-pdf/
keywords:
- upravit PDF
- nahradit text PDF
- PDF do PPTX
- PPTX do PDF
- .NET
- C#
- Aspose.Slides
description: "Upravte PDF dokumenty v C# importováním do Aspose.Slides, nahrazením textu a uložením upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduchou výměnu textu. Prezentace zůstává v paměti, takže uložení mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [AddFromPdf](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/addfrompdf/) k importu stránek, [ReplaceText](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/replacetext/) k aktualizaci textu a [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) k exportu výsledku.

Následující příklad předpokládá, že `input.pdf` obsahuje slovo "Draft" jako editovatelný text po importu. Nahrazuje toto slovo slovem "Final" a zapíše `edited.pdf`. Vymazání úvodního snímku před importem zabraňuje extra prázdné stránce ve výstupu. Vyhledávání odpovídá celým slovům se stejnou velikostí písmen; `null` znamená, že není potřeba žádné zpětné volání výsledku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Pro více možností viz [Search and Replace Text](/slides/cs/net/search-and-replace-text/) a [Convert PowerPoint to PDF](/slides/cs/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Výměna textu funguje na importovaném textu, nikoli na textu ve skenovaných obrázcích. Konverze může ovlivnit rozvržení a formátování, proto si výstup pečlivě zkontrolujte, zejména když je náhradní text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Potřebuji uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Uložte kopii PPTX pouze pokud ji také chcete dále upravovat v PowerPointu; viz [Save Presentations](/slides/cs/net/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu "Draft" s přesnou velikostí písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí nutně odpovídat hledání. Zkontrolujte importovaný obsah a upravte hledání pro svůj dokument.
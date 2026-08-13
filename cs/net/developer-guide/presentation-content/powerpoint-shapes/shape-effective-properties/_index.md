---
title: Získat efektivní vlastnosti tvaru z prezentací v .NET
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/net/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelný rig
- zkosený tvar
- textový rámec
- styl textu
- výška písma
- formát výplně
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro .NET rozlišovat mezi lokálním, děděným a efektivním formátováním tvarů v prezentacích PowerPoint."
---
## **Pochopte lokální, děděné a efektivní vlastnosti**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **lokální hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na nadřazené zdroje formátování, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **děděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** — hodnota používaná k vykreslení objektu.

Například část textu nemusí definovat vlastní výšku písma. Její lokální [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fontheight/) je pak `float.NaN`, což znamená „není zde nastavena“. Část může dědit výšku z odstavce, výchozího textového stylu prezentace nebo jiného relevantního zdroje. Volání [GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/geteffective/) na formát části vrátí finální vyřešenou výšku.

Používejte dva typy formátovacích dat pro různé účely:
- Čtěte nebo měňte lokální objekt formátu, například [IPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/), pokud potřebujete řídit, kde je hodnota definována.
- Čtěte objekt efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformateffectivedata/), pokud potřebujete konečný, vykreslený výsledek. Efektivní data jsou pouze pro čtení.

## **Porovnejte lokální, děděné a efektivní hodnoty**

Následující kompletní příklad vytvoří tvar a použije výšky písma na úrovních prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou část textu. Také ukazuje, proč musí být efektivní data po změnách formátování znovu načtena.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definujte děděné hodnoty na dvou různých úrovních.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Lokální hodnota v části přepíše obě děděné hodnoty.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Změna děděné hodnoty nepřepíše existující lokální hodnotu.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Vymažte lokální hodnotu. Část nyní opět dědí z odstavce.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Přečtěte efektivní data po předchozích změnách.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Priorita v tomto příkladu je lokální formátování části, pak formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít různé řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vyhrává a [GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/geteffective/) vrací konečný výsledek.

## **Získejte efektivní textové vlastnosti**

Formátování textu je rozděleno mezi několik objektů:
- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/geteffective/) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a vertikální směr textu.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/cs/net/aspose.slides/itextstyle/geteffective/) řeší formátování odstavců pro každou úroveň textového stylu.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/geteffective/) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/geteffective/) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro následující příklad musí `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) s neprázdným textovým rámcem. AutoShape může být na libovolné pozici ve sbírce tvarů; kód hledá vhodný objekt a před použitím jej ověří.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Získejte efektivní 3D vlastnosti**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/geteffective/) vrací jeden objekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/) který seskupuje všechna vyřešená 3D nastavení. Jeho vlastnosti [Camera](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/beveltop/) a [BevelBottom](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) vystavují odpovídající efektivní data. Čtení těchto souvisejících nastavení dohromady usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí `shape-3d.pptx` obsahovat alespoň jeden tvar na prvním snímku. Aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení zkosení, pokud chcete, aby výstup obsahoval jiné hodnoty než výchozí.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Získejte efektivní formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. Při konfliktech mezi explicitně definovanými výplněmi je priorita buňka, řádek, sloupec a potom celá tabulka. Efektivní formát buňky je konečný formát použité k vykreslení této buňky.

Pro tento příklad musí `table-formatting.pptx` obsahovat alespoň jednu tabulku na prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) místo předpokladu, že `Shapes[0]` je tabulka.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Pokud potřebujete barvu místo jen typu výplně, nejprve zkontrolujte efektivní [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/filltype/) a poté přečtěte vlastnost, která se vztahuje k tomuto typu — například [SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) pro plnou výplň.

## **Znovu načtěte efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Zavolejte `GetEffective` znovu po změně čehokoli, co může v této hierarchii participovat, včetně:
- lokálního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného ke snímku.

Neuchovávejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může některá efektivní data interně kešovat a pozdější volání `GetEffective` může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte potřebné skalární hodnoty — například výšku písma, barvu, zarovnání nebo šířku zkosení — do vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný lokální objekt formátu a poté zavolejte `GetEffective`, abyste výsledek ověřili. Objekt efektivních dat je sám o sobě pouze pro čtení.

## **Často kladené otázky**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují finální hodnotu, nikoli její zdroj. Prohlédněte si příslušné lokální objekty od nejspecifičtější úrovně směrem ven. U textu to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `float.NaN` nebo `null` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides určuje odpovídající výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když ji žádný lokální objekt explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná lokální hodnotě?**

Lokální hodnota vyhrála výpočet dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné specifičtější pravidlo ji nepřepíše.

**Kdy bych měl použít lokální data místo efektivních dat?**

Používejte lokální data k prozkoumání nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete konečný vzhled po provedení dědičnosti, pravidel motivu a použitelných stylů. [Kompletní příklad srovnání](#compare-local-inherited-and-effective-values) ukazuje obojí ve stejném pracovním postupu.
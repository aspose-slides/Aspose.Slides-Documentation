---
title: Získání efektivních vlastností tvaru z prezentací v .NET
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
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro .NET vypočítává a používá efektivní vlastnosti tvaru pro přesné vykreslení v PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty nastavené přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úsečků na snímku.
1. Textové styly prototypových tvarů v rozložení nebo hlavním snímku, pokud má tvar textového rámce úsečku.
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na jakékoli úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje konečné „vypočtené“ formátování, vyřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Získáte je voláním metody `GetEffective` na místním objektu formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá se, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) s textovým rámečkem a alespoň jednou úsečkou.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Data efektivního formátování představují aktuální vypočtené formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objektů efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformateffectivedata/), uloženy v mezipaměti vnitřně. Opětovné volání `GetEffective` po změně nadřazeného nebo zděděného formátování může mezipaměť obnovit a dříve získaný objekt již nemusí představovat předchozí stav. Pokud potřebujete zachovat efektivní hodnoty pro pozdější opětovné použití, zkopírujte požadované vlastnosti, například výšku písma, barvu výplně, styl písma nebo zarovnání, do svého vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides vám umožňuje získat efektivní vlastnosti kamery. Rozhraní [ICameraEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/icameraeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/icameraeffectivedata/) je zpřístupněna přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Získání efektivních vlastností světelného rig**

Aspose.Slides vám umožňuje získat efektivní vlastnosti světelného rig. Rozhraní [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilightrigeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti světelného rig. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilightrigeffectivedata/) je zpřístupněna přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti světelného rig. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Získání efektivních vlastností zkoseného tvaru**

Aspose.Slides vám umožňuje získat efektivní vlastnosti zkoseného tvaru. Rozhraní [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapebeveleffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti reliéfu pro tvar. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapebeveleffectivedata/) je zpřístupněna přes [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformateffectivedata/), které poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ithreedformat/).

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá se, že první tvar na prvním snímku má 3D formátování.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Rozhraní [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformateffectivedata/) obsahuje efektivní vlastnosti formátování textového rámce.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá se, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) s textovým rámečkem.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Rozhraní [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/itextstyleeffectivedata/) obsahuje efektivní vlastnosti textového stylu.

Následující ukázka kódu ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá se, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) s textovým rámečkem.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Získání efektivní hodnoty výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód demonstruje, jak se efektivní výška písma úsečky mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formát výplně pro různé části tabulky. Rozhraní [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformateffectivedata/) obsahuje efektivní vlastnosti formátu výplně. Formátování buněk má vyšší prioritu než formátování řádku, řádku vyšší prioritu než formátování sloupce a sloupce vyšší prioritu než formátování celé tabulky.

Výsledkem je, že vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/icellformateffectivedata/) jsou použity při vykreslování buňky tabulky. Následující ukázka kódu ukazuje, jak získat efektivní formát výplně pro různé části tabulky. Předpokládá se, že první tvar na prvním snímku je [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

**Vrací `GetEffective` snímek (snapshot)?**

Ne vždy. Efektivní data představují vypočtené formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být interně uloženy v mezipaměti. Následující volání `GetEffective` může formátování přepočítat a obnovit mezipaměť, takže dříve získaný objekt by neměl být považován za trvalý snímek.

**Kdy mám znovu načíst efektivní vlastnosti?**

Opětovně zavolejte `GetEffective` po změně lokálního formátování, nadřazených stylů, formátování rozložení, formátování hlavního snímku nebo výchozích nastavení na úrovni prezentace. Další volání přehodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Ovlivňuje změna nebo odebrání snímku rozložení/hlavního snímku efektivní vlastnosti, které již byly získány?**

Ano, ale změna se projeví při dalším volání `GetEffective`. Pokud je změněn nebo odebrán zdroj nadřazeného formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `GetEffective` Aspose.Slides přehodnotí strom formátování a výsledné písma, barvy, velikosti či jiné hodnoty se mohou změnit.

**Mohu upravovat hodnoty pomocí objektů efektivních dat?**

Ne. Objektům efektivních dat jsou vystaveny pouze vypočtené hodnoty. Proveďte změny v lokálních objektech formátování a poté znovu získáte efektivní hodnoty.

**Co se stane, pokud není vlastnost nastavena na úrovni tvaru, ani v rozložení/hlavním snímku, ani v globálním nastavení?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí nastavení PowerPointu i Aspose.Slides. Tato vyřešená hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma zjistím, která úroveň poskytla velikost nebo typ písma?**

Ne přímo. Efektivní data vrací konečnou hodnotu. Pro zjištění zdroje zkontrolujte lokální hodnoty na úrovni úsečky, odstavce, textového rámce a textových stylů v rozložení, hlavním snímku a prezentaci, abyste zjistili, kde se objeví první explicitní definice.

**Proč se efektivní hodnoty někdy shodují s lokálními?**

Protože lokální hodnota se ukázala jako konečná (není potřeba žádná vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy mám používat efektivní vlastnosti a kdy pracovat jen s lokálními?**

Používejte efektivní data, když potřebujete výsledek „jak je vykresleno“ po aplikaci veškeré dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud potřebujete zachovat tyto hodnoty nezávisle na pozdějších změnách formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud chcete měnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, pokud je to nutné, opět načtěte efektivní data pro ověření výsledku.
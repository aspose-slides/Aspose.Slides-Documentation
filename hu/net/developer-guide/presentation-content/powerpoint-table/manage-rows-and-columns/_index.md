---
title: Sorok és oszlopok kezelése PowerPoint táblázatokban .NET-ben
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/net/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázás
- oszlop szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a táblázat sorait és oszlopait PowerPointban az Aspose.Slides for .NET segítségével, és gyorsítsa a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for .NET lehetővé teszi, hogy táblázatszerkezetet és -formázást kezeljen a PowerPoint‑prezentációkban a [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) osztály és az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interfész segítségével. Megjelölhet fejlécsort, klónozhat vagy eltávolíthat sorokat és oszlopokat, és alkalmazhat szövegformázást egy teljes sorra vagy oszlopra.

Ez a cikk bemutatja ezeket a műveleteket C# példákkal. Emellett megmutatja, hogyan lehet lekérni egy táblázat stílus‑előbeállítását, hogy újra felhasználhassa. A táblázat sor- és oszlopszámai nullától kezdődnek.

## **Sormagasság vezérlése**

Használja az [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) tulajdonságot a sor minimális magasságának pontban történő beállításához. Ez egy alsó határ, nem rögzített magasság. Az [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) visszaadja a tényleges magasságot, és csak olvasható. A sort az [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) segítségével érheti el.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amely az első dián az első alakzatként egy táblázatot tartalmaz. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorba törik. A példa a minimálist 100 pontra növeli, majd 20 pontra csökkenti, minden változás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

A mellékelt prezentációval a minimum növelése helyet ad a sorban. A csökkentés eltávolítja ezt a plusz helyet, de a tényleges magasság továbbra is nagyobb lesz, mint 20 pont, mivel a szöveg és a cellamargók több helyet igényelnek. A minimum magányos csökkentése önmagában nem tudja a sort a tartalom által igényelt tér alá nyomni.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** hosszabb szöveg, explicit sortörés vagy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** a sortörés engedélyezésével egy szűkebb [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) több sorhoz vezethet. Egy szélesebb oszlop csökkentheti a függőlegesen szükséges helyet.
- **Cellamargók:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) és [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) függőleges helyet adnak. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) és [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) csökkentik a szövegnek rendelkezésre álló szélességet, ami további sortörést okozhat.

Ezen egyes celláktól, amelyek egyesülő cellákat nem tartalmaznak, a legtöbb függőleges helyet igénylő cella határozza meg a sor tartalom‑vezérelt alsó határát. A sor lerövidítéséhez gyakran a szöveg rövidítése, a betűméret vagy a margók csökkentése, illetve egy oszlop szélesítése szükséges.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretezésben. Ebben a futtatásban a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor magasabb maradt, mint a 20‑pontos minimum. A pontos szövegméretek környezeti betűkészlettől függően változhatnak. Töltse le a mentett eredményeket: [megnövelt minimum](row-height-increased.pptx) és [csökkentett minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti tábla 70 pontos első sorral.](row-height-before.png) | ![A tábla az első sor minimumjának 100 pontra növelése után.](row-height-increased.png) | ![A tábla az első sor minimumjának 20 pontra csökkentése után; a sortöréses szöveg miatt a sor magasabb marad a minimumnál.](row-height-decreased.png) |

## **Állítsa be az első sort fejlécként**

Használja a [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) tulajdonságot az első sor fejlécként való megjelöléséhez. Megjelenése a táblázatra alkalmazott táblastílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Érje el a táblázatot, amely a dia első alakzata.
4. Engedélyezze a fejlécformázást az első sorra.
5. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzatként szerepel. Fejlécformázást kapcsol be az első sorra, és a `First_row_header.pptx` fájlt menti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Táblázatsor vagy -oszlop klónozása**

Klónozzon sorokat vagy oszlopokat a tartalom és formázás újrahasználatához. A másolatot hozzáfűzheti a táblázat végéhez, vagy egy meghatározott pozícióba beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot az [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) módszerrel.
5. Klónozza a szükséges sorokat.
6. Klónozza a szükséges oszlopokat.
7. Mentse a módosított prezentációt.

A példa a `Test.pptx` fájlt igényli, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos és öt soros táblázatot, a méreteket pontban megadva. Az első sort és oszlopot másolatként a végére fűzi, majd a második sort és oszlopot a 3‑as index (a negyedik pozíció) helyére illeszti be. Az eredmény egy hét soros és öt oszlopos táblázat lesz. A `false` argumentum letiltja a klónozást szomszédos egyesített sorokra vagy oszlopokra; ez a táblázat nem tartalmaz egyesített cellákat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Sor vagy oszlop eltávolítása a táblázatból**

Távolítson el sorokat vagy oszlopokat, amelyek már nem szükségesek a táblázatban. Egy elem eltávolítása eltolja a mögötte következő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot az [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) módszerrel.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, majd az 1‑es indexű sort és oszlopot eltávolítva egy két‑kétas táblázatot eredményez a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `false` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz egyesített cellákat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Szövegformázás beállítása a táblázatsor szintjén**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellái egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyes cellákat külön kellene formázni.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Állítsa be a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) értékét az első sorra.
4. Állítsa be az [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) és a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) értékét az első sorra.
5. Állítsa be a [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) értékét a második sorra.
6. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzatként található, és legalább két sor van. A 25 pontos szöveget, a jobb igazítást és a 20 pontos jobb bekezdésmargót alkalmazza az első sorra, majd a második sorra függőleges szöveget állít be.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellái egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyes cellákat külön kellene formázni.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Állítsa be a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) értékét az első oszlopra.
4. Állítsa be az [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) és a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) értékét az első oszlopra.
5. Állítsa be a [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) értékét a második oszlopra.
6. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzatként található, és legalább két oszlop van. A 25 pontos szöveget, a jobb igazítást és a 20 pontos jobb bekezdésmargót alkalmazza az első oszlopra, majd a második oszlopra függőleges szöveget állít be.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Táblázat stílus tulajdonságok lekérése**

Használja a [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) tulajdonságot egy táblázatra alkalmazott előbeállítás lekéréséhez, hogy azt egy másik táblázaton is újra felhasználhassa. Ez az előbeállítást azonosítja, nem pedig az egyedi cellaformázási felülírásokat.

A példa egy táblázatot hoz létre, a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) előbeállítást alkalmazza, majd visszaolvassa azt. Kiírja a `DarkStyle1` értéket, és a táblázatot a `table.pptx` fájlba menti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Alkalmazhatok PowerPoint‑témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/oldal/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem a táblázatsorokat, mint az Excelben?**

Nem, az Aspose.Slides táblázatoknak nincs beépített rendezési vagy szűrési funkciója. Először rendezze az adatokat a memóriában, majd töltse fel a táblázat sorait abban a sorrendben.

**Lehet csíkozott (csíkozott) oszlopokat használni, miközben egyes cellákra egyéni színeket állítok be?**

Igen. Kapcsolja be a csíkozott oszlopokat, majd felülírhatja a kívánt cellákat helyi formázással; a cellaszintű formázás előbb kerül alkalmazásra a táblázat stílusával szemben.
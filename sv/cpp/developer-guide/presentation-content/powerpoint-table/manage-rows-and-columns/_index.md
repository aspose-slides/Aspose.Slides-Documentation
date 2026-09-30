---
title: "Hantera rader och kolumner i PowerPoint-tabeller med C++"
linktitle: "Rader och kolumner"
type: docs
weight: 20
url: /sv/cpp/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första rad
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för C++ och påskynda redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

Aspose.Slides för C++ låter dig hantera tabellstruktur och formatering i PowerPoint-presentationer via klassen [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) och gränssnittet [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner samt tillämpa textformatering på en hel rad eller kolumn.

Den här artikeln förklarar dessa operationer med C++-exempel. Den visar också hur du hämtar en tabells stilförinställning så att du kan återanvända den. Rads- och kolumnindex i tabellen är nollbaserade.

## **Styr radens höjd**

Använd [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) för att ange en rads minsta höjd i punkter. Det är en lägre gräns, inte en fast höjd. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) returnerar den faktiska höjden; detta värde kan inte sättas direkt. Få åtkomst till raden via [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar på 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts marginaler topp och botten; den längre texten i den andra kolumnen radbryts till flera rader. Exemplet ökar minimum till 100 punkter, sänker det sedan till 20 punkter, skriver ut den faktiska höjden efter varje ändring och sparar båda resultaten.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Med den medföljande presentationen lägger en ökning av minimum till extra utrymme i raden. En minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna kräver mer plats. Att bara minska minimum kan inte tvinga raden under det utrymme som dess innehåll kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller ett större teckensnitt kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** när radbrytning är aktiverad kan en minskning av kolumnbredden med [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) skapa fler rader. En bredare kolumn kan minska det vertikala utrymmet som behövs.
- **Cell marginaler:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) och [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) styr marginalerna som lägger till vertikalt utrymme. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) och [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) styr marginalerna som minskar bredden tillgänglig för text och kan orsaka ytterligare radbrytning.

För den här tabellen utan sammanslagna celler bestämmer den cell som kräver mest vertikalt utrymme den innehållsstyrda lägre gränsen för hela raden. För att göra raden kortare kan du också behöva förkorta texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I .NET‑referensen som visas här var de faktiska höjderna 70, 100 och 55,2 punkter: den sista raden förblev högre än sitt 20‑punkts minimum. Exakta textmått kan variera beroende på vilka teckensnitt som finns i din miljö. Ladda ner de sparade resultaten: [increased minimum](row-height-increased.pptx) och [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, faktisk 70 pt | Ökad: minimum 100 pt, faktisk 100 pt | Minskad: minimum 20 pt, faktisk 55,2 pt |
| --- | --- | --- |
| ![Original tabell med en 70‑punkts första rad.](row-height-before.png) | ![Tabell efter att ha ökat första radens minimum till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat första radens minimum till 20 punkter; radbruten text håller raden högre än minimum.](row-height-decreased.png) |

## **Ställ in den första raden som rubrik**

Använd metoden [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Hämta tabellen som är lagrad som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Klona en tabellrad eller -kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik plats.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Klona de behövda raderna.
6. Klona de behövda kolumnerna.
7. Spara den ändrade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `false` inaktiverar kloning i intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort flyttas indexen för de rader eller kolumner som följer efter.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den ändrade presentationen.

Exemplet skapar en tre‑på‑tre‑tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑på‑två‑tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `false` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Ställ in textformatering på radnivå i tabellen**

Tillämpa textformatering på en hel rad för att hålla dess celler enhetliga. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Ange teckenhöjden med [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) för den första raden.
4. Ange justeringen och högermarginalen för stycket med [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) och [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) för den första raden.
5. Ange textriktningen med [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) för den andra raden.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första raden, och sätter sedan vertikal text i den andra raden.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Ställ in textformatering på kolumnnivå i tabellen**

Tillämpa textformatering på en hel kolumn för att hålla dess celler enhetliga. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Ange teckenhöjden med [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) för den första kolumnen.
4. Ange justeringen och högermarginalen för stycket med [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) och [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) för den första kolumnen.
5. Ange textriktningen med [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) för den andra kolumnen.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Hämta tabellstilsegenskaper**

Använd metoden [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) för att hämta den förinställning som har tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än individuella cellformateringsöverskrivningar.

Exemplet skapar en tabell, tillämpar [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), och läser tillbaka förinställningen. Det skriver ut `DarkStyle1` och sparar tabellen i `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en tabell som redan är skapad?**

Ja. Tabellen ärver bild-/layout-/master‑temat och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först och fyll sedan tabellraderna på nytt i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller egna färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokal formatering; cellnivåformatering har företräde framför tabellstilen.
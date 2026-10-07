---
title: "Hantera tabellceller i presentationer med C++"
linktitle: "Hantera celler"
type: docs
weight: 30
url: /sv/cpp/manage-cells/
keywords:
- "tabellcell"
- "sammanfoga celler"
- "ta bort kant"
- "dela cell"
- "bild i cell"
- "bakgrundsfärg"
- "PowerPoint"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Hantera PowerPoint‑tabellceller i C++: identifiera sammanslagna celler, ta bort kanter, dela celler samt ange bakgrundsfärger och bilder med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur man identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild inuti en tabellcell. Exemplen visar hur man skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) för att identifiera celler i sammanslagna områden. För varje träff skriver det ut cellkoordinaterna i ordningen `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) och områdets startkoordinater, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) och [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Ta bort tabellcellkanter**

Skapa en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellkanter till [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), vilket gör dem osynliga.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Sammanfoga tabellceller**

Använd [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra och det nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får omfatta celler utanför det angivna området; `false` behåller sammanslagningen inom det området.

Exemplet skapar en 4×4‑tabell med 70‑punkts kolumner och rader, och sammanslår sedan de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table->idx_get(1, 1)` i detta exempel. De övriga positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Dela tabellceller**

Att sammanslå celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan introducera en ny rutnätskolumn och ändra kolumnindex för celler till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4×4‑tabell med 70‑punkts kolumner och rader och anropar [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) på cell `(1, 1)`. Halva cellens 70‑punkts bredd används för att skapa två celler med lika bredd.

Efter denna delning nås de två halvorna som `table->idx_get(1, 1)` och `table->idx_get(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen låg i kolumnerna 2 och 3 flyttas till kolumnerna 3 respektive 4. Radräknarna förblir oförändrade. Använd dessa uppdaterade kolumnindex när du kommer åt celler efter delningen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) för att dela längs en befintlig radgräns, eller [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) för att dela längs en kolumngräns.

Argumentet `index` räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Kolumndelning: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den lägre positionen använder det [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) och [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) för att hitta ursprunget och kontrollerar båda spannen. `SplitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell tvåkolumnssammanslagning, använd `SplitByColSpan(1)` istället.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Hämta de resulterande cellerna från tabellen efter delning.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Tabellrutnätet och omkringliggande cellindex förblir oförändrade. Hämta de resulterande cellerna med deras koordinater; här har båda en spann på 1 och [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) skriver ut `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering finns kvar i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, kanter och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata "Product A"- och "Product B"-celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) för detaljer.

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det använder [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) för att välja en solid fyllning och [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) för att komma åt fyllningsfärgen och sätta den till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) och lägger till den i presentationens bildsamling med [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Den tilldelar sedan bilden till bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra dess bildförhållande. Kolumnbredder och radhöjder anges i punkter. Den inlästa bilden frigörs efter att den har lagts till i presentationen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)-kanterna har separata egenskaper, så tjockleken och stilen för varje sida kan vara olika.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Vid streching anpassas bilden till den nya cellen; vid tiling beräknas rutorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/cpp/manage-hyperlinks/) sätts på textnivå (portion) inne i cellens textram eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika typsnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run) med oberoende formatering — typsnittsfamilj, stil, storlek och färg.
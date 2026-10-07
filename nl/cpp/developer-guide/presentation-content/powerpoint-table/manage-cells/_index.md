---
title: Beheer tabelcellen in presentaties met C++
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/cpp/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in C++: identificeer samengevoegde cellen, verwijder randen, splits cellen en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. In dit artikel wordt uitgelegd hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummers na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, de celopmaak via cel‑eigenschappen bijwerkt en de gewijzigde presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Identificeer een samengevoegde tabelcel**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Er wordt aangenomen dat de dia en de vorm bestaan en dat de vorm een tabel is. Vervolgens wordt door alle rijen en kolommen gelopen en wordt [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) gebruikt om cellen in samengevoegde gebieden te identificeren. Voor elke overeenkomst worden de celcoördinaten in `row;column`‑volgorde, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), en de begincoördinaten van het gebied, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) en [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) afgedrukt.

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

## **Verwijder tabelcelranden**

Maak een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). De breedtes van kolommen, hoogtes van rijen en de positie van de tabel worden opgegeven in punten. Het voorbeeld stelt alle vier de celranden in op [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Tabelcellen samenvoegen**

Gebruik [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of het samenvoegen cellen buiten het opgegeven bereik mag omvatten; `false` houdt het samenvoegen binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot `(2, 2)` samen. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik u de linkerbovenpositie: `table->idx_get(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

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

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van cellen rechts ervan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten en roept [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) aan op cel `(1, 1)`. De helft van de breedte van 70 punten van de cel wordt doorgegeven om twee even breedte cellen te creëren.

Na deze splitsing worden de twee helften benaderd als `table->idx_get(1, 1)` en `table->idx_get(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen zich naar respectievelijk kolommen 3 en 4. Rijomschrijvingen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensvulling voor te bereiden, gebruik [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) om langs een bestaande rij‑grens te splitsen, of [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) om langs een kolom‑grens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linker deel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Rijsplitsing: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Kolomsplitsing: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als de eerste vorm op de eerste dia, waarbij `(1, 2)` en `(1, 3)` verticaal samengevoegd zijn. Beginnende vanaf de lagere positie, gebruikt het [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) en [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) om de oorsprong te lokaliseren en controleert beide spans. `SplitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale samensmelting van twee kolommen, gebruik `SplitByColSpan(1)` in plaats daarvan.

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

    // Haal de resulterende cellen op uit de tabel na het splitsen.
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

Het tabelraster en de omliggende celindexen blijven onveranderd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) geeft `False` weer. Grotere gebieden kunnen gedeeltelijk samengevoegd blijven na één splitsing.

De oorspronkelijke tekst en opmaak blijven behouden in de boven‑ (of linker‑)cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen in na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke "Product A"‑ en "Product B"‑cellen met de celopmaak van het sjabloon behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) voor details.

## **Wijzig de achtergrondkleur van de tabelcel**

Dit voorbeeld maakt een tabel met kolommen van 150 punten en rijen van 50 punten. Het gebruikt [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) om een effen vulling te selecteren en [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) om de vulkleur te benaderen en deze op rood in te stellen voor cel `(2, 3)`, in de derde kolom en vierde rij.

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

## **Afbeelding toevoegen binnen een tabelcel**

Plaats de invoerafbeelding in de werkmap vóór het uitvoeren van dit voorbeeld. Het laadt de afbeelding met [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) en voegt deze toe aan de afbeeldingcollectie van de presentatie met [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Vervolgens wordt de afbeelding toegewezen aan de pictuurvulling van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, hetgeen de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes worden opgegeven in punten. De geladen afbeelding wordt verwijderd nadat deze aan de presentatie is toegevoegd.

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

## **Veelgestelde vragen**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elk zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte verander nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Bij rekken past de afbeelding zich aan de nieuwe cel aan; bij betegelen worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan de volledige inhoud van een cel?**

[Hyperlinks](/slides/nl/cpp/manage-hyperlinks/) worden ingesteld op het tekst‑ (portie) niveau binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk kent u de link toe aan een portie of aan alle tekst in de cel.

**Kan ik verschillende lettertypes instellen binnen één cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertype, stijl, grootte en kleur.
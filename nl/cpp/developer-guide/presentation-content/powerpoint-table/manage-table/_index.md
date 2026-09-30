---
title: Beheer presentatietabellen in C++
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/cpp/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- toegang tot tabel
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor C++. Ontdek eenvoudige codevoorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Introductie**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het eenvoudiger wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) interface, en andere types om tabellen in presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

Maak een tabel door de positie, kolombreedtes en rijhoogtes te specificeren. Nadat je deze aan een dia hebt toegevoegd, kun je celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Definieer een array met kolombreedtes in punten.
4. Definieer een array met rijhoogtes in punten.
5. Voeg een [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object toe aan de dia via de methode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Itereer over elke [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linkerrand.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Toegang tot de samengevoegde cel via de methode [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. Stel de tekst in de samengevoegde cel in.
10. Sla de aangepaste presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) punten. Het past rode randen toe met een breedte van 5 punten, voegt de eerste twee cellen in de eerste rij samen en slaat het resultaat op als `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Nummering in een standaardtabel**

In een standaardtabel zijn celindices nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de bovenstaande 4 × 4 tabel, met kolombreedtes en rijhoogtes van 70 punten en rode celranden met een breedte van 5 punten. De coördinaten illustreren celindices; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Itereer door de vormen om een tabel te vinden, gebruik vervolgens de interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) om de cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Verkrijg een referentie naar de dia die de tabel bevat op basis van de index.
3. Itereer door de objecten van type [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) en stop wanneer een tabel is gevonden. Als de dia meerdere tabellen bevat, gebruik dan [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) om degene te identificeren die je nodig hebt.
4. Werk de tekst in de doelcel bij.
5. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel op kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet minstens één kolom en twee rijen hebben.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Om een rij in een bestaande tabel te wijzigen en te begrijpen waarom de werkelijke hoogte de gevraagde minimumhoogte kan overschrijden, zie [Rijhoogte regelen](/slides/nl/cpp/manage-rows-and-columns/#control-row-height).

## **Vind de cel die een tekstkader bezit**

Wanneer algemene tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) om het eigenaar-[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) op te halen. Voor een tabelcel-tekstkader retourneert [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) de eigenaar en retourneert [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen-lezen methoden [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) en [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) biedt ook alleen-lezen navigatie: het retourneert de eigenaar maar verandert de eigendom niet. Controleer altijd of de geretourneerde cel `nullptr` is vóór gebruik.

Voor een volledig voorbeeld dat tabelcel- en vorm-eigenaars identificeert, inclusief vormen die aan SmartArt‑knopen zijn gekoppeld, zie [Zoeken en vervangen van tekst](/slides/nl/cpp/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

Je kunt de verticale verankering en tekstrichting van individuele tabelcellen beheersen. Het voorbeeld in deze sectie centreert tekst in de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Voeg een [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object toe aan de dia.
4. Verkrijg een [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) object van de tabel.
5. Verkrijg de eerste [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstrichting van de cel in met behulp van [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) en [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 punten en rijhoogtes van 100 punten. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de resterende cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Tekstopmaak instellen op tabelniveau**

Gebruik [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren opmaak voor delen, alinea's en tekstkaders, zodat je deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met behulp van de klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Verkrijg een referentie naar de dia op basis van de index.
3. Verkrijg een [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object van de dia.
4. Stel de lettergrootte in met behulp van [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) voor de tekst.
5. Stel de alinea-uitlijning en de rechter marge in met [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Stel de tekstrichting in met [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 punten, lijnt alinea's rechts uit met een rechter marge van 20 punten, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tabelstijleigenschappen ophalen**

Gebruik [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) om de vooraf ingestelde stijl van een tabel te lezen en [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) toe op één tabel, geeft de naam van de preset weer, en wijst dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Verhouding van een tabel vergrendelen**

De beeldverhouding van een tabel is de verhouding tussen de breedte en de hoogte. Gebruik [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het toont de huidige vergrendelingsstatus, schakelt de vergrendeling van de verhouding in, toont de bijgewerkte status (`True`), en slaat het resultaat op als `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik de rechts-naar-links (RTL) leesrichting voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt een [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) methode, en alinea's hebben [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Het gebruik van beide zorgt voor de juiste RTL-volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel verplaatsen of van grootte wijzigen in het uiteindelijke bestand?**

Gebruik [shape locks](/slides/nl/cpp/applying-protection-to-presentation/) om verplaatsen, van grootte wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of tegel).
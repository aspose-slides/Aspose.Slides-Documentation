---
title: Beheer presentatietabellen in C++
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/cpp/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- aspectverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor C++. Ontdek eenvoudige code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is overzichtelijk en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/)‑klasse, de [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑interface, de [Cell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/cell/)‑klasse, de [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/)‑interface en andere typen waarmee u tabellen kunt maken, bijwerken en beheren in alle soorten presentaties. 

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑object toe aan de dia via de [AddTable()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addtable/)‑methode.  
6. Itereer over elke [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/) om opmaak toe te passen op de boven‑, onder‑, rechts‑ en linkerranden.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/).  
9. Voeg enkele tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

This C++ code shows you how to create a table in a presentation:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Initialiseert een Presentation‑klasse die een PPTX‑bestand voorstelt
auto pres = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Voegt een tabelvorm toe aan de dia
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Voegt cellen 1 en 2 van rij 1 samen
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Voegt wat tekst toe aan de samengevoegde cel
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Slaat de presentatie op op schijf
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nul‑gebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Voorbeeld van de nummering bij een tabel met 4 kolommen en 4 rijen:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C++ code shows you how to specify the numbering for cells in a table:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instantieert een Presentation‑klasse die een PPTX‑bestand voorstelt
auto pres = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Voegt een tabelvorm toe aan de dia
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
for (const auto& row : tbl->get_Rows())
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

// Slaat de presentatie op naar schijf
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  

2. Haal een referentie naar de dia op die de tabel bevat via de index.  

3. Maak een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑object aan en stel het in op null.  

4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑objecten totdat de tabel wordt gevonden.  
   Als u vermoedt dat de dia waar u mee werkt slechts één tabel bevat, kunt u eenvoudig alle vormen die erin staan controleren. Wanneer een vorm wordt herkend als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/)‑object. Maar als de dia meerdere tabellen bevat, zoekt u beter de gewenste tabel via de [set_AlternativeText()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_alternativetext/).  

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑object om met de tabel te werken. In het voorbeeld hieronder hebben we een nieuwe rij aan de tabel toegevoegd.  

6. Sla de gewijzigde presentatie op.  

This C++ code shows you how to access and work with an existing table:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantieert een Presentation‑klasse die een PPTX‑bestand voorstelt
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Toegang tot de eerste dia
auto sld = pres->get_Slides()->idx_get(0);

// Initialiseert een null‑tabel
System::SharedPtr<ITable> tbl;

// Itereert door de shapes en stelt een referentie in naar de gevonden tabel
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Stelt de tekst in voor de eerste kolom van de tweede rij
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Slaat de gewijzigde presentatie op naar schijf
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Zoek de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van een tabel ontvangt, gebruikt u [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) om de eigenaar‑[ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/) op te halen. Voor een tekstframe in een tabelcel retourneert [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) de eigenaar en retourneert [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen methoden [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/get_firstcolumnindex/) en [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) biedt eveneens alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt de eigendom niet. Controleer altijd of de geretourneerde cel `nullptr` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabelcel‑ en vormeigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/cpp/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑object toe aan de dia.  
4. Toegang tot een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/)‑object van de tabel.  
5. Toegang tot de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.  

This C++ code shows you how to align the text in a table:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Creëert een instantie van de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

// Haalt de eerste dia op
auto slide = presentation->get_Slides()->idx_get(0);

// Definieert kolommen met breedtes en rijen met hoogtes
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Voegt de tabelvorm toe aan de dia
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Toegang tot het tekstframe
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Creëert het Paragraph‑object voor het tekstframe
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Creëert het Portion‑object voor de alinea
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Lijnt de tekst verticaal uit
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Slaat de presentatie op op schijf
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Tekstopmaak op tabelniveau instellen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Toegang tot een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/)‑object van de dia.  
4. Stel de [set_FontHeight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_fontheight/) in voor de tekst.  
5. Stel de [set_Alignment()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) en [set_MarginRight()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginright/) in.  
6. Stel de [set_TextVerticalType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_textverticaltype/) in.  
7. Sla de gewijzigde presentatie op.  

This C++ code shows you how to apply your preferred formatting options to the text in a table:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Creëert een instantie van de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Stelt de letterhoogte van de tabelcellen in
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Stelt de tekstuitlijning en rechtermarge van de tabelcellen in één stap in
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Stelt het verticale type van de tekst in de tabelcellen in
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tabelstijl‑eigenschappen ophalen**

Aspose.Slides stelt u in staat om de stijl‑eigenschappen van een tabel op te halen, zodat u die details kunt gebruiken voor een andere tabel of elders. Deze C++‑code laat zien hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl verkrijgt:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Vergrendel de aspectverhouding van een tabel**

De aspectverhouding van een geometrische vorm is de verhouding tussen de afmetingen in verschillende dimensies. Aspose.Slides biedt de `AspectRatioLocked()`‑eigenschap zodat u de instelling voor de aspectverhouding kunt vergrendelen voor tabellen en andere vormen. 

This C++ code shows you how to lock the aspect ratio for a table:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik de leesrichting van rechts naar links (RTL) inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel biedt een [set_RightToLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/set_righttoleft/)‑methode, en alinea's hebben [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/set_righttoleft/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen de cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel kunnen verplaatsen of de grootte wijzigen in het uiteindelijke bestand?**

Gebruik [shape locks](/slides/nl/cpp/applying-protection-to-presentation/) om verplaatsen, grootte wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen zijn ook van toepassing op tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (rekken of tegelpatroon).
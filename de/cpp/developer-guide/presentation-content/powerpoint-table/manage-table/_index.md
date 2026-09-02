---
title: Verwalte Präsentationstabellen in C++
linktitle: Tabellen verwalten
type: docs
weight: 10
url: /de/cpp/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint‑Folien mit Aspose.Slides für C++. Entdecken Sie einfache Codebeispiele, um Ihre Tabellenvorgänge zu optimieren."
---
## **Einleitung**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen und zu präsentieren. Die Informationen in einem Raster von Zellen (geordnet in Zeilen und Spalten) sind klar und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/de/cpp/aspose.slides/table/) bereit, das Interface [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/), die Klasse [Cell](https://reference.aspose.com/slides/de/cpp/aspose.slides/cell/), das Interface [ICell](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/) und weitere Typen, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können. 

## **Erstellen einer Tabelle von Grund auf**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) Objekt über die Methode [AddTable()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addtable/) hinzu.
6. Iterieren Sie über jedes [ICell](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/) und wenden Sie die Formatierung auf die oberen, unteren, rechten und linken Ränder an.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen. 
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframe/) eines [ICell](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/) zu. 
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframe/) etwas Text hinzu.
10. Speichern Sie die geänderte Präsentation.

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

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Fügt der Folie ein Tabellen-Shape hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Randformat für jede Zelle
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
// Verbindet Zellen 1 und 2 der Zeile 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Fügt dem zusammengeführten Feld Text hinzu
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C++‑Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:

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

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Fügt der Folie ein Tabellen-Shape hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Randformat für jede Zelle
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

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf eine vorhandene Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).

2. Holen Sie eine Referenz zur Folie, die die Tabelle enthält, über ihren Index. 

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) Objekt und setzen Sie es auf null.

4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden ist.

   Wenn Sie vermuten, dass die Folie, mit der Sie arbeiten, nur eine einzelne Tabelle enthält, können Sie einfach alle darin enthaltenen Shapes prüfen. Wenn ein Shape als Tabelle identifiziert wird, können Sie es mittels Typecast in ein [Table](https://reference.aspose.com/slides/de/cpp/aspose.slides/table/) Objekt umwandeln. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die benötigte Tabelle über ihr [set_AlternativeText()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_alternativetext/) zu suchen.

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die geänderte Präsentation.

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

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Initialisiert eine null Table
System::SharedPtr<ITable> tbl;

// Durchläuft die Shapes und setzt eine Referenz auf die gefundene Tabelle
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Setzt den Text für die erste Spalte der zweiten Zeile
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Speichert die geänderte Präsentation auf dem Datenträger
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Finden Sie die Zelle, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungscode ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) einer Tabelle erhält, verwenden Sie [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/), um die zugehörige [ICell](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/) abzurufen. Für einen Tabellenzellen‑Textframe liefert [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/) den Besitzer und [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/) liefert `nullptr`, obwohl die Tabelle selbst ein Shape ist.

Die Zellkoordinaten stehen über die schreibgeschützten Methoden [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/get_firstcolumnindex/) und [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/get_firstrowindex/) zur Verfügung. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/) bietet ebenfalls nur lesende Navigation: Sie gibt den Besitzer zurück, ändert jedoch den Besitz nicht. Prüfen Sie stets, ob die zurückgegebene Zelle `nullptr` ist, bevor Sie sie verwenden.

Ein komplettes Beispiel, das Tabellen‑Zell‑ und Shape‑Besitzer identifiziert, einschließlich Shapes, die mit SmartArt‑Knoten verknüpft sind, finden Sie unter [Search and Replace Text](/slides/de/cpp/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) Objekt hinzu. 
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) Objekt aus der Tabelle zu. 
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) des [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

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

// Erstellt eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Holt die erste Folie
auto slide = presentation->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Fügt das Tabellen-Shape zur Folie hinzu
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Greift auf den Textrahmen zu
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Erstellt das Paragraph-Objekt für den Textrahmen
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellt das Portion-Objekt für den Paragraph
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Richtet den Text vertikal aus
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Speichert die Präsentation auf dem Datenträger
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Greifen Sie von der Folie auf ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) Objekt zu.
4. Setzen Sie die [set_FontHeight()](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_fontheight/) für den Text. 
5. Setzen Sie die [set_Alignment()](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight()](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Setzen Sie die [set_TextVerticalType()](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Speichern Sie die geänderte Präsentation. 

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

// Erstellt eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Setzt die Schriftgröße der Tabellenzellen
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Setzt den vertikalen Texttyp der Tabellenzellen
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C++‑Code zeigt Ihnen, wie Sie die Stil‑Eigenschaften eines vordefinierten Tabellen‑Stils erhalten:

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

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft `AspectRatioLocked()` zur Verfügung, mit der Sie die Einstellung des Seitenverhältnisses für Tabellen und andere Formen sperren können. 

Dieser C++‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:

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

**Kann ich die Rechts‑nach‑Links‑Schreibrichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [set_RightToLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/table/set_righttoleft/) bereit, und Paragraphen besitzen [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraphformat/set_righttoleft/). Die Verwendung beider sorgt für die korrekte RTL‑Reihenfolge und Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder deren Größe ändern?**

Verwenden Sie [shape locks](/slides/de/cpp/applying-protection-to-presentation/), um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten ebenfalls für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/cpp/aspose.slides/picturefillformat/) festlegen; das Bild deckt den Zellbereich gemäß dem gewählten Modus (Strecken oder Kacheln) ab.
---
title: Tabellenzellen in Präsentationen mit C++
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/cpp/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen in C++: Identifizieren Sie zusammengeführte Zellen, entfernen Sie Rahmen, teilen Sie Zellen und setzen Sie Hintergrundfarben und Bilder mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint-Präsentationen und deren Modifizierung. Dieser Artikel erklärt, wie zusammengeführte Tabellenzellen identifiziert, Zellrahmen entfernt, die Zellnummerierung nach dem Zusammenführen oder Teilen von Zellen bearbeitet, die Hintergrundfarbe einer Zelle geändert und ein Bild in einer Tabellenzelle eingefügt wird. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle aus einer Folie abgerufen, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX-Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Eine zusammengeführte Tabellenzelle identifizieren**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird angenommen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend iteriert es über alle Zeilen und Spalten und verwendet [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/), um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellenkoordinaten in der Reihenfolge `row;column` aus, sowie [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), und die Startkoordinaten des Bereichs, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) und [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Tabellenzellenrahmen entfernen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und fügen Sie mit [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) eine Tabelle zur ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkt angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), wodurch sie unsichtbar werden.

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

## **Diagonale Zellrahmen hinzufügen**

Verwenden Sie [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/), um eine Linie von der oberen linken Ecke zur unteren rechten zu zeichnen, und [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/), um eine Linie von der unteren linken Ecke zur oberen rechten zu zeichnen. Eine Diagonale kann eine Ecküberschrift kennzeichnen; beide Diagonalen können ein X bilden, um eine Zelle als nicht zutreffend zu markieren.

Jede Diagonale ist ein [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Verwenden Sie [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/), um deren Füllung zu erhalten, rufen Sie [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) mit [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) auf und wählen Sie eine Farbe über [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Setzen Sie die Linienbreite mit [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) in Punkten.

Das Beispiel erstellt drei Zellen in einer Reihe: eine rote Diagonale nach unten, eine blaue Diagonale nach oben und beide Diagonalen. Die oberen, unteren, linken und rechten Zellrahmen bleiben unverändert.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Eine Diagonale ist eine Formatierungseigenschaft, kein Zellsplit. Jede Zelle behält einen einzelnen Textrahmen, der über [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) zugegriffen wird; die Bereiche auf beiden Seiten einer Diagonalen können nicht unabhängig bearbeitet werden.

Die gespeicherte Tabelle, dargestellt in Microsoft PowerPoint:

![Drei Tabellenzellen, die eine rote Diagonale von oben links nach unten rechts, eine blaue Diagonale von unten links nach oben rechts und beide Diagonalen, die ein X bilden, zeigen.](diagonal-cell-borders.png)

*Von links nach rechts: abwärts gerichtete Diagonale (rot, 3 pt), aufwärts gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4x4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und fügt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Gitternetz der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere‑linke Position: `table->idx_get(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes von Zellen außerhalb des Bereichs nicht ändern.

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

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel bewahrt das Gitter der Tabelle. Das Teilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes von Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4x4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird verwendet, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Split werden die beiden Hälften über `table->idx_get(1, 1)` und `table->idx_get(2, 1)` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu den Spalten 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split auf Zellen zugreifen.

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

<!-- visual-explanation:manage-cells:start -->
[![Eine nicht zusammengeführte 70‑Punkt‑Zelle wird in zwei 35‑Punkt‑Zellen aufgeteilt, wodurch eine fünfte Gitterspalte hinzugefügt und die Indizes rechts davon verschoben werden.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Der Breiten‑Split betrifft die Zelle (1, 1) und verwendet nullbasierte (Spalte, Zeile)-Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen‑ oder Spaltenspanne teilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/), um entlang einer bestehenden Zeilengrenze zu teilen, oder [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/), um entlang einer Spaltengrenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilen‑Split: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)
- Spalten‑Split: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) und [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/), um den Ursprung zu finden, und prüft beide Spannen. `SplitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung von zwei Spalten verwenden Sie stattdessen `SplitByColSpan(1)`.

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

    // Rufen Sie die resultierenden Zellen aus der Tabelle nach dem Aufteilen ab.
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

Das Tabellengitter und die umliegenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) gibt `False` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Split und setzen Sie erforderliche Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate „Product A“- und „Product B“-Zellen mit beibehaltener Zellformatierung der Vorlage. Siehe die [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) für Details.

### **Eine Zelle an einer bestimmten Höhe teilen**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) nimmt die Höhe des oberen Teils in Punkten. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) nimmt die Anzahl vorhandener Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Höhe der Zelle und teilen den verbleibenden Raum gleichmäßig darüber und darunter auf.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

Der erste Split fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkte bei `(1, 1)` übrig. Der zweite Split richtet sich an diese Zelle und fügt darunter eine weitere Zeile ein. Die rechte Spalte enthält nun `(1, 0)` mit 50 Punkten (`margin`), `(1, 1)` mit 40 Punkten und `(1, 2)` mit 50 Punkten (`margin`). Die linke Zelle erstreckt sich über alle drei Zeilen mit ihrer ursprünglichen Höhe von 140 Punkten.

![Die linke Zelle erstreckt die volle Tabellhöhe neben drei Zellen mit 'Middle' in der Mitte.](split-by-height.png)

## **Die Hintergrundfarbe einer Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/), um eine Vollfüllung auszuwählen, und [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), um die Füllfarbe zu erhalten und sie für die Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot zu setzen.

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

## **Ein Bild in einer Tabellenzelle hinzufügen**

Platzieren Sie das Eingabebild im Arbeitsverzeichnis, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) und fügt es der Bildsammlung der Präsentation mit [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) hinzu. Anschließend wird das Bild der Bildfüllung der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

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

## **FAQ**

**Kann ich für die verschiedenen Seiten einer einzelnen Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[unten](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[links](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[rechts](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)‑Ränder besitzen eigene Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle gesetzt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textrahmens der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriftarten festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung—Schriftfamilie, -stil, -größe und -farbe.
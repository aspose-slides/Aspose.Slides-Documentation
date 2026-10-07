---
title: Verwalten von Tabellenzellen in Präsentationen mit C++
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
description: "Verwalten von PowerPoint-Tabellenzellen in C++: Erkennen zusammengeführter Zellen, Entfernen von Rahmen, Teilen von Zellen sowie Festlegen von Hintergrundfarben und Bildern mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Änderung. Dieser Artikel erklärt, wie Sie zusammengeführte Tabellenzellen erkennen, Zellrahmen entfernen, mit der Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeiten, die Hintergrundfarbe einer Zelle ändern und ein Bild in einer Tabellenzelle einfügen. Die Beispiele zeigen, wie Sie eine Präsentation erstellen oder öffnen, eine Tabelle von einer Folie abrufen, die Zellformatierung über Zelleigenschaften aktualisieren und die geänderte Präsentation als PPTX‑Datei speichern.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Erkennen einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung werden die Zellkoordinaten in der Reihenfolge `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), und die Startkoordinaten des Bereichs, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) und [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/), ausgegeben.

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

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und fügen Sie mit [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) eine Tabelle zu ihrer ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkt angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), wodurch sie unsichtbar werden.

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

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken bzw. unteren rechten Ecke des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier zentralen Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Tabellengitter vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie in diesem Beispiel die Position oben links: `table->idx_get(1, 1)`. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes von Zellen außerhalb des Bereichs unverändert bleiben.

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

## **Aufteilen von Tabellenzellen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Spalte im Gitter einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table->idx_get(1, 1)` bzw. `table->idx_get(2, 1)` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu den Spalten 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen Zellen ansprechen.

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

### **Aufteilen zusammengeführter Zellen nach Zeilen‑ oder Spaltenumfang**

Um zusammengeführte Vorlagencellen für die Datenbefüllung vorzubereiten, verwenden Sie [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) zum Aufteilen entlang einer bestehenden Zeilenbegrenzung oder [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) zum Aufteilen entlang einer Spaltenbegrenzung.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil der Aufteilung; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Spaltenaufteilung: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) und [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/), um den Ursprung zu finden, und prüft beide Umfänge. `SplitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung von zwei Spalten verwenden Sie stattdessen `SplitByColSpan(1)`.

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

    // Abrufen der resultierenden Zellen aus der Tabelle nach dem Aufteilen.
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

Das Tabellengitter und die umgebenden Zellenindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spannweite von 1 und [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) gibt `False` aus. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie erforderliche Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate "Product A"- und "Product B"-Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Weitere Details finden Sie in der [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/).

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) zur Auswahl einer Vollfüllung und [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), um die Füllfarbe abzurufen und für die Zelle `(2, 3)` – in der dritten Spalte und vierten Zeile – auf Rot zu setzen.

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

## **Ein Bild in eine Tabellenzelle einfügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels im Arbeitsverzeichnis ab. Es lädt das Bild mit [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) und fügt es der Bildsammlung der Präsentation mit [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) hinzu. Anschließend wird das Bild der Bildfüllung der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, wodurch das Seitenverhältnis geändert werden kann. Spaltenbreiten und Zeilenhöhen werden in Punkt angegeben. Das geladene Bild wird freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

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

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzelnen Zelle festlegen?**  
Ja. Die [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)-Ränder besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilen‑Größe ändere, nachdem ein Bild als Hintergrund der Zelle festgelegt wurde?**  
Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) ab. Bei Stretching passt sich das Bild der neuen Zelle an; bei Tiling werden die Kacheln neu berechnet.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**  
[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzelnen Zelle festlegen?**  
Ja. Das Textfeld einer Zelle unterstützt [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (Textabschnitte) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.
---
title: Verwalten von Präsentationstabellen in C++
linktitle: Tabelle verwalten
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
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint‑Folien mit Aspose.Slides für C++. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Arbeitsabläufe zu optimieren."
---
## **Einleitung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten, wodurch das Lesen und Vergleichen von Werten einfacher wird.

Aspose.Slides bietet die [Tabelle](https://reference.aspose.com/slides/cpp/aspose.slides/table/)‑Klasse, das [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Interface, die [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)‑Klasse, das [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)‑Interface und weitere Typen, um Tabellen in Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie Position, Spaltenbreiten und Zeilenhöhen angeben. Nachdem Sie sie zu einer Folie hinzugefügt haben, können Sie Zellrahmen formatieren, Zellen zusammenführen und Text einfügen.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spaltenbreiten in Punkten.
4. Definieren Sie ein Array von Zeilenhöhen in Punkten.
5. Fügen Sie über die [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)‑Methode ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt zur Folie hinzu.
6. Durchlaufen Sie jedes [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/), um die oberen, unteren, rechten und linken Rahmen zu formatieren.
7. Führen Sie die ersten beiden Zellen der ersten Tabellenzeile zusammen.
8. Greifen Sie über die [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/)‑Methode auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Rahmen mit einer Breite von 5 Punkten an, führt die ersten beiden Zellen der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

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

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0).

Beispielsweise werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellrahmen von 5 Punkten Breite. Die Koordinaten veranschaulichen Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

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

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formensammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie dann das [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Interface, um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, über ihren Index.
3. Durchlaufen Sie die [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Objekte und stoppen Sie, sobald eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, nutzen Sie [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/), um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabe muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen besitzen.

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

Um die Höhe einer Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum ihre tatsächliche Höhe die angeforderte Mindesthöhe überschreiten kann, siehe [Control Row Height](/slides/de/cpp/manage-rows-and-columns/#control-row-height).

## **Finden Sie die Zelle, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungs‑Code ein [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) von einer Tabelle erhält, verwenden Sie [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/), um die zugehörige [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) abzurufen. Für einen Tabellen‑Zellen‑Textrahmen liefert [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) den Besitzer und [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) gibt `nullptr` zurück, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten stehen über die schreibgeschützten Methoden [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) und [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) zur Verfügung. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) bietet zudem eine schreibgeschützte Navigation: Sie liefert den Besitzer, ändert jedoch nicht die Besitzverhältnisse. Prüfen Sie stets, ob die zurückgegebene Zelle `nullptr` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zellen‑ und Form‑Besitzer sowie Formen, die mit SmartArt‑Knoten verbunden sind, identifiziert, finden Sie unter [Search and Replace Text](/slides/de/cpp/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Text­richtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt zur Folie hinzu.
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)‑Objekt zu.
5. Greifen Sie auf das erste [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie die vertikale Verankerung und Text‑Richtung der Zelle mittels [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) und [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt Werte zu den übrigen Zellen der ersten Zeile hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

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

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/), um Textformatierung auf alle Zellen einer Tabelle anzuwenden. Die Überladungen akzeptieren Abschnitts‑, Absatz‑ und Textrahmen‑Formatierung, sodass Sie diese Eigenschaften setzen können, ohne jede Zelle einzeln durchlaufen zu müssen.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Greifen Sie von der Folie aus auf ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt zu.
4. Setzen Sie die Schriftgröße mittels [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) für den Text.
5. Setzen Sie die Absatzausrichtung und den rechten Rand mittels [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Setzen Sie die Text­richtung mittels [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

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

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/), um den vordefinierten Stil einer Tabelle zu lesen, und [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/), um ihn zuzuweisen. Dieses Beispiel wendet [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Namen des Presets aus und weist denselben Preset einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

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

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/), um dieses Verhältnis für eine Tabelle zu sperren.

Das nachstehende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es gibt den aktuellen Sperrstatus aus, aktiviert die Sperrung des Seitenverhältnisses, gibt den aktualisierten Zustand (`True`) aus und speichert das Ergebnis als `pres-out.pptx`.

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

**Kann ich die Rechts‑zu‑Links‑Leserichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) bereit, und Absätze besitzen [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Die Verwendung beider stellt die korrekte RTL‑Reihenfolge und -Darstellung in den Zellen sicher.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [Form‑Sperren](/slides/de/cpp/applying-protection-to-presentation/), um Verschieben, Größeneinstellung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt die Zellenfläche gemäß dem gewählten Modus (Strecken oder Kacheln).
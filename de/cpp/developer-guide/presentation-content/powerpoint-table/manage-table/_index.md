---
title: Tabelle verwalten
type: docs
weight: 10
url: /cpp/manage-table/
keywords: "Tabelle, Tabelle erstellen, auf Tabelle zugreifen, Tabellen-Seitenverhältnis, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Tabelle in PowerPoint-Präsentationen in C++ erstellen und verwalten"
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und darzustellen. Die Informationen in einem Gitter von Zellen (angeordnet in Zeilen und Spalten) sind einfach und leicht zu verstehen.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) Klasse, die [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Schnittstelle, die [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) Klasse, die [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) Schnittstelle und andere Typen, um Ihnen zu ermöglichen, Tabellen in allen Arten von Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt zur Folie über die [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) Methode hinzu.
6. Iterieren Sie durch jede [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/), um die Formatierung für die oberen, unteren, rechten und linken Ränder anzuwenden.
7. Mergen Sie die ersten beiden Zellen der ersten Zeile der Tabelle.
8. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) einer [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) zu.
9. Fügen Sie etwas Text zum [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```c++
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Fügt eine Tabellenform zur Folie hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Randformat für jede Zelle
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// Merged die Zellen 1 & 2 von Zeile 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Fügt Text zur zusammengeführten Zelle hinzu
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Zusammengeführte Zellen");

// Speichert die Präsentation auf der Festplatte
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen einfach und null-basiert. Die erste Zelle in einer Tabelle ist mit 0,0 (Spalte 0, Zeile 0) indiziert.

Zum Beispiel sind die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen so nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C++-Code zeigt Ihnen, wie Sie die Nummerierung für Zellen in einer Tabelle angeben:

```c++
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Fügt eine Tabellenform zur Folie hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Randformat für jede Zelle
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Rot());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Speichert die Präsentation auf der Festplatte
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf vorhandene Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.

2. Erhalten Sie einen Verweis auf die Folie, die die Tabelle enthält, über ihren Index.

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt und setzen Sie es auf null.

4. Iterieren Sie durch alle [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die Folie, mit der Sie arbeiten, eine einzelne Tabelle enthält, können Sie einfach alle Formen, die sie enthält, überprüfen. Wenn eine Form als Tabelle identifiziert wird, können Sie sie als [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) Objekt typisieren. Wenn die Folie, mit der Sie arbeiten, mehrere Tabellen enthält, suchen Sie besser nach der Tabelle, die Sie benötigen, über ihre [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten können:

```c++
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Initialisiert null Table
System::SharedPtr<ITable> tbl;

// Iteriert durch die Formen und setzt einen Verweis auf die gefundene Tabelle
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Setzt den Text für die erste Spalte der zweiten Zeile
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"Neu");

// Speichert die geänderte Präsentation auf der Festplatte
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Text in Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Objekt aus der Tabelle zu.
5. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie den Text in einer Tabelle ausrichten:

```c++
// Erstellt eine Instanz der Präsentationsklasse
auto presentation = System::MakeObject<Presentation>();

// Holt die erste Folie
auto slide = presentation->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Fügt die Tabellenform zur Folie hinzu
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Greift auf den Textrahmen zu
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Erstellt das Absatzobjekt für den Textrahmen
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellt das Portionenobjekt für den Absatz
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text hier");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Schwarz());

// Richtet den Text vertikal aus
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Speichert die Präsentation auf der Festplatte
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt aus der Folie zu.
4. Setzen Sie die [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) für den Text.
5. Setzen Sie die [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Setzen Sie den [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```c++
// Erstellt eine Instanz der Präsentationsklasse
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
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

## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, damit Sie diese Details für eine andere Tabelle oder anderswo verwenden können. Dieser C++-Code zeigt Ihnen, wie Sie die Stileigenschaften von einem vordefinierten Tabellestil abrufen:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Seitenverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die `AspectRatioLocked()` Eigenschaft zur Verfügung, um das Seitenverhältnis für Tabellen und andere Formen zu sperren.

Dieser C++-Code zeigt Ihnen, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Seitenverhältnis gesperrt: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Seitenverhältnis gesperrt: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```
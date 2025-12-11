---
title: Präsentationstabellen in C++ verwalten
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
description: "Tabellen in PowerPoint-Folien mit Aspose.Slides für C++ erstellen und bearbeiten. Entdecken Sie einfache Codebeispiele, um Ihre Tabellenvorgänge zu optimieren."
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu vermitteln. Die Informationen in einem Raster von Zellen (geordnet in Zeilen und Spalten) sind eindeutig und leicht zu verstehen.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Interface, die [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) Interface und weitere Typen, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können. 

## **Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt über die Methode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) hinzu.  
6. Iterieren Sie über jedes [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/), um die Formatierung für die oberen, unteren, rechten und linken Ränder anzuwenden.  
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) eines [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

```c++
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Fügt der Folie ein Tabellenshape hinzu
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

Zum Beispiel werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C++‑Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:
```c++
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Fügt der Folie ein Tabellenshape hinzu
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
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red);
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red);
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```


## **Zugriff auf eine vorhandene Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  

2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, über ihren Index.  

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt und setzen Sie es auf null.  

4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden wird.  

   Wenn Sie vermuten, dass die betreffende Folie nur eine einzige Tabelle enthält, können Sie einfach alle enthaltenen Formen prüfen. Wird eine Form als Tabelle identifiziert, können Sie sie mittels Cast in ein [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) Objekt umwandeln. Enthält die Folie jedoch mehrere Tabellen, sollten Sie die gewünschte Tabelle über deren [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/) suchen.  

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im nachstehenden Beispiel haben wir der Tabelle eine neue Zeile hinzugefügt.  

6. Speichern Sie die geänderte Präsentation.

```c++
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Initialisiert null Tabelle
System::SharedPtr<ITable> tbl;

// Iteriert über die Shapes und setzt eine Referenz auf die gefundene Tabelle
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Setzt den Text für die erste Spalte der zweiten Zeile
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Speichert die modifizierte Präsentation auf dem Datenträger
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.  
3. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt hinzu.  
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Objekt der Tabelle zu.  
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) des [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) zu.  
6. Richten Sie den Text vertikal aus.  
7. Speichern Sie die geänderte Präsentation.

```c++
// Erstellt eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Ruft die erste Folie ab
auto slide = presentation->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Fügt der Folie das Tabellenshape hinzu
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Greift auf den Textframe zu
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Erstellt das Paragraph-Objekt für den Textframe
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

// Speichert die Presentation auf dem Datenträger
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```


## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.  
3. Greifen Sie vom Folienobjekt auf ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) Objekt zu.  
4. Setzen Sie die [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) für den Text.  
5. Setzen Sie die [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).  
6. Setzen Sie die [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).  
7. Speichern Sie die geänderte Präsentation. 

```c++
// Erstellt eine Instanz der Presentation-Klasse
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

Aspose.Slides ermöglicht es Ihnen, die Stil‑Eigenschaften einer Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C++‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellenvorlage‑Stil erhalten:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Abmessungen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft `AspectRatioLocked()` bereit, mit der Sie die Einstellung des Seitenverhältnisses für Tabellen und andere Formen sperren können. 

Dieser C++‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich die Rechts‑zu‑Links‑Lese­richtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt eine [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) Methode bereit, und Absätze haben [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Die Verwendung beider sorgt für die korrekte RTL‑Reihenfolge und -Darstellung in den Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/cpp/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, die Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt die Zellenfläche gemäß dem gewählten Modus (Strecken oder Kacheln).
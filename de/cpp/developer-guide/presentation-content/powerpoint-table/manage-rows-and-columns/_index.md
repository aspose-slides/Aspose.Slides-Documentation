---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit C++
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/cpp/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopfzeile
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Textformatierung für Zeilen
- Textformatierung für Spalten
- Tabellenstil
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für C++ und beschleunigen Sie die Bearbeitung von Präsentationen sowie Datenaktualisierungen."
---

Um Ihnen die Verwaltung von Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) und das Interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) sowie viele weitere Typen bereit. 

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation. 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt und setzen Sie es auf null. 
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Objekte, um die entsprechende Tabelle zu finden. 
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile. 

Dieser C++‑Code zeigt Ihnen, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:
```c++
// Instanziiert die Presentation-Klasse 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Initialisiert die null TableEx
SharedPtr<ITable> tbl;

// Iteriert durch die Shapes und setzt eine Referenz auf die Tabelle
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Setzt die erste Zeile einer Tabelle als Kopfzeile 
tbl->set_FirstRow(true);
```


## **Eine Tabellenzeile oder -spalte klonen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt über die Methode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Klonen Sie die Tabellenzeile. 
7. Klonen Sie die Tabellenspalte. 
8. Speichern Sie die modifizierte Präsentation. 

Dieser C++‑Code zeigt Ihnen, wie Sie eine PowerPoint‑Tabellenzeile oder -spalte klonen:
```c++
 // Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instanziert die Presentation-Klasse
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Fügt der Folie ein Tabellenshape hinzu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Setzt das Rahmenformat für jede Zelle
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone fügt am Ende der Tabelle eine Zeile hinzu
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone fügt an einer bestimmten Position in der Tabelle eine Zeile ein
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone fügt am Ende der Tabelle eine Spalte hinzu
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone fügt an einer bestimmten Position in der Tabelle eine Spalte ein
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Speichert die Präsentation auf dem Datenträger
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt über die Methode [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Entfernen Sie die Tabellenzeile. 
7. Entfernen Sie die Tabellenspalte. 
8. Speichern Sie die modifizierte Präsentation. 

Dieser C++‑Code zeigt Ihnen, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instanziert die Presentation-Klasse
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert die Spalten mit Breiten und die Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Fügt der Folie ein Tabellenshape hinzu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Zusammenführen der Zellen (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Zusammenführen der Zellen (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Speichert die Präsentation auf dem Datenträger
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Textformatierung auf Zeilenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Greifen Sie auf das entsprechende [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt der Folie zu. 
4. Setzen Sie für die Zellen der ersten Zeile [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Setzen Sie für die Zellen der ersten Zeile [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Setzen Sie für die Zellen der zweiten Zeile [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Speichern Sie die modifizierte Präsentation. 

Dieser C++‑Code demonstriert den Vorgang.
```c++
// Erstellt eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle
// Setzt die Schriftgröße der Zellen der ersten Zeile
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Setzt den vertikalen Texttyp der Zellen der zweiten Zeile
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf dem Datenträger
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **Textformatierung auf Spaltenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, 
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Greifen Sie auf das entsprechende [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)‑Objekt der Folie zu. 
4. Setzen Sie für die Zellen der ersten Spalte [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Setzen Sie für die Zellen der ersten Spalte [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) und [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Setzen Sie für die Zellen der zweiten Spalte [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Speichern Sie die modifizierte Präsentation. 

Dieser C++‑Code demonstriert den Vorgang: 
```c++
// Erstellt eine Instanz der Presentation-Klasse
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle

// Setzt die Schriftgröße der Zellen der ersten Spalte
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte in einem Aufruf
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stileigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C++‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellestil erhalten:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/Layout/Master und Sie können dennoch Füllungen, Rahmen und Textfarben über das Design hinweg überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen verfügen nicht über integrierte Sortier‑ oder Filterfunktionen. Sortieren Sie Ihre Daten zuerst im Speicher und fügen Sie dann die Tabellzeilen in dieser Reihenfolge wieder hinzu.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Zellen‑formatierung hat Vorrang vor dem Tabellstil.
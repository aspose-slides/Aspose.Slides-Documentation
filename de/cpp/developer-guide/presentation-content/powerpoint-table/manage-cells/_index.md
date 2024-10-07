---
title: Zellen verwalten
type: docs
weight: 30
url: /cpp/manage-cells/
keywords: "Tabelle, zusammengeführte Zellen, geteilte Zellen, Bild in Tabellenzelle, C++, CPP, Aspose.Slides für C++"
description: "Tabellenzellen in PowerPoint-Präsentationen in C++"
---

## **Zusammengeführte Zelle identifizieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie sich die Tabelle von der ersten Folie. 
3. Iterieren Sie durch die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Drucken Sie eine Nachricht, wenn zusammengeführte Zellen gefunden werden.

Dieser C++-Code zeigt, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// vorausgesetzt, dass Slide#0.Shape#0 eine Tabelle ist
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Zelle {0};{1} ist Teil der zusammengeführten Zelle mit RowSpan={2} und ColSpan={3}, beginnend von Zelle {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Tabellenzellenrahmen entfernen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index. 
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie eine Tabelle zur Folie über die `AddTable` Methode hinzu.
6. Iterieren Sie durch jede Zelle, um die oberen, unteren, rechten und linken Rahmen zu löschen.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt, wie Sie die Rahmen von Tabellenzellen entfernen:

``` cpp
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
auto pres = MakeObject<Presentation>();
// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Fügt eine Tabellenform zur Folie hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Rahmendesign für jede Zelle
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Nummerierung in zusammengeführten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser C#-Code demonstriert den Prozess:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Fügt eine Tabellenform zur Folie hinzu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Setzt das Rahmendesign für jede Zelle
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
// Fügt zusammen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fügt zusammen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Wir führen dann die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle, die eine große zusammengeführte Zelle in der Mitte enthält:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/MergeCells_out.pptx";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Fügt eine Tabellenform zur Folie hinzu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Setzt das Rahmendesign für jede Zelle
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

// Fügt zusammen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fügt zusammen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nummerierung in geteilten Zellen**
In den vorherigen Beispielen, als Tabellenzellen zusammengeführt wurden, änderte sich die Numerierung oder das Nummerierungssystem in anderen Zellen nicht. 

Diesmal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, die Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie sollten auf die Nummerierung dieser Tabelle achten, die als merkwürdig angesehen werden kann. Doch so nummeriert Microsoft PowerPoint Tabellenzellen, und Aspose.Slides macht dasselbe. 

Dieser C++-Code demonstriert den beschriebenen Prozess:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/CellSplit_out.pptx";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Fügt eine Tabellenform zur Folie hinzu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Setzt das Rahmendesign für jede Zelle
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

// Fügt zusammen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fügt zusammen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// teilt die Zelle (1, 1).
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser C++-Code zeigt, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// erstellen Sie eine neue Tabelle
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// Hintergrundfarbe für eine Zelle festlegen 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Bild innerhalb der Tabellenzelle hinzufügen**
1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie eine Tabelle zur Folie über die `AddTable` Methode hinzu. 
6. Erstellen Sie ein `Bitmap`-Objekt, um die Bilddatei zu halten.
7. Fügen Sie das Bitmap-Bild zum `IPPImage`-Objekt hinzu.
8. Setzen Sie das `FillFormat` für die Tabellenzelle auf `Bild`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt, wie Sie ein Bild innerhalb einer Tabellenzelle hinzufügen, wenn Sie eine Tabelle erstellen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Fügt eine Tabellenform zur Folie hinzu
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Holt das Bild
auto img = Images::FromFile(ImagePath);

// Fügt ein Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Fügt das Bild zur ersten Tabellenzelle hinzu
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Speichern Sie die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```
---
title: Tabellenzellen in Präsentationen mit C++ verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/cpp/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Tabellenzellen in PowerPoint mühelos mit Aspose.Slides für C++. Beherrschen Sie den schnellen Zugriff, die Modifizierung und das Styling von Zellen für eine nahtlose Folienautomatisierung."
---

## **Zusammengeführte Zelle identifizieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie die Tabelle von der ersten Folie.
3. Iterieren Sie durch die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Dieser C++-Code zeigt Ihnen, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren:
``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```


## **Tabellenzellenrahmen entfernen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie über die `AddTable`-Methode eine Tabelle zur Folie hinzu.
6. Iterieren Sie durch jede Zelle, um die oberen, unteren, rechten und linken Rahmen zu löschen.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Rahmen von Tabellenzellen entfernen:
``` cpp
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
auto pres = MakeObject<Presentation>();
// Greift auf die erste Folie zu
auto sld = pres->get_Slides()->idx_get(0);

// Definiert Spalten mit Breiten und Zeilen mit Höhen
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Fügt der Folie ein Tabellenshape hinzu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Setzt das Rahmenformat für jede Zelle
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
Wenn wir 2 Zellpaare (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser C#-Code demonstriert den Vorgang:
```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Lädt die gewünschte Präsentation
// Greift auf die erste Folie zu
// Definiert Spalten mit Breiten und Zeilen mit Höhen
// Fügt der Folie ein Tabellenshape hinzu


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
// Führt Zellen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Führt Zellen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Wir führen anschließend die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in ihrer Mitte:
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

// Fügt Zellen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fügt Zellen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Nummerierung in einer geteilten Zelle**
In früheren Beispielen änderte sich die Numerierung oder das Nummernsystem in den anderen Zellen nicht, wenn Tabellenzellen zusammengeführt wurden.

Dieses Mal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie sollten die Nummerierung dieser Tabelle beachten, die möglicherweise seltsam wirkt. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides macht dasselbe.

Dieser C++-Code demonstriert den beschriebenen Vorgang:
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

// Führt Zellen (1, 1) x (2, 1) zusammen
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Führt Zellen (1, 2) x (2, 2) zusammen
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Teilt Zelle (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Hintergrundfarbe der Tabellenzelle ändern**
Dieser C++-Code zeigt Ihnen, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:
``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// erzeuge eine neue Tabelle
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// setze die Hintergrundfarbe für eine Zelle 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Bild in einer Tabellenzelle hinzufügen**
1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie über die `AddTable`-Methode eine Tabelle zur Folie hinzu.
6. Erstellen Sie ein `Bitmap`-Objekt, um die Bilddatei zu halten.
7. Fügen Sie das Bitmap-Bild dem `IPPImage`-Objekt hinzu.
8. Setzen Sie das `FillFormat` für die Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei

Dieser C#-Code zeigt Ihnen, wie Sie beim Erstellen einer Tabelle ein Bild in einer Tabellenzelle platzieren:
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

// Fügt der Folie ein Tabellenshape hinzu
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Lädt das Bild
auto img = Images::FromFile(ImagePath);

// Fügt ein Bild zur Bildersammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Fügt das Bild in die erste Tabellenzelle ein
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Speichert die PPTX-Datei auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[unten](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[links](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[rechts](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)‑Ränder haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Dies ergibt sich logisch aus der per‑Seite‑Randsteuerung für eine Zelle, die im Artikel demonstriert wird.

**Was passiert mit dem Bild, wenn ich nach dem Festlegen eines Bildes als Hintergrund der Zelle die Spalten‑/Zeilengröße ändere?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Bildanzeigemodi in einer Zelle.

**Kann ich einem Hyperlink dem gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.
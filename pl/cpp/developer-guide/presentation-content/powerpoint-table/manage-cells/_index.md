---
title: Zarządzanie komórkami tabel w prezentacjach przy użyciu C++
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/cpp/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Bezproblemowo zarządzaj komórkami tabel w PowerPoint przy użyciu Aspose.Slides dla C++. Opanuj szybki dostęp, modyfikację i stylizację komórek, aby uzyskać płynną automatyzację slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez ich właściwości oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikacja scalonej komórki**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz tabelę z pierwszego slajdu. 
3. Przejdź przez wiersze i kolumny tabeli, aby znaleźć scalone komórki.
4. Wypisz komunikat, gdy zostaną znalezione scalone komórki.

Ten kod C++ pokazuje, jak zidentyfikować scalone komórki tabel w prezentacji:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// zakładając, że Slide#0.Shape#0 jest tabelą
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

## **Usuwanie obramowań komórek tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz odniesienie do slajdu przez jego indeks. 
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu metodą `AddTable`.
6. Przejdź przez każdą komórkę, aby usunąć górne, dolne, prawe i lewe obramowanie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C++ pokazuje, jak usunąć obramowania z komórek tabeli:

``` cpp
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
auto pres = MakeObject<Presentation>();
// Uzyskuje dostęp do pierwszego slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Dodaje kształt tabeli do slajdu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ustawia format obramowania dla każdej komórki
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

// Zapisuje plik PPTX na dysku
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numeracja w scalonych komórkach**
Jeśli scalimy 2 pary komórek (1, 1) x (2, 1) i (1, 2) x (2, 2), powstała tabela będzie ponumerowana. Ten kod C# demonstruje ten proces:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Dodaje kształt tabeli do slajdu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ustawia format obramowania dla każdej komórki
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
// Scala komórki (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Scala komórki (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Zapisuje plik PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Następnie scalamy komórki dalej, scalając (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą scaloną komórkę w środku:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/MergeCells_out.pptx";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Dodaje kształt tabeli do slajdu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ustawia format obramowania dla każdej komórki
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

// Scala komórki (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Scala komórki (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Zapisuje plik PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numeracja w podzielonej komórce**
W poprzednich przykładach, gdy komórki tabeli były scalane, numeracja w pozostałych komórkach nie ulegała zmianie. 

Tym razem bierzemy zwykłą tabelę (bez scalonych komórek) i dzielimy komórkę (1,1), aby uzyskać specjalną tabelę. Zwróć uwagę na numerację tej tabeli, która może wydawać się nietypowa. Tak jednak numeruje komórki Microsoft PowerPoint, a Aspose.Slides zachowuje się tak samo. 

Ten kod C++ demonstruje opisany proces:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/CellSplit_out.pptx";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Dodaje kształt tabeli do slajdu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Ustawia format obramowania dla każdej komórki
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

// Scala komórki (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Scala komórki (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Dzieli komórkę (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Zapisuje plik PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zmiana koloru tła komórki tabeli**

Ten kod C++ pokazuje, jak zmienić kolor tła komórki tabeli:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// utwórz nową tabelę
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// set the background color for a cell 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Dodanie obrazu wewnątrz komórki tabeli**
1. Utwórz instancję klasy `Presentation`.
2. Pobierz odniesienie do slajdu przez jego indeks.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu metodą `AddTable`. 
6. Utwórz obiekt `Bitmap`, aby przechować plik obrazu.
7. Dodaj obraz bitmapowy do obiektu `IPPImage`.
8. Ustaw `FillFormat` dla komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod C# pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Dodaje kształt tabeli do slajdu
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Pobiera obraz
auto img = Images::FromFile(ImagePath);

// Dodaje obraz do kolekcji obrazów prezentacji
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Dodaje obraz do pierwszej komórki tabeli
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Zapisuje plik PPTX na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/pl/cpp/aspose.slides/cellformat/get_bordertop/),[dolne](https://reference.aspose.com/slides/pl/cpp/aspose.slides/cellformat/get_borderbottom/),[lewe](https://reference.aspose.com/slides/pl/cpp/aspose.slides/cellformat/get_borderleft/),[prawe](https://reference.aspose.com/slides/pl/cpp/aspose.slides/cellformat/get_borderright/) mają osobne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to z kontrolowania obramowań po stronie w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełniania](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. Artykuł wspomina o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej treści komórki?**

[Hyperlinks](/slides/pl/cpp/manage-hyperlinks/) są ustawiane na poziomie fragmentu tekstu wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portiony](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portion/) (uruchomienia) z niezależnym formatowaniem — rodziną czcionki, stylem, rozmiarem i kolorem.
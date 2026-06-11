---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu C++
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/cpp/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonowanie wiersza
- klonowanie kolumny
- kopiowanie wiersza
- kopiowanie kolumny
- usuwanie wiersza
- usuwanie kolumny
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabeli w PowerPoint przy pomocy Aspose.Slides dla C++ oraz przyspiesz edycję prezentacji i aktualizację danych."
---
## **Wprowadzenie**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) oraz wiele innych typów. 

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację. 
2. Uzyskaj referencję do slajdu po jego indeksie. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) i ustaw go na null. 
4. Iteruj po wszystkich obiektach [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) aby znaleźć odpowiednią tabelę. 
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek. 

Ten kod C++ pokazuje, jak ustawić pierwszy wiersz tabeli jako nagłówek:

```c++
// Tworzy instancję klasy Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Uzyskuje dostęp do pierwszego slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Inicjalizuje nulowy TableEx
SharedPtr<ITable> tbl;

// Iteruje po kształtach i ustawia referencję do tabeli
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Ustawia pierwszy wiersz tabeli jako nagłówek 
tbl->set_FirstRow(true);
```

## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację, 
2. Uzyskaj referencję do slajdu po jego indeksie. 
3. Zdefiniuj tablicę `columnWidth`. 
4. Zdefiniuj tablicę `rowHeight`. 
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) do slajdu za pomocą metody [AddTable()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addtable/). 
6. Sklonuj wiersz tabeli. 
7. Sklonuj kolumnę tabeli. 
8. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```c++
 // Ścieżka do katalogu dokumentów.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instancjonuje klasę Presentation
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone dodaje wiersz na końcu tabeli
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone dodaje wiersz w określonej pozycji w tabeli
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone dodaje kolumnę na końcu tabeli
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone dodaje kolumnę w określonej pozycji w tabeli
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Zapisuje prezentację na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację, 
2. Uzyskaj referencję do slajdu po jego indeksie. 
3. Zdefiniuj tablicę `columnWidth`. 
4. Zdefiniuj tablicę `rowHeight`. 
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) do slajdu za pomocą metody [AddTable()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addtable/). 
6. Usuń wiersz tabeli. 
7. Usuń kolumnę tabeli. 
8. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Tworzy instancję klasy Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Dodaje kształt tabeli do slajdu
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Łączy komórki (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Łączy komórki (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Zapisuje prezentację na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację, 
2. Uzyskaj referencję do slajdu po jego indeksie. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) ze slajdu. 
4. Ustaw wysokość czcionki pierwszego wiersza przy użyciu [set_FontHeight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Ustaw wyrównanie pierwszego wiersza przy użyciu [set_Alignment()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz prawy margines przy użyciu [set_MarginRight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Ustaw pionowy typ tekstu w komórkach drugiego wiersza przy użyciu [set_TextVerticalType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ demonstruje tę operację.

```c++
// Tworzy instancję klasy Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
// Ustawia wysokość czcionki komórek pierwszego wiersza
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu i prawy margines komórek pierwszego wiersza
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek drugiego wiersza
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Zapisuje prezentację na dysk
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację, 
2. Uzyskaj referencję do slajdu po jego indeksie. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) ze slajdu. 
4. Ustaw wysokość czcionki pierwszej kolumny przy użyciu [set_FontHeight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Ustaw wyrównanie pierwszej kolumny przy użyciu [set_Alignment()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz prawy margines przy użyciu [set_MarginRight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Ustaw pionowy typ tekstu w komórkach drugiej kolumny przy użyciu [set_TextVerticalType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ demonstruje tę operację: 

```c++
// Tworzy instancję klasy Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą

// Ustawia wysokość czcionki komórek pierwszej kolumny
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu i prawy margines komórek pierwszej kolumny w jednym wywołaniu
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek drugiej kolumny
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można je było wykorzystać w innej tabeli lub w innym miejscu. Ten kod C++ pokazuje, jak pobrać właściwości stylu z predefiniowanego stylu tabeli:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę zastosować motywy/styl PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/master, a nadal można nadpisać wypełnienia, obramowania i kolory tekstu w ramach tego motywu.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie posiadają wbudowanego sortowania ani filtrów. Najpierw posortuj dane w pamięci, a następnie wypełnij ponownie wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (przebarwione) kolumny, zachowując własne kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz określone komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.
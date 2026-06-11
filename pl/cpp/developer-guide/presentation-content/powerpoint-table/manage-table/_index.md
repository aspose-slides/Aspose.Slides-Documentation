---
title: "Zarządzanie tabelami prezentacji w C++"
linktitle: "Zarządzaj tabelą"
type: docs
weight: 10
url: /pl/cpp/manage-table/
keywords:
- "dodaj tabelę"
- "utwórz tabelę"
- "dostęp do tabeli"
- "proporcje"
- "wyrównaj tekst"
- "formatowanie tekstu"
- "styl tabeli"
- "PowerPoint"
- "prezentacja"
- "C++"
- "Aspose.Slides"
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla C++. Odkryj proste przykłady kodu, które usprawnią Twoje przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint jest efektywnym sposobem wyświetlania i przedstawiania informacji. Informacje w siatce komórek (ustawionych w wierszach i kolumnach) są proste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) , klasę [Cell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/cell/) , interfejs [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami we wszystkich rodzajach prezentacji. 

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu przez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) do slajdu przy użyciu metody [AddTable()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addtable/) .
6. Iteruj po każdym [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/) , aby zastosować formatowanie krawędzi górnej, dolnej, prawej i lewej.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/) obiektu [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/) .
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/) .
10. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak utworzyć tabelę w prezentacji:

```c++
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
auto pres = System::MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Dodaje kształt tabeli do slajdu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ustawia format obramowania dla każdej komórki
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
// Scala komórki 1 i 2 wiersza 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Dodaje tekst do scalonej komórki
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Zapisuje prezentację na dysku
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład, komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod C++ pokazuje, jak określić numerację komórek w tabeli:

```c++
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
auto pres = System::MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Dodaje kształt tabeli do slajdu
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Ustawia format obramowania dla każdej komórki
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
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Zapisuje prezentację na dysku
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .

2. Uzyskaj referencję do slajdu zawierającego tabelę przez jego indeks. 

3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) i ustaw go na null.

4. Iteruj przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) , aż znajdziesz tabelę.  
   Jeśli podejrzewasz, że slajd, z którym pracujesz, zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie znajdujące się na nim kształty. Gdy kształt zostanie zidentyfikowany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/) . Jednak jeśli slajd zawiera kilka tabel, lepiej jest wyszukać potrzebną tabelę przy użyciu jej metody [set_AlternativeText()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_alternativetext/) .

5. Użyj obiektu [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) , aby pracować z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.

6. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak uzyskać dostęp do istniejącej tabeli i pracować z nią:

```c++
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Uzyskuje dostęp do pierwszego slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Inicjalizuje pustą tabelę
System::SharedPtr<ITable> tbl;

// Iteruje przez kształty i ustawia referencję do znalezionej tabeli
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Ustawia tekst dla pierwszej kolumny drugiego wiersza
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Zapisuje zmodyfikowaną prezentację na dysk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Wyrównanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu przez jego indeks. 
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) do slajdu. 
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) z tabeli. 
5. Uzyskaj dostęp do [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) obiektu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) .
6. Wyrównaj tekst pionowo.
7. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak wyrównać tekst w tabeli:

```c++
// Tworzy instancję klasy Presentation
auto presentation = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd 
auto slide = presentation->get_Slides()->idx_get(0);

// Definiuje kolumny o szerokościach i wiersze o wysokościach
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Dodaje kształt tabeli do slajdu
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Uzyskuje dostęp do ramki tekstowej
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Tworzy obiekt Paragraph dla ramki tekstowej
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Tworzy obiekt Portion dla akapitu
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Wyrównuje tekst pionowo
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Zapisuje prezentację na dysku
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Ustawienie formatowania tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj referencję do slajdu przez jego indeks. 
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) ze slajdu.
4. Ustaw [set_FontHeight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_fontheight/) dla tekstu. 
5. Ustaw [set_Alignment()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz [set_MarginRight()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Ustaw [set_TextVerticalType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak zastosować preferowane opcje formatowania do tekstu w tabeli:

```c++
// Tworzy instancję klasy Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Ustawia wysokość czcionki komórek tabeli
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu komórek tabeli oraz prawy margines w jednym wywołaniu
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek tabeli
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było użyć tych informacji w innej tabeli lub w innym miejscu. Ten kod C++ pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Zablokowanie proporcji tabeli**

Proporcje geometrycznego kształtu to stosunek jego wymiarów w różnych kierunkach. Aspose.Slides udostępnia właściwość `AspectRatioLocked()` , która pozwala zablokować ustawienie proporcji dla tabel i innych kształtów. 

Ten kod C++ pokazuje, jak zablokować proporcje dla tabeli:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [set_RightToLeft](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/set_righttoleft/) , a akapity mają [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Użycie obu zapewnia prawidłowy kolejność RTL oraz renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmianie rozmiaru tabeli przez użytkowników w finalnym pliku?**

Użyj [shape locks](/slides/pl/cpp/applying-protection-to-presentation/) , aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady dotyczą również tabel.

**Czy wstawianie obrazu jako tła wewnątrz komórki jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillformat/) , aby wypełnić komórkę obrazem; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciągnięcie lub kafelkowanie).
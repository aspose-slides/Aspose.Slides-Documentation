---
title: Pobieranie granic akapitu z prezentacji w C++
linktitle: Akapit
type: docs
weight: 60
url: /pl/cpp/paragraph/
keywords:
- granice akapitu
- granice fragmentu tekstu
- współrzędne akapitu
- współrzędne fragmentu
- rozmiar akapitu
- rozmiar fragmentu tekstu
- ramka tekstowa
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu i fragmentu tekstu w Aspose.Slides dla C++, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu w `TextFrame` za pomocą `GetRect()`, jak uzyskać współrzędne akapitu i fragmentu wewnątrz tekstowego pola komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli oraz efektywne wartości formatowania akapitu.

## **Uzyskiwanie współrzędnych akapitu i fragmentu w TextFrame**

Korzystając z Aspose.Slides dla C++, programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Umożliwia to także pobranie współrzędnych fragmentu w kolekcji fragmentów akapitu. W tym temacie pokażemy, jak na przykładzie uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu wewnątrz akapitu.

## **Uzyskiwanie prostokątnych współrzędnych akapitu**

Dodano nową metodę **GetRect()** , która umożliwia pobranie prostokąta granic akapitu.

``` cpp
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Uzyskiwanie rozmiaru akapitu i fragmentu wewnątrz tekstowego pola komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Portion](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.portion) lub [Paragraph](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.paragraph) w tekstowym polu komórki tabeli, możesz użyć metod [IPortion::GetRect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) i [IParagraph::GetRect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Ten przykładowy kod demonstruje opisaną operację:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**W jakich jednostkach zwracane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie wyrazów wpływa na granice akapitu?**

Tak. Jeśli [wrapping](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframeformat/set_wraptext/) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/), tekst jest dzielony, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele używając: pixels = points × (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI przy renderowaniu/eksportowaniu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, biorąc pod uwagę dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/cpp/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.
---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/cpp/examples/elements/text-box/
keywords:
- przykład kodu
- pole tekstowe
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj z polami tekstowymi w Aspose.Slides dla C++: dodawaj, formatuj, wyrównuj, zawijaj, automatycznie dopasowuj i stylizuj tekst przy użyciu C++ w prezentacjach PPT, PPTX i ODP."
---
W Aspose.Slides **pole tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

## **Dodaj pole tekstowe**

Pole tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z pewnym sformatowanym tekstem. Oto jak je utworzyć:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Utwórz prostokątny kształt (domyślnie wypełniony obramowaniem i bez tekstu).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pole tekstowe.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ustaw formatowanie tekstu.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Przypisz rzeczywistą treść tekstu.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Uwaga:** Każde `AutoShape`, które zawiera niepusty `TextFrame`, może pełnić funkcję pola tekstowego.

## **Dostęp do pól tekstowych według zawartości**

Aby znaleźć wszystkie pola tekstowe zawierające określone słowo kluczowe (np. „Slide”), przeiteruj kształty i sprawdź ich tekst:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Tylko AutoShape mogą zawierać edytowalny tekst.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Zrób coś z pasującym polem tekstowym.
            }
        }
    }

    presentation->Dispose();
}
```

## **Usuwanie pól tekstowych według zawartości**

Ten przykład znajduje i usuwa wszystkie pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Wskazówka:** Zawsze twórz kopię kolekcji kształtów przed jej modyfikacją podczas iteracji, aby uniknąć błędów związanych z modyfikacją kolekcji.
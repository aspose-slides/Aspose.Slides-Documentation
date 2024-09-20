---
title: Параграф
type: docs
weight: 60
url: /cpp/paragraph/
---

## **Получение координат параграфа и порции в TextFrame**
С помощью Aspose.Slides для C++ разработчики теперь могут получать прямоугольные координаты для параграфа внутри коллекции параграфов TextFrame. Это также позволяет получить координаты порции внутри коллекции порций параграфа. В этой теме мы собираемся продемонстрировать с помощью примера, как получить прямоугольные координаты для параграфа вместе с положением порции внутри параграфа.

## **Получение прямоугольных координат параграфа**
Новый метод **GetRect()** был добавлен. Он позволяет получить прямоугольник границ параграфа.

``` cpp
// Создание объекта Presentation, представляющего файл презентации
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Получение размера параграфа и порции внутри текстового фрейма ячейки таблицы** ##

Чтобы получить размер и координаты [Порции](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) или [Параграфа](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) в текстовом фрейме ячейки таблицы, вы можете использовать методы [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) и [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Этот пример кода демонстрирует описанную операцию:

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
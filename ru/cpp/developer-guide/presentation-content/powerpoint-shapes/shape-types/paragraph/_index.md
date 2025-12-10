---
title: Получить границы абзаца в презентациях на C++
linktitle: Абзац
type: docs
weight: 60
url: /ru/cpp/paragraph/
keywords:
- границы абзаца
- границы текстового фрагмента
- координата абзаца
- координата фрагмента
- размер абзаца
- размер текстового фрагмента
- текстовый фрейм
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстового фрагмента в Aspose.Slides для C++, чтобы оптимизировать размещение текста в презентациях PowerPoint."
---

## **Получить координаты абзаца и фрагмента в TextFrame**
Используя Aspose.Slides for C++, разработчики теперь могут получать прямоугольные координаты абзаца внутри коллекции абзацев TextFrame. Это также позволяет получать координаты фрагмента внутри коллекции фрагментов абзаца. В этом разделе мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с позицией фрагмента внутри абзаца.

## **Получить прямоугольные координаты абзаца**
Добавлен новый метод **GetRect()**. Он позволяет получить ограничивающий прямоугольник абзаца.
``` cpp
// Создайте объект Presentation, представляющий файл презентации
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **Получить размер абзаца и фрагмента внутри TextFrame ячейки таблицы**

Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) или [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) в TextFrame ячейки таблицы, можно использовать методы [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) и [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

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


## **FAQ**

**В каких единицах измеряются координаты, возвращаемые для абзаца и фрагментов текста?**

В пунктах, где 1 дюйм = 72 пункта. Это применимо ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если включено [wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) в [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/), текст разбивается по ширине области, что меняет фактические границы абзаца.

**Можно ли надежно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Переведите пункты в пиксели с помощью формулы: pixels = points × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/cpp/shape-effective-properties/); он возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и прочих параметров.
---
title: Получить границы абзаца из презентаций на C++
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/cpp/paragraph-bounds/
keywords:
- границы абзаца
- координата абзаца
- размер абзаца
- текстовый фрейм
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для C++ для оптимизации позиционирования текста в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как получить границы, размер и координаты абзацев в Aspose.Slides. Показано, как получить прямоугольник абзаца из [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) с помощью [IParagraph::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getrect/), как получить координаты абзаца внутри текстового фрейма ячейки таблицы, а также выделены важные детали, такие как единицы измерения, влияние переноса текста на границы, преобразование пикселей и эффективные значения форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [IParagraph::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getrect/) чтобы получить ограничивающий прямоугольник абзаца.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Получить размер абзаца внутри текстового фрейма ячейки таблицы**

Чтобы получить размер и координаты [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) в текстовом фрейме ячейки таблицы, используйте [IParagraph::GetRect](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/getrect/). Возвращаемый прямоугольник относится к текстовому фрейму ячейки таблицы, поэтому при необходимости координат уровня слайда добавьте позицию таблицы и смещение ячейки.

Следующий пример получает границы абзаца внутри ячейки таблицы и рисует прямоугольники на слайде для визуализации этих границ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**В каких единицах измеряются координаты абзаца?**

Они измеряются в пунктах, где 1 дюйм равен 72 пунктам. Это касается всех координат и размеров на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) включено [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_wraptext/), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца пикселям в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI при рендеринге или экспорте.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/cpp/shape-effective-properties/); он возвращает окончательные агрегированные значения отступов, интервалов, переноса, RTL и прочего.
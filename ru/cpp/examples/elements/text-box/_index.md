---
title: Текстовое поле
type: docs
weight: 40
url: /ru/cpp/examples/elements/text-box/
keywords:
- пример кода
- текстовое поле
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Работайте с текстовыми полями в Aspose.Slides для C++: добавляйте, форматируйте, выравнивайте, переносите, автоматически подгоняйте и стилизуйте текст с помощью C++ для презентаций PPT, PPTX и ODP."
---
В Aspose.Slides **текстовое поле** представлено объектом `AutoShape`. Практически любую форму можно заполнить текстом, но типичное текстовое поле не имеет заливки и границы и отображает только текст.

В этом руководстве объясняется, как программно добавлять, получать доступ и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы с некоторым форматированным текстом. Ниже показано, как создать его:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Создать прямоугольную форму (по умолчанию заполнена границей и без текста).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Удалить заливку и границу, чтобы выглядеть как типичное текстовое поле.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Установить форматирование текста.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Назначить фактическое текстовое содержимое.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Получить текстовые поля по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, "Slide"), пройдитесь по всем фигурам и проверьте их текст:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
            // Только AutoShapes могут содержать редактируемый текст.
            if (ObjectExt::Is<IAutoShape>(shape))
            {
                auto autoShape = ExplicitCast<IAutoShape>(shape);
                auto text = autoShape->get_TextFrame()->get_Text();
                if (text.Contains(u"Slide"))
                {
                    // Сделать что‑то с соответствующим текстовым полем.
                }
            }
    }

    presentation->Dispose();
}
```

## **Удалить текстовые поля по содержимому**

В этом примере находятся и удаляются все текстовые поля на первом слайде, которые содержат определённое ключевое слово:

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

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время перебора, чтобы избежать ошибок изменения коллекции.
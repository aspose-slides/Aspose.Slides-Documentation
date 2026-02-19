---
title: Мастер‑слайд
type: docs
weight: 30
url: /ru/cpp/examples/elements/master-slide/
keywords:
- пример кода
- мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Изучите примеры мастер‑слайдов Aspose.Slides for C++: создание, редактирование и оформление мастеров, заполнителей и тем в PPT, PPTX и ODP с понятным кодом C++."
---
Главные слайды образуют верхний уровень иерархии наследования слайдов в PowerPoint. **Мастер‑слайд** определяет общие элементы дизайна, такие как фоны, логотипы и форматирование текста. **Слайды‑макета** наследуются от мастер‑слайдов, а **обычные слайды** наследуются от слайдов‑макета.

В этой статье демонстрируется, как создавать, изменять и управлять мастер‑слайдами с помощью Aspose.Slides for C++.

## **Добавить мастер‑слайд**

В этом примере показано, как создать новый мастер‑слайд, клонировав стандартный. Затем он добавляет баннер с названием компании ко всем слайдам через наследование макета.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Клонировать стандартный мастер‑слайд.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Добавить баннер с названием компании в верхнюю часть мастер‑слайда.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Присвоить новый мастер‑слайд слайду‑макету.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Присвоить слайд‑макет первому слайду в презентации.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Примечание 1:** Мастер‑слайды позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения, внесённые в мастер, автоматически отразятся на зависимых макетах и обычных слайдах.
> 💡 **Примечание 2:** Любые фигуры или форматирование, добавленные в мастер‑слайд, наследуются слайдами‑макета и, в свою очередь, всеми обычными слайдами, использующими эти макеты.
> Изображение ниже иллюстрирует, как текстовое поле, добавленное в мастер‑слайд, автоматически отображается на конечном слайде.

![Пример наследования мастер‑слайда](master-slide-banner.png)

## **Получить доступ к мастер‑слайду**

Вы можете получить доступ к мастер‑слайдам, используя коллекцию мастеров презентации. Ниже показано, как извлекать их и работать с ними:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Изменить тип фона.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Удалить мастер‑слайд**

Мастер‑слайды можно удалять как по индексу, так и по ссылке.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Удалить мастер‑слайд по индексу.
    presentation->get_Masters()->RemoveAt(0);

    // Удалить мастер‑слайд по ссылке.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Удалить неиспользуемые мастер‑слайды**

Некоторые презентации содержат мастер‑слайды, которые не используются. Удаление этих слайдов может помочь уменьшить размер файла.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Удалить все неиспользуемые мастер‑слайды (даже те, которые помечены как Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```
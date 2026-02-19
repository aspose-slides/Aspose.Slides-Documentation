---
title: Заголовок и нижний колонтитул
type: docs
weight: 220
url: /ru/cpp/examples/elements/header-footer/
keywords:
- пример кода
- заголовок
- нижний колонтитул
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами слайдов с помощью Aspose.Slides for C++: добавляйте даты, номера слайдов и пользовательский текст в PPT, PPTX и ODP с примерами на C++."
---
В этой статье демонстрируется, как добавить нижние колонтитулы и обновить заполнители даты и времени с использованием **Aspose.Slides for C++**.

## **Добавить нижний колонтитул**

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Обновить дату и время**

Измените заполнитель даты и времени на слайде.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```
---
title: Диаграмма
type: docs
weight: 60
url: /ru/cpp/examples/elements/chart/
keywords:
- пример кода
- диаграмма
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте работу с диаграммами в Aspose.Slides for C++: создавайте, форматируйте, связывайте данные и экспортируйте диаграммы в PPT, PPTX и ODP с примерами на C++."
---
Примеры добавления, доступа, удаления и обновления различных типов диаграмм с помощью **Aspose.Slides for C++**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## **Добавить диаграмму**

Этот метод добавляет простую диаграмму с областями на первый слайд.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавить простую диаграмму области на первый слайд.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Получить доступ к диаграмме**

После создания диаграммы вы можете получить её через коллекцию фигур.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Получить доступ к первой диаграмме на слайде.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Удалить диаграмму**

Следующий код удаляет диаграмму со слайда.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Удалить диаграмму.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Обновить данные диаграммы**

Вы можете изменить свойства диаграммы, такие как заголовок.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Изменить заголовок диаграммы.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```
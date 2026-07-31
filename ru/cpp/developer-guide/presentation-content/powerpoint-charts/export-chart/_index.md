---
title: Экспорт диаграмм презентаций в C++
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/cpp/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечение изображения диаграммы
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для C++, поддерживая форматы PPT и PPTX, и оптимизировать создание отчетов в любом рабочем процессе."
---
## **Обзор**

Aspose.Slides позволяет экспортировать диаграмму из презентации в виде изображения. Эта статья показывает, как получить изображение диаграммы и сохранить его, что полезно, когда нужно использовать визуальные элементы диаграммы вне презентации PowerPoint.

## **Получить изображение диаграммы**
Aspose.Slides for C++ предоставляет поддержку извлечения изображения конкретной диаграммы. Ниже приведён пример.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/writeassvg/).

**Как установить точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, которые позволяют указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если шрифты в метках и легенде отображаются некорректно после экспорта?**

[Загрузите необходимые шрифты](/slides/ru/cpp/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Учитывает ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides следует форматированию презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите раздел экспорта в [API](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/)/[documentation](/slides/ru/cpp/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), и т.д.) и связанных параметров рендеринга.
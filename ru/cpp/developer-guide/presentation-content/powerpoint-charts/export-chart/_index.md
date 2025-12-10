---
title: Экспорт диаграмм презентации в C++
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
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для C++, поддерживая форматы PPT и PPTX, и упростите создание отчетов в любой рабочий процесс."
---

## **Получить изображение диаграммы**
Aspose.Slides для C++ предоставляет возможность извлекать изображение конкретной диаграммы. Ниже приведён пример.  
```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**Могу ли я экспортировать диаграмму как вектор (SVG) вместо растрового изображения?**

Да. Диаграмма — это shape, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).

**Как я могу задать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, позволяющие указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если шрифты в подписи и легенде выглядят неправильно после экспорта?**

[Загрузите необходимые шрифты](/slides/ru/cpp/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Сохраняет ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides учитывает форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где я могу найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите раздел экспорта в [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[документации](/slides/ru/cpp/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), и т.д.) и связанные параметры рендеринга.
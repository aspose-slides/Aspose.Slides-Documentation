---
title: Настройка легенд диаграмм в презентациях с помощью Python
linktitle: Легенда диаграммы
type: docs
url: /ru/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для Python через .NET, чтобы оптимизировать презентации PowerPoint и OpenDocument с индивидуальным форматированием легенд."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над легендами диаграмм, позволяя сделать подписи данных понятными и готовыми к показу. Вы можете показывать или скрывать легенду, выбирать её позицию на слайде и настраивать макет, чтобы избежать перекрытия области построения. API позволяет стилизовать текст и маркеры, точно настраивать отступы и фон, а также форматировать границы и заливки в соответствии с вашей темой. Разработчики также могут получить доступ к отдельным элементам легенды, переименовывать их или фильтровать, обеспечивая отображение только наиболее релевантных рядов. Благодаря этим возможностям ваши диаграммы остаются читабельными, согласованными и соответствующими стандартам дизайна презентаций.

## **Позиционирование легенды**

С помощью Aspose.Slides вы можете быстро управлять тем, где появляется легенда диаграммы и как она вписывается в макет слайда. Узнайте, как точно разместить легенду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте диаграмму на слайд.
1. Задайте свойства легенды.
1. Сохраните презентацию в файл PPTX.

В примере ниже задаются позиция и размер легенды диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка размера шрифта легенды**

Легенда диаграммы должна быть так же читаема, как и данные, которые она поясняет. В этом разделе показано, как настроить размер шрифта легенды, чтобы он соответствовал типографике вашей презентации и улучшал доступность.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Создайте диаграмму.
1. Установите размер шрифта.
1. Сохраните презентацию в файл.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка размера шрифта для отдельного элемента легенды**

Aspose.Slides позволяет точно настроить внешний вид легенд, форматируя отдельные элементы. В примере ниже показано, как выбрать конкретный элемент легенды и задать его свойства, не меняя остальные элементы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Создайте диаграмму.
1. Получите доступ к элементу легенды.
1. Задайте свойства элемента.
1. Сохраните презентацию в файл.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли включить легенду так, чтобы диаграмма автоматически выделяла место для неё, а не накладывалась?**

Да. Используйте режим без наложения ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); в этом случае область построения уменьшится, чтобы разместить легенду.

**Можно ли сделать многострочные подписи в легенде?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные переносы поддерживаются символами новой строки в названии ряда.

**Как заставить легенду следовать цветовой схеме темы презентации?**

Не задавайте явные цвета/заполнения/шрифты для легенды и её текста. Тогда они наследуются из темы и корректно обновляются при изменении дизайна.
---
title: Настройка легенд диаграмм в презентациях с Python
linktitle: Легенда диаграммы
type: docs
url: /ru/python-net/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для Python через .NET, чтобы оптимизировать презентации PowerPoint и OpenDocument, используя индивидуальное форматирование легенд."
---

## **Обзор**

Aspose.Slides for Python предоставляет полный контроль над легендами диаграмм, позволяя делать подписи данных ясными и готовыми к презентации. Вы можете показывать или скрывать легенду, выбирать её позицию на слайде и настраивать макет, чтобы избежать наложения на область построения. API позволяет оформлять текст и маркеры, точно регулировать отступы и фон, а также задавать границы и заливки в соответствии с вашей темой. Разработчики также могут получать доступ к отдельным элементам легенды для переименования или фильтрации, гарантируя отображение только наиболее релевантных рядов. Благодаря этим возможностям ваши диаграммы остаются читаемыми, согласованными и соответствуют стандартам дизайна презентации.

## **Расположение легенды**

С помощью Aspose.Slides вы можете быстро управлять тем, где появляется легенда диаграммы и как она вписывается в макет слайда. Узнайте, как точно разместить легенду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд.
1. Добавьте диаграмму на слайд.
1. Установите свойства легенды.
1. Сохраните презентацию в файл PPTX.

В примере ниже мы задаём позицию и размер легенды диаграммы:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Получите ссылку на слайд.
    slide = presentation.slides[0]

    # Добавьте кластеризованную столбчатую диаграмму на слайд.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Установите свойства легенды.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Сохраните презентацию на диск.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить размер шрифта легенды**

Легенда диаграммы должна быть столь же читаемой, как и отображаемые данные. В этом разделе показано, как изменить размер шрифта легенды, чтобы он соответствовал типографике вашей презентации и повышал доступность.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Создайте диаграмму.
1. Установите размер шрифта.
1. Сохраните презентацию на диск.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить размер шрифта для элемента легенды**

Aspose.Slides позволяет точно настраивать внешний вид легенд диаграмм, форматируя отдельные элементы. Пример ниже демонстрирует, как выбрать конкретный элемент легенды и задать его свойства без изменения остальных элементов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Создайте диаграмму.
1. Получите доступ к элементу легенды.
1. Установите свойства элемента.
1. Сохраните презентацию на диск.
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

**Могу ли я включить легенду так, чтобы диаграмма автоматически выделяла для неё место, а не накладывала её?**

Да. Используйте режим без наложения ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); в этом случае область построения сократится, чтобы разместить легенду.

**Можно ли сделать многострочные подписи в легенде?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные разрывы строки поддерживаются символами новой строки в имени ряда.

**Как заставить легенду следовать цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Тогда они будут наследоваться из темы и корректно обновятся при изменении дизайна.
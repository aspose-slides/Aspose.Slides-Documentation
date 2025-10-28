---
title: Настройка легенд диаграмм в презентациях с помощью Python
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
description: "Настройте легенды диаграмм с помощью Aspose.Slides для Python через .NET, чтобы оптимизировать презентации PowerPoint и OpenDocument с индивидуальным форматированием легенд."
---

## **Обзор**

Aspose.Slides для Python предоставляет полный контроль над легендами диаграмм, позволяя делать подписи данных понятными и готовыми к презентации. Вы можете показывать или скрывать легенду, выбирать её положение на слайде и регулировать макет, чтобы избежать перекрытия с областью графика. API позволяет оформлять текст и маркеры, точно настраивать отступы и фон, а также формировать границы и заливки в соответствии с вашей темой. Разработчики также могут получать доступ к отдельным элементам легенды для переименования или фильтрации, обеспечивая отображение только самых релевантных рядов. Благодаря этим возможностям ваши диаграммы остаются читаемыми, согласованными и соответствуют стандартам дизайна презентации.

## **Позиционирование легенды**

С помощью Aspose.Slides вы можете быстро управлять тем, где появляется легенда диаграммы и как она вписывается в макет слайда. Узнайте, как точно разместить легенду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Добавьте диаграмму на слайд.
4. Установите свойства легенды.
5. Сохраните презентацию как файл PPTX.

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

## **Установить размер шрифта легенды**

Легенда диаграммы должна быть так же читаема, как и данные, которые она объясняет. В этом разделе показано, как изменить размер шрифта легенды, чтобы он соответствовал типографии вашей презентации и повышал доступность.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте диаграмму.
3. Установите размер шрифта.
4. Сохраните презентацию на диск.

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

Aspose.Slides позволяет точно настраивать внешний вид легенд диаграмм, форматируя отдельные элементы. Пример ниже показывает, как выбрать конкретный элемент легенды и задать его свойства, не изменяя остальную часть легенды.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте диаграмму.
3. Получите элемент легенды.
4. Установите свойства элемента.
5. Сохраните презентацию на диск.

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

## **Вопросы и ответы**

**Могу ли я включить легенду так, чтобы диаграмма автоматически выделяла для неё место, а не накладывала её поверх?**

Да. Используйте режим без наложения ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); в этом случае область графика уменьшится, чтобы разместить легенду.

**Могу ли я сделать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные разрывы строк поддерживаются символами новой строки в имени ряда.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Тогда они будут наследоваться из темы и корректно обновляться при изменении дизайна.
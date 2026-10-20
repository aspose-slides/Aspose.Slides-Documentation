---
title: Рабочее решение проблемы изменения размера диаграммы в PPTX
type: docs
weight: 60
url: /ru/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE-объект
- встраивание диаграммы
- PowerPoint
- презентация
- Python через .NET
- Python
- Aspose.Slides
description: "Устраните неожиданное изменение размера диаграммы в PPTX при использовании встроенных OLE-объектов Excel с Aspose.Slides для Python через .NET. Установите фиксированные размеры диаграммы, чтобы сохранить согласованность размеров диаграммы и рамки OLE."
---
## **Обзор**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут менять размер после их первой активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размера, и показывается, как предотвратить его, сопоставив фиксированные размеры диаграммы с рамкой OLE.

В [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Python via .NET и встроить её в презентацию PowerPoint с помощью Aspose.Slides for Python via .NET. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/python-net/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы рамке OLE‑объекта диаграммы. В результирующей презентации, когда вы дважды щёлкните по рамке OLE‑объекта, отображающей изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную книгу Excel, а затем вернуть‑ся к слайду, щёлкнув за пределами активированной книги. Размер рамки OLE‑объекта меняется, когда пользователь возвращается к слайду, и коэффициент изменения зависит от исходных размеров как рамки OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Рамка OLE на слайде имеет независимо определённые размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе внедрения. Различия между окном книги и рамкой OLE могут приводить к изменению размера объекта.

## **Рабочее решение**

Сопоставьте размер диаграммы с рамкой OLE на слайде и сделайте размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Пример требует Aspose.Cells for Python via .NET и Aspose.Slides for Python via .NET. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Изображение предварительного просмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑рамкой размером 9,5 × 4 дюйма, расположенной на 0,5 дюйма от левого края и 1 дюйм от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта = 1 дюйм). Для существующей презентации смотрите [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) в false, чтобы размеры диаграммы были независимы от окна книги. Задайте размеры [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) через [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) и [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), преобразовывая пункты в пиксели при 96 пикселях на дюйм: рамка 684 × 288 пунктов соответствует диаграмме 912 × 384 пикселей. Установите [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) в значение CUSTOM перечисления [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Пример встраивает книгу с помощью [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) и сохраняет презентацию с OLE‑рамкой размером 9,5 × 4 дюйма.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм).
    width = 684.0  # 9,5 дюйма.
    height = 288.0  # 4 дюйма.

    chart.size_with_window = False
    # Преобразуйте пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Использовать шаблон**

Логика размеров одинакова для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.  
2. Убедитесь, что на первом слайде есть как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.  
3. Возьмите ширину и высоту рамки из этой фигуры вместо фиксированных значений 684 и 288. Оставьте расчёты размеров без изменений.  
4. Добавьте OLE‑рамку в положение заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **Часто задаваемые вопросы**

**Почему моя встроенная диаграмма Excel меняет размер после её активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как рамка OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может приводить к изменению размеров.

**Как сохранить согласованность размеров диаграммы и рамки OLE?**

Установите фиксированные размеры диаграммы, соответствующие рамке OLE, и используйте пользовательский размер печати диаграммы перед встраиванием книги. Пример выше показывает необходимые настройки и преобразования единиц.

**Достаточно ли согласовать размер окна книги?**

Только согласование размера окна книги не гарантирует предотвращения изменения размеров рамки OLE после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как с шаблонными, так и с новыми презентациями?**

Да. Для шаблона используйте размеры и положение заполнителя. Для новой презентации укажите размеры и положение рамки напрямую.

**Можно ли использовать этот пример с диаграммами, созданными в других табличных программах?**

Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ru/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
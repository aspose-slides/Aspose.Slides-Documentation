---
title: Рабочая тетрадь диаграмм
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "Рабочая тетрадь диаграмм, данные диаграмм, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Рабочая тетрадь диаграмм в презентации PowerPoint на Python"
---

## **Установите данные диаграммы из рабочей тетради**

Aspose.Slides предоставляет некоторые методы, которые позволяют читать и записывать данные диаграмм из рабочих тетрадей (содержащих данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграмм должны быть организованы таким же образом или иметь структуру, аналогичную исходной.

Этот код на Python демонстрирует пример операции:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, который представляет файл презентации 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "Значение ячейки Метки 0")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "Значение ячейки Метки 1")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "Значение ячейки Метки 2")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Установите ячейку рабочей тетради как метку данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте круговую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграмм.
1. Установите ячейку рабочей тетради как метку данных.
1. Сохраните презентацию.

Этот код на Python показывает, как установить ячейку рабочей тетради как метку данных диаграммы: xxx

```python

```

## **Управление листами**

Этот код на Python демонстрирует операцию, в которой свойство `worksheets` используется для доступа к коллекции листов:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **Укажите тип источника данных**

Этот код на Python показывает, как указать тип для источника данных: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "LiteralString"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Внешняя рабочая тетрадь**

{{% alert color="primary" %}} 
В [Aspose.Slides для .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/) мы реализовали поддержку внешних рабочих тетрадей в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создать внешнюю рабочую тетрадь**

Используя некоторые методы из **`IChartData`**, вы можете либо создать внешнюю рабочую тетрадь с нуля, либо сделать внутреннюю рабочую тетрадь внешней.

Этот код на Python демонстрирует процесс создания внешней рабочей тетради:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **Установить внешнюю рабочую тетрадь**

С помощью метода **`chartData.set_external_workbook`** вы можете присвоить внешнюю рабочую тетрадь диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей тетради (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих тетрадях, хранящихся в удаленных расположениях или ресурсах, вы все еще можете использовать такие рабочие тетради в качестве внешнего источника данных. Если предоставлен относительный путь для внешней рабочей тетради, он автоматически преобразуется в полный путь.

Этот код на Python показывает, как установить внешнюю рабочую тетрадь:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# Путь к каталогу документов.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `chart_data` (в методе `set_external_workbook`) используется для указания, будет ли загружена Excel-рабочая тетрадь или нет. 

* Если значение `chart_data` установлено в `false`, только путь к рабочей тетради обновляется — данные диаграммы не будут загружены или обновлены из целевой рабочей тетради. Вы можете использовать эту настройку в ситуации, когда целевая рабочая тетрадь отсутствует или недоступна. 
* Если значение `chart_data` установлено в `true`, данные диаграммы обновляются из целевой рабочей тетради.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Получить путь к внешней рабочей тетради источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных диаграммы.
1. Укажите соответствующее условие, основываясь на том, что тип источника совпадает с типом источника данных внешней рабочей тетради.

Этот код на Python демонстрирует операцию:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих тетрадях так же, как и в содержимом внутренних рабочих тетрадей. Когда внешняя рабочая тетрадь не может быть загружена, возникает исключение.

Этот код на Python является реализацией описанного процесса:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```
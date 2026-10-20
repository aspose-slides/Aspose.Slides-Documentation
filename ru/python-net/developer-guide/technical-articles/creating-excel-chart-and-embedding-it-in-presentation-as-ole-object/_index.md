---
title: Создание диаграмм Excel и их встраивание в презентации в виде OLE-объектов
type: docs
weight: 50
url: /ru/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Диаграмма Excel
- встроить диаграмму
- OLE-объект
- PowerPoint
- презентация
- Python
- Python через .NET
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells for Python via .NET и встроите книгу в презентацию PowerPoint с Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for Python via .NET и встроить её книгу в презентацию PowerPoint с помощью Aspose.Slides for Python via .NET. Встроенная книга содержит как исходные данные, так и диаграмму. Отдельный PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

Результатом является встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Установите пакеты `aspose-cells-python` и `aspose-slides` в своё окружение Python. Microsoft Office не требуется для генерации презентации с использованием этих библиотек.

Входные файлы не требуются: пример создаёт данные и диаграмму в памяти, а затем записывает `OutputChart.pptx` в текущий рабочий каталог. Примените лицензии для обоих продуктов при выполнении вне режима оценки.

## **Как работает встраивание**

1. Создайте книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE книги и отрендерите диаграмму в PNG.  
4. Сохраните книгу в формате XLSX в памяти и внедрите эти байты в слайд.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию в формате PPTX.

Диапазон отображения книги и рамка на слайде имеют разные назначения. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) принимает нулевые индексы начальной/конечной строки и столбца. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) же принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве границ правого нижнего угла используется индекс строки 55 и индекс столбца 25; эти значения являются выбором макета, а не количеством строк или столбцов данных.

Рамка слайда использует пункты. Пример помещает её в рамки слайда и центрирует, сохраняя соотношение сторон PNG, вместо растягивания предварительного просмотра до заполнения слайда.

## **Создание и встраивание диаграммы**

Ниже приведён полный пример, который заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбран как активный лист перед сохранением книги.

Книга явно сохраняется в формате XLSX, соответствуя расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG загружается непосредственно из потока без промежуточного преобразования в bitmap. Присвоение его через [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) заменяет стандартный заполнитель OLE.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Отрисовать предварительный просмотр диаграммы и отдельно сериализовать редактируемую книгу.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Поместить предварительный просмотр в слайд без изменения его соотношения сторон.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд со встроенной книгой Excel и предварительным просмотром диаграммы. Книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel дважды щёлкните объект, чтобы активировать и отредактировать встроенную книгу. Активация и редактирование зависят от поддержки OLE в приложении‑хосте и настроек безопасности.

## **Часто задаваемые вопросы**

**Зачем требуется изображение предварительного просмотра?**

Встроенная книга и её предварительный просмотр на слайде — это отдельное содержимое. Предоставьте изображение диаграммы, чтобы на слайде отображалась диаграмма вместо стандартного заполняющего текста "EMBEDDED OLE OBJECT". См. [Object Preview Issue when Adding OleObjectFrame](/slides/ru/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении книги в коде?**

Считайте предварительный просмотр снимком. При программном обновлении данных книги заново генерируйте изображение диаграммы и заменяйте как предварительный просмотр, так и данные встроенной книги.

**Можно ли использовать XLS вместо XLSX?**

Да. Сохраните книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать реальному формату книги; изменение только расширения не конвертирует данные.

**Почему объект может изменить размер после активации?**

Приложение‑хост может обновить отображение OLE‑объекта при активации книги. На это влияют как диапазон отображения OLE книги, так и размеры рамки слайда. См. [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/ru/python-net/working-solution-for-worksheet-resizing/).

## **Связанные разделы**

- [Автоматическое изменение размера OLE‑объектов в презентациях PowerPoint](/slides/ru/python-net/working-solution-for-worksheet-resizing/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Управление OLE‑объектами](/slides/ru/python-net/manage-ole/)
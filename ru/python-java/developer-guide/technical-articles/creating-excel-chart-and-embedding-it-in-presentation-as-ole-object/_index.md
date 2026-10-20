---
title: Создание диаграмм Excel и их встраивание в презентации как OLE‑объекты
type: docs
weight: 30
url: /ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- диаграмма Excel
- встроить диаграмму
- OLE‑объект
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells for Python via Java и встроите книгу в презентацию PowerPoint с помощью Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for Python via Java и встроить её книгу в презентацию PowerPoint с помощью Aspose.Slides for Python via Java. Встроенная книга содержит как исходные данные, так и диаграмму. Отдельное PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

В результате получаем встроенный объект Excel, а не нативную диаграмму PowerPoint. Для редактирования книги через OLE требуется настольное приложение, поддерживающее активацию OLE, и совместимая установка Excel.

## **Требования**

Установите Python‑пакеты `aspose-cells` и `aspose-slides-java` и совместимую среду выполнения Java. Импортируйте оба пакета до запуска JVM, чтобы их Java‑библиотеки были доступны через JPype. Для создания презентации с помощью этих библиотек Microsoft Office не требуется.

Входные файлы не нужны: пример создает данные и диаграмму в памяти, затем записывает `OutputChart.pptx` в текущий рабочий каталог. Примените лицензии для обоих продуктов при работе вне режима оценки.

## **Как работает встраивание**

1. Создайте книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE книги и отрендерите диаграмму в PNG.  
4. Сохраните книгу как XLSX в памяти и внедрите эти байты в слайд.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию как PPTX.

Диапазон отображения книги и кадр на слайде играют разные роли. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) принимает нулевые индексы начала/конца строки и столбца. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) вместо этого принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правых нижних границ используются индексы строки 55 и столбца 25; эти значения являются выбором макета, а не количеством строк или столбцов данных.

Кадр слайда использует единицы измерения в точках. Пример помещает его внутри слайда и центрирует, сохраняя соотношение сторон PNG, вместо растягивания предварительного просмотра до заполнения слайда.

## **Создание и встраивание диаграммы**

Следующий полнофункциональный пример заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбирается как активный лист перед сохранением книги.

Книга явно сохраняется как XLSX, соответствуя расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Потоки массивов байтов Java удерживают книгу и изображение в памяти и предоставляют массивы байтов, требуемые API Java. PNG загружается напрямую из байтов без промежуточного преобразования в bitmap. Назначение его через [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) заменяет стандартный заполнитель OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Отобразить предварительный просмотр диаграммы и отдельно сериализовать редактируемую книгу.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Подогнать предварительный просмотр к слайду без изменения соотношения сторон.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд со встроенной книгой Excel и предварительным просмотром диаграммы. Книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойной клик по объекту активирует и откроет встроенную книгу для редактирования. Активация и редактирование зависят от поддержки OLE и настроек безопасности хост‑приложения.

## **FAQ**

**Зачем нужен предварительный просмотр изображения?**

Встроенная книга и её предварительный просмотр на слайде представляют отдельный контент. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполнительного текста «EMBEDDED OLE OBJECT». См. [Object Preview Issue when Adding OleObjectFrame](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении книги в коде?**

Предпросмотр рассматривается как снимок. При программном обновлении данных книги необходимо заново создать изображение диаграммы и заменить как предварительный просмотр, так и данные встроенной книги.

**Можно ли использовать XLS вместо XLSX?**

Да. Сохраните книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать фактическому формату книги; изменение только расширения не преобразует данные.

**Почему объект может изменить размер после активации?**

Хост‑приложение может обновить представление OLE‑объекта при активации книги. И диапазон отображения OLE книги, и размеры кадра слайда имеют значение. См. [Working Solution for Chart Resizing in PPTX](/slides/ru/python-java/working-solution-for-chart-resizing-in-pptx/).

## **См. также**

- [Working Solution for Chart Resizing in PPTX](/slides/ru/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/)
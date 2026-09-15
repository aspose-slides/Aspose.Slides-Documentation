---
title: Рабочее решение проблемы изменения размера диаграммы в PPTX
type: docs
weight: 40
url: /ru/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE объект
- встраивание диаграммы
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграммы в PPTX при использовании встроенных OLE объектов Excel с Aspose.Slides for Python via Java. Узнайте два метода с кодом, чтобы размеры оставались согласованными."
---
## **Фон**

Было замечено, что диаграммы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, после первой активации изменяют масштаб до неопределённого значения. Это приводит к заметному визуальному различию в презентации между состоянием диаграммы до и после активации. Команда Aspose подробно изучила проблему и нашла решение. В этой статье описаны причины проблемы и соответствующее исправление.

В [предыдущая статья](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Python via Java и внедрить её в презентацию PowerPoint, используя Aspose.Slides for Python via Java. Чтобы решить [проблема предварительного просмотра объекта](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение диаграммы OLE‑объекту кадра. В готовой презентации, когда вы дважды щёлкаете по кадру OLE‑объекта, отображающему изображение диаграммы, активируется диаграмма Excel. Пользователи могут вносить любые изменения в исходную книгу Excel, а затем возвращаться к соответствующему слайду, щёлкнув вне активированного окна книги. Размер кадра OLE‑объекта меняется при возврате к слайду, и коэффициент изменения зависит от исходных размеров как кадра OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Поскольку у книги Excel собственный размер окна, при первой активации она пытается сохранить свой исходный размер. У OLE‑объекта также есть свой размер. По данным Microsoft, когда книга Excel активируется, Excel и PowerPoint согласовывают размер и поддерживают правильные пропорции в процессе встраивания. В зависимости от различий между размером окна Excel и размером или положением кадра OLE‑объекта происходит изменение размера.

## **Рабочее решение**

Существует два возможных сценария создания презентаций PowerPoint с помощью Aspose.Slides for Python via Java.

**Сценарий 1:** Создать презентацию на основе существующего шаблона.

**Сценарий 2:** Создать презентацию с нуля.

Предлагаемое решение применимо к обоим сценариям. Основа всех подходов одинакова: **размер окна встроенного OLE‑объекта должен соответствовать размеру кадра OLE‑объекта в слайде PowerPoint**. Дальше мы рассмотрим два подхода к реализации этого решения.

## **Первый подход**

В этом подходе мы узнаем, как задать размер окна встроенной книги Excel так, чтобы он совпадал с размером кадра OLE‑объекта в слайде PowerPoint.

**Сценарий 1**

Предположим, у нас есть шаблон, и мы хотим создавать презентации на его основе. В шаблоне есть фигура с индексом 2, в которую необходимо поместить кадр OLE, содержащий встроенную книгу Excel. В этом случае размер кадра OLE‑объекта предопределён — он соответствует размеру фигуры с индексом 2 в шаблоне. Всё, что нужно сделать, — установить размер окна книги, равный размеру этой фигуры. Для этого служит следующий фрагмент кода:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Загрузите книгу Excel, содержащую диаграмму.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Установите размер окна книги в дюймах (PowerPoint использует 72 пункта на дюйм).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Сохраните книгу в поток памяти.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Создайте кадр OLE‑объекта с вложенными данными Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Сценарий 2**

Допустим, мы хотим создать презентацию с нуля и добавить кадр OLE‑объекта произвольного размера с встроенной книгой Excel. В следующем фрагменте кода мы создаём кадр OLE‑объекта высотой 4 дюйма и шириной 9,5 дюйма, расположенный на слайде в точке x = 0,5 дюйма, y = 1 дюйм. Затем мы задаём окну книги Excel такие же размеры — 4 дюйма в высоту и 9,5 дюйма в ширину.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Загрузите книгу Excel, содержащую диаграмму.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 дюйма (4 * 72).
    desired_width = 684  # 9.5 дюйма (9.5 * 72).

    # Задайте размер диаграммы с окном.
    chart.setSizeWithWindow(True)

    # Установите размер окна книги в дюймах (PowerPoint использует 72 пункта на дюйм).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Сохраните книгу в поток памяти.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Создайте кадр OLE‑объекта с вложенными данными Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Второй подход**

В этом подходе мы узнаем, как задать размер диаграммы во встроенной книге Excel так, чтобы он соответствовал размеру кадра OLE‑объекта в слайде PowerPoint. Этот подход полезен, когда размер диаграммы известен заранее и не будет изменяться.

**Сценарий 1**

Предположим, у нас есть шаблон, и мы хотим создавать презентации на его основе. В шаблоне есть фигура с индексом 2, в которую мы планируем поместить кадр OLE, содержащий встроенную книгу Excel. В этом случае размер кадра OLE‑объекта предопределён — он совпадает с размером фигуры с индексом 2. Всё, что нужно сделать, — установить размер диаграммы в книге, равный размеру этой фигуры. Для этого служит следующий фрагмент кода:

```python
import jpage
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Загрузите книгу Excel, содержащую диаграмму.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Задайте размер диаграммы без окна.
    chart.setSizeWithWindow(False)

    # Установите размер диаграммы в пикселях (Excel использует 96 пикселей на дюйм).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Задайте размер печати диаграммы.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Сохраните книгу в поток памяти.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Создайте кадр OLE‑объекта с вложенными данными Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Сценарий 2**:

Допустим, мы хотим создать презентацию с нуля и добавить кадр OLE‑объекта произвольного размера с встроенной книгой Excel. В следующем фрагменте кода мы создаём кадр OLE‑объекта высотой 4 дюйма и шириной 9,5 дюйма, расположенный на слайде в точке x = 0,5 дюйма, y = 1 дюйм. Мы также задаём соответствующий размер диаграммы — высоту 4 дюйма и ширину 9,5 дюйма.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Загрузите книгу Excel, содержащую диаграмму.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 дюйма (4 * 72).
    desired_width = 684  # 9.5 дюйма (9.5 * 72).

    # Задайте размер диаграммы без окна.
    chart.setSizeWithWindow(False)

    # Установите размер диаграммы в пикселях (Excel использует 96 пикселей на дюйм).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Сохраните книгу в поток памяти.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Создайте кадр OLE‑объекта с вложенными данными Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Заключение**

Существует два подхода к исправлению проблемы изменения размера диаграммы. Выбор подхода зависит от требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений по размеру кадра OLE‑объекта.

## **FAQ**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить оригинальный размер окна при первой активации, тогда как кадр OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

**Можно ли полностью предотвратить эту проблему с изменением размера?**

Да. Согласовав размер окна книги Excel или размер диаграммы с размером кадра OLE‑объекта до встраивания, вы можете поддерживать одинаковый размер диаграммы.

**Какой подход выбрать: задавать размер окна книги или размер диаграммы?**

Используйте **Подход 1 (размер окна)**, если хотите сохранить соотношение сторон книги и, возможно, позволить последующее изменение размера.  
Используйте **Подход 2 (размер диаграммы)**, если размеры диаграммы фиксированы и не будут изменяться после встраивания.

**Будут ли эти методы работать как с шаблонными, так и с новыми презентациями?**

Да. Оба подхода работают одинаково для презентаций, созданных из шаблонов, и для презентаций, создаваемых с нуля.

**Есть ли ограничение по размеру кадра OLE‑объекта?**

Нет. Вы можете задать кадр OLE‑объекта любого размера, при условии, что он корректно масштабируется к размеру книги или диаграммы.

**Можно ли использовать эти методы с диаграммами, созданными в других табличных программах?**

Примеры рассчитаны на диаграммы Excel, созданные с помощью Aspose.Cells, но принципы применимы к другим OLE‑совместимым табличным программам, если они поддерживают аналогичные параметры размера.

## **Связанные разделы**

- [Создание диаграмм Excel и их встраивание как OLE‑объектов в презентации](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
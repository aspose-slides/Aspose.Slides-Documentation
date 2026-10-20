---
title: Рабочее решение проблемы изменения размера диаграмм в PPTX
type: docs
weight: 40
url: /ru/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE‑объект
- встраивание диаграммы
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграмм в PPTX при использовании встроенных OLE‑объектов Excel с Aspose.Slides для Python через Java. Установите фиксированные размеры диаграммы, чтобы сохранить согласованность размеров диаграммы и рамки OLE."
---
## **Предыстория**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут менять размер после их первой активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размера, и показывается, как предотвратить его, согласовав фиксированные размеры диаграммы с OLE‑рамкой.

В [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Python via Java и встроить её в презентацию PowerPoint с помощью Aspose.Slides for Python via Java. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы рамке OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щелкаете по рамке OLE‑объекта, отображающей изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги. Размер рамки OLE‑объекта меняется, когда пользователь возвращается к слайду, и коэффициент изменения зависит от исходных размеров как рамки OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Рамка OLE‑объекта на слайде имеет независимые заданные размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в рамках процесса внедрения. Различия между окном книги и рамкой OLE‑объекта могут привести к изменению размера объекта.

## **Рабочее решение**

Согласуйте размер диаграммы с рамкой OLE‑объекта на слайде и сделайте размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells for Python via Java и Aspose.Slides for Python via Java. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Изображение предварительного просмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑рамкой размером 9,5 × 4 дюйма, расположенной на полдюйма от левого края и в 1 дюйм от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм). Для существующей презентации см. [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) в значение false, чтобы размеры диаграммы были независимы от окна книги. Установите размеры [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) через [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) и [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), преобразуя пункты в пиксели при 96 пикселях на дюйм: рамка 684 × 288 пунктов соответствует диаграмме 912 × 384 пикселя. Установите [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) в значение CUSTOM перечисления [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Пример встраивает книгу с помощью [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) и сохраняет презентацию с OLE‑рамкой 9,5 × 4 дюйма.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Координаты слайда и размеры заданы в пунктах (72 пункта на дюйм).
        width = 684.0  # 9.5 дюйма.
        height = 288.0  # 4 дюйма.

        chart.setSizeWithWindow(False)
        # Преобразовать пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Использовать шаблон**

Логика определения размеров та же для существующей презентации. Чтобы адаптировать пример:

1. Загрузите презентацию‑шаблон вместо создания пустой презентации.  
2. Проверьте, что на первом слайде присутствует как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполняющего места.  
3. Возьмите ширину и высоту рамки из этой фигуры вместо фиксированных значений 684 и 288. Сохраните расчёты размеров без изменений.  
4. Добавьте OLE‑рамку в позицию заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **FAQ**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как рамка OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Как сохранить согласованность размеров диаграммы и рамки OLE‑объекта?**

Установите фиксированные размеры диаграммы, соответствующие рамке OLE‑объекта, и используйте пользовательский размер печати диаграммы перед встраиванием книги. Пример выше показывает необходимые настройки и преобразования единиц.

**Достаточно ли согласовать размер окна книги?**

Только согласование размера окна книги не гарантирует, что рамка OLE‑объекта не изменит размер после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как для шаблонных, так и для новых презентаций?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации задайте размеры и позицию рамки напрямую.

**Можно ли использовать пример с диаграммами, созданными в других табличных программах?**

Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
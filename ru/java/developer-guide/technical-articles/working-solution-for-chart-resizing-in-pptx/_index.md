---
title: Рабочее решение для изменения размера диаграмм в PPTX
type: docs
weight: 40
url: /ru/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE-объект
- встраивание диаграммы
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграмм в PPTX при использовании встроенных OLE-объектов Excel с Aspose.Slides для Java. Установите фиксированные размеры диаграммы, чтобы размеры диаграммы и OLE-кадра оставались согласованными."
---
## **Предыстория**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут менять размер после первой активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размера, и показывается, как предотвратить его, согласовав фиксированные размеры диаграммы с OLE‑кадром.

В статье [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Java и встроить её в презентацию PowerPoint с помощью Aspose.Slides for Java. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы кадру OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щёлкаете по кадру OLE‑объекта, отображающему изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной рабочей книги. Размер кадра OLE‑объекта меняется, когда пользователь возвращается к слайду, и коэффициент изменения размера зависит от исходных размеров как кадра OLE‑объекта, так и встроенной рабочей книги Excel.

## **Причина изменения размера**

Встроенная рабочая книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Кадр OLE на слайде имеет независимо определённые размеры. Когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе встраивания. Различия между окном рабочей книги и кадром OLE могут привести к изменению размера объекта.

## **Рабочее решение**

Согласуйте размер диаграммы с кадром OLE на слайде и сделайте размеры диаграммы независимыми от окна рабочей книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells for Java и Aspose.Slides for Java. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает рабочую книгу в формате XLS. Изображение предварительного просмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑кадром размером 9,5 × 4 дюйма, расположенным на 0,5 дюйма от левого края и на 1 дюйм от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта = 1 дюйм). Для существующей презентации см. раздел [Использовать шаблон](#use-a-template).

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Координаты слайда и его размеры указаны в пунктах (72 пункта на дюйм).
        float width = 684f; // 9,5 дюйма.
        float height = 288f; // 4 дюйма.

        chart.setSizeWithWindow(false);
        // Преобразуйте пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Установить фиксированный размер диаграммы**

Установите [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) в false, чтобы размеры диаграммы не зависели от окна рабочей книги. Установите размеры [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) через [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) и [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), преобразуя пункты в пиксели при 96 пикселях на дюйм: кадр размером 684 × 288 пунктов соответствует диаграмме размером 912 × 384 пикселя. Установите [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) в значение CUSTOM перечисления [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Пример встраивает рабочую книгу с помощью [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) и сохраняет презентацию с OLE‑кадром размером 9,5 × 4 дюйма.

## **Использовать шаблон**

Логика задания размеров одинаковая для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.  
2. Убедитесь, что на первом слайде есть как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.  
3. Возьмите ширину и высоту кадра из этой фигуры вместо фиксированных значений 684 и 288. Сохраните расчёты размеров без изменений.  
4. Добавьте OLE‑кадр в позицию заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **Вопросы и ответы**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить оригинальный размер окна при первой активации, тогда как кадр OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить пропорции, что может вызвать изменение размера.

**Как сохранить одинаковый размер диаграммы и OLE‑кадра?**

Установите фиксированные размеры диаграммы, соответствующие кадру OLE, и задайте пользовательский размер печати диаграммы перед встраиванием рабочей книги. В примере выше показаны необходимые настройки и преобразования единиц.

**Достаточно ли сопоставить размер окна рабочей книги?**

Сопоставление только размера окна рабочей книги надёжно не предотвращает изменение размера кадра OLE после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как с презентациями на основе шаблона, так и с новыми презентациями?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации укажите размеры и позицию кадра напрямую.

**Могу ли я использовать этот пример с диаграммами, созданными в других табличных программах?**

Пример использует рабочую книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
---
title: Рабочее решение для изменения размера диаграмм в PPTX
type: docs
weight: 40
url: /ru/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE объект
- внедрить диаграмму
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграммы в PPTX при использовании внедрённых OLE объектов Excel с Aspose.Slides for Android через Java. Установите фиксированные размеры диаграммы, чтобы размеры диаграммы и OLE кадра оставались согласованными."
---
## **Обзор**

Диаграммы Excel, внедрённые как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут менять размер после первого активации. Это может привести к заметному различию во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размера, и показывается, как предотвратить его, согласовав фиксированные размеры диаграммы с OLE‑кадром.

В статье [Создать диаграммы Excel и внедрить их как OLE‑объекты в презентации](/slides/ru/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Android через Java и внедрить её в презентацию PowerPoint, используя Aspose.Slides for Android через Java. Чтобы решить [проблема предварительного просмотра объекта](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение диаграммы кадру OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щёлкаете кадр OLE‑объекта, отображающий изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать внедрённую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги. Размер кадра OLE‑объекта меняется, когда пользователь возвращается к слайду, и коэффициент изменения размера зависит от исходных размеров как кадра OLE‑объекта, так и внедрённой книги Excel.

## **Причина изменения размера**

Внедрённая книга Excel имеет свои собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. OLE‑кадр на слайде имеет независимые размеры. Когда книга Excel активируется, Excel и PowerPoint согласуют размер объекта, чтобы сохранить его пропорции в процессе внедрения. Различия между окном книги и OLE‑кадром могут приводить к изменению размера объекта.

## **Рабочее решение**

Согласуйте размер диаграммы с OLE‑кадром на слайде и держите размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells for Android через Java и Aspose.Slides for Android через Java. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и внедряет книгу в формате XLS. Вызовите `FixedChartSize.createPresentation(getFilesDir())` из Android‑активности, чтобы сохранить результат в внутренний каталог файлов приложения. Активация OLE требует настольного PowerPoint и совместимой установки Excel. Изображение предварительного просмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑кадром размером 9,5 × 4 дюйма, расположенным на 0,5 дюйма от левого края и 1 дюйм от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм). Для существующей презентации см. [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) в false, чтобы размеры диаграммы были независимы от окна книги. Задайте размеры [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) через [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) и [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), преобразуя пункты в пиксели с помощью 96 пикселей на дюйм: кадр размером 684 × 288 пунктов соответствует диаграмме размером 912 × 384 пикселя. Установите [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) в значение CUSTOM перечисления [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). В примере книга внедряется с помощью [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) и сохраняется презентация с OLE‑кадром 9,5 × 4 дюйма.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм).
                    float width = 684f; // 9.5 дюйма.
                    float height = 288f; // 4 дюйма.

                    chart.setSizeWithWindow(false);
                    // Преобразовать пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Использовать шаблон**

Логика размеров одинаковая для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.
1. Убедитесь, что первый слайд содержит как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.
1. Возьмите ширину и высоту кадра из этой фигуры вместо фиксированных значений 684 и 288. Оставьте расчёты размеров без изменений.
1. Добавьте OLE‑кадр в положение заполнителя вместо фиксированных координат 36 и 72.
1. Удалите заполнитель перед сохранением презентации.

## **Вопросы и ответы**

**Почему моя внедрённая диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить соотношение сторон, что может приводить к изменению размера.

**Как сохранить согласованные размеры диаграммы и OLE‑кадра?**

Установите фиксированные размеры диаграммы, соответствующие OLE‑кадру, и используйте пользовательский размер печати диаграммы перед внедрением книги. Приведённый выше пример показывает необходимые настройки и преобразования единиц.

**Достаточно ли согласовать размер окна книги?**

Только согласование размера окна книги надёжно не предотвращает изменение размера OLE‑кадра после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как с презентациями на основе шаблонов, так и с новыми презентациями?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации задайте размеры и позицию кадра напрямую.

**Могу ли я использовать этот пример с диаграммами, созданными в других табличных программах?**

В примере используется книга Excel, созданная с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Создать диаграммы Excel и внедрить их как OLE‑объекты в презентации](/slides/ru/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
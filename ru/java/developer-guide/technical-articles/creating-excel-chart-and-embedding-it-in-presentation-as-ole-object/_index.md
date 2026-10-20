---
title: Создание диаграмм Excel и их внедрение в презентации в виде OLE‑объектов
type: docs
weight: 30
url: /ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- диаграмма Excel
- встраивание диаграммы
- OLE‑объект
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells for Java и внедрите рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for Java и встроить её рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides for Java. Встроенная рабочая книга содержит как исходные данные, так и диаграмму. Отдельный PNG‑превью отображает диаграмму на слайде до активации OLE‑объекта.

В результате получается встроенный объект Excel, а не нативная диаграмма PowerPoint. Для редактирования рабочей книги через OLE требуется настольное приложение, поддерживающее активацию OLE, и совместимая установка Excel.

## **Предварительные требования**

Добавьте Aspose.Cells for Java и Aspose.Slides for Java в зависимости вашего проекта. Запустите пример внутри метода Java. Для создания презентации с этими библиотеками Microsoft Office не требуется.

Входные файлы не нужны: пример создает данные и диаграмму в памяти, а затем записывает `OutputChart.pptx` в текущий рабочий каталог. Примените лицензии для обоих продуктов при работе вне режима оценки.

## **Как работает внедрение**

1. Создайте рабочую книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы рабочая книга открывалась сразу на диаграмме.  
3. Задайте диапазон отображения OLE для рабочей книги и отобразите диаграмму в PNG.  
4. Сохраните рабочую книгу как XLSX в памяти и внедрите полученные байты в слайд.  
5. Назначьте PNG в качестве превью OLE‑объекта и сохраните презентацию как PPTX.

Диапазон отображения рабочей книги и рамка на слайде выполняют разные функции. **[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-)** принимает нулевые индексы начала/конца строки и столбца. **[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-)** принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правой‑нижней границы используются индекс строки 55 и индекс столбца 25; эти значения являются выбором разметки, а не количеством строк или столбцов данных.

Рамка слайда использует пункты. Пример вписывает её в слайд и центрирует, сохраняя соотношение сторон PNG, вместо растягивания превью до заполнения слайда.

## **Создание и внедрение диаграммы**

Ниже приведён полный пример, который заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбирается как активный лист перед сохранением рабочей книги.

Рабочая книга явно сохраняется как XLSX, что соответствует расширению `xlsx`, переданному в **[OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/)**. PNG загружается напрямую из байтов без промежуточного преобразования в bitmap. Назначение его через **[getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)** заменяет стандартный заполнитель OLE.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Отрисовать превью диаграммы и отдельно сериализовать редактируемую рабочую книгу.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Поместить превью в слайд без изменения его соотношения сторон.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд со встроенной рабочей книгой Excel и превью диаграммы. Рабочая книга содержит оригинальные данные и столбчатую диаграмму с четырьмя сериями. Превью центрировано на слайде и сохраняет свои пропорции.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойной щелчок по объекту активирует и позволит отредактировать встроенную рабочую книгу. Активация и редактирование зависят от поддержки OLE хост‑приложения и его настроек безопасности.

## **FAQ**

**Зачем нужен образ превью?**

Встроенная рабочая книга и её превью на слайде — отдельный контент. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполнителья «EMBEDDED OLE OBJECT». См. **[Проблема превью объекта при добавлении OleObjectFrame](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/)**.

**Обновляется ли превью автоматически при изменении рабочей книги в коде?**

Превью рассматривается как статический снимок. При программном обновлении данных рабочей книги необходимо заново генерировать изображение диаграммы и заменять как превью, так и данные встроенной рабочей книги.

**Можно ли использовать XLS вместо XLSX?**

Да. Сохраните рабочую книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать фактическому формату рабочей книги; простая замена расширения не преобразует данные.

**Почему объект может изменить размер после активации?**

Хост‑приложение может обновлять представление OLE‑объекта при его активации. И диапазон отображения OLE рабочей книги, и размеры рамки на слайде влияют на конечный размер. См. **[Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/)**.

## **Связанные разделы**

- **[Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/)**
- **[Проблема превью объекта при добавлении OleObjectFrame](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/)**
- **[Автоматическое обновление OLE‑объектов с помощью надстройки PowerPoint](/slides/ru/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)**
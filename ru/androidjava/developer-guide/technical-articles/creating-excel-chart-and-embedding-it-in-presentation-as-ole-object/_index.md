---
title: Создать диаграммы Excel и внедрить их в презентации как OLE объекты
type: docs
weight: 30
url: /ru/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- диаграмма Excel
- встраивание диаграммы
- OLE объект
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создать диаграмму Excel с помощью Aspose.Cells for Android via Java и встроить рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides for Android via Java, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for Android via Java и встроить её рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides for Android via Java. Встроенная рабочая книга содержит как исходные данные, так и диаграмму. Отдельное PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

Результатом является встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование рабочей книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Добавьте Aspose.Cells for Android via Java и Aspose.Slides for Android via Java в зависимости вашего проекта. Вызовите `ExcelChartEmbedding.createPresentation(getFilesDir())` из активности Android. Для создания презентации с помощью этих библиотек Microsoft Office не требуется.

Входные файлы не требуются: пример создает данные и диаграмму в памяти, затем записывает `OutputChart.pptx` в внутренний каталог файлов приложения. Применяйте лицензии для обоих продуктов при запуске вне режима оценки.

## **Как работает внедрение**

1. Создайте рабочую книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы рабочая книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE рабочей книги и отрендерите диаграмму в PNG.  
4. Сохраните рабочую книгу как XLSX в памяти и внедрите эти байты в слайд.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию как PPTX.

Диапазон отображения рабочей книги и рамка на слайде имеют разные роли. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) принимает индексы строк и столбцов начала/конца, начинающиеся с нуля. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) же принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правой‑нижней границы используется индекс строки 55 и индекс столбца 25; эти значения являются вариантами разметки, а не количеством строк или столбцов данных.

Рамка слайда использует пункты. Пример помещает её внутри слайда и центрирует, сохраняя пропорции PNG, а не растягивая предварительный просмотр, чтобы заполнить слайд.

## **Создание и внедрение диаграммы**

Следующий полный пример заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится рядом диаграммы. `ChartSheet` выбран как активный лист перед сохранением рабочей книги.

Рабочая книга явно сохраняется как XLSX, соответствуя расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG загружается непосредственно из его байтов без промежуточного преобразования в bitmap. Присвоение его через [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) заменяет стандартный заполнитель OLE.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // Отобразить предварительный просмотр диаграммы и отдельно сериализовать редактируемую рабочую книгу.
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

                        // Поместить предварительный просмотр в слайд, не изменяя его соотношение сторон.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд со встроенной рабочей книгой Excel и предварительным просмотром диаграммы. Рабочая книга содержит исходные данные и столбчатую диаграмму с четырьмя рядами. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной рабочей книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойной щелчок по объекту активирует и позволяет редактировать встроенную рабочую книгу. Активация и редактирование зависят от поддержки OLE в приложении‑хосте и настроек безопасности.

## **FAQ**

**Зачем требуется изображение предварительного просмотра?**  
Встроенная рабочая книга и её предварительный просмотр на слайде — отдельный контент. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполняющего текста «EMBEDDED OLE OBJECT». См. [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении рабочей книги в коде?**  
Считайте предварительный просмотр мгновенным снимком. При программном обновлении данных рабочей книги необходимо заново сгенерировать изображение диаграммы и заменить как предварительный просмотр, так и данные встроенной рабочей книги.

**Можно ли использовать XLS вместо XLSX?**  
Да. Сохраните рабочую книгу в формате XLS и используйте `xls` в качестве расширения вложенных данных. Расширение должно соответствовать фактическому формату рабочей книги; изменение только расширения не конвертирует данные.

**Почему объект может изменять размер после активации?**  
Приложение‑хост может обновлять представление OLE‑объекта при активации рабочей книги. На размер влияют как диапазон отображения OLE рабочей книги, так и размеры рамки слайда. См. [Рабочее решение для изменения размера листа](/slides/ru/androidjava/working-solution-for-worksheet-resizing/).

## **Связанные разделы**

- [Рабочее решение для изменения размера листа](/slides/ru/androidjava/working-solution-for-worksheet-resizing/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Управление OLE](/slides/ru/androidjava/manage-ole/)
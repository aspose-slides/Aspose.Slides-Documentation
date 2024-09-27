---
title: Создание и встраивание диаграммы Excel в качестве OLE-объекта на слайде Microsoft PowerPoint
type: docs
weight: 60
url: /ru/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Диаграммы являются визуальными представлениями ваших данных и широко используются на слайдах презентаций. Эта статья покажет вам код для создания и встраивания диаграммы Excel в качестве OLE-объекта в слайде PowerPoint программно, с использованием [VSTO](/slides/ru/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides для PHP через Java](/slides/ru/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и встраивание диаграммы Excel**
Два приведенных ниже примера кода длинные и подробные, потому что задача, которую они описывают, сложна. Вы создаете книгу Microsoft Excel, создаете диаграмму, а затем создаете презентацию Microsoft PowerPoint, в которую вы будете встраивать диаграмму. OLE-объекты содержат ссылки на оригинальный документ, поэтому пользователь, дважды щелкнув на встроенном файле, откроет файл и его приложение.
### **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую книгу с одним листом.
1. Добавьте диаграмму на лист.
1. Сохраните книгу.
1. Откройте книгу Excel, содержащую рабочий лист с данными диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Получите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму с рабочего листа Excel в буфер обмена.
1. Вставьте диаграмму в презентацию PowerPoint.
1. Разместите диаграмму на слайде.
1. Сохраните презентацию.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Пример Aspose.Slides для PHP через Java**
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте книгу с использованием Aspose.Cells для Java.
1. Создайте диаграмму Microsoft Excel.
1. Установите размер OLE диаграммы Excel.
1. Получите изображение диаграммы.
1. Вставьте диаграмму Excel в качестве OLE-объекта внутри презентации PPTX с использованием Aspose.Slides для PHP через Java.
1. Замените изображение измененного объекта на изображение, полученное на шаге 3, чтобы избежать проблемы с изменением объекта.
1. Запишите итоговую презентацию на диск в формате PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
---
title: Создание и встраивание диаграммы Excel как OLE-объекта в слайд Microsoft PowerPoint
type: docs
weight: 60
url: /ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

Диаграммы являются визуальными представлениями ваших данных и широко используются в слайдах презентаций. В этой статье будет показан код для создания и встраивания диаграммы Excel как OLE-объекта в слайд PowerPoint программным способом с использованием [VSTO](/slides/ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides для Java](/slides/ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и встраивание диаграммы Excel**
Ниже приведены два примера кода, которые длительны и подробны, потому что описываемая задача является сложной. Вы создаете рабочую книгу Microsoft Excel, создаете диаграмму, а затем создаете презентацию Microsoft PowerPoint, в которую вы встроите диаграмму. OLE-объекты содержат ссылки на исходный документ, поэтому пользователь, дважды щелкнувший по встроенному файлу, откроет файл и его приложение.
### **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую рабочую книгу с одним листом.
1. Добавьте диаграмму на лист.
1. Сохраните рабочую книгу.
1. Откройте рабочую книгу Excel, содержащую таблицу с данными диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Получите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму из листа Excel в буфер обмена.
1. Вставьте диаграмму в презентацию PowerPoint.
1. Установите диаграмму на слайде.
1. Сохраните презентацию.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Пример Aspose.Slides для Java**
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте рабочую книгу с помощью Aspose.Cells для Java.
1. Создайте диаграмму Microsoft Excel.
1. Установите OLE размер диаграммы Excel.
1. Получите изображение диаграммы.
1. Встроите диаграмму Excel как OLE-объект в презентацию PPTX с помощью Aspose.Slides для Java.
1. Замените изображение измененного объекта на изображение, полученное на шаге 3, чтобы учесть проблему измененного объекта.
1. Запишите выходную презентацию на диск в формате PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
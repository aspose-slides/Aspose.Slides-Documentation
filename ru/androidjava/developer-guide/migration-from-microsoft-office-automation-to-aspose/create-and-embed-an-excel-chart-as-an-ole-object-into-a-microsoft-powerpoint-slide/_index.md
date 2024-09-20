---
title: Создание и встраивание диаграммы Excel в виде OLE-объекта в слайд Microsoft PowerPoint
type: docs
weight: 60
url: /androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Диаграммы являются визуальными представлениями ваших данных и широко используются в презентациях. В этой статье мы покажем вам код для создания и встраивания диаграммы Excel в виде OLE-объекта в слайд PowerPoint программно, используя [VSTO](/slides/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides для Android через Java](/slides/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и встраивание диаграммы Excel**
Два приведенных ниже примера кода длинные и подробные, так как описываемая задача сложная. Вы создаете книгу Microsoft Excel, добавляете диаграмму, а затем создаете презентацию Microsoft PowerPoint, в которую вы встраиваете диаграмму. OLE-объекты содержат ссылки на оригинальный документ, поэтому пользователь, дважды щелкнув по вложенному файлу, запустит файл и соответствующее приложение.
### **Пример VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создать экземпляр объекта Microsoft Excel ApplicationClass.
1. Создать новую книгу с одним листом.
1. Добавить диаграмму на лист.
1. Сохранить книгу.
1. Открыть книгу Excel с таблицей, содержащей данные диаграммы.
1. Получить коллекцию ChartObjects для листа.
1. Получить диаграмму для копирования.
1. Создать презентацию Microsoft PowerPoint.
1. Добавить пустой слайд в презентацию.
1. Скопировать диаграмму с листа Excel в буфер обмена.
1. Вставить диаграмму в презентацию PowerPoint.
1. Установить положение диаграммы на слайде.
1. Сохранить презентацию.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Пример Aspose.Slides для Android через Java**
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создать книгу с использованием Aspose.Cells для Java.
1. Создать диаграмму Microsoft Excel.
1. Установить размер OLE диаграммы Excel.
1. Получить изображение диаграммы.
1. Встроить диаграмму Excel в виде OLE-объекта внутри презентации PPTX с использованием Aspose.Slides для Android через Java.
1. Заменить изображение объекта измененного на изображение, полученное на этапе 3, чтобы учесть проблему измененного объекта.
1. Записать выходную презентацию на диск в формате PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
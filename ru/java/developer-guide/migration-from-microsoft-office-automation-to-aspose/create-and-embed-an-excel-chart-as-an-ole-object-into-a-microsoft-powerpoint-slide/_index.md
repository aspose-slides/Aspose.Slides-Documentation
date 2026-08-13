---
title: Создание и внедрение диаграмм Excel в виде OLE‑объектов с использованием VSTO и Aspose.Slides for Java
linktitle: Создание и внедрение диаграмм Excel в виде OLE‑объектов
type: docs
weight: 60
url: /ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- создать диаграмму
- внедрить диаграмму Excel
- OLE‑объект
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Мигрировать от автоматизации Microsoft Office к Aspose.Slides for Java и внедрять диаграммы Excel в виде OLE‑объектов в слайды PowerPoint (PPT, PPTX) на Java."
---
{{% alert color="info" %}} 

Диаграммы — это визуальные представления ваших данных, широко используемые в презентационных слайдах. В этой статье показан код для создания и внедрения диаграммы Excel в виде OLE‑объекта в слайд PowerPoint программно с использованием [VSTO](/slides/ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) и [Aspose.Slides for Java](/slides/ru/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Создание и внедрение диаграммы Excel**
Оба примера кода ниже длинные и подробные, потому что описываемая задача сложна. Вы создаёте книгу Microsoft Excel, создаёте диаграмму, а затем создаёте презентацию Microsoft PowerPoint, в которую внедрите диаграмму. OLE‑объекты содержат ссылки на исходный документ, поэтому пользователь, дважды щёлкнув встроенный файл, запустит файл и его приложение.
### **Пример VSTO**
При работе с VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую книгу с одним листом.
1. Добавьте диаграмму на лист.
1. Сохраните книгу.
1. Откройте книгу Excel, содержащую лист с данными диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Выберите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму с листа Excel в буфер обмена.
1. Вставьте диаграмму в презентацию PowerPoint.
1. Разместите диаграмму на слайде.
1. Сохраните презентацию.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Пример Aspose.Slides for Java**
При работе с Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте книгу с помощью Aspose.Cells for Java.
1. Создайте диаграмму Microsoft Excel.
1. Установите размер OLE‑объекта диаграммы Excel.
1. Получите изображение диаграммы.
1. Внедрите диаграмму Excel как OLE‑объект в презентацию PPTX с помощью Aspose.Slides for Java.
1. Замените изображение объекта, изменённого при вставке, изображением, полученным на шаге 3, чтобы устранить проблему изменения объекта.
1. Запишите полученную презентацию на диск в формате PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
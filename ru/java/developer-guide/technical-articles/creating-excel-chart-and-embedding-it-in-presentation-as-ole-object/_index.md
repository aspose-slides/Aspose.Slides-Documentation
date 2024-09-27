---
title: Создание диаграммы Excel и встраивание её в презентацию как OLE объект
type: docs
weight: 30
url: /ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

В слайдах PowerPoint использование редактируемых диаграмм для графического отображения данных является обычной практикой. Aspose предоставляет поддержку создания диаграмм Excel с использованием Aspose.Cells для Java, а далее эти диаграммы могут быть встроены как OLE объект в слайд PowerPoint с помощью Aspose.Slides для Java. Эта статья описывает необходимые шаги и реализацию на Java для создания и встраивания диаграммы MS Excel как OLE объекта в презентацию PowerPoint с использованием Aspose.Cells для Java и Aspose.Slides для Java.

{{% /alert %}} 
## **Необходимые шаги**
Следующая последовательность шагов необходима для создания и встраивания диаграммы Excel как OLE объекта в слайд PowerPoint:# Создание диаграммы Excel с использованием Aspose.Cells для Java.# Установка размера OLE диаграммы Excel с использованием Aspose.Cells для Java.# Получение изображения диаграммы Excel с помощью Aspose.Cells для Java.# Встраивание диаграммы Excel как OLE объекта внутри PPTX презентации с использованием Aspose.Slides для Java.# Замена изображения измененного объекта изображением, полученным на шаге 3, чтобы устранить проблему измененного объекта.# Сохранение выходной презентации на диск в формате PPTX.
## **Реализация необходимых шагов**
Реализация вышеуказанных шагов на Java представлена ниже:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

Презентация, созданная вышеуказанным методом, будет содержать диаграмму Excel как OLE объект, который можно активировать двойным щелчком на рамке OLE объекта.

{{% /alert %}} 
## **Заключение**
{{% alert color="primary" %}} 

С помощью Aspose.Cells для Java вместе с Aspose.Slides для Java мы можем создать любую из диаграмм Excel, поддерживаемых Aspose.Cells для Java, и встроить созданную диаграмму как OLE объект в слайд PowerPoint. Размер OLE диаграммы Excel также может быть определен. Конечные пользователи могут дополнительно редактировать диаграмму Excel, как любой другой OLE объект.

{{% /alert %}} 
## **Связанные разделы**
[Рабочее решение для изменения размера диаграммы](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/)

[Проблема измененного объекта](/slides/ru/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)

---
title: Создание диаграммы Excel и вставка ее в презентацию в виде OLE-объекта
type: docs
weight: 30
url: /php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

В слайдах PowerPoint использование редактируемых диаграмм для графического отображения данных является распространенной практикой. Aspose предоставляет поддержку создания диаграмм Excel с использованием Aspose.Cells для Java, и эти диаграммы можно вставить как OLE-объект в слайд PowerPoint через Aspose.Slides для PHP с использованием Java. В этой статье описываются необходимые шаги вместе с реализацией для создания и вставки диаграммы MS Excel как OLE-объекта в презентацию PowerPoint с использованием Aspose.Cells для Java и Aspose.Slides для PHP через Java.

{{% /alert %}} 
## **Необходимые шаги**
Следующая последовательность шагов необходима для создания и вставки диаграммы Excel как OLE-объекта в слайд PowerPoint:
# Создать диаграмму Excel с использованием Aspose.Cells для Java.
# Установить размер OLE для диаграммы Excel с использованием Aspose.Cells для Java.
# Получить изображение диаграммы Excel с помощью Aspose.Cells для Java.
# Вставить диаграмму Excel как OLE-объект в PPTX-презентацию с использованием Aspose.Slides для PHP через Java.
# Заменить изображение измененного объекта на изображение, полученное на шаге 3, чтобы решить проблему измененного объекта.
# Сохранить выходную презентацию на диск в формате PPTX.
## **Реализация необходимых шагов**
Реализация вышеуказанных шагов описана ниже:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

Презентация, созданная указанным выше методом, будет содержать диаграмму Excel как OLE-объект, который можно активировать двойным щелчком мыши по рамке OLE-объекта.

{{% /alert %}} 
## **Заключение**
{{% alert color="primary" %}} 

Используя Aspose.Cells для Java вместе с Aspose.Slides для PHP через Java, мы можем создать любую из диаграмм Excel, поддерживаемых Aspose.Cells для Java, и встроить созданную диаграмму как OLE-объект в слайд PowerPoint. Размер OLE диаграммы Excel также может быть определен. Конечные пользователи могут дополнительно редактировать диаграмму Excel, как и любой другой OLE-объект.

{{% /alert %}} 
## **Связанные разделы**
[Рабочее решение для изменения размера диаграммы](/slides/php-java/working-solution-for-chart-resizing-in-pptx/)

[Проблема измененного объекта](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
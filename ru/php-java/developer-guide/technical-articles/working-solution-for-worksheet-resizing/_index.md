---
title: Рабочее решение для изменения размера листа
type: docs
weight: 20
url: /php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Было замечено, что таблицы Excel, встроенные как OLE в презентацию PowerPoint через компоненты Aspose, изменяются до неопределенного масштаба после первого активации. Такое поведение создает значительное визуальное различие в презентации между состояниями до и после активации диаграммы. Мы подробно изучили эту проблему и нашли решение, которое освещается в этой статье.

{{% /alert %}} 
## **Предыстория**
В статье [Добавление OLE-рамок]() мы объяснили, как добавить OLE-рамку в презентацию PowerPoint с использованием Aspose.Slides для PHP через Java. Чтобы решить проблему [изменения объекта](/slides/php-java/object-changed-issue-when-adding-oleobjectframe/), мы привязали изображение листа выбранной области к графику OLE-объекта. В итоговой презентации, когда мы дважды щелкаем по OLE-объекту, показывающему изображение листа, активируется диаграмма Excel. Конечные пользователи могут вносить любые необходимые изменения в фактическую книгу Excel, а затем вернуться к нужному слайду, щелкнув вне активной книги Excel. Размер OLE-объекта изменится, когда пользователь вернется к слайду. Фактор изменения размера будет различаться для разных размеров OLE-объекта и встроенной книги Excel.
## **Причина изменения размера**
Поскольку у книги Excel есть свой собственный размер окна, она пытается сохранить свой первоначальный размер при первом активации. С другой стороны, OLE-объект будет иметь свой собственный размер. Согласно данным Microsoft, при активации книги Excel происходит согласование размеров между Excel и PowerPoint, чтобы гарантировать, что они находятся в правильных пропорциях в рамках операции встраивания. Основываясь на различиях в размерах окна Excel и размерах/положении OLE-объекта, происходит изменение размера.
## **Рабочее решение**
Существует два возможных решения для предотвращения эффекта изменения размера.* Изменить размер OLE-рамки в PPT, чтобы он соответствовал размеру по высоте/ширине необходимого количества строк/столбцов в OLE-рамке.* Сохранить размер OLE-рамки постоянным и адаптировать размер участковых строк/столбцов, чтобы они поместились в выбранный размер OLE-рамки.
## **Изменить размер OLE-рамки в соответствии с размером выбранных строк/столбцов листа**
В этом подходе мы узнаем, как установить размер OLE-рамки встроенной книги Excel, эквивалентный совокупному размеру числа участвующих строк и столбцов на листе Excel.
## **Пример**
Предположим, мы определили шаблонный excel-лист и хотим добавить его в презентацию в качестве OLE-рамки. В этом сценарии сначала будет рассчитан размер OLE-объекта на основе совокупной высоты строк и ширины столбцов участвующих строк и столбцов книги соответственно. Затем мы установим размер OLE-рамки на это рассчитанное значение. Чтобы избежать красного **Встроенный объект** сообщения для OLE-рамки в PowerPoint, мы также получим изображение необходимых частей строк и столбцов в книге и установим это в качестве изображения OLE-рамки.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **Изменить высоту строк на листе и ширину столбцов в соответствии с размером OLE-рамки**
В этом подходе мы узнаем, как изменить размеры высоты участвующих строк и ширины участвующих столбцов в соответствии с настраиваемым размером OLE-рамки.
## **Пример**
Предположим, мы определили шаблонный excel-лист и хотим добавить его в презентацию в качестве OLE-рамки. В этом сценарии мы установим размер OLE-рамки и изменим размеры строк и столбцов, участвующих в зоне OLE-рамки. Затем мы сохраним книгу в потоке, чтобы сохранить изменения, и преобразуем ее в массив байтов для добавления в OLE-рамку. Чтобы избежать красного **Встроенный объект** сообщения для OLE-рамки в PowerPoint, мы также получим изображение необходимых частей строк и столбцов в книге и установим это в качестве изображения OLE-рамки.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Заключение**
{{% alert color="primary" %}} 

Существует два подхода для решения проблемы изменения размера листа. Выбор подходящего подхода зависит от требований и конкретного случая. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или создаются с нуля. Также нет ограничения на размер OLE-объекта в этом решении.

{{% /alert %}}
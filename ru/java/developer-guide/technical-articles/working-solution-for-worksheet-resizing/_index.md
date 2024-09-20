---
title: Рабочее решение для изменения размера таблицы
type: docs
weight: 20
url: /java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Наблюдалось, что листы Excel, встроенные как OLE в презентацию PowerPoint через компоненты Aspose, изменяют размер до неопознанного масштаба после первого активации. Такое поведение создает значительную визуальную разницу в презентации между состояниями до и после активации диаграммы. Мы подробно исследовали эту проблему и нашли решение, которое рассматривается в этой статье.

{{% /alert %}} 
## **Фон**
В [статье о добавлении Ole рамок]() мы объяснили, как добавить Ole рамку в презентацию PowerPoint с использованием Aspose.Slides для Java. Чтобы учесть [проблему изменения объекта](/slides/java/object-changed-issue-when-adding-oleobjectframe/), мы присвоили изображение листа выбранной области OLE-объекту рамки диаграммы. В выходной презентации, когда мы дважды нажимаем на OLE-объект рамки, показывающий изображение листа, активируется диаграмма Excel. Конечные пользователи могут внести любые желаемые изменения в фактическую книгу Excel и затем вернуться к соответствующему слайду, щелкнув вне активной книги Excel. Размер OLE-объекта рамки изменится, когда пользователь вернется на слайд. Фактор изменения размера будет отличаться для разных размеров OLE-объекта рамки и встроенной книги Excel.
## **Причина изменения размера**
Поскольку книга Excel имеет свой собственный размер окна, она пытается сохранить свой оригинальный размер при первом активации. С другой стороны, OLE-объект рамки будет иметь свой размер. Согласно Microsoft, при активации книги Excel Excel и PowerPoint договариваются о размере и обеспечивают соотношение сторон в рамках операции встраивания. В зависимости от различий в размере окна Excel и размере/положении OLE-объекта рамки происходит изменение размера.
## **Рабочее решение**
Существует два возможных решения для избежания эффекта изменения размера. * Масштабируйте размер Ole рамки в PPT, чтобы он соответствовал размеру в терминах высоты/ширины необходимого количества строк/столбцов в Ole рамке * Сохраните размер Ole рамки постоянным и масштабируйте размер участвующих строк/столбцов, чтобы они соответствовали выбранному размеру Ole рамки.
## **Масштабируйте размер Ole рамки по выбранным строкам/столбцам таблицы**
В этом подходе мы узнаем, как установить размер Ole рамки встроенной книги Excel, эквивалентный кумулятивному размеру количества участвующих строк и столбцов в листе Excel.
## **Пример**
Предположим, мы определили шаблонную таблицу Excel и хотим добавить ее в презентацию как Ole рамку. В этом сценарии размер OLE-объекта рамки будет сначала рассчитан на основе кумулятивной высоты строк и ширины столбцов участвующих строк и столбцов книги соответственно. Затем мы установим размер Ole рамки на это рассчитанное значение. Чтобы избежать сообщения **Встроенный объект** для Ole рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его в качестве изображения Ole рамки.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}






## **Масштабируйте высоту строки и ширину столбца таблицы в соответствии с размером Ole рамки**
В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширину участвующего столбца в соответствии с произвольно установленным размером Ole рамки.
## **Пример**
Предположим, мы определили шаблонную таблицу Excel и хотим добавить ее в презентацию как Ole рамку. В этом сценарии мы установим размер Ole рамки и масштабируем размер строк и столбцов, участвующих в области Ole рамки. Затем мы сохраним книгу в потоке, чтобы сохранить изменения и конвертировать ее в массив байтов для добавления в Ole рамку. Чтобы избежать сообщения **Встроенный объект** для Ole рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его в качестве изображения Ole рамки.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Заключение**
{{% alert color="primary" %}} 

Существуют два подхода для решения проблемы изменения размера таблицы. Выбор подходящего метода зависит от требований и сценария. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в решении нет ограничения на размер OLE-объекта рамки.

{{% /alert %}}
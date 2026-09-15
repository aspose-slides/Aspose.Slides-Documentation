---
title: Рабочее решение изменения размера диаграмм в PPTX
type: docs
weight: 40
url: /ru/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE‑объект
- вставить диаграмму
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграмм в PPTX при использовании встроенных Excel OLE‑объектов с Aspose.Slides для Java. Узнайте два метода с примером кода, чтобы сохранить размеры согласованными."
---
## **Фон**

Было замечено, что диаграммы Excel, встроенные в презентацию PowerPoint как OLE‑объекты с помощью компонентов Aspose, после первого активации изменяют масштаб до неопределённого значения. Это приводит к заметному визуальному различию между состоянием диаграммы до и после активации. Команда Aspose подробно изучила проблему и нашла решение. В статье описываются причины проблемы и соответствующее исправление.

В [previous article](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Java и встроить её в презентацию PowerPoint с помощью Aspose.Slides for Java. Чтобы решить [object preview issue](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы объекту OLE‑кадра. В полученной презентации, когда вы дважды щёлкните по OLE‑кадру с изображением диаграммы, диаграмма Excel активируется. Пользователи могут вносить любые изменения в соответствующую книгу Excel, а затем возвращаться к нужному слайду, щёлкнув за пределами активированной книги. Размер OLE‑кадра меняется при возврате к слайду, и коэффициент изменения размера зависит от исходных размеров как OLE‑кадра, так и встроенной книги Excel.

## **Причина изменения размера**

Поскольку у книги Excel своё собственное окно, при первой активации она пытается сохранить оригинальный размер. OLE‑кадр, однако, имеет свои размеры. Согласно Microsoft, при активации книги Excel Excel и PowerPoint согласовывают размер и сохраняют правильные пропорции в процессе внедрения. В зависимости от различий между размером окна Excel и размером или позицией OLE‑кадра происходит изменение масштаба.

## **Рабочее решение**

Существует два возможных сценария создания презентаций PowerPoint с использованием Aspose.Slides for Java.

**Scenario 1:** Создание презентации на основе существующего шаблона.

**Scenario 2:** Создание презентации «с нуля».

Предложенное здесь решение подходит для обоих сценариев. Основная идея обоих подходов одинаковая: **размер окна встроенного OLE‑объекта должен совпадать с размером OLE‑кадра на слайде PowerPoint**. Далее рассматриваются два подхода к реализации этого решения.

## **Первый подход**

В этом подходе мы узнаем, как задать размер окна встроенной книги Excel так, чтобы он соответствовал размеру OLE‑кадра на слайде PowerPoint.

**Scenario 1**

Предположим, у нас есть шаблон, и мы хотим создавать презентации на его основе. В шаблоне есть фигура с индексом 2, в которой нужно разместить OLE‑кадр с вложенной книгой Excel. В этом сценарии размер OLE‑кадра заранее определён — он совпадает с размером фигуры с индексом 2 в шаблоне. Всё, что нужно сделать, — установить размер окна книги, равный размеру этой фигуры. Следующий фрагмент кода решает задачу:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Установите ширину окна книги в дюймах (делится на 72, так как PowerPoint использует 72 пункта на дюйм).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Установите высоту окна книги в дюймах.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Сохраните книгу в поток памяти.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Создайте OLE‑объектный кадр с вложенными данными Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Допустим, мы создаём презентацию с нуля и хотим добавить OLE‑кадр любого размера с вложенной книгой Excel. В следующем фрагменте кода мы создаём OLE‑кадр высотой 4 дюйма и шириной 9,5 дюйма, расположенный в точке x = 0,5 дюйма, y = 1 дюйм на слайде. Затем устанавливаем окно книги Excel того же размера — 4 дюйма в высоту и 9,5 дюйма в ширину.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Желаемая высота.
int desiredHeight = 288; // 4 дюйма (4 * 72)
 
// Желаемая ширина.
int desiredWidth = 684; // 9.5 дюйма (9.5 * 72)
 
// Задать размер диаграммы с окном.
chart.setSizeWithWindow(true);
 
// Установить ширину окна книги в дюймах (делится на 72, так как PowerPoint использует 72 пункта на дюйм).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Установить высоту окна книги в дюймах.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Сохранить книгу в поток памяти.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Создать OLE‑объектный кадр с вложенными данными Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 дюйма (0.5 * 72)
    72,  // y = 1 дюйм (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Второй подход**

В этом подходе мы узнаем, как задать размер диаграммы во вложенной книге Excel, чтобы он соответствовал размеру OLE‑кадра на слайде PowerPoint. Этот подход полезен, когда размер диаграммы известен заранее и не будет изменяться.

**Scenario 1**

Предположим, у нас есть шаблон, и мы хотим создавать презентации на его основе. В шаблоне есть фигура с индексом 2, в которой планируется разместить OLE‑кадр с вложенной книгой Excel. В этом сценарии размер OLE‑кадра заранее определён — он совпадает с размером фигуры с индексом 2 в шаблоне. Всё, что требуется, — установить размер диаграммы в книге, равный размеру этой фигуры. Следующий фрагмент кода реализует задачу:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Определить размер диаграммы без окна.
chart.setSizeWithWindow(false);
 
// Установить ширину диаграммы в пикселях (умножить на 96, так как Excel использует 96 пикселей на дюйм).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Установить высоту диаграммы в пикселях.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Задать размер печати диаграммы.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Сохранить книгу в поток памяти.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Создать OLE‑объектный кадр с вложенными данными Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

Допустим, мы создаём презентацию с нуля и хотим добавить OLE‑кадр любого размера с вложенной книгой Excel. В следующем фрагменте кода мы создаём OLE‑кадр высотой 4 дюйма и шириной 9,5 дюйма, расположенный в точке x = 0,5 дюйма, y = 1 дюйм на слайде. Мы также задаём соответствующий размер диаграммы: высота 4 дюйма, ширина 9,5 дюйма.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Желательная высота.
int desiredHeight = 288; // 4 дюйма (4 * 72)
 
// Желательная ширина.
int desiredWidth = 684; // 9.5 дюйма (9.5 * 72)
 
// Определить размер диаграммы без окна.
chart.setSizeWithWindow(false);
 
// Установить ширину диаграммы в пикселях (делить на 72 для получения дюймов, умножать на 96, так как Excel использует 96 пикселей на дюйм).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Установить высоту диаграммы в пикселях.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Сохранить книгу в поток памяти.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Создать OLE‑объектный кадр с вложенными данными Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 дюйма (0.5 * 72)
    72,  // y = 1 дюйм (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Заключение**

Существует два подхода к решению проблемы изменения размеров диаграммы. Выбор подхода зависит от требований и конкретного сценария использования. Оба подхода работают одинаково как для презентаций, созданных из шаблона, так и для презентаций, созданных с нуля. При этом отсутствуют ограничения по размеру OLE‑кадра в данном решении.

## **FAQ**

### Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?

Это происходит потому, что Excel пытается восстановить оригинальный размер окна при первой активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, сохраняя соотношение сторон, что может вызвать изменение масштаба.

### Можно ли полностью избежать этой проблемы с изменением размера?

Да. Совместив размер окна книги Excel или размер диаграммы с размером OLE‑кадра до внедрения, можно удерживать размеры диаграммы постоянными.

### Какой подход выбрать: задавать размер окна книги или размер диаграммы?

Используйте **Approach 1 (window size)**, если хотите сохранить соотношение сторон книги и, возможно, позволить последующее изменение размера.  
Используйте **Approach 2 (chart size)**, если размеры диаграммы фиксированы и не будут изменяться после внедрения.

### Работают ли эти методы как с шаблонными, так и с новыми презентациями?

Да. Оба подхода работают одинаково для презентаций, созданных из шаблонов, и для созданных с нуля.

### Есть ли ограничение по размеру OLE‑кадра?

Нет. Вы можете задать OLE‑кадр любого размера, при условии корректного масштабирования к размеру книги или диаграммы.

### Можно ли использовать эти методы с диаграммами, созданными в других электронных таблицах?

Примеры рассчитаны на диаграммы Excel, созданные с помощью Aspose.Cells, но принципы применимы к другим программам, поддерживающим OLE и аналогичные параметры размеров.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
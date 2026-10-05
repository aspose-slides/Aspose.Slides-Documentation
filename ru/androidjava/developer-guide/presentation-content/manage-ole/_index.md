---
title: Управление OLE в презентациях на Android
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/androidjava/manage-ole/
keywords:
- OLE объект
- Связывание и внедрение объектов
- добавить OLE
- встроить OLE
- добавить объект
- встроить объект
- добавить файл
- встроить файл
- связанный объект
- связанный файл
- изменить OLE
- значок OLE
- заголовок OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Android via Java. Встраивайте, обновляйте и экспортируйте содержимое OLE без проблем."
---
## **Введение**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или внедрения. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint. Такая диаграмма считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в сопряжённом приложении (Excel) или предлагает выбрать приложение для открытия или редактирования объекта.
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) позволяет вставлять OLE‑объекты в слайды как OLE‑кадры объектов ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Добавление OLE‑кадров объектов в слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑кадр объекта с помощью Aspose.Slides for Android via Java. Делайте так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel как массив байтов.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel в слайд как OLE‑кадр объекта, используя Aspose.Slides for Android via Java.  
**Note** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать нужное приложение для открытия OLE‑объекта.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Подготовьте данные для OLE‑объекта.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Добавьте OLE‑кадр объекта на слайд.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for Android via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) без внедрения данных, а лишь с ссылкой на файл.

Этот код на Java показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE‑кадр объекта со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже внедрён в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это был нужный OLE‑кадр объекта.
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции с ним.

В примере ниже показывается, как получить доступ к OLE‑кадру объекта (встроенному объекту Excel chart) и к его файловым данным.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Получить данные встроенного файла.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение встроенного файла.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.

Этот код на Java показывает, как проверить, является ли OLE‑объект связанным, и затем получить путь к связанному файлу:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Проверьте, связан ли OLE-объект.
    if (oleFrame.isObjectLink()) {
        // Выведите полный путь к связанному файлу.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Выведите относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Note" %}}

В этом разделе пример кода использует [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к фигуре OLE‑кадра объекта.  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится одна фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это был нужный OLE‑кадр объекта.
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции с ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Получите нужный `Worksheet` и измените данные.
7. Сохраните обновлённый `Workbook` в поток.
8. Измените данные OLE‑объекта из потока.

В примере ниже OLE‑кадр объекта (встроенный объект Excel chart) доступен, и его файловые данные изменяются для обновления данных диаграммы.

```java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Прочитать данные OLE-объекта как объект Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Изменить данные рабочей книги.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Изменить данные OLE-кадра.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Android via Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы как объекты. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для открытия.

Этот код на Java показывает, как встроить HTML и ZIP в слайд:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Установка типов файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Android via Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑кадра или его расширение.

Этот код на Java показывает, как задать тип файла для встроенного OLE‑объекта — `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Изменить тип файла на ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Установка изображений‑значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется превью в виде изображения‑значка. Это превью видят пользователи перед доступом к объекту. Если нужно использовать конкретное изображение и текст в превью, можно задать изображение‑значок и заголовок с помощью Aspose.Slides for Android via Java.

Этот код на Java показывает, как задать изображение‑значок и заголовок для встроенного объекта:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Добавить изображение в ресурсы презентации.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Установить заголовок и изображение для предварительного просмотра OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Предотвращение изменения размера и перемещения OLE‑кадра объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑кадра, потому что PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы отключить запрос PowerPoint об обновлении данных объекта, вызовите метод [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) со значением `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Извлечение встроенных файлов**

Aspose.Slides for Android via Java позволяет извлекать файлы, внедрённые в слайды как OLE‑объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь.
2. Пройдитесь по всем фигурам в презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Получите данные встроенных файлов из OLE‑кадров и запишите их на диск.

Этот код на Java показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Будет ли содержимое OLE отрисовано при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (превью). «Живое» OLE‑содержимое не исполняется при рендеринге. При необходимости задайте собственное изображение‑превью, чтобы обеспечить ожидаемый внешний вид в экспортированном PDF.

Чтобы также сохранить встроенный файл как вложение PDF, вызовите [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) со значением `true`. Эта опция по умолчанию отключена. Пример и инструкции по проверке вложения смотрите в статье [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте фигуру: Aspose.Slides предоставляет блокировки на уровне фигур. Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «прыгает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/androidjava/working-solution-for-worksheet-resizing/) — либо подгоняйте кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте подходящее заменяющее изображение.

**Сохраняются ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути существуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.
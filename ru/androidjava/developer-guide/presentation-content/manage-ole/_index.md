---
title: Управление OLE в презентациях на Android
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/androidjava/manage-ole/
keywords:
- OLE объект
- Связывание и встраивание объектов
- добавление OLE
- встраивание OLE
- добавление объекта
- встраивание объекта
- добавление файла
- встраивание файла
- связанный объект
- связанный файл
- изменение OLE
- значок OLE
- заголовок OLE
- извлечение OLE
- извлечение объекта
- извлечение файла
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---
## **Введение**

{{% alert color="info" %}} 
OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или встраивания. 
{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Диаграмма затем помещается в слайд PowerPoint. Эта диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться как значок. В этом случае при двойном щелчке по значку диаграмма откроется в связанном приложении (Excel) или будет предложено выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может отображать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides для Android через Java](https://products.aspose.com/slides/ru/androidjava/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleObjectFrame)).

## **Добавление OLE‑объектных фреймов в слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE‑объектного фрейма, используя Aspose.Slides для Android через Java. Это можно сделать следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Прочитайте файл Excel как массив байтов.  
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleObjectFrame) на слайд, указав массив байтов и другую информацию об OLE‑объекте.  
5. Сохраните изменённую презентацию в файл PPTX.  

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде OLE‑объектного фрейма, используя Aspose.Slides для Android через Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint корректно определить тип файла и выбрать подходящее приложение для открытия этого OLE‑объекта.

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

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides для Android через Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleObjectFrame) без встраивания данных, а лишь с ссылкой на файл.  

Этот код Java демонстрирует, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить OLE объектный фрейм со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Доступ к OLE‑объектным фреймам**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/OleObjectFrame).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/). Это и был нужный OLE‑объектный фрейм для доступа.  
4. После доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.  

В примере ниже получаем доступ к OLE‑объектному фрейму (встроенному объекту диаграммы Excel в слайде) и его файловым данным.

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

### **Доступ к свойствам связанных OLE‑объектных фреймов**

Aspose.Slides позволяет получать свойства связанных OLE‑объектных фреймов.  

Этот код Java показывает, как проверить, является ли OLE‑объект связанным, и затем получить путь к связанному файлу:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Проверить, связан ли OLE объект.
    if (oleFrame.isObjectLink()) {
        // Вывести полный путь к связанному файлу.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Вывести относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" %}} 
В этом разделе пример кода ниже использует [Aspose.Cells для Android через Java](/cells/androidjava/). 
{{% /alert %}} 

Если OLE‑объект уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Получите форму OLE‑объектного фрейма.  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/). Это был нужный OLE‑объектный фрейм для доступа.  
4. После доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.  
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.  
6. Получите нужный `Worksheet` и измените данные.  
7. Сохраните обновлённый `Workbook` в поток.  
8. Измените данные OLE‑объекта из потока.  

В примере ниже получаем доступ к OLE‑объектному фрейму (встроенному объекту диаграммы Excel в слайде) и изменяем его файловые данные для обновления данных диаграммы.

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

    // Считать данные OLE‑объекта как объект Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Изменить данные workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Изменить данные объекта OLE‑фрейма.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides для Android через Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять файлы HTML, PDF и ZIP в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящую программу для его открытия.  

Этот код Java показывает, как встраивать HTML и ZIP в слайд:

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

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides для Android через Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑фрейма или его расширение.  

Этот код Java показывает, как задать тип файла для встроенного OLE‑объекта как `zip`:

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

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр, состоящий из изображения значка. Этот предварительный просмотр видят пользователи перед доступом к OLE‑объекту или его открытием. Если необходимо использовать определённое изображение и текст в качестве элементов предварительного просмотра, вы можете задать изображение значка и заголовок с помощью Aspose.Slides для Android через Java.  

Этот код Java показывает, как задать изображение значка и заголовок для встроенного объекта:

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

## **Предотвращение изменения размера и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑объектного фрейма, так как PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы избежать запроса PowerPoint об обновлении данных объекта, установите метод `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/) в значение `false`:

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

Aspose.Slides для Android через Java позволяет извлекать файлы, встроенные в слайды как OLE‑объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащего OLE‑объекты, которые вы планируете извлечь.  
2. Пройдитесь по всем формам в презентации и получите доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/oleobjectframe).  
3. Получите данные встроенных файлов из OLE‑объектных фреймов и запишите их на диск.  

Этот код Java показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

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

### Будет ли OLE‑контент отрисовываться при экспорте слайдов в PDF/изображения?

Отрисовывается то, что видно на слайде — значок/замещающее изображение (превью). «Живой» OLE‑контент не исполняется во время рендеринга. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

### Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?

Заблокируйте форму: Aspose.Slides предоставляет блокировки на уровне формы. Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

### Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/androidjava/working-solution-for-worksheet-resizing/) — либо подгоните фрейм к диапазону, либо масштабируйте диапазон до фиксированного фрейма и задайте подходящее замещающее изображение.

### Будут ли относительные пути для связанных OLE‑объектов сохраняться в формате PPTX?

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.
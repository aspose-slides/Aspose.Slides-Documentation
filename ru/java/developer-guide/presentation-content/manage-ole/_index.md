---
title: Управление OLE в презентациях с использованием Java
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/java/manage-ole/
keywords:
- OLE объект
- Объектное связывание и внедрение
- добавление OLE
- внедрение OLE
- добавление объекта
- внедрение объекта
- добавление файла
- внедрение файла
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
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для Java. Встраивайте, обновляйте и экспортируйте содержимое OLE без усилий."
---
## **Введение**

{{% alert color="info" %}} 
OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или внедрения. 
{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в связанном приложении (Excel) или запрашивает выбор приложения для открытия или редактирования объекта. 
- OLE‑объект может показывать свое фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for Java](https://products.aspose.com/slides/ru/java/) позволяет вставлять OLE Objects на слайды в виде OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleObjectFrame)).

## **Добавление OLE Object Frames на слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE object frame с помощью Aspose.Slides for Java. Вы можете сделать это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд по его индексу. 
1. Прочитайте файл Excel в виде массива байтов. 
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте. 
1. Запишите изменённую презентацию в файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде OLE object frame с помощью Aspose.Slides for Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Добавление связанных OLE Object Frames**

Aspose.Slides for Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleObjectFrame) без встраивания данных, используя только ссылку на файл.

Этот код Java показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add an OLE object frame with a linked Excel file.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Доступ к OLE Object Frames**

Если OLE‑объект уже встроен в слайд, вы легко можете найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/OleObjectFrame).  
   В нашем примере мы использовали ранее созданный PPTX, на котором на первом слайде находится единственная фигура. Затем мы *cast* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IOleObjectFrame). Это и был требуемый OLE object frame. 
4. После получения доступа к OLE object frame вы можете выполнить любую операцию с ним. 

В примере ниже демонстрируется доступ к OLE object frame (встроенному объекту диаграммы Excel) и к его файловым данным.

``` java 
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

### **Доступ к свойствам связанных OLE Object Frame**

Aspose.Slides позволяет получать свойства связанных OLE object frame.

Этот код Java показывает, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:

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

## **Изменение данных OLE объекта**

{{% alert color="info" %}} 
В этом разделе пример кода использует [Aspose.Cells for Java](/cells/java/). 
{{% /alert %}} 

Если OLE‑объект уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Доступ к фигуре OLE object frame.  
   В нашем примере мы использовали ранее созданный PPTX, на котором на первом слайде находится одна фигура. Затем мы *cast* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IOleObjectFrame). Это был нужный OLE object frame. 
4. После получения доступа к OLE object frame вы можете выполнить любую операцию с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока. 

В примере ниже OLE object frame (встроенный объект диаграммы Excel) открывается, и его файловые данные изменяются для обновления данных диаграммы.

``` java 
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

    // Прочитать данные OLE‑объекта как объект Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Изменить данные рабочей книги.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Изменить данные объекта OLE‑кадра.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Java позволяет встраивать в слайды другие типы файлов. Например, вы можете вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователь автоматически открывает вставленный объект в соответствующей программе или получает запрос выбрать подходящее приложение для его открытия.

Этот код Java показывает, как встроить HTML и ZIP в слайд:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Установка типов файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑фрейма или его расширение.

Этот код Java показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот просмотр виден пользователям до доступа к объекту. Если вы хотите использовать конкретное изображение и текст в качестве элементов превью, вы можете задать изображение значка и заголовок через Aspose.Slides for Java.

Этот код Java показывает, как задать изображение значка и заголовок для встроенного объекта:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Добавить изображение в ресурсы презентации.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Установить заголовок и изображение для превью OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Предотвращение изменения размера и перемещения OLE Object Frame**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE Object Frame, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и пересоздаёт превью. Чтобы PowerPoint не предлагал обновлять данные объекта, установите метод `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ioleobjectframe/) в `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Извлечение встроенных файлов**

Aspose.Slides for Java позволяет извлекать файлы, встроенные в слайды как OLE‑объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащего OLE‑объекты, которые требуется извлечь. 
2. Пройдитесь по всем фигурам презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/oleobjectframe). 
3. Доступ к данным встроенных файлов из OLEObjectFrame и запись их на диск. 

Этот код Java показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

### Будет ли OLE‑контент отображаться при экспорте слайдов в PDF/изображения?

Отображается то, что видно на слайде — иконка/заместительное изображение (превью). «Живой» OLE‑контент не выполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

### Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?

Заблокируйте фигуру: Aspose.Slides предоставляет [блокировки на уровне фигур](/slides/ru/java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

### Почему связанный объект Excel «прыгает» или меняет размер при открытии презентации?

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/java/working-solution-for-worksheet-resizing/) — либо подгоняйте фрейм под диапазон, либо масштабируйте диапазон до фиксированного фрейма и задавайте соответствующее заместительное изображение.

### Сохраняются ли относительные пути для связанных OLE‑объектов в формате PPTX?

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или встраивание.
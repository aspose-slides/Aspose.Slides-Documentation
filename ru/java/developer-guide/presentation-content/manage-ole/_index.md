---
title: Управление OLE в презентациях с помощью Java
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/java/manage-ole/
keywords:
- OLE объект
- Объектная связь и внедрение
- добавить OLE
- внедрить OLE
- добавить объект
- внедрить объект
- добавить файл
- внедрить файл
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
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Java. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---
## **Введение**

{{% alert color="info" title="Примечание" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или встраивание. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в связанном приложении (Excel) либо запрашивает выбор приложения для открытия или редактирования объекта.  
- OLE‑объект может показывать своё реальное содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы прямо в PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) позволяет вставлять OLE‑объекты в слайды как OLE‑объектные фреймы ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Добавление OLE‑объектных фреймов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑объектный фрейм с помощью Aspose.Slides for Java. Делается это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
1. Получите ссылку на слайд по его индексу.  
1. Прочитайте файл Excel в виде массива байтов.  
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) на слайд, содержащий массив байтов и другую информацию об OLE‑объекте.  
1. Сохраните изменённую презентацию в файл PPTX.  

В примере ниже мы добавили диаграмму из файла Excel на слайд как OLE‑объектный фрейм с помощью Aspose.Slides for Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определять тип файла и выбирать нужное приложение для открытия OLE‑объекта.

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

### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides for Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) без встраивания данных, а только со ссылкой на файл.

Этот код Java показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:

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

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная фигура. Затем мы *привели* этот объект к интерфейсу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это и был нужный OLE‑объектный фрейм.  
4. После доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.  

В примере ниже показан доступ к OLE‑объектному фрейму (встроенному объекту Excel‑диаграммы) и его файловым данным.

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

### **Доступ к свойствам связанного OLE‑объектного фрейма**

Aspose.Slides позволяет получать свойства связанного OLE‑объектного фрейма.

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

        // Вывести относительный путь к связанному файлу, если он существует.
        // Только презентации PPT могут содержать относительный путь.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Примечание" %}}

В этом разделе пример кода использует [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные так:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Доступ к фигуре OLE‑объектного фрейма. В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна фигура. Затем мы *привели* этот объект к интерфейсу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это был нужный OLE‑объектный фрейм.  
4. После доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.  
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.  
6. Получите нужный `Worksheet` и измените данные.  
7. Сохраните обновлённый `Workbook` в поток.  
8. Измените данные OLE‑объекта из потока.  

В примере ниже показан доступ к OLE‑объектному фрейму (встроенному объекту Excel‑диаграммы) и модификация его файловых данных для обновления данных диаграммы.

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

Помимо диаграмм Excel, Aspose.Slides for Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы как объекты. При двойном щелчке пользователем вставленного объекта он автоматически откроется в соответствующей программе, либо пользователь получит запрос выбрать подходящее приложение.

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

При работе с презентациями иногда требуется заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Java позволяет задать тип файла для встроенного объекта, что позволяет обновлять данные OLE‑фрейма или его расширение.

Этот код Java показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

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

## **Установка изображений‑иконок и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде иконки. Этот предварительный просмотр виден пользователям до доступа или открытия OLE‑объекта. Если необходимо использовать конкретное изображение и текст в качестве элементов preview, можно задать иконку и заголовок с помощью Aspose.Slides for Java.

Этот код Java показывает, как задать изображение‑иконку и заголовок для встроенного объекта:

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Предотвращение изменения размеров и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑объектного фрейма, потому что PowerPoint обновляет данные из связанного OLE‑объекта и перезапускает его предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, вызовите метод [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) со значением `false`:

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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь.  
2. Пройдите по всем фигурам в презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).  
3. Доступ к данным встроенных файлов из OLE‑объектных фреймов и запись их на диск.  

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

**Будет ли OLE‑контент отрисован при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (preview). «Живой» OLE‑контент не выполняется во время рендеринга. При необходимости задайте собственное изображение‑preview, чтобы обеспечить ожидаемый вид в экспортированном PDF.

Чтобы также сохранить вложенный файл как вложение PDF, вызовите [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) со значением `true`. Эта опция отключена по умолчанию. Пример и инструкции по проверке вложения см. в разделе [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте фигуру: Aspose.Slides предоставляет [shape-level locks](/slides/ru/java/applying-protection-to-presentation/). Это не шифрование, но эффективно препятствует случайным изменениям и перемещениям.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять preview связанного OLE‑объекта. Для стабильного внешнего вида следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/java/working-solution-for-worksheet-resizing/) — либо подгоните фрейм под диапазон, либо масштабируйте диапазон до фиксированного фрейма и задайте подходящее заменяющее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI либо встраивание.
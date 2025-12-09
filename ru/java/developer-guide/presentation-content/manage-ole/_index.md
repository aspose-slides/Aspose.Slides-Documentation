---
title: Управление OLE в презентациях с использованием Java
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/java/manage-ole/
keywords:
- OLE-объект
- Связывание и встраивание объектов
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
- Java
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Java. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или запросом выбора приложения для открытия или редактирования объекта. 
- OLE‑объект может отображать свое фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается интерфейс диаграммы, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Добавление OLE‑кадров объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE‑кадра объекта с помощью Aspose.Slides for Java, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) на слайд, включающий массив байтов и другую информацию об OLE‑объекте.
5. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили диаграмму из файла Excel на слайд в виде OLE‑кадра объекта с помощью Aspose.Slides for Java. **Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно распознавать тип файла и выбирать соответствующее приложение для открытия этого OLE‑объекта.
``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Подготовьте данные для OLE‑объекта.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Добавьте кадр OLE‑объекта на слайд.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) без встраивания данных, а только с ссылкой на файл.

This Java code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) with a linked Excel file to a slide:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить кадр OLE‑объекта со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встраиваемым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). В нашем примере мы использовали ранее созданный PPTX, содержащий только одну фигуру на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это был нужный OLE‑кадр объекта, к которому нужно получить доступ.
4. Когда доступ к OLE‑кадру объекта получен, вы можете выполнять любые операции с ним.

В примере ниже доступен OLE‑кадр объекта (встроенный в слайд объект диаграммы Excel) и его файловые данные.
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Получить данные встроенного файла.
    // Получить расширение встроенного файла.
    // ...
}
```


### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.

This Java code shows you how to check if an OLE object is linked and then obtain the path to the linked file:
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Проверить, связан ли OLE‑объект.
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

{{% alert color="primary" %}} 

В этом разделе ниже приведён пример кода, использующий [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с встраиваемым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к фигуре OLE‑кадра объекта. В нашем примере мы использовали ранее созданный PPTX, содержащий одну фигуру на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это был нужный OLE‑кадр объекта, к которому нужно получить доступ.
4. Когда доступ к OLE‑кадру объекта получен, вы можете выполнять любые операции с ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Получите нужный `Worksheet` и измените данные.
7. Сохраните обновлённый `Workbook` в поток.
8. Измените данные OLE‑объекта из потока.

В примере ниже доступен OLE‑кадр объекта (встроенный в слайд объект диаграммы Excel), и его файловые данные изменены для обновления данных диаграммы.
``` java 
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

Помимо диаграмм Excel, Aspose.Slides for Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять файлы HTML, PDF и ZIP в виде объектов. Когда пользователь двойным щелчком открывает вставленный объект, он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящую программу для его открытия.

This Java code shows you how to embed HTML and ZIP into a slide:
```java
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


## **Установка типов файлов для встраиваемых объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Java позволяет задать тип файла для встраиваемого объекта, позволяя обновить данные OLE‑кадра или его расширение.

This Java code shows you how to set the file type for an embedded OLE object to `zip`:
```java
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


## **Установка изображений значков и заголовков для встраиваемых объектов**

После встраивания OLE‑объекта автоматически добавляется превью‑изображение, состоящее из значка. Это превью видят пользователи перед доступом к объекту. Если нужно использовать конкретное изображение и текст в превью, можно задать изображение значка и заголовок с помощью Aspose.Slides for Java.

This Java code shows you how to set the icon image and title for an embedded object:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Добавить изображение в ресурсы презентации.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Установить заголовок и изображение для предварительного просмотра OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Предотвращение изменения размера и перемещения OLE‑кадра объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновления связей. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы предотвратить запрос PowerPoint о обновлении данных объекта, установите метод `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) в `false`:
```java
oleFrame.setUpdateAutomatic(false);
```


## **Извлечение встраиваемых файлов**

Aspose.Slides for Java позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего OLE‑объекты, которые вы хотите извлечь.
2. Пройдитесь по всем фигурам в презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Получите данные встраиваемых файлов из OLE‑кадров объектов и запишите их на диск.

This Java code shows you how to extract files embedded in a slide as OLE objects:
```java
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

**Будет ли содержимое OLE отображаться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/замещающее изображение (превью). «Живое» OLE‑содержимое не исполняется во время рендеринга. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте фигуру: Aspose.Slides предоставляет [shape-level locks](/slides/ru/java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/java/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон в фиксированный кадр и задайте подходящее замещающее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости рекомендуется использовать надёжные абсолютные пути/доступные URI или встраивание.
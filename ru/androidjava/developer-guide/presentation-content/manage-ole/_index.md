---
title: Управление OLE в презентациях на Android
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/androidjava/manage-ole/
keywords:
- OLE объект
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
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте управление объектами OLE в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Android via Java. Встраивайте, обновляйте и экспортируйте содержимое OLE без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или встраивания. 

{{% /alert %}} 

Представьте диаграмму, созданную в MS Excel. Эта диаграмма затем помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или запрашивается выбор приложения для открытия/редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)). 

## **Добавление OLE‑кадров объектов на слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑кадр объекта, используя Aspose.Slides for Android via Java. Это делается так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Прочитайте файл Excel как массив байтов.  
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте.  
5. Сохраните изменённую презентацию в файл PPTX.  

В примере ниже мы добавили диаграмму из файла Excel на слайд как OLE‑кадр объекта, используя Aspose.Slides for Android via Java.  
**Примечание**, что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать нужное приложение для открытия OLE‑объекта.  
```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Подготовка данных для OLE объекта.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Добавление OLE кадра объекта на слайд.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for Android via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) без встраивания данных, а только со ссылкой на файл.  

Этот Java‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE кадр объекта со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить к нему доступ следующим образом:  

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). В нашем примере использовалась ранее созданная PPTX, на которой на первом слайде есть только одна фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это и был нужный OLE‑кадр объекта.  
4. После получения доступа к OLE‑кадру объекта можно выполнять любые операции с ним.  

В примере ниже доступ получен к OLE‑кадру объекта (встроенному объекту диаграммы Excel на слайде) и к его файловым данным.  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Получить встроенные данные файла.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение встроенного файла.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.  

Этот Java‑код показывает, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:  
```java
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

{{% alert color="primary" %}} 

В этом разделе приведён пример кода, использующий [Aspose.Cells for Android via Java](/cells/androidjava/). 

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные следующим образом:  

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к фигуре OLE‑кадра объекта. В нашем примере использовалась ранее созданная PPTX, в которой на первом слайде одна фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это был нужный OLE‑кадр объекта.  
4. После получения доступа к OLE‑кадру объекта можно выполнять любые операции с ним.  
5. Создайте объект `Workbook` и получите доступ к данным OLE.  
6. Получите нужный `Worksheet` и измените данные.  
7. Сохраните обновлённый `Workbook` в поток.  
8. Измените данные OLE‑объекта из потока.  

В примере ниже OLE‑кадр объекта (встроенный объект диаграммы Excel на слайде) получен, и его файловые данные изменены для обновления данных диаграммы.  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Прочитать данные OLE объекта как объект Workbook.
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

Помимо диаграмм Excel, Aspose.Slides for Android via Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователем вставленного объекта он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящее приложение для открытия.  

```java
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


## **Установка типа файла для встроенных объектов**

При работе с презентациями иногда требуется заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Android via Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑кадра или его расширение.  

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


## **Установка изображений‑значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется превью в виде значка. Это превью видят пользователи до доступа к объекту. Если нужно использовать конкретное изображение и текст в превью, можно задать значок и заголовок с помощью Aspose.Slides for Android via Java.  

```java
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


## **Предотвращение изменения размеров и перемещения OLE‑кадра объекта**

После добавления связанного OLE‑объекта на слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновления связей. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы PowerPoint не предлагал обновлять данные объекта, установите метод `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) в значение `false`:  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Извлечение встроенных файлов**

Aspose.Slides for Android via Java позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь.  
2. Пройдитесь по всем фигурам презентации и получите доступ к фигурам типа [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).  
3. Получите данные встроенных файлов из OLE‑кадров и запишите их на диск.  

```java
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

**Будет ли OLE‑контент отображаться при экспорте слайдов в PDF/изображения?**  

Отображается то, что видно на слайде — значок/замещающее изображение (превью). «Живой» OLE‑контент не выполняется при рендеринге. При необходимости задайте собственное превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.  

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**  

Заблокируйте фигуру: Aspose.Slides предоставляет [блокировки на уровне фигуры](/slides/ru/androidjava/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.  

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**  

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида используйте рекомендации из [Working Solution for Worksheet Resizing](/slides/ru/androidjava/working-solution-for-worksheet-resizing/) — либо подгоняйте кадр под диапазон, либо масштабируйте диапазон под фиксированный кадр и задайте подходящее заменяющее изображение.  

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**  

В PPTX информация о «относительных путях» отсутствует — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости рекомендуется использовать надёжные абсолютные пути/доступные URI или встраивание.
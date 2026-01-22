---
title: "Управление OLE в презентациях на Android"
linktitle: "Управление OLE"
type: docs
weight: 40
url: /ru/androidjava/manage-ole/
keywords:
- "OLE‑объект"
- "Связывание и внедрение объектов"
- "добавить OLE"
- "внедрить OLE"
- "добавить объект"
- "внедрить объект"
- "добавить файл"
- "внедрить файл"
- "связанный объект"
- "связанный файл"
- "изменить OLE"
- "значок OLE"
- "заголовок OLE"
- "извлечь OLE"
- "извлечь объект"
- "извлечь файл"
- "PowerPoint"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Оптимизируйте управление OLE‑объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides for Android via Java. Внедряйте, обновляйте и экспортируйте OLE‑контент без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или внедрения. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint и считается OLE‑объектом. 

- OLE‑объект может отображаться как значок. В этом случае двойной щелчок по значку открывает диаграмму в соответствующем приложении (Excel) или запрашивает выбор приложения для открытия/редактирования объекта. 
- OLE‑объект может показывать своё содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) позволяет вставлять OLE‑объекты в слайды в виде кадров OLE‑объектов ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Добавить кадры OLE‑объектов в слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как кадр OLE‑объекта с помощью Aspose.Slides for Android via Java. Делается это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
1. Получите ссылку на слайд по его индексу.  
1. Прочитайте файл Excel в виде массива байтов.  
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) на слайд, указав массив байтов и другую информацию об OLE‑объекте.  
1. Сохраните изменённую презентацию в файл PPTX.  

В примере ниже мы добавили диаграмму из файла Excel в слайд как кадр OLE‑объекта с помощью Aspose.Slides for Android via Java.  
**Примечание** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать подходящее приложение для открытия OLE‑объекта.  
```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Подготовить данные для OLE‑объекта.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Добавить кадр OLE‑объекта на слайд.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Добавить связанные кадры OLE‑объектов**

Aspose.Slides for Android via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) без внедрения данных, а только со ссылкой на файл.

Этот код Java показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить кадр OLE-объекта со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к кадрам OLE‑объектов**

Если OLE‑объект уже внедрён в слайд, найти или получить к нему доступ можно так:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). В нашем примере мы использовали ранее созданный PPTX, содержащий только одну форму на первом слайде. Затем мы *cast* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это и был нужный кадр OLE‑объекта.  
4. После получения доступа к кадру OLE‑объекта вы можете выполнить любую операцию с ним.  

В примере ниже доступны кадр OLE‑объекта (внедрённый объект диаграммы Excel) и его данные файла.  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Получить данные вложенного файла.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение вложенного файла.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных кадров OLE‑объектов**

Aspose.Slides позволяет получать свойства связанных кадров OLE‑объекта.

Этот код Java показывает, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Проверьте, связан ли OLE‑объект.
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


## **Изменить данные OLE‑объекта**

{{% alert color="primary" %}} 

В этом разделе пример кода использует [Aspose.Cells for Android via Java](/cells/androidjava/).  

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, его можно легко получить и изменить данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Получите форму кадра OLE‑объекта. В нашем примере мы использовали ранее созданный PPTX, содержащий одну форму на первом слайде. Затем мы *cast* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Это и был нужный кадр OLE‑объекта.  
4. После получения доступа к кадру OLE‑объекта вы можете выполнить любую операцию с ним.  
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.  
6. Получите нужный `Worksheet` и измените данные.  
7. Сохраните обновлённый `Workbook` в поток.  
8. Обновите данные OLE‑объекта из потока.  

В примере ниже кадр OLE‑объекта (внедрённый объект диаграммы Excel) доступается, и его данные файла изменяются для обновления данных диаграммы.  
```java 
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

    // Изменить данные объекта кадра OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Внедрять другие типы файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Android via Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы как объекты. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящее приложение.  

Этот код Java показывает, как внедрить HTML и ZIP в слайд:  
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


## **Установить типы файлов для внедрённых объектов**

При работе с презентациями иногда требуется заменить старый OLE‑объект новым или заменить неподдерживаемый объект поддерживаемым. Aspose.Slides for Android via Java позволяет задать тип файла для внедрённого объекта, позволяя обновлять данные кадра OLE или его расширение.  

Этот код Java показывает, как установить тип файла для внедрённого OLE‑объекта — `zip`:  
```java
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


## **Установить изображения‑значки и заголовки для внедрённых объектов**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Это то, что пользователи видят до доступа к объекту. Если нужно использовать конкретное изображение и текст в превью, можно задать значок и заголовок через Aspose.Slides for Android via Java.  

Этот код Java показывает, как задать изображение‑значок и заголовок для внедрённого объекта:  
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

// Установить заголовок и изображение для превью OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Предотвратить изменение размеров и перемещение кадра OLE‑объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение кадра OLE‑объекта, поскольку PowerPoint обновляет данные из связанного объекта и перерисовывает превью. Чтобы отключить запрос PowerPoint об обновлении данных объекта, задайте методу `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) значение `false`:  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Извлекать внедрённые файлы**

Aspose.Slides for Android via Java позволяет извлекать файлы, внедрённые в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь.  
2. Пройдитесь по всем формам презентации и получите формы [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).  
3. Получите данные внедрённых файлов из кадров OLE‑объектов и запишите их на диск.  

Этот код Java показывает, как извлечь файлы, внедрённые в слайд как OLE‑объекты:  
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


## **Часто задаваемые вопросы**

**Будет ли OLE‑контент отрисован при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (превью). «Живой» OLE‑контент не исполняется во время рендера. При необходимости задайте собственное превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет блокировки на уровне формы. Это не шифрование, но эффективно предотвращает случайные правки и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE‑объекта. Для стабильного отображения следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/androidjava/working-solution-for-worksheet-resizing/) — либо подгоняйте кадр под диапазон, либо масштабируйте диапазон под фиксированный кадр и задавайте подходящее заменяющее изображение.

**Сохранятся ли относительные пути к связанным OLE‑объектам в формате PPTX?**

В PPTX информация о «относительном пути» отсутствует — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или внедрение.
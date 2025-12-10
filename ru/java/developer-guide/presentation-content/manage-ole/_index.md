---
title: Управление OLE в презентациях с использованием Java
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/java/manage-ole/
keywords:
- OLE объект
- Связывание и внедрение объектов
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
description: "Оптимизируйте управление OLE объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для Java. Внедряйте, обновляйте и экспортируйте OLE контент без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или внедрения. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной клик по значку открывает диаграмму в связанном приложении (Excel) или предлагает выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может показывать своё содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается интерфейс диаграммы, и вы можете изменить данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) позволяет вставлять OLE‑объекты в слайды как OLE‑кадры ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Добавить OLE Object Frames в слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑кадр с помощью Aspose.Slides for Java. Делайте так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд по его индексу. 
1. Прочтите файл Excel в виде массива байтов. 
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте. 
1. Сохраните изменённую презентацию как файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel в слайд как OLE‑кадр с помощью Aspose.Slides for Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) принимает расширение внедряемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия OLE‑объекта.  
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Подготовьте данные для OLE объекта.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Добавьте OLE‑кадр объекта на слайд.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Добавить связанные OLE Object Frames**

Aspose.Slides for Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) без внедрения данных, а лишь со ссылкой на файл.

Ниже Java‑код, показывающий, как добавить [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) со связанным файлом Excel в слайд:  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE‑кадр объекта со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к OLE Object Frames**

Если OLE‑объект уже внедрён в слайд, его можно легко найти или получить доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это и был нужный OLE‑кадр. 
4. После получения доступа к OLE‑кадру можно выполнить любую операцию. 

В примере ниже демонстрируется доступ к OLE‑кадру (внедрённому объекту диаграммы Excel) и его файловым данным.  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Получить данные внедренного файла.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение внедренного файла.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных OLE Object Frames**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров.

Ниже Java‑код, показывающий, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Проверьте, связан ли OLE объект.
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


## **Изменить данные OLE Object**

{{% alert color="primary" %}} 

В этом разделе пример кода использует [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Получите форму OLE‑кадра.  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится одна форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Это был нужный OLE‑кадр. 
4. После доступа к OLE‑кадру можно выполнить любую операцию. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Обновите данные OLE‑объекта из потока. 

В примере ниже демонстрируется доступ к OLE‑кадру (внедрённому объекту диаграммы Excel) и изменение его файловых данных для обновления данных диаграммы.  
``` java 
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


## **Внедрять другие типы файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользовательского объекта он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для открытия. 

Ниже Java‑код, показывающий, как внедрить HTML и ZIP в слайд:  
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


## **Установить типы файлов для внедрённых объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Java позволяет задать тип файла для внедрённого объекта, что даёт возможность обновить данные OLE‑кадра или его расширение. 

Ниже Java‑код, показывающий, как установить тип файла для внедрённого OLE‑объекта в `zip`:  
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

После внедрения OLE‑объекта автоматически добавляется превью‑изображение‑значок. Это превью видят пользователи до доступа к объекту. Если необходимо использовать конкретное изображение и текст в превью, можно задать значок и заголовок с помощью Aspose.Slides for Java. 

Ниже Java‑код, показывающий, как задать изображение‑значок и заголовок для внедрённого объекта:  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Добавьте изображение в ресурсы презентации.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Установите заголовок и изображение для превью OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Предотвратить изменение размера и позиционирования OLE Object Frame**

После добавления связанного OLE‑объекта в слайд, при открытии презентации в PowerPoint может появиться сообщение с просьбой обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и пересчитывает превью. Чтобы не показывать запрос на обновление данных, установите значение `false` для метода `setUpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/):  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Извлекать внедрённые файлы**

Aspose.Slides for Java позволяет извлекать из слайдов файлы, внедрённые в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь. 
2. Пройдитесь по всем формам презентации и получайте формы [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe). 
3. Получите данные внедрённых файлов из OLE‑кадров и запишите их на диск. 

Ниже Java‑код, показывающий, как извлечь файлы, внедрённые в слайд как OLE‑объекты:  
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

**Будет ли OLE‑контент отображён при экспорте слайдов в PDF/изображения?**  

Отображается то, что видно на слайде — значок/заместительное изображение (превью). «Живой» OLE‑контент не исполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.  

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**  

Заблокируйте форму: Aspose.Slides предоставляет [блокировки уровня форм](/slides/ru/java/applying-protection-to-presentation/). Это не шифрование, но эффективно препятствует случайным изменениям и перемещениям.  

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**  

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида используйте рекомендации из [Working Solution for Worksheet Resizing](/slides/ru/java/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон под фиксированный кадр и задайте подходящее заместительное изображение.  

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**  

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или внедрять объекты.
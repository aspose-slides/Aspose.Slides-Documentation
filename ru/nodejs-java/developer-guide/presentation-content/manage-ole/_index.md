---
title: Управление OLE в презентациях с помощью JavaScript
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/nodejs-java/manage-ole/
keywords:
- OLE-объект
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для Node.js. Внедряйте, обновляйте и экспортируйте OLE‑контент без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или внедрения. 

{{% /alert %}} 

Рассмотрите диаграмму, созданную в MS Excel. Эта диаграмма затем размещается на слайде PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или предлагается выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑фреймов объектов ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)). 

## **Добавление OLE‑объектных фреймов на слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑объектный фрейм с помощью Aspose.Slides for Node.js via Java, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд по его индексу. 
1. Прочитайте файл Excel в виде массива байтов. 
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) на слайд, содержащий массив байтов и другую информацию об OLE‑объекте. 
1. Сохраните изменённую презентацию в файл PPTX. 

В приведённом ниже примере мы добавили диаграмму из файла Excel на слайд в виде OLE‑объектного фрейма, используя Aspose.Slides for Node.js via Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides for Node.js via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) без внедрения данных, а только со ссылкой на файл.  

Этот JavaScript‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Добавить OLE‑объектный фрейм со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к OLE‑объектным фреймам**

Если OLE‑объект уже внедрён в слайд, его можно легко найти или получить к нему доступ следующим образом:  

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). В нашем примере использовалась ранее созданная PPTX, содержащая единственную форму на первом слайде. 
4. После доступа к OLE‑объектному фрейму вы можете выполнить любую операцию с ним.  

В приведённом ниже примере демонстрируется доступ к OLE‑объектному фрейму (объекту диаграммы Excel, внедрённому в слайд) и его файловым данным.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Получить данные внедренного файла.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение внедренного файла.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных OLE‑объектных фреймов**

Aspose.Slides позволяет получать свойства связанных OLE‑объектных фреймов.  

Этот JavaScript‑код показывает, как проверить, является ли OLE‑объект связанным, и затем получить путь к связанному файлу:  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Проверить, связан ли OLE объект.
    if (oleFrame.isObjectLink()) {
        // Вывести полный путь к связанному файлу.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Вывести относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Изменение данных OLE‑объекта**

{{% alert color="primary" %}} 

В этом разделе ниже пример кода использует [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, его можно легко получить и изменить его данные следующим образом:  

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Получите форму OLE‑объектного фрейма. В нашем примере использовалась ранее созданная PPTX, содержащая одну форму на первом слайде. 
4. После доступа к OLE‑объектному фрейму вы можете выполнить любую операцию с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока. 

В приведённом ниже примере демонстрируется доступ к OLE‑объектному фрейму (объекту диаграммы Excel, внедрённому в слайд) и модификация его файловых данных для обновления данных диаграммы.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Прочитать данные OLE‑объекта как объект Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Изменить данные рабочей книги.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Изменить данные объекта OLE‑фрейма.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Внедрение других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Node.js via Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователем по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящее приложение для открытия.  

Этот JavaScript‑код показывает, как внедрить HTML и ZIP в слайд:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Установка типа файлов для внедрённых объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Node.js via Java позволяет задать тип файла для внедрённого объекта, что даёт возможность обновить данные OLE‑фрейма или его расширение.  

Этот JavaScript‑код показывает, как задать тип файла для внедрённого OLE‑объекта как `zip`:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Установка изображений‑значков и заголовков для внедрённых объектов**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи перед доступом к объекту или его открытием. Если требуется использовать конкретное изображение и текст в качестве элементов предварительного просмотра, можно задать изображение‑значок и заголовок с помощью Aspose.Slides for Node.js via Java.  

Этот JavaScript‑код показывает, как задать изображение‑значок и заголовок для внедрённого объекта:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Добавить изображение в ресурсы презентации.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Предотвращение изменения размера и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновления ссылок. Щелчок по кнопке «Update Links» может изменить размер и положение OLE‑объектного фрейма, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы PowerPoint не запрашивал обновление данных объекта, используйте метод `setUpdateAutomatic` класса [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) со значением `false`:  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **Извлечение внедрённых файлов**

Aspose.Slides for Node.js via Java позволяет извлекать файлы, внедрённые в слайды в виде OLE‑объектов, следующим образом:  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий OLE‑объекты, которые планируется извлечь. 
2. Пройдитесь по всем формам в презентации и получите формы [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe). 
3. Получите данные внедрённых файлов из OLE‑объектных фреймов и запишите их на диск.  

Этот JavaScript‑код показывает, как извлечь файлы, внедрённые в слайд в виде OLE‑объектов:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```


## **FAQ**

**Будет ли OLE‑контент отрисовываться при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (preview). «Живой» OLE‑контент не исполняется при рендеринге. При необходимости задайте собственное изображение‑превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.  

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки уровня формы](/slides/ru/nodejs-java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.  

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или внедрение.
---
title: Управление OLE в презентациях с помощью JavaScript
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides for Node.js via Java. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая помещать данные и объекты, созданные в одном приложении, в другое приложение с помощью связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке значка диаграмма открывается в соответствующем приложении (Excel) либо появляется запрос выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)). 

## **Добавление OLE‑кадров объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её на слайд в виде OLE‑кадра объекта с помощью Aspose.Slides for Node.js via Java. Это делается следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд по его индексу. 
1. Прочитайте файл Excel в виде массива байтов. 
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте. 
1. Запишите изменённую презентацию в файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде OLE‑кадра объекта с помощью Aspose.Slides for Node.js via Java.  
**Note** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта как второй параметр. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать нужное приложение для открытия данного OLE‑объекта.  
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


### **Добавление связанных OLE Object Frames**

Aspose.Slides for Node.js via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) без встраивания данных, а только со ссылкой на файл.  

Этот JavaScript‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Добавить OLE‑объектный кадр со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Доступ к OLE Object Frames**

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). В нашем примере использовалась ранее созданная PPTX, содержащая только одну фигуру на первом слайде. 
4. После получения доступа к OLE‑кадру объекта вы можете выполнить любую операцию с ним.  

В примере ниже получен доступ к OLE‑кадру объекта (встроенный объект диаграммы Excel на слайде) и его файловым данным.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Получить данные встроенного файла.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение встроенного файла.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных OLE Object Frame**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.  

Этот JavaScript‑код показывает, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Проверить, связан ли OLE‑объект.
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


## **Изменение данных OLE Object**

{{% alert color="primary" %}} 

В этом разделе пример кода использует [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}  

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к фигуре OLE‑кадра объекта. В нашем примере использовалась ранее созданная PPTX, содержащая одну фигуру на первом слайде. 
4. После получения доступа к OLE‑кадру объекта вы можете выполнить любую операцию с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока.  

В примере ниже получен доступ к OLE‑кадру объекта (встроенный объект диаграммы Excel на слайде) и его файловые данные изменены для обновления данных диаграммы.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Прочитать данные OLE-объекта как объект Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Изменить данные рабочей книги.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Изменить данные объекта OLE-кадра.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Node.js via Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователем вставленного объекта он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для открытия.  

Этот JavaScript‑код показывает, как встроить HTML и ZIP в слайд:  
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


## **Установка типа файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Node.js via Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑кадра или его расширение.  

Этот JavaScript‑код показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:  
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


## **Установка значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Именно этот предварительный просмотр видят пользователи перед доступом к объекту. Если необходимо использовать определённое изображение и текст в качестве элементов предварительного просмотра, можно задать значок и заголовок с помощью Aspose.Slides for Node.js via Java.  

Этот JavaScript‑код показывает, как задать изображение значка и заголовок для встроенного объекта:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Добавить изображение в ресурсы презентации.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Установить заголовок и изображение для предварительного просмотра OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Предотвращение изменения размера и перемещения OLE Object Frame**

После добавления связанного OLE‑объекта на слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение кадра OLE‑объекта, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, используйте метод `setUpdateAutomatic` класса [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) со значением `false`:  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **Извлечение встроенных файлов**

Aspose.Slides for Node.js via Java позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий OLE‑объекты, которые необходимо извлечь. 
2. Пройдитесь по всем фигурам презентации и получайте доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe). 
3. Получите данные встроенных файлов из OLE‑кадров объектов и запишите их на диск.  

Этот JavaScript‑код показывает, как извлечь файлы, встроенные в слайд в виде OLE‑объектов:  
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

**Будут ли OLE‑данные отрисовываться при экспорте слайдов в PDF/изображения?**  

Отрисовывается то, что видно на слайде — значок/замещающее изображение (preview). «Живой» OLE‑контент во время рендеринга не исполняется. При необходимости задайте собственное изображение предварительного просмотра, чтобы обеспечить ожидаемый вид в экспортированном PDF.  

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**  

Блокируйте фигуру: Aspose.Slides предоставляет блокировки уровня фигуры. Это не шифрование, но эффективно предотвращает случайные изменения и перемещение.  

**Сохраняются ли относительные пути для связанных OLE‑объектов в формате PPTX?**  

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в более старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или встраивание.
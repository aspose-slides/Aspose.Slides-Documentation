---
title: Управление OLE в презентациях с помощью JavaScript
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для Node.js via Java. Встраивайте, обновляйте и экспортируйте OLE‑контент без усилий."
---
## **Введение**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или встраивание. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем диаграмма размещается на слайде PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке значка диаграмма открывается в связанной программе (Excel) или появляется запрос выбора программы для открытия/редактирования объекта.
- OLE‑объект может показывать своё реальное содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы прямо в PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑фреймов ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Добавление OLE‑фреймов в слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE‑фрейма с помощью Aspose.Slides for Node.js via Java. Делать это можно следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Прочитайте файл Excel как массив байтов.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) на слайд, передав массив байтов и другую информацию об OLE‑объекте.
1. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде OLE‑фрейма с помощью Aspose.Slides for Node.js via Java.
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) принимает расширение встраиваемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия OLE‑объекта.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

### **Добавление связанных OLE‑фреймов**

Aspose.Slides for Node.js via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) без встраивания данных, а только со ссылкой на файл.

Этот JavaScript‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) со связанным файлом Excel на слайд:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Добавить OLE объектный фрейм со связанным файлом Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Доступ к OLE‑фреймам**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). В нашем примере использовалась ранее созданная PPTX, содержащая единственную форму на первом слайде.
4. После получения доступа к OLE‑фрейму вы можете выполнять любые операции с ним.

В примере ниже получен доступ к OLE‑фрейму (встроенному объекту диаграммы Excel в слайде) и к его файловым данным.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Получить данные вложенного файла.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Получить расширение вложенного файла.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Доступ к свойствам связанных OLE‑фреймов**

Aspose.Slides позволяет получать свойства связанных OLE‑фреймов.

Этот JavaScript‑код показывает, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Проверить, связан ли OLE объект.
    if (oleFrame.isObjectLink()) {
        // Вывести полный путь к связанному файлу.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Вывести относительный путь к связанному файлу, если он указан.
        // Только презентации PPT могут содержать относительно путь.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Note" %}}

В этом разделе пример кода использует [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Доступ к форме OLE‑объекта. В нашем примере использовалась ранее созданная PPTX, содержащая одну форму на первом слайде.
4. После доступа к OLE‑фрейму вы можете выполнять любые операции с ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Доступ к нужному `Worksheet` и изменение данных.
7. Сохраните обновлённый `Workbook` в поток.
8. Замените данные OLE‑объекта из потока.

В примере ниже получен доступ к OLE‑фрейму (встроенному объекту диаграммы Excel в слайде) и изменены его файловые данные для обновления данных диаграммы.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Прочитать данные OLE‑объекта как объект Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Модифицировать данные рабочей книги.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Изменить данные OLE‑фрейма.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for Node.js via Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователю автоматически открывается соответствующая программа, либо появляется запрос выбора подходящей программы.

Этот JavaScript‑код показывает, как встроить HTML и ZIP в слайд:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for Node.js via Java позволяет задать тип файла для встроенного объекта, позволяя обновлять данные OLE‑фрейма или его расширение.

Этот JavaScript‑код показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Изменить тип файла на ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется превью в виде изображения значка. Это превью видят пользователи перед доступом к объекту. Если необходимо использовать определённое изображение и текст в превью, вы можете задать изображение значка и заголовок с помощью Aspose.Slides for Node.js via Java.

Этот JavaScript‑код показывает, как установить изображение значка и заголовок для встроенного объекта:

```javascript
const asposeSlides = require("aspose.slides.via.java");

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

## **Запрет изменения размера и позиции OLE‑фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑фрейма, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, вызовите метод [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) класса [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) со значением `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Извлечение встроенных файлов**

Aspose.Slides for Node.js via Java позволяет извлекать файлы, встроенные в слайды как OLE‑объекты, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий OLE‑объекты, которые нужно извлечь.
2. Пройдитесь по всем формам презентации и получите доступ к формам [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Получите данные встроенных файлов из OLE‑фреймов и запишите их на диск.

Этот JavaScript‑код показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

То, что видно на слайде, будет отрисовано — значок/замещающее изображение (превью). «Живой» OLE‑контент не выполняется во время рендеринга. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

Чтобы также сохранить встроенный файл как вложение PDF, вызовите [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) со значением `true`. Эта опция отключена по умолчанию. Пример и инструкции по проверке вложения см. в разделе [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет блокировки на уровне формы. Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Будут ли относительные пути для связанных OLE‑объектов сохранены в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.
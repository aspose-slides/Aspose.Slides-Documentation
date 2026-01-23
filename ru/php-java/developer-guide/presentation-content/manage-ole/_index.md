---
title: Управление OLE в презентациях с помощью PHP
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "Оптимизируйте управление OLE объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Внедряйте, обновляйте и экспортируйте содержимое OLE без проблем."
---

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) — технология Microsoft, позволяющая помещать данные и объекты, созданные в одном приложении, в другое приложение с помощью связывания или внедрения. 
{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Диаграмма помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в соответствующем приложении (Excel) или предлагает выбрать приложение для открытия/редактирования объекта. 
- OLE‑объект может показывать своё содержимое, например содержимое диаграммы. Тогда диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑object frames ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Add OLE Object Frames to Slides**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑object frame с помощью Aspose.Slides for PHP via Java. Сделать это можно так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
1. Получите ссылку на слайд по его индексу.  
1. Прочитайте файл Excel как массив байтов.  
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) на слайд, указав массив байтов и другую информацию об OLE‑объекте.  
1. Сохраните изменённую презентацию в файл PPTX.  

В примере ниже мы добавили диаграмму из файла Excel на слайд как OLE‑object frame с помощью Aspose.Slides for PHP via Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.
```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


### **Add Linked OLE Object Frames**

Aspose.Slides for PHP via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) без внедрения данных, а только со ссылкой на файл.

Этот PHP‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайд:
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Добавить OLE объектный кадр со связанным файлом Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Access OLE Object Frames**

Если OLE‑объект уже внедрён в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд, используя его индекс.  
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма.  
4. После доступа к OLE‑object frame вы можете выполнить любую операцию над ним.  

В примере ниже демонстрируется доступ к OLE‑object frame (объект диаграммы Excel, внедрённый в слайд) и его файловым данным.
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Получить данные вложенного файла.
    // Получить расширение вложенного файла.
    // ...
}
```


### **Access Linked OLE Object Frame Properties**

Aspose.Slides позволяет получать свойства связанных OLE‑object frame.

Этот PHP‑код показывает, как проверить, является ли OLE‑объект связанным, и затем получить путь к связанному файлу:
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Проверить, связан ли OLE объект.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Вывести полный путь к связанному файлу.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Вывести относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```


## **Change OLE Object Data**

{{% alert color="primary" %}} 
В этом разделе пример кода использует [Aspose.Cells for PHP via Java](/cells/php-java/). 
{{% /alert %}} 

Если OLE‑объект уже внедрён в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма.  
4. После доступа к OLE‑object frame выполните любую требуемую операцию.  
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.  
6. Получите нужный `Worksheet` и измените данные.  
7. Сохраните обновлённый `Workbook` в поток.  
8. Замените данные OLE‑объекта из потока.  

В примере ниже показано, как получить доступ к OLE‑object frame (объект диаграммы Excel, внедрённый в слайд) и изменить его файловые данные для обновления данных диаграммы.
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Прочитать данные OLE‑объекта как объект Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Изменить данные workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Изменить данные объекта OLE‑кадра.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Embed Other File Types in Slides**

Помимо диаграмм Excel, Aspose.Slides for PHP via Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользовательского объекта он автоматически откроется в соответствующей программе, либо пользователю будет предложено выбрать подходящую программу для открытия.  

Этот PHP‑код показывает, как внедрить HTML и ZIP в слайд:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Set File Types for Embedded Objects**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for PHP via Java позволяет установить тип файла для внедрённого объекта, что даёт возможность обновить данные OLE‑frame или его расширение.  

Этот PHP‑код показывает, как установить тип файла для внедрённого OLE‑объекта как `zip`:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Изменить тип файла на ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Set Icon Images and Titles for Embedded Objects**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр виден пользователям до доступа к объекту. Если необходимо использовать конкретное изображение и текст в этом предварительном просмотре, можно задать изображение значка и заголовок с помощью Aspose.Slides for PHP via Java.  

Этот PHP‑код показывает, как задать изображение значка и заголовок для внедрённого объекта:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Добавить изображение в ресурсы презентации.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Установить заголовок и изображение для превью OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновления связей. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑object frame, так как PowerPoint обновляет данные из связанного OLE‑объекта и обновляет его превью. Чтобы предотвратить запрос PowerPoint о обновлении данных объекта, установите метод `setUpdateAutomatic` класса [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) в `false`:
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Extract Embedded Files**

Aspose.Slides for PHP via Java позволяет извлекать файлы, внедрённые в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) с OLE‑объектами, которые необходимо извлечь.  
2. Пройдите по всем формам презентации и получите формы [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).  
3. Получите данные встроенных файлов из OLE‑object frame и запишите их на диск.  

Этот PHP‑код показывает, как извлечь файлы, внедрённые в слайд как OLE‑объекты:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```


## **FAQ**

**Will the OLE content be rendered when exporting slides to PDF/images?**

То, что видно на слайде, будет отрендерено — значок/замещающее изображение (превью). «Живое» OLE‑содержимое при рендеринге не исполняется. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет блокировки на уровне формы. Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

В PPTX информация о «относительном пути» отсутствует — сохраняется только полный путь. Относительные пути встречаются в более старом формате PPT. Для переносимости рекомендуется использовать надёжные абсолютные пути/доступные URI или внедрение.
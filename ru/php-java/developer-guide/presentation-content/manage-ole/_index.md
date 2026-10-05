---
title: Управление OLE в презентациях с использованием PHP
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
description: "Оптимизируйте управление OLE‑объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Внедряйте, обновляйте и экспортируйте OLE‑контент без проблем."
---
## **Введение**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или внедрения. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае двойной щелчок по значку открывает диаграмму в связанном приложении (Excel) или запрашивает выбор приложения для открытия или редактирования объекта.
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides для PHP via Java](https://products.aspose.com/slides/php-java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑кадров объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд в виде OLE‑кадра объекта с использованием Aspose.Slides for PHP via Java. Делайте так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) на слайд, указав массив байтов и другую информацию об OLE‑объекте.
5. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде OLE‑кадра объекта, используя Aspose.Slides for PHP via Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) принимает расширение внедряемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия данного OLE‑объекта.

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

### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for PHP via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) без внедрения данных, а только со ссылкой на файл.

Этот PHP‑код показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) с привязанным файлом Excel на слайд:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Добавить OLE‑кадр объекта с привязанным файлом Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже внедрён в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к элементу формы [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В нашем примере использовался ранее созданный PPTX, содержащий единственную форму на первом слайде.
4. После получения доступа к OLE‑кадру вы можете выполнять любые операции с ним.

В примере ниже демонстрируется доступ к OLE‑кадру объекта (внедрённому объекту Excel‑диаграммы) и его файловым данным.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Получить данные внедрённого файла.
    // Получить расширение внедрённого файла.
    // ...
}
```

### **Доступ к свойствам связанного OLE‑кадра объекта**

Aspose.Slides позволяет получать свойства связанного OLE‑кадра объекта.

Этот PHP‑код показывает, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Проверить, связан ли OLE-объект.
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

## **Изменение данных OLE‑объекта**

{{% alert color="info" title="Note" %}}

В этом разделе приведён пример кода, использующий [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Доступ к элементу формы [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В примере использовался ранее созданный PPTX с одной формой на первом слайде.
4. После получения доступа к OLE‑кадру выполните нужные операции.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Доступ к требуемому `Worksheet` и изменение данных.
7. Сохраните обновлённый `Workbook` в поток.
8. Замените данные OLE‑объекта из потока.

В примере ниже OLE‑кадр объекта (внедрённый объект Excel‑диаграммы) открывается, и его файловые данные изменяются для обновления данных диаграммы.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Прочитать данные OLE‑объекта как объект Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Изменить данные книги.
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

## **Внедрение других типов файлов в слайды**

Помимо Excel‑диаграмм, Aspose.Slides for PHP via Java позволяет внедрять в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящую программу для открытия.

Этот PHP‑код демонстрирует, как внедрить HTML и ZIP в слайд:

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

## **Установка типов файлов для внедрённых объектов**

При работе с презентациями иногда требуется заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for PHP via Java позволяет задать тип файла для внедрённого объекта, что даёт возможность обновить данные OLE‑кадра или его расширение.

Этот PHP‑код показывает, как установить тип файла для внедрённого OLE‑объекта в `zip`:

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

## **Установка изображений‑значков и заголовков для внедрённых объектов**

После внедрения OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр виден пользователям до доступа к объекту. Если требуется использовать конкретное изображение и текст в качестве элементов предварительного просмотра, можно задать значок и заголовок с помощью Aspose.Slides for PHP via Java.

Этот PHP‑код демонстрирует, как задать изображение‑значок и заголовок для внедрённого объекта:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Добавить изображение в ресурсы презентации.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Предотвращение изменения размера и перемещения OLE‑кадра объекта**

После добавления связанного OLE‑объекта на слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет его предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, вызовите метод [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) класса [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) со значением `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Извлечение внедрённых файлов**

Aspose.Slides for PHP via Java позволяет извлекать файлы, внедрённые в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) с OLE‑объектами, которые необходимо извлечь.
2. Пройдитесь по всем формам в презентации и получите доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Получите данные внедрённых файлов из OLE‑кадров объектов и запишите их на диск.

Этот PHP‑код показывает, как извлечь файлы, внедрённые в слайд в виде OLE‑объектов:

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

**Будет ли OLE‑содержимое отображено при экспорте слайдов в PDF/изображения?**

При рендеринге отображается то, что видно на слайде — значок/заменяющее изображение (превью). «живое» OLE‑содержимое не исполняется во время рендеринга. При необходимости задайте своё превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

Чтобы также сохранить внедрённый файл в PDF как вложение, вызовите [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) со значением `true`. Эта опция отключена по умолчанию. Пример и инструкции по проверке вложения см. в статье [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет блокировки на уровне формы. Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или внедрение.
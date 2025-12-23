---
title: Управление OLE в презентациях с помощью PHP
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/php-java/manage-ole/
keywords:
- OLE объект
- Связывание и встраивание объектов
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
description: "Оптимизируйте управление OLE объектами в PowerPoint и OpenDocument файлах с помощью Aspose.Slides for PHP via Java. Внедряйте, обновляйте и экспортируйте OLE содержимое без проблем."
---


{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — Microsoft‑технология, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или встраивания. 

{{% /alert %}} 

Рассмотрите диаграмму, созданную в MS Excel. Диаграмма затем помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке значка диаграмма открывается в соответствующем приложении (Excel) или появляется запрос выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может отображать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается интерфейс диаграммы, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑рамок объектов ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑объектных рамок в слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как OLE‑рамку объекта с помощью Aspose.Slides for PHP via Java, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Получите ссылку на слайд по его индексу. 
3. Прочитайте файл Excel в виде массива байтов. 
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) на слайд, содержащий массив байтов и другую информацию об OLE‑объекте. 
5. Запишите изменённую презентацию в файл PPTX. 

В приведённом ниже примере мы добавили диаграмму из файла Excel на слайд в виде OLE‑рамки объекта с помощью Aspose.Slides for PHP via Java.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать нужное приложение для открытия этого OLE‑объекта.  
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


### **Добавление связанных OLE‑объектных рамок**

Aspose.Slides for PHP via Java позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/), не встраивая данные, а только с ссылкой на файл.  

Этот PHP‑код демонстрирует, как добавить [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) с связанным файлом Excel на слайд:  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Добавьте OLE‑рамку объекта со связанным файлом Excel.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Доступ к OLE‑объектным рамкам**

Если OLE‑объект уже встраивается в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встраиваемым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде только одна фигура. 
4. После получения доступа к OLE‑рамке объекта вы можете выполнять любые операции с ней.  

В приведённом ниже примере доступ получен к OLE‑рамке объекта (встроенному в слайд объекту диаграммы Excel) и её файловым данным.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Получить данные встроенного файла.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Получить расширение встроенного файла.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **Доступ к свойствам связанных OLE‑объектных рамок**

Aspose.Slides позволяет получить доступ к свойствам связанных OLE‑рамок объектов.  

Этот PHP‑код демонстрирует, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:  
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


## **Изменение данных OLE‑объекта**

{{% alert color="primary" %}} 

В этом разделе пример кода ниже использует [Aspose.Cells for PHP via Java](/cells/php-java/).  

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна фигура. 
4. После доступа к OLE‑рамке объекта вы можете выполнять любые операции с ней. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока.  

В приведённом ниже примере получен доступ к OLE‑рамке объекта (встроенному в слайд объекту диаграммы Excel), и её файловые данные изменяются для обновления данных диаграммы.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Считать данные OLE‑объекта как объект Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Изменить данные Workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Изменить данные объекта OLE‑рамки.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for PHP via Java позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для открытия.  

Этот PHP‑код демонстрирует, как встраивать HTML и ZIP в слайд:  
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


## **Установка типов файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for PHP via Java позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑рамки или её расширение.  

Этот PHP‑код демонстрирует, как установить тип файла для встроенного OLE‑объекта как `zip`:  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи перед доступом или открытием OLE‑объекта. Если необходимо использовать определённое изображение и текст в качестве элементов предварительного просмотра, можно задать изображение значка и заголовок с помощью Aspose.Slides for PHP via Java.  

Этот PHP‑код демонстрирует, как задать изображение значка и заголовок для встроенного объекта:  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Добавить изображение в ресурсы презентации.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Установить заголовок и изображение для предварительного просмотра OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Предотвращение изменения размера и перемещения OLE‑рамки объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновить ссылки. При нажатии кнопки «Update Links» размер и положение OLE‑рамки может измениться, так как PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите метод `setUpdateAutomatic` класса [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) в значение `false`:  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Извлечение встроенных файлов**

Aspose.Slides for PHP via Java позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) содержащий OLE‑объекты, которые вы планируете извлечь. 
2. Пройдитесь по всем фигурам в презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). 
3. Получите данные встроенных файлов из OLE‑рамок и запишите их на диск.  

Этот PHP‑код демонстрирует, как извлечь файлы, встроенные в слайд в виде OLE‑объектов:  
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

**Будет ли OLE‑контент отрисован при экспорте слайдов в PDF/изображения?**  
На экспортируемый слайд рендерится то, что видно — иконка/замещающее изображение (превью). «Живой» OLE‑контент при рендеринге не исполняется. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый внешний вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**  
Заблокируйте фигуру: Aspose.Slides предоставляет [блокировки на уровне фигур](/slides/ru/php-java/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**  
PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида следуйте рекомендациям [Working Solution for Worksheet Resizing](/slides/ru/php-java/working-solution-for-worksheet-resizing/) — либо подгоняйте рамку под диапазон, либо масштабируйте диапазон до фиксированной рамки и задавайте подходящее замещающее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**  
В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в более старом формате PPT. Для переносимости предпочтительно использовать надёжные абсолютные пути/доступные URI или встраивание.
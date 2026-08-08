---
title: Оптимизация управления изображениями в презентациях с использованием PHP
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/php-java/image/
keywords:
- добавить изображение
- добавить картинку
- добавить битмап
- заменить изображение
- заменить картинку
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- внешние ресурсы SVG
- разрешитель SVG
- связанные изображения SVG
- шрифты SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, повышая производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и визуально привлекательными. В Microsoft PowerPoint вы можете вставлять картинки на слайды из файлов, интернета или других источников. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды презентаций несколькими способами.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры —[JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение в виде рамки рисунка — особенно если планируете менять его размер, применять эффекты или использовать другие стандартные параметры форматирования — смотрите [Picture Frame](/slides/ru/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете конвертировать изображения из одного формата в другой. См. следующие страницы: конвертировать [image to JPG](https://products.aspose.com/slides/ru/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/ru/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/ru/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ru/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/ru/php-java/conversion/png-to-svg/), и [SVG to PNG](https://products.aspose.com/slides/ru/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает изображения в популярных форматах, таких как JPEG, PNG, BMP, GIF и другие. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений, хранящихся на вашем компьютере, в слайд презентации. Ниже приведён пример кода PHP, показывающий, как добавить изображение в слайд:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Добавление изображений из Интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, не хранится на вашем компьютере, его можно добавить непосредственно из Интернета. 

Ниже приведён пример кода PHP, показывающий, как добавить изображение из Интернета в слайд:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Добавление изображений в шаблоны слайдов**

Шаблон слайда (slide master) хранит и управляет информацией, такой как тема и макет для слайдов, использующих его. Когда вы добавляете изображение в шаблон слайда, оно отображается на каждом слайде, основанном на этом шаблоне. 

Ниже приведён пример кода PHP, показывающий, как добавить изображение в шаблон слайда:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Добавление изображений в качестве фона слайдов**

Вы можете использовать картинку в качестве фона для одного или нескольких слайдов. Подробности см. в *[Setting Images as Backgrounds for Slides](/slides/ru/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Содержимое SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/). Полученный объект SVG‑изображения затем можно добавить в коллекцию изображений презентации и использовать для создания рамки рисунка. 

Ниже приведён пример на PHP, импортирующий автономную строку SVG. Все изображения, стили и другие ресурсы, используемые этим SVG, встроены непосредственно в содержание SVG. 

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Импорт SVG‑содержимого с внешними ресурсами**

Файлы SVG, экспортированные из дизайнерских инструментов, редакторов диаграмм, систем иконок и веб‑конвейеров, могут ссылаться на ресурсы, хранящиеся вне документа SVG. Например, SVG может содержать ссылку на изображение вроде `images/photo.png`, значение CSS `url(...)` или URL шрифта. 

Чтобы импортировать такое SVG‑содержимое, создайте реализацию [ExternalResourceResolver](https://reference.aspose.com/slides/ru/php-java/aspose.slides/externalresourceresolver/) и передайте её вместе с базовым URI в соответствующий конструктор [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/). Базовый URI определяет местоположение документа SVG и используется для разрешения относительных ссылок. 

Объект SVG‑изображения предоставляет доступ к информации об импортированном SVG: 

- `getSvgContent()` возвращает разметку SVG в виде строки. 
- `getSvgData()` возвращает содержимое SVG в виде массива байтов. 
- `getBaseUri()` возвращает базовый URI, используемый для относительных ссылок. 
- `getExternalResourceResolver()` возвращает разрешитель, назначенный объекту SVG‑изображения. 

### **Реализация внешнего разрешителя ресурсов**

У разрешителя есть два метода: 

- `resolveUri` комбинирует базовый URI и относительную ссылку на ресурс и возвращает абсолютный URI. Возвращайте `null`, когда ссылка не может быть разрешена или не разрешена. 
- `getEntity` возвращает поток для чтения абсолютного URI ресурса. Возвращайте `null`, когда ресурс отсутствует, заблокирован или недоступен. При необходимости может быть возвращён запасной поток. 

Следующий разрешитель загружает связанные ресурсы только из разрешённого локального каталога. Сетевые ресурсы и пути за пределами разрешённого каталога блокируются. Для нерешённых ссылок на изображения возвращается опциональное запасное изображение. 

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Этот разрешитель намеренно допускает только локальные файлы.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Использовать запасной вариант только для графических ресурсов. Возврат потока изображения
            // для отсутствующего шрифта или таблицы стилей недопустим.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Разрешение связанных ресурсов при импорте SVG**

Предположим, что `assets/diagram.svg` содержит относительную ссылку, например: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ниже приведён пример на PHP, передающий URI SVG‑файла в качестве базового URI и предоставляющий собственный разрешитель. Разрешитель преобразует относительную ссылку на изображение в абсолютный URI и возвращает поток, содержащий связанный ресурс, пока Aspose.Slides обрабатывает SVG. 

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Базовый URI представляет местоположение документа SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Объект SVG‑изображения предоставляет исходное содержимое, бинарные данные, базовый URI и разрешитель.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Класс `SvgImage` также предоставляет перегрузки, принимающие данные SVG в виде массива байтов или входного потока, вместе с внешним разрешителем ресурсов и базовым URI. 

{{% alert title="Important" color="warning" %}}

Разрешитель ресурсов делает внешние ресурсы доступными, пока Aspose.Slides обрабатывает и рендерит SVG. Он не изменяет исходную разметку SVG и не встраивает автоматически разрешённые ресурсы в неё. 

Когда SVG‑изображение добавляется в коллекцию изображений презентации, файл PPTX может содержать как оригинальное представление SVG, так и растровое запасное изображение. Связанный ресурс может появиться в сгенерированном запасном изображении, тогда как относительная ссылка вроде `images/photo.png` остаётся неизменной в сохранённом SVG. Приложение, которое рендерит нативное представление SVG, может поэтому опустить связанное содержимое, если оригинальный внешний ресурс недоступен. 

{{% /alert %}}

### **Создание переносного SVG‑изображения**

Чтобы создать SVG‑изображение, не зависящее от внешних файлов, сделайте SVG автономным до создания `SvgImage`. Например, замените связанные URL‑адреса изображений на URI `data:`, содержащие данные изображения: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

После того как все необходимые ресурсы будут встроены в содержимое SVG, создайте `SvgImage`, добавьте его в коллекцию изображений презентации и вставьте в рамку рисунка, как показано в предыдущем примере. 

### **Обработка отсутствующих или заблокированных ресурсов**

Возвращайте `null` из `resolveUri`, когда URI ресурса недействителен, запрещён или не может быть разрешён. Возвращайте `null` из `getEntity`, когда ресурс не может быть прочитан. Aspose.Slides продолжает обработку SVG без этого ресурса, если это возможно. 

Для отсутствующего ресурса может быть возвращён запасной поток, но его содержимое должно соответствовать типу запрашиваемого ресурса. Например, возвращайте поток изображения только для отсутствующего изображения, а не для шрифта или таблицы стилей. 

{{% alert title="Security" color="warning" %}}

Не разрешайте произвольные пути к файлам или неограниченные сетевые URL из недоверенных SVG‑файлов. Ограничьте допустимые схемы, каталоги и хосты. Для сетевых ресурсов также применяйте тайм‑ауты соединения, ограничения размера ответа и проверку содержимого. 

{{% /alert %}}

## **Конвертация SVG в набор фигур**

Aspose.Slides может преобразовать SVG в набор фигур, аналогично соответствующей функции в PowerPoint: 

![PowerPoint Popup Menu](img_01_01.png)

Эта возможность предоставляется перегрузкой метода [addGroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addgroupshape/) класса [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/), который принимает объект [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/) в качестве первого аргумента. 

Ниже приведён пример кода PHP, демонстрирующий, как использовать этот метод для преобразования SVG‑файла в набор фигур: 

```php
// Имя файла исходного SVG.
$svgFileName = "sample.svg";

// Имя выходного файла презентации.
$outPptxPath = "presentation.pptx";

// Создать новую презентацию.
$presentation = new Presentation();
try {
    // Прочитать содержимое SVG‑файла.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Создать объект SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Получить размер слайда.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Преобразовать SVG‑изображение в группу фигур и масштабировать её до размера слайда.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Сохранить презентацию в формате PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Добавление изображений в формате EMF на слайды**

Aspose.Slides for PHP via Java позволяет создавать EMF‑изображения из листов Excel с помощью Aspose.Cells и добавлять их в слайды презентации. 

Ниже приведён пример кода PHP, показывающий, как это сделать: 

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Сохранить рабочую книгу в поток.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Добавить файл как есть, чтобы изображение оставалось векторным EMF, а не было растеризировано.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая изображения, используемые фигурами слайдов. В этом разделе описываются несколько способов обновления изображений в коллекции. Вы можете заменить изображение, используя необработанные байтовые данные, экземпляр [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) или другое изображение, уже существующее в коллекции. 

Выполните следующие шаги: 

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). 
1. Загрузите новое изображение из файла в массив байтов. 
1. Замените целевое изображение новым, используя массив байтов. 
1. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) и замените целевое изображение этим объектом. 
1. В третьем подходе замените целевое изображение изображением, уже существующим в коллекции изображений презентации. 
1. Сохраните изменённую презентацию в файл PPTX. 

```php
// Создать экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation("sample.pptx");
try {
    // Первый способ.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Второй способ.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Третий способ.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Сохранить презентацию в файл.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) вы можете легко анимировать текст и создавать GIF‑изображения из текста. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли исходное разрешение изображения после вставки?**  

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/php-java/picture-frame/) масштабируется на слайде и от любой компрессии, применяемой при сохранении.  

**Как лучший способ заменить один и тот же логотип сразу на десятках слайдов?**  

Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие этот ресурс.  

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**  

Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.  

**Как установить изображение в качестве фона сразу для нескольких слайдов?**  

[Назначьте изображение в качестве фона](/slides/ru/php-java/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.  

**Как предотвратить увеличение размера презентации из‑за большого количества изображений?**  

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте сжатие при сохранении и размещайте повторяющиеся графические элементы на мастер‑слайде, где это уместно.
---
title: Оптимизация управления изображениями в презентациях с использованием PHP
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/php-java/image/
keywords:
- добавить изображение
- добавить картинку
- заменить изображение
- коллекция изображений
- рамка изображения
- связанное изображение
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- SVG в фигуры
- внешние ресурсы SVG
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять, повторно использовать, связывать, заменять и управлять растровыми и SVG‑изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java."
---
## **Введение**

Aspose.Slides for PHP via Java предоставляет несколько способов работы с изображениями, и каждый из них служит своей цели. Вы можете хранить изображение в презентации, отображать его в рамке изображения, использовать его как фон слайда, связывать с внешним изображением, заменять общий ресурс изображения или преобразовывать содержимое SVG в редактируемые формы.

Эта статья посвящена ресурсам изображений и их использованию в презентации. Для обрезки, прозрачности, эффектов, растягивания и другого форматирования, применяемого к отдельной рамке изображения, см. [Рамка изображения](/slides/ru/php-java/picture-frame/).

## **Понимание модели изображений**

Следующие концепции API тесно связаны, но не взаимозаменяемы:

- [коллекция изображений презентации](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/) хранит ресурсы изображений, используемые в презентации. Используйте [ImageCollection::addImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/) для добавления данных изображения и получения ресурса [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).
- [рамка изображения](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) — это фигура, отображающая изображение на слайде, макете или шаблоне. Используйте [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/) для размещения ресурса изображения на слайде.
- Фон слайда использует изображение в качестве части заливки слайда, а не как фигуру. Поэтому он не ведет себя как рамка изображения.
- [PPImage::replaceImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Преобразование SVG в фигуры создает редактируемые фигуры слайда. После преобразования содержимое больше не управляется как один ресурс изображения.

Типичный рабочий процесс выглядит так: добавить данные изображения в коллекцию изображений, получить [PPImage], а затем использовать этот ресурс в одной или нескольких рамках изображения или заливках.

## **Добавление встроенного изображения**

Чтобы вставить локальное изображение, загрузите файл, добавьте его в коллекцию изображений и создайте рамку изображения, использующую возвращённый `PPImage`.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Изображение, добавленное таким образом, встраивается в презентацию, поэтому полученный файл не зависит от наличия исходного файла изображения.

### **Добавление изображения из сети**

Если изображение доступно по HTTP или HTTPS, загрузите его байты, добавьте их в коллекцию изображений презентации и используйте возвращённый ресурс изображения так же, как локальное изображение.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В длительно работающих приложениях переиспользуйте HTTP‑клиент или стратегию управления соединениями, подходящую для приложения, вместо многократного создания ненужной сетевой инфраструктуры. Также проверяйте удалённые URL‑адреса, размеры ответов и типы содержимого, если источник не доверенный.

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение необходимо более одного раза, добавьте его в презентацию один раз и переиспользуйте полученный [PPImage] при создании дополнительных рамок изображения. Это избавляет от многократной загрузки одних и тех же исходных данных и явно фиксирует связь между общим ресурсом изображения и его использованием.

Для графики, которая должна автоматически появляться на многих слайдах, например логотип компании, рассмотрите возможность размещения рамки изображения на [мастер слайда](/slides/ru/php-java/slide-master/) или макете вместо добавления эквивалентной фигуры на каждый слайд.

## **Использование изображения в качестве фона слайда**

Фоновое изображение присваивается заливке слайда; оно не добавляется как фигура рамки изображения. Это полезно, когда картинка должна покрывать фон слайда и не должна обрабатываться как обычный объект слайда.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Для дополнительных вариантов фона, включая фон мастера и макета, см. [Фон презентации](/slides/ru/php-java/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы по портативности и размеру файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация автономна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация хранит путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен оставаться доступным при открытии или рендеринге презентации.

Связанное изображение можно создать, назначив внешний путь или URL через [Picture::setLinkPathLong](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picture/) вместо встраивания данных изображения.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Используйте связанные изображения только тогда, когда среда развертывания может надёжно получить доступ к внешнему ресурсу. Для презентаций, которые должны работать офлайн или перемещаться между системами, встроенные изображения обычно безопаснее.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он полезен для значков, диаграмм и другой графики, которая должна масштабироваться без потери детализации, характерной для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения, так и как источник редактируемых фигур слайда.

### **Добавление SVG в качестве изображения**

Создайте [SvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgimage/), добавьте его в коллекцию изображений и разместите полученный ресурс изображения в рамке изображения.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG‑файлы с внешними ресурсами**

SVG может ссылаться на внешние изображения, таблицы стилей или шрифты. Для этих случаев [SvgImage] предоставляет конструкторы, принимающие [ExternalResourceResolver] и базовый URI. Резолвер может сопоставлять относительный URI с разрешённым абсолютным URI и возвращать поток для запрошенного ресурса.

Резолвер делает внешние ресурсы доступными, пока Aspose.Slides обрабатывает SVG, но не переписывает SVG в автономный документ. Если SVG должен оставаться портативным, внедрите необходимые ресурсы в сам SVG, например используя URI `data:` для связанных изображений.

Когда SVG‑файлы поступают из недоверенных источников, ограничьте схемы, расположения файлов и хосты, к которым резолвер может получить доступ. Сетевые резолверы также должны применять тайм‑ауты, ограничения размеров ответов и проверку содержимого.

### **Преобразование SVG в редактируемые фигуры**

Aspose.Slides может преобразовать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![Меню PowerPoint](img_01_01.png)

Используйте перегрузку [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addgroupshape/), принимающую [SvgImage], чтобы выполнить преобразование.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Применяйте преобразование SVG‑в‑фигуры, когда отдельные векторные элементы необходимо редактировать как фигуры PowerPoint. Если SVG нужно только отобразить, хранение его как изображения проще и избегает создания множества отдельных фигур.

## **Замена существующего ресурса изображения**

Используйте [PPImage::replaceImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/), когда необходимо заменить существующий ресурс изображения. Это особенно полезно для общих графических элементов, таких как логотипы.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если несколько рамок изображения, фоновых заливок, мастеров или макетов используют один и тот же ресурс изображения, замена этого ресурса обновит все его использования. Если нужно изменить только одну рамку изображения, назначьте ей другое изображение вместо замены общего ресурса.

`PPImage::replaceImage` также предоставляет перегрузки, принимающие массив байтов или другой [PPImage].

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут сделать презентацию неоправданно большой. Используйте исходные изображения с размерами, соответствующими их предполагаемому отображению, по возможности переиспользуйте общие ресурсы изображений и избегайте встраивания повторяющихся копий одного и того же графического элемента в полном разрешении.

Для растровых изображений, уже размещённых в рамках, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) может уменьшить данные изображения в соответствии с выбранным разрешением и параметрами обрезки. Это обработка рамки изображения, а не управление коллекцией изображений, поэтому см. [Рамка изображения](/slides/ru/php-java/picture-frame/).

### **Выбор между встроенным и связанным содержимым**

Встраивание делает презентацию портативной, поскольку все необходимые данные изображений находятся в файле. Связывание может уменьшить размер файла, но вводит внешнюю зависимость. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование общего брендинга**

Для повторяющихся логотипов, водяных знаков или декоративных графических элементов используйте один ресурс изображения и переиспользуйте его. Если графика относится к дизайну презентации, а не к содержимому слайда, разместите её на мастере или макете, чтобы она наследовалась соответствующими слайдами.

### **Соблюдение портативности SVG‑ресурсов**

Самодостаточный SVG легче перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности внедряйте необходимые ресурсы перед импортом SVG. Преобразуйте SVG в фигуры только тогда, когда отдельные векторные элементы необходимо редактировать.

### **Использование современного кроссплатформенного API изображений**

Для нового кода PHP via Java используйте API Aspose.Slides [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) и [Images](https://reference.aspose.com/slides/ru/php-java/aspose.slides/images/) вместо устаревшего публичного API, основанного на `java.awt.image.BufferedImage`. См. [Modern API](/slides/ru/php-java/modern-api/) для рекомендаций по миграции.

WMF и EMF требуют особого внимания. Когда эти форматы проходят через [IImage], [ImageCollection::addImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/) преобразует метафайл в растровое представление PNG перед вставкой. Если важно сохранить данные метафайла, используйте перегрузку [ImageCollection::addImage] на основе потока. Генерация содержимого EMF из электронных таблиц или других продуктов — отдельный процесс интеграции и выходит за рамки данной статьи.

## **Часто задаваемые вопросы**

**В чём разница между коллекцией изображений и рамкой изображения?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка изображения — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое для изображения форматирование, такое как обрезка и эффекты.

**Как лучше всего заменить один и тот же логотип везде?**

Если логотип уже используется как один ресурс изображения, замените этот ресурс с помощью [PPImage::replaceImage]. Для брендинга на уровне всей презентации размещение логотипа на мастере или макете также может уменьшить дублирование контента слайдов.

**Почему связанное изображение исчезает на другом компьютере?**

Связанное изображение зависит от внешнего файла или URL. Если этот ресурс недоступен с другого компьютера, связанное изображение может быть недоступно. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли отредактировать вставленный SVG как фигуры PowerPoint?**

Да. Преобразуйте SVG с помощью [ShapeCollection::addGroupShape]; полученная группа содержит редактируемые фигуры слайда, а не одну картинку SVG.

**Как можно уменьшить размер презентаций с большим количеством изображений?**

Переиспользуйте общие ресурсы изображений, избегайте ненужных больших растровых источников, по возможности сжимайте соответствующие растровые изображения, размещайте повторяющийся брендинг на мастерах или макетах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.
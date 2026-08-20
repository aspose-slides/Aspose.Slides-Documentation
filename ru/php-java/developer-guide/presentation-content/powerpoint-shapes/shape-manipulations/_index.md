---
title: Управление фигурами презентации в PHP
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/php-java/shape-manipulations/
keywords:
  - Фигура PowerPoint
  - Фигура презентации
  - Фигура на слайде
  - Найти фигуру
  - Клонировать фигуру
  - Удалить фигуру
  - Скрыть фигуру
  - Изменить порядок фигур
  - Получить ID интерапа фигуры
  - Альтернативный текст фигуры
  - Форматы макета фигуры
  - Фигура как SVG
  - Фигура в SVG
  - Выравнивание фигуры
  - Отразить фигуру
  - PowerPoint
  - Презентация
  - PHP
  - Aspose.Slides
description: "Узнайте, как идентифицировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides for PHP via Java представляет фигуры на слайде как упорядоченную [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/). Эта коллекция одновременно является местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала объясняется, как надежно идентифицировать фигуру, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. Заключительные разделы охватывают форматирование уровня макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Идентификация и поиск фигур**

Индексы коллекций удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигур может изменить их индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getname/) полезно для шаблонов, контролируемых разработчиком, и его легко просмотреть в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому при зависимости кода от них следует установить соглашение об именовании.
- [AlternativeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getalternativetext/) удобно, когда описание доступности или тег, добавленный автором, уже идентифицируют фигуру. Оно видимо пользователям, может быть локализовано или переписано для доступности и не гарантирует уникальность. Не переиспользуйте значимый текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getofficeinteropshapeid/) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный указатель в течение жизни фигуры. Клонированная или вновь созданная фигура — другая фигура и получает собственный ID.

Связанный метод [Shape::getUniqueId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getuniqueid/) возвращает идентификатор в пределах презентации, но он предназначен для надстроек и может быть переопределён. Не следует рассматривать его как постоянный внешний ключ. Если длительная идентичность важна, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по имени с точным сравнением и выводит ID интерапа в рамках слайда. Когда в шаблоне нет ожидаемой фигуры, код сообщает об этом результате вместо продолжения работы с неверным объектом.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Когда операция специфична для типа фигуры, проверьте класс во время выполнения перед использованием членов, специфичных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Модификация коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочения работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте опираться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/insertclone/) также создаёт копию, но размещает её по указанному индексу z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут изменять размер.

Пример создаёт слайд‑назначения, клонирует помеченный прямоугольник на передний план и вставляет второй клон в задний план. Изменения любого из клонов не влияют на исходную фигуру.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальны. Ресурсы, используемые сложными фигурами, управляются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[ShapeCollection::remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из его коллекции. При удалении нескольких совпадений во время итерации по индексам проходите от конца, чтобы каждый оставшийся индекс оставался валидным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает фигуру по текущему индексу, а не фиксированный элемент коллекции, и не приводит её к типу без необходимости.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

После удаления количество фигур и индексы последующих фигур изменяются. Ссылки на не затронутые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие элементы презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить больше, чем только внешний вид слайда.

### **Скрытие фигуры**

Установка [Shape::setHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/sethidden/) в `true` оставляет фигуру в коллекции, но предотвращает её отображение в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Скрытие — это не удаление и не защита. Объект всё ещё может быть найден и раскрыт пользователем или кодом и остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [ShapeCollection::reorder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний план; `size() - 1` — передний план.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сначала создаётся прямоугольник, который изначально находится за эллипсом. Перемещение его к последнему индексу помещает его спереди. Финализируйте Z‑порядок после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют или вставляют новые элементы коллекции и могут изменить ожидаемую стековую структуру.

## **Осмотр фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогичная по расположению фигура на обычном слайде. Осматривайте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример читает [FillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getfillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getlineformat/) каждой фигуры макета, не предполагая, что каждая фигура является `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Редактирование макета может затронуть несколько слайдов, которые используют его. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/writeassvg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не фон всего слайда или соседние фигуры.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Владелец потока обязан закрыть его.

## **Выравнивание фигур**

Перегрузки [SlideUtil::alignShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapesalignmenttype/) определяет край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы выравнивать по краям слайда; в `false` — чтобы выравнивать выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Выравнивание изменяет позиции, а не Z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, а горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения промежутков. Пересчитайте индексы, если изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращение. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/php-java/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает его, а `NotDefined` сохраняет неустановленное/значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

Пример сохраняет все остальные параметры кадра и заменяет только два параметра отражения. Это важно, потому что установка нового [Frame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/setframe/) заменяет весь кадр.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом сохраняются её позиция, размер и вращение.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции как идентификатор фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенный `Name` или конвенцию `AlternativeText` для шаблонов, либо `OfficeInteropShapeId` для работы с интерапом в рамках слайда.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клонированная фигура оказалась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что соответствует переднему плану Z‑порядка. Используйте `insertClone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.
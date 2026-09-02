---
title: Управление фигурами презентации в PHP
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/php-java/shape-manipulations/
keywords:
- фигура PowerPoint
- фигура презентации
- фигура на слайде
- найти фигуру
- клонировать фигуру
- удалить фигуру
- скрыть фигуру
- изменить порядок фигур
- получить ID фигуры interop
- альтернативный текст фигуры
- точка регулировки фигуры
- предустановленная регулировка фигуры
- геометрия фигуры
- форматы макета фигуры
- фигура как SVG
- фигура в SVG
- выравнить фигуру
- отразить фигуру
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java представляет фигуры на слайде как упорядоченную [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/). Коллекция является одновременно местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье используется эта модель. Сначала объясняется, как надёжно идентифицировать фигуру и изменить предустановленные точки регулировки, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. В последних разделах рассматриваются форматирование уровня макета, экспорт в SVG, выравнивание и параметры отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Идентификация и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются устойчивыми идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выбирайте идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getname/) полезен для шаблонов, контролируемых разработчиком, и легко просматривается в панели выделения PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому задайте соглашение об именовании, если код от них зависит.
- [AlternativeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getalternativetext/) полезен, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или изменено для доступности и также не гарантирует уникальность. Не переиспользуйте значимый текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getofficeinteropshapeid/) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный справочник в течение жизни фигуры. Клонированная или воссозданная фигура получает новый ID.

Связанный метод [Shape::getUniqueId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getuniqueid/) возвращает идентификатор в области презентации, но он предназначен для надстроек и может быть переименован. Его не следует рассматривать как постоянный внешний ключ. Если требуется долгосрочная идентификация, храните соответствие в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по имени с точным сравнением и выводит межоперационный ID в области слайда. Когда шаблон не содержит ожидаемой фигуры, код сообщает об этом результате, вместо того чтобы продолжать работать с неверным объектом.

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

Когда операция специфична для типа фигуры, проверьте класс во время выполнения перед использованием членов, характерных для типа. В этом примере обновляются текст и альтернативный текст только если названный объект является [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/).

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

## **Идентификация и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут иметь точки регулировки, контролирующие такие свойства, как размер углов, пропорции стрелки или углы дуги. Доступ к ним осуществляется через только для чтения коллекцию [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/geometryshape/#getAdjustments). Коллекция поставляется фигурой, но каждый [AdjustValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Перебирайте регулировки и проверяйте только для чтения метод [AdjustValue::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/#getType), значение [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapeadjustmenttype/) которого описывает, что контролирует регулировка. Метод только для чтения [AdjustValue::getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/getname/) даёт дополнительную идентификационную информацию и особенно полезен, когда предустановка содержит более одной регулировки с одинаковым семантическим типом.

Используйте метод значения, соответствующий смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер скруглённых углов | [setRawValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `setRawValue` |
| `ArrowheadLength` | Длина острия стрелки | `setRawValue` |
| `ArrowheadWidth` | Ширина острия стрелки | `setRawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Конечный угол сектора или дуги | `setAngleValue` |

`getType` и `getName` возвращают только читаемую информацию. `getRawValue` и `setRawValue` работают с целым числом в единицах геометрии предустановки, тогда как `getAngleValue` и `setAngleValue` работают с углом в градусах. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановленного [GeometryShape::getShapeType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/geometryshape/#getShapeType). Значение, допустимое для одной предустановки, может быть недопустимым или иметь иной эффект для другой.

Когда `getType` возвращает `ShapeAdjustmentType::Custom`, API не распознаёт стандартный семантический смысл. Проверьте `getName`, тип предустановки и текущее значение, и оставляйте регулировку неизменной, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверяйте, не встречается ли один и тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/php-java/connector/) демонстрирует эту ситуацию с регулировками изгиба соединителей.

Следующий полный пример создаёт стандартные и изменённые версии трёх предустановленных фигур. Он перебирает каждую регулировку, выводит её имя и тип, изменяет значения, связанные с размером, через `setRawValue`, меняет углы через `setAngleValue` и сохраняет результат. Левая колонка сохраняет стандартную геометрию; правая показывает скорректированный закруглённый прямоугольник, четырёхстороннюю стрелку и сектор.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить заголовки для столбцов фигур по умолчанию и изменённых
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Проверка семантического типа перед изменением значения делает код явным в своих намерениях и избавляет от предположения, что конкретный индекс коллекции имеет одинаковый смысл для разных предустановленных фигур.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают непосредственно с коллекцией. Если операция меняет количество или порядок фигур, не продолжавайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/insertclone/) также создаёт копию, но размещает её по указанному индексу z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут также изменять размер.

Пример создаёт целевой слайд, клонирует помеченный прямоугольник в переднюю часть и вставляет второй клон в заднюю. Изменения любого клона не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новым логическим идентификаторам клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентификацией фигуры.

### **Удаление фигур**

[ShapeCollection::remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам пройдите коллекцию в обратном порядке, чтобы каждый оставшийся индекс оставался валидным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает фигуру по текущему индексу, а не фиксированный элемент коллекции, и не принудительно кастует её тип.

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

После удаления количество фигур и индексы последующих фигур меняются. Ссылки на нетронутые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Shape::setHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/sethidden/) в `true` оставляет фигуру в коллекции, но запрещает её отображение в обычном слайдшоу. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

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

Скрытие — это не удаление и не безопасность. Объект по‑прежнему может быть найден и сделан видимым пользователем или кодом, и остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [ShapeCollection::reorder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `size() - 1` — передний.

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

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к конечному индексу помещает его спереди. Завершайте настройку z‑порядка после добавления или клонирования всех связанных фигур, потому что эти операции добавляют или вставляют новые элементы коллекции и могут изменить предполагаемую стековую структуру.

## **Просмотр фигур на макетных слайдах**

Обычные слайды, макетные слайды и мастер‑слайды имеют отдельные коллекции фигур. Фигура в коллекции макета — это не тот же объект, что аналогично расположенная фигура на обычном слайде. Проверяйте фигурки макета, когда нужно понять или изменить форматирование, задаваемое макетом.

Следующий пример читает у каждой макетной фигуры [FillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getfillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getlineformat/) без предположения, что каждая фигура является `AutoShape`.

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

Редактирование макета может повлиять на несколько слайдов, которые его используют. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/writeassvg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только фигуру, а не фон всего слайда или соседние фигуры.

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

Оставляйте презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и должна закрыть его.

## **Выравнивание фигур**

Перегрузки [SlideUtil::alignShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapesalignmenttype/) определяет край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

В этом примере три фигуры выравниваются по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

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

Выравнивание меняет позиции, а не z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения промежутков. Пересчитайте индексы, если вы модифицируете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapeframe/) хранит позицию, размер, горизонтальные и вертикальные настройки отражения и поворот. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/php-java/aspose.slides/nullablebool/): `True` — включает отражение, `False` — отключает, `NotDefined` — сохраняет неопределённое/значение по умолчанию.

Входящая презентация ниже содержит одну неотражённую фигуру.

![The shape before flipping](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что назначение нового [Frame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/setframe/) заменяет весь кадр.

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

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом позиция, размер и поворот остаются прежними.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции как идентификатор фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенный `Name` или конвенцию `AlternativeText` для шаблонов, созданных вручную, либо `OfficeInteropShapeId` для задач, связанных с interop в пределах слайда.

**Удаляется ли скрытая фигура из z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции под тем же индексом. Её можно найти, переупорядочить, отредактировать или вновь сделать видимой.

**Почему клон фигуры появился перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что является передним слоем z‑порядка. Используйте `insertClone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации регулировки предустановленной фигуры?**

Только после проверки точной предустановки и макета коллекции. Предпочтительно перебрать `GeometryShape::getAdjustments` и проверять `AdjustValue::getType`; используйте `AdjustValue::getName` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.
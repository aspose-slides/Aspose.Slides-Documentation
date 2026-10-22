---
title: Настройка фигур презентации в PHP
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/php-java/custom-shape/
keywords:
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
- путь геометрии
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java: пути геометрии, скруглённые углы, составные фигуры."
---
## **Обзор**

В этой статье объясняется, как настраивать фигуры в презентациях Aspose.Slides, редактируя геометрию фигур с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для изменения существующих фигур, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к фигуре.

Также демонстрируется, как создавать пользовательские и составные фигуры, строить фигуры со скруглёнными углами, определять, закрыта ли геометрия фигуры, исследовать элементы фигуры и преобразовывать контуры текста Java AWT в пути геометрии.

## **Изменение фигуры с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур фигуры или использовать существующую фигуру в качестве основы для новой.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

При редактировании фигур в PowerPoint учитывайте следующие концепции:

* Фигура (или её путь) может быть закрытой или открытой.
* Путь фигуры состоит из опорных точек, соединённых сегментами.
* Сегмент может быть прямым или изогнутым. Опорные точки и управляющие рычаги определяют его форму.
* Опорные точки бывают угловыми, прямыми или гладкими:
  * В угловой точке соединяющие сегменты могут встречаться под углом.
  * В гладкой точке два управляющих рычага выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке два управляющих рычага выровнены, но могут находиться на разном расстоянии от опорной точки.
* Перемещение опорных точек или корректировка их рычагов изменяет контур фигуры.

Для редактирования фигур PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) представляет путь геометрии объекта [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), можно использовать метод [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для фигуры, можно использовать следующие методы: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) для фигур с одним путём и [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) для фигур с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* С помощью методов [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) и [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) можно задать внешний вид пути геометрии.
* С помощью метода [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) в виде массива сегментов пути.
* Для доступа к дополнительным параметрам настройки геометрии фигуры можно прочитать [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через её [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести сегменты на [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) массива сегментов пути.

| Operation | Method |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной точкой. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Задать начальную точку фигуры. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Удалить сегмент по индексу, начиная с нуля. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Добавление пользовательских точек к фигуре**

В этом примере в прямоугольную фигуру вставляются две точки с помощью [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) и применяется отредактированный путь через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Координаты локальны относительно фигуры: обе новые точки находятся в её центре, на расстоянии 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, притягивая эти края внутрь.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Удаление точек из фигуры**

В этом примере контур в виде сердца изменяется удалением сегмента с нулевым индексом 2 с помощью [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Применение изменённого пути через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) обновляет контур фигуры.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Создание пользовательской фигуры**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и выемки; шаг в 72 градуса равномерно размещает пять вершин. Путь закрывается методом [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) и применяется к прямоугольной фигуре через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), заменяя её контур.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Создание составной пользовательской фигуры**

В этом примере определяются два замкнутых объекта [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для верхней и нижней трети фигуры. Применение обоих путей через [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну составную фигуру с зазором в средней трети.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Создание пользовательской фигуры со скруглёнными углами**

В этом примере комбинируются прямые сегменты с [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) для создания фигуры со скруглёнными внутрь углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а проход -90 градусов рисует дугу против часовой стрелки, представляющую четверть эллипса. Завершённый путь применяется через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), и презентация сохраняется в формате PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Определение, закрыта ли геометрия фигуры**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она считывает [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) и сравнивает последнюю команду сегмента с помощью [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) с [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Проверяется окончательная команда каждого пути; не анализируются все подфигуры внутри пути. Пример выводит `true` для прямоугольника.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Извлечение и проверка элементов фигуры**

Используйте [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) для просмотра существующей фигуры в виде элементов, содержащих точки пути и типы точек. Каждый возвращённый [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) используйте для получения массивов точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) и [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается файл input.pptx, находится первая геометрическая фигура на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую фигуру с прямыми и изогнутыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Сохранить тип сегмента, исключая флаги.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Массивы соответствуют по индексу: `$points[$i]` — точка, а `$types[$i]` описывает её роль. Тип `0` начинается фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается в предыдущей конечной точке и использует три последовательных элемента типа `3`: две управляющие точки и новую конечную точку. Цикл обрабатывает эти три записи вместе и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` используется для определения типа сегмента, а проверка `0x80` отдельно — для обнаружения закрытого подпути. Например, `129` (`0x81`) означает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую подпуть. PHP/Java Bridge возвращает массив байтов как бинарную строку; распаковка её с помощью "C*" дает беззнаковые байтовые значения. Маскирование сохраняет требуемые битовые значения. Сравнение сырого значения только с `1` или `3` упустит эти случаи. Другие флаги, такие как черта (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), при этом X увеличивается вправо, а Y — вниз. Для не сгруппированной фигуры извлечённые координаты уже включают позицию, полученную через [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) и [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY), и отражают её текущую ширину и высоту. Например, не повернутый прямоугольник с координатами `(100, 200)` и размерами `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию фигуры повторно. Вычтите её X и Y, чтобы получить координаты относительно её ненаправленного кадра.

Извлечённые точки не учитывают вращение фигуры, возвращаемое через [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), а также горизонтальные и вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования относительно центра фигуры. Для сгруппированных фигур также учитывайте сопоставление координат группы и её преобразования; не предполагайте, что извлечённые точки являются конечными координатами на слайде, и не применяйте трансляцию или масштаб дважды, если они уже учтены в кадре дочернего элемента.

**Проверка против редактирования.** Извлечённые массивы описывают контур; их изменение не обновляет исходную фигуру. Выбирайте этот подход, когда ваш код анализа или рисования требует массивов точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), когда нужны команды геометрии в локальной системе координат фигуры или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) или [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Преобразование Java AWT Shape в GeometryPath**

В этом примере комбинируется прямоугольный контур с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) контура отключает его заливку. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в виде [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) предоставляет операции перемещения, линии, квадратичной, кубической и закрывающей сегментов, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

В примере используется массив Java float, чтобы PHP/Java Bridge сохранял координаты, записанные итератором. Текст использует шрифт Arial размером 40 пунктов. Контур смещён на 20 пунктов по горизонтали и расположен так, что его визуальная верхняя часть находится на 10 пунктов ниже верхнего края фигуры. Путь текста заполнен, в то время как исходный прямоугольник остаётся контуром. Применение обоих путей через [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну фигуру, содержащую прямоугольник и текст.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую фигуру вместе с её геометрией?**

Используйте метод [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) фигуры; геометрия вращается вместе с фигурой, потому что она привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте нужную [slide](/slides/ru/php-java/convert-powerpoint-to-png/) область или саму [shape](/slides/ru/php-java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.
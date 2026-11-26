---
title: Настройка форм презентаций в PHP
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/php-java/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
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
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновленной геометрии обратно к форме.

Она также демонстрирует, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, закрыта ли геометрия формы, исследовать элементы формы и преобразовывать контуры текста Java AWT в пути геометрии.

## **Изменить форму с помощью точек редактирования**

В PowerPoint вы можете использовать **Точки редактирования**, чтобы изменить квадрат:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму как основу для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint удерживайте в уме следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из узловых точек, соединённых отрезками.
* Отрезок может быть прямым или изогнутым. Узловые точки и управляющие ручки определяют его форму.
* Узловые точки могут быть угловыми, прямыми или гладкими:
  * У угловой точки смежные отрезки могут встречаться под углом.
  * У гладкой точки две управляющие ручки выровнены и находятся на одинаковом расстоянии от узловой точки.
  * У прямой точки две управляющие ручки выровнены, но могут находиться на разном расстоянии от узловой точки.
* Перемещение узловых точек или настройка их ручек изменяет контур формы.

Для редактирования форм PowerPoint с помощью точек редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) представляет путь геометрии объекта [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), можно использовать метод [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы установить [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для формы, вы можете использовать эти методы: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) для форм с единственным путём и [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) для форм с несколькими путями.
* Чтобы добавить отрезки, можно использовать методы из [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* С помощью методов [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) и [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) можно задать внешний вид пути геометрии.
* С помощью метода [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) в виде массива отрезков пути.
* Для доступа к дополнительным параметрам настройки геометрии формы можно прочитать [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через её [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести отрезки на [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют отрезок в указанную позицию с нулевой базой в массиве отрезков пути.

| Operation | Method |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Закрыть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Установить начальную точку фигуры. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Удалить отрезок по индексу с нулевой базой. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Добавить пользовательские точки к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) и применяется отредактированный путь с помощью [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Координаты локальны относительно формы: обе новые точки находятся в её центре, на расстоянии 100 пунктов от левой стороны и 50 пунктов от верхней. Индексы отрезков 1 и 4 размещают их на верхних и нижних ребрах, притягивая эти ребра внутрь.

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

## **Удалить точки из формы**

В этом примере изменяется контур сердца, удаляя отрезок с нулевым индексом 2 с помощью [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Применение модифицированного пути с помощью [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) обновляет контур формы.

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

## **Создать пользовательскую форму**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и выемки; шаг 72 градуса равномерно распределяет пять вершин. Путь закрывается с помощью [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) и применяется к прямоугольной форме через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), заменяя её контур.

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

## **Создать составную пользовательскую форму**

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну составную форму с зазором в её средней трети.

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

## **Создать пользовательскую форму со скруглёнными углами**

В этом примере комбинируются прямые отрезки с [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) для создания формы со скруглёнными внутрь углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а sweep -90 градусов рисует эллипс четвертью против часовой стрелки. Завершённый путь применяется через [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), а презентация сохраняется в формате PPTX.

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

## **Узнать, закрыта ли геометрия формы**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим отрезком. Она читает [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) и сравнивает команду последнего отрезка [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) с [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Проверяется только конечная команда каждого пути; не просматриваются все подфигуры внутри пути. Пример выводит `true` для прямоугольника.

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

## **Исследовать команды пути геометрии**

Скачайте [contour.pptx](contour.pptx) и поместите его в рабочий каталог приложения. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой закрывающий край. Используйте [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) для чтения путей формы и [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) для чтения отрезков каждого пути в порядке рисования. Для каждого отрезка [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) определяет команду и указывает, как интерпретировать значения, возвращаемые [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

Форма расположена в точке (200, 100) пунктов на слайде. Сообщённые координаты локальны относительно формы, где (0, 0) находится в её верхнем левом углу, x растёт вправо, а y — вниз. Закрывающий отрезок возвращается к начальной точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Форма PowerPoint с прямым верхним ребром, изогнутым ребром от верхнего правого к нижнему левому и прямым левым ребром](contour.png)

## **Извлечь и исследовать элементы формы**

Используйте [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) для исследования существующей формы как элементов, содержащих точки пути и типы точек. Используйте каждый возвращённый [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) для получения массивов точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) и [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Такое представление удобно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается input.pptx, находится первая геометрическая форма непосредственно на первом слайде и выводятся её отрезки пути. Используйте презентацию, содержащую форму с прямыми и изогнутыми отрезками, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

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
                $pointType = $types[$i] & 0x07; // Сохранить тип отрезка, исключая флаги.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Использовать обе контрольные точки и конечную точку.
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

Массивы соответствуют по индексу: `$points[$i]` — точка, а `$types[$i]` описывает её роль. Тип `0` начинается фигура, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается с предыдущей конечной точки и использует три последовательных элемента типа `3`: две управляющие точки и новую конечную точку. Цикл обрабатывает эти три элемента вместе и проверяет конечную точку на закрытие.

Типы точек также содержат флаги. Маска `0x07` используется для определения типа отрезка, а тест `0x80` отдельно — для обнаружения закрытого подпути. Например, `129` (`0x81`) означает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую его. PHP/Java Bridge возвращает массив байтов как бинарную строку; распаковка с помощью "C*" даёт беззнаковые байтовые значения. Маскирование сохраняет требуемые битовые значения. Сравнение сырого значения только с `1` или `3` упустит эти случаи. Другие флаги, такие как штрих (`0x10`) и маркер (`0x20`), не меняют базовый тип отрезка.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для отдельной формы извлечённые координаты уже включают позицию, возвращаемую [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) и [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY), и отражают её текущую ширину и высоту. Например, неповернутый прямоугольник в `(100, 200)` с размерами `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её неповернутой рамки.

Извлечённые точки не учитывают вращение формы, получаемое через [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), или горизонтальные и вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте отображение координат группы и её преобразования; не предполагайте, что извлечённые точки являются окончательными координатами отрисованного слайда, и не применяйте трансляцию или масштаб дважды, если они уже учтены в кадре дочернего объекта.

**Исследование vs редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет оригинальную форму. Выбирайте этот подход, когда ваш анализ или код рисования нуждается в массивах точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), когда нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) или [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Преобразовать Java AWT Shape в GeometryPath**

В этом примере комбинируется прямоугольный контур с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) контура отключает его заливку. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) предоставляет перемещения, линии, квадратичные, кубические и закрывающие отрезки, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Пример использует массив Java float, чтобы PHP/Java Bridge сохранял координаты, записанные итератором. Текст использует шрифт Arial размером 40 пунктов. Контур сдвинут на 20 пунктов по горизонтали и расположен так, что его визуальная верхняя часть находится на 10 пунктов ниже верхнего края формы. Путь текста залит, в то время как оригинальный прямоугольник остаётся контуром. Применение обоих путей с помощью [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт единую форму, содержащую прямоугольник и текст.

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

Стиль остаётся у формы; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте метод [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) формы; геометрия вращается вместе с формой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте требуемую область [слайда](/slides/ru/php-java/convert-powerpoint-to-png/) или саму [форму](/slides/ru/php-java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.
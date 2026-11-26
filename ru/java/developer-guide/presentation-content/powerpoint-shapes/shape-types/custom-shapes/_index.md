---
title: Настройка форм презентаций в Java
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/java/custom-shape/
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
- Java
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для Java: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

В этой статье объясняется, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Также демонстрируется, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, закрыта ли геометрия формы, исследовать элементы формы и преобразовывать контуры текста Java AWT в пути геометрии.

## **Изменить форму с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменить контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из якорных точек, соединённых сегментами.
* Сегмент может быть прямым или изогнутым. Якорные точки и управляющие ручки определяют его форму.
* Якорные точки могут быть угловыми, прямыми или плавными:
  * В угловой точке прилежащие сегменты могут встречаться под углом.
  * В плавной точке две управляющие ручки выровнены и находятся на одинаковом расстоянии от якорной точки.
  * В прямой точке две управляющие ручки выровнены, но могут находиться на разном расстоянии от якорной точки.
* Перемещение якорных точек или регулировка их ручек изменяет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) представляет путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), можно использовать метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) для формы, можно использовать следующие методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) для форм с одним путём и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) для форм с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Используя методы [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), можно задать внешний вид пути геометрии.
* С помощью метода [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) в виде массива сегментов пути.
* Для доступа к дополнительным параметрам настройки геометрии формы можно прочитать [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести сегменты на [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) массива сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Закрыть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Установить начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Удалить сегмент по нулевому индексу. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Добавить пользовательские точки в форму**

Этот пример вставляет две точки в прямоугольную форму с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) и применяет отредактированный путь через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Координаты локальны для формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 помещают их на верхнюю и нижнюю границы, втягивая эти границы внутрь.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Удалить точки из формы**

Этот пример изменяет контур формы в виде сердца, удалив сегмент с нулевым индексом 2 с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Применение модифицированного пути через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) обновляет контур формы.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Создать пользовательскую форму**

Этот пример создаёт пятиконечную звезду с помощью [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и вогнутые части; шаг 72 градуса равномерно распределяет пять вершин. Путь закрывается с помощью [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) и применяется к прямоугольной форме через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), заменяя её контур.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Создать составную пользовательскую форму**

Этот пример определяет два закрытых [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) для верхней и нижней третьей части формы. Применение обоих путей через [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) создаёт одну составную форму с пробелом в её средней трети.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Создать пользовательскую форму со скруглёнными углами**

Этот пример сочетает прямые сегменты с [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) для создания формы со скруглёнными внутрь углами. Каждый размер угла задаёт ширину и высоту дуги в пунктах, а разворот ‑90° рисует против часовой стрелки четверть эллипса. Завершённый путь применяется через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), и презентация сохраняется в формате PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Определить, закрыта ли геометрия формы**

Следующий помощник проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Он читает [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) и сравнивает команду последнего сегмента [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) с [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Проверяется только конечная команда каждого пути; отдельные подфигуры внутри пути не анализируются. Пример выводит `true` для прямоугольника.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Исследовать команды пути геометрии**

Скачайте [contour.pptx](contour.pptx) и разместите его в рабочем каталоге приложения. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой закрывающий край. Используйте [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) для чтения путей формы и [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) для чтения сегментов каждого пути в порядке рисования. Для каждого сегмента [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) определяет команду и указывает, как интерпретировать значения, возвращаемые [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Форма расположена в точке (200, 100) пунктов на слайде. Сообщённые координаты локальны для формы, где (0, 0) — её левый верхний угол, X растёт вправо, а Y — вниз. Закрывающий сегмент возвращается к начальной точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```
![Форма PowerPoint с прямым верхним краем, изогнутым краем от верхнего правого к нижнему левому и прямым левым краем](contour.png)

## **Извлечь и исследовать элементы формы**

Используйте [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) для исследования существующей формы как элементов, содержащих точки пути и типы точек. Приведите каждый возвращённый [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) к типу [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/), чтобы получить массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) и [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

Пример открывает input.pptx, находит первую геометрическую форму непосредственно на первом слайде и выводит её сегменты пути. Используйте презентацию, содержащую форму с прямыми и изогнутыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Сохраняет тип сегмента, исключая флаги.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Потребляет обе контрольные точки и конечную точку.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Массивы согласованы по индексу: `points[i]` — точка, а `types[i]` — её роль. Тип `0` начинается фигура, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три подряд идущих типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три записи совместно и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` определяет тип сегмента, а отдельная проверка `0x80` выявляет закрытый подпуть. Например, `129` (`0x81`) — конечная точка линии, закрывающая подпуть, а `131` (`0x83`) — конечная точка Безье, закрывающая подпуть. Java хранит эти флаги в знаковых байтах; маскирование сохраняет intended битовые значения. Сравнение сырого значения только с `1` или `3` упустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают положение, возвращаемое [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) и [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--), и отражают её текущие ширину и высоту. Например, не повернутый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её неповернутой рамки.

Извлечённые точки не учитывают вращение формы, возвращаемое [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), а также горизонтальные и вертикальные отражения. Чтобы восстановить отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте отображение координат группы и её преобразования; не предполагайте, что извлечённые точки являются окончательными координатами отрисовки слайда, и не применяйте трансляцию или масштаб дважды, если они уже учтены в кадре дочернего элемента.

**Исследование против редактирования.** Извлечённые массивы описывают контур; изменение их не обновляет исходную форму. Выбирайте этот подход, когда ваш анализ или код рисования требуют массивов точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) когда нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) или [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Преобразовать Java AWT Shape в GeometryPath**

Этот пример сочетает прямоугольный контур с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) контура отключает его заливку. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) предоставляет сегменты перемещения, линии, квадратичной, кубической и закрывающей, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

Текст использует шрифт Arial 40 пунктов. Контур смещён на 20 пунктов по горизонтали и расположен так, чтобы визуальный верх был на 10 пунктов ниже верхнего края формы. Путь текста заполнен, тогда как исходный прямоугольник остаётся только контуром. Применение обоих путей через [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) создаёт одну форму, содержащую прямоугольник и текст.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Создать новую форму
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Получить путь геометрии формы
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Создать новый графический путь с текстом
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Преобразовать графический путь в путь геометрии
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Установить комбинацию нового пути геометрии и исходного пути геометрии для формы
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся у формы; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Используйте метод формы [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-); геометрия вращается вместе с формой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «закрепить» результат?**

Да. Экспортируйте требуемую [slide](/slides/ru/java/convert-powerpoint-to-png/) или саму [shape](/slides/ru/java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.
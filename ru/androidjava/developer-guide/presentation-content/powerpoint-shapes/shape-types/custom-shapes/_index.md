---
title: Настройка форм презентаций на Android
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для Android на Java: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

В этой статье объясняется, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии к форме.

Также демонстрируется создание пользовательских и составных форм, построение форм со скруглёнными углами, определение, замкнута ли геометрия формы, и исследование элементов формы с помощью массивов точек Android.

## **Изменение формы с помощью точек редактирования**

В PowerPoint можно использовать **Точки редактирования** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменить контур формы или использовать существующую форму как основу для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из опорных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Его форму определяют опорные точки и управляющие рычаги.
* Опорные точки бывают угловыми, прямыми или плавными:
  * В угловой точке смежные сегменты могут встречаться под углом.
  * В плавной точке два управляющих рычага выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке два управляющих рычага выровнены, но могут находиться на разном расстоянии от опорной точки.
* Перемещение опорных точек или изменение их рычагов меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) представляет путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), используйте метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) для формы, используйте методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) для форм с единственным путём и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) для форм с несколькими путями.
* Чтобы добавить сегменты, используйте методы интерфейса [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) .
* С помощью методов [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) можно задать внешний вид пути геометрии.
* Метод [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) позволяет получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) в виде массива сегментов пути.

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Добавить эллиптическую дугу с заданными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Задать начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Удалить сегмент по нулевому индексу. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Добавление пользовательских точек в форму**

В этом примере в прямоугольную форму вставляются две точки с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) и применяют отредактированный путь через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) . Координаты задаются относительно формы: обе новые точки находятся в её центре, в 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, вытягивая эти края внутрь.

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

## **Удаление точек из формы**

В этом примере контур формы в виде сердца изменяется удалением сегмента с нулевым индексом 2 с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) . Применение изменённого пути через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) обновляет контур формы.

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

## **Создание пользовательской формы**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) . Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и вмятины; шаг 72 градуса равномерно размещает пять вершин. Путь замыкается методом [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) и применяется к прямоугольной форме через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) , заменяя её контур.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **Создание составной пользовательской формы**

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) создаёт одну составную форму с разрывом в её средней трети.

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

## **Создание пользовательской формы со скруглёнными углами**

В этом примере прямые сегменты комбинируются с [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) для создания формы со внутренно‑изгибанными углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а sweep ‑90 ° рисует контрчасовую четверть эллипса. Готовый путь применяется через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) , а презентация сохраняется в формате PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **Определение, закрыта ли геометрия формы**

Следующий вспомогательный код проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Он читает [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) и сравнивает команду последнего сегмента [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) с [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) . Возвращает false, если нет непустых путей. Проверка охватывает только конечную команду каждого пути; она не анализирует каждую подпостфикцию внутри пути. Пример выводит `true` для прямоугольника.

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

## **Исследование команд пути геометрии**

Скачайте [contour.pptx](contour.pptx) и замените примерное имя файла на путь к нему на устройстве. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой замыкающий край. Используйте [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) для чтения путей формы и [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) для чтения сегментов каждого пути в порядке рисования. Для каждого сегмента метод [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) определяет команду и позволяет понять, как интерпретировать значения, возвращаемые [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) .

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

Форма располагается в точке (200, 100) на слайде. Сообщаемые координаты локальны для формы, где (0, 0) — её верхний‑левый угол, ось X растёт вправо, а ось Y — вниз. Замыкающий сегмент возвращается к стартовой точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Извлечение и анализ элементов формы**

Используйте [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) для получения существующей формы как набора элементов, содержащих точки пути и типы точек. Приведите каждый возвращённый [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) к типу [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) и получите массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) и [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Такое представление удобно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

Пример открывает input.pptx, находит первую форму геометрии непосредственно на первом слайде и выводит её сегменты пути. Используйте презентацию, содержащую форму с прямыми и изогнутыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Сохраняйте тип сегмента, исключая флаги.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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


Массивы синхронны по индексу: `points[i]` — точка, `types[i]` — её роль. Тип `0` начинается фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных типа `3`: две управляющие точки и новую конечную точку. Цикл обрабатывает эти три записи совместно и проверяет конечную точку на замыкание.

Типы точек также могут содержать флаги. Маска `0x07` определяет тип сегмента, а бит `0x80` отдельно указывает закрытый подпуть. Например, `129` (`0x81`) — конец линии, закрывающий подпуть, а `131` (`0x83`) — конец кривой Безье, закрывающий подпуть. Java хранит эти флаги в знаковых байтах; маскирование сохраняет нужные битовые значения. Сравнение чистого значения только с `1` или `3` пропустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), ось X растёт вправо, ось Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают позицию, возвращаемую [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) и [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) , и отражают её текущую ширину и высоту. Например, не повернутый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её неповоротного кадра.

Извлечённые точки не учитывают вращение формы, возвращаемое [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) , а также горизонтальное и вертикальное отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте отображение координат группы и её преобразования; не полагайте, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштабирование дважды, если они уже учтены в кадре дочернего элемента.

**Анализ vs. редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет исходную форму. Выбирайте такой подход, когда ваш анализ или код рисования требует массивов точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) , когда нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) или [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **FAQ**

**Что произойдёт с заливкой и конуром после замены геометрии?**

Стиль остаётся привязанным к форме; меняется только контур. Заливка и обводка автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Вызовите метод формы [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) ; геометрия вращается вместе с формой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужный [slide](/slides/ru/androidjava/convert-powerpoint-to-png/) или саму [shape](/slides/ru/androidjava/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.
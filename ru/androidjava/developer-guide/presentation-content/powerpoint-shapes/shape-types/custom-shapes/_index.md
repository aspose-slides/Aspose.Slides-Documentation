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

В этой статье объясняется, как настраивать формы презентации в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) и [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Также демонстрируется, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, закрыта ли геометрия формы, и исследовать элементы формы, используя массивы точек Android.

## **Изменение формы с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из точек привязки, соединённых сегментами.
* Сегмент может быть прямым или кривым. Точки привязки и управляющие ручки определяют его форму.
* Точки привязки могут быть угловыми, прямыми или сглаженными точками:
  * В угловой точке смежные сегменты могут встречаться под углом.
  * В сглаженной точке две управляющие ручки выровнены и находятся на одинаковом расстоянии от точки привязки.
  * В прямой точке две управляющие ручки выровнены, но могут находиться на разном расстоянии от точки привязки.
* Перемещение точек привязки или настройка их ручек изменяет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) и интерфейс [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) представляет путь геометрии объекта [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) из экземпляра [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), можно использовать метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) для формы, можно использовать следующие методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) для форм с единственным путём и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) для форм с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* С помощью методов [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) можно задать внешний вид пути геометрии.
* С помощью метода [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) в виде массива сегментов пути.

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в позицию с нулевым базовым индексом в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Установить начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Удалить сегмент по индексу, начинающемуся с нуля. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Добавление пользовательских точек к форме**

Этот пример вставляет две точки в прямоугольную форму с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) и применяет отредактированный путь с помощью [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Координаты относятся к локальным координатам формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, втягивая эти края внутрь.

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

В этом примере изменяется контур сердцевидной формы путём удаления сегмента с нулевым базовым индексом 2 с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Применение изменённого пути с помощью [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) обновляет контур формы.

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

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют кончики и впадины; шаг 72 градуса равномерно размещает пять кончиков. Путь замыкается с помощью [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) и применяется к прямоугольной форме через [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), заменяя её контур.

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

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей с помощью [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) создаёт единую составную форму с промежутком через её среднюю треть.

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

В этом примере соединяются прямые сегменты с [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) для создания формы со внутренно‑изогнутыми углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а sweep -90 градусов рисует контр‑часовой четверть эллипса. Готовый путь применяется с помощью [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), и презентация сохраняется в формате PPTX.

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

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она читает [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) и сравнивает команду последнего сегмента [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) с [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Функция проверяет только конечную команду каждого пути; она не исследует каждую субфигуру внутри пути. Пример выводит `true` для прямоугольника.

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

## **Извлечение и проверка элементов формы**

Используйте [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) для исследования существующей формы как элементов, содержащих точки пути и типы точек. Приведите каждый возвращённый [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) к [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/), чтобы получить массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) и [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается input.pptx, находится первая геометрическая форма непосредственно на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не проводится.

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
                int pointType = types[i] & 0x07; // Сохранить тип сегмента, исключая флаги.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Потреблять обе контрольные точки и конечную точку.
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

Массивы соответствуют по индексу: `points[i]` — точка, а `types[i]` описывает её роль. Тип `0` начинается фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается в предыдущем конечном пункте и использует три последовательных элемента типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три элемента вместе и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` используется для определения типа сегмента, а `0x80` проверяется отдельно для обнаружения закрытого подпути. Например, `129` (`0x81`) обозначает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую его. Java хранит эти флаги в знаковых байтах; маскирование сохраняет ожидаемые битовые значения. Сравнение сырого значения только с `1` или `3` пропустит такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X увеличивается вправо, Y — вниз. Для отдельной формы извлечённые координаты уже включают позицию, возвращаемую методами [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) и [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--), и отражают её текущие ширину и высоту. Например, необращенный прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её необращённого кадра.

Извлечённые точки не учитывают вращение формы, возвращаемое [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), или горизонтальное и вертикальное отражения. Чтобы воссоздать отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте преобразования и координатное отображение группы; не полагайтесь, что извлечённые точки являются окончательными координатами отрисовки слайда, и не применяйте трансляцию или масштабирование дважды, если они уже учтены в кадре дочернего элемента.

**Проверка vs редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет оригинальную форму. Выбирайте этот подход, когда ваш аналитический или рисующий код требует массивов точка/тип. Используйте [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) , если нужны команды геометрии в локальной системе координат формы или требуется редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) или [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**  
Стиль остаётся привязанным к форме; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**  
Используйте метод формы [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-), геометрия будет вращаться вместе с формой, поскольку привязана к её собственной системе координат.

**Могу ли я преобразовать пользовательскую форму в изображение, чтобы "зафиксировать" результат?**  
Да. Экспортируйте нужную область [слайд](/slides/ru/androidjava/convert-powerpoint-to-png/) или саму [форму](/slides/ru/androidjava/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.
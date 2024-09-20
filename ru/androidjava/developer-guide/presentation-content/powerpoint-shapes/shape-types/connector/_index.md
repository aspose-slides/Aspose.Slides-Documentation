---
title: Соединитель
type: docs
weight: 10
url: /androidjava/connector/
keywords: "Соединить фигуры, соединители, фигуры PowerPoint, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Соединить фигуры PowerPoint на Java"
---

Соединитель в PowerPoint — это специальная линия, которая соединяет или связывает две фигуры и остается прикрепленной к фигурам, даже когда они перемещаются или reposition на данном слайде.

Соединители обычно подключены к *точкам соединения* (зеленые точки), которые по умолчанию существуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только на определенных соединителях, используются для изменения положения и формы соединителей.

## **Типы Соединителей**

В PowerPoint вы можете использовать прямые, угловые и изогнутые соединители.

Aspose.Slides предоставляет следующие соединители:

| Соединитель                     | Изображение                                                  | Количество точек регулировки |
| ------------------------------- | ------------------------------------------------------------ | ----------------------------- |
| `ShapeType.Line`                | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                             |
| `ShapeType.StraightConnector1`  | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                             |
| `ShapeType.BentConnector2`      | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                             |
| `ShapeType.BentConnector3`      | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                             |
| `ShapeType.BentConnector4`      | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                             |
| `ShapeType.BentConnector5`      | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                             |
| `ShapeType.CurvedConnector2`    | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                             |
| `ShapeType.CurvedConnector3`    | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                             |
| `ShapeType.CurvedConnector4`    | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                             |
| `ShapeType.CurvedConnector5`    | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                             |

## **Соедините Фигуры С Помощью Соединителей**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, доступный через объект `Shapes`.
1. Добавьте соединитель, используя метод `addConnector`, доступный через объект `Shapes`, определив тип соединителя.
1. Соедините фигуры с помощью соединителя.
1. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить соединитель (изогнутый соединитель) между двумя фигурами (эллипсом и прямоугольником):

```Java
// Создает экземпляр класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Добавляет эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Добавляет форму соединителя в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Соединяет фигуры с помощью соединителя
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Вызывает reroute, устанавливающий автоматический кратчайший путь между фигурами
    connector.reroute();
    
    // Сохраняет презентацию
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Метод `Connector.reroute` перенастраивает соединитель и заставляет его занимать кратчайший возможный путь между фигурами. Для достижения своей цели метод может изменить точки `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex`.

{{% /alert %}}

## **Укажите Точку Соединения**

Если вы хотите, чтобы соединитель связывал две фигуры, используя конкретные точки на фигурах, вам нужно указать желаемые точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, доступный через объект `Shapes`.
1. Добавьте соединитель, используя метод `addConnector`, доступный через объект `Shapes`, определив тип соединителя.
1. Соедините фигуры с помощью соединителя.
1. Установите желаемые точки соединения на фигурах.
1. Сохраните презентацию.

Этот код на Java демонстрирует операцию, в которой указывается желаемая точка соединения:

```java
// Создает экземпляр класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Добавляет эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму соединителя в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Соединяет фигуры с помощью соединителя
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Устанавливает индекс желаемой точки соединения на фигуре Эллипс
    int wantedIndex = 6;

    // Проверяет, меньше ли желаемый индекс максимального количества индексов соединения
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Устанавливает желаемую точку соединения на эллипсе
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Сохраняет презентацию
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Регулировка Точки Соединителя**

Вы можете регулировать существующий соединитель через его точки регулировки. Только соединители с точками регулировки могут быть изменены таким образом. Смотрите таблицу в разделе **[Типы соединителей.](/slides/androidjava/connector/#types-of-connectors)**

#### **Простой Случай**

Рассмотрим случай, когда соединитель между двумя фигурами (A и B) проходит через третью фигуру (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Чтобы избежать или обойти третью фигуру, мы можем отрегулировать соединитель, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Сложные Случаи**

Для выполнения более сложных корректировок необходимо учитывать следующие моменты:

* Точка регулировки соединителя сильно связана с формулой, которая вычисляет и определяет ее позицию. Поэтому изменения в положении точки могут изменять форму соединителя.
* Точки регулировки соединителя определены в строгом порядке в массиве. Точки регулировки нумеруются от начальной точки соединителя до его конечной.
* Значения точек регулировки отражают процент ширины/высоты формы соединителя.
  * Форма ограничивается начальной и конечной точками соединителя, умноженными на 1000. 
  * Первая, вторая и третья точки определяют процент от ширины, процент от высоты и процент от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты точек регулировки соединителя, необходимо учитывать вращение соединителя и его отражение. **Примечание**: угол вращения для всех соединителей, указанных в разделе **[Типы соединителей](/slides/androidjava/connector/#types-of-connectors)**, составляет 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстового кадра связаны между собой через соединитель:

![connector-shape-complex](connector-shape-complex.png)

```java
// Создает экземпляр класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide sld = pres.getSlides().get_Item(0);
    // Добавляет фигуры, которые будут соединены через соединитель
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("От");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("К");
    // Добавляет соединитель
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Указывает направление соединителя
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Указывает цвет соединителя
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Указывает толщину линии соединителя
    connector.getLineFormat().setWidth(3);
    
    // Связывает фигуры вместе с помощью соединителя
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Получает точки регулировки для соединителя
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Регулировка**

Мы можем изменить значения точек регулировки соединителя, увеличив процент ширины и высоты на 20% и 200% соответственно:

```java
// Изменяет значения точек регулировки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, которая позволит нам определить координаты и форму отдельных частей соединителя, давайте создадим фигуру, которая соответствует горизонтальному компоненту соединителя в точке connector.getAdjustments().get_Item(0):

```java
// Рисует вертикальный компонент соединителя
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки соединителя, используя основные принципы. В обычных ситуациях необходимо учитывать вращение соединителя и его отображение (которые задаются параметрами connector.getRotation(), connector.getFrame().getFlipH(), и connector.getFrame().getFlipV()). Теперь мы продемонстрируем этот процесс.

Сначала добавим новый объект текстового кадра (**К 1**) на слайд (для целей соединения) и создадим новый (зеленый) соединитель, который связывает его с объектами, которые мы уже создали.

```java
// Создает новый связывающий объект
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("К 1");
// Создает новый соединитель
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Связывает объекты, используя вновь созданный соединитель
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Получает точки регулировки соединителя
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Изменяет значения точек регулировки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во-вторых, создадим фигуру, которая будет соответствовать горизонтальному компоненту соединителя, который проходит через новую точку регулировки соединителя connector.getAdjustments().get_Item(0). Мы будем использовать значения из данных соединителя для параметров connector.getRotation(), connector.getFrame().getFlipH(), и connector.getFrame().getFlipV() и применим популярную формулу преобразования координат для поворота вокруг данной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол объекта равен 90 градусам, и соединитель отображается вертикально, так что это соответствующий код:

```java
// Сохраняет координаты соединителя
x = connector.getX();
y = connector.getY();
// Корректирует координаты соединителя в случае появления
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Принимает значение точки регулировки как координату
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Определяет ширину горизонтального компонента с использованием второго значения точки регулировки
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчеты, связанные с простыми регулировками и сложными точками регулировки (точками регулировки с углами вращения). Используя полученные знания, вы можете разработать свою собственную модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек регулировки соединителя на основе конкретных координат слайда.

## **Найдите Угол Линий Соединителей**

1. Создайте экземпляр класса.
1. Получите ссылку на слайд по индексу.
1. Получите форму линии соединителя.
1. Используйте ширину линии, высоту, высоту рамки фигуры и ширину рамки фигуры, чтобы рассчитать угол.

Этот код на Java демонстрирует операцию, в которой мы рассчитали угол для формы линии соединителя:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```
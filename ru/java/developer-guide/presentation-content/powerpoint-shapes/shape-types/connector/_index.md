---
title: Коннектор
type: docs
weight: 10
url: /java/connector/
keywords: "Связывайте фигуры, коннекторы, фигуры PowerPoint, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Связывайте фигуры PowerPoint на Java"
---

Коннектор PowerPoint — это специальная линия, которая соединяет или связывает две фигуры вместе и остается прикрепленной к фигурам, даже когда они перемещаются или изменяются на данном слайде.

Коннекторы обычно подключены к *точкам соединения* (зелёные точки), которые по умолчанию существуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки настройки* (оранжевые точки), которые существуют только на определённых коннекторах, используются для изменения позиций и форм коннекторов.

## **Типы Коннекторов**

В PowerPoint вы можете использовать прямые, угловые (с наклоном) и изогнутые коннекторы.

Aspose.Slides предоставляет эти коннекторы:

| Коннектор                       | Изображение                                                   | Количество контрольных точек |
| ------------------------------- | ------------------------------------------------------------- | ----------------------------- |
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

## **Связывание фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) на слайд с помощью метода `addAutoShape`, предоставленного объектом `Shapes`.
1. Добавьте коннектор с помощью метода `addConnector`, предоставленного объектом `Shapes`, определив тип коннектора.
1. Свяжите фигуры с помощью коннектора.
1. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипсом и прямоугольником):

```Java
// Создает экземпляр класса презентации, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Добавляет эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Добавляет форму коннектора в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Соединяет фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Вызывает reroute, который устанавливает автоматический кратчайший путь между фигурами
    connector.reroute();
    
    // Сохраняет презентацию
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Метод `Connector.reroute` перенаправляет коннектор и заставляет его занять кратчайший возможный путь между фигурами. Для достижения своей цели метод может изменить точки `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex`.

{{% /alert %}} 

## **Укажите точку соединения**

Если вы хотите, чтобы коннектор связывал две фигуры, используя конкретные точки на фигурах, вы должны указать ваши предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) на слайд с помощью метода `addAutoShape`, предоставленного объектом `Shapes`.
1. Добавьте коннектор с помощью метода `addConnector`, предоставленного объектом `Shapes`, определив тип коннектора.
1. Свяжите фигуры с помощью коннектора.
1. Установите свои предпочтительные точки соединения на фигурах.
1. Сохраните презентацию.

Этот код на Java демонстрирует операцию, в которой указана предпочитаемая точка соединения:

```java
// Создает экземпляр класса презентации, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Добавляет эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму коннектора в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Соединяет фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Устанавливает предпочитаемый индекс точки соединения на эллипсе
    int wantedIndex = 6;

    // Проверяет, меньше ли предпочитаемый индекс максимального количества индексов сайтов
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Устанавливает предпочитаемую точку соединения на эллипсе
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Сохраняет презентацию
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Настройка точки коннектора**

Вы можете настроить существующий коннектор через его точки настройки. Только коннекторы с точками настройки могут быть изменены таким образом. См. таблицу в разделе **[Типы коннекторов.](/slides/java/connector/#types-of-connectors)** 

#### **Простой случай**

Рассмотрим случай, когда коннектор между двумя фигурами (А и Б) проходит через третью фигуру (C):

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

Чтобы избежать или обойти третью фигуру, мы можем настроить коннектор, переместив его вертикальную линию влево таким образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Сложные случаи** 

Для выполнения более сложных настроек вам необходимо учитывать следующие вещи:

* Настройка точки коннектора тесно связана с формулой, которая вычисляет и определяет его позицию. Поэтому изменения в местоположении точки могут изменить форму коннектора.
* Точки настройки коннектора определяются в строгом порядке в массиве. Точки настройки нумеруются от начальной точки коннектора до его конечной.
* Значения точек настройки отражают процент ширины/высоты формы коннектора. 
  * Форма ограничена начальной и конечной точками коннектора, умноженными на 1000. 
  * Первая точка, вторая точка и третья точка определяют проценты от ширины, проценты от высоты и проценты от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты точек настройки коннектора, вам необходимо учитывать поворот коннектора и его отражение. **Примечание**: угол поворота для всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/java/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстовых рамок связаны друг с другом через коннектор:

![connector-shape-complex](connector-shape-complex.png)

```java
// Создает экземпляр класса презентации, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide sld = pres.getSlides().get_Item(0);
    // Добавляет фигуры, которые будут соединены через коннектор
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("Из");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("К");
    // Добавляет коннектор
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Указывает направление коннектора
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Указывает цвет коннектора
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Указывает толщину линии коннектора
    connector.getLineFormat().setWidth(3);
    
    // Связывает фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Получает точки настройки для коннектора
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Настройка**

Мы можем изменить значения точек настройки коннектора, увеличив соответствующий процент ширины и высоты на 20% и 200% соответственно:

```java
// Меняет значения точек настройки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, которая позволит нам определить координаты и форму отдельных частей коннектора, создадим фигуру, которая соответствует горизонтальному компоненту коннектора в точке connector.getAdjustments().get_Item(0):

```java
// Рисует вертикальный компонент коннектора
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию настройки коннектора, используя базовые принципы. В обычных ситуациях вам необходимо учитывать поворот коннектора и его отображение (которые устанавливаются методами connector.getRotation(), connector.getFrame().getFlipH(), и connector.getFrame().getFlipV()). Теперь мы продемонстрируем этот процесс.

Сначала добавим новый объект текстовой рамки (**К 1**) на слайд (для целей соединения) и создадим новый (зелёный) коннектор, который соединит его с уже созданными объектами.

```java
// Создает новый объект привязки
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("К 1");
// Создает новый коннектор
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Связывает объекты с помощью вновь созданного коннектора
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Получает точки настройки коннектора
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Меняет значения точек настройки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во-вторых, давайте создадим фигуру, которая будет соответствовать горизонтальному компоненту коннектора, который проходит через новую точку настройки коннектора connector.getAdjustments().get_Item(0). Мы будем использовать значения из данных коннектора для connector.getRotation(), connector.getFrame().getFlipH(), и connector.getFrame().getFlipV() и применим популярную формулу преобразования координат для вращения вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол поворота объекта составляет 90 градусов, и коннектор отображается вертикально, так что вот соответствующий код:

```java
// Сохраняет координаты коннектора
x = connector.getX();
y = connector.getY();
// Корректирует координаты коннектора в случае, если это необходимо
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Учитывает значение точки настройки в качестве координаты
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Определяет ширину горизонтального компонента, используя значение второй точки настройки
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, связанные с простыми настройками и сложными точками настройки (точками настройки с углами поворота). Используя полученные знания, вы можете разработать свою модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек настройки коннектора на основе определённых координат слайда.

## **Найти угол соединительных линий**

1. Создайте экземпляр класса.
1. Получите ссылку на слайд по его индексу.
1. Получите форму линии коннектора.
1. Используйте ширину линии, высоту, высоту формы и ширину формы, чтобы рассчитать угол.

Этот код на Java демонстрирует операцию, в которой мы рассчитали угол для формы линии коннектора:

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
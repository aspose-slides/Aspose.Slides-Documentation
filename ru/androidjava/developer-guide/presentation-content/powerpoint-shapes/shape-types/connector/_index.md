---
title: Управление коннекторами в презентациях на Android
linktitle: Коннектор
type: docs
weight: 10
url: /ru/androidjava/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- соединять фигуры
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Позвольте Java‑приложениям рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint на Android — получайте полный контроль над прямыми, угловыми и изогнутыми коннекторами."
---

Коннектор PowerPoint — это специальная линия, соединяющая две фигуры и остающаяся привязанной к фигурам даже при их перемещении или переустановке на слайде. 

Коннекторы обычно присоединяются к *точкам соединения* (зеленым точкам), которые присутствуют на всех фигурах по умолчанию. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только у некоторых коннекторов, используются для изменения положения и формы коннекторов.

## **Типы коннекторов**

В PowerPoint можно использовать прямые, сгибные (угловые) и изогнутые коннекторы. 

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор                      | Изображение                                                   | Количество точек регулировки |
| ------------------------------ | ------------------------------------------------------------- | ---------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                            |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                            |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                            |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                            |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                            |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                            |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                            |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                            |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                            |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                            |

## **Подключение фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, доступный через объект `Shapes`.
1. Добавьте коннектор, используя метод `addConnector` объекта `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора. 
1. Вызовите метод `reroute`, чтобы применить самый короткий путь соединения.
1. Сохраните презентацию. 

Этот Java‑код показывает, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипсом и прямоугольником):
```Java
// Создает объект презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Добавляет автодиаграмму Эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Добавляет автодиаграмму Прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Добавляет форму‑коннектор в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Соединяет фигуры с помощью коннектора
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


{{%  alert title="NOTE"  color="warning"   %}} 

Метод `Connector.reroute` перенастраивает коннектор и заставляет его занять самый короткий возможный путь между фигурами. Для достижения этой цели метод может изменить точки `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указание точки соединения**

Если вы хотите, чтобы коннектор связывал две фигуры через конкретные точки на фигурах, укажите желаемые точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, доступный через объект `Shapes`.
1. Добавьте коннектор, используя метод `addConnector` объекта `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора. 
1. Установите желаемые точки соединения на фигурах. 
1. Сохраните презентацию.

Этот Java‑код демонстрирует операцию, в которой задаётся предпочтительная точка соединения:
```java
// Создает объект класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Добавляет автофигуру Эллипс
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автофигуру Прямоугольник
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму‑коннектор в коллекцию фигур слайда
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Соединяет фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Устанавливает предпочтительный индекс точки соединения для фигуры Эллипс
    int wantedIndex = 6;

    // Проверяет, меньше ли предпочтительный индекс максимального количества точек соединения
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Устанавливает предпочтательную точку соединения для автофигуры Эллипс
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Сохраняет презентацию
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Регулировка точки коннектора**

Вы можете регулировать существующий коннектор через его точки регулировки. Только коннекторы с точками регулировки можно изменять таким образом. См. таблицу в разделе **[Типы коннекторов](/slides/ru/androidjava/connector/#types-of-connectors)**

### **Простой случай**

Рассмотрим случай, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

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


Чтобы избежать или обойти третью фигуру, мы можем отрегулировать коннектор, сместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Сложные случаи** 

Для выполнения более сложных регулировок необходимо учитывать следующее:

* Точка регулировки коннектора тесно связана с формулой, вычисляющей её положение. Поэтому изменение положения точки может изменить форму коннектора.  
* Точки регулировки коннектора определены в строгом порядке в массиве. Точки нумеруются от начальной до конечной точки коннектора.  
* Значения точек регулировки отражают процент от ширины/высоты фигуры коннектора.  
  * Фигура ограничена начальной и конечной точками коннектора, умноженными на 1000.  
  * Первая точка, вторая точка и третья точка определяют соответственно процент от ширины, процент от высоты и снова процент от ширины.  
* При вычислении координат точек регулировки необходимо учитывать вращение коннектора и его отражение. **Note** что угол вращения всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/ru/androidjava/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два текстовых кадра связаны друг с другом через коннектор:

![connector-shape-complex](connector-shape-complex.png)
```java
// Создает объект класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд в презентации
    ISlide sld = pres.getSlides().get_Item(0);
    // Добавляет фигуры, которые будут соединены коннектором
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Добавляет коннектор
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Указывает направление коннектора
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Указывает цвет коннектора
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Указывает толщину линии коннектора
    connector.getLineFormat().setWidth(3);
    
    // Связывает фигуры коннектором
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Получает точки регулировки коннектора
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**Adjustment**

Мы можем изменить значения точек регулировки коннектора, увеличив соответствующие процентные значения ширины и высоты на 20 % и 200 % соответственно:
```java
// Изменяет значения точек регулировки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую вычислить координаты и форму отдельных частей коннектора, создадим фигуру, соответствующую горизонтальной составляющей коннектора в точке `connector.getAdjustments().get_Item(0)`:
```java
// Рисует вертикальную составляющую коннектора
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки коннектора, используя базовые принципы. В обычных ситуациях необходимо учитывать вращение коннектора и его отображение (которые задаются методами `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV()`). Сейчас мы покажем процесс.

Сначала добавим новый текстовый кадр (**To 1**) на слайд (для целей соединения) и создадим новый (зеленый) коннектор, соединяющий его с уже созданными объектами.
```java
// Создаёт новый объект привязки
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Создаёт новый коннектор
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Соединяет объекты с помощью вновь созданного коннектора
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Получает точки регулировки коннектора
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Изменяет значения точек регулировки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Затем создадим фигуру, соответствующую горизонтальной составляющей коннектора, проходящей через новую точку регулировки `connector.getAdjustments().get_Item(0)`. Используем значения из данных коннектора для `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV()` и применим популярную формулу преобразования координат при вращении вокруг точки x₀:

X = (x — x₀) * cos(α) — (y — y₀) * sin(α) + x₀;

Y = (x — x₀) * sin(α) + (y — y₀) * cos(α) + y₀;

В нашем случае угол вращения объекта = 90°, а коннектор отображается вертикально, поэтому код выглядит так:
```java
// Сохраняет координаты коннектора
x = connector.getX();
y = connector.getY();
// Корректирует координаты коннектора, если это необходимо
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Берёт значение точки регулировки как координату
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Преобразует координаты, поскольку Sin(90) = 1 и Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Определяет ширину горизонтального компонента, используя значение второй точки регулировки
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, включающие простые регулировки и сложные точки регулировки (точки с углами вращения). Используя полученные знания, вы можете разработать собственную модель (или написать код) для получения объекта `GraphicsPath` или даже установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Нахождение угла линий коннектора**

1. Создайте экземпляр класса.
1. Получите ссылку на слайд по его индексу.
1. Доступ к форме линии коннектора.
1. Используйте ширину, высоту, высоту рамки фигуры и ширину рамки фигуры для вычисления угла.

Этот Java‑код демонстрирует операцию, в которой вычисляется угол линии коннектора:
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


## **FAQ**

**Как определить, может ли коннектор «приклеиться» к конкретной фигуре?**

Проверьте, предоставляет ли фигура [connection sites](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Если их нет или их количество равно 0, приклеивание недоступно; в этом случае используйте свободные концы и размещайте их вручную. Рекомендуется проверить количество сайтов перед привязкой.

**Что происходит с коннектором, если я удалю одну из соединённых фигур?**

Его концы будут отсоединены; коннектор останется на слайде как обычная линия со свободным началом/концом. Вы можете либо удалить его, либо переустановить соединения и, при необходимости, [reroute](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/#reroute--).

**Сохраняются ли привязки коннектора при копировании слайда в другую презентацию?**

Как правило, да, при условии, что связанные фигуры также копируются. Если слайд вставляется в другой файл без соединённых фигур, концы становятся свободными и их нужно будет снова прикрепить.
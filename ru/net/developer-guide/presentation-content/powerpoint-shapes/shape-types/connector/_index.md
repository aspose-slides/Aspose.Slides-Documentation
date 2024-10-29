---
title: Коннектор
type: docs
weight: 10
url: /ru/net/connector/
keywords: "Соединить фигуры, коннекторы, фигуры PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Соедините фигуры PowerPoint на C# или .NET"
---

Коннектор PowerPoint — это специальная линия, которая соединяет или связывает две фигуры и остается прикрепленной к фигурам, даже когда они перемещаются или изменяются на данном слайде.

Коннекторы обычно подключаются к *точкам подключения* (зелёные точки), которые по умолчанию существуют на всех фигурах. Точки подключения появляются, когда курсор приближается к ним.

*Регулировочные точки* (оранжевые точки), которые существуют только у определенных коннекторов, используются для изменения положения и формы коннекторов.

## **Типы Коннекторов**

В PowerPoint вы можете использовать прямые, угловые и изогнутые коннекторы.

Aspose.Slides предоставляет эти коннекторы:

| Коннектор                      | Изображение                                                   | Количество регулировочных точек |
| ------------------------------- | ------------------------------------------------------------- | ------------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                               |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                               |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                               |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                               |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                               |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                               |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                               |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                               |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                               |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                               |

## **Соединение Фигур С Помощью Коннекторов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд, используя метод `AddAutoShape`, предоставленный объектом `Shapes`.
1. Добавьте коннектор, используя метод `AddConnector`, предоставленный объектом `Shapes`, определив тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Вызовите метод `Reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Этот код на C# показывает, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипс и прямоугольник):

```c#
// Создает экземпляр класса презентации, представляющий файл PPTX
using (Presentation input = new Presentation())
{                
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Добавляет эллипс
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет коннектор в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Подключает фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Вызывает reroute, который устанавливает автоматический кратчайший путь между фигурами
    connector.Reroute();

    // Сохраняет презентацию
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Метод `Connector.Reroute` перенаправляет коннектор и заставляет его принять кратчайший возможный путь между фигурами. Чтобы достичь этой цели, метод может изменить индексы точек `StartShapeConnectionSiteIndex` и `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указать Точку Соединения**
Если вы хотите, чтобы коннектор соединял две фигуры с использованием конкретных точек на фигурах, вы должны указать свои предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд с использованием метода `AddAutoShape`, предоставленного объектом `Shapes`.
1. Добавьте коннектор, используя метод `AddConnector`, предоставленный объектом `Shapes`, определив тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Установите свои предпочтительные точки соединения на фигурах.
1. Сохраните презентацию.

Этот код на C# демонстрирует операцию, в которой указывается предпочитаемая точка соединения:

```c#
// Создает экземпляр класса презентации, представляющий файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Добавляет коннектор в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Добавляет эллипс
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет прямоугольник
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Соединяет фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Устанавливает индекс предпочитаемой точки соединения на фигуре Эллипс
    uint wantedIndex = 6;

    // Проверяет, меньше ли предпочитаемый индекс максимального количества индексов точек
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Устанавливает предпочитаемую точку соединения на Эллипсе
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Сохраняет презентацию
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Регулировка Точки Коннектора**

Вы можете отрегулировать существующий коннектор через его регулировочные точки. Только коннекторы с регулировочными точками могут быть изменены таким образом. Смотрите таблицу в разделе **[Типы коннекторов.](/slides/ru/net/connector/#types-of-connectors)** 

#### **Простой случай**

Рассмотрим случай, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

![connector-obstruction](connector-obstruction.png)

Код:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Чтобы избежать или обойти третью фигуру, мы можем отрегулировать коннектор, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Сложные случаи** 

Для выполнения более сложных корректировок вам необходимо учитывать следующие моменты:

* Регулируемая точка коннектора сильно связана с формулой, которая вычисляет и определяет ее положение. Поэтому изменения в расположении точки могут изменить форму коннектора.
* Регулирующие точки коннектора определены в строгом порядке в массиве. Регулирующие точки нумеруются от начальной точки коннектора к его конечной точке.
* Значения регулировочных точек отражают процент ширины/высоты формы коннектора.
  * Форма ограничена начальной и конечной точками коннектора, умноженными на 1000.
  * Первая точка, вторая точка и третья точка определяют процент от ширины, процент от высоты и процент от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты регулировочных точек коннектора, вам необходимо учитывать вращение коннектора и его отражение. **Обратите внимание**, что угол поворота для всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/ru/net/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстовой рамки соединены вместе через коннектор:

![connector-shape-complex](connector-shape-complex.png)

Код:

```c#
// Создает экземпляр класса презентации, представляющий файл PPTX
Presentation pres = new Presentation();
// Получает первый слайд в презентации
ISlide sld = pres.Slides[0];
// Добавляет фигуры, которые будут соединены через коннектор
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "От";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "К";
// Добавляет коннектор
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Указывает направление коннектора
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Указывает цвет коннектора
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Указывает толщину линии коннектора
connector.LineFormat.Width = 3;

// Соединяет фигуры с помощью коннектора
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Получает регулировочные точки для коннектора
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Регулировка**

Мы можем изменить значения регулировочных точек коннектора, увеличив соответствующий процент ширины и высоты на 20% и 200%, соответственно:

```c#
// Изменяет значения регулировочных точек
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, которая позволит нам определить координаты и форму отдельных частей коннектора, создадим фигуру, которая соответствует горизонтальному компоненту коннектора в точке connector.Adjustments[0]:

```c#
// Рисует вертикальный компонент коннектора

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки коннектора с использованием основных принципов. В обычных условиях вам нужно учитывать вращение коннектора и его отображение (которые устанавливаются через `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV`). Теперь мы продемонстрируем этот процесс.

Сначала давайте добавим новый объект текстовой рамки (**К 1**) на слайд (для соединительных целей) и создадим новый (зеленый) коннектор, который соединит его с уже созданными объектами.

```c#
// Создает новый объект привязки
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "К 1";
// Создает новый коннектор
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Соединяет объекты с помощью вновь созданного коннектора
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Получает регулировочные точки коннектора
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Изменяет значения регулировочных точек 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Затем давайте создадим фигуру, которая будет соответствовать горизонтальному компоненту коннектора, который проходит через новую регулировочную точку коннектора `connector.Adjustments[0]`. Мы будем использовать значения из данных коннектора для `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV` и применим популярную формулу преобразования координат для вращения вокруг данной точки `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта составляет 90 градусов, и коннектор отображается вертикально, поэтому соответствующий код такой:

```c#
// Сохраняет координаты коннектора
x = connector.X;
y = connector.Y;
// Корректирует координаты коннектора в случае, если он появляется
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Принимает значение регулировочной точки как координату
x += connector.Width * adjValue_0.RawValue / 100000;
//  Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Определяет ширину горизонтального компонента, используя значение второй регулировочной точки
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали вычисления, связанные с простыми корректировками и сложными регулировочными точками (регулировочные точки с углом вращения). Используя полученные знания, вы можете разработать свою собственную модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения регулировочной точки коннектора на основе конкретных координат слайда.

## **Найдите Угол Линий Коннектора**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Получите доступ к форме линии коннектора. 
1. Используйте ширину линии, высоту, высоту рамки фигуры и ширину рамки фигуры, чтобы рассчитать угол.

Этот код на C# демонстрирует операцию, в которой мы рассчитали угол для формы линии коннектора:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```
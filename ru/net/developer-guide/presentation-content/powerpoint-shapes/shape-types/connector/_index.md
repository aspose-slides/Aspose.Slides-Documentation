---
title: Управление коннекторами в презентациях на .NET
linktitle: Коннектор
type: docs
weight: 10
url: /ru/net/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- соединить формы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Позвольте приложениям .NET рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint — получайте полный контроль над прямыми, угловыми и кривыми коннекторами."
---

Коннектор PowerPoint — это специальная линия, которая соединяет две формы и остаётся привязанной к ним даже при перемещении или перестановке на слайде. 

Коннекторы обычно присоединяются к *точкам соединения* (зелёным точкам), которые присутствуют на всех формах по умолчанию. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только у некоторых коннекторов, используются для изменения положения и формы коннекторов.

## **Типы коннекторов**

В PowerPoint вы можете использовать прямые, уголковые (с изгибом) и кривые коннекторы. 

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор                      | Изображение                                                        | Количество точек регулировки |
| ------------------------------ | ----------------------------------------------------------------- | ---------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)          | 0                            |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                            |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)      | 0                            |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)        | 1                            |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)        | 2                            |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)        | 3                            |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png)    | 0                            |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png)    | 1                            |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png)    | 2                            |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png)    | 3                            |

## **Соединение фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд, вызвав метод `AddAutoShape` у объекта `Shapes`.
1. Добавьте коннектор, вызвав метод `AddConnector` у объекта `Shapes`, указав тип коннектора.
1. Соедините формы при помощи коннектора. 
1. Вызовите метод `Reroute`, чтобы применить самый короткий путь соединения.
1. Сохраните презентацию. 

Этот C#‑код показывает, как добавить коннектор (изогнутый коннектор) между двумя формами (эллипсом и прямоугольником):
```c#
// Создает экземпляр класса презентации, представляющий файл PPTX
using (Presentation input = new Presentation())
{                
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Добавляет автофигуру эллипса
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автофигуру прямоугольника
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму коннектора в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Связывает фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Вызывает Reroute, который устанавливает автоматический кратчайший путь между фигурами
    connector.Reroute();

    // Сохраняет презентацию
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Метод `Connector.Reroute` перенастраивает коннектор и заставляет его пройти по кратчайшему возможному пути между фигурами. Для достижения этой цели метод может изменить точки `StartShapeConnectionSiteIndex` и `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указание точки соединения**
Если необходимо, чтобы коннектор связывал две фигуры через определённые точки на этих фигурах, укажите предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд, вызвав метод `AddAutoShape` у объекта `Shapes`.
1. Добавьте коннектор, вызвав метод `AddConnector` у объекта `Shapes`, указав тип коннектора.
1. Соедините формы при помощи коннектора. 
1. Установите предпочтительные точки соединения на фигурах. 
1. Сохраните презентацию.

Этот C#‑код демонстрирует операцию, в которой задана предпочтительная точка соединения:
```c#
// Создает экземпляр класса презентации, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Добавляет форму коннектора в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Добавляет автофигуру эллипса
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автофигуру прямоугольника
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Связывает фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Устанавливает индекс предпочтительной точки соединения на фигуре Эллипс
    uint wantedIndex = 6;

    // Проверяет, что предпочтительный индекс меньше максимального количества точек соединения
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Устанавливает предпочтительную точку соединения на автофигуре Эллипс
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Сохраняет презентацию
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Регулировка точки коннектора**

Вы можете изменять существующий коннектор через его точки регулировки. Только коннекторы, имеющие такие точки, могут быть изменены таким способом. См. таблицу в разделе **[Types of connectors.](/slides/ru/net/connector/#types-of-connectors)** 

### **Простой случай**

Рассмотрим ситуацию, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

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


Чтобы избежать или обойти третью фигуру, можно сместить вертикальную линию коннектора влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **Сложные случаи** 

Для выполнения более сложных регулировок следует учитывать следующее:

* Точка регулировки коннектора тесно связана с формулой, вычисляющей её положение. Поэтому изменение координат точки может изменить форму коннектора.
* Точки регулировки коннектора определены в строгом порядке в массиве. Точки нумеруются от начальной до конечной.
* Значения точек регулировки отражают процент от ширины/высоты фигуры коннектора. 
  * Фигура ограничена начальной и конечной точками коннектора, умноженными на 1000. 
  * Первая, вторая и третья точки определяют соответственно процент от ширины, процент от высоты и снова процент от ширины.
* При расчёте координат точек регулировки необходимо учитывать вращение коннектора и его отражение. **Обратите внимание**, что угол вращения для всех коннекторов, показанных в разделе **[Types of connectors](/slides/ru/net/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два текстовых фрейма соединены между собой коннектором:

![connector-shape-complex](connector-shape-complex.png)

Код:
```c#
// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
// Получает первый слайд в презентации
ISlide sld = pres.Slides[0];
// Добавляет фигуры, которые будут соединены коннектором
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Добавляет коннектор
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Указывает направление коннектора
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Указывает цвет коннектора
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Указывает толщину линии коннектора
connector.LineFormat.Width = 3;

// Связывает фигуры вместе с помощью коннектора
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Получает точки регулировки коннектора
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Регулировка**

Можно изменить значения точек регулировки коннектора, увеличив соответствующие проценты ширины и высоты на 20 % и 200 % соответственно:
```c#
// Изменяет значения точек регулировки
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы построить модель, позволяющую определить координаты и форму отдельных частей коннектора, создадим фигуру, соответствующую горизонтальному компоненту коннектора в точке `connector.Adjustments[0]`:
```c#
// Рисует вертикальную составляющую коннектора

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку коннектора, используя базовые принципы. В обычных ситуациях необходимо учитывать вращение коннектора и его отображение (которые задаются свойствами `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV`). Сейчас покажем процесс.

Сначала добавим новый объект текстового фрейма (**To 1**) на слайд (для соединения) и создадим новый (зелёный) коннектор, связывающий его с уже созданными объектами.
```c#
// Создаёт новый объект привязки
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Создаёт новый коннектор
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Связывает объекты с помощью только что созданного коннектора
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Получает точки регулировки коннектора
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Изменяет значения точек регулировки
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```



Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Затем создадим фигуру, соответствующую горизонтальному компоненту коннектора, проходящего через новую точку регулировки `connector.Adjustments[0]`. Используем значения из данных коннектора `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV` и применим распространённую формулу преобразования координат при вращении вокруг точки x₀:

X = (x — x₀) * cos(alpha) — (y — y₀) * sin(alpha) + x₀;

Y = (x — x₀) * sin(alpha) + (y — y₀) * cos(alpha) + y₀;

В нашем случае угол вращения объекта = 90 °, а коннектор отображается вертикально, поэтому соответствующий код выглядит так:
```c#
// Сохраняет координаты коннектора
x = connector.X;
y = connector.Y;
// Корректирует координаты коннектора, если они смещены
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Принимает значение точки регулировки как координату
x += connector.Width * adjValue_0.RawValue / 100000;
//  Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Определяет ширину горизонтального компонента, используя значение второй точки регулировки
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```


Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, включающие простые и сложные точки регулировки (точки с углами вращения). Используя полученные знания, вы можете разработать свою модель (или написать код) для получения объекта `GraphicsPath` либо установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Определение угла линии коннектора**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к форме линии коннектора. 
1. Используйте ширину, высоту, высоту рамки формы и ширину рамки формы для расчёта угла.

Этот C#‑код демонстрирует операцию, в которой рассчитывается угол линии коннектора:
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


## **FAQ**

**Как определить, можно ли «приклеить» коннектор к конкретной фигуре?**

Проверьте, предоставляет ли фигура [точки соединения](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/). Если их нет или их количество равно нулю, приклеивание недоступно; в этом случае используйте свободные концы и разместите их вручную. Рекомендуется проверять количество точек перед привязкой.

**Что происходит с коннектором, если я удалю одну из соединённых фигур?**

Его концы будут отсоединены; коннектор останется на слайде как обычная линия со свободным началом/концом. Вы можете удалить его либо повторно установить соединения и, при необходимости, вызвать [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки коннектора при копировании слайда в другую презентацию?**

Обычно да, при условии, что связные фигуры также копируются. Если слайд вставляется в другой файл без соединённых фигур, концы становятся свободными и их придётся снова привязать.
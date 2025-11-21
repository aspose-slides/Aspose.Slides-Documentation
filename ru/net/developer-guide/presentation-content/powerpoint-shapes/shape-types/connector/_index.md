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
- соединять фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Позвольте приложениям .NET рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint — получайте полный контроль над прямыми, угловыми (с локтем) и изогнутыми коннекторами."
---

Коннектор PowerPoint — это специальная линия, которая соединяет две фигуры и остаётся привязанной к ним даже при перемещении или перестановке на слайде. 

Коннекторы обычно привязываются к *точкам соединения* (зелёные точки), которые присутствуют у всех фигур по умолчанию. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые присутствуют лишь у некоторых коннекторов, позволяют менять положение и форму коннектора.

## **Типы соединителей**

В PowerPoint можно использовать прямые, угловые (с локтем) и изогнутые коннекторы. 

Aspose.Slides предоставляет следующие коннекторы:

| Соединитель                     | Image                                                        | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Соединить фигуры с помощью соединителей**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд с помощью метода `AddAutoShape`, доступного у объекта `Shapes`.
1. Добавьте соединитель с помощью метода `AddConnector`, доступного у объекта `Shapes`, указав тип соединителя.
1. Соедините фигуры при помощи соединителя. 
1. Вызовите метод `Reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию. 

Этот C#‑код показывает, как добавить соединитель (изогнутый) между двумя фигурами (эллипсом и прямоугольником):
```c#
// Создает экземпляр класса презентации, представляющего файл PPTX
using (Presentation input = new Presentation())
{                
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Добавляет автофигуру эллипса
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автофигуру прямоугольника
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму соединителя в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Соединяет фигуры с помощью соединителя
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Вызывает Reroute, который задает автоматический кратчайший путь между фигурами
    connector.Reroute();

    // Сохраняет презентацию
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Метод `Connector.Reroute` перепрокидывает соединитель и заставляет его взять самый короткий возможный путь между фигурами. Для достижения этой цели метод может изменить точки `StartShapeConnectionSiteIndex` и `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указать точку соединения**
Если нужно, чтобы соединитель связывал две фигуры через конкретные точки на этих фигурах, укажите предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд с помощью метода `AddAutoShape`, доступного у объекта `Shapes`.
1. Добавьте соединитель с помощью метода `AddConnector`, доступного у объекта `Shapes`, указав тип соединителя.
1. Соедините фигуры при помощи соединителя. 
1. Установите предпочтительные точки соединения на фигурах. 
1. Сохраните презентацию.

Этот C#‑код демонстрирует операцию, в которой задаётся предпочтительная точка соединения:
```c#
// Создает объект класса презентации, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Добавляет форму соединителя в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Добавляет автофигуру эллипса
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автофигуру прямоугольника
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Соединяет фигуры с помощью соединителя
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Устанавливает желаемый индекс точки соединения на фигуре эллипса
    uint wantedIndex = 6;

    // Проверяет, что желаемый индекс меньше максимального количества точек соединения
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Устанавливает желаемую точку соединения на автофигуре эллипса
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Сохраняет презентацию
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Регулировка точки соединителя**

Вы можете изменять существующий соединитель через его точки регулировки. Только соединители с точками регулировки могут быть изменены таким образом. См. таблицу в разделе **[Типы соединителей](/slides/ru/net/connector/#types-of-connectors)** 

#### **Простой случай**

Рассмотрим ситуацию, когда соединитель между двумя фигурами (A и B) проходит через третью фигуру (C):

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


Чтобы обойти третью фигуру, можно сместить вертикальную линию соединителя влево:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **Сложные случаи** 

Для более сложных регулировок следует учитывать следующее:

* Точка регулировки соединителя тесно связана с формулой, вычисляющей её положение. Поэтому изменение позиции точки может изменить форму соединителя.
* Точки регулировки определены в строгом порядке в массиве. Нумерация идёт от начальной точки соединителя к конечной.
* Значения точек представляют процент от ширины/высоты фигуры соединителя. 
  * Фигура ограничена начальной и конечной точками соединителя, умноженными на 1000. 
  * Первая, вторая и третья точки определяют процент от ширины, процент от высоты и снова процент от ширины соответственно.
* При вычислении координат точек регулировки необходимо учитывать вращение соединителя и его отражение. **Примечание**: угол вращения всех соединителей, показанных в разделе **[Типы соединителей](/slides/ru/net/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим ситуацию, когда два текстовых фрейма соединены соединителем:

![connector-shape-complex](connector-shape-complex.png)

Код:
```c#
// Создаёт экземпляр класса презентации, представляющего файл PPTX
Presentation pres = new Presentation();
// Получает первый слайд в презентации
ISlide sld = pres.Slides[0];
// Добавляет фигуры, которые будут соединены через коннектор
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Добавляет коннектор
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Задаёт направление коннектора
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Задаёт цвет коннектора
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Задаёт толщину линии коннектора
connector.LineFormat.Width = 3;

// Соединяет фигуры с помощью коннектора
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Получает точки регулировки коннектора
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Регулировка**

Можно изменить значения точек регулировки, увеличив соответствующий процент ширины и высоты на 20 % и 200 % соответственно:
```c#
// Изменяет значения точек регулировки
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы построить модель, позволяющую определить координаты и форму отдельных частей соединителя, создадим фигуру, соответствующую горизонтальному компоненту соединителя в точке `connector.Adjustments[0]`:
```c#
// Рисует вертикальный компонент соединителя

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку соединителя, используя базовые принципы. В обычных ситуациях необходимо учитывать вращение соединителя и его отображение (параметры `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV`). Теперь покажем процесс.

Сначала добавим новый текстовый фрейм (**To 1**) на слайд (для соединения) и создадим новый (зелёный) соединитель, который соединит его с уже созданными объектами.
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
// Соединяет объекты с помощью только что созданного коннектора
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

Затем создадим фигуру, соответствующую горизонтальному компоненту соединителя, проходящего через новую точку регулировки `connector.Adjustments[0]`. Используем значения из данных соединителя для `connector.Rotation`, `connector.Frame.FlipH` и `connector.Frame.FlipV` и применим распространённую формулу преобразования координат при вращении вокруг точки x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта = 90 °, а соединитель отображается вертикально, поэтому соответствующий код выглядит так:
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
// Принимает значение точки регулировки как координату
x += connector.Width * adjValue_0.RawValue / 100000;
//  Преобразует координаты, поскольку Sin(90) = 1 и Cos(90) = 0
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

Мы продемонстрировали расчёты, связанные как с простыми регулировками, так и со сложными точками регулировки (точки с углом вращения). Полученные знания позволяют создать собственную модель (или написать код) для получения объекта `GraphicsPath` или даже установки значений точек регулировки соединителя на основе конкретных координат слайда.

## **Найти угол линий соединителя**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Доступ к форме линии соединителя. 
1. Используйте ширину, высоту, высоту кадра фигуры и ширину кадра фигуры для вычисления угла.

Этот C#‑код демонстрирует вычисление угла линии соединителя:
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

**Как определить, можно ли «приклеить» соединитель к конкретной фигуре?**

Проверьте, предоставляет ли фигура [точки соединения](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/). Если их нет или количество равно 0, приклеивание недоступно; в этом случае используйте свободные концы и позиционируйте их вручную. Рекомендуется проверять количество точек перед привязкой.

**Что происходит с соединителем, если я удаляю одну из соединённых фигур?**

Концы отсоединятся; соединитель останется на слайде как обычная линия со свободными началом и концом. Его можно удалить либо повторно привязать, при необходимости используя [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**

Обычно да, при условии, что связанные фигуры также копируются. Если слайд вставлен в другой файл без связанных фигур, концы становятся свободными, и их нужно будет заново привязать.
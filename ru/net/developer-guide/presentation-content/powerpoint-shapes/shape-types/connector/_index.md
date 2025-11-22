---
title: Коннектор
type: docs
weight: 10
url: /ru/net/connector/
keywords: "Соединять фигуры, коннекторы, фигуры PowerPoint, презентацию PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Соединять фигуры PowerPoint на C# или .NET"
---

Коннектор PowerPoint — это специальная линия, которая соединяет или связывает две фигуры и остаётся прикреплённой к фигурам даже при их перемещении или переустановке на данном слайде. 

Коннекторы обычно подключаются к *точкам соединения* (зеленые точки), которые по умолчанию присутствуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только у некоторых коннекторов, используются для изменения положения и формы коннекторов.

## **Типы коннекторов**

В PowerPoint можно использовать прямые, отрезные (угловые) и изогнутые коннекторы. 

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор                      | Изображение                                                        | Количество точек регулировки |
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

## **Соединение фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте два [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд, используя метод `AddAutoShape`, предоставляемый объектом `Shapes`.
1. Добавьте коннектор, используя метод `AddConnector`, предоставляемый объектом `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Вызовите метод `Reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию. 

Этот код C# показывает, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипсом и прямоугольником):
```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation input = new Presentation())
{                
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Добавляет автоматическую форму Эллипс
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автоматическую форму Прямоугольник
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Добавляет форму‑коннектор в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Соединяет фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Вызывает Reroute, который задаёт автоматический кратчайший путь между фигурами
    connector.Reroute();

    // Сохраняет презентацию
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Метод `Connector.Reroute` переурезает коннектор и заставляет его пройти по самому короткому возможному пути между фигурами. Для достижения цели метод может изменить точки `StartShapeConnectionSiteIndex` и `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указание точки соединения**
Если вы хотите, чтобы коннектор связывал две фигуры, используя конкретные точки на фигурах, необходимо указать предпочтительные точки соединения следующим способом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте два [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) на слайд, используя метод `AddAutoShape`, предоставляемый объектом `Shapes`.
1. Добавьте коннектор, используя метод `AddConnector`, предоставляемый объектом `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Установите предпочтительные точки соединения на фигурах.
1. Сохраните презентацию.

Этот код C# демонстрирует операцию, где указана предпочтительная точка соединения:
```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает коллекцию фигур для конкретного слайда
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Добавляет форму‑коннектор в коллекцию фигур слайда
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Добавляет автоматическую форму Эллипс
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Добавляет автоматическую форму Прямоугольник
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Соединяет фигуры с помощью коннектора
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Устанавливает индекс предпочтительной точки соединения для фигуры Эллипс
    uint wantedIndex = 6;

    // Проверяет, меньше ли предпочтительный индекс максимального количества точек соединения
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Устанавливает предпочтительную точку соединения для автоматической формы Эллипс
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Сохраняет презентацию
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Настройка точки коннектора**
Вы можете настроить существующий коннектор через его точки регулировки. Только коннекторы с точками регулировки могут быть изменены таким способом. См. таблицу в разделе **[Типы коннекторов.](/slides/ru/net/connector/#types-of-connectors)** 

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

Для выполнения более сложных настроек необходимо учитывать следующие моменты:

* Точка регулировки коннектора тесно связана с формулой, которая вычисляет и определяет её позицию. Поэтому изменения положения точки могут изменить форму коннектора.
* Точки регулировки коннектора определены в строгом порядке в массиве. Точки регулировки нумеруются от начальной точки коннектора до конечной.
* Значения точек регулировки отражают процент ширины/высоты формы коннектора.
  * Фигура ограничена начальной и конечной точками коннектора, умноженными на 1000.
  * Первый, второй и третий пункт определяют процент от ширины, процент от высоты и снова процент от ширины соответственно.
* Для вычисления координат точек регулировки коннектора необходимо учитывать его поворот и отражение. **Примечание**: угол поворота всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/ru/net/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстового фрейма соединены друг с другом через коннектор:

![connector-shape-complex](connector-shape-complex.png)

Код:
```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
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
// Устанавливает направление коннектора
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Устанавливает цвет коннектора
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Указывает толщину линии коннектора
connector.LineFormat.Width = 3;

// Связывает фигуры коннектором
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Получает точки регулировки коннектора
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Настройка**

Мы можем изменить значения точек регулировки коннектора, увеличив соответствующий процент ширины и высоты на 20% и 200% соответственно:
```c#
// Изменяет значения точек регулировки
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую вычислять координаты и форму отдельных частей коннектора, создадим фигуру, соответствующую горизонтальному компоненту коннектора в точке connector.Adjustments[0]:
```c#
// Отрисовать вертикальный компонент коннектора
float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию настройки коннектора, используя базовые принципы. В обычных ситуациях необходимо учитывать поворот коннектора и его отображение (которые задаются свойствами connector.Rotation, connector.Frame.FlipH и connector.Frame.FlipV). Сейчас мы покажем процесс.

Сначала добавим новый объект текстового фрейма (**To 1**) на слайд (для целей соединения) и создадим новый (зеленый) коннектор, который соединит его с уже созданными объектами.
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
// Связывает объекты с помощью нового коннектора
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

Во‑вторых, создадим фигуру, соответствующую горизонтальному компоненту коннектора, проходящему через новую точку регулировки connector.Adjustments[0]. Мы используем значения из данных коннектора для connector.Rotation, connector.Frame.FlipH и connector.Frame.FlipV и применим известную формулу преобразования координат для вращения вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол поворота объекта равен 90 градусам, и коннектор отображается вертикально, поэтому соответствующий код выглядит так:
```c#
// Сохраняет координаты коннектора
x = connector.X;
y = connector.Y;
// Корректирует координаты коннектора, если это необходимо
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

Мы продемонстрировали расчёты, включающие простые настройки и сложные точки регулировки (точки регулировки с углами поворота). Используя полученные знания, вы можете разработать собственную модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Определение угла линий коннектора**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к фигуре линии коннектора.
1. Используйте ширину и высоту линии, высоту и ширину кадра фигуры, чтобы вычислить угол.

Этот код C# демонстрирует операцию, в которой мы вычислили угол для фигуры линии коннектора:
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

**Как определить, может ли коннектор «приклеиваться» к конкретной фигуре?**

Проверьте, предоставляет ли фигура [точки соединения](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/). Если их нет или их количество равно нулю, приклеивание недоступно; в этом случае используйте свободные конечные точки и позиционируйте их вручную. Рекомендуется проверять количество точек перед прикреплением.

**Что происходит с коннектором, если я удаляю одну из соединённых фигур?**

Его концы будут отсоединены; коннектор останется на слайде как обычная линия с свободным началом/концом. Вы можете либо удалить его, либо переустановить соединения и, при необходимости, [перепроложить](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки коннектора при копировании слайда в другую презентацию?**

Как правило, да, при условии, что целевые фигуры также копируются. Если слайд вставляется в другой файл без связанных фигур, концы становятся свободными, и их нужно будет повторно прикрепить.
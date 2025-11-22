---
title: Коннектор
type: docs
weight: 10
url: /ru/nodejs-java/connector/
keywords: "Соединять фигуры, коннекторы, фигуры PowerPoint, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Соединять фигуры PowerPoint в JavaScript"
---

Коннектор PowerPoint — это специальная линия, которая соединяет две фигуры и остаётся привязанной к фигурам даже при их перемещении или переустановке на данном слайде. 

Коннекторы обычно соединяются с *точками соединения* (зелёными точками), которые по умолчанию присутствуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только у некоторых коннекторов, используются для изменения положения и формы коннекторов.

## **Типы коннекторов**

В PowerPoint можно использовать прямые, локтевые (угловые) и изогнутые коннекторы. 

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор | Изображение | Количество точек регулировки |
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

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, предоставляемый объектом `Shapes`.
1. Добавьте коннектор, используя метод `addConnector`, предоставляемый объектом `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию. 

В этом коде JavaScript показано, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипсом и прямоугольником):
```javascript
// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Добавляет автоконтур в виде эллипса
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Добавляет автоконтур в виде прямоугольника
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Добавляет форму‑коннектор в коллекцию фигур слайда
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Соединяет фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Вызывает reroute, который устанавливает автоматически кратчайший путь между фигурами
    connector.reroute();
    // Сохраняет презентацию
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Метод `Connector.reroute` перенаправляет коннектор и заставляет его взять кратчайший возможный путь между фигурами. Чтобы достичь этой цели, метод может изменить точки `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Указание точки соединения**

Если вы хотите, чтобы коннектор соединял две фигуры, используя определённые точки на фигурах, необходимо указать желаемые точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) на слайд, используя метод `addAutoShape`, предоставляемый объектом `Shapes`.
1. Добавьте коннектор, используя метод `addConnector`, предоставляемый объектом `Shapes`, указав тип коннектора.
1. Соедините фигуры с помощью коннектора.
1. Установите желаемые точки соединения на фигурах.
1. Сохраните презентацию.

В этом коде JavaScript продемонстрирована операция, где указана предпочтительная точка соединения:
```javascript
// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает коллекцию фигур для конкретного слайда
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Добавляет автоконтур в виде эллипса
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Добавляет автоконтур в виде прямоугольника
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Добавляет форму‑коннектор в коллекцию фигур слайда
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Соединяет фигуры с помощью коннектора
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Устанавливает индекс предпочтительной точки соединения для фигуры Эллипс
    var wantedIndex = 6;
    // Проверяет, меньше ли предпочтительный индекс максимального количества точек соединения
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Устанавливает предпочтительную точку соединения на автоконтуре Эллипс
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Сохраняет презентацию
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Регулировка точки коннектора**

Вы можете отрегулировать существующий коннектор с помощью его точек регулировки. Только коннекторы с точками регулировки можно изменять таким образом. Смотрите таблицу в разделе **[Типы коннекторов.](/slides/ru/nodejs-java/connector/#types-of-connectors)**

### **Простой случай**

Рассмотрите случай, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Чтобы избежать или обойти третью фигуру, мы можем отрегулировать коннектор, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Сложные случаи** 

Для выполнения более сложных регулировок необходимо учитывать следующее:

* Точка регулировки коннектора тесно связана с формулой, которая вычисляет и определяет её положение. Поэтому изменения местоположения точки могут изменить форму коннектора.
* Точки регулировки коннектора определены в строгом порядке в массиве. Точки регулировки нумеруются от начальной точки коннектора к конечной.
* Значения точек регулировки отражают процент ширины/высоты формы коннектора. 
  * Форма ограничена начальной и конечной точками коннектора, умноженными на 1000. 
  * Первая точка, вторая точка и третья точка соответственно определяют процент от ширины, процент от высоты и снова процент от ширины. 
* Для вычислений, определяющих координаты точек регулировки коннектора, необходимо учитывать вращение коннектора и его отражение. **Примечание**: угол вращения всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/ru/nodejs-java/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрите случай, когда два текстовых фрейма связаны друг с другом через коннектор:

![connector-shape-complex](connector-shape-complex.png)
```javascript
// Создает экземпляр класса презентации, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var sld = pres.getSlides().get_Item(0);
    // Добавляет фигуры, которые будут соединены коннектором
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Добавляет коннектор
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Указывает направление коннектора
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Указывает цвет коннектора
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Указывает толщину линии коннектора
    connector.getLineFormat().setWidth(3);
    // Связывает фигуры вместе с помощью коннектора
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Получает точки регулировки для коннектора
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Регулировка**

Мы можем изменить значения точек регулировки коннектора, увеличив соответствующий процент ширины и высоты на 20 % и 200 % соответственно:
```javascript
// Изменяет значения точек регулировки
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую вычислять координаты и форму отдельных частей коннектора, создадим форму, соответствующую горизонтальному компоненту коннектора в точке `connector.getAdjustments().get_Item(0)`:
```javascript
// Рисуем вертикальную компоненту коннектора
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки коннектора, используя базовые принципы. В обычных ситуациях необходимо учитывать вращение коннектора и его отображение (которые задаются методами `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV()`). Сейчас мы покажем процесс.

Сначала добавим новый объект текстового фрейма (**To 1**) на слайд (для целей соединения) и создадим новый (зелёный) коннектор, который соединит его с уже созданными объектами.
```javascript
// Создает новый объект привязки
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Создает новый коннектор
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Связывает объекты с помощью только что созданного коннектора
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

Затем создадим форму, соответствующую горизонтальному компоненту коннектора, проходящего через новую точку регулировки коннектора `connector.getAdjustments().get_Item(0)`. Мы используем значения из данных коннектора для `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV()` и применим известную формулу преобразования координат при вращении вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта составляет 90 градусов, а коннектор отображается вертикально, поэтому соответствующий код выглядит так:
```javascript
// Сохраняет координаты коннектора
x = connector.getX();
y = connector.getY();
// Корректирует координаты коннектора в случае появления
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Берёт значение точки регулировки как координату
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Определяет ширину горизонтального компонента, используя значение второй точки регулировки
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, связанные как с простыми, так и со сложными точками регулировки (точки с углами вращения). Полученными знаниями вы можете разработать собственную модель (или написать код) для получения объекта `GraphicsPath` или даже установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Определение угла линий коннектора**

1. Создайте экземпляр класса.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к форме линии коннектора.
1. Используйте ширину и высоту линии, высоту и ширину рамки фигуры для вычисления угла.

В этом коде JavaScript продемонстрирована операция, в которой мы вычислили угол линии коннектора:
```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**How can I tell whether a connector can be "glued" to a specific shape?**  
Проверьте, что фигура предоставляет [точки соединения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Если их нет или их количество равно нулю, возможность «приклеить» недоступна; в этом случае используйте свободные концы и разместите их вручную. Рекомендуется проверять количество точек перед привязкой.

**What happens to a connector if I delete one of the connected shapes?**  
Концы оторвутся; коннектор останется на слайде как обычная линия со свободными началом/концом. Вы можете либо удалить его, либо переназначить соединения и при необходимости [перенаправить](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/).

**Are connector bindings preserved when copying a slide to another presentation?**  
Обычно да, при условии, что целевые фигуры также копируются. Если слайд вставлен в другой файл без подключенных фигур, концы становятся свободными, и их потребуется повторно прикрепить.
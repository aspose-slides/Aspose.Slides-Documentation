---
title: Соединитель
type: docs
weight: 10
url: /php-java/connector/
keywords: "Соединить фигуры, соединители, фигуры PowerPoint, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Соединить фигуры PowerPoint "
---

Соединитель PowerPoint — это специальная линия, которая соединяет или связывает две фигуры между собой и остается прикрепленной к фигурам, даже когда они перемещаются или меняют положение на данном слайде.

Соединители обычно подключаются к *точкам соединения* (зеленые точки), которые по умолчанию существуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только на определенных соединителях, используются для изменения позиций и форм соединителей.

## **Типы соединителей**

В PowerPoint вы можете использовать прямые, уголковые (угловые) и криволинейные соединители.

Aspose.Slides предоставляет следующие соединители:

| Соединитель                     | Изображение                                                   | Количество точек регулировки |
| -------------------------------- | ------------------------------------------------------------- | ----------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                             |
| `ShapeType::StraightConnector1`  | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                             |
| `ShapeType::BentConnector2`      | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                             |
| `ShapeType::BentConnector3`      | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                             |
| `ShapeType::BentConnector4`      | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                             |
| `ShapeType::BentConnector5`      | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                             |
| `ShapeType::CurvedConnector2`    | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                             |
| `ShapeType::CurvedConnector3`    | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                             |
| `ShapeType::CurvedConnector4`    | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                             |
| `ShapeType::CurvedConnector5`    | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                             |

## **Соединить фигуры с помощью соединителей**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) на слайд с помощью метода `addAutoShape`, доступного в объекте `Shapes`.
1. Добавьте соединитель с помощью метода `addConnector`, доступного в объекте `Shapes`, определив тип соединителя.
1. Соедините фигуры с помощью соединителя.
1. Вызовите метод `reroute`, чтобы применить самый короткий путь соединения.
1. Сохраните презентацию.

Этот PHP-код показывает, как добавить соединитель (изогнутый соединитель) между двумя фигурами (эллипсом и прямоугольником):

```php
// Создает экземпляр класса презентации, представляющий файл PPTX
  $pres = new Presentation();
  try {
    # Получает коллекцию фигур для конкретного слайда
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Добавляет эллипс
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Добавляет прямоугольник
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Добавляет соединитель в коллекцию фигур слайда
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Соединяет фигуры с помощью соединителя
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Вызывает reroute, который устанавливает автоматический самый короткий путь между фигурами
    $connector->reroute();
    # Сохраняет презентацию
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Метод `Connector.reroute` перенаправляет соединитель и заставляет его принимать кратчайший возможный путь между фигурами. Для достижения этой цели метод может изменить `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex` точки. 

{{% /alert %}} 

## **Укажите точку соединения**

Если вы хотите, чтобы соединитель связывал две фигуры с использованием определенных точек на фигурах, вы должны указать предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) на слайд с помощью метода `addAutoShape`, доступного в объекте `Shapes`.
1. Добавьте соединитель с помощью метода `addConnector`, доступного в объекте `Shapes`, определив тип соединителя.
1. Соедините фигуры с помощью соединителя.
1. Установите предпочтительные точки соединения на фигурах.
1. Сохраните презентацию.

Этот PHP-код демонстрирует операцию, где указывается предпочтительная точка соединения:

```php
  # Создает экземпляр класса презентации, представляющий файл PPTX
  $pres = new Presentation();
  try {
    # Получает коллекцию фигур для конкретного слайда
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Добавляет эллипс
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Добавляет прямоугольник
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Добавляет соединитель в коллекцию фигур слайда
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Соединяет фигуры с помощью соединителя
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Устанавливает индекс предпочтительной точки соединения для фигуры Элипс
    $wantedIndex = 6;
    # Проверяет, меньше ли предпочтительный индекс максимального количества индексов площадок соединения
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Устанавливает предпочтительную точку соединения на автозиге эллипса
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Сохраняет презентацию
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Регулировка точки соединителя**

Вы можете регулировать существующий соединитель через его точки регулировки. Только соединители с точками регулировки могут быть изменены таким образом. См. таблицу под **[Типами соединителей.](/slides/php-java/connector/#types-of-connectors)**

#### **Простой случай**

Рассмотрим случай, когда соединитель между двумя фигурами (А и В) проходит через третью фигуру (С):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Чтобы избежать или обойти третью фигуру, мы можем отрегулировать соединитель, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **Сложные случаи** 

Чтобы выполнить более сложные корректировки, вам придется учитывать следующие моменты:

* Регулируемая точка соединителя сильно связана с формулой, которая рассчитывает и определяет его положение. Так что изменения в местоположении точки могут изменить форму соединителя.
* Точки регулировки соединителя определяются в строгом порядке в массиве. Точки регулировки нумеруются от начальной точки соединителя до его конечной.
* Значения точек регулировки отражают процент ширины/высоты формы соединителя. 
  * Фигура ограничена начальной и конечной точками соединителя, умноженными на 1000. 
  * Первая точка, вторая точка и третья точка определяют процент от ширины, процент от высоты и процент от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты точек регулировки соединителя, вы должны учитывать поворот соединителя и его отражение. **Примечание**: угол поворота для всех соединителей, показанных в разделе **[Типы соединителей](/slides/php-java/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстового фрейма связаны вместе через соединитель:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Создает экземпляр класса презентации, представляющий файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет фигуры, которые будут соединены через соединитель
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("От");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("К");
    # Добавляет соединитель
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Указывает направление соединителя
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Указывает цвет соединителя
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Устанавливает толщину линии соединителя
    $connector->getLineFormat()->setWidth(3);
    # Связывает фигуры вместе с помощью соединителя
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Получает точки регулировки для соединителя
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Регулировка**

Мы можем изменить значения точек регулировки соединителя, увеличив соответствующие процентные соотношения ширины и высоты на 20% и 200% соответственно:

```php
  # Изменяет значения точек регулировки
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, которая позволит нам определить координаты и форму отдельных частей соединителя, давайте создадим фигуру, которая соответствует горизонтальному компоненту соединителя в точке connector.getAdjustments().get_Item(0):

```php
  # Рисует вертикальный компонент соединителя
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки соединителя, используя основные принципы. В обычных ситуациях вам необходимо учитывать поворот соединителя и его отображение (которые задаются connector.getRotation(), connector.getFrame().getFlipH() и connector.getFrame().getFlipV()). Теперь мы продемонстрируем процесс.

Сначала давайте добавим новый объект текстового фрейма (**К 1**) на слайд (для целей соединения) и создадим новый (зеленый) соединитель, который соединит его с уже созданными объектами.

```php
  # Создает новый объект привязки
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("К 1");
  # Создает новый соединитель
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Связывает объекты с помощью вновь созданного соединителя
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Получает точки регулировки соединителя
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Изменяет значения точек регулировки
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во-вторых, давайте создадим фигуру, которая будет соответствовать горизонтальному компоненту соединителя, который проходит через точку регулировки нового соединителя connector.getAdjustments().get_Item(0). Мы используем значения из данных соединителя для connector.getRotation(), connector.getFrame().getFlipH() и connector.getFrame().getFlipV() и применим популярную формулу преобразования координат для вращения вокруг данной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта равен 90 градусам, и соединитель отображается вертикально, поэтому это соответствующий код:

```php
  # Сохраняет координаты соединителя
  $x = $connector->getX();
  $y = $connector->getY();
  # Корректирует координаты соединителя в случае их появления
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Принимает значение точки регулировки в качестве координаты
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Определяет ширину горизонтального компонента на основе второго значения точки регулировки
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчеты, связанные с простыми регулировками и сложными точками регулировки (точками регулировки с углами вращения). Используя приобретенные знания, вы можете разработать свою собственную модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек регулировки соединителя на основе конкретных координат слайда.

## **Найти угол линий соединителя**

1. Создайте экземпляр класса.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к фигурной линии соединителя.
1. Используйте ширину линии, высоту, высоту кадра фигуры и ширину кадра фигуры для расчета угла.

Этот PHP-код демонстрирует операцию, в которой мы рассчитали угол для фигуры линии соединителя:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
---
title: Управление коннекторами в презентациях с использованием PHP
linktitle: Коннектор
type: docs
weight: 10
url: /ru/php-java/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- связывание фигур
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Позвольте PHP‑приложениям рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint — получайте полный контроль над прямыми, локтевыми и изогнутыми коннекторами."
---

Коннектор PowerPoint — это специальная линия, соединяющая две фигуры и остающаяся прикреплённой к ним даже при перемещении или переустановке на слайде.

Коннекторы обычно привязываются к *точкам соединения* (зеленым точкам), которые по умолчанию присутствуют на всех фигурах. Точки соединения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые присутствуют только у некоторых коннекторов, используются для изменения их положения и формы.

## **Типы коннекторов**

В PowerPoint можно использовать прямые, локтевые (угловые) и изогнутые коннекторы.

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор | Изображение | Количество точек регулировки |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Соединение фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два [AutoShape] к слайду, используя метод `addAutoShape`, доступный через объект `Shapes`.
4. Добавьте коннектор, используя метод `addConnector`, доступный через объект `Shapes`, указав тип коннектора.
5. Соедините фигуры с помощью коннектора.
6. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
7. Сохраните презентацию.

Этот PHP‑код демонстрирует, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипс и прямоугольник):
```php
// Создает экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает коллекцию фигур для конкретного слайда
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Добавляет автоконтур Эллипс
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Добавляет автоконтур Прямоугольник
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Добавляет форму-коннектор в коллекцию фигур слайда
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Соединяет фигуры с помощью коннектора
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Вызывает reroute, который устанавливает автоматический кратчайший путь между фигурами
    $connector->reroute();
    # Сохраняет презентацию
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` метод перенаправляет коннектор и заставляет его выбирать кратчайший возможный путь между фигурами. Для достижения этой цели метод может изменить точки `setStartShapeConnectionSiteIndex` и `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Указание точки соединения**

Если вы хотите, чтобы коннектор соединял две фигуры через конкретные точки на фигурах, необходимо указать предпочитаемые точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два [AutoShape] к слайду, используя метод `addAutoShape`, доступный через объект `Shapes`.
4. Добавьте коннектор, используя метод `addConnector`, доступный через объект `Shapes`, указав тип коннектора.
5. Соедините фигуры с помощью коннектора.
6. Установите предпочитаемые точки соединения на фигурах.
7. Сохраните презентацию.

Этот PHP‑код демонстрирует операцию, в которой указана предпочтительная точка соединения:
```php
  # Создает экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает коллекцию фигур для конкретного слайда
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Добавляет автоконтур Эллипс
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Добавляет автоконтур Прямоугольник
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Добавляет форму-коннектор в коллекцию фигур слайда
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Соединяет фигуры с помощью коннектора
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Устанавливает индекс предпочтительной точки соединения у фигуры Эллипс
    $wantedIndex = 6;
    # Проверяет, меньше ли предпочтительный индекс максимального количества индексов точек соединения
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Устанавливает предпочтительную точку соединения у автоконтурa Эллипс
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


## **Регулировка точки коннектора**

Вы можете регулировать существующий коннектор через его точки регулировки. Только коннекторы с точками регулировки могут изменяться таким образом. См. таблицу в разделе **[Типы коннекторов.](/slides/ru/php-java/connector/#types-of-connectors)**

### **Простой случай**

Рассмотрим случай, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

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


Чтобы избежать или обойти третью фигуру, можно отрегулировать коннектор, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```


### **Сложные случаи** 

Для выполнения более сложных регулировок необходимо учесть следующие моменты:

* Регулируемая точка коннектора тесно связана с формулой, рассчитывающей и определяющей её позицию. Поэтому изменение положения точки может изменить форму коннектора.
* Точки регулировки коннектора определяются в строгом порядке в массиве. Точки нумеруются от начальной точки коннектора к конечной.
* Значения точек регулировки отражают процент ширины/высоты фигуры коннектора.
  * Фигура ограничена начальной и конечной точками коннектора, умноженными на 1000.
  * Первая, вторая и третья точки определяют соответственно процент от ширины, процент от высоты и снова процент от ширины.
* При расчёте координат точек регулировки коннектора необходимо учитывать его вращение и отражение. **Примечание**: угол вращения всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/ru/php-java/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два текстовых блока соединены друг с другом с помощью коннектора:

![connector-shape-complex](connector-shape-complex.png)
```php
  # Создает экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет фигуры, которые будут соединены коннектором
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Добавляет коннектор
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Задает направление коннектора
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Задает цвет коннектора
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Задает толщину линии коннектора
    $connector->getLineFormat()->setWidth(3);
    # Связывает фигуры с помощью коннектора
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Получает точки регулировки коннектора
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Регулировка**

Мы можем изменить значения точек регулировки коннектора, увеличив соответствующие процентные значения ширины и высоты на 20 % и 200 % соответственно:
```php
  # Изменяет значения точек регулировки
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Для определения модели, позволяющей вычислить координаты и форму отдельных частей коннектора, создадим фигуру, соответствующую горизонтальному компоненту коннектора в точке `connector.getAdjustments().get_Item(0)`:
```php
  # Рисует вертикальную компоненту коннектора
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки коннектора, используя базовые принципы. В обычных ситуациях необходимо учитывать вращение коннектора и его отображение (которые задаются методами `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV`). Сейчас мы покажем процесс.

Сначала добавим новый текстовый блок (**To 1**) на слайд (для целей соединения) и создадим новый (зеленый) коннектор, соединяющий его с уже созданными объектами.
```php
  # Создает новый объект привязки
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Создает новый коннектор
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Связывает объекты с помощью вновь созданного коннектора
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Получает точки регулировки коннектора
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Изменяет значения точек регулировки
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во‑вторых, создадим фигуру, соответствующую горизонтальному компоненту коннектора, проходящего через новую точку регулировки `connector.getAdjustments().get_Item(0)`. Мы используем значения из данных коннектора для `connector.getRotation()`, `connector.getFrame().getFlipH()` и `connector.getFrame().getFlipV` и применим известную формулу преобразования координат при вращении вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта составляет 90 градусов, а коннектор отображается вертикально, поэтому соответствующий код выглядит так:
```php
  # Сохраняет координаты коннектора
  $x = $connector->getX();
  $y = $connector->getY();
  # Корректирует координаты коннектора, если они изменятся
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Использует значение точки регулировки как координату
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Преобразует координаты, так как Sin(90) = 1 и Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Определяет ширину горизонтального компонента, используя значение второй точки регулировки
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```


Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, включающие простые регулировки и сложные точки регулировки (точки регулировки с углами вращения). Используя полученные знания, вы можете разработать собственную модель (или написать код) для получения объекта `GraphicsPath` или даже установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Определение угла линий коннектора**

1. Создайте экземпляр класса.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к фигуре линии коннектора.
4. Используйте ширину и высоту линии, а также высоту и ширину рамки фигуры для вычисления угла.

Этот PHP‑код демонстрирует операцию, в которой мы вычислили угол линии коннектора:
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


## **FAQ**

**Как определить, можно ли «приклеить» коннектор к конкретной фигуре?**

Убедитесь, что фигура предоставляет [connection sites](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/). Если их нет или их количество равно нулю, «приклеивание» недоступно; в этом случае используйте свободные конечные точки и размещайте их вручную. Рекомендуется проверять количество точек перед соединением.

**Что происходит с коннектором, если удалить одну из соединённых фигур?**

Его концы будут отсоединены; коннектор останется на слайде как обычная линия со свободными началом/концом. Вы можете либо удалить его, либо переназначить соединения и, при необходимости, выполнить [reroute](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/).

**Сохраняются ли привязки коннекторов при копировании слайда в другую презентацию?**

Как правило, да, при условии, что целевые фигуры также копируются. Если слайд вставлен в другой файл без соединённых фигур, концы становятся свободными, и их потребуется вновь присоединить.
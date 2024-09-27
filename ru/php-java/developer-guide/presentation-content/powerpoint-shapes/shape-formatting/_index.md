---
title: Форматирование фигур
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords: "Форматирование фигур, форматирование линий, стиль соединения, градиентная заливка, паттерн заливка, картинка заливка, заливка однородным цветом, поворот фигур, 3d эффекты фаски, 3d эффект вращения, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Форматирование фигур в презентации PowerPoint"
---

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составляющим линиям. Кроме того, вы можете форматировать фигуры, задавая параметры, которые определяют, как они (их область) будут заполнены.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для PHP через Java** предоставляет интерфейсы и свойства, которые позволяют вам форматировать фигуры на основе известных параметров в PowerPoint.

## **Форматирование линий**

Используя Aspose.Slides, вы можете задать предпочитаемый стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) для линий фигуры.
7. Установите [стиль штриха](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) для линий фигуры.
8. Запишите измененную презентацию в файл PPTX.

Этот код на PHP демонстрирует операцию, где мы отформатировали прямоугольник `AutoShape`:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет автозакруглённую фигуру типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # Устанавливает цвет заливки для фигуры прямоугольника
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Применяет некоторые параметры форматирования к линиям прямоугольника
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # Устанавливает цвет линий прямоугольника
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Записывает файл PPTX на диск
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Форматирование стилей соединения**
Это 3 типа соединений:

* Закругленное
* Деревянное
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), он использует настройку **Закругленное**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вам может потребоваться выбрать **Деревянное**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот код на Java демонстрирует операцию, где были созданы 3 прямоугольника (изображение выше) с типами соединений Деревянное, Фаска и Закругленное:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет 3 автозакругленных прямоугольника
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # Устанавливает цвет заливки для фигуры прямоугольника
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Устанавливает ширину линии
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # Устанавливает цвет линий прямоугольника
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Устанавливает стиль соединения
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # Добавляет текст к каждому прямоугольнику
    $shp1->getTextFrame()->setText("Стиль соединения Деревянное");
    $shp2->getTextFrame()->setText("Стиль соединения Фаска");
    $shp3->getTextFrame()->setText("Стиль соединения Закругленное");
    # Записывает файл PPTX на диск
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Градиентная заливка**
В PowerPoint градиентная заливка является параметром форматирования, который позволяет вам применять непрерывный переход цветов к фигуре. Например, вы можете применить два или более цветов в установке, где один цвет постепенно затухает и меняется на другой цвет.

Вот как вы используете Aspose.Slides, чтобы применить градиентную заливку к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) фигуры на `Gradient`.
5. Добавьте ваши 2 предпочитаемых цвета с определенными позициями, используя методы `Add`, доступные в коллекции `GradientStops`, связанной с классом `GradientFormat`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на PHP демонстрирует операцию, где эффект градиентной заливки использовался на эллипсе:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет автозакругленную фигуру типа эллипс
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # Применяет градиентное форматирование к эллипсу
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # Устанавливает направление градиента
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # Добавляет 2 цвета градиента
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # Записывает файл PPTX на диск
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Паттерн заливка**
В PowerPoint паттерн заливка является параметром форматирования, который позволяет вам применять двухцветный дизайн, состоящий из точек, полос, крестов или клеток, к фигуре. Кроме того, вы можете выбрать ваши предпочитаемые цвета для переднего и фона вашего шаблона.

Aspose.Slides предоставляет более 45 предопределенных стилей, которые можно использовать для форматирования фигур и обогащения презентаций. Даже после того как вы выберете предопределенный паттерн, вы все равно можете указать цвета, которые должен содержать паттерн.

Вот как вы используете Aspose.Slides, чтобы применить паттерн заливку к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) фигуры на `Pattern`.
5. Установите предпочитаемый стиль паттерна для фигуры.
6. Установите [Цвет фона](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) для [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
7. Установите [Цвет переднего плана](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) для [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
8. Запишите измененную презентацию в файл PPTX.

Этот код на PHP демонстрирует операцию, где была использована заливка паттерном для украшения прямоугольника:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет автозакругленную фигуру типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Устанавливает тип заливки на Паттерн
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # Устанавливает стиль паттерна
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # Устанавливает фон и передние цвета паттерна
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # Записывает файл PPTX на диск
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Картинка заливка**
В PowerPoint картинка заливка является параметром форматирования, который позволяет вам размещать картинку внутри фигуры. По сути, вы можете использовать картинку как фон фигуры.

Вот как вы используете Aspose.Slides, чтобы заполнить фигуру картинкой:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) фигуры на `Picture`.
5. Установите режим заливки картинки на Тайловый.
6. Создайте объект `IPPImage`, используя изображение, которое будет использовано для заполнения фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на недавно созданный `IPPImage`.
8. Запишите измененную презентацию в файл PPTX.

Этот код на PHP показывает вам, как заполнить фигуру картинкой:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет автозакругленную фигуру типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Устанавливает тип заливки на Картинка
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # Устанавливает режим заливки картинки
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # Устанавливает картинку
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Записывает файл PPTX на диск
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Заливка однородным цветом**
В PowerPoint заливка однородным цветом является параметром форматирования, который позволяет заполнить фигуру одним цветом. Выбранный цвет обычно является простым цветом. Цвет применяется к фону фигуры с любыми специальными эффектами или изменениями.

Вот как вы используете Aspose.Slides, чтобы применить заливку однородным цветом к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) фигуры на `Solid`.
5. Установите предпочитаемый цвет для фигуры.
6. Запишите измененную презентацию в файл PPTX.

Этот код на PHP показывает вам, как применить заливку однородным цветом к коробке в PowerPoint:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет автозакругленную фигуру типа прямоугольник
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Устанавливает тип заливки на Однородный
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # Устанавливает цвет для прямоугольника
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Записывает файл PPTX на диск
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка прозрачности**

В PowerPoint, когда вы заполняете фигуры однородными цветами, градиентами, картинками или текстурами, вы можете задать уровень прозрачности, который определяет непрозрачность заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект слайда или фон, находящийся позади (фигуры), будет просвечиваться.

Aspose.Slides позволяет вам установить уровень прозрачности для фигуры следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Используйте `new Color` с установленным альфа-компонентом.
5. Сохраните объект как файл PowerPoint.

Этот код на PHP демонстрирует процесс:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет сплошную фигуру
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # Добавляет прозрачную фигуру поверх сплошной фигуры
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # Записывает файл PPTX на диск
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Поворот фигур**
Aspose.Slides позволяет вам поворачивать фигуру, добавленную на слайд, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
4. Поверните фигуру на нужные градусы.
5. Запишите измененную презентацию в файл PPTX.

Этот код на PHP показывает вам, как повернуть фигуру на 90 градусов:

```php
  # Создает экземпляр класса презентации, представляющий файл презентации
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет автозакругленную фигуру типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Поворачивает фигуру на 90 градусов
    $shp->setRotation(90);
    # Записывает файл PPTX на диск
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление эффектов 3D фаски**
Aspose.Slides позволяет вам добавлять 3D эффекты фаски к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
3. Установите предпочитаемые параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) фигуры.
4. Запишите презентацию на диск.

Этот код на PHP показывает вам, как добавить 3D эффекты фаски к фигуре:

```php
  # Создает экземпляр класса презентации
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет фигуру на слайд
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # Устанавливает свойства ThreeDFormat фигуры
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # Записывает презентацию как файл PPTX
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление эффекта 3D вращения**
Aspose.Slides позволяет вам применять эффекты 3D вращения к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) на слайд.
3. Укажите предпочитаемые фигуры для [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) и [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--).
4. Запишите презентацию на диск.

Этот код на PHP показывает вам, как применить эффекты 3D вращения к фигуре:

```php
  # Создает экземпляр класса презентации
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # Записывает презентацию как файл PPTX
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сброс форматирования**

Этот код на PHP показывает вам, как сбросить форматирование на слайде и вернуть положение, размер и форматирование каждой фигуры, которая имеет заполнение на [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide), к их значениям по умолчанию:

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # каждая фигура на слайде, которая имеет заполнение на макете, будет возвращена
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
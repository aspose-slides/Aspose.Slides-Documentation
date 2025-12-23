---
title: Создание 3D презентаций в PHP
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Легко создавайте интерактивные 3D презентации на PHP с Aspose.Slides. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**
Начиная с Aspose.Slides Java 20.9 возможно создавать 3D в презентациях. PowerPoint 3D — это способ оживить презентации. Покажите реальные объекты мира с 3D‑презентацией, продемонстрируйте 3D‑модель вашего будущего бизнес‑проекта, 3D‑модель здания или его интерьера, 3D‑модель игрового персонажа или просто 3D‑представление ваших данных. 

Модели PowerPoint 3D могут быть созданы из 2D‑форм, применяя такие эффекты: 3D‑поворот, 3D‑глубина и экструзия, 3D‑градиент, 3D‑текст и т. д. Список 3D‑функций, применяемых к формам, можно найти в классе **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. Экземпляр класса можно получить с помощью: 

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** метод для создания модели PowerPoint 3D. 
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** метод для создания 3D‑текста (WordArt). 

Все эффекты, реализованные в **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**, могут использоваться как для форм, так и для текста. Давайте быстро посмотрим основные методы класса **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. В следующем примере мы создаём прямоугольную 2D‑форму с текстом. Получив вид камеры на форму, мы меняем её вращение, чтобы она выглядела как 3D‑модель. Установив плоское освещение и его направление к верхней части 3D‑модели, мы придаём модели больший объём. Изменённые материалы, высота экструзии и цвет делают 3D‑модель более живой. 
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Вот получившаяся 3D‑модель:

![todo:image_alt_text](img_01_01.png)

## **3D Поворот**
Поворот 3D‑модели в PowerPoint можно выполнить через меню:

![todo:image_alt_text](img_02_01.png)

Чтобы повернуть 3D‑модель с помощью Aspose.Slides API, используйте метод **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**, задайте вращение камеры относительно 3D‑формы:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... установить другие параметры 3D сцены

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **3D Глубина и Экструзия**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** и **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** методы используются для создания экструзии на форме:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... установить другие параметры 3D сцены

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


В PowerPoint глубина формы задаётся через:

![todo:image_alt_text](img_02_02.png)

## **3D Градиент**
3D‑градиент может добавить объём 3D‑форме PowerPoint:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


Вот как это выглядит:

![todo:image_alt_text](img_02_03.png)
  
Вы также можете создать градиент изображения:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... настроить 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* свойства

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


Вот результат:

![todo:image_alt_text](img_02_04.png)

## **3D Текст (WordArt)**
Чтобы создать 3D‑текст (WordArt), выполните следующее:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# настроить трансформационный эффект WordArt "Arch Up"

$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Вот результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Сохранятся ли 3D‑эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides визуализирует 3D‑эффекты при экспорте в поддерживаемые форматы ([images](/slides/ru/php-java/convert-powerpoint-to-png/), [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), и т. д.).

**Могу ли я получить «эффективные» (окончательные) значения 3D‑параметров, учитывающие темы, наследование и т.д.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/php-java/shape-effective-properties/) (включая 3D‑освещение, фаски и др.), чтобы вы могли увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/php-java/convert-powerpoint-to-video/) 3D‑эффекты визуализируются так же, как и при [экспорте изображений](/slides/ru/php-java/convert-powerpoint-to-png/).
---
title: 3D Презентация
type: docs
weight: 232
url: /ru/php-java/3d-presentation/
---

## Обзор
С версии Aspose.Slides Java 20.9 стало возможным создание 3D в презентациях. PowerPoint 3D — это способ оживить презентации. Покажите реальные объекты с помощью 3D-презентации, продемонстрируйте 3D-модель вашего будущего бизнес-проекта, 3D-модель здания или его интерьера, 3D-модель игрового персонажа или просто 3D-представление ваших данных.

3D-модели PowerPoint могут быть созданы из 2D-форм, путем применения к ним таких эффектов, как: 3D-вращение, 3D-глубина и экструзия, 3D-градиент, 3D-текст и т.д. Список 3D-функций, применяемых к формам, можно найти в классе **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. Экземпляр этого класса можно получить с помощью:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** метода для создания 3D-модели PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** метода для создания 3D-текста (WordArt).

Все эффекты, реализованные в **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**, могут использоваться как для форм, так и для текста. Давайте быстро рассмотрим основные методы класса **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. В следующем примере мы создаем 2D-прямоугольную форму с текстом на ней. Получив вид камеры на форме, мы изменяем ее вращение и делаем ее похожей на 3D-модель. Установка плоского света и его направление к верхней части 3D-модели придают модели больший объем. Измененные материалы, высота экструзии и цвет делают 3D-модель более живой.
``` php 
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);
    try {
      $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
      $slideImage->save("sample_3d.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $pres->save("sandbox_3d.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Вот итоговая 3D-модель:

![todo:image_alt_text](img_01_01.png)

## 3D Вращение
Вращение 3D модели в PowerPoint можно выполнить через меню:

![todo:image_alt_text](img_02_01.png)

Чтобы вращать 3D модель с помощью API Aspose.Slides, используйте метод **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**, устанавливая вращение камеры относительно 3D формы:

``` php
$shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... задайте другие параметры 3D сцены
try {
        $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
        $slideImage->save("sample_3d.png", ImageFormat::Png);
    } finally {
             if (!java_is_null($slideImage)) $slideImage->dispose();
         }
```

## 3D Глубина и Экструзия
Методы **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** и **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** используются для создания экструзии на форме:

``` php
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
    # ... задайте другие параметры 3D сцены
    try {
      $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
      $slideImage->save("sample_3d.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
  }
```

В PowerPoint глубина формы устанавливается через:

![todo:image_alt_text](img_02_02.png)

## 3D Градиент
3D градиент может добавить объем к 3D форме PowerPoint:

``` php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
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
    try {
      $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
      $slideImage->save("sample_3d.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Вот как это выглядит:

![todo:image_alt_text](img_02_03.png)

Вы также можете создать изображение-градиент:
``` php
    $shape->getFillFormat()->setFillType(FillType::Picture);
    try {
      $picture;
      $image = Images->fromFile("image.png");
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
      $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
      # .. настройка 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* свойства
      try {
        $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
        $slideImage->save("sample_3d.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
```

Вот результат:

![todo:image_alt_text](img_02_04.png)

## 3D Текст (WordArt)
Чтобы создать 3D текст (WordArt), выполните следующие действия:
``` php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Текст");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
    $textFrame = $shape->getTextFrame();
    # настройка эффекта трансформации "Арка вверх" WordArt
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUp);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
    try {
      $slideImage = $pres->getSlides()->get_Item(0)->getImage(2, 2);
      $slideImage->save("text3d.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $pres->save("text3d.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Вот результат:

![todo:image_alt_text](img_02_05.png)

## Не поддерживается - Скоро будет
Следующие функции 3D PowerPoint пока не поддерживаются:
- Фаска
- Материал
- Контур
- Освещение
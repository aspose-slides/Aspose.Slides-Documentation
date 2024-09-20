---
title: 3D Презентация
type: docs
weight: 232
url: /androidjava/3d-presentation/
---

## Обзор
С версии Aspose.Slides Java 20.9 стало возможным создавать 3D в презентациях. PowerPoint 3D — это способ оживить презентации. Показывайте реальные объекты
с помощью 3D-презентации, демонстрируйте 3D-модель вашего будущего бизнес-проекта, 3D-модель здания или его интерьера, 3D-модель игрового персонажа
или просто 3D-представление ваших данных.

3D-модели PowerPoint могут быть созданы из 2D-форм, применяя к ним такие эффекты: 3D-вращение, 3D-глубина и экструзия, 3D-градиент, 3D-текст и т.д.
Список 3D-функций, применяемых к формам, можно найти в классе **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**.
Экземпляр класса можно получить с помощью:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** метода для создания 3D-модели PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** метода для создания 3D-текста
(WordArt).

Все эффекты, реализованные в **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**, могут использоваться как для форм, так и для текста.
Давайте быстро рассмотрим основные методы класса **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. В следующем примере
мы создаем прямоугольную 2D-форму с текстом на ней. Получив камеру вид на форму, мы изменяем ее вращение и делаем ее похожей на 3D-модель. Установка плоского света
и его направление вверх к 3D-модели придает модели больше объема. Измененные материалы, высота экструзии и цвет делают 3D-модель более живой.
``` java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }

    pres.save("sandbox_3d.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Вот полученная 3D-модель:

![todo:image_alt_text](img_01_01.png)

## 3D Вращение
Вращение 3D-модели в PowerPoint можно выполнить через меню:

![todo:image_alt_text](img_02_01.png)

Чтобы повернуть 3D-модель с помощью API Aspose.Slides, используйте **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**
метод, установите вращение камеры относительно 3D-формы:

``` java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... установить другие параметры 3D-сцены
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

## 3D Глубина и Экструзия
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)**
и **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** методы
используются для создания экструзии на форме:

``` java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... установить другие параметры 3D-сцены
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

В PowerPoint глубина формы устанавливается через:

![todo:image_alt_text](img_02_02.png)

## 3D Градиент
3D градиент может придать больше объема 3D-форме PowerPoint:

``` java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

    try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
} finally {
    if (pres != null) pres.dispose();
}
```

Вот как это выглядит:

![todo:image_alt_text](img_02_03.png)

Вы также можете создать градиент изображения:
``` java
shape.getFillFormat().setFillType(FillType.Picture);
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// .. настройка 3D: свойства shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion*
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

Вот результат:

![todo:image_alt_text](img_02_04.png)

## 3D Текст (WordArt)
Чтобы создать 3D-текст (WordArt), выполните следующее:
``` java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Текст");

    Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrame textFrame = shape.getTextFrame();
    // настройка эффекта трансформации "Арка вверх" WordArt
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUp);

    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5f);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }

    pres.save("text3d.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Вот результат:

![todo:image_alt_text](img_02_05.png)

## Не поддерживается - Скоро
Следующие функции 3D PowerPoint еще не поддерживаются:
- Скос
- Материал
- Контур
- Освещение
---

Название: 3D презентация
Тип: документы
Вес: 232
URL:/AndroidJava/3D-Presentation/
---

## Обзор

Поскольку Aspose.slides Java 20.9 можно создать 3D в презентациях.PowerPoint 3D - это способ дать жизнь презентациям.Показать объекты реального мира
С 3D -презентацией продемонстрируйте 3D -модель вашего будущего бизнес -проекта, 3D -модель здания или его интерьера, 3D -модель игрового персонажа,
Или просто 3D -представление ваших данных.

3D -модели PowerPoint могут быть созданы из 2D -форм, применяя такие эффекты на них: 3D вращение, 3D -глубина, 3D -градиент, 3D -текст и т. Д.
Список трехмерных функций, применяемых к формам, можно найти в**[Threedformat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**сорт.
Экземпляр класса может быть получена:

- **[Shape.getThreedFormat ()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)**Метод создания 3D -модели PowerPoint.
- **[TextFrameFormat.getThreedFormat ()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)**Метод создания 3D -текста
  (WordArt).

Все эффекты, реализованные в**[Threedformat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**может быть использован как для форм, так и для текста.
Давайте быстро рассмотрим основные методы**[Threedformat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**сорт.В следующем примере
Мы создаем прямоугольную 2D -форму с текстом на нем.Получив вид камеры на форме, мы меняем ее вращение и делаем вид на 3D -модель.Установка плоского света
и его направление на вершину 3D -модели, приведите больше объема в модель.Измененные материалы, высота экструзии и цвет делают трехмерную модель более живой.

```java
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

Вот полученная 3D -модель:

![TODO: image_alt_text](img_01_01.png)

## 3D вращение

Вращение 3D -модели в PowerPoint может быть сделано через меню:

![TODO: image_alt_text](img_02_01.png)

Чтобы повернуть 3D -модель с Aspose.Slides API, используйте**[Ithreedformat.getCamera ()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**
Метод, установите вращение камеры относительно 3D -формы:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... set other 3D scene parameters
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

## 3D глубина и экструзия

**[Ithreedformat.getextrusionHeight ()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)**
и**[Ithreed format.getExtrusionColor ()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)**методы
используются для создания экструзии на форме:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... set other 3D scene parameters
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

В PowerPoint глубина формы устанавливается через:

![TODO: image_alt_text](img_02_02.png)

## 3D градиент

3D -градиент может принести больший объем до 3D -формы PowerPoint:

```java
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

![TODO: image_alt_text](img_02_03.png)

Вы также можете создать градиент изображения:

```java
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
// .. setup 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties
try {
        IImage slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", ImageFormat.Png);
    } finally {
             if (slideImage != null) slideImage.dispose();
         }
```

Вот результат:

![TODO: image_alt_text](img_02_04.png)

## 3D Text (WordArt)

Чтобы создать 3D -текст (WordArt), сделайте следующее:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
 
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");
 
    Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);
 
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
 
    ITextFrame textFrame = shape.getTextFrame();
    // setup "Arch Up" WordArt transform effect
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

![TODO: image_alt_text](img_02_05.png)

## Не поддерживается - скоро появится

Следующие функции PowerPoint 3D еще не поддерживаются:

- Скос
- Материал
- Контур
- 

---
title: 3D презентация
type: docs
weight: 232
url: /ru/nodejs-java/3d-presentation/
---

## **Обзор**

Начиная с Aspose.Slides for Java 20.9, возможно создавать 3D в презентациях. PowerPoint 3D — это способ оживить презентации. Показать реальные объекты в 3D‑презентации, продемонстрировать 3D‑модель вашего будущего бизнес‑проекта, 3D‑модель здания или его интерьера, 3D‑модель игрового персонажа или просто 3D‑представление ваших данных. 

3D‑модели PowerPoint можно создавать из 2D‑форм, применяя к ним такие эффекты: 3D‑поворот, 3D‑глубина и экструдирование, 3D‑градиент, 3D‑текст и т.д. Список 3D‑функций, применяемых к фигурам, можно найти в классе **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. Экземпляр класса можно получить с помощью:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** метод для создания 3D‑модели PowerPoint.  
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** метод для создания 3D‑текста (WordArt).

Все эффекты, реализованные в **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**, могут использоваться как для фигур, так и для текста. Давайте быстро рассмотрим основные методы класса **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. В следующем примере мы создаём прямоугольную 2D‑фигуру с текстом. Получив камеру для фигуры, мы изменяем её поворот, чтобы она выглядела как 3D‑модель. Установка плоского освещения и направление его к верху 3D‑модели добавляют объём модели. Изменённые материалы, высота экструдирования и цвет делают 3D‑модель более живой.  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Вот получившаяся 3D‑модель:

![todo:image_alt_text](img_01_01.png)

## **3D‑поворот**

Поворот 3D‑модели в PowerPoint можно выполнить через меню:

![todo:image_alt_text](img_02_01.png)

Чтобы повернуть 3D‑модель с помощью API Aspose.Slides, используйте метод **[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)**, задающий вращение камеры относительно 3D‑фигуры:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... задать другие параметры 3D-сцены
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **3D‑глубина и экструдирование**

Методы **[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** и **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** используются для создания экструдирования фигуры:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... задать другие параметры 3D-сцены
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


В PowerPoint глубина фигуры задаётся через:

![todo:image_alt_text](img_02_02.png)

## **3D‑градиент**

3D‑градиент может добавить объём 3D‑фигуре PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Вот как это выглядит:

![todo:image_alt_text](img_02_03.png)
  
Вы также можете создать градиент изображения:
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. настройка 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* свойства
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


Вот результат:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**

Чтобы создать 3D‑текст (WordArt), выполните следующее:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // настройка эффекта трансформации WordArt "Arch Up"
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Вот результат:

![todo:image_alt_text](img_02_05.png)

## **Часто задаваемые вопросы**

**Сохранятся ли 3D‑эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. Движок Slides 3D рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([images](/slides/ru/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), и т.п.).

**Могу ли я получить «эффективные» (окончательные) значения 3D‑параметров, учитывающие темы, наследование и т.д.?**

Да. Slides предоставляет API для [читать эффективные значения](/slides/ru/nodejs-java/shape-effective-properties/) (включая 3D‑освещение, фаски и т.д.), чтобы вы могли увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как и для [экспортированных изображений](/slides/ru/nodejs-java/convert-powerpoint-to-png/).
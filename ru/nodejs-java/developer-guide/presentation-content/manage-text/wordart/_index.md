---
title: Создать и применить эффекты WordArt в Node.js
linktitle: WordArt
type: docs
weight: 110
url: /ru/nodejs-java/wordart/
keywords:
- WordArt
- создание WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- преобразование WordArt
- 3D‑эффект
- эффект внешней тени
- эффект внутренней тени
- Node.js
- JavaScript
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides for Node.js via Java. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом в Node.js."
---
## **Обзор**

Эффекты WordArt позволяют стилизовать текст с помощью заливок, контуров, теней, отражений, свечения, преобразований и 3D‑форматирования. В этой статье описывается, как создавать и настраивать эти эффекты в презентациях PowerPoint с помощью Aspose.Slides for Node.js via Java без установки Microsoft Office.

## **Создание простого шаблона WordArt и применение его к тексту**

В следующих примерах создаётся простой стиль WordArt путём задания текста, шрифта, шаблона заливки и контура.

Каждый пример создаёт новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. В первом примере текст устанавливается как «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Установите шрифт Arial Black размером 36 пунктов, чтобы форматирование было более заметным:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Примените шаблон [SmallGrid](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/patternstyle/#SmallGrid) с темно‑оранжевым передним планом и белой заливкой, затем добавьте чёрный контур текста шириной 1 пункт:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применение других эффектов WordArt**

В следующих примерах показано, как применять тени, отражения, свечение, преобразования и 3D‑эффекты к тексту.

### **Применение внешних теневых эффектов**

Внешняя тень добавляет глубину, размещая тень позади текста. Вы можете настроить её цвет, направление, расстояние, радиус размытия, масштаб и наклон.

В этом примере вызывается [enableOuterShadowEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) и задаётся чёрная тень с радиусом размытия 4 пункта, направлением 230 градусов и расстоянием 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон отклоняет её на 20 градусов. Альфа‑преобразование устанавливает непрозрачность 32 %:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}

- Когда внешняя и предустановленная тени используются одновременно, применяется только внешняя тень.
- Если одновременно применяются внешняя и внутренняя тени, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.

{{% /alert %}}

### **Применение эффектов отражения**

Отражение создаёт зеркальную копию текста. Регулируйте его позицию, масштаб, размытие и непрозрачность, чтобы контролировать внешний вид.

В этом примере вызывается [enableReflectionEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) и отражение отражается вертикально с масштабом ‑100 %. Используется радиус размытия 0,5 пункта и расстояние 4,72 пункта. Непрозрачность уменьшается с 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![Эффект отражения](reflection_effect.png)

### **Применение свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Регулируйте его цвет, непрозрачность и радиус, чтобы управлять эффектом.

В этом примере вызывается [enableGlowEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) и применяется красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![Эффект свечения](glow_effect.png)

### **Применение преобразований WordArt**

Преобразования WordArt изгибают, растягивают или искажают блок текста.

Установите [setTransform](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setTransform) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textshapetype/#ArchUpPour), чтобы изогнуть весь текстовый фрейм вверх:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![Преобразование WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java предоставляет набор предопределённых [типа преобразований](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textshapetype/).

{{% /alert %}}

### **Применение 3D‑эффектов к фигурам и тексту**

Вы можете применять 3D‑эффекты к фигуре или к её тексту. Фаски, экструзия, освещение и параметры камеры определяют конечный вид.

В следующем примере используется [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/) для добавления круглых фасок, оранжевой экструзии и тёмно‑красного контура к прямоугольнику. Размеры фасок, высота экструзии, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, вращённое на 40 градусов вокруг оси Z, и перспективная камера задают внешний вид:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Получившаяся фигура:

![3D‑эффект фигуры](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Меньшие фаски формируют края букв, а экструзия и освещение придают тексту глубину:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Получившийся текст:

![3D‑эффект текста](text_3D_effect.png)

{{% alert color="info" title="Note" %}}

Применение 3D‑эффектов к тексту или к их фигурам — и взаимодействие между этими эффектами — регулируются особыми правилами. Рассмотрим сцену, включающую как текст, так и фигуру, содержащую его. 3D‑эффект включает 3D‑представление объекта и сцену, в которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применяется только к тексту.

Эти поведения относятся к методам [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getLightRig) и [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getCamera).

{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, одновременно удерживая 3D‑форматирование его фигуры, см. раздел [Keep Text Flat on a 3D Shape](/slides/ru/nodejs-java/3d-presentation/) для сравнения обеих настроек и полного примера на JavaScript.

## **FAQ**

**Можно ли использовать эффекты WordArt с различными шрифтами или алфавитами (например, арабским, китайским)?**

Да, Aspose.Slides for Node.js via Java поддерживает Unicode и работает со всеми основными шрифтами и алфавитами. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам макета слайда?**

Да, эффекты WordArt можно применять к фигурам на мастер‑слайдах, включая заполнитель заголовка, нижний колонтитул или фоновой текст. Изменения в макете мастера отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечение и градиентные заливки, могут немного увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно незначительна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете рендерить слайды с WordArt в изображения (например, PNG, JPEG) с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage) или рендерить отдельные фигуры с помощью [Shape.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getImage). Это позволяет просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
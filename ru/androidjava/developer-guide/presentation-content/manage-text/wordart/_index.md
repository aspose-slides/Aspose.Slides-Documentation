---
title: Создание и применение эффектов WordArt на Android
linktitle: WordArt
type: docs
weight: 110
url: /ru/androidjava/wordart/
keywords:
- WordArt
- Создать WordArt
- Шаблон WordArt
- Эффект WordArt
- Эффект тени
- Эффект отражения
- Эффект свечения
- Трансформация WordArt
- 3D-эффект
- Эффект внешней тени
- Эффект внутренней тени
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides for Android via Java. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом на Android."
---
## **Обзор**

Эффекты WordArt позволяют стилизовать текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3D‑форматирования. Эта статья объясняет, как создавать и настраивать эти эффекты в презентациях PowerPoint с использованием Aspose.Slides for Android via Java без установки Microsoft Office.

## **Создание простого шаблона WordArt и применение его к тексту**

Следующие примеры создают простой стиль WordArt, задавая текст, шрифт, узор заливки и контур.

Каждый пример создаёт новую презентацию и добавляет прямоугольник на первый слайд; исходный файл не требуется. Первый пример задаёт текст «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Установите шрифт Arial Black размером 36 пунктов, чтобы форматирование было более заметным:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Примените узор [SmallGrid](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/patternstyle/#SmallGrid) с тёмно‑оранжевым передним планом и белым фоном, затем добавьте чёрный контур текста шириной 1 пункт:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The simple WordArt template](WordArt_template.png)

## **Применение других эффектов WordArt**

Следующие примеры показывают, как применять тени, отражения, свечение, трансформации и 3D‑эффекты к тексту.

### **Применение внешних теней**

Внешняя тень создаёт глубину, размещая тень за текстом. Вы можете настроить её цвет, направление, дистанцию, радиус размытия, масштаб и наклон.

Этот пример вызывает [enableOuterShadowEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) и задаёт чёрную тень с радиусом размытия 4 пункта, направлением 230° и дистанцией 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон tilts её на 20°. Преобразование альфа‑канала задаёт непрозрачность 32%:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- При одновременном использовании внешних и предустановленных теней применяется только внешняя тень.
- Если одновременно использовать внешние и внутренние тени, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.
{{% /alert %}}

### **Применение отражений**

Отражение создаёт зеркальное копирование текста. Настраивайте его позицию, масштаб, размытие и непрозрачность, чтобы управлять внешним видом.

Этот пример вызывает [enableReflectionEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) и переворачивает отражение вертикально с масштабом –100%. Используется радиус размытия 0.5 пункта и дистанция 4.72 пункта. Непрозрачность уменьшается с 60% до 0.9% между позициями 0% и 60% вдоль отражения:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The Reflection effect](reflection_effect.png)

### **Применение свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Настраивайте его цвет, непрозрачность и радиус, чтобы управлять эффектом.

Этот пример вызывает [enableGlowEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) и применяет красное свечение с непрозрачностью 54% и радиусом 7 пунктов:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The Glow effect](glow_effect.png)

### **Применение трансформаций WordArt**

Трансформации WordArt изгибают, растягивают или искажают блок текста.

Установите [setTransform](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textshapetype/#ArchUpPour), чтобы изогнуть весь текстовый фрейм вверх:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java предоставляет набор предопределённых [transformation types](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Применение 3D‑эффектов к фигурам и тексту**

Вы можете применять 3D‑эффекты к фигуре или к её тексту. Склёочки, экструзия, освещение и параметры камеры управляют финальным видом.

Следующий пример использует [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/) для добавления круглых склёочков, оранжевой экструзии и тёмно‑красного контура к прямоугольнику. Размеры склёочков, высота экструзии, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, повернутое на 40° вокруг оси Z, и перспективная камера определяют внешний вид:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Полученная фигура:

![The shape 3D effect](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Меньшие склёочки формируют края букв, а экструзия и освещение придают тексту объём:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Полученный текст:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или к их фигурам — а также взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрим сцену, включающую как текст, так и содержащую его фигуру. 3D‑эффект включает 3D‑репрезентацию объекта и сцену, в которой он размещён.
- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑репрезентация, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применяется только к тексту.
Эти поведения относятся к методам [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/#getLightRig--) и [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, одновременно сохраняя 3D‑форматирование фигуры, см. [Keep Text Flat on a 3D Shape](/slides/ru/androidjava/3d-presentation/) для сравнения обеих настроек и полного примера на Java.

## **FAQ**

**Можно ли использовать эффекты WordArt с разными шрифтами или письменными системами (например, арабским, китайским)?**

Да, Aspose.Slides for Android via Java поддерживает Unicode и работает со всеми основными шрифтами и письменными системами. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, эффекты WordArt можно применять к фигурам на шаблонах мастер‑слайдов, включая заполнители заголовков, колонтитулы или фоновый текст. Изменения, внесённые в макет шаблона, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла из‑за добавленных метаданных форматирования, но разница обычно пренебрежимо мала.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, можно отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью [ISlide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getImage--), либо отрисовывать отдельные фигуры через [IShape.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getImage--). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
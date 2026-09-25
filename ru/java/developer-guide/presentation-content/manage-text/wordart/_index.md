---
title: Создать и применить эффекты WordArt в Java
linktitle: WordArt
type: docs
weight: 110
url: /ru/java/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D‑эффект
- внешний эффект тени
- внутренний эффект тени
- Java
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides for Java. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом на Java."
---
## **Обзор**

Эффекты WordArt позволяют оформить текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3‑D‑форматирования. В этой статье объясняется, как создавать и настраивать эти эффекты в презентациях PowerPoint с помощью Aspose.Slides for Java без установленного Microsoft Office.

## **Создать простой шаблон WordArt и применить его к тексту**

Следующие примеры создают простой стиль WordArt, задавая текст, шрифт, узор заливки и контур.

Каждый пример создает новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. В первом примере текст устанавливается в «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

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

Примените узор [SmallGrid](https://reference.aspose.com/slides/ru/java/com.aspose.slides/patternstyle/#SmallGrid) с тёмно‑оранжевым передним планом и белой заливкой, затем добавьте чёрный контур текста толщиной 1 пункт:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color darkOrange = new Color(255, 140, 0);
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

## **Применить другие эффекты WordArt**

Следующие примеры показывают, как применять тени, отражения, свечение, трансформации и 3‑D‑эффекты к тексту.

### **Применить внешние тени**

Внешняя тень придаёт глубину, помещая её за текст. Можно настроить цвет, направление, дистанцию, радиус размытия, масштаб и наклон.

В этом примере вызывается [enableOuterShadowEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) и задаётся чёрная тень с радиусом размытия 4 пункта, направлением 230 градусов и дистанцией 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон наклоняет её на 20 градусов. Преобразование альфа‑канала задаёт непрозрачность 32 %:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
- Если одновременно используются внешняя и внутренняя тени, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.
{{% /alert %}}

### **Применить эффекты отражения**

Отражение создаёт зеркальную копию текста. Регулируйте позицию, масштаб, размытие и непрозрачность, чтобы управлять внешним видом.

В этом примере вызывается [enableReflectionEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effectformat/#enableReflectionEffect--) и отражение переворачивается вертикально с масштабом –100 %. Используется радиус размытия 0,5 пункта и дистанция 4,72 пункта. Непрозрачность уменьшается с 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

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

### **Применить эффекты свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Регулируйте цвет, непрозрачность и радиус, чтобы контролировать эффект.

В этом примере вызывается [enableGlowEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effectformat/#enableGlowEffect--) и применяется красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **Применить трансформации WordArt**

Трансформации WordArt изгибают, растягивают или деформируют блок текста.

Установите [setTransform](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframeformat/#setTransform-int-) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textshapetype/#ArchUpPour), чтобы изогнуть весь текстовый кадр вверх:

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
Aspose.Slides for Java предоставляет набор предопределённых [transformation types](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Применить 3‑D‑эффекты к фигурам и тексту**

Можно применять 3‑D‑эффекты к фигуре или к её тексту. Скосы, выдавливание, освещение и настройки камеры определяют окончательный вид.

Следующий пример использует [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/) для добавления круглых скосов, оранжевого выдавливания и тёмно‑красного контура к прямоугольнику. Размеры скосов, высота выдавливания, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, повернутое на 40 градусов вокруг оси Z, и перспективная камера задают внешний вид:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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

Этот пример применяет аналогичное 3‑D‑форматирование к тексту через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Меньшие скосы формируют края букв, а выдавливание и освещение добавляют глубину:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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
Применение 3‑D‑эффектов к тексту или его фигурам — и взаимодействие между этими эффектами — регулируется особыми правилами. Рассмотрим сцену, включающую и текст, и содержащую его фигуру. 3‑D‑эффект включает 3‑D‑представление объекта и сцену, в которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3‑D‑представление, используется сцена текста.
- Если у фигуры нет 3‑D‑эффекта вообще, она считается плоской, и 3‑D‑эффект применяется только к тексту.

Эти поведения относятся к методам [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/#getLightRig--) и [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, при этом оставив 3‑D‑форматирование фигуры, смотрите раздел [Keep Text Flat on a 3D Shape](/slides/ru/java/3d-presentation/) для сравнения настроек и полного примера на Java.

## **FAQ**

**Можно ли использовать эффекты WordArt с разными шрифтами или системами письма (например, арабским, китайским)?**

Да, Aspose.Slides for Java поддерживает Unicode и работает со всеми основными шрифтами и системами письма. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифта и отрисовка могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, эффекты WordArt можно применять к фигурам на мастер‑слайдах, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения в макете мастера будут отражаться на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно незначительна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, можно отрисовывать слайды, содержащие WordArt, в изображения (например, PNG, JPEG) с помощью [ISlide.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getImage--), либо отрисовывать отдельные фигуры с помощью [IShape.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getImage--). Это позволяет просмотреть результат в памяти или на экране перед сохранением или экспортом полной презентации.
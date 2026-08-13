---
title: Создание и применение эффектов WordArt на Android
linktitle: WordArt
type: docs
weight: 110
url: /ru/androidjava/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides для Android. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом на Java."
---
## **Обзор**

Эффекты WordArt позволяют добавить визуально привлекательный стилизованный текст в ваши презентации PowerPoint. С помощью Aspose.Slides разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint, без необходимости установки Office. В этой статье представлен обзор работы с WordArt, включая применение трансформаций текста, стилей заливки, контуров, теней и других вариантов форматирования, чтобы сделать содержимое презентации более выразительным и захватывающим. WordArt позволяет рассматривать текст как графический объект. Он состоит из эффектов или специальных модификаций, применяемых к тексту для повышения его привлекательности или заметности.

## **Создание простого шаблона WordArt и его применение к тексту**

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью этого Java‑кода: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Теперь устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметен, используя следующий код:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В правом меню вы можете выбрать предопределённый эффект WordArt. В левом меню можно задать параметры для нового WordArt. 

Ниже перечислены некоторые доступные параметры и опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем к тексту цвет шаблона [SmallGrid](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PatternStyle#SmallGrid) и добавляем чёрный контур шириной 1 пиксель, используя следующий код:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Полученный текст:

![todo:image_alt_text](image-20200930114108-4.png)

## **Применение других эффектов WordArt**

**Использование Microsoft PowerPoint**

Из интерфейса программы вы можете применять эти эффекты к тексту, текстовому блоку, фигуре или подобному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Светящееся (Glow) могут применяться к тексту; 3D‑формат и 3D‑вращение – к текстовому блоку; Свойство «Мягкие края» может применяться к объекту Shape (оно сохраняет эффект, даже если 3D‑формат не установлен). 

### **Применение теневых эффектов**

Здесь мы настраиваем свойства, относящиеся только к тексту. Применяем теневой эффект к тексту с помощью этого Java‑кода:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow. 

С PresetShadow можно применить предустановленную тень к тексту. 

**Использование Microsoft PowerPoint**

В PowerPoint доступен только один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides позволяет одновременно применять два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### **Применение отражающих эффектов к тексту**

Мы добавляем отражение к тексту с помощью следующего примера кода на Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **Применение светящихся эффектов к тексту**

Мы применяем светящийся эффект к тексту, чтобы он светился или выделялся, используя следующий код:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Вы можете менять параметры тени, отражения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### **Использование трансформаций в WordArt**

Мы применяем свойство Transform (действующее на весь блок текста) с помощью следующего кода:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

И Microsoft PowerPoint, и Aspose.Slides для Android через Java предоставляют определённое количество предопределённых типов трансформаций.

{{% /alert %}} 

**Использование PowerPoint**

Для доступа к предопределённым типам трансформаций перейдите: **Format** → **TextEffect** → **Transform**

**Использование Aspose.Slides**

Для выбора типа трансформации используйте перечисление TextShapeType. 

### **Применение 3D‑эффектов к тексту и фигурам**

Мы задаём 3D‑эффект текстовой фигуре с помощью следующего примера кода:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Полученный текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту следующим Java‑кодом:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

Применение 3D‑эффектов к текстам или их фигурам и взаимодействие между эффектами подчиняется определённым правилам. 

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает 3D‑представление объекта и сцену, на которой объект размещён. 

- Когда сцена задаётся одновременно для фигуры и текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Применение внешних теневых эффектов к тексту**
Aspose.Slides для Android через Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinnershadow/), позволяющие применять теневые эффекты к тексту, находящемуся в [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте к слайду AutoShape типа Rectangle.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите свойство FillType AutoShape в значение NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте свойство BlurRadius тени.  
8. Установите Direction тени.  
9. Задайте Distance тени.  
10. Установите RectangleAlign в TopLeft.  
11. Установите PresetColor тени в Black.  
12. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода на Java, реализующий перечисленные шаги, показывает, как применить внешний теневой эффект к тексту:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");

    // Отключить заливку фигуры, если нужно получить тень текста
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавить внешнюю тень и установить все необходимые параметры
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Сохранить презентацию на диск
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение внутренних теневых эффектов к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Установите все необходимые параметры.  
6. Установите ColorType в Scheme.  
7. Задайте Scheme Color.  
8. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода (основанный на перечисленных шагах) показывает, как применить внутренний теневой эффект к тексту в Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Включить InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Установить все необходимые параметры
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Установить ColorType как Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Установить Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Сохранить презентацию
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Можно ли использовать эффекты WordArt с разными шрифтами или алфавитами (например, арабским, китайским)?

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и алфавитами. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя наличие шрифта и его отображение зависят от системных шрифтов.

### Можно ли применять эффекты WordArt к элементам шаблона слайдов?

Да, эффекты WordArt можно применять к объектам на мастер‑слайдах, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет мастера, отразятся на всех связанных слайдах.

### Влияют ли эффекты WordArt на размер файла презентации?

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла за счёт добавления метаданных форматирования, но разница обычно незначительна.

### Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?

Да, можно отрендерить слайды с WordArt в изображения (например, PNG, JPEG), используя метод `getImage` интерфейсов [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/). Это позволяет просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
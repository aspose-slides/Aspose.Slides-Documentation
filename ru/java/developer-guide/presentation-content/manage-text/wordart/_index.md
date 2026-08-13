---
title: Создание и применение эффектов WordArt в Java
linktitle: WordArt
type: docs
weight: 110
url: /ru/java/wordart/
keywords:
- WordArt
- создание WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D‑эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides для Java. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом в Java."
---
## **Обзор**

Эффекты WordArt позволяют добавлять визуально привлекательный стилизованный текст в презентации PowerPoint. С помощью Aspose.Slides разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint, без необходимости установки Office. В этой статье представляется обзор работы с WordArt, включая применение трансформаций текста, стилей заливки, контуров, теней и других параметров форматирования, чтобы сделать содержание вашей презентации более выразительным и захватывающим. WordArt позволяет рассматривать текст как графический объект. Это набор эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным.

## **Создание простого шаблона WordArt и применение его к тексту**

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
Теперь мы задаём высоту шрифта текста большим значением, чтобы эффект был более заметным, используя следующий код:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

В меню справа вы можете выбрать предопределённый эффект WordArt. В меню слева можно указать настройки для нового WordArt. 

Ниже представлены некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем к тексту цвет шаблона [SmallGrid](https://reference.aspose.com/slides/ru/java/com.aspose.slides/PatternStyle#SmallGrid) и добавляем чёрную границу шириной 1 пиксель с помощью следующего кода:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Через интерфейс программы вы можете применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Свечение могут быть применены к тексту; эффекты 3D‑формат и 3D‑поворот — к блоку текста; свойство Мягкие края может быть применено к объекту Shape (оно сохраняет действие даже при отсутствии свойства 3D‑формат). 

### **Применение теней**

Здесь мы планируем задать свойства, относящиеся только к тексту. Применяем эффект тени к тексту с помощью следующего Java‑кода:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint можно использовать один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides действительно позволяет одновременно применять два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- Когда OuterShadow и PresetShadow используются вместе, применяется только эффект OuterShadow. 
- Если OuterShadow и InnerShadow применяются одновременно, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### **Применение отображения к текстам**

Мы добавляем отображение к тексту с помощью этого примера кода на Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Применение свечения к тексту**

Мы применяем эффект свечения к тексту, чтобы он сиял или выделялся, используя следующий код:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Вы можете изменить параметры тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### **Использование преобразований в WordArt**

Мы используем свойство Transform (применимое к всему блоку текста) с помощью следующего кода:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Как Microsoft PowerPoint, так и Aspose.Slides for Java предоставляют определённое количество предопределённых типов трансформаций. 

{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предопределённым типам трансформаций, перейдите: **Format**->**TextEffect**->**Transform**  

**Использование Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType. 

### **Применение 3D‑эффектов к тексту и фигурам**

Мы задаём 3D‑эффект текстовой фигуре с помощью следующего примера кода:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Полученный текст и его фигура:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью этого Java‑кода:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Применение 3D‑эффектов к текстам или их фигурам и взаимодействие между эффектами основаны на определённых правилах. 

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, на которой объект размещён. 

- Если сцена задаётся как для фигуры, так и для текста, приоритет получает сцена фигуры — сцена текста игнорируется. 
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, а 3D‑эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Применение внешних теней к тексту**
Aspose.Slides for Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinnershadow/), которые позволяют применять теневые эффекты к тексту, содержащемуся в [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframe/). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте к слайду AutoShape типа Rectangle.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите свойство FillType AutoShape в значение NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте BlurRadius тени.  
8. Задайте Direction тени.  
9. Задайте Distance тени.  
10. Установите RectanglelAlign в значение TopLeft.  
11. Установите PresetColor тени в Black.  
12. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Пример кода на Java, реализующий перечисленные шаги, показывает, как применить эффект внешней тени к тексту:

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

    // Добавить внешнюю тень и задать все необходимые параметры
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Сохранить презентацию на диск
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение внутренней тени к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Задайте все необходимые параметры.  
6. Установите ColorType в значение Scheme.  
7. Задайте Scheme Color.  
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода (основанный на вышеописанных шагах) показывает, как применить эффект внутренней тени к тексту в фигуре на Java:

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

### Можно ли использовать эффекты WordArt с разными шрифтами или письменностями (например, арабский, китайский)?

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и письменностями. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя наличие шрифтов и их отображение могут зависеть от системных шрифтов.

### Можно ли применять эффекты WordArt к элементам мастер‑слайдов?

Да, вы можете применять эффекты WordArt к фигурам на мастер‑слайдах, включая плейсхолдеры заголовка, нижние колонтитулы или фоновый текст. Изменения в макете мастера отразятся на всех связанных слайдах.

### Влияют ли эффекты WordArt на размер файла презентации?

Незначительно. Эффекты WordArt, такие как тени, свечение и градиентные заливки, могут слегка увеличить размер файла из‑за добавленных метаданных форматирования, но разница обычно пренебрежимо мала.

### Можно ли просмотреть результат эффектов WordArt без сохранения презентации?

Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `getImage` интерфейсов [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/). Это позволяет предварительно увидеть результат в памяти или на экране до сохранения или экспорта полной презентации.
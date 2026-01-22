---
title: Создание и применение эффектов WordArt на JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /ru/nodejs-java/wordart/
keywords:
- WordArt
- Создать WordArt
- Шаблон WordArt
- Эффект WordArt
- Эффект тени
- Эффект отображения
- Эффект свечения
- Трансформация WordArt
- 3D‑эффект
- Эффект внешней тени
- Эффект внутренней тени
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides для Node.js. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом."
---

## **О WordArt?**

WordArt (или Word Art) — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст линией или залить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Также можно наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 
WordArt позволяет обращаться с текстом так же, как с графическим объектом. Обычно WordArt представляет собой набор эффектов или специальных модификаций текста, делающих его более привлекательным или заметным. 
{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, необходимо выбрать один из предопределённых шаблонов WordArt. Шаблон WordArt — это набор эффектов, применяемый к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides для Node.js через Java версии 20.10 мы реализовали поддержку WordArt и внесли улучшения в эту функцию в последующих выпусках Aspose.Slides для Node.js через Java.  
С помощью Aspose.Slides для Node.js через Java вы можете легко создавать собственные шаблоны WordArt (один эффект или комбинацию эффектов) на JavaScript и применять их к текстам.

## **Создание простого шаблона WordArt и применение его к тексту**

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью этого кода JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Затем мы увеличиваем высоту шрифта текста, чтобы эффект был более заметным, используя следующий код:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В меню справа вы можете выбрать предопределённый эффект WordArt. В меню слева можно задать настройки для нового WordArt. 

Ниже перечислены некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем к тексту цвет шаблона [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid), а также добавляем черную границу толщиной 1 с помощью следующего кода:
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## **Применение других эффектов WordArt**

**Использование Microsoft PowerPoint**

Из раздела программы можно применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту можно применить эффекты Тень, Отражение и Светящееся; к блоку текста — эффекты 3D‑формат и 3D‑поворачивания; к объекту Shape можно применить свойство Мягкие края (оно действует, даже если свойство 3D‑формат не задано). 

### **Применение эффектов тени**

Здесь мы будем задавать свойства, относящиеся только к тексту. Применяем эффект тени к тексту с помощью следующего кода на JavaScript:
```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```


API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow.  

С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint можно использовать один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides действительно позволяет одновременно применять два типа теней: InnerShadow и PresetShadow.

Примечания:

- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow.  
- Если одновременно используют OuterShadow и InnerShadow, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### **Применение отображения к текстам**

Мы добавляем отображение к тексту с помощью следующего примера кода на JavaScript:
```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```


### **Применение эффекта свечения к текстам**

Мы применяем к тексту эффект свечения, чтобы он светился или выделялся, используя следующий код:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Результат выполнения:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Вы можете изменять параметры тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 
{{% /alert %}} 

### **Использование трансформаций в WordArt**

Мы используем свойство Transform (присущее всему блоку текста) с помощью следующего кода:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
И Microsoft PowerPoint, и Aspose.Slides для Node.js через Java предоставляют определённое количество предопределённых типов трансформаций. 
{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предопределённым типам трансформаций, перейдите: **Format** → **TextEffect** → **Transform**

**Использование Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType. 

### **Применение 3D‑эффектов к текстам и фигурам**

Мы задаём 3D‑эффект для текстовой фигуры с помощью следующего примера кода:
```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


Получившийся текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью следующего кода JavaScript:
```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


Результат выполнения:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Применение 3D‑эффектов к текстам или их формам и взаимодействие эффектов основаны на определённых правилах.  

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, на которой объект размещён.  

- Когда сцена задана и для фигуры, и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется.  
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.  
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту.  

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Применение внешних теней к текстам**

Aspose.Slides для Node.js через Java предоставляет классы [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/) и [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/innershadow/) , позволяющие применять эффекты теней к тексту, находящемуся в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте к слайду AutoShape типа Rectangle.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите свойство FillType у AutoShape в значение NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте BlurRadius тени.  
8. Задайте Direction тени.  
9. Задайте Distance тени.  
10. Установите RectanglelAlign в TopLeft.  
11. Задайте PresetColor тени в Black.  
12. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получить ссылку на слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");
    // Отключить заливку фигуры, если нужно получить тень текста
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Добавить внешнюю тень и установить все необходимые параметры
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Write the presentation to disk
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Применение внутренней тени к фигурам**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Задайте все необходимые параметры.  
6. Установите ColorType в Scheme.  
7. Задайте Scheme Color.  
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получить ссылку на слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Включить эффект внутренней тени
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Установить все необходимые параметры
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Установить ColorType как Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Установить Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Сохранить презентацию
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли использовать эффекты WordArt с разными шрифтами или системами письма (например, арабским, китайским)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и системами письма. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, вы можете применять эффекты WordArt к фигурам на шаблонах слайдов, включая заполнители заголовков, нижние колонтитулы или фоновый текст. Изменения, внесённые в шаблон, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла за счёт добавления метаданных форматирования, но разница обычно несущественна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете визуализировать слайды с WordArt в виде изображений (например, PNG, JPEG), используя метод `getImage` из классов [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) или [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/). Это позволяет просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
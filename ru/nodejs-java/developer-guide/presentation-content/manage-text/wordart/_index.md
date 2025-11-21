---
title: WordArt
type: docs
weight: 110
url: /ru/nodejs-java/wordart/
---

## **О WordArt?**

WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст контуром или заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Также можно наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 

WordArt позволяет обращаться с текстом так же, как с графическим объектом. Как правило, WordArt состоит из эффектов или специальных модификаций текста, делая его более привлекательным или заметным. 

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, нужно выбрать один из предустановленных шаблонов WordArt. Шаблон WordArt — это набор эффектов, применяемый к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides for Node.js via Java 20.10 мы реализовали поддержку WordArt и внесли улучшения в эту функцию в последующих выпусках Aspose.Slides for Node.js via Java. 

С Aspose.Slides for Node.js via Java вы можете легко создать собственный шаблон WordArt (один эффект или их комбинацию) на JavaScript и применить его к тексту. 

## **Создание простого шаблона WordArt и применение его к тексту**

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью следующего кода JavaScript:
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

Затем мы устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметным, с помощью этого кода:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В меню справа можно выбрать предустановленный эффект WordArt. В меню слева можно задать параметры нового WordArt. 

Это некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет узора [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем чёрную границу шириной 1 с помощью этого кода:
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

Из класса программы можно применять эти эффекты к тексту, текстовому блоку, фигуре или похожему элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту могут быть применены эффекты Тень, Отражение и Свечение; к текстовому блоку — эффекты 3D-формат и 3D-поворот; свойство Мягкие края может быть применено к объекту Shape (оно сохраняет эффект, даже если свойство 3D‑формат не задано). 

### **Применение эффектов Тени**

Здесь мы намерены задать свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода на JavaScript:
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

С PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint можно использовать один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides действительно позволяет применять одновременно два типа теней: InnerShadow и PresetShadow. 

**Примечания:**

- Если одновременно используются OuterShadow и PresetShadow, применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, конечный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется эффект OuterShadow. 

### **Применение отображения к текстам**

Мы добавляем отображение к тексту с помощью этого примера кода на JavaScript:
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

Мы применяем эффект свечения к тексту, чтобы он светился или выделялся, используя этот код:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете менять параметры тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### **Использование трансформаций в WordArt**

Мы используем свойство Transform (присущее всему блоку текста) с помощью этого кода:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

И Microsoft PowerPoint, и Aspose.Slides for Node.js via Java предоставляют определённое количество предустановленных типов трансформаций.

{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предустановленным типам трансформаций, пройдите: **Format** -> **TextEffect** -> **Transform** 

**Использование Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType. 

### **Применение 3D-эффектов к текстам и фигурам**

Мы задаём 3D-эффект для текстовой фигуры с помощью этого образца кода:
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

Мы применяем 3D-эффект к тексту с помощью этого кода JavaScript:
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


Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D-эффектов к текстам или их формам и взаимодействие между эффектами основаны на определённых правилах. 

Рассмотрим сцену для текста и фигуру, содержащую этот текст. 3D-эффект содержит представление 3D‑объекта и сцену, в которой объект размещён. 

- Если сцена задана и для фигуры, и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- В противном случае, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Применение внешних теней к тексту**

Aspose.Slides for Node.js via Java предоставляет классы [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) и [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow), позволяющие применять эффекты теней к тексту, содержащемуся в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте к слайду AutoShape прямоугольного типа.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите FillType AutoShape в значение NoFill.  
6. Создайте экземпляр класса OuterShadow  
7. Установите BlurRadius тени.  
8. Установите Direction тени  
9. Установите Distance тени.  
10. Установите RectanglelAlign в TopLeft.  
11. Установите PresetColor тени в Black.  
12. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода на Java — реализация вышеуказанных шагов — показывает, как применить эффект внешней тени к тексту:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получить ссылку на слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Добавить TextFrame к Rectangle
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
    // Сохранить презентацию на диск
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
3. Добавьте AutoShape прямоугольного типа.  
4. Включите InnerShadowEffect.  
5. Установите все необходимые параметры.  
6. Установите ColorType как Scheme.  
7. Установите Scheme Color.  
8. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода (основываясь на указанных шагах) показывает, как добавить соединитель между двумя фигурами на JavaScript:
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
    // Включить InnerShadowEffect
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

**Можно ли использовать эффекты WordArt с различными шрифтами или системами письма (например, арабским, китайским)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и системами письма. Эффекты WordArt, такие как тень, заливка и контур, могут применяться независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, вы можете применять эффекты WordArt к фигурам на мастер‑слайдах, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет мастера, будут отражены на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно пренебрежимо мала.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете рендерить слайды с WordArt в изображения (например, PNG, JPEG), используя метод `getImage` из классов [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) или [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
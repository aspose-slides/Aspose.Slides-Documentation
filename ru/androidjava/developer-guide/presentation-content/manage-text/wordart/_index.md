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
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D‑эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides для Android. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным текстом на Java."
---

## **О WordArt?**

WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст, заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.п. Также можно наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 

WordArt позволяет обращаться с текстом так же, как с графическим объектом. Как правило, WordArt состоит из эффектов или специальных модификаций текста, делающих его более привлекательным или заметным. 

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, нужно выбрать один из готовых шаблонов WordArt. Шаблон WordArt — это набор эффектов, которые применяются к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides for Android via Java 20.10 мы внедрили поддержку WordArt и улучшили эту функцию в последующих выпусках Aspose.Slides for Android via Java.

С помощью Aspose.Slides for Android via Java вы можете легко создать собственный шаблон WordArt (один эффект или их комбинацию) в Java и применять его к текстам. 

## **Создание простого шаблона WordArt и применение его к тексту**

**Использование Aspose.Slides** 

Сначала создаём простой текст с помощью следующего кода Java: 
``` java
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

Теперь задаём высоту шрифта текста более большим значением, чтобы эффект был заметнее, через этот код:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В правой части меню можно выбрать предустановленный эффект WordArt. В левой части меню можно задать параметры нового WordArt. 

Ниже перечислены некоторые доступные параметры и опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем к тексту цвет шаблона [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) и добавляем чёрную границу шириной 1 пиксель с помощью следующего кода:
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


Полученный текст:

![todo:image_alt_text](image-20200930114108-4.png)

## **Применение других эффектов WordArt**

**Использование Microsoft PowerPoint**

Из интерфейса программы можно применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Светящийся контур могут быть применены к тексту; Формат 3D и Вращение 3D — к блоку текста; Свойство Мягкие края можно применить к объекту Shape (оно будет работать даже без свойства Формат 3D). 

### **Применение теневых эффектов**

Здесь мы будем задавать свойства, относящиеся только к тексту. Применяем теневой эффект к тексту с помощью следующего кода на Java:
``` java
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
```


API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow. 

С помощью PresetShadow можно задать тень для текста (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint доступен один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides позволяет применять одновременно два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### **Применение отражающих эффектов к тексту**

Мы добавляем отражение к тексту с помощью этого образца кода на Java:
``` java
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
```


### **Применение светящихся эффектов к тексту**

Мы применяем светящийся эффект к тексту, чтобы он сиял или выделялся, используя следующий код:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Можно изменять параметры тени, отражения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### **Использование трансформаций в WordArt**

Мы применяем свойство Transform (действующее на весь блок текста) с помощью следующего кода:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

И Microsoft PowerPoint, и Aspose.Slides for Android via Java предоставляют определённое количество предустановленных типов трансформаций.

{{% /alert %}} 

**Использование PowerPoint**

Чтобы открыть предустановленные типы трансформаций, перейдите: **Format** → **TextEffect** → **Transform**

**Использование Aspose.Slides**

Для выбора типа трансформации используйте перечисление TextShapeType. 

### **Применение 3D‑эффектов к тексту и фигурам**

Мы задаём 3D‑эффект для текстовой фигуры с помощью этого примера кода:
``` java
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
```


Полученный текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью следующего кода на Java:
``` java
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
```


Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D‑эффектов к текстам или их фигурам и взаимодействие между эффектами подчиняется определённым правилам. 

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, на которой объект размещён. 

- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Применение внешних теневых эффектов к тексту**
Aspose.Slides for Android via Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinnershadow/), позволяющие применять теневые эффекты к тексту, находящемуся в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте к слайду AutoShape типа Rectangle.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите для AutoShape свойство FillType, равное NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте BlurRadius тени.  
8. Установите Direction тени.  
9. Установите Distance тени.  
10. Установите RectanglelAlign в значение TopLeft.  
11. Установите PresetColor тени в Black.  
12. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода на Java, реализующий описанные шаги, демонстрирует, как применить внешний теневой эффект к тексту:
```java
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

    //Сохранить презентацию на диск
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Применение внутренних теневых эффектов к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Задайте все необходимые параметры.  
6. Установите ColorType в значение Scheme.  
7. Задайте Scheme Color.  
8. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода (основанный на вышеописанных шагах) показывает, как добавить соединитель между двумя фигурами в Java:
```java
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

**Можно ли использовать эффекты WordArt с разными шрифтами или системами письма (например, арабским, китайским)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и системами письма. Эффекты WordArt, такие как тень, заливка и контур, могут применяться независимо от языка, хотя доступность шрифтов и рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, вы можете применять эффекты WordArt к объектам на шаблонах слайдов, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения в шаблоне отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут незначительно увеличить размер файла за счёт дополнительного метаданных форматирования, но разница обычно пренебрежимо мала.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью метода `getImage` из интерфейсов [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/). Это позволяет предварительно увидеть результат в памяти или на экране перед сохранением или экспортом полной презентации.
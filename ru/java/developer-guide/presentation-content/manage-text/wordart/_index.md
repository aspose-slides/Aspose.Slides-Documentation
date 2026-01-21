---
title: Создание и применение эффектов WordArt в Java
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
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides для Java. Этот пошаговый гид помогает разработчикам улучшать презентации профессиональным текстом на Java."
---

## **О WordArt?**
WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст контуром или заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Также можно искажать, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 
WordArt позволяет обращаться с текстом так же, как с графическим объектом. Как правило, WordArt состоит из эффектов или специальных модификаций текста, делающих его более привлекательным или заметным. 
{{% /alert %}} 

**WordArt в Microsoft PowerPoint**
Чтобы использовать WordArt в Microsoft PowerPoint, необходимо выбрать один из предопределённых шаблонов WordArt. Шаблон WordArt — это набор эффектов, которые применяются к тексту или его форме. 

**WordArt в Aspose.Slides**
В Aspose.Slides для Java версии 20.10 мы реализовали поддержку WordArt и улучшили эту функцию в последующих выпусках Aspose.Slides для Java. 
С помощью Aspose.Slides для Java вы можете легко создавать собственный шаблон WordArt (один эффект или комбинацию эффектов) на Java и применять его к тексту. 

## **Создание простого шаблона WordArt и применение его к тексту**
**Использование Aspose.Slides** 
Сначала мы создаём простой текст с помощью этого кода Java: 
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

Затем мы задаём высоту шрифта текста большим значением, чтобы эффект был более заметным, с помощью этого кода:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Использование Microsoft PowerPoint**
Откройте меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В правом меню вы можете выбрать предопределённый эффект WordArt. В левом меню можно задать параметры нового WordArt. 

Ниже представлены некоторые доступные параметры или варианты:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**
Здесь мы применяем цвет узора [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем чёрную границу текста толщиной 1 с помощью следующего кода:
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


Полученный результат:

![todo:image_alt_text](image-20200930114108-4.png)

## **Применение других эффектов WordArt**
**Использование Microsoft PowerPoint**
В интерфейсе программы вы можете применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Свечение можно применить к тексту; эффекты 3D‑формат и 3D‑поворот — к блоку текста; свойство Мягкие границы можно применить к объекту Shape (оно сохраняет действие, даже если свойство 3D‑формат не задано). 

### **Применение теневых эффектов**
Здесь мы планируем задать свойства, относящиеся только к тексту. Мы применяем теневой эффект к тексту с помощью этого кода на Java:
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
С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**
В PowerPoint можно использовать один тип тени. Например:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**
Aspose.Slides действительно позволяет применять сразу два типа теней: InnerShadow и PresetShadow.  

**Примечания:**  
- Если одновременно используются OuterShadow и PresetShadow, применяется только эффект OuterShadow.  
- Если одновременно используются OuterShadow и InnerShadow, результат зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow.  

### **Применение Display к текстам**
Мы добавляем отображение к тексту с помощью следующего примера кода на Java:
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


### **Применение эффекта Glow к текстам**
Мы применяем эффект свечения к тексту, чтобы он блестел или выделялся, используя следующий код:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Вы можете изменять параметры тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 
{{% /alert %}} 

### **Использование трансформаций в WordArt**
Мы используем свойство Transform (находящееся в целом блоке текста) с помощью следующего кода:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
И Microsoft PowerPoint, и Aspose.Slides для Java предоставляют определённое количество предопределённых типов трансформаций. 
{{% /alert %}} 

**Использование PowerPoint**
Чтобы получить доступ к предопределённым типам трансформаций, перейдите: **Format** -> **TextEffect** -> **Transform**  

**Использование Aspose.Slides**
Чтобы выбрать тип трансформации, используйте перечисление TextShapeType.  

### **Применение 3D‑эффектов к тексту и фигурам**
Мы задаём 3D‑эффект форме текста с помощью следующего образца кода:
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

Мы применяем 3D‑эффект к тексту с помощью этого кода на Java:
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
Применение 3D‑эффектов к тексту или его фигурам и взаимодействие между эффектами основаны на определённых правилах.  
Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, на которой объект размещён.  
- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется.  
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.  
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, она плоская, и 3D‑эффект применяется только к тексту.  
Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().  
{{% /alert %}} 

## **Применение внешних теневых эффектов к тексту**
Aspose.Slides для Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/iinnershadow/), позволяющие применять теневые эффекты к тексту, находящемуся в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/). Выполните следующие шаги:  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте AutoShape типа Rectangle на слайд.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите свойство FillType AutoShape в значение NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте BlurRadius тени.  
8. Установите Direction тени.  
9. Задайте Distance тени.  
10. Установите RectanglelAlign в TopLeft.  
11. Установите PresetColor тени в Black.  
12. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Этот пример кода на Java — реализация вышеописанных шагов — показывает, как применить внешний теневой эффект к тексту:
```java
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавить TextFrame к Rectangle
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


## **Применение внутреннего теневого эффекта к фигурам**
Выполните следующие шаги:  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Установите все необходимые параметры.  
6. Установите ColorType в Scheme.  
7. Установите Scheme Color.  
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Этот пример кода (на основе приведённых шагов) показывает, как добавить соединитель между двумя фигурами на Java:
```java
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавить TextFrame к Rectangle
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

**Могу ли я использовать эффекты WordArt с различными шрифтами или сценариями (например, арабский, китайский)?**  
Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.  

**Могу ли я применять эффекты WordArt к элементам шаблона слайда?**  
Да, вы можете применять эффекты WordArt к фигурам на слайдах‑шаблонах, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет шаблона, отразятся на всех связанных слайдами.  

**Влияют ли эффекты WordArt на размер файла презентации?**  
Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла за счёт добавленных метаданных форматирования, однако разница обычно несущественна.  

**Могу ли я просмотреть результат эффектов WordArt без сохранения презентации?**  
Да, вы можете отрисовать слайды, содержащие WordArt, в виде изображений (например, PNG, JPEG), используя метод `getImage` из интерфейсов [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). Это позволяет просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.
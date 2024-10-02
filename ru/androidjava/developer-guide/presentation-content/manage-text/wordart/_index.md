---
title: WordArt
type: docs
weight: 110
url: /ru/androidjava/wordart/
---


## **Что такое WordArt?**
WordArt — это функция, которая позволяет применять эффекты к текстам, чтобы они выделялись. С помощью WordArt, например, вы можете обвести текст или заполнить его цветом (или градиентом), добавить к нему 3D-эффекты и т. д. Вы также можете наклонять, изгибать и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет обращаться с текстом так, как вы бы обращались с графическими объектами. В общем, WordArt состоит из эффектов или специальных модификаций, внесенных в тексты, чтобы сделать их более привлекательными или заметными.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предустановленных шаблонов WordArt. Шаблон WordArt — это набор эффектов, которые применяются к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для Android через Java 20.10 мы реализовали поддержку WordArt и внесли улучшения в функцию в последующих релизах Aspose.Slides для Android через Java.

С помощью Aspose.Slides для Android через Java вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинация эффектов) на Java и применить его к текстам.

## Создание простого шаблона WordArt и применение его к тексту

**Использование Aspose.Slides** 

Сначала мы создаем простой текст с помощью этого Java-кода: 

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
Теперь мы устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметным через этот код:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предустановленный эффект WordArt. Из меню слева вы можете настроить параметры для нового WordArt. 

Это некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет паттерна [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем черную границу текста шириной 1 с помощью этого кода:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Результирующий текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Использование Microsoft PowerPoint**

Из интерфейса программы вы можете применить эти эффекты к тексту, блоку текста, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты тени, отражения и свечения могут быть применены к тексту; 3D-формат и 3D-вращение могут быть применены к блоку текста; свойство мягких краев может применяться к объекту формы (оно все еще будет иметь эффект, когда свойство 3D-формата не установлено). 

### Применение эффектов теней

Здесь мы собираемся установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода на Java:

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

С помощью PresetShadow вы можете применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides фактически позволяет применять два типа теней одновременно: InnerShadow и PresetShadow.

**Примечания:**

- Когда используются OuterShadow и PresetShadow вместе, применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, полученный или примененный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект OuterShadow. 

### Применение отображения к текстам

Мы добавляем отображение к тексту через этот образец кода на Java:

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

### Применение эффекта свечения к текстам

Мы применяем эффект свечения к тексту, чтобы он сиял или выделялся, с помощью этого кода:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменить параметры для тени, отображения и свечения. Свойства эффектов устанавливаются для каждой части текста отдельно. 

{{% /alert %}} 

### Использование преобразований в WordArt

Мы используем свойство Transform (присуще всему блоку текста) через этот код:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для Android через Java предоставляют определенное количество предустановленных типов преобразований.

{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предустановленным типам преобразования, перейдите по пути: **Формат** -> **Эффект текста** -> **Преобразование**

**Использование Aspose.Slides**

Чтобы выбрать тип преобразования, используйте перечисление TextShapeType. 

### Применение 3D-эффектов к текстам и формам

Мы устанавливаем 3D-эффект к текстовой форме с помощью этого образца кода:

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

Результующий текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D-эффект к тексту с помощью этого кода на Java:

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

Применение 3D-эффектов к текстам или их формам и взаимодействие между эффектами основывается на определенных правилах. 

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D-эффект содержит 3D-репрезентацию объекта и сцену, на которой объект был размещен. 

- Когда сцена задана для обеих фигур и текста, сцена фигуры имеет более высокий приоритет — сцена текста игнорируется. 
- Когда у фигуры нет собственной сцены, но есть 3D-репрезентация, используется сцена текста. 
- В противном случае — когда у формы изначально нет 3D-эффекта — форма плоская, и 3D-эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().

{{% /alert %}} 

## **Применение эффектов внешней тени к текстам**
Aspose.Slides для Android через Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) и [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow), которые позволяют применять эффекты теней к тексту, представленному [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame). Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте автофигуру типа прямоугольник на слайд.
4. Доступ к TextFrame, связанному с автофигурой.
5. Установите FillType автофигуры на NoFill.
6. Создайте экземпляр класса OuterShadow.
7. Установите BlurRadius тени.
8. Установите направление тени.
9. Установите расстояние тени.
10. Установите RectangleAlign на TopLeft.
11. Установите PresetColor тени на черный.
12. Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот образец кода на Java — реализация вышеуказанных шагов — показывает, как применить эффект внешней тени к тексту:

```java
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа прямоугольник
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");

    // Отключить заливку фигуры на случай, если мы хотим получить тень текста
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавить внешнюю тень и установить все необходимые параметры
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Записать презентацию на диск
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение эффекта внутренней тени к фигурам**
Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Добавьте автофигуру типа прямоугольник.
4. Включите InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Этот образец кода (основанный на вышеуказанных шагах) показывает, как добавить соединитель между двумя фигурами на Java:

```java
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа прямоугольник
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Включить эффект внутренней тени
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Установить все необходимые параметры
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Установить ColorType как Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Установить цвет схемы
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Сохранить презентацию
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
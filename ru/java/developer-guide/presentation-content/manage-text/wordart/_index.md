---
title: WordArt
type: docs
weight: 110
url: /java/wordart/
---

## **Что такое WordArt?**
WordArt или Word Art — это функция, которая позволяет применять эффекты к текстам, чтобы сделать их более заметными. С помощью WordArt, например, вы можете обвести текст или заполнить его цветом (или градиентом), добавить к нему 3D-эффекты и так далее. Вы также можете наклонять, изгибать и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет вам рассматривать текст так же, как графический объект. В общем, WordArt состоит из эффектов или специальных модификаций, примененных к текстам, чтобы сделать их более привлекательными или заметными.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предопределенных шаблонов WordArt. Шаблон WordArt – это набор эффектов, который применяется к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для Java 20.10 мы реализовали поддержку WordArt и сделали улучшения функции в последующих выпусках Aspose.Slides для Java.

С Aspose.Slides для Java вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинация эффектов) на Java и применить его к текстам.

## Создание простого шаблона WordArt и его применение к тексту

**Используя Aspose.Slides**

Сначала создадим простой текст с помощью этого кода на Java:

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
Теперь мы устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметным с помощью следующего кода:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Используя Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предопределённый эффект WordArt. В меню слева вы можете задать настройки для нового WordArt.

Вот некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Используя Aspose.Slides**

Здесь мы применяем цвет шаблона [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем черную рамку шириной 1 с помощью этого кода:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Используя Microsoft PowerPoint**

Из интерфейса программы вы можете применять эти эффекты к тексту, текстовому блоку, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тени, Отражения и Сияния могут быть применены к тексту; эффекты 3D Формата и 3D Вращения могут быть применены к текстовому блоку; свойство Мягкие края может быть применено к объекту Форма (оно все равно имеет эффект, даже если свойство 3D Формата не задано).

### Применение эффектов тени

Здесь мы намерены установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода на Java:

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

API Aspose.Slides поддерживает три типа теней: Внешняя тень, Внутренняя тень и Предустановленная тень.

С помощью Предустановленной тени вы можете применить тень к тексту (используя предустановленные значения).

**Используя Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Используя Aspose.Slides**

Aspose.Slides на самом деле позволяет вам применять два типа теней одновременно: Внутренняя тень и Предустановленная тень.

**Заметки:**

- Когда Внешняя тень и Предустановленная тень используются вместе, применяется только эффект Внешней тени.
- Если Внешняя тень и Внутренняя тень используются одновременно, результативный или примененный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект Внешней тени.

### Применение отображения к текстам

Мы добавляем отображение к тексту с помощью этого примера кода на Java:

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

### Применение эффекта сияния к текстам

Мы применяем эффект сияния к тексту, чтобы он сиял или выделялся, с помощью этого кода:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменить параметры для тени, отображения и сияния. Свойства эффектов устанавливаются для каждого отдельного сегмента текста.

{{% /alert %}} 

### Использование преобразований в WordArt

Мы используем свойство Transform (свойственное всему блоку текста) с помощью этого кода:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для Java предоставляют определенное количество предопределённых типов преобразований.

{{% /alert %}} 

**Используя PowerPoint**

Чтобы получить доступ к предопределённым типам преобразований, пройдите через: **Формат** -> **Текстовый эффект** -> **Преобразовать**

**Используя Aspose.Slides**

Чтобы выбрать тип преобразования, используйте перечисление TextShapeType.

### Применение 3D-эффектов к текстам и формам

Мы устанавливаем 3D-эффект для текстовой формы с помощью этого примера кода:

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

Получившийся текст и его форма:

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

Применение 3D-эффектов к текстам или их формам и взаимодействие между эффектами основаны на определенных правилах.

Рассмотрите сцену для текста и фигуры, содержащей этот текст. 3D-эффект включает представление 3D-объекта и сцену, на которой объект был помещён.

- Когда сцена задана для фигуры и текста, сцена фигуры имеет более высокий приоритет — сцена текста игнорируется.
- Когда у фигуры нет своей сцены, но есть 3D-представление, используется сцена текста.
- В противном случае, когда у формы изначально нет 3D-эффекта, форма плоская, и 3D-эффект применяется только к тексту.

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().

{{% /alert %}} 

## **Применение внешних теневых эффектов к текстам**
Aspose.Slides для Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) и [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow), которые позволяют применять эффекты теней к тексту, содержащемуся в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame). Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Прямоугольник на слайд.
4. Получите доступ к TextFrame, связанному с AutoShape.
5. Установите FillType для AutoShape в NoFill.
6. Создайте экземпляр класса OuterShadow.
7. Установите BlurRadius для тени.
8. Установите Direction для тени.
9. Установите Distance для тени.
10. Установите RectangleAlign в TopLeft.
11. Установите PresetColor для тени в Черный.
12. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот пример кода на Java — реализация вышеуказанных шагов — показывает, как применить внешний теневой эффект к тексту:

```java
Presentation pres = new Presentation();
try {
    // Получите ссылку на слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Прямоугольник
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавьте TextFrame к Прямоугольнику
    ashp.addTextFrame("Aspose TextBox");

    // Отключите заполнение фигуры, если мы хотим получить тень текста
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавьте внешнюю тень и установите все необходимые параметры
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Запишите презентацию на диск
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение внутреннего теневого эффекта к формам**
Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Добавьте AutoShape типа Прямоугольник.
4. Включите InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Этот пример кода (основанный на вышеуказанных шагах) показывает, как добавить соединитель между двумя формами на Java:

```java
Presentation pres = new Presentation();
try {
    // Получите ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Прямоугольник
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Добавьте TextFrame к Прямоугольнику
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Включите InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Установите все необходимые параметры
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Установите ColorType как Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Установите цвет схемы
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Сохраните презентацию
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
---
title: Создание и применение эффектов WordArt в PHP
linktitle: WordArt
type: docs
weight: 110
url: /ru/php-java/wordart/
keywords:
- WordArt
- создание WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PHP
- Aspose.Slides
description: Создайте и настройте эффекты WordArt в Aspose.Slides for PHP via Java. Это пошаговое руководство помогает разработчикам улучшать презентации профессиональным оформлением текста в PHP.
---
## **Обзор**

Эффекты WordArt позволяют оформлять текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3D‑форматирования. В этой статье объясняется, как создавать и настраивать эти эффекты в презентациях PowerPoint с использованием Aspose.Slides for PHP via Java, без установленного Microsoft Office.

## **Создать простой шаблон WordArt и применить его к тексту**

В следующих примерах создаётся простой стиль WordArt путём задания текста, шрифта, шаблона заливки и контура.  
Каждый пример создаёт новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. В первом примере задаётся текст "Aspose.Slides". Позиция и размеры фигуры измеряются в пунктах:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Установите шрифт Arial Black размером 36 пунктов, чтобы оформление было более заметным:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Примените шаблон [SmallGrid](https://reference.aspose.com/slides/ru/php-java/aspose.slides/patternstyle/#SmallGrid) с темно‑оранжевым передним планом и белой задней зоной, затем добавьте чёрный контур текста толщиной 1 пункт:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применить другие эффекты WordArt**

В следующих примерах демонстрируется, как применять тени, отражения, свечение, трансформации и 3D‑эффекты к тексту.

### **Применить внешние тени**

Внешняя тень добавляет глубину, размещая тень позади текста. Вы можете настроить её цвет, направление, дистанцию, радиус размытия, масштаб и скос.  
В этом примере вызывается [enableOuterShadowEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) и задаётся чёрная тень с радиусом размытия 4 пункта, направлением 230 градусов и дистанцией 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный скос наклоняет её на 20 градусов. Преобразование альфа задаёт непрозрачность 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Когда внешняя и предустановленная тени используются одновременно, применяется только внешняя тень.
- Если внешняя и внутренняя тени используются одновременно, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, тогда как в PowerPoint 2007 применяется только внешняя тень.
{{% /alert %}}

### **Применить эффекты отражения**

Отражение создаёт зеркальную копию текста. Настройте её позицию, масштаб, размытие и непрозрачность, чтобы управлять внешним видом.  
В этом примере вызывается [enableReflectionEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effectformat/#enableReflectionEffect--) и отражение переворачивается вертикально с масштабом -100 %. Используется радиус размытия 0,5 пункта и дистанция 4,72 пункта. Непрозрачность уменьшается с 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![Эффект отражения](reflection_effect.png)

### **Применить эффекты свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Настройте его цвет, непрозрачность и радиус, чтобы управлять эффектом.  
В этом примере вызывается [enableGlowEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effectformat/#enableGlowEffect--) и применяется красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![Эффект свечения](glow_effect.png)

### **Применить трансформации WordArt**

Трансформации WordArt изгибают, растягивают или деформируют блок текста.  
Установите [setTransform](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setTransform-int-) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textshapetype/#ArchUpPour), чтобы изогнуть весь текстовый фрейм вверх:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java предоставляет набор предопределённых [видов трансформаций](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Применить 3D‑эффекты к фигурам и тексту**

Вы можете применять 3D‑эффекты к фигуре или к её тексту. Скосы, выдавливание, освещение и настройки камеры управляют итоговым внешним видом.  
В следующем примере используется [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/) для добавления круглых скосов, оранжевого выдавливания и темно‑красного контура к прямоугольнику. Размеры скосов, высота выдавливания, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, вращённое на 40 градусов вокруг оси Z, и перспективная камера определяют его внешний вид:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Получившаяся фигура:

![3D‑эффект фигуры](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Более мелкие скосы формируют края букв, а выдавливание и освещение придают тексту глубину:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Получившийся текст:

![3D‑эффект текста](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или их фигурам — а также взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрите сцену, включающую как текст, так и содержащую его фигуру. 3D‑эффект включает 3D‑представление объекта и сцену, в которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет отдаётся сцене фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применятся только к тексту.

Эти поведения относятся к методам [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getLightRig--) и [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Больше примеров 3D‑форматирования см. в статье [Создание 3D‑эффектов в презентациях с использованием PHP](/slides/ru/php-java/3d-presentation/).

## **FAQ**

**Могу ли я использовать эффекты WordArt с разными шрифтами или сценариями (например, арабский, китайский)?**

Да, Aspose.Slides for PHP via Java поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифтов и их отображение могут зависеть от системных шрифтов.

**Могу ли я применять эффекты WordArt к элементам мастер‑слайдов?**

Да, вы можете применять эффекты WordArt к фигурам на мастер‑слайдах, включая заполнители заголовков, нижние колонтитулы или фоновый текст. Изменения, внесённые в макет мастера, отразятся на всех связанных сладах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно незначительна.

**Могу ли я просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью [Slide::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage--), или отрисовывать отдельные фигуры с помощью [Shape::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage--). Это позволяет просмотреть результат в памяти или на экране перед сохранением или экспортом полной презентации.
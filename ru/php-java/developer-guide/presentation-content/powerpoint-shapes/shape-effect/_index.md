---
title: Применение эффектов фигур в презентациях с помощью PHP
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/php-java/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур в Aspose.Slides for PHP via Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить форму, но они отличаются от [заполнений](/slides/ru/php-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создать убедительные отражения формы, распространить её свечение и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Можно применить один или несколько эффектов к одной форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает варианты в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, известные своим хорошим внешним видом. Выбирая предустановку, вам не придётся тратить время на попытки подобрать комбинацию эффектов.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), позволяющие применять такие же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for PHP via Java поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краёв формы, создавая ощущение, что форма приподнята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии с освещением и стилем вашего шаблона.

Этот PHP‑код демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Эффект тени](shadow_effect.png)

### **Применение внутренней тени**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное отображение. Внешняя тень располагается за формой и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние края её границ.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, полученную через [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Большие значения радиуса размытия дают более мягкие края.

Этот PHP‑пример создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов формы.

### **Применение, изменение и удаление предустановленной тени**

Вызовите [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect), чтобы включить предустановленную тень. С помощью [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) выберите [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) или переключитесь на другой стиль той же формы. Вызовите [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect), чтобы удалить тень, сохранив заполнение и контур.

Этот PHP‑пример клонирует прямоугольник после каждого из первых трёх этапов, чтобы вы могли сравнить все четыре этапа бок о бок на одном слайде. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень слева‑сверху от прямоугольника, а 45° — вторую снизу‑справа.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![ТеньTopLeftDropShadow](preset_shadow_top_left.png) | ![ТеньBottomRightDropShadow](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for PHP via Java, вы можете добавить зеркальное отражение к формам, регулируя параметры такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более полированный и изысканный вид. Реализовать его просто с помощью небольшого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот PHP‑код показывает, как применить [эффект отражения](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) к форме:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Эффект отражения](reflection_effect.png)

## **Применение эффекта свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for PHP via Java, вы можете добавить мягкую, светящуюся ору вокруг формы, регулируя свойства такие как цвет и размер. Этот эффект помогает выделить форму и добавляет привлекательный визуальный элемент в вашу презентацию. Реализовать его легко с минимальным объёмом кода, улучшая общий вид ваших слайдов.

Этот PHP‑код демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) к форме:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Эффект свечения](glow_effect.png)

## **Применение эффекта мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for PHP via Java, вы можете создать плавный, размытый переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, которым нужна нежная, более мягкая внешность. Вы легко можете настроить такие параметры, как радиус, чтобы достичь желаемого результата для различных форм в вашей презентации.

Этот PHP‑код показывает, как применить [эффект мягких краёв](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Эффект мягких краёв](soft_edges_effect.png)

## **Применение эффекта размытия**

Используйте размытие формы, чтобы смягчить её заполнение и контур, оставляя форму редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус 0 — вид внешнего вида не меняется.

Параметр [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При `false` размытие ограничено исходными красками, включая контур. При `true` размытие может выходить за эти границы. Ни одна из настроек не изменяет положение или размеры формы.

Сравнение ниже использует одинаковое заполнение, контур и размеры формы. Верхняя строка использует `grow = false`; нижняя — `grow = true`.

![Исходный прямоугольник сравнивается с размерами размытия 5 и 15 пунктов, при отключённом и включённом росте](shape_blur_comparison.png)

Этот PHP‑пример создаёт оранжевый прямоугольник с тёмно‑синей окантовкой, применяет размытие в 5 пунктов, а затем обновляет его до размытия в 15 пунктов, снова вызывая [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Он сохраняет оба размытого состояния, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняет форму без размытия.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Размытие формы влияет одновременно на заполнение и контур. Эффект мягких краёв плавно стирает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; данный пример применяет размытие непосредственно к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Можно ли применять несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме для создания более динамичного вида.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и другие.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет действовать на всю группу.
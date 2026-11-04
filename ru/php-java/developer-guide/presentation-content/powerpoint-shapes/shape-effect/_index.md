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
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides for PHP via Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint могут использоваться, чтобы выделить форму, они отличаются от [заливок](/slides/ru/php-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, распространять светящееся свечение формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые считаются удачными. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или сочетание разных эффектов, чтобы найти хорошую комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), которые позволяют применять те же самые эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for PHP via Java поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы сделать карточку или панель более заметной на фоне слайда. Тень выходит за пределы границ формы, создавая впечатление, что форма поднята над слайдом. Отрегулируйте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

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

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное ощущение. Внешняя тень выходит за пределы формы и делает её выглядящей поднятой, тогда как внутренняя тень затемняет внутреннюю часть её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Большее значение радиуса размытия создаёт более мягкие края.

В этом примере PHP создаётся светло‑голубая карточка с темно‑серой внутренней тенью и сохраняется как файл PPTX. Направление тени — 225 градусов, её расстояние — 7 пунктов, а радиус размытия — 6 пунктов:

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

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for PHP via Java, вы можете добавить зеркальное отражение к формам, регулируя параметры, такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая формам более отполированный и утончённый вид. Его легко реализовать с помощью простого кода, позволяя быстро применять его к нескольким элементам для единообразного дизайна.

Этот PHP‑код демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) к форме:

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

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for PHP via Java, вы можете добавить мягкую, светящуюся ауру вокруг форм, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, броский визуальный элемент в вашу презентацию. Его легко реализовать с минимальным количеством кода, улучшая общий вид ваших слайдов.

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

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for PHP via Java, вы можете создать плавный, размытой переход вокруг границ формы. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого появления. Вы можете легко настраивать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

Этот PHP‑код демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

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

## **Применить эффект размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, оставляя её редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, оставляет внешний вид без изменений.

Параметр [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При `false` размытие обрезается до исходных нарисованных границ, включая контур. При `true` размытие может выходить за эти границы. Ни один из этих вариантов не меняет позицию или размеры формы.

Ниже приведённое сравнение использует одинаковую заливку, контур и размеры формы. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, при отключённом и включённом параметре grow](shape_blur_comparison.png)

В этом примере PHP создаётся оранжевый прямоугольник с темно‑синим контуром, применяется размытие 5 пунктов, а затем обновляется до 15 пунктов, вызывая [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) повторно. Сохраняются оба состояния с размытием, затем вызывается [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняется форма без размытия.

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

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краёв размывает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**  
Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**  
Вы можете применять эффекты к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и др.

**Можно ли применять эффекты к сгруппированным формам?**  
Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.
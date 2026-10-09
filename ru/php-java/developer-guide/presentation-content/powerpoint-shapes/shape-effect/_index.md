---
title: Применение эффектов фигур в презентациях с использованием PHP
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/php-java/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффектов
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для PHP через Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить форму, но они отличаются от [заполнений](/slides/ru/php-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на форме, распространять светящееся свечение формы и т. д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предоставляет параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые известны как хорошо выглядящие. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов для поиска удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides для PHP через Java поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выступает за границы формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот PHP‑код показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели утопленное (врезанное) отображение. Внешняя тень выходит за пределы формы и создаёт ощущение подъёма, тогда как внутренняя тень затемняет внутренние стороны её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Большие значения радиуса размытия дают более мягкие края.

Этот PHP‑пример создаёт светло‑голубой карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, её расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

![Светло-голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы убрать внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов формы.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides для PHP через Java, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более отполированный и изысканный внешний вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к множеству элементов для согласованного дизайна.

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

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides для PHP через Java, вы можете добавить мягкое, светящееся сияние вокруг форм, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот PHP‑код показывает, как применить [эффект свечения](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) к форме:

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

Чтобы применить эффект мягких краев в Aspose.Slides для PHP через Java, вы можете создать плавный, размытый переход вокруг краёв формы. Этот эффект придаёт более нежный и изысканный вид, что идеально подходит для дизайнов, требующих мягкого, более нежного отображения. Вы можете легко регулировать параметры, такие как радиус, чтобы достичь желаемого эффекта для различных форм в вашей презентации.

Этот PHP‑код показывает, как применить [эффект мягких краев](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

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

![Эффект мягких краев](soft_edges_effect.png)

## **FAQ**

**Могу ли я применить несколько эффектов к одной и той же форме?**  
Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**Каким формам я могу применять эффекты?**  
Эффекты можно применять к различным формам, включая автоформы, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Могу ли я применять эффекты к сгруппированным формам?**  
Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.
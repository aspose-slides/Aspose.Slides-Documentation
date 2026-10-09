---
title: Применение эффектов фигур в презентациях с использованием JavaScript
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/nodejs-java/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью расширенных эффектов фигур, используя JavaScript и Aspose.Slides для Node.js — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint могут использоваться для выделения фигуры, они отличаются от [заполнения](/slides/ru/nodejs-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения фигуры, распространять её свечение и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поиске удачной комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/), позволяющие применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Node.js via Java поддерживает внешние и внутренние тени для фигур. Вы можете настроить их цвет, направление, расстояние и радиус размытия в соответствии с дизайном вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выступает за пределы краёв фигуры, создавая ощущение, что фигура поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот JavaScript‑код демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект тени](shadow_effect.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели отступающий вид. Внешняя тень выходит за пределы фигуры, делая её выглядящей поднятой, тогда как внутренняя тень затемняет внутреннюю часть её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, полученную по [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Более крупные значения радиуса размытия дают более мягкие края.

Этот JavaScript‑пример создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Синий прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов фигуры.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Node.js via Java, можно добавить зеркальное отражение к фигурам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетику ваших презентаций, придавая фигурам более изысканный и полированный вид. Реализовать его просто с помощью небольшого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот JavaScript‑код демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) к фигуре:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект отражения](reflection_effect.png)

## **Применить эффект свечения**

Чтобы применить эффект свечения к фигуре в Aspose.Slides for Node.js via Java, можно добавить мягкое светящееся свечение вокруг фигур, регулируя свойства, такие как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный визуальный элемент в вашу презентацию. Реализовать его просто с минимальным объёмом кода, улучшая общий вид ваших слайдов.

Этот JavaScript‑код демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) к фигуре:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Node.js via Java, можно создать плавный, размытый переход вокруг границ фигуры. Этот эффект придаёт более нежный и изысканный вид, идеально подходящий для дизайнов, которым требуется мягкое, более деликатное оформление. Вы легко можете регулировать такие параметры, как радиус, чтобы достичь желаемого результата для различных фигур в вашей презентации.

Этот JavaScript‑код демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) к фигуре:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект мягких краёв](soft_edges_effect.png)

## **FAQ**

**Можно ли применить несколько эффектов к одной фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**К каким типам фигур можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, вы можете применять эффекты к сгруппированным фигурам. Эффект будет применён ко всей группе.
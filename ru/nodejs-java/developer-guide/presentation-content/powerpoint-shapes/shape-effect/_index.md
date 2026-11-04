---
title: Применение эффектов фигур в презентациях с помощью JavaScript
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
- формат эффектов
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя JavaScript и Aspose.Slides для Node.js — создавайте впечатляющие, профессиональные слайды за считанные секунды."
---
## **Введение**

Эффекты в PowerPoint можно использовать, чтобы выделить форму, но они отличаются от [заполнений](/slides/ru/nodejs-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на форме, разгонять свечение формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает варианты в разделе **Preset**. Параметры Preset — это комбинации из двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Node.js via Java поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы карточка или панель выделялись на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии с освещением и стилем вашего шаблона.

Этот JavaScript‑код показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) к прямоугольнику:

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

При воссоздании визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вписанный вид. Внешняя тень выходит за границы формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние стороны её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Большие значения радиуса размытия дают более мягкие края.

Этот пример JavaScript создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, её расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов формы.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Node.js via Java, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более отполированный и изысканный вид. Реализовать его просто с помощью небольшого кода, что позволяет быстро применять его к нескольким элементам для единообразного дизайна.

Этот JavaScript‑код демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) к форме:

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

Чтобы применить эффект свечения к форме в Aspose.Slides for Node.js via Java, можно добавить мягкое светящееся сияние вокруг формы, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Реализовать его просто при помощи небольшого кода, улучшая общий вид ваших слайдов.

Этот JavaScript‑код показывает, как применить [эффект свечения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) к форме:

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

Чтобы применить эффект мягких краёв в Aspose.Slides for Node.js via Java, можно создать плавный размытный переход вокруг краёв формы. Этот эффект придаёт более утончённый и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого внешнего вида. Вы легко можете регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для различных форм в презентации.

Этот JavaScript‑код демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) к форме:

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

## **Применить эффект размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, оставаясь при этом редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения создают более сильное размытие. Радиус, равный нулю, не изменяет внешний вид.

Параметр [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При значении `false` размытие ограничивается исходными нарисованными границами, включая контур. При значении `true` размытие может выходить за эти границы. Ни один из параметров не меняет положение или размеры формы.

В сравнении ниже используются одинаковые заливка, контур и размеры формы. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, при отключённом и включённом grow](shape_blur_comparison.png)

Этот пример JavaScript создаёт оранжевый прямоугольник с тёмно‑синей окантовкой, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия радиусом 15 пунктов, повторно вызывая [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Он сохраняет оба состояния с размытием, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняет форму без размытия.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Размытие формы влияет одновременно на заливку и контур. Эффект мягких краёв затухает края формы, тогда как размытие тени смягчает только тень. Эффекты преобразования изображения работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Вы можете применять эффекты к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и др.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.
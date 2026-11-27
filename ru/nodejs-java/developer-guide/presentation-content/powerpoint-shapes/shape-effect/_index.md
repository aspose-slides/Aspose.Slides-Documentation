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
- формат эффекта
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя JavaScript и Aspose.Slides для Node.js — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint можно использовать, чтобы выделить объект, они отличаются от [заполнений](/slides/ru/nodejs-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать правдоподобные отражения на объекте, распространять сияние объекта и т.п.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к объектам. Вы можете применить один или несколько эффектов к объекту.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает параметры в разделе **Preset**. Параметры Preset представляют собой комбинации двух и более эффектов, которые известны как подходящие. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках хорошей комбинации.

Aspose.Slides предлагает свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/), позволяющие применять те же эффекты к объектам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Node.js via Java поддерживает внешние и внутренние тени для объектов. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы карточка или панель выделялись на фоне слайда. Тень выходит за границы объекта, создавая ощущение, что объект приподнят над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии со светом и стилем вашего шаблона.

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

#### **Управление направлением тени при повороте объекта**

По умолчанию внешняя тень вращается вместе с объектом. Чтобы объекты с разными поворотами выглядели освещёнными из одного направления, вызовите [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) со значением `false` и используйте [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection), чтобы задать одинаковое направление теням.

В примере создаются две синие стрелки с серыми тенями, смещёнными на 42 пункта вправо (0°). Затем дублируется слайд, и обе стрелки поворачиваются на 90° по часовой стрелке.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

На втором слайде левая стрелка отбрасывает тень вниз, тогда как правая стрелка по‑прежнему отбрасывает тень направо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после поворота на 90°. Обе тени начинаются справа. После поворота тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели врезанные границы. Внешняя тень выходит за пределы объекта и создаёт эффект поднятости, тогда как внутренняя тень затемняет внутренние границы.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), затем настройте теневые параметры, полученные через [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Большие значения радиуса размытия дают более мягкие края.

Этот JavaScript‑пример создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225°, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) у формата эффектов объекта.

### **Применить, изменить и удалить предустановленную тень**

Вызовите [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) и используйте [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) для выбора [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/). Чтобы переключить стили, измените предустановку у того же объекта. Вызовите [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect), чтобы удалить тень, сохранив заполнение и контур.

В примере показаны четыре стадии рядом на одном слайде. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень сверху слева от прямоугольника, а 45° размещает вторую тень снизу справа.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![ТеньСверхуСлева](preset_shadow_top_left.png) | ![ТеньСнизуСправа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применить эффект отражения**

Для применения эффекта отражения в Aspose.Slides for Node.js via Java можно добавить зеркальное отражение к объектам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая объектам более полированный и изысканный вид. Реализовать его легко с помощью простого кода, что позволяет быстро применять эффект к нескольким элементам для единообразного дизайна.

Этот JavaScript‑код демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) к объекту:

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

## **Применить эффект сияния**

Чтобы применить эффект сияния к объекту в Aspose.Slides for Node.js via Java, можно добавить мягкую, светящую ауру вокруг объектов, регулируя свойства, такие как цвет и размер. Этот эффект помогает объектам выделяться и добавляет привлекательный, привлекающий внимание визуальный элемент вашей презентации. Реализовать его легко с минимальным объёмом кода, улучшая общий внешний вид слайдов.

Этот JavaScript‑код демонстрирует, как применить [эффект сияния](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) к объекту:

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

![Эффект сияния](glow_effect.png)

## **Применить эффект мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Node.js via Java, можно создать плавный, размытый переход вокруг границ объекта. Этот эффект придаёт более тонкий и изысканный вид, подходящий для дизайнов, требующих нежного, более мягкого отображения. Вы легко можете регулировать параметры, такие как радиус, чтобы достичь желаемого эффекта для различных объектов в презентации.

Этот JavaScript‑код демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) к объекту:

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

Используйте размытие объектов, чтобы смягчить заполнение и контур объекта, оставляя его редактируемым. Вызовите [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) у формата эффектов объекта. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом более большие значения дают более сильное размытие. Радиус 0 оставляет внешний вид без изменений.

Параметр [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) управляет видимыми границами эффекта. При `false` размытие обрезается оригинальными границами рисования, включая контур. При `true` размытие может выходить за эти границы. Ни один из вариантов не меняет позицию или размеры объекта.

Сравнение ниже использует одинаковые заполнение, контур и размеры объекта. Верхняя строка — `grow = false`; нижняя строка — `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, при отключённом и включённом росте](shape_blur_comparison.png)

Этот JavaScript‑пример создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие в 5 пунктов, затем обновляет его до 15 пунктов, вновь вызывая [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Оба состояния сохраняются, после чего вызывается [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) и сохраняется объект без размытия.

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

Размытие объекта влияет одновременно на заполнение и контур. Эффект мягких краёв затемняет края объекта, тогда как размытие тени смягчает только тень. Эффекты преобразования изображений работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов объекта без преобразования его в изображение.

## **FAQ**

**Можно ли применить несколько эффектов к одному объекту?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и сияние, на одном объекте для создания более динамичного внешнего вида.

**К каким объектам можно применять эффекты?**

Эффекты можно применять к различным объектам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным объектам?**

Да, эффекты можно применять к сгруппированным объектам. Эффект будет применён ко всей группе.
---
title: Применение эффектов фигур в презентациях с помощью Java
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/java/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур в Aspose.Slides for Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заливок](/slides/ru/java/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создавать убедительные отражения на форме, распространять светящееся свечение формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает варианты в разделе **Preset**. Опции Preset — это комбинации двух или более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов, чтобы найти хорошую комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), позволяющие применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Java поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма приподнята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот Java‑код демонстрирует, как применить [эффект внешней тени](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) к прямоугольнику:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект тени](shadow_effect.png)

#### **Управление направлением тени при повороте формы**

По умолчанию внешняя тень вращается вместе с формой. Чтобы формы с разными поворотами выглядели освещёнными из одного направления, вызовите [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) с `false` и используйте [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) чтобы задать их теням одинаковое направление.

В примере создаются две синие стрелки с серыми тенями, смещёнными на 42 пункта вправо (0°). Затем слайд дублируется, и обе стрелки поворачиваются на 90° по часовой стрелке.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

На втором слайде левая стрелка отбрасывает свою тень вниз, в то время как правая стрелка всё ещё отбрасывает тень вправо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после поворота на 90°. Обе тени начинаются справа. После поворота тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленный вид. Внешняя тень выходит за пределы формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние края формы.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), а затем настройте тень, полученную через [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Большие значения радиуса размытия дают более мягкие края.

Этот пример на Java создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225°, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) у формата эффектов формы.

### **Применить, изменить и удалить предустановленную тень**

Вызовите [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) и используйте [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) для выбора [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). Чтобы переключать стили, меняйте предустановку у той же формы. Вызовите [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) чтобы удалить тень, сохранив заливку и контур.

В этом примере показаны четыре стадии рядом на одном слайде. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень сверху слева от прямоугольника, а 45° размещает вторую тень снизу справа.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![Тень сверху слева](preset_shadow_top_left.png) | ![Тень снизу справа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Java, вы можете добавить зеркальное отражение к формам, настраивая такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая формам более отполированный и изысканный вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот Java‑код демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) к форме:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект отражения](reflection_effect.png)

## **Применить эффект свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for Java, вы можете добавить мягкое светящееся сияние вокруг форм, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, броский визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид слайдов.

Этот Java‑код демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) к форме:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краев**

Чтобы применить эффект мягких краев в Aspose.Slides for Java, вы можете создать плавный, размытой переход вокруг краёв формы. Этот эффект добавляет более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого внешнего вида. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта на разных формах в презентации.

Этот Java‑код демонстрирует, как применить [эффект мягких краев](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) к форме:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект мягких краев](soft_edges_effect.png)

## **Применить эффект размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, оставляя её редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения создают более сильное размытие. Радиус, равный нулю, не меняет внешний вид.

Параметр [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) управляет видимыми границами эффекта. При `false` размытие обрезается по исходным нарисованным границам, включая контур. При `true` размытие может выходить за эти границы. Ни одна из настроек не меняет позицию или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы. Верхняя строка использует `grow = false`; нижняя — `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов при отключённом и включённом параметре grow](shape_blur_comparison.png)

Этот пример на Java создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия радиусом 15 пунктов, снова вызывая [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Он сохраняет оба размазанных состояния, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) и сохраняет форму без размытия.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краев размывает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов формы без преобразования её в изображение.

## **Часто задаваемые вопросы**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.
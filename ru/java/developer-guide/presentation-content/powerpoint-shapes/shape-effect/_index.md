---
title: Применение эффектов форм в презентациях с использованием Java
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/java/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов форм, используя Aspose.Slides для Java — создавайте впечатляющие профессиональные слайды за считанные секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заливки](/slides/ru/java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на форме, распространять светящееся свечение формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Можно применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает параметры в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for Java поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы карточка или панель выделялась на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код Java демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) к прямоугольнику:

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

### **Применение внутренней тени**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное ощущение. Внешняя тень выходит за пределы формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутренние края её границ.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Большие значения радиуса размытия дают более мягкие края.

Этот пример Java создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225°, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

![Светло-голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) у формата эффектов формы.

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for Java, вы можете добавить зеркальное отражение к формам, отрегулировав такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более полированный и утончённый вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять эффект к нескольким элементам для согласованного дизайна.

Этот код Java демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) к форме:

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

## **Применение эффекта свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for Java, вы можете добавить мягкое светящееся ореол вокруг формы, отрегулировав свойства, такие как цвет и размер. Этот эффект помогает формам выделяться и добавляет привлекательный визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид слайдов.

Этот код Java демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) к форме:

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

## **Применение эффекта мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Java, вы можете создать плавный размытый переход вокруг краёв формы. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, которым нужна нежная, более мягкая презентация. Вы легко можете регулировать такие параметры, как радиус, чтобы достичь желаемого результата для разных форм в вашей презентации.

Этот код Java демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) к форме:

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

![Эффект мягких краёв](soft_edges_effect.png)

## **Применение эффекта размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, при этом оставив форму редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус 0 оставляет внешний вид без изменений.

Параметр [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) управляет видимыми границами эффекта. При `false` размытие ограничивается оригинальными нарисованными границами, включая контур. При `true` размытие может выходить за эти границы. Ни одна из настроек не меняет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы во всех примерах. В верхней строке `grow = false`; в нижней — `grow = true`.

![Исходный прямоугольник сравнивается с размерами размытия 5 и 15 пунктов, при отключённом и включённом росте](shape_blur_comparison.png)

Этот пример Java создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие в 5 пунктов, затем меняет его на размытие в 15 пунктов, повторно вызывая [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Оба состояния сохраняются, после чего вызывается [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) и форма сохраняется без размытия.

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

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краёв смягчает края формы, тогда как размытие тени смягчает только тень. Эффекты преобразования изображений работают с содержимым изображения; в данном примере размытие применяется напрямую к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный внешний вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.
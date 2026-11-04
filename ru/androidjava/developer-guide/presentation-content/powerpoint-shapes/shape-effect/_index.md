---
title: Применение эффектов фигур в презентациях на Android
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/androidjava/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффектов
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides for Android via Java — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить фигуру, они отличаются от [заливок](/slides/ru/androidjava/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на фигуре, рассеивать её свечение и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает варианты в разделе **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов, чтобы найти удачную комбинацию.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/), которые позволяют применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Android via Java поддерживает внешние и внутренние тени для фигур. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы сделать карточку или панель более заметными на фоне слайда. Тень выходит за пределы границ фигуры, создавая впечатление, что фигура поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код Java показывает, как применить [эффект внешней тени](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) к прямоугольнику:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эффект тени](shadow_effect.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленную форму. Внешняя тень выходит за пределы фигуры и делает её выглядящей поднятой, тогда как внутренняя тень затемняет внутреннюю часть её краёв.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), затем настройте тень, полученную через [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Большие значения радиуса размытия дают более мягкие края.

Этот пример Java создает светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, её расстояние — 7 пунктов, а радиус размытия — 6 пунктов:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) у формата эффектов фигуры.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Android via Java, вы можете добавить зеркальное отражение к фигурам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая фигурам более изысканный и полированный вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять эффект к нескольким элементам для единого дизайна.

Этот код Java показывает, как применить [эффект отражения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) к фигуре:

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

Чтобы применить эффект свечения к фигуре в Aspose.Slides for Android via Java, вы можете добавить мягкое, светящееся сияние вокруг фигур, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный, привлекающий внимание визуальный элемент в вашу презентацию. Его легко реализовать с минимальным количеством кода, улучшая общий вид ваших слайдов.

Этот код Java показывает, как применить [эффект свечения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) к фигуре:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Чтобы применить эффект мягких краев в Aspose.Slides for Android via Java, вы можете создать плавный, размытый переход по краям фигуры. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого внешнего вида. Вы можете легко регулировать параметры, такие как радиус, чтобы достичь нужного эффекта для различных фигур в презентации.

Этот код Java показывает, как применить [эффект мягких краев](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) к фигуре:

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

Используйте размытие фигуры, чтобы смягчить её заливку и контур, оставляя фигуру редактируемой. Вызовите [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) у формата эффектов фигуры. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не изменяет внешний вид.

Параметр [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) управляет видимыми границами эффекта. При `false` размытие обрезается границами оригинального рисунка, включая контур. При `true` размытие может выходить за эти границы. Ни один из параметров не меняет позицию или размеры фигуры.

Сравнение ниже использует одинаковые заливку, контур и размеры фигуры. В верхней строке `grow = false`; в нижней строке `grow = true`.

![Исходный прямоугольник, сравнение радиусов размытия 5 и 15 пунктов, с `grow` выключенным и включённым](shape_blur_comparison.png)

Этот пример Java создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия радиусом 15 пунктов, снова вызывая [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Он сохраняет оба состояния с размытием, затем вызывает [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) и сохраняет фигуру без размытия.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Размытие фигуры воздействует одновременно на заливку и контур. Эффект мягких краев размывает края фигуры, тогда как размытие тени смягчает только тень. Эффекты преобразования изображения работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов фигуры без преобразования её в изображение.

## **Часто задаваемые вопросы**

**Можно ли применить несколько эффектов к одной фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**К каким фигурам можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, объекты OLE и другие.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, вы можете применять эффекты к сгруппированным фигурам. Эффект будет применён ко всей группе.
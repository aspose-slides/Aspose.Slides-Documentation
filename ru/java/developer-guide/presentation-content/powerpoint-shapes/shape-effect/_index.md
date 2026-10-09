---
title: Применение эффектов фигур в презентациях с использованием Java
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/java/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для Java, — создавайте яркие, профессиональные слайды за считанные секунды."
---
## **Введение**

В то время как эффекты в PowerPoint могут использоваться, чтобы выделить форму, они отличаются от [заливок](/slides/ru/java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать правдоподобные отражения формы, рассеивать её свечение и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint предлагает варианты под **Preset**. Параметры Preset — это комбинации двух и более эффектов, которые, как известно, выглядят хорошо. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов в поисках хорошей комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for Java поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за границы формы, создавая ощущение, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот Java‑код демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) к прямоугольнику:

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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вогнутый вид. Внешняя тень располагается за пределами формы и делает её выглядящей поднятой, а внутренняя тень затемняет внутренние края.

Вызовите [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), затем настройте тень, возвращаемую [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Большие значения радиуса размытия дают более мягкие края.

Этот Java‑пример создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX. Направление тени — 225 градусов, расстояние — 7 пунктов, радиус размытия — 6 пунктов:

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

Чтобы удалить внутреннюю тень, вызовите [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) у формата эффекта формы.

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for Java, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более отполированный и изящный вид. Реализовать его просто с помощью небольшого кода, позволяющего быстро применить эффект к нескольким элементам для единообразного дизайна.

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

## **Применение эффекта свечения**

Чтобы применить эффект свечения к форме в Aspose.Slides for Java, вы можете добавить мягкое светящееся сияние вокруг формы, регулируя свойства, такие как цвет и размер. Этот эффект помогает форму выделить и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид слайдов.

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

## **Применение эффекта мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for Java, вы можете создать плавный, размытый переход вокруг границ формы. Этот эффект придаёт более деликатный и изысканный вид, идеально подходящий для дизайнов, требующих нежного, мягкого оформления. Вы можете легко настроить такие параметры, как радиус, чтобы достичь нужного результата для различных форм в вашей презентации.

Этот Java‑код демонстрирует, как применить [эффект мягких краёв](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) к форме:

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

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и др.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.
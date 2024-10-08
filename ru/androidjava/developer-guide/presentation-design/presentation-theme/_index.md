---
title: Тема Презентации
type: docs
weight: 10
url: /ru/androidjava/presentation-theme/
keywords: "Тема, Тема PowerPoint, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Тема презентации PowerPoint на Java"
---

Тема презентации определяет свойства элементов дизайна. При выборе темы презентации вы фактически выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/androidjava/powerpoint-fonts/), [стили фона](/slides/ru/androidjava/presentation-background/) и эффекты.

![компоненты-темы](theme-constituents.png)

## **Изменить Цвет Темы**

Тема PowerPoint использует определенный набор цветов для различных элементов на слайде. Если вам не нравятся цвета, вы можете изменить их, применив новые цвета для темы. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

Этот Java код показывает, как изменить цвет акцента для темы:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Вы можете определить эффективное значение полученного цвета следующим образом:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Цвет [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаем другой элемент и присваиваем ему цвет акцента (из первоначальной операции). Затем мы изменяем цвет в теме:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Новый цвет автоматически применяется к обоим элементам.

### **Установить Цвет Темы из Дополнительной Палитры**

Когда вы применяете преобразования светимости к основному цвету темы (1), формируются цвета из дополнительной палитры (2). Вы можете затем установить и получить эти цвета темы.

![цвета-дополнительной-палитры](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот Java код демонстрирует операцию, в которой цвета из дополнительной палитры получаются из основного цвета темы и затем используются в формах:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Акцент 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Акцент 4, Светлее на 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Акцент 4, Светлее на 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Акцент 4, Светлее на 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Акцент 4, Темнее на 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Акцент 4, Темнее на 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Изменить Шрифт Темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (похожие на те, что используются в PowerPoint):

* **+mn-lt** - Шрифт для тела Латиница (Небольшой латинский шрифт)
* **+mj-lt** - Шрифт Заголовка Латиница (Основной латинский шрифт)
* **+mn-ea** - Шрифт для тела Восточная Азия (Небольшой восточноазиатский шрифт)
* **+mj-ea** - Шрифт Заголовка Восточная Азия (Основной восточноазиатский шрифт)

Этот Java код показывает, как присвоить латинский шрифт элементу темы:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Формат текста темы");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Этот Java код показывает, как изменить шрифт темы презентации:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Шрифт во всех текстовых полях будет обновлен.

{{% alert color="primary" title="Совет" %}} 

Вы можете ознакомиться с [шрифтами PowerPoint](/slides/ru/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Изменить Стиль Фона Темы**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но только 3 из этих 12 фонов сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после того как вы сохраните презентацию в приложении PowerPoint, вы можете выполнить этот Java код, чтобы узнать количество предустановленных фонов в презентации:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Количество стилей фона для темы равно " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

С помощью свойства [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) класса [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) вы можете добавить или получить стиль фона в теме PowerPoint.

{{% /alert %}} 

Этот Java код показывает, как установить фон для презентации:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Указатель индекса**: 0 используется для без заливки. Индекс начинается с 1.

{{% alert color="primary" title="Совет" %}} 

Вы можете ознакомиться с [фоном PowerPoint](/slides/ru/androidjava/presentation-background/).

{{% /alert %}}

## **Изменить Эффект Темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединены в 3 эффекта: тонкий, умеренный и интенсивный. Например, вот результат, когда эффекты применяются к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) класса [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) вы можете изменить элементы в теме (даже более гибко, чем в PowerPoint).

Этот Java код показывает, как изменить эффект темы, изменяя части элементов:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Результирующие изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)


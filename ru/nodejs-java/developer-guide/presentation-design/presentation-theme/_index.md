---
title: Тема презентации
type: docs
weight: 10
url: /ru/nodejs-java/presentation-theme/
keywords: "Тема, Тема PowerPoint, Презентация PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Тема презентации PowerPoint на JavaScript"
---

Тема презентации определяет свойства дизайнерских элементов. Выбирая тему презентации, вы по сути выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [шрифты](/slides/ru/nodejs-java/powerpoint-fonts/), [стили фона](/slides/ru/nodejs-java/presentation-background/), и эффектов.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определённый набор цветов для различных элементов слайда. Если вам не нравятся эти цвета, вы можете изменить их, применив новые цвета к теме. Для выбора нового цвета темы Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor).

Этот JavaScript‑код показывает, как изменить цвет акцента в теме:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Вы можете определить эффективное значение полученного цвета следующим образом:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и назначаем ему цвет акцента (из первоначальной операции). Затем меняем цвет в теме:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


Новый цвет применяется автоматически к обоим элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** – Основные цвета темы  

**2** – Цвета из дополнительной палитры.

Этот JavaScript‑код демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Акцент 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Акцент 4, светлее 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Акцент 4, светлее 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Акцент 4, светлее 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Акцент 4, темнее 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Акцент 4, темнее 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, что используются в PowerPoint):

* **+mn-lt** – Основной шрифт Latin (Minor Latin Font)  
* **+mj-lt** – Шрифт заголовка Latin (Major Latin Font)  
* **+mn-ea** – Основной шрифт East Asian (Minor East Asian Font)  
* **+mj-ea** – Основной шрифт East Asian (Major East Asian Font)

Этот JavaScript‑код показывает, как назначить латинский шрифт элементу темы:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


Этот JavaScript‑код показывает, как изменить шрифт темы презентации:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


Шрифт во всех текстовых полях будет обновлён.

{{% alert color="primary" title="TIP" %}} 

Возможно, вам будет полезно ознакомиться с [PowerPoint fonts](/slides/ru/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предопределённых фонов, но только 3 из этих 12 сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете запустить этот JavaScript‑код, чтобы узнать количество предопределённых фонов в презентации:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 

С помощью свойства [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) вы можете добавить или получить доступ к стилю фона в теме PowerPoint.

{{% /alert %}} 

Этот JavaScript‑код показывает, как установить фон для презентации:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Руководство по индексам**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="TIP" %}} 

Возможно, вам будет полезно ознакомиться с [PowerPoint Background](/slides/ru/nodejs-java/presentation-background/).

{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: лёгкий, умеренный и интенсивный. Например, так выглядит результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) вы можете менять элементы темы (даже гибче, чем параметры в PowerPoint).

Этот JavaScript‑код показывает, как изменить эффект темы, изменяя части элементов:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Полученные изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастер‑тема?**

Да. Aspose.Slides поддерживает переопределение темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив мастер‑тему неизменной (через [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)).

**Как безопасно перенести тему из одной презентации в другую?**

[Клонировать слайды](/slides/ru/nodejs-java/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, обеспечивая одинаковый внешний вид.

**Как увидеть «эффективные» значения после всех наследований и переопределений?**

Используйте «эффективные» представления API [/slides/nodejs-java/shape-effective-properties/](/slides/ru/nodejs-java/shape-effective-properties/) для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и всех локальных переопределений.
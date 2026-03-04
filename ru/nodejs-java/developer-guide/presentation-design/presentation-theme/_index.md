---
title: Управление темами презентаций в JavaScript
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/nodejs-java/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- установить тему
- изменить тему
- управлять темой
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте темами презентаций в JavaScript с Aspose.Slides для Node.js, создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендингом."
---
Тема презентации определяет свойства элементов дизайна. При выборе темы презентации вы фактически выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [шрифты](/slides/ru/nodejs-java/powerpoint-fonts/), [стили фона](/slides/ru/nodejs-java/presentation-background/), и эффектов.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определённый набор цветов для разных элементов на слайде. Если вам не нравятся цвета, вы меняете их, применяя новые цвета к теме. Чтобы выбрать новый цвет темы, Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SchemeColor).

Этот код JavaScript показывает, как изменить цвет акцента для темы:

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

Таким образом вы можете определить эффективное значение получаемого цвета:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём ещё один элемент и присваиваем ему цвет акцента (из начальной операции). Затем меняем цвет в теме:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Новый цвет применяется автоматически к обоим элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете устанавливать и получать эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот код JavaScript демонстрирует операцию, при которой цвета дополнительной палитры получают из основного цвета темы и затем используют в фигурах:

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

### **Сопоставить `SchemeColor` с цветами `ColorScheme`**

При работе с [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/), вы можете заметить, что он содержит следующие значения цветов темы:

`Background1`, `Background2`, `Text1`, and `Text2`.

Однако `Presentation.getMasterTheme().getColorScheme()` возвращает [ColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorscheme/), который предоставляет соответствующие цвета как:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Это различие лишь в названиях. Эти значения относятся к одним и тем же слотам цветов темы, и сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Динамического преобразования между `Text`/`Background` и `Dark`/`Light` нет. Это просто альтернативные названия одних и тех же цветов темы.

Это различие в названиях происходит из терминологии Microsoft Office. В старых версиях Office использовались `Dark 1`, `Light 1`, `Dark 2` и `Light 2`, тогда как в новых версиях интерфейса те же слоты отображаются как `Text 1`, `Background 1`, `Text 2` и `Background 2`.

## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, что используются в PowerPoint):

* **+mn-lt** - Основной шрифт (Minor Latin Font)
* **+mj-lt** - Заголовочный шрифт (Major Latin Font)
* **+mn-ea** - Основной шрифт восточноазиатский (Minor East Asian Font)
* **+mj-ea** - Основной шрифт восточноазиатский (Major East Asian Font)

Этот код JavaScript показывает, как назначить латинский шрифт элементу темы:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Этот код JavaScript показывает, как изменить шрифт темы презентации:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Шрифт во всех текстовых блоках будет обновлён.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint шрифты](/slides/ru/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предопределённых фонов, но в типичной презентации сохраняются только 3 из этих 12 фонов.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить следующий код JavaScript, чтобы определить количество предопределённых фонов в презентации:

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
Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme), вы можете добавить или получить доступ к стилю фона в теме PowerPoint.
{{% /alert %}} 

Этот код JavaScript показывает, как установить фон для презентации:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Руководство по индексам**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint фон](/slides/ru/nodejs-java/presentation-background/).
{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: тонкий, средний и интенсивный. Например, это результат, когда эффекты применяются к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/FormatScheme) вы можете изменять элементы темы (даже более гибко, чем параметры в PowerPoint).

Этот код JavaScript показывает, как изменить эффект темы, изменяя части элементов:

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

**Могу ли я применить тему к отдельному слайду, не изменяя мастер?**  

Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, сохранив оригинальную тему мастера (через [SlideThemeManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidethememanager/)).

**Какой лучший способ перенести тему из одной презентации в другую?**  

[Клонировать слайды](/slides/ru/nodejs-java/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, раскладки и связанную тему, чтобы внешний вид оставался согласованным.

**Как увидеть «эффективные» значения после всего наследования и переопределений?**  

Используйте "эффективные" представления API (["effective" views](/slides/ru/nodejs-java/shape-effective-properties/)) для темы/цвета/шрифта/эффекта. Они возвращают вычисленные окончательные свойства после применения мастера и всех локальных переопределений.
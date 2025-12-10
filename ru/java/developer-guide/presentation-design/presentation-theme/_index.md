---
title: Управление темами презентаций в Java
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/java/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управлять темой
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- OpenDocument
- Презентация
- Java
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для Java, чтобы создавать, настраивать и конвертировать файлы PowerPoint с единым брендингом."
---

Тема презентации определяет свойства элементов дизайна. При выборе темы презентации вы фактически выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [шрифты](/slides/ru/java/powerpoint-fonts/), [стили фона](/slides/ru/java/presentation-background/) и эффектов.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

Тема PowerPoint использует определённый набор цветов для различных элементов слайда. Если вам не нравятся эти цвета, вы можете изменить их, задав новые цвета для темы. Чтобы выбрать новый цвет темы, Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor).

Этот Java‑код показывает, как изменить акцентный цвет темы:
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


Вы можете определить эффективное значение получившегося цвета следующим способом:
```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и присваиваем ему акцентный цвет (из первоначальной операции). Затем меняем цвет в теме:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


Новый цвет применяется автоматически к обоим элементам.

### **Set Theme Color from an Additional Palette**

При применении преобразований яркости к основному цвету темы(1) формируются цвета из дополнительной палитры(2). Затем их можно установить и получить.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот Java‑код демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Акцент 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Акцент 4, светлее 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Акцент 4, светлее 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Акцент 4, светлее 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Акцент 4, темнее 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Акцент 4, темнее 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Change Theme Font**

Чтобы выбрать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, что использует PowerPoint):

* **+mn-lt** – Основной шрифт латиницы (Minor Latin Font)
* **+mj-lt** – Шрифт заголовка латиницы (Major Latin Font)
* **+mn-ea** – Основной шрифт восточно‑азиатских языков (Minor East Asian Font)
* **+mj-ea** – Шрифт заголовка восточно‑азиатских языков (Major East Asian Font)

Этот Java‑код показывает, как присвоить латинский шрифт элементу темы:
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


Этот Java‑код показывает, как изменить шрифт темы презентации:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


Шрифт во всех текстовых полях будет обновлён.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint шрифты](/slides/ru/java/powerpoint-fonts/). 
{{% /alert %}}

## **Change Theme Background Style**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фоновых стилей, но только 3 из этих 12 обычно сохраняются в типичной презентации. 

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить следующий Java‑код, чтобы узнать количество предустановленных фонов в презентации:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
С помощью свойства [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) можно добавить или получить доступ к стилю фона в теме PowerPoint. 
{{% /alert %}} 

Этот Java‑код показывает, как задать фон для презентации:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Справочник индексов**: 0 используется для «без заполнения». Индексация начинается с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint фон](/slides/ru/java/presentation-background/). 
{{% /alert %}}

## **Change Theme Effect**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: «технический», «умеренный» и «интенсивный». Например, так выглядит результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) можно изменять элементы темы (даже гибче, чем параметры в PowerPoint).

Этот Java‑код показывает, как изменить эффект темы, изменяя части элементов:
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


Полученные изменения в цвете заполнения, типе заливки, теневом эффекте и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Можно ли применить тему только к одному слайду, не меняя мастер?**

Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему лишь к этому слайду, оставив мастер‑тему неизменной (через [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/)).

**Как безопаснее всего перенести тему из одной презентации в другую?**

[Клонировать слайды](/slides/ru/java/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, поэтому внешний вид остаётся согласованным.

**Как увидеть «эффективные» значения после всех наследований и переопределений?**

Используйте «эффективные» представления API [/slides/java/shape-effective-properties/] для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и всех локальных переопределений.
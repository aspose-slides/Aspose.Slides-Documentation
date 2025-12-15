---
title: Управление темами презентаций на Android
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/androidjava/presentation-theme/
keywords:
- тема PowerPoint
- тема презентации
- тема слайда
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
- Android
- Java
- Aspose.Slides
description: "Освойте темы презентаций в Aspose.Slides для Android с помощью Java, чтобы создавать, настраивать и конвертировать файлы PowerPoint с единым фирменным стилем."
---

Тема презентации определяет свойства элементов дизайна. Выбирая тему презентации, вы по сути выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [fonts](/slides/ru/androidjava/powerpoint-fonts/), [background styles](/slides/ru/androidjava/presentation-background/), и эффектов.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определенный набор цветов для различных элементов слайда. Если вам не нравятся цвета, вы меняете их, применяя новые цвета к теме. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

Этот Java‑код показывает, как изменить цвет акцента для темы:
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


Таким образом вы можете определить эффективное значение полученного цвета:
```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и назначаем ему цвет акцента (из первоначальной операции). Затем меняем цвет в теме:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


Новый цвет применяется автоматически к обоим элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** – Основные цвета темы  
**2** – Цвета из дополнительной палитры.

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


## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (подобные тем, что используются в PowerPoint):

* **+mn-lt** – основной шрифт Latin (Minor Latin Font)
* **+mj-lt** – шрифт заголовка Latin (Major Latin Font)
* **+mn-ea** – основной шрифт East Asian (Minor East Asian Font)
* **+mj-ea** – основной шрифт East Asian (Major East Asian Font)

Этот Java‑код показывает, как назначить шрифт Latin элементу темы:
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
Возможно, вам будет интересно посмотреть [PowerPoint fonts](/slides/ru/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предопределённых фонов, но в типичной презентации сохраняются только 3 из этих 12 фонов.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить этот Java‑код, чтобы узнать количество предопределённых фонов в презентации:
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
Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), вы можете добавить или получить стиль фона в теме PowerPoint.
{{% /alert %}} 

Этот Java‑код показывает, как установить фон для презентации:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Справочник индексов**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint Background](/slides/ru/androidjava/presentation-background/).
{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: тонкий, умеренный и интенсивный. Например, это результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) вы можете менять элементы темы (даже гибче, чем варианты в PowerPoint).

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


Получившиеся изменения в цвете заливки, типе заливки, теневом эффекте и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **Часто задаваемые вопросы**

**Могу ли я применить тему к отдельному слайду, не меняя мастер?**  
Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, сохранив мастер‑тему нетронутой (через [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/)).

**Какой самый надёжный способ перенести тему из одной презентации в другую?**  
[Clone slides](/slides/ru/androidjava/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, так что внешний вид остаётся одинаковым.

**Как увидеть «эффективные» значения после всех наследований и переопределений?**  
Используйте «эффективные» представления API [/slides/androidjava/shape-effective-properties/] для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и любых локальных переопределений.
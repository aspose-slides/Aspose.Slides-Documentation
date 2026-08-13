---
title: Управление темами презентаций в Java
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/java/presentation-theme/
keywords:
- Тема PowerPoint
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
- Java
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для Java, создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендированием."
---
## **Введение**

Тема презентации определяет свойства элементов дизайна. Выбирая тему презентации, вы фактически выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/java/powerpoint-fonts/), [стили фона](/slides/ru/java/presentation-background/), и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменение цвета темы**

Тема PowerPoint использует определённый набор цветов для разных элементов на слайде. Если вам не нравятся цвета, вы меняете их, применяя новые цвета к теме. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SchemeColor).

Этот Java‑код показывает, как изменить акцентный цвет темы:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Вы можете определить фактическое значение полученного цвета следующим способом:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и назначаем ему акцентный цвет (из начальной операции). Затем меняем цвет в теме:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Новый цвет применяется автоматически к обоим элементам.

### **Установка цвета темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот Java‑код демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Акцент 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Акцент 4, Светлее 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Акцент 4, Светлее 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Акцент 4, Светлее 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Акцент 4, Темнее 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Акцент 4, Темнее 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Отображение `SchemeColor` в цвета `IColorScheme`**

Работая с [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/), вы можете заметить, что он содержит следующие значения цветов темы:

`Background1`, `Background2`, `Text1` и `Text2`.

Однако `Presentation.getMasterTheme().getColorScheme()` возвращает [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/), который предоставляет соответствующие цвета как:

`Dark1`, `Dark2`, `Light1` и `Light2`.

Это различие только в названиях. Эти значения относятся к тем же слотам цветов темы, и сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Динамического преобразования между `Text`/`Background` и `Dark`/`Light` нет. Это просто альтернативные названия одних и тех же цветов темы.

Такое различие в названиях происходит из терминологии Microsoft Office. В более старых версиях Office использовались `Dark 1`, `Light 1`, `Dark 2` и `Light 2`, тогда как в новых версиях пользовательского интерфейса те же слоты отображаются как `Text 1`, `Background 1`, `Text 2` и `Background 2`.

## **Изменение шрифта темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (аналогичные тем, что используются в PowerPoint):

* **+mn-lt** – Основной шрифт Latin (Minor Latin Font)
* **+mj-lt** – Шрифт заголовка Latin (Major Latin Font)
* **+mn-ea** – Основной шрифт East Asian (Minor East Asian Font)
* **+mj-ea** – Шрифт заголовка East Asian (Major East Asian Font)

Этот Java‑код показывает, как назначить латинский шрифт элементу темы:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Этот Java‑код показывает, как изменить шрифт темы презентации:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Шрифт во всех текстовых полях будет обновлён.

{{% alert color="info" title="TIP" %}} 
Возможно, вы захотите посмотреть [шрифты PowerPoint](/slides/ru/java/powerpoint-fonts/).
{{% /alert %}}

## **Изменение стиля фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предопределённых фонов, но только 3 из этих 12 сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint, вы можете выполнить этот Java‑код, чтобы узнать количество предопределённых фонов в презентации:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) из класса [FormatScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme), вы можете добавить или получить доступ к стилю фона в теме PowerPoint. 
{{% /alert %}} 

Этот Java‑код показывает, как установить фон для презентации:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Справочник индексов**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="info" title="TIP" %}} 
Возможно, вы захотите посмотреть [фон PowerPoint](/slides/ru/java/presentation-background/).
{{% /alert %}}

## **Изменение эффекта темы**

Тема PowerPoint обычно содержит по 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: лёгкий, умеренный и интенсивный. Например, так выглядит результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme#getEffectStyles--)) из класса [FormatScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FormatScheme) вы можете изменять элементы в теме (даже гибче, чем параметры в PowerPoint).

Этот Java‑код показывает, как изменить эффект темы, изменяя части элементов:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Полученные изменения в цвете заливки, типе заливки, тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Можно ли применить тему к отдельному слайду без изменения мастера?

Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив мастер‑тему без изменений (через [SlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidethememanager/)).

### Какой самый безопасный способ перенести тему из одной презентации в другую?

[Клонировать слайды](/slides/ru/java/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, чтобы внешний вид оставался согласованным.

### Как увидеть «фактические» значения после всех наследований и переопределений?

Используйте «фактические» представления API](/slides/ru/java/shape-effective-properties/) для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и любых локальных переопределений.
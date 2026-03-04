---
title: Управление темами презентаций в .NET
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/net/presentation-theme/
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
- .NET
- C#
- Aspose.Slides
description: "Создавайте, настраивайте и конвертируйте файлы PowerPoint с единым фирменным стилем, используя мастер‑темы презентаций в Aspose.Slides для .NET."
---
Тема презентации определяет свойства элементов оформления. При выборе темы презентации вы по сути выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема состоит из цветов, [шрифтов](/slides/ru/net/powerpoint-fonts/), [стилей фона](/slides/ru/net/presentation-background/) и эффектов.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

Тема PowerPoint использует определённый набор цветов для разных элементов слайда. Если вам не нравятся эти цвета, вы можете изменить их, применив новые цвета к теме. Чтобы выбрать новый цвет темы, Aspose.Slides предоставляет значения перечисления [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/).

Этот код C# показывает, как изменить цвет акцента для темы:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Вы можете определить эффективное значение полученного цвета следующим образом:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Цвет [A=255, R=128, G=100, B=162])
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём ещё один элемент и назначаем ему цвет акцента (из начальной операции). Затем меняем цвет в теме:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Новый цвет применяется автоматически к обоим элементам.

### **Set Theme Color from an Additional Palette**

Когда вы применяете преобразования яркости к основному цвету темы (1), формируются цвета из дополнительной палитры (2). Затем вы можете задавать и получать эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** – Основные цвета темы  

**2** – Цвета из дополнительной палитры.

Этот код C# демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Акцент 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Акцент 4, светлее 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Акцент 4, светлее 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Акцент 4, светлее 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Акцент 4, темнее 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Акцент 4, темнее 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Map `SchemeColor` to `IColorScheme` Colors**

При работе с [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/) вы можете заметить, что он содержит следующие значения цветов темы: `Background1`, `Background2`, `Text1` и `Text2`.

Однако `Presentation.MasterTheme.ColorScheme` возвращает [IColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/icolorscheme/), который раскрывает соответствующие цвета как: `Dark1`, `Dark2`, `Light1` и `Light2`.

Это различие только в названиях. Эти значения относятся к тем же слотам цветов темы, и сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Динамического преобразования между `Text`/`Background` и `Dark`/`Light` нет. Это просто альтернативные названия одних и тех же цветов темы.

Такое различие в названиях происходит из терминологии Microsoft Office. В старых версиях Office использовались названия `Dark 1`, `Light 1`, `Dark 2` и `Light 2`, а в новых интерфейсах те же слоты отображаются как `Text 1`, `Background 1`, `Text 2` и `Background 2`.

## **Change Theme Font**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует следующие специальные идентификаторы (аналогичные тем, что применяются в PowerPoint):

* **+mn-lt** – Текстовый шрифт Latin (Minor Latin Font)
* **+mj-lt** – Шрифт заголовка Latin (Major Latin Font)
* **+mn-ea** – Текстовый шрифт East Asian (Minor East Asian Font)
* **+mj-ea** – Текстовый шрифт East Asian (Minor East Asian Font)

Этот код C# показывает, как назначить латинский шрифт элементу темы:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Этот код C# показывает, как изменить шрифт темы презентации:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Шрифт во всех текстовых блоках будет обновлён.

{{% alert color="primary" title="TIP" %}} 
Возможно, вы захотите посмотреть [шрифты PowerPoint](/slides/ru/net/powerpoint-fonts/). 
{{% /alert %}}

## **Change Theme Background Style**

По умолчанию приложение PowerPoint предоставляет 12 предопределённых фонов, но в типичной презентации сохраняются только 3 из этих 12 фонов.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить этот код C# чтобы узнать количество предопределённых фонов в презентации:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) класса [FormatScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/) вы можете добавить или получить доступ к стилю фона в теме PowerPoint. 
{{% /alert %}}

Этот код C# показывает, как установить фон для презентации:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Справочник индексов**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет интересно посмотреть [фон PowerPoint](/slides/ru/net/presentation-background/). 
{{% /alert %}}

## **Change Theme Effect**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: subtle, moderate и intense. Например, так выглядит результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/effectstyles)) класса [FormatScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme) вы можете изменять элементы темы (даже более гибко, чем варианты в PowerPoint).

Этот код C# показывает, как изменить эффект темы, изменяя части элементов:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Полученные изменения в цвете заливки, типе заливки, тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив мастер‑тему неизменной (через [SlideThemeManager](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/slidethememanager/)).

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

[Клонирование слайдов](/slides/ru/net/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет исходный мастер, макеты и связанную тему, поэтому внешний вид остаётся согласованным.

**Как я могу увидеть «эффективные» значения после всех наследований и переопределений?**

Используйте «эффективные» представления API [/shape-effective-properties/](/slides/ru/net/shape-effective-properties/) для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и любых локальных переопределений.
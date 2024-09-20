---
title: Тема Презентации
type: docs
weight: 10
url: /net/presentation-theme/
keywords: "Тема, тема PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Тема презентации PowerPoint на C# или .NET"
---

Тема презентации определяет свойства элементов дизайна. Когда вы выбираете тему презентации, вы в основном выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/net/powerpoint-fonts/), [стили фона](/slides/net/presentation-background/) и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует конкретный набор цветов для различных элементов на слайде. Если вам не нравятся цвета, вы можете изменить их, применив новые цвета к теме. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения из перечисления [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

Этот код на C# показывает, как изменить цвет акцента для темы:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Вы можете определить эффективное значение полученного цвета таким образом:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Цвет [A=255, R=128, G=100, B=162])
```

Чтобы дальше продемонстрировать операцию изменения цвета, мы создаем другой элемент и присваиваем ему цвет акцента (из начальной операции). Затем мы изменяем цвет в теме:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Новый цвет автоматически применяется ко всем элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Вы можете тогда установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот код на C# демонстрирует операцию, в которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Акцент 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Акцент 4, Светлее на 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Акцент 4, Светлее на 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Акцент 4, Светлее на 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Акцент 4, Темнее на 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Акцент 4, Темнее на 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **Изменить шрифт темы**

Чтобы позволить вам выбрать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (подобные тем, что используются в PowerPoint):

* **+mn-lt** - Тело шрифта Латиница (минорный латинский шрифт)
* **+mj-lt** - Заглавный шрифт Латиница (мажорный латинский шрифт)
* **+mn-ea** - Тело шрифта Восточная Азия (минорный восточноазиатский шрифт)
* **+mj-ea** - Заглавный шрифт Восточная Азия (минорный восточноазиатский шрифт)

Этот код на C# показывает, как назначить латиницу элементу темы:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Формат текста темы");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Этот код на C# показывает, как изменить шрифт темы презентации:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Шрифт во всех текстовых полях будет обновлен.

{{% alert color="primary" title="СОВЕТ" %}} 

Вы можете посмотреть [шрифты PowerPoint](/slides/net/powerpoint-fonts/).

{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но только 3 из этих 12 фонов сохраняются в типичной презентации.

![todo:image_alt_text](presentation-design_8.png)

Например, после того как вы сохранили презентацию в приложении PowerPoint, вы можете выполнить этот код на C#, чтобы узнать количество предустановленных фонов в презентации:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Количество стилей заливки фона для темы равно {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) из класса [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/), вы можете добавить или получить стиль фона в теме PowerPoint.

{{% /alert %}}

Этот код на C# показывает, как установить фон для презентации:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Справочник индексов**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="СОВЕТ" %}} 

Вы можете посмотреть [фон PowerPoint](/slides/net/presentation-background/).

{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединены в 3 эффекта: легкий, умеренный и интенсивный. Например, это результат, когда эффекты применяются к определенной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) из класса [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme), вы можете изменить элементы в теме (даже более гибко, чем варианты в PowerPoint).

Этот код на C# показывает, как изменить эффект темы, изменяя части элементов:

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

Изменения в цвете заливки, типе заливки, эффекте тени и т. д.:

![todo:image_alt_text](presentation-design_11.png)
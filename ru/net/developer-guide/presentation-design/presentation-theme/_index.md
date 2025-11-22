---
title: Тема презентации
type: docs
weight: 10
url: /ru/net/presentation-theme/
keywords: "Тема, Тема PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Тема презентации PowerPoint на C# или .NET"
---

Тема презентации определяет свойства элементов дизайна. Когда вы выбираете тему презентации, вы по сути выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/net/powerpoint-fonts/), [стили фона](/slides/ru/net/presentation-background/) и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определённый набор цветов для разных элементов на слайде. Если вам не нравятся цвета, вы меняете их, применяя новые цвета к теме. Чтобы выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

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


Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём ещё один элемент и назначаем ему цвет акцента (из первоначальной операции). Затем меняем цвет в теме:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


Новый цвет применяется автоматически к обоим элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы (1), формируются цвета из дополнительной палитры (2). Затем вы можете задавать и получать эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы  
**2** - Цвета из дополнительной палитры.

Этот код C# демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используют в фигурах:
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


## **Изменить шрифт темы**

Чтобы вы могли выбирать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (аналогичные тем, что используются в PowerPoint):

* **+mn-lt** - Основной шрифт Latin (Minor Latin Font)
* **+mj-lt** - Заголовочный шрифт Latin (Major Latin Font)
* **+mn-ea** - Основной шрифт East Asian (Minor East Asian Font)
* **+mj-ea** - Основной шрифт East Asian (Minor East Asian Font)

Этот код C# показывает, как назначить шрифт Latin элементу темы:
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


Шрифт во всех текстовых полях будет обновлён.

{{% alert color="primary" title="СОВЕТ" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint шрифты](/slides/ru/net/powerpoint-fonts/).
{{% /alert %}}

## **Изменить стиль фона темы**

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
С помощью свойства [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) класса [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) вы можете добавить или получить доступ к стилю фона в теме PowerPoint. 
{{% /alert %}}

Этот код C# показывает, как установить фон для презентации:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**Справочник индексов**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="СОВЕТ" %}} 
Возможно, вам будет интересно посмотреть [PowerPoint фон](/slides/ru/net/presentation-background/).
{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы комбинируются в 3 эффекта: нежный, умеренный и интенсивный. Например, это результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) класса [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) вы можете изменять элементы темы (даже гибче, чем опции в PowerPoint).

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


Получившиеся изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **Часто задаваемые вопросы**

**Могу ли я применить тему к отдельному слайду без изменения мастера?**  
Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, сохранив тему мастера нетронутой (через [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**Какой самый безопасный способ перенести тему из одной презентации в другую?**  
[Клонировать слайды](/slides/ru/net/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, так что внешний вид остаётся согласованным.

**Как я могу увидеть «эффективные» значения после всех наследований и переопределений?**  
Используйте «эффективные» представления API [/slides/net/shape-effective-properties/] для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и любых локальных переопределений.
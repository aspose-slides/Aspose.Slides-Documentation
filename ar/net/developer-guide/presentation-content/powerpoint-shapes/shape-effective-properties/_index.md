---
title: خصائص الشكل الفعالة
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords: "خصائص الشكل، خصائص الكاميرا، تجهيز الضوء، شكل التبع، إطار النص، نمط النص، قيمة ارتفاع الخط، تنسيق التعبئة للجدول، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "احصل على خصائص الشكل الفعالة في عروض PowerPoint باستخدام C# أو .NET"
---

في هذا الموضوع، سنتحدث عن الخصائص **الفعالة** و **المحلية**. عندما نقوم بتعيين قيم مباشرة في هذه المستويات

1. في خصائص الجزء على الشريحة الخاصة بالجزء.
1. في نمط نص الشكل النموذجي على التخطيط أو الشريحة الرئيسية (إذا كان لإطار نص الجزء شكل).
1. في إعدادات النص العالمية للعروض التقديمية.

تُعرف تلك القيم بـ **القيم المحلية**. في أي مستوى، يمكن تعريف أو إغفال **القيم المحلية**. ولكن في النهاية، عندما يتعلق الأمر باللحظة التي تحتاج فيها التطبيق لمعرفة كيف يجب أن يبدو الجزء، فإنها تستخدم **القيم الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

يوضح المثال التالي كيفية الحصول على القيم الفعالة.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```



## **احصل على خصائص الكاميرا الفعالة**
تسمح Aspose.Slides لـ .NET للمطورين بالحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، تمت إضافة فئة **CameraEffectiveData** في Aspose.Slides. تمثل فئة CameraEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم استخدام مثيل فئة **CameraEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعالة لفئة ThreeDFormat.

يوضح المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة للكاميرا.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= خصائص الكاميرا الفعالة =");
	Console.WriteLine("النوع: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("زاوية الرؤية: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("تكبير: " + threeDEffectiveData.Camera.Zoom);
}
```


## **احصل على خصائص تجهيز الضوء الفعالة**
تسمح Aspose.Slides لـ .NET للمطورين بالحصول على الخصائص الفعالة لتجهيز الضوء. لهذا الغرض، تمت إضافة فئة **LightRigEffectiveData** في Aspose.Slides. تمثل فئة LightRigEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص تجهيز الضوء الفعالة. يتم استخدام مثيل فئة **LightRigEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعالة لفئة ThreeDFormat.

يوضح المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة لتجهيز الضوء.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= خصائص تجهيز الضوء الفعالة =");
	Console.WriteLine("النوع: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("الاتجاه: " + threeDEffectiveData.LightRig.Direction);
}
```


## **احصل على خصائص شكل التبع الفعالة**
تسمح Aspose.Slides لـ .NET للمطورين بالحصول على الخصائص الفعالة لشكل التبع. لهذا الغرض، تمت إضافة فئة **ShapeBevelEffectiveData** في Aspose.Slides. تمثل فئة ShapeBevelEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص شكل الوجه الفعالة. يتم استخدام مثيل فئة **ShapeBevelEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعالة لفئة ThreeDFormat.

يوضح المثال البرمجي التالي كيفية الحصول على الخصائص الفعالة لشكل التبع.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= خصائص شكل الوجه العلوي الفعالة =");
	Console.WriteLine("النوع: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("العرض: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("الارتفاع: " + threeDEffectiveData.BevelTop.Height);
}
```



## **احصل على خصائص إطار النص الفعالة**
باستخدام Aspose.Slides لـ .NET، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، تمت إضافة فئة **TextFrameFormatEffectiveData** في Aspose.Slides التي تحتوي على خصائص تنسيق إطار النص الفعالة.

يوضح المثال البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعالة.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("نوع الربط: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("نوع التكييف التلقائي: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("نوع النص العمودي: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("الهوامش");
	Console.WriteLine("   اليسار: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   الأعلى: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   اليمين: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   الأسفل: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **احصل على خصائص نمط النص الفعالة**
باستخدام Aspose.Slides لـ .NET، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، تمت إضافة فئة **TextStyleEffectiveData** في Aspose.Slides التي تحتوي على خصائص نمط النص الفعالة. 

يوضح المثال البرمجي التالي كيفية الحصول على خصائص نمط النص الفعالة.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= تنسيق الفقرة الفعالة لمستوى النمط #" + i + " =");

        Console.WriteLine("العمق: " + effectiveStyleLevel.Depth);
        Console.WriteLine("هوامش: " + effectiveStyleLevel.Indent);
        Console.WriteLine("المحاذاة: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("محاذاة الخط: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **احصل على قيمة ارتفاع الخط الفعالة**
باستخدام Aspose.Slides لـ .NET، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا هو الكود الذي يوضح تغيير القيمة الفعالة لارتفاع الخط للجزء بعد تعيين القيم المحلية لارتفاع الخط على مستويات هيكل العروض التقديمية المختلفة. 

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("نص نموذجي مع الجزء الأول");
    IPortion portion1 = new Portion(" و الجزء الثاني.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("ارتفاع الخط الفعال مباشرة بعد الإنشاء:");
    Console.WriteLine("الجزء #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("الجزء #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للعروض التقديمية:");
    Console.WriteLine("الجزء #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("الجزء #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للفقرة:");
    Console.WriteLine("الجزء #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("الجزء #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("ارتفاع الخط الفعال بعد تعيين ارتفاع خط الجزء #0:");
    Console.WriteLine("الجزء #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("الجزء #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("ارتفاع الخط الفعال بعد تعيين ارتفاع خط الجزء #1:");
    Console.WriteLine("الجزء #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("الجزء #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **احصل على تنسيق التعبئة الفعال للجدول**
باستخدام Aspose.Slides لـ .NET، يمكنك الحصول على تنسيق التعبئة الفعال لأجزاء منطق الجدول المختلفة. لهذا الغرض، تمت إضافة واجهة **IFillFormatEffectiveData** في Aspose.Slides التي تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة أن تنسيق الخلية دائمًا له أولوية أعلى من تنسيق الصف، والصف له أولوية أعلى من العمود والعمود أعلى من الجدول ككل.

لذا، فإن خصائص **CellFormatEffectiveData** تُستخدم دائمًا لرسم الجدول. يوضح المثال البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعال لأجزاء منطق الجدول المختلفة.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```
---
title: "خصائص الشكل الفعالة"
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords: "خصائص الشكل، خصائص الكاميرا، تركيب الإضاءة، الشكل المشطوف، إطار النص، نمط النص، قيمة ارتفاع الخط، تنسيق التعبئة للجدول، عرض PowerPoint، C#، Csharp، Aspose.Slides للـ .NET"
description: "الحصول على خصائص الشكل الفعالة في عروض PowerPoint باستخدام C# أو .NET"
---

في هذا الموضوع، سنناقش الخصائص **الفعالة** و**المحلية**. عندما نقوم بتعيين القيم مباشرةً في هذه المستويات

1. في خصائص الجزء على شريحة الجزء.
1. في نمط نص الشكل النموذجي على تخطيط أو شريحة رئيسية (إذا كان لشكل إطار نص الجزء نمط).
1. في إعدادات النص العامة للعرض التقديمي.

ثم تُسمى تلك القيم **القيم المحلية**. في أي مستوى، يمكن تعريف القيم **المحلية** أو إغفالها. ولكن في النهاية عندما تحتاج التطبيق إلى معرفة الشكل الذي يجب أن يظهر به الجزء يستخدم القيم **الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

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


## **الحصول على الخصائص الفعالة للكاميرا**
يتيح Aspose.Slides for .NET للمطورين الحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، تمت إضافة الفئة **CameraEffectiveData** في Aspose.Slides. تمثل فئة CameraEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم استخدام مثال من الفئة **CameraEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** التي تمثل زوجًا من القيم الفعالة لفئة ThreeDFormat.

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة للكاميرا.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **الحصول على الخصائص الفعالة لتركيب الإضاءة**
يتيح Aspose.Slides for .NET للمطورين الحصول على الخصائص الفعالة لتركيب الإضاءة. لهذا الغرض، تمت إضافة الفئة **LightRigEffectiveData** في Aspose.Slides. تمثل فئة LightRigEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص تركيب الإضاءة الفعالة. يتم استخدام مثال من الفئة **LightRigEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** التي تمثل زوجًا من القيم الفعالة لفئة ThreeDFormat.

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة لتركيب الإضاءة.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **الحصول على الخصائص الفعالة للشكل المشطوف**
يتيح Aspose.Slides for .NET للمطورين الحصول على الخصائص الفعالة للشكل المشطوف. لهذا الغرض، تمت إضافة الفئة **ShapeBevelEffectiveData** في Aspose.Slides. تمثل فئة ShapeBevelEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص الإغماس الوجهي للشكل الفعالة. يتم استخدام مثال من الفئة **ShapeBevelEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** التي تمثل زوجًا من القيم الفعالة لفئة ThreeDFormat.

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة للشكل المشطوف.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```


## **الحصول على الخصائص الفعالة لإطار النص**
باستخدام Aspose.Slides for .NET، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، تمت إضافة الفئة **TextFrameFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق إطار النص الفعالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعالة.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```


## **الحصول على الخصائص الفعالة لنمط النص**
باستخدام Aspose.Slides for .NET، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، تمت إضافة الفئة **TextStyleEffectiveData** في Aspose.Slides والتي تحتوي على خصائص نمط النص الفعالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعالة.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```


## **الحصول على قيمة ارتفاع الخط الفعالة**
باستخدام Aspose.Slides for .NET، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. إليك الشيفرة التي توضح تغير قيمة ارتفاع الخط الفعالة للجزء بعد تعيين قيم ارتفاع الخط المحلية في مستويات مختلفة من هيكل العرض التقديمي.
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **الحصول على تنسيق التعبئة الفعال للجدول**
باستخدام Aspose.Slides for .NET، يمكنك الحصول على تنسيق تعبئة فعال لأجزاء منطقية مختلفة في الجدول. لهذا الغرض، تمت إضافة الواجهة **IFillFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة أن تنسيق الخلية له دائمًا أولوية أعلى من تنسيق الصف، والصف له أولوية أعلى من العمود، والعمود أعلى من كامل الجدول.

لذلك في النهاية تُستخدم خصائص **CellFormatEffectiveData** دائمًا لرسم الجدول. يعرض مثال الشيفرة التالي كيفية الحصول على تنسيق تعبئة فعال لأجزاء منطقية مختلفة في الجدول.
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


## **FAQ**

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن حي"، ومتى ينبغي لي قراءة الخصائص الفعالة مرة أخرى؟**  
كائنات EffectiveData هي لقطات ثابتة غير قابلة للتغيير للقيم المحسوبة في لحظة الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، يجب عليك استرجاع البيانات الفعالية مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير شريحة التخطيط/الرئيسية على الخصائص الفعالة التي تم استرجاعها بالفعل؟**  
نعم، ولكن فقط بعد قراءتها مرة أخرى. الكائن EffectiveData الذي تم الحصول عليه مسبقًا لا يحدث نفسه تلقائيًا — يجب طلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**  
لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟**  
يتم تحديد القيمة الفعالة بواسطة آلية القيم الافتراضية (القيم الافتراضية لبرنامج PowerPoint / Aspose.Slides). تصبح هذه القيمة المستخرجة جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعالة، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**  
ليس بشكل مباشر. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء/الفقرة/إطار النص والأنماط النصية في التخطيط/الرئيسية/العرض التقديمي لمعرفة أين تظهر التعريف الأول الصريح.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**  
لأن القيمة المحلية أصبحت النهائية (لم يُستدعَ أي وراثة من مستوى أعلى). في هذه الحالات، تكون القيمة الفعالة مطابقة للقيمة المحلية.

**متى يجب استخدام الخصائص الفعالة، ومتى يجب العمل فقط بالقيم المحلية؟**  
استخدم EffectiveData عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق جميع الوراثات (مثلاً، لمطابقة الألوان أو المسافات البادئة أو الأحجام). إذا كنت بحاجة إلى تغيير التنسيق على مستوى معين، عدل القيم المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.
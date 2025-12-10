---
title: إدارة أشكال العروض التقديمية في .NET
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض
- شكل على الشريحة
- العثور على الشكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض
- .NET
- C#
- Aspose.Slides
description: "تعلم إنشاء وتحرير وتحسين الأشكال في Aspose.Slides لـ .NET وتقديم عروض PowerPoint ذات أداء عالي."
---

## **العثور على شكل في شريحة**
سيتناول هذا الموضوع تقنية بسيطة لتسهيل عملية إيجاد شكل معين في شريحة للمطورين دون الحاجة إلى استخدام المعرّف الداخلي له. من المهم معرفة أن ملفات عرض PowerPoint لا توفر أي طريقة لتحديد الأشكال في الشريحة إلا باستخدام معرّف فريد داخلي. يبدو أن العثور على شكل باستخدام المعرّف الفريد الداخلي صعب على المطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل (Alt Text). نوصي المطورين باستخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح ذلك العرض باستخدام Aspose.Slides for .NET والمرور عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل، وسيكون الشكل الذي يمتلك النص البديل المطابق هو الشكل الذي تحتاجه. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) التي تقوم بالعثور على شكل معين في شريحة وتعيده ببساطة.
```c#
public static void Run()
{
    // إنشاء كائن من فئة Presentation يمثل ملف العرض
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // النص البديل للشكل المراد العثور عليه
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// تنفيذ الطريقة للعثور على شكل في شريحة باستخدام النص البديل الخاص به
public static IShape FindShape(ISlide slide, string alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // إذا كان النص البديل للشريحة يطابق المطلوب ثم
        // إرجاع الشكل
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **استنساخ شكل**
To clone a shape to a slide using Aspose.Slides for .NET:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال في الشريحة الأصلية.
1. إضافة شريحة جديدة إلى العرض.
1. استنساخ الأشكال من مجموعة الأشكال في الشريحة الأصلية إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```c#
// إنشاء كائن من فئة Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// كتابة ملف PPTX إلى القرص
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **إزالة شكل**
تمكن Aspose.Slides for .NET المطورين من إزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي لديه نص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف على القرص.
```c#
 // إنشاء كائن عرض تقديمي
 Presentation pres = new Presentation();

 // الحصول على الشريحة الأولى
 ISlide sld = pres.Slides[0];

 // إضافة شكل أوتوماتيكي من نوع مستطيل
 IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
 IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
 String alttext = "User Defined";
 int iCount = sld.Shapes.Count;
 for (int i = 0; i < iCount; i++)
 {
	AutoShape ashp = (AutoShape)sld.Shapes[0];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		sld.Shapes.Remove(ashp);
	}
 }

 // حفظ العرض التقديمي إلى القرص
 pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```




## **إخفاء شكل**
تمكن Aspose.Slides for .NET المطورين من إخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي لديه نص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف على القرص.
```c#
// إنشاء كائن من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل أوتوماتيكي من نوع مستطيل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// حفظ العرض التقديمي إلى القرص
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```




## **تغيير ترتيب الشكل**
تمكن Aspose.Slides for .NET المطورين من إعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص داخل إطار النص الخاص بالشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف على القرص.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **الحصول على معرف الشكل Interop**
تمكن Aspose.Slides for .NET المطورين من الحصول على معرف فريد للشكل ضمن نطاق الشريحة بالمقارنة مع الخاصية UniqueId التي تسمح بالحصول على معرف فريد ضمن نطاق العرض. تمت إضافة الخاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة التي تُرجعها الخاصية OfficeInteropShapeId تتطابق مع قيمة المعرف Id لكائن Microsoft.Office.Interop.PowerPoint.Shape. فيما يلي مثال على الشفرة.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// الحصول على معرّف الشكل الفريد في نطاق الشريحة
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **تعيين نص بديل لشكل**
تمكن Aspose.Slides for .NET المطورين من تعيين AlternateText لأي شكل.
يمكن تمييز الأشكال في العرض باستخدام الخاصية AlternativeText أو خاصية اسم الشكل (Shape Name).
يمكن قراءة أو تعيين الخاصية AlternativeText باستخدام Aspose.Slides وكذلك Microsoft PowerPoint.
باستخدام هذه الخاصية، يمكنك وضع علامة على شكل وإجراء عمليات مختلفة مثل إزالة الشكل،
إخفاء الشكل أو إعادة ترتيب الأشكال في شريحة.
لتعيين AlternateText لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. إجراء بعض العمليات على الشكل المضاف حديثًا.
1. المرور عبر الأشكال للعثور على شكل معين.
1. تعيين AlternativeText.
1. حفظ الملف على القرص.
```c#
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();

// الحصول على أول شريحة
ISlide sld = pres.Slides[0];

// إضافة شكل أوتوماتيكي من نوع مستطيل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// حفظ العرض التقديمي إلى القرص
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **الوصول إلى تنسيقات التخطيط لشكل**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

فيما يلي مثال على الشفرة.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **عرض شكل كـ SVG**
الآن تدعم Aspose.Slides for .NET تصيير شكل كملف SVG. تمت إضافة طريقة WriteAsSvg (وتحميلاتها) إلى فئة Shape وواجهة IShape. تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يظهر المقتطف البرمجي أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
```c#
public static void Run()
{
    string outSvgFileName = "SingleShape.svg";
    using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
    {
        using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
        {
            pres.Slides[0].Shapes[0].WriteAsSvg(stream);
        }
    }
}
```


## **محاذاة شكل**

من خلال الطريقة المحملة [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index)، يمكنك

* محاذاة الأشكال بالنسبة لهوامش الشريحة. انظر المثال 1.
* محاذاة الأشكال بالنسبة لبعضها البعض. انظر المثال 2.

تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) خيارات المحاذاة المتاحة.

**المثال 1**

يظهر هذا الكود C# كيفية محاذاة الأشكال ذات الفهارس 1 و2 و4 على الحدود العليا للشريحة:
الكود المصدر أدناه يقوم بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على الحد العلوي للشريحة.
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**المثال 2**

يوضح هذا الكود C# كيفية محاذاة مجموعة كاملة من الأشكال بالنسبة إلى الشكل السفلي في المجموعة:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **خصائص الانعكاس**

في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) التحكم في انعكاس الأشكال أفقياً وعمودياً عبر خصائص `FlipH` و`FlipV`. كلا الخصائص من نوع [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)، وتسمح بالقيم `True` للإشارة إلى انعكاس، `False` لعدم وجود انعكاس، أو `NotDefined` لاستخدام السلوك الافتراضي. هذه القيم يمكن الوصول إليها من خلال [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء كائن جديد من فئة [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) باستخدام الموقع والحجم الحاليين للشكل، والقيم المطلوبة لـ`FlipH` و`FlipV`، وزاوية الدوران. يُعيّن هذا الكائن إلى [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) الخاص بالشكل، وحفظ العرض يطبق التحولات العكسية ويثبتها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى بها شكل واحد بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

يعرض مثال الشيفرة التالي الخصائص الحالية للانعكاس للشكل ويقوم بعكسه أفقياً وعامودياً.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // استرجاع خاصية الانعكاس الأفقي للشكل.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // استرجاع خاصية الانعكاس العمودي للشكل.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // انعكاس أفقي.
    NullableBool flipV = NullableBool.True; // انعكاس عمودي.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **FAQ**

**هل يمكنني دمج الأشكال (union/intersect/subtract) في شريحة كما في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك بإنشاء المخطط المطلوب بنفسك—مثلاً حساب الهندسة الناتجة (باستخدام [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)) وإنشاء شكل جديد بهذا المخطط، مع إمكانية إزالة الأصليين.

**كيف يمكنني التحكم في ترتيب التراص (z-order) بحيث يبقى الشكل دائمًا "في الأعلى"?**

غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) الخاصة بالشريحة. للحصول على نتائج متوقعة، أكمل ترتيب z بعد جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تعديلها في PowerPoint؟**

نعم. قم بتعيين [shape-level protection flags](/slides/ar/net/applying-protection-to-presentation/) (مثل قفل الاختيار، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، انقل القيود إلى القالب الرئيس أو التخطيط. لاحظ أن هذا الحماية على مستوى واجهة المستخدم، وليست ميزة أمان؛ للحصول على حماية أقوى، اجمعها مع قيود على مستوى الملف مثل [توصيات القراءة فقط أو كلمات المرور](/slides/ar/net/password-protected-presentation/).
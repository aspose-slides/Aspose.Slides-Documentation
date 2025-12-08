---
title: معالجة الأشكال
type: docs
weight: 40
url: /ar/net/shape-manipulations/
keywords: "شكل PowerPoint, شكل على الشريحة, العثور على الشكل, استنساخ الشكل, إزالة الشكل, إخفاء الشكل, تغيير ترتيب الشكل, الحصول على معرف الشكل المتداخل, النص البديل للشكل, تنسيقات تخطيط الشكل, الشكل كـ SVG, محاذاة الشكل, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "معالجة أشكال PowerPoint في C# أو .NET"
---

## **العثور على الشكل في الشريحة**
هذا الموضوع يصف تقنية بسيطة لتسهيل العثور على شكل محدد في الشريحة دون استخدام معرّفه الداخلي. من المهم معرفة أن ملفات PowerPoint لا تملك طريقة لتحديد الأشكال في الشريحة إلا عبر معرّف فريد داخلي. يبدو أن العثور على شكل باستخدام معرّفه الفريد الداخلي صعب على المطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح ذلك العرض باستخدام Aspose.Slides for .NET والمرور عبر جميع الأشكال المضافة إلى الشريحة. خلال كل دورة، يمكنك فحص النص البديل للشكل، والشكل الذي يتطابق نصه البديل هو الشكل المطلوب. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) التي تقوم بالمهمة للعثور على شكل محدد في الشريحة وتعيد ذلك الشكل ببساطة.
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
        
// تنفيذ طريقة للعثور على شكل في شريحة باستخدام النص البديل الخاص به
public static IShape FindShape(ISlide slide, string alttext)
{
    // التجول عبر جميع الأشكال داخل الشريحة
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


## **استنساخ الشكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف مجموعة أشكال إلى شريحة.
```c#
// إنشاء فئة Presentation
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


## **إزالة الشكل**
يسمح Aspose.Slides for .NET للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```c#
// إنشاء كائن Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// إضافة AutoShape من النوع Rectangle
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

// حفظ العرض إلى القرص
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```


## **إخفاء الشكل**
يسمح Aspose.Slides for .NET للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل تلقائي من نوع المستطيل
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

// حفظ العرض إلى القرص
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **تغيير ترتيب الأشكال**
يسمح Aspose.Slides for .NET للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو الخلفية. لإعادة ترتيب الأشكال في أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص إلى إطار النص الخاص بالشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف إلى القرص.
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


## **الحصول على معرّف الشكل المتناظر (Interop Shape ID)**
يسمح Aspose.Slides for .NET للمطورين بالحصول على معرّف شكل فريد في نطاق الشريحة بالمقارنة مع الخاصية UniqueId التي تسمح بالحصول على معرّف فريد في نطاق العرض. تمت إضافة الخاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة التي تُرجعها الخاصية OfficeInteropShapeId تتطابق مع قيمة Id لكائن Microsoft.Office.Interop.PowerPoint.Shape. فيما يلي مثال على الكود.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// الحصول على معرف الشكل الفريد في نطاق الشريحة
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **تعيين النص البديل للشكل**
يسمح Aspose.Slides for .NET للمطورين بتعيين AlternateText لأي شكل. يمكن تمييز الأشكال في العرض بواسطة الخاصية AlternativeText أو خاصية اسم الشكل. يمكن قراءة أو تعيين الخاصية AlternativeText باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الخاصية، يمكنك وضع علامة على الشكل وإجراء عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على الشريحة. لتعيين AlternateText لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. إجراء بعض العمليات على الشكل المضاف حديثًا.
1. التجول عبر الأشكال للعثور على شكل.
1. تعيين AlternativeText.
1. حفظ الملف إلى القرص.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل تلقائي من نوع المستطيل
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

// حفظ العرض إلى القرص
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```


## **الوصول إلى تنسيقات التخطيط للشكل**
يوفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. يوضح هذا المقال كيفية الوصول إلى تنسيقات التخطيط.

فيما يلي مثال على الكود.
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


## **تصيير الشكل كـ SVG**
الآن يدعم Aspose.Slides for .NET تصيير الشكل كملف SVG. تم إضافة طريقة WriteAsSvg (وتحميلها) إلى فئة Shape وواجهة IShape. تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح المقتطف التالي كيفية تصدير شكل الشريحة إلى ملف SVG.
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


## **محاذاة الشكل**

من خلال الطريقة [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) المتعددة التحميل، يمكنك

* محاذاة الأشكال نسبة إلى هوامش الشريحة. انظر المثال 1.
* محاذاة الأشكال نسبة إلى بعضها البعض. انظر المثال 2.

تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) خيارات المحاذاة المتاحة.

**المثال 1**

هذا الكود C# يوضح كيفية محاذاة الأشكال ذات الفهارس 1 و2 و4 على الحدود العليا للشريحة:
الكود المصدر أدناه يحرك الأشكال ذات الفهارس 1 و2 و4 على الحد العلوي للشريحة.
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

هذا الكود C# يوضح كيفية محاذاة مجموعة كاملة من الأشكال نسبة إلى الشكل السفلي في المجموعة:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **خصائص الانعكاس (Flip Properties)**

في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) التحكم في الانعكاس الأفقي والعمودي للأشكال عبر خصائص `FlipH` و `FlipV`. كلتا الخاصيتين من نوع [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)، وتقبل القيم `True` للدلالة على الانعكاس، `False` لعدم الانعكاس، أو `NotDefined` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء مثيل جديد من [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) باستخدام الموقع الحالي والحجم للشكل، والقيم المطلوبة لـ `FlipH` و `FlipV`، وزاوية الدوران. يتم تعيين هذا المثيل إلى [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) الخاص بالشكل وحفظ العرض لتطبيق التحولات الانعكاسية وتسجيلها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx حيث تحتوي الشريحة الأولى على شكل واحد بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

المثال التالي يسترجع خصائص الانعكاس الحالية للشكل ويقوم بانعكاسه أفقيًا وعموديًا.
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

## **الأسئلة الشائعة**

**هل يمكنني دمج الأشكال (اتحاد/تقاطع/طرح) في شريحة كما في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك بإنشاء الشكل المطلوب يدويًا—مثلاً حساب الهندسة الناتجة (باستخدام [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)) وإنشاء شكل جديد بهذه الحدود، مع إلغاء الأصلية إذا رغبت.

**كيف يمكنني التحكم في ترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا "في القمة"؟**

غيّر ترتيب الإدخال/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) الخاصة بالشريحة. للحصول على نتائج متوقعة، اضبط z-order بعد جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تعديلها في PowerPoint؟**

نعم. عيّن علامات الحماية على مستوى الشكل ([shape-level protection flags])(/slides/ar/net/applying-protection-to-presentation/) (مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، طبع القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى الواجهة، ليست ميزة أمان؛ للحصول على حماية أقوى، اجمعها مع قيود على مستوى الملف مثل التوصيات للقراءة فقط أو كلمات المرور ([read‑only recommendations or passwords](/slides/ar/net/password-protected-presentation/)).
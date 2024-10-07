---
title: عمليات تغيير الشكل
type: docs
weight: 40
url: /net/shape-manipulations/
keywords: "شكل PowerPoint، شكل على الشريحة، العثور على شكل، استنساخ شكل، إزالة شكل، إخفاء شكل، تغيير ترتيب الشكل، الحصول على معرف شكل Interlop، نص بديل للشكل، تنسيقات تخطيط الشكل، شكل كـ SVG، محاذاة الشكل، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تلاعب بأشكال PowerPoint في C# أو .NET"
---

## **البحث عن شكل في الشريحة**
سيصف هذا الموضوع تقنية بسيطة لتسهيل على المطورين العثور على شكل معين على شريحة دون استخدام معرفه الداخلي. من المهم معرفة أن ملفات عرض PowerPoint لا تحتوي على أي وسيلة لتحديد الأشكال على الشريحة باستثناء معرف فريد داخلي. يبدو أن من الصعب على المطورين العثور على شكل باستخدام معرفه الفريد الداخلي. جميع الأشكال المضافة إلى الشرائح لها نص بديل. نحن نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للأشياء التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب فيه، يمكنك فتح ذلك العرض باستخدام Aspose.Slides لـ .NET والتكرار عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك التحقق من النص البديل للشكل والشكل الذي يتطابق مع النص البديل سيكون الشكل المطلوب منك. لإظهار هذه التقنية بشكل أفضل، قمنا بإنشاء طريقة، [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) التي تقوم بالحيلة للعثور على شكل معين في الشريحة ثم تعيد ببساطة ذلك الشكل.

```c#
public static void Run()
{
    // إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // النص البديل للشكل الذي سيتم العثور عليه
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("اسم الشكل: " + shape.Name);
        }
    }
}
        
// تنفيذ الطريقة للعثور على شكل في الشريحة باستخدام نصه البديل
public static IShape FindShape(ISlide slide, string alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // إذا كان النص البديل للشريحة يتطابق مع النص المطلوب
        // إرجاع الشكل
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **استنساخ الشكل**
لاستنساخ شكل إلى الشريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى الشريحة.

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



## **إزالة الشكل**
يسمح Aspose.Slides لـ .NET للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل معين.
1. إزالة الشكل.
1. حفظ الملف على القرص.

```c#
// إنشاء كائن Presentation
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل تلقائي من نوع المستطيل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "مستخدم محدد";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// حفظ العرض التقديمي على القرص
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **إخفاء الشكل**
يسمح Aspose.Slides لـ .NET للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل معين.
1. إخفاء الشكل.
1. حفظ الملف على القرص.

```c#
// إنشاء كائن Presentation يمثل PPTX
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة شكل تلقائي من نوع المستطيل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "مستخدم محدد";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// حفظ العرض التقديمي على القرص
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **تغيير ترتيب الأشكال**
يسمح Aspose.Slides لـ .NET للمطورين بإعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل في المقدمة أو أي شكل في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص في إطار نص الشكل.
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
portion.Text="نص العلامة المائية نص العلامة المائية نص العلامة المائية";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **الحصول على معرف الشكل Interop**
يسمح Aspose.Slides لـ .NET للمطورين بالحصول على معرف فريد للشكل في إطار الشريحة، على عكس خاصية UniqueId، التي تسمح بالحصول على معرف فريد في نطاق العرض التقديمي. تمت إضافة خاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة التي ترجعها خاصية OfficeInteropShapeId تتوافق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه هو مثال للشفرة المعطاة.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// الحصول على معرف شكل فريد في إطار الشريحة
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **تعيين نص بديل للشكل**
يسمح Aspose.Slides لـ .NET للمطورين بتعيين AlternateText لأي شكل. 
يمكن تمييز الأشكال في عرض تقديمي من خلال خاصية النص البديل أو اسم الشكل. 
يمكن قراءة أو تعيين خاصية النص البديل باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. 
باستخدام هذه الخاصية، يمكنك وضع علامة على شكل ويمكنك تنفيذ عمليات مختلفة مثل إزالة شكل، 
إخفاء شكل أو إعادة ترتيب الأشكال على شريحة.
لتعيين النص البديل لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض العمل مع الشكل الذي تم إضافته حديثًا.
1. التكرار عبر الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف على القرص.

```c#
// إنشاء كائن Presentation يمثل PPTX
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
        ashp.AlternativeText = "مستخدم محدد";
    }
}

// حفظ العرض التقديمي على القرص
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **الوصول إلى تنسيقات التخطيط للشكل**
 يوفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. يوضح هذا المقال كيف يمكنك الوصول إلى تنسيقات التخطيط.

أدناه هو كود المثال المعطى.

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
الآن يدعم Aspose.Slides لـ .NET عرض شكل كـ SVG. تمت إضافة طريقة WriteAsSvg (والتحميلات الخاصة بها) إلى فئة Shape وواجهة IShape. هذه الطريقة تسمح بحفظ محتوى الشكل كملف SVG. يظهر مقتطف الكود أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.

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

## محاذاة الشكل

من خلال طريقة [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) المحملة، يمكنك 

* محاذاة الأشكال بالنسبة لهامش الشريحة. انظر المثال 1. 
* محاذاة الأشكال بالنسبة لبعضها البعض. انظر المثال 2. 

تُعرف التعداد ShapesAlignmentType خيارات المحاذاة المتاحة.

### المثال 1

يعرض هذا الكود C# كيفية محاذاة الأشكال ذات الفهارس 1 و2 و4 على طول الحدود العلوية لشريحة:
الكود المصدر أدناه يقوم بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على طول الحدود العلوية للشريحة. 

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

### المثال 2

يعرض هذا الكود C# كيفية محاذاة مجموعة كاملة من الأشكال بالنسبة إلى الشكل السفلي في المجموعة:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```
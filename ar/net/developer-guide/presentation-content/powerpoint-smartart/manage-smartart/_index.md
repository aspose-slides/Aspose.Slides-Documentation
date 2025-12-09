---
title: إدارة SmartArt في عروض PowerPoint التقديمية في .NET
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/net/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفي
- مخطط المؤسسة
- مخطط صورة المؤسسة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for .NET مع أمثلة كود C# واضحة تسهل تصميم الشرائح والأتمتة."
---

## **الحصول على النص من SmartArt**
تم الآن إضافة الخاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من SmartArt إذا لم يقتصر على نص العقد فقط. سيساعدك كود العينة التالي في الحصول على النص من عقدة SmartArt.
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **تغيير نوع التخطيط لـ SmartArt**
لتغيير نوع التخطيط لـ SmartArt، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة `Presentation` class.
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة SmartArt BasicBlockList.
- تغيير LayoutType إلى BasicProcess.
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكليْن.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // تغيير LayoutType إلى BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // حفظ العرض التقديمي
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **التحقق من الخاصية Hidden في SmartArt**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات. للتحقق من الخاصية hidden لأي عقدة في SmartArt، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة `Presentation` class.
- إضافة SmartArt RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من الخاصية isHidden.
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكليْن.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة إلى SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // التحقق من خاصية isHidden
    bool hidden = node.IsHidden; // يعيد true

    if (hidden)
    {
        // تنفيذ بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **الحصول على أو تعيين نوع مخطط المؤسسة**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) بالحصول على أو تعيين نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المؤسسة، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة `Presentation` class.
- إضافة SmartArt إلى الشريحة.
- الحصول على أو تعيين نوع مخطط المؤسسة.
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكليْن.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول على أو تعيين نوع مخطط المؤسسة 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // حفظ العرض التقديمي
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مخطط صورة المؤسسة**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء نسخة من الفئة `Presentation` class.
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط بالبيانات الافتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. كتابة العرض التقديمي المعدل إلى ملف PPTX

يتم استخدام الكود التالي لإنشاء المخطط.
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**هل يدعم SmartArt عكس/انعكاس للغات من اليمين إلى اليسار؟**

نعم. الخاصية [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة كاملة](/slides/ar/net/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والنمط.

**كيف أُظهر SmartArt كصورة نقطية للمعاينة أو التصدير إلى الويب؟**

يمكنك [تحويل الشريحة](/slides/ar/net/convert-powerpoint-to-png/) (أو العرض التقديمي كاملًا) إلى PNG/JPEG عبر API الذي يحول الشرائح/العروض إلى صور — سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا اختيار SmartArt معين على شريحة إذا كان هناك عدة منها؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) والبحث عن الشكل عبر تلك السمة داخل [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). توضح الوثائق تقنيات شائعة للعثور على الأشكال والعمل معها.
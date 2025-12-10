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
- خاصية الإخفاء
- مخطط تنظيمي
- مخطط تنظيم صورة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for .NET مع أمثلة شفرة C# واضحة تُسرّع تصميم الشرائح وأتمتتها."
---

## **الحصول على النص من كائن SmartArt**
تم الآن إضافة خاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من SmartArt إذا لم يقتصر فقط على نص العقد. سيساعدك كود العينة التالي في الحصول على النص من عقدة SmartArt.
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


## **تغيير نوع التخطيط لكائن SmartArt**
لتغيير نوع تخطيط SmartArt. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة `Presentation`.
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة SmartArt BasicBlockList.
- تغيير LayoutType إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
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


## **التحقق من خاصية الإخفاء لكائن SmartArt**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة في SmartArt. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة `Presentation`.
- إضافة SmartArt RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية isHidden.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
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
        // إجراء بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **الحصول على أو تعيين نوع مخطط التنظيم**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) بالحصول على أو تعيين نوع مخطط التنظيم المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط التنظيم. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة `Presentation`.
- إضافة SmartArt على الشريحة.
- الحصول على أو تعيين نوع مخطط التنظيم.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول على أو تعيين نوع مخطط التنظيم 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // حفظ العرض التقديمي
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مخطط تنظيم بصورة**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من الفئة `Presentation`.
2. الحصول على مرجع الشريحة بواسطة فهرستها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. حفظ العرض التقديمي المعدل إلى ملف PPTX.
الكود التالي يُستخدم لإنشاء مخطط.
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


## **الأسئلة المتكررة**

**هل يدعم SmartArt عكس/انعكاس للغات من اليمين إلى اليسار؟**

نعم. خاصية [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) تغيّر اتجاه المخطط (من اليسار إلى اليمين/من اليمين إلى اليسار) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/net/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو التصدير للويب؟**

[قم بتحويل الشريحة](/slides/ar/net/convert-powerpoint-to-png/) (أو العرض التقديمي بالكامل) إلى PNG/JPEG عبر الواجهة التي تحول الشرائح/العروض إلى صور — سيُرسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا تحديد SmartArt معين على شريحة إذا كان هناك عدة عناصر؟**

من الممارسات الشائعة استخدام [النص البديل](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) والبحث عن الشكل عبر تلك السمة داخل [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)، ثم التحقق من النوع للتأكد أنه [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). توضح الوثائق تقنيات شائعة للعثور على الأشكال والعمل معها.
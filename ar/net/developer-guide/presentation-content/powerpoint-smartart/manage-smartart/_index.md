---
title: إدارة SmartArt
type: docs
weight: 10
url: /ar/net/manage-smartart/
keywords: "SmartArt, نص من SmartArt, مخطط نوع المنظمة, مخطط منظمة الصورة, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "SmartArt ومخطط نوع المنظمة في عروض PowerPoint باستخدام C# أو .NET"
---

## **الحصول على النص من SmartArt**
تمت إضافة خاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من SmartArt إذا لم يكن يحتوي فقط على نص العقد. سيساعدك شفرة العينة التالية في الحصول على النص من عقدة SmartArt.
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
من أجل تغيير نوع التخطيط لـ SmartArt. يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة `Presentation`.
- الحصول على مرجع الشريحة باستخدام فهرستها.
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


## **التحقق من الخاصية المخفية لـ SmartArt**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() تُعيد true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من الخاصية المخفية لأي عقدة في SmartArt. يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة `Presentation`.
- إضافة SmartArt RadialCycle.
- إضافة عقدة على SmartArt.
- التحقق من الخاصية isHidden.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة على SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // التحقق من خاصية isHidden
    bool hidden = node.IsHidden; // ترجع true

    if (hidden)
    {
        // تنفيذ بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **الحصول على نوع مخطط المنظمة أو تعيينه**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int) بالحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المنظمة. يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة `Presentation`.
- إضافة SmartArt إلى الشريحة.
- الحصول على أو تعيين نوع مخطط المنظمة.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
```c#
using (Presentation presentation = new Presentation())
{
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول على أو تعيين نوع مخطط المنظمة 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // حفظ العرض التقديمي
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء مثال من الفئة `Presentation`.
2. الحصول على مرجع الشريحة بواسطة فهرستها.
3. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. حفظ العرض التقديمي المعدل كملف PPTX

يتم استخدام الشفرة التالية لإنشاء مخطط.
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


## **الأسئلة الشائعة**

**هل يدعم SmartArt العكس/الانعكاس للغات RTL؟**

نعم. الخاصية [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) تُغيّر اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/net/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني تصيير SmartArt إلى صورة نقطية للمعاينة أو التصدير للويب؟**

[تصيير الشريحة](/slides/ar/net/convert-powerpoint-to-png/) (أو العرض الكامل) إلى PNG/JPEG عبر واجهة برمجة التطبيقات التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني اختيار SmartArt معين برمجيًا على شريحة إذا كان هناك عدة؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) والبحث عن الشكل عبر تلك الخاصية داخل [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)، ثم فحص النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). توضح الوثائق تقنيات مألوفة للعثور على الأشكال والعمل معها.
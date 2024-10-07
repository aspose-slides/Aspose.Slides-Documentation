---
title: إدارة الرسوم الذكية
type: docs
weight: 10
url: /net/manage-smartart/
keywords: "الرسوم الذكية, نص من الرسوم الذكية, مخطط نوع المنظمة, مخطط تنظيم الصور, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "الرسوم الذكية ومخطط نوع المنظمة في عروض PowerPoint في C# أو .NET"
---

## **احصل على النص من الرسوم الذكية**
الآن تم إضافة خاصية TextFrame إلى واجهة ISmartArtShape وطبقة SmartArtShape على التوالي. تسمح لك هذه الخاصية بالحصول على جميع النصوص من الرسوم الذكية إذا كانت تحتوي على نصوص من العقد فقط. سيساعدك كود المثال التالي على الحصول على النص من عقدة الرسوم الذكية.

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



## **تغيير نوع تخطيط الرسوم الذكية**
لتغيير نوع تخطيط الرسوم الذكية. يرجى اتباع الخطوات أدناه:

- إنشاء حالة من طبقة `Presentation`.
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة الرسوم الذكية BasicBlockList.
- تغيير LayoutType إلى BasicProcess.
- كتابة العرض كملف PPTX.
  في المثال التالي، قمنا بإضافة موصل بين شكلين.

```c#
using (Presentation presentation = new Presentation())
{
    // إضافة الرسوم الذكية BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // تغيير LayoutType إلى BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // حفظ العرض
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **تحقق من خاصية مخفية في الرسوم الذكية**
يرجى ملاحظة أن الطريقة com.aspose.slides.ISmartArtNode.isHidden() تُرجع true إذا كانت هذه العقدة هي عقدة مخفية في نموذج البيانات. للتحقق من الخاصية المخفية لأي عقدة في الرسوم الذكية. يرجى اتباع الخطوات أدناه:

- إنشاء حالة من طبقة `Presentation`.
- إضافة الرسوم الذكية RadialCycle.
- إضافة عقدة في الرسوم الذكية.
- التحقق من خاصية isHidden.
- كتابة العرض كملف PPTX.

في المثال التالي، قمنا بإضافة موصل بين شكلين.

```c#
using (Presentation presentation = new Presentation())
{
    // إضافة الرسوم الذكية BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة في الرسوم الذكية 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // تحقق من خاصية isHidden
    bool hidden = node.IsHidden; // تُرجع true

    if (hidden)
    {
        // تنفيذ بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **احصل على أو اضبط نوع مخطط المنظمة**
تسمح الطرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int) بالحصول على نوع مخطط المنظمة أو تعيينه المرتبط بالعقدة الحالية. للحصول على أو ضبط نوع مخطط المنظمة. يرجى اتباع الخطوات أدناه:

- إنشاء حالة من طبقة `Presentation`.
- إضافة الرسوم الذكية على الشريحة.
- الحصول على نوع مخطط المنظمة أو تعيينه.
- كتابة العرض كملف PPTX.
  في المثال التالي، قمنا بإضافة موصل بين شكلين.

```c#
using (Presentation presentation = new Presentation())
{
    // إضافة الرسوم الذكية BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // احصل على نوع مخطط المنظمة أو اضبطه 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // حفظ العرض
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **إنشاء مخطط تنظيم الصور**
تقدم Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإنشاء مخططات وتنظيم الصور بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء حالة من الطبقة `Presentation`.
1. الحصول على مرجع شريحة بواسطة فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. كتابة العرض المعدل إلى ملف PPTX.

يستخدم الكود التالي لإنشاء مخطط.

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
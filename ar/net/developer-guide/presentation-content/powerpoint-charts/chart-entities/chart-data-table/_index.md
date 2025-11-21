---
title: تخصيص جداول بيانات المخططات في العروض التقديمية في .NET
linktitle: جدول البيانات
type: docs
url: /ar/net/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتخصيص جداول بيانات المخططات في .NET للملفات PPT و PPTX باستخدام Aspose.Slides لزيادة الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

فيما يلي مثال توضيحي.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح أسطورة صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح الأسطورة](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/net/convert-powerpoint-to-html/)/[image](/slides/ar/net/convert-powerpoint-to-png/) المُصدّر يتضمن المخطط مع جدول البيانات الخاص به.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط يتم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني العثور بسرعة على المخططات في ملف ما التي لديها جدول البيانات مفعّل؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) وتحوّل عبر الشرائح لتحديد المخططات التي يتم تفعيلها.
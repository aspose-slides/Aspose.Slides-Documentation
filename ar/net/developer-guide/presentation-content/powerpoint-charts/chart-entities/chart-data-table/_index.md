---
title: جدول بيانات المخطط
type: docs
url: /ar/net/chart-data-table/
keywords: "خصائص الخط, جدول بيانات المخطط, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تعيين خصائص الخط لجدول بيانات المخطط في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط إلى الشريحة.
1. ضبط جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

مثال توضيحي أدناه.
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


## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح وسيلة إيضاح صغيرة بجانب القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح وسيلة الإيضاح](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيبقى جدول البيانات محفوظًا عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/net/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/net/convert-powerpoint-to-html/)/[صورة](/slides/ar/net/convert-powerpoint-to-png/) المصدر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. بالنسبة لأي مخطط تم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي تم تمكين جدول البيانات لها؟**

قم بفحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) وتكرار المرور عبر الشرائح لتحديد المخططات التي تم تمكينه فيها.
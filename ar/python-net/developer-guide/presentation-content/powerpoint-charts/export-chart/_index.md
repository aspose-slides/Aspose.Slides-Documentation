---
title: تصدير مخططات العروض التقديمية باستخدام Python
linktitle: تصدير المخطط
type: docs
weight: 90
url: /ar/python-net/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides للغة Python عبر .NET، مع دعم صيغ PPT و PPTX و ODP، وتبسيط إعداد التقارير في أي سير عمل."
---

## **احصل على صورة المخطط**
توفر Aspose.Slides للغة Python عبر .NET دعمًا لاستخراج صورة مخطط محدد. أدناه مثال توضيحي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **الأسئلة الشائعة**

**هل يمكنني تصدير مخطط كمتجه (SVG) بدلاً من صورة نقطية؟**
نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/).

**كيف يمكنني تحديد الحجم الدقيق للمخطط المصدر بوحدات البكسل؟**
استخدم المتجاوزات الخاصة برسم الصورة التي تسمح لك بتحديد الحجم أو المقياس—المكتبة تدعم تصيير الكائنات بالأبعاد/المقياس المحدد.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية غير صحيحة بعد التصدير؟**
[حمّل الخطوط المطلوبة](/slides/ar/python-net/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) حتى يحافظ تصيير المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**
نعم. يُطبق مُصَيِّر Aspose.Slides تنسيق العرض التقديمي (السمات، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على إمكانيات التصيير/التصدير المتاحة بخلاف صور المخططات؟**
اطلع على قسم التصدير في [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[التوثيق](/slides/ar/python-net/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ar/python-net/convert-powerpoint-to-html/), إلخ) والخيارات المتعلقة بالتصيير.
---
title: تصدير مخططات العروض التقديمية في بايثون عبر جافا
linktitle: تصدير المخطط
type: docs
weight: 90
url: /ar/python-java/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides للبايثون عبر جافا، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تصدير مخطط من عرض تقديمي كصورة. تُظهر هذه المقالة كيفية الحصول على صورة من مخطط وحفظها، وهو مفيد عندما تحتاج إلى إعادة استخدام رسومات المخطط خارج عرض PowerPoint.

بالإضافة إلى سير عمل تصدير الصورة الأساسي، تتناول المقالة أيضًا أسئلة شائعة متعلقة بالتصدير، بما في ذلك حفظ محتوى المخطط كملف SVG، التحكم في حجم الإخراج من خلال خيارات العرض، تحميل الخطوط للحفاظ على مظهر النصوص والوسم، والحفاظ على تنسيق العرض الأصلي مثل السمات والأنماط والتعبئات والتأثيرات أثناء العرض.

## **الحصول على صورة المخطط**
يدعم Aspose.Slides for Python via Java استخراج صورة لمخطط معين. يوضح المثال التالي كيفية القيام بذلك.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني تصدير مخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام طريقة [shape-to-SVG saving method](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**كيف يمكنني تحديد الحجم الدقيق للمخطط المُصدَّر بالبكسل؟**

استخدم الفَرُض الزائدة للعرض التي تتيح لك تحديد الحجم أو المقياس — المكتبة تدعم عرض الكائنات بأبعاد/مقياس محدد.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسم بشكل غير صحيح بعد التصدير؟**

[Load the required fonts](/slides/ar/python-java/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/) لكي يحافظ عرض المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع عارض Aspose.Slides تنسيق العرض (السمات، الأنماط، التعبئات، التأثيرات)، لذلك يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على إمكانيات العرض/التصدير المتاحة بخلاف صور المخططات؟**

انظر إلى [API](https://reference.aspose.com/slides/ar/python-java/aspose.slides/)/[documentation](/slides/ar/python-java/convert-powerpoint/) لأهداف الإخراج ([PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، إلخ) والخيارات المتعلقة بالعرض.
---
title: خصائص الشكل الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords: "خصائص الشكل، خصائص الكاميرا، جهاز الإضاءة، شكل الحواف، إطار النص، نمط النص، قيمة ارتفاع الخط، تنسيق التعبئة للجدول، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "احصل على خصائص الشكل الفعّالة في عروض PowerPoint باستخدام بايثون"
---

في هذا الموضوع، سنناقش الخصائص **الفعّالة** و**المحلية**. عندما نقوم بتعيين قيم مباشرة على هذه المستويات

1. في خصائص القسم على شريحة القسم.
1. في نمط نص شكل النموذج الأولي على شريحة التخطيط أو الشريحة الرئيسية (إذا كان شكل إطار نص القسم يحتوي على واحد).
1. في إعدادات النص العامة للعرض.

فتسمى تلك القيم **محلية**. في أي مستوى، يمكن تعريف القيم **المحلية** أو إغفالها. لكن عندما يأتي الوقت الذي يحتاج فيه التطبيق إلى معرفة كيف ينبغي أن يبدو القسم، فإنه يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **الحصول على خصائص فعّالة للكاميرا**
تسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بالحصول على خصائص فعّالة للكاميرا. لهذا الغرض، تم إضافة فئة **CameraEffectiveData** في Aspose.Slides. تمثل فئة CameraEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص فعّالة للكاميرا. يتم استخدام نسخة من فئة **CameraEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعّالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص فعّالة للكاميرا.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= خصائص الكاميرا الفعّالة =")
	print("النوع: " + str(threeDEffectiveData.camera.camera_type))
	print("زاوية الرؤية: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("تقريب: " + str(threeDEffectiveData.camera.zoom))
```


## **الحصول على خصائص فعّالة لجهاز الإضاءة**
تسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بالحصول على خصائص فعّالة لجهاز الإضاءة. لهذا الغرض، تم إضافة فئة **LightRigEffectiveData** في Aspose.Slides. تمثل فئة LightRigEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص فعّالة لجهاز الإضاءة. يتم استخدام نسخة من فئة **LightRigEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعّالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص فعّالة لجهاز الإضاءة.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= خصائص جهاز الإضاءة الفعّالة =")
	print("النوع: " + str(threeDEffectiveData.light_rig.light_type))
	print("الاتجاه: " + str(threeDEffectiveData.light_rig.direction))
```


## **الحصول على خصائص فعّالة لشكل الحواف**
تسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بالحصول على خصائص فعّالة لشكل الحواف. لهذا الغرض، تم إضافة فئة **ShapeBevelEffectiveData** في Aspose.Slides. تمثل فئة ShapeBevelEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص وجه الشكل الفعالة. يتم استخدام نسخة من فئة **ShapeBevelEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData** والتي تمثل زوج القيم الفعّالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص فعّالة لشكل الحواف.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= خصائص شكل الحواف العلوية الفعّالة =")
	print("النوع: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("العرض: " + str(threeDEffectiveData.bevel_top.width))
	print("الارتفاع: " + str(threeDEffectiveData.bevel_top.height))
```



## **الحصول على خصائص فعّالة لإطار النص**
باستخدام Aspose.Slides لـ بايثون عبر .NET، يمكنك الحصول على خصائص فعّالة لإطار النص. لهذا الغرض، تم إضافة فئة **TextFrameFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق إطار النص الفعالة.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّالة.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("نوع التثبيت: " + str(effectiveTextFrameFormat.anchoring_type))
	print("نوع التكيف التلقائي: " + str(effectiveTextFrameFormat.autofit_type))
	print("نوع النص العمودي: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("الهامش")
	print("   اليسار: " + str(effectiveTextFrameFormat.margin_left))
	print("   الأعلى: " + str(effectiveTextFrameFormat.margin_top))
	print("   اليمين: " + str(effectiveTextFrameFormat.margin_right))
	print("   الأسفل: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **الحصول على خصائص فعّالة لنمط النص**
باستخدام Aspose.Slides لـ بايثون عبر .NET، يمكنك الحصول على خصائص فعّالة لنمط النص. لهذا الغرض، تم إضافة فئة **TextStyleEffectiveData** في Aspose.Slides والتي تحتوي على خصائص نمط النص الفعالة.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص نمط النص الفعالة.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= تنسيق الفقرة الفعالة لمستوى النمط #" + str(i) + " =")

        print("العمق: " + str(effectiveStyleLevel.depth))
        print("الهوامش: " + str(effectiveStyleLevel.indent))
        print("المحاذاة: " + str(effectiveStyleLevel.alignment))
        print("محاذاة الخط: " + str(effectiveStyleLevel.font_alignment))

```


## **الحصول على قيمة ارتفاع الخط الفعّالة**
باستخدام Aspose.Slides لـ بايثون عبر .NET، يمكنك الحصول على خصائص فعّالة لارتفاع الخط. هنا هو الكود الذي يوضح قيمة ارتفاع الخط الفعالة للقسم، والمتغيرة بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من هيكل العرض.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("نص عينة مع الجزء الأول")
    portion1 = slides.Portion(" و الجزء الثاني.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("ارتفاع الخط الفعّال بعد الإنشاء مباشرة:")
    print("الجزء #0: " + str(portion0.portion_format.get_effective().font_height))
    print("الجزء #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط الافتراضي للعروض بالكامل:")
    print("الجزء #0: " + str(portion0.portion_format.get_effective().font_height))
    print("الجزء #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط الافتراضي للفقرة:")
    print("الجزء #0: " + str(portion0.portion_format.get_effective().font_height))
    print("الجزء #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع خط الجزء #0:")
    print("الجزء #0: " + str(portion0.portion_format.get_effective().font_height))
    print("الجزء #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع خط الجزء #1:")
    print("الجزء #0: " + str(portion0.portion_format.get_effective().font_height))
    print("الجزء #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **الحصول على تنسيق التعبئة الفعّال للجدول**
باستخدام Aspose.Slides لـ بايثون عبر .NET، يمكنك الحصول على تنسيق التعبئة الفعّالة لأجزاء منطقية مختلفة من الجدول. لهذا الغرض، تم إضافة واجهة **IFillFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق التعبئة الفعّالة. يرجى ملاحظة أن تنسيق الخلايا دائمًا له أولوية أعلى من تنسيق الصف، والصف له أولوية أعلى من العمود، والعمود له أولوية أعلى من الجدول بالكامل.

لذا فإن خصائص **CellFormatEffectiveData** تُستخدم دائمًا لرسم الجدول. المثال البرمجي التالي يوضح كيفية الحصول على تنسيق التعبئة الفعّالة لأجزاء منطقية مختلفة من الجدول.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```
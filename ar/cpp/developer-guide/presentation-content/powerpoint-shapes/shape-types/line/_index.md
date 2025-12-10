---
title: إضافة أشكال الخط إلى العروض التقديمية بلغة C++
linktitle: خط
type: docs
weight: 50
url: /ar/cpp/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين الخط
- تخصيص الخط
- نمط الشرط
- رأس السهم
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint باستخدام Aspose.Slides للغة C++. اكتشف الخصائص والطرق والأمثلة."
---

## **إنشاء خط عادي**
لإضافة خط عادي بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام طريقة [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) المتاحة من قبل كائن Shapes.
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المرفق أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **إنشاء خط على شكل سهم**
تتيح Aspose.Slides for C++ للمطورين أيضًا تكوين بعض خصائص الخط لجعله أكثر جاذبية. لنحاول تكوين بعض خصائص الخط لجعله يشبه السهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثيل من [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape المتاحة من كائن Shapes.
- تعيين نمط الخط إلى أحد الأنماط المتوفرة من Aspose.Slides for C++.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) للخط إلى أحد الأنماط المتوفرة من Aspose.Slides for C++.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/) و​​الطول لنقطة البداية للخط.
- تعيين نمط رأس السهم والطول لنقطة النهاية للخط.
- حفظ العرض التقديمي المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتقط" الأشكال؟**

لا. لا يتحول الخط العادي (‏[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) و[APIs المقابلة](/slides/ar/cpp/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من القالب وكان من الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعالة](/slides/ar/cpp/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تحسب بالفعل الميراث وأنماط القالب.

**هل يمكنني قفل الخط لمنع التحرير (النقل، تغيير الحجم)؟**

نعم. توفر Shapes كائنات [lock](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/) التي تسمح لك [بمنع عمليات التحرير](/slides/ar/cpp/applying-protection-to-presentation/).
---
title: خط
type: docs
weight: 50
url: /cpp/Line/
---

## **إنشاء خط بسيط**
لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [فئة Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة شكل تلقائي من نوع خط باستخدام [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) الذي تعرضه كائنات أشكال.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **إنشاء خط على شكل سهم**
تسمح Aspose.Slides لـ C++ أيضًا للمطورين بتكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. دعنا نحاول تكوين بعض خصائص خط لجعله يبدو مثل سهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثيل من [فئة Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة شكل تلقائي من نوع خط باستخدام طريقة AddAutoShape التي تعرضها كائنات أشكال.
- تعيين نمط الخط إلى أحد الأنماط المقدمة من Aspose.Slides لـ C++.
- تعيين عرض الخط.
- تعيين [نمط الخط المتقطع](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المقدمة من Aspose.Slides لـ C++.
- تعيين [نمط رأس السهم](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) وطول نقطة بداية الخط.
- تعيين نمط رأس السهم وطول نقطة نهاية الخط.
- كتابة العرض التقديمي المعدل كملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}
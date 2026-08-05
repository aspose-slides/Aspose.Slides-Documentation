---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام C++
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/cpp/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides للغة C++، مع دعم ملفات PPT و PPTX—قم بتحسين عروضك التقديمية اليوم."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص مخطط ثلاثي الأبعاد في Aspose.Slides عن طريق تكوين إعدادات `Rotation3D` مثل `RotationX` و `RotationY` و `DepthPercents` و `RightAngleAxes`. تستعرض عملية إنشاء عرض تقديمي، إضافة مخطط ثلاثي الأبعاد ببيانات افتراضية، تطبيق إعدادات العرض الثلاثي المطلوبة، وحفظ العرض التقديمي المعدل كملف PPTX.

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. ستساعدك المقالة التالية في كيفية ضبط خصائص مختلفة مثل دوران X و Y، **DepthPercents** وغيرها. يطبق الشيفرة النموذجية إعداد الخصائص المذكورة أعلاه.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. تعيين خصائص Rotation3D.
1. حفظ العرض التقديمي المعدل في ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides إصدارات ثلاثية الأبعاد من مخططات الأعمدة، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية ذات الصلة التي يتم كشفها عبر تعداد [ChartType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكن الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/getimage/) أو [render the entire slide](/slides/ar/cpp/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو ترغب في دمج المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد الرسومات. للحصول على أفضل النتائج، احرص على تقليل التأثيرات الثلاثية إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومناطق الرسم، وحدّ عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالتصيير إلى مخرج بالحجم المناسب (الدقة والأبعاد) ليتوافق مع شاشة العرض أو متطلبات الطباعة المستهدفة.
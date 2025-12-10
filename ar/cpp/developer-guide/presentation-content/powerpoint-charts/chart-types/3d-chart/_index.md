---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام С++
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/cpp/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides للـ С++، مع دعم ملفات PPT و PPTX—عزّز عروضك التقديمية اليوم."
---

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك المقال التالي على كيفية تعيين خصائص مختلفة مثل دوران X و Y ، **DepthPercents** وغيرها. يطبق الكود النموذجي تعيين الخصائص المذكورة أعلاه.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات الثلاثية الأبعاد من مخططات الأعمدة، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، إلى جانب الأنواع الثلاثية ذات الصلة المعروضة من خلال تعداد [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) في مرجع واجهة البرمجة للنسخة المثبتة لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) أو [render the entire slide](/slides/ar/cpp/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

تعتمد الأداء على حجم البيانات وتعقيد التصور البصري. للحصول على أفضل النتائج، احرص على تقليل تأثيرات 3D إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومنطقة الرسم، وقم بتقليل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالعرض بتحديد حجم إخراج مناسب (الدقة والأبعاد) ليتطابق مع شاشة العرض أو متطلبات الطباعة.
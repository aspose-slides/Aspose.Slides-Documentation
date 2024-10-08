---
title: خصائص الشكل الفعالة
type: docs
weight: 50
url: /ar/cpp/shape-effective-properties/
---

في هذا الموضوع، سنناقش **الخصائص الفعالة** و **المحلية**. عندما نقوم بتعيين القيم مباشرة على هذه المستويات

1. في خصائص الجزء على شريحة الجزء.
1. في نمط نص الشكل النموذجي على الشريحة الرئيسية أو الشريحة الأساسية (إذا كان لشكل إطار نص الجزء شكل).
1. في إعدادات النص العالمية الخاصة بالعروض التقديمية.

فإن تلك القيم تُسمى **قيم محلية**. في أي مستوى، يمكن تعريف أو إغفال **القيم المحلية**. لكن في النهاية، عندما يتعين على التطبيق معرفة كيف يجب أن يبدو الجزء، فإنه يستخدم **القيم الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **GetEffective()** من التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعالة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **الحصول على الخصائص الفعالة للكاميرا**
تتيح Aspose.Slides لـ C++ للمطورين الحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، تم إضافة **CameraEffectiveData** في Aspose.Slides. تمثل فئة CameraEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم استخدام قيمة من فئة **CameraEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، وهي زوج من القيم الفعالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعالة للكاميرا.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **الحصول على الخصائص الفعالة لجهاز الإضاءة**
تتيح Aspose.Slides لـ C++ للمطورين الحصول على الخصائص الفعالة لجهاز الإضاءة. لهذا الغرض، تم إضافة **LightRigEffectiveData** في Aspose.Slides. تمثل فئة LightRigEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعالة. يتم استخدام قيمة من فئة **LightRigEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، وهي زوج من القيم الفعالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعالة لجهاز الإضاءة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **الحصول على الخصائص الفعالة بشكل محدب**
تتيح Aspose.Slides لـ C++ للمطورين الحصول على الخصائص الفعالة بشكل محدب. لهذا الغرض، تم إضافة **ShapeBevelEffectiveData** في Aspose.Slides. تمثل فئة ShapeBevelEffectiveData كائنًا غير قابل للتغيير يحتوي على خصائص وجه الشكل الفعالة. يتم استخدام قيمة من فئة **ShapeBevelEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، وهي زوج من القيم الفعالة لفئة ThreeDFormat.

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعالة بشكل محدب.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **الحصول على الخصائص الفعالة لإطار النص**
باستخدام Aspose.Slides لـ C++، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، تم إضافة **TextFrameFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق إطار النص الفعالة.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعالة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **الحصول على الخصائص الفعالة لنمط النص**
باستخدام Aspose.Slides لـ C++، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، تم إضافة **TextStyleEffectiveData** في Aspose.Slides والتي تحتوي على خصائص نمط النص الفعالة.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص نمط النص الفعالة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **الحصول على قيمة ارتفاع الخط الفعالة**
باستخدام Aspose.Slides لـ C++، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا هو الكود الذي يوضح تغيير القيمة الفعالة لارتفاع الخط للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات هيكل العروض التقديمية المختلفة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **الحصول على تنسيق التعبئة الفعالة للجدول**
باستخدام Aspose.Slides لـ C++، يمكنك الحصول على تنسيق تعبئة فعالة لأجزاء منطق الجدول المختلفة. لهذا الغرض، تم إضافة واجهة **IFillFormatEffectiveData** في Aspose.Slides والتي تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة أن تنسيق الخلية دائمًا له أولوية أعلى من تنسيق الصف، والصف له أولوية أعلى من العمود والعمود أعلى من الجدول بالكامل.

لذا، فإن خصائص **CellFormatEffectiveData** تُستخدم دائمًا لرسم الجدول. المثال البرمجي التالي يوضح كيفية الحصول على تنسيق التعبئة الفعالة لأجزاء منطق الجدول المختلفة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}
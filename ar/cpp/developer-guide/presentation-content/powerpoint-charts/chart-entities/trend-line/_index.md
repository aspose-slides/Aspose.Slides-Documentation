---
title: إضافة خطوط الاتجاه إلى مخططات العرض التقديمي في С++
linktitle: خط الاتجاه
type: docs
url: /ar/cpp/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسّي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "أضف خطوط الاتجاه وخصّصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للغة С++ — دليل عملي لجذب جمهورك."
---

## **إضافة خط اتجاه**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة وفقًا لرقم الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وإحدى الأنواع المطلوبة (هذا المثال يستخدم ChartType.ClusteredColumn).
4. إضافة خط الاتجاه الأسِّي للسلسلة 1 في المخطط.
5. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
6. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
7. إضافة خط اتجاه المتوسط المتحرك للسلسلة 2 في المخطط.
8. إضافة خط اتجاه كثير حدود للسلسلة 3 في المخطط.
9. إضافة خط اتجاه أسّي للسلسلة 3 في المخطط.
10. كتابة العرض التقديمي المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **إضافة خط مخصص**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
- إنشاء مخطط جديد باستخدام طريقة AddChart التي يوفرها الكائن Shapes
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape التي يوفره الكائن Shapes
- تعيين اللون لخطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **الأسئلة الشائعة**

**ماذا يعني 'forward' و 'backward' لخط الاتجاه؟**

إنهما طول خط الاتجاه الممدود إلى الأمام/إلى الخلف: للمخططات النقطية (XY) — بوحدات المحور؛ للمخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحافظ على خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

Yes. Aspose.Slides converts presentations to [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/) and renders charts to images; trendlines, as part of the chart, are preserved during these operations. A method is also available to [تصدير صورة للمخطط](/slides/ar/cpp/create-shape-thumbnails/) itself.
---
title: تخصيص وسيلة إيضاح المخطط في العروض التقديمية باستخدام С++
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/cpp/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع وسيلة الإيضاح
- حجم الخط
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "قم بتخصيص وسائط إيضاح المخطط باستخدام Aspose.Slides للـ С++ لتحسين عروض PowerPoint التقديمية من خلال تنسيق مخصص لوسائل الإيضاح."
---

## **Legend Positioning**
لتعيين خصائص وسيلة الإيضاح. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- تعيين خصائص وسيلة الإيضاح.
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بتعيين الموقع والحجم لوسيلة إيضاح المخطط.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **Set the Font Size of a Legend**
يسمح Aspose.Slides للـ C++ للمطورين بتعيين حجم الخط لوسيلة الإيضاح. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة Presentation.
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **Set the Font Size of an Individual Legend**
يسمح Aspose.Slides للـ C++ للمطورين بتعيين حجم الخط لمدخلات وسيلة الإيضاح الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة Presentation.
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل وسيلة الإيضاح.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **الأسئلة المتكررة**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

نعم. استخدم وضع عدم التراكب ([set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)); في هذه الحالة، سيصغر مساحة الرسم لتستوعب وسيلة الإيضاح.

**Can I make multi-line legend labels?**

نعم. يتم تلقائيًا التفاف التسميات الطويلة عندما تكون المساحة غير كافية؛ وتدعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**How do I make the legend follow the presentation theme’s color scheme?**

لا تقم بتعيين ألوان/ملء/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارثون ذلك من الثيم وسيتم تحديثهم بشكل صحيح عندما يتغير التصميم.
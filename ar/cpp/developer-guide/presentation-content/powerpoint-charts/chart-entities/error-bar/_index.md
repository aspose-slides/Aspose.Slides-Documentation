---
title: شريط الخطأ
type: docs
url: /ar/cpp/error-bar/
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لـ C++ واجهة برمجية بسيطة لإدارة قيم شريط الخطأ. ينطبق الكود التجريبي عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** للسلاسل:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى من المخطط وضبط تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وضبط تنسيق شريط الخطأ Y.
1. ضبط قيم الأشرطة والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **إضافة شريط خطأ مخصص**
توفر Aspose.Slides لـ C++ واجهة برمجية بسيطة لإدارة قيم شريط الخطأ المخصص. ينطبق الكود التجريبي عند تساوي خاصية **IErrorBarsFormat.ValueType** مع **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** للسلاسل:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى من المخطط وضبط تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وضبط تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية للسلسلة وضبط قيم شريط الخطأ لنقطة بيانات فردية.
1. ضبط قيم الأشرطة والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}
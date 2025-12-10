---
title: تخصيص أشرطة الخطأ في مخططات العروض باستخدام C++
linktitle: شريط الخطأ
type: docs
url: /ar/cpp/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides لـ C++ — تحسين تمثيل البيانات في عروض PowerPoint."
---

## **إضافة أشرطة الأخطاء**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء. ينطبق رمز العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. إضافة مخطط فقاعة على الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **إضافة أشرطة أخطاء مخصصة**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء المخصصة. ينطبق رمز العينة عندما تكون خاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. إضافة مخطط فقاعة على الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لنقطة بيانات واحدة في السلسلة.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض المعدل إلى ملف PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **الأسئلة الشائعة**

**ماذا يحدث لأشرطة الأخطاء عند تصدير العرض إلى PDF أو صور؟**

يتم عرضها كجزء من المخطط وتُحافظ عليها أثناء التحويل إلى جانب بقية تنسيق المخطط، بافتراض وجود نسخة أو مُحَرِّك متوافق.

**هل يمكن دمج أشرطة الأخطاء مع العلامات وملصقات البيانات؟**

نعم. أشرطة الأخطاء عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى ضبط التنسيق.

**أين يمكنني العثور على قائمة الخصائص والعدادات (enums) للعمل مع أشرطة الأخطاء في واجهة برمجة التطبيقات؟**

في مرجع واجهة برمجة التطبيقات: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) والعدادات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/).
---
title: تحويل ODP إلى PPTX في C++
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/cpp/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- حفظ ODP كـ PPTX
- تصدير ODP إلى PPTX
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides للغة C++. أمثلة شفرة نظيفة، نصائح دفعات، ونتائج عالية الجودة—لا حاجة إلى PowerPoint."
---

## **تحويل ODP إلى PPTX**

تقدم Aspose.Slides for .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الوصول إلى ODP من خلال مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.
``` cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

// فتح ملف ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// حفظ عرض ODP إلى تنسيق PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي تم بناؤه باستخدام **Aspose.Slides API.** يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. تعمل Aspose.Slides بشكل مستقل ولا تتطلب تطبيقات من طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الاحتفاظ بالشرائح الرئيسية والتخطيطات والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالبنية، بما في ذلك الشرائح الرئيسية والتخطيطات، لذا يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. تدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [العروض التقديمية المحمية](/slides/ar/cpp/password-protected-presentation/) (بما في ذلك ODP) عند تقديم كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
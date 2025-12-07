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
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ C++. أمثلة شفرة نظيفة، نصائح دفعات، ونتائج عالية الجودة—بدون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى PPTX**

توفر Aspose.Slides لـ .NET فئة Presentation التي تمثل ملف عرض تقديمي. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) يمكن الآن أيضًا الوصول إلى ODP عبر المُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.
``` cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

// فتح ملف ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// حفظ عرض ODP إلى تنسيق PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ، الذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تطبيق تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الاحتفاظ بشريحة القالب، التخطيطات، والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالهيكل، بما في ذلك شرائح القالب والتخطيطات، لذا يظل التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، فتح والعمل مع [العروض المحمية](/slides/ar/cpp/password-protected-presentation/) (بما في ذلك ODP) عندما تزود البرنامج بكلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
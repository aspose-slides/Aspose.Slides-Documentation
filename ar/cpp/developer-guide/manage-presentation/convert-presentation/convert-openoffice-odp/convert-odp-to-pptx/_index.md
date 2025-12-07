---
title: تحويل ODP إلى PPTX في C++
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/cpp/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
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
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ C++. أمثلة شفرة نظيفة، نصائح للدفعات، ونتائج عالية الجودة—دون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى PPTX**

تقدم Aspose.Slides for .NET الفئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن للفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) أيضًا الوصول إلى ODP عبر مُنشئ Presentation عند إنشاء الكائن. المثال التالي يوضح كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.
``` cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

// فتح ملف ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// حفظ عرض ODP إلى صيغة PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ، والذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيف يمكن تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ملفات ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية والتخطيطات والأنماط أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحافظ على الهيكل، بما في ذلك الشرائح الرئيسية والتخطيطات، لذا يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [العروض المحمية](/slides/ar/cpp/password-protected-presentation/) (بما في ذلك ODP) عند توفير كلمة المرور، وكذلك تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
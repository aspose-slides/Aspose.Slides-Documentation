---
title: تحويل ODP إلى PPTX باستخدام C++
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
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ C++. أمثلة شفرة نظيفة، نصائح للمعالجة دفعات، ونتائج عالية الجودة—دون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى PPTX**

توفر Aspose.Slides لـ .NET الفئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن للفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) أيضًا الوصول إلى ODP من خلال مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.
``` cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

// فتح ملف ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// حفظ عرض ODP بصيغة PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ، والذي تم بناؤه باستخدام **Aspose.Slides API.** يعرض التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. تعمل Aspose.Slides بشكل مستقل ولا تتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية، التخطيطات، والثيمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحافظ على الهيكل، بما في ذلك الشرائح الرئيسية والتخطيطات، وبالتالي يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. تدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [protected presentations](/slides/ar/cpp/password-protected-presentation/) (بما في ذلك ODP) عندما تقدم كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسبة لخدمات التحويل السحابي أو المستندة إلى REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
---
title: تحويل ODP إلى PPTX في Python
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/python-net/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ Python عبر .NET. أمثلة شفرة نظيفة، نصائح للمعالجة الدفوعة، ونتائج عالية الجودة—دون الحاجة إلى PowerPoint."
---

## **تصدير ODP إلى PPTX**

توفر Aspose.Slides لـ Python عبر .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الوصول إلى ODP عبر مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.
```py
# استيراد Aspose.Slides لـ Python عبر .NET
import aspose.slides as slides

# فتح ملف ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# حفظ عرض ODP إلى تنسيق PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي تم بناءه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتداولة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. تعمل Aspose.Slides بشكل مستقل ولا تتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية، والتصميمات، والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالهيكل، بما في ذلك الشرائح الرئيسية والتصميمات، لذا يظل التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. تدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [العروض المحمية](/slides/ar/python-net/password-protected-presentation/) (بما في ذلك ODP) عندما تزود كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
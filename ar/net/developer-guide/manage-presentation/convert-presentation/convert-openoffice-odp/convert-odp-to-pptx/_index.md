---
title: تحويل ODP إلى PPTX في .NET
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ .NET. أمثلة شفرة C# نظيفة، نصائح دفعات، ونتائج عالية الجودة—بدون الحاجة إلى PowerPoint."
---

## **نظرة عامة**

تشرح هذه المقالة المواضيع التالية.

- [C# تحويل ODP إلى PPTX](#csharp-odp-to-pptx)
- [C# تحويل ODP إلى PowerPoint](#csharp-odp-to-powerpoint)

## **تحويل ODP إلى PPTX**

تقدم Aspose.Slides لـ .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) الوصول إلى ODP عبر منشئ Presentation عند إنشاء الكائن. يظهر المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>الخطوات: تحويل ODP إلى PPTX باستخدام C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>الخطوات: تحويل ODP إلى PowerPoint باستخدام C#</strong></a>
```c#
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// حفظ عرض ODP إلى تنسيق PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ، والذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسة والتخطيطات والسمات أثناء التحويل؟**

نعم. يستخدم المكتبة نموذج كائن عرض تقديمي كامل ويحافظ على الهيكل، بما في ذلك الشرائح الرئيسة والتخطيطات، وبالتالي يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [العروض المحمية](/slides/ar/net/password-protected-presentation/) (بما في ذلك ODP) عندما تزود كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب للخدمات السحابية أو الخدمات المستندة إلى REST للتحويل؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
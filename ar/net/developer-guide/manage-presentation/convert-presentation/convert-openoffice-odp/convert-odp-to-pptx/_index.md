---
title: تحويل ODP إلى PPTX في .NET
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/net/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides for .NET. أمثلة شفرة C# نظيفة، نصائح للمعالجة الدفعاتية، ونتائج عالية الجودة—بدون الحاجة إلى PowerPoint."
---

## **نظرة عامة**

هذه المقالة تشرح المواضيع التالية.

- [تحويل ODP إلى PPTX باستخدام C#](#csharp-odp-to-pptx)
- [تحويل ODP إلى PowerPoint باستخدام C#](#csharp-odp-to-powerpoint)

## **تحويل ODP إلى PPTX**

يقدم Aspose.Slides for .NET فئة Presentation التي تمثل ملف عرض تقديمي. فئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) يمكنها الآن أيضًا الوصول إلى ODP عبر مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>خطوات: تحويل ODP إلى PPTX باستخدام C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>خطوات: تحويل ODP إلى PowerPoint باستخدام C#</strong></a>
```c#
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// حفظ عرض ODP إلى تنسيق PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية والتخطيطات والأنماط أثناء التحويل؟**

نعم. يستخدم المكتبة نموذج كائن عرض تقديمي كامل ويحتفظ بالهيكل، بما في ذلك الشرائح الرئيسية والتخطيطات، بحيث يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides كشف الحماية، وفتح والعمل مع [العروض التقديمية المحمية](/slides/ar/net/password-protected-presentation/) (بما في ذلك ODP) عندما تزود كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخادم الخاص بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
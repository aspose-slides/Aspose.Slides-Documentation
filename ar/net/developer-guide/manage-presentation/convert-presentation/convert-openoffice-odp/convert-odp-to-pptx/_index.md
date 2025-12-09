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
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ .NET. أمثلة نظيفة على كود C#، ونصائح الدفعات، ونتائج عالية الجودة — لا حاجة لـ PowerPoint."
---

## **نظرة عامة**

تشرح هذه المقالة المواضيع التالية.

- [C# تحويل ODP إلى PPTX](#csharp-odp-to-pptx)
- [C# تحويل ODP إلى PowerPoint](#csharp-odp-to-powerpoint)

## **تحويل ODP إلى PPTX**

تقدم Aspose.Slides for .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) الوصول إلى ODP عبر منشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>الخطوات: تحويل ODP إلى PPTX في C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>الخطوات: تحويل ODP إلى PowerPoint في C#</strong></a>
```c#
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// حفظ عرض ODP التقديمي إلى تنسيق PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) المُبنى باستخدام **Aspose.Slides API.** يُظهر التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. Aspose.Slides يعمل بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية، والتخطيطات، والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالهيكل، بما في ذلك الشرائح الرئيسية والتخطيطات، لذا يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. تدعم Aspose.Slides الكشف عن الحماية، وفتح والعمل مع [protected presentations](/slides/ar/net/password-protected-presentation/) (بما في ذلك ODP) عند تقديم كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخادم الخلفي الخاص بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
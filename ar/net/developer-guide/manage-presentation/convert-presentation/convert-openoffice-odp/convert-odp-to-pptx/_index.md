---
title: تحويل ODP إلى PPTX في C#
linktitle: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/net/convert-odp-to-pptx/
keywords: "تحويل عرض OpenOffice التقديمي, ODP, ODP إلى PPTX, C#, Csharp, .NET"
description: "تحويل ODP الخاص بـ OpenOffice إلى عرض تقديمي PowerPoint بصيغة PPTX في C# أو .NET"
---

## **نظرة عامة**

تشرح هذه المقالة المواضيع التالية.

- [C# تحويل ODP إلى PPTX](#csharp-odp-to-pptx)
- [C# تحويل ODP إلى PowerPoint](#csharp-odp-to-powerpoint)

## **تحويل ODP إلى PPTX**

تقدم Aspose.Slides for .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) الوصول إلى ODP عبر مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>الخطوات: تحويل ODP إلى PPTX في C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>الخطوات: تحويل ODP إلى PowerPoint في C#</strong></a>
```c#
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// حفظ عرض ODP إلى صيغة PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **مثال حي**

يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ، والذي تم بناءه باستخدام **Aspose.Slides API**. يُظهر التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بصورة مستقلة ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم حفظ الشرائح الرئيسية والتصاميم والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحافظ على الهيكل، بما في ذلك الشرائح الرئيسية والتصاميم، لذا يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، وفتح العروض التقديمية [protected presentations](/slides/ar/net/password-protected-presentation/) (بما في ذلك ODP) عند تقديم كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.
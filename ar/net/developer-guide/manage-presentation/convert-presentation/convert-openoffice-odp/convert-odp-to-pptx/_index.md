---
title: تحويل ODP إلى PPTX في C#
linktitle: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/net/convert-odp-to-pptx/
keywords: "تحويل عرض OpenOffice، ODP، ODP إلى PPTX، C#، Csharp، .NET"
description: "تحويل ODP من OpenOffice إلى عرض PowerPoint PPTX في C# أو .NET"
---

## نظرة عامة

تتناول هذه المقالة المواضيع التالية.

- [C# تحويل ODP إلى PPTX](#csharp-odp-to-pptx)
- [C# تحويل ODP إلى PowerPoint](#csharp-odp-to-powerpoint)

## تحويل ODP إلى PPTX باستخدام C#

تقدم Aspose.Slides لـ .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) الوصول إلى ODP من خلال مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>خطوات: تحويل ODP إلى PPTX في C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>خطوات: تحويل ODP إلى PowerPoint في C#</strong></a>

```c#
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// حفظ عرض ODP بصيغة PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```



## **مثال مباشر**
يمكنك زيارة [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/) التطبيق عبر الويب، الذي تم بناؤه باستخدام **Aspose.Slides API.** يعرض التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.
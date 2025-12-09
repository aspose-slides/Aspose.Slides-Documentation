---
title: قيود API
type: docs
weight: 320
url: /ar/net/api-limitations/
keywords:
- قيود API
- صيغة التصدير
- تطبيق
- منتج
- خصائص المستند
- بيانات وصفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for .NET: تصدر عمليات التصدير بيانات وصفية ثابتة للتطبيق/المنتج في ملفات PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكامل دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for .NET يتم كتابة بعض البيانات الوصفية التقنية داخل الملف. غالبًا ما يثار سؤال حول حقلين:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرضًا تقديميًا بصيغة **PPTX**. في Aspose.Slides for .NET تكون هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا قمت بتعيين [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصدير **PDF** تُستخدم البيانات الوصفية حقلي **Creator** و **Producer**. مع Aspose.Slides for .NET يكون كلا الحقلين ثابتين ويعكسان المكتبة وإصدارها.

**What’s restricted**

لا يمكنك تجاوز هذه الحقول عبر API للأنساق المذكورة أعلاه. بالنسبة لـ **PPTX**، تُكتب خاصية Application كـ "Aspose.Slides for .NET". بالنسبة لـ **PDF**، تُكتب خاصيتي Creator و Producer كـ "Aspose.Slides for .NET x.x.x". هذا السلوك مُصمم بهذه الطريقة ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة لـ [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

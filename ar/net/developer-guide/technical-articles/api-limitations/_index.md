---
title: قيود بيانات التعريف في المخرجات
type: docs
weight: 320
url: /ar/net/api-limitations/
keywords:
- قيود API
- تنسيق التصدير
- تطبيق
- منتج
- خصائص المستند
- بيانات تعريف
- مولد
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "يقوم Aspose.Slides for .NET بكتابة بيانات تعريف ثابتة للتطبيق والمنشئ والمنتج في ملفات PPTX وPDF وODP المحفوظة، بغض النظر عن اسم التطبيق الذي تحدده."
---
## **نظرة عامة**

عند إنشاء العروض التقديمية أو تصديرها باستخدام Aspose.Slides، يتم كتابة بعض البيانات الوصفية التقنية إلى ملف الإخراج. توضح هذه المقالة القيود المتعلقة بحقول البيانات الوصفية `Application` و`Creator` و`Producer` وgenerator في ملفات PPTX وPDF وODP.

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for .NET، يتم كتابة بعض البيانات الوصفية التقنية إلى الملف. غالبًا ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرض **PPTX**. في Aspose.Slides for .NET، تكون هذه القيمة ثابتة وتظهر اسم المكتبة بدلاً من اسم تطبيقك، حتى إذا قمت بتعيين [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ar/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقول **Creator** و**Producer**. مع Aspose.Slides for .NET، يكون كلا هذين الحقلين ثابتًا ويعكسان المكتبة وإصدارها.

**ما هو مقيد**

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة لـ **PPTX**، يتم كتابة خاصية Application كـ "Aspose.Slides for .NET". بالنسبة لـ **PDF**، يتم كتابة خاصيتي Creator وProducer كـ "Aspose.Slides for .NET" متبوعًا بإصدار المكتبة. بالنسبة لـ **ODP**، يتم كتابة حقل generator كـ "Aspose.Slides for .NET" متبوعًا بإصدار المكتبة. هذا السلوك مصمم بشكل افتراضي ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة لـ [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ar/net/aspose.slides/documentproperties/nameofapplication/).

هذا القيد لا ينطبق على ملفات **PPT**: في ملف PPT، يتم حفظ اسم التطبيق الذي قمت بتعيينه في [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ar/net/aspose.slides/documentproperties/nameofapplication/).
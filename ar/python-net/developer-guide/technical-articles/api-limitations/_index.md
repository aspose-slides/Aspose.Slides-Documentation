---
title: قيود API
type: docs
weight: 210
url: /ar/python-net/api-limitations/
keywords:
- قيود API
- صيغة التصدير
- التطبيق
- المنتج
- خصائص المستند
- البيانات التعريفية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for Python: تصادرات تُعيّن بيانات تعريفية ثابتة للتطبيق/المنتج في ملفات PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء عروض تقديمية أو تصديرها باستخدام Aspose.Slides for Python via .NET، يتم كتابة بعض البيانات الوصفية التقنية داخل الملف. غالبًا ما يثير حقلان تساؤلات:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عَرْض **PPTX**. في Aspose.Slides for Python via .NET، هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا قمت بتعيين [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و **Producer**. مع Aspose.Slides for Python via .NET، كلا الحقلين ثابتان ويعكسان المكتبة وإصدارها.

**ما هو مقيد**

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة إلى **PPTX**، تُكتب خاصية Application كـ "Aspose.Slides for Python via .NET". بالنسبة إلى **PDF**، تُكتب خصائص Creator و Producer كـ "Aspose.Slides for Python via .NET x.x.x". هذا السلوك مصمم بهذه الطريقة وينطبق بغض النظر عن طريقة تحميل أو حفظ الملف، بغض النظر عن القيم المعينة لـ [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).
---
title: قيود API
type: docs
weight: 320
url: /ar/cpp/api-limitations/
keywords:
- قيود API
- صيغة التصدير
- التطبيق
- المنتج
- خصائص المستند
- البيانات الوصفية
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for C++: تصدير يحدد بيانات وصفية ثابتة للتطبيق/المنتج في ملفات PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for C++، يتم كتابة بعض البيانات الوصفية التقنية في الملف. غالبًا ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرض **PPTX**. في Aspose.Slides for C++، هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصدير **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و**Producer**. مع Aspose.Slides for C++، كلاهما ثابت ويعكس المكتبة وإصدارها.

**ما هو مقيد**

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة لـ **PPTX**، تُكتب خاصية Application كـ "Aspose.Slides for C++". بالنسبة لـ **PDF**، تُكتب خصائص Creator وProducer كـ "Aspose.Slides for C++ x.x.x". هذا السلوك جزء من التصميم ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة باستخدام [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).
---
title: قيود API
type: docs
weight: 320
url: /ar/nodejs-java/api-limitations/
keywords:
- قيود API
- تنسيق التصدير
- التطبيق
- المنتج
- خصائص المستند
- البيانات الوصفية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for Node.js: تصدر تعيين بيانات وصفية ثابتة للتطبيق/المنتج في PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for Node.js via Java، يتم كتابة بعض البيانات الفوقية التقنية إلى الملف. غالبًا ما يثير حقْلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرض **PPTX**. في Aspose.Slides for Node.js via Java، هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الفوقية حقول **Creator** و**Producer**. مع Aspose.Slides for Node.js via Java، كلا هذين الحقلين ثابتان ويعكسان المكتبة وإصدارها.

**What’s restricted** لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة ل**PPTX**، تُكتب خاصية Application كـ "Aspose.Slides for Node.js via Java". بالنسبة ل**PDF**، تُكتب خاصية Creator وProducer كـ "Aspose.Slides for Node.js via Java x.x.x." هذا السلوك مصمم بهذا الشكل ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).
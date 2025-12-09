---
title: قيود API
type: docs
weight: 320
url: /ar/php-java/api-limitations/
keywords:
- قيود API
- تنسيق التصدير
- التطبيق
- المنتج
- خصائص المستند
- البيانات الوصفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for PHP: تصديراتها تحدد بيانات وصفية ثابتة لتطبيق/منتج في ملفات PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for PHP via Java، يتم كتابة بعض البيانات الوصفية التقنية في الملف. عادة ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرض **PPTX**. في Aspose.Slides for PHP via Java، هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و**Producer**. مع Aspose.Slides for PHP via Java، كلاهما ثابتان ويعكسان المكتبة وإصدارها.

**What’s restricted** ما هو مقيد

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة لـ **PPTX**، يتم كتابة خاصية Application كـ "Aspose.Slides for PHP via Java". بالنسبة لـ **PDF**، يتم كتابة خصائص Creator وProducer كـ "Aspose.Slides for PHP via Java x.x.x." هذا السلوك مصمم مسبقًا وينطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة باستخدام [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).
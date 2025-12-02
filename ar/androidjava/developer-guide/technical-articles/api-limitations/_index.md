---
title: قيود واجهة برمجة التطبيقات
type: docs
weight: 320
url: /ar/androidjava/api-limitations/
keywords:
- قيود واجهة برمجة التطبيقات
- تنسيق التصدير
- التطبيق
- المنتج
- خصائص المستند
- بيانات التعريف
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for Android: تصدر عمليات التصدير بيانات تعريف Application/Producer ثابتة في صيغ PPT و PPTX و ODP و PDF — مما يساعدك على التخطيط للتكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء عروض تقديمية أو تصديرها باستخدام Aspose.Slides for Android via Java، يتم كتابة بعض البيانات الوصفية التقنية داخل الملف. غالبًا ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرضًا تقديميًا بصيغة **PPTX**. في Aspose.Slides for Android via Java، تكون هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقول **Creator** و**Producer**. مع Aspose.Slides for Android via Java، كلا الحقلين ثابتان ويعكسان المكتبة وإصدارها.

**ما هو مقيد**

لا يمكنك تجاوز هذه الحقول عبر API للصيغات المذكورة أعلاه. بالنسبة لـ **PPTX**، تُكتب خاصية Application كـ "Aspose.Slides for Android via Java". بالنسبة لـ **PDF**، تُكتب خصائص Creator وProducer كـ "Aspose.Slides for Android via Java x.x.x." هذا السلوك مصمم مسبقًا وينطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وأيًا كان القيم المعطاة باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).
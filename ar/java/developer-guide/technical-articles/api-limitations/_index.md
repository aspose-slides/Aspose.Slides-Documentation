---
title: قيود API
type: docs
weight: 320
url: /ar/java/api-limitations/
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
- Java
- Aspose.Slides
description: "اعرف حدود Aspose.Slides for Java: تصدير يضع بيانات وصفية ثابتة للتطبيق/المنتج في PPT و PPTX و ODP و PDF—مما يساعدك على تخطيط التكاملات دون مفاجآت."
---

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for Java، يتم كتابة بعض البيانات الوصفية التقنية في الملف. غالبًا ما يثير حقلان أسئلة:

**التطبيق** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرض **PPTX**. في Aspose.Slides for Java، هذه القيمة ثابتة وتظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**المنتج** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و **Producer**. مع Aspose.Slides for Java، كلا الحقلين ثابتان ويعكسان المكتبة وإصدارها.

**ما الممنوع**

لا يمكنك تجاوز هذه الحقول عبر الـ API للأنواع المذكورة أعلاه. بالنسبة لـ **PPTX**، يتم كتابة خاصية التطبيق كـ "Aspose.Slides for Java". بالنسبة لـ **PDF**، تُكتب خصائص Creator و Producer كـ "Aspose.Slides for Java x.x.x." هذا السلوك مُصمم مسبقًا ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينّة باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).
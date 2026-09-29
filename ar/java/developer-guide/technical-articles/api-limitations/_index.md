---
title: حدود بيانات التعريف الناتجة
type: docs
weight: 320
url: /ar/java/api-limitations/
keywords:
- قيود واجهة برمجة التطبيقات
- تنسيق التصدير
- التطبيق
- المنتج
- خصائص المستند
- بيانات تعريف
- المولد
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "يقوم Aspose.Slides for Java بكتابة بيانات تعريف ثابتة للتطبيق، والمنشئ، والمنتج في ملفات PPTX وPDF وODP المحفوظة، بغض النظر عن اسم التطبيق الذي تحدده."
---
## **Overview**

عند إنشاء العروض التقديمية أو تصديرها باستخدام Aspose.Slides، يتم كتابة بعض البيانات الوصفية التقنية إلى ملف الإخراج. يوضح هذا المقال القيود المتعلقة بحقول البيانات الوصفية `Application` و`Creator` و`Producer` و`generator` في ملفات PPTX وPDF وODP.

## **Application and Producer**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for Java، يتم كتابة بعض البيانات الوصفية التقنية في الملف. غالبًا ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرضًا تقديميًا بصيغة **PPTX**. في Aspose.Slides for Java، هذه القيمة ثابتة وتظهر اسم المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصدير **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و**Producer**. مع Aspose.Slides for Java، كلا الحقلين ثابتان ويعكسان المكتبة وإصدارها.

**What’s restricted**

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة إلى **PPTX**، يتم كتابة خاصية Application كـ "Aspose.Slides for Java". بالنسبة إلى **PDF**، يتم كتابة خاصيتي Creator وProducer كـ "Aspose.Slides for Java" متبوعًا بإصدار المكتبة. بالنسبة إلى **ODP**، يتم كتابة حقل generator كـ "Aspose.Slides for Java" متبوعًا بإصدار المكتبة. هذا السلوك مقصود ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، أو القيم التي تم تعيينها باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

هذا القيد لا ينطبق على ملفات **PPT**: ففي ملف PPT، يتم حفظ اسم التطبيق الذي تحدده باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).
---
title: قيود API
type: docs
weight: 320
url: /ar/python-java/api-limitations/
keywords:
- قيود API
- تنسيق التصدير
- تطبيق
- منتج
- خصائص المستند
- بيانات وصفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على قيود Aspose.Slides for Python via Java: بيانات وصفية ثابتة للحقول Application و Creator و Producer في ملفات PPTX و PDF."
---
## **نظرة عامة**

عند إنشاء العروض التقديمية أو تصديرها باستخدام Aspose.Slides، يتم كتابة بعض البيانات الوصفية التقنية إلى ملف الإخراج. توضح هذه المقالة القيود المتعلقة بالحقول الوصفية `Application` و `Creator` و `Producer` في ملفات PPTX و PDF.

## **التطبيق والمنتج**

عند إنشاء أو تصدير العروض التقديمية باستخدام Aspose.Slides for Python via Java، يتم كتابة بعض البيانات الوصفية التقنية في الملف. غالبًا ما يثير حقلان أسئلة:

**Application** يحدد البرنامج الذي أنشأ أو حفظ آخر مرة عرضًا تقديميًا **PPTX**. في Aspose.Slides for Python via Java، تكون هذه القيمة ثابتة وتُظهر بائع المكتبة بدلاً من اسم تطبيقك، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** يحدد محرك العرض الذي أنشأ الملف النهائي أثناء التصدير. في تصديرات **PDF**، تستخدم البيانات الوصفية حقلي **Creator** و **Producer**. مع Aspose.Slides for Python via Java، كلاهما ثابتان ويعكسان المكتبة وإصدارها.

**ما هو مقيد**

لا يمكنك تجاوز هذه الحقول عبر API للتنسيقات المذكورة أعلاه. بالنسبة إلى **PPTX**، يتم كتابة خاصية Application كـ "Aspose.Slides for Java". بالنسبة إلى **PDF**، يتم كتابة خصائص Creator و Producer كـ "Aspose.Slides for Java x.x.x." هذا السلوك مقصود ويطبق بغض النظر عن طريقة تحميل أو حفظ الملف، وبغض النظر عن القيم المعينة باستخدام [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **الأسئلة المتكررة**

**هل يمكنني استبدال قيمة Application في ملف PPTX باسم تطبيقي؟**

لا. القيمة ثابتة، حتى إذا استخدمت [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#setnameofapplication).

**هل يمكنني تجاوز حقلي Creator و Producer في تصديرات PDF؟**

لا. كلا الحقلين ثابتان ويعكسان المكتبة وإصدارها، بغض النظر عن طريقة تحميل أو حفظ العرض التقديمي.
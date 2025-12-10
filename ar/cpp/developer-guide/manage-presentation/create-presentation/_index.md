---
title: إنشاء عروض تقديمية بلغة C++
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/cpp/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "إنشاء عروض تقديمية بلغة C++ باستخدام Aspose.Slides — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **إنشاء عرض تقديمي PowerPoint**
لإضافة خط بسيط عادي إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape الموجودة في كائن Shapes.
4. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المرفق أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/cpp/save-presentation/)، وتصدير إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ar/cpp/convert-powerpoint-to-html/), [SVG](/slides/ar/cpp/convert-powerpoint-to-png/), و[images](/slides/ar/cpp/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب وحفظه بالتنسيق المطلوب؛ الصيغ مثل POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/cpp/supported-file-formats/).

**كيف أتحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [slide size](/slides/ar/cpp/slide-size/) (بما في ذلك الإعدادات المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيفية مقياس المحتوى.

**بأي وحدات يتم قياس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [BLOB management strategies](/slides/ar/cpp/manage-blob/)، قلل التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات التي تُحفظ بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس مثال [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) من [multiple threads](/slides/ar/cpp/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة التجربة والقيود؟**

[Apply a license](/slides/ar/cpp/licensing/) مرة واحدة لكل عملية. يجب بقاء ملف ترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع PPTX الذي أنشئه رقميًا؟**

نعم. [Digital signatures](/slides/ar/cpp/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل يتم دعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [create/edit VBA projects](/slides/ar/cpp/presentation-via-vba/) وحفظ ملفات ممكّنة للماكرو مثل PPTM/PPSM.
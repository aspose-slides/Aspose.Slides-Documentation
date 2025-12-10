---
title: إدارة النص العلوي والنص السفلي في العروض التقديمية باستخدام C++
linktitle: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/cpp/superscript-and-subscript/
keywords:
- نص علوي
- نص سفلي
- إضافة نص علوي
- إضافة نص سفلي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إتقان النص العلوي والنص السفلي في Aspose.Slides للغة C++ وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **إدارة النص العلوي والنص السفلي**
يمكنك إضافة نص علوي أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو سفلي في إطار نص Aspose.Slides يجب استخدام خاصية **Escapement** في فئة PortionFormat.

تُعيد هذه الخاصية أو تُعيّن النص العلوي أو السفلي (القيمة من -100% (سفلي) إلى 100% (علوي)). على سبيل المثال :

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة IAutoShape من النوع Rectangle إلى الشريحة.
- الوصول إلى ITextFrame المرتبط بـ IAutoShape.
- مسح الفقرات الحالية.
- إنشاء كائن فقرة جديد للاحتفاظ بالنص العلوي وإضافته إلى مجموعة IParagraphs في ITextFrame.
- إنشاء كائن Portion جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص علوي. (0 يعني عدم وجود نص علوي)
- تعيين نص للـ Portion ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديد للاحتفاظ بالنص السفلي وإضافته إلى مجموعة IParagraphs في ITextFrame.
- إنشاء كائن Portion جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 يعني عدم وجود نص سفلي)
- تعيين نص للـ Portion ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **الأسئلة الشائعة**

**هل يتم الحفاظ على النص العلوي والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، يحتفظ Aspose.Slides بشكل صحيح بتنسيق النص العلوي والسفلي عند تصدير العروض التقديمية إلى PDF أو PPT/PPTX أو الصور أو أي صيغ مدعومة أخرى. يبقى التنسيق المتخصص سليمًا في جميع ملفات الإخراج.

**هل يمكن دمج النص العلوي أو السفلي مع أنماط تنسيق أخرى مثل العريض أو المائل؟**

نعم، يسمح Aspose.Slides بخلط أنماط النص المختلفة داخل نفس Portion. يمكنك تمكين العريض أو المائل أو التسطير وتطبيق النص العلوي أو السفلي في الوقت نفسه عن طريق ضبط الخصائص المقابلة في [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/).

**هل يعمل تنسيق النص العلوي والسفلي للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، يدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) بطريقة مماثلة.
---
title: تحويل PPTX إلى PPT في Python
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/python-net/convert-pptx-to-ppt/
keywords:
- PPTX إلى PPT
- تحويل PPTX إلى PPT
- تحويل PowerPoint
- تحويل العرض التقديمي
- Python
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides for Python عبر .NET — تأكد من توافق سلس مع تنسيقات PowerPoint مع الحفاظ على تخطيط العرض التقديمي وجودته."
---

## **نظرة عامة**

Aspose.Slides for Python يتيح لك تحويل عروض PPTX الحديثة إلى تنسيق PPT القديم بالكامل عبر الكود. افتح ملف PPTX وصدره كـ PPT مع الحفاظ على محتوى العرض وتخطيطه، مما يجعل النتيجة متوافقة مع إصدارات PowerPoint القديمة. يمكن لنفس سير العمل إنتاج مخرجات أخرى—مثل PDF و XPS و ODP و HTML أو الصور—وبالتالي يندمج بسلاسة في السكريبتات، أنابيب CI، والمعالجة الدفعية.

## **تحويل PPTX إلى PPT**

لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). المثال التالي بلغة Python يحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
presentation = slides.Presentation("presentation.pptx")

# حفظ العرض التقديمي كملف PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ إلى تنسيق PPT القديم (97–2003)؟**

ليس دائمًا. تنسيق PPT يفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المختارة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح محددة، أنشئ عرضًا جديدًا يحتوي على هذه الشرائح فقط واحفظه كـ PPT؛ أو استخدم خدمة/API تدعم معلمات تحويل حسب الشريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك الكشف عما إذا كان الملف محميًا، فتحه باستخدام كلمة المرور، وكذلك [configure protection/encryption settings](/slides/ar/python-net/password-protected-presentation/) للـ PPT المحفوظ.

**انظر أيضًا:**
- [تحويل PPT و PPTX إلى PDF في Python | خيارات متقدمة](/slides/ar/python-net/convert-powerpoint-to-pdf/)
- [تحويل عروض PowerPoint إلى XPS في Python](/slides/ar/python-net/convert-powerpoint-to-xps/)
- [تحويل عروض PowerPoint إلى HTML في Python](/slides/ar/python-net/convert-powerpoint-to-html/)
- [تحويل شرائح PowerPoint إلى PNG في Python](/slides/ar/python-net/convert-powerpoint-to-png/)
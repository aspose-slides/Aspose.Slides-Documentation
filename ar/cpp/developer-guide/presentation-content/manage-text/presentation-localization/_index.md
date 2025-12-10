---
title: أتمتة توطين العروض التقديمية في C++
linktitle: توطين العرض التقديمي
type: docs
weight: 100
url: /ar/cpp/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- معرف اللغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "أتمتة توطين شرائح PowerPoint وOpenDocument في C++ باستخدام Aspose.Slides، مع أمثلة عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة للعرض التقديمي ونص الشكل**
- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع مستطيل إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- ضبط Language Id للنص.
- حفظ العرض التقديمي كملف PPTX.

يتم توضيح تنفيذ الخطوات أعلاه أدناه في مثال.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **الأسئلة الشائعة**
**هل يُؤدي Language ID إلى ترجمة النص تلقائيًا؟**

No. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) في Aspose.Slides يخزن اللغة لتدقيق الإملاء وإثبات القواعد، لكنه لا يترجم أو يغير محتوى النص. إنها بيانات وصفية يفهمها PowerPoint لأغراض التدقيق.

**هل يؤثر Language ID على التجزيء إلى مقاطع وفواصل الأسطر أثناء العرض؟**

في Aspose.Slides، يُستخدم [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) للتدقيق. تعتمد جودة التجزيء إلى مقاطع ولف السطر أساسًا على توفر [الخطوط المناسبة](/slides/ar/cpp/powerpoint-fonts/) وإعدادات التخطيط/فواصل الأسطر لنظام الكتابة. لضمان العرض الصحيح، احرص على إتاحة الخطوط المطلوبة، وضبط [قواعد استبدال الخطوط](/slides/ar/cpp/font-substitution/)، أو [دمج الخطوط](/slides/ar/cpp/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

Yes. يُطبق [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) على مستوى جزء النص، لذا يمكن للفقرة الواحدة أن تحتوي على لغات متعددة مع إعدادات تدقيق متميزة.
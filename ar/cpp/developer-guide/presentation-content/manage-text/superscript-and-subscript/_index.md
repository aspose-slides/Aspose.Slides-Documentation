---
title: النص الفرعي والنص العلوي
type: docs
weight: 80
url: /ar/cpp/superscript-and-subscript/
---

## **إدارة نص النص العلوي والنص الفرعي**
يمكنك إضافة نص نص علوي ونص فرعي داخل أي فقرة. لإضافة نص علوي أو نص فرعي في إطار نص Aspose.Slides، يجب استخدام خصائص **Escapement** من فئة PortionFormat.

تُرجع هذه الخاصية أو تضبط نص النص العلوي أو النص الفرعي (قيمة تتراوح من -100% (نص فرعي) إلى 100% (نص علوي). على سبيل المثال:

- أنشئ مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- احصل على مرجع لشريحة باستخدام فهرسها.
- أضف شكل تلقائي من نوع مستطيل إلى الشريحة.
- الوصول إلى ITextFrame المرتبط بالشكل التلقائي.
- امسح الفقرات الموجودة
- أنشئ كائن فقرة جديد للاحتفاظ بالنص العلوي وأضفه إلى مجموعة IParagraphs من ITextFrame.
- أنشئ كائن جزء جديد
- اضبط خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص علوي. (0 يعني لا نص علوي)
- حدد بعض النصوص للجزء ثم أضف ذلك في مجموعة الأجزاء للفقرة.
- أنشئ كائن فقرة جديد للاحتفاظ بالنص الفرعي وأضفه إلى مجموعة IParagraphs من ITextFrame.
- أنشئ كائن جزء جديد
- اضبط خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص فرعي. (0 يعني لا نص فرعي)
- حدد بعض النصوص للجزء ثم أضف ذلك في مجموعة الأجزاء للفقرة.
- احفظ العرض التقديمي كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}
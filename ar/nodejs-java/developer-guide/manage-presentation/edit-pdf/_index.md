---
title: تحرير مستندات PDF في JavaScript
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/nodejs-java/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "تحرير مستندات PDF في JavaScript عن طريق استيرادها إلى Aspose.Slides، استبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى كملف PDF."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يتيح لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، وتصديره مرة أخرى إلى PDF. يوضح هذا المقال استبدال نص بسيط. يبقى العرض التقديمي في الذاكرة، لذا حفظ ملف PPTX وسيط اختياري.

## **استبدال النص في PDF**

استخدم [addFromPdf](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addFromPdf) لاستيراد الصفحات، [replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceText) لتحديث النص، و[save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لتصدير النتيجة.

يتوقع المثال التالي أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في الناتج. البحث يطابق الكلمات الكاملة بنفس حالة الحروف؛ `null` يعني عدم الحاجة إلى رد ناتج.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

لمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/nodejs-java/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
استبدال النص يعمل على النص المستورد، وليس النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا راجع الإخراج، خاصةً عندما يكون النص البديل أطول من الأصلي.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت تريد الاستمرار في تحريرها في PowerPoint؛ راجع [Save Presentations](/slides/ar/nodejs-java/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

المثال يطابق الكلمة الكاملة "Draft" بحالة الحروف الدقيقة. النص المستورد كصورة أو المقسم عبر إطارات نصية منفصلة قد لا يتطابق مع البحث. افحص المحتوى المستورد وعدل البحث ليتناسب مع مستندك.
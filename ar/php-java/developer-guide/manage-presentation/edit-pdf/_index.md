---
title: تعديل مستندات PDF في PHP
linktitle: تعديل PDF
type: docs
weight: 65
url: /ar/php-java/edit-pdf/
keywords:
- تعديل PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- PHP
- Aspose.Slides
description: "تحرير مستندات PDF في PHP عن طريق استيرادها إلى Aspose.Slides، واستبدال النص، وحفظ العرض المعدل مرة أخرى كملف PDF."
---
## **نظرة عامة**

يتيح Aspose.Slides for PHP عبر Java لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، وتعديل العرض التقديمي، وتصديره مرة أخرى إلى PDF. يوضح هذا المقال طريقة استبدال نص بسيط. يبقى العرض التقديمي في الذاكرة، لذا حفظ ملف PPTX مؤقت اختياري.

## **استبدال النص في PDF**

استخدم [SlideCollection::addFromPdf](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/#addFromPdf) لاستيراد الصفحات، و[Presentation::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceText) لتحديث النص، و[Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لتصدير النتيجة.

يتوقع المثال التالي أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب النتيجة إلى `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في النتيجة. البحث يطابق الكلمات الكاملة مع نفس حالة الأحرف؛ `null` يعني عدم الحاجة إلى استدعاء نتيجة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

لمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/php-java/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
يعمل استبدال النص على النص المستورد، وليس على النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا يرجى مراجعة النتيجة، خاصةً عندما يكون النص المستبدل أطول من الأصلي.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تحرير وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت ترغب في الاستمرار في تحريره في PowerPoint؛ راجع [Save Presentations](/slides/ar/php-java/save-presentation/).

**لماذا قد يبقى بعض النصوص دون تغيير؟**

يتطابق المثال مع الكلمة الكاملة "Draft" مع مطابقة حالة الأحرف بالضبط. النص المستورد كصورة أو مفرق عبر إطارات نصية منفصلة قد لا يتطابق مع البحث. تحقق من المحتوى المستورد واضبط عملية البحث لتناسب مستندك.
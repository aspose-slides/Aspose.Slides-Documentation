---
title: تحرير مستندات PDF في Java
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/java/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- Java
- Aspose.Slides
description: "تحرير مستندات PDF في Java عن طريق استيرادها إلى Aspose.Slides، استبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى إلى PDF."
---
## **نظرة عامة**

تتيح لك Aspose.Slides for Java تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، ثم تصديره مرة أخرى إلى PDF. توضح هذه المقالة استبدال نص بسيط. يظل العرض التقديمي في الذاكرة، لذا حفظ ملف PPTX وسيط أمر اختياري.

## **استبدال النص في PDF**

استخدم [addFromPdf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) لاستيراد الصفحات، [replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتحديث النص، و[save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لتصدير النتيجة.

يفترض المثال التالي أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب النتيجة إلى `edited.pdf`. يضمن مسح الشريحة الأولية قبل الاستيراد عدم ظهور صفحة فارغة إضافية في الناتج. يتطابق البحث مع الكلمات الكاملة بنفس حالة الأحرف؛ `null` يعني أنه لا حاجة إلى استدعاء نتيجة.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

لمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/java/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
يعمل استبدال النص على النص المستورد، وليس على النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا راجع الناتج خاصةً عندما يكون النص البديل أطول من النص الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت ترغب في الاستمرار في تحريره باستخدام PowerPoint؛ راجع [Save Presentations](/slides/ar/java/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

يتطابق المثال مع الكلمة الكاملة "Draft" بالحالة الدقيقة. النص المستورد كصورة أو المقسم عبر إطارات نصية منفصلة قد لا يطابق البحث. تحقق من المحتوى المستورد وقم بضبط عملية البحث وفقاً لمستندك.
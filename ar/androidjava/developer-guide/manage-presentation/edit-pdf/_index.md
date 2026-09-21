---
title: تحرير مستندات PDF على Android
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/androidjava/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- Android
- Java
- Aspose.Slides
description: "تحرير مستندات PDF على Android باستخدام Java عن طريق استيرادها إلى Aspose.Slides، استبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى إلى PDF."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يتيح لك تحرير محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، ثم تصديره مرة أخرى إلى PDF. يعرض هذا المقال مثالاً بسيطاً على استبدال النص. يبقى العرض التقديمي في الذاكرة، لذا حفظ ملف PPTX وسيط اختياري.

## **استبدال النص في ملف PDF**

استخدم [addFromPdf](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) لاستيراد الصفحات، [replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتحديث النص، و[save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لتصدير النتيجة.

يتوقع المثال التالي أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب الملف الناتج `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في النتيجة. البحث يطابق الكلمات الكاملة بحالة الأحرف نفسها؛ `null` يعني عدم الحاجة إلى رد ناتج.

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

لمزيد من الخيارات، راجع [بحث واستبدال النص](/slides/ar/androidjava/search-and-replace-text/) و[تحويل PowerPoint إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
عمل استبدال النص يطبق على النص المستورد، وليس على النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا يُنصح بمراجعة المخرجات، خاصةً عندما يكون النص البديل أطول من الأصل.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يجب علي حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا رغبت في الاستمرار في تحريرها عبر PowerPoint؛ راجع [حفظ العروض التقديمية](/slides/ar/androidjava/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

يتطابق المثال مع الكلمة الكاملة "Draft" بحالة الأحرف الدقيقة. النص المستورد كصورة أو المقسم عبر إطارات نصية منفصلة قد لا يتطابق مع البحث. تحقق من المحتوى المستورد وقم بضبط البحث وفقاً لوثيقتك.
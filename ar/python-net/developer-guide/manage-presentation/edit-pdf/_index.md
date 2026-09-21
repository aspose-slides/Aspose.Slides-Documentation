---
title: تحرير مستندات PDF في Python
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/python-net/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- Python
- Aspose.Slides
description: "تحرير مستندات PDF في Python عن طريق استيرادها إلى Aspose.Slides، واستبدال النص، وحفظ العرض المعدل مرة أخرى إلى PDF."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يتيح لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض، ثم تصديره مرة أخرى إلى PDF. تُظهر هذه المقالة استبدال نص بسيط. يظل العرض في الذاكرة، لذا فإن حفظ ملف PPTX متوسط غير إلزامي.

## **استبدال النص في PDF**

استخدم [add_from_pdf](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_from_pdf/) لاستيراد الصفحات، [replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_text/) لتحديث النص، و[save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لتصدير النتيجة.

يتوقع المثال التالي أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في النتيجة. البحث يطابق الكلمات الكاملة مع الحفاظ على حالة الأحرف؛ `None` يعني عدم الحاجة إلى رد نداء للنتيجة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

لمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/python-net/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
استبدال النص يعمل على النص المستورد، وليس على النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا يُنصح بمراجعة المخرجات، خاصةً عندما يكون النص المُستبدل أطول من النص الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض في الذاكرة. احفظ نسخة PPTX فقط إذا رغبت في الاستمرار في تحريره باستخدام PowerPoint؛ راجع [Save Presentations](/slides/ar/python-net/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

المثال يطابق الكلمة الكاملة "Draft" مع الحالة الدقيقة. النص المستورد كصورة أو مقسم عبر إطارات نصية منفصلة قد لا يتطابق مع البحث. تحقق من المحتوى المستورد وعدّل البحث وفقًا لمستندك.
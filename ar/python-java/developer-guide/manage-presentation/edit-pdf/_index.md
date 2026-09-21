---
title: تحرير مستندات PDF في Python عبر Java
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/python-java/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- Python
- Java
- Aspose.Slides
description: "تحرير مستندات PDF في Python عبر Java عن طريق استيرادها إلى Aspose.Slides، واستبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى بصيغة PDF."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يتيح لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، ثم تصديره مرة أخرى إلى PDF. تُظهر هذه المقالة استبدال نص بسيط. يبقى العرض التقديمي في الذاكرة، لذا فإن حفظ ملف PPTX مؤقت اختياري.

## **استبدال النص في ملف PDF**

استخدم [addFromPdf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addFromPdf) لاستيراد الصفحات، [replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#replaceText) لتحديث النص، و[save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لتصدير النتيجة.

المثال التالي يفترض أن يحتوي `input.pdf` على الكلمة "Draft" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "Final" ويكتب `edited.pdf`. مسح الشريحة الأولى قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في الناتج. البحث يطابق الكلمات الكاملة مع مراعاة حالة الأحرف؛ `None` يعني عدم الحاجة إلى رد اتصال للنتائج.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

لمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/python-java/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
يعمل استبدال النص على النص المستورد، وليس على النص داخل الصور الممسوحة ضوئياً. قد تؤثر عملية التحويل على تخطيط وتنسيق المستند، لذا يُنصح بمراجعة الناتج، خصوصاً عندما يكون النص البديل أطول من النص الأصلي.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت ترغب في متابعة تحريرها في PowerPoint؛ راجع [Save Presentations](/slides/ar/python-java/save-presentation/).

**لماذا قد يبقى بعض النص دون تغيير؟**

المثال يطابق الكلمة الكاملة "Draft" مع الحالة الدقيقة. النص المستورد كصورة أو المتقسم على إطارات نصية منفصلة قد لا يطابق البحث. تحقق من المحتوى المستورد واضبط البحث حسب مستندك.
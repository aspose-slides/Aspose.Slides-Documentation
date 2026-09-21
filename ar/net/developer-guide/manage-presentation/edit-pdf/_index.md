---
title: تحرير مستندات PDF في .NET
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/net/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- .NET
- C#
- Aspose.Slides
description: "تحرير مستندات PDF في C# عن طريق استيرادها إلى Aspose.Slides، واستبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى كملف PDF."
---
## **نظرة عامة**

Aspose.Slides for .NET يتيح لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، وتصديره مرة أخرى إلى PDF. توضح هذه المقالة استبدال نص بسيط. يبقى العرض التقديمي في الذاكرة، لذا حفظ ملف PPTX وسيط اختياري.

## **استبدال النص في PDF**

استخدم [AddFromPdf](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/addfrompdf/) لاستيراد الصفحات، و[ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replacetext/) لتحديث النص، و[Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لتصدير النتيجة.

المثال التالي يتوقع أن يحتوي `input.pdf` على كلمة "Draft" كنص قابل للتعديل بعد الاستيراد. يستبدل تلك الكلمة بـ "Final" ويكتب `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في النتيجة. البحث يطابق الكلمات الكاملة بنفس حالة الحروف؛ `null` يعني عدم الحاجة إلى رد ناتج.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

للمزيد من الخيارات، راجع [Search and Replace Text](/slides/ar/net/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
يعمل استبدال النص على النص المستورد، وليس النص داخل الصور الممسوحة ضوئياً. قد تؤثر التحويلات على التخطيط والتنسيق، لذا راجع النتيجة، لا سيما عندما يكون النص المستبدل أطول من الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يلزم حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت ترغب في الاستمرار في تحريره في PowerPoint؛ راجع [حفظ العروض](/slides/ar/net/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

المثال يطابق الكلمة الكاملة "Draft" بحالة الأحرف الدقيقة. النص المستورد كصورة أو المقسّم عبر إطارات نصية منفصلة قد لا يطابق البحث بالضرورة. تحقق من المحتوى المستورد وعدّل البحث ليتناسب مع مستندك.
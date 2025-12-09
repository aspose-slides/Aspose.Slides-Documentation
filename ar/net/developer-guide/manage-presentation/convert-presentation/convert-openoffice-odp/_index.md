---
title: تحويل عروض OpenDocument في .NET
linktitle: تحويل OpenDocument
type: docs
weight: 10
url: /ar/net/convert-openoffice-odp/
keywords:
- تحويل ODP
- ODP إلى صورة
- ODP إلى GIF
- ODP إلى HTML
- ODP إلى JPG
- ODP إلى MD
- ODP إلى PDF
- ODP إلى PNG
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى TIFF
- ODP إلى فيديو
- ODP إلى Word
- ODP إلى XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "تمكنك Aspose.Slides for .NET من تحويل ODP إلى PDF وHTML وتنسيقات الصور بسهولة. عزز تطبيقات .NET الخاصة بك بتحويل العروض التقديمية بسرعة ودقة."
---

## **نظرة عامة**

Aspose.Slides for .NET توفر واجهة برمجة تطبيقات قوية لتحويل عروض OpenDocument (ODP) إلى صيغ أخرى متنوعة. باتباع نهج مشابه للملفات الخاصة بـ PowerPoint (PPT و PPTX)، يمكن للمطورين بسهولة تصدير مستندات ODP إلى صيغ مثل HTML و PDF و TIFF و JPG و XPS والمزيد.

تظهر هذه الأمثلة كيفية تحويل مستندات ODP إلى صيغ أخرى (ما عليك سوى تغيير المصدر إلى ملف ODP):

- [Convert ODP to HTML](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convert ODP to PDF](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convert ODP to TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [Convert ODP to SWF](/slides/ar/net/convert-powerpoint-to-swf-flash/)
- [Convert ODP to XPS](/slides/ar/net/convert-powerpoint-to-xps/)
- [Convert ODP to PDF with Notes](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/)
- [Convert ODP to TIFF with Notes](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/)

على سبيل المثال، تحويل عرض ODP إلى PDF يتطلب بضع أسطر من الشيفرة في C#:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **عرض OpenDocument في تطبيقات مختلفة**

عند فتح ملف عرض OpenDocument (ODP) في PowerPoint، قد لا يحتفظ بالتنسيق الأصلي من التطبيق الذي تم إنشاؤه فيه. يحدث هذا لأن تطبيق عرض OpenDocument وتطبيق PowerPoint يقدمان ميزات وسلوكيات عرض مختلفة.

فيما يلي بعض الفروقات:

- في PowerPoint، عادةً ما يتم عرض الجداول في النهاية وقد تُغطي الأشكال الأخرى، بغض النظر عن ترتيبها على شريحة ODP.
- تعبئة الصور للجداول في ODP غير مدعومة في PowerPoint.
- دوران النص عموديًا (270°، مكدس) والمحاذاة الموزعة غير مدعومة في LibreOffice/OpenOffice Impress.
- تعبئة الصورة، التعبئة المتدرجة، وتعبئة النمط للنص غير مدعومة في LibreOffice/OpenOffice Impress.

يتعامل كل من MS PowerPoint و LibreOffice/OpenOffice Impress مع القوائم بشكل مختلف. قد لا يتم عرض ملف ODP تم إنشاؤه في PowerPoint بشكل صحيح في LibreOffice/OpenOffice Impress، والعكس صحيح.

الصورة أدناه توضح كيف يظهر القائمة عندما تُنشأ في LibreOffice Impress:

![مثال على قائمة ODP](odp-list-example.png)

Aspose.Slides يحفظ قوائم ODP بطريقة تضمن عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[Learn more about the OpenDocument format and PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **الأسئلة الشائعة**

**ماذا إذا تغير تنسيق ملف ODP بعد التحويل؟**

تستخدم ODP و PowerPoint نماذج عرض مختلفة، وقد لا يتم عرض بعض العناصر—مثل الجداول، الخطوط المخصصة، أو أنماط التعبئة—بنفس الشكل بالضبط. يُنصح بمراجعة الناتج وضبط التخطيط أو التنسيق في الشيفرة إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا، Aspose.Slides for .NET مكتبة مستقلة ولا تتطلب تثبيت OpenOffice أو LibreOffice على نظامك.

**هل يمكنني تخصيص صيغة الإخراج أثناء تحويل ODP (مثل ضبط خيارات PDF)؟**

نعم، Aspose.Slides يوفر خيارات غنية لتخصيص الإخراج. على سبيل المثال، عند الحفظ كـ PDF، يمكنك التحكم في الضغط، جودة الصورة، عرض النص، والمزيد عبر فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**هل Aspose.Slides مناسب لمعالجة ODP على الخادم أو في السحابة؟**

بالطبع. Aspose.Slides for .NET صُممت للعمل في بيئات سطح المكتب والخادم على حد سواء، بما في ذلك المنصات السحابية مثل Azure و AWS وحاويات Docker، دون أي تبعيات لواجهة المستخدم.
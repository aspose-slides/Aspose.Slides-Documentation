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
description: "يتيح لك Aspose.Slides لـ .NET تحويل ODP إلى PDF وHTML وتنسيقات الصور بسهولة. عزّز تطبيقات .NET الخاصة بك بتحويل عروض تقديمية سريع ودقيق."
---

## **نظرة عامة**

Aspose.Slides for .NET توفر واجهة برمجة تطبيقات قوية لتحويل عروض OpenDocument (ODP) إلى صيغ أخرى متعددة. باتباع نهج مماثل للملفات PowerPoint (PPT وPPTX)، يمكن للمطورين بسهولة تصدير مستندات ODP إلى صيغ مثل HTML وPDF وTIFF وJPG وXPS وأكثر.

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


## **العرض التقديمي OpenDocument في تطبيقات مختلفة**

عند فتح ملف عرض OpenDocument (ODP) في PowerPoint، قد لا يحتفظ بالتنسيق الأصلي من التطبيق الذي تم إنشاؤه فيه. يحدث ذلك لأن تطبيق عرض OpenDocument وتطبيق PowerPoint يقدمان ميزات وسلوكيات عرض مختلفة.

فيما يلي بعض الاختلافات:

- في PowerPoint، يتم عادةً عرض الجداول في النهاية وقد تتراكب فوق أشكال أخرى، بغض النظر عن ترتيبها على شريحة ODP.
- تعبئة الصور للجداول في ODP غير مدعومة في PowerPoint.
- دوران النص عموديًا (270°، مكدس) والمحاذاة الموزعة غير مدعومة في LibreOffice/OpenOffice Impress.
- تعبئة الصور، تعبئة التدرج، وتعبئة النمط للنص غير مدعومة في LibreOffice/OpenOffice Impress.

كما أن MS PowerPoint وLibreOffice/OpenOffice Impress يتعاملان مع القوائم بشكل مختلف. قد لا يتم عرض ملف ODP تم إنشاؤه في PowerPoint بشكل صحيح في LibreOffice/OpenOffice Impress، والعكس صحيح.

توضح الصورة أدناه كيفية ظهور قائمة تم إنشاؤها في LibreOffice Impress:

![مثال قائمة ODP](odp-list-example.png)

Aspose.Slides يحفظ قوائم ODP بطريقة تضمن عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[Learn more about the OpenDocument format and PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **الأسئلة المتكررة**

**ماذا إذا تغير تنسيق ملف ODP الخاص بي بعد التحويل؟**

تستخدم ODP وPowerPoint نماذج عرض مختلفة، وقد لا يتم عرض بعض العناصر—مثل الجداول أو الخطوط المخصصة أو أنماط التعبئة—نفسه تمامًا. يوصى بمراجعة المخرج وتعديل التخطيط أو التنسيق في الشيفرة إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا، Aspose.Slides for .NET مكتبة مستقلة ولا تتطلب وجود OpenOffice أو LibreOffice مثبتًا على نظامك.

**هل يمكنني تخصيص صيغة المخرج أثناء تحويل ODP (مثل ضبط خيارات PDF)؟**

نعم، Aspose.Slides توفر خيارات غنية لتخصيص المخرج. على سبيل المثال، عند الحفظ إلى PDF، يمكنك التحكم في الضغط، جودة الصورة، عرض النص، وأكثر عبر فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**هل Aspose.Slides مناسبة لمعالجة ODP على الخادم أو في السحابة؟**

بالطبع. Aspose.Slides for .NET مصممة للعمل في بيئات سطح المكتب والخوادم، بما في ذلك المنصات السحابية مثل Azure وAWS وحاويات Docker، دون أي تبعيات واجهة مستخدم.
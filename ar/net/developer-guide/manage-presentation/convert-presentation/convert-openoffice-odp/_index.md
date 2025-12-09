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
description: "تمكنك Aspose.Slides for .NET من تحويل ODP إلى PDF وHTML وتنسيقات الصور بسهولة. عزز تطبيقات .NET الخاصة بك بتحويل عروض سريع ودقيق."
---

## **نظرة عامة**

توفر Aspose.Slides for .NET واجهة برمجة تطبيقات قوية لتحويل عروض OpenDocument (ODP) إلى صيغ أخرى متعددة. باتباع نهج مشابه يُستخدم لملفات PowerPoint (PPT وPPTX)، يمكن للمطورين تصدير مستندات ODP بسهولة إلى صيغ مثل HTML وPDF وTIFF وJPG وXPS وغيرها.

تُظهر هذه الأمثلة كيفية تحويل مستندات ODP إلى صيغ أخرى (ما عليك سوى تغيير المصدر إلى ملف ODP):
- [تحويل ODP إلى HTML](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF](/slides/ar/net/convert-powerpoint-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/net/convert-powerpoint-to-xps/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/)

على سبيل المثال، يتطلب تحويل عرض ODP إلى PDF بضع أسطر فقط من الشيفرة في C#:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **العرض التقديمي OpenDocument في تطبيقات مختلفة**

عند فتح ملف عرض OpenDocument (ODP) في PowerPoint، قد لا يحتفظ بالتنسيق الأصلي من التطبيق الذي تم إنشاءه فيه. يحدث ذلك لأن تطبيق عرض OpenDocument وتطبيق PowerPoint يقدمان ميزات وسلوكيات عرض مختلفة.

فيما يلي بعض الاختلافات:
- في PowerPoint، يتم عادةً عرض الجداول في النهاية وقد تغطي أشكالًا أخرى، بغض النظر عن ترتيبها على شريحة ODP.
- ملء الصورة للجداول ODP غير مدعوم في PowerPoint.
- تدوير النص عموديًا (270°، مكدس) والمحاذاة الموزعة غير مدعومة في LibreOffice/OpenOffice Impress.
- ملء الصورة، والملء المتدرج، وملء النمط للنص غير مدعومة في LibreOffice/OpenOffice Impress.

كما يتعامل كل من MS PowerPoint وLibreOffice/OpenOffice Impress مع القوائم بصورة مختلفة. قد لا يتم عرض ملف ODP الذي تم إنشاؤه في PowerPoint بشكل صحيح في LibreOffice/OpenOffice Impress، والعكس صحيح.

الصورة أدناه توضح كيف تظهر القائمة عند إنشائها في LibreOffice Impress:
![مثال قائمة ODP](odp-list-example.png)

يقوم Aspose.Slides بحفظ قوائم ODP بطريقة تضمن عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[اعرف المزيد عن تنسيق OpenDocument وPowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **الأسئلة الشائعة**

**ماذا إذا تغير تنسيق ملف ODP بعد التحويل؟**

يستخدم ODP وPowerPoint نماذج عرض مختلفة، وبعض العناصر—مثل الجداول أو الخطوط المخصصة أو أنماط التعبئة—قد لا تُظهر بنفس الطريقة تمامًا. يُنصح بمراجعة النتيجة وضبط التخطيط أو التنسيق في الشيفرة إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا، Aspose.Slides for .NET هي مكتبة مستقلة ولا تتطلب تثبيت OpenOffice أو LibreOffice على نظامك.

**هل يمكنني تخصيص تنسيق الإخراج أثناء تحويل ODP (مثلاً، تعيين خيارات PDF)؟**

نعم، توفر Aspose.Slides خيارات غنية لتخصيص الإخراج. على سبيل المثال، عند الحفظ إلى PDF، يمكنك التحكم في الضغط وجودة الصورة وعرض النص وغير ذلك عبر الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**هل Aspose.Slides مناسبة لمعالجة ODP من جانب الخادم أو على السحابة؟**

بالطبع. تم تصميم Aspose.Slides for .NET للعمل في بيئات سطح المكتب والخادم على حدٍ سواء، بما في ذلك المنصات السحابية مثل Azure وAWS وحاويات Docker، دون أي اعتماد على واجهة المستخدم.
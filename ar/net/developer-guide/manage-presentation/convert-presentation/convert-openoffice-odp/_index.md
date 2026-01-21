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
description: "تمكنك Aspose.Slides for .NET من تحويل ODP إلى PDF و HTML وتنسيقات الصور بسهولة. عزز تطبيقات .NET الخاصة بك بتحويل عروض سريع ودقيق."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) يتيح لك تحويل عروض OpenDocument (ODP) إلى صيغ متعددة (HTML, PDF, TIFF, SWF, XPS، إلخ). API المستخدمة لتحويل ملفات ODP إلى صيغ مستندات أخرى هي نفسها المستخدمة في عمليات تحويل PowerPoint (PPT و PPTX).

For example, if you need to convert an ODP presentation to PDF, you can do it as follows:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **عرض OpenDocument في تطبيقات مختلفة**

عند فتح ملف عرض OpenDocument (ODP) في PowerPoint، قد لا يحتفظ بالتنسيق الأصلي من التطبيق الذي تم إنشاءه فيه. يحدث ذلك لأن تطبيق عرض OpenDocument وتطبيق PowerPoint يقدمان ميزات وسلوكيات عرض مختلفة.

فيما يلي بعض الاختلافات:

- في PowerPoint، يتم عادةً رسم الجداول في النهاية وقد تتغطى على أشكال أخرى، بغض النظر عن ترتيبها على شريحة ODP.
- تعبئة الصور للجداول في ODP غير مدعومة في PowerPoint.
- لا يدعم LibreOffice/OpenOffice Impress تدوير النص عموديًا (270°، متراكم) والمحاذاة الموزعة.
- لا يدعم LibreOffice/OpenOffice Impress تعبئة الصور، وتعبئة التدرج، وتعبئة النمط للنص.

كما يتعامل MS PowerPoint وLibreOffice/OpenOffice Impress مع القوائم بشكل مختلف. قد لا يعرض ملف ODP الذي تم إنشاؤه في PowerPoint بشكل صحيح في LibreOffice/OpenOffice Impress، والعكس صحيح.

الصورة أدناه توضح كيف تظهر قائمة عند إنشائها في LibreOffice Impress:

![مثال لقائمة ODP](odp-list-example.png)

Aspose.Slides يحفظ قوائم ODP بطريقة تضمن عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[تعرف على المزيد حول تنسيق OpenDocument وPowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **الأسئلة الشائعة**

**ماذا لو تغير تنسيق ملف ODP بعد التحويل؟**

تستخدم ODP وPowerPoint نماذج عرض مختلفة، وقد لا يتم عرض بعض العناصر—مثل الجداول، الخطوط المخصصة، أو أنماط التعبئة—بنفس الطريقة. يُنصح بمراجعة النتيجة وتعديل التخطيط أو التنسيق في الكود إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا، Aspose.Slides for .NET هي مكتبة مستقلة ولا تتطلب تثبيت OpenOffice أو LibreOffice على نظامك.

**هل يمكنني تخصيص تنسيق الإخراج أثناء تحويل ODP (مثلاً تعيين خيارات PDF)؟**

نعم، توفر Aspose.Slides خيارات غنية لتخصيص الإخراج. على سبيل المثال، عند الحفظ إلى PDF، يمكنك التحكم في الضغط، جودة الصورة، عرض النص، وأكثر من ذلك عبر فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) .

**هل Aspose.Slides مناسب لمعالجة ODP من جانب الخادم أو السحابة؟**

بالطبع. تم تصميم Aspose.Slides for .NET للعمل في بيئات سطح المكتب والخادم على حد سواء، بما في ذلك المنصات السحابية مثل Azure وAWS وحاويات Docker، دون أي تبعيات واجهة مستخدم.
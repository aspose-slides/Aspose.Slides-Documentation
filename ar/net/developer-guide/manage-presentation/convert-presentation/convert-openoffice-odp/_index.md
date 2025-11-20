---
title: تحويل عروض OpenDocument (ODP) في C#
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
description: "تمكنك Aspose.Slides for .NET من تحويل ODP إلى PDF وHTML وصيغ الصور بسهولة. عزّز تطبيقات .NET الخاصة بك بتحويل عروض تقديمية سريع ودقيق."
---

## **نظرة عامة**

Aspose.Slides for .NET يقدم واجهة برمجة تطبيقات قوية لتحويل عروض OpenDocument (ODP) إلى صيغ أخرى متعددة. باتباع نهج مشابه للملفات PowerPoint (PPT وPPTX)، يمكن للمطورين بسهولة تصدير مستندات ODP إلى صيغ مثل HTML وPDF وTIFF وJPG وXPS وغيرها.

هذه الأمثلة توضح كيفية تحويل مستندات ODP إلى صيغ أخرى (فقط غير مصدر الملف إلى ملف ODP):

- [تحويل ODP إلى HTML](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF](/slides/ar/net/convert-powerpoint-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/ar/net/convert-powerpoint-to-xps/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/)

على سبيل المثال، تحويل عرض ODP إلى PDF يتطلب بضع أسطر فقط من الكود في C#:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **عرض OpenDocument في تطبيقات مختلفة**

عند فتح ملف عرض OpenDocument (ODP) في PowerPoint، قد لا يحتفظ بالتنسيق الأصلي من التطبيق الذي تم إنشاؤه فيه. يحدث ذلك لأن تطبيق عرض OpenDocument وتطبيق PowerPoint يوفران ميزات وسلوكيات عرض مختلفة.

إليك بعض الاختلافات:

- في PowerPoint، تُعرض الجداول عادةً في النهاية وقد تغطي أشكالًا أخرى، بغض النظر عن ترتيبها على شريحة ODP.
- تعبئة الصورة للجداول في ODP غير مدعومة في PowerPoint.
- تدوير النص عموديًا (270°، مكدس) والمحاذاة الموزعة غير مدعومة في LibreOffice/OpenOffice Impress.
- تعبئة الصورة، وتعبئة التدرج، وتعبئة النمط للنص غير مدعومة في LibreOffice/OpenOffice Impress.

كما أن MS PowerPoint وLibreOffice/OpenOffice Impress يتعاملان مع القوائم بطريقة مختلفة. قد لا يتم عرض ملف ODP تم إنشاؤه في PowerPoint بشكل صحيح في LibreOffice/OpenOffice Impress، والعكس صحيح.

الصورة أدناه توضح كيف تظهر القائمة عند إنشائها في LibreOffice Impress:

![مثال قائمة ODP](odp-list-example.png)

Aspose.Slides يحفظ قوائم ODP بطريقة تضمن عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[تعرف على المزيد حول تنسيق OpenDocument وPowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **الأسئلة الشائعة**

**ماذا لو تغير تنسيق ملف ODP الخاص بي بعد التحويل؟**

تستخدم ODP وPowerPoint نماذج عرض مختلفة، وقد لا تُظهر بعض العناصر—مثل الجداول أو الخطوط المخصصة أو أنماط الملء—نفس الشكل بالضبط. يوصى بمراجعة الناتج وتعديل التخطيط أو التنسيق في الكود إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا، Aspose.Slides for .NET مكتبة مستقلة لا تتطلب تثبيت OpenOffice أو LibreOffice على نظامك.

**هل يمكنني تخصيص صيغة الإخراج أثناء تحويل ODP (على سبيل المثال، تعيين خيارات PDF)؟**

نعم، Aspose.Slides يوفر خيارات غنية لتخصيص الإخراج. على سبيل المثال، عند الحفظ إلى PDF، يمكنك التحكم في الضغط وجودة الصورة وعرض النص والمزيد عبر فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) .

**هل Aspose.Slides مناسب لمعالجة ODP من جانب الخادم أو السحابة؟**

بالطبع. Aspose.Slides for .NET مصمم للعمل في بيئات سطح المكتب والخادم، بما في ذلك المنصات السحابية مثل Azure وAWS وحاويات Docker، دون أي تبعيات واجهة مستخدم.
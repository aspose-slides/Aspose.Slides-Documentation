---
title: تحويل ODP من OpenOffice
type: docs
weight: 10
url: /net/convert-openoffice-odp/
keywords: "تحويل ODP إلى PDF، ODP إلى PPT، ODP إلى PPTX، ODP إلى XPS، ODP إلى HTML، ODP إلى TIFF"
description: "تحويل ODP إلى PDF، ODP إلى PPT، ODP إلى PPTX، ODP إلى HTML وأشكال أخرى باستخدام Aspose.Slides."
---

[**واجهة برمجة تطبيقات Aspose.Slides**](https://products.aspose.com/slides/net/) تتيح لك تحويل عروض OpenOffice ODP إلى العديد من التنسيقات. واجهة برمجة التطبيقات المستخدمة لتحويل ملفات ODP إلى تنسيقات مستندات أخرى هي نفسها المستخدمة لعمليات تحويل PowerPoint (PPT و PPTX).

تظهر هذه الأمثلة كيفية تحويل مستندات ODP إلى تنسيقات أخرى (فقط غير الملف المصدر ODP):

- [تحويل ODP إلى HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [تحويل ODP إلى PDF](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [تحويل ODP إلى TIFF](/slides/net/convert-powerpoint-to-tiff/)
- [تحويل ODP إلى SWF Flash](/slides/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [تحويل ODP إلى XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [تحويل ODP إلى PDF مع الملاحظات](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [تحويل ODP إلى TIFF مع الملاحظات](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

على سبيل المثال، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF، يمكنك القيام بذلك بهذه الطريقة:

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```

## عرض تقديمي OpenDocument في تطبيقات مختلفة

عند فتح ملف عرض تقديمي OpenDocument في PowerPoint، قد يفتقر إلى التنسيق كما كان في التطبيق الأصلي الذي أنشئ فيه بسبب أن تطبيق عرض OpenDocument وتطبيق PowerPoint يوفران ميزات وخيارات مختلفة.

هذه بعض من الفروقات:
- في PowerPoint، عادةً ما يتم تحميل جميع الجداول أخيرًا وتداخلها مع الأشكال الأخرى (بغض النظر عن ترتيب الأشكال على شريحة ODP).
- ملء الصورة للجداول ODP غير مدعوم في PowerPoint.
- تدوير النص العمودي (270، متراكب) ومحاذاة التوزيع غير مدعومة في LibreOffice/OpenOffice Impress.
- ملء الصورة، وملء التدرج، وملء الأنماط للنصوص غير مدعومة في LibreOffice/OpenOffice Impress.

تتعامل MS PowerPoint و LibreOffice/OpenOffice Impress مع القوائم بشكل مختلف أيضًا. ملف ODP الذي تم إنشاؤه في PowerPoint لن يفتح بشكل صحيح في LibreOffice/OpenOffice والعكس صحيح.

توضح هذه الصورة عرض القائمة المكونة في LibreOffice Impress:

![odp-list-example](odp-list-example.png)

**Aspose.Slides** يحفظ قوائم ODP لضمان عرضها بشكل صحيح في LibreOffice/OpenOffice Impress.

[تعلم المزيد حول تنسيق OpenDocument و PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/).
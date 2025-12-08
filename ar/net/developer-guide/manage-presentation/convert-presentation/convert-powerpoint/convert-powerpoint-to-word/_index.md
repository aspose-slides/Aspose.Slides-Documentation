---
title: تحويل عروض PowerPoint إلى مستندات Word باستخدام C#
linktitle: تحويل PowerPoint إلى Word
type: docs
weight: 110
url: /ar/net/convert-powerpoint-to-word/
keywords:
- PowerPoint إلى DOCX
- OpenDocument إلى DOCX
- العرض التقديمي إلى DOCX
- الشريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- ODP إلى DOCX
- PowerPoint إلى DOC
- OpenDocument إلى DOC
- العرض التقديمي إلى DOC
- الشريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- ODP إلى DOC
- PowerPoint إلى Word
- OpenDocument إلى Word
- العرض التقديمي إلى Word
- الشريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- ODP إلى Word
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- تحويل ODP
- C#
- .NET
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint وOpenDocument بسهولة إلى مستندات Word باستخدام Aspose.Slides for .NET. يقدم دليلنا خطوة بخطوة مع مثال كود C# الحل للمطورين الذين يرغبون في تبسيط سير عمل المستندات لديهم."
---

## **نظرة عامة**

هذه المقالة توفر حلاً للمطورين لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word باستخدام Aspose.Slides for .NET وAspose.Words for .NET. يقدم الدليل خطوة بخطوة شرحًا لكل مرحلة من عملية التحويل.

## **تحويل عرض تقديمي إلى مستند Word**

اتبع التعليمات أدناه لتحويل عرض PowerPoint أو OpenDocument إلى مستند Word:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل ملف العرض التقديمي.
2. إنشاء كائنات من الفئتين [Document](https://reference.aspose.com/words/net/aspose.words/document/) و[DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) لتوليد مستند Word.
3. تعيين حجم الصفحة لمستند Word ليتطابق مع حجم العرض التقديمي باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. تعيين الهوامش في مستند Word باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. استعراض جميع شرائح العرض التقديمي باستخدام الخاصية [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
    - إنشاء صورة للشريحة باستخدام الطريقة `GetImage` من الواجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) وحفظها في تدفق الذاكرة.
    - إضافة صورة الشريحة إلى مستند Word باستخدام الطريقة `InsertImage` من الفئة [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. حفظ مستند Word إلى ملف.

لنفترض أن لدينا عرضًا تقديميًا باسم "sample.pptx" يبدو هكذا:

![عرض PowerPoint](PowerPoint.png)

المثال التالي بلغة C# يوضح كيفية تحويل عرض PowerPoint إلى مستند Word:
```cs
// تحميل ملف عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// إنشاء كائنات Document و DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// تعيين حجم الصفحة في مستند Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// تعيين الهوامش في مستند Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// استعراض جميع شرائح العرض التقديمي.
foreach (var slide in presentation.Slides)
{
    // إنشاء صورة الشريحة وحفظها في تدفق الذاكرة.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // إضافة صورة الشريحة إلى مستند Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// حفظ مستند Word إلى ملف.
document.Save("output.docx");
```


النتيجة:

![مستند Word](Word.png)

{{% alert color="primary" %}} 

جرّب أداة [**تحويل PPT إلى Word على الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لتعرف ما يمكنك الاستفادة منه من تحويل عروض PowerPoint وOpenDocument إلى مستندات Word. 

{{% /alert %}}

## **الأسئلة المتكررة**

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة حزم NuGet الخاصة بـ [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) و[ Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) إلى مشروع C# الخاص بك. كلا المكتبتين تعملان كواجهات برمجة تطبيقات مستقلة، ولا يلزم تثبيت Microsoft Office.

**هل يتم دعم جميع صيغ عروض PowerPoint وOpenDocument؟**

Aspose.Slides for .NET [يدعم جميع صيغ العروض التقديمية](/slides/ar/net/supported-file-formats/)، بما في ذلك PPT وPPTX وODP وغيرها من أنواع الملفات الشائعة. هذا يضمن أنك تستطيع العمل على العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.
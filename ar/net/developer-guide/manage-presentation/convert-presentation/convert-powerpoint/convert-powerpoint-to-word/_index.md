---
title: تحويل عروض PowerPoint إلى مستندات Word في .NET
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/net/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى Word
- عرض تقديمي إلى Word
- شريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- PowerPoint إلى DOCX
- عرض تقديمي إلى DOCX
- شريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- PowerPoint إلى DOC
- عرض تقديمي إلى DOC
- شريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- حفظ PPT كـ DOCX
- حفظ PPTX كـ DOCX
- تصدير PPT إلى DOCX
- تصدير PPTX إلى DOCX
- .NET
- C#
- Aspose.Slides
description: "تحويل شرائح PowerPoint PPT و PPTX إلى مستندات Word قابلة للتعديل في C# باستخدام Aspose.Slides لـ .NET مع الحفاظ على التخطيط الدقيق والصور والتنسيق."
---

## **نظرة عامة**

توفر هذه المقالة حلاً للمطورين لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word باستخدام Aspose.Slides لـ .NET وAspose.Words لـ .NET. يرشِدك الدليل خطوةً بخطوة عبر كل مرحلة من عملية التحويل.

## **تحويل عرض تقديمي إلى مستند Word**

اتبع التعليمات أدناه لتحويل عرض PowerPoint أو OpenDocument إلى مستند Word:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتحميل ملف عرض تقديمي.
2. إنشاء مثال من الفئتين [Document](https://reference.aspose.com/words/net/aspose.words/document/) و[DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) لإنشاء مستند Word.
3. تعيين حجم الصفحة لمستند Word ليتطابق مع حجم عرض تقديمي باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. تعيين الهوامش في مستند Word باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. التنقل عبر جميع شرائح العرض باستخدام الخاصية [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
   - إنشاء صورة للشريحة باستخدام الطريقة `GetImage` من الواجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) وحفظها إلى تدفق الذاكرة.
   - إضافة صورة الشريحة إلى مستند Word باستخدام الطريقة `InsertImage` من الفئة [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. حفظ مستند Word إلى ملف.

لنفترض أن لدينا عرضًا تقديميًا باسم "sample.pptx" يبدو هكذا:

![عرض PowerPoint](PowerPoint.png)

يوضح المثال البرمجي التالي بلغة C# كيفية تحويل عرض PowerPoint إلى مستند Word:
```cs
// تحميل ملف عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// إنشاء كائنات Document و DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// تحديد حجم الصفحة في مستند Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// تحديد الهوامش في مستند Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// التنقل عبر جميع شرائح العرض التقديمي.
foreach (var slide in presentation.Slides)
{
    // إنشاء صورة للشريحة وحفظها إلى تدفق الذاكرة.
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
جرّب [**محول PPT إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك الاستفادة منه من تحويل عروض PowerPoint وOpenDocument إلى مستندات Word. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة حزم NuGet الخاصة بـ [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) و[Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) إلى مشروع C# الخاص بك. تعمل المكتبتان كواجهات برمجة تطبيقات مستقلة، ولا توجد حاجة لتثبيت Microsoft Office.

**هل يتم دعم جميع تنسيقات عروض PowerPoint وOpenDocument؟**

يدعم Aspose.Slides لـ .NET [جميع تنسيقات العروض](/slides/ar/net/supported-file-formats/)، بما في ذلك PPT وPPTX وODP وغيرها من أنواع الملفات الشائعة. يضمن ذلك إمكانية العمل مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.
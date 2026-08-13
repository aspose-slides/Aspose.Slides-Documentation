---
title: تحويل عروض PowerPoint إلى مستندات Word في .NET
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/net/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى Word
- العرض التقديمي إلى Word
- الشريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- PowerPoint إلى DOCX
- العرض التقديمي إلى DOCX
- الشريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- PowerPoint إلى DOC
- العرض التقديمي إلى DOC
- الشريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- حفظ PPT كـ DOCX
- حفظ PPTX كـ DOCX
- تصدير PPT إلى DOCX
- تصدير PPTX إلى DOCX
- .NET
- C#
- Aspose.Slides
description: "تحويل شرائح PowerPoint PPT و PPTX إلى مستندات Word قابلة للتحرير في C# باستخدام Aspose.Slides for .NET مع الحفاظ على التخطيط الدقيق والصور والتنسيق."
---
## **نظرة عامة**

تقدم هذه المقالة حلاً للمطورين حول تحويل عروض PowerPoint وOpenDocument إلى مستندات Word باستخدام Aspose.Slides for .NET وAspose.Words for .NET. الدليل خطوة بخطوة يأخذك عبر كل مرحلة من عملية التحويل.

## **تحويل عرض تقديمي إلى مستند Word**

اتبع التعليمات أدناه لتحويل عرض PowerPoint أو OpenDocument إلى مستند Word:

1. إنشاء كائن من الصنف [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وتحميل ملف عرض تقديمي.
2. إنشاء كائنات من الصنفين [Document](https://reference.aspose.com/words/net/aspose.words/document/) و[DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) لتوليد مستند Word.
3. ضبط حجم الصفحة للمستند Word لمطابقة حجم عرض الشرائح باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. ضبط الهوامش في مستند Word باستخدام الخاصية [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. المرور على جميع شرائح العرض باستخدام الخاصية [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/).
   - إنشاء صورة للشريحة باستخدام الطريقة `GetImage` من الواجهة [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/) وحفظها في تدفق ذاكرة.
   - إضافة صورة الشريحة إلى مستند Word باستخدام الطريقة `InsertImage` من الصنف [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. حفظ مستند Word إلى ملف.

لنفترض أن لدينا عرض تقديمي "sample.pptx" يبدو هكذا:

![عرض PowerPoint](PowerPoint.png)

يوضح المثال البرمجي التالي بلغة C# كيفية تحويل عرض PowerPoint إلى مستند Word:

```cs
using Aspose.Slides;
using Aspose.Words;

// تحميل ملف عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// إنشاء كائنات Document و DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// ضبط حجم الصفحة في مستند Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// ضبط الهوامش في مستند Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// المرور على جميع شرائح العرض.
foreach (var slide in presentation.Slides)
{
    // إنشاء صورة للشريحة وحفظها إلى تدفق ذاكرة.
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

{{% alert color="info" %}} 
جرّب أداة [**Online PPT to Word Converter**](https://products.aspose.app/slides/ar/conversion/ppt-to-word) لمعرفة ما يمكنك الاستفادة منه من تحويل عروض PowerPoint وOpenDocument إلى مستندات Word. 
{{% /alert %}}

## **الأسئلة الشائعة**

### ما المكونات التي يجب تثبيتها لتحويل عروض PowerPoint وOpenDocument إلى مستندات Word؟

كل ما عليك هو إضافة حزم NuGet الخاصة بـ [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) و[ Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) إلى مشروع C# الخاص بك. كلا المكتبتين تعملان كواجهات برمجة تطبيقات مستقلة، ولا يتطلب تثبيت Microsoft Office.

### هل يتم دعم جميع تنسيقات عروض PowerPoint وOpenDocument؟

Aspose.Slides for .NET [يدعم جميع تنسيقات العروض](/slides/ar/net/supported-file-formats/)، بما في ذلك PPT وPPTX وODP وغيرها من أنواع الملفات الشائعة. يضمن لك ذلك إمكانية العمل على عروض تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.
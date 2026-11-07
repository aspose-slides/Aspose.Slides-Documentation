---
title: ضغط العروض التقديمية
description: تقليل حجم العرض من خلال ضغط الصور وحفظ الإعدادات.
type: docs
url: /ar/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: العمليات
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **نظرة عامة**

ضغط الصور، وإزالة مناطق الصورة المقصوصة عندما لم تعد ضرورية، واختيار إعدادات ضغط العرض قبل الحفظ. هذا مفيد للعرض الذي يحتوي على صور كبيرة أو وسائط مكررة. مقدار التوفير يعتمد على المحتوى والإعدادات التي تختارها.

## **مثال على الاستخدام**

يستخدم مثال C# هذا Aspose.Slides for .NET. يولد بصورة واضحة صورة PNG متدرجة بحجم 1600 × 900 بكسل، يدخلها في إطار صورة صغير، ويحفظ *before.pptx*. ثم يضغط تلك الصورة إلى دقة هدف 96 DPI ويحفظ *compressed.pptx*. قارن حجم الملفين والمعاينات: يعتمد التوفير على الصورة المدخلة وحجم العرض.

لإعداد، راجع [تثبيت Aspose.Slides for .NET](/slides/ar/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **الأسئلة المتكررة**

### **هل هذا مفتاح تحسين الملف الكامل الوحيد؟**

يضيف Aspose.Slides for .NET 26.11 [Compress.CompressPresentation](/slides/ar/net/low-code-presentation-operations/#compress-the-whole-presentation) الذي يجمع بين إزالة التخطيطات/القوالب غير المستخدمة، وتقسيم الخطوط المضمّنة، وضغط الصور بدقة 150 DPI. إنه يزيل بصورة دائمة مناطق الصورة المقصوصة. للمعالجة التي تقتصر على الصور فقط، استخدم Compress.CompressImages؛ للحصول على تحكم أدق، احتفظ بسير العمل لكل صورة كما هو مذكور أعلاه. هذه المساعدات الجديدة مخصصة لإصدار .NET المذكور؛ تحقق من الدليل المقابل للـ SDKs الأخرى.

### **هل يغيّر ضغط الصورة النص القابل للتعديل أو المخططات؟**

يستهدف ضغط الصورة بيانات الصورة، وليس النص القابل للتعديل أو بيانات المخططات. راجع الصور لأن إعادة التحجيم أو إعادة الضغط قد يقلل من تفاصيلها.

### **كيف يجب أن أختار دقة صور العرض؟**

اختر الهدف بناءً على حجم الصورة المعروضة والاستخدام المقصود للشاشة أو الطباعة. احتفظ بدقة أعلى للشاشات الكبيرة، والطباعة، والرسوم البيانية التفصيلية، وقارن المخرجات المُصغرة قبل حذف الأصل.

## **الأدلة**

- [تحسين إدارة الصور في العروض التقديمية في .NET](/slides/ar/net/image/)

الميزة ذات الصلة: [إزالة القوالب، التخطيطات والوسائط غير المستخدمة](/slides/ar/features/remove-unused-content/).

## أمثلة .NET القابلة للتنفيذ

- [تقليل حجم العرض](/slides/ar/net/examples/optimization-batch/compression/)
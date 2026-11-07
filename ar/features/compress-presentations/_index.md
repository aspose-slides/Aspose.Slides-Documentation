---
title: ضغط العروض التقديمية
description: تقليل حجم العرض التقديمي عبر ضغط الصور وإزالة المحتوى غير المستخدم.
type: docs
url: /ar/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **نظرة عامة**

ضغط الصور، إزالة مناطق الصورة المقصوصة عندما لا تكون ضرورية بعد الآن، واختيار إعدادات ضغط العرض التقديمي قبل الحفظ. هذا مفيد للشرائح التي تحتوي على صور كبيرة أو وسائط متكررة. مقدار التوفير يعتمد على المحتوى والإعدادات التي تختارها.

## **مثال على الاستخدام**

هذا المثال المكتوب بـ C# يقوم بتحميل `input.pptx`، ضغط العرض التقديمي، وحفظه كـ `compressed.pptx`.

استخدم Aspose.Slides for .NET 26.11 أو أحدث. للحصول على الإعدادات، راجع [تثبيت Aspose.Slides لـ .NET](/slides/ar/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

### **هل هذا مفتاح تحسين كامل للملف الواحد؟**

Aspose.Slides for .NET 26.11 يضيف [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)، الذي يجمع بين إزالة التخطيطات/القوالب غير المستخدمة، تقليل الخطوط المدمجة وضغط الصور بدقة 150 DPI. يزيل بشكل دائم مناطق الصورة المقصوصة. للمعالجة التي تقتصر على الصور فقط، استخدم [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); للحصول على تحكم أدق، راجع [مثال ضغط الصورة الفردية](/slides/ar/net/examples/optimization-batch/compression/). هذه الأدوات الجديدة مخصصة للإصدار المذكور من .NET؛ تحقق من الدليل المقابل للـ SDKs الأخرى.

### **هل تغير ضغط الصور النص القابل للتحرير أو المخططات؟**

ضغط الصور يستهدف بيانات الصورة فقط، وليس النص القابل للتحرير أو بيانات المخططات. راجع الصور لأن تغيير الحجم أو إعادة الضغط قد يقلل من تفاصيلها.

### **كيف يجب أن أختار الدقة لصور العرض التقديمي؟**

اختر الهدف بناءً على حجم الصورة المعروض والاستخدام المقصود للشاشة أو الطباعة. حافظ على دقة أعلى للعرض على شاشات كبيرة، والطباعة، والرسوم البيانية التفصيلية، وقارن النتيجة المعروضة قبل حذف الأصل.

## **أدلة**

- [ضغط العرض التقديمي بالكامل في .NET](/slides/ar/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [تحسين إدارة الصور في العروض التقديمية في .NET](/slides/ar/net/image/)

الميزة ذات الصلة: [إزالة القوالب، التخطيطات والوسائط غير المستخدمة](/slides/ar/features/remove-unused-content/).

## أمثلة .NET القابلة للتنفيذ

- [تقليل حجم العرض التقديمي](/slides/ar/net/examples/optimization-batch/compression/)
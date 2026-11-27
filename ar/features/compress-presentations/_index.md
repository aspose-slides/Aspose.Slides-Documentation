---
title: ضغط العروض التقديمية
description: تقليل حجم العرض التقديمي عن طريق ضغط الصور وإزالة المحتوى غير المستخدم.
type: docs
url: /ar/features/compress-presentations/
weight: 250
feature_id: ضغط-العروض
feature_group: عمليات
translationKey: شرائح-ميزة-ضغط-العروض
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **نظرة عامة**

قُم بضغط الصور، واحذف مناطق الصور المُقتصَة عندما لا تحتاجها بعد الآن، واختر إعدادات ضغط العرض قبل الحفظ. هذا مفيد للعروض التي تحتوي على صور كبيرة أو وسائط متكررة. مقدار التوفير يعتمد على المحتوى والإعدادات التي تختارها.

## **مثال على الاستخدام**

يقوم هذا المثال بلغة C# بتحميل `input.pptx`، وضغط العرض، وحفظه كـ `compressed.pptx`.

استخدم Aspose.Slides for .NET الإصدار 26.11 أو أحدث. للحصول على إعداد، راجع [تثبيت Aspose.Slides for .NET](/slides/ar/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![عرض صور ذات مقياس مماثل قبل وبعد الضغط، يتبعه أشرطة حجم ملف PPTX المقاسة وأبعاد الصورة المخزنة.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*تم القياس على تثبيت تفصيلي صناعي واحد: 584,030 → 128,323 بايت. كلا العرضين يستخدمان نفس المقياس وإطار 252 × 336 نقطة. يزيل الضغط الهوامش المُقتصَة ويقلل الصورة المخزنة إلى 525 × 700 بكسل؛ يعتمد توفير الحجم على المدخلات.*  
<!-- visual-explanation:compress-presentations:end -->

## **الأسئلة المتكررة**

### **هل هذا مفتاح تحسين للملف بأكمله؟**

يضيف Aspose.Slides for .NET 26.11 الدالة [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)، التي تجمع بين إزالة التخطيطات/القوالب غير المستخدمة، وتقسيم الخط المضمن، وضغط الصور بدقة 150 DPI. يزيل بشكل دائم مناطق الصور المقتصَة. لمعالجة الصور فقط، استخدم [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); للحصول على تحكم أدق، راجع [مثال ضغط الصورة الفردية](/slides/ar/net/examples/optimization-batch/compression/). منذ الإصدار 26.11، يتوفر نفس الاستدعاء للعرض الكامل أيضًا في Java و Node.js عبر Java و Python عبر .NET و C++. المثال والروابط في هذه الصفحة موجهة ل .NET.

### **هل يغيّر ضغط الصورة النص القابل للتحرير أو المخططات؟**

يستهدف ضغط الصورة بيانات الصورة، وليس النص القابل للتحرير أو بيانات المخطط. راجع الصور لأن تغيير الحجم أو إعادة الضغط قد يقلل من تفاصيلها.

### **كيف أختار دقة صور العرض؟**

اختر هدفًا بناءً على حجم الصورة المعروضة والاستخدام المقصود للشاشة أو الطباعة. احتفظ بمزيد من الدقة للشاشات الكبيرة، والطباعة، والرسوم البيانية التفصيلية، وقارن النتيجة قبل حذف الأصل.

## **الأدلة**

- [ضغط العرض الكامل في .NET](/slides/ar/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [تحسين إدارة الصور في العروض في .NET](/slides/ar/net/image/)

الميزة ذات الصلة: [إزالة القوالب، التخطيطات والوسائط غير المستخدمة](/slides/ar/features/remove-unused-content/).

## **أمثلة .NET القابلة للتنفيذ**

- [تقليل حجم العرض](/slides/ar/net/examples/optimization-batch/compression/)
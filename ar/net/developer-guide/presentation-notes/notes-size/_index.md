---
title: تغيير حجم واتجاه صفحة الملاحظات في .NET
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/net/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات عمودية
- حجم النشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- C#
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لـ .NET، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF والصور."
---
## **نظرة عامة**

استخدم [Presentation.NotesSize](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/notessize/) للوصول إلى إعدادات صفحة الملاحظات في العرض التقديمي. تُعيد كائنًا من نوع [INotesSize](https://reference.aspose.com/slides/ar/net/aspose.slides/inotessize/) حيث يمكن كتابة خاصية [Size](https://reference.aspose.com/slides/ar/net/aspose.slides/inotessize/size/). على الرغم من أن كائن الإعدادات نفسه للقراءة فقط، يمكنك تعيين أبعاد جديدة لخاصية الحجم.

يتم تحديد العرض والارتفاع بوحدة **النقاط**، حيث يوجد 72 نقطة في البوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي ككل، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/notessize/) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرات. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slidesize/) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [ISlideSize](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/). |

تغيير أي من الإعدادين لا يغيّر الآخر تلقائيًا. تغيير اتجاه صفحة الملاحظات لا يدير الشرائح العادية أيضًا. راجع [Slide Size](/slides/ar/net/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملفًا موجودًا باسم `sample.pptx`. بالنسبة لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل تحتوي على ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم واتجاه صفحة الملاحظات**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأوسع تكون أفقية، الصفحة الأطول تكون عامودية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **التبديل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض الحالي مع الارتفاع. هذا يحافظ على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى عمودية ويترك الصفحة المربعة دون تغيير.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

للاتجاه العمودي، استخدم نفس التعيين عندما تكون `size.Width > size.Height`. لا تستبدل أبعاد A4 أو Letter إلا إذا كنت ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

عيّن البعدين معًا، ثم استخدم [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لكتابة العرض التقديمي. يحدد هذا المثال صفحة أفقية بقيمة 900 × 600 نقطة، ويحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المخزنة. يسمح المقارنة بتحمل مقدار 0.01 نقطة للقيم العائمة؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

النتيجة المتوقعة هي `900 x 600 points` و `Size preserved: True`. يتحقق فحص عرض تقديمي مفتوح حديثًا من الملف المحفوظ، وليس فقط الإعدادات في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المساحة المتوفرة للملاحظات أو تخطيطات النشرات. هذه الأبعاد لا تُفعِّل تلك التخطيطات بحد ذاتها: يجب أيضًا تكوين خيارات التصدير. يستمر تصدير الشرائح العادية في استخدام أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) إلى [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) لتضمين الملاحظات في ملف PDF. كما يقوم هذا المثال بتحويل الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage/) و [RenderingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/renderingoptions/).

وضعية [BottomTruncated](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notespositions/) تحتفظ بالملاحظات في صفحة واحدة؛ يمكن قص الملاحظات التي لا تتناسب. يستخدم PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون حجم PNG 900 × 600 بكسل. تصف النقاط هندسة الصفحة؛ تصف البكسلات مخرجات الرستر، والتي تعتمد أبعادها أيضًا على مقياس التجسيم.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

للتصدير إلى PDF مع ملاحظات طويلة، يسمح [BottomFull](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notespositions/) بإضافة صفحات إضافية حسب الحاجة. لا تستخدم هذه الوضعية مع استدعاء صورة شريحة واحدة أعلاه، لأنه لا يدعمها. بعد تغيير الحجم، افحص المخرجات بحثًا عن ملاحظات مقطوعة وموقع كائنات notes-master القائمة؛ تغيير أبعاد الصفحة وحده لا يجب أن يُعتبر ضمانًا لتناسب كل المحتوى. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/) للمزيد عن تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handoutlayoutingoptions/) لوضع عدة مصغرات شرائح في صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handouttype/) لترتيب ما يصل إلى أربع شرائح في الصفحة. يتحكم الإعداد الأفقي في ترتيب الشرائح؛ يأتي اتجاه الصفحة من عرضه وارتفاعه.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرات دون تغيير أبعاد الشرائح المصدرية. للحصول على صور النشرات، استخدم [Presentation.GetImages](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages/) مع تخطيط النشرة، بدلاً من طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم تصيير النشرات على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما لا تنتج طريقة صورة الشريحة الفردية صفحة النشرة. راجع [Handout Mode](/slides/ar/net/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في العارضات، التصدير والطباعة**

احتفظ بحجم العرض المخزن، وحجم الصفحة المصدرة، وحجم الورق المطبوع بشكل منفصل:

- **عَارِضُ العَرْض التَّقْدِيمِي:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد التخطيط الخاصة به. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد يقوم تحويل تنسيق ذلك التطبيق بتطبيعها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المكوَّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس تجسيم، لذا قد تُقرب القيم العشرية للنقاط في مخرجات الصورة. لا يطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **برمجيات تشغيل الطابعات:** اختيار الورق، والدوران التلقائي، وإعدادات الملاءمة للصفحة يمكن أن تُغيّر المخرجات الفعلية دون تغيير الأبعاد المخزنة في العرض التقديمي أو PDF. للحصول على حجم ورق محدد، طابق إعدادات الطابعة وتفقد معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني ضبط حجم ملاحظات شريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن أن تحتوي الشرائح الفردية على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يؤدي تغيير اتجاه الملاحظات إلى تغيير شرائحي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما ترغب في تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

أولاً أعد فتح العرض التقديمي المحفوظ وقارن أبعاد ملاحظاته. إذا تغيرت، تحقق مما إذا كان حفظ الملف أو تحويله في تطبيق آخر قد غير إعدادات الصفحة. إذا لم يحدث ذلك، فافحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.
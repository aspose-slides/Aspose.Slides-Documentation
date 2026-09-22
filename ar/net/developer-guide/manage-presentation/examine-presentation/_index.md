---
title: استرجاع وتحديث معلومات العرض التقديمي في .NET
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/net/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام .NET للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

Aspose.Slides يمكنه تحديد تنسيق العرض التقديمي وقراءة البيانات الوصفية للمستند دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة الفحص الخفيف الوزن عبر [PresentationFactory](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/)، بالإضافة إلى التحديثات المستهدفة عبر [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/).

## **التحقق من تنسيق العرض التقديمي**

إذا كان لديك عرض تقديمي مُحمَّل بالفعل، انظر إلى [تحديد تنسيق العرض التقديمي الأصلي](/slides/ar/net/detect-presentation-source-format/) للكشف بعد التحميل وقيود تدفقات PPT وPPS وPOT القديمة.

استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) لفحص ملف دون إنشاء مثال [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). خاصية [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/loadformat/) تُبلغ عن التنسيق المُكتشف، مثل PPTX أو PPT أو ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة العديد من ملفات العروض التقديمية، قد تحتاج إلى جرد مُضغَط للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/)، ثم استدعِ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة البيانات الوصفية للمستند. لا ينشئ هذا الأسلوب مثال [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) ولا يتطلب تجوال نموذج كائن العرض الكامل.

الخصائص الموسعة التي تُظهرها [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/) توفر القيم التالية للجرد:

| الخاصية | قيمة المخزون |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/slides/ar/) | إجمالي عدد الشرائح. |
| [HiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/hiddenslides/) | عدد الشرائح المخفية. |
| [Notes](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/notes/) | عدد الشرائح التي تحتوي على ملاحظات. |
| [Paragraphs](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/paragraphs/) | إجمالي عدد الفقرات، إذا كانت متاحة. |
| [Words](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/words/) | إجمالي عدد الكلمات. |
| [MultimediaClips](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/multimediaclips/) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation] ويطبع جردًا مُضغَطًا. كما يجمع بين [HeadingPairs] و[TitlesOfParts] لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

كل [IHeadingPair] يوفر اسم المجموعة وعدد العناصر في تلك المجموعة. [IDocumentProperties.TitlesOfParts] هو مصفوفة مسطحة ومُرتبة، لذا استهلك عدد العناوين المتتابعة المحدد بواسطة كل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود التنسيق**

خصائص الجرد التي تُرجعها [IPresentationInfo.ReadDocumentProperties] تعكس البيانات الوصفية المتوفرة في المستند المصدر. لا تقوم Aspose.Slides بتحميل وتجوّل نموذج كائن العرض لإعادة حساب هذه القيم لهذه العملية. تُمثل الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم تُحدّث التطبيق الذي حفظ الملف آخر مرة خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. التوفر يعتمد على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت خاصية غير موجودة أو لم يتم تحديثها من قبل منتج المستند، تُعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر البيانات الوصفية لـ OpenDocument إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، الشرائح التي تحتوي ملاحظات، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المصفوفة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيف للجرود وفحوصات أولية. حمِّل العرض التقديمي وتفحّص نموذج كائنه الحي عندما يجب أن يعكس النتيجة تغييرات الذاكرة أو عندما تحتاج إلى التحقق من محتوى العرض الفعلي.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُرجعها [IPresentationInfo.ReadDocumentProperties] دون إنشاء مثال [Presentation]. طبّق التغييرات باستخدام [IPresentationInfo.UpdateDocumentProperties]، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo.WriteBindedPresentation].

الصورة التالية تُظهر خصائص المستند الأصلية لعرض PowerPoint:

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

الصورة التالية تُظهر خصائص المستند المعدلة لعرض PowerPoint:

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/net/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/net/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمَّنة وأيها؟**

حمِّل العرض التقديمي واستخدم [Presentation.FontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/fontsmanager/). استدعِ [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) للحصول على الخطوط المضمَّنة و[FontsManager.GetFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getfonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للتصيير ولكنها غير مضمَّنة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كفاية البيانات الوصفية المخزنة، اقرأ [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/hiddenslides/) عبر [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) و[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو تحتاج إلى التحقق من القيم الحية؛ في هذه الحالة تجوَّل [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) وتفحص خاصية [Slide.Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا كان حجم الشريحة المخصص والاتجاه مستخدمين، وما إذا كانت تختلف عن الإعدادات الافتراضية؟**

نعم. حمِّل العرض التقديمي واقرأ [Presentation.SlideSize](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slidesize/). تفحّص [ISlideSize.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/type/)، [ISlideSize.Size](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/size/)، و[ISlideSize.Orientation](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/orientation/) لمقارنة الإعدادات الحالية مع القالب والأبعاد المتوقعة.

**هل هناك طريقة سريعة لرؤية ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. ابحث عن كل [Chart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/) وتفحّص [ChartData.DataSourceType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/). للوركبوك الخارجي، اقرأ [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/). يُحدِّد نوع مصدر البيانات والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحص موارد منفصل.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية التصيير أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. تجوَّل [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) وكل مجموعة [IBaseSlide.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/shapes/) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسومات متحركة، أو وسائط متعددة كإشارات فحص، وقُم بقياس تصيير أو تصدير تمثيلي قبل اعتبار شريحة معينة كعقبة أداء مؤكدة.
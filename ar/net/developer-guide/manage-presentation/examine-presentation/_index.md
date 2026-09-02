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
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام .NET للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

Aspose.Slides يمكنه التعرف على تنسيق العرض التقديمي وقراءة بيانات تعريف المستند دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض.

توضح هذه المقالة كيفية الفحص الخفيف الوزن باستخدام [PresentationFactory](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/)، بالإضافة إلى التحديثات المستهدفة عبر [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/).

## **تحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) لفحص ملف دون إنشاء نسخة من كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). تُظهر الخاصية [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/loadformat/) التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

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

عند معالجة العديد من ملفات العروض التقديمية، قد تحتاج إلى جرد مدمج لغرض التحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/)، ثم استدعِ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات تعريف المستند. لا ينتج هذا النهج كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) أو يتطلب عبور نموذج كائن العرض الكامل.

توفر الخصائص الموسعة التي يكشف عنها [IDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/) القيم التالية للجرد:

| الخاصية | قيمة الجرد |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/slides/ar/) | إجمالي عدد الشرائح. |
| [HiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/hiddenslides/) | عدد الشرائح المخفية. |
| [Notes](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/notes/) | عدد الشرائح التي تحتوي على ملاحظات. |
| [Paragraphs](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/paragraphs/) | إجمالي عدد الفقرات، إذا كانت متاحة. |
| [Words](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/words/) | إجمالي عدد الكلمات. |
| [MultimediaClips](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/multimediaclips/) | إجمالي عدد مقاطع الصوت والفيديو. |

تقرأ المثال التالي هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) وتطبع جردًا مدمجًا. كما يجمع بين [HeadingPairs](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/headingpairs/) و[TitlesOfParts](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/titlesofparts/) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

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

كل [IHeadingPair](https://reference.aspose.com/slides/ar/net/aspose.slides/iheadingpair/) يوفر اسم مجموعة وعدد العناصر في تلك المجموعة. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/titlesofparts/) هو مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحددة بكل زوج من العناوين.

### **البيانات الوصفية المخزنة وقيود التنسيق**

تعكس خصائص الجرد التي تُعيدها [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) البيانات الوصفية المتوفرة في المستند المصدر. لا يقوم Aspose.Slides بتحميل وعبور نموذج كائن العرض لإعادة حساب هذه القيم لهذه الاستدعاءة. تُظهر الخصائص المفقودة قيمًا افتراضية، وقد تكون القيم المخزنة قديمة إذا لم يقم التطبيق الذي حفظ الملف آخرًا بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوافرية على الخصائص التي كتبها مُنتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غير موجودة أو لم يتم تحديثها من قبل مُنتج المستند، يُعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات ODP الوصفية إحصائيات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، الشرائح ذات الملاحظات، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل قيمة الصفر أو المصفوفة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيفة للجرد والفحوصات الأولية. قم بتحميل العرض وفحص نموذج الكائن الحي عندما يجب أن تعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تعديل الخصائص التي تُعيدها [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). طبّق التغييرات باستخدام [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/updatedocumentproperties/)، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

الصورة التالية تُظهر خصائص المستند الأصلية للعرض التقديمي PowerPoint.

![خصائص المستند الأصلية للعرض التقديمي PowerPoint](input_properties.png)

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

![خصائص المستند المعدلة للعرض التقديمي PowerPoint](output_properties.png)

## **روابط مفيدة**

للقواعد المتعلقة بالتحقق من الأمان وإعدادات الحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/net/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/net/write-protected-presentation/)

## **الأسئلة المتداولة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأيها؟**

قم بتحميل العرض واستخدم [Presentation.FontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/fontsmanager/). استدعِ [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) للحصول على الخطوط المضمنة و[FontsManager.GetFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getfonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض لكنها غير مضمنة.

**كيف يمكنني معرفة بسرعة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كفاية بيانات المستند الوصفية المخزنة، اقرأ [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/idocumentproperties/hiddenslides/) عبر [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) و[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/readdocumentproperties/). هذا مناسب لجرد خفيف الوزن. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو إذا كنت بحاجة للتحقق من القيم الحية، قم بالتجول عبر [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) وتفقد خاصية [Slide.Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم وشكل مخصص للشرائح، وما إذا كانت تختلف عن القيم الافتراضية؟**

نعم. حمل العرض واقرأ [Presentation.SlideSize](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slidesize/). افحص [ISlideSize.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/type/)، [ISlideSize.Size](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/size/)، و[ISlideSize.Orientation](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/orientation/) لمقارنة الإعدادات الحالية مع الإعدادات المسبقة والأبعاد المتوقعة.

**هل توجد طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/) وتفحص [ChartData.DataSourceType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/). بالنسبة لدفتر عمل خارجي، اقرأ [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/externalworkbookpath/). يحدد نوع مصدر البيانات والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحص موارد منفصل.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. تجول عبر [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) وكل مجموعة [IBaseSlide.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/shapes/) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسوم متحركة، أو وسائط متعددة كإشارات فحص، وقم بقياس تمثيل أو تصدير نمطي قبل اعتبار الشريحة عنق زجاجة مؤكد للأداء.
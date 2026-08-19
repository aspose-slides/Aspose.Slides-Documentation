---
title: دمج العروض التقديمية بفعالية في .NET
linktitle: دمج العروض
type: docs
weight: 40
url: /ar/net/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument في .NET عن طريق استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وتغيير حجم محتوى الشرائح، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for .NET يدمج العروض التقديمية عن طريق استنساخ الشرائح من [العرض التقديمي](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الهدف.

تغطي هذه المقالة أكثر سير عمل دمج شائعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي؛
- دمج الشرائح المحددة؛
- تطبيق ماستر من العرض التقديمي الهدف؛
- تطبيق تخطيط محدد من العرض التقديمي الهدف؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل واحد؛
- التعامل مع الماسترات، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومشكلات البرمجة المتعددة الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد اختيارك للوظيفة الزائدة (overload) في الاستنساخ كيفية دمج الشريحة المدمجة في العرض التقديمي الهدف.

استخدم [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) بأحد الطرق التالية:

- `AddClone(sourceSlide)` — الحفاظ على تخطيط وتنسيق الشريحة الأصلية. عند الحاجة، يمكن استنساخ الماستر الأصلي إلى العرض الهدف تلقائيًا. تتبع Aspose.Slides الماسترات المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرات متعددة عند وجود شرائح مكررة تستخدم نفس الماستر.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى ماستر هدف محدد [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/). تبحث Aspose.Slides عن تخطيط متطابق تحت ذلك الماستر حسب نوع التخطيط أو اسمه.
- `AddClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرةً إلى تخطيط هدف محدد [ILayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/).

يجب أن يكون الماستر أو التخطيط المُمرّر إلى وظيفة `AddClone` جزءًا من العرض التقديمي **الهدف**، وليس من العرض المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض التقديمي المصدر إلى العرض التقديمي الهدف. هذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها الأصلي، والماستر، وعلاقات التخطيط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والهدف تصاميم مختلفة. وهذا متوقع عندما يتم الحفاظ على تنسيق المصدر عن قصد.

## **دمج الشرائح المحددة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المحددة من العرض التقديمي المصدر.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تأتي من مدخلات المستخدم أو من تكوين خارجي.

## **دمج الشرائح باستخدام ماستر هدف**

استخدم الوظيفة الزائدة [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما يجب أن تتبع الشرائح المستوردة ماسترًا ينتمي بالفعل إلى العرض التقديمي الهدف.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

تختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد عن طريق مطابقة نوع التخطيط المصدر أو اسمه. إذا لم يكن هناك تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط المصدر حتى يمكن إضافة الشريحة. إذا كان `false`، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إدخال تخطيط إضافي إلى الماستر الهدف.

## **دمج الشرائح باستخدام تخطيط هدف محدد**

استخدم الوظيفة الزائدة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما تعرف بالضبط أي تخطيط هدف يجب أن تستخدمه الشرائح المستوردة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

تطبيق تخطيط هدف يغيّر علاقة التخطيط الموروثة؛ لكنه لا يعيد تصميم محتوى الشريحة المصدر. إذا كان للتخطيطين المصدر والهدف هياكل عنصر نائب مختلفة، تحقق من النتيجة لتؤكد أن التنسيق الموروث وسلوك العنصر النائب ملائم.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج العروض التقديمية ذات أبعاد شرائح مختلفة، ولكن استنساخ شريحة إلى عرض تقديمي بحجم شريحة مختلف لا يعيد تصميم محتواها تلقائيًا للقماش الجديد. لذلك قد تظهر الأشكال مُزاحة، أو مُقاسة بشكل غير متوقع، أو خارج مساحة الشريحة المرئية.

نهج عملي هو تغيير حجم العرض التقديمي المصدر قبل الاستنساخ. يمكن للطريقة [SlideSize.SetSize](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesize/setsize/) أن تُعيد تحجيم المحتوى الموجود أثناء تغيير أبعاد الشريحة. كما أن [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesizescaletype/) يُعيد تحجيم المحتوى ليتناسب مع الحجم المطلوب.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

تغيير الحجم يُعدِّل كائن العرض التقديمي المصدر في الذاكرة. إذا كنت بحاجة إلى إبقاء العرض التقديمي الأصلي غير متغير لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

حَلقة استنساخ الشرائح الأساسية لا تعيد إنشاء هيكلية الأقسام في العرض التقديمي المصدر. إذا كانت الأقسام مهمة في النتيجة، أنشئ أو اختر أقسامًا في العرض الهدف واستنسخ الشرائح إليها صراحةً باستخدام [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

تُضاف الشرائح المستنسخة إلى القسم الهدف المحدد. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في الهدف واربط كل شريحة مصدر بالقسم الهدف المقابل.

## **دمج عروض تقديمية متعددة بأمان**

المثال التالي الشامل يستخدم العرض التقديمي الأول كهدف، ويُوحد حجم الشرائح لكل مصدر إضافي، ويُبقي كل مصدر مفتوحًا فقط أثناء نسخه، ويحفظ الملف النهائي مرة واحدة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

هذه قاعدة مفيدة للحفاظ على تنسيق المصدر للشرائح المستوردة. إذا كان يجب أن يستخدم الإخراج موضوعًا واحدًا للهدف، استبدل الاستدعاء البسيط `AddClone(slide)` بالوظيفة الزائدة المناسبة للماستر الهدف أو التخطيط الهدف المذكورة أعلاه.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب ماستر المصدر المطلوب تلقائيًا إلى العرض الهدف. تحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ الماستر نفسه مرّات متعددة. لا يتم تتبع الماسترات المستنسخة يدويًا بهذا السجل، لذا تجنّب استنساخ الماسترات مسبقًا ما لم تحتاج إلى تحكم صريح في هيكلة الماستر.

لا تفترض أن ماسترَين أو تخطيطين لهما نفس الاسم متساويين بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط هدف صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشريحة مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. كما توفر Aspose.Slides واجهات برمجة تطبيقات مخصصة لـ [ملاحظات العرض التقديمي](https://docs.aspose.com/slides/ar/net/presentation-notes/) و[تعليقات العرض التقديمي](https://docs.aspose.com/slides/ar/net/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. لأعمال المراجعة، تحقق أيضًا من مؤلفي التعليقات وتعليقات السلسلة بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى تتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمُربطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يعتمد على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

تتبع Aspose.Slides صراحةً الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض تقديمية مصادر غير مرتبطة ستتم إزالتها دائمًا. إذا كان حجم ملف الإخراج مهمًا، فافحص الحزمة المدمجة وقم بقياس النتيجة بدلًا من الاعتماد على الإزالة الضمنية للتكرارات.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض التقديمي. إذا كان يجب أن يبقى التنسيق الطباعي متسقًا عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الهدف. يمكنك فحص الخطوط المدمجة عبر [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) وإدارة الدمج صراحةً كما هو موضح في [دمج الخطوط في العروض التقديمية](https://docs.aspose.com/slides/ar/net/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر. قد تقيد تراخيص الخطوط عملية الدمج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل إمكانية استنساخ شرائحه. قدم كلمة المرور عبر [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

فتح مصدر مشفر لا يطبق الحماية نفسها تلقائيًا على العرض التقديمي الهدف. قم بتكوين حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستخدام الذاكرة**

العروض التقديمية الكبيرة التي تحتوي على صور عالية الدقة، صوت، فيديو، أو كائنات ثنائية كبيرة أخرى يمكن أن تستهلك ذاكرة كبيرة. توفر [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/blobmanagementoptions/) أدوات للتحكم في معالجة الـ BLOB واستخدام الملفات المؤقتة. راجع [إدارة BLOBs للعرض التقديمي](https://docs.aspose.com/slides/ar/net/manage-blob/) لاستراتيجيات الملفات الكبيرة.

بالنسبة للملفات الكبيرة، يفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، وتفريغ كل عرض تقديمي مصدر بمجرد دمجه، وتجنب حفظ النتائج المتوسطة بشكل متكرر إلا إذا كان سير العمل يتطلب نقاط تحقق.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ نفس نسخة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) بشكل متزامن من عدة خيوط. احتفظ بكل نسخة عرض تقديمي محصورة في عملية دمج واحدة. إذا قمت بتوازية مهام مستقلة، استخدم نسخ عرض تقديمي مستقلة وتابع إرشادات [البرمجة المتعددة الخيوط في Aspose.Slides](https://docs.aspose.com/slides/ar/net/multithreading/).

## **الأسئلة الشائعة**

**كيف أحافظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) بدون توفير ماستر أو تخطيط هدف. يمكن لـ Aspose.Slides استنساخ ماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع العرض الهدف؟**

استخدم الوظيفة الزائدة التي تقبل ماستر هدف. مرر ماسترًا من العرض التقديمي الهدف، وليس من المصدر. ستحاول Aspose.Slides ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى ينبغي استخدام تخطيط هدف محدد بدلاً من ماستر هدف؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد أن تختار Aspose.Slides من بين تخطيطات ذلك الماستر بناءً على نوع التخطيط المصدر أو اسمه.

**هل يمكن دمج عروض تقديمية بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا لأبعاد الهدف. قم بتغيير حجم العرض المصدر أولاً عندما تحتاج إلى وضع متوقع، على سبيل المثال باستخدام [SlideSize.SetSize](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesize/setsize/) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesizescaletype/).

**هل يمكن دمج عروض PPT, PPTX, و ODP في ملف واحد؟**

نعم. حمِّل كل عرض تقديمي مصدر، استنسخ الشرائح المطلوبة إلى هدف واحد، واحفظ الهدف بصيغة خروج مدعومة. نظرًا لأن تنسيقات العروض لا تدعم تمامًا نفس مجموعة الميزات، تحقق من المحتوى المعقد بعد عمليات الدمج بين التنسيقات. راجع [تنسيقات الملفات المدعومة](https://docs.aspose.com/slides/ar/net/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**

ليس بواسطة حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الهدف واستخدم الوظيفة الزائدة للقسم في [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما يجب الحفاظ على بنية الأقسام.

**هل يتم الحفاظ على ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. لأعمال تعتمد على تنسيق ماستر الملاحظات، مؤلفي التعليقات، أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض وكذلك محتوى على مستوى الشريحة.

**ماذا يحدث للملفات الصوتية، الفيديو، كائنات OLE، والروابط التشعبية؟**

يتم نقل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. تبقى الروابط الخارجية خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل تضمن الخطوط المدمجة من كل مصدر توافرها في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المدمجة في الهدف وأدرج إدارة دمج الخطوط صراحةً أو توفر الخطوط الخارجية عندما يكون التنسيق الطباعي مهمًا.

**كيف أدمج ملفًا محمًى بكلمة مرور؟**

افتحه باستخدام [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/) الصحيحة، ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية الإخراج بشكل منفصل.

**كيف يجب التعامل مع العروض التقديمية الكبيرة جدًا؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، ويفضل التحميل من مسار الملف للملفات الكبيرة جدًا، وتفريغ العروض المصدرية فور الانتهاء من دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكن دمج الشرائح من عدة خيوط؟**

لا تستخدم نسخة واحدة من [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) بشكل متزامن من عدة خيوط. احفظ كل عملية دمج معزولة إلى نسخ العرض الخاصة بها.
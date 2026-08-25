---
title: دمج العروض التقديمية بفعالية في .NET
linktitle: دمج العروض التقديمية
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
- جمع PowerPoint
- جمع العروض التقديمية
- جمع الشرائح
- جمع PPT
- جمع PPTX
- جمع ODP
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument في .NET عن طريق استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وإعادة تحجيم محتوى الشرائح، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for .NET يدمج العروض التقديمية عن طريق استنساخ الشرائح من أحد [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في عرض تقديمي الوجهة.

يغطي هذا المقال أكثر طرق الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي؛
- دمج شرائح مختارة؛
- تطبيق ماستر من عرض تقديمي الوجهة؛
- تطبيق تخطيط محدد من عرض تقديمي الوجهة؛
- تطبيع أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في تدفق عمل من البداية إلى النهاية؛
- معالجة الماسترات والموارد والملاحظات والتعليقات والوسائط والخطوط وكلمات المرور والملفات الكبيرة ومقائيس الخيوط المتعددة.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد اختيارك لتعددية الاستنساخ كيف يتم دمج الشريحة المدموجة في عرض تقديمي الوجهة.

استخدم [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) بأحد الطريقتين التاليتين:

- `AddClone(sourceSlide)` — الحفاظ على تخطيط وتنسيق الشريحة الأصلية. عند الحاجة، يمكن استنساخ الماستر الأصلي إلى عرض تقديمي الوجهة تلقائيًا. يتتبع Aspose.Slides الماسترات المستنسخة تلقائيًا بحيث لا تتكرر عملية الاستنساخ لنفس الماستر عند وجود شرائح متعددة تستخدمه.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) معين في الوجهة. يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر بناءً على نوع التخطيط أو اسمه.
- `AddClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرةً إلى [ILayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/) معين في الوجهة.

يجب أن يكون الماستر أو التخطيط المرسل إلى تعددية `AddClone` تابعًا لعرض تقديمي **الوجهة**، وليس للعرض المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض المصدر إلى عرض الوجهة. هذا هو الاختيار المناسب عندما ينبغي على الشرائح المستوردة الاحتفاظ بالمظهر الأصلي، والماستر، وعلاقات التخطيط.

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

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والوجهة تصاميم مختلفة. هذا متوقع عندما يُحافظ على تنسيق المصدر عمدًا.

## **دمج شرائح مختارة**

ليس من الضروري استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المحددة من العرض المصدر.

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

قم بالتحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تكون مدخلة من المستخدم أو من تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم تعددية [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما يجب أن تتبع الشرائح المستوردة ماسترًا موجودًا بالفعل في عرض تقديمي الوجهة.

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

يختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد عبر مطابقة نوع التخطيط الأصلي أو اسمه. إذا لم يوجد تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط الأصلي لكي تُضاف الشريحة. إذا كان `false`، يتم إطلاق استثناء [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إضافة تخطيط إضافي إلى ماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم تعددية [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

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

يغيّر تطبيق تخطيط الوجهة علاقة التخطيط الموروث؛ لكنه لا يعيد تصميم محتوى الشريحة الأصلية. إذا كان لتخطيطي المصدر والوجهة هياكل نائبة مختلفة، تحقق من النتيجة لتأكد من ملاءمة التنسيق الموروث وسلوك النائبة.

## **دمج عروض تقديمية بأحجام شرائح مختلفة**

يمكن دمج عروض تقديمية بأبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد أخرى لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال مُحَوَّلة أو مُقاسة بشكل غير متوقع، أو خارج منطقة الشريحة المرئية.

نهج عملي هو تغيير حجم العرض المصدر قبل الاستنساخ. يمكن للطريقة [SlideSize.SetSize](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesize/setsize/) تعديل المحتوى الحالي أثناء تغيير أبعاد الشريحة. كما أن [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesizescaletype/) يقيِّم المحتوى ليملأ الحجم المطلوب.

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

يغيّر تغيير الحجم كائن العرض المصدر في الذاكرة. إذا كنت بحاجة إلى إبقاء العرض الأصلي دون تعديل لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

الحلقة الأساسية لاستنساخ الشرائح لا تُعيد إنشاء هيكل أقسام العرض المصدر. إذا كانت الأقسام مهمة في النتيجة، أنشئ أو حدد أقسامًا في عرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/).

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

تُضاف الشرائح المستنسخة إلى القسم المحدد في الوجهة. للحفاظ على عدة أقسام مصدر، قم بتعداد [Presentation.Sections](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sections/)، استخرج الشرائح الحالية لكل قسم مصدر باستخدام [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/getslideslistofsection/)، أعد إنشاء الأقسام في الوجهة، واستنسخ كل شريحة مُسترجعة إلى قسم الوجهة المقابل. راجع مثال إدارة أقسام الشرائح [Manage Slide Sections](/slides/ar/net/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عروض تقديمية متعددة بأمان**

المثال التالي من البداية إلى النهاية يستخدم العرض الأول كوجهة، يُطبع حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

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

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان على الناتج استخدام مظهر وجهة موحد، استبدل استدعاء `AddClone(slide)` البسيط بتعددية الماستر أو التخطيط المناسب للوجهة المذكورة مسبقًا.

## **اعتبارات عملية**

### **الماسترات والتخطيطات ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب ماستر مصدر مطلوب إلى عرض الوجهة تلقائيًا. يحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. لا يتم تتبع الماسترات المستنسخة يدويًا في ذلك السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين يحملان نفس الاسم متطابقان بصريًا. إذا كان قالب الشركة يتحكم في المظهر النهائي، اختر ماستر أو تخطيط وجهة صريحًا وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

الملاحظات الصوتية وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. يقدم Aspose.Slides أيضًا واجهات برمجة تطبيقات مخصصة لـ [presentation notes](/slides/ar/net/presentation-notes/) و[presentation comments](/slides/ar/net/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدموج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين الملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات والسلاسل المتفرعية بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط لكي يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معاملة الموارد المرتبطة وغير المرتبطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدموج.

يتتبع Aspose.Slides الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا بأن الموارد الثنائية المتطابقة من عروض مصدر غير ذات صلة ستُدمج دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدموجة وقس النتيجة بدلًا من الاعتماد على التجميع الضمني.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان يجب الحفاظ على تناسق الطباعية عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل الخطوط المطلوبة في بيئة الوجهة. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/net/embedded-font/).

تحقق أيضًا من أنه يُسمح لك بدمج الخطوط المستخدمة في الملفات المصدر. قد تفرض تراخيص الخطوط قيودًا على الدمج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. قدم كلمة المرور عبر [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

فتح مصدر مشفر لا يطبق الحماية نفسها تلقائيًا على عرض الوجهة. قم بتكوين حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض الكبيرة واستهلاك الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة أخرى قد تستهلك ذاكرة ملحوظة. يوفر [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/blobmanagementoptions/) أدوات للتحكم في معالجة BLOB واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/net/manage-blob/) لاستراتيجيات التعامل مع الملفات الكبيرة.

للملفات الضخمة، يُفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، وتفريغ كل عرض مصدر بمجرد دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر ما لم تتطلب سير العمل نقاط تفتيش.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) بشكل متزامن من خيوط متعددة. احتفظ بكل كائن عرض ضمن عملية دمج واحدة. إذا قمت بتوازٍ وظائف مستقلة، استخدم كائنات عرض مستقلة واتبع إرشادات [Aspose.Slides multithreading guidance](/slides/ar/net/multithreading/).

## **الأسئلة الشائعة**

**كيف أحافظ على التصميم الأصلي لكل عرض مصدر؟**

استخدم [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) بدون تزويد ماستر أو تخطيط وجهة. يستطيع Aspose.Slides استنساخ ماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم مظهر الوجهة؟**

استخدم التعددية التي تقبل ماستر وجهة. مرّر ماسترًا من عرض الوجهة، وليس من المصدر. سيحاول Aspose.Slides مطابقة كل شريحة مصدر إلى تخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلاً من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides من بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط الأصلي.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يعاد تصميمه تلقائيًا لأبعاد الوجهة. قم بتغيير حجم العرض المصدر أولاً عندما تحتاج إلى وضعية متنبأ بها، على سبيل المثال باستخدام [SlideSize.SetSize](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesize/setsize/) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesizescaletype/).

**هل يمكنني دمج ملفات PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض واحد كوجهة، واحفظ الوجهة بصيغة مدعومة. نظرًا لاختلاف مجموعة الميزات بين صيغ العروض، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ المختلفة. راجع [Supported File Formats](/slides/ar/net/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**

ليس من خلال حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم تعددية القسم في [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدثين والتعليقات؟**

تُنسخ مع الشريحة المستنسخة. بالنسبة لسير العمل الذي يعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدموجة لأن تلك السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للصوت والفيديو وكائنات OLE والروابط التشعبية؟**

المحتوى المدمج ينتقل كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تكون ملفات الهدف أو عناوين URL الخاصة بها متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر تكون مضمونة الوجود في العرض المدموج؟**

لا تعتمد على استنساخ الشرائح فقط لتوزيع الخطوط. افحص الخطوط المدمجة في الوجهة وأدرج إدارة الخطوط المدمجة أو توافر الخطوط الخارجية صراحةً عندما تكون الطباعية مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/)، ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية الإخراج بشكل منفصل.

**كيف أتعامل مع عروض تقديمية كبيرة جدًا؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضّل التحميل من مسار الملف للملفات الضخمة، وتفريغ عروض المصدر بسرعة، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج الشرائح من عدة خيوط؟**

لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحدًا بشكل متزامن من خيوط متعددة. حافظ على عزل كل عملية دمج في كائنات عرض مستقلة.
---
title: دمج العروض التقديمية بفعالية في جافا سكريبت
linktitle: دمج العروض
type: docs
weight: 40
url: /ar/nodejs-java/merge-presentation/
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
- Node.js
- جافا سكريبت
- Aspose.Slides
description: "تعرّف على كيفية دمج عروض PowerPoint وOpenDocument في جافا سكريبت عن طريق استنساخ الشرائح، والتحكم في الـ masters والـ layouts، وتغيير حجم محتوى الشرائح، وحفظ الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Node.js عبر Java يدمج العروض التقديمية عن طريق استنساخ الشرائح من عرض تقديمي [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)، والتي يمكنها الحفاظ على تنسيق الشريحة المصدر أو ربط الشريحة المستنسخة ب​master أو layout في عرض التقديم الوجهة.

يغطي هذا المقال أكثر سيناريوهات الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي؛
- دمج شرائح مختارة؛
- تطبيق master من عرض التقديم الوجهة؛
- تطبيق layout محدد من عرض التقديم الوجهة؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل؛
- التعامل مع masters، والموارد، والملاحظات، والتعليقات، والوسائط، والخطوط، وكلمات المرور، والملفات الكبيرة، ومخاوف تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على Masters والـ Layouts**

تستمد الشريحة جزءًا كبيرًا من مظهرها من layout وmaster الخاصين بها. لهذا السبب يحدد اختيارك للنسخة المتجاوزة (overload) كيف يتم دمج الشريحة في عرض التقديم الوجهة.

استخدم [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) بأحد الطرق التالية:

- `addClone(sourceSlide)` — الحفاظ على layout وتنسيق الشريحة المصدر. عند الحاجة، يمكن استنساخ الـ master المصدر إلى عرض التقديم الوجهة تلقائيًا. يتعقب Aspose.Slides الـ masters المستنسخة تلقائيًا بحيث لا يتم استنساخ الـ master نفسه مرارًا عندما تُستخدم الشرائح المتعددة ذات الـ master نفسه.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — ربط الشريحة المستنسخة ب​[MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) معين في الوجهة. يبحث Aspose.Slides عن layout مطابق تحت ذلك الـ master إما بنوع الـ layout أو باسمه.
- `addClone(sourceSlide, destinationLayout)` — ربط الشريحة المستنسخة مباشرةً بـ[LayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) معين في الوجهة.

يجب أن يكون الـ master أو الـ layout الممرر إلى نسخة `addClone` المتجاوزة تابعًا لـ **العرض الوجهة**، وليس للعرض المصدر.

## **دمج عروض تقديمية كاملة مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض المصدر إلى العرض الوجهة. هذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بالموضوع، والـ master، وعلاقات الـ layout الأصلية.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

قد يحتوي العرض الناتج على عدة masters عندما تستخدم العروض المصدر والوجهة تصاميم مختلفة. وهذا متوقع عندما يُراد الحفاظ على تنسيق المصدر عن قصد.

## **دمج شرائح مختارة**

ليس من الضروري استنساخ كل شريحة. المثال التالي يستورد فهارس شرائح مختارة فقط من العرض المصدر.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تكون مأخوذة من إدخال المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام Master في الوجهة**

استخدم نسخة [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) عندما يجب أن تتبع الشرائح المستوردة master موجود مسبقًا في عرض التقديم الوجهة.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

يحدد Aspose.Slides layout مناسب تحت الـ master المحدد بمطابقة نوع أو اسم layout المصدر. إذا لم يكن هناك layout مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ layout المصدر لكي يمكن إضافة الشريحة. إذا كان `false`، يتم رفع استثناء [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إضافة layout إضافي إلى الـ master الوجهة.

## **دمج الشرائح باستخدام Layout محدد في الوجهة**

استخدم نسخة [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) عندما تعرف بالضبط أي layout في الوجهة يجب أن تُستخدم للشرائح المستوردة.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تطبيق layout في الوجهة يغيّر علاقة الـ layout الموروثة؛ لا يعيد تصميم محتوى الشريحة المصدر. إذا كان للـ layoutين (المصدر والوجهة) هياكل placeholder مختلفة، افحص النتيجة لتتأكد من أن التنسيق والسلوك الموروث مناسبين.

## **دمج عروض تقديمية بأحجام شرائح مختلفة**

يمكن دمج عروض تقديمية بأبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد مختلفة لا يُعيد تصميم المحتوى تلقائيًا ليتناسب مع القماش الجديد. قد تظهر الأشكال مُحَوَّلة أو مُقَدَّرة بشكل غير متوقع أو خارج مساحة الشريحة المرئية.

نهج عملي هو إعادة تحجيم العرض المصدر قبل الاستنساخ. طريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) يمكنها تحجيم المحتوى الحالي مع تغيير أبعاد الشريحة. النوع [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesizescaletype/) يُحَجِّم المحتوى ليتناسب مع الحجم المطلوب.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

إعادة التحجيم تغير كائن العرض المصدر في الذاكرة. إذا كنت بحاجة إلى إبقاء العرض المصدر الأصلي دون تغيير لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح إلى قسم في العرض**

الحلقة الأساسية لاستنساخ الشرائح لا تُعيد إنشاء هيكلية الأقسام من العرض المصدر. إذا كانت الأقسام مهمة في الناتج، أنشئ أو اختر أقسامًا في العرض الوجهة واستنسخ الشرائح إليها صراحة باستخدام [addClone(Slide, Section)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تُضاف الشرائح المستنسخة إلى القسم المحدد في الوجهة. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في الوجهة وربط كل شريحة مصدر بالقسم الوجهة المقابل.

## **دمج عروض تقديمية متعددة بأمان**

المثال الشامل التالي يستخدم العرض الأول كوجهة، يطبع حجم الشرائح لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

هذا هو أساس موثوق للحفاظ على تنسيق الشرائح المستوردة. إذا كان ناتجك بحاجة إلى موضوع (theme) واحد للوجهة، استبدل الاستدعاء البسيط `addClone(sourceSlide)` بالنسخة المناسبة التي تستخدم master أو layout في الوجهة كما هو موضح أعلاه.

## **اعتبارات عملية**

### **Masters و Layouts ودقة التنسيق**

الاستنساخ الافتراضي للشرائح يمكنه جلب الـ master المطلوب من المصدر إلى العرض الوجهة تلقائيًا. يحتفظ Aspose.Slides بسجل داخلي للـ masters المستنسخة تلقائيًا لتجنب استنساخ الـ master نفسه مرارًا. الـ masters التي تم استنساخها يدويًا لا يتم تتبعها في ذلك السجل، لذا تجنّب استنساخ الـ masters مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في بنية الـ master.

لا تفترض أن master أو layoutين يحملان نفس الاسم متطابقان بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم في المظهر النهائي، اختر master أو layout وجهة صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

الملاحظات الخاصة بالمقدم وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. يقدم Aspose.Slides أيضًا واجهات برمجة تطبيقات مخصصة لـ[presentation notes](https://docs.aspose.com/slides/ar/nodejs-java/presentation-notes/) و[presentation comments](https://docs.aspose.com/slides/ar/nodejs-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن masters الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وتعليقات السلاسل بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معالجة الموارد المدمجة والموارد المرتبطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الرابط الخارجي معتمدًا على الهدف الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

يتعقب Aspose.Slides الـ masters المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا بأن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة سيتم إلغاء تكرارها دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدمجة وقس الحجم بدلًا من الاعتماد على الإلغاء الضمني للتكرار.

### **الخطوط المدمجة وتوفر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان من الضروري الحفاظ على تناسق الطباعة عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المدمجة عبر [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](https://docs.aspose.com/slides/ar/nodejs-java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر؛ تراخيص الخطوط قد تقيد عملية الدمج.

### **العروض المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. قدّم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // التعامل مع العرض المفرغ من التشفير.
} finally {
    source.dispose();
}
```

فتح مصدر مشفر لا يطبق الحماية نفسها تلقائيًا على العرض الوجهة. اضبط حماية الإخراج بصورة منفصلة عند الحاجة.

### **العروض الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة، صوت، فيديو أو كائنات ثنائية كبيرة قد تستهلك ذاكرةً ملحوظة. توفر [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) تحكمًا في معالجة الـ BLOBs واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](https://docs.aspose.com/slides/ar/nodejs-java/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الضخمة، يفضَّل التحميل من مسارات الملفات حينما يكون ذلك ممكنًا، وتفريغ كل عرض مصدر بمجرد دمجه، وتجنّب حفظ النتائج الوسيطة بشكل متكرر ما لم يتطلب سير العمل نقاط فحص.

### **سلامة الخيوط**

لا تقم بتحميل أو حفظ أو استنساخ كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) في عدة خيوط. هذه العمليات غير مدعومة للاستخدام المتعدد الخيوط. إذا احتجت إلى تنفيذ وظائف دمج مستقلة بالتوازي، استخدم عدة عمليات منفصلة أحادية الخيط، كلٌ منها يمتلك مثاله الخاص من العروض، واتبع إرشادات [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ar/nodejs-java/multithreading/).

## **التعليمات المتكررة (FAQ)**

**كيف يمكنني الحفاظ على التصميم الأصلي لكل عرض مصدر؟**

استخدم [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) دون تحديد master أو layout للوجهة. يستطيع Aspose.Slides استنساخ الـ master المصدر تلقائيًا عندما تكون الحاجة إليه من قبل الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع (theme) الوجهة؟**

استخدم النسخة المتجاوزة التي تقبل master وجهة. مرّر master من العرض الوجهة، وليس من العرض المصدر. سيحاول Aspose.Slides ربط كل شريحة مصدر بـlayout مناسب تحت ذلك الـ master.

**متى يجب استخدام layout وجهة محدد بدلاً من master وجهة؟**

استخدم layout محدد عندما يجب أن تستخدم كل شريحة مستوردة نفس الـ layout المعروف. استخدم master عندما تريد أن يختار Aspose.Slides بين الـ layouts المتاحة للـ master بناءً على نوع أو اسم layout المصدر.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشرائح لا يُعاد تصميمه تلقائيًا لأبعاد الوجهة. احرص على تحجيم العرض المصدر مسبقًا عندما تحتاج إلى وضعية predictable، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesizescaletype/).

**هل يمكنني دمج عروض PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض وجهة واحد، واحفظ الوجهة بصيغة إخراج مدعومة. نظرًا لاختلاف مجموعة الميزات بين الصيغ، تحقق من المحتوى المعقّد بعد عمليات الدمج عبر الصيغ. راجع [Supported File Formats](https://docs.aspose.com/slides/ar/nodejs-java/supported-file-formats/).

**هل يتم الحفاظ على الأقسام المصدر تلقائيًا؟**

ليس في حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم نسخة الـ section من [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدث والتعليقات؟**

نعم، تُنسخ مع الشريحة المستنسخة. بالنسبة لسير عمل يعتمد على تنسيق master الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للملفات الصوتية والفيديوية وكائنات OLE والروابط؟**

المحتوى المدمج يُحمل كجزء من علاقات الموارد للشرائح المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تكون الملفات أو عناوين URL المستهدفة متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر مضمونة التوفر في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المدمجة في الوجهة وادارة دمج الخطوط صراحةً أو تأكد من توفر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية الإخراج بشكل منفصل.

**كيف أتعامل مع عروض تقديمية ضخمة جدًا؟**

استخدم إدارة الـ BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضّل تحميل من مسار الملف للملفات الضخمة، وتفريغ عروض المصدر بسرعة بعد دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج شرائح من عدة خيوط؟**

لا تقم بتحميل أو حفظ أو استنساخ كائنات العرض في عدة خيوط. للوظائف المستقلة المتوازية، استخدم عمليات أحادية الخيط منفصلة مع مثيلاتها المستقلة من العروض وتبع إرشادات [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ar/nodejs-java/multithreading/).
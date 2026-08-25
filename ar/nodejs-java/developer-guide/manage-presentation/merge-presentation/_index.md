---
title: دمج العروض التقديمية بفعالية في JavaScript
linktitle: دمج العروض التقديمية
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
- جمع PowerPoint
- جمع العروض التقديمية
- جمع الشرائح
- جمع PPT
- جمع PPTX
- جمع ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وعروض OpenDocument في JavaScript عن طريق استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وتغيير حجم محتوى الشرائح، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Node.js عبر Java يدمج العروض التقديمية عن طريق استنساخ الشرائح من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) إلى أخرى. العملية الأساسية هي [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)، والتي يمكنها الحفاظ على تنسيق الشريحة المصدر أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في عرض الوجهة.

تغطي هذه المقالة أكثر سير عمل دمج شائع:

- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر؛
- دمج شرائح مختارة؛
- تطبيق ماستر من عرض الوجهة؛
- تطبيق تخطيط محدد من عرض الوجهة؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة شرائح مستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل متكامل؛
- معالجة الماسترات والموارد والملاحظات والتعليقات والوسائط والخطوط وكلمات السر والملفات الكبيرة ومشكلات تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد الحمل الزائد (overload) الذي تختاره كيفية دمج الشريحة المستنسخة في عرض الوجهة.

استخدم [SlideCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) بأحد الطرق التالية:

- `addClone(sourceSlide)` — الحفاظ على تخطيط الشريحة المصدر وتنسيقها. عند الحاجة، يمكن استنساخ الماستر المصدر إلى عرض الوجهة تلقائيًا. يتتبع Aspose.Slides الماسترات المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرارًا عند وجود شرائح متعددة تستخدم نفس الماستر المصدر.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) معين في الوجهة. يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر بحسب نوع التخطيط أو اسمه.
- `addClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرة إلى [LayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) معين في الوجهة.

يجب أن يكون الماستر أو التخطيط الممرر إلى حمل `addClone` جزءًا من **عرض الوجهة**، وليس من عرض المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط عملية دمج هي نسخ كل شريحة من عرض المصدر إلى عرض الوجهة. هذا هو الخيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها الأصلي والماستر وعلاقات التخطيط الخاصة بها.

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

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والوجهة تصاميم مختلفة. وهذا متوقع عندما يُحافظ على تنسيق المصدر عمدًا.

## **دمج الشرائح المختارة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فهارس شرائح مختارة فقط من عرض المصدر.

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

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تأتي من إدخال المستخدم أو من تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم حمل [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) عندما يجب أن تتبع الشرائح المستوردة ماسترًا موجودًا بالفعل في عرض الوجهة.

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

يختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد بمطابقة نوع أو اسم التخطيط المصدر. إذا لم يكن هناك تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط المصدر حتى يمكن إضافة الشريحة. إذا كان `false`، يتم رفع استثناء [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلًا من إدخال تخطيط إضافي إلى ماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم حمل [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

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

تغيير التخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ لا يعيد تصميم محتوى الشريحة المصدر. إذا كان لتخطيطات المصدر والوجهة هياكل نائبة مختلفة، افحص النتيجة لتتأكد من أن التنسيق والسلوك النائب مناسبان.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج عروض ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأحجام شرائح مختلفة لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال منقولة أو مُحولة غير متوقعة أو خارج مساحة الشريحة المرئية.

نهج عملي هو تغيير حجم عرض المصدر قبل الاستنساخ. يمكن طريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) تعديل المحتوى الحالي أثناء تغيير أبعاد الشريحة. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesizescaletype/) يضبط المحتوى ليتناسب مع الحجم المطلوب.

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

تغيير الحجم يغير كائن عرض المصدر في الذاكرة. إذا كنت تحتاج إلى إبقاء عرض المصدر الأصلي دون تغيير لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

الحلقة الأساسية لاستنساخ الشرائح لا تعيد إنشاء هيكل الأقسام في عرض المصدر. إذا كانت الأقسام مهمة في الناتج، أنشئ أو حدد أقسامًا في عرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [addClone(Slide, Section)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

تُضاف الشرائح المستنسخة إلى القسم المحدد في الوجهة. للحفاظ على عدة أقسام مصدر، قم بجلب [Presentation.getSections](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSections)، استرجع الشرائح الحالية لكل قسم مصدر عبر [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSlidesListOfSection)، أعد إنشاء الأقسام في الوجهة، واستنسخ كل شريحة إلى القسم المقابل. راجع [Manage Slide Sections](/slides/ar/nodejs-java/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عروض تقديمية متعددة بأمان**

المثال التالي يغطي سيناريو من طرف إلى طرف يستخدم العرض الأول كوجهة، يوحد حجم الشرائح لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

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

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان ناتجك يجب أن يستخدم موضوعًا موحدًا في الوجهة، استبدل استدعاء `addClone(sourceSlide)` البسيط بالحمل المناسب للماستر أو التخطيط المذكورين سابقًا.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

يمكن أن يجلب استنساخ الشرائح الافتراضي ماستر مصدر مطلوب إلى عرض الوجهة تلقائيًا. يحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. لا يتعقب السجل الماسترات المستنسخة يدويًا، لذا تجنب استنساخ الماسترات مسبقًا ما لم تحتاج إلى سيطرة صريحة على بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متساويان بصريًا. إذا كان قالب الشركة يتحكم في المظهر النهائي، اختر ماستر أو تخطيط وجهة صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

الملاحظات والشرح المرتبط بالمتحدث والتعليقات المرتبطة بالشريحة تُنسخ مع الشريحة المستنسخة. يوفر Aspose.Slides أيضًا واجهات برمجة تطبيقات مخصصة لـ[ملاحظات العرض](/slides/ar/nodejs-java/presentation-notes/) و[تعليقات العرض](/slides/ar/nodejs-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وتعليقات السلاسل بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمرتبطة بشكل مختلف. يبقى الصوت، الفيديو، كائن OLE، أو الارتباط التشعبي المرتبط معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

يتتبع Aspose.Slides تلقائيًا الماسترات المستنسخة، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا بأن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة ستتم إزالتها دائمًا. إذا كان حجم ملف الناتج مهمًا، فافحص الحزمة المدمجة وقم بقياس النتيجة بدلاً من الاعتماد على الإزالة الضمنية.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان من الضروري الحفاظ على تنسيق النص عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل الخطوط المطلوبة في بيئة الوجهة. يمكنك فحص الخطوط المدمجة عبر [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) وإدارة دمج الخطوط صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/nodejs-java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر؛ قد تقيد تراخيص الخطوط عملية الدمج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. قدم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // العمل مع العرض المفكّك.
} finally {
    source.dispose();
}
```

فتح مصدر مشفر لا يطبق الحماية نفسها تلقائيًا على عرض الوجهة. عَيّن حماية الإخراج بشكل منفصل إذا لزم الأمر.

### **العروض الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة قد تستهلك الكثير من الذاكرة. توفر [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) تحكمًا في معالجة الـ BLOBs واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/nodejs-java/manage-blob/) لاستراتيجيات الملفات الكبيرة.

بالنسبة للملفات الضخمة، يفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، وتحرير كل عرض مصدر بمجرد دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر ما لم يتطلب سير العمل نقاط تفتيش.

### **سلامة الخيوط**

لا تقم بتحميل أو حفظ أو استنساخ كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) في عدة خيوط. هذه العمليات غير مدعومة للاستخدام متعدد الخيوط. إذا كنت بحاجة إلى موازاة مهام دمج مستقلة، استخدم عمليات منفصلة أحادية الخيط، كل منها يملك مثاله الخاص من العروض، واتبع [إرشادات تعدد الخيوط في Aspose.Slides](/slides/ar/nodejs-java/multithreading/).

## **الأسئلة الشائعة**

**كيف أحافظ على التصميم الأصلي لكل عرض مصدر؟**

استخدم [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) دون توفير ماستر أو تخطيط وجهة. يمكن لـ Aspose.Slides استنساخ ماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع الوجهة؟**

استخدم الحمل الذي يقبل ماستر الوجهة. مرّر ماسترًا من عرض الوجهة، وليس من المصدر. سيحاول Aspose.Slides مطابقة كل شريحة مصدر مع تخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلاً من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة نفس التخطيط المعروف. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides من بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشرائح لا يُعاد تصميمه تلقائيًا للأبعاد الجديدة. قم بتغيير حجم عرض المصدر أولاً عندما تحتاج إلى موضع ثابت، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesizescaletype/).

**هل يمكن دمج ملفات PPT وPPTX وODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض واحد كوجهة، واحفظ الوجهة بصيغة مدعومة. نظرًا لاختلاف مجموعات الميزات بين الصيغ، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ المختلفة. راجع [Supported File Formats](/slides/ar/nodejs-java/supported-file-formats/).

**هل يتم حفظ أقسام المصدر تلقائيًا؟**

ليس مع حلقة أساسية تنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم حمل القسم من [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدث والتعليقات؟**

نعم، تُنسخ مع الشريحة المستنسخة. بالنسبة لسير عمل يعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدموجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث لل صوت، الفيديو، كائنات OLE، والروابط التشعبية؟**

المحتوى المدمج يُنقل كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر مضمونة في العرض المدموج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المدمجة في الوجهة وأدرج الخطوط صراحةً أو تأكد من توفر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية الإخراج بشكل منفصل.

**كيف أتعامل مع عروض تقديمية ضخمة جدًا؟**

استخدم إدارة الـ BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضّل التحميل من مسار الملف للملفات الضخمة، حرّر عروض المصدر فور انتهاء دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكن دمج شرائح من عدة خيوط؟**

لا تقم بتحميل أو حفظ أو استنساخ كائنات العروض في عدة خيوط. للمهام المتوازية، استخدم عمليات منفصلة أحادية الخيط مع مثيلات عرض مستقلة.
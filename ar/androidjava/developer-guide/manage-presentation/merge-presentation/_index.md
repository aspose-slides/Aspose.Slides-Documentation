---
title: دمج العروض التقديمية بكفاءة على أندرويد
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument على أندرويد عن طريق استنساخ الشرائح، التحكم في الماسترات والتخطيطات، تغيير حجم محتوى الشرائح، الحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يدمج العروض من خلال استنساخ الشرائح من واحد [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)، والتي يمكنها الحفاظ على تنسيق الشريحة المصدر أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في عرض الوجهة.

هذا المقال يغطي أكثر سير عمل الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر.
- دمج الشرائح المحددة.
- تطبيق ماستر من عرض الوجهة.
- تطبيق تخطيط محدد من عرض الوجهة.
- تطبيع أحجام الشرائح المختلفة قبل الدمج.
- إضافة الشرائح المستنسخة إلى قسم.
- دمج عدة عروض في سير عمل شامل من البداية إلى النهاية.
- معالجة الماسترات والموارد والملاحظات والتعليقات والوسائط والخطوط وكلمات المرور والملفات الكبيرة ومشكلات تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

الشريحة ترث جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، تحدد طريقة الاستنساخ التي تختارها كيفية دمج الشريحة في عرض الوجهة.

استخدم [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) بإحدى الطرق التالية:

- `addClone(sourceSlide)` — الحفاظ على تخطيط الشريحة المصدر وتنسيقها. عند الحاجة، يمكن استنساخ ماستر المصدر إلى عرض الوجهة تلقائيًا. Aspose.Slides يتتبع الماسترات المستنسخة تلقائيًا بحيث لا تُستنسخ الماسترات نفسها مرارًا وتكرارًا للشرائح المتكررة.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى ماستر وجهة محدد [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides يبحث عن تخطيط مطابق تحت ذلك الماستر بحسب نوع التخطيط أو اسمه.
- `addClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرة إلى تخطيط وجهة محدد [ILayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/).

الماستر أو التخطيط الممرر إلى إحدى طرق `addClone` يجب أن يكون تابعًا لعرض **الوجهة**، وليس لعرض المصدر.

## **دمج العروض الكاملة والحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من عرض المصدر إلى عرض الوجهة. هذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها الأصلي والماستر وعلاقات التخطيط.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والوجهة تصاميم مختلفة. وهذا متوقع عندما يُحافظ عمداً على تنسيق المصدر.

## **دمج الشرائح المحددة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المحددة من عرض المصدر.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تحقق من فهارس الشرائح قبل الاستنساخ عندما تأتي من مدخلات المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) عندما يجب أن تتبع الشرائح المستوردة ماسترًا موجودًا بالفعل في عرض الوجهة.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides يختار تخطيطًا مناسبًا تحت الماستر المحدد عن طريق مطابقة نوع التخطيط أو اسمه من المصدر. إذا لم يتوفر تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط المصدر حتى يمكن إضافة الشريحة. إذا كان `false`، يُرمى استثناء [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إدخال تخطيط إضافي إلى ماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) عندما تعرف بدقة أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تطبيق تخطيط وجهة يغيّر علاقة التخطيط الموروثة؛ لا يُعيد تصميم محتوى الشريحة المصدر. إذا كان للتخطيطات في المصدر والوجهة بنى عناصر نائبة مختلفة، فافحص النتيجة لتتأكد من أن التنسيق الموروث وسلوك العناصر النائبة مناسبان.

## **دمج العروض بأحجام شرائح مختلفة**

يمكن دمج عروض بأبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأحجام شرائح أخرى لا يعيد تلقائيًا تصميم محتواها لتتناسب مع القماش الجديد. قد تظهر الأشكال مُزاحة أو مُقاسة بشكل غير متوقع أو خارج مساحة الشريحة المرئية.

نهج عملي هو تغيير حجم عرض المصدر قبل الاستنساخ. طريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) يمكنها تحجيم المحتوى الحالي مع تغيير أبعاد الشريحة. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesizescaletype/) تضبط المحتوى ليتناسب مع الحجم المطلوب.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تغيير الحجم يغيّر كائن عرض المصدر في الذاكرة. إذا كنت بحاجة إلى إبقاء العرض الأصلي دون تعديل لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم العرض**

حلقة استنساخ الشرائح الأساسية لا تعيد إنشاء هيكلية أقسام عرض المصدر. إذا كانت الأقسام مهمة في النتيجة، أنشئ أو اختر أقسامًا في عرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [addClone(ISlide, ISection)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

الشرائح المستنسخة تُضاف إلى القسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في الوجهة واربط كل شريحة مصدر بالقسم الوجهة المقابل.

## **دمج عدة عروض بأمان**

المثال التالي يغطي سير عمل من البداية إلى النهاية يستخدم العرض الأول كوجهة، يطبع حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان على ناتجك استخدام موضوع وجهة موحد، استبدل استدعاء `addClone(slide)` البسيط بالماستر أو التخطيط الوجهة المناسب كما هو موضح أعلاه.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

استنساخ الشرائح الافتراضي يمكنه تلقائيًا جلب ماستر المصدر المطلوب إلى عرض الوجهة. Aspose.Slides يحتفظ بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا وتكرارًا. الماسترات المستنسخة يدويًا لا يُتابعها هذا السجل، لذا تجنب استنساخ الماسترات مقدمًا ما لم تكن بحاجة إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متساويان بصريًا. إذا كان قالب الشركة يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط وجهة صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشريحة مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. Aspose.Slides يقدم أيضًا واجهات برمجة تطبيقات مخصصة لـ[presentation notes](https://docs.aspose.com/slides/ar/androidjava/presentation-notes/) و[presentation comments](https://docs.aspose.com/slides/ar/androidjava/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. لسير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وسلاسل التعليقات بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور والصوت المدمج والفيديو المدمج وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال الظاهرة فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معاملة الموارد المدمجة والموارد المرتبطة بشكل مختلف. الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يبقى معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

Aspose.Slides يتتبع الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا أن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة دائمًا ستتم إزالة التكرار. إذا كان حجم ملف النتيجة مهمًا، فافحص الحزمة المدمجة وقم بقياس النتيجة بدلًا من الاعتماد على إزالة التكرار الضمنية.

### **الخطوط المدمجة وتوافر الخطوط**

الخطوط تُدار على مستوى العرض. إذا كان من الضروري الحفاظ على تنسيق النص عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](https://docs.aspose.com/slides/ar/androidjava/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر. تراخيص الخطوط قد تقيد عملية الدمج.

### **العروض المحمية بكلمة مرور**

يجب فتح مصدر محمي بكلمة مرور بنجاح قبل أن تُستنسخ شرائحه. قدم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // العمل مع العرض المفكوك.
} finally {
    source.dispose();
}
```

فتح مصدر مشفر لا يطبق تلقائيًا نفس الحماية على عرض الوجهة.Configure الحماية للناتج بشكل منفصل عند الحاجة.

### **العروض الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة قد تستهلك ذاكرة ملحوظة. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) يوفر أدوات للتحكم في معالجة الـBLOBs واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](https://docs.aspose.com/slides/ar/androidjava/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الكبيرة، فضلًا تحميلها من مسارات الملفات عندما يكون ذلك ممكنًا، حرر كل عرض مصدر فورًا بعد دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر ما لم يتطلب سير العمل نقاط تفتيش.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) بصورة متزامنة من عدة خيوط. احفظ كل كائن عرض داخل عملية دمج واحدة. إذا قمت بتوازي مهام مستقلة، استخدم كائنات عرض مستقلة واتبع [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ar/androidjava/multithreading/).

## **الأسئلة المتكررة**

**كيف أحافظ على التصميم الأصلي لكل عرض مصدر؟**  
استخدم [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) دون تمرير ماستر أو تخطيط وجهة. يمكن لـ Aspose.Slides استنساخ ماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع الوجهة؟**  
استخدم الطريقة التي تقبل ماستر وجهة. مرّر ماسترًا من عرض الوجهة، وليس من المصدر. سيسعى Aspose.Slides لتعيين كل شريحة مصدر إلى تخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلًا من ماستر وجهة؟**  
استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة نفس التخطيط المعروف. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides بين تخطيطات ذلك الماستر بناءً على نوع أو اسم تخطيط المصدر.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**  
نعم، لكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا لأبعاد الوجهة. قم بتغيير حجم عرض المصدر أولًا عندما تحتاج إلى موضع ثابت، مثالًا باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesizescaletype/).

**هل يمكن دمج ملفات PPT و PPTX و ODP في ملف واحد؟**  
نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض وجهة واحد، ثم احفظ الوجهة بصيغة مدعومة. بما أن صيغ العروض لا تدعم جميع الميزات نفسها، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ.

**هل تُحافظ الأقسام المصدر تلقائيًا؟**  
ليس في حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم overload الخاص بالقسم في [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) عندما يجب الحفاظ على هيكلية الأقسام.

**هل تُحفظ الملاحظات والتعليقات؟**  
يتم نسخها مع الشريحة المستنسخة. لسير عمل يعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو سلاسل المراجعة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشريحة.

**ماذا يحدث للصوت والفيديو وكائنات OLE والروابط التشعبية؟**  
المحتوى المدمج يُحمل كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل الضمان أن الخطوط المدمجة من كل مصدر ستكون متاحة في العرض المدمج؟**  
لا تعتمد على استنساخ الشرائح وحده لتوزيع الخطوط. افحص الخطوط المدمجة في الوجهة وأدرج الخطوط صراحةً أو تأكد من توافر الخطوط الخارجية عندما يكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**  
افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) الصحيح، ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية النتيجة بشكل منفصل.

**كيف أتعامل مع العروض الكبيرة جدًا؟**  
استخدم إدارة الـBLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، فضلًا تحميل الملفات من مساراتها، حرّر العروض المصدرية فور الانتهاء من دمجها، واحفظ النتيجة النهائية فقط عند الضرورة.

**هل يمكن دمج الشرائح من عدة خيوط؟**  
لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحد متزامنًا عبر خيوط متعددة. حافظ على كل عملية دمج في كائن عرض مستقل.
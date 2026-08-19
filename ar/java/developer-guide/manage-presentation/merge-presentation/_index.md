---
title: دمج العروض تقديميًا بفعالية في Java
linktitle: دمج العروض تقديميًا
type: docs
weight: 40
url: /ar/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument في Java عن طريق استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وتغيير حجم محتوى الشرائح، والحفاظ على الأقسام، والتعامل مع الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Java يدمج العروض التقديمية عن طريق استنساخ الشرائح من [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) إلى أخرى. العملية الرئيسية هي [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) التي يمكنها الحفاظ على تنسيق الشريحة المصدر أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الهدف.

تغطي هذه المقالة أكثر سيناريوهات الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي;
- دمج الشرائح المحددة;
- تطبيق ماستر من العرض التقديمي الهدف;
- تطبيق تخطيط معين من العرض التقديمي الهدف;
- توحيد أحجام الشرائح المختلفة قبل الدمج;
- إضافة الشرائح المستنسخة إلى قسم;
- دمج عدة عروض تقديمية في سير عمل شامل من البداية إلى النهاية;
- التعامل مع الماسترات والموارد والملاحظات والتعليقات والوسائط والخطوط وكلمات المرور والملفات الكبيرة ومقضايا التعددية الخيطية.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة كثيرًا من مظهرها من التخطيط والماستر الخاص بها. لذلك، الاختيار الذي تقوم به للتحميل الزائد لتقنية الاستنساخ يحدد كيفية دمج الشريحة المدمجة في العرض التقديمي الهدف.

استخدم [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) بأحد الطرق التالية:

- `addClone(sourceSlide)` — حافظ على تخطيط وتنسيق الشريحة المصدر. عند الحاجة، يمكن استنساخ ماستر المصدر إلى العرض التقديمي الهدف تلقائيًا. يتعقب Aspose.Slides الماسترات المستنسخة تلقائيًا بحيث لا يتم استنساخ نفس الماستر مرارًا عند وجود شرائح مكررة تستخدمه.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى ماستر هدف محدد [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/). يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر حسب نوع التخطيط أو اسمه.
- `addClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرةً إلى تخطيط هدف محدد [ILayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/).

يجب أن يكون الماستر أو التخطيط الممرر إلى تحميل زائد `addClone` جزءًا من العرض التقديمي **الهدف**، وليس من العرض التقديمي المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض التقديمي المصدر إلى العرض التقديمي الهدف. هذا هو الاختيار المناسب عندما يجب على الشرائح المستوردة الاحتفاظ بالثيم والماستر وعلاقات التخطيط الأصلية.

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

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والهدف تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ على تنسيق المصدر عن عمد.

## **دمج الشرائح المحددة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط مؤشرات الشرائح المحددة من العرض التقديمي المصدر.

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

تحقق من صحة مؤشرات الشرائح قبل الاستنساخ عندما تكون مأخوذة من إدخال المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام ماستر هدف**

استخدم تحميل زائد [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) عندما يجب أن تتبع الشرائح المستوردة ماسترًا ينتمي بالفعل إلى العرض التقديمي الهدف.

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

يقوم Aspose.Slides باختيار تخطيط مناسب تحت الماستر المحدد عن طريق مطابقة نوع أو اسم التخطيط المصدر. إذا لم يكن هناك تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط المصدر حتى يمكن إضافة الشريحة. إذا كان `false`، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد فشل عملية الدمج بدلاً من إضافة تخطيط إضافي إلى ماستر الهدف.

## **دمج الشرائح باستخدام تخطيط هدف محدد**

استخدم تحميل زائد [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) عندما تعرف بالضبط أي تخطيط هدف يجب أن تستخدمه الشرائح المستوردة.

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

تطبيق تخطيط هدف يغيّر علاقة التخطيط الموروثة؛ لا يعيد تصميم محتوى الشريحة المصدر. إذا كان للتخطيطات المصدر والهدف هياكل مربعات نائبة مختلفة، فافحص النتيجة للتأكد من أن التنسيق الموروث وسلوك المربعات النائبة مناسبين.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج العروض التقديمية ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض تقديمي بأبعاد شريحة أخرى لا يعيد تصميم محتواها تلقائيًا لتناسب القماشة الجديدة. قد تظهر الأشكال متقلبة أو محجمة بشكل غير متوقع أو خارج مساحة الشريحة الظاهرة.

نهج عملي هو تعديل حجم العرض التقديمي المصدر قبل الاستنساخ. طريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesize/#setSize-float-float-int-) يمكنها تحجيم المحتوى الحالي مع تغيير أبعاد الشريحة. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesizescaletype/) تحجم المحتوى ليتناسب مع الحجم المطلوب.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

تغيير الحجم يغيّر كائن العرض التقديمي المصدر في الذاكرة. إذا كنت تحتاج إلى الحفاظ على العرض التقديمي المصدر الأصلي دون تغيير لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

حلقة استنساخ الشرائح الأساسية لا تعيد إنشاء هيكلية أقسام العرض التقديمي المصدر. إذا كانت الأقسام مهمة في النتيجة، أنشئ أو اختر أقسامًا في العرض التقديمي الهدف واستنسخ الشرائح إليها صراحةً باستخدام [addClone(ISlide, ISection)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

يتم إلحاق الشرائح المستنسخة بالقسم الهدف المحدد. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في العرض الهدف واربط كل شريحة مصدر بالقسم الهدف المقابل.

## **دمج عروض تقديمية متعددة بأمان**

يستخدم المثال التالي الشامل العرض التقديمي الأول كهدف، ويُقنّن حجم الشرائح لكل مصدر إضافي، ويحتفظ بكل مصدر مفتوحًا فقط أثناء النسخ، ثم يحفظ الملف النهائي مرة واحدة.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

هذا أساس مفيد للحفاظ على تنسيق المصدر للشرائح المستوردة. إذا كان يجب أن يستخدم الناتج ثيم هدف واحد، استبدل استدعاء `addClone(slide)` البسيط بتحميل زائد للماستر الهدف أو التخطيط الهدف المناسب كما هو موضح سابقًا.

## **اعتبارات عملية**

### **الماسترات والتخطيطات ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب الماستر المصدر المطلوب تلقائيًا إلى العرض التقديمي الهدف. يحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر بشكل متكرر. الماسترات المستنسخة يدويًا لا يتم تتبعها في ذلك السجل، لذا تجنب استنساخ الماسترات مسبقًا إلا إذا كان لديك حاجة للتحكم الصريح في هيكلة الماستر.

لا تفترض أن ماسترين أو تخطيطين يحملان نفس الاسم متساويان بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط هدف صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشريحة مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. كما يوفر Aspose.Slides واجهات برمجة تطبيقات مخصصة لـ [presentation notes](https://docs.aspose.com/slides/ar/java/presentation-notes/) و[presentation comments](https://docs.aspose.com/slides/ar/java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين الملفات المصدر. في عمليات المراجعة، تحقق أيضًا من مؤلفي التعليقات والتعليقات المتسلسلة بعد دمج ملفات لمؤلفين أو قوالب مختلفة.

### **الصور والصوت والفيديو وكائنات OLE والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، والصوت المدمج، والفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمرتبطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يعتمد على هدفه الخارجي؛ استنساخ شريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

يتتبع Aspose.Slides صراحة الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا أن الموارد الثنائية المتطابقة من عروض تقديمية مصدرية غير مرتبطة ستتم دائمًا إلغاء تكرارها. إذا كان حجم ملف الإخراج مهمًا، فافحص الحزمة المدمجة وقم بقياس النتيجة بدلاً من الاعتماد على إلغاء التكرار الضمني.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض التقديمي. إذا كان يجب أن تكون الطباعة متسقة عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توافر كل خط مطلوب في بيئة الهدف. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) وإدارة الإدماج صراحةً كما هو موضح في [Embed Fonts in Presentations](https://docs.aspose.com/slides/ar/java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بإدماج الخطوط المستخدمة في الملفات المصدرية. قد تقيد تراخيص الخطوط عملية الإدماج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يتم استنساخ شرائحه. قدم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكوك.
} finally {
    source.dispose();
}
```

فتح مصدر مشفر لا يطبق نفس الحماية تلقائيًا على العرض التقديمي الهدف. قم بتكوين حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستخدام الذاكرة**

العروض التقديمية الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية أخرى قد تستهلك ذاكرة كبيرة. توفر [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) أدوات للتحكم في معالجة الـ BLOB واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](https://docs.aspose.com/slides/ar/java/manage-blob/) لاستراتيجيات الملفات الكبيرة.

بالنسبة للملفات الكبيرة، فضل تحميلها من مسارات الملفات عندما يكون ذلك ممكنًا، وتخلص من كل عرض تقديمي مصدر بمجرد دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر ما لم يتطلب سير العمل نقاط تحقق.

### **أمان الخيوط**

لا تقوم بتحميل أو تعديل أو حفظ أو استنساخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) بشكل متزامن من عدة خيوط. احتفظ بكل كائن عرض تقديمي محصورًا في عملية دمج واحدة. إذا قمت بتوازية وظائف مستقلة، استخدم كائنات عرض تقديمي مستقلة واتبع إرشادات [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ar/java/multithreading/).

## **الأسئلة المتكررة**

**كيف أحافظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) دون توفير ماستر أو تخطيط هدف. يمكن لـ Aspose.Slides استنساخ ماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم ثيم الهدف؟**

استخدم التحميل الزائد الذي يقبل ماستر هدف. مرر ماسترًا من العرض التقديمي الهدف، وليس من المصدر. سيحاول Aspose.Slides ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط هدف محدد بدلاً من ماستر هدف؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا واحدًا معروفًا. استخدم ماسترًا عندما تريد من Aspose.Slides اختيار أحد تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض تقديمية بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يعاد تصميمه تلقائيًا لأبعاد الهدف. قم بتعديل حجم العرض التقديمي المصدر أولاً عندما تحتاج إلى وضعية متوقعة، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesize/#setSize-float-float-int-) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesizescaletype/).

**هل يمكن دمج عروض PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض تقديمي مصدر، استنسخ الشرائح المطلوبة إلى هدف واحد، واحفظ الهدف بتنسيق إخراج مدعوم. نظرًا لأن تنسيقات العروض لا تدعم مجموعة الميزات نفسها تمامًا، تحقق من المحتوى المعقد بعد عمليات الدمج عبر التنسيقات. راجع [Supported File Formats](https://docs.aspose.com/slides/ar/java/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**

ليس عبر حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الهدف واستخدم التحميل الزائد للقسم في [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) عندما يجب الحفاظ على هيكل الأقسام.

**هل يتم الحفاظ على ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة للعمليات التي تعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشريحة.

**ماذا يحدث للملفات الصوتية والفيديوية وكائنات OLE والروابط التشعبية؟**

يتم نقل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل تضمن الخطوط المدمجة من كل مصدر توافرها في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح وحده لتوزيع الخطوط. افحص الخطوط المدمجة في الهدف وأدر إدماج الخطوط صراحةً أو توافر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) الصحيح، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية الإخراج بشكل منفصل.

**كيف يجب أن أتعامل مع العروض التقديمية الكبيرة جدًا؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضِّل تحميل الملفات من مساراتها للملفات الضخمة جدًا، وتخلص من العروض المصدرية بسرعة، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكن دمج الشرائح من خيوط متعددة؟**

لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) واحدًا بشكل متزامن من عدة خيوط. احفظ كل عملية دمج معزولة على كائنات عرض تقديمي مستقلة.
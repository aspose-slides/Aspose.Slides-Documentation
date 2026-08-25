---
title: دمج العروض التقديمية بفعالية على Android
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
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument على Android عن طريق استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وإعادة تحجيم محتوى الشرائح، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Android عبر Java تقوم بدمج العروض التقديمية عن طريق استنساخ الشرائح من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) إلى أخرى. العملية الأساسية هي [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الهدف.

تغطي هذه المقالة أكثر سير عمل الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي؛
- دمج الشرائح المحددة؛
- تطبيق ماستر من العرض التقديمي الهدف؛
- تطبيق تخطيط محدد من العرض التقديمي الهدف؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل؛
- التعامل مع الماسترات، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، واعتبارات تعدد الخيوط.

## **كيف يؤثر استنساخ الشريحة على الماسترات والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد overload الاستنساخ الذي تختاره كيفية دمج الشريحة في العرض التقديمي الهدف.

استخدم [ISlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) بأحد الطرق التالية:

- `addClone(sourceSlide)` — الحفاظ على تخطيط الشريحة الأصلية وتنسيقها. عند الحاجة، يمكن استنساخ الماستر الأصلي إلى العرض الهدف تلقائيًا. Aspose.Slides يتتبع الماسترات المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرارًا عند وجود شرائح مكررة.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى ماستر هدف محدد من نوع [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides يبحث عن تخطيط مطابق تحت ذلك الماستر حسب نوع التخطيط أو اسمه.
- `addClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرة إلى تخطيط هدف محدد من نوع [ILayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/).

يجب أن يكون الماستر أو التخطيط الممرر إلى overload `addClone` جزءًا من العرض التقديمي **الهدف**، وليس من العرض الأصلي.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض الأصلي إلى العرض الهدف. هذا الاختيار مناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها، ماسترتها، وعلاقات التخطيط الأصلية.

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

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والهدف تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ على تنسيق المصدر عمدًا.

## **دمج الشرائح المحددة**

ليس من الضروري استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المحددة من العرض الأصلي.

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

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تكون مأخوذة من إدخال المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الهدف**

استخدم overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) عندما يجب أن تتبع الشرائح المستوردة ماسترًا يخص العرض الهدف بالفعل.

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

Aspose.Slides يختار تخطيطًا مناسبًا تحت الماستر المحدد بمطابقة نوع التخطيط الأصلي أو اسمه. إذا لم يوجد تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط الأصلي لتتم إضافة الشريحة. إذا كان `false`، يتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إضافة تخطيط إضافي إلى ماستر الهدف.

## **دمج الشرائح باستخدام تخطيط هدف محدد**

استخدم overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) عندما تعرف بالضبط أي تخطيط هدف يجب أن تستخدمه الشرائح المستوردة.

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

تطبيق تخطيط هدف يغير علاقة التخطيط الموروثة؛ لا يعيد تصميم محتوى الشريحة الأصلية. إذا كان للتخطيطات الأصلية والهدف بنية نائبي مكان مختلفة، افحص النتيجة لتتأكد من أن التنسيق الموروث وسلوك النائبي مكان مناسبين.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج عروض تقديمية بأبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأحجام شرائح أخرى لا يعيد تصميم محتواها تلقائيًا للوحة الجديدة. قد تظهر الأشكال مُحرَّكة أو مُقاسة بصورة غير متوقعة أو خارج مساحة الشريحة المرئية.

نهج عملي هو تغيير حجم العرض الأصلي قبل الاستنساخ. طريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) يمكنها تحجيم المحتوى الحالي مع تغيير أبعاد الشريحة. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesizescaletype/) يحجم المحتوى ليتناسب مع الحجم المطلوب.

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

تغيير الحجم يغيّر كائن العرض الأصلي في الذاكرة. إذا كنت تحتاج إلى ترك العرض الأصلي دون تعديل لعمليات أخرى، افتح نسخة مستقلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

الحلقة الأساسية لاستنساخ الشرائح لا تعيد إنشاء تسلسل الأقسام في العرض الأصلي. إذا كان للأقسام أهمية في الناتج، أنشئ أو حدد أقسامًا في العرض الهدف واستنسخ الشرائح إليها صراحةً باستخدام [addClone(ISlide, ISection)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

يتم إلحاق الشرائح المستنسخة بالقسم الهدف المحدد. للحفاظ على عدة أقسام مصدر، استدعِ [Presentation.getSections](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSections--)، احصل على الشرائح الحالية لكل قسم مصدر باستخدام [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)، أعد إنشاء الأقسام في الهدف، واستنسخ كل شريحة إلى القسم المقابل. راجع [Manage Slide Sections](/slides/ar/androidjava/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عروض تقديمية متعددة بأمان**

المثال التالي شامل يستخدم العرض الأول كهدف، يُوحد حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

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

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان على الناتج استخدام موضوع واحد للهدف، استبدل استدعاء `addClone(slide)` البسيط بالـ overload المناسب للماستر أو التخطيط الهدف كما هو موضح أعلاه.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب ماستر المصدر المطلوب تلقائيًا إلى العرض الهدف. Aspose.Slides يحتفظ بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. الماسترات المستنسخة يدويًا لا يتتبعها هذا السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت تحتاج إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متساويان بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط هدف صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشريحة مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. Aspose.Slides يوفّر أيضًا واجهات برمجة تطبيقات مخصصة لـ [presentation notes](/slides/ar/androidjava/presentation-notes/) و[presentation comments](/slides/ar/androidjava/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدموج لأن ماسترات الملاحظات هي كائنات على مستوى العرض قد تختلف بين الملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات والتعليقات المتسلسلة بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال الظاهرة فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمرتبطة بصورة مختلفة. الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يظل معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدموج.

Aspose.Slides يتتبع بوضوح الماسترات المستنسخة تلقائيًا، لكن لا يجوز اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة ستتم إزالتها دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدموجة وقِس النتيجة بدلًا من الاعتماد على الإزالة الضمنية.

### **الخطوط المضمنة وتوفر الخطوط**

يتم إدارة الخطوط على مستوى العرض. إذا كان يجب أن يبقى التنضيد متسقًا بين الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الهدف. يمكنك فحص الخطوط المضمَّنة باستخدام [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) وإدارة التضمين صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/androidjava/embedded-font/).

تحقق أيضًا من أنك مسموح لك بتضمين الخطوط المستخدمة في الملفات المصدر. قد تحد تراخيص الخطوط من إمكانية التضمين.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. وزّع كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكك.
} finally {
    source.dispose();
}
```

فتح مصدر مشفّر لا يطبق الحماية نفسها تلقائيًا على العرض الهدف. اضبط حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية ضخمة قد تستهلك ذاكرة كبيرة. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) يوفر تحكمًا في إدارة الـ BLOB واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/androidjava/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الكبيرة، فضلًا تحميلها من مسارات الملفات عندما يكون ذلك ممكنًا، حرّر كل عرض مصدر فور دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر إلا إذا استدعى سير العمل نقاط فحص.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) متزامنًا من عدة خيوط. حافظ على كل كائن عرض محصورًا في عملية دمج واحدة. إذا قمت بتوازية وظائف مستقلة، استخدم كائنات عرض مستقلة وتبع إرشادات [Aspose.Slides multithreading guidance](/slides/ar/androidjava/multithreading/).

## **الأسئلة المتكررة**

**كيف أحافظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) دون تزويد ماستر أو تخطيط هدف. يمكن لـ Aspose.Slides استنساخ الماستر الأصلي تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع العرض الهدف؟**

استخدم overload الذي يقبل ماستر هدف. مرّر ماسترًا من العرض الهدف، وليس من المصدر. سيحاول Aspose.Slides ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط هدف محدد بدلاً من ماستر هدف؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم جميع الشرائح المستوردة تخطيطًا واحدًا معروفًا. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط الأصلي.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا لأبعاد الهدف. قم بتغيير حجم العرض الأصلي أولًا عندما تحتاج إلى وضعية متوقعة، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesizescaletype/).

**هل يمكن دمج ملفات PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض هدف واحد، واحفظ الهدف بصيغة مدعومة. نظرًا لاختلاف مجموعة الميزات بين الصيغ، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ المختلفة. راجع [Supported File Formats](/slides/ar/androidjava/supported-file-formats/).

**هل تُحفظ أقسام المصدر تلقائيًا؟**

ليس في الحلقة الأساسية التي تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في العرض الهدف واستخدم overload القسم من [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير العمل الذي يعتمد على نمط ماستر الملاحظات أو مؤلفي التعليقات أو البيانات المتسلسلة، تحقق من النتيجة المدموجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للملفات الصوتية والفيديوية وكائنات OLE والروابط التشعبية؟**

المحتوى المدمج يُنقل كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل تضمن الخطوط المضمنة من كل مصدر توفرها في العرض المدموج؟**

لا تعتمد على استنساخ الشرائح فقط لتوزيع الخطوط. افحص الخطوط المضمَّنة في الهدف وأدرج الخطوط يدويًا أو تأكد من توفرها خارجيًا عندما يكون التنضيد مهمًا.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) الصحيح، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية الإخراج بصورة منفصلة.

**كيف أتعامل مع العروض الكبيرة؟**

استخدم إدارة الـ BLOB عندما تسيطر الكائنات الثنائية الكبيرة على استهلاك الذاكرة، فضلًا تحميل الملفات من المسارات عندما تكون كبيرة جدًا، حرّر عروض المصدر سريعًا، واحفظ النتيجة النهائية فقط عندما يكون ذلك ضروريًا.

**هل يمكن دمج الشرائح من عدة خيوط؟**

لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحدًا بشكل متزامن من خيوط متعددة. حافظ على كل عملية دمج معزولة في كائنات عرض مستقلة.
---
title: دمج العروض التقديمية بفعالية في Python عبر Java
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-java/merge-presentation/
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
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية دمج عروض PowerPoint و OpenDocument في Python عبر Java عن طريق استنساخ الشرائح، التحكم بالماسترات والتخطيطات، تعديل حجم محتوى الشرائح، الحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يدمج العروض التقديمية عن طريق استنساخ الشرائح من عرض تقديمي [العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة بماستر أو تخطيط في عرض الوجهة.

يتناول هذا المقال أكثر سيناريوهات الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر؛
- دمج شرائح مختارة؛
- تطبيق ماستر من عرض الوجهة؛
- تطبيق تخطيط محدد من عرض الوجهة؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل من البداية إلى النهاية؛
- معالجة الماسترات، والموارد، والملاحظات، والتعليقات، والوسائط، والخطوط، وكلمات المرور، والملفات الكبيرة، ومخاوف تعدد الخيوط.

## **كيف يؤثر استنساخ الشريحة على الماستر والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لذلك، يحدد نوع التحميل (overload) الذي تختاره كيفية دمج الشريحة المستنسخة في عرض الوجهة.

استخدم [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) بأحد الطرق التالية:

- `addClone(source_slide)` — الحفاظ على تخطيط الشريحة الأصلية وتنسيقها. عند الحاجة، يمكن استنساخ الماستر المصدر تلقائيًا إلى عرض الوجهة. Aspose.Slides يتتبع الماسترات المستنسخة تلقائيًا حتى لا يُستنسخ نفس الماستر مرارًا وتكرارًا.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — إرفاق الشريحة المستنسخة بماستر وجهة محدد [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/). يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر بناءً على نوع التخطيط أو اسمه.
- `addClone(source_slide, destination_layout)` — إرفاق الشريحة المستنسخة مباشرةً بتخطيط وجهة محدد [LayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/).

يجب أن يكون الماستر أو التخطيط الممرَّر إلى تحميل `addClone` تابعًا لـ **عرض الوجهة**، وليس لعرض المصدر.

## **دمج العروض بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من عرض المصدر إلى عرض الوجهة. هذا هو الاختيار المناسب عندما ينبغي أن تحتفظ الشرائح المستوردة بموضوعها الأصلي والماستر وعلاقات التخطيط الخاصة بها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم كل من المصدر والوجهة تصاميم مختلفة. وهذا متوقع عندما يتم الحفاظ عن قصد على تنسيق المصدر.

## **دمج شرائح مختارة**

ليس من الضروري استنساخ كل شريحة. المثال التالي يستورد فهارس شرائح محددة فقط من عرض المصدر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تكون مدخلات من المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم تحميل [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما يجب أن تتبع الشرائح المستوردة ماسترًا يخص عرض الوجهة بالفعل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

يقوم Aspose.Slides باختيار تخطيط مناسب تحت الماستر المحدد عن طريق مطابقة نوع أو اسم التخطيط المصدر. إذا لم يتوفر تخطيط مناسب وكان `allow_clone_missing_layout` هو `True`، يتم استنساخ التخطيط المصدر حتى تُضاف الشريحة. إذا كان `False`، يتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/).

استخدم `False` عندما تريد أن يفشل الدمج بدلاً من إضافة تخطيط إضافي إلى ماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم تحميل [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

تطبيق تخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ لكنه لا يعيد تصميم محتوى الشريحة المصدر. إذا كان للتخطيطات المصدر والوجهة هياكل عنصر نائبة مختلفة، فافحص النتيجة للتأكد من أن التنسيق الموروث وسلوك العناصر النائبة ملائمين.

## **دمج عروض بأحجام شرائح مختلفة**

يمكن دمج عروض ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد شريحة أخرى لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال م.shifted أو مُقاسة بشكل غير متوقع أو خارج مساحة الشريحة المرئية.

نهج عملي هو تعديل حجم عرض المصدر قبل الاستنساخ. يمكن لطريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#setSize) تعديل المحتوى الموجود مع تغيير أبعاد الشريحة. تُقوِّم [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/) المحتوى ليتناسب مع الحجم المطلوب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

تغيّر عملية تعديل الحجم كائن عرض المصدر في الذاكرة. إذا كنت تحتاج إلى الحفاظ على عرض المصدر الأصلي لاستخدامات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم عرض**

الحلقة الأساسية لاستنساخ الشرائح لا تعيد إنشاء التسلسل الهرمي لأقسام عرض المصدر. إذا كانت الأقسام مهمة في النتيجة، أنشئ أو اختر أقسامًا في عرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

يتم إلحاق الشرائح المستنسخة بالقسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، استدعِ [Presentation.getSections](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSections)، استخرج الشرائح الحالية لكل قسم مصدر عبر [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection)، أعد إنشاء الأقسام في الوجهة، واستنسخ كل شريحة مُسترجعة إلى قسمها الوجهة المقابل. راجع [Manage Slide Sections](/slides/ar/python-java/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عروض متعددة بأمان**

المثال التالي يغطي سير عمل من البداية إلى النهاية يستخدم العرض الأول كوجهة، يُوحِّد حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان على المخرج استخدام موضوع واحد للوجهة، استبدل استدعاء `addClone(slide)` البسيط بتحميل الماستر أو التخطيط الوجهة المناسب كما هو موضح سابقًا.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

الاستنساخ الافتراضي للشرائح يمكنه تلقائيًا جلب ماستر مصدر مطلوب إلى عرض الوجهة. Aspose.Slides يحتفظ بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. الماسترات المستنسخة يدويًا لا تُتَتبع في هذا السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متطابقان بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط وجهة صريحًا وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشريحة مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. Aspose.Slides يوفر أيضًا واجهات برمجة تطبيقات مخصصة لـ [ملاحظات العرض](/slides/ar/python-java/presentation-notes/) و[تعليقات العرض](/slides/ar/python-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وسلسلة التعليقات بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن أن تشير الشرائح إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال الظاهرة فقط لكي تتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمرتبطة بطريقة مختلفة. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط الخارجي معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الروابط والـ URLs في البيئة التي سيُفتح فيها العرض المدمج.

Aspose.Slides يتعقب الماسترات المستنسخة تلقائيًا، لكن لا يجب اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة سيتم دمجها دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدمجة وقس النتيجة بدلاً من الاعتماد على دمج ضمني.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان لابد من اتساق الطباعة عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المدمجة عبر [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/python-java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر. قد تقيد تراخيص الخطوط عملية الدمج.

### **العروض المحمية بكلمة مرور**

يجب فتح مصدر محمي بكلمة مرور بنجاح قبل أن تُستنسخ شرائحه. قدِّم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # العمل مع العرض التقديمي المفكوك.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

فتح مصدر مشفر لا يطبق تلقائيًا نفس الحماية على عرض الوجهة. اضبط حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة قد تستهلك ذاكرة كبيرة. يوفر [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) تحكمًا في معالجة الـ BLOB والملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/python-java/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الكبيرة، فضل تحميلها من مسارات الملفات عندما يكون ذلك ممكنًا، حرِّر كل عرض مصدر فور الانتهاء من دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر إلا إذا تطلب سير العمل نقاط تفتيش.

### **سلامة الخيوط**

لا تحمِّل أو تعدِّل أو تحفظ أو تستنسخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) من عدة خيوط في آن واحد. احتفظ بكل كائن عرض ضمن عملية دمج واحدة. إذا قمت بتوازية مهام مستقلة، استخدم كائنات عرض مستقلة وتبع إرشادات [Aspose.Slides multithreading guidance](/slides/ar/python-java/multithreading/).

## **الأسئلة الشائعة**

**كيف أحافظ على التصميم الأصلي لكل عرض مصدر؟**

استخدم [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) بدون توفير ماستر أو تخطيط وجهة. يمكن لـ Aspose.Slides استنساخ الماستر المصدر تلقائيًا عندما يحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع الوجهة؟**

استخدم التحميل الذي يقبل ماستر وجهة. مرّر ماسترًا من عرض الوجهة، وليس من المصدر. سيحاول Aspose.Slides مطابقة كل شريحة مصدر لتخطيط مناسب تحت هذا الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلًا من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides من بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يُعيد تصميمه تلقائيًا لأبعاد الوجهة. عدّل حجم عرض المصدر أولًا عندما تحتاج إلى موضع ثابت، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#setSize) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/).

**هل يمكن دمج ملفات PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض وجهة واحد، واحفظ الوجهة بصيغة مدعومة. نظرًا لاختلاف مجموعات الميزات بين الصيغ، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ. راجع [Supported File Formats](/slides/ar/python-java/supported-file-formats/).

**هل يتم حفظ أقسام المصدر تلقائيًا؟**

لا، ليس في حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم تحميل القسم من [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما يجب الحفاظ على هيكل الأقسام.

**هل تُحفظ الملاحظات والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير عمل يعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو مراجعات الخيوط، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشريحة.

**ماذا يحدث للصوت والفيديو وكائنات OLE والروابط التشعبية؟**

يُحمل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تظل ملفاتها أو عناوين URL الخاصة بها متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر مضمونة التوفر في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح وحده لنشر الخطوط. افحص الخطوط المدمجة في الوجهة وادِر دمج الخطوط صراحةً أو تأكد من توافر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword) الصحيح، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية الإخراج بشكل منفصل.

**كيف أتعامل مع عروض تقديمية كبيرة جدًا؟**

استخدم إدارة الـ BLOB عندما تكون الكائنات الثنائية الكبيرة هي المسيطر الرئيسي على استهلاك الذاكرة، فضلًا عن التحميل من مسارات الملفات للملفات الضخمة، حرِّر عروض المصدر فور الانتهاء من دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكن دمج الشرائح من عدة خيوط؟**

لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحدًا بشكل متزامن من خيوط متعددة. احتفظ بكل عملية دمج معزولة على كائنات عرض مستقلة.
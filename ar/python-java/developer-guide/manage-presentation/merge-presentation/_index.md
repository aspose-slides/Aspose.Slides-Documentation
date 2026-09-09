---
title: دمج العروض التقديمية بكفاءة في Python عبر Java
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
description: "تعرف على كيفية دمج عروض PowerPoint وعروض OpenDocument في Python عبر Java عبر استنساخ الشرائح، والتحكم في الماسترات والتخطيطات، وإعادة تحجيم محتوى الشريحة، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يجمع العروض التقديمية عن طريق استنساخ الشرائح من [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الهدف.

هذه المقالة تغطي أكثر سيرات العمل شيوعًا للدمج:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي؛
- دمج الشرائح المحددة؛
- تطبيق ماستر من العرض التقديمي الهدف؛
- تطبيق تخطيط محدد من العرض التقديمي الهدف؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل؛
- معالجة الماسترات، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومشكلات التعددية.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة الكثير من مظهرها من تخطيطها والماستر الخاص بها. لهذا السبب، تحدد الدالة الزائدة (overload) التي تختارها كيفية دمج الشريحة المدموجة في العرض التقديمي الهدف.

استخدم [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) بإحدى الطرق التالية:

- `addClone(source_slide)` — يحافظ على تخطيط الشريحة الأصلية وتنسيقها. عند الحاجة، يمكن استنساخ الماستر الأصلي إلى العرض الهدف تلقائيًا. تتعقب Aspose.Slides الماسترات المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرَّات متعددة عند وجود شرائح مكررة تستخدم نفس الماستر.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — إرفاق الشريحة المستنسخة إلى ماستر هدف محدد [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/). تبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر بناءً على نوع التخطيط أو اسمه.
- `addClone(source_slide, destination_layout)` — إرفاق الشريحة المستنسخة مباشرةً إلى تخطيط هدف محدد [LayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/).

يجب أن يكون الماستر أو التخطيط الممرر إلى دالة `addClone` تابعة للعرض التقديمي **الهدف**، وليس للعرض الأصلي.

## **دمج العروض التقديمية بالكامل والحفاظ على تنسيق المصدر**

أبسط عملية دمج تنسخ كل شريحة من العرض التقديمي الأصلي إلى العرض الهدف. هذا هو الاختيار المناسب عندما يجب على الشرائح المستوردة الحفاظ على السمة الأصلية والماستر وعلاقات التخطيط.

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

قد يحتوي العرض الناتج على عدة ماسترات عندما يستخدم المصدر والهدف تصاميم مختلفة. وهذا متوقع عندما يتم الحفاظ على تنسيق المصدر عن قصد.

## **دمج الشرائح المحددة**

لا تحتاج إلى استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المحددة من العرض الأصلي.

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

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تأتي من إدخال المستخدم أو إعداد خارجي.

## **دمج الشرائح باستخدام ماستر هدف**

استخدم الدالة الزائدة [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما يجب على الشرائح المستوردة اتباع ماستر موجود بالفعل في العرض التقديمي الهدف.

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

تختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد من خلال مطابقة نوع أو اسم التخطيط الأصلي. إذا لم يوجد تخطيط مناسب وكان `allow_clone_missing_layout` يساوي `True`، يتم استنساخ التخطيط الأصلي حتى يمكن إضافة الشريحة. إذا كان `False`، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/).

استخدم `False` عندما ترغب في فشل الدمج بدلاً من إضافة تخطيط إضافي إلى الماستر الهدف.

## **دمج الشرائح باستخدام تخطيط هدف محدد**

استخدم الدالة الزائدة [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما تعرف بالضبط أي تخطيط هدف يجب أن تستخدمه الشرائح المستوردة.

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
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

تطبيق تخطيط هدف يغير علاقة التخطيط الموروثة؛ لكنه لا يعيد تصميم محتوى الشريحة الأصلية. إذا كان للتخطيطات الأصلية والهدف هياكل نائبة مختلفة، قم بفحص النتيجة للتأكد من أن التنسيق الموروث وسلوك النائب مناسب.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج العروض التقديمية ذات أبعاد شرائح متنوعة، ولكن استنساخ شريحة إلى عرض بأبعاد شريحة مختلفة لا يعيد تصميم محتواها تلقائيًا للوحة الجديدة. لذلك قد تظهر الأشكال محوَّلة، أو مُقاسة بشكل غير متوقع، أو خارج منطقة الشريحة المرئية.

نهج عملي هو إعادة حجم العرض الأصلي قبل الاستنساخ. يمكن للطريقة [SlideSize.setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#setSize) أن تُعيد مقياس المحتوى الحالي مع تغيير أبعاد الشريحة. تقوم [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/) بتوسيع المحتوى ليناسب الحجم المطلوب.

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

تغيير الحجم يغيّر كائن العرض الأصلي في الذاكرة. إذا كنت بحاجة إلى الحفاظ على العرض الأصلي دون تغيير لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

حلقة استنساخ الشرائح الأساسية لا تعيد إنشاء تسلسل أقسام العرض الأصلي. إذا كانت الأقسام ذات أهمية في الناتج، أنشئ أو اختر أقسامًا في العرض الهدف واستنسخ الشرائح إليها صراحةً باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone).

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

تُضاف الشرائح المستنسخة إلى القسم الهدف المحدد. للحفاظ على عدة أقسام مصدر، قم بعدّ [Presentation.getSections](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSections)، استرجع الشرائح الحالية لكل قسم مصدر باستخدام [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection)، أعد إنشاء الأقسام في العرض الهدف، واستنسخ كل شريحة تم إرجاعها إلى قسمها المقابل في العرض الهدف. راجع [Manage Slide Sections](/slides/ar/python-java/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عدة عروض تقديمية بأمان**

المثال التالي شامل من البداية إلى النهاية يستخدم العرض الأول كهدف، يطبع حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

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

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة من المصدر. إذا كان الناتج يجب أن يستخدم سمة هدف واحدة، استبدل استدعاء `addClone(slide)` البسيط بالدالة الزائدة للماستر الهدف أو التخطيط الهدف كما هو موضح سابقًا.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب تلقائيًا ماستر المصدر المطلوب إلى العرض الهدف. تحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. لا يتم تتبع الماسترات المستنسخة يدويًا في ذلك السجل، لذا تجنب استنساخ الماسترات مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في هيكل الماستر.

لا تفترض أن ماسترين أو تخطيطين يحملان نفس الاسم متساويان بصريًا. إذا كان قالب الشركة يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط هدف صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. كما توفر Aspose.Slides واجهات برمجة تطبيقات مخصصة لـ [presentation notes](/slides/ar/python-java/presentation-notes/) و[presentation comments](/slides/ar/python-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمجة لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في عمليات المراجعة، تحقق أيضًا من مؤلفي التعليقات وسلاسل التعليقات بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى تستطيع Aspose.Slides الحفاظ على علاقة الشريحة بمواردها.

يجب التعامل مع الموارد المدمجة والمربوطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يعتمد على هدفه الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

تتبع Aspose.Slides بوضوح الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًّا بأن الموارد الثنائية المتطابقة من عروض مصدر غير مرتبطة سيتم دائمًا حذف التكرار. إذا كان حجم الملف الناتج مهمًا، افحص الحزمة المدمجة وقم بقياس النتيجة بدلاً من الاعتماد على حذف التكرار الضمني.

### **الخطوط المدمجة وتوافر الخطوط**

يتم إدارة الخطوط على مستوى العرض. إذا كان يجب أن يظل التنسيق ثابتًا عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الهدف. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts)، وإدارة الإدماج صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/python-java/embedded-font/).

كما تحقق من أنك مسموح لك بإدماج الخطوط المستخدمة في ملفات المصدر. قد تقيّد تراخيص الخطوط عملية الإدماج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شُرُحه. قدّم كلمة المرور عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword).

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
    # العمل مع العرض المفكوك.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

فتح مصدر مشفّر لا يطبق تلقائيًا نفس الحماية على العرض الهدف. قم بتكوين حماية المخرجات بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستهلاك الذاكرة**

العروض التقديمية الكبيرة التي تحتوي على صور عالية الدقة، صوت، فيديو أو كائنات ثنائية كبيرة أخرى قد تستهلك ذاكرة كبيرة. يوفر [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) ضوابط للتعامل مع BLOB واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/python-java/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الكبيرة، يُفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، وتخلص من كل عرض مصدر فور دمجه، وتجنّب حفظ النتائج الوسيطة بشكل متكرر إلا إذا كان سير العمل يتطلب نقاط تفتيش.

### **سلامة الخيوط**

لا تقوم بتحميل أو تعديل أو حفظ أو استنساخ نفس كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) concurrently من عدة خيوط. احتفظ بكل كائن عرض ضمن عملية دمج واحدة. إذا قمت بالتوازي بين مهام مستقلة، استخدم كائنات عرض مستقلة واتبع إرشادات [Aspose.Slides multithreading guidance](/slides/ar/python-java/multithreading/).

## **الأسئلة الشائعة**

**كيف أحافظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**  
استخدم [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) دون تزويد ماستر أو تخطيط هدف. يمكن لـ Aspose.Slides استنساخ الماستر الأصلي تلقائيًا عندما تكون الشريحة المستوردة بحاجة إليه.

**كيف أجعل الشرائح المستوردة تستخدم سمة العرض الهدف؟**  
استخدم الدالة الزائدة التي تقبل ماستر هدف. مرّر ماسترًا من العرض الهدف، وليس من المصدر. ستحاول Aspose.Slides ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط هدف محدد بدلاً من ماستر هدف؟**  
استخدم تخطيطًا محددًا عندما يجب على كل شريحة مستوردة استخدام تخطيط واحد معروف. استخدم ماسترًا عندما تريد أن تختار Aspose.Slides بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط الأصلي.

**هل يمكن دمج عروض تقديمية بأحجام شرائح مختلفة؟**  
نعم، لكن محتوى الشريحة لا يتم إعادة تصميمه تلقائيًا لأبعاد الهدف. أعد تحجيم العرض الأصلي أولًا عندما تحتاج إلى موضعية متوقعة، على سبيل المثال باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#setSize) و[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/).

**هل يمكن دمج ملفات PPT و PPTX و ODP في ملف واحد؟**  
نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض هدف واحد، واحفظ الهدف بتنسيق مدعوم. نظرًا لأن تنسيقات العروض لا تدعم نفس مجموعة الميزات بالضبط، تحقق من المحتوى المعقد بعد عمليات الدمج عبر التنسيقات. راجع [Supported File Formats](/slides/ar/python-java/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**  
ليس عبر حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في العرض الهدف واستخدم الدالة الزائدة للقسم في [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدث والتعليقات؟**  
يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير العمل التي تعتمد على تنسيق ماستر الملاحظات، أو مؤلفي التعليقات، أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للملفات الصوتية، الفيديو، كائنات OLE، والروابط التشعبية؟**  
يتم نقل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تظل خارجية، لذا يجب أن تكون ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل تضمن الخطوط المدمجة من كل مصدر أن تكون متاحة في العرض المدمج؟**  
لا تعتمد على استنساخ الشرائح وحده لتوزيع الخطوط. افحص الخطوط المدمجة في العرض الهدف وأدر إدماج الخطوط صراحةً أو تأكد من توفر الخطوط الخارجية عندما يكون التنسيق مهمًا.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**  
افتحه باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setPassword) الصحيح، ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية المخرجات بشكل منفصل.

**كيف أتعامل مع العروض التقديمية الكبيرة جدًا؟**  
استخدم إدارة BLOB عندما تت dominate كائنات ثنائية كبيرة استهلاك الذاكرة، وفضّل التحميل من مسار الملف للملفات الكبيرة جدًا، وتخلص من عروض المصدر بسرعة، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكن دمج الشرائح من عدة خيوط؟**  
لا تستخدم كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحدًا بشكل متزامن من عدة خيوط. احتفظ بكل عملية دمج معزولة إلى كائنات عرض خاصة بها.
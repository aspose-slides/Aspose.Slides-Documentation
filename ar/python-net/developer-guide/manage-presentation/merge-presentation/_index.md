---
title: دمج العروض التقديمية بفعالية باستخدام بايثون
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-net/merge-presentation/
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
- Aspose.Slides
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument في بايثون عن طريق استنساخ الشرائح، التحكم في الماسترات والتخطيطات، تعديل حجم محتوى الشرائح، الحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يدمج العروض التقديمية عن طريق استنساخ الشرائح من [العرض](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) إلى آخر. العملية الرئيسية هي [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)، والتي يمكنها الحفاظ على تنسيق الشريحة الأصلية أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض الوجهة.

تغطي هذه المقالة أكثر سير عمل الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر؛
- دمج شرائح مختارة؛
- تطبيق ماستر من العرض الوجهة؛
- تطبيق تخطيط محدد من العرض الوجهة؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل نهائي شامل؛
- معالجة الماسترات، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومخاوف تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماسترات والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد عبء الاستنساخ الذي تختاره كيفية دمج الشريحة المدمجة في العرض الوجهة.

استخدم [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) بأحد الطرق التالية:

- `add_clone(source_slide)` — الحفاظ على تخطيط الشريحة الأصلية وتنسيقها. عند الحاجة، يمكن استنساخ الماستر الأصلي إلى العرض الوجهة تلقائيًا. Aspose.Slides يتعقب الماسترات المستنسخة تلقائيًا بحيث لا تتكرر عملية الاستنساخ لنفس الماستر.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — إرفاق الشريحة المستنسخة إلى [IMasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/) محدد في الوجهة. Aspose.Slides يبحث عن تخطيط مطابق تحت ذلك الماستر وفقًا لنوع التخطيط أو اسمه.
- `add_clone(source_slide, destination_layout)` — إرفاق الشريحة المستنسخة مباشرة إلى [ILayoutSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilayoutslide/) محدد في الوجهة.

يجب أن ينتمي الماستر أو التخطيط الممرّر إلى **العرض الوجهة**، وليس إلى العرض المصدر.

## **دمج العروض الكاملة مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض المصدر إلى العرض الوجهة. هذا هو الخيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها، ماسترها، وعلاقات التخطيط الأصلية.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

قد يحتوي العرض الناتج على عدة master عندما يستخدم المصدر والوجهة تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ عمدًا على تنسيق المصدر.

## **دمج شرائح مختارة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المختارة من العرض المصدر.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

تحقق من فهارس الشرائح قبل الاستنساخ عندما تكون مأخوذة من مدخلات المستخدم أو من تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم overload ‎[add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)‎ عندما يجب أن تتبع الشرائح المستوردة ماسترًا موجودًا بالفعل في العرض الوجهة.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides يختار تخطيطًا مناسبًا تحت الماستر المحدد بمطابقة نوع أو اسم التخطيط الأصلي. إذا لم يوجد تخطيط مناسب وكان `allow_clone_missing_layout` يساوي `True`، يتم استنساخ التخطيط الأصلي حتى يمكن إضافة الشريحة. إذا كان `False`، تُطرح استثناء ‎[PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/)‎.

استخدم `False` عندما تريد أن يفشل الدمج بدلاً من إدخال تخطيط إضافي إلى الماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم overload ‎[add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)‎ عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

تطبيق تخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ لكنه لا يعيد تصميم محتوى الشريحة الأصلية. إذا كان للتخطيطات في المصدر والوجهة هياكل نائبة مختلفة، فافحص النتيجة للتأكد من أن التنسيق الموروث وسلوك النائبة مناسبان.

## **دمج العروض بأحجام شرائح مختلفة**

يمكن دمج عروض ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد أخرى لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال مُحَّوَّلة، مُقاسة بشكل غير متوقع، أو خارج مساحة الشريحة الظاهرة.

نهج عملي هو تغيير حجم العرض المصدر قبل الاستنساخ. يمكن للطريقة ‎[SlideSize.set_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/set_size/)‎ أن تُعيد تحجيم المحتوى الحالي أثناء تغيير أبعاد الشريحة. ‎[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesizescaletype/)‎ يُعيد تحجيم المحتوى ليتناسب مع الحجم المطلوب.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

تغيير الحجم يُعدّل كائن العرض المصدر في الذاكرة. إذا كنت تحتاج إلى إبقاء العرض المصدر الأصلي كما هو لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض**

الحلقة الأساسية لاستنساخ الشرائح لا تُعيد إنشاء تسلسل الأقسام في العرض المصدر. إذا كانت الأقسام مهمة في المخرجات، أنشئ أو اختر أقسامًا في العرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام ‎[SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)‎.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

تُضاف الشرائح المستنسخة إلى القسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في الوجهة باستخدام ‎[SectionCollection.append_empty_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/append_empty_section/)‎ واربط كل شريحة مصدر بالقسم الوجهة المقابل.

## **دمج عروض متعددة بأمان**

المثال التالي يغطي سير عمل نهائي يستخدم العرض الأول كوجهة، يُوحّد حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان يجب أن يستخدم الناتج موضوعًا واحدًا للوجهة، استبدل نداء ‎`add_clone(slide)`‎ البسيط بـ overload الماستر أو التخطيط الوجهة المناسب الموضح سابقًا.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

الاستنساخ الافتراضي للشرائح يمكنه إحضار ماستر مصدر مطلوب إلى العرض الوجهة تلقائيًا. Aspose.Slides يحتفظ بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. الماسترات المستنسخة يدويًا لا يتم تتبعها في ذلك السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متطابقين بصريًا. إذا كان القالب المؤسسي يجب أن يتحكم بالمظهر النهائي، اختر ماستر أو تخطيط وجهة صريحًا وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. Aspose.Slides يوفر أيضًا واجهات برمجة تطبيقات مخصصة لـ [ملاحظات العرض](https://docs.aspose.com/slides/ar/python-net/presentation-notes/) و[تعليقات العرض](https://docs.aspose.com/slides/ar/python-net/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وسلاسل التعليقات بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المضمّن، الفيديو المضمّن، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب التعامل مع الموارد المضمَّنة والمرتبطة بشكل مختلف. الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يبقى معتمدًا على الهدف الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مضمّن. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفُتَح فيها العرض المدمج.

Aspose.Slides يتعقب الماسترات المستنسخة تلقائيًا، لكن لا يجب اعتبار ذلك ضمانًا عامًّا بأن الموارد الثنائية المتطابقة من مصادر مختلفة ستُدمَّج دائمًا. إذا كان حجم ملف الناتج مهمًا، افحص الحزمة المدمجة وقِس النتيجة بدلاً من الاعتماد على الدمج الضمني.

### **الخطوط المضمَّنة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان يجب أن يبقى تنسيق النص ثابتًا عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل الخطوط المطلوبة في بيئة الوجهة. يمكنك فحص الخطوط المضمَّنة باستخدام ‎[FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)‎ وإدارة التضمين صراحةً كما هو موضح في [تضمين الخطوط في العروض](https://docs.aspose.com/slides/ar/python-net/embedded-font/).

تحقق أيضًا من أنك مسموح لك بتضمين الخطوط المستخدمة في ملفات المصدر. قد تقيد تراخيص الخطوط عملية التضمين.

### **العروض المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل استنساخ شرائحه. زوّد كلمة المرور عبر ‎[LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/)‎.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

فتح مصدر مُشفَّر لا يطبق الحماية نفسها تلقائيًا على العرض الوجهة. قم بتكوين حماية المخرج بشكل منفصل عند الحاجة.

### **العروض الكبيرة واستهلاك الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة، صوت، فيديو، أو كائنات ثنائية كبيرة قد تستهلك ذاكرةً كبيرة. ‎[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/blob_management_options/)‎ يوفر تحكمًا في معالجة الـ BLOB واستخدام الملفات المؤقتة. راجع ‎[إدارة BLOBs للعرض](https://docs.aspose.com/slides/ar/python-net/manage-blob/)‎ لاستراتيجيات الملفات الكبيرة.

للملفات الضخمة، يفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، أغلق كل عرض مصدر بمجرد دمجه، وتجنب حفظ النتائج الوسيطية بشكل متكرر إلا إذا استدعت سير العمل نقاط تفتيش. استخدام ‎`with slides.Presentation(...)`‎ يضمن تحرير موارد العرض عند الخروج من السياق.

### **سلامة الخيوط**

لا تقم بتحميل أو حفظ أو استنساخ كائن ‎[Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)‎ من عدة خيوط في آنٍ واحد. حافظ على كل عملية دمج أحادية الخيط. إذا كنت ستُوازِن وظائف دمج مستقلة، استخدم عمليات منفصلة أحادية الخيط وكائنات عرض مستقلة كما هو موضح في ‎[دليل تعدد الخيوط في Aspose.Slides](https://docs.aspose.com/slides/ar/python-net/multithreading/)‎.

## **الأسئلة المتكررة**

**كيف يمكنني الحفاظ على التصميم الأصلي لكل عرض مصدر؟**

استخدم ‎[`add_clone(source_slide)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)‎ دون تزويد ماستر أو تخطيط وجهة. Aspose.Slides يمكنه استنساخ الماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع الوجهة؟**

استخدم overload الذي يقبل ماستر وجهة. مرّر ماسترًا من العرض الوجهة، ليس من المصدر. سيحاول Aspose.Slides ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلًا من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا واحدًا معروفًا. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط الأصلي.

**هل يمكن دمج عروض بأحجام شرائح مختلفة؟**

نعم، لكن محتوى الشرائح لا يُعاد تصميمه تلقائيًا لأبعاد الوجهة. قم بإعادة تحجيم العرض المصدر أولًا عندما تحتاج إلى موضع ثابت، على سبيل المثال باستخدام ‎[SlideSize.set_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/set_size/)‎ و ‎[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesizescaletype/)‎.

**هل يمكنني دمج عروض PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض وجهة واحد، واحفظ الوجهة بصيغة إخراج مدعومة. نظرًا لاختلاف مجموعات الخصائص بين الصيغ، تحقق من المحتوى المعقد بعد دمج صيغ مختلفة. راجع ‎[الصيغ المدعومة للملفات](https://docs.aspose.com/slides/ar/python-net/supported-file-formats/)‎.

**هل يتم حفظ أقسام المصدر تلقائيًا؟**

ليس في الحلقة الأساسية التي تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم overload القسم لـ ‎[add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)‎ عندما يجب الحفاظ على بنية الأقسام.

**هل تُحفظ ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير عمل يعتمد على تنسيق ماستر الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للصوت والفيديو وكائنات OLE والروابط التشعبية؟**

يُحمل المحتوى المُضمَّن كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تبقى خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل الخطوط المضمَّنة من كل مصدر مضمونة التوافر في العرض المدمج؟**

لا تعتمد فقط على استنساخ الشرائح لنشر الخطوط. افحص الخطوط المضمَّنة في الوجهة وقم بإدارة تضمين الخطوط صراحةً أو تأكد من توفر الخطوط الخارجية عندما يكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام ‎[LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/)‎ الصحيح، ثم استنسخ شرائحه كالمعتاد. تُضبط حماية المخرج بشكل منفصل.

**كيف أتعامل مع العروض الكبيرة جدًا؟**

استخدم إدارة الـ BLOB عندما تسيطر الكائنات الثنائية الكبيرة على استهلاك الذاكرة، فضلًا عن تحميل العروض من مسار الملف للملفات الضخمة، أغلق العروض المصدر فور الانتهاء من دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج شرائح من خيوط متعددة؟**

لا تقم بتحميل أو حفظ أو استنساخ كائنات ‎[Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)‎ في عدة خيوط في آنٍ واحد. حافظ على كل عملية دمج أحادية الخيط؛ استخدم عمليات منفصلة أحادية الخيط إذا كنت بحاجة إلى موازنة وظائف دمج مستقلة.
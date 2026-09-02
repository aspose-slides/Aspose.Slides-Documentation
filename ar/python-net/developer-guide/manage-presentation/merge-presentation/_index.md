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
description: "تعلم كيفية دمج عروض PowerPoint وOpenDocument في بايثون عن طريق استنساخ الشرائح، التحكم في الماسترات والتخطيطات، تغيير حجم محتوى الشرائح، الحفاظ على الأقسام، والتعامل مع الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يقوم بدمج العروض التقديمية عن طريق استنساخ الشرائح من [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) إلى آخر. العملية الأساسية هي [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/)، والتي يمكن أن تحافظ على تنسيق الشريحة المصدر أو تُرفق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الوجهة.

هذه المقالة تغطي أكثر سير عمل دمج شائعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيقها الأصلي;
- دمج الشرائح المختارة;
- تطبيق ماستر من العرض التقديمي الوجهة;
- تطبيق تخطيط محدد من العرض التقديمي الوجهة;
- توحيد أحجام الشرائح المختلفة قبل الدمج;
- إضافة الشرائح المستنسخة إلى قسم;
- دمج عدة عروض تقديمية في سير عمل شامل من البداية إلى النهاية;
- التعامل مع الماسترز، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومشكلات تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماستر والتخطيطات**

شريحة ورثت الكثير من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، الاختيار الذي تقوم به لتجاوز الاستنساخ يحدد كيف يتم دمج الشريحة في العرض التقديمي الوجهة.

استخدم [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) بأحد الطرق التالية:

- `add_clone(source_slide)` — الحفاظ على تخطيط وتنسيق الشريحة المصدر. عند الحاجة، يمكن استنساخ الماستر المصدر إلى العرض التقديمي الوجهة تلقائيًا. Aspose.Slides يتتبع الماسترز المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرارًا مع الشرائح المتكررة.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — ربط الشريحة المستنسخة بماستر وجهة محدد [IMasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/). Aspose.Slides يبحث عن تخطيط مطابق تحت ذلك الماستر بحسب نوع التخطيط أو الاسم.
- `add_clone(source_slide, destination_layout)` — ربط الشريحة المستنسخة مباشرةً إلى تخطيط وجهة محدد [ILayoutSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilayoutslide/).

الماستر أو التخطيط الممرَّر إلى تجاوز `add_clone` يجب أن ينتمي إلى **العرض التقديمي الوجهة**، وليس إلى العرض التقديمي المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

الدمج الأبسط ينسخ كل شريحة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. هذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها الأصلي، الماستر، وعلاقات التخطيط.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

قد يحتوي العرض الناتج على عدة ماسترز عندما يستخدم المصدر والوجهة تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ على تنسيق المصدر عمدًا.

## **دمج الشرائح المختارة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المختارة من العرض التقديمي المصدر.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تكون مأخوذة من إدخال المستخدم أو تكوين خارجي.

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم تجاوز [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) عندما يجب أن تتبع الشرائح المستوردة ماسترًا ينتمي بالفعل إلى العرض التقديمي الوجهة.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides يختار تخطيطًا مناسبًا تحت الماستر المحدد عن طريق مطابقة نوع التخطيط أو الاسم الخاص بالتخطيط المصدر. إذا لم يكن هناك تخطيط مناسب وكانت القيمة `allow_clone_missing_layout` هي `True`، يتم استنساخ التخطيط المصدر لكي يمكن إضافة الشريحة. إذا كانت `False`، يتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/).

استخدم `False` عندما تريد أن يفشل الدمج بدلاً من إدخال تخطيط إضافي إلى الماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

استخدم تجاوز [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

تطبيق تخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ لا يعيد تصميم محتوى الشريحة المصدر. إذا كان لدى التخطيطات المصدر والوجهة هياكل نائبة مختلفة، فافحص النتيجة لتأكيد أن التنسيق الموروث وسلوك النائبة مناسبين.

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

يمكن دمج العروض التي لها أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد مختلفة لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال مُزاحة، مُحرفة بشكل غير متوقع، أو خارج منطقة الشريحة المرئية.

نهج عملي هو تغيير حجم العرض المصدر قبل الاستنساخ. طريقة [SlideSize.set_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/set_size/) يمكنها تحجيم المحتوى الموجود مع تغيير أبعاد الشريحة. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesizescaletype/) تحجّم المحتوى ليتناسب مع الحجم المطلوب.

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

تغيير الحجم يغيّر كائن العرض المصدر في الذاكرة. إذا كنت تحتاج إلى الحفاظ على العرض الأصلي بدون تعديل لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

حلقة استنساخ الشرائح الأساسية لا تعيد إنشاء هيكلية الأقسام في العرض المصدر. إذا كانت الأقسام مهمة في الناتج، أنشئ أو اختر أقسامًا في العرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [SlideCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

يتم إلحاق الشرائح المستنسخة بالقسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، قم بعدّ [Presentation.sections](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sections/)، استعد الشرائح الحالية لكل قسم مصدر باستخدام [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/get_slides_list_of_section/)، أعد إنشاء الأقسام في الوجهة، واستنسخ كل شريحة مُسترجعة إلى قسم الوجهة المقابل. راجع [Manage Slide Sections](/slides/ar/python-net/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عدة عروض تقديمية بأمان**

المثال التالي شاملاً من البداية إلى النهاية يستخدم العرض الأول كوجهة، يطبع حجم الشرائح لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

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

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان يجب أن يستخدم الناتج سمة واحدة للوجهة، استبدل الاستدعاء البسيط `add_clone(slide)` بالتحايل المناسب للماستر أو التخطيط الوجهة الموضح سابقًا.

## **اعتبارات عملية**

### **الماستر، التخطيطات، ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب ماستر المصدر المطلوب إلى العرض الوجهة تلقائيًا. Aspose.Slides يحتفظ بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ الماستر نفسه مرات متعددة. الماسترات المستنسخة يدويًا لا يتم تتبعها في ذلك السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت تحتاج إلى سيطرة صريحة على هيكل الماستر.

لا تفترض أن ماسترين أو تخطيطين يحملان الاسم نفسه متساويان بصريًا. إذا كان قالب الشركة يجب أن يتحكم بالمظهر النهائي، اختر ماستر أو تخطيط وجهة صريحًا وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

الملاحظات الصوتية وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. Aspose.Slides أيضًا يوفر واجهات برمجة تطبيقات مخصصة لـ [presentation notes](/slides/ar/python-net/presentation-notes/) و[presentation comments](/slides/ar/python-net/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. لتدفقات المراجعة، تحقق أيضًا من مؤلفي التعليقات وتعليقات السلسلة بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلًا من نسخ الأشكال المرئية فقط لكي يتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معاملة الموارد المدمجة والموارد المرتبطة بشكل مختلف. الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط يظل معتمدًا على الهدف الخارجي؛ استنساخ الشريحة لا يحول الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

Aspose.Slides يتعقب الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض تقديمية غير مرتبطة ستُدمج دائمًا. إذا كان حجم ملف الخرج مهمًا، افحص الحزمة المدمجة وقِس النتيجة بدلًا من الاعتماد على التجميع الضمني.

### **الخطوط المضمنة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان يجب أن يبقى الطباعة متسقًا عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توافر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المضمنة باستخدام [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) وإدارة التضمين صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/python-net/embedded-font/).

تحقق أيضًا من أنك مسموح لك بتضمين الخطوط المستخدمة في ملفات المصدر. تراخيص الخطوط قد تقيد التضمين.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. قدم كلمة المرور عبر [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

فتح مصدر مشفر لا يطبق تلقائيًا نفس الحماية على العرض الوجهة. قم بتكوين حماية الخرج بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة، صوت، فيديو، أو كائنات ثنائية كبيرة قد تستهلك ذاكرةً كبيرة. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/blob_management_options/) يوفر ضوابط لإدارة BLOB واستخدام الملفات المؤقتة. راجع [Manage Presentation BLOBs](/slides/ar/python-net/manage-blob/) لاستراتيجيات الملفات الكبيرة.

للملفات الكبيرة، يفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، أغلق كل عرض مصدر فورًا بعد دمجه، وتجنب حفظ النتائج المتوسطة بشكل متكرر ما لم تتطلب سير العمل نقاط تفتيش. استخدام `with slides.Presentation(...)` يضمن تحرير موارد العرض عند الخروج من السياق.

### **سلامة الخيوط**

لا تقم بتحميل أو حفظ أو استنساخ مثيل [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) من عدة خيوط في وقتٍ واحد. حافظ على كل عملية دمج ذات خيط واحد. إذا كنت تُوازن وظائف دمج مستقلة، استخدم عمليات منفصلة ذات خيط واحد ومثيلات عرض مستقلة كما هو موضح في [Aspose.Slides multithreading guidance](/slides/ar/python-net/multithreading/).

## **الأسئلة المتكررة**

**كيف أحافظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) دون تزويد ماستر أو تخطيط وجهة. Aspose.Slides يمكنه استنساخ الماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم سمة الوجهة؟**

استخدم التحايل الذي يقبل ماستر وجهة. مرّر ماسترًا من العرض التقديمي الوجهة، ليس من المصدر. Aspose.Slides سيحاول ربط كل شريحة مصدر بتخطيط مناسب تحت ذلك الماستر.

**متى يجب أن أستخدم تخطيط وجهة محدد بدلًا من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد أن يختار Aspose.Slides من بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض بحجم شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا للأبعاد الجديدة. غيّر حجم العرض المصدر أولًا عندما تحتاج إلى تحديد مواضع ثابتة، على سبيل المثال باستخدام [SlideSize.set_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/set_size/) و[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesizescaletype/).

**هل يمكنني دمج ملفات PPT، PPTX، وODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض واحد وجهة، واحفظ الوجهة بصيغة مدعومة. بما أن تنسيقات العروض لا تدعم نفس مجموعة الخصائص تمامًا، تحقق من المحتوى المعقد بعد الدمج عبر الصيغ المختلفة. راجع [Supported File Formats](/slides/ar/python-net/supported-file-formats/).

**هل تُحفظ أقسام المصدر تلقائيًا؟**

لا في حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم التحايل الخاص بالقسم في [add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/add_clone/) عندما يجب الحفاظ على هيكلة الأقسام.

**هل تُحفظ الملاحظات والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير العمل الذي يعتمد على تنسيق ماستر الملاحظات، مؤلفي التعليقات، أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى على مستوى الشريحة.

**ماذا يحدث للملفات الصوتية، الفيديو، كائنات OLE، والروابط التشعبية؟**

المحتوى المدمج يُحمل كجزء من علاقات موارد الشريحة المستنسخة. الروابط الخارجية تبقى خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل تضمن الخطوط المضمنة من كل مصدر وجودها في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المضمنة في الوجهة وأدرجها صراحةً أو تأكد من توفر الخطوط الخارجية عندما يكون الطباعة مهمة.

**كيف دمج ملف محمي بكلمة مرور؟**

افتحه باستخدام [LoadOptions.password](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/password/) الصحيح، ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية الخرج بشكل منفصل.

**كيف أتعامل مع العروض الكبيرة؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، فضّل تحميل الملفات عبر مساراتها للملفات الضخمة، أغلق عروض المصدر سريعًا، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج الشرائح من عدة خيوط؟**

لا تقم بتحميل أو حفظ أو استنساخ مثيلات [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) في خيوط متعددة. حافظ على كل عملية دمج ذات خيط واحد؛ استخدم عمليات منفصلة ذات خيط واحد إذا كنت بحاجة إلى موازنة وظائف دمج مستقلة.
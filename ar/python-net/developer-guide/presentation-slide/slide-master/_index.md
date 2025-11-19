---
title: إدارة ماسترات شرائح PowerPoint في Python
linktitle: ماستر الشريحة
type: docs
weight: 80
url: /ar/python-net/slide-master/
keywords:
- ماستر شريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- Python
- Aspose.Slides
description: "أتمتة ماسترات شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET لتعزيز كفاءة التطوير إلى أقصى حد. دليل شامل للمبتدئين والمتقدمين."
---

## **نظرة عامة**

**Slide Master** هو قالب شريحة يحدد التخطيط، الأنماط، السمة، الخطوط، الخلفية، والخصائص الأخرى للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام **Slide Master**.

يُعد **Slide Master** مفيدًا لأنه يتيح لك ضبط وتغيير مظهر جميع شرائح العرض التقديمي دفعة واحدة. تدعم Aspose.Slides آلية **Slide Master** في PowerPoint.

كما يتيح VBA تعديل **Slide Master** وأداء نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيطات، وأكثر. توفر Aspose.Slides واجهات برمجة تطبيقات مرنة تسمح لك بالعمل مع **Slide Masters** وأداء المهام الشائعة.

هذه هي عمليات **Slide Master** الأساسية:

- إنشاء **Slide Master**.
- تطبيق **Slide Master** على شرائح العرض التقديمي.
- تغيير خلفية **Slide Master**.
- إضافة صورة أو عنصر نائب أو SmartArt، إلخ، إلى **Slide Master**.

هذه عمليات أكثر تقدماً تتضمن **Slide Master**:

- مقارنة **Slide Masters**.
- دمج **Slide Masters**.
- تطبيق عدة **Slide Masters**.
- نسخ شريحة مع **Slide Master** الخاص بها إلى عرض تقديمي آخر.
- تحديد **Slide Masters** المكررة في العروض التقديمية.
- تعيين **Slide Master** كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}}
قد ترغب في تجربة Aspose [Online PowerPoint Viewer](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموصوفة هنا.
{{% /alert %}}

## **كيفية تطبيق Slide Master**

قبل البدء في العمل مع **Slide Master**، قد تريد فهم كيفية استخدام **Slide Masters** في العروض التقديمية وتطبيقها على الشرائح.

- يحتوي كل عرض تقديمي على **Slide Master** واحد على الأقل افتراضيًا.
- يمكن للعرض التقديمي أن يحتوي على عدة **Slide Masters**. يمكنك إضافة عدة **Slide Masters** واستخدامها لتصيير أجزاء مختلفة من العرض بطرق مختلفة.

في Aspose.Slides، يُمثَّل **Slide Master** بالنوع [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

كائن Aspose.Slides [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على مجموعة [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) من النوع [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)، التي تحتفظ بجميع الشرائح الرئيسية المعرفة في العرض التقديمي.

بالإضافة إلى عمليات CRUD، توفر فئة [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) طرقًا مفيدة مثل [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) و[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/). هذه الطرق توسّع وظائف استنساخ الشرائح الأساسية، وعند العمل مع **Slide Masters**، تسمح لك بتنفيذ إعدادات أكثر تعقيدًا.

عند إضافة شريحة جديدة إلى عرض تقديمي، يُطبق **Slide Master** عليها تلقائيًا. افتراضيًا، يتم اختيار **Slide Master** من الشريحة السابقة.

**ملاحظة:** تُخزن شرائح العرض التقديمي في مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)، وتُضاف كل شريحة جديدة إلى نهاية تلك المجموعة افتراضيًا. إذا كان العرض يحتوي على **Slide Master** واحد، يتم اختيار ذلك **Slide Master** لجميع الشرائح الجديدة. لذلك لا تحتاج إلى تحديد **Slide Master** لكل شريحة جديدة تنشئها.

ينطبق المبدأ نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة شريحة جديدة، يمكنك النقر على المنطقة أسفل آخر شريحة، وستُنشأ شريحة جديدة (باستخدام **Slide Master** الخاص بالشريحة السابقة).

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) من فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

## **Slide Master في تسلسل الشرائح الهرمي**

استخدام **Slide Layouts** مع **Slide Master** يوفر أقصى مرونة. يمكن لـ **Slide Layout** أن يعرّف نفس أنواع الأنماط كما في **Slide Master** (الخلفية، الخطوط، الأشكال، إلخ). عندما يتم تعريف عدة **Slide Layouts** تحت **Slide Master**، تُكوّن معًا نظام نمط موحد. عبر تطبيق **Slide Layout** على شريحة فردية، يمكنك تعديل نمطها بناءً على ما يقدّمه **Slide Master**.

الأولوية هي: **Slide Master** → **Slide Layout** → **Slide**.

![todo:image_alt_text](slide-master_2.jpg)

كل كائن [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) يحتوي على خاصية [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) التي تضم قائمة تخطيطات الشرائح. كائن [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) لديه خاصية [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) التي تُشير إلى تخطيط الشريحة المطبق عليه. يحدث التفاعل بين الشريحة و**Slide Master** من خلال تخطيط الشريحة الخاص بها.

{{% alert color="info" title="ملاحظة" %}}
- في Aspose.Slides، جميع بنى الشرائح (Slide Master، Slide Layout، والشريحة نفسها) هي كائنات شريحة تمتد من فئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/).
- لأن **Slide Master** و**Slide Layout** يقدمان العديد من الخصائص نفسها، تحتاج إلى معرفة كيف تُطبق قيمهما على كائن [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). يُطبق **Slide Master** أولًا، ثم **Slide Layout**. على سبيل المثال، إذا عرّف كلاهما خلفية، تستخدم الشريحة الخلفية من **Slide Layout**.
{{% /alert %}}

## **ما يتكوّن منه Slide Master**

لفهم كيفية تعديل **Slide Master**، تحتاج لمعرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/):

- `background` — الحصول/تعيين خلفية الشريحة.
- `body_style` — الحصول/تعيين أنماط النص لجسم الشريحة.
- `shapes` — الحصول/تعيين جميع الأشكال على **Slide Master** (عناصر نائب، إطارات صور، إلخ).
- `controls` — الحصول/تعيين عناصر التحكم ActiveX.
- `theme_manager` — الحصول على مدير السمة.
- `header_footer_manager` — الحصول على مدير الرأس والتذييل.

طرق **Slide Master**:

- `get_depending_slides()` — يحصل على جميع الشرائح التي تعتمد على **Slide Master**.
- `apply_external_theme_to_depending_slides(fname)` — ينشئ **Slide Master** جديدًا بناءً على الحالي وسمة خارجية، ثم يطبّق **Slide Master** الجديد على جميع الشرائح التابعة.

## **الحصول على Slide Master**

في PowerPoint، يمكنك الوصول إلى **Slide Master** عبر **View** → **Slide Master**:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى **Slide Master** كما يلي:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # احصل على أول شريحة ماستر في العرض التقديمي.
    master_slide = presentation.masters[0]
```


فئة [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) تمثل **Slide Master**. خاصية [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (وهي [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) تحتفظ بجميع **Slide Masters** المعرفة في العرض التقديمي.

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى **Slide Master**، تظهر تلك الصورة على جميع الشرائح التي تعتمد على ذلك الماستر.

على سبيل المثال، ضع شعار شركتك أو صورًا أخرى على **Slide Master**، ثم عُد إلى عرض Normal. سترى الصورة على كل شريحة تابعة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى **Slide Master** باستخدام Aspose.Slides:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="انظر أيضًا" %}}
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Add Picture Frames to Presentations with Python](/slides/ar/python-net/picture-frame/).
{{% /alert %}}

## **إضافة عنصر نائب إلى Slide Master**

هذه الحقول النصية هي عناصر نائب قياسية على **Slide Master**:

- انقر لتحرير نمط عنوان الماستر
- تحرير أنماط نص الماستر
- المستوى الثاني
- المستوى الثالث

تظهر هذه العناصر النائبة أيضًا على الشرائح المستندة إلى **Slide Master**. يمكنك تحرير هذه العناصر النائبة على **Slide Master**، وتُطبّق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر **Slide Master** → **Insert Placeholder**:

![todo:image_alt_text](slide-master_5.png)

دعنا نستعرض مثالًا أكثر تعقيدًا للعناصر النائبة في Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب موروثة من **Slide Master**:

![todo:image_alt_text](slide-master_6.png)

نريد تحديث تنسيق العنوان والعنوان الفرعي على **Slide Master** كما يلي:

![todo:image_alt_text](slide-master_7.png)

أولاً، احصل على عنصر نائب العنوان من **Slide Master**، ثم استخدم خاصية `PlaceHolder.fill_format`:
```python
# احصل على مرجع إلى العنصر النائب لعنوان شريحة الماستر.
title_placeholder = master_slide.shapes[0]

# تعيين تنسيق التعبئة إلى تدرج.
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


سيتغير نمط وتنسيق العنوان على جميع الشرائح المستندة إلى **Slide Master**:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}}
* [Manage Placeholders in Presentations with Python](/slides/ar/python-net/manage-placeholder/)
* [Format PowerPoint Text in Python](/slides/ar/python-net/text-formatting/)
{{% /alert %}}

## **تغيير خلفية Slide Master**

عند تغيير لون خلفية **Slide Master**، ترث جميع الشرائح العادية في العرض التقديمي اللون الجديد. يوضح كود Python التالي ذلك:
```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="انظر أيضًا" %}}
- [Manage Presentation Backgrounds in Python](/slides/ar/python-net/presentation-background/)
- [Manage PowerPoint Presentation Themes in Python](/slides/ar/python-net/presentation-theme/)
{{% /alert %}}

## **إضافة عدة Slide Masters إلى عرض تقديمي**

تتيح Aspose.Slides لك إضافة عدة **Slide Masters** و**Slide Layouts** إلى أي عرض تقديمي. يتيح لك ذلك تكوين الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق مختلفة متعددة.

في PowerPoint، يمكنك إضافة **Slide Masters** و**Slide Layouts** جديدة من قائمة **Slide Master** كما يلي:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة **Slide Master** جديد عبر استدعاء طريقة `add_clone`:
```python
# أضف شريحة ماستر جديدة.
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **مقارنة Slide Masters**

يمتد **Slide Master** من فئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)، التي تتضمن طريقة `equals(slide)` لمقارنة الشرائح. تُعيد هذه الطريقة true عندما تكون **Slide Masters** متطابقة في الهيكلة والمحتوى الثابت.

تُعتبر **Slide Masters** متساوية إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متطابقة. يتجاهل المقارنة قيم المعرفات الفريدة (مثل `slide_id`) والمحتوى الديناميكي (مثل التاريخ الحالي في عنصر نائب التاريخ).

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

تتيح Aspose.Slides لك تعيين **Slide Master** كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولًا عند فتح العرض. يوضح المثال التالي بـ Python كيفية تعيين **Slide Master** كعرض افتراضي للعرض:
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # تعيين العرض الافتراضي كعرض ماستر الشرائح.
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # حفظ العرض التقديمي.
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة Master Slide غير مستخدم**

توفر Aspose.Slides طريقة `remove_unused_master_slides` (في فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) لحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يوضح كود Python التالي كيفية إزالة الشرائح الرئيسية غير المستخدمة من عرض PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط، الأنماط، السمات، الخطوط، الخلفية، والخصائص الأخرى للشرائح في عرض تقديمي. يسمح لك بضبط وتغيير مظهر جميع شرائح العرض دفعة واحدة.

**كيف يرتبط Slide Masters بـ Slide Layouts؟**

تعمل Slide Layouts بالتوازي مع Slide Masters لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط والسمات العامة، تسمح [Slide Layouts](/slides/ar/python-net/slide-layout/) بتنوع ترتيبات المحتوى. التسلسل الهرمي هو كما يلي:

- **Slide Master** → يحدد الأنماط العامة.
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة.
- **Slide** → يرث التصميم من Slide Layout الخاص به.

**هل يمكن أن يكون لدي عدة Slide Masters في عرض تقديمي واحد؟**

نعم، يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يتيح لك ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثَّل Slide Master بالفئة [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). يمكنك الوصول إلى Slide Master عبر خاصية [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) لكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
---
title: الرئيسية للشرائح
type: docs
weight: 80
url: /python-net/slide-master/
keywords: "إضافة الرئيسية للشرائح، شريحة الماستر PPT، الرئيسية للشرائح PowerPoint، صورة إلى الرئيسية للشرائح، عنصر نائب، عدة رئيسيات للشرائح، مقارنة رئيسيات الشرائح، بايثون، Aspose.Slides"
description: "إضافة أو تحرير الرئيسية للشرائح في عرض PowerPoint باستخدام بايثون"
---

## **ما هي الرئيسية للشرائح في PowerPoint**

الرئيسية للشرائح هي نموذج شريحة تحدد تخطيط، أنماط، موضوع، خطوط، خلفية، وخصائص أخرى للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة من العروض التقديمية) بنفس النمط والنموذج لشركتك، يمكنك استخدام الرئيسية للشرائح.

الرئيسية للشرائح مفيدة لأنها تتيح لك ضبط وتغيير مظهر جميع شرائح العرض في وقت واحد. تدعم Aspose.Slides آلية الرئيسية للشرائح من PowerPoint.

يتيح لك VBA أيضًا التلاعب بالرئيسية للشرائح وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تتيح لك استخدام الرئيسيات للشرائح وأداء المهام الأساسية معها.

هذه هي العمليات الأساسية للرئيسية للشرائح:

- إنشاء أو استيراد الرئيسية للشرائح.
- تطبيق الرئيسيات على شرائح العرض.
- تغيير خلفية الرئيسية للشرائح.
- إضافة صورة، عنصر نائب، فن ذكي، إلخ. إلى الرئيسية للشرائح.

هذه هي العمليات الأكثر تطورًا المتعلقة بالرئيسية للشرائح:

- مقارنة الرئيسيات للشرائح.
- دمج الرئيسيات للشرائح.
- تطبيق عدة رئيسيات للشرائح.
- نسخ شريحة مع الرئيسية للشرائح إلى عرض تقديمي آخر.
- اكتشاف الرئيسيات المكررة في العروض التقديمية.
- تعيين الرئيسية للشرائح كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 

قد ترغب في التحقق من Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموصوفة هنا.

{{% /alert %}} 

## **كيف يتم تطبيق الرئيسية للشرائح**

قبل أن تعمل مع الرئيسية للشرائح، قد ترغب في فهم كيف يتم استخدامها في العروض التقديمية وتطبيقها على الشرائح.

* يحتوي كل عرض تقديمي على الأقل على الرئيسية للشرائح واحدة بشكل افتراضي.
* يمكن أن يحتوي العرض التقديمي على عدة رئيسيات للشرائح. يمكنك إضافة عدة رئيسيات للشرائح واستخدامها لتنسيق أجزاء مختلفة من العرض التقديمي بطرق مختلفة.

في **Aspose.Slides**، يتم تمثيل الرئيسية للشرائح بواسطة [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) النوع.

يحتوي كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في Aspose.Slides على قائمة [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من نوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) التي تحتوي على قائمة بكل الشرائح الرئيسية المعرفة في عرض تقديمي.

بجانب عمليات CRUD، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) على هذه الأساليب المفيدة: [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) و [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) هذه الأساليب موروثة من وظيفة نسخ الشرائح الأساسية. ولكن عند التعامل مع الرئيسيات للشرائح، تتيح لك هذه الأساليب تنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق الرئيسية للشرائح عليها تلقائيًا. يتم اختيار الرئيسية للشرائح للشريحة السابقة بشكل افتراضي.

**ملاحظة**: يتم تخزين شرائح العرض في قائمة [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، وكل شريحة جديدة تتم إضافتها إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض التقديمي يحتوي على الرئيسية للشرائح واحدة، يتم اختيار تلك الرئيسية لجميع الشرائح الجديدة. هذه هي السبب في أنك لا تحتاج إلى تعريف الرئيسية للشرائح لكل شريحة جديدة تقوم بإنشائها.

المبدأ هو نفسه بالنسبة لـ PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف عرضًا تقديميًا جديدًا، يمكنك ببساطة الضغط على السطر السفلي تحت آخر شريحة، ثم سيتم إنشاء شريحة جديدة (مع الرئيسية للشرائح من العرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك أداء المهمة المكافئة باستخدام الطريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

## **الرئيسية للشرائح في تسلسل الشرائح**

باستخدام تخطيطات الشرائح مع الرئيسية للشرائح، يمكنك تحقيق أقصى قدر من المرونة. تتيح لك تخطيط الشريحة تعيين جميع نفس الأنماط مثل الرئيسية للشرائح (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات في الرئيسية للشرائح، يتم إنشاء نمط جديد. عند تطبيق تخطيط الشريحة على شريحة واحدة، يمكنك تغيير نمطها من النمط المطبق بواسطة الرئيسية للشرائح.

تتفوق الرئيسية للشرائح على جميع عناصر الإعداد: الرئيسية للشرائح -> تخطيط الشريحة -> الشريحة:

![todo:image_alt_text](slide-master_2)

يمتلك كل كائن [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) خاصية [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) التي تحتوي على قائمة بتخطيطات الشرائح. تحتوي شريحة من نوع [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide) على خاصية [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) التي تحتوي على رابط لتخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة والرئيسية للشرائح من خلال تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، جميع إعدادات الشرائح (الرئيسية للشرائح، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شرائح تنفذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/).
* لذلك، قد تنفذ الرئيسية للشرائح وتخطيط الشريحة نفس الخصائص، وتحتاج إلى معرفة كيف سيتم تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). يتم تطبيق الرئيسية للشرائح أولاً على الشريحة، ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كانت الرئيسية للشرائح وتخطيط الشريحة يحتويان كلاهما على قيمة الخلفية، ستنتهي الشريحة بالخلفية من تخطيط الشريحة.

{{% /alert %}}

## **مكونات الرئيسية للشرائح**

لفهم كيف يمكن تغيير الرئيسية للشرائح، تحتاج إلى معرفة مكوناتها. وهذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). 

- `background` الحصول/تعيين خلفية الشريحة.
- `body_style` الحصول/تعيين أنماط النص لجسم الشريحة.
- `shapes` الحصول/تعيين جميع الأشكال في الرئيسية للشرائح (عناصر نائب، إطارات صور، إلخ).
- `controls` - الحصول/تعيين عناصر تحكم ActiveX.
- `theme_manager` - الحصول على مدير الموضوع.
- `header_footer_manager` - الحصول على مدير الرأس والتذييل.

طرق الرئيسية للشرائح:

- `get_depending_slides()` - الحصول على جميع الشرائح المعتمدة على الرئيسية للشرائح.
- `apply_external_theme_to_depending_slides(fname)` - يتيح لك إنشاء رئيسية جديدة بناءً على الرئيسية الحالية وموضوع جديد. ستطبق الرئيسية الجديدة على جميع الشرائح التابعة.

## **الحصول على الرئيسية للشرائح**

في PowerPoint، يمكن الوصول إلى الرئيسية للشرائح من قائمة عرض -> الرئيسية للشرائح:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى الرئيسية للشرائح بهذه الطريقة:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # يعطي الوصول إلى الشريحة الرئيسية للعرض
    masterSlide = pres.masters[0]
```

تمثل واجهة [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) الرئيسية للشرائح. تحتوي خاصية `masters` (ذات الصلة بـ [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) النوع) على قائمة بجميع الرئيسيات للشرائح المعرفة في العرض التقديمي. 

## **إضافة صورة إلى الرئيسية للشرائح**

عند إضافة صورة إلى الرئيسية للشرائح، ستظهر هذه الصورة على جميع الشرائح المعتمدة على تلك الرئيسية للشرائح.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على الرئيسية للشرائح ثم التبديل مرة أخرى إلى وضع تحرير الشرائح. ينبغي أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى الرئيسية للشرائح باستخدام Aspose.Slides:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="مزيد من المعلومات" %}} 

للحصول على مزيد من المعلومات حول إضافة الصور إلى الشريحة، انظر مقال [إطار الصورة](/slides/python-net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى الرئيسية للشرائح**

تعد هذه الحقول النصية عناصر نائب قياسية في الرئيسية للشرائح:

* انقر لتحرير نمط عنوان الماستر

* تحرير أنماط نص الماستر

* المستوى الثاني

* المستوى الثالث

تظهر أيضًا على الشرائح المعتمدة على الرئيسية للشرائح. يمكنك تحرير تلك العناصر النائبة في الرئيسية للشرائح، وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر المسار الرئيسية للشرائح -> إدراج عنصر نائب:

![todo:image_alt_text](slide-master_5.png)

دعونا نفحص مثالًا أكثر تعقيدًا لعناصر النائب باستخدام Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب تم تهيئتها من الرئيسية للشرائح:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على الرئيسية للشرائح بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر نائب العنوان من كائن الرئيسية للشرائح ثم نستخدم المجال `PlaceHolder.FillFormat`:

```python
# يحصل على مرجع إلى عنصر نائب العنوان في الماستر
titlePlaceholder = masterSlide.shapes[0]

# يحدد تنسيق التعبئة كملء تدرجي
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

سيتغير نمط وتنسيق العنوان لجميع الشرائح المعتمدة على الرئيسية للشرائح:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="مزيد من المعلومات" %}} 

* [تعيين نص التذكير في عنصر نائب](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **تغيير الخلفية على الرئيسية للشرائح**

عند تغيير لون خلفية شريحة الماستر، ستحصل جميع الشرائح العادية في العرض التقديمي على اللون الجديد. توضح هذه الشيفرة البرمجية بلغة بايثون العملية:

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="مزيد من المعلومات" %}} 

- [خلفية العرض التقديمي](https://docs.aspose.com/slides/python-net/presentation-background/)

- [موضوع العرض التقديمي](https://docs.aspose.com/slides/python-net/presentation-theme/)

  {{% /alert %}}

## **استنساخ الرئيسية للشرائح إلى عرض تقديمي آخر**

لاستنساخ الرئيسية للشرائح إلى عرض تقديمي آخر، استدعِ الطريقة `add_clone(source_slide, dest_master, allow_clone_missing_layout)` من العرض التقديمي الوجهة جنبًا إلى جنب مع الرئيسية للشرائح الممررة إليها. توضح هذه الشيفرة البرمجية كيفية استنساخ الرئيسية للشرائح إلى عرض تقديمي آخر:

```python
# يضيف شريحة رئيسية جديدة 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **إضافة عدة رئيسيات للشرائح إلى العرض التقديمي**

تتيح لك Aspose.Slides إضافة عدة رئيسيات للشرائح وتخطيطات الشرائح إلى أي عرض تقديمي معين. وهذا يتيح لك إعداد أنماط وتخطيطات وخيارات تنسيق لشرائح العرض بعدة طرق.

في PowerPoint، يمكنك إضافة رئيسيات جديدة وتخطيطات (من قائمة "الرئيسية للشرائح") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة رئيسية جديدة عن طريق استدعاء الطريقة `add_clone`:

```python
# يضيف شريحة رئيسية جديدة
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **مقارنة الرئيسية للشرائح**

تقوم الشريحة الرئيسية بتنفيذ واجهة [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) التي تحتوي على الطريقة `equals(slide)`، والتي يمكن استخدامها لمقارنة الشرائح. تعود `true` لشرائح رئيسية متطابقة في الهيكل والمحتوى الثابت.

تكون رئيستين للشرائح متساويتين إذا كانت أشكالها، أنماطها، نصوصها، الرسوم المتحركة والإعدادات الأخرى، إلخ، متساوية. لا تأخذ المقارنة في اعتبارها قيم المعرف الفريد (مثل SlideId) والمحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).

## **تعيين الرئيسية للشرائح كعرض افتراضي للعرض التقديمي**

تتيح لك Aspose.Slides تعيين الرئيسية للشرائح كعرض افتراضي للعرض التقديمي. يوضح هذا الرمز كيفية تعيين الرئيسية للشرائح كعرض افتراضي للعرض التقديمي بلغة بايثون:

```py
import aspose.slides as slides

# ينشئ كائن عرض يقدم ملف العرض التقديمي
with slides.Presentation() as presentation:
    # يعين العرض الافتراضي كعرض الرئيسي للشرائح
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # يحفظ العرض التقديمي
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الشريحة الرئيسية غير المستخدمة**

توفر Aspose.Slides الطريقة `remove_unused_master_slides` (من فئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. توضح هذه الشيفرة البرمجية كيفية إزالة شريحة رئيسية من عرض تقديمي PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```
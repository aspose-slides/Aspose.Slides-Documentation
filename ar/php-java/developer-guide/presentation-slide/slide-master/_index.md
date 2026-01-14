---
title: إدارة شرائح الرئيس في PHP
linktitle: شريحة الرئيس
type: docs
weight: 70
url: /ar/php-java/slide-master/
keywords:
- شريحة رئيس
- شريحة رئيسية
- شريحة رئيسية PPT
- شرائح رئيسية متعددة
- مقارنة شرائح رئيسية
- خلفية
- عنصر نائب
- استنساخ شريحة رئيسية
- نسخ شريحة رئيسية
- تكرار شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة شرائح الرئيس في Aspose.Slides للـ PHP عبر Java: إنشاء، تحرير وتطبيق التخطيطات، السمات والعناصر النائبة على ملفات PPT، PPTX و ODP مع أمثلة مختصرة."
---

## **ما هو شريحة الرئيس في PowerPoint**

Slide Master هو قالب شريحة يحدد التخطيط والأنماط والسمة والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. إذا أردت إنشاء عرض تقديمي (أو سلسلة عروض) بنفس النمط والقالب لشركتك، يمكنك استخدام شريحة الرئيس.

Slide Master مفيدة لأنها تسمح لك بتعيين وتغيير مظهر جميع شرائح العرض مرة واحدة. تدعم Aspose.Slides آلية شريحة الرئيس من PowerPoint.

كما يتيح VBA لك التعامل مع شريحة الرئيس وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة لاستخدام شرائح الرئيس وأداء المهام الأساسية معها.

هذه عمليات شريحة الرئيس الأساسية:

- إنشاء أو حذف شريحة الرئيس.
- تطبيق شريحة الرئيس على شرائح العرض.
- تغيير خلفية شريحة الرئيس. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى شريحة الرئيس.

هذه عمليات شريحة الرئيس المتقدمة:

- مقارنة شرائح الرئيس.
- دمج شرائح الرئيس.
- تطبيق عدة شرائح رئيس.
- نسخ شريحة مع شريحة الرئيس إلى عرض تقديمي آخر.
- العثور على شرائح رئيس مكررة في العروض التقديمية.
- تعيين شريحة الرئيس كطريقة العرض الافتراضية للعرض.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموصوفة هنا.
{{% /alert %}} 

## **كيف يتم تطبيق شريحة الرئيس**

قبل العمل مع شريحة الرئيس، قد تريد فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح.

* كل عرض تقديمي يحتوي على شريحة رئيس واحدة على الأقل بشكل افتراضي. 
* يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيس. يمكنك إضافة عدة شرائح رئيس واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، تمثل شريحة الرئيس النوع [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) من النوع [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)، والتي تحتوي على جميع شرائح الرئيس المعرفة في العرض.

بالإضافة إلى عمليات CRUD، يحتوي الصف [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) على الطرق المفيدة: [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) و[**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone). هذه الطرق موروثة من وظيفة استنساخ الشريحة الأساسية. ولكن عند التعامل مع شرائح الرئيس، تسمح لك هذه الطرق بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق شريحة الرئيس عليها تلقائيًا. يتم اختيار شريحة الرئيس الخاصة بالشريحة السابقة بشكل افتراضي.

**ملاحظة**: تُخزن شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides)، ويتم إضافة كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على شريحة رئيس واحدة، يتم اختيار تلك الشريحة لجميع الشرائح الجديدة. هذا هو السبب في أنك لا تحتاج إلى تحديد شريحة الرئيس لكل شريحة جديدة تنشئها.

المبدأ نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك النقر على السطر الأسفل تحت الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع شريحة الرئيس من العرض السابق):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المقابلة باستخدام طريقة [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) ضمن الصف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).

## **شريحة الرئيس في هيكلية الشرائح**

استخدام تخطيطات الشرائح مع شريحة الرئيس يتيح أقصى قدر من المرونة. تخطيط الشريحة يسمح لك بتعيين جميع الأنماط نفسها مثل شريحة الرئيس (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات شرائح على شريحة الرئيس، يتم إنشاء نمط جديد. عندما تطبق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من شريحة الرئيس.

شريحة الرئيس تتفوق على جميع عناصر الإعداد: شريحة الرئيس → تخطيط الشريحة → الشريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) يحتوي على خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) التي تُعيد قائمة من تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) يحتوي على خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide) التي تُشير إلى تخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة وشريحة الرئيس عبر تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (شريحة الرئيس، تخطيط الشريحة، والشريحة نفسها) هي بالفعل كائنات شريحة ترث من الصف [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide).
* لذلك، قد تُنفّذ شريحة الرئيس وتخطيط الشريحة نفس الخصائص وتحتاج إلى معرفة كيفية تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). يتم تطبيق شريحة الرئيس أولًا على الشريحة ثم يُطبق تخطيط الشريحة. على سبيل المثال، إذا كان لكل من شريحة الرئيس وتخطيط الشريحة قيمة خلفية، فإن الشريحة ستحصل على الخلفية من تخطيط الشريحة.
{{% /alert %}}

## **ما الذي تحتويه شريحة الرئيس**

لفهم كيفية تغيير شريحة الرئيس، عليك معرفة مكوناتها. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) الحصول/ضبط خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) الحصول/ضبط أنماط نص جسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) الحصول/ضبط كافة الأشكال في شريحة الرئيس (عناصر نائبة، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) الحصول/ضبط عناصر تحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) الحصول على مدير السمة.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) الحصول على مدير الترويسة والتذييل.

طرق شريحة الرئيس:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) الحصول على جميع الشرائح التي تعتمد على شريحة الرئيس.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) يتيح لك إنشاء شريحة رئيس جديدة بناءً على شريحة الرئيس الحالية وسمة جديدة. ثم تُطبق شريحة الرئيس الجديدة على جميع الشرائح التابعة.

## **الحصول على شريحة الرئيس**

في PowerPoint، يمكن الوصول إلى شريحة الرئيس من القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى شريحة الرئيس بهذه الطريقة:
```php
  $pres = new Presentation();
  try {
    # يوفّر الوصول إلى شريحة الرئيس للعرض
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


الصف [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) يمثل شريحة الرئيس. طريقة [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) (المرتبطة بنوع [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)) تُعيد قائمة بجميع شرائح الرئيس المعرفة في العرض.

## **إضافة صورة إلى شريحة الرئيس**

عند إضافة صورة إلى شريحة الرئيس، ستظهر تلك الصورة على جميع الشرائح التي تعتمد على تلك الشريحة.

على سبيل المثال، يمكنك وضع شعار شركتك وعدد قليل من الصور على شريحة الرئيس ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى شريحة الرئيس باستخدام Aspose.Slides:
```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="انظر أيضًا" %}} 
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى شريحة الرئيس**

هذه الحقول النصية هي عناصر نائب قياسية على شريحة الرئيس:

* اضغط لتحرير نمط عنوان الرئيس
* تحرير أنماط نص الرئيس
* المستوى الثاني
* المستوى الثالث

تظهر أيضًا على الشرائح التي تستند إلى شريحة الرئيس. يمكنك تحرير تلك العناصر على شريحة الرئيس وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنستعرض مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. افترض وجود شريحة بعناصر نائب مكوّنة من شريحة الرئيس:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على شريحة الرئيس بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نستعيد محتوى عنصر العنوان من كائن شريحة الرئيس ثم نستخدم الحقل `PlaceHolder.FillFormat`:

```php

```


سيتغير نمط العنوان والتنسيق لجميع الشرائح المستندة إلى شريحة الرئيس:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على شريحة الرئيس**

عند تغيير لون خلفية شريحة الرئيس، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يوضح هذا الكود PHP العملية:
```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)
{{% /alert %}}

## **استنساخ شريحة الرئيس إلى عرض تقديمي آخر**

لاستنساخ شريحة الرئيس إلى عرض آخر، استدعِ طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) من العرض الوجهة مع تمرير شريحة الرئيس إليها. يوضح هذا الكود PHP كيفية استنساخ شريحة الرئيس إلى عرض آخر:
```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```


## **إضافة عدة شرائح رئيس إلى عرض تقديمي**

يسمح Aspose.Slides بإضافة عدة شرائح رئيس وتخطيطات شرائح إلى أي عرض. يتيح ذلك ضبط الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة شرائح رئيس وتخطيطات جديدة (من "قائمة شريحة الرئيس") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة رئيس جديدة باستدعاء طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone):
```php
  # يضيف شريحة رئيسية جديدة
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```


## **مقارنة شرائح الرئيس**

تنفّذ شريحة الرئيس الصف [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) الذي يحتوي على طريقة [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#equals)، والتي يمكن استخدامها لمقارنة الشرائح. تُرجع `true` عندما تكون شرائح الرئيس متطابقة في الهيكل والمحتوى الثابت.

تُعد شرائح الرئيس متساوية إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متطابقة. لا تُأخذ المقارنة في الاعتبار قيم المعرف الفريدة (مثل SlideId) والمحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).

## **تعيين شريحة الرئيس كطريقة عرض افتراضية للعرض**

يسمح Aspose.Slides بتعيين شريحة الرئيس كطريقة العرض الافتراضية للعرض. طريقة العرض الافتراضية هي ما تراه أولًا عند فتح العرض.

يعرض هذا الكود كيفية تعيين شريحة الرئيس كطريقة عرض افتراضية للعرض:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف العرض
  $presentation = new Presentation();
  try {
    # يعيّن العرض الافتراضي إلى SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # يحفظ العرض
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **إزالة شرائح الرئيس غير المستخدمة**

يوفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) (من الصف [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) لحذف شرائح الرئيس غير المرغوب فيها وغير المستخدمة. يوضح هذا الكود PHP كيفية إزالة شريحة رئيس من عرض PowerPoint:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**ما هي شريحة الرئيس في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط والأنماط والسمة والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. يسمح لك بتعيين وتغيير مظهر جميع شرائح العرض مرة واحدة.

**كيف يتم تطبيق شريحة الرئيس في العرض؟**

كل عرض يحتوي على شريحة رئيس واحدة على الأقل بشكل افتراضي. عندما تُضاف شريحة جديدة، تُطبق شريحة الرئيس عليها تلقائيًا، عادةً مُستمدّة من شريحة الرئيس للشريحة السابقة. يمكن للعرض أن يحتوي على عدة شرائح رئيس لتنسيق أقسام مختلفة بطريقة فريدة.

**ما العناصر التي يمكن تخصيصها في شريحة الرئيس؟**

تتضمن شريحة الرئيس عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تحديد خلفية الشريحة.
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.
- **Shapes**: إدارة جميع الأشكال على شريحة الرئيس، بما في ذلك العناصر النائبة وإطارات الصور.
- **Controls**: معالجة عناصر تحكم ActiveX.
- **ThemeManager**: الوصول إلى مدير السمة.
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.

**كيف يمكنني إضافة صورة إلى شريحة الرئيس؟**

إضافة صورة إلى شريحة الرئيس يضمن ظهورها على جميع الشرائح التي تعتمد على تلك الشريحة. على سبيل المثال، وضع شعار الشركة على شريحة الرئيس سيظهر على كل شريحة في العرض.

**كيف ترتبط شرائح الرئيس بتخطيطات الشرائح؟**

تعمل تخطيطات الشرائح بالتعاون مع شرائح الرئيس لتوفير مرونة في تصميم الشرائح. تُحدد شريحة الرئيس الأنماط والسمات العامة، بينما تسمح تخطيطات الشرائح بتنوع ترتيب المحتوى. هيكلية العلاقة كالتالي:

- **Slide Master** → يحدد الأنماط العامة.
- **Slide Layout** → يقدم ترتيبات محتوى مختلفة.
- **Slide** → يرث التصميم من تخطيط الشريحة الخاص به.

**هل يمكن أن يكون لدي عدة شرائح رئيس في عرض واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة شرائح رئيس. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، ما يوفر مرونة في التصميم.

**كيف يمكنني الوصول إلى شريحة الرئيس وتعديلها باستخدام Aspose.Slides؟**

في Aspose.Slides، تمثل شريحة الرئيس الصف [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). يمكنك الوصول إلى شريحة الرئيس باستخدام طريقة [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) لكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
---
title: ماستر الشريحة
type: docs
weight: 70
url: /ar/php-java/slide-master/
keywords: "إضافة ماستر الشريحة، شريحة ماستر PPT، ماستر الشريحة PowerPoint، صورة إلى ماستر الشريحة، عنصر نمطي، عدة ماسترات للشريحة، مقارنة ماسترات الشريحة، Java، Aspose.Slides لPHP عبر Java"
description: "إضافة أو تعديل ماستر الشريحة في عرض PowerPoint"
---

## **ما هو ماستر الشريحة في PowerPoint**

ماستر الشريحة هو نموذج شريحة يحدد التخطيط، الأنماط، السمة، الخطوط، الخلفية، وخصائص أخرى للشرائح في العرض التقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة من العروض التقديمية) بنفس الأسلوب والنموذج لشركتك، يمكنك استخدام ماستر الشريحة.

ماستر الشريحة مفيد لأنه يسمح لك بتعيين وتغيير مظهر جميع شرائح العرض التقديمي دفعة واحدة. Aspose.Slides يدعم آلية ماستر الشريحة من PowerPoint.

VBA أيضًا يسمح لك بالتلاعب بماستر الشريحة وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. Aspose.Slides يوفر آليات مرنة تتيح لك استخدام ماسترات الشرائح وأداء المهام الأساسية معها.

هذه هي العمليات الأساسية لماستر الشريحة:

- إنشاء أو ماستر الشريحة.
- تطبيق ماستر الشرائح على شرائح العرض التقديمي.
- تغيير خلفية ماستر الشريحة.
- إضافة صورة، عنصر نمطي، Smart Art، إلخ. إلى ماستر الشريحة.

هذه هي العمليات الأكثر تقدمًا المتعلقة بماستر الشريحة:

- مقارنة ماسترات الشريحة.
- دمج ماسترات الشريحة.
- تطبيق عدة ماسترات للشريحة.
- نسخ شريحة مع ماستر الشريحة إلى عرض تقديمي آخر.
- اكتشاف ماسترات الشريحة المكررة في العروض التقديمية.
- تعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 

قد ترغب في مراجعة Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تمثيل مباشر لبعض العمليات الأساسية الموصوفة هنا.

{{% /alert %}} 


## **كيف يتم تطبيق ماستر الشريحة**

قبل العمل مع ماستر الشريحة، قد ترغب في فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح.

* يحتوي كل عرض تقديمي على الأقل على ماستر شريحة واحد بشكل افتراضي.
* يمكن أن يحتوي العرض التقديمي على عدة ماسترات للشريحة. يمكنك إضافة عدة ماسترات للشريحة واستخدامها لتنسيق أجزاء مختلفة من العرض التقديمي بطرق مختلفة.

في **Aspose.Slides**، يتم تمثيل ماستر الشريحة بواسطة [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) النوع.

كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) من Aspose.Slides يحتوي على القائمة [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) من نوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) والتي تحتوي على قائمة بجميع الماسترات المعروفة في العرض التقديمي.

بجانب العمليات الأساسية، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) على هذه الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) هذه الطرق موروثة من وظيفة استنساخ الشريحة الأساسية. ولكن عند التعامل مع ماسترات الشريحة، تتيح لك هذه الطرق تنفيذ إعدادات معقدة.

عندما تتم إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق ماستر الشريحة عليها تلقائيًا. يتم اختيار ماستر الشريحة للشريحة السابقة افتراضيًا.

**ملاحظة**: يتم تخزين شرائح العرض التقديمي في قائمة [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--)، وتتم إضافة كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض التقديمي يحتوي على ماستر شريحة واحدة، يتم اختيار تلك الماستر لجميع الشرائح الجديدة. هذه هي السبب أنك لا يجب أن تحدد ماستر الشريحة لكل شريحة جديدة تقوم بإنشائها.

المبدأ هو نفسه لـ PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة عرض تقديمي جديد، يمكنك الضغط فقط على الخط السفلي تحت الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع ماستر الشريحة لآخر عرض تقديمي):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المقابلة باستخدام [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) الطريقة تحت فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).


## **ماستر الشريحة في تسلسل الشرائح**

استخدام تخطيطات الشرائح مع ماستر الشريحة يوفر أقصى قدر من المرونة. تتيح لك تخطيط الشريحة تعيين جميع الأنماط نفسها كما في ماستر الشريحة (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند دمج عدة تخطيطات على ماستر الشريحة، يتم إنشاء نمط جديد. عند تطبيق تخطيط الشريحة على شريحة واحدة، يمكنك تغيير نمطها عن ذلك الذي تم تطبيقه بواسطة ماستر الشريحة.

يتفوق ماستر الشريحة على جميع عناصر الإعدادات: ماستر الشريحة -> تخطيط الشريحة -> الشريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) لديه خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) مع قائمة تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) لديه خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) مع رابط على تخطيط الشريحة المطبق على الشريحة. تحدث التفاعلات بين الشريحة وماستر الشريحة من خلال تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، يتمثل جميع إعدادات الشرائح (ماستر الشريحة، تخطيط الشريحة، والشريحة نفسها) في الواقع كائنات شرائح تنفذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).
* لذلك، قد تنفذ كل من ماستر الشريحة وتخطيط الشريحة نفس الخصائص وتحتاج إلى معرفة كيف سيتم تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). يتم تطبيق ماستر الشريحة أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كانت ماستر الشريحة وتخطيط الشريحة كلاهما يحتويان على قيمة خلفية، ستنتهي الشريحة بخلفية تخطيط الشريحة.

{{% /alert %}}


## **ما الذي يتضمنه ماستر الشريحة**

لفهم كيف يمكن تغيير ماستر الشريحة، تحتاج إلى معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) .

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) الحصول على/تعيين خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - الحصول على/تعيين أنماط النص لجسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) الحصول على/تعيين كل الأشكال في ماستر الشريحة (عناصر نمطية، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) الحصول على/تعيين عناصر تحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - الحصول على مدير السمة.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - الحصول على مدير الرأس والتذييل.

طرق ماستر الشريحة:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - الحصول على جميع الشرائح التي تعتمد على ماستر الشريحة.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - يتيح لك إنشاء ماستر شريحة جديدة بناءً على ماستر الشريحة الحالي وسمة جديدة. سيتم بعد ذلك تطبيق ماستر الشريحة الجديدة على جميع الشرائح المعتمدة.


## **الحصول على ماستر الشريحة**

في PowerPoint، يمكن الوصول إلى ماستر الشريحة من قائمة العرض -> ماستر الشريحة:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى ماستر الشريحة بهذه الطريقة: 

```php
  $pres = new Presentation();
  try {
    # يمنح الوصول إلى ماستر الشريحة للعرض التقديمي
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

واجهة [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) تمثل ماستر الشريحة. خاصية [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) ( المرتبطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) ) تحتوي على قائمة بجميع ماسترات الشرائح التي تم تعريفها في العرض التقديمي.


## **إضافة صورة إلى ماستر الشريحة**

عندما تضيف صورة إلى ماستر الشريحة، ستظهر تلك الصورة على جميع الشرائح المعتمدة على تلك الماستر.

على سبيل المثال، يمكنك وضع شعار شركتك وعدد من الصور على ماستر الشريحة ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة. 

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى ماستر الشريحة مع Aspose.Slides:

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

لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع المقالة [إطار الصورة](/slides/ar/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نمطي إلى ماستر الشريحة**

هذه الحقول النصية هي عناصر نمطية قياسية على ماستر الشريحة:

* انقر لتحرير نمط عنوان الماستر

* تحرير أنماط نص الماستر

* المستوى الثاني

* المستوى الثالث 

  كما تظهر أيضًا على الشرائح المعتمدة على ماستر الشريحة. يمكنك تحرير تلك العناصر النمطية على ماستر الشريحة وستطبق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نمطي من خلال المسار ماستر الشريحة -> إدراج عنصر نمطي:

![todo:image_alt_text](slide-master_5.png)

دعونا نفحص مثالًا أكثر تعقيدًا لعنصر نمطي باستخدام Aspose.Slides. اعتبر شريحة تحتوي على عناصر نمطية موضوعة من ماستر الشريحة:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي في ماستر الشريحة بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولًا، نسترجع محتوى عنصر النمط الخاص بالعناصر من كائن ماستر الشريحة ثم نستخدم حقل `PlaceHolder.FillFormat`:

```php

```

سيتغير نمط العنوان وتنسيقه لجميع الشرائح المعتمدة على ماستر الشريحة:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [تعيين نص التوجيه في عنصر النمط](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية على ماستر الشريحة**

عندما تقوم بتغيير لون خلفية ماستر الشريحة، ستحصل جميع الشرائح العادية في العرض التقديمي على اللون الجديد. يقوم هذا الشيفرة PHP بإظهار العملية:

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

- [خلفية العرض التقديمي](https://docs.aspose.com/slides/php-java/presentation-background/)

- [سمة العرض التقديمي](https://docs.aspose.com/slides/php-java/presentation-theme/)

  {{% /alert %}}

## **استنساخ ماستر الشريحة إلى عرض تقديمي آخر**

لاستنساخ ماستر الشريحة إلى عرض تقديمي آخر، استدعِ الطريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض التقديمي وجهة بالتوازي مع ماستر الشريحة الممررة إليه. تظهر هذه الشيفرة PHP كيفية استنساخ ماستر الشريحة إلى عرض تقديمي آخر:

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


## **إضافة عدة ماسترات للشرائح إلى العرض التقديمي**

Aspose.Slides يتيح لك إضافة عدة ماسترات للشرائح وتخطيطات إلى أي عرض تقديمي معين. هذا يسمح لك بإعداد الأنماط، التخطيطات، وخيارات التنسيق لشرائح العرض التقديمي بطرق متعددة.

في PowerPoint، يمكنك إضافة ماسترات جديدة وتخطيطات (من قائمة "ماستر الشريحة") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة ماستر شريحة جديدة من خلال استدعاء الطريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```php
  # يضيف شريحة ماستر جديدة
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);

```


## **مقارنة ماسترات الشريحة**

تقوم ماستر الشريحة بتنفيذ واجهة [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) التي تحتوي على طريقة [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) ويمكن استخدامها لمقارنة الشرائح. ترجع `true` لماسترات الشرائح المتطابقة في الهيكل والمحتوى الثابت.

تكون ماسترات الشرائح متساوية إذا كانت أشكالها، أنماطها، نصوصها، الرسوم المتحركة وإعداداتها الأخرى متساوية وغيرها. لا تأخذ المقارنة قيم المعرفات الفريدة (مثل SlideId) والمحتويات الديناميكية (مثل قيمة التاريخ الحالي في عنصر التاريخ) في الاعتبار. 


## **تعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي**

Aspose.Slides يسمح لك بتعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي. تُظهر هذه الشيفرة كيفية تعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي:

```php
  # يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
  $presentation = new Presentation();
  try {
    # يحدد العرض الافتراضي كعرض ماستر الشريحة
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # يحفظ العرض التقديمي
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **إزالة ماستر الشرائح غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة  [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) ) للسماح لك بحذف الماسترات غير المرغوبة وغير المستخدمة. توضح هذه الشيفرة PHP كيفية إزالة ماستر شريحة من عرض تقديمي PowerPoint:

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
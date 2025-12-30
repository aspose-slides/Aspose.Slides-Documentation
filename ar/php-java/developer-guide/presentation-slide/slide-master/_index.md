---
title: إدارة ماسترات الشرائح في PHP
linktitle: ماستر الشريحة
type: docs
weight: 70
url: /ar/php-java/slide-master/
keywords:
- ماستر الشريحة
- شريحة ماستر
- شريحة ماستر PPT
- عدة شرائح ماستر
- مقارنة شرائح ماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة ماسترات الشرائح في Aspose.Slides للـ PHP عبر Java: إنشاء، تعديل وتطبيق القوالب والسمات والعناصر النائبة على ملفات PPT و PPTX و ODP مع أمثلة مختصرة."
---

## **ما هو سلايد ماستر (Slide Master) في PowerPoint**

**سلايد ماستر** هو قالب شريحة يحدد التخطيط والأنماط والموضوع والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة عروض) بنفس النمط والقالب لشركتك، يمكنك استخدام سلايد ماستر.

سلايد ماستر مفيد لأنه يتيح لك ضبط وتغيير مظهر جميع شرائح العرض مرة واحدة. تدعم Aspose.Slides آلية سلايد ماستر من PowerPoint.

كما يتيح VBA التحكم بسلايد ماستر وتنفيذ نفس العمليات المدعومة في PowerPoint: تعديل الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تسمح لك باستخدام سلايد ماستر وأداء المهام الأساسية معه.

هذه هي عمليات سلايد ماستر الأساسية:

- إنشاء أو سلايد ماستر.
- تطبيق سلايد ماستر على شرائح العرض.
- تغيير خلفية سلايد ماستر. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى سلايد ماستر.

هذه هي عمليات سلايد ماستر المتقدمة:

- مقارنة سلايد ماستر.
- دمج سلايد ماستر.
- تطبيق عدة سلايد ماستر.
- نسخ شريحة بسلايد ماستر إلى عرض تقديمي آخر.
- العثور على سلايد ماستر مكررة في العروض.
- تعيين سلايد ماستر كطريقة العرض الافتراضية للعرض.

{{% alert color="primary" %}} 

قد ترغب في تجربة Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموضحة هنا.

{{% /alert %}} 


## **كيف يتم تطبيق سلايد ماستر**

قبل العمل مع سلايد ماستر، قد ترغب في فهم كيفية استخدامه في العروض وتطبيقه على الشرائح. 

* كل عرض تقديمي يحتوي على سلايد ماستر واحد على الأقل بشكل افتراضي. 
* يمكن للعرض أن يحتوي على عدة سلايد ماستر. يمكنك إضافة عدة سلايد ماستر واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يُمثَّل سلايد ماستر بواسطة النوع [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) .

كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) ، والتي تحتوي على جميع سلايد ماستر المعرفة في العرض.

إلى جانب عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) على الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . هذه الطرق موروثة من وظيفة استنساخ الشرائح الأساسية. لكن عند التعامل مع سلايد ماستر، تسمح لك هذه الطرق بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق سلايد ماستر عليها تلقائيًا. يتم اختيار سلايد ماستر الشريحة السابقة بشكل افتراضي. 

**ملاحظة**: تُخزن شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على سلايد ماستر واحد، يتم اختيار هذا السلايد ماستر لجميع الشرائح الجديدة. وهذا هو السبب في أنك لا تحتاج إلى تحديد سلايد ماستر لكل شريحة جديدة تنشئها.

المبدأ نفسه ينطبق على PowerPoint و Aspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك الضغط على الخط السفلي تحت الشريحة الأخيرة وستُنشأ شريحة جديدة (مع سلايد ماستر العرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) تحت فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).


## **سلايد ماستر في هيكلية الشرائح**

استخدام تخطيطات الشرائح مع سلايد ماستر يتيح أقصى مرونة. يسمح تخطيط الشريحة لك بتعيين جميع الأنماط نفسها مثل سلايد ماستر (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند دمج عدة تخطيطات شرائح على سلايد ماستر، يُنشأ نمط جديد. عندما تطبق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من سلايد ماستر.

سلايد ماستر يتفوق على جميع العناصر: سلايد ماستر → تخطيط الشريحة → الشريحة:

![todo:image_alt_text](slide-master_2)



كل كائن [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) يحتوي على خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) بقائمة تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) يحتوي على خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) التي تُشير إلى تخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة وسلايد ماستر عبر تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، جميع إعدادات الشريحة (سلايد ماستر، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شريحة تنفّذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).

* لذلك، قد يطبق سلايد ماستر وتخطيط الشريحة نفس الخصائص وتحتاج إلى معرفة كيفية تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). يُطبق سلايد ماستر أولاً على الشريحة ثم يُطبق تخطيط الشريحة. على سبيل المثال، إذا كان لكل من سلايد ماستر وتخطيط الشريحة قيمة خلفية، ستنتهي الشريحة بالخلفية من تخطيط الشريحة.

{{% /alert %}}


## **ما يحتويه سلايد ماستر**

لفهم كيفية تعديل سلايد ماستر، عليك معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) الحصول/تعيين خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) الحصول/تعيين أنماط النص لجسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) الحصول/تعيين جميع أشكال سلايد ماستر (عناصر نائبة، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) الحصول/تعيين عناصر التحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) الحصول على مدير السمة.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) الحصول على مدير الرأس والتذييل.

طرق سلايد ماستر:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) الحصول على جميع الشرائح المعتمدة على سلايد ماستر.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — يسمح لك بإنشاء سلايد ماستر جديد استنادًا إلى سلايد ماستر الحالي وموضوع جديد. ثم يُطبق سلايد ماستر الجديد على جميع الشرائح المعتمدة.


## **الحصول على سلايد ماستر**

في PowerPoint، يمكن الوصول إلى سلايد ماستر عبر القائمة View → Slide Master :

![todo:image_alt_text](slide-master_3.jpg)



باستخدام Aspose.Slides، يمكنك الوصول إلى سلايد ماستر بهذه الطريقة:
```php
  $pres = new Presentation();
  try {
    # يمنح الوصول إلى شريحة الماستر في العرض التقديمي
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


واجهة [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) تمثل سلايد ماستر. خاصية [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) (المرتبطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)) تحتوي على قائمة جميع سلايد ماستر المعرفة في العرض.


## **إضافة صورة إلى سلايد ماستر**

عند إضافة صورة إلى سلايد ماستر، ستظهر تلك الصورة على جميع الشرائح المعتمدة على ذلك السلايد ماستر.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على سلايد ماستر ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى سلايد ماستر باستخدام Aspose.Slides:
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


## **إضافة عنصر نائب إلى سلايد ماستر**

هذه الحقول النصية هي عناصر نائب قياسية على سلايد ماستر:

* انقر لتحرير نمط عنوان الماستر
* تحرير أنماط نص الماستر
* المستوى الثاني
* المستوى الثالث

تظهر أيضًا على الشرائح المستندة إلى سلايد ماستر. يمكنك تحرير تلك العناصر على سلايد ماستر وستُطبق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder :

![todo:image_alt_text](slide-master_5.png)

دعنا نستعرض مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. اعتبار شريحة بها عناصر نائب مُقَيمة من سلايد ماستر:

![todo:image_alt_text](slide-master_6.png)

نرغب في تغيير تنسيق العنوان والعنوان الفرعي على سلايد ماستر بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولًا، نسترجع محتوى عنصر العنوان النائب من كائن سلايد ماستر ثم نستخدم حقل `PlaceHolder.FillFormat` :
```php

```


سيتغير نمط وتنسيق العنوان لجميع الشرائح المستندة إلى سلايد ماستر:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية على سلايد ماستر**

عند تغيير لون خلفية سلايد ماستر، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يظهر الكود PHP التالي العملية:
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

## **استنساخ سلايد ماستر إلى عرض تقديمي آخر**

لاستنساخ سلايد ماستر إلى عرض تقديمي آخر، استدعِ طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الوجهة مع تمرير سلايد ماستر إليه. يُظهر الكود PHP التالي كيفية استنساخ سلايد ماستر إلى عرض تقديمي آخر:
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



## **إضافة عدة سلايد ماستر إلى عرض تقديمي**

تسمح Aspose.Slides بإضافة عدة سلايد ماستر وتخطيطات شرائح إلى أي عرض تقديمي. يتيح ذلك ضبط الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة سلايد ماستر وتخطيطات جديدة (من قائمة "Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة سلايد ماستر جديد عبر استدعاء طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :
```php
  # يضيف شريحة ماستر جديدة
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **مقارنة سلايد ماستر**

تنفذ شريحة الماستر واجهة [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) التي تحتوي على طريقة [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` عندما تكون شرائح الماستر متطابقة في البنية والمحتوى الثابت.

تُعد شريحتا الماستر متساويتين إذا كانت الأشكال، الأنماط، النصوص، الحركات والإعدادات الأخرى متساوية. لا تُؤخذ القيم الفريدة للمعرف (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالي في عنصر التاريخ) في الاعتبار.


## **تعيين سلايد ماستر كطريقة العرض الافتراضية للعرض**

تتيح Aspose.Slides تعيين سلايد ماستر كطريقة العرض الافتراضية للعرض. طريقة العرض الافتراضية هي ما تراه أولًا عند فتح العرض.

يُظهر هذا الكود كيفية تعيين سلايد ماستر كطريقة عرض افتراضية للعرض:
```php
  # ينشئ كائن من فئة Presentation يمثل ملف العرض التقديمي
  $presentation = new Presentation();
  try {
    # يضبط العرض الافتراضي على SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # يحفظ العرض التقديمي
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **إزالة شرائح ماستر غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) لتمكينك من حذف شرائح ماستر غير مرغوب فيها وغير مستخدمة. يُظهر هذا الكود PHP كيفية إزالة شريحة ماستر من عرض PowerPoint:
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


## **الأسئلة المتكررة**

**ما هو سلايد ماستر في PowerPoint؟**

سلايد ماستر هو قالب شريحة يحدد التخطيط والأنماط والموضوعات والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. يسمح لك بضبط وتغيير مظهر جميع شرائح العرض مرة واحدة.  

**كيف يتم تطبيق سلايد ماستر في العرض؟**

كل عرض يحتوي على سلايد ماستر واحد على الأقل بشكل افتراضي. عندما تُضاف شريحة جديدة، يُطبق سلايد ماستر عليها تلقائيًا، غالبًا ما يرث سلايد ماستر الشريحة السابقة. يمكن للعرض أن يحتوي على عدة سلايد ماستر لتنسيق أجزاء مختلفة بشكل فريد.  

**ما العناصر التي يمكن تخصيصها في سلايد ماستر؟**

يتكون سلايد ماستر من عدة خصائص أساسية يمكن تخصيصها:

- **الخلفية**: ضبط خلفية الشريحة.
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.
- **Shapes**: إدارة جميع الأشكال على سلايد ماستر، بما في ذلك العناصر النائبة وإطارات الصور.
- **Controls**: التعامل مع عناصر التحكم ActiveX.
- **ThemeManager**: الوصول إلى مدير السمة.
- **HeaderFooterManager**: إدارة الرؤوس والتذييلات.  

**كيف يمكنني إضافة صورة إلى سلايد ماستر؟**

إضافة صورة إلى سلايد ماستر يضمن ظهورها على جميع الشرائح التي تعتمد على ذلك الماستر. على سبيل المثال، وضع شعار الشركة على سلايد ماستر سيظهر على كل شريحة في العرض.  

**كيف يرتبط سلايد ماستر بتخطيطات الشرائح؟**

تعمل تخطيطات الشرائح بالتكامل مع سلايد ماستر لتوفير مرونة في تصميم الشرائح. يحدد سلايد ماستر الأنماط والموضوعات العامة، بينما تسمح تخطيطات الشرائح بتنوع في ترتيب المحتوى. الهيكلية كالتالي:

- **سلايد ماستر** → يحدد الأنماط العامة.
- **تخطيط الشريحة** → يوفر ترتيبات محتوى مختلفة.
- **الشريحة** → ترث التصميم من تخطيط الشريحة.

**هل يمكن أن يكون لدي عدة سلايد ماستر في عرض واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة سلايد ماستر. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى سلايد ماستر وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثَّل سلايد ماستر بواسطة فئة [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). يمكنك الوصول إلى سلايد ماستر باستخدام طريقة [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) لكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
---
title: "إدارة ماسترات الشرائح في العرض التقديمي في JavaScript"
linktitle: "ماستر الشريحة"
type: docs
weight: 70
url: /ar/nodejs-java/slide-master/
keywords:
- "ماستر الشريحة"
- "شريحة ماستر"
- "شريحة ماستر PPT"
- "شرائح ماستر متعددة"
- "مقارنة شرائح ماستر"
- "خلفية"
- "عنصر نائب"
- "استنساخ شريحة ماستر"
- "نسخ شريحة ماستر"
- "تكرار شريحة ماستر"
- "شريحة ماستر غير مستخدمة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "إدارة ماسترات الشرائح في Aspose.Slides لـ Node.js عبر Java: إنشاء، تحرير وتطبيق التخطيطات، السمات والعناصر النائبة على ملفات PPT، PPTX و ODP مع أمثلة مختصرة."
---

## **ما هو Slide Master في PowerPoint**

**Slide Master** هو قالب شريحة يحدد التخطيط والأنماط والمظهر والخطوط والخلفية والخصائص الأخرى للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو مجموعة عروض تقديمية) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master.

يعد Slide Master مفيدًا لأنه يتيح لك تعيين وتغيير مظهر جميع شرائح العرض التقديمي مرة واحدة. Aspose.Slides يدعم آلية Slide Master من PowerPoint.

كما يسمح VBA لك بالتلاعب بـ Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. Aspose.Slides يوفر آليات مرنة لاستخدام Slide Masters وأداء المهام الأساسية معها.

هذه هي عمليات Slide Master الأساسية:

- إنشاء أو Slide Master.
- تطبيق Slides Master على شرائح العرض التقديمي.
- تغيير خلفية Slide Master. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى Slide Master.

وهذه عمليات أكثر تقدمًا تتعلق بـ Slide Master:

- مقارنة Slide Masters.
- دمج Slide Masters.
- تطبيق عدة Slide Masters.
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.
- العثور على Slide Masters مكررة في العروض التقديمية.
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموصوفة هنا.
{{% /alert %}} 

## **كيفية تطبيق Slide Master**

قبل أن تبدأ بالعمل مع Slide Master، قد ترغب في فهم كيفية استخدامه في العروض التقديمية وتطبيقه على الشرائح.

* كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. 
* يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يتم تمثيل Slide Master بـ [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) النوع.

كائن Aspose.Slides [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) يحتوي على القائمة [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) من نوع [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) التي تضم جميع الشرائح الرئيسية المعرفة في العرض التقديمي.

إلى جانب عمليات CRUD، يحتوي الصف [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) على الطرق المفيدة التالية: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-) . تُورث هذه الطرق من وظيفة استنساخ الشريحة الأساسية. ولكن عند التعامل مع Slide Masters، تسمح لك هذه الطرق بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق Slide Master عليها تلقائيًا. يتم اختيار Slide Master الخاص بالشريحة السابقة بشكل افتراضي.

**ملاحظة**: تُخزن شرائح العرض التقديمي في القائمة [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على Slide Master واحد، يتم اختيار هذا الـ Slide Master لجميع الشرائح الجديدة. هذا هو السبب في أنك لا تحتاج إلى تعريف Slide Master لكل شريحة جديدة تُنشئها.

المبدأ نفسه ينطبق على PowerPoint و Aspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف عرضًا تقديميًا جديدًا، يمكنك فقط النقر على الخط الأسفل تحت الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع Slide Master الخاص بالعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) داخل الصف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).

## **Slide Master في هيكل الشرائح**

استخدام Slide Layouts مع Slide Master يتيح أقصى مرونة. يسمح لك Slide Layout بتعيين جميع الأنماط نفسها مثل Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم الجمع بين عدة Slide Layouts على Slide Master، يتم إنشاء نمط جديد. عندما تطبق Slide Layout على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من Slide Master.

Slide Master يتفوق على جميع عناصر الإعداد: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

كل كائن [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) يحتوي على الخاصية [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) التي تُرجع قائمة من Slide Layouts. نوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) يحتوي على الخاصية [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) التي تُشير إلى Slide Layout المطبق على الشريحة. يحدث التفاعل بين الشريحة و Slide Master عبر Slide Layout.

{{% alert color="info" title="Note" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master و Slide Layout والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق صف [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). 
* لذلك، قد تُطبق Slide Master و Slide Layout نفس الخصائص ويجب أن تعرف كيف سيتم تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). يتم تطبيق Slide Master أولاً على الشريحة ثم يتم تطبيق Slide Layout. على سبيل المثال، إذا كان لكل من Slide Master و Slide Layout قيمة خلفية، ستحصل الشريحة على الخلفية من Slide Layout.
{{% /alert %}}

## **ما يتكون منه Slide Master**

لفهم كيفية تعديل Slide Master، تحتاج إلى معرفة مكوّناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) الحصول على/تعيين خلفية الشريحة. 
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) الحصول على/تعيين أنماط النص لجسم الشريحة. 
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) الحصول على/تعيين جميع الأشكال في Slide Master (عناصر نائبة، إطارات صور، إلخ). 
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) الحصول على/تعيين عناصر تحكم ActiveX. 
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) الحصول على مدير السمة. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) الحصول على مدير الترويسة والتذييل.

طرق Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) الحصول على جميع الشرائح التابعة لـ Slide Master. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) يتيح لك إنشاء Slide Master جديد بناءً على الـ Slide Master الحالي وسمة جديدة. ثم يُطبق الـ Slide Master الجديد على جميع الشرائح التابعة.

## **الحصول على Slide Master**

في PowerPoint، يمكن الوصول إلى Slide Master من خلال القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يمنح الوصول إلى شريحة الماستر الخاصة بالعرض التقديمي
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


الصف [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) يمثل Slide Master. الخاصية [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (المرتبطة بنوع [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) تحتوي على قائمة بجميع Slide Masters المعرفة في العرض التقديمي.

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح التابعة لهذا الـ Master.

على سبيل المثال، يمكنك وضع شعار شركتك وعدد من الصور على Slide Master ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى Slide Master باستخدام Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/nodejs-java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى Slide Master**

هذه الحقول النصية هي عناصر نائب قياسية على Slide Master:

* Click to edit Master title style
* Edit Master text styles
* Second level
* Third level

تظهر أيضًا على الشرائح المستندة إلى Slide Master. يمكنك تحرير تلك العناصر النائبة على Slide Master وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر المسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنتفحص مثالًا أكثر تعقيدًا للعناصر النائبة باستخدام Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب مُنمذجّة من Slide Master:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على Slide Master بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر نائب العنوان من كائن Slide Master ثم نستخدم الحقل `PlaceHolder.FillFormat`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


سيتغير نمط العنوان والتنسيق لجميع الشرائح المستندة إلى الـ Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على Slide Master**

عند تغيير لون خلفية شريحة رئيسية، ستتلقى جميع الشرائح العادية في العرض اللون الجديد. يوضح هذا الشيفرة JavaScript العملية:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)
{{% /alert %}}

## **استنساخ Slide Master إلى عرض تقديمي آخر**

لاستنساخ Slide Master إلى عرض تقديمي آخر، استدعِ طريقة [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) من العرض الهدف مع تمرير Slide Master إليه. يوضح هذا الكود JavaScript كيفية استنساخ Slide Master إلى عرض آخر:
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```


## **إضافة عدة Slide Masters إلى العرض التقديمي**

Aspose.Slides يتيح لك إضافة عدة Slide Masters و Slide Layouts إلى أي عرض تقديمي. يتيح لك ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة Slide Masters وتخطيطات جديدة (من "قائمة Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد عبر استدعاء طريقة [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):
```javascript
// يضيف شريحة رئيسية جديدة
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة Slide Masters**

Slide Master يُطبق صف [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) الذي يحتوي على طريقة [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` عندما تكون Slide Masters متماثلة في البنية والمحتوى الثابت.

تُعتبر Slide Masters متساوية إذا كانت الأشكال والأنماط والنصوص والأنيميشن والإعدادات الأخرى متساوية. المقارنة لا تأخذ قيم المعرّفات الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ) في الاعتبار.

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

Aspose.Slides يتيح لك تعيين Slide Master كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولًا عند فتح العرض.

يُظهر هذا الكود كيفية تعيين Slide Master كعرض افتراضي للعرض باستخدام JavaScript:
```javascript
// تنشئ كلاس Presentation الذي يمثل ملف العرض التقديمي
var presentation = new aspose.slides.Presentation();
try {
    // يضبط العرض الافتراضي كـ SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة Slide Master غير المستخدم**

Aspose.Slides يوفر طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (من صف [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) للسماح لك بحذف شرائح Master غير المرغوب فيها وغير المستخدمة. يُظهر هذا الكود JavaScript كيفية إزالة شريحة Master من عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط والأنماط والمظاهر والخطوط والخلفية والخصائص الأخرى للشرائح في عرض تقديمي. يتيح لك تعيين وتغيير مظهر جميع شرائح العرض مرة واحدة.  

**كيف يتم تطبيق Slide Master في عرض تقديمي؟**

كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. عندما تُضاف شريحة جديدة، يُطبق عليها Slide Master تلقائيًا، عادةً ما يرث الـ Master من الشريحة السابقة. يمكن للعرض أن يحوي عدة Slide Masters لتنسيق أجزاء مختلفة بصورة فريدة.  

**ما العناصر التي يمكن تخصيصها في Slide Master؟**

يتكون Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تعيين خلفية الشريحة. 
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة. 
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور. 
- **Controls**: معالجة عناصر التحكم ActiveX. 
- **ThemeManager**: الوصول إلى مدير السمات. 
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.  

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master يضمن ظهورها على جميع الشرائح التابعة لهذا الـ Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهر على كل شريحة في العرض.  

**كيف يرتبط Slide Master بـ Slide Layouts؟**

تعمل Slide Layouts بالتنسيق مع Slide Master لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط العامة والسمات، تسمح Slide Layouts بتنوع ترتيب المحتوى. التسلسل الهرمي كالتالي:

- **Slide Master** → يحدد الأنماط العامة. 
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة. 
- **Slide** → يرث التصميم من Slide Layout الخاص به.  

**هل يمكن أن يكون لدي عدة Slide Masters في عرض تقديمي واحد؟**

نعم، يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، ما يمنح مرونة في التصميم.  

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثل Slide Master الصف [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). يمكنك الوصول إلى Slide Master باستخدام طريقة [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) لكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
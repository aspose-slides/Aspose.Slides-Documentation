---
title: "الشريحة الرئيسية"
type: docs
weight: 70
url: /ar/nodejs-java/slide-master/
keywords: "إضافة شريحة رئيسية, شريحة رئيسية PPT, الشريحة الرئيسية في PowerPoint, صورة إلى الشريحة الرئيسية, عنصر نائب, شرائح رئيسية متعددة, مقارنة الشرائح الرئيسية, Java, Aspose.Slides لـ Node.js عبر Java"
description: "إضافة أو تعديل الشريحة الرئيسية في عرض تقديمي PowerPoint باستخدام JavaScript"
---

## **ما هي الشريحة الرئيسية في PowerPoint**

**الشريحة الرئيسية** هي قالب شريحة يحدد التخطيط، الأنماط، السمة، الخطوط، الخلفية والخصائص الأخرى للشرائح في عرض تقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام الشريحة الرئيسية. 

تُعد الشريحة الرئيسية مفيدة لأنها تتيح لك ضبط وتغيير مظهر جميع شرائح العرض التقديمي دفعة واحدة. تدعم Aspose.Slides آلية الشريحة الرئيسية من PowerPoint. 

كما يتيح VBA لك التعامل مع الشريحة الرئيسية وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تسمح لك باستخدام الشرائح الرئيسية وأداء المهام الأساسية معها. 

هذه هي عمليات الشريحة الرئيسية الأساسية:

- إنشاء أو تعديل الشريحة الرئيسية.  
- تطبيق الشريحة الرئيسية على شرائح العرض.  
- تغيير خلفية الشريحة الرئيسية.  
- إضافة صورة، عنصر نائب، مخطط ذكي، إلخ إلى الشريحة الرئيسية.  

هذه عمليات متقدمة تشمل الشريحة الرئيسية:

- مقارنة الشرائح الرئيسية.  
- دمج الشرائح الرئيسية.  
- تطبيق عدة شرائح رئيسية.  
- نسخ شريحة مع الشريحة الرئيسية إلى عرض تقديمي آخر.  
- اكتشاف الشرائح الرئيسية المكررة في العروض.  
- تعيين الشريحة الرئيسية كعرض افتراضي للعرض التقديمي.  

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموضحة هنا.  
{{% /alert %}} 

## **كيف يتم تطبيق الشريحة الرئيسية**

قبل العمل مع الشريحة الرئيسية، قد ترغب في فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح. 

* كل عرض تقديمي يحتوي على شريحة رئيسية واحدة على الأقل افتراضيًا.  
* يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. يمكنك إضافة عدة شرائح رئيسية واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة.  

في **Aspose.Slides**، تمثل الشريحة الرئيسية النوع [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).  

كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) من النوع [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/)، والتي تضم جميع الشرائح الرئيسية المعرفة في العرض.  

إلى جانب عمليات CRUD، يحتوي الصف [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) على الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-) . تُورث هذه الطرق من وظيفة استنساخ الشرائح الأساسية، ولكن عند التعامل مع الشرائح الرئيسية تسمح لك بتنفيذ إعدادات معقدة.  

عند إضافة شريحة جديدة إلى عرض تقديمي، تُطبق الشريحة الرئيسية عليها تلقائيًا. يتم اختيار شريحة الرئيسة للشرحة السابقة افتراضيًا.  

**ملاحظة**: تُحفظ شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--)، ويُضاف كل شريحة جديدة إلى نهاية المجموعة افتراضيًا. إذا كان العرض يحتوي على شريحة رئيسية واحدة، فسيتم اختيار تلك الشريحة لجميع الشرائح الجديدة. وهذا هو السبب في عدم الحاجة لتحديد الشريحة الرئيسية لكل شريحة جديدة تُنشئها.  

المبدأ نفسه ينطبق على PowerPoint و Aspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك النقر على الخط الفاصل تحت الشريحة الأخيرة ثم تُنشأ شريحة جديدة (مع شريحة الرئيسة الأخيرة):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) داخل الصف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  

## **الشريحة الرئيسية في هيكلية الشرائح**

استخدام تخطيطات الشرائح مع الشريحة الرئيسية يتيح أقصى مرونة. يتيح لك تخطيط الشريحة ضبط جميع الأنماط نفسها كما في الشريحة الرئيسية (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات شريحة على شريحة رئيسية، يُنشأ نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من الشريحة الرئيسية.  

الشريحة الرئيسية تتفوق على جميع عناصر الإعداد: الشريحة الرئيسية → تخطيط الشريحة → الشريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) يحتوي على الخاصية [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) التي تُعيد قائمة بتخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) يمتلك الخاصية [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) التي تُشير إلى تخطيط الشريحة المُطبق على الشريحة. يحدث التفاعل بين الشريحة وتخطيط الشريحة عبر تخطيط الشريحة.  

{{% alert color="info" title="ملاحظة" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (الشريحة الرئيسية، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق الصف [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide).  
* لذلك قد تُطبق الشريحة الرئيسية وتخطيط الشريحة نفس الخصائص، وتحتاج إلى معرفة كيفية تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). تُطبق الشريحة الرئيسية أولاً على الشريحة ثم يُطبق تخطيط الشريحة. على سبيل المثال، إذا كان لكل من الشريحة الرئيسية وتخطيط الشريحة قيمة خلفية، فإن الشريحة ستحصل على الخلفية من تخطيط الشريحة.  
{{% /alert %}}

## **ما يتكون منه الشريحة الرئيسية**

لفهم كيفية تعديل الشريحة الرئيسية، عليك معرفة مكوناتها. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) : الحصول على/تعيين خلفية الشريحة.  
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) : الحصول على/تعيين أنماط النص للجسم.  
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) : الحصول على/تعيين جميع الأشكال في الشريحة الرئيسية (عناصر نائب، إطارات صور، إلخ).  
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) : الحصول على/تعيين عناصر تحكم ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) : الحصول على مدير السمة.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) : الحصول على مدير الرأس والتذييل.  

طرق الشريحة الرئيسية:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) : الحصول على جميع الشرائح التابعة للشريحة الرئيسية.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : يسمح لك بإنشاء شريحة رئيسية جديدة بناءً على الشريحة الحالية وسمة جديدة. تُطبق الشريحة الرئيسية الجديدة بعد ذلك على جميع الشرائح التابعة.  

## **الحصول على الشريحة الرئيسية**

في PowerPoint، يمكن الوصول إلى الشريحة الرئيسية عبر القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى الشريحة الرئيسية بهذه الطريقة:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يمنح الوصول إلى الشريحة الرئيسية للعرض التقديمي
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


الصف [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) يمثل الشريحة الرئيسية. الخاصية [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (المتعلقة بنوع [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) تحتوي على قائمة بجميع الشرائح الرئيسية المعرفة في العرض.  

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى الشريحة الرئيسية، ستظهر تلك الصورة على جميع الشرائح التابعة لتلك الشريحة الرئيسية.  

على سبيل المثال، يمكنك وضع شعار شركتك وعدد من الصور على الشريحة الرئيسية ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.  

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى الشريحة الرئيسية باستخدام Aspose.Slides:  
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


{{% alert color="primary" title="انظر أيضًا" %}} 
لمزيد من المعلومات حول إضافة الصور إلى الشريحة، راجع مقالة [Picture Frame](/slides/ar/nodejs-java/picture-frame/#create-picture-frame).  
{{% /alert %}}

## **إضافة عنصر نائب إلى الشريحة الرئيسية**

هذه الحقول النصية هي عناصر نائب قياسية على الشريحة الرئيسية:

* انقر لتحرير نمط عنوان الشريحة الرئيسية  
* تحرير أنماط نص الشريحة الرئيسية  
* المستوى الثاني  
* المستوى الثالث  

تظهر أيضًا على الشرائح المستندة إلى الشريحة الرئيسية. يمكنك تحرير تلك العناصر على الشريحة الرئيسية وسيتم تطبيق التغييرات تلقائيًا على الشرائح.  

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنفحص مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب مُستمدة من الشريحة الرئيسية:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والفرعي على الشريحة الرئيسية بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر عنوان العنصر النائب من كائن الشريحة الرئيسية ثم نستخدم الحقل `PlaceHolder.FillFormat`:  
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


سيتغيّر نمط العنوان والتنسيق لجميع الشرائح المستندة إلى الشريحة الرئيسية:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)  
{{% /alert %}}

## **تغيير الخلفية على الشريحة الرئيسية**

عند تغيير لون خلفية شريحة الرئيسة، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا الكود JavaScript العملية:  
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


{{% alert color="primary" title="انظر أيضًا" %}} 
- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)  
{{% /alert %}}

## **نسخ الشريحة الرئيسية إلى عرض تقديمي آخر**

لنسخ شريحة رئيسية إلى عرض تقديمي آخر، استدعِ الطريقة [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) من العرض الوجهة مع تمرير الشريحة الرئيسية إليها. يُظهر هذا الكود JavaScript كيفية نسخ شريحة رئيسية إلى عرض تقديمي آخر:  
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


## **إضافة عدة شرائح رئيسية إلى العرض التقديمي**

تتيح لك Aspose.Slides إضافة عدة شرائح رئيسية وتخطيطات شرائح إلى أي عرض تقديمي. يتيح لك ذلك ضبط الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.  

في PowerPoint، يمكنك إضافة شرائح رئيسية وتخطيطات جديدة (من قائمة "Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة رئيسية جديدة باستدعاء الطريقة [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-):  
```javascript
// يضيف شريحة رئيسية جديدة
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة الشرائح الرئيسية**

تنفذ شريحة الرئيسة الصف [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) الذي يحتوي على الطريقة [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُرجع `true` للشرائح الرئيسة المتطابقة في الهيكل والمحتوى الثابت.  

تُعدّ شريحتا الرئيس متساويتين إذا كانت الأشكال، الأنماط، النصوص، الرسوم المتحركة والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).  

## **تعيين الشريحة الرئيسية كعرض افتراضي للعرض التقديمي**

تتيح لك Aspose.Slides تعيين شريحة رئيسية كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العرض.  

يُظهر هذا الكود كيفية تعيين شريحة رئيسية كعرض افتراضي للعرض التقديمي باستخدام JavaScript:  
```javascript
// ينشئ كائن من فئة Presentation يمثل ملف العرض التقديمي
var presentation = new aspose.slides.Presentation();
try {
    // يضبط العرض الافتراضي على SlideMasterView
    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة شريحة رئيسية غير مستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (من الصف [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) للسماح لك بحذف الشرائح الرئيسة غير المرغوبة وغير المستخدمة. يُظهر هذا الكود JavaScript كيفية إزالة شريحة رئيسية من عرض PowerPoint:  
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


## **الأسئلة الشائعة**

**ما هي الشريحة الرئيسية في PowerPoint؟**  
الشريحة الرئيسية هي قالب شريحة يحدد التخطيط، الأنماط، السمات، الخطوط، الخلفية والخصائص الأخرى للشرائح في عرض تقديمي. تسمح لك بضبط وتغيير مظهر جميع شرائح العرض دفعة واحدة.  

**كيف يتم تطبيق الشريحة الرئيسية في العرض التقديمي؟**  
كل عرض تقديمي يحتوي على شريحة رئيسية واحدة على الأقل افتراضيًا. عند إضافة شريحة جديدة، تُطبق الشريحة الرئيسية عليها تلقائيًا، عادةً ما يتم توريث شريحة الرئيسة للشرحة السابقة. يمكن للعرض أن يحتوي على عدة شرائح رئيسية لتنسيق أجزاء مختلفة بشكل فريد.  

**ما العناصر التي يمكن تخصيصها في الشريحة الرئيسية؟**  
تتكون الشريحة الرئيسية من عدة خصائص أساسية يمكن تخصيصها:  

- **Background**: تعيين خلفية الشريحة.  
- **BodyStyle**: تحديد أنماط النص للجسم.  
- **Shapes**: إدارة جميع الأشكال على الشريحة الرئيسية، بما في ذلك العناصر النائبة وإطارات الصور.  
- **Controls**: التعامل مع عناصر تحكم ActiveX.  
- **ThemeManager**: الوصول إلى مدير السمة.  
- **HeaderFooterManager**: إدارة رؤوس وتذييلات الشرائح.  

**كيف يمكنني إضافة صورة إلى الشريحة الرئيسية؟**  
إضافة صورة إلى الشريحة الرئيسية يضمن ظهورها على جميع الشرائح التابعة لتلك الشريحة. على سبيل المثال، وضع شعار الشركة على الشريحة الرئيسية سيظهره على كل شريحة في العرض.  

**كيف ترتبط الشرائح الرئيسية بتخطيطات الشرائح؟**  
تعمل تخطيطات الشرائح بالتزامن مع الشرائح الرئيسية لتوفير مرونة في تصميم الشرائح. بينما تحدد الشريحة الرئيسية الأنماط العامة والسمات، تسمح تخطيطات الشرائح بتنوع ترتيب المحتوى. تكون الهيكلية كالتالي:  

- **الشريحة الرئيسية** → تحدد الأنماط العامة.  
- **تخطيط الشريحة** → يوفر ترتيبات محتوى مختلفة.  
- **الشريحة** → ترث التصميم من تخطيط الشريحة.  

**هل يمكن أن يكون لدي عدة شرائح رئيسية في عرض تقديمي واحد؟**  
نعم، يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. يتيح لك ذلك تنسيق أقسام مختلفة من العرض بطرق متنوعة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى الشريحة الرئيسية وتعديلها باستخدام Aspose.Slides؟**  
في Aspose.Slides، تُمثل الشريحة الرئيسية الصف [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). يمكنك الوصول إلى الشريحة الرئيسية باستخدام طريقة [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) لكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
---
title: الشريحة الرئيسية
type: docs
weight: 70
url: /java/slide-master/
keywords: "إضافة شريحة رئيسية، شريحة ماستر PPT، الشريحة الرئيسية PowerPoint، صورة إلى الشريحة الرئيسية، عنصر نائب، عدة شرائح رئيسية، مقارنة الشرائح الرئيسية، Java، Aspose.Slides لـ Java"
description: "إضافة أو تعديل شريحة رئيسية في عرض PowerPoint باستخدام Java"
---

## **ما هي الشريحة الرئيسية في PowerPoint**

الشريحة الرئيسية هي قالب شريحة يحدد التخطيط، الأنماط، السمة، الخطوط، الخلفية، وغيرها من الخصائص للشرائح في العرض. إذا كنت ترغب في إنشاء عرض (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام الشريحة الرئيسية.

الشريحة الرئيسية مفيدة لأنها تتيح لك تعيين وتغيير مظهر جميع شرائح العرض دفعة واحدة. تدعم Aspose.Slides آلية الشريحة الرئيسية من PowerPoint.

كما أن VBA يسمح لك بالتلاعب بالشريحة الرئيسية وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تسمح لك باستخدام الشرائح الرئيسية وأداء المهام الأساسية معها.

هذه هي العمليات الأساسية للشريحة الرئيسية:

- إنشاء شريحة رئيسية.
- تطبيق الشرائح الرئيسية على الشرائح في العرض.
- تغيير خلفية الشريحة الرئيسية.
- إضافة صورة، عنصر نائب، فن ذكي، إلخ. إلى الشريحة الرئيسية.

هذه هي العمليات الأكثر تقدماً المتعلقة بالشريحة الرئيسية:

- مقارنة الشرائح الرئيسية.
- دمج الشرائح الرئيسية.
- تطبيق عدة شرائح رئيسية.
- نسخ الشريحة مع الشريحة الرئيسية إلى عرض آخر.
- اكتشاف الشرائح الرئيسية المكررة في العروض.
- تعيين الشريحة الرئيسية كعرض افتراضي للعرض.

{{% alert color="primary" %}} 

قد ترغب في التحقق من Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموضحة هنا.

{{% /alert %}}

## **كيف يتم تطبيق الشريحة الرئيسية**

قبل أن تعمل مع الشريحة الرئيسية، قد ترغب في فهم كيف يتم استخدامها في العروض ويتم تطبيقها على الشرائح.

* كل عرض يحتوي على شريحة رئيسية واحدة على الأقل بشكل افتراضي.
* يمكن أن يحتوي العرض على عدة شرائح رئيسية. يمكنك إضافة عدة شرائح رئيسية واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة.

في **Aspose.Slides**، يتم تمثيل الشريحة الرئيسية بواسطة [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) نوع.

تحتوي كائنات [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) الخاصة بـ Aspose.Slides على [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) قائمة تحتوي على [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) نوع، الذي يحتوي على قائمة لجميع الشرائح الرئيسية المحددة في العرض.

بالإضافة إلى عمليات CRUD، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) على هذه الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) طرق. يتم وراثة هذه الطرق من وظيفة النسخ الأساسية للشرائح. ولكن عند التعامل مع الشرائح الرئيسية، تتيح لك هذه الطرق تنفيذ إعدادات معقدة.

عندما تتم إضافة شريحة جديدة إلى عرض، يتم تطبيق الشريحة الرئيسية عليها تلقائياً. يتم اختيار الشريحة الرئيسية للشريحة السابقة بشكل افتراضي.

**ملاحظة**: يتم تخزين شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)، ويتم إضافة كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على شريحة رئيسية واحدة، يتم اختيار تلك الشريحة الرئيسية لجميع الشرائح الجديدة. هذه هي السبب في أنك لا تحتاج إلى تحديد الشريحة الرئيسية لكل شريحة جديدة تنشئها.

المبدأ هو نفسه بالنسبة لـ PowerPoint و Aspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف عرضاً جديداً، يمكنك فقط الضغط على السطر السفلي تحت الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع الشريحة الرئيسية للعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المعادلة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) تحت فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **الشريحة الرئيسية في تسلسل الشرائح**

يسمح استخدام تخطيطات الشرائح مع الشريحة الرئيسية بأقصى قدر من المرونة. تسمح تخطيط الشريحة لك بتعيين جميع الأنماط ذاتها مثل الشريحة الرئيسية (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند دمج عدة تخطيطات شرائح على شريحة رئيسية، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها من النمط المطبق بواسطة الشريحة الرئيسية.

الشريحة الرئيسية تتفوق على جميع عناصر الإعداد: شريحة رئيسية -> تخطيط شريحة -> شريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) لديه خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) مع قائمة تخطيطات الشرائح. تحتوي نوع [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) على خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) مع رابط إلى تخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة والشريحة الرئيسية من خلال تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، جميع إعدادات الشرائح (الشريحة الرئيسية، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شرائح تنفذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* لذلك، قد تنفذ الشريحة الرئيسية وتخطيط الشريحة نفس الخصائص وتحتاج إلى معرفة كيف سيتم تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). يتم تطبيق الشريحة الرئيسية أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كانت الشريحة الرئيسية وتخطيط الشريحة كليهما يحتويان على قيمة خلفية، ستنتهي الشريحة بخلفية تخطيط الشريحة.

{{% /alert %}}


## **ماذا تحتوي عليه الشريحة الرئيسية**

لفهم كيفية تغيير الشريحة الرئيسية، تحتاج إلى معرفة مكوناتها. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) الحصول على/تعيين خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - الحصول على/تعيين أنماط النص لجسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) الحصول على/تعيين جميع الأشكال للشريحة الرئيسية (عناصر نائب، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) الحصول على/تعيين عناصر التحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - الحصول على مدير السمة.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - الحصول على مدير الرأس والتذييل.

طرق الشريحة الرئيسية:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - الحصول على جميع الشرائح المعتمدة على الشريحة الرئيسية.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - يسمح لك بإنشاء شريحة رئيسية جديدة بناءً على الشريحة الرئيسية الحالية وسمة جديدة. سيتم تطبيق الشريحة الرئيسية الجديدة بعد ذلك على جميع الشرائح التابعة.


## **احصل على الشريحة الرئيسية**

في PowerPoint، يمكن الوصول إلى الشريحة الرئيسية من قائمة العرض -> شريحة رئيسية:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى الشريحة الرئيسية بهذه الطريقة: 

```java
Presentation pres = new Presentation();
try {
    // يعطي الوصول إلى الشريحة الرئيسية لعرض تقديمي
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

تشير واجهة [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) إلى الشريحة الرئيسية. تحتوي خاصية [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (المتعلقة بـ [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) نوع) على قائمة بجميع الشرائح الرئيسية المحددة في العرض. 


## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى الشريحة الرئيسية، ستظهر تلك الصورة على جميع الشرائح المعتمدة على تلك الشريحة الرئيسية.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على الشريحة الرئيسية ثم العودة إلى وضع تحرير الشرائح. يجب أن تظهر الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى الشريحة الرئيسية باستخدام Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="انظر أيضًا" %}} 

للحصول على مزيد من المعلومات حول إضافة الصور إلى الشريحة، راجع مقال [إطار الصورة](/slides/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نائب إلى الشريحة الرئيسية**

تعتبر هذه الحقول النصية عناصر نائب قياسية على الشريحة الرئيسية:

* انقر لتعديل أسلوب عنوان الشريحة الرئيسية

* تعديل أنماط نص الشريحة الرئيسية

* المستوى الثاني

* المستوى الثالث 

  كما تظهر أيضًا على الشرائح المستندة إلى الشريحة الرئيسية. يمكنك تحرير تلك العناصر النائبة على الشريحة الرئيسية وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب من خلال المسار الشريحة الرئيسية -> إدراج عنصر نائب:

![todo:image_alt_text](slide-master_5.png)

دعنا نفحص مثالًا أكثر تعقيدًا لعناصر النائب باستخدام Aspose.Slides. اعتبر شريحة بها عناصر نائب منقولة من الشريحة الرئيسية:

![todo:image_alt_text](slide-master_6.png)

نرغب في تغيير تنسيق العنوان والعنوان الفرعي على الشريحة الرئيسية بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر نائب العنوان من كائن الشريحة الرئيسية ثم نستخدم حقل `PlaceHolder.FillFormat`:

```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
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

سيتم تغيير أسلوب العنوان وتنسيقه لجميع الشرائح بناءً على الشريحة الرئيسية:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [تعيين نص المطالبات في عنصر نائب](https://docs.aspose.com/slides/java/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية في الشريحة الرئيسية**

عند تغيير اللون الخلفي لشريحة رئيسية، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يوضح هذا الرمز البرمجي في Java هذه العملية:

```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="انظر أيضًا" %}} 

- [خلفية العرض](https://docs.aspose.com/slides/java/presentation-background/)

- [سمة العرض](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **نسخ الشريحة الرئيسية إلى عرض آخر**

لنسخ الشريحة الرئيسية إلى عرض آخر، اتصل بطريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الهدف مع بطاقة شريحة رئيسية تم تمريرها لها. يظهر هذا الرمز في Java كيفية نسخ الشريحة الرئيسية إلى عرض آخر:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **إضافة عدة شرائح رئيسية إلى العرض**

تسمح لك Aspose.Slides بإضافة عدة شرائح رئيسية وتخطيطات إلى أي عرض معين. يتيح لك ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق للشرائح في عدة طرق.

في PowerPoint، يمكنك إضافة شرائح رئيسية جديدة وتخطيطات (من قائمة "الشريحة الرئيسية") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة رئيسية جديدة عن طريق استدعاء طريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```java
// يضيف شريحة رئيسية جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة الشرائح الرئيسية**

تقوم الشريحة الرئيسية بتنفيذ واجهة [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) التي تحتوي على طريقة [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) التي يمكن استخدامها بعد ذلك لمقارنة الشرائح. وتعيد `true` للشرائح الرئيسية المتطابقة في الهيكل والمحتوى الثابت.

تكون شرحتان رئيسيتان متساويتين إذا كانت أشكالهما، وأنماطها، ونصوصها، والرسوم المتحركة وغيرها من الإعدادات، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد (مثل SlideId) والمحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).


## **تعيين الشريحة الرئيسية كعرض افتراضي للعرض**

تسمح لك Aspose.Slides بتعيين شريحة رئيسية كعرض افتراضي للعرض. يوضح لك هذا الرمز كيفية تعيين شريحة رئيسية كعرض افتراضي للعرض في Java:

```java
// يقوم بإنشاء كائن من فئة Presentation التي تمثل ملف العرض
Presentation presentation = new Presentation();
try {
    // تعيين العرض الافتراضي كعرض الشريحة الرئيسية
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // حفظ العرض
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إزالة شريحة رئيسية غير مستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يوضح هذا الرمز بلغة Java كيفية إزالة شريحة رئيسية من عرض PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```
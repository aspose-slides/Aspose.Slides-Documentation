---
title: شريحة رئيسية
type: docs
weight: 70
url: /androidjava/slide-master/
keywords: "إضافة شريحة رئيسية، شريحة رئيسية PPT، شريحة رئيسية PowerPoint، صورة إلى شريحة رئيسية، عنصر نائب، عدة شرائح رئيسية، مقارنة الشرائح الرئيسية، جافا، Aspose.Slides لأندرويد عبر جافا"
description: "إضافة أو تعديل شريحة رئيسية في عرض PowerPoint في جافا"
---

## **ما هي الشريحة الرئيسية في PowerPoint**

الشريحة الرئيسية هي قالب شريحة يُحدد التخطيط، والأنماط، والثيم، والخطوط، والخلفية، وخصائص أخرى للشرائح في عرض تقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة من العروض التقديمية) بنفس النمط والقالب لشركتك، يمكنك استخدام الشريحة الرئيسية.

تعتبر الشريحة الرئيسية مفيدة لأنها تسمح لك بضبط وتغيير مظهر جميع شرائح العرض التقديمي دفعة واحدة. تدعم Aspose.Slides آلية الشريحة الرئيسية من PowerPoint.

يتيح لك VBA أيضًا التلاعب بالشريحة الرئيسية وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، وإضافة الأشكال، وتخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تتيح لك استخدام الشرائح الرئيسية وأداء المهام الأساسية معها.

هذه هي العمليات الأساسية للشريحة الرئيسية:

- إنشاء أو تعديل الشريحة الرئيسية.
- تطبيق الشرائح الرئيسية على شرائح العرض التقديمي.
- تغيير خلفية الشريحة الرئيسية.
- إضافة صورة، عنصر نائب، فن ذكي، إلخ إلى الشريحة الرئيسية.

هذه هي العمليات الأكثر تقدمًا المتعلقة بالشريحة الرئيسية:

- مقارنة الشرائح الرئيسية.
- دمج الشرائح الرئيسية.
- تطبيق عدة شرائح رئيسية.
- نسخ الشريحة مع الشريحة الرئيسية إلى عرض تقديمي آخر.
- اكتشاف شرائح رئيسية مكررة في العروض التقديمية.
- تعيين الشريحة الرئيسية كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على Aspose [**عارض PowerPoint على الإنترنت**](https://products.aspose.app/slides/viewer) لأنه يمثل تنفيذًا مباشرًا لبعض العمليات الأساسية الموصوفة هنا.

{{% /alert %}} 

## **كيف يتم تطبيق الشريحة الرئيسية**

قبل أن تعمل مع الشريحة الرئيسية، قد ترغب في فهم كيف تُستخدم في العروض التقديمية وكيف تُطبق على الشرائح.

* يحتوي كل عرض تقديمي على الأقل على شريحة رئيسية واحدة بشكل افتراضي.
* يمكن أن يحتوي العرض التقديمي على عدة شرائح رئيسية. يمكنك إضافة عدة شرائح رئيسية واستخدامها لتزيين أجزاء مختلفة من العرض التقديمي بطرق مختلفة.

في **Aspose.Slides**، يتم تمثيل الشريحة الرئيسية بواسطة نوع [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

كائن عرض **Aspose.Slides** [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) من نوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) التي تحتوي على قائمة بجميع الشرائح الرئيسية المحددة في العرض التقديمي.

بجانب عمليات CRUD، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) على هذه الأساليب المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). تم اشتقاق هذه الأساليب من وظيفة نسخ الشرائح الأساسية. ولكن عند التعامل مع الشرائح الرئيسية، تتيح لك هذه الأساليب تنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق الشريحة الرئيسية عليها تلقائيًا. يتم اختيار الشريحة الرئيسية للشرائح السابقة بشكل افتراضي.

**ملاحظة**: يتم تخزين شرائح العرض التقديمي في قائمة [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)، ويتم إضافة كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض التقديمي يحتوي على شريحة رئيسية واحدة، فإن هذه الشريحة الرئيسية يتم اختيارها لجميع الشرائح الجديدة. هذه هي السبب وراء عدم الحاجة لتعريف الشريحة الرئيسية لكل شريحة جديدة تقوم بإنشائها.

المبدأ هو نفسه بالنسبة لـ PowerPoint و Aspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة عرض تقديمي جديد، يمكنك ببساطة الضغط على الحد السفلي أسفل الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع الشريحة الرئيسية للعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك إجراء المهمة المعادلة باستخدام [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) الـطريقة في صنف [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).


## **الشريحة الرئيسية في تسلسل شرائح العرض**

يتيح لك استخدام تخطيطات الشرائح مع الشريحة الرئيسية تحقيق أقصى قدر من المرونة. يسمح لك تخطيط الشريحة بتعيين جميع الأنماط نفسها كالشريحة الرئيسية (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند دمج عدة تخطيطات شرائح على شريحة رئيسية، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن ذلك المطبق بواسطة الشريحة الرئيسية.

تتفوق الشريحة الرئيسية على جميع العناصر الإعدادية: شريحة رئيسية -> تخطيط شريحة -> شريحة:

![todo:image_alt_text](slide-master_2)

يتضمن كل كائن [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) مع قائمة تخطيطات الشرائح. يحتوي نوع [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) على خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) مع رابط على تخطيط شريحة مطبق على الشريحة. تحدث التفاعلات بين الشريحة والشريحة الرئيسية من خلال تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، جميع إعدادات الشرائح (الشريحة الرئيسية، تخطيط الشريحة، والشريحة نفسها) هي في الحقيقة كائنات شرائح تقوم بتنفيذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).
* لذلك، قد تقوم الشريحة الرئيسية وتخطيط الشريحة بتنفيذ نفس الخصائص وأنت بحاجة إلى معرفة كيفية تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). يتم تطبيق الشريحة الرئيسية أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كانت كل من الشريحة الرئيسية وتخطيط الشريحة تحتويان على قيمة خلفية، ستنتهي الشريحة بخلفية من تخطيط الشريحة.

{{% /alert %}}


## **ما تتكون منه الشريحة الرئيسية**

لفهم كيفية تغيير الشريحة الرئيسية، تحتاج إلى معرفة مكوناتها. وهذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) الحصول على/تعيين خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - الحصول على/تعيين أنماط النص لجسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) الحصول على/تعيين جميع الأشكال في الشريحة الرئيسية (عناصر نائب، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) الحصول على/تعيين عناصر تحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - الحصول على إدارة الثيم.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - الحصول على إدارة الرأس والتذييل.

طرق الشريحة الرئيسية:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - الحصول على جميع الشرائح المعتمدة على الشريحة الرئيسية.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - يتيح لك إنشاء شريحة رئيسية جديدة بناءً على الشريحة الرئيسية الحالية وثيم جديدة. ستتطبق الشريحة الرئيسية الجديدة على جميع الشرائح التابعة.

## **احصل على الشريحة الرئيسية**

في PowerPoint، يمكن الوصول إلى الشريحة الرئيسية من قائمة عرض -> شريحة رئيسية:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى الشريحة الرئيسية بهذه الطريقة: 

```java
Presentation pres = new Presentation();
try {
    // يمنح الوصول إلى الشريحة الرئيسية للعرض
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

تمثل واجهة [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) الشريحة الرئيسية. خاصية [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (المتعلقة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) تحتوي على قائمة بجميع الشرائح الرئيسية المحددة في العرض التقديمي. 

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى الشريحة الرئيسية، ستظهر تلك الصورة على جميع الشرائح التابعة لتلك الشريحة الرئيسية.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على الشريحة الرئيسية ثم العودة إلى وضع تحرير الشريحة. يجب أن ترى الصورة على كل شريحة.

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

لمزيد من المعلومات حول إضافة الصور إلى الشريحة، راجع مقالة [إطار الصورة](/slides/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نائب إلى الشريحة الرئيسية**

هذه الحقول النصية هي عناصر نائب قياسية على الشريحة الرئيسية:

* انقر لتحرير نمط عنوان الشريحة الرئيسية

* تحرير أنماط نص الشريحة الرئيسية

* المستوى الثاني

* المستوى الثالث 

   تظهر أيضًا على الشرائح المستندة إلى الشريحة الرئيسية. يمكنك تحرير تلك العناصر النائبة على الشريحة الرئيسية وستُطبق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب من خلال مسار الشريحة الرئيسية -> إدراج عنصر نائب:

![todo:image_alt_text](slide-master_5.png)

لنلقي نظرة على مثال أكثر تعقيدًا لعناصر النائب باستخدام Aspose.Slides. ضع في اعتبارك شريحة بها عناصر نائب تم تصميمها من الشريحة الرئيسية:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على الشريحة الرئيسية بهذه الطريقة:

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

ستتغير نمط التنسيق والعنوان لجميع الشرائح استنادًا إلى الشريحة الرئيسية:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [تعيين نص التلميح في عنصر نائب](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية على الشريحة الرئيسية**

عند تغيير لون خلفية الشريحة الرئيسية، ستحصل جميع الشرائح العادية في العرض التقديمي على اللون الجديد. يوضح هذا الكود الجافا العملية:

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

- [خلفية العرض التقديمي](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [ثيم العرض التقديمي](https://docs.aspose.com/slides/androidjava/presentation-theme/)

  {{% /alert %}}

## **نسخ الشريحة الرئيسية إلى عرض تقديمي آخر**

لنسخ الشريحة الرئيسية إلى عرض تقديمي آخر، قم باستدعاء الطريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض التقديمي الوجهة جنبًا إلى جنب مع الشريحة الرئيسية الممررة إليها. يُظهر هذا الكود الجافا كيفية نسخ الشريحة الرئيسية إلى عرض تقديمي آخر:

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **إضافة عدة شرائح رئيسية إلى العرض التقديمي**

تسمح لك Aspose.Slides بإضافة عدة شرائح رئيسية وتخطيطات شرائح إلى أي عرض تقديمي مُعطى. وهذا يتيح لك إعداد الأنماط، والتخطيطات، وخيارات التنسيق لشرائح العرض التقديمي بطرق عديدة.

في PowerPoint، يمكنك إضافة شرائح رئيسية وتخطيطات جديدة (من قائمة "شريحة رئيسية") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة رئيسية جديدة عن طريق استدعاء الطريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```java
// يضيف شريحة رئيسية جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة الشرائح الرئيسية**

تقوم الشريحة الرئيسية بتنفيذ واجهة [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) التي تحتوي على الطريقة [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والتي يمكن استخدامها بعد ذلك لمقارنة الشرائح. ترجع القيمة `true` للشرائح الرئيسية المتطابقة في الهيكل والمحتوى الثابت.

تكون الشريحتان الرئيسية متساويتين إذا كانت أشكالهما، وأنماطها، ونصوصها، ورسومها المتحركة وغيرها من الإعدادات، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة (مثل SlideId) والمحتوى الديناميكي (مثل القيمة الحالية في عنصر نائب التاريخ). 

## **تعيين الشريحة الرئيسية كعرض افتراضي للعرض التقديمي**

تتيح لك Aspose.Slides تعيين شريحة رئيسية كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح عرض تقديمي.

يوضح هذا الكود كيفية تعيين شريحة رئيسية كعرض افتراضي للعرض التقديمي في جافا:

```java
// يقوم بتهيئة صنف Presentation الذي يمثل ملف العرض التقديمي
Presentation presentation = new Presentation();
try {
    // تعيين العرض الافتراضي كعرض شريحة رئيسية
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // حفظ العرض التقديمي
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إزالة الشريحة الرئيسية غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من صنف [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يُظهر هذا الكود الجافا كيفية إزالة شريحة رئيسية من عرض تقديمي PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```
---
title: إدارة أسس شرائح العرض التقديمي في Java
linktitle: شريحة الأساس
type: docs
weight: 70
url: /ar/java/slide-master/
keywords:
- شريحة أساس
- شريحة أساسية
- شريحة أساسية PPT
- شرائح أساسية متعددة
- مقارنة الشرائح الأساسية
- خلفية
- عنصر نائب
- استنساخ شريحة أساسية
- نسخ شريحة أساسية
- تكرار شريحة أساسية
- شريحة أساسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة شرائح الأساس في Aspose.Slides لـ Java: إنشاء وتحرير وتطبيق التخطيطات والسمات والعناصر النائبة على ملفات PPT و PPTX و ODP مع أمثلة Java مختصرة."
---

## **ما هي شريحة الأساس في PowerPoint**

شريحة **الأساس** هي قالب شريحة يحدد التخطيط والأنماط والموضوع والخطوط والخلفية والخصائص الأخرى للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة عروض) بنفس النمط والقالب لشركتك، يمكنك استخدام شريحة الأساس.

تُعد شريحة الأساس مفيدة لأنها تتيح لك ضبط وتغيير مظهر جميع شرائح العرض مرة واحدة. تدعم Aspose.Slides آلية شريحة الأساس من PowerPoint.

كما يتيح VBA تعديل شريحة الأساس وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة تسمح لك باستخدام شرائح الأساس وأداء المهام الأساسية معها.

هذه هي عمليات شريحة الأساس الأساسية:

- إنشاء أو شريحة أساس.
- تطبيق شريحة الأساس على شرائح العرض.
- تغيير خلفية شريحة الأساس. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى شريحة الأساس.

هذه هي العمليات المتقدمة التي تتضمن شريحة الأساس:

- مقارنة شرائح الأساس.
- دمج شرائح الأساس.
- تطبيق عدة شرائح أساس.
- نسخ شريحة مع شريحة أساس إلى عرض تقديمي آخر.
- العثور على شرائح أساس مكررة في العروض.
- تعيين شريحة الأساس كعرض افتراضي للعرض.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموضحة هنا.
{{% /alert %}} 

## **كيف يتم تطبيق شريحة الأساس**

قبل العمل مع شريحة الأساس، قد ترغب في فهم كيفية استخدامها في العروض وتطبيقها على الشرائح.

* كل عرض تقديمي يحتوي على شريحة أساس واحدة على الأقل بشكل افتراضي. 
* يمكن للعرض أن يحتوي على عدة شرائح أساس. يمكنك إضافة عدة شرائح أساس واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، تمثَّل شريحة الأساس النوع [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) في Aspose.Slides يحتوي على القائمة [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)، والتي تضم جميع شرائح الأساس المعرفة في العرض.

إلى جانب عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) على الأساليب المفيدة التالية: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). هذه الأساليب موروثة من وظيفة استنساخ الشرائح الأساسية، لكن عند التعامل مع شرائح الأساس تسمح لك بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، تُطبق شريحة الأساس عليها تلقائيًا. تُختار شريحة الأساس الخاصة بالشريحة السابقة بشكل افتراضي.

**ملاحظة**: تُخزن شرائح العرض في القائمة [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على شريحة أساس واحدة، فسيتم اختيار تلك الشريحة لجميع الشرائح الجديدة. وهذا هو السبب في عدم الحاجة لتحديد شريحة الأساس لكل شريحة جديدة تنشئها.

المبدأ نفسه ينطبق على PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة شريحة جديدة يمكنك الضغط على السطر السفلي تحت الشريحة الأخيرة، ثم تُنشأ شريحة جديدة (مع شريحة الأساس الأخيرة).

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة بالأسلوب [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ضمن الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

## **شريحة الأساس في هيكل الشرائح**

استخدام تخطيطات الشرائح مع شريحة الأساس يمنح أقصى مرونة. يسمح لك تخطيط الشريحة بتعيين جميع الأنماط نفسها كما في شريحة الأساس (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات شرائح على شريحة أسس، تُنشأ نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من شريحة الأساس.

تتفوّق شريحة الأساس على جميع عناصر الإعداد: شريحة الأساس → تخطيط الشريحة → الشريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) يحتوي على الخاصية [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) التي تُعيد قائمة بتخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) يحتوي على الخاصية [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) التي تُشير إلى تخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة وشريحة الأساس عبر تخطيط الشريحة.

{{% alert color="info" title="Note" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (شريحة الأساس، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شريحة تُنفّذ الواجهة [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* لذلك، قد تُنفّذ شريحة الأساس وتخطيط الشريحة نفس الخصائص وتحتاج إلى معرفة كيفية تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). يتم تطبيق شريحة الأساس أولاً على الشريحة ثم يُطبق تخطيط الشريحة. على سبيل المثال، إذا كان لكلٍ منهما قيمة خلفية، فإن الشريحة ستحصل على الخلفية من تخطيط الشريحة.
{{% /alert %}}

## **ما الذي تحتويه شريحة الأساس**

لفهم كيفية تعديل شريحة الأساس، تحتاج إلى معرفة مكوّناتها. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) : الحصول/تعيين خلفية الشريحة.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) : الحصول/تعيين أنماط نص جسم الشريحة.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) : الحصول/تعيين جميع الأشكال في شريحة الأساس (عناصر نائب، إطارات صور، إلخ).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) : الحصول/تعيين عناصر التحكم ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) : الحصول على مدير السمات.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) : الحصول على مدير الرأس والتذييل.

أساليب شريحة الأساس:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) : الحصول على جميع الشرائح المعتمدة على شريحة الأساس.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : يتيح لك إنشاء شريحة أسس جديدة بناءً على شريحة الأساس الحالية وسمّة جديدة. ثم تُطبق شريحة الأساس الجديدة على جميع الشرائح المعتمدة.

## **الحصول على شريحة أساس**

في PowerPoint، يمكن الوصول إلى شريحة الأساس من قائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى شريحة الأساس بهذه الطريقة:
```java
Presentation pres = new Presentation();
try {
    // يمنح الوصول إلى شريحة الأساس للعرض التقديمي
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


تمثل الواجهة [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) شريحة الأساس. الخاصية [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (المربوطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) تحتوي على قائمة بجميع شرائح الأساس المعرفة في العرض.

## **إضافة صورة إلى شريحة أساس**

عند إضافة صورة إلى شريحة الأساس، ستظهر تلك الصورة على جميع الشرائح المعتمدة على تلك الشريحة.

على سبيل المثال، يمكنك وضع شعار الشركة وعدد من الصور على شريحة الأساس ثم العودة إلى وضع تحرير الشرائح. سترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى شريحة أساس باستخدام Aspose.Slides:
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


{{% alert color="primary" title="See also" %}} 
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى شريحة أساس**

هذه الحقول النصية هي عناصر نائب قياسية على شريحة الأساس:

* انقر لتعديل نمط عنوان الشريحة
* تعديل أنماط نص الشريحة
* المستوى الثاني
* المستوى الثالث

تظهر أيضًا على الشرائح المستندة إلى شريحة الأساس. يمكنك تعديل تلك العناصر على شريحة الأساس وستُطبق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنستعرض مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. افترض شريحة تحتوي على عناصر نائب مُقَـيَّدة من شريحة الأساس:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على شريحة الأساس كالتالي:

![todo:image_alt_text](slide-master_7.png)

أولاً، نستخرج محتوى عنصر العنوان من كائن شريحة الأساس ثم نستخدم الحقل `PlaceHolder.FillFormat`:
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


سيتغيّر نمط وتنسيق العنوان لجميع الشرائح المستندة إلى شريحة الأساس:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على شريحة أساس**

عند تغيير لون خلفية شريحة الأساس، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا المثال بلغة Java العملية:
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


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)
{{% /alert %}}

## **استنساخ شريحة أساس إلى عرض تقديمي آخر**

لاستنساخ شريحة أساس إلى عرض آخر، استدعِ الأسلوب [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الوجهة مع تمرير شريحة الأساس المراد استنساخها. يُظهر هذا المثال بلغة Java كيفية استنساخ شريحة أساس إلى عرض آخر:
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **إضافة عدة شرائح أساس إلى عرض تقديمي**

تتيح Aspose.Slides لك إضافة عدة شرائح أساس وتخطيطات شرائح إلى أي عرض تقديمي. يتيح لك ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة شرائح أساس جديدة وتخطيطات (من قائمة “Slide Master”) بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة أساس جديدة عبر استدعاء الأسلوب [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// يضيف شريحة أساس جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة شرائح الأساس**

تُنفّذ شريحة الأساس الواجهة [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) التي تحتوي على الأسلوب [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والذي يمكن استخدامه لمقارنة الشرائح. تُعيد القيمة true إذا كانت شرائح الأساس متطابقة في البنية والمحتوى الثابت.

تُعتبر شريحتا أساس متساويتين إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة وغيرها من الإعدادات متساوية. لا يُؤخذ في الاعتبار قيم المعرف الفريد (مثل SlideId) والمحتوى الديناميكي (مثل قيمة التاريخ في عنصر نائب التاريخ).

## **تعيين شريحة أساس كعرض افتراضي للعرض**

تسمح Aspose.Slides لك بتعيين شريحة أساس كعرض افتراضي للعرض. العرض الافتراضي هو ما تراه أولًا عند فتح العرض.

يُظهر هذا المثال بلغة Java كيفية تعيين شريحة أساس كعرض افتراضي للعرض:
```java
// ينشئ فئة Presentation التي تمثل ملف العرض التقديمي
Presentation presentation = new Presentation();
try {
    // يحدد طريقة العرض الافتراضية كـ SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة شرائح الأساس غير المستخدمة**

توفر Aspose.Slides الأسلوب [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) لتتيح لك حذف شرائح الأساس غير المرغوب فيها وغير المستخدمة. يُظهر هذا المثال بلغة Java كيفية إزالة شريحة أساس من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **الأسئلة المتكررة**

**ما هي شريحة الأساس في PowerPoint؟**

شريحة الأساس هي قالب شريحة يحدد التخطيط والأنماط والسمات والخطوط والخلفية والخصائص الأخرى للشرائح في عرض تقديمي. تتيح لك ضبط وتغيير مظهر جميع الشرائح مرة واحدة.

**كيف يتم تطبيق شريحة الأساس في العرض؟**

كل عرض يحتوي على شريحة أساس واحدة على الأقل بشكل افتراضي. عند إضافة شريحة جديدة، تُطبق شريحة الأساس عليها تلقائيًا، عادةً ما تكون شريحة الأساس للشرحة السابقة. يمكن للعرض أن يحتوي على عدة شرائح أساس لتنسيق أقسام مختلفة بطرق فريدة.

**ما العناصر التي يمكن تخصيصها في شريحة الأساس؟**

تتضمن شريحة الأساس عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تحديد خلفية الشريحة.
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.
- **Shapes**: إدارة جميع الأشكال على شريحة الأساس، بما في ذلك العناصر النائبة وإطارات الصور.
- **Controls**: التعامل مع عناصر التحكم ActiveX.
- **ThemeManager**: الوصول إلى مدير السمات.
- **HeaderFooterManager**: إدارة الرؤوس والتذييلات.

**كيف يمكنني إضافة صورة إلى شريحة أساس؟**

إضافة صورة إلى شريحة الأساس يضمن ظهورها على جميع الشرائح المعتمدة على تلك الشريحة. على سبيل المثال، وضع شعار الشركة على شريحة الأساس سيظهر على كل شريحة في العرض.

**كيف ترتبط شرائح الأساس بتخطيطات الشرائح؟**

تعمل تخطيطات الشرائح بالتكامل مع شرائح الأساس لتوفير مرونة في تصميم الشرائح. بينما تحدد شريحة الأساس الأنماط العامة والسمات، تسمح تخطيطات الشرائح بتنوع ترتيب المحتوى. التسلسل الهرمي كالتالي:

- **شريحة الأساس** → تحديد الأنماط العامة.
- **تخطيط الشريحة** → توفير ترتيبات محتوى مختلفة.
- **الشريحة** → وراثة التصميم من تخطيط الشريحة.

**هل يمكنني وجود عدة شرائح أساس في عرض واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة شرائح أساس. يتيح لك ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.

**كيف أُصلِح وأُعدِّل شريحة أساس باستخدام Aspose.Slides؟**

في Aspose.Slides، تُمثَّل شريحة الأساس بالواجهة [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). يمكنك الوصول إلى شريحة الأساس باستخدام الأسلوب [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) لكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
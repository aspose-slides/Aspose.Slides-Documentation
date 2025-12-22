---
title: إدارة ماستر شرائح العرض التقديمي على Android
linktitle: ماستر الشريحة
type: docs
weight: 70
url: /ar/androidjava/slide-master/
keywords:
- ماستر شريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
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
- Android
- Java
- Aspose.Slides
description: "إدارة ماسترات الشرائح في Aspose.Slides لنظام Android: إنشاء، تعديل وتطبيق التخطيطات والسمات والعناصر النائبة على ملفات PPT و PPTX و ODP باستخدام أمثلة Java مختصرة."
---

## **ما هو Slide Master في PowerPoint**

A **Slide Master** هو قالب شريحة يحدد التخطيط والأنماط والسمة والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. إذا كنت تريد إنشاء عرض تقديمي (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master.

Slide Master مفيد لأنه يسمح لك بتعيين وتغيير مظهر جميع شرائح العرض مرة واحدة. تدعم Aspose.Slides آلية Slide Master من PowerPoint.

VBA يتيح أيضًا التلاعب بـ Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. تقدم Aspose.Slides آليات مرنة لاستخدام Slide Masters وأداء المهام الأساسية معها.

هذه هي عمليات Slide Master الأساسية:

- إنشاء أو Slide Master.
- تطبيق Slides Master على شرائح العرض.
- تغيير خلفية Slide Master. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى Slide Master.

هذه عمليات أكثر تقدماً تتعلق بـ Slide Master:

- مقارنة Slide Masters.
- دمج Slide Masters.
- تطبيق عدة Slide Masters.
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.
- العثور على Slide Masters مكررة في العروض التقديمية.
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 

You may want to check out Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) because it is a live implementation of some of the core processes described here.

{{% /alert %}} 


## **كيف يتم تطبيق Slide Master**

قبل أن تعمل مع Slide Master، قد ترغب في فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح.

* كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. 
* يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يُمثَّل Slide Master بواسطة النوع [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)، والتي تحتوي على قائمة بجميع الشرائح الرئيسية المعرفة في العرض التقديمي.

بالإضافة إلى عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) على الطرق المفيدة التالية: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . هذه الطرق ورثت من وظيفة استنساخ الشريحة الأساسية. لكن عند التعامل مع Slide Masters، تسمح لك هذه الطرق بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى عرض تقديمي، يُطبّق Slide Master عليها تلقائيًا. يتم اختيار Slide Master الخاص بالشريحة السابقة بشكل افتراضي.

**ملاحظة**: تُخزن شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على Slide Master واحد، يتم اختيار هذا الـ Slide Master لجميع الشرائح الجديدة. هذا هو السبب في أنك لا تحتاج إلى تحديد Slide Master لكل شريحة جديدة تُنشئها.

المبدأ هو نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك الضغط على الخط السفلي تحت الشريحة الأخيرة ثم تُنشأ شريحة جديدة (بتطبيق آخر Slide Master في العرض):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة نفسها باستخدام الطريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ضمن فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).


## **Slide Master في تسلسل Slides الهرمي**

استخدام Slide Layouts مع Slide Master يتيح أقصى مرونة. يتيح لك Slide Layout تعيين جميع الأنماط نفسها مثل Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة Slide Layouts على Slide Master، يتم إنشاء نمط جديد. عند تطبيق Slide Layout على شريحة واحدة، يمكنك تغيير نمطه عن النمط المطبّق من قبل Slide Master.

Slide Master يتفوق على جميع عناصر الإعداد: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) يحتوي على خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) التي تُرجع قائمة من Slide Layouts. نوع [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) يحتوي على خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) التي تشير إلى Slide Layout المطبّق على الشريحة. يحدث التفاعل بين الشريحة وSlide Master عبر Slide Layout.

{{% alert color="info" title="Note" %}}

* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master، Slide Layout، والشريحة نفسها) هي في الواقع كائنات شريحة تُنفّذ الواجهة [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide). 
* لذا، قد تُنفّذ كل من Slide Master وSlide Layout الخصائص نفسها وتحتاج إلى معرفة كيفية تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). يتم تطبيق Slide Master أولاً على الشريحة ثم يُطبق Slide Layout. على سبيل المثال، إذا كان لكل من Slide Master وSlide Layout قيمة خلفية، ستنتهي الشريحة بخلفية Slide Layout.

{{% /alert %}}


## **ما الذي يحتويه Slide Master**

لفهم كيفية تعديل Slide Master، تحتاج إلى معرفة مكوّناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) الحصول/وضع خلفية الشريحة. 
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) الحصول/وضع أنماط النص لجسم الشريحة. 
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) الحصول/وضع جميع الأشكال في Slide Master (العناصر النائبة، إطارات الصور، إلخ). 
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) الحصول/وضع عناصر التحكم ActiveX. 
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) الحصول على مدير السمة. 
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) الحصول على مدير الترويسات والتذييلات. 

طرق Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) الحصول على جميع الشرائح التي تعتمد على Slide Master. 
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) يسمح لك بإنشاء Slide Master جديد بناءً على Slide Master الحالي وسمة جديدة. سيتم تطبيق Slide Master الجديد على جميع الشرائح التابعة.

## **الحصول على Slide Master**

في PowerPoint، يمكن الوصول إلى Slide Master من خلال القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة:
```java
Presentation pres = new Presentation();
try {
    // يمنح الوصول إلى شريحة ماستر العرض
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


واجهة [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) تمثّل Slide Master. خاصية [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (المتعلقة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) تحتوي على قائمة بجميع Slide Masters المعرفة في العرض التقديمي.

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح التابعة لهذا الـ Master.

على سبيل المثال، يمكنك وضع شعار شركتك وعدة صور على Slide Master ثم العودة إلى وضع تحرير الشرائح. سترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى Slide Master باستخدام Aspose.Slides:
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

لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/androidjava/picture-frame/#create-picture-frame).

{{% /alert %}}


## **إضافة عنصر نائب إلى Slide Master**

هذه الحقول النصية هي عناصر نائب قياسية على Slide Master:

* Click to edit Master title style
* Edit Master text styles
* Second level
* Third level

كما تظهر على الشرائح المستندة إلى Slide Master. يمكنك تعديل تلك العناصر النائبة على Slide Master وسيتم تطبيق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر المسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

دعنا نفحص مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. ضع في الاعتبار شريحة تحتوي على عناصر نائب مُقَلمة من Slide Master:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على Slide Master بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر العنوان النائب من كائن Slide Master ثم نستخدم المجال `PlaceHolder.FillFormat`:
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


سيتغير نمط العنوان وتنسيقه لجميع الشرائح المستندة إلى الـ Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية على Slide Master**

عند تغيير لون خلفية شريحة الـ Master، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يوضح هذا الكود Java العملية:
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

- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **استنساخ Slide Master إلى عرض تقديمي آخر**

لنسخ Slide Master إلى عرض تقديمي آخر، استدعِ الطريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الوجهة مع تمرير Slide Master إليه. يوضح هذا الكود Java كيفية استنساخ Slide Master إلى عرض تقديمي آخر:
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **إضافة عدة Slide Masters إلى عرض تقديمي**

تسمح لك Aspose.Slides بإضافة عدة Slide Masters وSlide Layouts إلى أي عرض تقديمي. يتيح ذلك إعداد الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة Slide Masters وتخطيطات جديدة (من "قائمة Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد عبر استدعاء الطريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// يضيف شريحة ماستر جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **مقارنة Slide Masters**

تُنفّذ شريحة الـ Master الواجهة [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) التي تحتوي على الطريقة [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` عندما تكون شرائح الـ Master متطابقة في الهيكل والمحتوى الثابت.

تُعتبر شريحتا Master متساويتين إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ في عنصر نائب التاريخ).

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

تسمح لك Aspose.Slides بتعيين Slide Master كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولًا عند فتح العرض.

يوضح هذا الكود كيفية تعيين Slide Master كعرض افتراضي للعرض التقديمي في Java:
```java
// يقوم بإنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation presentation = new Presentation();
try {
    // يضبط طريقة العرض الافتراضية إلى SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **إزالة شرائح Master غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) للسماح بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يوضح هذا الكود Java كيفية إزالة شريحة Master من عرض PowerPoint:
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

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط والأنماط والسومات والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. يتيح لك ضبط وتغيير مظهر جميع شرائح العرض مرة واحدة.  

**كيف يتم تطبيق Slide Master في عرض تقديمي؟**

كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. عندما تُضاف شريحة جديدة، يُطبق Slide Master عليها تلقائيًا، عادةً ما يرث من Master الشريحة السابقة. يمكن للعرض أن يحتوي على عدة Slide Masters لتنسيق أجزاء مختلفة بصورة فريدة.  

**ما العناصر القابلة للتخصيص في Slide Master؟**

يتكوّن Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: ضبط خلفية الشريحة. 
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة. 
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور. 
- **Controls**: معالجة عناصر التحكم ActiveX. 
- **ThemeManager**: الوصول إلى مدير السمة. 
- **HeaderFooterManager**: إدارة رؤوس وتذييلات الشرائح.  

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master يضمن ظهورها على جميع الشرائح التابعة لهذا الـ Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهر على كل شريحة في العرض.  

**كيف يرتبط Slide Master بـ Slide Layouts؟**

تعمل Slide Layouts بالتعاون مع Slide Master لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط العامة والسومات، تسمح Slide Layouts بتنوع تنظيم المحتوى. التسلسل الهرمي كالآتي:

- **Slide Master** → يحدد الأنماط العامة. 
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة. 
- **Slide** → يرث التصميم من Slide Layout الخاص به.  

**هل يمكن أن يحتوي عرض تقديمي على عدة Slide Masters؟**

نعم، يمكن للعرض أن يحتوي على عدة Slide Masters. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متنوعة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثَّل Slide Master بواجهة [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). يمكنك الوصول إلى Slide Master عبر طريقة [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) لكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
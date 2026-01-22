---
title: إدارة ماسترات شرائح العرض على Android
linktitle: ماستر الشريحة
type: docs
weight: 70
url: /ar/androidjava/slide-master/
keywords:
- ماستر الشريحة
- الشريحة الرئيسية
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- الخلفية
- العنصر النائب
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
description: "إدارة ماسترات الشرائح في Aspose.Slides لـ Android: إنشاء وتحرير وتطبيق التخطيطات والسمات والعناصر النائبة على ملفات PPT و PPTX و ODP باستخدام أمثلة Java موجزة."
---

## **ما هو Slide Master في PowerPoint**

إن **Slide Master** هو قالب شريحة يحدد التخطيط، الأنماط، السمة، الخطوط، الخلفية، وغيرها من الخصائص للشرائح في عرض تقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة من العروض) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master.  

يكون Slide Master مفيدًا لأنه يتيح لك ضبط وتغيير مظهر جميع شرائح العرض التقديمي مرة واحدة. يدعم Aspose.Slides آلية Slide Master من PowerPoint.  

كما يتيح VBA تعديل Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. يوفر Aspose.Slides آليات مرنة لاستخدام Slide Masters وأداء المهام الأساسية معها.  

هذه هي عمليات Slide Master الأساسية:
- إنشاء Slide Master.
- تطبيق Slide Master على شرائح العرض التقديمي.
- تغيير خلفية Slide Master. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى Slide Master.

هذه هي العمليات المتقدمة المتعلقة بـ Slide Master:
- مقارنة Slide Masters.
- دمج Slide Masters.
- تطبيق عدة Slide Masters.
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.
- العثور على Slide Masters مكررة في العروض التقديمية.
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 
ربما ترغب في الاطلاع على Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الواردة هنا.
{{% /alert %}} 

## **كيف يتم تطبيق Slide Master**

قبل العمل مع Slide Master، قد ترغب في فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح. 

* يحتوي كل عرض تقديمي على Slide Master واحد على الأقل بشكل افتراضي. 
* يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يُمثَّل Slide Master بواسطة النوع [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) .  

كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) ، والتي تحتوي على جميع الشرائح الرئيسية المعرفة في العرض.  

إلى جانب عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) على الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و[**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . هذه الطرق موروثة من دالة استنساخ الشرائح الأساسية، لكن عند التعامل مع Slide Masters تسمح لك بتنفيذ إعدادات معقدة.  

عند إضافة شريحة جديدة إلى عرض تقديمي، يُطبق Slide Master عليها تلقائيًا. يتم اختيار Slide Master الخاص بالشريحة السابقة بشكل افتراضي.  

**Note**: تُخزن شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان للعرض Master واحد فقط، يتم اختيار ذلك Master لجميع الشرائح الجديدة. وهذا هو السبب في عدم الحاجة لتعريف Slide Master لكل شريحة جديدة تُنشئها.  

المبدأ نفسه للـ PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة شريحة جديدة يمكنك الضغط على الخط السفلي تحت آخر شريحة، ثم تُنشأ شريحة جديدة (مع Slide Master الخاص بالعرض الأخير):
![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ضمن فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  

## **Slide Master في هيكل الشرائح**

استخدام Slide Layouts مع Slide Master يتيح أقصى مرونة. يسمح Slide Layout بضبط جميع الأنماط نفسها كما في Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما تُدمج عدة Slide Layouts على Slide Master يُنشأ نمط جديد. عند تطبيق Slide Layout على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من قبل Slide Master.  

Slide Master يتجاوز جميع عناصر الإعداد: Slide Master → Slide Layout → Slide:
![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) يحتوي على خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) التي تُعيد قائمة من Slide Layouts. نوع [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) يمتلك خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) التي تُشير إلى Slide Layout المطبق على الشريحة. يتم التفاعل بين الشريحة وSlide Master عبر Slide Layout.  

{{% alert color="info" title="Note" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master، Slide Layout، والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق واجهة [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).  
* لذلك قد تُطبق Slide Master وSlide Layout نفس الخصائص ويجب معرفة كيفية تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). يُطبق Slide Master أولاً على الشريحة ثم يُطبق Slide Layout. على سبيل المثال، إذا كان لكلٍ منهما قيمة خلفية، ستحصل الشريحة على الخلفية من Slide Layout.  
{{% /alert %}}

## **ما يحتويه Slide Master**

لفهم كيفية تعديل Slide Master، عليك معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) الحصول/تعيين خلفية الشريحة.  
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) الحصول/تعيين أنماط النص لجسم الشريحة.  
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) الحصول/تعيين جميع الأشكال في Slide Master (العناصر النائبة، إطارات الصور، إلخ).  
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) الحصول/تعيين عناصر التحكم ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) الحصول على مدير السمة.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) الحصول على مدير الترويسة والتذييل.  

طرق Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) الحصول على جميع الشرائح التي تعتمد على Slide Master.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) يتيح لك إنشاء Slide Master جديد بناءً على Slide Master الحالي وسمة جديدة. ثم يُطبق Slide Master الجديد على جميع الشرائح التابعة.  

## **الحصول على Slide Master**

في PowerPoint، يمكن الوصول إلى Slide Master عبر قائمة View → Slide Master:
![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة:
```java
Presentation pres = new Presentation();
try {
    // يوفر وصولًا إلى الشريحة الرئيسية للعرض التقديمي
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


واجهة [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) تمثل Slide Master. خاصية [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (المرتبطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) تحتوي على قائمة بجميع Slide Masters المعرفة في العرض.  

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح المعتمدة على ذلك الـ Master. على سبيل المثال، يمكنك وضع شعار الشركة على Slide Master ثم العودة إلى وضع تحرير الشرائح؛ ستظهر الصورة على كل شريحة.  
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

تظهر أيضًا على الشرائح المستندة إلى Slide Master. يمكنك تعديل تلك العناصر النائبة على Slide Master وتُطبق التغييرات تلقائيًا على الشرائح.  

في PowerPoint، يمكنك إضافة عنصر نائب عبر المسار Slide Master → Insert Placeholder:
![todo:image_alt_text](slide-master_5.png)

دعنا نستعرض مثالًا أكثر تعقيدًا للعناصر النائبة باستخدام Aspose.Slides. اعتبر شريحة تحوي عناصر نائب مُستندة إلى Slide Master:
![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والفرعي على Slide Master بهذه الطريقة:
![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر العنوان النائب من كائن Slide Master ثم نستخدم حقل `PlaceHolder.FillFormat`:
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


سيتغير نمط العنوان وتنسيقه لجميع الشرائح المعتمدة على الـ Slide Master:
![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على Slide Master**

عند تغيير لون خلفية شريحة الـ Master، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا الكود Java العملية:
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

لاستنساخ Slide Master إلى عرض آخر، استدعِ طريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الهدف مع تمرير Slide Master إليه. يوضح هذا الكود Java كيفية استنساخ Slide Master إلى عرض آخر:
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

يسمح Aspose.Slides بإضافة عدة Slide Masters وSlide Layouts إلى أي عرض تقديمي. يتيح ذلك ضبط الأنماط، التخطيطات، وخيارات التنسيق للشرائح بطرق متعددة.  

في PowerPoint، يمكنك إضافة Slide Masters وتخطيطات جديدة (من قائمة "Slide Master") بهذه الطريقة:
![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد عبر استدعاء طريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// يضيف شريحة ماستر جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **مقارنة Slide Masters**

تُطبق الشريحة الرئيسية واجهة [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) التي تحتوي على طريقة [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُرجع `true` إذا كانت Slide Masters متطابقة في البنية والمحتوى الثابت.  

تُعد Slide Masters متساوية إذا كان أشكالها، أنماطها، نصوصها، الرسوم المتحركة وإعداداتها الأخرى متساوية. لا تُؤخذ القيم المعرفية الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ في العنصر النائب) في الاعتبار.  

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

يسمح Aspose.Slides بتعيين Slide Master كعرض افتراضي للعرض. العرض الافتراضي هو ما تُراه أولًا عند فتح العرض.  

يُظهر هذا الكود كيفية تعيين Slide Master كعرض افتراضي للعرض باستخدام Java:
```java
// ينشئ كائنًا من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation presentation = new Presentation();
try {
    // يضبط العرض الافتراضي كـ SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة Slide Masters غير المستخدمة**

يوفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) للسماح بحذف الشرائح الرئيسية غير المرغوبة وغير المستخدمة. يُظهر هذا الكود Java كيفية إزالة Slide Master من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **الأسئلة الشائعة**

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط، الأنماط، السُمات، الخطوط، الخلفية، وغيرها من الخصائص للشرائح في عرض تقديمي. يتيح لك ضبط وتغيير مظهر جميع الشرائح مرة واحدة.  

**كيف يتم تطبيق Slide Master في عرض تقديمي؟**

كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. عند إضافة شريحة جديدة، يُطبق عليها Slide Master تلقائيًا، عادةً ما يكون Master الشريحة السابقة هو المختار. يمكن للعرض أن يحتوي على عدة Slide Masters لتنسيق أجزاء مختلفة بشكل فريد.  

**ما العناصر التي يمكن تخصيصها في Slide Master؟**

يتألف Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: ضبط خلفية الشريحة.  
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.  
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور.  
- **Controls**: التعامل مع عناصر التحكم ActiveX.  
- **ThemeManager**: الوصول إلى مدير السمة.  
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.  

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master تضمن ظهورها على جميع الشرائح التي تعتمد على ذلك الـ Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهره على كل شريحة في العرض.  

**كيف يرتبط Slide Master بـ Slide Layouts؟**

تعمل Slide Layouts بالتعاون مع Slide Master لتوفير مرونة في تصميم الشرائح. يحدد Slide Master الأنماط والسُمات العامة، بينما تسمح Slide Layouts بتنوع ترتيب المحتوى. الهرمية كالتالي:

- **Slide Master** → يحدد الأنماط العالمية.  
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة.  
- **Slide** → يرث التصميم من Slide Layout الخاص به.  

**هل يمكن أن يكون لدي عدة Slide Masters في عرض تقديمي واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة Slide Masters. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثَّل Slide Master بواجهة [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). يمكنك الوصول إلى Slide Master باستخدام طريقة [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) لكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
---
title: إدارة نماذج الشرائح في العرض التقديمي باستخدام Java
linktitle: نموذج الشريحة
type: docs
weight: 70
url: /ar/java/slide-master/
keywords:
- نموذج الشريحة
- الشريحة الرئيسية
- شريحة رئيسية لـ PPT
- شرائح رئيسية متعددة
- مقارنة الشرائح الرئيسية
- الخلفية
- عنصر نائب
- استنساخ الشريحة الرئيسية
- نسخ الشريحة الرئيسية
- تكرار الشريحة الرئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة نماذج الشرائح في Aspose.Slides لـ Java: إنشاء وتعديل وتطبيق التخطيطات والسمات وعناصر النائب على ملفات PPT و PPTX و ODP مع أمثلة Java مختصرة."
---

## **ما هو Slide Master في PowerPoint**

يُعد **Slide Master** قالبًا للشرائح يحدد التخطيط والأنماط والسمة والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة عروض تقديمية) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master. 

Slide Master مفيد لأنه يتيح لك تحديد وتغيير مظهر جميع شرائح العرض التقديمي دفعة واحدة. تدعم Aspose.Slides آلية Slide Master من PowerPoint. 

كما تسمح VBA بالتعامل مع Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة لتمكينك من استخدام Slide Masters وأداء المهام الأساسية معها. 

هذه هي عمليات Slide Master الأساسية:

- إنشاء Slide Master.  
- تطبيق Slide Master على شرائح العرض التقديمي.  
- تغيير خلفية Slide Master.  
- إضافة صورة أو عنصر نائبي أو Smart Art، إلخ إلى Slide Master.  

هذه عمليات أكثر تقدماً تتعلق بـ Slide Master: 

- مقارنة Slide Masters.  
- دمج Slide Masters.  
- تطبيق عدة Slide Masters.  
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.  
- اكتشاف Slide Masters مكررة في العروض التقديمية.  
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.  

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنّه تنفيذ مباشر لبعض العمليات الأساسية الموضحة هنا.
{{% /alert %}} 


## **كيف يتم تطبيق Slide Master**

قبل العمل مع Slide Master، قد تريد فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح. 

* كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي.  
* يمكن للعرض التقديمي أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتصميم أجزاء مختلفة من العرض بطرق مختلفة.  

في **Aspose.Slides**، يُمثَّل Slide Master بنوع [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).  

كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) في Aspose.Slides يحتوي على قائمة [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)، والتي تضم جميع الشرائح الرئيسية المُعرَّفة في العرض.  

بالإضافة إلى عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) على هذه الطرق المفيدة: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) و[**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). هذه الطرق موروثة من وظيفة استنساخ الشرائح الأساسية، ولكن عند التعامل مع Slide Masters تسمح لك بتنفيذ إعدادات معقدة.  

عند إضافة شريحة جديدة إلى عرض تقديمي، يُطبق عليها Slide Master تلقائيًا. يُختار Slide Master الخاص بالشريحة السابقة بشكل افتراضي.  

**ملاحظة**: تُخزن شرائح العرض في قائمة [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة بشكل افتراضي. إذا كان العرض يحتوي على Slide Master واحد فقط، يتم اختيار هذا الـ Slide Master لجميع الشرائح الجديدة. هذا هو السبب في عدم الحاجة لتحديد Slide Master لكل شريحة جديدة تُنشئها.  

المبدأ نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك الضغط على الخط السفلي تحت آخر شريحة ثم تُنشأ شريحة جديدة (مع Slide Master للعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ضمن فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).  


## **Slide Master في تسلسل الشرائح**

يسمح استخدام Slide Layouts مع Slide Master بأقصى مرونة. يتيح Slide Layout لك تعيين جميع الأنماط نفسها مثل Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عند دمج عدة Slide Layouts على Slide Master، يتم إنشاء نمط جديد. عندما تطبق Slide Layout على شريحة واحدة، يمكنك تغيير نمطها مقارنةً بالنمط المطبَّق من قبل Slide Master.  

Slide Master يتفوق على جميع عناصر الإعداد: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)



كل كائن [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) يحتوي على خاصية [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) التي تُعيد قائمة من Slide Layouts. نوع [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) له خاصية [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) التي تُشير إلى Slide Layout المطبَّق على الشريحة. التفاعل بين الشريحة وSlide Master يحدث عبر Slide Layout.  

{{% alert color="info" title="ملاحظة" %}}

* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master، Slide Layout، والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق واجهة [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).  
* لذلك قد يطبق Slide Master وSlide Layout نفس الخصائص ويجب أن تعرف كيف سيتم تطبيق قيمهما على كائن [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). يُطبق Slide Master أولاً على الشريحة ثم يُطبق Slide Layout. على سبيل المثال، إذا كان لكل من Slide Master وSlide Layout قيمة خلفية، ستنتهي الشريحة بخلفية Slide Layout.  

{{% /alert %}}


## **ما الذي يحتويه Slide Master**

لفهم كيفية تعديل Slide Master، عليك معرفة مكوّناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/): 

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) احصل/عيّن خلفية الشريحة.  
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) احصل/عيّن أنماط النص لجسم الشريحة.  
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) احصل/عيّن جميع الأشكال في Slide Master (العناصر النائبة، إطارات الصور، إلخ).  
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) احصل/عيّن عناصر تحكم ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) احصل على مدير السمة.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) احصل على مدير الترويسات والتذييلات.  

طرق Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) احصل على جميع الشرائح التي تعتمد على Slide Master.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) يتيح لك إنشاء Slide Master جديد بناءً على الـ Slide Master الحالي وسمة جديدة. ثم يُطبق الـ Slide Master الجديد على جميع الشرائح التابعة.  


## **الحصول على Slide Master**

في PowerPoint، يمكن الوصول إلى Slide Master من قائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)



باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة: 
```java
Presentation pres = new Presentation();
try {
    // يتيح الوصول إلى الشريحة الرئيسية للعرض التقديمي
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


واجهة [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) تمثل Slide Master. الخاصية [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (المتعلقة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) تحتوي على قائمة بجميع Slide Masters المعرَّفة في العرض.  


## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح التي تعتمد على ذلك الـ Slide Master.  

على سبيل المثال، يمكنك وضع شعار شركتك وعدد قليل من الصور على Slide Master ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.  

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


{{% alert color="primary" title="انظر أيضًا" %}} 
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نائبي إلى Slide Master**

هذه الحقول النصية هي عناصر نائبة قياسية على Slide Master: 

* اضغط لتحرير نمط عنوان Master  
* تحرير أنماط نص Master  
* المستوى الثاني  
* المستوى الثالث  

تظهر أيضًا على الشرائح المستندة إلى Slide Master. يمكنك تحرير تلك العناصر النائبة على Slide Master وسيتم تطبيق التغييرات تلقائيًا على الشرائح.  

في PowerPoint، يمكنك إضافة عنصر نائبي عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنستعرض مثالًا أكثر تعقيدًا للعناصر النائبة باستخدام Aspose.Slides. اعتبر شريحة بها عناصر نائبة مُستخرجة من Slide Master:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على Slide Master بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر النائبي للعنوان من كائن Slide Master ثم نستخدم الحقل `PlaceHolder.FillFormat`:
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


سيتغير نمط العنوان والتنسيق لجميع الشرائح المستندة إلى Slide Master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)  
{{% /alert %}}


## **تغيير الخلفية على Slide Master**

عند تغيير لون خلفية الشريحة الرئيسية، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يوضح هذا الكود Java العملية:
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
- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)  
{{% /alert %}}

## **استنساخ Slide Master إلى عرض تقديمي آخر**

لاستنساخ Slide Master إلى عرض تقديمي آخر، استدعِ طريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) من العرض الهدف مع تمرير Slide Master إليه. يُظهر هذا الكود Java كيفية استنساخ Slide Master إلى عرض تقديمي آخر:
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

تسمح Aspose.Slides لك بإضافة عدة Slide Masters وSlide Layouts إلى أي عرض تقديمي. يتيح لك ذلك ضبط الأنماط والتخطيطات وخيارات التنسيق للشرائح بطرق متعددة.  

في PowerPoint، يمكنك إضافة Slide Masters وتخطيطات جديدة (من "قائمة Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد عن طريق استدعاء طريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):
```java
// يضيف شريحة رئيسية جديدة
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **مقارنة Slide Masters**

تُطبق Slide Master واجهة [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) التي تحتوي على طريقة [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` عندما تكون Slide Masters متماثلة في الهيكل والمحتوى الثابت.  

تُعد Slide Masters متساوية إذا كانت أشكالها، أنماطها، نصوصها، الرسوم المتحركة وإعداداتها الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر النائبي Date).  


## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**

تسمح Aspose.Slides لك بتعيين Slide Master كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العرض.  

يُظهر هذا الكود كيفية تعيين Slide Master كعرض افتراضي للعرض في Java:
```java
// ينشئ كائنًا من فئة Presentation يمثل ملف العرض التقديمي
Presentation presentation = new Presentation();
try {
    // يحدد العرض الافتراضي كـ SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // يحفظ العرض التقديمي
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **إزالة Slide Masters غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) لتمكينك من حذف Slide Masters غير المرغوب فيها وغير المستخدمة. يوضح هذا الكود Java كيفية إزالة Slide Master من عرض PowerPoint:
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

Slide Master هو قالب شرائح يحدد التخطيط والأنماط والسمات والخطوط والخلفية وغيرها من الخصائص للشرائح في عرض تقديمي. يتيح لك ضبط وتغيير مظهر جميع شرائح العرض دفعة واحدة.  

**كيف يتم تطبيق Slide Master في العرض التقديمي؟**

كل عرض تقديمي يحتوي على Slide Master واحد على الأقل بشكل افتراضي. عندما تُضاف شريحة جديدة، يُطبق عليها Slide Master تلقائيًا، عادةً ما يرث Slide Master من الشريحة السابقة. يمكن للعرض أن يحتوي على عدة Slide Masters لتصميم أجزاء مختلفة بطرق فريدة.  

**ما العناصر التي يمكن تخصيصها في Slide Master؟**

يتألف Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تعيين خلفية الشريحة.  
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.  
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور.  
- **Controls**: التعامل مع عناصر تحكم ActiveX.  
- **ThemeManager**: الوصول إلى مدير السمة.  
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.  

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master تضمن ظهورها على جميع الشرائح التي تعتمد على ذلك الـ Slide Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهر على كل شريحة في العرض.  

**كيف يتفاعل Slide Masters مع Slide Layouts؟**

تعمل Slide Layouts بالتكامل مع Slide Master لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط العامة والسمات، تتيح Slide Layouts تنوعًا في ترتيب المحتوى. التسلسل الهرمي كالتالي:

- **Slide Master** → يحدد الأنماط العامة.  
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة.  
- **Slide** → يرث التصميم من Slide Layout الخاص به.  

**هل يمكن أن يكون لدي عدة Slide Masters في عرض واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة Slide Masters. يتيح لك ذلك تصميم أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثَّل Slide Master بواجهة [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). يمكنك الوصول إلى Slide Master باستخدام طريقة [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) لكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
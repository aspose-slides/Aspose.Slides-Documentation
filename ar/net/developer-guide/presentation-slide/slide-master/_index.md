---
title: إدارة ماسترات الشرائح في .NET
linktitle: ماستر الشريحة
type: docs
weight: 80
url: /ar/net/slide-master/
keywords:
- ماستر الشريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة ماسترات الشريحة في Aspose.Slides لـ .NET: إنشاء، تعديل وتطبيق التخطيطات والسمات والعناصر النائبة على PPT و PPTX و ODP مع أمثلة مختصرة بلغة C#."
---

## **ما هو Slide Master في PowerPoint**
A **Slide Master** في PowerPoint هو خاصية تتحكم في تخطيط الخطوط والأنماط عبر عدة شرائح. يساعد ذلك على الحفاظ على الاتساق والعلامة التجارية في العروض التقديمية. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة عروض) بنفس النمط والقالب لشركتك، يمكنك استخدام Slide Master.

يعد Slide Master مفيدًا لأنه يتيح لك ضبط وتغيير مظهر جميع شرائح العرض مرة واحدة. يدعم Aspose.Slides آلية Slide Master من PowerPoint.

كما يتيح VBA التلاعب بـ Slide Master وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التخطيط، إلخ. يوفر Aspose.Slides آليات مرنة لاستخدام Slide Masters وأداء المهام الأساسية معها.

هذه هي عمليات Slide Master الأساسية:

- إنشاء أو تعديل Slide Master.
- تطبيق Slide Master على شرائح العرض.
- تغيير خلفية Slide Master. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى Slide Master.

هذه عمليات أكثر تقدماً تتضمن Slide Master:

- مقارنة Slide Masters.
- دمج Slide Masters.
- تطبيق عدة Slide Masters.
- نسخ شريحة مع Slide Master إلى عرض تقديمي آخر.
- العثور على Slide Masters مكررة في العروض.
- تعيين Slide Master كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموضحة هنا.
{{% /alert %}} 

## **كيف يتم تطبيق Slide Master**
قبل العمل بـ Slide Master، قد ترغب في فهم كيفية استخدامها في العروض وتطبيقها على الشرائح.

* كل عرض تقديمي يحتوي على Slide Master واحد على الأقل افتراضياً. 
* يمكن للعرض أن يحتوي على عدة Slide Masters. يمكنك إضافة عدة Slide Masters واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يتم تمثيل Slide Master بواسطة النوع [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide).

كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في Aspose.Slides يحتوي على قائمة [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)، والتي تحتوي على جميع الشرائح الرئيسية المعرفة في العرض. 

بالإضافة إلى عمليات CRUD، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) على الطريقتين المفيدتين: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) و[**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). تلك الطُرُق موروثة من وظيفة استنساخ الشرائح الأساسية. ولكن عند التعامل مع Slide Masters، تسمح لك هذه الطُرُق بتنفيذ إعدادات معقدة. 

عند إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق Slide Master عليها تلقائياً. يتم اختيار Slide Master للشرائح السابقة افتراضياً. 

**ملاحظة**: يتم تخزين شرائح العرض في قائمة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)، وتُضاف كل شريحة جديدة إلى نهاية المجموعة افتراضياً. إذا كان العرض يحتوي على Slide Master واحد، يتم اختيار ذلك الـ Slide Master لجميع الشرائح الجديدة. هذا هو السبب في عدم الحاجة لتحديد Slide Master لكل شريحة جديدة تنشئها.

المبدأ نفسه ينطبق على PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عند إضافة شريحة جديدة، يمكنك الضغط على الخط السفلي تحت آخر شريحة لتُنشأ شريحة جديدة (مع Slide Master الخاص بالعرض الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) داخل فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

## **Slide Master في هيكلية الشرائح**
استخدام تخطيطات الشرائح مع Slide Master يتيح أقصى مرونة. يسمح لك تخطيط الشريحة (Slide Layout) بتعيين جميع الأنماط نفسها مثل Slide Master (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات شرائح على Slide Master، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها من النمط المطبق بواسطة Slide Master.

Slide Master يتفوق على جميع العناصر الأخرى: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) يحتوي على خاصية [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) مع قائمة تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) يحتوي على خاصية [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) مرتبطة بتخطيط شريحة مُطبق على الشريحة. يحدث التفاعل بين الشريحة وSlide Master عبر تخطيط الشريحة.

{{% alert color="info" title="Note" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (Slide Master، Slide Layout، والشريحة نفسها) هي في الواقع كائنات شريحة تُطبق واجهة [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).  
* لذلك، قد تُطبق Slide Master وSlide Layout نفس الخصائص ويجب معرفة كيفية تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) . يتم تطبيق Slide Master أولاً على الشريحة ثم يُطبق تخطيط الشريحة. على سبيل المثال، إذا كان لكل من Slide Master وتخطيط الشريحة قيمة خلفية، ستحصل الشريحة على الخلفية من تخطيط الشريحة.
{{% /alert %}}

## **ما الذي يحتويه Slide Master**
لفهم كيفية تعديل Slide Master، يجب أن تعرف مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/):

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - الحصول/تعيين خلفية الشريحة.  
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - الحصول/تعيين أنماط النص في جسم الشريحة.  
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - الحصول/تعيين جميع الأشكال في Slide Master (عناصر نائبة، إطارات صور، إلخ).  
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - الحصول/تعيين عناصر تحكم ActiveX.  
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - الحصول على مدير السمة.  
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - الحصول على مدير الترويسات وتذييلات الصفحات.

طرق Slide Master:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - الحصول على جميع الشرائح التي تعتمد على Slide Master.  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - يتيح لك إنشاء Slide Master جديد بناءً على Slide Master الحالي وسمة جديدة. سيتم تطبيق الـ Slide Master الجديد بعد ذلك على جميع الشرائح التابعة.

## **الحصول على Slide Master**
في PowerPoint، يمكن الوصول إلى Slide Master من خلال القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى Slide Master بهذه الطريقة:
```c#
IMasterSlide master = pres.Masters[0];
```


واجهة [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) تمثل Slide Master. خاصية [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (المتعلقة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) تحتوي على قائمة جميع Slide Masters المعرفة في العرض.

## **إضافة صورة إلى Slide Master**
عند إضافة صورة إلى Slide Master، ستظهر تلك الصورة على جميع الشرائح التي تعتمد على هذا الـ Slide Master.

على سبيل المثال، يمكنك وضع شعار الشركة وعدد من الصور على Slide Master ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى Slide Master باستخدام Aspose.Slides:
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 
لمزيد من المعلومات حول إضافة الصور إلى شريحة، راجع مقال [Picture Frame](/slides/ar/net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **إضافة عنصر نائب إلى Slide Master**
هذه الحقول النصية هي عناصر نائبة قياسية على Slide Master:

* انقر لتحرير نمط عنوان الـ Master  
* تحرير أنماط نص الـ Master  
* المستوى الثاني  
* المستوى الثالث  

تظهر هذه العناصر أيضاً على الشرائح المعتمدة على Slide Master. يمكنك تحرير تلك العناصر النائبة على Slide Master وتُطبق التغييرات تلقائياً على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر المسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنستعرض مثالاً أكثر تعقيداً للعناصر النائبة باستخدام Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائبة مُقَدمة من Slide Master:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على Slide Master بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نستعيد محتوى عنصر العنوان من كائن Slide Master ثم نستخدم حقل `PlaceHolder.FillFormat`:
```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
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
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)
{{% /alert %}}

## **تغيير الخلفية على Slide Master**
عند تغيير لون خلفية الشريحة الرئيسية، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا الكود C# العملية:
```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)  
{{% /alert %}}

## **نسخ Slide Master إلى عرض تقديمي آخر**
لنسخ Slide Master إلى عرض تقديمي آخر، استدعِ طريقة [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) من العرض الوجهة مع تمرير Slide Master إليه. يُظهر هذا الكود C# كيفية نسخ Slide Master إلى عرض تقديمي آخر:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **إضافة عدة Slide Masters إلى عرض تقديمي**
يسمح Aspose.Slides لك بإضافة عدة Slide Masters وتخطيطات شرائح إلى أي عرض تقديمي. يتيح ذلك إعداد أنماط وتخطيطات وخيارات تنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة Slide Masters وتخطيطات جديدة (من قائمة "Slide Master") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة Slide Master جديد عن طريق استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):
```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **مقارنة Slide Masters**
تُطبق شريحة الـ Master واجهة [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) التي تحتوي على طريقة [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` إذا كانت شرائح الـ Master متماثلة في الهيكل والمحتوى الثابت.

تُعتبر شريحتا Master متساويتين إذا كانت الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالي في عنصر التاريخ النائب).

## **تعيين Slide Master كعرض افتراضي للعرض التقديمي**
يسمح Aspose.Slides بتعيين Slide Master كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العرض.

يُظهر هذا الكود كيفية تعيين Slide Master كعرض افتراضي للعرض في C#:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **إزالة شرائح Master غير المستخدمة**
يوفر Aspose.Slides طريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من الفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لحذف شرائح Master غير المطلوبة وغير المستخدمة. يُظهر هذا الكود C# كيفية إزالة شريحة Master من عرض PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**ما هو Slide Master في PowerPoint؟**

Slide Master هو قالب شريحة يحدد التخطيط والأنماط والسمات والخطوط والخلفية وغيرها من الخصائص للشرائح في العرض. يتيح لك ضبط وتغيير مظهر جميع الشرائح مرة واحدة.  

**كيف يتم تطبيق Slide Master في العرض؟**

كل عرض يحتوي على Slide Master واحد على الأقل افتراضياً. عند إضافة شريحة جديدة، يُطبق عليها Slide Master تلقائياً، عادةً ما يكون Slide Master للشرائح السابقة. يمكن للعرض أن يحتوي على عدة Slide Masters لتنسيق أجزاء مختلفة بشكل فريد.  

**ما العناصر التي يمكن تخصيصها في Slide Master؟**

يتألف Slide Master من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تعيين خلفية الشريحة.  
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.  
- **Shapes**: إدارة جميع الأشكال على Slide Master، بما في ذلك العناصر النائبة وإطارات الصور.  
- **Controls**: التعامل مع عناصر تحكم ActiveX.  
- **ThemeManager**: الوصول إلى مدير السمة.  
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.  

**كيف يمكنني إضافة صورة إلى Slide Master؟**

إضافة صورة إلى Slide Master تضمن ظهورها على جميع الشرائح التي تعتمد على هذا الـ Master. على سبيل المثال، وضع شعار الشركة على Slide Master سيظهر على كل شريحة في العرض.  

**كيف يرتبط Slide Master بـ Slide Layouts؟**

تعمل Slide Layouts بالاشتراك مع Slide Master لتوفير مرونة في تصميم الشرائح. بينما يحدد Slide Master الأنماط العامة والسمات، تسمح Slide Layouts بتغيّر ترتيب المحتوى. الهيكلية كالتالي:

- **Slide Master** → يحدد الأنماط العامة.  
- **Slide Layout** → يوفر ترتيبات محتوى مختلفة.  
- **Slide** → يرث التصميم من تخطيط الشريحة الخاص به.  

**هل يمكن أن يكون لدي عدة Slide Masters في عرض واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة Slide Masters. يتيح ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.  

**كيف يمكنني الوصول إلى Slide Master وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثل Slide Master الواجهة `IMasterSlide`. يمكنك الوصول إلى Slide Master باستخدام خاصية `Masters` لكائن `Presentation`.
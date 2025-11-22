---
title: ما هو ماستر الشرائح في PowerPoint؟ التعريف ودليل الاستخدام
linktitle: ماستر الشرائح
type: docs
weight: 80
url: /ar/net/slide-master/
keywords: "Add Slide Master, PPT master slide, slide master PowerPoint, Image to Slide Master, Placeholder, Multiple Slide Masters, Compare Slide Masters, C#, Csharp, .NET, Aspose.Slides"
description: "تعرف على ما هو ماستر الشرائح في PowerPoint وكيف يساعدك في التحكم في تخطيطات الشرائح، الخطوط، الألوان، والهوية البصرية. دليل سهل خطوة بخطوة مع أمثلة في C# أو .NET."
---

## **ما هو ماستر الشرائح في PowerPoint**
ماستر **Slide Master** في PowerPoint هو ميزة تتحكم في التخطيط، الخطوط، والأنماط عبر عدة شرائح. يساعد على الحفاظ على الاتساق والعلامة التجارية في العروض التقديمية. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة عروض) بنفس النمط والقالب لشركتك، يمكنك استخدام ماستر الشرائح.

يُعد ماستر الشرائح مفيدًا لأنه يتيح لك ضبط وم تغيير مظهر جميع شرائح العرض مرة واحدة. تدعم Aspose.Slides آلية ماستر الشرائح من PowerPoint.

كما يسمح VBA بالتعامل مع ماستر الشرائح وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة الأشكال، تخصيص التخطيط، إلخ. توفر Aspose.Slides آليات مرنة لاستخدام ماستر الشرائح وأداء المهام الأساسية معه.

هذه هي عمليات ماستر الشرائح الأساسية:

- إنشاء أو ماستر الشرائح.
- تطبيق ماستر الشرائح على شرائح العرض.
- تغيير خلفية ماستر الشرائح. 
- إضافة صورة أو عنصر نائب أو Smart Art، إلخ إلى ماستر الشرائح.

هذه عمليات أكثر تقدماً تتضمن ماستر الشرائح:

- مقارنة ماسترات الشرائح.
- دمج ماسترات الشرائح.
- تطبيق عدة ماسترات شرائح.
- نسخ شريحة مع ماستر الشرائح إلى عرض تقديمي آخر.
- العثور على ماسترات الشرائح المكررة في العروض.
- تعيين ماستر الشرائح كعرض إفتراضي للعرض التقديمي.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ مباشر لبعض العمليات الأساسية الموصوفة هنا.
{{% /alert %}} 


## **كيف يتم تطبيق ماستر الشرائح**
قبل العمل مع ماستر الشرائح، قد ترغب في فهم كيفية استخدامه في العروض وتطبيقه على الشرائح.

* كل عرض تقديمي يحتوي على ماستر شرائح واحد على الأقل افتراضياً. 
* يمكن للعرض أن يحتوي على عدة ماسترات شرائح. يمكنك إضافة عدة ماسترات واستخدامها لتنسيق أجزاء مختلفة من العرض بطرق مختلفة. 

في **Aspose.Slides**، يتم تمثيل ماستر الشرائح بواسطة النوع [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide).

كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في Aspose.Slides يحتوي على قائمة [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) من النوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)، والتي تضم جميع ماسترات الشرائح المعرفة في العرض.

بالإضافة إلى عمليات CRUD، يحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) على الطرق المفيدة: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) و[**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). هذه الطرق موروثة من وظيفة استنساخ الشرائح الأساسية. لكن عند التعامل مع ماسترات الشرائح، تسمح لك هذه الطرق بتنفيذ إعدادات معقدة.

عند إضافة شريحة جديدة إلى العرض، يتم تطبيق ماستر الشرائح عليها تلقائيًا. يتم اختيار ماستر الشريحة السابقة افتراضياً.

**ملاحظة**: تُخزن شرائح العرض في قائمة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)، ويتم إضافة كل شريحة جديدة إلى نهاية المجموعة افتراضياً. إذا كان العرض يحتوي على ماستر شريحة واحد، يتم اختيار هذا الماستر لجميع الشرائح الجديدة. هذا هو السبب في أنك لست بحاجة لتحديد ماستر الشريحة لكل شريحة جديدة تنشئها.

المبدأ نفسه في PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف شريحة جديدة، يمكنك الضغط على السطر السفلي تحت الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (بتطبيق ماستر الشريحة الأخير):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك تنفيذ المهمة المكافئة باستخدام طريقة [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) داخل فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **ماستر الشرائح في هيكل Slides**
استخدام تخطيطات الشرائح مع ماستر الشرائح يتيح أقصى مرونة. يسمح تخطيط الشريحة لك بضبط جميع الأنماط نفسها مثل ماستر الشرائح (الخلفية، الخطوط، الأشكال، إلخ). ومع ذلك، عندما يتم دمج عدة تخطيطات شرائح على ماستر الشرائح، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها عن النمط المطبق من ماستر الشرائح.

ماستر الشرائح يتفوق على جميع عناصر الإعداد: ماستر الشرائح → تخطيط الشريحة → الشريحة:

![todo:image_alt_text](slide-master_2)

كل كائن [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) يحتوي على خاصية [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) التي تضم قائمة تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) يحتوي على خاصية [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) التي تربط تخطيط الشريحة المطبق على الشريحة. يحدث التفاعل بين الشريحة وماستر الشرائح عبر تخطيط الشريحة.

{{% alert color="info" title="ملاحظة" %}}
* في Aspose.Slides، جميع إعدادات الشريحة (ماستر الشرائح، تخطيط الشريحة، والشريحة نفسها) هي في الواقع كائنات شرائح تنفذ واجهة [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* لذلك، قد يشارك ماستر الشرائح وتخطيط الشريحة نفس الخصائص ويجب أن تعرف كيف سيتم تطبيق قيمها على كائن [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) . يتم تطبيق ماستر الشرائح أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كان لكل من ماستر الشرائح وتخطيط الشريحة قيمة خلفية، ستحصل الشريحة على الخلفية من تخطيط الشريحة.
{{% /alert %}}


## **ما يتكون منه ماستر الشريحة**
لفهم كيفية تغيير ماستر الشريحة، تحتاج إلى معرفة مكوناته. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - الحصول/تعيين خلفية الشريحة.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - الحصول/تعيين أنماط النص لجسم الشريحة.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - الحصول/تعيين جميع الأشكال في ماستر الشريحة (العناصر النائبة، إطارات الصور، إلخ).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - الحصول/تعيين عناصر التحكم ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - الحصول على مدير السمة.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - الحصول على مدير الترويسة والتذييل.

طرق ماستر الشرائح:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - الحصول على جميع الشرائح المعتمدة على ماستر الشرائح.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - يتيح لك إنشاء ماستر شريحة جديد بناءً على ماستر الشرائح الحالي وسمة جديدة. سيُطبق ماستر الشريحة الجديد على جميع الشرائح التابعة.

## **الحصول على ماستر الشريحة**
في PowerPoint، يمكن الوصول إلى ماستر الشريحة من القائمة View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

باستخدام Aspose.Slides، يمكنك الوصول إلى ماستر الشريحة بهذه الطريقة:
```c#
IMasterSlide master = pres.Masters[0];
```


تمثل الواجهة [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) ماستر الشريحة. خاصية [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (المرتبطة بنوع [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) تحتوي على قائمة جميع ماسترات الشرائح المعرفة في العرض.

## **إضافة صورة إلى ماستر الشريحة**
عند إضافة صورة إلى ماستر الشريحة، ستظهر تلك الصورة على جميع الشرائح التابعة لهذا الماستر.

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على ماستر الشريحة ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة.

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى ماستر الشريحة باستخدام Aspose.Slides:
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="انظر أيضًا" %}} 
لمزيد من المعلومات حول إضافة صور إلى شريحة، راجع مقالة [Picture Frame](/slides/ar/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نائب إلى ماستر الشريحة**
هذه الحقول النصية هي عناصر نائب قياسية على ماستر الشريحة:

* انقر لتحرير نمط عنوان الماستر
* تحرير أنماط نص الماستر
* المستوى الثاني
* المستوى الثالث

تظهر أيضًا على الشرائح المستندة إلى ماستر الشريحة. يمكنك تحرير هذه العناصر النائبة على ماستر الشريحة وستُطبق التغييرات تلقائيًا على الشرائح.

في PowerPoint، يمكنك إضافة عنصر نائب عبر مسار Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

لنتفحص مثالًا أكثر تعقيدًا للعناصر النائبة مع Aspose.Slides. اعتبر شريحة تحتوي على عناصر نائب مُقَلمة من ماستر الشريحة:

![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على ماستر الشريحة بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر نائب العنوان من كائن ماستر الشريحة ثم نستخدم الحقل `PlaceHolder.FillFormat`:
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


سيتغير نمط العنوان وتنسيقه لكل الشرائح المستندة إلى ماستر الشريحة:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)
{{% /alert %}}


## **تغيير الخلفية على ماستر الشريحة**
عند تغيير لون خلفية ماستر الشريحة، ستحصل جميع الشرائح العادية في العرض على اللون الجديد. يُظهر هذا الكود C# العملية:
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


{{% alert color="primary" title="انظر أيضًا" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)
{{% /alert %}}

## **استنساخ ماستر الشريحة إلى عرض تقديمي آخر**
لاستنساخ ماستر الشريحة إلى عرض تقديمي آخر، استدعِ طريقة [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) من العرض الوجهة مع تمرير ماستر الشريحة إليه. يوضح لك هذا الكود C# كيفية استنساخ ماستر الشريحة إلى عرض آخر:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **إضافة عدة ماسترات شرائح إلى العرض**
تسمح لك Aspose.Slides بإضافة عدة ماسترات شرائح وتخطيطات شرائح إلى أي عرض تقديمي. يتيح لك ذلك إعداد الأنماط، التخطيطات، وخيارات التنسيق للشرائح بطرق متعددة.

في PowerPoint، يمكنك إضافة ماسترات شرائح وتخطيطات جديدة (من "قائمة ماستر الشرائح") بهذه الطريقة:

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة ماستر شريحة جديد عبر استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/):
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **مقارنة ماسترات الشرائح**
تنفذ شريحة الماستر واجهة [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) التي تحتوي على طريقة [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals)، والتي يمكن استخدامها لمقارنة الشرائح. تُعيد `true` للماسترات المتطابقة في البنية والمحتوى الثابت.

تُعتبر شريحتا ماستر متساويتين إذا كانت الأشكال، الأنماط، النصوص، الرسوم المتحركة والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار القيم المعرفية الفريدة (مثل SlideId) أو المحتوى الديناميكي (مثل قيمة التاريخ الحالية في عنصر نائب التاريخ).


## **تعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي**
تسمح لك Aspose.Slides بتعيين ماستر الشريحة كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح العرض.

يوضح لك هذا الكود كيفية تعيين ماستر الشريحة كعرض افتراضي للعرض في C#:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **إزالة ماستر شريحة غير مستخدم**
توفر Aspose.Slides طريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لتمكينك من حذف ماسترات الشرائح غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود C# كيفية إزالة ماستر شريحة من عرض PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**ما هو ماستر الشرائح في PowerPoint؟**

ماستر الشرائح هو قالب شريحة يحدد التخطيط، الأنماط، السمات، الخطوط، الخلفية، وغيرها من الخصائص للشرائح في عرض تقديمي. يسمح لك بضبط وتغيير مظهر جميع الشرائح مرة واحدة.

**كيف يتم تطبيق ماستر الشرائح في عرض تقديمي؟**

كل عرض يحتوي على ماستر شريحة واحد على الأقل افتراضياً. عند إضافة شريحة جديدة، يتم تطبيق ماستر الشريحة عليها تلقائيًا، عادةً باستخدام ماستر الشريحة للشفرة السابقة. يمكن للعرض أن يحتوي على عدة ماسترات شرائح لتنسيق أجزاء مختلفة بصورة فريدة.

**ما العناصر التي يمكن تخصيصها في ماستر الشرائح؟**

يتألف ماستر الشرائح من عدة خصائص أساسية يمكن تخصيصها:

- **Background**: تعيين خلفية الشريحة.
- **BodyStyle**: تعريف أنماط النص لجسم الشريحة.
- **Shapes**: إدارة جميع الأشكال على ماستر الشريحة، بما في ذلك العناصر النائبة وإطارات الصور.
- **Controls**: التعامل مع عناصر تحكم ActiveX.
- **ThemeManager**: الوصول إلى مدير السمة.
- **HeaderFooterManager**: إدارة الترويسات والتذييلات.

**كيف يمكنني إضافة صورة إلى ماستر الشرائح؟**

إضافة صورة إلى ماستر الشريحة يضمن ظهورها على جميع الشرائح التي تعتمد على ذلك الماستر. على سبيل المثال، وضع شعار الشركة على ماستر الشريحة سيظهره على كل شريحة في العرض.

**كيف ترتبط ماسترات الشرائح بتخطيطات الشرائح؟**

تعمل تخطيطات الشرائح بالتنسيق مع ماستر الشرائح لتوفير مرونة في تصميم الشريحة. بينما يحدد ماستر الشرائح الأنماط العامة والسمات، تسمح تخطيطات الشرائح بتنوع ترتيبات المحتوى. الهيكلية هي كالتالي:

- **ماستر الشرائح** → يحدد الأنماط العامة.
- **تخطيط الشريحة** → يوفر ترتيبات محتوى مختلفة.
- **الشريحة** → ترث التصميم من تخطيط الشريحة.

**هل يمكن أن يكون لدي عدة ماسترات شرائح في عرض تقديمي واحد؟**

نعم، يمكن للعرض أن يحتوي على عدة ماسترات شرائح. يتيح لك ذلك تنسيق أقسام مختلفة من العرض بطرق متعددة، مما يوفر مرونة في التصميم.

**كيف يمكنني الوصول إلى ماستر الشريحة وتعديله باستخدام Aspose.Slides؟**

في Aspose.Slides، يُمثل ماستر الشريحة الواجهة `IMasterSlide`. يمكنك الوصول إلى ماستر الشريحة باستخدام خاصية `Masters` لكائن `Presentation`.
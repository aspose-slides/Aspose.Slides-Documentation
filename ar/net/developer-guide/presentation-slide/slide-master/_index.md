---
title: شريحة ماسطر
type: docs
weight: 80
url: /net/slide-master/
keywords: "إضافة شريحة ماسطر، شريحة ماسطر PPT، شريحة ماسطر PowerPoint، صورة إلى شريحة ماسطر، عنصر نائب، عدة شرائح ماسطر، مقارنة شرائح ماسطر، C#، Csharp، .NET، Aspose.Slides"
description: "إضافة أو تحرير شريحة ماسطر في عرض PowerPoint باستخدام C# أو .NET"
---


## **ما هي شريحة ماسطر في PowerPoint**
شريحة **ماسطر** هي قالب شريحة يحدد التنسيق، الأنماط، السمة، الخطوط، الخلفية، وخصائص أخرى للشرائح في عرض تقديمي. إذا كنت ترغب في إنشاء عرض تقديمي (أو سلسلة عروض تقديمية) بنفس الأسلوب والقالب لشركتك، يمكنك استخدام شريحة ماسطر. 

تكون شريحة الماسطر مفيدة لأنها تتيح لك ضبط وتغيير مظهر جميع الشرائح في العرض في آن واحد. تدعم Aspose.Slides آلية شريحة الماسطر من PowerPoint. 

تسمح VBA أيضًا بالتلاعب بشريحة ماسطر وتنفيذ نفس العمليات المدعومة في PowerPoint: تغيير الخلفيات، إضافة أشكال، تخصيص التنسيق، وما إلى ذلك. تقدم Aspose.Slides آليات مرنة تتيح لك استخدام شرائح الماسطر وإجراء مهام أساسية معها. 

هذه هي العمليات الأساسية لشريحة ماسطر:

- إنشاء أو شريحة ماسطر.
- تطبيق شرائح ماسطر على الشرائح التقديمية.
- تغيير خلفية شريحة الماسطر.
- إضافة صورة، عنصر نائب، فن ذكي، إلخ. إلى شريحة الماسطر.

هذه هي العمليات الأكثر تقدمًا المتعلقة بشريحة الماسطر:

- مقارنة شرائح الماسطر.
- دمج شرائح الماسطر.
- تطبيق عدة شرائح ماسطر.
- نسخ شريحة مع شريحة ماسطر إلى عرض تقديمي آخر.
- اكتشاف شرائح ماسطر مكررة في العروض التقديمية.
- تعيين شريحة الماسطر كعرض افتراضي للعرض التقديمي.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على Aspose [**عارض PowerPoint عبر الإنترنت**](https://products.aspose.app/slides/viewer) لأنه تنفيذ حي لبعض العمليات الأساسية الموصوفة هنا.

{{% /alert %}} 


## **كيف يتم تطبيق شريحة الماسطر**
قبل أن تعمل مع شريحة ماسطر، قد ترغب في فهم كيفية استخدامها في العروض التقديمية وتطبيقها على الشرائح. 

* يحتوي كل عرض تقديمي على الأقل على شريحة ماسطر واحدة بشكل افتراضي. 
* يمكن أن يحتوي العرض التقديمي على عدة شرائح ماسطر. يمكنك إضافة عدة شرائح ماسطر واستخدامها لتنسيق أجزاء مختلفة من العرض التقديمي بطرق مختلفة. 

في **Aspose.Slides**، يتم تمثيل شريحة الماسطر بواسطة [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) نوع. 

يحتوي كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في Aspose.Slides على قائمة [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) من نوع [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) التي تحتوي على قائمة بجميع شرائح الماسطر المعرفة في عرض تقديمي.

بجانب عمليات CRUD، تحتوي واجهة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) على هذه الطرق المفيدة: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) و[**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). تم اشتقاق تلك الطرق من وظيفة النسخ الأساسية للشرائح. لكن عند التعامل مع شرائح الماسطر، تتيح لك تلك الطرق تنفيذ إعدادات معقدة. 

عندما يتم إضافة شريحة جديدة إلى عرض تقديمي، يتم تطبيق شريحة ماسطر عليها تلقائيًا. يتم اختيار شريحة الماسطر السابقة بشكل افتراضي. 

**ملاحظة**: يتم تخزين الشرائح التقديمية في قائمة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)، وكل شريحة جديدة تضاف في نهاية المجموعة بشكل افتراضي. إذا كان العرض التقديمي يحتوي على شريحة ماسطر واحدة، يتم اختيار تلك الشريحة لجميع الشرائح الجديدة. هذه هي السبب في أنك لا تحتاج إلى تحديد شريحة ماسطر لكل شريحة جديدة تقوم بإنشائها.

المبدأ هو نفسه بالنسبة لـ PowerPoint وAspose.Slides. على سبيل المثال، في PowerPoint، عندما تضيف عرضًا تقديميًا جديدًا، يمكنك الضغط فقط على السطر السفلي أسفل الشريحة الأخيرة ثم سيتم إنشاء شريحة جديدة (مع شريحة الماسطر العرض السابقة):

![todo:image_alt_text](slide-master_1.jpg)

في Aspose.Slides، يمكنك إجراء المهمة المعادلة باستخدام [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) الطريقة ضمن [الـ Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.


## **شريحة ماسطر في تسلسل الشرائح**
استخدام تخطيط الشرائح مع شريحة الماسطر يسمح بأقصى درجات المرونة. يسمح لك تخطيط الشريحة بتعيين جميع الأنماط نفسها مثل شريحة الماسطر (الخلفية والخطوط والأشكال، إلخ). ومع ذلك، عند دمج عدة تخطيطات شرائح على شريحة ماسطر، يتم إنشاء نمط جديد. عند تطبيق تخطيط شريحة على شريحة واحدة، يمكنك تغيير نمطها من ذلك المطابق للذي تطبقه شريحة الماسطر.

تتفوق شريحة الماسطر على جميع عناصر الإعدادات: شريحة ماسطر -> تخطيط الشريحة -> شريحة:

![todo:image_alt_text](slide-master_2)

كل [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) كائن لديه خاصية [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) مع قائمة من تخطيطات الشرائح. نوع [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) لديه خاصية [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) مع رابط على تخطيط الشريحة المطبق على الشريحة. يتم التفاعل بين شريحة وشريحة ماسطر من خلال تخطيط شريحة.

{{% alert color="info" title="ملاحظة" %}}

* 
   في Aspose.Slides، جميع إعدادات الشرائح (شريحة ماسطر، تخطيط الشريحة، والشريحة نفسها) هي فعليًا كائنات شرائح تنفذ الـ [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) واجهة.
* لذلك، قد تقوم شريحة الماسطر وتخطيط الشريحة بتنفيذ نفس الخصائص، ويجب أن تعرف كيف ستطبق قيمها على [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) كائن. يتم تطبيق شريحة الماسطر أولاً على الشريحة ثم يتم تطبيق تخطيط الشريحة. على سبيل المثال، إذا كانت شريحة الماسطر وتخطيط الشريحة كلاهما تحتويان على قيمة خلفية، ستنتهي الشريحة بالخلفية من تخطيط الشريحة.

{{% /alert %}}


## **مكونات شريحة الماسطر**
لفهم كيف يمكن تغيير شريحة الماسطر، تحتاج إلى معرفة مكوناتها. هذه هي الخصائص الأساسية لـ [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). 

- [الخلفية](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - الحصول على/تعيين خلفية الشريحة.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - الحصول على/تعيين أنماط نصوص جسم الشريحة.
- [الأشكال](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - الحصول على/تعيين جميع الأشكال في شريحة الماسطر (العناصر النائبة، وأطر الصور، إلخ).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - الحصول على/تعيين عناصر التحكم ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - الحصول على مدير السمة.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - الحصول على مدير الرأس والتذييل.

طرق شريحة الماسطر:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - الحصول على جميع الشرائح المعتمدة على شريحة الماسطر.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - يتيح لك إنشاء شريحة ماسطر جديدة بناءً على شريحة الماسطر الحالية وسمة جديدة. سيتم تطبيق شريحة الماسطر الجديدة على جميع الشرائح المعتمدة. 


## **الحصول على شريحة الماسطر**
في PowerPoint، يمكن الوصول إلى شريحة الماسطر من قائمة العرض -> شريحة الماسطر:

![todo:image_alt_text](slide-master_3.jpg)



باستخدام Aspose.Slides، يمكنك الوصول إلى شريحة الماسطر بهذه الطريقة:

```c#
IMasterSlide master = pres.Masters[0];
```

تمثل واجهة [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) شريحة الماسطر. تحتوي خاصية [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (ذات الصلة بـ [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) نوع) على قائمة بجميع شرائح الماسطر المعرفة في العرض التقديمي. 


## **إضافة صورة إلى شريحة الماسطر**
عندما تضيف صورة إلى شريحة ماسطر، ستظهر تلك الصورة على جميع الشرائح المعتمدة على تلك الشريحة. 

على سبيل المثال، يمكنك وضع شعار شركتك وبعض الصور على شريحة الماسطر ثم العودة إلى وضع تحرير الشرائح. يجب أن ترى الصورة على كل شريحة. 

![todo:image_alt_text](slide-master_4.png)

يمكنك إضافة صور إلى شريحة الماسطر باستخدام Aspose.Slides: 

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="انظر أيضًا" %}} 

للحصول على مزيد من المعلومات حول إضافة الصور إلى شريحة، انظر المقالة [إطار الصورة](/slides/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **إضافة عنصر نائب إلى شريحة الماسطر**
هذه الحقول النصية هي عناصر نائب قياسية على شريحة الماسطر:

* انقر لتحرير نمط عنوان الماسطر

* تحرير أنماط نصوص الماسطر

* المستوى الثاني

* المستوى الثالث 

  تظهر أيضًا على الشرائح المعتمدة على شريحة الماسطر. يمكنك تحرير تلك العناصر النائبة في شريحة الماسطر وسيتم تطبيق التغييرات تلقائيًا على الشرائح. 

في PowerPoint، يمكنك إضافة عنصر نائب من خلال مسار شريحة الماسطر -> إدراج عنصر نائب:



![todo:image_alt_text](slide-master_5.png)

دعنا نستعرض مثالًا أكثر تعقيدًا لعنصر نائب باستخدام Aspose.Slides. اعتبر شريحة بها عناصر نائب تم تصميمها من شريحة الماسطر:



![todo:image_alt_text](slide-master_6.png)

نريد تغيير تنسيق العنوان والعنوان الفرعي على شريحة الماسطر بهذه الطريقة:

![todo:image_alt_text](slide-master_7.png)

أولاً، نسترجع محتوى عنصر النائب للعناوين من كائن شريحة الماسطر ثم نستخدم حقل `PlaceHolder.FillFormat`: 

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

سيتم تغيير نمط العنوان والتنسيق لجميع الشرائح المعتمدة على شريحة الماسطر: 



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="انظر أيضًا" %}} 

* [تعيين نص موجه في العنصر النائب](https://docs.aspose.com/slides/net/manage-placeholder/)
* [تنسيق النص](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **تغيير الخلفية على شريحة الماسطر**
عندما تغير لون خلفية شريحة الماسطر، ستحصل جميع الشرائح العادية في العرض التقديمي على اللون الجديد. يوضح كود C# هذا العملية:

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
- [خلفية العرض التقديمي](https://docs.aspose.com/slides/net/presentation-background/)

- [سمة العرض التقديمي](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}


## **استنساخ شريحة الماسطر إلى عرض تقديمي آخر**
لاستنساخ شريحة ماسطر إلى عرض تقديمي آخر، اتصل بـ [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) الطريقة من العرض التقديمي الوجهة مع شريحة ماسطر تمرر إليها. يوضح كود C# التالي كيفية استنساخ شريحة ماسطر إلى عرض تقديمي آخر:

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **إضافة عدة شرائح ماسطر إلى العرض التقديمي**
تسمح Aspose.Slides لك بإضافة عدة شرائح ماسطر وتخطيطات شرائح إلى أي عرض تقديمي معين. يسمح لك ذلك بإعداد الأنماط، والتنسيقات، وخيارات التنسيق لشرائح العرض التقديمي بطرق متعددة. 

في PowerPoint، يمكنك إضافة شرائح ماسطر جديدة وتخطيطات (من قائمة "شريحة الماسطر بالطريقة التالية):

![todo:image_alt_text](slide-master_9.jpg)

باستخدام Aspose.Slides، يمكنك إضافة شريحة ماسطر جديدة عن طريق استدعاء [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) الطريقة:

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **مقارنة شرائح الماسطر**
تقوم شريحة ماسطر بتنفيذ واجهة [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) التي تحتوي على طريقة [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals) التي يمكن استخدامها بعد ذلك لمقارنة الشرائح. ترجع `true` لشرائح الماسطر المتماثلة في الهيكل والمحتوى الثابت. 

تكون شرائح الماسطر متساوية إذا كانت أشكالها، وأنماطها، ونصوصها، ورسومها المتحركة، وإعدادات أخرى، إلخ متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد (مثل SlideId) والمحتوى الديناميكي (مثل القيمة الحالية في عنصر نائب التاريخ). 


## **تعيين شريحة الماسطر كعرض افتراضي للعرض التقديمي**
تسمح Aspose.Slides لك بتعيين شريحة ماسطر كعرض افتراضي للعرض التقديمي. العرض الافتراضي هو ما تراه أولاً عند فتح عرض تقديمي. 

يوضح هذا الكود كيفية تعيين شريحة ماسطر كعرض افتراضي للعرض التقديمي باستخدام C#:

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **إزالة شريحة ماسطر غير مستخدمة**

توفر Aspose.Slides طريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح الماسطر غير المرغوبة وغير المستخدمة. يوضح كود C# التالي كيفية إزالة شريحة ماسطر من عرض تقديمي PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
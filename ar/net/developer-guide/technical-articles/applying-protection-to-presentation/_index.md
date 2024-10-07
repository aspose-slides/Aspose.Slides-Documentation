---
title: تطبيق الحماية على العروض التقديمية
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint 2007 (PPTX) كجزء من سير العمل الآلي. يحصل مستخدمو التطبيق الذي يستخدم Aspose.Slides بهذه الطريقة على إمكانية الوصول إلى العروض الناتجة. حماية هذه العروض من التعديل هي قضية شائعة. من المهم أن تحتفظ العروض التلقائية بتنسيقها ومحتواها الأصليين.

تتناول هذه المقالة كيفية [إنشاء العروض والشرائح](/slides/net/applying-protection-to-presentation/) وكيف يمكن لـ Aspose.Slides لـ .NET [تطبيق الحماية على](/slides/net/applying-protection-to-presentation/) ، ثم [إزالتها من](/slides/net/applying-protection-to-presentation/) عرض تقديمي. هذه الميزة فريدة من نوعها في Aspose.Slides وفي وقت كتابة هذه السطور، غير متاحة في Microsoft PowerPoint. إنها تعطي المطورين وسيلة للتحكم في كيفية استخدام العروض التي تنشئها تطبيقاتهم.

{{% /alert %}} 
## **تركيب الشريحة**
تتكون شريحة PPTX من عدد من المكونات مثل الأشكال التلقائية، والجداول، والكائنات OLE، والأشكال المجتمعة، وإطارات الصور، وإطارات الفيديو، والموصلات، والعناصر الأخرى المختلفة المتاحة لبناء عرض تقديمي.

في Aspose.Slides لـ .NET، يتم تحويل كل عنصر على الشريحة إلى كائن Shape. بعبارة أخرى، كل عنصر على الشريحة إما كائن Shape أو كائن مشتق من كائن Shape.

بنية PPTX معقدة، لذا على عكس PPT، حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، توجد أنواع مختلفة من الأقفال لأنواع أشكال مختلفة. تعتبر فئة BaseShapeLock هي الفئة العامة لقفل PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides لـ .NET لـ PPTX.

- قفل AutoShapeLock يقفل الأشكال التلقائية.
- قفل ConnectorLock يقفل أشكال الموصلات.
- قفل GraphicalObjectLock يقفل الكائنات الرسومية.
- قفل GroupshapeLock يقفل الأشكال المجتمعة.
- قفل PictureFrameLock يقفل إطارات الصور.

أي إجراء يتم على جميع كائنات Shape في كائن Presentation يتم تطبيقه على العرض التقديمي بالكامل.
## **تطبيق وإزالة الحماية**
يضمن تطبيق الحماية أن لا يمكن تعديل العرض التقديمي. إنها تقنية مفيدة لحماية محتوى العرض التقديمي.
### **تطبيق الحماية على أشكال PPTX**
توفر Aspose.Slides لـ .NET فئة Shape للتعامل مع شكل على الشريحة.

كما ذُكر سابقًا، تحتوي كل فئة من أشكال على فئة قفل شكل مرتبطة بها للحماية. تركز هذه المقالة على الأقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال أن الأشكال لا يمكن تحديدها (من خلال نقرات الماوس أو طرق التحديد الأخرى)، ولا يمكن نقلها أو تغيير حجمها.

تطبق عينات الشيفرة التي تلي ذلك الحماية على جميع أنواع الأشكال في عرض تقديمي.

```c#
//تجهيز فئة Presentation التي تمثل ملف PPTX
Presentation pTemplate = new Presentation("RectPicFrame.pptx");
           

//كائن ISlide للوصول إلى الشرائح في العرض التقديمي
ISlide slide = pTemplate.Slides[0];

//كائن IShape للاحتفاظ بالأشكال المؤقتة
IShape shape;

//التنقل عبر جميع الشرائح في العرض التقديمي
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //التنقل عبر جميع الأشكال في الشرائح
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //إذا كان الشكل هو شكل تلقائي
        if (shape is IAutoShape)
        {
            //تحويل النوع إلى شكل تلقائي والحصول على قفل الشكل التلقائي
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //تطبيق أقفال الأشكال
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //إذا كان الشكل هو شكل مجموعة
        else if (shape is IGroupShape)
        {
            //تحويل النوع إلى شكل مجموعة والحصول على قفل شكل المجموعة
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //تطبيق أقفال الأشكال
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //إذا كان الشكل هو موصل
        else if (shape is IConnector)
        {
            //تحويل النوع إلى شكل موصل والحصول على قفل شكل الموصل
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //تطبيق أقفال الأشكال
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //إذا كان الشكل هو إطار صورة
        else if (shape is IPictureFrame)
        {
            //تحويل النوع إلى إطار صورة والحصول على قفل شكل إطار الصورة
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //تطبيق أقفال الأشكال
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }

}

//حفظ ملف العرض التقديمي
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **إزالة الحماية**
يمكن إزالة الحماية المطبقة باستخدام Aspose.Slides لـ .NET فقط. لإلغاء قفل شكل، يتم تعيين قيمة القفل المطبق إلى false. تُظهر عينة الشيفرة التي تلي ذلك كيفية إلغاء قفل الأشكال في عرض تقديمي محمي.

```c#
//فتح العرض التقديمي المطلوب
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//كائن ISlide للوصول إلى الشرائح في العرض التقديمي
ISlide slide = pTemplate.Slides[0];

//كائن IShape للاحتفاظ بالأشكال المؤقتة
IShape shape;

//التنقل عبر جميع الشرائح في العرض التقديمي
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //التنقل عبر جميع الأشكال في الشرائح
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //إذا كان الشكل هو شكل تلقائي
        if (shape is IAutoShape)
        {
            //تحويل النوع إلى شكل تلقائي والحصول على قفل الشكل التلقائي
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //تطبيق أقفال الأشكال
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //إذا كان الشكل هو شكل مجموعة
        else if (shape is IGroupShape)
        {
            //تحويل النوع إلى شكل مجموعة والحصول على قفل شكل المجموعة
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //تطبيق أقفال الأشكال
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //إذا كان الشكل هو شكل موصل
        else if (shape is IConnector)
        {
            //تحويل النوع إلى شكل موصل والحصول على قفل شكل الموصل
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //تطبيق أقفال الأشكال
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //إذا كان الشكل هو إطار صورة
        else if (shape is IPictureFrame)
        {
            //تحويل النوع إلى إطار صورة والحصول على قفل شكل إطار الصورة
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //تطبيق أقفال الأشكال
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}

//حفظ ملف العرض التقديمي
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



### **الملخص**
{{% alert color="primary" %}} 

توفر Aspose.Slides عددًا من الخيارات لتطبيق الحماية على الأشكال في عرض تقديمي. من الممكن قفل شكل معين، أو التكرار عبر جميع الأشكال في عرض تقديمي وقفل جميعها بشكل فعال لقفل العرض التقديمي.

فقط Aspose.Slides لـ .NET يمكنه إزالة الحماية من عرض تقديمي تم حمايته مسبقًا. قم بإزالة الحماية من خلال تعيين قيمة القفل إلى false.

{{% /alert %}} 
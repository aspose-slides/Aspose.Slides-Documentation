---
title: إدارة الزوم
type: docs
weight: 60
url: /net/manage-zoom/
keywords: 
- زوم
- إطار زوم
- إضافة زوم
- تنسيق إطار الزوم
- زوم ملخص
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "إضافة زوم أو إطارات زوم إلى عروض PowerPoint في C# أو .NET"
---

## **نظرة عامة**
تتيح لك الزوم في PowerPoint الانتقال إلى ومن الشرائح المحددة، الأقسام، وأجزاء من العرض التقديمي. عندما تقدم، قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة جدًا.

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [زوم ملخص](#Summary-Zoom).
* لإظهار الشرائح المحددة فقط، استخدم [زوم شريحة](#Slide-Zoom).
* لإظهار قسم واحد فقط، استخدم [زوم قسم](#Section-Zoom).

## **زوم الشريحة**
يمكن أن تجعل زوم الشريحة عرضك التقديمي أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة سير عرضك. يعتبر زوم الشرائح رائعًا للعروض القصيرة التي لا تحتوي على العديد من الأقسام، ولكن يمكنك استخدامها في سيناريوهات تقديم مختلفة.

تساعدك زوم الشرائح على التعمق في عدة قطع من المعلومات بينما تشعر أنك على قماش واحد.

![overview_image](slidezoomsel.png)

بالنسبة لكائنات زوم الشريحة، يوفر Aspose.Slides التعداد [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)، الواجهة [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)، وبعض الطرق ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء إطارات الزوم**

يمكنك إضافة إطار زوم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شرائح جديدة تنوي ربط إطارات الزوم بها.
3. أضف نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات زوم (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إنشاء إطار زوم على شريحة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشفيفة الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ صندوق نص للشفيفة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "الشفيفة الثانية";

    // ينشئ خلفية للشفيفة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ صندوق نص للشفيفة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "الشفيفة الثالثة";

    //يضيف كائنات زوم
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **إنشاء إطارات زوم بصور مخصصة**
باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار زوم بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شريحة جديدة تنوي ربط إطار الزوم بها. 
3. أضف نص تعريف وخلفية إلى الشريحة.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيتم استخدامه لملء الإطار.
5. أضف إطارات زوم (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إنشاء إطار زوم بصورة مختلفة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشفيفة الثانية
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ صندوق نص للشفيفة الثالثة
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "الشفيفة الثانية";

    // ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //يضيف كائن ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **تنسيق إطارات الزوم**
في الأقسام السابقة، عرضنا لك كيفية إنشاء إطارات زوم بسيطة. لإنشاء إطارات زوم أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار الزوم.

يمكنك التحكم في تنسيق إطار الزوم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شرائح جديدة تنوي ربط إطار الزوم بها.
3. أضف بعض نص التعريف والخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات زوم (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيتم استخدامه لملء الإطار.
6. عيّن صورة مخصصة لكائن إطار الزوم الأول.
7. غيّر تنسيق الخط لكائن إطار الزوم الثاني.
8. أزل الخلفية من صورة كائن إطار الزوم الثاني.
5. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية تغيير تنسيق إطار الزوم على شريحة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشفيفة الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ صندوق نص للشفيفة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "الشفيفة الثانية";

    // ينشئ خلفية للشفيفة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ صندوق نص للشفيفة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "الشفيفة الثالثة";

    //يضيف كائنات زوم
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يحدد صورة مخصصة لكائن zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // يحدد تنسيق إطار زوم لكائن zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // إعداد لعدم عرض الخلفية لكائن zoomFrame2
    zoomFrame2.ShowBackground = false;

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **زوم القسم**

زوم القسم هو ارتباط لقسم في عرضك التقديمي. يمكنك استخدام زوم الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك التقديمي.

![overview_image](seczoomsel.png)

بالنسبة لكائنات زوم القسم، يوفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) وبعض الطرق ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء إطارات زوم القسم**

يمكنك إضافة إطار زوم القسم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تنوي ربط إطار الزوم به. 
5. أضف إطار زوم القسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إنشاء إطار زوم على شريحة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **إنشاء إطارات زوم القسم بصور مخصصة**

باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار زوم القسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تنوي ربط إطار الزوم به. 
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيتم استخدامه لملء الإطار.
5. أضف إطار زوم القسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إنشاء إطار زوم بصورة مختلفة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    // ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **تنسيق إطارات زوم القسم**

لإنشاء إطارات زوم القسم أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار زوم القسم. 

يمكنك التحكم في تنسيق إطار زوم القسم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تنوي ربط إطار الزوم به. 
5. أضف إطار زوم القسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غيّر الحجم والموقع لكائن زوم القسم الذي تم إنشاؤه.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيتم استخدامه لملء الإطار.
8. عيّن صورة مخصصة لكائن إطار زوم القسم الذي تم إنشاؤه.
9. عيّن القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. أزل الخلفية من صورة كائن إطار زوم القسم.
11. غيّر تنسيق الخط لكائن إطار الزوم الثاني.
12. غيّر مدة الانتقال.
13. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية تغيير تنسيق إطار زوم القسم:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    // إضافة كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // التنسيق لإطار SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **زوم الملخص**

زوم الملخص هو مثل صفحة الهبوط التي يتم عرض جميع أجزاء عرضك التقديمي مرة واحدة. عندما تقدم، يمكنك استخدام الزوم للانتقال من مكان إلى آخر في عرضك التقديمي بأي ترتيب تريده. يمكنك أن تكون مبدعًا، تتخطى إلى الأمام، أو تعيد زيارة أجزاء من عرض الشريحة الخاص بك دون مقاطعة سير عرضك.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات زوم الملخص، يوفر Aspose.Slides الواجهة [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)، [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) والعديد من الطرق ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء زوم الملخص**

يمكنك إضافة إطار زوم الملخص إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشريحة التي تم إنشاؤها.
3. أضف إطار الزوم الملخص إلى الشريحة الأولى.
4. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إنشاء إطار زوم ملخص على شريحة:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 2", slide);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 3", slide);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 4", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إضافة وإزالة قسم زوم الملخص**

تمثل جميع الأقسام في إطار زوم الملخص كائنات [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)، التي يتم تخزينها في الكائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). يمكنك إضافة أو إزالة كائن قسم زوم الملخص من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشريحة التي تم إنشاؤها.
3. أضف إطار الزوم الملخص إلى الشريحة الأولى.
4. أضف شريحة جديدة وقسمًا إلى العرض.
5. أضف القسم الذي تم إنشاؤه إلى إطار الزوم الملخص.
6. أزل القسم الأول من إطار الزوم الملخص.
7. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية إضافة وإزالة الأقسام في إطار زوم الملخص:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    ISection section3 = pres.Sections.AddSection("القسم 3", slide);

    // يضيف قسمًا إلى زوم الملخص
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // يزيل القسم من زوم الملخص
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق أقسام زوم الملخص**

لإنشاء كائنات قسم زوم الملخص أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم زوم الملخص.

يمكنك التحكم في تنسيق كائن قسم زوم الملخص في إطار زوم الملخص بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشريحة التي تم إنشاؤها.
3. أضف إطار الزوم الملخص إلى الشريحة الأولى.
4. احصل على كائن قسم زوم الملخص الأول من `ISummaryZoomSectionCollection`.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيتم استخدامه لملء الإطار.
6. عيّن صورة مخصصة لكائن قسم زوم الملخص الذي تم إنشاؤه.
7. عيّن القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. غيّر تنسيق الخط لكائن زوم الملخص الثاني.
9. غيّر مدة الانتقال.
10. اكتب العرض المعدل كملف PPTX.

هذا الكود في C# يوضح لك كيفية تغيير تنسيق قسم زوم الملخص:

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 1", slide);

    //يضيف شريحة جديدة إلى العرض
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض
    pres.Sections.AddSection("القسم 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // يحصل على كائن SummaryZoomSection الأول
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // تنسيق كائن SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // يحفظ العرض
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
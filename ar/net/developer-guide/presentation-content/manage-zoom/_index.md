---
title: إدارة تقريب العرض التقديمي في .NET
linktitle: إدارة التقريب
type: docs
weight: 60
url: /ar/net/manage-zoom/
keywords:
- تقريب
- إطار التقريب
- تقريب الشريحة
- تقريب القسم
- تقريب الملخص
- إضافة تقري
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص التقريب باستخدام Aspose.Slides لـ .NET — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح لك ميزات التقريب في PowerPoint بالتنقل إلى ومن شرائح وأقسام وأجزاء محددة من العرض التقديمي. عند تقديمك، قد يكون هذا القدرة على التنقل السريع عبر المحتوى مفيدةً جداً. 

![صورة نظرة عامة](overview.png)

* لتلخيص العرض التقديمي بالكامل في شريحة واحدة، استخدم [Summary Zoom](#Summary-Zoom).
* لعرض الشرائح المختارة فقط، استخدم [Slide Zoom](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [Section Zoom](#Section-Zoom).

## **تقريب الشريحة**
يمكن لتقريب الشريحة أن يجعل عرضك التقديمي أكثر حيوية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون إعاقة تدفق العرض. تقريبات الشرائح مفيدة للعرض القصير الذي لا يحتوي على أقسام كثيرة، لكن يمكنك أيضاً استخدامها في سيناريوهات عرض مختلفة.

تساعدك تقريبات الشرائح على الغوص في عدة أجزاء من المعلومات بينما تشعر أنك على لوحة واحدة. 

![صورة تقريبات الشريحة](slidezoomsel.png)

للكائنات الخاصة بتقريب الشريحة، توفر Aspose.Slides تعداد [ZoomImageType]، والواجهة [IZoomFrame]، وبعض الأساليب ضمن الواجهة [IShapeCollection].

### **إنشاء إطارات التقريب**

يمكنك إضافة إطار تقريب إلى شريحة بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شرائح جديدة التي تنوي ربط إطارات التقريب بها. 
3. أضف نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات التقريب (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //ينشئ خلفية للشرائح الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //ينشئ صندوق نص للشرائح الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //ينشئ خلفية للشرائح الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //ينشئ صندوق نص للشرائح الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //يضيف كائنات ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إنشاء إطارات التقريب بصور مخصصة**
باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار تقريب بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شريحة جديدة التي تنوي ربط إطار التقريب بها. 
3. أضف نص تعريف وخلفية إلى الشريحة.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
5. أضف إطارات التقريب (التي تحتوي على المرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشريحة الثانية
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ صندوق نص للشريحة الثالثة
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ صورة جديدة لكائن التقريب
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //يضيف كائن ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات التقريب**
في الأقسام السابقة، أوضحنا لك كيفية إنشاء إطارات التقريب البسيطة. لإنشاء إطارات تقريبيّة أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التقريب. 

يمكنك التحكم في تنسيق إطار التقريب على شريحة بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شرائح جديدة للربط التي تنوي ربط إطار التقريب بها. 
3. أضف بعض نصوص التعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات التقريب (التي تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
6. اضبط صورة مخصصة لكائن إطار التقريب الأول.
7. غيّر تنسيق الخط لكائن إطار التقريب الثاني.
8. أزل الخلفية من صورة كائن إطار التقريب الثاني.
5. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشريحة الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ صندوق نص للشريحة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ خلفية للشريحة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ صندوق نص للشريحة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // يضيف كائنات ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ينشئ صورة جديدة لكائن Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يحدد صورة مخصصة لكائن zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // يحدد تنسيق إطار Zoom لكائن zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // إعداد لعدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.ShowBackground = false;

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **تقريب القسم**

تقريب القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تقريبات الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية اتصال أجزاء معينة من عرضك.

![صورة تقريب القسم](seczoomsel.png)

للكائنات الخاصة بتقريب القسم، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) وبعض الأساليب ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء إطارات تقريبات القسم**

يمكنك إضافة إطار تقريب قسم إلى شريحة بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شريحة جديدة. 
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار التقريب به. 
5. أضف إطار تقريب قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إنشاء إطارات تقريبات القسم بصور مخصصة**

باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار تقريب قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار التقريب به. 
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
5. أضف إطار تقريب قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    // ينشئ صورة جديدة لكائن Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات تقريبات القسم**

لإنشاء إطارات تقريبات قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تقريبات القسم. 

يمكنك التحكم في تنسيق إطار تقريبات القسم على شريحة بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار التقريب به. 
5. أضف إطار تقريبات قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غيّر الحجم والموقع لكائن تقريبات القسم الذي تم إنشاؤه.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
8. اضبط صورة مخصصة لكائن إطار تقريبات القسم الذي تم إنشاؤه.
9. اضبط إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. أزل الخلفية من صورة كائن إطار تقريبات القسم.
11. غيّر تنسيق الخط لكائن إطار التقريب الثاني.
12. غيّر مدة الانتقال.
13. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // تنسيق SectionZoomFrame
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

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```



## **تقريب الملخص**

تقريب الملخص يشبه صفحة هبوط حيث تُعرض جميع أجزاء عرضك التقديمي مرة واحدة. عندما تقوم بالتقديم، يمكنك استخدام التقريب للانتقال من مكان إلى آخر في عرضك بأي ترتيب تختاره. يمكنك الإبداع، القفز للأمام، أو إعادة زيارة أجزاء من عرض الشرائح دون إيقاف تدفق العرض.

![صورة تقريب الملخص](sumzoomsel.png)

للكائنات الخاصة بتقريب الملخص، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)، [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)، و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) وبعض الأساليب ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء تقريبات الملخص**

يمكنك إضافة إطار تقريبات ملخص إلى شريحة بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تقريبات الملخص إلى الشريحة الأولى.
4. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 2", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 3", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 4", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **إضافة وإزالة قسم تقريبات الملخص**

جميع الأقسام في إطار تقريبات الملخص ممثلة بكائنات [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). يمكنك إضافة أو إزالة كائن قسم تقريبات الملخص عبر واجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تقريبات الملخص إلى الشريحة الأولى.
4. أضف شريحة جديدة وقسم إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار تقريبات الملخص.
6. أزل القسم الأول من إطار تقريبات الملخص.
7. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // يضيف قسمًا إلى Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // يزيل القسم من Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **تنسيق أقسام تقريبات الملخص**

لإنشاء كائنات أقسام تقريبات الملخص أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تقريبات الملخص. 

يمكنك التحكم في تنسيق كائن قسم تقريبات الملخص داخل إطار تقريبات الملخص بهذه الطريقة:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تقريبات الملخص إلى الشريحة الأولى.
4. احصل على كائن قسم تقريبات الملخص الأول من `ISummaryZoomSectionCollection`.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
8. اضبط صورة مخصصة لكائن إطار تقريبات القسم الذي تم إنشاؤه.
9. اضبط إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
11. غيّر تنسيق الخط لكائن إطار التقريب الثاني.
12. غيّر مدة الانتقال.
13. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // يحصل على أول كائن SummaryZoomSection
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

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent`، والذي عند تمكينه يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "سرعة" أو مدة انتقال الـ Zoom؟**

نعم. يدعم Zoom ضبط خاصية `TransitionDuration` بحيث يمكنك التحكم في مدة حركة القفز.

**هل هناك حدود لعدد كائنات Zoom التي يمكن للعرض التقديمي احتواؤها؟**

ليس هناك حد ثابت موثق في واجهة البرمجة. تعتمد الحدود العملية على تعقيد العرض التقديمي الإجمالي وأداء المشاهد. يمكنك إضافة العديد من إطارات Zoom، لكن يُفضَّل مراعاة حجم الملف ووقت التقديم.
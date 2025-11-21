---
title: إدارة تكبير العرض التقديمي في .NET
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/net/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لـ .NET — الانتقال بين الأقسام، إضافة مصغرات وانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
Zooms في PowerPoint تسمح لك بالقفز إلى ومن الشرائح المحددة، والأقسام، وأجزاء العرض التقديمي. عند تقديم العرض قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [ملخص الزوم](#Summary-Zoom).
* لعرض الشرائح المختارة فقط، استخدم [Zoom الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [Zoom القسم](#Section-Zoom).

## **زوم الشريحة**
يمكن أن يجعل Zoom الشريحة عرضك أكثر حيوية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض التقديمي. Zoom الشريحة رائعة للعروض القصيرة دون أقسام كثيرة، لكن لا يزال يمكنك استخدامها في سيناريوهات عرض مختلفة.

Zoom الشريحة تساعدك على الغوص في قطع متعددة من المعلومات بينما تشعر وكأنك على قماش واحد. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات Zoom الشريحة، توفر Aspose.Slides تعداد ZoomImageType، وواجهة IZoomFrame، وبعض الطرق ضمن واجهة IShapeCollection.

### **إنشاء إطارات Zoom**
يمكنك إضافة إطار Zoom إلى شريحة بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شرائح جديدة تريد ربط إطارات الزوم بها.
3. أضف نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات الزوم (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
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

    // ينشئ مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ خلفية للشريحة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ مربع نص للشريحة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // يضيف كائنات ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إنشاء إطارات Zoom بصور مخصصة**
مع Aspose.Slides لـ .NET، يمكنك إنشاء إطار Zoom بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شريحة جديدة تريد ربط إطار الزوم بها. 
3. أضف نص تعريف وخلفية إلى الشريحة.
4. أنشئ كائن IPPImage بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
5. أضف إطارات الزوم (التي تحتوي على مرجع الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //ينشئ خلفية للشريحة الثانية
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //ينشئ مربع نص للشريحة الثالثة
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //يضيف كائن ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات Zoom**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات Zoom بسيطة. لإنشاء إطارات Zoom أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار Zoom. 

يمكنك التحكم في تنسيق إطار الزوم على شريحة بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شرائح جديدة للربط التي تنوي ربط إطار الزوم بها.
3. أضف بعض نص التعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات الزوم (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن IPPImage بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
6. تعيين صورة مخصصة لكائن إطار الزوم الأول.
7. تغيير تنسيق الخط لكائن إطار الزوم الثاني.
8. إزالة الخلفية من صورة كائن إطار الزوم الثاني.
5. احفظ العرض التقديمي المعدل كملف PPTX.

``` csharp
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //ينشئ خلفية للشريحة الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //ينشئ مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //ينشئ خلفية للشريحة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //ينشئ مربع نص للشريحة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //يضيف كائنات ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //يضبط صورة مخصصة لكائن zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    //يضبط تنسيق إطار الزوم لكائن zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    //إعداد عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.ShowBackground = false;

    //يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **زوم القسم**
زوم القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام زوم الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك. 

![overview_image](seczoomsel.png)

بالنسبة لكائنات زوم القسم، توفر Aspose.Slides واجهة ISectionZoomFrame وبعض الطرق ضمن واجهة IShapeCollection.

### **إنشاء إطارات زوم القسم**
يمكنك إضافة إطار زوم القسم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسماً جديدًا تريد ربط إطار الزوم به. 
5. أضف إطار زوم القسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
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

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إنشاء إطارات زوم القسم بصور مخصصة**
باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار زوم قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسماً جديدًا تريد ربط إطار الزوم به. 
5. إنشاء كائن IPPImage بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
5. أضف إطار زوم القسم (الذي يحتوي على مرجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
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

    //ينشئ صورة جديدة لكائن الزوم
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات زوم القسم**
لإنشاء إطارات زوم قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار زوم القسم. 

يمكنك التحكم في تنسيق إطار زوم القسم على شريحة بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسماً جديدًا تريد ربط إطار الزوم به. 
5. أضف إطار زوم القسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غير حجم وموقع كائن زوم القسم المُنشأ.
7. إنشاء كائن IPPImage بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
8. تعيين صورة مخصصة لكائن إطار زوم القسم المُنشأ.
9. تعيين خاصية *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. إزالة الخلفية من صورة كائن إطار زوم القسم.
11. تغيير تنسيق الخط لكائن إطار الزوم الثاني.
12. تغيير مدة الانتقال.
13. احفظ العرض التقديمي المعدل كملف PPTX.

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


## **زوم الملخص**
زوم الملخص يشبه صفحة هبوط تُظهر جميع أجزاء عرضك مرة واحدة. عند تقديم العرض يمكنك استخدام الزوم للانتقال من مكان إلى آخر في أي ترتيب تختاره. يمكنك الإبداع، القفز إلى الأمام، أو العودة إلى أجزاء من عرض الشرائح دون مقاطعة تدفق العرض.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات زوم الملخص، توفر Aspose.Slides الواجهات ISummaryZoomFrame، ISummaryZoomFrameSection، وISummaryZoomSectionCollection وبعض الطرق ضمن واجهة IShapeCollection.

### **إنشاء زوم الملخص**
يمكنك إضافة إطار زوم الملخص إلى شريحة بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار زوم الملخص إلى الشريحة الأولى.
4. احفظ العرض التقديمي المعدل كملف PPTX.

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

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 3", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
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


### **إضافة وإزالة قسم زوم الملخص**
جميع الأقسام في إطار زوم الملخص ممثلة بكائنات ISummaryZoomFrameSection، المخزنة في كائن ISummaryZoomSectionCollection. يمكنك إضافة أو إزالة كائن قسم زوم الملخص عبر واجهة ISummaryZoomSectionCollection بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار زوم الملخص إلى الشريحة الأولى.
4. أضف شريحة وقسم جديدين إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار زوم الملخص.
6. أزل القسم الأول من إطار زوم الملخص.
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

    // يضيف قسمًا إلى ملخص الزوم
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // يزيل القسم من ملخص الزوم
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **تنسيق أقسام زوم الملخص**
لإنشاء كائنات قسم زوم الملخص أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم زوم الملخص. 

يمكنك التحكم في تنسيق كائن قسم زوم الملخص داخل إطار زوم الملخص بهذه الطريقة:

1. أنشئ مثيلاً من فئة Presentation.
2. أنشئ شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار زوم الملخص إلى الشريحة الأولى.
4. احصل على كائن قسم زوم الملخص الأول من `ISummaryZoomSectionCollection`.
7. إنشاء كائن IPPImage بإضافة صورة إلى مجموعة الصور المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
8. تعيين صورة مخصصة لكائن إطار زوم القسم المُنشأ.
9. تعيين خاصية *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
11. تغيير تنسيق الخط لكائن إطار الزوم الثاني.
12. تغيير مدة الانتقال.
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


## **FAQ**

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**

نعم. يحتوي إطار Zoom أو القسم على سلوك `ReturnToParent` الذي، عند تمكينه، يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "السرعة" أو مدة انتقال Zoom؟**

نعم. يدعم Zoom ضبط `TransitionDuration` لتتمكن من التحكم في مدة حركة القفزة.

**هل هناك حدود لعدد كائنات Zoom التي يمكن أن يحتويها عرض تقديمي؟**

لا يوجد حد ثابت موثق في واجهة البرمجة. تعتمد الحدود العملية على تعقيد العرض التقديمي وأداء المشاهد. يمكنك إضافة العديد من إطارات Zoom، ولكن يجب مراعاة حجم الملف ووقت التصيير.
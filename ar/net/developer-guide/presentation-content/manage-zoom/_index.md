---
title: إدارة التكبير
type: docs
weight: 60
url: /ar/net/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- إضافة تكبير
- تنسيق إطار التكبير
- تكبير ملخص
- عرض تقديمي PowerPoint
- C#
- Csharp
- Aspose.Slides for .NET
description: "إضافة تكبير أو إطارات تكبير إلى عروض PowerPoint التقديمية في C# أو .NET"
---

## **نظرة عامة**
تتيح لك خاصية التكبير في PowerPoint القفز إلى شرائح أو أقسام أو أجزاء معينة من العرض التقديمي والعودة منها. عند تقديمك، قد يكون هذا القدرة على التنقل بسرعة عبر المحتوى مفيدة للغاية. 

![صورة_نظرة_عامة](overview.png)

* لتلخيص العرض التقديمي بالكامل على شريحة واحدة، استخدم [تكبير ملخص](#Summary-Zoom).
* لعرض شرائح محددة فقط، استخدم [تكبير شريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير قسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة جعل عرضك التقديمي أكثر حيوية، حيث يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض. تكبير الشرائح مفيد للعروض القصيرة التي لا تحتوي على أقسام كثيرة، لكنك لا تزال تستطيع استخدامه في سيناريوهات عرض مختلفة.

يساعدك تكبير الشرائح على الخوض في معلومات متعددة بينما تشعر أنك على لوحة واحدة.

![صورة_نظرة_عامة](slidezoomsel.png)

بالنسبة لكائنات تكبير الشرائح، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)، وواجهة [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)، وبعض الطرق ضمن واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إنشاء إطار تكبير على شريحة:
``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشرريحة الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ مربع نص للشرريحة الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ خلفية للشرريحة الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ مربع نص للشرريحة الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //يضيف كائنات ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **إنشاء إطارات التكبير بصور مخصصة**
مع Aspose.Slides لـ .NET، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
5. إضافة إطارات تكبير (تحتوي على المرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إنشاء إطار تكبير بصورة مخصصة:
``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشريحة الثانية
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ مربع نص للشرريحة الثالثة
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ صورة جديدة لكائن التكبير
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //يضيف كائن ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات التكبير**
في الأقسام السابقة، عرضنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شرائح جديدة للربط التي تريد ربط إطار التكبير بها. 
3. إضافة بعض النصوص التعريفية وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لإطار التكبير الأول.
7. تغيير تنسيق الخط لإطار التكبير الثاني.
8. إزالة الخلفية من صورة إطار التكبير الثاني.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية تغيير تنسيق إطار التكبير على شريحة: 
``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // ينشئ خلفية للشرائح الثانية
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // ينشئ مربع نص للشرائح الثانية
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // ينشئ خلفية للشرائح الثالثة
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // ينشئ مربع نص للشرائح الثالثة
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //يضيف كائنات ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ينشئ صورة جديدة لكائن التكبير
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يحدد صورة مخصصة لكائن zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // يحدد تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // إعداد عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.ShowBackground = false;

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **تكبير القسم**

تكبير القسم هو ارتباط لقسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي ترغب في التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من العرض.

![صورة_نظرة_عامة](seczoomsel.png)

بالنسبة لكائنات تكبير الأقسام، توفر Aspose.Slides واجهة [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) وبعض الطرق ضمن واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إنشاء إطار تكبير على شريحة:
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

### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
5. إضافة إطار تكبير قسم (يحتوي على مرجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إنشاء إطار تكبير بصورة مختلفة:
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

    // ينشئ صورة جديدة لكائن التكبير
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموقع لكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط لإطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية تغيير تنسيق إطار تكبير القسم:
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



## **تكبير الملخص**

تكبير الملخص يشبه صفحة هبوط حيث يتم عرض جميع أجزاء العرض التقديمي مرة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في العرض بأي ترتيب ترغب فيه. يمكنك الإبداع، القفز إلى الأمام، أو العودة إلى أجزاء من عرض الشرائح دون مقاطعة تدفق العرض.

![صورة_نظرة_عامة](sumzoomsel.png)

بالنسبة لكائنات تكبير الملخص، توفر Aspose.Slides واجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)، [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)، و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **إنشاء تكبير الملخص**

يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إنشاء إطار تكبير ملخص على شريحة:
``` csharp 
using (Presentation pres = new Presentation())
{
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    //يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 1", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    //يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 2", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    //يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 3", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.Sections.AddSection("Section 4", slide);

    //يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //يحفظ العرض التقديمي
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **إضافة وإزالة أقسام تكبير الملخص**

جميع الأقسام في إطار تكبير الملخص ممثلة بكائنات [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)، والتي تُحفظ في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). يمكنك إضافة أو إزالة كائن قسم تكبير الملخص عبر واجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير ملخص إلى الشريحة الأولى.
4. إضافة شريحة وقسم جديدين إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية إضافة وإزالة الأقسام في إطار تكبير الملخص:
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


### **تنسيق أقسام تكبير الملخص**

لإنشاء كائنات أقسام تكبير ملخص أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الملخص. 

يمكنك التحكم في تنسيق كائن قسم تكبير الملخص داخل إطار تكبير الملخص بهذه الطريقة:

1. إنشاء كائن من صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير ملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير ملخص من `ISummaryZoomSectionCollection` للكائن الأول.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح كيفية تغيير تنسيق كائن قسم تكبير الملخص:
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

نعم. يحتوي [إطار التكبير](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) أو [القسم](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent` الذي، عند تفعيله، يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "سرعة" أو مدة انتقال التكبير؟**

نعم. يدعم التكبير تعيين `TransitionDuration` لتتمكن من التحكم في طول حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض التقديمي؟**

لا توجد حد ثابت موثق للـ API. الحدود العملية تعتمد على تعقيد العرض الإجمالي وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، لكن يُنصح بمراعاة حجم الملف وزمن التقديم.
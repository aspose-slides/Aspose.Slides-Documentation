---
title: إدارة تكبير العرض التقديمي في C++
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/cpp/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides للـ C++ — الانتقال بين الأقسام، إضافة صور مصغرة وانتقالات عبر العروض بصيغ PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح خاصية التكبير في PowerPoint لك بالقفز إلى ومن شرائح معينة، أقسام، وأجزاء من العرض التقديمي. عندما تقوم بالتقديم، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![overview_image](Overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض شرائح مختارة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك التقديمي أكثر حيوية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف تدفق العرض. تعتبر تكبيرات الشرائح رائعة للعروض القصيرة التي لا تحتوي على العديد من الأقسام، لكن لا يزال بإمكانك استخدامها في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على التعمق في عدة قطع من المعلومات بينما تشعر أنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) ، واجهة [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) ، وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير على شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة ترغب بربط إطارات التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح المُنشأة.
4. إضافة إطارات التكبير (التي تحتوي على مراجع إلى الشرائح المُنشأة) إلى الشريحة الأولى.
5. حفظ العرض المُعدل كملف PPTX.

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شرائح جديدة إلى العرض التقديمي
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// ينشئ خلفية للشريحة الثانية
SetSlideBackground(slide2, Color::get_Cyan());

// ينشئ مربع نص للشريحة الثانية
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ينشئ خلفية للشريحة الثالثة
SetSlideBackground(slide3, Color::get_DarkKhaki());

// ينشئ مربع نص للشريحة الثالثة
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//يضيف كائنات ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **إنشاء إطارات تكبير بصور مخصصة**
مع Aspose.Slides للـ C++، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة ترغب بربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع إلى الشريحة المُنشأة) إلى الشريحة الأولى.
6. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// ينشئ خلفية للشريحة الثانية
SetSlideBackground(slide, Color::get_Cyan());

// ينشئ مربع نص للشريحة الثالثة
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//يضيف كائن ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق إطارات التكبير**
في الأقسام السابقة، عرضنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة لربط إطار التكبير بها. 
3. إضافة بعض نصوص التعريف والخلفية إلى الشرائح المُنشأة.
4. إضافة إطارات التكبير (التي تحتوي على مراجع إلى الشرائح المُنشأة) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
5. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//يضيف شرائح جديدة إلى العرض التقديمي
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

 // ينشئ خلفية للشريحة الثانية
SetSlideBackground(slide2, Color::get_Cyan());

 // ينشئ مربع نص للشريحة الثانية
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ينشئ خلفية للشريحة الثالثة
SetSlideBackground(slide3, Color::get_DarkKhaki());

// ينشئ مربع نص للشريحة الثالثة
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

// يضيف كائنات ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// يحدد صورة مخصصة لكائن zoomFrame1
zoomFrame1->set_Image(image);

// يضبط تنسيق إطار التكبير لكائن zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// إعداد عدم إظهار الخلفية لكائن zoomFrame2
zoomFrame2->set_ShowBackground(false);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **تكبير القسم**

تكبير القسم هو وصلة إلى قسم في العرض التقديمي الخاص بك. يمكنك استخدام تكبيرات الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك التقديمي.

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides واجهة [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريف إلى الشريحة المُنشأة.
4. إنشاء قسم جديد ترغب بربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم المُنشأ) إلى الشريحة الأولى.
6. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

// يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides للـ C++، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة المُنشأة.
4. إنشاء قسم جديد ترغب بربط إطار التكبير به. 
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لملء الإطار.
5. إضافة إطار تكبير القسم (الذي يحتوي على مرجع إلى القسم المُنشأ) إلى الشريحة الأولى.
6. حفظ العرض المُعدل كملف PPTX.

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

//ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

//يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة المُنشأة.
4. إنشاء قسم جديد ترغب بربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم المُنشأ) إلى الشريحة الأولى.
6. تغيير الحجم والموقع لكائن تكبير القسم المُنشأ.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم المُنشأ.
9. تفعيل القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

// يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// تنسيق SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **ملخص التكبير**

ملخص التكبير يشبه صفحة هبوط حيث يتم عرض جميع أجزاء العرض التقديمي مرة واحدة. عندما تقوم بالتقديم، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تفضله. يمكنك الإبداع، تخطي مقدماً، أو إعادة زيارة أجزاء عرض الشرائح دون إيقاف تدفق العرض.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides واجهة [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)، [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)، وواجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص التكبير إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح المُنشأة.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

// يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 2", slide);

// يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 3", slide);

// يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 4", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **إضافة وإزالة قسم ملخص التكبير**

جميع الأقسام في إطار ملخص التكبير تمثل كائنات [ISummaryZoomSection]، والتي تُخزن في كائن [ISummaryZoomSectionCollection]. يمكنك إضافة أو إزالة كائن قسم ملخص التكبير عبر واجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح المُنشأة.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم المُنشأ إلى إطار ملخص التكبير.
6. إزالة القسم الأول من إطار ملخص التكبير.
7. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide>();
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

//يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide>();
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 2", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide>();
SetSlideBackground(slide, Color::get_Chartreuse());

// يضيف قسمًا جديدًا إلى العرض التقديمي
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// يضيف قسمًا إلى Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// يزيل القسم من Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق أقسام ملخص التكبير**

لإنشاء أقسام ملخص تكبير أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم ملخص التكبير. 

يمكنك التحكم في تنسيق كائن قسم ملخص التكبير في إطار ملخص التكبير بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح المُنشأة.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. الحصول على كائن قسم ملخص التكبير الأول من `ISummaryZoomSectionCollection`.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عبر إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation] الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم المُنشأ.
9. تفعيل القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض المُعدل كملف PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

//يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 2", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// يحصل على كائن SummaryZoomSection الأول
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// تنسيق كائن SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) على طريقة `set_ReturnToParent` التي تعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "السرعة" أو مدة انتقال التكبير؟**

نعم. يدعم التكبير ضبط مدة الانتقال بحيث يمكنك التحكم في طول حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد صريح موثق في API. تعتمد الحدود العملية على تعقيد العرض وأداء المشاهد. يمكنك إضافة الكثير من إطارات التكبير، لكن يجب مراعاة حجم الملف ووقت التقديم.
---
title: إدارة الزوم
type: docs
weight: 60
url: /ar/cpp/manage-zoom/
keywords: "زوم، إطار الزوم، إضافة زوم، تنسيق إطار الزوم، زوم ملخص، عرض PowerPoint، C++، Aspose.Slides لـ C++"
description: "إضافة زوم أو إطارات زوم لعروض PowerPoint في C++"
---

## **نظرة عامة**
تسمح لك الزوم في PowerPoint بالتنقل إلى ومن شرائح، أقسام، وأجزاء محددة من العرض. عندما تقوم بالتقديم، قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة جدًا.

![overview_image](Overview.png)

* لتلخيص عرض كامل على شريحة واحدة، استخدم [زوم الملخص](#Summary-Zoom).
* لإظهار الشرائح المحددة فقط، استخدم [زوم الشريحة](#Slide-Zoom).
* لإظهار قسم واحد فقط، استخدم [زوم القسم](#Section-Zoom).

## **زوم الشريحة**
يمكن أن يجعل زوم الشريحة عرضك أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض. تعتبر زوم الشرائح رائعة للعروض القصيرة التي لا تحتوي على العديد من الأقسام، ولكن يمكنك استخدامها أيضًا في سيناريوهات عرض مختلفة.

تساعدك زوم الشرائح على التعمق في معلومات متعددة بينما تشعر وكأنك على قماش واحد.

![overview_image](slidezoomsel.png)

بالنسبة لأغراض زوم الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2)، واجهة [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame)، وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء إطارات الزوم**

يمكنك إضافة إطار زوم على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة تربط إليها إطارات الزوم.
3. إضافة نص تعريف وخلفية للشرائح المنشأة.
4. إضافة إطارات زوم (تحتوي على مراجع إلى الشرائح المنشأة) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار زوم على شريحة:

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

//يضيف شرائح جديدة إلى العرض
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// خلق خلفية للشريحة الثانية
SetSlideBackground(slide2, Color::get_Cyan());

// خلق مربع نص للشريحة الثانية
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"الشريحة الثانية");

// خلق خلفية للشريحة الثالثة
SetSlideBackground(slide3, Color::get_DarkKhaki());

// خلق مربع نص للشريحة الثالثة
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"الشريحة الثالثة");

//يضيف كائنات ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **إنشاء إطارات زوم بصور مخصصة**
باستخدام Aspose.Slides لـ C++، يمكنك إنشاء إطار زوم بصورة المعاينة للشرائح المختلفة بهذه الطريقة:
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة ترغب في ربط إطار الزوم بها. 
3. إضافة نص تعريف وخلفية للشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الذي سيستخدم لملء الإطار.
5. إضافة إطارات زوم (تحتوي على مرجع إلى الشريحة المنشأة) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار زوم بصورة مختلفة:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// خلق خلفية للشريحة الثانية
SetSlideBackground(slide, Color::get_Cyan());

// خلق مربع نص للشريحة الثالثة
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"الشريحة الثانية");

// خلق صورة جديدة لكائن الزوم
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//يضيف كائن SectionZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **تنسيق إطارات الزوم**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات زوم بسيطة. لإنشاء إطارات زوم أكثر تعقيدًا، يتعين عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار الزوم.

يمكنك التحكم في تنسيق إطار الزوم على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة تربط إليها إطارات الزوم.
3. إضافة بعض النص التعريفي والخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات زوم (تحتوي على مراجع إلى الشرائح المنشأة) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الذي سيستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار الزوم الأول.
7. تغيير تنسيق الخط للكائن الثاني لإطار الزوم.
8. إزالة الخلفية من صورة الكائن الثاني لإطار الزوم.
5. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية تغيير تنسيق إطار الزوم على شريحة: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//يضيف شرائح جديدة إلى العرض
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// خلق خلفية للشريحة الثانية
SetSlideBackground(slide2, Color::get_Cyan());

// خلق مربع نص للشريحة الثانية
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"الشريحة الثانية");

// خلق خلفية للشريحة الثالثة
SetSlideBackground(slide3, Color::get_DarkKhaki());

// خلق مربع نص للشريحة الثالثة
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"الشريحة الثالثة");

//يضيف كائنات ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// خلق صورة جديدة لكائن الزوم
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// تعيين صورة مخصصة لكائن zoomFrame1
zoomFrame1->set_Image(image);

// تعيين تنسيق إطار زوم لكائن zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// إعداد عدم إظهار الخلفية لكائن zoomFrame2
zoomFrame2->set_ShowBackground(false);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **زوم القسم**

زوم القسم هو رابط إلى قسم في عرضك. يمكنك استخدام زوم الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية اتصالات بعض أجزاء عرضك.

![overview_image](seczoomsel.png)

بالنسبة لأغراض زوم القسم، توفر Aspose.Slides واجهة [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء إطارات زوم القسم**

يمكنك إضافة إطار زوم إلى قسم على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية للشريحة المنشأة.
4. إنشاء قسم جديد ترغب في ربط إطار الزوم به.
5. إضافة إطار زوم (يحتوي على مراجع إلى القسم المنشأ) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار زوم على شريحة:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// إضافة قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

// إضافة كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **إنشاء إطارات زوم القسم بصور مخصصة**

باستخدام Aspose.Slides لـ C++، يمكنك إنشاء إطار زوم القسم بصورة المعاينة للشرائح المختلفة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية للشريحة المنشأة.
4. إنشاء قسم جديد ترغب في ربط إطار الزوم به.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الذي سيستخدم لملء الإطار.
6. إضافة إطار زوم (يحتوي على مرجع إلى القسم المنشأ) إلى الشريحة الأولى.
7. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار زوم بصورة مختلفة:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// إضافة قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

// خلق صورة جديدة لكائن الزوم
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **تنسيق إطارات زوم القسم**

لإنشاء إطارات زوم القسم الأكثر تعقيدًا، عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار زوم القسم.

يمكنك التحكم في تنسيق إطار زوم القسم على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية للشريحة المنشأة.
4. إنشاء قسم جديد ترغب في ربط إطار الزوم به.
5. إضافة إطار زوم (يحتوي على مراجع إلى القسم المنشأ) إلى الشريحة الأولى.
6. تغيير الحجم والموضع لكائن زوم القسم المنشأ.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الذي سيستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار الزوم المنشأ.
9. تعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار الزوم.
11. تغيير تنسيق الخط لكائن الزوم الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية تغيير تنسيق إطار زوم القسم:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// إضافة قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

// إضافة كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// تنسيق لإطار زوم القسم
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

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **زوم الملخص**

زوم الملخص هو مثل صفحة هبوط تُعرض فيها جميع أجزاء عرضك في وقت واحد. عندما تقوم بالتقديم، يمكنك استخدام الزوم للانتقال من مكان إلى آخر في عرضك بأي ترتيب تفضله. يمكنك أن تصبح إبداعيًا، وتخطي إلى الأمام، أو إعادة زيارة أجزاء من عرض الشرائح الخاص بك دون مقاطعة تدفق العرض.

![overview_image](sumzoomsel.png)

بالنسبة لأغراض زوم الملخص، توفر Aspose.Slides واجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)، [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) وبعض الطرق تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **إنشاء زوم الملخص**

يمكنك إضافة إطار زوم الملخص إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار زوم الملخص إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار زوم الملخص على شريحة:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

// يضيف شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 2", slide);

// يضيف شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 3", slide);

// يضيف شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 4", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **إضافة وإزالة قسم زوم الملخص**

جميع الأقسام في إطار زوم الملخص ممثلة بواسطة كائنات [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)، المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). يمكنك إضافة أو إزالة كائن قسم زوم الملخص من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار زوم ملخص إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم جديد إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار زوم الملخص.
6. إزالة القسم الأول من إطار الزوم الملخص.
7. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إضافة وإزالة الأقسام في إطار زوم الملخص:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

//يضيف شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 2", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//يadds شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// يضيف قسم جديد إلى العرض
auto section3 = pres->get_Sections()->AddSection(u"القسم 3", slide);

// يضيف قسم إلى زوم الملخص
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// يزيل القسم من زوم الملخص
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **تنسيق أقسام زوم الملخص**

لإنشاء كائنات قسم زوم الملخص الأكثر تعقيدًا، يتعين عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم زوم الملخص.

يمكنك التحكم في تنسيق كائن قسم زوم الملخص في إطار زوم الملخص بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. إنشاء شرائح جديدة بخلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار زوم الملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم زوم الملخص الأول من `ISummaryZoomSectionCollection`.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الذي سيستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن قسم زوم الملخص المنشأ.
7. تعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. تغيير تنسيق الخط للكائن الزوم الثاني.
9. تغيير مدة الانتقال.
10. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية تغيير تنسيق كائن قسم زوم الملخص:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 1", slide);

//يadds شريحة جديدة إلى العرض
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// يضيف قسم جديد إلى العرض
pres->get_Sections()->AddSection(u"القسم 2", slide);

// يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// يحصل على كائن SummaryZoomSection الأول
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// تنسيق لكائن SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// يحفظ العرض
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
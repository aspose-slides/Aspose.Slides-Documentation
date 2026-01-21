---
title: إدارة تكبير العرض التقديمي في C++
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/cpp/manage-zoom/
keywords:
- تكبير
- إطار تكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides للـ C++ — الانتقال بين الأقسام، إضافة صور مصغرة وانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح مكبرات التكبير في PowerPoint لك بالتنقل إلى ومن شرائح معينة، أقسام، وأجزاء من العرض التقديمي. عندما تقوم بتقديم العرض، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![overview_image](Overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [Summary Zoom](#Summary-Zoom).
* لعرض شرائح مختارة فقط، استخدم [Slide Zoom](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [Section Zoom](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك أكثر ديناميكية، مما يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض التقديمي. تكبيرات الشرائح رائعة للعرض التقديمي القصير دون أقسام عديدة، لكن لا يزال بإمكانك استخدامها في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على الغوص في قطع متعددة من المعلومات بينما تشعر أنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides enumeration [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/) والواجهة [IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) وبعض الطرق تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير على شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إنشاء إطار تكبير على شريحة:
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

//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **إنشاء إطارات تكبير بصور مخصصة**
باستخدام Aspose.Slides للـ C++، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة:
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إنشاء إطار تكبير بصورة مختلفة:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// ينشئ خلفية للشريحة الثانية
SetSlideBackground(slide, Color::get_Cyan());

// ينشئ مربع نص للشريحة الثالثة
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// يضيف كائن ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق إطارات التكبير**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة تريد ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لإطار التكبير الأول.
7. تغيير تنسيق الخط لإطار التكبير الثاني.
8. إزالة الخلفية من صورة إطار التكبير الثاني.
5. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية تغيير تنسيق إطار التكبير على شريحة: 
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

//يضيف كائنات ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// يضبط صورة مخصصة لكائن zoomFrame1
zoomFrame1->set_Image(image);

// يضبط تنسيق إطار التكبير لكائن zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// إعداد لعدم إظهار الخلفية لكائن zoomFrame2
zoomFrame2->set_ShowBackground(false);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **تكبير القسم**

تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها بشدة. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من العرض التقديمي. 

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) وبعض الطرق تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إنشاء إطار تكبير على شريحة:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

//يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides للـ C++، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
5. إضافة إطار تكبير القسم (الذي يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إنشاء إطار تكبير بصورة مختلفة:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

// ينشئ صورة جديدة لكائن التكبير
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// يضيف كائن SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموضع لكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن الإطار الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية تغيير تنسيق إطار تكبير القسم:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

// يضيف كائن SectionZoomFrame object
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// تنسيق كائن SectionZoomFrame
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


## **تكبير الملخص**

تكبير الملخص يشبه صفحة هبوط حيث تُعرض جميع أجزاء العرض التقديمي مرة واحدة. عندما تقوم بتقديم العرض، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في العرض بأي ترتيب تختاره. يمكنك أن تكون مبدعًا، تتخطى أجزاءً، أو تعيد زيارة شرائح العرض دون تعطيل تدفقه.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات تكبير الملخص، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/), و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) وبعض الطرق تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/).

### **إنشاء تكبير الملخص**

يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريفية وقسم جديد للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إنشاء إطار تكبير ملخص على شريحة:
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


### **إضافة وإزالة قسم تكبير ملخص**

جميع الأقسام في إطار تكبير الملخص ممثلة بكائنات [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/). يمكنك إضافة أو إزالة كائن قسم تكبير ملخص عبر واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريفية وقسم جديد للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير ملخص إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض التقديمي.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية إضافة وإزالة أقسام في إطار تكبير الملخص:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//يضيف شريحة جديدة إلى العرض التقديمي
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

//يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 1", slide);

//يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

//يضيف قسمًا جديدًا إلى العرض التقديمي
pres->get_Sections()->AddSection(u"Section 2", slide);

//يضيف كائن SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//يضيف شريحة جديدة إلى العرض التقديمي
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

//يضيف قسمًا جديدًا إلى العرض التقديمي
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

//يضيف قسمًا إلى Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

//يزيل القسم من Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

//يحفظ العرض التقديمي
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **تنسيق أقسام تكبير الملخص**

لإنشاء كائنات أقسام تكبير ملخص أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الملخص. 

يمكنك التحكم في تنسيق كائن قسم تكبير الملخص داخل إطار تكبير الملخص بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريفية وقسم جديد للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير ملخص لأول كائن من `ISummaryZoomSectionCollection`.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. تغيير تنسيق الخط لكائن الإطار الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود C++ كيفية تغيير تنسيق كائن قسم تكبير الملخص:
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

// يحصل على أول كائن SummaryZoomSection
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


## **FAQ**

**هل يمكنني التحكم في العودة إلى الشريحة \"الأصلية\" بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) على طريقة `set_ReturnToParent` التي تعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى الهدف.

**هل يمكنني تعديل \"السرعة\" أو مدة انتقال Zoom؟**

نعم. يدعم Zoom ضبط مدة الانتقال بحيث يمكنك التحكم في طول مدة الحركة القفزية.

**هل هناك حدود لعدد كائنات Zoom التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد صريح موثق في API. تعتمد الحدود العملية على تعقيد العرض التقديمي بشكل عام وأداء المشاهد. يمكنك إضافة العديد من إطارات Zoom، لكن يجب مراعاة حجم الملف ووقت التحميل.
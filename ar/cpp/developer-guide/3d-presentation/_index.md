---
title: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /cpp/3d-presentation/
keywords:
- ثلاثي الأبعاد
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض PowerPoint
- C++
- Aspose.Slides لـ C++
description: "عرض PowerPoint ثلاثي الأبعاد بلغة C++"
---

## نظرة عامة
منذ Aspose.Slides 20.9 أصبح من الممكن إنشاء وتعديل نماذج PowerPoint ثلاثية الأبعاد. يمكن تحقيق ذلك من خلال إضافة مجموعة من التأثيرات الثلاثية الأبعاد إلى الأشكال ثنائية الأبعاد. عن طريق إنشاء عرض كاميرا على الشكل، يمكنك تدويره حول المحور. قم بإنشاء بروز أو عمق على الشكل، مما يحول الشكل من شكل ثنائي الأبعاد إلى نموذج ثلاثي الأبعاد. 
يمكن أن يؤدي تعيين تأثير الضوء على الشكل ثلاثي الأبعاد أو تغيير المواد إلى جعله يبدو أكثر حيوية. تغيير ألوان النماذج ثلاثية الأبعاد إلى تدرج ثلاثي الأبعاد، 
تعديل شكل الكنتور، وإضافة حافة تجعل النموذج ثلاثي الأبعاد أكثر حجماً. يمكن تطبيق جميع التأثيرات ثلاثية الأبعاد على كل من نماذج PowerPoint ثلاثية الأبعاد والنصوص.

دعنا نلاحظ المثال الأول لإنشاء نماذج ثلاثية الأبعاد، والذي يتضمن جميع الميزات المذكورة أعلاه:
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
presentation->Dispose();
```

نموذج PowerPoint ثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## دوران ثلاثي الأبعاد
في PowerPoint، يتوفر دوران الشكل عبر:

![todo:image_alt_text](img_02_01.png)

لتدوير نماذج PowerPoint ثلاثية الأبعاد، من الضروري إنشاء عرض كاميرا على الشكل. يتم ذلك باستخدام طريقة [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4) 
. يتم استدعاء طريقة الدوران من فئة الكاميرا كما لو كنت تقوم بتدوير الكاميرا. في الواقع، عند تدوير الكاميرا بالنسبة إلى الشكل، فإنك تقوم بتدوير الشكل على المستوى ثلاثي الأبعاد.

``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... تعيين معلمات المشهد الثلاثي الأبعاد الأخرى

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```

## عمق وبروز ثلاثي الأبعاد
لإضافة عمق وبروز لنموذج PowerPoint ثلاثي الأبعاد استخدم 
[IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295) .
لتعديل لون البروز استخدم 
[IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e) :
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... تعيين معلمات المشهد الثلاثي الأبعاد الأخرى

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```

قائمة العمق في PowerPoint:

![todo:image_alt_text](img_02_02.png)

## تدرج ثلاثي الأبعاد
يمكن رسم تدرج ثلاثي الأبعاد على نموذج PowerPoint ثلاثي الأبعاد عبر 
[Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58) 
الطريقة:

``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"تدرج ثلاثي الأبعاد");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```

نموذج ثلاثي الأبعاد مع تدرج ثلاثي الأبعاد:

![todo:image_alt_text](img_02_03.png)

لإنشاء تدرج صورة استخدم 
[Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb) الطريقة:
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. إعداد 3D: الكاميرا، LightRig، البروز

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```

نموذج ثلاثي الأبعاد مع تدرج صورة:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
لتطبيق الدوران، البروز، الضوء، التدرج على النص وجعله نصاً ثلاثي الأبعاد (WordArt)، تحتاج إلى الوصول إلى [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30) الطريقة:

``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"نص ثلاثي الأبعاد");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// إعداد تأثير تحويل WordArt "القوس للأعلى"
textFrameFormat->set_Transform(TextShapeType::ArchUp);

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text3d.png");
thumbnail->Dispose();

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

مثال على نص ثلاثي الأبعاد (WordArt):

![todo:image_alt_text](img_02_05.png)

## غير مدعوم - قادم قريباً
الميزات الثلاثية الأبعاد التالية في PowerPoint غير مدعومة بعد: 
- حافة
- مادة
- كنتور
- إضاءة

نواصل تحسين محركنا الثلاثي الأبعاد، وهذه الميزات هي موضوع تنفيذ إضافي.
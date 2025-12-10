---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في C++
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/cpp/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في C++ باستخدام Aspose.Slides بكل سهولة. تصدير سريع إلى صيغ PowerPoint و OpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**
منذ إصدار Aspose.Slides 20.9 أصبح من الممكن إنشاء وتعديل نماذج PowerPoint ثلاثية الأبعاد. يمكن تحقيق ذلك بإضافة مجموعة من التأثيرات ثلاثية الأبعاد إلى الأشكال ثنائية الأبعاد. من خلال إنشاء منظور كاميرا على الشكل، يمكنك تدويره حول المحور. إنشاء بروز أو عمق على الشكل سيحول الشكل من شكل ثنائي الأبعاد إلى نموذج ثلاثي الأبعاد. تعيين تأثير الضوء على الشكل الثلاثي الأبعاد أو تغيير المواد يمكن أن يجعله يبدو أكثر حيوية. تغيير ألوان النماذج الثلاثية الأبعاد إلى تدرج ثلاثي الأبعاد، تعديل محيط الأشكال، إضافة حافة تجعل النموذج الثلاثي الأبعاد أكثر حجمًا. يمكن تطبيق جميع التأثيرات الثلاثية الأبعاد على نماذج PowerPoint ثلاثية الأبعاد والنصوص.

دعونا نلاحظ المثال الأول لإنشاء نماذج ثلاثية الأبعاد، والذي يتضمن جميع الميزات المذكورة أعلاه:
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

## **تدوير ثلاثي الأبعاد**
في PowerPoint يتوفر تدوير الشكل عبر:

![todo:image_alt_text](img_02_01.png)

لتدوير نماذج PowerPoint ثلاثية الأبعاد، يلزم إنشاء منظور كاميرا على الشكل. يتم ذلك باستخدام طريقة [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4). تُستدعى طريقة التدوير من فئة الكاميرا كما لو أنك تقوم بتدوير الكاميرا. في الواقع، عندما تدور الكاميرا بالنسبة إلى الشكل، تقوم بتدوير الشكل على المستوى الثلاثي الأبعاد.
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... ضبط معلمات المشهد ثلاثي الأبعاد

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **العمق الثلاثي الأبعاد والبروز**
لإضافة العمق والبروز إلى نموذج PowerPoint ثلاثي الأبعاد استخدم طريقة [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295).

لتعديل لون البروز استخدم طريقة [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e):
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


قائمة العمق في PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **تدرج ثلاثي الأبعاد**
يمكن رسم تدرج ثلاثي الأبعاد على نموذج PowerPoint ثلاثي الأبعاد عبر طريقة [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58):
``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
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
  
لإنشاء تدرج صورة استخدم طريقة [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb):
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. إعداد 3D: Camera, LightRig, Extrusion

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


نموذج ثلاثي الأبعاد مع تدرج صورة:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**
لتطبيق التدوير، البروز، الإضاءة، التدرج على النص وتحويله إلى نص ثلاثي الأبعاد (WordArt)، تحتاج إلى الوصول إلى طريقة [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30):
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// إعداد تأثير تحويل WordArt "Arch Up"
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

## **الأسئلة المتكررة**

**هل سيتم الحفاظ على التأثيرات الثلاثية الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides ثلاثي الأبعاد بتصيير التأثيرات الثلاثية الأبعاد عند التصدير إلى التنسيقات المدعومة ([images](/slides/ar/cpp/convert-powerpoint-to-png/)، [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "الفعالة" (النهائية) لمعلمات 3D التي تأخذ في الاعتبار السمات، الوراثة، إلخ؟**

نعم. توفر Slides واجهات برمجة تطبيقات لـ [read effective values](/slides/ar/cpp/shape-effective-properties/) (بما في ذلك للـ 3D — الإضاءة، الحواف، إلخ) بحيث يمكنك رؤية الإعدادات النهائية المطبقة.

**هل تعمل التأثيرات الثلاثية الأبعاد عند تحويل العرض إلى فيديو؟**

نعم. عند [generating frames for the video](/slides/ar/cpp/convert-powerpoint-to-video/)، تُصَدر التأثيرات الثلاثية الأبعاد كما هي للـ [exported images](/slides/ar/cpp/convert-powerpoint-to-png/).
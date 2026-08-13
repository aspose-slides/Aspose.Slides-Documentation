---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام C++
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/cpp/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بسط ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في C++ باستخدام Aspose.Slides. ضبط الكاميرا والإضاءة والمادة والبسط والتعبئة والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for C++ يمكنه إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البسط، الحواف المائلة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" %}}
هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في المخرجات الثنائية الأبعاد المصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة الواجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) **get_ThreeDFormat**([get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_threedformat/)) لتطبيق تنسيق ثلاثي الأبعاد على الشكل. تُعيد الطريقة الكائن [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم طريقة الواجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/) **get_ThreeDFormat**([get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/)). يطبق هذا تنسيقًا ثلاثيًا الأبعاد على إطار النص بدلًا من جسم الشكل.

الطرق الأكثر أهمية هي:

| الطريقة | ما الذي تتحكم فيه | متى يتم استخدامها |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_camera/) | نقطة المشاهدة، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | لتدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_lightrig/) | إعداد الإضاءة المسبق، الاتجاه، ودوران الإضاءة. | لتغيير طريقة ظهور اللمسات والظلال على السطح ثلاثي الأبعاد. |
| [set_Material](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_material/) | مادة السطح، مثل مسطح، مطفأ، بلاستيك، أو معدن. | لجعل الهندسة نفسها تبدو أكثر تسطيحًا أو نعومة أو لمعانًا أو معدنية. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سميك يُرى. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | لون الجوانب البسطية. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق PowerPoint ثلاثي الأبعاد. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [get_BevelTop](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_beveltop/) و [get_BevelBottom](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح حاد. |
| [get_ContourColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_contourcolor/) و [set_ContourWidth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_contourwidth/) | حد حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في المخرجات المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البسط.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب مقروءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات البسط أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض كملف PPTX، ويعرض الشريحة كصورة PNG.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تُظهر صورة الشريحة المعروضة المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل ثلاثي الأبعاد أزرق مُظهر مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة "3‑D Rotation". قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة PowerPoint 3‑D Rotation مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك الهندسة الثنائية الأبعاد للشكل على الشريحة؛ وإنما يغيّر منظور العرض ثلاثي الأبعاد المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة بسط وعمق**

البسط يجعل الشكل يبدُو سميكًا بامتداده خلف الوجه الأمامي. في PowerPoint، يتحكم عنصر العمق في هذا السمك المرئي، ويتحكم عنصر اللون في لون الوجوه الجانبية.

![عناصر تحكم العمق في PowerPoint مُطابقة للخصائص extrusion color وextrusion height](img_02_02.png)

استخدم [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) لتحديد السمك و[get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) للون الجوانب:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

استخدم [set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) عندما تحتاج للعمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحواف والمادة وتأثيرات النص. في كثير من سيناريوهات الشكل، يكون `set_ExtrusionHeight` هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن البسط المرئي.

## **استخدام تعبئة تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبسط.

هذا المثال يطبق تعبئة تدرج على الشكل ولون بسط أغمق للجوانب:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

تحتفظ المخرجات المعروضة بالتدرج على الوجه الأمامي وتعرض البسط بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج من الأزرق إلى البرتقالي وبسط برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلًا من ذلك، أضف الصورة إلى العرض وعيّنها لتعبئة الشكل:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

تُعرض الصورة على الوجه الأمامي، بينما يُعرض البسط كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبسط برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق الشكل ثلاثي الأبعاد يؤثر على جسم الشكل. تنسيق النص ثلاثي الأبعاد يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الأحرف نفسها إلى بسط ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط تعبئة، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يُعرض النص كحروف ثلاثية الأبعاد مقوسة ومسطّة:

![نص ثلاثي الأبعاد مع تحويل WordArt مقوس وتعبئة نمط برتقالي وبسط داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة التخطيط، يتم تحويل المشهد ثلاثي الأبعاد إلى صورة نقطية أو رسم في المخرجات كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تعرض الشرائح إلى [PNG](/slides/ar/cpp/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، أو توليد إطارات لتحويل [video](/slides/ar/cpp/convert-powerpoint-to-video/).

ضع في اعتبارك النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة الس rig، والمادة، والبسط، والتعبئة، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائمة على السمة، اقرأ [الخصائص الفعّالة للشكل](/slides/ar/cpp/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق PowerPoint ثلاثي الأبعاد القابل للتحرير. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

### هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟

Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

### ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يتم إدراجه في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البسط، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات الثلاثية الأبعاد.

### ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد ظاهر؟

على الأقل، اضبط دوران الكاميرا إما البسط أو العمق. عمليًا، قم أيضًا بضبط إضاءة الس rig والمادة لكي تكون الوجوه الظاهرة ذات إضاءات وظلال واضحة.

### هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟

نعم. استخدم [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) لجسم الشكل و[ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/) للنص.

### هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى الصور أو PDF أو HTML أو إطارات الفيديو؟

نعم. Aspose.Slides يعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. يحتوي المخرج المصدَّر على الشكل المعروض، وليس كائنًا ثلاثيًا قابلًا للتحرير.

### هل يمكنني قراءة القيم النهائية لتنسيق ثلاثي الأبعاد بعد تطبيق الميراث وإعدادات السمة؟

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/cpp/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة الس rig، والحافة، والقيم الثلاثية الأبعاد المرتبطة.
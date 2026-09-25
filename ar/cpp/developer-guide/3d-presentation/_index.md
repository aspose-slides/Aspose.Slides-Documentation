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
- اختراق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وتصيير تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في C++ باستخدام Aspose.Slides. ضبط الكاميرا، الإضاءة، المادة، الاختراق، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، والاختراق، والحواف المقطوعة، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}

هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. وهي ليست عن إدراج أو تحرير ملفات نماذج ثلاثية الأبعاد مستقلة. عندما تقوم بتصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتصيير تلك التأثيرات الثلاثية الأبعاد في الناتج الثنائي الأبعاد.

{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الطريقة [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_threedformat/) لتطبيق تنسيق ثلاثي الأبعاد على الشكل. تُعيد الطريقة الكائن [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/)، الذي يتحكم في المشهد الثلاثي الأبعاد لذلك الشكل.

للنص، استخدم الطريقة [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/) . يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الطرق الأكثر أهمية هي:

| الطريقة | ما الذي يتحكم به | متى يتم استخدامه |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_camera/) | نقطة المشاهدة، نوع الكاميرا الافتراضي، الدوران، التكبير، والمنظور. | دوّر الكائن في الفضاء ثلاثي الأبعاد أو طابق إعداد دوران ثلاثي أبعاد مسبق في PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_lightrig/) | إضاءة مسبقة، الاتجاه، ودوران الضوء. | غيّر طريقة ظهور الإبرازات والظلال على السطح الثلاثي الأبعاد. |
| [set_Material](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_material/) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | اجعل الهندسة نفسها تبدو أكثر مسطحًا أو ناعمًا أو لامعًا أو معدنيًا. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | مدى بُعد الشكل إلى الخلف من وجهه الأمامي. | حوّل الشكل المسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | لون الجوانب المختارة. | اجعل العمق مرئيًا أو نسق لون الجوانب مع الملء الأمامي. |
| [set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | اضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمواد. |
| [get_BevelTop](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_beveltop/) و [get_BevelBottom](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | حواف مرتفعة أو مُدوَّرة على الوجهين الأمامي والخلفي. | أضف حافة مُلينَة أو مُشكَّلة بدلًا من وجه مسطح حاد. |
| [get_ContourColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_contourcolor/) و [set_ContourWidth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_contourwidth/) | مخطط حول الكائن الثلاثي الأبعاد. | أبرز حدود الكائن في الناتج المصور. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي الاختراق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات الاختراق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع الاختراق 100 نقطة. يُظهر المثال الشريحة كصورة PNG بأبعاد مضاعفة عن الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

الصورة المصدرة للشرائح تُظهر المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل ثلاثي أبعاد أزرق مُصوَّر مع نص ثلاثي أبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران الثلاثي الأبعاد من خلال لوحة 3‑D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة PowerPoint 3‑D Rotation مع إبراز قيم دوران X وY وZ](img_02_01.png)

في Aspose.Slides، احصل على الكاميرا عبر الطريقة [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_camera/). يُنشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

presentation->Dispose();
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائية الأبعاد على الشريحة. يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند التصيير.

## **إضافة اختراق وعمق**

يُجعل الاختراق الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السمك المرئي، ويتحكم التحكم في اللون في لون الوجه الجانبي.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون الاختراق وارتفاع الاختراق](img_02_02.png)

اضبط الطريقة [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) لتحديد السمك و[IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) للون الجوانب. يمنح هذا المثال المستطيل اختراقًا بارتفاع 100 نقطة مع جوانب بنفسجية ويدور الكاميرا لإظهار سماكته. يكوّن الشكل في الذاكرة دون حفظ ملف:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

الطريقة [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) تُحدد عمق الشكل الثلاثي الأبعاد. الطريقة [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) تتحكم في ارتفاع تأثير الاختراق، كما هو موضح في هذا المثال.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا والإضاءة والمادة والاختراق.

يطبق هذا المثال تدرجًا من الأزرق إلى البرتقالي على الوجه الأمامي ولونًا برتقاليًا داكنًا على الاختراق بارتفاع 150 نقطة. نقاط التدرج عند 0 و100 تمثل بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُصّور الشريحة كصورة PNG بأبعاد مضاعفة عن الأبعاد الافتراضية:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

الناتج المصور يحتفظ بالتدرج على الوجه الأمامي ويصوّر الاختراق بصورة منفصلة:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي واختراق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها كملء الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يمتد الصورة لتملأ المستطيل، يطبق اختراقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو تصيير ملف:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

تُصوّر الصورة على الوجه الأمامي، بينما يُصوّر الاختراق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي واختراق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات ثلاثية الأبعاد على جسم الشكل. تؤثر تنسيقات ثلاثية الأبعاد على النص على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى اختراق ومادة وإضاءة وإعدادات كاميرا.

ينشئ المثال التالي نصًا بنمط شبكة برتقالية-بيضاء، يطبق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر الطريقة [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/). ارتفاع الاختراق والعمق بالنقاط، ودوران الضوء بالدرجات. يُخفى ملء الشكل ومحدوده بحيث لا يُرى سوى النص. يُصوّر المثال صورة PNG بأبعاد مضاعفة عن أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

يُصوّر النص كحروف ثلاثية الأبعاد مقوسة ومختارة:

![نص ثلاثي الأبعاد مُصوَّر مع تحويل WordArt مقوس، تعبئة نمط برتقالي، واختراق داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ الطريقة [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_keeptextflat/) عبر الطريقة [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_textframeformat/). عندما تكون القيمة `true`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع اتجاهه الثلاثي الأبعاد.

هذه الإعدادات لا تزيل تنسيق ثلاثي الأبعاد للشكل: لا تزال الكاميرا والإضاءة والمادة والاختراق مُكوَّنة عبر الطريقة [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_threedformat/). وهي مختلفة أيضًا عن الدوران العادي. الطريقة [IShape::set_Rotation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_rotation/) تدور الشكل في طائرة الشريحة، بينما الطريقة [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_rotationangle/) تتحكم في دوران مخصص للنص داخل صندوقه الحدودي. إبقاء النص خارج المشهد الثلاثي الأبعاد لا يعيد ضبط أي من هذين الزاويتين.

ينشئ المثال المستقل التالي مستطيلًا أزرقًا مع نص، ثم ينسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الفرق الوحيد هو إعداد النص: `false` على اليسار و `true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع الاختراق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويصوّر شريحة المقارنة إلى PNG بأبعاد مضاعفة عن الأبعاد الافتراضية.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

على اليسار، يتبع النص اتجاه الثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل للقراءة. يحتفظ كلا المستطيلين بالاختراق الظاهر نفسه والاتجاه الثلاثي الأبعاد.

![مستطيلان ثلاثيان جنبًا إلى جنب: KeepTextFlat = false على اليسار و true على اليمين](keep_text_flat.png)

## **سلوك التصدير والتصيير**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ بصيغ PowerPoint مثل PPTX. عند التصيير أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد الثلاثي الأبعاد إلى صورة نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تصيغ الشرائح إلى [PNG](/slides/ar/cpp/convert-powerpoint-to-png/)، أو تصدر إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، أو تُولِّد إطارات لتحويل الفيديو [video conversion](/slides/ar/cpp/convert-powerpoint-to-video/).

احتفظ بهذه النقاط في الاعتبار:

- الصور وملفات PDF المُصدَّرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على تركيبة الكاميرا، وإضاءة المشهد، والمادة، والاختراق، والملء، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعَّالة](/slides/ar/cpp/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يُصوَّر النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية أبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

إن Aspose.Slides ينشئ ويصوّر تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية ثلاثية الأبعاد يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، الاختراق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، عيّن دوران الكاميرا وإما الاختراق أو العمق. عمليًا، يجب أيضًا ضبط إضاءة المشهد والمادة حتى تكون الوجوه المصوَّرة ذات إبرازات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم الطريقة [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_threedformat/) لجسم الشكل والطريقة [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/) للنص.

**هل ستظهر التأثيرات الثلاثية الأبعاد عند تصديرها إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بتصيير التأثيرات الثلاثية الأبعاد عند إنتاج صور الشرائح، أو مخرجات PDF، أو مخرجات HTML، أو الإطارات المستخدمة لتحويل الفيديو. يحتوي الناتج المصوَّر على المظهر النهائي، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الموروثات وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعَّال الموصوفة في [Shape Effective Properties](/slides/ar/cpp/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد المرتبطة.
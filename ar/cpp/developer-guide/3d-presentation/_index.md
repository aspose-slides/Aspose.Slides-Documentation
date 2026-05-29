---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام C++
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/cpp/3d-presentation/
keywords:
- 3D PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- استخراج ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في C++ باستخدام Aspose.Slides. تكوين الكاميرا، الإضاءة، المادة، الإخراج، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد بنمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، والإخراج، والحواف المائلة، والإضاءة، والمواد، وتعبئة التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
يتناول هذا المقال تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتعامل مع إدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتحويل تلك التأثيرات الثلاثية الأبعاد إلى المخرجات الثنائية الأبعاد المُصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_threedformat/) في واجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) لتطبيق تنسيق ثلاثي الأبعاد على الشكل. تُعيد الطريقة كائنًا من النوع [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم طريقة [get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/) في واجهة [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/). تُطبق هذه الطريقة تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الطرق الأكثر أهمية هي:

| الطريقة | ما الذي يتحكم به | متى يتم استخدامها |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_camera/) | وجهة العرض، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق لدوران ثلاثي الأبعاد في PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_lightrig/) | إعداد إضاءة محدد مسبقًا، الاتجاه، ودوران الضوء. | تغيير مظهر الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [set_Material](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_material/) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | جعل الشكل نفسه يبدو أكثر تسطحًا، أو نعومة، أو لامعًا، أو معدنيًا. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | المسافة التي يمتد فيها الشكل إلى الخلف من سطحه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك ظاهر. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | لون الجوانب المستخرجة. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) | عمق ثلاثي الأبعاد إضافي يُستخدم في تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط عمق الشكل أو النص بدقة، خاصةً مع إعدادات الحافة والمواد. |
| [get_BevelTop](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | حواف مرتفعة أو مُدَّورة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُصقَّلة بدلًا من وجه مسطح حاد. |
| [get_ContourColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_contourwidth/) | محيط حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في النتيجة المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي الإخراج.  
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب واضحة.  
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.  
- إعدادات الإخراج أو العمق، لأن الشكل المسطح يحتاج إلى السماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويحوّل الشريحة إلى صورة PNG.

```cpp
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

تظهر صورة الشريحة المُرَسَمة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُرَسَم مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة PowerPoint 3-D Rotation مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا تغير الهندسة ثنائية الأبعاد للشكل على الشريحة. إنها تغير منظور ثلاثي الأبعاد المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة الإخراج والعمق**

الإخراج يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في هذا السمك المرئي، وتتحكم أداة اللون في لون الجوانب.

![تحكمات العمق في PowerPoint مرتبطة بخصائص لون الإخراج وارتفاع الإخراج](img_02_02.png)

قم بتعيين [set_ExtrusionHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_extrusionheight/) للسمك و[get_ExtrusionColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) للون الجوانب:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

استخدم [set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/set_depth/) عندما تحتاج إلى التعامل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في العديد من سيناريوهات الشكل، يكون `set_ExtrusionHeight` الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن الإخراج المرئي.

## **استخدام تعبئة بالتدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمادة والإخراج.

هذا المثال يطبق تعبئة بالتدرج على الشكل ولون إخراج أغمق على الجوانب:

```cpp
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

المخرج المُرَسَم يحافظ على التدرج على الوجه الأمامي ويعرض الإخراج بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُرَسَم مع تعبئة تدرج أزرق إلى برتقالي وإخراج برتقالي](img_02_03.png)

استخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```cpp
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

![مستطيل ثلاثي الأبعاد مُرَسَم مع تعبئة صورة على الوجه الأمامي وإخراج برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق الشكل ثلاثي الأبعاد يؤثر على جسم الشكل. تنسيق النص ثلاثي الأبعاد يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى الإخراج، المادة، الإضاءة، وإعدادات الكاميرا.

المثال التالي ينشئ نصًا مع تعبئة بنمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/):

```cpp
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

![نص ثلاثي الأبعاد مُرَسَم مع تحويل WordArt مقوس، تعبئة نمط برتقالي، وإخراج داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نمط نقطي أو رسمه في المخرجات كنتيجة ثنائية الأبعاد. ينطبق هذا عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/cpp/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، أو إنشاء إطارات للتحويل إلى [video conversion](/slides/ar/cpp/convert-powerpoint-to-video/).

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على مجموعة الكاميرا، وإضاءة المشهد، والمادة، والإخراج، والتعبئة، وتوسعة الشريحة.  
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [effective shape properties](/slides/ar/cpp/shape-effective-properties/).  
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتعديل في PowerPoint. في تلك الصيغ، يتم عرض النتيجة المرئية بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتداولة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**  
يقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. ولا يجعل الصور، ملفات PDF، أو صفحات HTML المصدرة مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في ملف PPTX، يظل تنسيق ثلاثي الأبعاد قابلًا للتعديل في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**  
النموذج الثلاثي الأبعاد هو كائن ثلاثي الأبعاد مستقل يُدرج في العرض التقديمي. أما التأثير الثلاثي الأبعاد فهو تنسيق يُطبق على شكل أو نص عادي في PowerPoint، مثل الدوران، الإخراج، الحافة، الإضاءة، والمادة. يغطي هذا المقال التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد ظاهر؟**  
على الأقل، يجب ضبط دوران الكاميرا وإما الإخراج أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة المشهد والمادة بحيث تكون الوجوه المعروضة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**  
نعم. استخدم [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) لجسم الشكل و[ITextFrameFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**  
نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، ومخرجات PDF، ومخرجات HTML، والإطارات المستخدمة في تحويل الفيديو. يحتوي الناتج المصدَّر على الشكل المعروض، وليس كائنًا ثلاثيًا أبعادًا قابلًا للتعديل.

**هل يمكنني قراءة القيم ثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعلي الموضحة في [Shape Effective Properties](/slides/ar/cpp/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.
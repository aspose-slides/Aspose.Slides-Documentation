---
title: إنشاء وتطبيق تأثيرات WordArt في C++
linktitle: WordArt
type: docs
weight: 110
url: /ar/cpp/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير 3D
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- PowerPoint
- عرض
- C++
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides for C++. هذا الدليل خطوة بخطوة يساعد المطورين على تحسين العروض التقديمية بنص احترافي في C++."
---

## **عن WordArt؟**
WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك تحديد حدود للنص أو ملئه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد إليه، إلخ. يمكنك أيضاً إمالة النص، انحنائه، وتمدد شكل النص.

{{% alert color="primary" %}} 
WordArt يتيح لك التعامل مع النص ككائن رسومي. بشكل عام، يتكون WordArt من تأثيرات أو تعديل خاص يُجرى على النصوص لجعلها أكثر جاذبية أو وضوحاً. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قالب WordArt المحددة مسبقًا. قالب WordArt هو مجموعة من التأثيرات تُطبق على نص أو شكله.

**WordArt في Aspose.Slides**

في Aspose.Slides for C++ 20.10، أدّينا الدعم لـ WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for C++ اللاحقة.

مع Aspose.Slides for C++، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) في C++ وتطبيقه على النصوص.

## **إنشاء قالب WordArt بسيط وتطبيقه على نص**

**باستخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام كود C++ التالي:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```


الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:
``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```


**باستخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة اليمنى، يمكنك اختيار تأثير WordArt محدد مسبقًا. من القائمة اليسرى، يمكنك تحديد إعدادات WordArt جديد.

هذه بعض المعاملات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق لون نمط SmallGrid على النص ونضيف حد نص أسود بعرض 1 باستخدام هذا الكود:
``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```


النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## **تطبيق تأثيرات WordArt أخرى**

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نصية أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على نص؛ وتأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد على كتلة نصية؛ وخاصية الحواف الناعمة يمكن تطبيقها على كائن شكل (وما زال لها تأثير عندما لا يتم تعيين خاصية تنسيق ثلاثي الأبعاد).

### **تطبيق تأثيرات الظل على النص**

هنا، نهدف إلى ضبط الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود في C++:
``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```


API الخاص بـ Aspose.Slides يدعم ثلاثة أنواع من الظلال: OuterShadow، InnerShadow، و PresetShadow.

مع PresetShadow، يمكنك تطبيق ظل للنص (باستخدام قيم مسبقة).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظل. إليك مثالاً:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

Aspose.Slides يتيح لك بالفعل تطبيق نوعين من الظلال في آن واحد: InnerShadow و PresetShadow.

**ملاحظات:**

- عندما يتم استخدام OuterShadow و PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط.  
- إذا تم استخدام OuterShadow و InnerShadow في نفس الوقت، فإن النتيجة أو التأثير المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. لكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow. 

### **تطبيق تأثيرات الانعكاس**

نضيف انعكاسًا إلى النص عبر عينة الكود هذه في C++:
``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```


### **تطبيق تأثيرات التوهج**

نطبق تأثير التوهج على النص لجعله يبرق أو يبرز باستخدام هذا الكود:
``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
يمكنك تغيير المعايير للظل، العرض، والتوهج. تُحدد خصائص التأثيرات لكل جزء من النص على حدة. 
{{% /alert %}} 

### **استخدام التحولات في WordArt**

نستخدم الطريقة set_Transform (المطبقة على الكتلة النصية بأكملها) عبر هذا الكود:
``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
كل من Microsoft PowerPoint و Aspose.Slides for C++ يقدمان عددًا معينًا من أنواع التحويل المحددة مسبقًا. 
{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحويل المحددة مسبقًا، انتقل عبر: **Format** → **TextEffect** → **Transform**

**باستخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد TextShapeType.

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**

نضبط تأثير ثلاثي الأبعاد على شكل نص باستخدام عينة الكود التالية:
``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


النص والشكل الناتجين:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص عبر هذا الكود C++:
``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعل بين التأثيرات قائم على قواعد معينة. 

تخيل مشهدًا للنص والشكل الذي يحتويه. يتضمن تأثير ثلاثي الأبعاد تمثيلًا كائنًا ثلاثيًا الأبعاد والمشهد الذي وُضع عليه الكائن. 

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى — يُهمل مشهد النص.  
- عندما يفتقر الشكل إلى مشهد خاص به ولكن له تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.  
- وإلا — عندما لا يمتلك الشكل أصلاً تأثيرًا ثلاثيًا الأبعاد — يكون الشكل مسطحًا ويُطبق تأثير ثلاثي الأبعاد فقط على النص.  

هذه الأوصاف مرتبطة بالطرق ThreeDFormat.getLightRig() و ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على الأشكال**
Aspose.Slides for C++ يوفر الفصول [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) و [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) التي تسمح لك بتطبيق تأثيرات الظل على نص داخل TextFrame. اتبع الخطوات التالية:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. احصل على مرجع شريحة باستخدام فهرسها.  
3. أضف AutoShape من النوع Rectangle إلى الشريحة.  
4. احصل على TextFrame المرتبط بـ AutoShape.  
5. اضبط FillType لـ AutoShape إلى NoFill.  
6. أنشئ كائن OuterShadow.  
7. اضبط BlurRadius للظل.  
8. اضبط Direction للظل.  
9. اضبط Distance للظل.  
10. اضبط RectanglelAlign إلى TopLeft.  
11. اضبط PresetColor للظل إلى Black.  
12. احفظ العرض كملف PPTX.

توضح عينة الكود هذه في C++—تنفيذ للخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص:
```cpp
auto pres = System::MakeObject<Presentation>();
// الحصول على مرجع الشريحة
auto sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من نوع مستطيل
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u"Aspose TextBox");

// تعطيل تعبئة الشكل في حالة رغبتنا بالحصول على ظل النص
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// إضافة ظل خارجي وتعيين جميع المعلمات اللازمة
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// كتابة العرض إلى القرص
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **تطبيق تأثيرات الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. احصل على مرجع للشريحة.  
3. أضف AutoShape من النوع Rectangle.  
4. فعل InnerShadowEffect.  
5. اضبط جميع المعلمات اللازمة.  
6. اضبط ColorType إلى Scheme.  
7. اضبط Scheme Color.  
8. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

توضح عينة الكود (استنادًا إلى الخطوات أعلاه) كيفية إضافة موصل بين شكلين في C++:
``` cpp
auto presentation = System::MakeObject<Presentation>();
// الحصول على مرجع شريحة
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة AutoShape من نوع مستطيل
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// تمكين تأثير الظل الداخلي    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// تعيين جميع المعلمات اللازمة
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// تعيين نوع اللون إلى Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// تعيين لون المخطط
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// حفظ العرض
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الرئيسية؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في الشرائح الرئيسية، بما في ذلك عناصر النُسخ والعناوين، والتذييلات، أو النص الخلفي. التغييرات التي تُجريها على تخطيط الشريحة الرئيسية ستظهر في جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

تؤثر قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج حجم الملف قليلًا بسبب بيانات التنسيق الإضافية، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام الطريقة `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.
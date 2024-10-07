---
title: فن الكتابة
type: docs
weight: 110
url: /cpp/wordart/
---

## **ما هو فن الكتابة؟**
فن الكتابة هو ميزة تُتيح لك تطبيق تأثيرات على النصوص لجعلها تبرز. مع فن الكتابة، على سبيل المثال، يمكنك تحديد نص أو ملؤه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد إليه، وما إلى ذلك. يمكنك أيضًا تحريف وشد شكل النص.

{{% alert color="primary" %}} 

يتيح لك فن الكتابة التعامل مع النص كما لو كان كائنًا رسوميًا. بشكل عام، يتكون فن الكتابة من تأثيرات أو تعديلات خاصة تضاف إلى النصوص لجعلها أكثر جاذبية أو وضوحًا.

{{% /alert %}} 

**فن الكتابة في Microsoft PowerPoint**

لاستخدام فن الكتابة في Microsoft PowerPoint، يجب عليك اختيار أحد قوالب فن الكتابة المحددة مسبقًا. قالب فن الكتابة هو مجموعة من التأثيرات التي تُطبق على نص أو شكله.

**فن الكتابة في Aspose.Slides**

في Aspose.Slides لـ C++ 20.10، قمنا بتنفيذ دعم لفن الكتابة وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides لـ C++ اللاحقة.

مع Aspose.Slides لـ C++، يمكنك بسهولة إنشاء قالب فن كتابة خاص بك (تأثير واحد أو مجموعة من التأثيرات) في C++ وتطبيقه على النصوص.

## إنشاء قالب فن كتابة بسيط وتطبيقه على نص

**باستخدام Aspose.Slides**

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الكود في C++: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"آسبوز.سلايدز");
```

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**باستخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات فن الكتابة في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير فن الكتابة المحدد مسبقًا. من القائمة على اليسار، يمكنك تحديد الإعدادات لفن كتابة جديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق لون نمط SmallGrid على النص ونضيف حدود نصية سوداء بعرض 1 باستخدام هذا الكود:

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

## تطبيق تأثيرات أخرى لفن الكتابة

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نصية، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ ويمكن تطبيق تأثيرات التنسيق ثلاثي الأبعاد والتدوير ثلاثي الأبعاد على كتلة نصية؛ ويمكن تطبيق خاصية الحواف الناعمة على شكل كائن (لا يزال له تأثير عند عدم تعيين خاصية التنسيق ثلاثي الأبعاد).

### تطبيق تأثيرات الظل

هنا، ننوي ضبط الخصائص المتعلقة بنص فقط. نقوم بتطبيق تأثير الظل على النص باستخدام هذا الكود في C++:

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

يدعم Aspose.Slides API ثلاثة أنواع من الظلال: الظل الخارجي، الظل الداخلي، والظل المحدد مسبقًا.

 مع الظل المحدد مسبقًا، يمكنك تطبيق ظل على نص (باستخدام القيم المحددة مسبقًا).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظل. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

يسمح Aspose.Slides في الواقع بتطبيق نوعين من الظلال في وقت واحد: الظل الداخلي والظل المحدد مسبقًا.

**ملاحظات:**

- عند استخدام الظل الخارجي والظل المحدد مسبقًا معًا، يتم تطبيق تأثير الظل الخارجي فقط.
- إذا تم استخدام الظل الخارجي والظل الداخلي في نفس الوقت، يعتمد التأثير الناتج أو المطبق على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. لكن في PowerPoint 2007، يتم تطبيق تأثير الظل الخارجي.

### تطبيق العرض على النصوص

نضيف العرض إلى النص من خلال هذا المثال البرمجي في C++:

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

### تطبيق تأثير التوهج على النصوص

نقوم بتطبيق تأثير التوهج على النص لجعله يتألق أو يبرز باستخدام هذا الكود:

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

يمكنك تغيير معايير الظل، العرض، والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل.

{{% /alert %}} 

### استخدام التحويلات في فن الكتابة

نستخدم طريقة set_Transform (الموروثة في الكتلة الكاملة من النص) من خلال هذا الكود:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

توفر كل من Microsoft PowerPoint وAspose.Slides لـ C++ عددًا معينًا من أنواع التحويل المحددة مسبقًا.

{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحويل المحددة مسبقًا، اذهب من خلال: **تنسيق** -> **تأثير النص** -> **تحويل**

**باستخدام Aspose.Slides**

لتحديد نوع تحويل، استخدم تعداد TextShapeType.

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نقوم بتعيين تأثير ثلاثي الأبعاد على شكل نص باستخدام هذا الكود التجريبي:

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

النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثير ثلاثي الأبعاد على النص بهذا الكود في C++:

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

تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات تعتمد على قواعد معينة.

اعتبر مشهدًا لنص والشكل الذي يحتوي ذلك النص. يحتوي التأثير الثلاثي الأبعاد على تمثيل الكائن ثلاثي الأبعاد والمشهد الذي وُضع فيه الكائن.

- عند تعيين المشهد لكل من الشكل والنص، يحصل شكل المشهد على أولوية أعلى—يتم تجاهل مشهد النص.
- عند عدم وجود مشهد خاص بالشكل ولكن يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- بخلاف ذلك—عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد—يكون الشكل مسطحًا فقط ويُطبق التأثير الثلاثي الأبعاد على النص.

 تتصل هذه الأوصاف بطرق ThreeDFormat.getLightRig() وThreeDFormat.getCamera().

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
تقدم Aspose.Slides لـ C++ الفئات [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) و [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) التي تتيح لك تطبيق تأثيرات الظل على نص محمول بواسطة TextFrame. اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع للشرائح باستخدام فهرسها.
3. إضافة شكل أوتو من نوع المستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبط بالشكل أوتو.
5. تعيين نوع التعبئة للشكل أوتو إلى NoFill.
6. إنشاء فئة OuterShadow.
7. تعيين BlurRadius للظل.
8. تعيين اتجاه الظل.
9. تعيين مسافة الظل.
10. تعيين RectangleAlign إلى TopLeft.
11. تعيين اللون المحدد للظل إلى الأسود.
12. كتابة العرض كملف PPTX.

هذا المثال البرمجي في C++—تطبيق الخطوات أعلاه—يظهر لك كيفية تطبيق تأثير الظل الخارجي على نص:

``` cpp
auto pres = System::MakeObject<Presentation>();
// احصل على مرجع الشريحة
auto sld = pres->get_Slides()->idx_get(0);

// أضف شكل أوتو من نوع المستطيل
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// أضف نص إطار إلى المستطيل
ashp->AddTextFrame(u"آسبوز نص صندوق");

// تعطيل تعبئة الشكل في حالة أردنا الحصول على ظل النص
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// إضافة ظل خارجي وضبط كافة المعلمات اللازمة
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


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة.
3. إضافة شكل أوتو من نوع المستطيل.
4. تفعيل InnerShadowEffect.
5. تعيين كافة المعلمات اللازمة.
6. تعيين نوع اللون كـ Scheme.
7. تعيين لون المخطط.
8. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

هذا المثال البرمجي (استنادًا إلى الخطوات أعلاه) يوضح لك كيفية إضافة وصلة بين شكلين في C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// احصل على مرجع الشريحة
auto slide = presentation->get_Slides()->idx_get(0);

// أضف شكل أوتو من نوع المستطيل
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// أضف نص إطار إلى المستطيل
ashp->AddTextFrame(u"آسبوز نص صندوق");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// تفعيل InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// تعيين جميع المعلمات اللازمة
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// تعيين نوع اللون كـ Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// تعيين لون المخطط
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// حفظ العرض
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```
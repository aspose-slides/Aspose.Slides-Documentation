---
title: إدارة إعدادات التكيف التلقائي
type: docs
weight: 30
url: /ar/cpp/manage-autofit-settings/
keywords: "مربع نص, تكيف تلقائي, عرض بوربوينت, C++, Aspose.Slides for C++"
description: "تعيين إعدادات التكيف التلقائي لمربع النص في عرض بوربوينت باستخدام C++"
---

بشكل افتراضي، عندما تضيف مربع نص، يستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لمربع النص—فهو يقوم تلقائيًا بتغيير حجم مربع النص لضمان تناسب النص دائمًا فيه.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint بتكبير مربع النص تلقائيًا—يزيد ارتفاعه—لسماحه بحمل مزيد من النص. 
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint بتقليص مربع النص تلقائيًا—يقلل ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي 4 معلمات أو خيارات هامة تتحكم في سلوك التكيف التلقائي لمربع النص:

* **عدم التكيف التلقائي**
* **تصغير النص عند تجاوز الحد**
* **تغيير حجم الشكل ليتناسب مع النص**
* **لف النص داخل الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for C++ خيارات مماثلة—بعض الطرق تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)—التي تتيح لك التحكم في سلوك التكيف التلقائي لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص في مربع مع ذلك المربع دائمًا بعد إجراء التغييرات على النص، عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يوضح لك هذا الكود في C++ كيفية تعيين أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض بوربوينت:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

إذا أصبح النص أطول أو أكبر، سيتم تغيير حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان ملاءمة كل النص فيه. إذا أصبح النص أقصر، يحدث العكس.

## **عدم التكيف التلقائي**

إذا كنت تريد لمربع النص أو الشكل أن يحتفظ بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، عليك استخدام خيار **عدم التكيف التلقائي**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يوضح لك هذا الكود في C++ كيفية تعيين أن مربع النص يجب أن يحتفظ دائمًا بأبعاده في عرض بوربوينت:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه، سيتجاوز حدوده.

## **تصغير النص عند تجاوز الحد**

إذا أصبح النص طويلًا جدًا بالنسبة لصندوقه، من خلال خيار **تصغير النص عند تجاوز الحد**، يمكنك تحديد أن حجم النص ومسافاته يجب أن تقلل لتناسب في صندوقه. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يوضح لك هذا الكود في C++ كيفية تعيين أن نص يجب تصغيره عند تجاوز الحد في عرض بوربوينت:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="معلومات" color="info" %}}

عندما يتم استخدام خيار **تصغير النص عند تجاوز الحد**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه. 

{{% /alert %}}

## **لف النص**

إذا كنت تريد أن يتم لف النص داخل شكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **لف النص داخل الشكل**. لتحديد هذا الإعداد، عليك تعيين خاصية [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) إلى `true`. 

يوضح لك هذا الكود في C++ كيفية استخدام إعداد لف النص في عرض بوربوينت:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="ملاحظة" color="warning" %}} 

إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل، عندما يصبح النص داخل الشكل أطول من عرض الشكل، سيتم تمديد النص إلى ما وراء حدود الشكل على سطر واحد. 

{{% /alert %}}
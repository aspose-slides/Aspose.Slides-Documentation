---
title: تعزيز عروضك التقديمية باستخدام AutoFit في C++
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/cpp/manage-autofit-settings/
keywords:
- مربع نص
- AutoFit
- عدم AutoFit
- ملائمة النص
- تقليص النص
- تغليف النص
- تحجيم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية إدارة إعدادات AutoFit في Aspose.Slides لـ C++ لتحسين عرض النص في عروض PowerPoint و OpenDocument وتحسين قابلية قراءة المحتوى."
---

افتراضيًا، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص — يقوم تلقائيًا بتغيير حجم مربع النص لضمان ملاءمة النص دائمًا داخلها.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص — يزيد ارتفاعه — للسماح باستيعاب نص أكبر. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص — يقلل ارتفاعه — لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي المعلمات أو الخيارات الأربعة المهمة التي تتحكم في سلوك الـ Autofit لمربع النص:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides لـ C++ خيارات مماثلة — بعض الطرق تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) — التي تتيح لك التحكم في سلوك الـ autofit لمربعات النص في العروض التقديمية. 

## **تحجيم الشكل لتناسب النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا مع الصندوق بعد إجراء تغييرات على النص، يجب عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يظهر لك هذا الكود C++ كيفية تحديد أن النص يجب أن يتناسب دائمًا مع الصندوق الخاص به في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن يتناسب جميع النصوص داخله. إذا صار النص أقصر، يحدث العكس. 

## **عدم الملاءمة التلقائية**

إذا أردت أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تُجرى على النص الموجود فيه، يجب عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) إلى `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يظهر لك هذا الكود C++ كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص أطول من الصندوق، يتسرب خارجًا. 

## **تقليص النص عند الفائض**

إذا أصبح النص أطول من الصندوق، يمكنك من خلال خيار **Shrink text on overflow** تحديد أنه يجب تقليل حجم النص والمسافات لجعله يتناسب مع الصندوق. لتحديد هذا الإعداد، قم بتعيين الخاصية [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يظهر لك هذا الكود C++ كيفية تحديد أن النص يجب أن يُصغَر عند الفائض في عرض PowerPoint:
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
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من الصندوق.
{{% /alert %}}

## **تغليف النص**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معامل **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين الخاصية [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) إلى `true`.

يظهر لك هذا الكود C++ كيفية استخدام إعداد تغليف النص في عرض PowerPoint:
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
إذا قمت بتعيين الخاصية `WrapText` إلى `False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارجه على خط واحد.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. الهوامش الداخلية (Padding) تقلل مساحة النص القابلة للاستخدام، لذا سيتدخل AutoFit مبكرًا — إما بتقليل حجم الخط أو تعديل حجم الشكل أسرع. تحقق من الهوامش وقم بضبطها قبل تعديل AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية والفواصل الناعمة؟**

تبقى الفواصل القسرية في مكانها، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من حاجة AutoFit لتقليص النص بشكل مفرط.

**هل يؤثر تغيير خط السمة أو تشغيل استبدال الخط على نتائج AutoFit؟**

نعم. استبدال الخط بخط له مقاييس مختلفة يغيّر عرض/ارتفاع النص، ما قد يغيّر الحجم النهائي للخط وتغليف السطور. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.
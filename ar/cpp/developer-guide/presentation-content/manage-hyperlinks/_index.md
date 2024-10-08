---
title: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/cpp/manage-hyperlinks/
keywords: "تشعب PowerPoint، رابط نص، رابط شريحة، رابط شكل، رابط صورة، رابط فيديو، C++"
description: "كيفية إضافة رابط تشعبي إلى عرض PowerPoint في C++"
---

الرابط التشعبي هو مرجع إلى كائن أو بيانات أو مكان في شيء ما. هذه هي الروابط التشعبية الشائعة في عروض PowerPoint:

* روابط لمواقع الإنترنت داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تسمح لك Aspose.Slides لـ C++ بتنفيذ العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على محرر PowerPoint البسيط، [المجاني عبر الإنترنت.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النصوص**

هذا الكود C++ يوضح لك كيفية إضافة رابط لموقع إلكتروني إلى نص:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: واجهات برمجة تطبيقات تنسيق الملفات");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **إضافة روابط URL إلى الأشكال أو الإطارات**

هذا الكود النموذجي في C++ يوضح لك كيفية إضافة رابط لموقع إلكتروني إلى شكل:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **إضافة روابط URL إلى الوسائط**

تسمح لك Aspose.Slides بإضافة روابط إلى الصور والصوت وملفات الفيديو.

هذا الكود النموذجي يوضح لك كيفية إضافة رابط إلى **صورة**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// يضيف صورة إلى العرض
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// ينشئ إطار صورة على الشريحة 1 بناءً على الصورة المضافة سابقًا
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

هذا الكود النموذجي يوضح لك كيفية إضافة رابط إلى **ملف صوتي**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

هذا الكود النموذجي يوضح لك كيفية إضافة رابط إلى **فيديو**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في رؤية *[إدارة OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*.

{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول المحتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

هذا الكود النموذجي يوضح لك كيفية إنشاء جدول محتويات مع الروابط التشعبية:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"عنوان الشريحة 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"الصفحة 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **تنسيق الروابط التشعبية**

### **اللون**

مع الطرق [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) و[get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) في واجهة [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink)، يمكنك تعيين اللون للروابط التشعبية والحصول أيضًا على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا لا تنطبق التغييرات المتعلقة بالخاصية على إصدارات PowerPoint الأقدم.

هذا الكود النموذجي يوضح عملية حيث تتم إضافة روابط تشعبية بألوان مختلفة إلى نفس الشريحة:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"هذا هو مثال لرابط تشعبي ملون.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"هذا هو مثال لرابط تشعبي عادي.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **إزالة الروابط التشعبية في العروض التقديمية**

### **إزالة الروابط التشعبية من النصوص**

هذا الكود C++ يظهر لك كيفية إزالة الرابط التشعبي من نص في شريحة عرض تقديمي:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

هذا الكود C++ يظهر لك كيفية إزالة الرابط التشعبي من شكل في شريحة عرض تقديمي: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **الرابط التشعبي القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) قابلة للتعديل. مع هذه الفئة، يمكنك تغيير القيم لهذه الطرق:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

الشفرة توضح لك كيفية إضافة رابط تشعبي إلى الشريحة وتحرير تلميحه لاحقًا:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: واجهات برمجة تطبيقات تنسيق الملفات");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة تطبيقات Aspose");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **طرق المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي، شريحة، أو نص تم تعريف الرابط التشعبي له.

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

تدعم فئة IHyperlinkQueries هذه الطرق:

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)
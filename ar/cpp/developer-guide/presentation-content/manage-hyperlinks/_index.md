---
title: إدارة روابط العروض التقديمية في C++
linktitle: إدارة الارتباط التشعبي
type: docs
weight: 20
url: /ar/cpp/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي في النص
- ارتباط تشعبي في الشريحة
- ارتباط تشعبي في الشكل
- ارتباط تشعبي في الصورة
- ارتباط تشعبي في الفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "قم بإدارة الروابط التشعبية بسهولة في عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides لـ C++ — حسّن التفاعل وسير العمل في دقائق."
---

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان ما. هذه أمثلة على الارتباطات التشعبية الشائعة في عروض PowerPoint التقديمية:

* روابط إلى مواقع ويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for C++ يتيح لك تنفيذ مهام عديدة تتعلق بالارتباطات التشعبية في العروض التقديمية. 

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose بسيط، [محرر PowerPoint المجاني على الإنترنت.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **إضافة ارتباطات URL**

### **إضافة ارتباطات URL إلى النص**

يُظهر لك هذا الكود C++ كيفية إضافة ارتباط موقع ويب إلى نص:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


### **إضافة ارتباطات URL إلى الأشكال أو الأطر**

يُظهر لك هذا المثال المكتوب بلغة C++ كيفية إضافة ارتباط موقع ويب إلى شكل:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


### **إضافة ارتباطات URL إلى الوسائط**

Aspose.Slides يتيح لك إضافة ارتباطات تشعبية إلى الصور والملفات الصوتية وملفات الفيديو. 

يُظهر لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **صورة**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// يضيف صورة إلى العرض التقديمي
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// ينشئ إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


يُظهر لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


يُظهر لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **فيديو**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


{{% alert title="Tip" color="primary" %}} 
قد ترغب في الاطلاع على *[إدارة OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*.
{{% /alert %}}

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

نظرًا لأن الارتباطات التشعبية تسمح لك بإضافة إشارات إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات. 

يُظهر لك هذا المثال كيفية إنشاء جدول محتويات يحتوي على روابط تشعبية:
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
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **تنسيق الارتباطات التشعبية**

### **اللون**

باستخدام طريقتي [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) و [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) في واجهة [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink)، يمكنك تعيين اللون للارتباطات التشعبية وكذلك الحصول على معلومات اللون منها. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

يُظهر لك هذا المثال طريقة إضافة ارتباطات تشعبية بألوان مختلفة إلى نفس الشريحة:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **إزالة الارتباطات التشعبية من العروض التقديمية**

### **إزالة الارتباطات التشعبية من النص**

يُظهر لك هذا الكود C++ كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:
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


### **إزالة الارتباطات التشعبية من الأشكال أو الأطر**

يُظهر لك هذا الكود C++ كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي:
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


## **الارتباط التشعبي القابل للتغيير**

فئة [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) قابلة للتغيير. باستخدام هذه الفئة، يمكنك تعديل القيم للطرق التالية:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

يُظهر لك هذا المقتطف كيفية إضافة ارتباط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


## **الطرق المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص معرف فيه الارتباط التشعبي. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

تدعم فئة IHyperlinkQueries الطرق التالية:

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى في القسم؟**  
الأقسام في PowerPoint هي مجموعات من الشرائح؛ التقنية تستهدف شريحة محددة. للتنقل إلى قسم، عادةً ما تقوم بربط إلى الشريحة الأولى فيه.

**هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟**  
نعم. تدعم عناصر الشريحة الرئيسة وتنسيقها الارتباطات التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء العرض.

**هل سيتم حفظ الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو الصور أو الفيديو؟**  
في [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، نعم—تُحافظ الروابط عادةً. عند التصدير إلى [الصور](/slides/ar/cpp/convert-powerpoint-to-png/) و [الفيديو](/slides/ar/cpp/convert-powerpoint-to-video/)، لن يتم نقل قابلية النقر بسبب طبيعة هذه الصيغ (الإطارات النقطية/الفيديو لا تدعم الارتباطات التشعبية).
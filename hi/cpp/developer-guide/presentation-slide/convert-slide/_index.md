---
title: स्लाइड्स को C++ में इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/cpp/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ C++ में PPT, PPTX, और ODP प्रस्तुतियों की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मैट्स में बदलें।"
---
## **परिचय**

Aspose.Slides for C++ PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को PNG, JPEG, GIF, TIFF और अन्य इमेज फ़ॉर्मैट्स में रेंडर कर सकता है।

एक स्लाइड को इमेज में बदलने के लिए, निम्न चरणों का पालन करें:

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास से लोड करें।
2. उस स्लाइड को चुनें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।
4. [ISlide::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) मेथड को कॉल करें और [ImageFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/) वैल्यू के साथ आउटपुट फ़ॉर्मेट निर्दिष्ट करें।

## **स्लाइड को PNG इमेज में बदलें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामी [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सहेजा जा सकता है।

निम्नलिखित C++ उदाहरण पहली स्लाइड को रेंडर करता है और उसे PNG इमेज के रूप में सहेजता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में बदलें**

एक स्लाइड को सटीक पिक्सेल डाइमेंशन के साथ रेंडर करने के लिए वह [ISlide::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) ओवरलोड उपयोग करें जो एक [Size](https://reference.aspose.com/slides/hi/cpp/system.drawing/size/) वैल्यू स्वीकार करता है।

निम्न उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **नोट्स और कमेंट्स के साथ स्लाइड्स को इमेज में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड इमेज में नोट्स या कमेंट्स शामिल नहीं होते। नोट्स और कमेंट्स की स्थिति नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) मेथड में असाइन करें।

निम्न उदाहरण ट्रंकेटेड नोट्स को स्लाइड के नीचे और कमेंट्स को उसकी दाईं ओर रखता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-से-इमेज रूपांतरण के लिए, [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) मेथड को [BottomFull](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notespositions/) पर सेट न करें। नोट्स में ऐसा टेक्स्ट हो सकता है जो निर्धारित इमेज आकार में फिट नहीं होता। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास आपको रेंडर की गई TIFF इमेज का आकार, रिज़ॉल्यूशन और अन्य गुण नियंत्रित करने की सुविधा देता है।

निम्न उदाहरण पहली स्लाइड को 2160 × 2880 TIFF इमेज, 300 DPI पर रेंडर करता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **सभी स्लाइड्स को इमेज में बदलें**

पूरा प्रेजेंटेशन कई इमेजेज़ में बदलने के लिए स्लाइड कलेक्शन पर इटररेट करें। छिपी हुई स्लाइड्स को भी शामिल किया जाता है जब तक आप उन्हें स्पष्ट रूप से स्किप न करें।

निम्न उदाहरण प्रत्येक स्लाइड को हॉरिज़ॉन्टल और वर्टिकल स्केल फ़ैक्टर 2 के साथ JPEG इमेज के रूप में रेंडर करता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Enhanced Metafile आउटपुट बनाएं**

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर-आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows एप्लिकेशन जो Windows मेटाफाइल्स का समर्थन करते हैं, के साथ एक्सचेंज करना हो। पिक्सेल-आधारित इमेज के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बरकरार रख सकता है जो स्केल होने पर भी शार्पनेस नहीं खोते। हालांकि, EMF मुख्यतः उन एप्लिकेशनों के लिए एक संगतता फ़ॉर्मेट है जो Windows मेटाफाइल समर्थन रखते हैं, न कि एक सार्वभौमिक इंटरचेंज फ़ॉर्मेट। अतिरिक्त रूप से, जटिल स्लाइड सामग्री, जैसे बिटमैप इमेजेज़ और कुछ इफ़ेक्ट्स, वेक्टर मेटाफाइल कंटेनर के भीतर रैस्टराइज़्ड तत्वों के रूप में संग्रहीत हो सकते हैं।

### **स्लाइड को EMF में एक्सपोर्ट करें**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/writeasemf/) मेथड एक [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) को EMF फ़ॉर्मेट में टार्गेट स्ट्रीम पर लिखता है। निम्न उदाहरण एक प्रेजेंटेशन लोड करता है, पहली स्लाइड चुनता है, और उसे EMF फ़ाइल स्ट्रीम में लिखता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

स्ट्रीमर को कॉलर द्वारा पास किया गया स्ट्रीम वह नियंत्रित करता है और उसे बंद या डिस्पोज़ करना आवश्यक है। Aspose.Slides स्ट्रीम की वर्तमान पोजिशन पर लिखता है और स्ट्रीम को खुला छोड़ देता है।

### **SVG इमेज को EMF में बदलें और प्रेजेंटेशन में जोड़ें**

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/writeasemf/) का उपयोग करके SVG कंटेंट को EMF में कन्वर्ट करें। परिणामस्वरूप बाइट्स को [IImageCollection::AddImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimagecollection/addimage/) द्वारा प्रेजेंटेशन में जोड़ा जा सकता है और [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addpictureframe/) से स्लाइड पर रखा जा सकता है।

निम्न उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/svgimage/) बनाता है, उसे इन-मेमाॅरी EMF में बदलता है, प्रथम स्लाइड पर मेटाफाइल इन्सर्ट करता है, और प्रेजेंटेशन को सेव करता है:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/writeasemf/) गंतव्य स्ट्रीम का ओनरशिप नहीं लेता। लिखने के बाद, स्ट्रीम की पोज़िशन जनरेटेड डेटा के अंत में रहती है। उदाहरण [MemoryStream::ToArray](https://reference.aspose.com/slides/hi/cpp/system.io/memorystream/toarray/) को कॉल करके पूर्ण बफ़र प्राप्त करता है, चाहे वर्तमान स्ट्रीम पोज़िशन कुछ भी हो, फिर उस बाइट एरे को [IImageCollection::AddImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimagecollection/addimage/) को पास करता है। स्ट्रीम को तब तक खुला रखें जब तक उपभोक्ता इसे पढ़ रहा हो, और बाद में बंद करें।

EMF जेनरेशन Aspose.Slides for C++ द्वारा समर्थित ऑपरेटिंग सिस्टम पर उपलब्ध है, लेकिन फोंट या नेटिव ग्राफिक्स डिपेंडेंसीज़ की अनुपलब्धता पर विभिन्न प्लेटफ़ॉर्म पर रेंडरिंग में अंतर हो सकता है। स्रोत कंटेंट द्वारा उपयोग किए गए फोंट इंस्टॉल करें या उपयुक्त प्रतिस्थापन कॉन्फ़िगर करें, Aspose.Slides for C++ के [platform requirements](/slides/hi/cpp/system-requirements/) का पालन करें, और लक्ष्य EMF-उपयोगी एप्लिकेशन में परिणाम की पुष्टि करें। Linux और macOS एप्लिकेशन्स अक्सर Windows मेटाफाइल्स को दर्शाने और संपादित करने में सीमित या असंगत समर्थन रखते हैं।

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेजेंटेशन स्लाइड्स को इमेज में बदलते समय कलर इमोजी को सही ढंग से रेंडर करने के लिए प्रेजेंटेशन में उपयोग किए गए इमोजी फ़ॉन्ट को उस सिस्टम पर इंस्टॉल और उपलब्ध होना चाहिए जहाँ परिवर्तन किया जा रहा है। उदाहरण के लिए, यदि प्रेजेंटेशन **Segoe UI Emoji** फ़ॉन्ट का उपयोग करता है और वह फ़ॉन्ट उपलब्ध नहीं है, तो इमोजी आउटपुट इमेज में मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनिमेशन वाली स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं। [ISlide::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड स्लाइड की स्टैटिक इमेज रेंडर करता है और एनिमेशन को एक्सपोर्ट नहीं करता।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में एक्सपोर्ट किया जा सकता है?**

हां। छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह रेंडर किया जा सकता है। उन्हें प्रोसेसिंग लूप में शामिल करें, जैसा कि ऊपर के उदाहरण में दिखाया गया है।

**क्या स्लाइड इमेज में शैडोज़ और अन्य इफ़ेक्ट्स संरक्षित रहते हैं?**

हां। Aspose.Slides स्लाइड इमेज में शैडोज़, ट्रांसपैरेंसी और अन्य समर्थित ग्राफ़िकल इफ़ेक्ट्स को रेंडर करता है।
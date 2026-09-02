---
title: C++ में लो‑कोड प्रस्तुति संचालन
linktitle: लो‑कोड API
type: docs
weight: 50
url: /hi/cpp/low-code-presentation-operations/
keywords:
- लो‑कोड प्रस्तुति API
- प्रस्तुति रूपांतरण
- प्रस्तुतियों का मर्ज
- स्लाइड्स पर पुनरावृति
- आकारों पर पुनरावृति
- टेक्स्ट पर पुनरावृति
- आकार एकत्रित करें
- प्रस्तुति संपीड़न
- अप्रयुक्त मास्टर स्लाइड्स हटाएँ
- अप्रयुक्त लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़न
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में Aspose.Slides लो‑कोड API का उपयोग करके प्रस्तुतियों को रूपांतरित और मर्ज करें, सामग्री पर पुनरावृति करें, आकार एकत्रित करें, और प्रस्तुति का आकार घटाएँ।"
---
## **सारांश**

[ Aspose::Slides::LowCode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/) नेमस्पेस सामान्य प्रस्तुति संचालन के लिए स्थैतिक सहायक वर्ग प्रदान करता है। ये सहायक अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लो को केंद्रित विधियों में समेटते हैं, जिससे आप फ़ाइलें रूपांतरित या मिलाने, प्रस्तुति तत्वों को प्रोसेस करने, आकारों को एकत्रित करने और कम कोड के साथ अप्रयुक्त सामग्री हटाने जैसे कार्य कर सकते हैं।

जब ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है, तब लो‑कोड सहायक सबसे उपयोगी होते हैं। व्यक्तिगत स्लाइड, मास्टर, लेआउट, आकार, निर्यात सेटिंग या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण की आवश्यकता होने पर पूर्ण [Aspose.Slides ऑब्जेक्ट मॉडल](https://reference.aspose.com/slides/hi/cpp/aspose.slides/) का उपयोग करें।

निम्न तालिका उपलब्ध सहायक वर्गों का सार प्रस्तुत करती है:

| सहायक | किस लिए उपयोग करें |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ प्रस्तुति को अन्य प्रारूप में रूपांतरित करना। |
| [Merger](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/) | समान स्वरूप की पूरी प्रस्तुति फ़ाइलों को संयोजित करना। |
| [ForEach](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/) | प्रत्येक स्लाइड, आकार, पैराग्राफ या टेक्स्ट भाग के लिए क्रिया चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/) | संपूर्ण प्रस्तुति से आकारों को प्राप्त करना ताकि उन्हें बार‑बार प्रक्रिया या विश्लेषण किया जा सके। |
| [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) | अप्रयुक्त मास्टर और लेआउट हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **एक प्रस्तुति को रूपांतरित करें**

जब आउटपुट फ़ाइल एक्सटेंशन निर्यात फ़ॉर्मेट चुनने के लिए पर्याप्त हो, तो [Convert::AutoByExtension](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/autobyextension/) का उपयोग करें। यह विधि स्रोत प्रस्तुति खोलती है, आउटपुट पथ से आवश्यक फ़ॉर्मेट निर्धारित करती है, और परिणाम को लिखती है।

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/) वर्ग PDF, SVG, JPEG, PNG और TIFF आउटपुट के लिए समर्पित विधियाँ भी प्रदान करता है। यदि निर्यात से पहले प्रस्तुति की जाँच या संशोधन करने या ऐसी निर्यात विकल्प कॉन्फ़िगर करने की आवश्यकता है जो चयनित सहायक द्वारा उपलब्ध नहीं है, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। फ़ॉर्मेट‑विशिष्ट वर्कफ़्लो और विकल्पों के लिए देखें [Convert Presentation](/slides/hi/cpp/convert-presentation/)।

## **प्रस्तुतियों को मिलाएं**

एक कॉल में पूरी प्रस्तुति फ़ाइलों को संयोजित करने के लिए [Merger::Process](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/process/) का उपयोग करें। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

जब सभी स्लाइडों को एक परिणाम में जोड़ना हो और उन्हें व्यक्तिगत रूप से चुनने या पुनः मैप करने की आवश्यकता न हो, तब यह सहायक उपयुक्त है। चयनित स्लाइडों को मिलाने, गंतव्य मास्टर या लेआउट लागू करने, अनुभागों को स्पष्ट रूप से संरक्षित करने या विभिन्न स्लाइड आकारों को मिलाने की आवश्यकता होने पर पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। उन परिदृश्यों के लिए देखें [Merge Presentations](/slides/hi/cpp/merge-presentation/)।

## **प्रस्तुति तत्वों पर पुनरावृत्ति करें**

[ForEach](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/) वर्ग अनुरोधित प्रस्तुति तत्व प्रकार के प्रत्येक इंस्टेंस के लिए एक कॉलबैक को बुलाता है। यह नेस्टेड कलेक्शन लूप को समाप्त करता है और प्रस्तुति‑व्यापी निरीक्षण या फ़ॉर्मेटिंग परिवर्तन के लिए सुविधाजनक है।

निम्न उदाहरण में [ForEach::Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/paragraph/) और [ForEach::Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/portion/) का उपयोग करके संबंधित तत्वों का निरीक्षण किया गया है:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

डिफ़ॉल्ट रूप से प्रस्तुति‑व्यापी आकार और टेक्स्ट ट्रैवर्सल सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करता है। `includeNotes` पैरामीटर वाले ओवरलोड नोट स्लाइड्स को भी प्रोसेस कर सकते हैं। यदि ट्रैवर्सल क्रम, शीघ्र समाप्ति, कॉलबैक बुलाने से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे कलेक्शन लूप का उपयोग करें।

## **आकारों को एकत्रित करें**

जब आप एक प्रस्तुति में सभी आकारों का संग्रह चाहते हैं बजाय प्रत्येक आकार के लिए कॉलबैक के, तो [Collect::Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/shapes/) का उपयोग करें। यह तब उपयोगी होता है जब एक ही सेट को कई बार फ़िल्टर, गिनना या प्रोसेस करना हो।

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

यदि प्रत्येक आकार को तुरंत संभाला जा सकता है और आप एकत्रित परिणाम को बरकरार रखने की आवश्यकता नहीं रखते, तो इसके बजाय [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/) का उपयोग करें।

## **प्रस्तुति सामग्री को संकुचित करें**

[Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) वर्ग अप्रयुक्त संरचनात्मक तत्वों को हटाकर और एम्बेडेड फ़ॉन्ट डेटा को कम करके फ़ाइल आकार घटा सकता है:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) उन लेआउट स्लाइड्स को हटाता है जिनका कोई सामान्य स्लाइड संदर्भ नहीं है।
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) एम्बेडेड फ़ॉन्ट्स से अप्रयुक्त अक्षरों को हटाता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

पहले अप्रयुक्त लेआउट हटाएँ, फिर अप्रयुक्त मास्टर, क्योंकि लेआउट सफ़ाई के बाद अभिग्रहित न रहने वाले मास्टर को भी हटाया जा सकता है। यदि बाद में मूल मास्टर, लेआउट या पूर्ण एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता हो, तो अनुकूलित प्रस्तुति को नई फ़ाइल में सहेजें। अधिक विवरण के लिए देखें [Slide Master](/slides/hi/cpp/slide-master/) और [Embedded Font](/slides/hi/cpp/embedded-font/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**लो‑कोड API को पूर्ण ऑब्जेक्ट मॉडल के बजाय कब उपयोग करना चाहिए?**

जब कोई मानक ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो‑कोड सहायक उपयोग करें। यदि आपको विशिष्ट स्लाइडों का चयन, मास्टर‑लेआउट संबंधों का नियंत्रण, मध्यवर्ती स्थिति का निरीक्षण या वह व्यवहार कॉन्फ़िगर करना है जो सहायक नहीं देता, तो पूर्ण ऑब्जेक्ट मॉडल उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट की प्रस्तुतियों को मिला सकता है?**

नहीं। [Merger::Process](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/process/) को इनपुट प्रस्तुतियों का समान फ़ॉर्मेट चाहिए। पहले इनपुट फ़ाइलों को सामान्य फ़ॉर्मेट में रूपांतरित करें, उदाहरण के लिए [Convert::AutoByExtension](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/autobyextension/) से, फिर परिवर्तित फ़ाइलों को मिलाएँ।

**क्या ForEach मास्टर, लेआउट और नोट स्लाइड्स को प्रोसेस करता है?**

[ForEach::Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/slide/) सामान्य प्रस्तुति स्लाइड्स पर पुनरावृत्ति करता है। प्रस्तुति‑व्यापी [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/paragraph/) और [ForEach::Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/portion/) ऑपरेशन डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट स्लाइड्स को शामिल करने के लिए उनके ओवरलोड में `includeNotes` को `true` रखें।

**ForEach::Shape और Collect::Shapes में क्या अंतर है?**

हर आकार को तुरंत कॉलबैक के माध्यम से प्रोसेस करने के लिए [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/) का उपयोग करें। जब आपको एक संग्रहित परिणाम चाहिए जिसे बरकरार रखा, फ़िल्टर किया, गिना या कई बार पार किया जा सके, तब [Collect::Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/shapes/) उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रस्तुति में अप्रयुक्त लेआउट, अप्रयुक्त मास्टर या अप्रयुक्त अक्षरों वाले एम्बेडेड फ़ॉन्ट हैं या नहीं। यदि ये नहीं हैं, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) ऑपरेशन फ़ाइल आकार को घटा नहीं सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**

नहीं। ये सहायक लोडेड [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट पर मेमोरी में काम करते हैं। [ForEach](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/) कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) चलाने के बाद परिणाम को लिखने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को कॉल करें।

## **संबन्धित लेख**

- [Convert Presentation](/slides/hi/cpp/convert-presentation/)
- [Merge Presentations](/slides/hi/cpp/merge-presentation/)
- [Slide Master](/slides/hi/cpp/slide-master/)
- [Manage Text Box](/slides/hi/cpp/manage-textbox/)
- [Embedded Font](/slides/hi/cpp/embedded-font/)
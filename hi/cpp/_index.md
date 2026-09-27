---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /hi/cpp/
keywords:
  - दस्तावेज़ीकरण
  - प्रस्तुति प्रसंस्करण
  - प्रस्तुति रूपांतरण
  - PowerPoint
  - OpenDocument
  - C++
  - Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for C++ स्थापित करें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों के लिए मार्गदर्शिकाएँ, API संदर्भ और समर्थन देखें।"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ एक मूल C++ लाइब्रेरी है जो PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और रूपांतरित करने के लिए उपयोग होती है, बिना Microsoft PowerPoint या Office Automation के।

यह PPT, PPTX, PPS, POT और ODP को लोड और सहेजता है, जिसमें मैक्रो‑सक्षम और टेम्पलेट वेरिएंट शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और इमेजेज में एक्सपोर्ट करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरुआत</p>
<ul>
<li><a href="/slides/hi/cpp/installation/">स्थापना</a></li>
<li><a href="/slides/hi/cpp/create-presentation/">अपनी पहली प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/cpp/getting-started/">शुरु होने के लिए गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/cpp/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/cpp/evaluate-aspose-slides/">ट्रायल सीमाएं</a></li>
<li><a href="/slides/hi/cpp/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/cpp/open-presentation/">प्रेजेंटेशन खोलें</a></li>
<li><a href="/slides/hi/cpp/save-presentation/">प्रेजेंटेशन सहेजें</a></li>
<li><a href="/slides/hi/cpp/convert-powerpoint-to-pdf/">PDF में रूपांतरित करें</a></li>
<li><a href="/slides/hi/cpp/convert-slide/">स्लाइड्स को इमेजेस के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/cpp/manage-text/">टेक्स्ट और शैलियां संपादित करें</a></li>
</ul>
<p>Slides वर्कफ़्लो</p>
<ul>
<li><a href="/slides/hi/cpp/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/cpp/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/cpp/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/cpp/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/cpp/merge-presentation/">प्रेजेंटेशन मर्ज करें</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/cpp/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub पर उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hi/cpp/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/cpp/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/cpp/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/cpp/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hi/11">नि:शुल्क सहायता फोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान आधारित सहायता डेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

Windows पर, Visual Studio में एक C++ **Console App** प्रोजेक्ट बनाएं और पैकेज मैनेजर कंसोल में NuGet पैकेज स्थापित करें (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Linux पर, Linux ZIP पैकेज डाउनलोड करें और [स्थापना](/slides/hi/cpp/installation/#linux) में वर्णित CMake प्रोजेक्ट सेट अप करें।

फिर इस कोड को अपने प्रोग्राम की मुख्य स्रोत फ़ाइल के रूप में उपयोग करें। यह एक टेक्स्ट बॉक्स वाली प्रस्तुति बनाता है और उसे सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Windows पर इसे चलाने के लिए, टूलबार में **x64** प्लेटफ़ॉर्म चुनें और **Ctrl+F5** दबाएँ। Linux पर, इसे *main.cpp* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें, फिर वहाँ बनाकर चलाएँ:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

प्रोग्राम *hello.pptx* को एक स्लाइड के साथ सहेजता है जिसमें एक टेक्स्ट बॉक्स होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क रहता है — देखें [लाइसेंसिंग](/slides/hi/cpp/licensing/). अधिक तरीकों से प्रस्तुति बनाने और भरने के लिए, देखें [प्रेजेंटेशन बनाना](/slides/hi/cpp/create-presentation/).
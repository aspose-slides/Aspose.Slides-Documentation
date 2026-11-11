---
title: C++ में प्रस्तुति स्लाइड को SVG छवियों के रूप में प्रस्तुत करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रस्तुति से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में PowerPoint स्लाइड को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, पाठ, चित्र, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित छवि प्रारूप है जो वेब प्रकाशन, स्लाइड व्यूअर, एक्सेसिबिलिटी कार्यप्रवाह, और स्वचालित पोस्ट-प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for C++ प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल में निर्यात करता है और आपको नियंत्रण देता है कि पाठ, फ़ॉन्ट, चित्र, और SVG तत्व कैसे लिखे जाएँ।

जब निर्यात किया गया SVG छोटा, विभिन्न ब्राउज़रों में पूर्वानुमानित, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएँ, एक स्लाइड चुनें, और उसे स्ट्रीम में लिखें। नीचे दिया गया उदाहरण प्रस्तुति में प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल के रूप में निर्यात करता है।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) का उपयोग करता है। आप [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) के साथ एक व्यक्तिगत आकार भी निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वह आकार चाहिए।

## **SVG आउट्पुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) निर्धारित करता है कि फ्रेम का घूर्णन लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) को `true` सेट करें।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **तीर सिरों पर लाइन-एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में कोई मार्कर इनसेट सेटिंग नहीं है जो निर्धारित करे कि लाइन तीर-सिर के नीचे कहाँ समाप्त होनी चाहिए। डिफ़ॉल्ट रूप में, Aspose.Slides निर्यात की गई लाइन को छोटा करता है ताकि उसकी स्ट्रोक मार्कर के माध्यम से बाहर न निकले। [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) को `true` सेट करके स्ट्रोक को लाइन के मूल अंतिम बिंदु तक पूरी तरह से खींचा जा सकता है। यह सेटिंग केवल SVG आउट्पुट को प्रभावित करती है। स्लाइड पर लाइन अपनी स्थिति और लंबाई बनाए रखती है।

उदाहरण त्रिकोण और हीरे के तीर-सिर को 2 और 10 पॉइंट चौड़ी लाइनों पर बनाता है। यह समान स्लाइड को दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प को बदलते हुए।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

मुकाबला 10‑पॉइंट लाइन पर त्रिकोणीय तीर‑सिर दिखाता है। क्रॉपिंग सक्षम होने पर टिप तीक्ष्ण होती है। क्रॉपिंग निष्क्रिय होने पर स्ट्रोक मार्कर के झुके हुए किनारों से बाहर निकलता है और एक सपाट सिरा छोड़ देता है।

![जब क्रॉपिंग सक्षम हो तो तेज़ टिप वाला बड़ा 10‑पॉइंट त्रिकोण, और जब क्रॉपिंग निष्क्रिय हो तो सपाट सिरा](line-end-cropping.png)

उदाहरण की अन्य लाइनों में, 2‑पॉइंट त्रिकोण पर बाहर निकली स्ट्रोक कम दिखती है। भराई वाला हीरा दोनों चौड़ाइयों पर स्ट्रोक के अंत को कवर करता है।

## **पाठ और फ़ॉन्ट को नियंत्रित करें**

जब स्लाइड को SVG में निर्यात किया जाता है, तो आप नियंत्रित कर सकते हैं कि पाठ टेक्स्ट के रूप में रहे या वेक्टर ग्राफ़िक्स में बदल जाए, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। निम्न विकल्प आपको निर्यातित SVG में दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं के बीच संतुलन बनाने में मदद करते हैं।

### **सभी पाठ को वेक्टराइज़ करें**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को `true` सेट करके सभी स्लाइड पाठ को वेक्टर ग्राफ़िक्स के रूप में लिखा जाता है। यह फ़ॉन्ट निर्भरताओं को खत्म करता है और विभिन्न ब्राउज़रों में दृश्य परिणाम को अधिक सुसंगत बनाता है, लेकिन पाठ अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **बाहरी फ़ॉन्ट को कैसे संभालना है चुनें**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles`, फ़ॉन्ट डेटा को SVG में शामिल करने के लिए `Embed`, या बाहरी फ़ॉन्ट का उपयोग करने वाले पाठ को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की पुष्टि करें।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **एम्बेडेड छवि आकार घटाएँ**

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) का उपयोग करके एम्बेडेड चित्रों का रिज़ॉल्यूशन घटाएँ, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) का उपयोग करके क्रॉप किए गए स्रोत क्षेत्रों को हटाएँ, और [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) का उपयोग करके JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को कम करती हैं, लेकिन चित्र की स्पष्टता या रखी गई छवि डेटा के बलिदान पर।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को नियंत्रित करें**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) SVG निर्यात के दौरान मेटाफाइल को रास्टराइज़ करने के लिए निचली रिज़ॉल्यूशन सीमा सेट करता है। EMF या WMF छवि को रास्टराइज़ करते समय विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए इसका उपयोग करें। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता और स्लाइड पर हर वस्तु को रास्टर छवि बनने के लिए बाध्य नहीं करता।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकट अंतराल वाली तिरछी लाइनों वाली EMF छवि है। नीचे दिया गया उदाहरण [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) के माध्यम से इसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। अन्य सभी निर्यात सेटिंग्स समान रहती हैं ताकि परिणामों की तुलना की जा सके।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

आउटपुट में, EMF प्रत्येक SVG में एक एम्बेडेड PNG बन गया। नीचे दिए गए माप प्रदान किए गए प्रस्तुतीकरण के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं हैं।

| मेटाफाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे का तुलना समान एम्बेडेड रास्टर के क्षेत्र को समान बढ़े हुए प्रदर्शित आकार पर दर्शाती है। तिरछी लाइनों में 72 DPI पर स्पष्ट पिक्सेलेशन दिखता है और उच्च रिज़ॉल्यूशन पर किनारे स्मूथ होते हैं, जबकि SVG फ़ाइल का आकार बढ़ता है। मान बढ़ाने से जरूरी नहीं कि हर विवरण में सुधार हो या हर निर्यातित छवि बदल जाए।

![72, 150 और 300 DPI पर बड़ा तिरछी-लाइन विवरण](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) छवि रिज़ॉल्यूशन घटाने को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, न कि मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **शेप्स और टेक्स्ट को स्थायी IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG शेप के लिए [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) मान सेट करने के लिए [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) लागू करें। किसी भी नियंत्रक को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें।

निम्न नियंत्रक [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) का उपयोग करता है, जो शेप के जीवनकाल के लिए स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुतीकरण के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **SVG इवेंट हैंडलर्स जोड़ें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) में, निर्यातित शेप में JavaScript इवेंट हैंडलर जोड़ने के लिए [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) को एक [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) मान के साथ कॉल करें। नियंत्रक को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें और पेज या SVG दस्तावेज़ में JavaScript फ़ंक्शन परिभाषित करें जो परिणाम को होस्ट करता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

होस्ट पेज हैण्डलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, एक्सेसिबिलिटी सुधार, और अन्य इंटरैक्टिव SVG कार्यप्रवाह सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) के बजाय उपयोग करूँ?**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) का प्रयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) का प्रयोग तब करें जब केवल वही टेक्स्ट जो बाहरी फ़ॉन्ट उपयोग करता है, ग्राफ़िक्स में बदला जाना चाहिए।

**SVG को छोटा बनाने का सर्वोत्तम तरीका क्या है?**

पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए छवि क्षेत्रों को हटाएँ, और यदि लक्ष्य वातावरण फ़ॉन्ट फ़ाइलों को सर्व कर सकता है तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम छवि रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक की अलग गुणवत्ता और आकार संबंधी समझौते होते हैं।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हां। एक फ़ॉर्मेटिंग नियंत्रक के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।
---
title: C++ में प्रस्तुतिकरण स्लाइड्स को SVG इमेज के रूप में रेंडर करना
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
description: "C++ में PowerPoint स्लाइड्स को SVG इमेज के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट्स, टेक्स्ट, इमेज, आईडी और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसेबिलिटी वर्कफ़्लो और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for C++ प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में एक्सपोर्ट करता है और आपको टेक्स्ट, फ़ॉन्ट्स, चित्र और SVG तत्वों को कैसे लिखा जाए, नियंत्रित करने की सुविधा देता है।

जब निर्यात किया गया SVG कॉम्पैक्ट, विभिन्न ब्राउज़र में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिये तैयार होना चाहिए, तो [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) का उपयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएँ, एक स्लाइड चुनें, और उसे स्ट्रीम में लिखें। निम्न उदाहरण एक प्रस्तुति में प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) का उपयोग करता है। आप एकल आकार को [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) के साथ भी निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए।

## **SVG आउटपुट कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) निर्धारित करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) को `true` सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

जब स्लाइड्स को SVG में निर्यात किया जाता है, तो आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट के रूप में बना रहे या वेक्टर ग्राफ़िक्स में परिवर्तित हो, और बाहरी फ़ॉन्ट्स को कैसे शामिल या संदर्भित किया जाए। निम्न विकल्पों से आप निर्यातित SVG में दृश्य स्थिरता, टेक्स्ट चयन और फ़ॉन्ट निर्भरताओं का संतुलन बना सकते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखे जाएँ। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम ब्राउज़रों में अधिक सुसंगत रहता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

### **बाहरी फ़ॉन्ट्स को कैसे संभालें चुनें**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) बाहरी रूप से लोड किए जाने वाले फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles` चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए `Embed`, या बाहरी फ़ॉन्ट्स का उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स में बदलने के लिए `Vectorize` चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एंबेडेड इमेज आकार कम करें**

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) का उपयोग एंबेडेड चित्रों की रिज़ॉल्यूशन घटाने के लिए करें, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) का उपयोग क्रॉप किए गए स्रोत क्षेत्रों को छोड़ने के लिए, और [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) का उपयोग JPEG एन्कोडिंग क्वालिटी नियंत्रण के लिए करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज की स्पष्टता या रखे हुए डेटा की कीमत पर।

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

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) SVG निर्यात के दौरान मेटाफाइलों को रास्टराइज़ करने के लिए न्यूनतम रिज़ॉल्यूशन सीमा निर्धारित करता है। इसे EMF या WMF इमेज को रास्टराइज़ करते समय विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए उपयोग करें। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता या स्लाइड पर प्रत्येक ऑब्जेक्ट को रास्टर इमेज में बदलने के लिए बाध्य नहीं करता।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकटवर्ती विकर्ण रेखाओं वाला EMF इमेज है। निम्न उदाहरण उसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन के साथ [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) के माध्यम से निर्यात करता है। अन्य सभी निर्यात सेटिंग्स समान रहती हैं ताकि परिणामों की तुलना की जा सके।

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

| मेटाफाइल रास्टराइज़ेशन DPI | एंबेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे की तुलना एंबेडेड रास्टर के समान क्षेत्र को समान बढ़े हुए डिस्प्ले आकार पर दिखाती है। विकर्ण रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन और उच्च रिज़ॉल्यूशन पर स्मूथ किनारे दिखाती हैं, जबकि SVG फ़ाइल आकार बढ़ता है। मान बढ़ाने से हर विवरण में सुधार या प्रत्येक निर्यातित इमेज में परिवर्तन अनिवार्य नहीं है।

![72, 150, और 300 DPI पर बढ़ी हुई विकर्ण-रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) इमेज रिज़ॉल्यूशन घटाने को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) JPEG एन्कोडिंग क्वालिटी को नियंत्रित करता है, न कि मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **आकार और टेक्स्ट को स्थिर ID असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) मान सेट करने के लिए, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) लागू करें। इन दोनों में से किसी भी कंट्रोलर को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें।

निम्न कंट्रोलर [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) का उपयोग करता है, जो आकार के जीवनकाल तक स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावर्ती काउंटर। यह उत्पन्न ID को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) में, निर्यातित आकार में JavaScript इवेंट हैंडलर जोड़ने के लिए [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) को एक [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें और उस पृष्ठ या SVG दस्तावेज़ में JavaScript फ़ंक्शन परिभाषित करें जो परिणाम को होस्ट करता है।

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

होस्ट पृष्ठ हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। ID और इवेंट हैंडलर्स असाइन करने से स्लाइड व्यूअर्स, एक्सेसेबिलिटी सुधार और अन्य इंटरैक्टिव SVG वर्कफ़्लो सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) की बजाय उपयोग करूँ?**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) का उपयोग करें जब सभी टेक्स्ट को फ़ॉन्ट्स से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) का उपयोग तब करें जब केवल बाहरी फ़ॉन्ट्स का उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स में परिवर्तित किया जाना चाहिए।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एंबेडेड चित्रों को कॉम्प्रेस करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और तब लिंक्ड फ़ॉन्ट फ़ाइलें चुनें जब लक्ष्य वातावरण उन्हें प्रदान कर सके। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG क्वालिटी और वेक्टराइज़्ड टेक्स्ट प्रत्येक का गुणवत्ता और आकार में अलग संतुलन होता है।

**क्या निर्यातित SVG तत्वों को निर्यात के बाद संशोधित किया जा सकता है?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से ID असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चयनित करें।
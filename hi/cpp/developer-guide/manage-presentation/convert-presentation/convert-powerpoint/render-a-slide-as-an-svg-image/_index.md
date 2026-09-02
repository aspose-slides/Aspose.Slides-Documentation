---
title: C++ में SVG छवियों के रूप में प्रस्तुति स्लाइड्स रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG में
- प्रस्तुति को SVG में
- स्लाइड को SVG में
- PPT को SVG में
- PPTX को SVG में
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, छवियों, IDs और ईवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, अभिगम्य कार्यप्रवाह, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for C++ प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्वों के लिखे जाने के तरीके को नियंत्रित करने देता है।

जब निर्यात किया गया SVG संक्षिप्त, विभिन्न ब्राउज़रों में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं, एक स्लाइड चुनें, और इसे स्ट्रीम में लिखें। निम्न उदाहरण एक प्रस्तुति की प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide::get_SlideNumber](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/get_slidenumber/) का उपयोग करता है। आप एक व्यक्तिगत आकार को भी [IShape::WriteAsSvg](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/writeassvg/) से निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_useframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_useframerotation/) निर्धारित करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर किया जाना चाहिए, तो [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) को `true` सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम विभिन्न ब्राउज़रों में अधिक सुसंगत बनता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट को कैसे संभालें**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संकेत करने के लिए `AddLinksToFontFiles`, फ़ॉन्ट डेटा को SVG में शामिल करने के लिए `Embed`, या बाहरी फ़ॉन्ट उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंस की जाँच करें।

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

## **एम्बेडेड इमेज का आकार घटाएँ**

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_picturescompression/) का उपयोग करके एम्बेडेड चित्रों की रिज़ॉल्यूशन को घटाएँ, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) से क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और JPEG एन्कोडिंग क्वालिटी को नियंत्रित करने के लिए [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_jpegquality/) का उपयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं किंतु इमेज की फिडेलिटी या संग्रहीत इमेज डेटा की कीमत पर।

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

## **शेप्स और टेक्स्ट को स्थिर आईडी असाइन करें**

प्रत्येक SVG आकार के लिए [ISvgShape::set_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshape/set_id/) सेट करने के लिए [ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan::set_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgtspan/set_id/) मूल्य सेट करने हेतु, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) को लागू करें। इन दोनों नियंत्रकों में से किसी एक को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें।

निम्न कंट्रोलर [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) का उपयोग करता है, जो आकार के पूरे जीवनकाल के लिए स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। इससे उत्पन्न आईडी अनछुए प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनती हैं।

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshapeformattingcontroller/) में, निर्यात किए गए आकार में जावास्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshape/seteventhandler/) को एक [SvgEvent](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgevent/) मान के साथ कॉल करें। नियंत्रक को [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) के साथ असाइन करें और पेज या SVG दस्तावेज़ में जावास्क्रिप्ट फ़ंक्शन परिभाषित करें जो परिणाम को होस्ट करता है।

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

होस्ट पेज हैंडलर द्वारा संदर्भित जावास्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। आईडी और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, अभिगम्य सुधार, और अन्य इंटरैक्टिव SVG कार्यप्रवाह संभव होते हैं।

## **FAQ**

**कब मुझे [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) को [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgexternalfontshandling/) के बजाय उपयोग करना चाहिए?**

[SVGOptions::set_VectorizeText] का उपयोग करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling::Vectorize] का उपयोग करें जब केवल वह टेक्स्ट जो बाहरी फ़ॉन्ट का उपयोग करता है, ग्राफ़िक्स में परिवर्तित किया जाना चाहिए।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण उन्हें सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG क्वालिटी, और वेक्टराइज़्ड टेक्स्ट प्रत्येक की अलग गुणवत्ता और आकार ट्रेड‑ऑफ़ होते हैं।

**क्या मैं निर्यात के बाद निर्यात किए गए SVG तत्वों को संशोधित कर सकता हूँ?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से आईडी असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों का चयन करें।
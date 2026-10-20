---
title: C++ में प्रस्तुति स्लाइड्स पर आकार पुनःआकारित करें
type: docs
weight: 130
url: /hi/cpp/resizing-shapes-on-slide/
aliases:
  - /hi/cpp/re-sizing-shapes-on-slide/
keywords:
- आकार पुनःआकारित करें
- आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से आकार पुनःआकारित करें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **परिचय**

जब आप प्रस्तुति के स्लाइड आकार को बदलते हैं, तो आपको नई आयामों के अनुसार उसके आकारों को पुनःआकारित और पुनःस्थापित करना भी आवश्यक हो सकता है। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभालें।

## **आकारों को पुनःआकारित करें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को संरक्षित रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नए स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान अनुपात को उसकी ऊर्ध्वाधर निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक प्रस्तुति को लोड करता है जिसकी स्लाइड में कोई तालिका नहीं होती, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) को [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है ताकि बाद वाला लूप स्केलिंग को नियंत्रित करे। अनुपात इकाई‑रहित होते हैं; आकार की स्थितियां और आयाम पॉइंट्स में मापे जाते हैं। अलग‑अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार के आयाम बदलने से उसका फ़ॉन्ट आकार स्केल नहीं होता।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
तालिकाओं को अलग‑अलग संभालना पड़ता है: तालिका की कुल चौड़ाई और ऊँचाई निर्दिष्ट करने के बजाय उसके कॉलम की चौड़ाई और पंक्तियों की ऊँचाई को स्केल करें। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति की ऊँचाई अनुरोधित से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं को समर्थन देता है और आकारों को मास्टर और लेआउट दोनों पर, साथ ही व्यक्तिगत स्लाइड पर प्रोसेस करता है, फिर बदले हुए प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) को [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) और [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) को स्केल करके संभालता है। उसके बाद यह तालिका की स्थिति को स्केल करता है बिना उसकी कुल आयामों को अलग‑अलग स्केल किए।

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // तालिका के आयाम कॉलम की चौड़ाई और पंक्तियों की ऊँचाई द्वारा नियंत्रित होते हैं।
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// मास्टर और लेआउट पर परिभाषित आकारों को साथ ही व्यक्तिगत स्लाइड्स पर भी पुनःआकारित करें।
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड को पुनःआकारित करने के बाद आकार क्यों विकृत या कटे हुए दिखते हैं?**

यदि आप आकार स्केल किए बिना स्लाइड आकार बदलते हैं, तो आकार अपनी मूल स्थितियों और आयामों को बरकरार रखते हैं और स्लाइड से बाहर निकल सकते हैं। अलग‑अलग अनुपात से चौड़ाई और ऊँचाई स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार सीमाएँ सीधे बदलता है और उन स्लाइड के लिए है जिनमें तालिकाएँ नहीं होतीं। दूसरा उदाहरण तालिकाओं को अलग‑अलग संभालता है। परिणामस्वरूप लेआउट, विशेषकर पाठ और तालिकाएँ, की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकारों को स्केल नहीं करते और तालिका सामग्री पंक्ति की ऊँचाई को सीमित कर सकती है।

**स्लाइड को पुनःआकारित करते समय तालिकाओं का आकार कैसे बदलें?**

कॉलम की चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह पुनःआकारण मास्टर स्लाइड और लेआउट स्लाइड के लिए भी काम करेगा?**

हां। दूसरा उदाहरण [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) और प्रत्येक मास्टर की [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) के माध्यम से इटरेट करता है और उनके आकारों पर वही पुनःआकारण तर्क लागू करता है।

**क्या मैं स्लाइड की दिशा (portrait/landscape) को पुनःआकारण के साथ बदल सकता हूं?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) सेट करें, ताकि स्केल कारक अंतिम दिशा को दर्शाएँ।

**मैं कौन सा अधिकतम स्लाइड आकार सेट कर सकता हूं?**

आप [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर आस्पेक्ट अनुपात वाला आकार विकृत न हो, इसके लिए मैं क्या करूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल कारक उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा मान उपयोग करें। इससे अनुपात बना रहता है, लेकिन एक किनारे पर अप्रयुक्त स्थान रह सकता है।
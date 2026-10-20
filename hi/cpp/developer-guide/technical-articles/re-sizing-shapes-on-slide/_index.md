---
title: C++ में प्रस्तुति स्लाइड्स पर आकार बदलें
type: docs
weight: 130
url: /hi/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /hi/cpp/re-sizing-shapes-on-slide/
keywords:
  - आकार बदलें
  - आकार का आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - C++
  - Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से आकार बदलें — स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको नई मापदंडों के अनुकूल बनाने के लिए आकारों को पुनः आकार देना और उनके स्थान को पुनः निर्धारित करना पड़ सकता है। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट पर तालिकाओं को कैसे संभाला जाए।

## **आकार बदलें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार बनाए रखने के लिए, उसके क्षैतिज निर्देशांकों और चौड़ाई को नई स्लाइड चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। उसके ऊर्ध्वाधर निर्देशांकों और ऊँचाई पर समान ऊँचाई अनुपात लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसकी स्लाइड में कोई तालिका नहीं है, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) को [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है ताकि बाद वाला लूप स्केलिंग को नियंत्रित करे। अनुपात बिना इकाई के होते हैं; आकार की स्थितियाँ और आयाम बिंदुओं में मापे जाते हैं। अलग-अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार के आयाम बदलने से उसके फ़ॉन्ट आकार स्केल नहीं होते।

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

// स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
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
तालिकाओं को अलग तरीके से संभालना पड़ता है: पूरी तालिका की चौड़ाई और ऊँचाई को निर्धारित करने के बजाय उनके कॉलम की चौड़ाई और पंक्ति की ऊँचाई को स्केल करें। यदि सेल सामग्री अधिक स्थान की आवश्यकता रखती है तो पंक्तियों की ऊँचाई अनुरोधित से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट के साथ-साथ व्यक्तिगत स्लाइड पर भी प्रक्रिया करता है, फिर आकार बदली हुई प्रस्तुति सहेजता है। इसका सहायक प्रत्येक [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) को [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) और [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) को स्केल करके संभालता है। फिर वह तालिका की स्थिति को स्केल करता है, बिना उसकी कुल आयामों को अलग से स्केल किए।

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
            // तालिका के आयाम कॉलम की चौड़ाई और पंक्ति की ऊँचाई द्वारा नियंत्रित होते हैं।
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

// Resize shapes defined on masters and layouts as well as individual slides.
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

**स्लाइड का आकार बदलने के बाद आकार विकृत या कट क्यों जाते हैं?**

यदि आप स्लाइड आकार बदलते हैं बिना आकारों को स्केल किए, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड से बाहर निकल सकते हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और तालिका‑रहित स्लाइडों के लिए है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामस्वरूप लेआउट, विशेष रूप से टेक्स्ट और तालिकाओं की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और तालिका की सामग्री पंक्ति ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं का आकार कैसे बदलें?**

कॉलम की चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड और लेआउट स्लाइड के लिए भी काम करता है?**

हां। दूसरा उदाहरण [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) और प्रत्येक मास्टर की [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) के माध्यम से इटररेट करता है और उनके आकारों पर समान रिसाइज़िंग लॉजिक लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को आकार बदलते समय बदल सकता हूं?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) सेट करें, ताकि स्केल कारक अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार पर कोई सीमा है जिसे मैं सेट कर सकता हूं?**

आप [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) का उपयोग करके कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल को खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले आकारों को विकृत होने से कैसे रोकें?**

चौड़ाई और ऊँचाई के लिए समान स्केल कारक उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए चौड़ाई और ऊँचाई दोनों के लिए छोटे अनुपात का उपयोग करें। इससे अनुपात बना रहता है, लेकिन एक किनारे पर अप्रयुक्त स्थान रह सकता है।
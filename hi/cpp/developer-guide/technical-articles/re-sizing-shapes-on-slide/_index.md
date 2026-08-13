---
title: प्रेज़ेंटेशन स्लाइड्स पर शेप्स का आकार बदलें
type: docs
weight: 100
url: /hi/cpp/re-sizing-shapes-on-slide/
keywords:
- शेप का आकार बदलें
- शेप आकार बदलें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से शेप्स का आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides for C++ ग्राहकों के सबसे सामान्य प्रश्नों में से एक यह है कि शेप्स का आकार कैसे बदला जाए ताकि स्लाइड का आकार बदलने पर डेटा कटे नहीं। यह छोटा तकनीकी लेख दिखाता है कि यह कैसे किया जाए।

## **आकार बदलें शेप्स**

स्लाइड का आकार बदलने पर शेप्स के विसंगत होने से बचाने के लिए, प्रत्येक शेप की स्थिति और आयाम को अपडेट करें ताकि वे नए स्लाइड लेआउट के अनुरूप हों।

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

// प्रस्तुति फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// मूल स्लाइड आकार प्राप्त करें।
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// मौजूदा शेप्स को स्केल किए बिना स्लाइड आकार बदलें।
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// नया स्लाइड आकार प्राप्त करें।
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// प्रत्येक स्लाइड पर शेप्स को आकार बदलें और पुनः स्थित करें।
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // शेप का आकार स्केल करें।
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // शेप की स्थिति स्केल करें।
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
यदि किसी स्लाइड में तालिका है, तो ऊपर दिया गया कोड सही ढंग से काम नहीं करेगा। ऐसी स्थिति में, तालिका की प्रत्येक सेल का आकार बदलना आवश्यक है।
{{% /alert %}} 

तालिकाओं वाली स्लाइड्स को आकार बदलने के लिए अपने पक्ष में नीचे दिया गया कोड उपयोग करें। तालिकाओं के लिए, चौड़ाई या ऊँचाई सेट करना एक विशेष मामला है: तालिका के समग्र आकार को बदलने के लिए आपको व्यक्तिगत पंक्तियों की ऊँचाई और स्तम्भों की चौड़ाई समायोजित करनी होगी।

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// मूल स्लाइड आकार प्राप्त करें।
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// मौजूदा शेप्स को स्केल किए बिना स्लाइड आकार बदलें।
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// नया स्लाइड आकार प्राप्त करें।
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // शेप का आकार स्केल करें।
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // शेप की स्थिति स्केल करें।
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // शेप का आकार स्केल करें।
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // शेप की स्थिति स्केल करें।
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // शेप का आकार स्केल करें।
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // शेप की स्थिति स्केल करें।
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **सामान्य प्रश्न**

### स्लाइड का आकार बदलने के बाद शेप्स विकृत या कटे क्यों दिखते हैं?

स्लाइड का आकार बदलते समय, शेप्स अपनी मूल स्थिति और आकार बनाए रखते हैं जब तक कि स्केल स्पष्ट रूप से नहीं बदला जाता। इससे सामग्री कटे या शेप्स विसंगत हो सकते हैं।

### क्या प्रदान किया गया कोड सभी शेप प्रकारों के लिए काम करता है?

बुनियादी उदाहरण अधिकांश शेप प्रकारों (टेक्स्ट बॉक्स, छवियां, चार्ट आदि) के लिए काम करता है। हालांकि, तालिकाओं के लिए आपको पंक्तियों और स्तम्भों को अलग से संभालना होगा, क्योंकि तालिका की ऊँचाई और चौड़ाई व्यक्तिगत सेल के आयामों द्वारा निर्धारित होती है।

### स्लाइड का आकार बदलते समय तालिकाओं का आकार कैसे बदलें?

आपको तालिका की सभी पंक्तियों और स्तम्भों के माध्यम से लूप करना होगा और उनके ऊँचाई व चौड़ाई को अनुपातिक रूप से बदलना होगा, जैसा कि दूसरे कोड उदाहरण में दिखाया गया है।

### क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए भी काम करेगा?

हां, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) और [Layout slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_layoutslides/) के माध्यम से भी लूप करना चाहिए और उनकी शेप्स पर समान स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुतीकरण में निरंतरता बनी रहे।

### क्या मैं आकार बदलते समय स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) बदल सकता हूँ?

हां। आप [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/set_orientation/) का उपयोग करके अभिविन्यास बदल सकते हैं। लेआउट को बनाए रखने के लिए स्केलिंग लॉजिक को उसी अनुसार समायोजित करें।

### क्या स्लाइड आकार निर्धारित करने की कोई सीमा है?

Aspose.Slides कस्टम आकार का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों के साथ संगतता को प्रभावित कर सकते हैं।

### स्थिर अनुपात वाले शेप्स को विकृत होने से कैसे बचाया जा सकता है?

आप शेप के `get_AspectRatioLocked` मेथड को स्केल करने से पहले जांच सकते हैं। यदि यह लॉक्ड है, तो चौड़ाई या ऊँचाई को व्यक्तिगत रूप से स्केल करने के बजाय अनुपातिक रूप से समायोजित करें।
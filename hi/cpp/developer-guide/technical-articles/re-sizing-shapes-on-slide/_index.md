---
title: प्रेजेंटेशन स्लाइड्स पर शेप्स को री-साइज़ करें
type: docs
weight: 100
url: /hi/cpp/re-sizing-shapes-on-slide/
keywords:
- शेप आकार बदलें
- शेप का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से शेप्स को री-साइज़ करें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for C++ के ग्राहकों के सबसे सामान्य प्रश्नों में से एक है कि आकार बदलने पर डेटा कट न जाए, इसके लिए शेप्स को कैसे रिसाइज़ किया जाए। यह छोटा तकनीकी लेख इस प्रक्रिया को दिखाता है।

## **शेप्स का आकार बदलें**

जब स्लाइड का आकार बदलता है तो शेप्स को असंतुलित होने से रोकने के लिए, प्रत्येक शेप की स्थिति और आयामों को अपडेट करें ताकि वे नई स्लाइड लेआउट के अनुरूप हों।

```cpp
// प्रेजेंटेशन फ़ाइल लोड करें।
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

// हर स्लाइड पर शेप्स का आकार बदलें और उनका स्थान पुनः निर्धारित करें।
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

{{% alert color="primary" %}} 
यदि स्लाइड में तालिका (टेबल) शामिल है, तो ऊपर दिया गया कोड सही ढंग से काम नहीं करेगा। ऐसे में तालिका की प्रत्येक सेल को रिसाइज़ करना आवश्यक है। 
{{% /alert %}} 

अपने पक्ष पर तालिकाओं वाली स्लाइड्स का आकार बदलने के लिए नीचे दिया गया कोड उपयोग करें। तालिकाओं के लिए चौड़ाई या ऊँचाई सेट करना एक विशेष मामला है: तालिका के समग्र आकार को बदलने हेतु आपको प्रत्येक पंक्ति की ऊँचाई और प्रत्येक कॉलम की चौड़ाई को समायोजित करना होगा।

```cpp
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

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद शेप्स में विकृति या कटाव क्यों होता है?**  
जब स्लाइड का आकार बदला जाता है, तो शेप्स अपनी मूल स्थिति और आकार बनाए रखते हैं जब तक कि स्केल स्पष्ट रूप से नहीं बदला जाता। इससे सामग्री कट सकती है या शेप्स का संरेखण बिगड़ सकता है।

**क्या दिया गया कोड सभी शेप प्रकारों के लिए काम करता है?**  
बुनियादी उदाहरण अधिकांश शेप प्रकारों (टेक्स्ट बॉक्स, इमेज, चार्ट आदि) के लिए काम करता है। हालांकि, तालिकाओं के लिए आपको पंक्तियों और कॉलमों को अलग से संभालना होगा, क्योंकि तालिका की ऊँचाई और चौड़ाई व्यक्तिगत सेल्स के आयामों द्वारा निर्धारित होती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे री-साइज़ करूँ?**  
आपको तालिका की सभी पंक्तियों और कॉलमों पर लूप करना होगा और उनकी ऊँचाई व चौड़ाई को अनुपातिक रूप से बदलना होगा, जैसा कि दूसरे कोड उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिये भी काम करेगा?**  
हाँ, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) और [Layout slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_layoutslides/) के माध्यम से भी लूप करना चाहिए और उनकी शेप्स पर समान स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुति में निरंतरता बनी रहे।

**क्या मैं री-साइज़ के साथ स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) बदल सकता हूँ?**  
हाँ। आप [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/set_orientation/) का उपयोग करके अभिविन्यास बदल सकते हैं। लेआउट को बनाए रखने के लिये स्केलिंग लॉजिक को उसी अनुसार सेट करना सुनिश्चित करें।

**क्या स्लाइड के आकार पर कोई सीमा है जिसे मैं सेट कर सकता हूँ?**  
Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों की संगतता को प्रभावित कर सकते हैं।

**स्थिर आस्पेक्ट रेशियो वाले शेप्स को विकृति से कैसे बचा सकता हूँ?**  
`get_AspectRatioLocked` मेथड को स्केल करने से पहले जांचें। यदि यह लॉक है, तो व्यक्तिगत रूप से स्केल करने के बजाय चौड़ाई या ऊँचाई को अनुपातिक रूप से समायोजित करें।
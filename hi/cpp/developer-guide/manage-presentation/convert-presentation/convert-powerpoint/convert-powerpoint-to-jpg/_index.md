---
title: C++ में PPT और PPTX को JPG में परिवर्तित करें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint को परिवर्तित करें
- प्रेजेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से JPG
- प्रेजेंटेशन से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- PowerPoint को JPG के रूप में सहेजें
- प्रेजेंटेशन को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में एक्सपोर्ट करें
- PPTX को JPG में एक्सपोर्ट करें
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint (PPT, PPTX) स्लाइड्स को उच्च-गुणवत्ता वाली JPG छवियों में तेज़, विश्वसनीय कोड उदाहरणों के साथ परिवर्तित करें."
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में परिवर्तित करने से स्लाइड साझा करने, प्रदर्शन अनुकूलित करने और वेब साइटों या अनुप्रयोगों में सामग्री एम्बेड करने में मदद मिलती है। Aspose.Slides for C++ आपको PPTX, PPT और ODP फ़ाइलों को उच्च गुणवत्ता वाली JPEG छवियों में बदलने की अनुमति देता है। यह गाइड परिवर्तन की विभिन्न विधियों की व्याख्या करता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान है। यह उपयोगी हो सकता है यदि आप प्रस्तुति स्लाइड्स को कॉपी होने से बचाना चाहते हैं या केवल-निर्माण मोड में प्रस्तुति दिखाना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को छवि स्वरूपों में परिवर्तित करने की अनुमति देता है।

## **प्रस्तुति स्लाइड्स को JPG छवियों में परिवर्तित करें**

यहाँ PPT, PPTX या ODP फ़ाइल को JPG में परिवर्तित करने के चरण दिए गए हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. प्रस्तुति के स्लाइड संग्रह से [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
3. [ISlide.GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड का उपयोग करके स्लाइड की एक छवि बनाएं।
4. इमेज ऑब्जेक्ट पर [IImage.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) मेथड को कॉल करें। आउटपुट फ़ाइल नाम और इमेज फॉर्मेट को तर्कों के रूप में पास करें।

{{% alert color="primary" %}} 
**नोट:** PPT, PPTX या ODP से JPG रूपांतरण Aspose.Slides for C++ API में अन्य स्वरूपों के रूपांतरण से अलग है। अन्य स्वरूपों के लिए, आप सामान्यतः [IPresentation.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए, आपको [IImage.Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) मेथड का उपयोग करना होगा। 
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // निर्दिष्ट स्केल की स्लाइड छवि बनाएं।
    auto image = slide->GetImage(scaleX, scaleY);

    // छवि को JPEG फॉर्मेट में डिस्क पर सहेजें।
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **कस्टमाइज़्ड आयामों के साथ स्लाइड्स को JPG में परिवर्तित करें**

परिणामी JPG छवियों के आयाम बदलने के लिए, आप छवि आकार को [ISlide.GetImage(Size)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) मेथड में पास करके सेट कर सकते हैं। इससे आप विशिष्ट चौड़ाई और ऊँचाई मानों के साथ छवियाँ उत्पन्न कर सकते हैं, यह सुनिश्चित करते हुए कि आउटपुट आपकी रेज़ोल्यूशन और आस्पेक्ट रेशो आवश्यकताओं को पूरा करता है। यह लचीलापन विशेष रूप से वेब अनुपयोगों, रिपोर्टों या दस्तावेज़ीकरण के लिए छवियों को जनरेट करने में उपयोगी है, जहाँ सटीक छवि आयाम आवश्यक होते हैं।

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // निर्दिष्ट आकार की स्लाइड छवि बनाएं।
    auto image = slide->GetImage(imageSize);

    // छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **छवियों के रूप में स्लाइड्स को सहेजते समय टिप्पणी रेंडर करें**

Aspose.Slides for C++ एक सुविधा प्रदान करता है जो आपको प्रस्तुति की स्लाइड्स में टिप्पणी को JPG छवियों में बदलते समय रेंडर करने देता है। यह कार्यक्षमता विशेष रूप से PowerPoint प्रस्तुतियों में सहयोगियों द्वारा जोड़ी गई एनोटेशन, फीडबैक या चर्चाओं को संरक्षित करने में उपयोगी है। इस विकल्प को सक्षम करके, आप सुनिश्चित करते हैं कि टिप्पणियां उत्पन्न छवियों में दिखाई दें, जिससे मूल प्रस्तुति फ़ाइल खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास एक प्रस्तुति फ़ाइल "sample.pptx" है, जिसमें एक स्लाइड पर टिप्पणियां हैं:

![टिप्पणियों वाली स्लाइड](slide_with_comments.png)

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // स्लाइड टिप्पणियों के लिए विकल्प सेट करें।
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // पहली स्लाइड को छवि में परिवर्तित करें।
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

परिणाम:

![टिप्पणियों के साथ JPG छवि](image_with_comments.png)

## **संबंधित लिंक**

PPT, PPTX या ODP को छवियों में परिवर्तित करने के अन्य विकल्प देखें, जैसे:

- [PowerPoint को GIF में परिवर्तित करें](/slides/hi/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint को PNG में परिवर्तित करें](/slides/hi/cpp/convert-powerpoint-to-png/)
- [PowerPoint को TIFF में परिवर्तित करें](/slides/hi/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint को SVG में परिवर्तित करें](/slides/hi/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides PowerPoint को JPG छवियों में कैसे बदलता है, यह देखने के लिए इन मुफ्त ऑनलाइन रूपांतरणकर्ताओं को आज़माएँ: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)। 
{{% /alert %}}

![नि:शुल्क ऑनलाइन PPTX से JPG कन्वर्टर](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके आप छवियों को एक स्वरूप से दूसरे में बदल सकते हैं। अधिक जानकारी के लिए, इन पृष्ठों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/)। 

{{% /alert %}}

## **FAQ**

**क्या यह विधि बैच रूपांतरण का समर्थन करती है?**  
हाँ, Aspose.Slides एकल ऑपरेशन में कई स्लाइडों को JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स का समर्थन करता है?**  
हाँ, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, टेबल, आकार आदि शामिल हैं। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ा भिन्न हो सकती है, विशेष रूप से जब कस्टम या अनुपलब्ध फ़ॉन्ट्स का उपयोग किया जाता है।

**क्या प्रोसेस की जा सकने वाली स्लाइडों की संख्या पर कोई सीमा है?**  
Aspose.Slides स्वयं प्रोसेस की जा सकने वाली स्लाइडों की संख्या पर कोई सख्त सीमा नहीं लगाता। हालांकि, बड़ी प्रस्तुतियों या उच्च-रेज़ोल्यूशन छवियों के साथ काम करते समय आपको मेमोरी समाप्ति त्रुटि का सामना करना पड़ सकता है।
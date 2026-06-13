---
title: "आधुनिक API के साथ इमेज प्रोसेसिंग को बेहतर बनाएँ"
linktitle: "आधुनिक API"
type: docs
weight: 280
url: /hi/cpp/modern-api/
keywords:
- System.Drawing
- आधुनिक API
- ड्राइंग
- स्लाइड थंबनेल
- स्लाइड को इमेज में
- शेप थंबनेल
- शेप को इमेज में
- प्रेज़ेंटेशन थंबनेल
- प्रेज़ेंटेशन को इमेजेज़ में
- इमेज जोड़ें
- चित्र जोड़ें
- C++
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग APIs को C++ आधुनिक API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएँ, जिससे PowerPoint और OpenDocument ऑटोमेशन सहज हो।"
---
## **परिचय**

वर्तमान में, Aspose.Slides for C++ लाइब्रेरी की सार्वजनिक API में System::Drawing की निम्नलिखित क्लासेज़ पर निर्भरताएँ हैं:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/hi/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/)

संस्करण 24.4 से, यह सार्वजनिक API अप्रचलित घोषित की गई है।

System::Drawing पर निर्भरताओं से मुक्त होने के लिए, हमने “Modern API” नामक नई API जोड़ी है। [System::Drawing::Image](https://reference.aspose.com/slides/hi/cpp/system.drawing/image/) और [System::Drawing::Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/) वाले मेथड्स को अप्रचलित घोषित किया गया है और उन्हें Modern API के संबंधित मेथड्स से बदलना चाहिए। [System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) वाले मेथड्स को भी अप्रचलित घोषित किया गया है और उनका कोई प्रत्यक्ष Modern API विकल्प नहीं है।

वर्तमान संस्करणों में, System::Drawing टाइप्स पर निर्भर सार्वजनिक API को लेगेसी/अप्रचलित मानें। नए कोड के लिए Modern API का उपयोग करें तथा मौजूदा इमेज‑प्रोसेसिंग वर्कफ़्लो को माइग्रेट करते समय भी Modern API अपनाएँ।

## **Modern API**

निम्नलिखित क्लासेज़ और एन्‍युम्स को सार्वजनिक API में जोड़ा गया है:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) - रास्टर या वेक्टर इमेज को दर्शाता है।
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/) - इमेज के फ़ाइल फ़ॉर्मेट को दर्शाता है।
- [Aspose::Slides::Images](https://reference.aspose.com/slides/hi/cpp/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) इंटरफ़ेस को इंस्टैंशिएट और उपयोग करने के मेथड्स।

एकल स्लाइड या शेप को रेंडर करने के लिए `GetImage` का उपयोग करें। कई प्रेज़ेंटेशन स्लाइड्स को रेंडर करने के लिए `GetImages` का उपयोग करें। इमेज लोड करने, प्रेज़ेंटेशन में जोड़ने के लिए `AddImage` के साथ [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का प्रयोग करें, और मौजूदा प्रेज़ेंटेशन इमेज को अपडेट करने के लिए `ReplaceImage` के साथ [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का प्रयोग करें।

नया API उपयोग करने का एक सामान्य परिदृश्य इस प्रकार दिख सकता है:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// डिस्क पर फ़ाइल से IImage का एक डिस्पोजेबल इंस्टेंस बनाएं।  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// प्रेज़ेंटेशन की इमेजेज़ में IImage का एक इंस्टेंस जोड़कर PowerPoint इमेज बनाएं।
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// स्लाइड #1 पर एक चित्र आकृति जोड़ें
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// स्लाइड #1 का प्रतिनिधित्व करने वाले IImage का एक इंस्टेंस प्राप्त करें।
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// इमेज को डिस्क पर सहेजें।
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **पुराने कोड को Modern API से बदलना**

परिवर्तन को आसान बनाने के लिए, नए [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का इंटरफ़ेस [System::Drawing::Image](https://reference.aspose.com/slides/hi/cpp/system.drawing/image/) और [System::Drawing::Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/) क्लासेज़ की अलग‑अलग सिग्नेचर को दोहराता है। सामान्यतः आपको System::Drawing का उपयोग करने वाले पुराने मेथड कॉल को नए मेथड से बदलना होगा।

### **स्लाइड थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **शेप थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **प्रेज़ेंटेशन थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **प्रेज़ेंटेशन में चित्र जोड़ना**

लेगेसी/अप्रचलित API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **अप्रचलित मेथड्स/प्रॉपर्टीज़ और उनका Modern API में प्रतिस्थापन**

### **Presentation क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData क्लास**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **System::Drawing::Graphics के लिए API समर्थन**

[System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) वाले मेथड्स को अप्रचलित घोषित किया गया है और उनका कोई प्रत्यक्ष Modern API विकल्प नहीं है।

[System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) पर रेंडर करने वाले API के बजाय Modern API इमेज‑रेंडरिंग मेथड्स का उपयोग करें:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**[System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) को क्यों हटाया गया?**

[System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) के लिए समर्थन सार्वजनिक API में अप्रचलित कर दिया गया है ताकि रेंडरिंग और इमेज के साथ काम को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को हटाया जा सके, और [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) के माध्यम से क्रॉस‑प्लेटफ़ॉर्म दृष्टिकोण अपनाया जा सके। [System::Drawing::Graphics](https://reference.aspose.com/slides/hi/cpp/system.drawing/graphics/) पर रेंडर करने के बजाय `GetImage` या `GetImages` का उपयोग करें।

**[IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का [System::Drawing::Image](https://reference.aspose.com/slides/hi/cpp/system.drawing/image/) / [System::Drawing::Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/) की तुलना में व्यावहारिक लाभ क्या है?**

[IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) रास्टर और वेक्टर दोनों इमेज को एकीकृत करता है, [ImageFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/) के माध्यम से विभिन्न फ़ॉर्मेट में सहेजना सरल बनाता है, `System::Drawing` पर निर्भरता को कम करता है, और कोड को विभिन्न पर्यावरणों में अधिक पोर्टेबल बनाता है।

**क्या Modern API थंबनेल जेनरेशन के प्रदर्शन को प्रभावित करेगा?**

`GetThumbnail` से `GetImage` में स्विच करने से प्रदर्शन में गिरावट नहीं आती; नए मेथड समान क्षमताएँ प्रदान करते हैं, विकल्पों और आकारों के साथ इमेज बनाने में, तथा रेंडरिंग विकल्पों का समर्थन जारी रखते हैं। विशिष्ट लाभ या हानि परिदृश्य पर निर्भर करती है, लेकिन कार्यात्मक रूप से प्रतिस्थापन बराबर हैं।
---
title: C++ में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint बदलें
- OpenDocument बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF छवियों में आसानी से बदलना सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप पब्लिशर अक्सर अपने इमेज में लेयर्स, रंग की सटीकता, और मूल सेटिंग्स को बनाए रखने के लिए TIFF का चयन करते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF छवियों में आसानी से परिवर्तित कर सकते हैं, जिससे आपकी प्रस्तुतियां अधिकतम दृश्य सटीकता बनाए रखती हैं।

## **प्रस्तुति को TIFF में परिवर्तित करें**

प्रदान की गई [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड का उपयोग करके, आप जल्दी से पूरे PowerPoint प्रस्तुति को TIFF में बदल सकते हैं। परिणामी TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह C++ कोड दिखाता है कि PowerPoint प्रस्तुति को TIFF में कैसे बदलें:

```cpp
// Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **प्रस्तुति को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

विधि [set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास में आपको वह एल्गोरिदम निर्दिष्ट करने की अनुमति देती है जिसका उपयोग रंगीन स्लाइड या छवि को ब्लैक‑एंड‑व्हाइट TIFF में बदलते समय किया जाता है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [set_CompressionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) मेथड `CCITT4` या `CCITT3` पर सेट हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C++ कोड दिखाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे बदलें:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

परिणाम:

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रस्तुति को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाली TIFF छवि चाहिए, तो आप इच्छित मानों को [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) में उपलब्ध मेथड्स द्वारा सेट कर सकते हैं। उदाहरण के लिए, [set_ImageSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) मेथड आपको परिणामी छवि का आकार निर्धारित करने की सुविधा देता है।

यह C++ कोड दिखाता है कि PowerPoint प्रस्तुति को कस्टम आकार वाली TIFF छवियों में कैसे बदलें:

```cpp
// Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// कंप्रेशन प्रकार सेट करें।
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
संपीड़न प्रकार:
    Default - डिफ़ॉल्ट संपीड़न स्कीम (LZW) को निर्दिष्ट करता है।
    None - कोई संपीड़न नहीं निर्दिष्ट करता है।
    CCITT3
    CCITT4
    LZW
    RLE
*/

// गहराई कंप्रेशन प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

// छवि DPI सेट करें।
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// छवि आकार सेट करें।
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **कस्टम इमेज पिक्सेल फॉर्मेट के साथ प्रस्तुति को TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास से [set_PixelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) मेथड का उपयोग करके आप परिणामी TIFF छवि के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह C++ कोड दिखाता है कि PowerPoint प्रस्तुति को कस्टम पिक्सेल फॉर्मेट वाली TIFF छवि में कैसे बदलें:

```cpp
// Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
    Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
    Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
*/

// निर्दिष्ट छवि आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **FAQ**

**क्या मैं संपूर्ण PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF छवियों में बदलने की अनुमति देता है।

**प्रस्तुति को TIFF में बदलते समय स्लाइड की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइड की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड्स को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात होते हैं।
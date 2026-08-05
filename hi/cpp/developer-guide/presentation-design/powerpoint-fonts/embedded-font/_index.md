---
title: "C++ का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एंबेड करें"
linktitle: "फ़ॉन्ट एंबेडिंग"
type: docs
weight: 40
url: /hi/cpp/embedded-font/
keywords:
  - "फ़ॉन्ट जोड़ें"
  - "फ़ॉन्ट एंबेड करें"
  - "फ़ॉन्ट एंबेडिंग"
  - "एंबेडेड फ़ॉन्ट प्राप्त करें"
  - "एंबेडेड फ़ॉन्ट जोड़ें"
  - "एंबेडेड फ़ॉन्ट हटाएँ"
  - "एंबेडेड फ़ॉन्ट संकुचित करें"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रस्तुति"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एंबेड करें, सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित करते हुए।"
---
## **परिचय**

**PowerPoint** में एंबेडेड फ़ॉन्ट आपके प्रेज़ेंटेशन को किसी भी सिस्टम या डिवाइस पर खोलने पर भी उसकी इच्छित रूप‑रेखा बनाए रखने में मदद करते हैं। यह विशेष रूप से तब महत्वपूर्ण होता है जब आप ब्रांडिंग या रचनात्मक उद्देश्यों के लिए कस्टम, थर्ड‑पार्टी या गैर‑मानक फ़ॉन्ट का उपयोग करते हैं। एंबेडेड फ़ॉन्ट न होने पर टेक्स्ट का प्रतिस्थापन हो सकता है, लेआउट टूट सकता है, और अक्षर अनपढ़ चिन्ह या आयताकार के रूप में दिखाई दे सकते हैं, जिससे डिज़ाइन प्रभावित होता है।

Aspose.Slides for C++ एंबेडेड फ़ॉन्ट को प्रोग्रामेटिक रूप से प्रबंधित करने के लिए शक्तिशाली API का सेट प्रदान करता है। आप [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) और [FontData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontdata/) क्लासेज़ का उपयोग करके अपने प्रेज़ेंटेशन फ़ाइलों में एंबेडेड फ़ॉन्ट को निरीक्षण, जोड़ या हटाए जा सकते हैं। अतिरिक्त रूप से, [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास फ़ॉन्ट डेटा को संकुचित करके फ़ाइल आकार को अनुकूलित करने की अनुमति देती है, बिना गुणवत्ता या दिखावट को घटाए।

ये उपकरण आपको फ़ॉन्ट एंबेडिंग पर पूर्ण नियंत्रण देते हैं, जिससे आप प्लेटफ़ॉर्म्स के बीच समान टाइपोग्राफी बनाए रख सकते हैं और आवश्यकतानुसार फ़ाइल आकार घटा सकते हैं।

## **प्रेज़ेंटेशन से एंबेडेड फ़ॉन्ट प्राप्त करें**

Aspose.Slides for C++ `GetEmbeddedFonts` मेथड को [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास के माध्यम से प्रदान करता है, जो आपको PowerPoint प्रेज़ेंटेशन में एंबेडेड फ़ॉन्ट की सूची प्राप्त करने की अनुमति देता है। यह फ़ॉन्ट उपयोग का ऑडिट करने, ब्रांडिंग दिशानिर्देशों के अनुपालन को सुनिश्चित करने, या फ़ाइल साझा करने से पहले यह सत्यापित करने में उपयोगी है कि सभी आवश्यक फ़ॉन्ट सही ढंग से शामिल हैं।

निम्नलिखित C++ कोड प्रेज़ेंटेशन फ़ाइल से एंबेडेड फ़ॉन्ट प्राप्त करने का उदाहरण दिखाता है:

```cpp
// एक प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// सभी एंबेडेड फ़ॉन्ट प्राप्त करें।
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// एंबेडेड फ़ॉन्ट के नाम प्रिंट करें।
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **प्रेज़ेंटेशन में एंबेडेड फ़ॉन्ट जोड़ें**

Aspose.Slides for C++ आपको [AddEmbeddedFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/addembeddedfont/) मेथड का उपयोग करके PowerPoint प्रेज़ेंटेशन में फ़ॉन्ट एंबेड करने की सुविधा देता है, जिसमें दो ओवरलोड उपलब्ध हैं। आप [EmbedFontCharacters](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedfontcharacters/) एनेमरेशन का उपयोग करके एंबेड किए जाने वाले अक्षरों की मात्रा नियंत्रित कर सकते हैं — उदाहरण के लिए, केवल उपयोग किए गए अक्षर या पूरे फ़ॉन्ट सेट को एंबेड करने का चयन। यह सुविधा विशेष रूप से प्रेज़ेंटेशन को साझा या वितरित करने के लिए तैयार करने पर उपयोगी होती है, जिससे कस्टम या गैर‑मानक फ़ॉन्ट सभी सिस्टमों पर सही ढंग से दिखाई दें, भले ही वे फ़ॉन्ट इंस्टॉल न हों।

निम्नलिखित C++ कोड प्रेज़ेंटेशन में उपयोग किए गए सभी फ़ॉन्ट की जाँच करता है, और उन फ़ॉन्ट को एंबेड करता है जो अभी तक एंबेडेड नहीं हैं।

```cpp
// एक प्रस्तुतिकरण फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // जाँचें कि फ़ॉन्ट पहले से एंबेडेड है या नहीं।
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // फ़ॉन्ट को प्रस्तुतिकरण में एंबेड करें।
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// प्रस्तुतिकरण को डिस्क पर सहेजें।
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **प्रेज़ेंटेशन से एंबेडेड फ़ॉन्ट हटाएँ**

Aspose.Slides for C++ `RemoveEmbeddedFont` मेथड को [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास के माध्यम से प्रदान करता है, जिससे आप PowerPoint प्रेज़ेंटेशन में एंबेडेड विशिष्ट फ़ॉन्ट को हटाने में सक्षम होते हैं। यह कुल फ़ाइल आकार को घटाने में मदद कर सकता है, विशेषकर जब एंबेडेड फ़ॉन्ट अब उपयोग में नहीं हैं या उनकी आवश्यकता नहीं है। अनावश्यक फ़ॉन्ट हटाने से प्रदर्शन भी सुधरता है और आपका प्रेज़ेंटेशन केवल आवश्यक संसाधनों को ही शामिल करता है।

निम्नलिखित C++ कोड प्रेज़ेंटेशन से एंबेडेड फ़ॉन्ट हटाने का प्रदर्शन करता है:

```cpp
auto fontName = u"Calibri";

// एक प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// सभी एंबेडेड फ़ॉन्ट प्राप्त करें।
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // एंबेडेड फ़ॉन्ट हटाएँ।
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **एंबेडेड फ़ॉन्ट संकुचित करें**

Aspose.Slides for C++ `CompressEmbeddedFonts` मेथड को [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास के माध्यम से प्रदान करता है, जिससे आप एंबेडेड फ़ॉन्ट डेटा को अनुकूलित करके प्रेज़ेंटेशन के कुल फ़ाइल आकार को कम कर सकते हैं। यह विशेष रूप से तब उपयोगी है जब आपके प्रेज़ेंटेशन में बड़े या कई फ़ॉन्ट शामिल हों, और आप फ़ाइल को साझा करने, संग्रहित करने या ऑनलाइन उपयोग के लिए हल्का रखना चाहते हों — बिना सामग्री की दृश्य सटीकता से समझौता किए।

निम्नलिखित C++ कोड PowerPoint प्रेज़ेंटेशन में एंबेडेड फ़ॉन्ट को संकुचित करने का उदाहरण दर्शाता है:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कैसे पता चल सकता है कि प्रेज़ेंटेशन में कोई विशिष्ट फ़ॉन्ट एंबेड करने के बावजूद रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा?**  
[सब्स्टिट्यूशन जानकारी](/slides/hi/cpp/font-substitution/) को फ़ॉन्ट मैनेजर में और [फ़ॉलबैक/सब्स्टिट्यूशन नियम](/slides/hi/cpp/fallback-font/) को देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉलबैक का उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे “सिस्टम” फ़ॉन्ट को एंबेड करना सार्थक है?**  
आमतौर पर नहीं — वे लगभग हमेशा उपलब्ध होते हैं। लेकिन “पातला” पर्यावरण (Docker, फ़ॉन्ट‑प्रि‑इंस्टॉल न किए गए Linux सर्वर) में पूर्ण पोर्टेबलिटी के लिए सिस्टम फ़ॉन्ट एंबेड करने से अप्रत्याशित प्रतिस्थापन का जोखिम समाप्त हो जाता है।
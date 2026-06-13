---
title: С++ का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: फ़ॉन्ट एम्बेड करना
type: docs
weight: 40
url: /hi/cpp/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एम्बेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

PowerPoint में एम्बेडेड फ़ॉन्ट यह सुनिश्चित करते हैं कि आपका प्रस्तुतीकरण किसी भी सिस्टम या डिवाइस पर खोलने पर अपनी इच्छित रूपरेखा बरकरार रखे। यह विशेष रूप से तब महत्वपूर्ण है जब ब्रांडिंग या रचनात्मक उद्देश्यों के लिए कस्टम, थर्ड‑पार्टी, या गैर‑मानक फ़ॉन्ट का उपयोग किया जाता है। एम्बेडेड फ़ॉन्ट नहीं होने पर, टेक्स्ट बदल सकता है, लेआउट बिगड़ सकता है, और अक्षर अनपढ़ प्रतीक या आयत के रूप में दिख सकते हैं, जिससे समग्र डिज़ाइन प्रभावित होता है।

Aspose.Slides for C++ एम्बेडेड फ़ॉन्ट को प्रोग्रामेटिक रूप से प्रबंधित करने के लिए शक्तिशाली API का सेट प्रदान करता है। आप अपने प्रस्तुतीकरण फ़ाइलों में एम्बेडेड फ़ॉन्ट का निरीक्षण, जोड़ना या हटाना हेतु [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) और [FontData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontdata/) क्लासों का उपयोग कर सकते हैं। अतिरिक्त रूप से, [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास आपको फ़ॉन्ट डेटा को संपीड़ित करके फ़ाइल आकार को अनुकूलित करने की सुविधा देती है, बिना गुणवत्ता या रूपरेखा को प्रभावित किए।

ये टूल्स आपको फ़ॉन्ट एम्बेडिंग पर पूर्ण नियंत्रण देते हैं, जिससे आप प्लेटफ़ॉर्म के बीच समान टाइपोग्राफी बनाए रख सकते हैं और आवश्यकता पड़ने पर फ़ाइल आकार को घटा सकते हैं।

## **प्रेज़ेंटेशन से एम्बेडेड फ़ॉन्ट प्राप्त करें**

Aspose.Slides for C++ [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास के माध्यम से `GetEmbeddedFonts` मेथड प्रदान करता है, जो आपको PowerPoint प्रस्तुतीकरण में एम्बेडेड फ़ॉन्ट की सूची प्राप्त करने की अनुमति देता है। यह फ़ॉन्ट उपयोग का ऑडिट करने, ब्रांडिंग दिशानिर्देशों के साथ अनुपालन सुनिश्चित करने, या फ़ाइल साझा करने से पहले सभी आवश्यक फ़ॉन्ट सही ढंग से शामिल हैं या नहीं, यह सत्यापित करने में उपयोगी हो सकता है।

निम्नलिखित C++ कोड एक प्रस्तुतीकरण फ़ाइल से एम्बेडेड फ़ॉन्ट प्राप्त करने को दर्शाता है:

```cpp
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// सभी एम्बेडेड फ़ॉन्ट प्राप्त करें।
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// एम्बेडेड फ़ॉन्ट के नाम प्रिंट करें।
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **प्रेज़ेंटेशन में एम्बेडेड फ़ॉन्ट जोड़ें**

Aspose.Slides for C++ आपको [AddEmbeddedFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/addembeddedfont/) मेथड के माध्यम से PowerPoint प्रस्तुतीकरण में फ़ॉन्ट एम्बेड करने की सुविधा देता है, जिसमें दो ओवरलोड उपलब्ध हैं जिससे उपयोग में लचीलापन रहता है। आप [EmbedFontCharacters](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedfontcharacters/) एन्यूमरेशन का उपयोग करके यह नियंत्रित कर सकते हैं कि फ़ॉन्ट का कितना हिस्सा एम्बेड किया जाए — उदाहरण के लिए, केवल उपयोग किए गए अक्षर या पूरी फ़ॉन्ट सेट एम्बेड करना। यह सुविधा विशेष रूप से प्रस्तुतीकरण को साझा या वितरित करने से पहले उपयोगी है, जिससे कस्टम या गैर‑मानक फ़ॉन्ट सभी सिस्टम पर सही रूप से दिखें, चाहे वे फ़ॉन्ट स्थापित न हों।

निम्नलिखित C++ कोड सभी प्रयोग किए गए फ़ॉन्ट जाँचता है और उन फ़ॉन्ट को एम्बेड करता है जो पहले से एम्बेड नहीं हैं:

```cpp
// प्रस्तुति फ़ाइल लोड करें.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // फ़ॉन्ट पहले से एम्बेडेड है या नहीं जांचें.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // फ़ॉन्ट को प्रस्तुति में एम्बेड करें.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// प्रस्तुति को डिस्क पर सहेजें.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **प्रेज़ेंटेशन से एम्बेडेड फ़ॉन्ट हटाएँ**

Aspose.Slides for C++ [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास के माध्यम से `RemoveEmbeddedFont` मेथड प्रदान करता है, जो आपको PowerPoint प्रस्तुतीकरण में एम्बेडेड विशिष्ट फ़ॉन्ट को हटाने की अनुमति देता है। यह समग्र फ़ाइल आकार को कम करने में मदद कर सकता है, विशेष रूप से जब एम्बेडेड फ़ॉन्ट अब उपयोग में नहीं हैं या उनकी आवश्यकता नहीं है। अप्रयुक्त फ़ॉन्ट हटाने से प्रदर्शन भी सुधारता है और यह सुनिश्चित होता है कि आपका प्रस्तुतीकरण केवल आवश्यक संसाधन ही शामिल करे।

निम्नलिखित C++ कोड एक प्रस्तुतीकरण से एम्बेडेड फ़ॉन्ट हटाने को दर्शाता है:

```cpp
auto fontName = u"Calibri";

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// सभी एम्बेडेड फ़ॉन्ट प्राप्त करें.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // एम्बेडेड फ़ॉन्ट हटाएँ.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **एम्बेडेड फ़ॉन्ट संपीड़ित करें**

Aspose.Slides for C++ [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास के माध्यम से `CompressEmbeddedFonts` मेथड प्रदान करता है, जिससे आप एम्बेडेड फ़ॉन्ट डेटा को अनुकूलित करके प्रस्तुतीकरण का कुल फ़ाइल आकार घटा सकते हैं। यह विशेष रूप से तब उपयोगी है जब आपके प्रस्तुतीकरण में बड़े या कई फ़ॉन्ट शामिल हों, और आप फ़ाइल को साझा करने, संग्रहण या ऑनलाइन उपयोग के लिए हल्का रखना चाहते हैं — बिना सामग्री की दृश्य गुणवत्ता से समझौता किए।

निम्नलिखित C++ कोड PowerPoint प्रस्तुतीकरण में एम्बेडेड फ़ॉन्ट को संपीड़ित करने को दर्शाता है:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जान सकता हूँ कि प्रस्तुतीकरण में कोई विशेष फ़ॉन्ट एम्बेड करने के बावजूद रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा?**  
फ़ॉन्ट मैनेजर में [प्रतिस्थापन जानकारी](/slides/hi/cpp/font-substitution/) और [फ़ॉलबैक/प्रतिस्थापन नियम](/slides/hi/cpp/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे "सिस्टम" फ़ॉन्ट को एम्बेड करना योग्य है?**  
आमतौर पर नहीं—वे लगभग हमेशा उपलब्ध होते हैं। लेकिन "पतले" वातावरण (Docker, पूर्व स्थापित फ़ॉन्ट बिना वाला Linux सर्वर) में पूर्ण पोर्टेबिलिटी के लिए सिस्टम फ़ॉन्ट एम्बेड करने से आकस्मिक प्रतिस्थापनों का जोखिम समाप्त किया जा सकता है।
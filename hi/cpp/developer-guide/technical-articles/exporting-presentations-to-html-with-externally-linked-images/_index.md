---
title: "बाहरी लिंक वाली छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें"
type: docs
weight: 50
url: /hi/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "PowerPoint निर्यात"
- "OpenDocument निर्यात"
- "प्रस्तुति निर्यात"
- "स्लाइड निर्यात"
- "PPT निर्यात"
- "PPTX निर्यात"
- "ODP निर्यात"
- "PowerPoint से HTML"
- "OpenDocument से HTML"
- "प्रस्तुति से HTML"
- "स्लाइड से HTML"
- "PPT से HTML"
- "PPTX से HTML"
- "ODP से HTML"
- "लिंक्ड छवि"
- "बाहरी लिंक की गई छवि"
- "लिंक्ड संसाधन"
- "बाहरी संसाधन"
- "C++"
- "Aspose.Slides"
description: "C++ में Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जिसमें छवियों और अन्य संसाधनों को बाहरी लिंक वाली फ़ाइलों के रूप में सहेजा जाता है।"
---
## **अवलोकन**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्वतंत्र HTML फ़ाइल में निर्यात करता है। छवियों और अन्य संसाधनों को सीधे HTML में लिखा जाता है, आमतौर पर Base64 डेटा के रूप में। जब आपको एक पोर्टेबल फ़ाइल चाहिए होती है तो यह सुविधाजनक है, लेकिन यह हमेशा वेब साइट, CMS, या सर्वर‑साइड रूपांतरण पाइपलाइन के लिए सबसे अच्छा फ़ॉर्मेट नहीं होता।

बाहरी लिंक वाले संसाधनों का उपयोग तब करें जब आप चाहते हों:

- HTML दस्तावेज़ का आकार घटे;
- ब्राउज़र या CDN में छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो को अलग‑अलग कैश किया जा सके;
- निर्यात के बाद निर्मित संसाधनों की जाँच, प्रतिस्थापन, संपीड़न या पोस्ट‑प्रोसेसिंग की जा सके;
- आउटपुट संरचना वेब एप्लिकेशन की अपेक्षा के करीब रहे।

सामान्य HTML रूपांतरण कार्यप्रवाह के लिए, देखें [PowerPoint प्रस्तुतियों को HTML में बदलें](/slides/hi/cpp/convert-powerpoint-to-html/). यह लेख निर्यात के संसाधन‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड संसाधन निर्यात कैसे काम करता है**

[ILinkEmbedController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/) आपके एप्लिकेशन को प्रत्येक संसाधन के लिए यह तय करने देता है कि निर्यातकर्ता डेटा को HTML में एम्बेड करे या बाहरी रूप से सहेजे और लिंक लिखे।

इंटरफ़ेस में तीन विधियां हैं:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) तय करता है कि कोई संसाधन लिंक किया जाना चाहिए या एम्बेड।
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) वह URL लौटाता है जिसे निर्मित HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाएगा।
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज टार्गेट पर लिखता है।

फ़ाइल सिस्टम पाथ और ब्राउज़र URL अलग‑अलग पहलू हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलें `html-output/assets` पर डिस्क में लिखता है, जबकि HTML में सापेक्ष URLs जैसे `assets/resource-1.svg` होते हैं। ब्राउज़र उन URLs को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक मौजूद है। इसलिए, `presentation.html` से एक SVG फ़ाइल के लिंक में `assets/resource-1.svg` इस्तेमाल होता है, जबकि उस SVG फ़ाइल से उसी `assets` फ़ोल्डर में मौजूद छवि का लिंक `resource-4.jpg` होगा।

## **लिंक्ड संसाधनों के साथ HTML निर्यात**

निम्न C++ उदाहरण एक आउटपुट डायरेक्टरी बनाता है, वहाँ HTML फ़ाइल सहेजता है, और लिंक्ड संसाधनों को `assets` उप‑डायरेक्टरी में रखता है। कंट्रोलर सामान्य छवि, फ़ॉन्ट, ऑडियो, वीडियो और CSS संसाधनों को लिंक करता है जब Aspose.Slides प्रदान करता है या सुरक्षित फ़ाइल एक्सटेंशन अनुमानित कर सकता है। जो संसाधन पहचान नहीं पाए जाते वे एम्बेड रहे हैं।

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

निर्यात के बाद, आउटपुट फ़ोल्डर की संरचना इस प्रकार होगी:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर छवियों को सामान्यतः JPEG या PNG के रूप में निर्यात किया जाता है। Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए फ़ॉर्मेट से अलग कोडेक चुन सकता है यदि यह छोटा या अधिक उपयुक्त फ़ाइल बनाता है। पारदर्शिता वाली छवियों को PNG के रूप में निर्यात किया जाता है।

## **डिप्लॉयमेंट के लिए URL चयन**

नमूना सापेक्ष URL प्रीफ़िक्स `assets/` उपयोग करता है। यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड संसाधन दूसरे लिंक्ड संसाधन को संदर्भित करता है, तो नमूना `referrer` पैरामीटर को [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) में उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` की ओर संकेत करना चाहिए, न कि `assets/resource-4.jpg` की ओर।

फ़ाइलों को अन्यत्र डिप्लॉय करने पर अलग URL प्रीफ़िक्स का उपयोग करें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो तो `assets/` प्रयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो तो `../assets/` प्रयोग करें।
- जब फ़ाइलें CDN या स्थैतिक फ़ाइल सर्वर पर अपलोड की गई हों तो `https://cdn.example.com/presentations/job-123/assets/` प्रयोग करें।

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) द्वारा लौटाया गया URL उस फ़ाइल के अंतिम डिप्लॉयमेंट स्थान से मेल खाना चाहिए जो [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) द्वारा लिखी गई है। सर्वर अनुप्रयोगों में, प्रत्येक रूपांतरण कार्य के लिए एक विशिष्ट आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज प्रीफ़िक्स उपयोग करें ताकि किसी अन्य निर्यात की फ़ाइलें ओवरराइट न हों।

## **कब एम्बेड करना चाहिए**

जब आउटपुट को एकल फ़ाइल में होना आवश्यक हो—जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या ऐसा दस्तावेज़ जिसे समर्थन‑फ़ोल्डर के बिना स्थानांतरित किया जाएगा—तो एम्बेडेड Base64 HTML अभी भी उपयोगी है। लिंक्ड संसाधन अधिक उपयुक्त होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत होगा, बिल्ड पाइपलाइन द्वारा अनुकूलित किया जाएगा, या ब्राउज़र द्वारा स्वतंत्र रूप से कैश किया जाएगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल छवियों को बाहरीकरण कर सकता हूँ और अन्य संसाधनों को एम्बेड रख सकता हूँ?**

हाँ। [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) में उन कंटेंट टाइप्स के लिए `LinkEmbedDecision::Link` लौटाएँ जिन्हें आप अलग‑फ़ाइलों के रूप में सहेजना चाहते हैं, और बाकी सभी के लिए `LinkEmbedDecision::Embed` लौटाएँ।

**निर्यात की गई छवि एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों होती है?**

HTML निर्यात के दौरान Aspose.Slides आकार या ब्राउज़र संगतता सुधारने के लिए रास्टर छवियों को पुनः‑एन्कोड कर सकता है। उदाहरण के लिए, स्रोत फ़ाइल की कोई छवि परिणाम के अनुसार JPEG या PNG के रूप में लिखी जा सकती है।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URLs कार्य करेंगे?**

सापेक्ष URLs तभी काम करेंगे जब समान सापेक्ष फ़ोल्डर संरचना बरकरार रखी जाए। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में ही रहना चाहिए, जब तक आप अलग URL प्रीफ़िक्स नहीं बनाते।

**क्या सर्वर अनुप्रयोग समान आउटपुट फ़ोल्डर का पुन: उपयोग करे?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। इससे फ़ाइलनाम टकराव नहीं होते और एक निर्यात दूसरे निर्यात द्वारा उत्पन्न संसाधनों को ओवरराइट नहीं करता।
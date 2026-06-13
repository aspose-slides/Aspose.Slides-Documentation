---
title: फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करें
type: docs
weight: 70
url: /hi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- फ़ॉन्ट प्रतिस्थापन
- रेंडरिंग प्रक्रिया
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करना सीखें और PowerPoint व OpenDocument प्रस्तुतियों को सटीक रूप से प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for C++ आपको फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करने की अनुमति देता है जब आवश्यक फ़ॉन्ट रेंडरिंग के दौरान मशीन पर उपलब्ध नहीं होता है। ये कॉलबैक लापता या अनुपलब्ध फ़ॉन्ट से संबंधित समस्याओं का निदान करने में मदद करते हैं।

## **चेतावनी कॉलबैक सक्षम करें**

Aspose.Slides for C++ प्रस्तुति स्लाइड्स को रेंडर करते समय चेतावनी कॉलबैक प्राप्त करने के लिए सरल API प्रदान करता है। चेतावनी कॉलबैक को कॉन्फ़िगर करने के लिए निम्नलिखित चरणों का पालन करें:

1. एक कस्टम कॉलबैक क्लास बनाएं जो चेतावनियों को संभालने के लिए [IWarningCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides.warnings/iwarningcallback/) इंटरफ़ेस को लागू करता है।
1. RenderingOptions, PdfOptions, HtmlOptions आदि जैसी विकल्प क्लासों का उपयोग करके चेतावनी कॉलबैक सेट करें।
1. एक प्रस्तुति लोड करें जो लक्ष्य मशीन पर उपलब्ध नहीं होने वाले फ़ॉन्ट का उपयोग करती है।
1. प्रभाव देखने के लिए स्लाइड थंबनेल बनाएं या प्रस्तुति को निर्यात करें।

**कस्टम चेतावनी कॉलबैक क्लास:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// उदाहरण आउटपुट:
//
// फ़ॉन्ट XYZ से {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} में प्रतिस्थापित किया जाएगा
```

**स्लाइड थंबनेल जनरेट करें:**

```cpp
// स्लाइड रेंडरिंग के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// प्रस्तुति में प्रत्येक स्लाइड के लिए थंबनेल छवि उत्पन्न करें।
for(auto&& slide : presentation->get_Slides())
{
    // निर्दिष्ट रेंडरिंग विकल्पों का उपयोग करके स्लाइड थंबनेल छवि प्राप्त करें।
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**PDF प्रारूप में निर्यात करें:**

```cpp
// PDF निर्यात के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// प्रस्तुति को PDF के रूप में निर्यात करें।
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**HTML प्रारूप में निर्यात करें:**

```cpp
// HTML निर्यात के दौरान फ़ॉन्ट-संबंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// प्रस्तुति को HTML स्वरूप में निर्यात करें।
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```
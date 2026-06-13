---
title: "Aspose.Slides for C++ में मल्टीथ्रेडिंग"
linktitle: "मल्टीथ्रेडिंग"
type: docs
weight: 200
url: /hi/cpp/multithreading/
keywords:
- मल्टीथ्रेडिंग
- एकाधिक थ्रेड्स
- समानांतर कार्य
- स्लाइड्स को बदलें
- स्लाइड्स से छवियां
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को तेज़ करता है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वोत्तम प्रथाएँ जानें।"
---
## **परिचय**

जबकि प्रस्तुतियों के साथ समानांतर कार्य संभव है (पार्सिंग/लोडिंग/क्लोनिंग के अलावा) और अधिकांश समय सब कुछ ठीक चलता है, फिर भी कई थ्रेड्स में लाइब्रेरी का उपयोग करने पर गलत परिणाम मिलने की थोड़ी संभावना रहती है।

हम दृढ़ता से अनुशंसा करते हैं कि आप बहु-थ्रेडिंग परिवेश में एकल [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) उदाहरण का उपयोग **न** करें क्योंकि इससे अप्रत्याशित त्रुटियाँ या विफलताएँ हो सकती हैं जिन्हें आसानी से पता नहीं चल पाता।

कई थ्रेड्स में कोई [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) वर्ग का उदाहरण लोड, सहेज या क्लोन करना **सुरक्षित नहीं** है। ऐसी क्रियाओं को **समर्थित** नहीं किया जाता। यदि आपको ऐसी कार्यों को करना है, तो आपको कई एकल-थ्रेडेड प्रक्रियाओं का उपयोग करके ऑपरेशनों को समानांतर करना होगा—और इन प्रक्रियाओं में से प्रत्येक को अपना स्वयं का प्रस्तुतीकरण उदाहरण उपयोग करना चाहिए।

## **एकसाथ प्रस्तुति स्लाइड्स को छवियों में बदलना**

मान लीजिए हम सभी स्लाइड्स को एक PowerPoint प्रस्तुति से PNG छवियों में समानांतर रूप से बदलना चाहते हैं। चूँकि कई थ्रेड्स में एकल `Presentation` उदाहरण का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक प्रस्तुति को अलग थ्रेड में उपयोग करके स्लाइड्स को छवियों में समानांतर रूप से बदलते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि यह कैसे किया जाता है।

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // स्लाइड i को एक अलग प्रस्तुति में निकालें।
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // स्लाइड को एक अलग कार्य में छवि में बदलें।
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// सभी कार्यों के समाप्त होने की प्रतीक्षा करें।
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे हर थ्रेड में लाइसेंस सेटअप को कॉल करना आवश्यक है?**

नहीं। थ्रेड्स शुरू होने से पहले प्रक्रिया/ऐप डोमेन में एक बार यह करने से पर्याप्त है। यदि [license setup](/slides/hi/cpp/licensing/) को एक साथ (उदाहरण के तौर पर, लेज़ी इनिशियलाइज़ेशन के दौरान) बुलाया जा सकता है, तो उस कॉल को समन्वयित करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड-सुरक्षित नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

`"Live"` प्रस्तुति ऑब्जेक्ट्स को थ्रेड्स के बीच पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र उदाहरण उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियों/स्लाइड कंटेनर पहले से बनाएं। यह दृष्टिकोण सामान्य सिफ़ारिश का पालन करता है कि एकल प्रस्तुति उदाहरण को थ्रेड्स के बीच साझा न किया जाए।

**क्या प्रत्येक थ्रेड का अपना `Presentation` उदाहरण होने पर विभिन्न फ़ॉर्मैट्स (PDF, HTML, images) में निर्यात को समानांतर करना सुरक्षित है?**

हां। स्वतंत्र उदाहरणों और अलग आउटपुट पाथ्स के साथ, ऐसे कार्य सामान्यतः सही ढंग से समानांतर होते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**बहु-थ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर, सब्स्टिट्यूशन) के साथ क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल फ़ॉन्ट सेटिंग्स को इनिशियलाइज़ करें और समानांतर कार्य के दौरान उन्हें न बदलें। इससे साझा फ़ॉन्ट संसाधनों तक पहुंचते समय रेस की समस्या समाप्त हो जाती है।
---
title: Aspose.Slides for .NET में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 310
url: /hi/net/multithreading/
keywords:
- मल्टीथ्रेडिंग
- कई थ्रेड
- समानांतर कार्य
- स्लाइड्स परिवर्तित करें
- स्लाइड्स से छवियों में
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को तेज करता है। कुशल प्रस्तुति कार्यप्रवाह के लिए सर्वश्रेष्ठ प्रथाएँ जानें।"
---
## **परिचय**

जबकि प्रस्तुतियों के साथ समानांतर कार्य संभव है (पार्सिंग/लोडिंग/क्लोनिंग को छोड़कर) और अधिकांश समय सब ठीक चलता है, फिर भी कई थ्रेड में लाइब्रेरी का उपयोग करने पर गलत परिणाम मिलने की थोड़ी संभावना रहती है।

हम दृढ़ता से अनुशंसा करते हैं कि आप बहु-थ्रेडिंग परिवेश में एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) उदाहरण का उपयोग **न** करें क्योंकि इससे अप्रत्याशित त्रुटियाँ या विफलताएँ हो सकती हैं जिन्हें आसानी से पता नहीं चल पाता।

कई थ्रेड में [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) वर्ग का उदाहरण लोड, सहेजना और/या क्लोन करना **सुरक्षित नहीं** है। ऐसे कार्य **समर्थित** नहीं हैं। यदि आपको ऐसे कार्य करने की आवश्यकता है, तो आपको कई सिंगल-थ्रेडेड प्रक्रियाओं का उपयोग करके कार्यों को समानांतर करना होगा — और प्रत्येक प्रक्रिया को अपना स्वयं का प्रस्तुति उदाहरण उपयोग करना चाहिए।

## **समानांतर रूप में प्रस्तुति स्लाइड को छवियों में परिवर्तित करें**

मान लीजिए हम सभी स्लाइड को एक PowerPoint प्रस्तुति से PNG छवियों में समानांतर रूप में परिवर्तित करना चाहते हैं। चूँकि कई थ्रेड में एक ही `Presentation` उदाहरण का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और स्लाइड को समानांतर रूप में छवियों में बदलते हैं, प्रत्येक प्रस्तुति को अलग थ्रेड में उपयोग करते हुए। निम्नलिखित कोड उदाहरण दिखाता है कि इसे कैसे किया जाता है।

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // स्लाइड i को एक अलग प्रस्तुति में निकालें।
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // स्लाइड को एक अलग कार्य में छवि में परिवर्तित करें।
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रत्येक थ्रेड में लाइसेंस सेटअप को कॉल करना आवश्यक है?**

नहीं। थ्रेड शुरू होने से पहले प्रक्रिया/ऐप डोमेन में एक बार यह करना पर्याप्त है। यदि [लाइसेंस सेटअप](/slides/hi/net/licensing/) को समकालिक रूप से बुलाया जा सकता है (उदाहरण के लिए, आलसी प्रारम्भ के दौरान), तो उस कॉल को समक्रमित करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड-सेफ़ नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

थ्रेड्स के बीच “लाइव” प्रस्तुति ऑब्जेक्ट्स को पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र उदाहरणों का उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियों/स्लाइड कंटेनर को पूर्व-निर्मित करें। यह दृष्टिकोण सामान्य सिफ़ारिश का पालन करता है कि एक ही प्रस्तुति उदाहरण को थ्रेड्स के बीच साझा न किया जाए।

**क्या प्रत्येक थ्रेड के पास अपना `Presentation` उदाहरण होने पर विभिन्न फॉर्मेट (PDF, HTML, images) में एक्सपोर्ट को समानांतर करना सुरक्षित है?**

हां। स्वतंत्र उदाहरणों और अलग आउटपुट पाथ के साथ, ऐसे कार्य आमतौर पर सही ढंग से समानांतर होते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**बहु-थ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर, बदल) के साथ मैं क्या करूँ?**

सभी ग्लोबल फ़ॉन्ट सेटिंग्स को थ्रेड्स शुरू करने से पहले प्रारम्भ करें और समानांतर कार्य के दौरान उन्हें बदलें नहीं। इससे साझा फ़ॉन्ट संसाधनों तक पहुंच में रेस स्थितियों से बचा जा सकता है।
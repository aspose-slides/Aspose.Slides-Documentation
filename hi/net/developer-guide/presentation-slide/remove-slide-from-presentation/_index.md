---
title: .NET में प्रस्तुतियों से स्लाइड हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/net/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड मिटाएँ
- बिना उपयोग की स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड्स को आसानी से हटाएँ। स्पष्ट C# कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को बेहतर बनाएं।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप उसे हटा सकते हैं। Aspose.Slides, [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास प्रदान करता है जो [ISlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection) को संलग्न करता है, जो प्रस्तुति में सभी स्लाइड्स के लिए एक रिपॉज़िटरी है। किसी ज्ञात [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) ऑब्जेक्ट के लिए पॉइंटर (रेफ़रेंस या इंडेक्स) का उपयोग करके, आप वह स्लाइड निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं। 

## **संदर्भ द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. उस स्लाइड का रेफ़रेंस प्राप्त करें जिसे आप हटाना चाहते हैं, उसके ID या इंडेक्स के माध्यम से।
1. प्रस्तुति से संदर्भित स्लाइड को हटाएँ।
1. बदली गई प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि कैसे रेफ़रेंस के माध्यम से स्लाइड को हटाया जाए:

```c#
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // स्लाइड्स संग्रह में उसके इंडेक्स के माध्यम से एक स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];

    // स्लाइड को उसके रेफ़रेंस के माध्यम से हटाता है
    pres.Slides.Remove(slide);

    // संशोधित प्रस्तुति को सहेजता है
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **इंडेक्स द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. प्रस्तुति से स्लाइड को उसके इंडेक्स स्थिति के माध्यम से हटाएँ।
1. बदली गई प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि कैसे इंडेक्स के माध्यम से स्लाइड को हटाया जाए:

```c#
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // स्लाइड इंडेक्स के माध्यम से एक स्लाइड हटाता है
    pres.Slides.RemoveAt(0);

    // संशोधित प्रस्तुति को सहेजता है
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

Aspose.Slides, [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड ([Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) क्लास से) प्रदान करता है जिससे आप अनचाही और अप्रयुक्त लेआउट स्लाइड्स को हटा सकते हैं। यह C# कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से एक लेआउट स्लाइड को हटाया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

Aspose.Slides, [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) मेथड ([Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) क्लास से) प्रदान करता है जिससे आप अनचाही और अप्रयुक्त मास्टर स्लाइड्स को हटा सकते हैं। यह C# कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से एक मास्टर स्लाइड को हटाया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड हटाने के बाद स्लाइड इंडेक्स में क्या परिवर्तन होता है?**

हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) पुनः इंडेक्स करती है: प्रत्येक बाद वाली स्लाइड एक स्थिति बाएँ शिफ्ट हो जाती है, जिससे पिछले इंडेक्स नंबर पुरानी हो जाते हैं। यदि आपको स्थिर रेफ़रेंस चाहिए, तो प्रत्येक स्लाइड की स्थायी ID का उपयोग करें, न कि उसका इंडेक्स।

**क्या स्लाइड का ID उसके इंडेक्स से अलग है, और क्या यह पड़ोसी स्लाइड्स के हटने पर बदलता है?**

हां। इंडेक्स स्लाइड की स्थिति है और स्लाइड्स जोड़ने या हटाने पर बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइड्स के हटने पर नहीं बदलता।

**स्लाइड हटाने से स्लाइड सेक्शन्स पर क्या प्रभाव पड़ता है?**

यदि स्लाइड किसी सेक्शन का हिस्सा थी, तो वह सेक्शन केवल एक कम स्लाइड रखेगा। सेक्शन संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाता है, तो आप आवश्यकतानुसार [सेक्शन हटाएँ या पुनर्व्यवस्थित करें](/slides/hi/net/slide-section/) कर सकते हैं।

**जब एक स्लाइड हटाई जाती है, तो उस से जुड़ी नोट्स और कमेंट्स का क्या होता है?**

[Notes](/slides/hi/net/presentation-notes/) और [comments](/slides/hi/net/presentation-comments/) उस विशेष स्लाइड से जुड़ी होती हैं और स्लाइड के साथ हटाई जाती हैं। अन्य स्लाइड्स की सामग्री पर कोई असर नहीं पड़ता।

**स्लाइड हटाने और अप्रयुक्त लेआउट/मास्टर साफ़ करने में क्या अंतर है?**

डिलीट करने से डेक से विशेष सामान्य स्लाइड्स हटती हैं। अप्रयुक्त लेआउट/मास्टर को क्लीन अप करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका कोई रेफ़रेंस नहीं है, जिससे फ़ाइल आकार घटता है जबकि शेष स्लाइड सामग्री नहीं बदली जाती। ये दोनों कार्य पूरक हैं: आम तौर पर पहले डिलीट करें, फिर क्लीन अप करें।
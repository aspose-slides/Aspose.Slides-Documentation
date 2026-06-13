---
title: .NET में प्रस्तुतियों में सुपरसक्रिप्ट और सबस्क्रिप्ट का प्रबंधन करें
linktitle: सुपरसक्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/net/superscript-and-subscript/
keywords:
- सुपरसक्रिप्ट
- सबस्क्रिप्ट
- सुपरसक्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सुपरसक्रिप्ट और सबस्क्रिप्ट में निपुण बनें और पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अपनी प्रस्तुतियों को सर्वोत्तम प्रभाव के लिए ऊँचा उठाएँ।"
---
## **सारांश**

Aspose.Slides for .NET आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट एकीकृत करने की सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्रों, गणितीय समीकरणों को उजागर करना हो, या फुटनोट के साथ सामग्री को टिप्पणी करना हो, ये विशिष्ट फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में, आप सीखेंगे कि कैसे सहजता से सुपरसक्रिप्ट और सबस्क्रिप्ट शैलियों को लागू किया जाए और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित किए जाएँ।

## **सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट जोड़ें**

आप प्रस्तुति में किसी भी पैराग्राफ के अंदर सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट जोड़ सकते हैं। Aspose.Slides के साथ इसे प्राप्त करने के लिए, आपको `Escapement` प्रॉपर्टी का उपयोग करना होगा जो [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) क्लास की है।

यह प्रॉपर्टी आपको सुपरसक्रिप्ट या सबस्क्रिप्ट टेक्स्ट सेट करने की अनुमति देती है, जिसके मान -100% (सबस्क्रिप्ट) से 100% (सुपरसक्रिप्ट) तक होते हैं।

कार्यान्वयन चरण:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में `Rectangle` प्रकार का एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) से जुड़ा हुआ [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त करें।
5. मौजूदा पैराग्राफ़ साफ़ करें।
6. सुपरसक्रिप्ट टेक्स्ट के लिए एक नया [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएं और इसे [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) की पैराग्राफ़ संग्रह में जोड़ें।
7. एक नया टेक्स्ट पोर्शन ऑब्जेक्ट बनाएं।
8. `Escapement` प्रॉपर्टी को 0 से 100 के बीच सेट करें ताकि टेक्स्ट पोर्शन पर सुपरसक्रिप्ट लागू हो (0 का मतलब कोई सुपरसक्रिप्ट नहीं)।
9. [Portion](https://reference.aspose.com/slides/hi/net/aspose.slides/portion/) के लिए कुछ टेक्स्ट सेट करें और इसे पैराग्राफ़ के पोर्शन संग्रह में जोड़ें।
10. सबस्क्रिप्ट टेक्स्ट के लिए एक और [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएं और इसे पैराग्राफ़ संग्रह में जोड़ें।
11. एक नया टेक्स्ट पोर्शन ऑब्जेक्ट बनाएं।
12. `Escapement` प्रॉपर्टी को 0 से -100 के बीच सेट करें ताकि टेक्स्ट पोर्शन पर सबस्क्रिप्ट लागू हो (0 का मतलब कोई सबस्क्रिप्ट नहीं)।
13. [Portion](https://reference.aspose.com/slides/hi/net/aspose.slides/portion/) के लिए कुछ टेक्स्ट सेट करें और इसे पैराग्राफ़ के पोर्शन संग्रह में जोड़ें।
14. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C# कोड इन कदमों को लागू करता है:

```c#
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // एक टेक्स्ट बॉक्स बनाएं।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // सुपरसक्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं।
    IParagraph superPar = new Paragraph();

    // साधारण टेक्स्ट के साथ एक टेक्स्ट पोर्शन बनाएं।
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // सुपरसक्रिप्ट टेक्स्ट के साथ एक टेक्स्ट पोर्शन बनाएं।
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं।
    IParagraph paragraph2 = new Paragraph();

    // साधारण टेक्स्ट के साथ एक टेक्स्ट पोर्शन बनाएं।
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // सबस्क्रिप्ट टेक्स्ट के साथ एक टेक्स्ट पोर्शन बनाएं।
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // पैराग्राफ को टेक्स्ट बॉक्स में जोड़ें।
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![सुपरसक्रिप्ट और सबस्क्रिप्ट](superscript_and_subscript.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**PDF या अन्य फ़ॉर्मेट्स में एक्सपोर्ट करते समय सुपरसक्रिप्ट और सबस्क्रिप्ट बरकरार रखे जाएंगे?**

हाँ, Aspose.Slides for .NET पीडीएफ, PPT/PPTX, इमेजेज़ और अन्य समर्थित फ़ॉर्मेट्स में प्रेजेंटेशन एक्सपोर्ट करते समय सुपरसक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग को सही ढंग से बनाए रखता है। विशेष फ़ॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**क्या सुपरसक्रिप्ट और सबस्क्रिप्ट को बोल्ड या इटैलिक जैसे अन्य फ़ॉर्मेटिंग शैलियों के साथ मिलाया जा सकता है?**

हाँ, Aspose.Slides आपको एक ही टेक्स्ट पोर्शन में विभिन्न टेक्स्ट शैलियों को मिलाने की अनुमति देता है। आप बोल्ड, इटैलिक, अंडरलाइन को सक्षम कर सकते हैं, और साथ ही [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) में संबंधित प्रॉपर्टीज़ को कॉन्फ़िगर करके सुपरसक्रिप्ट या सबस्क्रिप्ट लागू कर सकते हैं।

**क्या टेबल, चार्ट या SmartArt के अंदर टेक्स्ट के लिए सुपरसक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग काम करती है?**

हाँ, Aspose.Slides for .NET अधिकांश ऑब्जेक्ट्स, जिसमें टेबल और चार्ट एलिमेंट्स शामिल हैं, के भीतर फ़ॉर्मेटिंग का समर्थन करता है। SmartArt के साथ काम करते समय, आपको उचित एलीमेंट्स (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartartnode/)) और उनके टेक्स्ट कंटेनर्स तक पहुँचने की आवश्यकता होती है, और फिर समान रूप से [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करें।
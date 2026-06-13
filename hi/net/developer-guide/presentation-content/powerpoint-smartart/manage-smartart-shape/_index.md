---
title: ".NET में प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें"
linktitle: "SmartArt ग्राफ़िक्स"
type: docs
weight: 20
url: /hi/net/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफ़िक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुँचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides का उपयोग करके PowerPoint SmartArt निर्माण, संपादन और शैलीकरण को स्वचालित करें, संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन प्रस्तुत करता है।"
---
## **परिचय**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रेजेंटेशन में SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि स्लाइड में SmartArt शैप कैसे जोड़ें, मौजूदा SmartArt शैप्स तक कैसे पहुँचें, एक विशिष्ट लेआउट प्रकार द्वारा SmartArt कैसे खोजें, और SmartArt शैली या रंग शैली बदलकर उसकी दृश्य उपस्थिति को कैसे अपडेट करें।

उदाहरण दर्शाते हैं कि कैसे प्रेजेंटेशन स्लाइड की shape संग्रह के माध्यम से SmartArt शैप्स के साथ काम किया जाए, यह जांचा जाए कि कोई shape SmartArt है या नहीं, और फिर उसकी प्रॉपर्टीज़ को संशोधित या निरीक्षण किया जाए।

## **SmartArt शैप बनाएं**
Aspose.Slides for .NET अब स्क्रैच से अपनी स्लाइड्स में कस्टम SmartArt शैप्स जोड़ना आसान बनाता है। Aspose.Slides for .NET ने SmartArt शैप्स बनाने के लिए सबसे सरल API प्रदान किया है। स्लाइड में SmartArt शैप बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक instance बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- LayoutType सेट करके एक SmartArt शैप जोड़ें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```c#
// प्रेजेंटेशन का इंस्टेंस बनाएं
using (Presentation pres = new Presentation())
{

    // प्रेजेंटेशन स्लाइड तक पहुँचें
    ISlide slide = pres.Slides[0];

    // Smart Art शैप जोड़ें
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // प्रेजेंटेशन सहेजें
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **स्लाइड पर SmartArt शैप तक पहुँचें**
निचे दिया गया कोड प्रेजेंटेशन स्लाइड में जोड़े गए SmartArt शैप्स तक पहुँचने के लिए उपयोग किया जाएगा। नमूना कोड में हम स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करेंगे और जांचेंगे कि वह SmartArt शैप है या नहीं। यदि shape SmartArt प्रकार की है तो हम उसे SmartArt instance में टाइपकास्ट करेंगे।

```c#
// इच्छित प्रेजेंटेशन लोड करें
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // जांचें कि shape SmartArt प्रकार की है या नहीं
        if (shape is ISmartArt)
        {
            // shape को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **विशिष्ट Layout Type वाले SmartArt शैप तक पहुँचें**
निचे दिया गया नमूना कोड विशिष्ट LayoutType वाले SmartArt शैप तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने के लिए है और केवल SmartArt शैप जोड़ते समय सेट होता है।

- `Presentation` क्लास की एक instance बनाएं और SmartArt शैप वाला प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें।
- जांचें कि shape SmartArt प्रकार का है या नहीं, और यदि है तो चयनित shape को SmartArt में टाइपकास्ट करें।
- विशिष्ट LayoutType वाले SmartArt शैप की जाँच करें और उसके बाद आवश्यक कार्य करें।

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // जांचें कि shape SmartArt प्रकार की है या नहीं
        if (shape is ISmartArt)
        {
            // shape को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt लेआउट जाँच रहे हैं
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **SmartArt शैप शैली बदलें**
निचे दिया गया नमूना कोड विशिष्ट LayoutType वाले SmartArt शैप तक पहुँचने में मदद करेगा।

- `Presentation` क्लास की एक instance बनाएं और SmartArt शैप वाला प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें।
- जांचें कि shape SmartArt प्रकार का है या नहीं, और यदि है तो चयनित shape को SmartArt में टाइपकास्ट करें।
- विशिष्ट Style वाले SmartArt शैप को खोजें।
- SmartArt शैप के लिए नई Style सेट करें।
- प्रेजेंटेशन सहेजें।

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // जांचें कि shape SmartArt प्रकार की है या नहीं
        if (shape is ISmartArt)
        {
            // shape को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt शैली की जाँच
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt शैली बदलें
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // प्रेजेंटेशन सहेजें
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **SmartArt शैप रंग शैली बदलें**
इस उदाहरण में हम किसी भी SmartArt शैप की रंग शैली कैसे बदलें सीखेंगे। निचे दिया गया नमूना कोड विशिष्ट रंग शैली वाले SmartArt शैप तक पहुँचता है और उसकी शैली बदलता है।

- `Presentation` क्लास की एक instance बनाएं और SmartArt शैप वाला प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें।
- जांचें कि shape SmartArt प्रकार का है या नहीं, और यदि है तो चयनित shape को SmartArt में टाइपकास्ट करें।
- विशिष्ट Color Style वाले SmartArt शैप को खोजें।
- SmartArt शैप के लिए नई Color Style सेट करें।
- प्रेजेंटेशन सहेजें।

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // पहली स्लाइड के भीतर प्रत्येक shape को ट्रैवर्स करें
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // जांचें कि shape SmartArt प्रकार की है या नहीं
        if (shape is ISmartArt)
        {
            // shape को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt रंग प्रकार की जाँच
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt रंग प्रकार बदलें
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // प्रेजेंटेशन सहेजें
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SmartArt को एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**

हाँ। SmartArt एक shape है, इसलिए आप अन्य shapes की तरह ही एनीमेशन API के माध्यम से [standard animations](/slides/hi/net/powerpoint-animation/) (प्रवेश, निकास, ज़ोर, मोशन पाथ) लागू कर सकते हैं।

**यदि मुझे SmartArt का internal ID नहीं पता है तो मैं स्लाइड पर विशिष्ट SmartArt कैसे खोज सकता हूँ?**

Alternative Text (AltText) सेट करके उसका उपयोग करें और उस मान से shape को खोजें—यह लक्ष्य shape को खोजने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य shapes के साथ समूहित कर सकता हूँ?**

हाँ। आप SmartArt को अन्य shapes (चित्र, तालिकाएँ आदि) के साथ समूहित कर सकते हैं और फिर [समूह को नियंत्रित करें](/slides/hi/net/group/)।

**मैं किसी विशिष्ट SmartArt की छवि (जैसे पूर्वावलोकन या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**

shape की थंबनेल/छवि निर्यात करें; लाइब्रेरी [individual shapes को रेंडर कर](/slides/hi/net/create-shape-thumbnails/) रास्टर फ़ाइलों (PNG/JPG/TIFF) में बदल सकती है।

**क्या पूरी प्रेजेंटेशन को PDF में बदलने पर SmartArt का रूप बना रहेगा?**

हाँ। रेंडरिंग इंजन [PDF export](/slides/hi/net/convert-powerpoint-to-pdf/) के लिए उच्च सटीकता लक्ष्य करता है, जिसमें विभिन्न गुणवत्ता और संगतता विकल्प शामिल हैं।
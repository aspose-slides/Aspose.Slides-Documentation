---
title: स्लाइड्स को इकट्ठा करें
type: docs
weight: 10
url: /hi/net/assemble-slides/
---
## **प्रेजेंटेशन में स्लाइड जोड़ें**
प्रेजेंटेशन फ़ाइलों में स्लाइड जोड़ने से पहले, चलिए स्लाइडों के बारे में कुछ तथ्य पर चर्चा करें। प्रत्येक PowerPoint प्रेजेंटेशन फ़ाइल में मास्टर/लेआउट स्लाइड और अन्य सामान्य स्लाइड्स होती हैं। इसका मतलब है कि एक प्रेजेंटेशन फ़ाइल में कम से कम एक या अधिक स्लाइड्स होती हैं। यह जानना महत्वपूर्ण है कि स्लाइडों के बिना प्रेजेंटेशन फ़ाइलें Aspose.Slides for .NET द्वारा समर्थित नहीं हैं। प्रत्येक स्लाइड का एक अनूठा Id होता है और सभी सामान्य स्लाइड्स को शून्य-आधारित सूचकांक द्वारा निर्दिष्ट क्रम में व्यवस्थित किया जाता है।

Aspose.Slides for .NET डेवलपर्स को उनके प्रेजेंटेशन में खाली स्लाइड जोड़ने की अनुमति देता है। प्रेजेंटेशन में एक खाली स्लाइड जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक **Presentation** वर्ग का इंस्टेंस बनाएँ
- प्रेजेंटेशन ऑब्जेक्ट द्वारा प्रदर्शित Slides (सामग्री Slide ऑब्जेक्ट्स का संग्रह) प्रॉपर्टी का संदर्भ सेट करके **SlideCollection** वर्ग का इंस्टेंस बनाएँ
- **SlideCollection** ऑब्जेक्ट द्वारा प्रदर्शित **AddEmptySlide** मेथड को कॉल करके सामग्री स्लाइड्स संग्रह के अंत में प्रेजेंटेशन में एक खाली स्लाइड जोड़ें
- नई जोड़ी गई खाली स्लाइड के साथ कुछ काम करें
- अंत में, **Presentation** ऑब्जेक्ट का उपयोग करके प्रेजेंटेशन फ़ाइल लिखें

``` csharp

 PresentationEx pres = new PresentationEx();

//SlideCollection क्लास का इंस्टेंस बनाएं

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Slides संग्रह में एक खाली स्लाइड जोड़ें

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTX फ़ाइल को डिस्क पर सहेजें

pres.Write("EmptySlide.pptx");

``` 
## **प्रेजेंटेशन की स्लाइड्स तक पहुँचें**
Aspose.Slides for .NET एक Presentation वर्ग प्रदान करता है जिसका उपयोग प्रेजेंटेशन में मौजूद किसी भी इच्छित स्लाइड को खोजने और पहुँचने के लिए किया जा सकता है।

**Slides संग्रह का उपयोग**

**Presentation** वर्ग एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है और इसमें सभी स्लाइड्स को **SlideCollection** संग्रह के रूप में प्रस्तुत करता है (जो **Slide** ऑब्जेक्ट्स का संग्रह है)। इन सभी स्लाइड्स को इस **Slides** संग्रह से स्लाइड इंडेक्स का उपयोग करके एक्सेस किया जा सकता है।

``` csharp

 //एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करें जो एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//उसके स्लाइड इंडेक्स का उपयोग करके स्लाइड तक पहुँच रहे हैं
SlideEx slide = pres.Slides[0];

``` 
## **स्लाइड्स हटाएँ**
हम जानते हैं कि **Aspose.Slides for .NET** में Presentation वर्ग एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है। Presentation वर्ग एक **SlideCollection** को समाहित करता है जो प्रेज़ेंटेशन का हिस्सा सभी स्लाइड्स का रिपॉजिटरी के रूप में कार्य करता है। डेवलपर्स इस Slides संग्रह से स्लाइड को दो तरीकों से हटा सकते हैं:

- स्लाइड रेफ़रेंस का उपयोग करके
- स्लाइड इंडेक्स का उपयोग करके

**स्लाइड रेफ़रेंस का उपयोग करके**

स्लाइड को उसके रेफ़रेंस का उपयोग करके हटाने के लिए, नीचे दिए गए चरणों का पालन करें:

- Presentation वर्ग का इंस्टेंस बनाएँ
- स्लाइड का रेफ़रेंस उसके Id या Index का उपयोग करके प्राप्त करें
- प्रेजेंटेशन से रेफ़रेंस किया गया स्लाइड हटाएँ
- परिवर्तित प्रेजेंटेशन फ़ाइल लिखें

``` csharp

 //एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करें जो एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//स्लाइड्स संग्रह में उसके इंडेक्स का उपयोग करके स्लाइड तक पहुँच रहे हैं
SlideEx slide = pres.Slides[0];

//उसके रेफ़रेंस का उपयोग करके स्लाइड हटाना
pres.Slides.Remove(slide);

//प्रेजेंटेशन फ़ाइल लिख रहे हैं
pres.Write("modified.pptx");

``` 
## **स्लाइड की स्थिति बदलें**
प्रेजेंटेशन में स्लाइड की स्थिति बदलना बहुत सरल है। नीचे दिए गए चरणों का पालन करें:

- Presentation वर्ग का इंस्टेंस बनाएँ
- स्लाइड का रेफ़रेंस उसके Index का उपयोग करके प्राप्त करें
- रेफ़रेंस किए गए स्लाइड का SlideNumber बदलें
- परिवर्तित प्रेजेंटेशन फ़ाइल लिखें

नीचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की एक स्लाइड (जो शून्य इंडेक्स स्थिति 1 पर स्थित थी) की स्थिति को इंडेक्स 1 (स्थिति 2) में बदल दिया है।

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//SlideCollection क्लास को इंस्टैंसिएट करें

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Slides संग्रह में एक खाली स्लाइड जोड़ें

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTX फ़ाइल को डिस्क पर सहेजें

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करें जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//स्लाइड इंडेक्स का उपयोग करके स्लाइड तक पहुँच रहे हैं

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करें जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//स्लाइड्स संग्रह में उसके इंडेक्स का उपयोग करके स्लाइड तक पहुँच रहे हैं

ISlide slide = pres.Slides[0];

//उसके रेफ़रेंस का उपयोग करके स्लाइड हटाना

pres.Slides.Remove(slide);

//प्रेजेंटेशन फ़ाइल लिख रहे हैं

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//स्रोत प्रेजेंटेशन फ़ाइल लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //उस स्लाइड को प्राप्त करें जिसकी स्थिति बदलनी है

    ISlide sld = pres.Slides[0];

    //स्लाइड के लिए नई स्थिति सेट करें

    sld.SlideNumber = 2;

    //प्रेजेंटेशन को डिस्क पर लिखें

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)
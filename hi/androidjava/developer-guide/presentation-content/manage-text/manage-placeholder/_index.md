---
title: एन्ड्रॉइड पर प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में प्लेसहोल्डर को आसानी से प्रबंधित करें: टेक्स्ट बदलें, प्रॉम्प्ट को अनुकूलित करें और PowerPoint और OpenDocument में छवि की पारदर्शिता सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति प्लेसहोल्डर को प्रोग्रामेटिक रूप से प्रबंधित करने की सुविधा देता है। यह लेख बताता है कि स्लाइड्स पर प्लेसहोल्डर कैसे खोजें और उनका टेक्स्ट बदलें, प्लेसहोल्डर लेआउट के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करें, और प्लेसहोल्डर बैकग्राउंड के रूप में उपयोग की गई छवि की पारदर्शिता कैसे समायोजित करें। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर और स्थानीय शैप के बीच अंतर स्पष्ट करता है, यह बताता है कि प्लेसहोल्डर बदलाव लेआउट या मास्टर के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर व फुटर प्लेसहोल्डर प्रबंधन की ओर संकेत करता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**
Using [Aspose.Slides for Android via Java](/slides/hi/androidjava/), you can find and modify placeholders on slides in presentations. Aspose.Slides आपको प्लेसहोल्डर में टेक्स्ट बदलने की अनुमति देता है।

**Prerequisite**: आपको एक ऐसी प्रस्तुति चाहिए जिसमें प्लेसहोल्डर हो। आप ऐसी प्रस्तुति मानक Microsoft PowerPoint ऐप में बना सकते हैं।

यहाँ बताया गया है कि Aspose.Slides का उपयोग करके उस प्रस्तुति में प्लेसहोल्डर का टेक्स्ट कैसे बदलें:

1. [`Presentation`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास को इंस्टैंशिएट करें और प्रस्तुति को आर्गुमेंट के रूप में पास करें।
2. इंडेक्स के माध्यम से स्लाइड रेफ़रेंस प्राप्त करें।
3. शैप्स को इटररेट करके प्लेसहोल्डर खोजें।
4. प्लेसहोल्डर शैप को एक [`AutoShape`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AutoShape) में टाइपकास्ट करें और उस [`AutoShape`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AutoShape) से जुड़ी [`TextFrame`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrame) का उपयोग करके टेक्स्ट बदलें।
5. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दिखाता है कि प्लेसहोल्डर में टेक्स्ट कैसे बदलें:

```java
// एक Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // पहली स्लाइड को एक्सेस करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // शैप्स के माध्यम से इटररेट करके प्लेसहोल्डर खोजता है
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // प्रत्येक प्लेसहोल्डर का टेक्स्ट बदलता है
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें**
Standard और pre-built लेआउट में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट होते हैं जैसे ***Click to add a title*** या ***Click to add a subtitle***। Aspose.Slides का उपयोग करके आप अपने पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट में डाल सकते हैं।

यह Java कोड दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट करें:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // स्लाइड के माध्यम से इटररेट करता है
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint "Click to add title" दिखाता है 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // सबटाइटल जोड़ता है
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्लेसहोल्डर छवि पारदर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर में बैकग्राउंड छवि की पारदर्शिता सेट करने की अनुमति देता है। इस फ़्रेम में चित्र की पारदर्शिता को समायोजित करके आप टेक्स्ट या चित्र को अधिक प्रमुख बना सकते हैं (टेक्स्ट और चित्र के रंगों के आधार पर)।

यह Java कोड दिखाता है कि शैप के भीतर चित्र बैकग्राउंड की पारदर्शिता कैसे सेट करें:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर स्थानीय शैप से कैसे अलग है?**

बेस प्लेसहोल्डर वह मूल शैप है जो लेआउट या मास्टर पर स्थित होता है और स्लाइड का शैप उससे टाइप, पोजीशन और कुछ फॉर्मेटिंग को वारिसे में प्राप्त करता है। स्थानीय शैप स्वतंत्र होता है; यदि बेस प्लेसहोल्डर नहीं है तो इनहेरिटेंस लागू नहीं होती।

**मैं पूरी प्रस्तुति में सभी शीर्षकों या कैप्शन को बिना प्रत्येक स्लाइड को इटररेट किए कैसे अपडेट कर सकता हूँ?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को एडिट करें। उन लेआउट/मास्टर पर आधारित स्लाइड्स स्वचालित रूप से परिवर्तन को वारिसे में प्राप्त कर लेंगी।

**मैं मानक हेडर/फुटर प्लेसहोल्डर—तारीख & समय, स्लाइड नंबर, और फुटर टेक्स्ट—को कैसे नियंत्रित करूँ?**

उचित स्कोप (सामान्य स्लाइड्स, लेआउट्स, मास्टर, नोट्स/हैंडआउट्स) पर HeaderFooter प्रबंधकों का उपयोग करके इन प्लेसहोल्डर को ऑन या ऑफ करें और उनकी सामग्री सेट करें।
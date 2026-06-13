---
title: जावा में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- इमेज प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्लेसहोल्डर को आसानी से प्रबंधित करें: टेक्स्ट बदलें, प्रॉम्प्ट को अनुकूलित करें और PowerPoint एवं OpenDocument में इमेज की पारदर्शिता सेट करें।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति प्लेसहोल्डर को प्रोग्रामmatically प्रबंधित करने की सुविधा देता है। यह लेख स्लाइड्स पर प्लेसहोल्डर को खोजने, उनका टेक्स्ट बदलने, प्लेसहोल्डर लेआउट के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करने, और प्लेसहोल्डर बैकग्राउंड के रूप में उपयोग किए गए चित्र की पारदर्शिता समायोजित करने के बारे में बताता है। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर और लोकल शेप के बीच अंतर स्पष्ट करता है, यह बताता है कि प्लेसहोल्डर बदलाव लेआउट या मास्टर के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर एवं फुटर प्लेसहोल्डर प्रबंधन की ओर इशारा करता है।

## **प्लेसहोल्डर में पाठ बदलें**
[ Aspose.Slides for Java](/slides/hi/java/) का उपयोग करके आप प्रस्तुति में स्लाइड्स पर प्लेसहोल्डर खोज और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर के टेक्स्ट में बदलाव करने की अनुमति देता है।

**पूर्वापेक्षा**: आपको एक ऐसी प्रस्तुति चाहिए जिसमें प्लेसहोल्डर हो। आप ऐसी प्रस्तुति मानक Microsoft PowerPoint एप्लिकेशन में बना सकते हैं।

यहाँ बताया गया है कि आप Aspose.Slides का उपयोग करके उस प्रस्तुति में प्लेसहोल्डर के टेक्स्ट को कैसे बदलें:

1. [`Presentation`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं और प्रस्तुति को आर्ग्यूमेंट के रूप में पास करें।
2. इसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. शेप्स को इटरेट करके प्लेसहोल्डर खोजें।
4. प्लेसहोल्डर शेप को [`AutoShape`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AutoShape) में टाइपकास्ट करें और जुड़े हुए [`TextFrame`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrame) का उपयोग करके टेक्स्ट बदलें।
5. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दिखाता है कि प्लेसहोल्डर के टेक्स्ट को कैसे बदला जाता है:

```java
// एक Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // शेप्स पर इटरेट करता है ताकि प्लेसहोल्डर मिल सके
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // प्रत्येक प्लेसहोल्डर में टेक्स्ट बदलता है
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
स्टैंडर्ड और प्री‑बिल्ट लेआउट्स में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट जैसे ***Click to add a title*** या ***Click to add a subtitle*** होते हैं। Aspose.Slides का उपयोग करके आप अपने पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट्स में डाल सकते हैं।

यह Java कोड दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट किया जाता है:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // स्लाइड के माध्यम से इटरेट करता है
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

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर में बैकग्राउंड इमेज की पारदर्शिता सेट करने की सुविधा देता है। ऐसी फ्रेम में चित्र की पारदर्शिता समायोजित करके आप टेक्स्ट या चित्र को अधिक प्रमुख बना सकते हैं (टेक्स्ट और चित्र के रंगों पर निर्भर करता है)।

यह Java कोड दिखाता है कि कैसे किसी शेप के अंदर चित्र बैकग्राउंड की पारदर्शिता सेट की जाती है:

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

**बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर लोकल शेप से कैसे अलग है?**

बेस प्लेसहोल्डर वह मूल शेप है जो लेआउट या मास्टर पर स्थित होता है और स्लाइड का शेप उससे टाइप, पोज़िशन और कुछ फॉर्मेटिंग को विरासत में प्राप्त करता है। लोकल शेप स्वतंत्र होता है; यदि कोई बेस प्लेसहोल्डर नहीं है तो विरासत लागू नहीं होती।

**मैं प्रस्तुति में सभी शीर्षक या कैप्शन बिना प्रत्येक स्लाइड पर इटरेट किए कैसे अपडेट कर सकता हूँ?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को संपादित करें। उन लेआउट/मास्टर पर आधारित स्लाइड्स स्वतः ही परिवर्तन विरासत में ले लेंगे।

**मैं मानक हेडर/फूटर प्लेसहोल्डर—तारीख एवं समय, स्लाइड नंबर, और फ़ूटर टेक्स्ट—को कैसे नियंत्रित करूँ?**

उपयुक्त स्कोप (सामान्य स्लाइड्स, लेआउट्स, मास्टर, नोट्स/हैंडआउट्स) पर HeaderFooter मैनेजर्स का उपयोग करके इन प्लेसहोल्डर को ऑन या ऑफ करें और उनका कंटेंट सेट करें।
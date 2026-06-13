---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/androidjava/examples/elements/text-box/
keywords:
- कोड उदाहरण
- टेक्स्ट बॉक्स
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुतीकरण
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android में टेक्स्ट बॉक्स के साथ काम करें: PPT, PPTX और ODP प्रस्तुतियों के लिए जावा का उपयोग करके टेक्स्ट जोड़ें, स्वरूपित करें, संरेखित करें, रैप करें, ऑटोफिट करें और शैली बनाएं।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** `AutoShape` द्वारा दर्शाया जाता है। लगभग सभी आकारों में टेक्स्ट हो सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में न तो भराव है और न ही बॉर्डर, और यह केवल टेक्स्ट दिखाता है।

यह गाइड बताता है कि प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को कैसे जोड़ें, पहुँचें, और हटाएँ।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स बस एक `AutoShape` है जिसमें न भराव है न ही बॉर्डर और कुछ स्वरूपित टेक्स्ट होता है। इसे बनाने का तरीका यहां दिया गया है:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक आयताकार आकार बनाएं (डिफ़ॉल्ट रूप से बॉर्डर के साथ भराव और कोई टेक्स्ट नहीं)।
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // भरण और बॉर्डर हटाएँ ताकि यह सामान्य टेक्स्ट बॉक्स की तरह दिखे।
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // टेक्स्ट स्वरूपण सेट करें।
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // वास्तविक टेक्स्ट सामग्री असाइन करें।
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ध्यान दें:** कोई भी `AutoShape` जिसमें गैर-खाली `TextFrame` हो, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री के आधार पर टेक्स्ट बॉक्स एक्सेस करें**

एक विशिष्ट कुंजीशब्द (जैसे "Slide") वाले सभी टेक्स्ट बॉक्स खोजने के लिए, आकारों के माध्यम से इटरेट करें और उनके टेक्स्ट को जांचें:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // केवल AutoShapes संपादन योग्य टेक्स्ट रख सकते हैं।
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // मिलते-जुलते टेक्स्ट बॉक्स के साथ कुछ करें।
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **सामग्री के आधार पर टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहली स्लाइड पर उन सभी टेक्स्ट बॉक्स को खोजता है और हटाता है जो विशिष्ट कुंजीशब्द रखते हैं:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **सलाह:** इटरेशन के दौरान संशोधित करने से पहले हमेशा आकार संग्रह की एक प्रति बनाएं ताकि संग्रह संशोधन त्रुटियों से बचा जा सके।
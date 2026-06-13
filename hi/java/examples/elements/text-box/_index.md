---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/java/examples/elements/text-box/
keywords:
- कोड उदाहरण
- टेक्स्ट बॉक्स
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में टेक्स्ट बॉक्स के साथ काम करें: जोड़ें, फ़ॉर्मेट करें, संरेखित करें, रैप करें, ऑटॉफ़िट करें, और PPT, PPTX और ODP प्रस्तुतियों के लिए जावा का उपयोग करके टेक्स्ट को स्टाइल करें।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** `AutoShape` द्वारा दर्शाया जाता है। लगभग कोई भी आकार टेक्स्ट रख सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई भराव या बॉर्डर नहीं होता और यह केवल टेक्स्ट दिखाता है।

यह गाइड प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को जोड़ने, एक्सेस करने और हटाने के तरीके समझाता है।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स बस एक `AutoShape` है जिसमें भराव या बॉर्डर नहीं होता और कुछ फ़ॉर्मेट किया गया टेक्स्ट होता है। इसे बनाने का तरीका यहाँ दिया गया है:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक आयताकार आकार बनाएं (डिफ़ॉल्ट रूप से बॉर्डर के साथ भरा हुआ और कोई टेक्स्ट नहीं)।
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // भराव और बॉर्डर हटाएं ताकि यह एक सामान्य टेक्स्ट बॉक्स जैसा दिखे।
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // टेक्स्ट फ़ॉर्मेटिंग सेट करें।
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

> 💡 **नोट:** कोई भी `AutoShape` जिसमें एक गैर-खाली `TextFrame` है, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री के आधार पर टेक्स्ट बॉक्स एक्सेस करें**

किसी विशिष्ट कीवर्ड (जैसे "Slide") को शामिल करने वाले सभी टेक्स्ट बॉक्स को खोजने के लिए, शेप्स के माध्यम से इटरेट करें और उनके टेक्स्ट को जांचें:

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
                    // मेल खाने वाले टेक्स्ट बॉक्स के साथ कुछ करें।
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **सामग्री के आधार पर टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहले स्लाइड पर उन सभी टेक्स्ट बॉक्स को खोजता और हटाता है जिनमें एक विशिष्ट कीवर्ड होता है:

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

> 💡 **टिप:** इटरेशन के दौरान मॉडिफिकेशन त्रुटियों से बचने के लिए हमेशा शेप कलेक्शन की एक कॉपी बनाकर उसे संशोधित करें।
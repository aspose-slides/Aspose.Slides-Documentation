---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/php-java/examples/elements/text-box/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट बॉक्स जोड़ें
- टेक्स्ट बॉक्स तक पहुँचें
- टेक्स्ट बॉक्स हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ Aspose.Slides में टेक्स्ट बॉक्स बनाएं और फॉर्मेट करें: फ़ॉन्ट, संरेखण, रैपिंग, ऑटोफ़िट सेट करें, और PowerPoint तथा OpenDocument के लिए स्लाइड को परिष्कृत करने हेतु लिंक जोड़ें।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** को `AutoShape` द्वारा दर्शाया जाता है। लगभग सभी आकार में टेक्स्ट हो सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई भराव या बॉर्डर नहीं होता और यह केवल टेक्स्ट दिखाता है।

यह गाइड बताता है कि प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को कैसे जोड़ें, एक्सेस करें और हटाएँ।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स सिर्फ एक `AutoShape` है जिसमें कोई भराव या बॉर्डर नहीं होता और कुछ फ़ॉर्मेटेड टेक्स्ट होता है। इसे बनाने का तरीका यहाँ दिया गया है:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // एक आयताकार आकार बनाएं (डिफ़ॉल्ट रूप से बॉर्डर वाला भरा हुआ और कोई टेक्स्ट नहीं)।
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // इसे सामान्य टेक्स्ट बॉक्स जैसा दिखाने के लिए भराव और बॉर्डर हटाएँ।
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // टेक्स्ट फॉर्मैट सेट करें।
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // वास्तविक टेक्स्ट सामग्री असाइन करें।
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **ध्यान दें:** कोई भी `AutoShape` जो गैर-खाली `TextFrame` रखता है, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री द्वारा टेक्स्ट बॉक्स तक पहुँच**

एक विशिष्ट कीवर्ड (जैसे "Slide") वाले सभी टेक्स्ट बॉक्स खोजने के लिए, आकारों के माध्यम से इटरेट करें और उनके टेक्स्ट की जाँच करें:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला टेक्स्ट बॉक्स एक्सेस करें।
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // मिलते हुए टेक्स्ट बॉक्स के साथ कुछ करें।
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **सामग्री द्वारा टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहले स्लाइड पर उस विशिष्ट कीवर्ड को शामिल करने वाले सभी टेक्स्ट बॉक्स को खोजता है और हटाता है:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **सलाह:** इटरेशन के दौरान इसे संशोधित करने से पहले हमेशा शेप कलेक्शन की एक कॉपी बनायें ताकि कलेक्शन संशोधन त्रुटियों से बचा जा सके।
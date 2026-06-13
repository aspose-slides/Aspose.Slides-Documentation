---
title: गणितीय पाठ
type: docs
weight: 160
url: /hi/php-java/examples/elements/math-text/
keywords:
- गणितीय पाठ
- गणितीय पाठ जोड़ें
- गणितीय पाठ पहुँचें
- गणितीय पाठ हटाएँ
- गणितीय पाठ स्वरूपित करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides का उपयोग करके गणितीय पाठ के साथ काम करें: समीकरण, अंश, मूल, स्क्रिप्ट, स्वरूपण बनाएं और संपादित करें, और PPT तथा PPTX के लिए परिणाम रेंडर करें।"
---
**Aspose.Slides for PHP via Java** का उपयोग करके गणितीय पाठ आकारों के साथ काम करने और समीकरणों को स्वरूपित करने को दर्शाता है।

## **गणित पाठ जोड़ें**

एक गणितीय आकार बनाएँ जिसमें एक अंश और पाइथागोरस सूत्र हो।

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड में एक गणितीय आकार जोड़ें।
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // गणितीय पैराग्राफ तक पहुँचें।
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // एक सरल अंश जोड़ें: x / y।
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // समीकरण जोड़ें: c² = a² + b²।
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **गणित पाठ पहुँचें**

स्लाइड पर एक गणितीय पैराग्राफ वाला आकार खोजें।

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // पहले आकार को खोजें जो गणितीय पैराग्राफ सम्मिलित करता है।
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **गणित पाठ हटाएँ**

स्लाइड से एक गणितीय आकार हटाएँ।

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार एक गणितीय आकार है।
        $mathShape = $slide->getShapes()->get_Item(0);

        // स्लाइड से गणितीय आकार हटाएँ।
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **गणित पाठ का स्वरूप**

एक गणितीय भाग के लिए फ़ॉन्ट गुण सेट करें।

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार एक गणितीय आकार है।
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
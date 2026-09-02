---
title: प्रेजेंटेशन्स से PHP में गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात
type: docs
weight: 30
url: /hi/php-java/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- समीकरण LaTeX में निर्यात
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: Aspose.Slides for PHP via Java के साथ PowerPoint प्रेजेंटेशन्स से सीधे LaTeX या MathML में गणितीय समीकरण निर्यात करें।
---
## **परिचय**

Aspose.Slides for PHP via Java आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको किसी विशिष्ट प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरणों को निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 

आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग की जाने वाली गणितीय सामग्री का एक लोकप्रिय मानक है।

{{% /alert %}}

## **LaTeX में गणितीय समीकरण निर्यात करना**

Aspose.Slides सीधे एक PowerPoint गणितीय समीकरण को LaTeX में बदल सकता है; एक मध्यवर्ती MathML फ़ाइल या बाहरी रूपांतारक की आवश्यकता नहीं होती। एक गणितीय समीकरण एक टेक्स्ट फ्रेम में एक [MathPortion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/) के रूप में संग्रहीत रहता है। एक [MathPortion::getMathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/#getMathParagraph) का उपयोग करके आप एक [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) प्राप्त कर सकते हैं, और फिर [MathParagraph::toLatex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य एप्लिकेशन को भेज सकते हैं या आगे प्रोसेस कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड के सभी टेक्स्ट फ्रेम की जाँच करता है, सभी गणितीय भागों को खोजता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#getAllTextBoxes) एक स्लाइड पर मिलने वाले सभी टेक्स्ट फ्रेम लौटाता है। [MathPortion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/) प्रकार की जांच वास्तविक संपाद्य समीकरणों को सामान्य टेक्स्ट और छवियों से अलग करती है।

सभी LaTeX इंजन और दस्तावेज़ टेम्पलेट एक ही कमांड, पैकेज या Unicode अक्षरों को समर्थन नहीं देते। अपने एप्लिकेशन द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो लौटाई गई स्ट्रिंग में उसे प्रोजेक्ट‑विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को दर्ज करें।

## **MathML के रूप में गणितीय समीकरण सहेजें**

मानव LaTeX जैसे कुछ समीकरण स्वरूपों का कोड आसानी से लिख सकते हैं, लेकिन MathML का कोड लिखने में कठिनाई होती है क्योंकि इसे एप्लिकेशन द्वारा स्वचालित रूप से उत्पन्न किया जाना चाहिए। प्रोग्राम MathML को आसानी से पढ़ और पार्स कर सकते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में व्यापक रूप से उपयोग किया जाता है।

यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति से गणितीय समीकरण को MathML में निर्यात किया जाए:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में निर्यात वास्तव में क्या होता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप सम्पूर्ण गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार के पास MathML लिखने की विधि उपलब्ध है।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या छवि नहीं बल्कि एक गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) होता है। उन छवियों और सामान्य टेक्स्ट भागों जिनके पास [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) नहीं है, को निर्यात योग्य सूत्र नहीं माना जाता।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint‑विशिष्ट है या मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति‑MathML—मानक का वह प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो विभिन्न अनुप्रयोगों और वेब में व्यापक रूप से प्रयुक्त है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर के सूत्रों का निर्यात समर्थित है?**

हाँ, यदि उन वस्तुओं में वह टेक्स्ट भाग है जिसमें [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) है (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात किए जाते हैं। यदि कोई सूत्र छवि के रूप में एंबेडेड है, तो वह निर्यात नहीं होगा।

**क्या MathML में निर्यात करते समय मूल प्रस्तुति में परिवर्तन होता है?**

नहीं। MathML लिखना सूत्र की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।
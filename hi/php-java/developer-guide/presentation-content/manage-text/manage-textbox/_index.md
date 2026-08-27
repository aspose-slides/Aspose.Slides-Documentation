---
title: PHP का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स को प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/php-java/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स को बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपकी प्रस्तुति स्वचालन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शैप्स में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको सबसे पहले एक टेक्स्ट बॉक्स जोड़ना पड़ता है और फिर उसके अंदर टेक्स्ट रखना पड़ता है। Aspose.Slides for PHP via Java वह [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास प्रदान करता है जो आपको टेक्स्ट वाले शैप को जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides additionally वह [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास भी प्रदान करता है जो स्लाइड्स में शैप जोड़ने की अनुमति देता है। हालांकि, `Shape` क्लास के माध्यम से जोड़े गए सभी शैप्स में टेक्स्ट नहीं हो सकता। लेकिन [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास के माध्यम से जोड़े गए शैप्स में टेक्स्ट हो सकता है।
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
इसलिए, जब आप किसी शैप के साथ काम कर रहे हैं जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `AutoShape` क्लास के माध्यम से कास्ट किया गया है। तभी आप `AutoShape` के अंतर्गत आने वाले [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्रॉपर्टी के साथ काम कर पाएंगे। इस पेज के [Update Text](/slides/hi/php-java/manage-textbox/#update-text) सेक्शन को देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए इन चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहले स्लाइड का संदर्भ प्राप्त करें।  
3. निर्दिष्ट स्थिति पर `Rectangle` के रूप में शैप टाइप सेट करके एक नया [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) ऑब्जेक्ट जोड़ें और नए जोड़े गए `AutoShape` ऑब्जेक्ट का संदर्भ प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें टेक्स्ट हो। नीचे के उदाहरण में हमने यह टेक्स्ट जोड़ा: *Aspose TextBox*  
5. अंत में `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह PHP कोड—उपरोक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड पर टेक्स्ट कैसे जोड़ें:

```php
  # प्रेजेंटेशन को इंस्टेंसिएट करता है
  $pres = new Presentation();
  try {
    # प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # टाइप को Rectangle सेट करके AutoShape जोड़ता है
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle में TextFrame जोड़ता है
    $ashp->addTextFrame(" ");
    # TextFrame को एक्सेस करता है
    $txtFrame = $ashp->getTextFrame();
    # TextFrame के लिए Paragraph ऑब्जेक्ट बनाता है
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph के लिए Portion ऑब्जेक्ट बनाता है
    $portion = $para->getPortions()->get_Item(0);
    # टेक्स्ट सेट करता है
    $portion->setText("Aspose TextBox");
    # प्रेजेंटेशन को डिस्क पर सहेजता है
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट बॉक्स शैप की जांच करें**

Aspose.Slides वह [isTextBox](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/istextbox/) मेथड [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास से प्रदान करता है, जिससे आप शैप्स की जांच कर टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![Text box and shape](istextbox.png)

यह PHP कोड दिखाता है कि किसी शैप को टेक्स्ट बॉक्स के रूप में जांचना है या नहीं:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

ध्यान दें कि यदि आप केवल `addAutoShape` मेथड का उपयोग करके [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास से एक ऑटॉशैप जोड़ते हैं, तो ऑटॉशैप का `isTextBox` मेथड `false` लौटाएगा। हालांकि, यदि आप `addTextFrame` मेथड या `setText` मेथड से ऑटॉशैप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाएगी।

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() false लौटता है
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() true लौटता है

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() false लौटता है
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() true लौटता है

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() false लौटता है
$shape3->addTextFrame("");
// shape3->isTextBox() false लौटता है

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() false लौटता है
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() false लौटता है
```

## **उस शैप को खोजें जो टेक्स्ट फ्रेम का मालिक है**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड में आप एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्राप्त कर सकते हैं बिना यह जाने कि वह कौनसे प्रेजेंटेशन ऑब्जेक्ट में है। मालिक शैप पर वापस जाने के लिए आप [TextFrame::getParentShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentShape) मेथड का उपयोग करें।

जब टेक्स्ट फ्रेम किसी [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) या किसी अन्य टेक्स्ट‑समेत शैप से जुड़ा होता है, तो [TextFrame::getParentShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentShape) मालिक को लौटाता है और [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) `null` लौटाता है। दोनों मेथड्स केवल रीड‑ओनली नेविगेशन प्रदान करते हैं, इसलिए इन्हें कॉल करने से मालिकाना हक़ नहीं बदलता। `java_is_null` के साथ लौटाए गए मान की जाँच करना न भूलें।

शैप और टेबल‑सेल मालिकों की पहचान करने वाले पूर्ण उदाहरण, जिसमें स्मार्टआर्ट नोड्स से जुड़े शैप्स शामिल हैं, के लिए देखें: [Search and Replace Text](/slides/hi/php-java/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides वह [setColumnCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumncount/) और [setColumnSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumnspacing/) मेथड्स [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) क्लास से प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं।

यह कोड वर्णित ऑपरेशन दर्शाता है:

```php
  $pres = new Presentation();
  try {
    # प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # टाइप को Rectangle सेट करके AutoShape जोड़ता है
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle में TextFrame जोड़ता है
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame का टेक्स्ट फॉर्मेट प्राप्त करता है
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
    $format->setColumnCount(3);
    # कॉलमों के बीच स्पेसिंग निर्दिष्ट करता है
    $format->setColumnSpacing(10);
    # प्रेजेंटेशन को सहेजता है
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for PHP via Java वह [setColumnCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumncount/) मेथड [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) क्लास से प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में इच्छित कॉलम संख्या निर्दिष्ट कर सकते हैं।

यह PHP कोड दर्शाता है कि टेक्स्ट फ्रेम के भीतर कॉलम कैसे जोड़ें:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रेजेंटेशन में सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है।

यह PHP कोड एक ऑपरेशन दर्शाता है जहाँ प्रेजेंटेशन में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # जाँचता है कि शैप टेक्स्ट फ्रेम (IAutoShape) को समर्थन देता है।
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # टेक्स्ट फ्रेम में पैराग्राफ़ पर इटररेट करता है
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # पैराग्राफ़ में प्रत्येक पोर्शन पर इटररेट करता है
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// टेक्स्ट बदलता है

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// फ़ॉर्मेट बदलता है

            }
          }
        }
      }
    }
    # संशोधित प्रस्तुति को सहेजता है
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

आप टेक्स्ट बॉक्स के भीतर लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलते हैं।

हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहले स्लाइड का संदर्भ प्राप्त करें।  
3. निर्दिष्ट स्थिति पर `Rectangle` के रूप में `ShapeType` सेट करके एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़ें गए `AutoShape` ऑब्जेक्ट का संदर्भ प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* हो।  
5. `HyperlinkManager` क्लास का एक इंस्टेंस बनाएं।  
6. अपने `TextFrame` के इच्छित हिस्से के साथ जुड़े हाइपरलिंक को सेट करने के लिए [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) मेथड का उपयोग करें।  
7. अंत में `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह PHP कोड—उपरोक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंसिएट करता है
  $pres = new Presentation();
  try {
    # प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # टाइप को Rectangle सेट करके AutoShape ऑब्जेक्ट जोड़ता है
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # शेप को AutoShape में कास्ट करता है
    $pptxAutoShape = $shape;
    # AutoShape से संबंधित ITextFrame प्रॉपर्टी को एक्सेस करता है
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # फ़्रेम में कुछ टेक्स्ट जोड़ता है
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करता है
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX प्रेजेंटेशन को सहेजता है
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/php-java/manage-placeholder/) शैली/स्थिति को [master](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) से विरासत में लेता है और इसे [layouts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि सामान्य टेक्स्ट बॉक्स किसी विशिष्ट स्लाइड पर एक स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं कैसे पूरे प्रेजेंटेशन में बड़े पैमाने पर टेक्स्ट रिप्लेसमेंट कर सकता हूँ बिना चार्ट्स, टेबल्स और SmartArt के भीतर के टेक्स्ट को छुए?**

ऑटो‑शैप्स को फ़िल्टर करें जिनमें टेक्स्ट फ्रेम हों और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/)) को बाहर रखें, या उनके संग्रह को अलग‑अलग ट्रैवर्स करें या उन ऑब्जेक्ट प्रकारों को स्किप करें।
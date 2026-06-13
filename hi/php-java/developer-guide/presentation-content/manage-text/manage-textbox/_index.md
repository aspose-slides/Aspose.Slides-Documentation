---
title: PHP का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
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
description: "Aspose.Slides for PHP PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रस्तुति स्वचालन में सुधार होता है।"
---
## **परिचय**

स्लाइडों पर पाठ आमतौर पर टेक्स्ट बॉक्स या आकार में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए, आपको एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उस बॉक्स के भीतर कुछ टेक्स्ट डालना होगा। Aspose.Slides for PHP via Java [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास प्रदान करता है जो आपको कुछ टेक्स्ट वाले आकार को जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides additionally [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास प्रदान करता है जो आपको स्लाइडों में आकार जोड़ने की अनुमति देता है। हालांकि, `Shape` क्लास के माध्यम से जोड़े गए सभी आकार टेक्स्ट नहीं रख सकते। लेकिन [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास के माध्यम से जोड़े गए आकार टेक्स्ट रख सकते हैं।
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
इसलिए, जब आप किसी आकार के साथ काम कर रहे हैं जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `AutoShape` क्लास के माध्यम से कास्ट किया गया है। तभी आप `AutoShape` के तहत मौजूद [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के साथ काम कर पाएंगे। इस पृष्ठ के [अपडेट टेक्स्ट](/slides/hi/php-java/manage-textbox/#update-text) खंड देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए, इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की instance बनाएं।  
2. नए बनाए गए प्रस्तुति में पहली स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थिति पर श shape प्रकार को [Rectangle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapetype/#Rectangle) के रूप में सेट करके एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) ऑब्जेक्ट जोड़ें और जोड़े गए `AutoShape` ऑब्जेक्ट का संदर्भ प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जो टेक्स्ट धारण करेगा। नीचे के उदाहरण में हमने यह टेक्स्ट जोड़ा: *Aspose TextBox*  
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह PHP कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ें:

```php
  # Presentation का इंस्टैंस बनाता है
  $pres = new Presentation();
  try {
    # प्रस्तुति में पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार के साथ एक AutoShape जोड़ता है
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle में TextFrame जोड़ता है
    $ashp->addTextFrame(" ");
    # TextFrame तक पहुँचता है
    $txtFrame = $ashp->getTextFrame();
    # TextFrame के लिए Paragraph ऑब्जेक्ट बनाता है
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph के लिए Portion ऑब्जेक्ट बनाता है
    $portion = $para->getPortions()->get_Item(0);
    # टेक्स्ट सेट करता है
    $portion->setText("Aspose TextBox");
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट बॉक्स आकार की जाँच**

Aspose.Slides [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) क्लास से [isTextBox](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/istextbox/) मेथड प्रदान करता है, जिससे आप आकारों की जाँच कर टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![Text box and shape](istextbox.png)

यह PHP कोड आपको दिखाता है कि किसी आकार को टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

ध्यान दें कि यदि आप केवल `addAutoShape` मेथड का उपयोग करके [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास से एक ऑटोशेप जोड़ते हैं, तो उस ऑटोशेप की `isTextBox` मेथड `false` लौटाएगी। हालांकि, जब आप `addTextFrame` मेथड या `setText` मेथड से ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाती है।

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() false वापस देता है
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() true वापस देता है

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() false वापस देता है
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() true वापस देता है

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() false वापस देता है
$shape3->addTextFrame("");
// shape3->isTextBox() false वापस देता है

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() false वापस देता है
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() false वापस देता है
```

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) क्लास से [setColumnCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumncount/) और [setColumnSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumnspacing/) मेथड प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलम की संख्या निर्धारित कर सकते हैं और कॉलम के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं।

यह कोड वर्णित ऑपरेशन को दर्शाता है:

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार सेट करके एक AutoShape जोड़ता है
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle में TextFrame जोड़ता है
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame का टेक्स्ट फ़ॉर्मेट प्राप्त करता है
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame में कॉलम की संख्या निर्दिष्ट करता है
    $format->setColumnCount(3);
    # कॉलम के बीच की दूरी निर्दिष्ट करता है
    $format->setColumnSpacing(10);
    # प्रस्तुति सहेजता है
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for PHP via Java [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) क्लास से [setColumnCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setcolumncount/) मेथड प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के द्वारा आप टेक्स्ट फ्रेम में वांछित कॉलम संख्या निर्दिष्ट कर सकते हैं।

यह PHP कोड आपको दिखाता है कि टेक्स्ट फ्रेम के भीतर एक कॉलम कैसे जोड़ें:

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

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रस्तुति में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है।

यह PHP कोड एक ऑपरेशन दर्शाता है जहाँ पूरी प्रस्तुति में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # जांचता है कि आकार टेक्स्ट फ्रेम (IAutoShape) को समर्थन देता है।
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # टेक्स्ट फ्रेम में पैराग्राफ़ों पर इटररेट करता है
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # पैराग्राफ में प्रत्येक पोर्शन पर इटररेट करता है
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// टेक्स्ट बदलता है

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// फ़ॉर्मेटिंग बदलता है

            }
          }
        }
      }
    }
    # परिवर्तित प्रस्तुति सहेजता है
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

आप टेक्स्ट बॉक्स के अंदर एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं।

एक लिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए, इन चरणों का पालन करें:

1. `Presentation` क्लास की एक instance बनाएं।  
2. नए बनाए गए प्रस्तुति में पहली स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थिति पर `ShapeType` को `Rectangle` सेट करके एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का संदर्भ प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट के रूप में *Aspose TextBox* हो।  
5. `HyperlinkManager` क्लास का एक instance बनाएं।  
6. अपने `TextFrame` के इच्छित हिस्से पर [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) मेथड के साथ एक हाइपरलिंक असाइन करें।  
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह PHP कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
  $pres = new Presentation();
  try {
    # प्रस्तुति में पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार सेट करके एक AutoShape ऑब्जेक्ट जोड़ता है
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # शेप को AutoShape में कास्ट करता है
    $pptxAutoShape = $shape;
    # AutoShape से जुड़ी ITextFrame प्रॉपर्टी तक पहुँचता है
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # फ़्रेम में कुछ टेक्स्ट जोड़ता है
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # पोर्टियन टेक्स्ट के लिए हाइपरलिंक सेट करता है
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX प्रस्तुति को सहेजता है
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मुख्य स्लाइडों के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/php-java/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) से शैली/स्थिति विरासत में लेता है और उसे [layouts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स विशिष्ट स्लाइड पर एक स्वतंत्र ऑब्जेक्ट है और लेआउट बदलने पर नहीं बदलता।

**मैं चार्ट, टेबल और SmartArt के भीतर टेक्स्ट को छुए बिना पूरी प्रस्तुति में बड़े पैमाने पर टेक्स्ट प्रतिस्थापन कैसे कर सकता हूँ?**

ऑटो‑शेप्स जिनमें टेक्स्ट फ्रेम हैं, तक अपनी इटरशन सीमित रखें और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/)) को अलग-अलग उनके संग्रहों को ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को छोड़कर बाहर निकालें।
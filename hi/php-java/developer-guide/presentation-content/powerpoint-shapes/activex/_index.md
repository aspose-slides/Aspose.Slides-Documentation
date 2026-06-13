---
title: "PHP का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें"
linktitle: "ActiveX"
type: docs
weight: 80
url: /hi/php-java/activex/
keywords:
  - "ActiveX"
  - "ActiveX नियंत्रण"
  - "ActiveX प्रबंधित करें"
  - "ActiveX जोड़ें"
  - "ActiveX संशोधित करें"
  - "मीडिया प्लेयर"
  - "PowerPoint"
  - "प्रस्तुति"
  - "PHP"
  - "Aspose.Slides"
description: "जाने कैसे Aspose.Slides for PHP via Java ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और उन्नत करता है, जिससे विकासकर्ताओं को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रणों का उपयोग प्रस्तुतियों में किया जाता है। Aspose.Slides for PHP via Java आपको ActiveX नियंत्रणों को जोड़ने और प्रबंधित करने की सुविधा देता है, लेकिन सामान्य प्रस्तुति आकारों की तुलना में इन्हें प्रबंधित करना थोड़ा अधिक जटिल है। हमने Aspose.Slides में Media Player Active नियंत्रण जोड़ने के समर्थन को लागू किया है। ध्यान रखें कि ActiveX नियंत्रण आकार नहीं हैं; वे प्रस्तुति के [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) का हिस्सा नहीं हैं। वे अलग-अलग [ControlCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/controlcollection/) का हिस्सा होते हैं। इस विषय में, हम आपको दिखाएंगे कि इनके साथ कैसे काम किया जाता है।

## **स्लाइड में Media Player ActiveX नियंत्रण जोड़ें**
ActiveX Media Player नियंत्रण जोड़ने के लिये, यह करें:

1. एक खाली प्रस्तुति उदाहरण उत्पन्न करने हेतु [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) में लक्ष्य स्लाइड तक पहुंचें।
1. [ControlCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/controlcollection/) द्वारा प्रदान किए गए [addControl](https://reference.aspose.com/slides/hi/php-java/aspose.slides/controlcollection/addcontrol/) मेथड का उपयोग करके Media Player ActiveX नियंत्रण जोड़ें।
1. Media Player ActiveX नियंत्रण तक पहुंचें और उसकी प्रॉपर्टीज़ का उपयोग करके वीडियो पथ सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

ऊपर दिए गए चरणों पर आधारित यह नमूना कोड स्लाइड में Media Player ActiveX नियंत्रण जोड़ने का तरीका दिखाता है:

```php
  # खाली प्रस्तुति इंस्टेंस बनाएँ
  $pres = new Presentation();
  try {
    # Media Player ActiveX नियंत्रण जोड़ रहा है
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Media Player ActiveX नियंत्रण तक पहुँचें और वीडियो पथ सेट करें
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # प्रस्तुति सहेजें
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ActiveX नियंत्रण को संशोधित करें**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 और नवीनतम संस्करणों में ActiveX नियंत्रणों को प्रबंधित करने के लिए घटक उपलब्ध हैं। आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुंच सकते हैं और उसकी प्रॉपर्टीज़ के माध्यम से उसे संशोधित या हटाना कर सकते हैं।

{{% /alert %}} 

स्लाइड पर टेक्स्ट बॉक्स और साधारण कमांड बटन जैसे एक सरल ActiveX नियंत्रण को प्रबंधित करने के लिये, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और उसमें ActiveX नियंत्रणों वाली प्रस्तुति लोड करें।
1. उसके सूचकांक द्वारा स्लाइड संदर्भ प्राप्त करें।
1. स्लाइड में मौजूद ActiveX नियंत्रणों तक पहुँचने के लिये [ControlCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/controlcollection/) तक पहुंचें।
1. [Control](https://reference.aspose.com/slides/hi/php-java/aspose.slides/control/) ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुंचें।
1. TextBox1 ActiveX नियंत्रण की प्रॉपर्टीज़ बदलें, जिनमें टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति शामिल हैं।
1. दूसरे पहुँच नियंत्रण जिसका नाम CommandButton1 है, तक पहुंचें।
1. बटन कैप्शन, फ़ॉन्ट और स्थिति बदलें।
1. ActiveX नियंत्रण फ्रेमों की स्थिति को शिफ्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

ऊपर दिये गये चरणों पर आधारित यह नमूना कोड एक सरल ActiveX नियंत्रण को प्रबंधित करने का तरीका दिखाता है:

```php
  # ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुंच
  $pres = new Presentation("ActiveX.pptm");
  try {
    # प्रस्तुति में पहली स्लाइड तक पहुंच
    $slide = $pres->getSlides()->get_Item(0);
    # TextBox टेक्स्ट बदल रहा है
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # बदली हुई छवि बदलना। PowerPoint सक्रियता के दौरान इस छवि को बदल देगा,
      # इसलिए कभी‑कभी छवि को अपरिवर्तित छोड़ना ठीक है।
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # बटन कैप्शन बदलना
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # बदली हुई छवि बदलना
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # 100 पॉइंट नीचे ले जा रहे हैं
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # नियंत्रणों को हटाना
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides सक्रिय नहीं हो सकने वाले ActiveX नियंत्रणों को पढ़ने और पुनः सहेजने पर संरक्षित रखता है?**

हां। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनकी प्रॉपर्टीज़ व फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं चलाना उन्हें संरक्षित रखने के लिये आवश्यक नहीं है।

**ActiveX नियंत्रण प्रस्तुति में OLE वस्तुओं से कैसे अलग होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/php-java/manage-ole/) एम्बेडेड एप्लिकेशन वस्तुओं को दर्शाता है (उदाहरण के लिये, एक Excel कार्यपत्र)। इन्हें अलग तरीके से संग्रहीत व संभाला जाता है और इनकी प्रॉपर्टी मॉडल अलग होती है।

**क्या ActiveX इवेंट्स और VBA मैक्रो काम करते हैं यदि फ़ाइल को Aspose.Slides ने संशोधित किया हो?**

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि इवेंट्स और मैक्रो केवल Windows पर PowerPoint के भीतर ही चलते हैं जब सुरक्षा अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती।
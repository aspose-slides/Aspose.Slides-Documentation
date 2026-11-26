---
title: PHP का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/php-java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX का प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटनों को संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में Windows Media Player नियंत्रण का पुन: उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को इंटरैक्टिव तत्व जैसे टेक्स्ट बॉक्स, कमांड बटन, और मीडिया प्लेयर्स प्रदान करते हैं। Aspose.Slides for PHP via Java स्लाइड के नियंत्रणों को [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं, या हटा सकते हैं।

## **ActiveX नियंत्रणों और उनके संग्रहीत गुणों की सूची**

अपरिचित टेम्प्लेट का निरीक्षण करने के लिए, उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से इटररेट करें। उदाहरण स्लाइड संख्या, नियंत्रण नाम, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) और प्रत्येक कुंजी‑मान जोड़ी को [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) में रिपोर्ट करता है। यह प्रस्तुति को बिना नियंत्रणों को सक्रिय किए, इवेंट्स या मैक्रोज़ को बुलाए, मान बदलें या फाइल सहेजे बिना पढ़ता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`ActiveX.pptm` से चयनित आउटपुट एक टेक्स्ट बॉक्स और एक कमांड बटन दिखाता है।

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

खाली गुण संग्रह `[]` के रूप में दिखता है। बाइनरी स्टोरेज का उपयोग करने वाले नियंत्रणों के लिए, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) `null` लौटा सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो null जाँच के बाद [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध गुणों को सूचीबद्ध करती है। एक नियंत्रण रन‑टाइम में अतिरिक्त गुणों को सपोर्ट कर सकता है।

## **ActiveX नियंत्रणों में संशोधन**

उदाहरण एक मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहले स्लाइड पर `TextBox1` नाम का टेक्स्ट बॉक्स और `CommandButton1` नाम का कमांड बटन हो। यह [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स मान और बटन कैप्शन बदलता है। प्रत्येक नियंत्रण का एक स्थिर प्रीव्यू भी होता है जिसे PowerPoint सक्रियण से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए अपडेटेड टेक्स्ट और स्वरूप दिखाने वाली PNG प्रदान करें। उदाहरण इन छवियों को [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) के माध्यम से असाइन करता है।

उदाहरण पहले स्लाइड पर सभी नियंत्रणों को 100 पॉइंट नीचे ले जाता है, उनके फ्रेम को [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) द्वारा सेट करके। यह संपादित प्रस्तुति को PPTM फ़ॉर्मेट में सहेजता है, फिर सभी ActiveX नियंत्रणों को हटाकर दूसरी प्रतिलिपि सहेजने के लिए [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) का उपयोग करता है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किए गए Windows Media Player नियंत्रण को पुन: उपयोग करने के लिए, ऐसे टेम्प्लेट से शुरू करें जहाँ पहले स्लाइड में `WindowsMediaPlayer1` नाम का प्लेयर हो। [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) पूरी स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसके [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में केवल स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides सक्रिय किए बिना ActiveX नियंत्रणों को संरक्षित कर सकता है?**

हाँ। Aspose.Slides नियंत्रणों को पढ़ और सहेज सकता है, जिसमें उनके गुण और स्थितियाँ शामिल हैं, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE ऑब्जेक्ट्स से कैसे अलग होते हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने देते हैं, जैसे टेक्स्ट दर्ज करना या बटन पर क्लिक करना। एक [OLE ऑब्जेक्ट](/slides/hi/php-java/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को सम्मिलित या लिंक करने देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट्स VBA मैक्रोज़ को ट्रिगर करेंगे?**

प्रेज़ेंटेशन को PPTM जैसे मैक्रो‑सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। Windows के लिए PowerPoint इन इवेंट हैंडलर्स को तब चलाएगा जब उसकी सुरक्षा सेटिंग्स ActiveX नियंत्रणों और मैक्रोज़ दोनों को अनुमति देती हैं।
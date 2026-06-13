---
title: "PHP में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें"
linktitle: "प्रस्तुतियों को मर्ज करें"
type: docs
weight: 40
url: /hi/php-java/merge-presentation/
keywords:
- "PowerPoint मर्ज करें"
- "प्रस्तुतियों को मर्ज करें"
- "स्लाइड्स को मर्ज करें"
- "PPT मर्ज करें"
- "PPTX मर्ज करें"
- "ODP मर्ज करें"
- "PowerPoint को संयोजित करें"
- "प्रस्तुतियों को संयोजित करें"
- "स्लाइड्स को संयोजित करें"
- "PPT को संयोजित करें"
- "PPTX को संयोजित करें"
- "ODP को संयोजित करें"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को सहजता से मर्ज करें, जिससे आपका कार्य प्रवाह सुगम हो जाता है।"
---
## **परिचय**

Aspose.Slides आपको एक प्रस्तुति से दूसरी में स्लाइड्स को क्लोन करके प्रस्तुतियों को मर्ज करने की अनुमति देता है। यह लेख बताता है कि संपूर्ण प्रस्तुतियों या चयनित स्लाइड्स को कैसे मर्ज किया जाए, मर्ज के दौरान स्लाइड मास्टर या विशिष्ट लेआउट का उपयोग कैसे किया जाए, विभिन्न स्लाइड आकार वाली प्रस्तुतियों को कैसे संभाला जाए, और मर्ज की गई स्लाइड्स को प्रस्तुति सेक्शन में कैसे जोड़ें। यह मर्ज किए गए कंटेंट से संबंधित व्यावहारिक नोट्स को भी कवर करता है, जिसमें वक्ता नोट्स, टिप्पणियाँ, पासवर्ड‑संरक्षित स्रोत फ़ाइलें, और थ्रेड उपयोग शामिल हैं।

## **प्रस्तुति मर्जिंग**

जब आप एक प्रस्तुति को दूसरी में मर्ज करते हैं, तो आप प्रभावी रूप से उनके स्लाइड्स को एक ही प्रस्तुति में संयोजन कर रहे होते हैं ताकि एक फ़ाइल प्राप्त हो। 

{{% alert title="Info" color="info" %}}

ज्यादातर प्रस्तुति प्रोग्राम (PowerPoint या OpenOffice) में ऐसी कार्यात्मकता नहीं होती जिससे उपयोगकर्ता प्रस्तुतियों को इस प्रकार जोड़ सकें। 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/hi/php-java/), हालांकि, विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की अनुमति देती है। आप सभी आकार, शैली, पाठ, फ़ॉर्मैटिंग, टिप्पणियाँ, एनीमेशन आदि के साथ प्रस्तुतियों को बिना गुणवत्ता या डेटा की हानि की चिंता किए मर्ज कर सकते हैं।

**संबंधित देखें**

[स्लाइड क्लोन](/slides/hi/php-java/clone-slides/).

{{% /alert %}}

### **क्या मर्ज किया जा सकता है**

Aspose.Slides के साथ, आप मर्ज कर सकते हैं 

* पूरी प्रस्तुतियां। सभी स्लाइड्स एक ही प्रस्तुति में आ जाती हैं
* विशिष्ट स्लाइड्स। चयनित स्लाइड्स एक ही प्रस्तुति में आ जाती हैं
* एक ही फ़ॉर्मैट (PPT से PPT, PPTX से PPTX, आदि) और विभिन्न फ़ॉर्मैट (PPT से PPTX, PPTX से ODP, आदि) में प्रस्तुतियों को एक‑दूसरे के साथ मर्ज करना। 

{{% alert title="Note" color="warning" %}} 

प्रस्तुतियों के अलावा, Aspose.Slides आपको अन्य फ़ाइलों को मर्ज करने की अनुमति देता है:

* [छवियां](https://products.aspose.com/slides/hi/php-java/merger/image-to-image/), जैसे कि [JPG to JPG](https://products.aspose.com/slides/hi/php-java/merger/jpg-to-jpg/) या [PNG to PNG](https://products.aspose.com/slides/hi/php-java/merger/png-to-png/)
* [दस्तावेज़](https://products.aspose.com/slides/hi/php-java/merger/pdf-to-pdf/), जैसे कि [PDF to PDF](https://products.aspose.com/slides/hi/php-java/merger/pdf-to-pdf/) या [HTML to HTML](https://products.aspose.com/slides/hi/php-java/merger/html-to-html/)
* और दो विभिन्न फ़ाइलें जैसे [image to PDF](https://products.aspose.com/slides/hi/php-java/merger/image-to-pdf/) या [JPG to PDF](https://products.aspose.com/slides/hi/php-java/merger/jpg-to-pdf/) या [TIFF to PDF](https://products.aspose.com/slides/hi/php-java/merger/tiff-to-pdf/)।

{{% /alert %}}

### **मर्जिंग विकल्प**

आप विकल्प लागू कर सकते हैं जो यह निर्धारित करते हैं कि

* आउटपुट प्रस्तुति की प्रत्येक स्लाइड अपनी अनूठी शैली बनाए रखे
* आउटपुट प्रस्तुति की सभी स्लाइड्स के लिए एक विशिष्ट शैली उपयोग की जाए। 

प्रस्तुतियों को मर्ज करने के लिए, Aspose.Slides [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) मेथड्स ([SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) क्लास) प्रदान करता है। `addClone` मेथड्स के कई इम्प्लीमेंटेशन हैं जो प्रस्तुति मर्ज प्रक्रिया के पैरामीटर निर्धारित करते हैं। प्रत्येक Presentation ऑब्जेक्ट में एक [slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getslides/) कलेक्शन होता है, इसलिए आप उस प्रस्तुति से `addClone` मेथड को कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`addClone` मेथड एक `Slide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड की क्लोन होती है। आउटपुट प्रस्तुति में स्लाइड्स बस स्रोत की स्लाइड्स की कॉपी होती हैं। इसलिए, आप परिणामी स्लाइड्स में परिवर्तन (जैसे शैली लागू करना या फ़ॉर्मैटिंग विकल्प या लेआउट) कर सकते हैं बिना स्रोत प्रस्तुतियों पर प्रभाव पड़े की चिंता किए। 

## **प्रस्तुतियों को मर्ज करें** 

Aspose.Slides वह [addClone(Slide)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) मेथड प्रदान करता है जो स्लाइड्स को संयोजित करने की अनुमति देता है जबकि स्लाइड्स अपने लेआउट और शैली (डिफ़ॉल्ट पैरामीटर) बनाए रखती हैं।

यह PHP कोड दिखाता है कि प्रस्तुतियों को कैसे मर्ज किया जाए:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **स्लाइड मास्टर के साथ प्रस्तुतियों को मर्ज करें**

Aspose.Slides वह [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) मेथड प्रदान करता है जो स्लाइड मास्टर प्रस्तुति टेम्पलेट लागू करते हुए स्लाइड्स को संयोजित करने की अनुमति देता है। इस प्रकार, आवश्यक होने पर आप आउटपुट प्रस्तुति में स्लाइड्स की शैली बदल सकते हैं।

यह कोड वर्णित ऑपरेशन को दर्शाता है:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

स्लाइड मास्टर के लिए स्लाइड लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, यदि `addClone` मेथड का `allowCloneMissingLayout` बूलियन पैरामीटर true पर सेट है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाता है। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PptxEditException) फेंका जाएगा।

{{% /alert %}}

यदि आप आउटपुट प्रस्तुति की स्लाइड्स के लिए अलग लेआउट चाहते हैं, तो मर्ज करते समय [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) मेथड का उपयोग करें।

## **प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करें**

कई प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करना कस्टम स्लाइड डेक बनाने में उपयोगी है। Aspose.Slides for PHP via Java आपको केवल आवश्यक स्लाइड्स चुनने और इम्पोर्ट करने की अनुमति देता है। API मूल स्लाइड्स की फ़ॉर्मैटिंग, लेआउट और डिज़ाइन को संरक्षित रखती है।

निम्नलिखित PHP कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से टाइटल स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **स्लाइड लेआउट के साथ प्रस्तुतियों को मर्ज करें**

यह PHP कोड दिखाता है कि प्रस्तुतियों से स्लाइड्स को कैसे संयोजित किया जाए जबकि आपके पसंदीदा स्लाइड लेआउट को लागू किया जाए, ताकि एक आउटपुट प्रस्तुति प्राप्त हो:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

{{% alert title="Note" color="warning" %}} 

आप विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 

{{% /alert %}}

विभिन्न स्लाइड आकारों वाली 2 प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुति का आकार बदलना होगा ताकि वह दूसरी प्रस्तुति के आकार से मेल खाए। 

यह नमूना कोड वर्णित ऑपरेशन को दर्शाता है:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

यह PHP कोड दिखाता है कि एक विशिष्ट स्लाइड को प्रस्तुति के एक सेक्शन में कैसे मर्ज किया जाए:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

स्लाइड सेक्शन के अंत में जोड़ी जाती है। 

## **संदर्भ देखें**


Aspose एक [FREE Online Collage Maker](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मर्ज कर सकते हैं, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, और अधिक। 

[Aspose FREE Online Merger](https://products.aspose.app/slides/hi/merger) देखें। यह समान फ़ॉर्मैट (जैसे PPT से PPT, PPTX से PPTX) या विभिन्न फ़ॉर्मैट (जैसे PPT से PPTX, PPTX से ODP) में PowerPoint प्रस्तुतियों को मर्ज करने की अनुमति देता है।

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/hi/merger)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या प्रस्तुतियों को मर्ज करते समय स्लाइडों की संख्या पर कोई सीमाएँ हैं?**

कोई कड़ी सीमाएँ नहीं हैं। Aspose.Slides बड़ी फ़ाइलों को संभाल सकता है, लेकिन प्रदर्शन फ़ाइल के आकार और सिस्टम संसाधनों पर निर्भर करता है। बहुत बड़ी प्रस्तुतियों के लिए 64‑bit JVM का उपयोग करने और पर्याप्त हीप मेमोरी आवंटित करने की सलाह दी जाती है।

**क्या मैं प्रस्तुतियों को एम्बेडेड वीडियो या ऑडियो के साथ मर्ज कर सकता हूँ?**

हां, Aspose.Slides स्लाइड्स में एम्बेडेड मल्टीमीडिया कंटेंट को संरक्षित रखता है, लेकिन अंतिम प्रस्तुति काफी बड़ी हो सकती है।

**क्या प्रस्तुतियों को मर्ज करते समय फ़ॉन्ट्स संरक्षित रहेंगे?**

हां। स्रोत प्रस्तुतियों में उपयोग किए गए फ़ॉन्ट्स आउटपुट फ़ाइल में संरक्षित रहते हैं, बशर्ते वे सिस्टम पर इंस्टॉल हों या [embedded](/slides/hi/php-java/embedded-font/) हों।
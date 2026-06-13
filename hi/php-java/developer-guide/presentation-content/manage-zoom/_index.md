---
title: PHP में प्रेजेंटेशन ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/php-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ़्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें PPT, PPTX और ODP प्रेजेंटेशनों में।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति की विशिष्ट स्लाइड्स, सेक्शन्स और हिस्सों के बीच जल्दी से कूदने की अनुमति देता है। जब आप प्रस्तुति दे रहे हों, तो सामग्री के बीच तेज़ी से नेविगेट करने की यह क्षमता बहुत उपयोगी साबित हो सकती है। 

![overview_image](overview.png)

* पूरे प्रस्तुतीकरण को एक ही स्लाइड पर सारांशित करने के लिए, एक [सारांश ज़ूम](#Summary-Zoom) का उपयोग करें।
* केवल चयनित स्लाइड्स दिखाने के लिए, एक [स्लाइड ज़ूम](#Slide-Zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [सेक्शन ज़ूम](#Section-Zoom) का उपयोग करें।

## **स्लाइड ज़ूम**
एक स्लाइड ज़ूम आपके प्रस्तुतीकरण को अधिक गतिशील बना सकता है, जिससे आप अपनी पसंद के किसी भी क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं, बिना प्रस्तुतीकरण के प्रवाह में बाधा डाले। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए उत्कृष्ट हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप इन्हें विभिन्न प्रस्तुतीकरण परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के हिस्सों में गहराई से जाने में मदद करते हैं जबकि आप ऐसा महसूस करते हैं कि आप एक ही कैनवास पर हैं। 

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zoomimagetype/) enumeration, [ZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास के तहत कुछ मेथड्स प्रदान करता है।

### **ज़ूम फ्रेम बनाएं**

आप एक स्लाइड पर ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनसे आप ज़ूम फ्रेम को लिंक करने का इरादा रखते हैं। 
3.	बनी हुई स्लाइड्स में एक पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड्स के रेफ़रेंस सहित) जोड़ें।
5.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड्स जोड़ता है
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # तीसरी स्लाइड के लिए बैकग्राउंड बनाता है
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame ऑब्जेक्ट्स जोड़ता है
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**
Aspose.Slides for PHP via Java के साथ, आप एक अलग स्लाइड प्रीव्यू इमेज के साथ ज़ूम फ्रेम इस प्रकार बना सकते हैं:
1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं जिससे आप ज़ूम फ्रेम को लिंक करना चाहते हैं। 
3.	स्लाइड में एक पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसके लिए आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़ते हैं, जिसका उपयोग फ्रेम को भरने के लिए किया जाएगा।
5.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड के रेफ़रेंस सहित) जोड़ें।
6.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में एक नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ZoomFrame ऑब्जेक्ट जोड़ता है
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ज़ूम फ्रेम को फॉर्मेट करें**
पहले के अनुभागों में हमने आपको सरल ज़ूम फ्रेम बनाने का तरीका दिखाया था। अधिक जटिल ज़ूम फ्रेम बनाने के लिए, आपको एक सरल फ्रेम के फॉर्मेट को बदलना होगा। ज़ूम फ्रेम पर आप कई फॉर्मेटिंग विकल्प लागू कर सकते हैं। 

आप स्लाइड पर ज़ूम फ्रेम के फॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनसे आप ज़ूम फ्रेम को लिंक करने का इरादा रखते हैं। 
3.	बनी हुई स्लाइड्स में कुछ पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड्स के रेफ़रेंस सहित) जोड़ें।
5.	एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसके लिए आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़ते हैं, जिसका उपयोग फ्रेम को भरने के लिए किया जाएगा।
6.	पहले ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
8.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
5.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड्स जोड़ता है
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # तीसरी स्लाइड के लिए बैकग्राउंड बनाता है
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame ऑब्जेक्ट्स जोड़ता है
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
    $zoomFrame1->setImage($picture);
    # zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फॉर्मेट सेट करता है
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # zoomFrame2 ऑब्जेक्ट के लिए बैकग्राउंड न दिखाने की सेटिंग
    $zoomFrame2->setShowBackground(false);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सेक्शन ज़ूम**

सेक्शन ज़ूम आपके प्रस्तुतीकरण में किसी सेक्शन का लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शन्स पर वापस जाने के लिए कर सकते हैं जिन्हें आप विशेष रूप से ज़ोर देना चाहते हैं। या आप उन्हें यह दर्शाने के लिए उपयोग कर सकते हैं कि आपके प्रस्तुतीकरण के कुछ हिस्से कैसे जुड़े हुए हैं। 

![overview_image](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास के तहत कुछ मेथड्स प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाएं**

आप एक स्लाइड पर सेक्शन ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं। 
3.	बनी हुई स्लाइड में एक पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम को लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame ऑब्जेक्ट जोड़ता है
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

Aspose.Slides for PHP via Java के साथ, आप एक अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम इस प्रकार बना सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनी हुई स्लाइड में एक पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम को लिंक करना चाहते हैं। 
5.	एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसके लिए आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़ते हैं, जिसका उपयोग फ्रेम को भरने के लिए किया जाएगा।
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # SectionZoomFrame ऑब्जेक्ट जोड़ता है
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **सेक्शन ज़ूम फ्रेम को फॉर्मेट करें**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए, आपको एक सरल फ्रेम के फॉर्मेट को बदलना होगा। सेक्शन ज़ूम फ्रेम पर आप कई फॉर्मेटिंग विकल्प लागू कर सकते हैं। 

आप स्लाइड पर सेक्शन ज़ूम फ्रेम के फॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनी हुई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम को लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6.	बने हुए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7.	एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसके लिए आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़ते हैं, जिसका उपयोग फ्रेम को भरने के लिए किया जाएगा।
8.	बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक किए गए सेक्शन से मूल स्लाइड पर वापस लौटने* की क्षमता सेट करें। 
10.	सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame ऑब्जेक्ट जोड़ता है
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrame के लिए फॉर्मेटिंग
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज जैसा होता है जहाँ आपके प्रस्तुतीकरण के सभी हिस्से एक साथ प्रदर्शित होते हैं। जब आप प्रस्तुति दे रहे हों, तो आप ज़ूम का उपयोग करके प्रस्तुतीकरण के एक हिस्से से दूसरे हिस्से में किसी भी क्रम में जा सकते हैं। आप रचनात्मक हो सकते हैं, आगे स्किप कर सकते हैं, या अपनी स्लाइड शो के टुकड़े फिर से देख सकते हैं बिना प्रस्तुतीकरण के प्रवाह को बाधित किए।

![overview_image](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomsectioncollection/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास के तहत कुछ मेथड्स प्रदान करता है।

### **सारांश ज़ूम बनाएं**

आप एक स्लाइड पर सारांश ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	पहले स्लाइड्स के लिए पहचान बैकग्राउंड और नए सेक्शन के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 2", $slide);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 3", $slide);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 4", $slide);
    # SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

सारांश ज़ूम फ्रेम में सभी सेक्शन [SummaryZoomSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomsection/) ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं, जो [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomsectioncollection/) ऑब्जेक्ट में संग्रहीत होते हैं। आप [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomsectioncollection/) क्लास के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को जोड़ या हटा सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	पहले स्लाइड्स के लिए पहचान बैकग्राउंड और नए सेक्शन के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	प्रस्तुतीकरण में एक नई स्लाइड और सेक्शन जोड़ें।
5.	बना हुआ सेक्शन सारांश ज़ूम फ्रेम में जोड़ें।
6.	सारांश ज़ूम फ्रेम से पहली सेक्शन हटाएँ।
7.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Summary Zoom में एक सेक्शन जोड़ता है
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Summary Zoom से सेक्शन हटाता है
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **सारांश ज़ूम सेक्शन को फॉर्मेट करें**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए, आपको एक सरल फ्रेम के फॉर्मेट को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर आप कई फॉर्मेटिंग विकल्प लागू कर सकते हैं। 

आप सारांश ज़ूम फ्रेम में सारांश ज़ूम सेक्शन ऑब्जेक्ट के फॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.	पहले स्लाइड्स के लिए पहचान बैकग्राउंड और नए सेक्शन के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	`SummaryZoomSectionCollection` से पहले ऑब्जेक्ट के लिए एक सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
7.	एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, जिसके लिए आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़ते हैं, जिसका उपयोग फ्रेम को भरने के लिए किया जाएगा।
8.	बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक किए गए सेक्शन से मूल स्लाइड पर वापस लौटने* की क्षमता सेट करें। 
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```php
  $pres = new Presentation();
  try {
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 1", $slide);
    # प्रस्तुति में नई स्लाइड जोड़ता है
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # प्रस्तुति में नया सेक्शन जोड़ता है
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # पहला SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # SummaryZoomSection ऑब्जेक्ट के लिए फॉर्मेटिंग
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # प्रस्तुति को सहेजता है
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर वापस लौटने को नियंत्रित कर सकता हूँ?**

हाँ। [Zoom frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sectionzoomframe/) में `ReturnToParent` व्यवहार है, जिसे सक्षम करने पर दर्शकों को लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस ले जाता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ज़ूम आपको `TransitionDuration` सेट करने की अनुमति देता है जिससे आप एनिमेशन की अवधि को नियंत्रित कर सकते हैं।

**क्या प्रस्तुतीकरण में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ीकृत कोई कठोर API सीमा नहीं है। व्यावहारिक सीमाएँ संपूर्ण प्रस्तुतीकरण की जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय को ध्यान में रखें।
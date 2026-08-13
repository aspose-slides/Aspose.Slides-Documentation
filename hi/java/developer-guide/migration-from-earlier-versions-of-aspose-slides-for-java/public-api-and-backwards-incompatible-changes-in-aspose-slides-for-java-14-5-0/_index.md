---
title: Aspose.Slides for Java 14.5.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides Java 14.5.0 के लिए
type: docs
weight: 40
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- स्थलांतर
- पुराना कोड
- आधुनिक कोड
- परम्परागत तरीका
- आधुनिक तरीका
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और तोड़ने वाले बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ Aspose.Slides for Java 14.5.0 API के साथ प्रस्तुत किए गए सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, किसी भी नई [पाबंदियों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API और बैकवर्ड असंगत परिवर्तन**
### **जोड़ी गई क्लास और मेथड**
#### **Aspose.Slides.IPresentationInfo इंटरफ़ेस और PresentationInfo क्लास जोड़ी गई**
प्रेजेंटेशन के बारे में जानकारी का प्रतिनिधित्व करता है।

मेथड Boolean isEncrypted() प्रेजेंटेशन एन्क्रिप्टेड होने पर True लौटाता है, अन्यथा False।

मेथड LoadFormat getLoadFormat() प्रेजेंटेशन प्रकार प्राप्त करता है।

#### **Aspose.Slides.IShape.isGrouped() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShape.isGrouped() निर्धारित करता है कि आकार समूहित है या नहीं।

#### **Aspose.Slides.IShape.getParentGroup() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShape.getParentGroup() यदि आकार समूहित है तो पैरेंट GroupShape ऑब्जेक्ट लौटाता है। अन्यथा null लौटाता है।

#### **Aspose.Slides.IShapeCollection.addGroupShape() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.addGroupShape() एक नया GroupShape बनाता है और उसे कलेक्शन के अंत में जोड़ता है।

नया आकार GroupShape में जोड़े जाने पर फ्रेम आकार और स्थिति सामग्री के अनुसार समायोजित हो जाएगी।

#### **Aspose.Slides.IShapeCollection.clear() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.clear() कलेक्शन से सभी आकारों को हटाता है।

#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.insertGroupShape(int) एक नया GroupShape बनाता है और निर्दिष्ट इंडेक्स पर कलेक्शन में डालता है।
नया आकार GroupShape में जोड़े जाने पर फ्रेम आकार और स्थिति सामग्री के अनुसार समायोजित हो जाएगी।

#### **IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) मेथड जोड़ी गई**
ये मेथड डेवलपर्स को पूरी प्रेजेंटेशन लोड किए बिना प्रेजेंटेशन फ़ाइल/स्ट्रीम की जानकारी प्राप्त करने की अनुमति देते हैं।

#### **IPresentationFactory PresentationFactory.getInstance() मेथड जोड़ी गई**
इन्स्टैंसिएशन के बिना फ़ैक्ट्री कार्यक्षमता का उपयोग करने की अनुमति देता है।

### **पाबंदियाँ**
#### **IShape.getFrame() के लिए अपरिभाषित मानों के उपयोग पर पाबंदियाँ जोड़ी गई**
कोड जो IShape.setFrame(IShapeFrame) को अपरिभाषित फ्रेम असाइन करने की कोशिश करता है, सामान्य मामलों में अर्थहीन है (विशेषकर जब पैरेंट GroupShape कई स्तरों में नेस्टेड हों {{GroupShape}}s). उदाहरण के लिए:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // एक ArgumentException फेंकेगा: फ्रेम मानों को परिभाषित किया जाना चाहिए।
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

या

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // एक ArgumentException फेंकेगा: x, y, width और height मानों को परिभाषित किया जाना चाहिए।
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

ऐसा कोड अस्पष्ट स्थितियों को जन्म दे सकता है। इसलिए IShape.Frame के लिए अपरिभाषित मानों के उपयोग पर पाबंदियाँ लागू की गई हैं। x, y, width, height, flipH, flipV और rotationAngle के मान परिभाषित होने चाहिए (Float.NaN या NullableBool.NotDefined नहीं)। ऊपर दिया गया उदाहरण कोड अब ArgumentException फेंकेगा।
यह निम्न उपयोग मामलों पर लागू होता है:

``` java
// IShape.setFrame(IShapeFrame) को पास किया गया फ्रेम अपरिभाषित मान नहीं रख सकता.

// x, y, width और height पैरामीटर निम्नलिखित IShapeCollection मेथड्स के
// Float.NaN नहीं हो सकते:

//
    addAudioFrameCD
    addAudioFrameEmbedded
    addAudioFrameLinked
    addAutoShape
    addChart
    addConnector
    addOleObjectFrame
    addPictureFrame
    addSmartArt
    addTable
    addVideoFrame
    insertAudioFrameEmbedded
    insertAudioFrameLinked
    insertAutoShape
    insertChart
    insertConnector
    insertOleObjectFrame
    insertPictureFrame
    insertTable
    insertVideoFrame
```

हालाँकि IShape.getRawFrame() फ्रेम अपरिभाषित हो सकता है। यह तब समझ में आता है जब आकार किसी प्लेसहोल्डर से लिंक्ड हो। तब अपरिभाषित आकार फ्रेम मान पैरेंट प्लेसहोल्डर आकार से ओवरराइड हो जाते हैं। यदि उस आकार के लिए कोई पैरेंट प्लेसहोल्डर नहीं है तो यह IShape.getRawFrame() के आधार पर प्रभावी फ्रेम का मूल्यांकन करते समय डिफ़ॉल्ट मानों का उपयोग करता है। डिफ़ॉल्ट मान x, y, width, height, flipH, flipV और rotationAngle के लिए क्रमशः 0 और NullableBool.False होते हैं। उदाहरण के लिए:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // आकार एक प्लेसहोल्डर से जुड़ा हुआ है।
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // अब आकार x, y, height, flipH और flipV मानों को प्लेसहोल्डर से विरासत में लेता है
    // और width = 100 तथा rotationAngle = 0 को ओवरराइड करता है।
} finally {
    if (pres != null) pres.dispose();
}
```

### **बदले गए प्रॉपर्टी**
#### **Aspose.Slides.IShapeCollection.getParent() मेथड के प्रकार और नाम में बदलाव**
Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का प्रकार ISlideComponent से नया IGroupShape इंटरफ़ेस में बदल दिया गया है। IGroupShape इंटरफ़ेस ISlideComponent की डेरिवेटिव है इसलिए मौजूदा कोड को कोई अनुकूलन नहीं करना पड़ेगा।

Aspose.Slides.IShapeCollection.getParent() मेथड का नाम getParent से बदलकर getParentGroup() कर दिया गया है।

#### **Aspose.Slides.IShapeFrame.getFlipH() और .getFlipV() मेथड के प्रकार में बदलाव**
Aspose.Slides.IShapeFrame.getFlipH() मेथड का प्रकार bool से NullableBool में बदल दिया गया है।

मेथड IShape.getFrame() IShapeFrame का प्रभावी इंस्टेंस लौटाता है (सभी प्रॉपर्टी के पास परिभाषित प्रभावी मान होते हैं)।

मेथड IShape.getRawFrame() IShapeFrame का इंस्टेंस लौटाता है जिसमें प्रत्येक प्रॉपर्टी का मान अपरिभाषित हो सकता है (विशेषकर FlipH या FlipV का मान NullableBool.NotDefined हो सकता है)।
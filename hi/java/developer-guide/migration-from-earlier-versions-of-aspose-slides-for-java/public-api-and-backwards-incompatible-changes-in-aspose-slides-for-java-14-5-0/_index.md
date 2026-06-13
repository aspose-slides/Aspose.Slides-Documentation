---
title: Aspose.Slides for Java 14.5.0 में सार्वजनिक API और अनुकूलन-व्यापी असंगत परिवर्तन
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- स्थलांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टूटने वाले परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ Aspose.Slides for Java 14.5.0 API के साथ प्रस्तुत किए गए सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, नए [पाबंदियों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) और अन्य [परिवर्तनों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API और अनुकूलन-व्यापी असंगत परिवर्तन**
### **जोड़े गए क्लास और मेथड**
#### **Aspose.Slides.IPresentationInfo इंटरफ़ेस और PresentationInfo क्लास जोड़े गए**
प्रेजेंटेशन के बारे में जानकारी का प्रतिनिधित्व करता है।

Method Boolean isEncrypted() प्रेजेंटेशन एन्क्रिप्टेड होने पर True लौटाता है, अन्यथा False।

Method LoadFormat getLoadFormat() प्रेजेंटेशन प्रकार प्राप्त करता है।
#### **Aspose.Slides.IShape.isGrouped() मेथड जोड़ा गया**
Method Aspose.Slides.IShape.isGrouped() निर्धारित करता है कि शेप ग्रुप किया गया है या नहीं।
#### **Aspose.Slides.IShape.getParentGroup() मेथड जोड़ा गया**
Method Aspose.Slides.IShape.getParentGroup() यदि शेप ग्रुप किया गया हो तो पैरेंट GroupShape ऑब्जेक्ट लौटाता है। अन्यथा null लौटाता है।
#### **Aspose.Slides.IShapeCollection.addGroupShape() मेथड जोड़ा गया**
Method Aspose.Slides.IShapeCollection.addGroupShape() नया GroupShape बनाता है और संग्रह के अंत में जोड़ता है।

जब नया शेप GroupShape में जोड़ा जाएगा तो GroupShape का फ्रेम आकार और स्थिति कंटेंट के अनुसार फिट हो जाएगी।
#### **Aspose.Slides.IShapeCollection.clear() मेथड जोड़ा गया**
Method Aspose.Slides.IShapeCollection.clear() संग्रह से सभी शेप को हटा देता है।
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) मेथड जोड़ा गया**
Method Aspose.Slides.IShapeCollection.insertGroupShape(int) नया GroupShape बनाता है और निर्दिष्ट इंडेक्स पर संग्रह में डालता है।
GroupShape का फ्रेम आकार और स्थिति कंटेंट के अनुसार फिट हो जाएगी जब नया शेप GroupShape में जोड़ा जाएगा।
#### **IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) मेथड जोड़े गए**
ये मेथड डेवलपर्स को पूरे प्रेजेंटेशन को लोड किए बिना फाइल/स्ट्रीम की जानकारी प्राप्त करने की अनुमति देते हैं।
#### **IPresentationFactory PresentationFactory.getInstance() मेथड जोड़ा गया**
फ़ैक्टरी कार्यक्षमता को इंस्टैंसिएशन के बिना उपयोग करने की अनुमति देता है।
### **पाबंदियां**
#### **IShape.getFrame() के लिए परिभाषित न किए गए मानों के उपयोग पर पाबंदियां जोड़ी गईं**
Code that attempts to assign an undefined frame to IShape.setFrame(IShapeFrame) doesn't make sense in general cases (particularly when the parent GroupShape is multiple nested into other {{GroupShape}}s). For example:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Such code can lead to unclear situations. So restrictions have been added for using undefined values for IShape.Frame. The values of x, y, width, height, flipH, flipV and rotationAngle must be defined (not Float.NaN or NullableBool.NotDefined). The example code above now throws an ArgumentException exception.
This applies to these use cases:

``` java

 IShape shape = ...;

shape.setFrame(...); // अपरिभाषित नहीं हो सकता

IShapeCollection shapes = ...;

// x, y, width, height पैरामीटर Float.NaN नहीं हो सकते:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

But the IShape.getRawFrame() frame can be undefined. This make sense when a shape is linked to a placeholder. Then undefined shape frame values are overridden from the parent placeholder shape. If there is no parent placeholder shape for that shape then it uses default values when it evaluates effective frame based on its IShape.getRawFrame(). Default values are 0 and NullableBool.False for x, y, width, height, flipH, flipV and rotationAngle. For example:

``` java

 IShape shape = ...; // shape प्लेसहोल्डर से जुड़ा है

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// अब shape प्लेसहोल्डर से x, y, height, flipH, flipV मान इनहेरिट करता है और width=100 तथा rotationAngle=0 को ओवरराइड करता है।

```
### **परिवर्तित प्रॉपर्टीज़**
#### **Aspose.Slides.IShapeCollection.getParent() मेथड का प्रकार और नाम बदल दिया गया**
Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का प्रकार ISlideComponent से नया IGroupShape इंटरफ़ेस कर दिया गया है। IGroupShape इंटरफ़ेस ISlideComponent का उत्तराधिकारी है इसलिए मौजूदा कोड को कोई अनुकूलन नहीं चाहिए।

Aspose.Slides.IShapeCollection.getParent() मेथड का नाम getParent से बदलकर getParentGroup() कर दिया गया है।
#### **Aspose.Slides.IShapeFrame.getFlipH() और .getFlipV() मेथड का प्रकार बदल दिया गया**
Aspose.Slides.IShapeFrame.getFlipH() मेथड का प्रकार bool से NullableBool में बदल दिया गया है।

IShape.getFrame() मेथड IShapeFrame का प्रभावी इंस्टेंस लौटाता है (जिसकी सभी प्रॉपर्टी के परिभाषित प्रभावी मान होते हैं)।

IShape.getRawFrame() मेथड IShapeFrame का ऐसा इंस्टेंस लौटाता है जिसमें प्रत्येक प्रॉपर्टी का मान अपरिभाषित हो सकता है (विशेष रूप से FlipH या FlipV का मान NullableBool.NotDefined हो सकता है)।
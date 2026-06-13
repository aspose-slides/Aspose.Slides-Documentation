---
title: Aspose.Slides for Java 14.7.0 में सार्वजनिक API और पीछे की असंगत परिवर्तन
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- स्थानांतरण
- पुराना कोड
- आधुनिक कोड
- परम्परागत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से स्थानांतरित कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) वर्गों, विधियों, गुणों आदि की सूची देता है, साथ ही नई प्रतिबंधों और Aspose.Slides for Java 14.7.0 API द्वारा प्रस्तुत किए गए अन्य परिवर्तन।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **कुछ TransitionValueBase उपप्रकारों के कंस्ट्रक्टर हटाए गए हैं और TransitionValueFactory को हटाया गया है**
कुछ TransitionValueBase उपप्रकारों (विशेष रूप से CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) के कंस्ट्रक्टर सार्वजनिक API में बेकार हैं और इसलिए हटा दिए गए हैं। संबंधित क्लास TransitionValueFactory और उसका इंटरफ़ेस ITransitionValueFactory भी उसी कारण से हटाए गए हैं।
### **Element SoundAction को com.aspose.slides.TransitionType enumeration से हटा दिया गया है**
Element SoundAction गलत था और उपयोग नहीं किया गया। ध्वनि सेटिंग्स SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName प्रॉपर्टीज़ द्वारा परिभाषित की जाती हैं।
### **FlyThroughTransition क्लास और IFlyThroughTransition इंटरफ़ेस जोड़े गए हैं**
com.aspose.slides.FlyThroughTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.IFlyThroughTransition) ट्रांज़िशन प्रकार Flythrough से संबंधित है जो इस रिलीज़ में समर्थित है।
### **GlitterTransition क्लास, IGlitterTransition इंटरफ़ेस और TransitionPattern enumeration जोड़े गए हैं**
com.aspose.slides.GlitterTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.IGlitterTransition) ट्रांज़िशन प्रकार Glitter से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionPattern enumeration इस क्लास में उपयोग की जाती है और बड़े क्षेत्र को भरने के लिए एक ज्यामितीय पैटर्न निर्धारित करती है।
### **LeftRightDirectionTransition क्लास, ILeftRightDirectionTransition इंटरफ़ेस और TransitionLeftRightDirectionType enumeration जोड़े गए हैं**
com.aspose.slides.LeftRightDirectionTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.ILeftRightDirectionTransition) ट्रांज़िशन प्रकार Switch, Flip, Ferris, Gallery, Conveyor से संबंधित है जो इस रिलीज़ में समर्थित हैं। com.aspose.slides.TransitionLeftRightDirectionType enumeration इस क्लास में उपयोग की जाती है और दिशा को केवल left और right तक सीमित करती है।
### **com.aspose.slides.TransitionType enumeration में नए तत्व जोड़े गए हैं**
com.aspose.slides.TransitionType enumeration को नए तत्वों के साथ विस्तारित किया गया है। नई PowerPoint 2010 ट्रांज़िशन से संबंधित तत्व: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse। नई PowerPoint 2013 ट्रांज़िशन से संबंधित तत्व: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami।
### **RevealTransition क्लास और IRevealTransition इंटरफ़ेस जोड़े गए हैं**
com.aspose.slides.RevealTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.IRevealTransition) ट्रांज़िशन प्रकार Reveal से संबंधित है जो इस रिलीज़ में समर्थित है।
RippleTransition क्लास, IRippleTransition इंटरफ़ेस और TransitionCornerAndCenterDirectionType enumeration जोड़े गए हैं
com.aspose.slides.RippleTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.IRippleTransition) ट्रांज़िशन प्रकार Ripple से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionCornerAndCenterDirectionType enumeration इस क्लास में उपयोग की जाती है और दिशा को केवल कोनों और केंद्र तक सीमित करती है।
### **ShredTransition क्लास, IShredTransition इंटरफ़ेस और TransitionShredPattern enumeration जोड़े गए हैं**
com.aspose.slides.ShredTransition क्लास (और उसका इंटरफ़ेस com.aspose.slides.IShredTransition) ट्रांज़िशन प्रकार Shred से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionShredPattern enumeration इस क्लास में उपयोग की जाती है और बड़े क्षेत्र को भरने के लिए एक ज्यामितीय आकार निर्धारित करती है।
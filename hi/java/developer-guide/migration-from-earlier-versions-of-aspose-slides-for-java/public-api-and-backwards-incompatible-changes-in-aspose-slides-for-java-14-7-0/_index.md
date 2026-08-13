---
title: Aspose.Slides for Java 14.7.0 में सार्वजनिक API और अनुकूल नहीं रहने वाले परिवर्तन
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- स्थानांतरण
- पुरानी कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और तोड़‑फोड़ वाले परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 
यह पृष्ठ सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) वर्ग, मेथड, प्रॉपर्टी आदि, साथ ही Aspose.Slides for Java 14.7.0 API के साथ प्रस्तुत किए गए किसी भी नए प्रतिबंध और अन्य परिवर्तनों को सूचीबद्ध करता है।
{{% /alert %}} 
## **Public API Changes**
### **Constructors of the some TransitionValueBase subtypes have been removed and TransitionValueFactory has been removed**
कुछ TransitionValueBase उपप्रकारों (विशेषकर CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) के कंस्ट्रक्टर्स सार्वजनिक API में उपयोगी नहीं हैं और इसलिए हटा दिए गए हैं। संबंधित क्लास TransitionValueFactory और इसका इंटरफ़ेस ITransitionValueFactory भी समान कारण से हटाए गए हैं।
### **Element SoundAction has been removed from com.aspose.slides.TransitionType enumeration**
Element SoundAction गलत था और उपयोग नहीं किया जाता था। साउंड सेटिंग्स SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName प्रॉपर्टीज़ द्वारा परिभाषित किए जाते हैं।
### **FlyThroughTransition class and IFlyThroughTransition interface have been added**
com.aspose.slides.FlyThroughTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.IFlyThroughTransition) ट्रांज़िशन प्रकार Flythrough से संबंधित है जो इस रिलीज़ में समर्थित है।
### **GlitterTransition class, IGlitterTransition interface and TransitionPattern enumeration have been added**
com.aspose.slides.GlitterTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.IGlitterTransition) ट्रांज़िशन प्रकार Glitter से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionPattern एनीमरेशन इस क्लास में उपयोग किया जाता है और बड़े क्षेत्र को भरने के लिए टाइल करने वाले ज्यामितीय पैटर्न को निर्दिष्ट करता है।
### **LeftRightDirectionTransition class, ILeftRightDirectionTransition interface and TransitionLeftRightDirectionType enumeration have been added**
com.aspose.slides.LeftRightDirectionTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.ILeftRightDirectionTransition) ट्रांज़िशन प्रकार Switch, Flip, Ferris, Gallery, Conveyor से संबंधित है जो इस रिलीज़ में समर्थित हैं। com.aspose.slides.TransitionLeftRightDirectionType एनीमरेशन इस क्लास में उपयोग किया जाता है और बाएं और दाएं मानों तक सीमित दिशा को निर्दिष्ट करता है।
### **New elements have been added into com.aspose.slides.TransitionType enumeration**
com.aspose.slides.TransitionType एनीमरेशन में नए तत्व जोड़े गए हैं। 
नए तत्व नए PowerPoint 2010 ट्रांज़िशन से संबंधित हैं: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.  
नए तत्व नए PowerPoint 2013 ट्रांज़िशन से संबंधित हैं: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition class and IRevealTransition interface have been added**
com.aspose.slides.RevealTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.IRevealTransition) ट्रांज़िशन प्रकार Reveal से संबंधित है जो इस रिलीज़ में समर्थित है।  
RippleTransition क्लास, IRippleTransition इंटरफ़ेस और TransitionCornerAndCenterDirectionType एनीमरेशन जोड़े गए हैं।  
com.aspose.slides.RippleTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.IRippleTransition) ट्रांज़िशन प्रकार Ripple से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionCornerAndCenterDirectionType एनीमरेशन इस क्लास में उपयोग किया जाता है और कोनों और केंद्र तक सीमित दिशा को निर्दिष्ट करता है।
### **ShredTransition class, IShredTransition interface and TransitionShredPattern enumeration have been added**
com.aspose.slides.ShredTransition क्लास (और इसका इंटरफ़ेस com.aspose.slides.IShredTransition) ट्रांज़िशन प्रकार Shred से संबंधित है जो इस रिलीज़ में समर्थित है। com.aspose.slides.TransitionShredPattern एनीमरेशन इस क्लास में उपयोग किया जाता है और बड़े क्षेत्र को भरने के लिए टाइल करने वाले ज्यामितीय आकार को निर्दिष्ट करता है।
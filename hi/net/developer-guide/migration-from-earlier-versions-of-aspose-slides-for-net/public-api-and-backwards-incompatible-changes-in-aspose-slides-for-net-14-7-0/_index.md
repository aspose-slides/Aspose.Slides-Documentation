---
title: Aspose.Slides for .NET 14.7.0 में सार्वजनिक API और पिछले संस्करणों के साथ असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- माइग्रेशन
- पारंपरिक कोड
- आधुनिक कोड
- पारंपरिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) क्लासेस, मेथड्स, प्रॉपर्टी और अन्य चीज़ें, तथा Aspose.Slides for .NET 14.7.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **Public API Changes**
### **Removed Constructors and Elements**
#### **Removed Some TransitionValueBase Subtype Constructors and TransitionValueFactory**
कुछ TransitionValueBase उपप्रकार (विशेष रूप से CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) के कन्स्ट्रक्टर्स सार्वजनिक API में उपयोगी नहीं हैं और इसलिए हटा दिए गए हैं।

समान कारणों से संबंधित क्लास TransitionValueFactory और उसका इंटरफ़ेस ITransitionValueFactory भी हटा दिया गया है।
#### **Removed the SoundAction Element from the Aspose.Slides.SlideShow.TransitionType Enumeration**
SoundAction एलिमेंट गलत था और उपयोग नहीं किया जाता था। साउंड सेटिंग्स SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName प्रॉपर्टीज़ द्वारा परिभाषित होती हैं।
### **Added Classes and Interfaces**
#### **Added the FlyThroughTransition Class and IFlyThroughTransition Interface**
Aspose.Slides.SlideShow.FlyThroughTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IFlyThroughTransition) इस रिलीज़ में समर्थित Flythrough ट्रांज़िशन प्रकार से संबंधित है।
#### **Added the GlitterTransition Class, IGlitterTransition Interface and TransitionPattern Enumeration**
Aspose.Slides.SlideShow.GlitterTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IGlitterTransition) इस रिलीज़ में समर्थित Glitter ट्रांज़िशन प्रकार से संबंधित है।

Aspose.Slides.SlideShow.TransitionPattern एनेमरेशन इस क्लास में प्रयुक्त होता है और बड़े क्षेत्र को भरने के लिए एक साथ टाइल होने वाले ज्यामितीय पैटर्न को निर्दिष्ट करता है।
#### **Added the LeftRightDirectionTransition Class, ILeftRightDirectionTransition Interface and TransitionLeftRightDirectionType Enumeration**
Aspose.Slides.SlideShow.LeftRightDirectionTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.ILeftRightDirectionTransition) Conveyor, Ferris, Flip, Gallery और Switch ट्रांज़िशन प्रकारों से संबंधित है। सभी इस रिलीज़ में समर्थित हैं।

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType एनेमरेशन इस क्लास में प्रयुक्त होता है और दिशा को निर्दिष्ट करता है, जो केवल left और right मानों तक सीमित है।
#### **Added New Elements to the Aspose.Slides.SlideShow.TransitionType Enumeration**
Aspose.Slides.SlideShow.TransitionType एनेमरेशन में नए एलिमेंट जोड़े गए हैं।

- PowerPoint 2010 ट्रांज़िशन से संबंधित नए एलिमेंट: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- नए PowerPoint 2013 ट्रांज़िशन से संबंधित नए एलिमेंट: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Added the RevealTransition Class and IRevealTransition Interface**
Aspose.Slides.SlideShow.RevealTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IRevealTransition) इस रिलीज़ में समर्थित Reveal ट्रांज़िशन प्रकार से संबंधित है।
#### **Added the RippleTransition Class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
Aspose.Slides.SlideShow.RippleTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IRippleTransition) इस रिलीज़ में समर्थित Ripple ट्रांज़िशन प्रकार से संबंधित है।

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType एनेमरेशन इस क्लास में प्रयुक्त होता है और दिशा को निर्दिष्ट करता है, जो केवल कोनों और केंद्र तक सीमित है।
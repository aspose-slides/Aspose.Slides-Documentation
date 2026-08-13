---
title: Aspose.Slides for .NET 14.7.0 में सार्वजनिक API और पीछे की ओर गैर‑अनुकूल परिवर्तन
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- स्थलांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि, तथा Aspose.Slides for .NET 14.7.0 API के साथ पेश किए गए अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **पब्लिक API बदलाव**
### **हटाए गए कन्स्ट्रक्टर्स और एलिमेंट्स**
#### **कुछ TransitionValueBase सबटाइप कन्स्ट्रक्टर्स और TransitionValueFactory को हटाया गया**
कुछ TransitionValueBase सबटाइप्स (विशेष रूप से CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) के कन्स्ट्रक्टर्स पब्लिक API में बेकार थे, इसलिए इन्हें हटा दिया गया है। 

संबंधित क्लास TransitionValueFactory और उसका इंटरफ़ेस ITransitionValueFactory भी उसी कारण से हटा दिया गया है। 
#### **Aspose.Slides.SlideShow.TransitionType एन्न्यूमेरेशन से SoundAction एलिमेंट को हटाया गया**
SoundAction एलिमेंट गलत था और उपयोग में नहीं था। साउंड सेटिंग्स SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName प्रॉपर्टीज़ द्वारा परिभाषित की जाती हैं। 
### **जोड़े गए क्लासेस और इंटरफ़ेस**
#### **FlyThroughTransition क्लास और IFlyThroughTransition इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SlideShow.FlyThroughTransition क्लास (और इसका इंटरफ़ेस Aspose.Slides.SlideShow.IFlyThroughTransition) इस रिलीज़ से समर्थित Flythrough ट्रांज़िशन टाइप से संबंधित है। 
#### **GlitterTransition क्लास, IGlitterTransition इंटरफ़ेस और TransitionPattern एन्न्यूमेरेशन जोड़ी गई**
Aspose.Slides.SlideShow.GlitterTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IGlitterTransition) इस रिलीज़ से समर्थित Glitter ट्रांज़िशन टाइप से संबंधित है। 

Aspose.Slides.SlideShow.TransitionPattern एन्न्यूमेरेशन इस क्लास में उपयोग किया जाता है और यह एक ज्यामितीय पैटर्न दर्शाता है जो बड़े क्षेत्र को भरने के लिए टाइल्स की तरह जुड़ता है। 
#### **LeftRightDirectionTransition क्लास, ILeftRightDirectionTransition इंटरफ़ेस और TransitionLeftRightDirectionType एन्न्यूमेरेशन जोड़ी गई**
Aspose.Slides.SlideShow.LeftRightDirectionTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.ILeftRightDirectionTransition) ट्रांज़िशन टाइप्स Conveyor, Ferris, Flip, Gallery और Switch से संबंधित है। ये सभी इस रिलीज़ से समर्थित हैं। 

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType एन्न्यूमेरेशन इस क्लास में उपयोग किया जाता है और यह दिशा निर्दिष्ट करता है, जो केवल left और right मानों तक सीमित है। 
#### **Aspose.Slides.SlideShow.TransitionType एन्न्यूमेरेशन में नए एलिमेंट जोड़े गए**
Aspose.Slides.SlideShow.TransitionType एन्न्यूमेरेशन को नए एलिमेंट्स के साथ विस्तारित किया गया है। 

- PowerPoint 2010 ट्रांज़िशन से संबंधित नए एलिमेंट्स: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- PowerPoint 2013 ट्रांज़िशन से संबंधित नए एलिमेंट्स: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind. 
#### **RevealTransition क्लास और IRevealTransition इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SlideShow.RevealTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IRevealTransition) इस रिलीज़ से समर्थित Reveal ट्रांज़िशन टाइप से संबंधित है। 
#### **RippleTransition क्लास, IRippleTransition इंटरफ़ेस और TransitionCornerAndCenterDirectionType एन्न्यूमेरेशन जोड़ी गई**
Aspose.Slides.SlideShow.RippleTransition क्लास (और उसका इंटरफ़ेस Aspose.Slides.SlideShow.IRippleTransition) इस रिलीज़ से समर्थित Ripple ट्रांज़िशन टाइप से संबंधित है। 

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType एन्न्यूमेरेशन इस क्लास में उपयोग किया जाता है और यह दिशा निर्दिष्ट करता है, जो कॉर्नर और सेंट्र तक सीमित है।
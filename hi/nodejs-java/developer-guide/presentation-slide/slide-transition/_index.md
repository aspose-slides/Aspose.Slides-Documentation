---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/nodejs-java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ जावास्क्रिप्ट में स्लाइड ट्रांज़िशन को अनुकूलित करें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करने का तरीका समझाता है। यह दर्शाता है कि स्लाइड पर ट्रांज़िशन प्रकार कैसे लागू करें, ट्रांज़िशन व्यवहार (जैसे क्लिक पर आगे बढ़ना या निर्दिष्ट समय के बाद) कैसे कॉन्फ़िगर करें, स्वचालित आगे बढ़ने की जाँच और उसे निष्क्रिय करें, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करें, और ट्रांज़िशन इफ़ेक्ट विकल्प सेट करें। उदाहरण दिखाते हैं कि प्रस्तुति को लोड या बनाएं, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स को संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। लेख में ट्रांज़िशन गति, ट्रांज़िशन ध्वनियों, कई स्लाइड्स पर समान ट्रांज़िशन लागू करने, और स्लाइड पर वर्तमान में सेट ट्रांज़िशन की जाँच जैसे सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक साधारण स्लाइड ट्रांज़िशन प्रभाव बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) class.
2. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Node.js via Java through TransitionType enum
3. Write the modified presentation file.

```javascript
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का उदाहरण बनाएं
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // प्रस्तुति को डिस्क पर लिखें
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**
ऊपर के अनुभाग में हमने स्लाइड पर केवल एक साधारण ट्रांज़िशन इफ़ेक्ट लागू किया था। अब, इस साधारण इफ़ेक्ट को और बेहतर और नियंत्रित बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) class.
2. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for Node.js via Java
3. You can also set the transition to Advance On Click, after a specific time period or both.
4. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
5. Write the modified presentation as a presentation file.

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 3 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 5 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // 7 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **मॉर्फ़ ट्रांज़िशन**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java अब [Morph Transition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MorphTransition) का समर्थन करता है। यह PowerPoint 2019 में प्रस्तुत किया गया नया मॉर्फ़ ट्रांज़िशन दर्शाता है।

{{% /alert %}} 

The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of [morph type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TransitionType) to the second slide.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मॉर्फ़ ट्रांज़िशन प्रकार**
New [TransitionMorphType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TransitionMorphType) enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**
Aspose.Slides for Node.js via Java supports setting the transition effects like, from black, from left, from right etc. In order to set the Transition Effect. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
- Get the reference of the slide.
- Setting the transition effect.
- Write the presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

In the example given below, we have set the transition effects.

```javascript
// Presentation क्लास का एक उदाहरण बनाएं
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // इफ़ेक्ट सेट करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // प्रस्तुति को डिस्क पर लिखें
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की पलेबैक गति नियंत्रित कर सकता हूँ?**

Yes. Set the transition’s [speed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setspeed/) using the [TransitionSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionspeed/) setting (e.g., slow/medium/fast).

**क्या मैं ट्रांज़िशन में ऑडियो जोड़ सकता हूँ और उसे लूप कर सकता हूँ?**

Yes. You can embed a sound for the transition and control behavior via settings like sound mode and looping (e.g., [setSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), plus metadata such as [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) and [setSoundName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

Configure the desired transition type on each slide’s transition settings; transitions are stored per slide, so applying the same type across all slides gives a consistent result.

**मैं कैसे जांच सकता हूँ कि वर्तमान में स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

Inspect the slide’s [transition settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) and read its [transition type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/gettype/); that value tells you exactly which effect is applied.
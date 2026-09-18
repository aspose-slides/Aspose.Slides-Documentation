---
title: जावा में कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/java/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- मोशन पाथ
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में कस्टम एनीमेशन व्यवहार और संपादन योग्य मोशन पाथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **परिचय**

कस्टम एनीमेशन व्यवहार आपको एनीमेशन प्रभाव के भीतर व्यक्तिगत संचालन को नियंत्रित करने की अनुमति देते हैं, जैसे रंग बदलना, आकार को घूर्णन करना, या एक संपादनीय मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि व्यवहारों को कैसे बनाएं और संयोजित करें, उनका समय कैसे कॉन्फ़िगर करें, मौजूदा एनीमेशन को कैसे निरीक्षण और संशोधित करें, और यह सत्यापित करें कि उनके गुण सहेजने और प्रस्तुति को फिर से खोलने के बाद भी बने रहते हैं।

प्रीडिफ़ाइंड इफ़ेक्ट्स और क्लिक ट्रिगर्स के लिए देखें [आकार एनीमेशन](/slides/hi/java/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एनीमेशन का क्रम **टाइमलाइन → सीक्वेंस → इफ़ेक्ट → व्यवहार** है:

- [getTimeline](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getTimeline--) मेथड स्लाइड टाइमलाइन लौटाता है, जिसमें मुख्य सीक्वेंस और इंटरैक्टिव सीक्वेंस होते हैं।
- एक [ISequence](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/) में इफ़ेक्ट्स होते हैं, जो विभिन्न आकारों को लक्षित कर सकते हैं।
- एक [IEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/) लक्ष्य आकार, प्रीसेट, सबटाइप और इफ़ेक्ट टाइमिंग की पहचान करता है।
- [IEffect.getBehaviors](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getBehaviors--) द्वारा लौटाई गई कलेक्शन उन ऑपरेशन्स को रखती है जो इफ़ेक्ट को लागू करती हैं: रंग बदलना, स्थानांतरित करना, घूर्णन करना, गुण सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

एक इफ़ेक्ट बनाने और [getBehaviors](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getBehaviors--) कलेक्शन तक पहुँचने के लिए [ISequence.addEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) को कॉल करें। एक प्रीसेट इस कलेक्शन को स्वचालित रूप से भर सकता है। प्रीसेट का विस्तार करते समय इसके ऑपरेशन्स रखिए, या जानबूझकर उन्हें बदलते समय [clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/#clear--) का उपयोग करें।

[IBehaviorFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/) नीचे दिखाए गए आठ व्यवहार प्रकार बना सकता है। मोशन को [एक मोशन पाथ बनाएं](#build-a-motion-path) अनुभाग में कवर किया गया है। प्रत्येक स्निपेट में उसके इम्पोर्ट्स शामिल हैं; निष्पादन योग्य स्टेटमेंट्स को किसी मेथड के अंदर रखें। बाद के संपादन उदाहरण बताते हैं कि वे कौन से आउटपुट फ़ाइल का उपयोग करते हैं।

### **घूर्णन**

घूर्णन बनाने के लिए [createRotationEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) का उपयोग करें। [getBy](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irotationeffect/#getBy--) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [getFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irotationeffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irotationeffect/#getTo--) समाप्त बिंदु निर्धारित करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू होता है, उसके प्रीसेट ऑपरेशन्स को एक घूर्णन व्यवहार से बदलता है, और उस ऑपरेशन को दो‑सेकंड की अवधि देता है। 90 डिग्री का सापेक्ष कोण आकार की प्रारम्भिक अभिविन्यास से एक चौथाई घुमाव दर्शाता है, इसलिए स्पष्ट प्रारम्भिक कोण की आवश्यकता नहीं होती।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` में एक आकार और एक घूर्णन व्यवहार है। नीचे के कलेक्शन, टाइमिंग और घूर्णन‑संपादन उदाहरण इस फ़ाइल का उपयोग करते हैं।

### **स्केल**

[X/Y प्रतिशत] के साथ [createScaleEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) का उपयोग करें: [getFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iscaleeffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iscaleeffect/#getTo--) प्रारम्भ और समाप्त आकार का वर्णन करते हैं, जबकि [getBy](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iscaleeffect/#getBy--) सापेक्ष परिवर्तन दर्शाता है। यहाँ 100 का अर्थ मूल आकार है।

उदाहरण दो सेकंड के भीतर दोनों आयामों को 100 % से 125 % तक बढ़ाता है। समान क्षैतिज और लंबवत प्रतिशत आकार के अनुपात को बनाए रखते हैं; अलग-अलग प्रतिशत एक आयाम को अधिक खींच देंगे।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **रंग**

भरण को नीले से नारंगी में बदलने के लिए [createColorEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) का उपयोग करें। [getFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icoloreffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icoloreffect/#getTo--) रंग हैं; [getBy](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icoloreffect/#getBy--) रंग ऑफ़सेट है। [IBehavior.getProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehavior/#getProperties--) एनीमेट किए जा रहे गुण की पहचान करता है।

आकार की ठोस भराई को नीला प्रारम्भिक रंग दिया गया है, जो एनीमेशन के प्रारम्भिक रंग से मेल खाता है। भराव‑रंग गुण चुनने से व्यवहार को पता चलता है कि किन हिस्से को बदलना है; केवल रंग समाप्त बिंदु यह निर्धारित नहीं करते। सहेजा गया इफ़ेक्ट दो‑सेकंड में नारंगी में परिवर्तन दर्शाता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **फ़िल्टर**

[createFilterEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) का प्रयोग करके एक वाइप चुनें। [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifiltereffect/#getSubtype--), और [getReveal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifiltereffect/#getReveal--) क्रमशः फ़िल्टर, दिशा, और आकार को प्रकट या छुपाने को निर्दिष्ट करते हैं।

यह उदाहरण दो‑सेकंड का वाइप कॉन्फ़िगर करता है जो दाएँ‑दिशा सबटाइप का उपयोग करके आकार को प्रकट करता है। फ़िल्टर सेटिंग्स इफ़ेक्ट के भीतर व्यवहार से संबंधित होती हैं, इसलिए प्रीसेट के मूल ऑपरेशन्स को हटाने के बाद इन्हें कॉन्फ़िगर किया जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **गुण (प्रॉपर्टी)**

[createPropertyEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) का उपयोग करके अपारदर्शिता (opacity) को एनीमेट करें। [getFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipropertyeffect/#getTo--), और [getBy](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipropertyeffect/#getBy--) स्ट्रिंग्स हैं जिन्हें क्रमशः [getValueType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipropertyeffect/#getValueType--) और [getCalcMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) के साथ व्याख्यायित किया जाता है। सभी तीन को एक साथ निर्दिष्ट करने के बजाय केवल समाप्त बिंदु या सापेक्ष ऑफ़सेट चुनें।

यहाँ चयनित गुण अपारदर्शिता है, और संख्यात्मक स्ट्रिंग्स 25 % अपारदर्शिता से पूर्ण अपारदर्शिता तक परिवर्तन दर्शाती हैं। रैखिक अंतरालीकरण इन मानों के बीच क्रमशः परिवर्तन को दर्शाता है। इस उदाहरण को किसी अन्य गुण पर लागू करते समय, उस गुण के अनुसार उपयुक्त मान प्रकार और समाप्त मान चुनें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सेट**

[createSetEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) का उपयोग करके [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iseteffect/#getTo--) द्वारा दृश्यता (visibility) असाइन करें। सेट व्यवहार समाप्त बिंदुओं के बीच अंतरण नहीं करता।

उदाहरण दृश्यता गुण को चुनता है और व्यवहार चलने पर स्ट्रिंग `visible` असाइन करता है। इस न्यूनतम प्रस्तुति में आयत पहले से ही दृश्यमान है, इसलिए यह असाइनमेंट अकेले स्पष्ट दृश्य परिवर्तन नहीं लाता। यह ऑपरेशन बड़े इफ़ेक्ट का हिस्सा बनाकर उपयोगी होता है जो आकार को छिपाने या दिखाने को भी नियंत्रित करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **कमांड**

[createCommandEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) का प्रयोग करें और [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icommandeffect/#getCommandString--), तथा [getShapeTarget](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icommandeffect/#getShapeTarget--) कॉन्फ़िगर करें। कार्य निर्देशिका में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [addAudioFrameEmbedded](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) से एम्बेड करता है और ऑडियो फ़्रेम पर प्ले कमांड जोड़ता है।

ऑडियो फ़्रेम इफ़ेक्ट का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; केवल कमांड स्ट्रिंग यह नहीं बताती कि कौन सी मीडिया ऑब्जेक्ट को नियंत्रित करना है। इफ़ेक्ट को स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

सहेजने पर कमांड `command.pptx` में संग्रहित होता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिए ऐसा स्लाइडशो प्लेयर चाहिए जो कमांड और उसके मीडिया लक्ष्य को सपोर्ट करे।

## **व्यवहार कलेक्शन का प्रबंधन**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/) [add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), और [removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) का समर्थन करता है। यह उदाहरण `rotation.pptx` खोलता है, स्केलिंग जोड़ता है, उसे घूर्णन से पहले रखता है, और घूर्णन को हटाता है। वही वस्तु को हटाकर और पुनः सम्मिलित करने से उसकी संग्रहीत स्थिति बदलती है, बिना प्रतिलिपि बनाए।

संपादन क्रम कलेक्शन को rotation–scale से scale–rotation, फिर केवल scale में बदल देता है। इंडेक्स वर्तमान कलेक्शन को दर्शाते हैं, इसलिए हटाने के समय घूर्णन का नया इंडेक्स उपयोग होता है। अंतिम गणना बताती है कि कौन सा व्यवहार सहेजा जाएगा।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग बची है। कलेक्शन क्रम स्वयं व्यवहारों को क्रम में चलाने का शेड्यूल नहीं बनाता। सभी ऑपरेशन्स को बदलते समय ही कलेक्शन को साफ़ करें।

## **व्यवहार टाइमिंग को कॉन्फ़िगर करें**

[IBehavior.getTiming](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehavior/#getTiming--) [ITiming](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/) को उजागर करता है, जो [IEffect.getTiming](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getTiming--) से स्वतंत्र है। इफ़ेक्ट टाइमिंग संलग्न इफ़ेक्ट को शेड्यूल करता है; व्यवहार टाइमिंग उसके भीतर की ऑपरेशन को।

### **अवधि, देरी, पुनरावृत्ति, और त्वरण सेट करें**

`rotation.pptx` खोलें और अवधि ([getDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getDuration--)) तथा ट्रिगर देरी ([getTriggerDelayTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) सेकंड में सेट करें, फिर [setRepeatCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#setRepeatCount-float-) से दोहराव संख्या निर्धारित करें। [getAccelerate](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getAccelerate--) और [getDecelerate](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getDecelerate--) अवधि के अंश होते हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जो घूर्णन उदाहरण में बनाई गई थी, जहाँ पहला व्यवहार घूर्णन है। यह उदाहरण केवल उस व्यवहार की टाइमिंग बदलता है; 90‑डिग्री का कोण वही रहता है। कोण और टाइमिंग को अलग रखने से गति को पुनः निर्मित किए बिना समायोजित करना आसान हो जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

व्यवहार दो‑सेकंड की अवधि, आधे‑सेकंड की देरी, और 3 की पुनरावृत्ति संख्या उपयोग करता है। इसकी अवधि के पहले और आखिरी 20 % क्रमशः त्वरण और मंदन के लिए उपयोग होते हैं।

अन्य पुनरावृत्ति नीतियों में [getRepeatDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), और [getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) शामिल हैं; सभी को एक साथ सक्षम करने के बजाय एक नीति चुनें। [getAutoReverse](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiming/#getAutoReverse--) अग्रिम पास के बाद एनीमेशन को उल्टा चलाता है। त्वरण और मंदन सतत परिवर्तनों पर लागू होते हैं, व्यक्तिगत असाइनमेंट या कमांड पर नहीं।

## **एक मोशन पाथ बनाएं**

[createMotionEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) का उपयोग करके मोशन बनाएँ। इसके [getFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#getTo--), और [getBy](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#getBy--) प्रतिशत‑आधारित निर्देशांक या ऑफ़सेट दर्शाते हैं। संपादनीय मार्ग के लिए एक [MotionPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/motionpath/) बनाएँ और उसे [IMotionEffect.setPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) से असाइन करें। [IMotionPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotionpath/) पाथ कमांड्स को रखता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/motioncommandpathtype/) ऑपरेशन चुनता है:

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | One | प्रारम्भिक स्थिति सेट करें। |
| LineTo | One | सीधी रेखा के साथ अंत बिंदु तक जाएँ। |
| CurveTo | Three | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित क्यूबिक कर्व का पालन करें। |
| CloseLoop | None | प्रारम्भिक स्थिति पर लौटें। |
| End | None | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/motionpathpointstype/) बिंदु‑संपादन की विशेषताओं को वर्णित करता है, जैसे कि कोना या स्मूथ बिंदु। यह कमांड प्रकार को प्रतिस्थापित नहीं करता। नीचे के कर्व उदाहरण में कर्व बिंदु प्रकार प्रयोग करें, और सीधी रेखा के भागों में कोना बिंदु प्रकार।

पाथ निर्देशांक स्लाइड आयामों के सापेक्ष सामान्यीकृत होते हैं: X विस्थापन 0.25 स्लाइड की चौड़ाई का एक चौथा भाग दर्शाता है, न कि 0.25 पॉइंट। सकारात्मक Y नीचे की ओर चलता है। निरपेक्ष कमांड पाथ निर्देशांक प्रणाली में स्थितियों को निर्दिष्ट करता है; सापेक्ष कमांड वर्तमान स्थिति से ऑफ़सेट देता है। यह [getOrigin](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#getOrigin--) से अलग है, जो पाथ के रेफ़रेंस फ्रेम को चुनता है, और [getPathEditMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioneffect/#getPathEditMode--) से, जो आकार के घूमने पर पाथ के आंदोलन को नियंत्रित करता है।

### **सीधा पाथ बनाएं**

एक मोशन व्यवहार बनाएँ जिसमें एक प्रारम्भिक बिंदु, एक सीधा खंड, और अंत कमांड हो। [IMotionPath.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और सापेक्ष‑निर्देशांक फ़्लैग लेता है।

प्रारम्भिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड चौड़ाई के एक चौथे भाग की क्षैतिज विस्थापन प्राप्त करता है। अंत कमांड के कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, मोशन व्यवहार को इफ़ेक्ट में जोड़ने से वह इस पाथ को आयत से जोड़ता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` में एक मोशन व्यवहार और तीन पाथ कमांड होते हैं। नीचे के फ़ाइल‑संपादन उदाहरण इस ज्ञात संरचना का उपयोग करते हैं।

### **निरपेक्ष और सापेक्ष निर्देशांक की तुलना**

ये दो पाथ ऑब्जेक्ट समान मार्ग वर्णित करते हैं। निरपेक्ष कमांड (0.3, 0.1) पर समाप्त होती है; सापेक्ष कमांड (0.1, 0.1) को वर्तमान स्थिति (0.2, 0) में जोड़ती है, जिससे अंत बिंदु (0.3, 0.1) बनता है।

दोनों पाथ समान प्रारम्भिक स्थिति से शुरू होते हैं। सापेक्ष रेखा के लिए वर्तमान स्थिति में X और Y ऑफ़सेट जोड़ें; निरपेक्ष रेखा के लिए सीधे अंत बिंदु पढ़ें। फ़्लैग को बदलने से बिना निर्देशांक बदलें अलग मार्ग बन जाएगा।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

किसी भी पाथ को मोशन व्यवहार में असाइन करके प्रस्तुति में उपयोग करें। अंतिम Boolean तर्क उस कमांड के लिए सापेक्ष निर्देशांक चुनता है।

### **रेखा को कर्व से बदलें**

`motion.pptx` खोलें और उसकी रेखा कमांड को क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु प्रदान करें, फिर अंत बिंदु।

प्रारम्भिक स्थिति पूर्ववर्ती कमांड द्वारा निर्धारित होती है। पहले दो बिंदु कर्व को आकार देते हैं, जबकि तीसरा उसका अंत बिंदु है; वे तीन लगातार लक्ष्य नहीं होते। कमांड प्रकार, बिंदु‑संपादन प्रकार, और बिंदु सरणी को साथ‑साथ अपडेट करने से खंड नई ज्यामिति के साथ सुसंगत रहता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` में पाथ अभी भी तीन कमांड रखता है; उसका मध्य कमांड अब कर्व को दर्शाता है।

## **सहेजे गए पाथ को निरीक्षण और संपादित करें**

प्रत्येक [IMotionCmdPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioncmdpath/) [getPoints](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioncmdpath/#getPointsType--), और [isRelative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotioncmdpath/#isRelative--) को उजागर करता है। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन‑कमांड पाथ का उपयोग करते हैं। 任意 इनपुट के लिए, प्रभाव को खोजें और इंडेक्स द्वारा संपादित करने से पहले कमांड प्रकार और बिंदु संख्या जाँचें।

### **कमांड और निर्देशांक पढ़ें**

पाथ को बिना बदले पढ़ें। End और CloseLoop कमांड को कोई बिंदु नहीं चाहिए, इसलिए नल बिंदु सरणी की अनुमति दें।

आउटपुट प्रत्येक संख्यात्मक कमांड प्रकार को उसके सापेक्ष‑निर्देशांक फ़्लैग के साथ जोड़ता है, फिर उसके बिंदु सूचीबद्ध करता है। यह आपको बिंदु को ऑफ़सेट या समाप्त बिंदु के रूप में पहचानने में मदद करता है, इससे पहले कि आप पाथ बदलें। कर्व तीन बिंदु सूचीबद्ध करेगा, जबकि इस फ़ाइल की सीधी रेखा केवल एक बिंदु दिखाती है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

सूची में एक प्रारम्भिक बिंदु, (0.25, 0) पर समाप्त निरपेक्ष रेखा, और अंत कमांड शामिल है।

### **समाप्त बिंदु बदलें**

`motion.pptx` खोलें और रेखा की बिंदु सरणी को बदलकर उसके अंत बिंदु को स्थानांतरित करें।

इनपुट फ़ाइल में, इंडेक्स 0 प्रारम्भिक कमांड है और इंडेक्स 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसकी समाप्ति बदलती है, जबकि कमांड प्रकार, टाइमिंग या कलेक्शन में उसकी स्थिति नहीं बदलती। चूँकि कमांड निरपेक्ष निर्देशांक उपयोग करता है, नया युग्म स्थिति को दर्शाता है, न कि जोड़िए गए ऑफ़सेट को।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` की रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलें**

[insert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) और [removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imotionpath/#removeAt-int-) का उपयोग करके `motion.pptx` में रेखा को बदलें। सम्मिलित करने से पुरानी रेखा इंडेक्स 2 पर चली जाती है।

यह कमांड ऑब्जेक्ट को बदलने को प्रदर्शित करता है, न कि उसके मौजूदा निर्देशांक को संपादित करने को। सम्मिलन के बाद कलेक्शन अस्थायी रूप से प्रारम्भिक कमांड, नई रेखा, पुरानी रेखा, और अंत कमांड रखता है। इंडेक्स 2 को हटाने से पुरानी रेखा समाप्त हो जाती है और नई मार्ग जगह पकड़ लेती है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और अंत कमांड आखिरी में रहता है।

## **मौजूद व्यवहार को संशोधित और सत्यापित करें**

जब व्यवहार का इंडेक्स अज्ञात हो, तो प्रकार द्वारा चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [IRotationEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irotationeffect/) ढूँढ़ता है, कोण बदलता है, और पुनः खोलने के बाद सहेजा गया मान जाँचता है।

प्रकार जाँच लूप को गैर‑घूर्णन व्यवहारों को छोड़ने देती है। दूसरा लोड फ़ाइल को अलग प्रस्तुति ऑब्जेक्ट में पढ़ता है, इसलिए तुलना सहेजे गए डेटा को देखती है, न कि मेमोरी में मौजूद मान को। यह उदाहरण मानता है कि ज्ञात इफ़ेक्ट मुख्य सीक्वेंस में पहला है; प्रकार द्वारा व्यवहार चुनना任意 प्रस्तुति में सही प्रभाव नहीं खोज सकता।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

आउटपुट `Rotation preserved: true` है। समान प्रकार‑जाँच पैटर्न को अन्य व्यवहारों पर लागू करें। पूर्ण संरक्षण जांच के लिए लक्ष्य आकार, इफ़ेक्ट, व्यवहार प्रकार एवं क्रम, टाइमिंग, और पाथ कमांड्स की तुलना करें। फ़्लोटिंग‑पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अज्ञात एनीमेशन लेआउट वाली प्रस्तुति के लिए देखें [Read Shape Animations](/slides/hi/java/shape-animation/#read-shape-animations) मुख्य और इंटरैक्टिव सीक्वेंस को ट्रैवर्स करने हेतु।

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehaviorcollection/) में क्रम इफ़ेक्ट के संचालन का संग्रहित क्रम है। यह कोई प्लेलिस्ट नहीं है जिससे प्रत्येक व्यवहार स्वचालित रूप से पिछले का इंतज़ार करता है। टाइमिंग और संलग्न इफ़ेक्ट शेड्यूलिंग तय करते हैं। व्यवहार ओवरलैप हो सकते हैं, और समान गुण पर ऑपरेशन्स [getAdditive](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehavior/#getAdditive--) और [getAccumulate](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibehavior/#getAccumulate--) के माध्यम से परस्पर प्रभाव डाल सकते हैं। केवल कलेक्शन क्रम बदलकर “move, then rotate” शेड्यूल न करें; जैसा कि [Shape Animation](/slides/hi/java/shape-animation/) में बताया गया है, स्पष्ट टाइमिंग या अलग‑अलग इफ़ेक्ट का प्रयोग करें।

इफ़ेक्ट का [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getType--) और [getSubtype](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ieffect/#getSubtype--) उसके प्रीसेट को वर्णित करता है। यह संपादित व्यवहार वृक्ष का पूर्ण विवरण नहीं है। व्यवहारों को कस्टमाइज़ करने से पहले प्रीसेट और सबटाइप चुनें: प्रीसेट बदलने से कलेक्शन पुनः निर्मित हो सकता है और आपके कस्टम ऑपरेशन्स हट सकते हैं। उदाहरण के लिये, एक कस्टम Spin इफ़ेक्ट को Fade में बदलने से उसका घूर्णन व्यवहार सेट और फ़िल्टर व्यवहारों से बदल सकता है। प्रीसेट या सबटाइप बदलने के बाद कलेक्शन फिर से जाँचें। प्रीसेट व्यवहारों को क्लियर करने से भी ऐसी दृश्यता या इनिशियलाइज़ेशन ऑपरेशन्स हट सकते हैं जिन्हें प्रीसेट आवश्यक रखता है। उदाहरण दृश्यमान आकारों का उपयोग करता है और व्यवहारों को बदलता है; वे हर प्रीसेट के कार्यान्वयन को पूरी तरह से पुनः निर्मित नहीं करते।

## **फ़ॉर्मेट संगतता**

एक संरक्षित व्यवहार वृक्ष सभी व्यूअर्स या निर्यात रेंडररों में समान प्लेबैक की गारंटी नहीं देता। सहेजे गए डेटा और रेंडर किए गए आउटपुट को अलग‑अलग जाँचें।

| फ़ॉर्मेट या आउटपुट | जाँचने योग्य बातें |
| --- | --- |
| PPTX | इन उदाहरणों के लिये प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। इसे फिर से खोलें ताकि संपादन योग्य व्यवहार वृक्ष की पुष्टि हो, फिर इच्छित PowerPoint संस्करण में प्लेबैक जाँचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। अलग‑अलग सहेज‑और‑पुनः‑खोल चक्र और प्लेबैक का परीक्षण करें; सफल PPTX आउटपुट से सभी कस्टम संयोजन समर्थित मानें नहीं। |
| PDF, PNG, JPEG, आदि स्थिर स्लाइड छवियां | स्थिर स्लाइड प्रतिनिधित्व रखती हैं, न कि चलने योग्य व्यवहार टाइमलाइन या अन्तिम एनीमेशन फ्रेम की गारंटी। |
| [HTML5](/slides/hi/java/export-to-html5/) | यदि निर्यात विकल्पों में shape animation सक्षम है तो समर्थित एनीमेशन चलाए जा सकते हैं। ब्राउज़र में कस्टम संयोजन का परीक्षण करें। |
| [Animated GIF](/slides/hi/java/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ़्रेम संग्रहीत करता है, न कि संपादन योग्य व्यवहार या क्लिक‑ट्रिगर इंटरैक्शन। वास्तविक रेंडर किया गया मोशन जाँचें। |
| [Video](/slides/hi/java/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम रेंडर करता है और उन्हें वीडियो के रूप में एन्कोड करता है। समर्थन सीमित है रेंडरर के [supported animations and effects](/slides/hi/java/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड और इंटरैक्टिव इवेंट संपादन योग्य टाइमलाइन नहीं बनते। |

## **FAQ**

**मेरे इफ़ेक्ट में व्यवहार क्यों हैं, जबकि मैं कुछ नहीं जोड़ा?**

प्रीडिफ़ाइंड इफ़ेक्ट बनाते समय उसकी अंतर्निहित ऑपरेशन्स बन सकती हैं। उन्हें निरीक्षण करें और फिर तय करें कि प्रीसेट को विस्तारित करना है या उसके व्यवहारों को बदलना।

**क्या व्यवहार को शुरुआत में ले जाने से वह पहले चलेगा?**

ज़रूरी नहीं। कलेक्शन क्रम टाइमिंग का विकल्प नहीं है। देरी, अवधि, और समान गुण पर ऑपरेशनों के बीच परस्पर क्रिया जाँचें।

**एक End कमांड के पास बिंदु क्यों नहीं होते?**

यह पाथ के अंत को चिह्नित करता है और कोई निर्देशांक आवश्यक नहीं होता। फ़ाइल से पढ़ी गई पाथ को निरीक्षण करते समय नल बिंदु सरणी के लिये जाँचें।

**क्या सफल राउंड‑ट्रिप प्लेबैक की पुष्टि के लिये पर्याप्त है?**

नहीं। पुनः‑खोलना केवल आपके जाँचे हुए गुणों की संरक्षण पुष्टि करता है। दृश्य व्यवहार की पुष्टि के लिये स्लाइडशो प्लेयर या एनीमेटेड निर्यात को अलग‑अलग परीक्षण करें।
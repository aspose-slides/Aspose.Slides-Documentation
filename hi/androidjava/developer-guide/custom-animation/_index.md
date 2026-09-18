---
title: एंड्रॉइड पर कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/androidjava/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- मोशन पाथ
- पॉवरपॉइंट
- प्रेज़ेंटेशन
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint प्रेज़ेंटेशन में कस्टम एनीमेशन व्यवहार और संपादन योग्य मोशन पाथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनीमेशन व्यवहार आपको एनीमेशन इफ़ेक्ट के भीतर व्यक्तिगत ऑपरेशन को नियंत्रित करने की अनुमति देते हैं, जैसे रंग बदलना, आकृति को घुमाना, या संपादन योग्य मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि व्यवहारों को कैसे बनाया और संयोजित किया जाए, उनका टाइमिंग कैसे कॉन्फ़िगर किया जाए, मौजूदा एनीमेशन को कैसे निरीक्षण और संशोधित किया जाए, और यह सत्यापित किया जाए कि उनके गुण प्रेज़ेंटेशन को सहेजने और पुनः खोलने पर भी बने रहते हैं।

प्रीडिफ़ाइन्ड इफ़ेक्ट्स और क्लिक ट्रिगर्स के लिए, देखें [आकार एनीमेशन](/slides/hi/androidjava/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एक एनीमेशन **Timeline → Sequence → Effect → Behaviors** के रूप में व्यवस्थित होता है:

- The [getTimeline](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) method स्लाइड टाइमलाइन लौटाता है, जिसमें इसका मुख्य क्रम और इंटरैक्टिव क्रम होते हैं।
- एक [ISequence](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/) प्रभावों को समाहित करता है, जो संभवतः विभिन्न आकृतियों को लक्षित कर सकते हैं।
- एक [IEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/) लक्ष्य आकृति, प्रीसेट, सबटाइप, और इफ़ेक्ट टाइमिंग को पहचानता है।
- जो संग्रह [IEffect.getBehaviors](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getBehaviors--) द्वारा लौटाया जाता है, वह उन संचालन को सम्मिलित करता है जो इफ़ेक्ट को लागू करते हैं: रंग बदलना, गति, घुमाव, कोई प्रॉपर्टी सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

[ISequence.addEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) को कॉल करके आप एक इफ़ेक्ट बनाते हैं और [getBehaviors](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getBehaviors--) संग्रह तक पहुँचते हैं। एक प्रीसेट इस संग्रह को स्वचालित रूप से भर सकता है। प्रीसेट को विस्तारित करते समय उसकी ऑपरेशन्स रखें, या इच्छित रूप से उन्हें बदलते समय [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) का उपयोग करें।

[IBehaviorFactory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/) नीचे दर्शाए गए आठ व्यवहार प्रकार बनाता है। मोशन को [Build a Motion Path](#build-a-motion-path) में कवर किया गया है। प्रत्येक स्निपेट में उसके इम्पोर्ट शामिल हैं; इन्हें किसी मेथड के भीतर रखकर निष्पादन योग्य बनाएं। बाद के संपादन उदाहरण दर्शाते हैं कि वे किस आउटपुट फ़ाइल का उपयोग करते हैं। एंड्रॉइड में, नमूना फ़ाइल नामों को ऐप‑एक्सेसिबल डायरेक्टरी के पूर्ण पाथ से बदलें, जैसे आपके ऐप की फ़ाइल्स डायरेक्टरी।

### **घुमाव**

[createRotationEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) का उपयोग करके घुमाव बनाएँ। [getBy](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irotationeffect/#getBy--) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [getFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irotationeffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irotationeffect/#getTo--) अंत बिंदु निर्दिष्ट करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू होता है, उसकी प्रीसेट ऑपरेशन्स को एक घुमाव व्यवहार से बदलता है, और उस ऑपरेशन को दो‑सेकंड की अवधि देता है। 90 डिग्री का सापेक्ष कोण आकृति की प्रारंभिक अभिविन्यास से एक चौथाई घुमाव दर्शाता है, इसलिए स्पष्ट प्रारंभिक कोण की आवश्यकता नहीं है।

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

`rotation.pptx` में एक आकृति और एक घुमाव व्यवहार है। नीचे दिखाए गए संग्रह, टाइमिंग, और घुमाव‑संपादन उदाहरण इसी फ़ाइल का उपयोग करते हैं।

### **आकार परिवर्तन**

[createScaleEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) को X/Y प्रतिशत के साथ उपयोग करें: [getFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iscaleeffect/#getTo--) प्रारंभिक और अंतिम आकार बताते हैं, जबकि [getBy](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iscaleeffect/#getBy--) सापेक्ष परिवर्तन बताता है। यहाँ, 100 मूल आकार को दर्शाता है।

उदाहरण दो सेकंड में दोनों आयामों को 100 % से 125 % तक बढ़ाता है। बराबर क्षैतिज और लंबवत प्रतिशत आकार बना रखते हैं; अलग‑अलग प्रतिशत एक आयाम को दूसरे से अधिक खींच देंगे।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **रंग**

[createColorEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) का उपयोग करके भराव को नीले से नारंगी में बदलें। [getFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icoloreffect/#getFrom--) और [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icoloreffect/#getTo--) रंग हैं; [getBy](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icoloreffect/#getBy--) रंग का ऑफ़सेट है। [IBehavior.getProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehavior/#getProperties--) वह विशेषता पहचानता है जो एनीमेट हो रही है।

आकृति का सॉलिड फ़िल नीले रंग से प्रारंभ किया गया है, जो एनीमेशन के शुरुआती रंग से मेल खाता है। फ़िल‑कलर विशेषता का चयन व्यवहार को बताता है कि आकृति के किस भाग को बदलना है; केवल रंग के अंत बिंदु उस विशेषता की पहचान नहीं करते। सहेजा गया इफ़ेक्ट दो‑सेकंड के ट्रांज़िशन को ऑरेंज में वर्णित करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **फ़िल्टर**

[createFilterEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) का उपयोग करके एक वाइप चुनें। [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), और [getReveal](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) क्रमशः फ़िल्टर, दिशा, और आकृति को प्रकट या छिपाने को निर्धारित करते हैं।

यह उदाहरण दो‑सेकंड की वाइप को सेट करता है जो दाएँ‑दिशा सबटाइप का उपयोग करके आकृति को प्रकट करता है। फ़िल्टर सेटिंग्स इफ़ेक्ट के भीतर व्यवहार का हिस्सा हैं, इसलिए उन्हें प्रीसेट की मूल ऑपरेशन्स हटाने के बाद कॉन्फ़िगर किया जाता है।

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

### **प्रॉपर्टी**

[createPropertyEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) का उपयोग करके अपारदर्शिता (opacity) एनीमेट करें। [getFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), और [getBy](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) स्ट्रिंग्स हैं जो क्रमशः [getValueType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) और [getCalcMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) द्वारा व्याख्यायित होती हैं। सभी तीन को एक साथ सेट करने के बजाय अंत बिंदु या सापेक्ष ऑफ़सेट चुनें।

यहाँ चयनित विशेषता opacity है, और संख्यात्मक स्ट्रिंग्स 25 % opacity से पूर्ण opacity तक परिवर्तन दर्शाती हैं। रैखिक इंटरपोलेशन इन मूल्यों के बीच क्रमिक परिवर्तन बताता है। इस उदाहरण को किसी अन्य विशेषता पर अनुकूलित करते समय उचित value type और endpoint मान चुनें।

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

[createSetEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) का उपयोग करके [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iseteffect/#getTo--) के माध्यम से दृश्यता (visibility) सेट करें। सेट व्यवहार अंत बिंदुओं के बीच इंटरपोलेशन नहीं करता।

उदाहरण दृश्यता विशेषता चुनता है और व्यवहार के चलने पर स्ट्रिंग `visible` असाइन करता है। इस न्यूनतम प्रेजेंटेशन में आयत पहले से ही दृश्यमान है, इसलिए असाइनमेंट स्वयं में स्पष्ट दृश्य परिवर्तन नहीं दे सकता। यह ऑपरेशन बड़े इफ़ेक्ट का भाग बनाकर उपयोगी होता है जो यह भी नियंत्रित करता है कि आकृति कब छिपे या दिखे।

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

[createCommandEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) का उपयोग करके [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), और [getShapeTarget](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) कॉन्फ़िगर करें। कार्यशील डायरेक्टरी में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [addAudioFrameEmbedded](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) से एम्बेड करता है और ऑडियो फ़्रेम को प्ले कमांड से जोड़ता है।

ऑडियो फ़्रेम इफ़ेक्ट का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; केवल कमांड स्ट्रिंग यह नहीं बताती कि कौन सा मीडिया ऑब्जेक्ट नियंत्रित किया जायेगा। इफ़ेक्ट स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

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

सहेजने से कमांड `command.pptx` में संग्रहित होता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिये ऐसा स्लाइडशो प्लेयर चाहिए जो कमांड और उसके मीडिया लक्ष्य को सपोर्ट करे।

## **व्यवहार संग्रह का प्रबंधन**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/) में [add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), और [removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) समर्थित हैं। यह उदाहरण `rotation.pptx` खोलता है, स्केलिंग जोड़ता है, घुमाव से पहले उसे इक़्तित करता है, और घुमाव को हटाता है। समान वस्तु को हटाकर फिर री‑इंसर्ट करने से उसकी संग्रहीत स्थिति बदलती है, लेकिन कॉपी नहीं बनती।

संपादनों की क्रमबद्धता संग्रह को rotation–scale → scale–rotation → केवल scale में बदल देती है। इंडेक्स वर्तमान संग्रह को दर्शाते हैं, इसलिए हटाना क्रमबद्धन के बाद घुमाव के नए इंडेक्स का उपयोग करता है। अंतिम इंटेरेशन बताता है कि कौन सा व्यवहार सहेजा जायेगा।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

आउटपुट `ScaleEffect` है: केवल स्केलिंग बची है। संग्रह क्रमस्वतः व्यवहारों को एक‑के‑बाद‑एक चलाने के लिये शेड्यूल नहीं करता। सभी ऑपरेशन्स को बदलते समय ही संग्रह को साफ़ करें।

## **व्यवहार टाइमिंग कॉन्फ़िगर करना**

[IBehavior.getTiming](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehavior/#getTiming--) [ITiming](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/) को उजागर करता है, जो [IEffect.getTiming](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getTiming--) से स्वतंत्र है। इफ़ेक्ट टाइमिंग बाहरी इफ़ेक्ट को शेड्यूल करता है; व्यवहार टाइमिंग उसके भीतर ऑपरेशन को दर्शाता है।

### **अवधि, देरी, दोहराव, और एक्सेलेरेशन सेट करना**

`rotation.pptx` खोलें और अवधि ([getDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getDuration--)) तथा ट्रिगर देरी ([getTriggerDelayTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) को सेकंड में सेट करें, फिर [setRepeatCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) के द्वारा री‑पीट काउंट कॉन्फ़िगर करें। [getAccelerate](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getAccelerate--) और [getDecelerate](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getDecelerate--) अवधि के अंश हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जो घुमाव उदाहरण में बनाई गई थी, जहाँ पहला व्यवहार घुमाव है। यह उदाहरण केवल उसी व्यवहार की टाइमिंग बदलता है; 90‑डिग्री कोण अपरिवर्तित रहता है। कोण और टाइमिंग को अलग‑अलग रखने से गति को पुनः‑निर्माण किए बिना समायोजित करना आसान होता है।

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

यह व्यवहार दो‑सेकंड की अवधि, आधा‑सेकंड की देरी, और 3 का री‑पीट काउंट उपयोग करता है। उसकी अवधि के पहले और अंतिम 20 % एक्सेलेरेशन और डिकेलेरेशन के लिये प्रयोग किए जाते हैं।

अन्य री‑पीट नीतियों में [getRepeatDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), और [getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) शामिल हैं; सभी को एक‑साथ सक्षम करने के बजाय एक नीति चुनें। [getAutoReverse](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiming/#getAutoReverse--) फॉरवर्ड पास के बाद एनीमेशन को उल्टा चलाता है। एक्सेलेरेशन और डिकेलेरेशन सतत परिवर्तनों पर लागू होते हैं, न कि डिस्क्रीट असाइनमेंट या कमांड पर।

## **मोशन पाथ बनाना**

[createMotionEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) का उपयोग करके मोशन बनाएँ। इसके [getFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#getTo--), और [getBy](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#getBy--) प्रतिशत‑आधारित निर्देशांक या ऑफ़सेट दर्शाते हैं। संपादन योग्य मार्ग के लिये, एक [MotionPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/motionpath/) बनाएँ और उसे [IMotionEffect.setPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) से असाइन करें। [IMotionPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotionpath/) पाथ कमांड्स संग्रहीत करता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/motioncommandpathtype/) ऑपरेशन चुनता है:

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | एक | प्रारंभिक स्थिति निर्धारित करें। |
| LineTo | एक | सीधी रेखा के साथ अंत बिंदु तक जाएँ। |
| CurveTo | तीन | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित घनात्मक वक्र का अनुसरण करें। |
| CloseLoop | कोई नहीं | प्रारंभिक स्थिति पर वापस आएँ। |
| End | कोई नहीं | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/motionpathpointstype/) बिंदु‑संपादन विशेषताओं को वर्णित करता है, जैसे कोना या स्मूद बिंदु। यह कमांड प्रकार को बदलता नहीं है। नीचे वक्र उदाहरण के लिये वक्र बिंदु प्रकार और सीधी रेखा सेगमेंट के लिये कोना बिंदु प्रकार उपयोग करें।

पाथ निर्देशांक स्लाइड आयामों के अनुसार सामान्यीकृत होते हैं: X विस्थापन 0.25 स्लाइड चौड़ाई के एक चौथे हिस्से को दर्शाता है, 0.25 पॉइंट्स नहीं। सकारात्मक Y नीचे की ओर चलता है। एब्सोल्यूट कमांड पाथ कॉर्डिनेट सिस्टम में स्थितियों को निर्दिष्ट करता है; रिलेटिव कमांड वर्तमान स्थिति से ऑफ़सेट निर्दिष्ट करता है। यह [getOrigin](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) से अलग है, जो पाथ के रेफ़रेंस फ्रेम को चुनता है, और [getPathEditMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) से, जो आकृति के मूव होने पर पाथ के मूवमेंट को नियंत्रित करता है।

### **सीधा पाथ बनाना**

एक मोशन व्यवहार को प्रारंभ बिंदु, एक सीधा सेगमेंट, और एक एंड कमांड के साथ बनाएँ। [IMotionPath.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और रिलेटिव‑कोऑर्डिनेट फ़्लैग लेता है।

प्रारंभिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड चौड़ाई के एक चौथे हिस्से का क्षैतिज विस्थापन प्राप्त करता है। एंड कमांड में कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, मोशन व्यवहार को इफ़ेक्ट में जोड़ने से वह रेक्टेंज से जुड़ जाता है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` में तीन पाथ कमांड्स वाला एक मोशन व्यवहार है। नीचे के फ़ाइल‑संपादन उदाहरण इसी संरचना पर आधारित हैं।

### **एब्सोल्यूट और रिलेटिव कोऑर्डिनेट की तुलना**

इन दो पाथ ऑब्जेक्ट्स का मार्ग समान है। एब्सोल्यूट कमांड (0.3, 0.1) पर समाप्त होता है; रिलेटिव कमांड वर्तमान स्थिति में (0.1, 0.1) जोड़कर (0.2, 0) बनाता है।

दोनों पाथ एक ही प्रारंभिक स्थिति से शुरू होते हैं। रिलेटिव रेखा के लिये वर्तमान स्थिति में X‑और‑Y ऑफ़सेट जोड़ें अंत बिंदु पाने के लिये; एब्सोल्यूट रेखा के लिये अंत बिंदु सीधे पढ़ें। फ़्लैग को बदले बिना कोऑर्डिनेट को परिवर्तित नहीं किया जाए तो अलग मार्ग बन जाएगा।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

किसी भी पाथ को मोशन व्यवहार में असाइन करके प्रेज़ेंटेशन में उपयोग किया जा सकता है। अंतिम Boolean तर्क उस कमांड के लिये रिलेटिव कोऑर्डिनेट चुनता है।

### **रेखा को वक्र से बदलना**

`motion.pptx` खोलें और उसकी रेखा कमांड को घनात्मक वक्र से बदलें। पहले दो नियंत्रण बिंदु प्रदान करें, फिर अंत बिंदु दें।

प्रारंभिक स्थिति पूर्व कमांड द्वारा प्रदान की गई है। पहले दो बिंदु वक्र को आकार देते हैं, तीसरा उसके लक्ष्य बिंदु के रूप में कार्य करता है; ये तीन लगातार लक्ष्य बिंदु नहीं हैं। कमांड प्रकार, बिंदु‑संपादन प्रकार, और बिंदु एरे को एक साथ अपडेट करने से सेगमेंट नई ज्यामिति के साथ संरेखित रहता है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` में अभी भी तीन कमांड्स हैं; मध्य कमांड अब वक्र को परिभाषित करता है।

## **सहेजे गए पाथ का निरीक्षण और संपादन**

प्रत्येक [IMotionCmdPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioncmdpath/) [getPoints](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), और [isRelative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) को उजागर करता है। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन‑कमांड पाथ का उपयोग करते हैं। मनमानी इनपुट के लिये, प्रभाव को खोजें और इंडेक्स द्वारा संपादन से पहले कमांड प्रकार और बिंदु संख्या जाँचें।

### **कमांड और निर्देशांक पढ़ना**

पाथ को बदले बिना पढ़ें। एंड और क्लोज‑लूप कमांड्स को बिंदुओं की आवश्यकता नहीं होती, इसलिए null बिंदु एरे की अनुमति रखें।

आउटपुट प्रत्येक संख्यात्मक कमांड प्रकार को उसके रिलेटिव‑कोऑर्डिनेट फ़्लैग के साथ जोड़ता है, फिर बिंदु सूचीबद्ध करता है। यह आपको बिंदु को ऑफ़सेट या अंत बिंदु के रूप में पहचानने में मदद करता है। वक्र में तीन बिंदु होंगे, जबकि इस फ़ाइल की सीधी रेखा में केवल एक बिंदु दिखेगा।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

सूची में एक प्रारंभिक बिंदु, (0.25, 0) पर समाप्त एब्सोल्यूट रेखा, और एक एंड कमांड शामिल है।

### **अंत बिंदु बदलना**

`motion.pptx` खोलें और रेखा के बिंदु एरे को बदलकर उसका अंत बिंदु बदलें।

इनपुट फ़ाइल में, इंडेक्स 0 प्रारंभिक कमांड है और इंडेक्स 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसकी गन्तव्य बदलती है, जबकि कमांड प्रकार, टाइमिंग, या संग्रह में उसकी स्थिति नहीं बदलती। क्योंकि कमांड एब्सोल्यूट कोऑर्डिनेट उपयोग करता है, नया युग्म स्थिति को दर्शाता है, न कि ऑफ़सेट जोड़ता है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` में रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलना**

[insert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) और [removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) का उपयोग करके `motion.pptx` में रेखा को बदलें। इंसर्शन पुराने रेखा को इंडेक्स 2 पर शिफ्ट करता है।

यह कमांड ऑब्जेक्ट को बदलने का प्रदर्शन करता है, न कि उसके मौजूदा निर्देशांक को संपादित करने का। इंसर्शन के बाद, संग्रह अस्थायी रूप से प्रारंभिक कमांड, नई रेखा, पुरानी रेखा, और एंड कमांड रखता है। इंडेक्स 2 को हटाने से पुरानी रेखा हट जाती है और नई पाथ बनी रहती है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और एंड कमांड आखरी में है।

## **मौजूद व्यवहार को संशोधित और सत्यापित करना**

जब व्यवहार का इंडेक्स ज्ञात नहीं होता, तो प्रकार द्वारा चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [IRotationEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irotationeffect/) खोजता है, कोण बदलता है, और पुनः खोलने पर सहेजी गई मान की जाँच करता है।

प्रकार जाँच लूप को उन व्यवहारों को छोड़ने देती है जो घुमाव नहीं हैं। दूसरा लोड अलग प्रेज़ेंटेशन ऑब्जेक्ट में सहेजी गई फ़ाइल पढ़ता है, इसलिए तुलना स्थायी डेटा की होती है, न कि मेमोरी में अभी मौजूद मान की। यह उदाहरण अभी भी मानता है कि ज्ञात इफ़ेक्ट मुख्य क्रम में पहला है; प्रकार द्वारा व्यवहार चुनना मनमानी प्रेज़ेंटेशन में सही इफ़ेक्ट खोज नहीं सकता।

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

आउटपुट `Rotation preserved: true` है। समान प्रकार‑जाँच पैटर्न अन्य व्यवहारों पर लागू करें। पूर्ण संरक्षण जाँच के लिये लक्ष्य आकृति, इफ़ेक्ट, व्यवहार प्रकार और क्रम, टाइमिंग, तथा पाथ कमांड्स की तुलना करें। फ्लोटिंग‑पॉइंट मानों के लिये संख्यात्मक सहनशीलता उपयोग करें। एक ऐसी प्रेज़ेंटेशन के लिये जहाँ एनीमेशन लेआउट अज्ञात हो, देखें [Read Shape Animations](/slides/hi/androidjava/shape-animation/#read-shape-animations) ताकि मुख्य और इंटरैक्टिव क्रम की यात्रा की जा सके।

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehaviorcollection/) में क्रम इफ़ेक्ट के ऑपरेशन्स का संग्रहीत क्रम है। यह एक प्लेलिस्ट नहीं है जहाँ हर व्यवहार स्वतः पिछले को इंतज़ार करता है। टाइमिंग और सम्मिलित इफ़ेक्ट शेड्यूलिंग तय करते हैं। व्यवहार ओवरलैप कर सकते हैं, और समान प्रॉपर्टी पर ऑपरेशन्स [getAdditive](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehavior/#getAdditive--) तथा [getAccumulate](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) के माध्यम से इंटरैक्ट कर सकते हैं। केवल संग्रह पुनः‑क्रमबद्धन का उपयोग “move, then rotate” शेड्यूल करने के लिये न करें; स्पष्ट टाइमिंग या अलग‑अलग इफ़ेक्ट का उपयोग करें जैसा कि [आकार एनीमेशन](/slides/hi/androidjava/shape-animation/) में बताया गया है।

इफ़ेक्ट का [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getType--) और [getSubtype](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ieffect/#getSubtype--) उसका प्रीसेट वर्णन करते हैं। ये संपादित व्यवहार वृक्ष का पूरा विवरण नहीं देते। प्रीसेट और सबटाइप को बदलने से संग्रह पुनः बन सकता है और आपके कस्टम ऑपरेशन्स हट सकते हैं। उदाहरण के लिये, कस्टमाइज़्ड Spin इफ़ेक्ट को Fade में बदलने से उसका घुमाव व्यवहार सेट और फ़िल्टर व्यवहारों से बदल सकता है। प्रीसेट या सबटाइप बदलने के बाद संग्रह को पुनः‑जाँचें। प्रीसेट व्यवहारों को साफ़ करना उन दृश्यता या इनिशियलाइज़ेशन ऑपरेशन्स को भी हटा सकता है जो प्रीसेट को आवश्यक होते हैं। यहाँ उपयोग किए गए उदाहरण दृश्यमान आकृतियों को बदलते हैं और व्यवहारों को बदलते हैं; वे हर प्रीसेट की पूरी इम्प्लीमेंटेशन को पुनः‑निर्मित नहीं करते।

## **फ़ॉर्मेट संगतता**

एक संरक्षित व्यवहार वृक्ष हर व्यूअर या एक्सपोर्ट रेंडरर में समान प्लेबैक की गारंटी नहीं देता। सहेजे गए डेटा और रेंडर किए गए आउटपुट को अलग‑अलग जाँचें।

| फ़ॉर्मेट या आउटपुट | क्या सत्यापित करें |
| --- | --- |
| PPTX | इन उदाहरणों के लिये मुख्य फ़ॉर्मेट के रूप में उपयोग करें। इसे पुनः‑खोलें ताकि संपादनीय व्यवहार वृक्ष की पुष्टि हो, फिर इच्छित PowerPoint संस्करण में प्लेबैक जाँचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से भिन्न हो सकता है। अलग‑अलग सेव‑और‑पुनः‑खोल चक्र और प्लेबैक टेस्ट करें; सफल PPTX आउटपुट से सभी कस्टम संयोजन के समर्थन का अनुमान न लगाएँ। |
| PDF, PNG, JPEG, और अन्य स्टैटिक स्लाइड इमेज | स्टैटिक स्लाइड प्रतिनिधित्व होते हैं, न कि चलने योग्य टाइमलाइन या अन्तिम एनीमेशन फ़्रेम। |
| [HTML5](/slides/hi/androidjava/export-to-html5/) | यदि एक्सपोर्ट विकल्पों में आकार एनीमेशन सक्षम हो तो समर्थित एनीमेशन चलाया जा सकता है। ब्राउज़र में कस्टम संयोजनों को टेस्ट करें। |
| [Animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ्रेम संग्रहीत करता है, न कि संपादनीय व्यवहार या क्लिक‑ट्रिगर इंटरैक्शन। वास्तविक रेंडर किया गया मोशन जाँचें। |
| [Video](/slides/hi/androidjava/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम को रेंडर करके वीडियो में एन्कोड करता है। समर्थन रेंडरर के [supported animations and effects](/slides/hi/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) तक सीमित है; कमांड और इंटरैक्टिव इवेंट संपादनीय टाइमलाइन नहीं बनते। |

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे इफ़ेक्ट में व्यवहार क्यों दिखते हैं जबकि मैंने कुछ नहीं जोड़ा?**  
प्रीडिफ़ाइन्ड इफ़ेक्ट बनाने से उसके अंतर्निहित ऑपरेशन्स बन सकते हैं। उन्हें विस्तारित करने या बदलने से पहले निरीक्षण करें।

**क्या व्यवहार को शुरुआत में ले जाने से वह पहले चलाता है?**  
ज़रूरी नहीं। संग्रह क्रम केवल टाइमिंग का विकल्प नहीं है। देरी, अवधि, और समान प्रॉपर्टी पर ऑपरेशन्स के बीच इंटरैक्शन जाँचें।

**एंड कमांड के पास बिंदु क्यों नहीं होते?**  
यह पाथ के अंत को दर्शाता है और किसी निर्देशांक की आवश्यकता नहीं होती। फ़ाइल से पढ़े पाथ को निरीक्षण करते समय null बिंदु एरे की जाँच करें।

**क्या सफल राउंड‑ट्रिप प्लेबैक की पुष्टि करता है?**  
नहीं। पुनः‑खोलना केवल उस गुण की संरक्षा की पुष्टि करता है जिसे आपने जाँचा। स्लाइडशो प्लेयर या एनीमेटेड एक्सपोर्ट को अलग‑अलग टेस्ट करें ताकि उसकी दृश्य व्यवहार की पुष्टि हो सके।
---
title: Java में प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटन को संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में Windows Media Player नियंत्रण को पुनः उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड में टेक्स्ट बॉक्स, कमांड बटन और मीडिया प्लेयर जैसी इंटरैक्टिव तत्व प्रदान करते हैं। Aspose.Slides for Java स्लाइड के नियंत्रणों को [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) के माध्यम से एक्सपोज़ करता है। इस कलेक्शन का उपयोग करके आप किसी नियंत्रण को संपादित कर सकते हैं, स्लाइड पर स्थानांतरित कर सकते हैं या उसे हटा सकते हैं।

## **ActiveX नियंत्रणों और उनके संग्रहीत गुणों की सूची**

एक अपरिचित टेम्पलेट की जाँच करने हेतु उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर स्थित नियंत्रणों के माध्यम से इटरेट करें। उदाहरण स्लाइड क्रमांक, नियंत्रण नाम, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--) और [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) में प्रत्येक कुंजी‑मान जोड़ी को रिपोर्ट करता है। यह प्रस्तुति को बिना नियंत्रणों को सक्रिय किए, इवेंट या मैक्रो को कॉल किए, मानों को बदले या फ़ाइल को सहेजे पढ़ता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`ActiveX.pptm` से चयनित आउटपुट एक टेक्स्ट बॉक्स और एक कमांड बटन दिखाता है।

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

खाली प्रॉपर्टी कलेक्शन `[]` के रूप में दिखाई देता है। बाइनरी स्टोरेज वाले नियंत्रणों के लिए, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) `null` लौटा सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो `null` जांच के बाद [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध प्रॉपर्टी को सूचीबद्ध करती है। एक नियंत्रण रन‑टाइम के दौरान अतिरिक्त प्रॉपर्टी का समर्थन कर सकता है।

## **ActiveX नियंत्रणों में परिवर्तन करें**

यह उदाहरण एक मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहले स्लाइड पर `TextBox1` नामक टेक्स्ट बॉक्स और `CommandButton1` नामक कमांड बटन हो। यह [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स का मान और बटन का कैप्शन बदलता है। प्रत्येक नियंत्रण का एक स्थिर प्रीव्यू भी होता है जिसे PowerPoint सक्रियण से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए अपडेटेड टेक्स्ट और उपस्थिति दर्शाने वाली PNG प्रदान करें। उदाहरण इन छवियों को [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) के माध्यम से असाइन करता है।

उदाहरण पहले स्लाइड पर सभी नियंत्रणों को 100 पॉइंट नीचे ले जाता है, जिसके लिए उसका फ्रेम [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) के साथ सेट किया जाता है। यह संपादित प्रस्तुति को PPTM फ़ॉर्मेट में सहेजता है, फिर [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) का उपयोग करके उस स्लाइड से सभी ActiveX नियंत्रण हटाकर दूसरी प्रतिलिपि सहेजता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किया हुआ Windows Media Player नियंत्रण पुनः उपयोग करने के लिए, ऐसे टेम्पलेट से शुरू करें जिसमें पहले स्लाइड पर `WindowsMediaPlayer1` नामक प्लेयर हो। [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) पूरे स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसके [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) में सेट करता है और क्लोन किए गए स्लाइड को आउटपुट में केवल स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**क्या Aspose.Slides ActiveX नियंत्रणों को बिना चलाए संरक्षित रख सकता है?**

हां। Aspose.Slides नियंत्रणों को, उनके गुणों और स्थितियों सहित, बिना सक्रिय किए पढ़ और सहेज सकता है।

**ActiveX नियंत्रण OLE ऑब्जेक्ट से कैसे अलग हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने की अनुमति देते हैं, जैसे टेक्स्ट दर्ज करना या बटन क्लिक करना। एक [OLE object](/slides/hi/java/manage-ole/) स्लाइड को अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, के साथ लिंक या एम्बेड करने देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट VBA मैक्रो को ट्रिगर करेंगे?**

प्रस्तुति को PPTM जैसे मैक्रो‑सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। Windows के लिए PowerPoint तब मौजूदा इवेंट हैंडलर चला सकता है जब उसकी सुरक्षा सेटिंग्स ActiveX नियंत्रण और मैक्रो दोनों की अनुमति देती हैं।
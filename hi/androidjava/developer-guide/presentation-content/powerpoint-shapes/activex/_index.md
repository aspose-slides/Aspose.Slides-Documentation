---
title: Android पर प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/androidjava/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटन संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों में Windows Media Player नियंत्रण का पुनः उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड में टेक्स्ट बॉक्स, कमांड बटन, और मीडिया प्लेयर जैसे इंटरैक्टिव तत्व प्रदान करते हैं। Aspose.Slides for Android via Java स्लाइड के नियंत्रणों को [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप किसी नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे ले जा सकते हैं, या हटा सकते हैं। नीचे के उदाहरणों में, उन फ़ाइल पथों का उपयोग करें जो आपका Android ऐप पढ़ सकता है और प्रत्येक आउटपुट प्रस्तुति के लिए लिखने योग्य स्थान चुनें।

## **ActiveX नियंत्रणों और उनके संग्रहीत गुणों की सूची**

किसी अपरिचित टेम्पलेट का निरीक्षण करने के लिए, उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से इटरेट करें। उदाहरण स्लाइड नंबर, नियंत्रण का नाम, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--) और [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) में प्रत्येक कुंजी‑मान जोड़े को रिपोर्ट करता है। यह प्रस्तुति को नियंत्रणों को सक्रिय किए बिना, इवेंट या मैक्रो को बुलाए बिना, मान बदले बिना, या फ़ाइल को सहेजे बिना पढ़ता है।

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

खाली गुण संग्रह `[]` के रूप में दिखाई देता है। बाइनरी स्टोरेज वाले नियंत्रणों के लिए, [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) `null` लौटा सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो `null` जांच के बाद [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) का उपयोग करें। रिपोर्ट में प्रस्तुति से उपलब्ध गुणों को सूचीबद्ध किया गया है। एक नियंत्रण रनटाइम पर अतिरिक्त गुणों का समर्थन कर सकता है।

## **ActiveX नियंत्रणों को संशोधित करें**

यह उदाहरण पहले स्लाइड पर `TextBox1` नामके टेक्स्ट बॉक्स और `CommandButton1` नामके कमांड बटन वाले मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है। यह [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स का मान और बटन का कैप्शन बदलता है। प्रत्येक नियंत्रण की एक स्थिर प्रीव्यू भी होती है जिसे PowerPoint सक्रियण से पहले प्रदर्शित कर सकता है। प्रत्येक नियंत्रण के लिए अपडेटेड टेक्स्ट और रूप दिखाने वाला PNG प्रदान करें। उदाहरण इन छवियों को [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) के माध्यम से असाइन करता है।

उदाहरण पहले स्लाइड पर प्रत्येक नियंत्रण को 100 पॉइंट नीचे ले जाता है, जिसके लिए इसका फ्रेम [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) के साथ सेट किया जाता है। यह संपादित प्रस्तुति को PPTM प्रारूप में सहेजता है, फिर [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) का उपयोग करके सभी ActiveX नियंत्रणों को हटाकर दूसरी प्रति सहेजता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

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

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
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

कॉन्फ़िगर किए गए Windows Media Player नियंत्रण को पुन: उपयोग करने के लिए, ऐसी टेम्पलेट से शुरू करें जिसकी पहली स्लाइड में `WindowsMediaPlayer1` नामक प्लेयर हो। [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) पूरी स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसकी [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में अकेली स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए प्लेयर के चलाते समय पहुँचने योग्य पथ चुनें।

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

**क्या Aspose.Slides ActiveX नियंत्रणों को बिना चलाए संरक्षित कर सकता है?**

हां। Aspose.Slides नियंत्रणों को पढ़ और सहेज सकता है, उनके गुण और स्थितियों सहित, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE ऑब्जेक्ट्स से कैसे भिन्न हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने देते हैं, जैसे टेक्स्ट दर्ज करना या बटन पर क्लिक करना। एक [OLE object](/slides/hi/androidjava/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को शामिल या लिंक करने की अनुमति देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट्स VBA मैक्रो को ट्रिगर करेंगे?**

प्रस्तुति को मैक्रो‑सक्षम प्रारूप जैसे PPTM में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। Windows के लिए PowerPoint सुरक्षा सेटिंग्स दोनों ActiveX नियंत्रण और मैक्रो की अनुमति देती हैं तो मौजूदा इवेंट हैंडलर्स चलाए जा सकते हैं।
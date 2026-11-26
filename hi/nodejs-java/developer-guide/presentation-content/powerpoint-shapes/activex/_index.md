---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटन संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों में Windows Media Player नियंत्रण को पुनः उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को इंटरैक्टिव तत्व जैसे टेक्स्ट बॉक्स, कमांड बटन, और मीडिया प्लेयर प्रदान करते हैं। Aspose.Slides for Node.js via Java एक स्लाइड के नियंत्रणों को [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप किसी नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं, या हटा सकते हैं।

## **ActiveX नियंत्रण और उनके संग्रहीत गुणों की सूची**

एक अपरिचित टेम्प्लेट का निरीक्षण करने के लिए, इसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से क्रमबद्ध करें। उदाहरण स्लाइड नंबर, नियंत्रण का नाम, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) और प्रत्येक कुंजी‑मूल्य जोड़ी को [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) में रिपोर्ट करता है। यह प्रस्तुति को नियंत्रणों को सक्रिय किए बिना, इवेंट या मैक्रो को बुलाए बिना, मान बदलें बिना, या फ़ाइल को सहेजे बिना पढ़ता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

एक खाली प्रॉपर्टी संग्रह `[]` के रूप में दिखता है। बाइनरी स्टोरेज का उपयोग करने वाले नियंत्रणों के लिए, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) `null` वापस कर सकता है, जिसे `Properties unavailable` के रूप में दिखाया गया है। यदि आपको केवल नाम चाहिए, तो null जाँच के बाद [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध प्रॉपर्टियों की सूची देता है। नियंत्रण रनटाइम में अतिरिक्त प्रॉपर्टियों का समर्थन कर सकता है।

## **ActiveX नियंत्रण संशोधित करें**

उदाहरण एक मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहली स्लाइड पर `TextBox1` नाम का टेक्स्ट बॉक्स और `CommandButton1` नाम का कमांड बटन हो। यह [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स का मान और बटन कैप्शन बदलता है। प्रत्येक नियंत्रण का एक स्थिर प्रीव्यू भी होता है जिसे PowerPoint सक्रिय होने से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए एक PNG प्रदान करें जो उसका अद्यतन पाठ और रूप दिखाता हो। उदाहरण इन छवियों को [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) के माध्यम से नियुक्त करता है।

उदाहरण पहले स्लाइड पर प्रत्येक नियंत्रण को 100 पॉइंट नीचे ले जाता है, इसके फ्रेम को [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) से सेट करके। यह संपादित प्रस्तुति को PPTM प्रारूप में सहेजता है, फिर [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) का उपयोग करके उसी स्लाइड से सभी ActiveX नियंत्रण हटाकर एक दूसरी कॉपी सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

एक कॉन्फ़िगर किए गए Windows Media Player नियंत्रण को पुनः उपयोग करने के लिए, एक टेम्प्लेट से शुरू करें जिसकी पहली स्लाइड में `WindowsMediaPlayer1` नाम का प्लेयर हो। [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) पूरे स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर की `URL` को उसकी [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) में सेट करता है और क्लोन किए गए स्लाइड को आउटपुट में एकमात्र स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides ActiveX नियंत्रणों को चलाए बिना संरक्षित कर सकता है?**  
हां। Aspose.Slides नियंत्रणों को पढ़ और सहेज सकता है, जिसमें उनके गुण और स्थितियां शामिल हैं, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE वस्तुओं से कैसे अलग होते हैं?**  
ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने देते हैं, उदाहरण के लिए टेक्स्ट दर्ज करके या बटन क्लिक करके। एक [OLE object](/slides/hi/nodejs-java/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को शामिल या लिंक करने देता है।

**क्या Aspose.Slides से प्रस्तुति सहेजने के बाद ActiveX इवेंट्स अभी भी VBA मैक्रो को ट्रिगर करेंगे?**  
प्रस्तुति को PPTM जैसे मैक्रो‑सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। Windows के लिए PowerPoint मौजूदा इवेंट हैंडलर्स को चला सकता है जब उसकी सुरक्षा सेटिंग्स ActiveX नियंत्रण और मैक्रो दोनों को अनुमति देती हैं।
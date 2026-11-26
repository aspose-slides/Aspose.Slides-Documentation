---
title: Python का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रण प्रबंधित करें
linktitle: ActiveX
type: docs
weight: 80
url: /hi/python-java/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटन संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में Windows Media Player नियंत्रण का पुनः उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को इंटरैक्टिव तत्व जैसे टेक्स्ट बॉक्स, कमांड बटन, और मीडिया प्लेयर प्रदान करते हैं। Aspose.Slides for Python via Java स्लाइड के नियंत्रणों को [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप एक नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं, या हटा सकते हैं।

## **सूची ActiveX नियंत्रण और उनके संग्रहित गुण**

एक अपरिचित टेम्पलेट का निरीक्षण करने के लिए, उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से लूप करें। यह उदाहरण स्लाइड क्रमांक, नियंत्रण का नाम, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), और [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) में प्रत्येक कुंजी‑मान जोड़ी की रिपोर्ट करता है। यह प्रस्तुति को नियंत्रणों को सक्रिय किए बिना, घटनाओं या मैक्रोज़ को बुलाए बिना, मान बदलें बिना, या फ़ाइल को सहेजे बिना पढ़ता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

खाली प्रॉपर्टी कलेक्शन `[]` के रूप में दिखाई देता है। द्विआधारी संग्रहण वाले नियंत्रणों के लिए, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) `None` लौटा सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो संग्रह उपलब्ध है यह जांचने के बाद [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध गुणों को सूचीबद्ध करती है। एक नियंत्रण रन‑टाइम पर अतिरिक्त गुणों का समर्थन कर सकता है।

## **ActiveX नियंत्रण संशोधित करें**

यह उदाहरण एक मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहले स्लाइड पर `TextBox1` नाम का टेक्स्ट बॉक्स और `CommandButton1` नाम का कमांड बटन हो। यह [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स मान और बटन कैप्शन बदलता है। प्रत्येक नियंत्रण का एक स्थिर पूर्वावलोकन भी होता है जिसे PowerPoint सक्रियण से पहले प्रदर्शित कर सकता है। प्रत्येक नियंत्रण के लिए एक PNG प्रदान करें जो उसके अद्यतन पाठ और रूप को दर्शाए। उदाहरण इन छवियों को [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) के द्वारा असाइन करता है।

उदाहरण पहले स्लाइड पर प्रत्येक नियंत्रण को 100 पॉइंट नीचे ले जाने के लिए उसका फ्रेम [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) द्वारा सेट करता है। यह संपादित प्रस्तुति को PPTM प्रारूप में सहेजता है, फिर सभी ActiveX नियंत्रणों को हटाकर दूसरी प्रतिलिपि बनाने के लिए [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) का उपयोग करता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किया गया Windows Media Player नियंत्रण पुनः उपयोग करने के लिए, ऐसी टेम्पलेट से शुरू करें जिसकी पहली स्लाइड पर `WindowsMediaPlayer1` नाम का प्लेयर हो। [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) पूरी स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसकी [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में एकमात्र स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिससे प्लेयर प्लेबैक के दौरान पहुंच सके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides ActiveX नियंत्रणों को बिना चलाए संरक्षित कर सकता है?**

हां। Aspose.Slides नियंत्रणों को, उनके गुणों और स्थानों सहित, बिना उन्हें सक्रिय किए पढ़ और सहेज सकता है।

**ActiveX नियंत्रण OLE वस्तुओं से कैसे अलग हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने की अनुमति देते हैं, उदाहरण के लिए टेक्स्ट दर्ज करना या बटन पर क्लिक करना। एक [OLE object](/slides/hi/python-java/manage-ole/) स्लाइड को किसी अन्य अनुप्रयोग द्वारा प्रबंधित सामग्री, जैसे Excel कार्यपत्रक, से लिंक या शामिल करने देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX घटनाएं VBA मैक्रोज़ को अभी भी ट्रिगर करेंगी?**

प्रस्तुति को PPTM जैसे मैक्रो‑सक्षम फॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बरकरार रहे। Windows के लिए PowerPoint, जब उसकी सुरक्षा सेटिंग्स ActiveX नियंत्रण और मैक्रोज़ दोनों की अनुमति देती हैं, तो मौजूदा इवेंट हैंडलरों को चला सकता है।
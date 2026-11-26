---
title: "Presentations में Python के साथ ActiveX नियंत्रण प्रबंधित करें"
linktitle: "ActiveX"
type: docs
weight: 80
url: /hi/python-net/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधित करें
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "ActiveX टेक्स्ट बॉक्स और बटन संपादित करें, नियंत्रण प्रीव्यू अपडेट करें, और Aspose.Slides for Python via .NET के साथ PowerPoint प्रेजेंटेशन में Windows Media Player नियंत्रण को पुन: उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को टेक्स्ट बॉक्स, कमांड बटन और मीडिया प्लेयर जैसे इंटरैक्टिव तत्व प्रदान करते हैं। Aspose.Slides for Python via .NET एक स्लाइड के नियंत्रणों को [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) के माध्यम से उजागर करता है। इस संग्रह का उपयोग कर आप किसी नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं, या हटा सकते हैं।

## **ActiveX नियंत्रणों और उनके संग्रहीत गुणों की सूची**

एक अपरिचित टेम्पलेट का निरीक्षण करने के लिए, उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से पुनरावृत्ति करें। उदाहरण स्लाइड नंबर, नियंत्रण नाम, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), और [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) में प्रत्येक कुंजी‑मान जोड़े की रिपोर्ट करता है। यह प्रस्तुति को पढ़ता है बिना नियंत्रणों को सक्रिय किए, घटनाओं या मैक्रो को बुलाए, मान बदलते या फ़ाइल सहेजे।

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

`ActiveX.pptm` का चयनित आउटपुट एक टेक्स्ट बॉक्स और एक कमांड बटन दिखाता है।

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

`[]` के रूप में एक खाली प्रॉपर्टी कलेक्शन दिखाई देता है। बाइनरी स्टोरेज वाले नियंत्रणों के लिए, `properties` `None` लौट सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो `None` की जाँच करने के बाद [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध प्रॉपर्टीज़ की सूची देती है। एक नियंत्रण रनटाइम पर अतिरिक्त प्रॉपर्टीज़ का समर्थन कर सकता है।

## **ActiveX नियंत्रणों को संशोधित करें**

उदाहरण मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहली स्लाइड पर `TextBox1` नामक टेक्स्ट बॉक्स और `CommandButton1` नामक कमांड बटन हो। यह [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) का उपयोग करके टेक्स्ट बॉक्स का मान और बटन का कैप्शन बदलता है। प्रत्येक नियंत्रण का एक स्थैतिक प्रीव्यू भी होता है जिसे PowerPoint सक्रियण से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए एक PNG प्रदान करें जो अद्यतन टेक्स्ट और रूप‑रेखा दिखाए। उदाहरण इन छवियों को [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) के माध्यम से असाइन करता है।

उदाहरण पहली स्लाइड पर प्रत्येक नियंत्रण को उसके [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) को बदलकर 100 पॉइंट नीचे ले जाता है। यह संपादित प्रस्तुति को PPTM फ़ॉर्मेट में सहेजता है, फिर [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) का उपयोग करके उसी स्लाइड से सभी ActiveX नियंत्रण हटाकर द्वितीय प्रतिलिपि सहेजता है।

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **एक ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किए गए Windows Media Player नियंत्रण को पुन: उपयोग करने के लिए, ऐसी टेम्पलेट से शुरू करें जिसकी पहली स्लाइड में `WindowsMediaPlayer1` नामक प्लेयर हो। [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) पूरे स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसकी [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में एक ही स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए वह पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides ActiveX नियंत्रणों को बिना चलाए सुरक्षित रख सकता है?**

हाँ। Aspose.Slides नियंत्रणों को पढ़ और सहेज सकता है, जिसमें उनके गुण और स्थितियाँ शामिल हैं, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE ऑब्जेक्ट से कैसे भिन्न होते हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने देते हैं, जैसे टेक्स्ट दर्ज करना या बटन को क्लिक करना। एक [OLE object](/slides/hi/python-net/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को समाहित या लिंक करने की अनुमति देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट्स VBA मैक्रो को ट्रिगर करेंगे?**

प्रस्तुति को PPTM जैसे मैक्रो‑सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। PowerPoint for Windows मौजूदा इवेंट हैंडलर को चलाएगा जब उसकी सुरक्षा सेटिंग्स दोनों ActiveX नियंत्रणों और मैक्रो की अनुमति दें।
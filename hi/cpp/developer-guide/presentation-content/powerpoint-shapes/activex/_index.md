---
title: C++ का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रणों का प्रबंधन
linktitle: ActiveX
type: docs
weight: 80
url: /hi/cpp/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में ActiveX टेक्स्ट बॉक्स और बटन को संपादित करें, नियंत्रण प्रीव्यू को अपडेट करें, और Windows Media Player नियंत्रण को पुन: उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को इंटरैक्टिव तत्व जैसे टेक्स्ट बॉक्स, कमांड बटन और मीडिया प्लेयर प्रदान करते हैं। Aspose.Slides for C++ एक स्लाइड के नियंत्रणों को [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप एक नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं या हटा सकते हैं।

## **ActiveX नियंत्रणों और उनकी संग्रहीत गुणों की सूची**

अपरिचित टेम्प्लेट का निरीक्षण करने के लिए, उसे पढ़ने के मोड में खोलें और प्रत्येक स्लाइड पर नियंत्रणों के माध्यम से इटरेट करें। उदाहरण स्लाइड नंबर, नियंत्रण का नाम, [क्लास आईडी](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), और [संग्रहीत गुण](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) में प्रत्येक कुंजी‑मान जोड़े की रिपोर्ट करता है। यह प्रस्तुति को नियंत्रनों को सक्रिय किए बिना, इवेंट या मैक्रो को कॉल किए बिना, मान बदलें बिना, या फ़ाइल को सहेजे बिना पढ़ता है।

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
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

`[]` के रूप में एक खाली गुण संग्रह प्रदर्शित होता है। बाइनरी स्टोरेज वाले नियंत्रणों के लिए, `get_Properties` `nullptr` वापस कर सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो संग्रह के मौजूद होने की जाँच करने के बाद [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध गुणों की सूची देती है। किसी नियंत्रण में रन‑टाइम पर अतिरिक्त गुण समर्थित हो सकते हैं।

## **ActiveX नियंत्रणों को संशोधित करें**

उदाहरण पहले स्लाइड पर `TextBox1` नामक टेक्स्ट बॉक्स और `CommandButton1` नामक कमांड बटन वाले एक मैक्रो‑सक्षम प्रस्तुति की अपेक्षा करता है। यह टेक्स्ट बॉक्स मूल्य और बटन कैप्शन बदलने के लिए [नियंत्रण गुण संग्रह](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) का उपयोग करता है। प्रत्येक नियंत्रण का एक स्थिर प्रीव्यू भी होता है जिसे PowerPoint सक्रिय करने से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए अद्यतन टेक्स्ट और रूप दिखाने वाला PNG प्रदान करें। उदाहरण इन छवियों को [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) के माध्यम से असाइन करता है।

उदाहरण पहले स्लाइड पर प्रत्येक नियंत्रण को उसके [फ्रेम](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) को बदलकर 100 पॉइंट नीचे ले जाता है। यह संपादित प्रस्तुति को PPTM फ़ॉर्मेट में सहेजता है, फिर [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) का उपयोग करके उसी स्लाइड से सभी ActiveX नियंत्रण हटाकर दूसरी कॉपी सहेजता है।

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```
## **एक ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किया गया Windows Media Player नियंत्रण पुन: उपयोग करने के लिए, ऐसे टेम्प्लेट से शुरू करें जिसकी पहली स्लाइड में `WindowsMediaPlayer1` नामक प्लेयर हो। [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) संपूर्ण स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर की `URL` को उसके [गुण संग्रह](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में केवल एक ही स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```
## **FAQ**

**क्या Aspose.Slides ActiveX नियंत्रणों को उनके चलाए बिना सुरक्षित रख सकता है?**

हां। Aspose.Slides नियंत्रनों को उनके गुणों और स्थितियों सहित पढ़ और सहेज सकता है, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE ऑब्जेक्ट से कैसे भिन्न हैं?**

ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने की अनुमति देते हैं, जैसे टेक्स्ट दर्ज करना या बटन पर क्लिक करना। एक [OLE object](/slides/hi/cpp/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को शामिल या लिंक करने देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट्स अभी भी VBA मैक्रो को ट्रिगर करेंगे?**

प्रस्तुति को PPTM जैसे मैक्रो‑सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बना रहे। PowerPoint for Windows उन मौजूदा इवेंट हैंडलर्स को चला सकता है जब उसकी सुरक्षा सेटिंग्स ActiveX नियंत्रण और मैक्रो दोनों को अनुमति देती हैं।
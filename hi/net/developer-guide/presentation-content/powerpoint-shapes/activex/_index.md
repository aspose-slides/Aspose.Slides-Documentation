---
title: ".NET में प्रस्तुतियों में ActiveX नियंत्रणों को प्रबंधित करें"
linktitle: "ActiveX"
type: docs
weight: 80
url: /hi/net/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX का प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में ActiveX टेक्स्ट बॉक्स और बटन संपादित करें, नियंत्रण के पूर्वावलोकन को अपडेट करें, और Windows Media Player नियंत्रण को पुनः उपयोग करें।"
---
## **परिचय**

ActiveX नियंत्रण PowerPoint स्लाइड को इंटरैक्टिव तत्व प्रदान करते हैं जैसे टेक्स्ट बॉक्स, कमांड बटन, और मीडिया प्लेयर। Aspose.Slides for .NET एक स्लाइड के नियंत्रणों को [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) के माध्यम से उजागर करता है। इस संग्रह का उपयोग करके आप किसी नियंत्रण को संपादित कर सकते हैं, स्लाइड पर उसे स्थानांतरित कर सकते हैं, या हट सकते हैं।

## **ActiveX नियंत्रणों और उनके संग्रहीत गुणों की सूची**

अपरिचित टेम्पलेट का निरीक्षण करने के लिए, उसे पढ़ने के लिए खोलें और प्रत्येक स्लाइड पर मौजूद नियंत्रणों को क्रमवार देखें। उदाहरण स्लाइड नंबर, नियंत्रण का नाम, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), और [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) में प्रत्येक कुंजी-मूल्य युग्म को रिपोर्ट करता है। यह प्रस्तुति को नियंत्रनों को सक्रिय किए बिना, इवेंट या मैक्रो को बुलाए बिना, मान बदलें बिना, या फ़ाइल को सहेजे बिना पढ़ता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
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

`[]` के रूप में एक खाली प्रॉपर्टी कलेक्शन दिखता है। उन नियंत्रणों के लिए जो बाइनरी स्टोरेज का उपयोग करते हैं, `Properties` `null` लौट सकता है, जिसे `Properties unavailable` के रूप में दिखाया जाता है। यदि आपको केवल नाम चाहिए, तो null जांच के बाद [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) का उपयोग करें। रिपोर्ट प्रस्तुति से उपलब्ध प्रॉपर्टियों की सूची देती है। एक नियंत्रण रनटाइम में अतिरिक्त प्रॉपर्टियों का समर्थन कर सकता है।

## **ActiveX नियंत्रणों को संशोधित करें**

यह उदाहरण एक मैक्रो-सक्षम प्रस्तुति की अपेक्षा करता है जिसमें पहले स्लाइड पर `TextBox1` नामक एक टेक्स्ट बॉक्स और `CommandButton1` नामक एक कमांड बटन हो। यह टेक्स्ट बॉक्स के मान और बटन की कैप्शन को बदलने के लिए [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) का उपयोग करता है। प्रत्येक नियंत्रण का एक स्थैतिक प्रीव्यू भी होता है जिसे PowerPoint सक्रिय करने से पहले दिखा सकता है। प्रत्येक नियंत्रण के लिए एक PNG प्रदान करें जो उसके अपडेटेड टेक्स्ट और रूप को दर्शाता हो। यह उदाहरण इन छवियों को [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) के माध्यम से असाइन करता है।

उदाहरण पहले स्लाइड पर प्रत्येक नियंत्रण को उसके [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) को बदलकर 100 पॉइंट नीचे ले जाता है। यह संपादित प्रस्तुति को PPTM फ़ॉर्मेट में सहेजता है, फिर [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) का उपयोग करके उस स्लाइड से सभी ActiveX नियंत्रण हटाकर दूसरी प्रति सहेजता है।

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**

कॉन्फ़िगर किए गए Windows Media Player नियंत्रण को पुन: उपयोग करने के लिए, एक टेम्पलेट से शुरू करें जिसकी पहली स्लाइड में `WindowsMediaPlayer1` नामक प्लेयर हो। [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) पूरी स्लाइड को नई प्रस्तुति में कॉपी करता है। उदाहरण प्लेयर के `URL` को उसकी [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) में सेट करता है और क्लोन की गई स्लाइड को आउटपुट में एकमात्र स्लाइड के रूप में सहेजता है। वीडियो बाहरी रहता है, इसलिए ऐसा पथ चुनें जिसे प्लेयर प्लेबैक के दौरान एक्सेस कर सके।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**क्या Aspose.Slides ActiveX नियंत्रणों को चलाए बिना संरक्षित रख सकता है?**  
हां। Aspose.Slides नियंत्रणों को पढ़ और संग्रहीत कर सकता है, जिसमें उनके गुण और स्थितियां शामिल हैं, बिना उन्हें सक्रिय किए।

**ActiveX नियंत्रण OLE ऑब्जेक्ट्स से कैसे अलग हैं?**  
ActiveX नियंत्रण उपयोगकर्ताओं को स्लाइड के साथ इंटरैक्ट करने देते हैं, उदाहरण के लिए टेक्स्ट दर्ज करके या बटन पर क्लिक करके। एक [OLE ऑब्जेक्ट](/slides/hi/net/manage-ole/) स्लाइड को किसी अन्य एप्लिकेशन द्वारा प्रबंधित सामग्री, जैसे Excel वर्कशीट, को समाहित या लिंक करने की अनुमति देता है।

**क्या Aspose.Slides के साथ प्रस्तुति सहेजने के बाद ActiveX इवेंट्स अभी भी VBA मैक्रोज़ को ट्रिगर करेंगे?**  
प्रस्तुति को PPTM जैसे मैक्रो-सक्षम फ़ॉर्मेट में सहेजें ताकि उसका VBA प्रोजेक्ट बरकरार रहे। Windows के लिए PowerPoint तब मौजूदा इवेंट हैंडलर चला सकता है जब उसकी सुरक्षा सेटिंग्स दोनों, ActiveX नियंत्रण और मैक्रोज़, की अनुमति देती हैं।
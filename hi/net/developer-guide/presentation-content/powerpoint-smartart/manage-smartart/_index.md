---
title: .NET में PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/net/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपा गुण
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "स्पष्ट C# कोड उदाहरणों का उपयोग करके .NET के लिए Aspose.Slides के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ बनाते हैं।"
---
## **परिचय**

SmartArt एक PowerPoint आरेख है जो नोड्स, नोड आकारों और लेआउट से बनाया जाता है। Aspose.Slides for .NET के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से पाठ पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे हुए नोड्स का निरीक्षण कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से पाठ प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। दृश्यमान पाठ पढ़ने के लिए, [ISmartArt.AllNodes](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartart/allnodes/) के माध्यम से इटरिट करें, फिर [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartartshape/textframe/) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) को पढ़ें।

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` मान होता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है।

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartartnode/ishidden/) दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। छिपे हुए नोड्स संरचना में मौजूद हो सकते हैं, भले ही चयनित लेआउट उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाए।

निम्न उदाहरण एक नोड को SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और नोड की छिपी स्थिति की जाँच करता है।

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt आरेखों के लिए जो संगठन चार्ट लेआउट का उपयोग करते हैं, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) निर्धारित करता है कि चाइल्ड नोड्स पैरेंट नोड के नीचे कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चाइल्ड नोड्स को बाएँ, दाएँ, या दोनों पक्षों से लटकाने के लिए सेट कर सकते हैं, यह चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/organizationchartlayouttype/) पर निर्भर करता है।

निम्न उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है।

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **एक चित्र संगठन चार्ट बनाएं**

चित्र संगठन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रम आरेखों के लिए डिजाइन किया गया है। जब SmartArt ऑब्जेक्ट को स्लाइड में जोड़ते हैं तो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें।

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। जब चयनित SmartArt लेआउट रिवर्सल को समर्थन देता है, तो [IsReversed](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartart/isreversed/) प्रॉपर्टी आरेख की दिशा को बाएँ-से-दाएँ से दाएँ-से-बाएँ या वापस बदल देती है।

**मैं फ़ॉर्मेटिंग को बनाए रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप [SmartArt shape को क्लोन कर सकते हैं](/slides/hi/net/shape-manipulations/) [ShapeCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/shapecollection/addclone/) के साथ या [सम्पूर्ण स्लाइड को क्लोन करें](/slides/hi/net/clone-slides/) जो SmartArt को शामिल करता है। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग बरकरार रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/net/convert-powerpoint-to-png/) या संपूर्ण प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि कई SmartArt ऑब्जेक्ट हैं तो स्लाइड पर एक विशिष्ट SmartArt ऑब्जेक्ट को कैसे खोजूँ?**

SmartArt shape पर एक विशिष्ट [AlternativeText](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/alternativetext/) या [Name](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/name/) मान सेट करें, उस मान को [Slide.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide/shapes/) में खोजें, और फिर जाँचें कि मिलती‑जुलती shape एक [ISmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartart/) है।
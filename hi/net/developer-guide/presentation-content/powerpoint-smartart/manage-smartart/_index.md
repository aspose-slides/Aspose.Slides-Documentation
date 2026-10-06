---
title: PowerPoint प्रस्तुतियों में .NET में SmartArt प्रबंधन
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/net/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "स्पष्ट C# कोड उदाहरणों का उपयोग करके .NET के लिए Aspose.Slides के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ करता है।"
---
## **समीक्षा**

SmartArt PowerPoint का एक आरेख है जो नोड्स, नोड शेप्स और लेआउट से निर्मित होता है। Aspose.Slides for .NET के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक शेप्स हो सकते हैं। नोड शेप्स से टेक्स्ट पढ़ने के लिए, [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/) के माध्यम से इटरेट करें, फिर [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) को पढ़ें।

उदाहरण के लिए एक प्रस्तुति आवश्यक है जिसमें कम से कम एक स्लाइड हो और उस स्लाइड में पहला शेप SmartArt ऑब्जेक्ट हो। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल पर प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट यह नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्नलिखित उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है। [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) को पास किया गया स्थिति और आकार बिंदुओं में मापा जाता है। लेआउट बदलने के लिए [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) सेट करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) इंगित करता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। छिपे हुए नोड्स संरचना में मौजूद हो सकते हैं भले ही चयनित लेआउट उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाए।

निम्नलिखित उदाहरण उन SmartArt ऑब्जेक्ट में एक नोड जोड़ता है जिसका [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` मान है और जोड़े गए नोड की छिपी स्थिति की जाँच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और आरेख को सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **ऑर्गनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

ऑर्गनाइज़ेशन चार्ट लेआउट वाले SmartArt आरेखों के लिए, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) यह निर्धारित करता है कि चाइल्ड नोड्स एक पैरेंट नोड के नीचे कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों पक्षों से लटकाने के लिए सेट कर सकते हैं।

निम्नलिखित उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित इंडेक्स `0` पहला टॉप-लेवल नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रस्तुति फिर सहेजी जाती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **पिक्चर ऑर्गनाइज़ेशन चार्ट बनाएं**

पिक्चर ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो इमेज प्लेसहोल्डर वाले पदानुक्रमिक आरेखों के लिए डिज़ाइन किया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण इमेज प्लेसहोल्डर वाले आरेख को सहेजता है; यह प्लेसहोल्डर को इमेज से नहीं भरता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **लेगेसी आरेखों को शेप्स के समूह में परिवर्तित करें**

मौजूदा प्रस्तुतीकरण को आधुनिक बनाने के दौरान, आपको PowerPoint 97–2003 में मूल रूप से बनाए गए ऑर्गनाइज़ेशन चार्ट को अपडेट करना पड़ सकता है। Aspose.Slides इन लेगेसी आरेखों को [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) ऑब्जेक्ट्स के रूप में दर्शाता है। आरेख को शेप्स के समूह में बदलने के लिए [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) का उपयोग करें ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) देखें।

कन्वर्ज़न मूल आरेख को हटाए बिना शेप कलेक्शन में एक नया ग्रुप जोड़ता है। सफल परिवर्तन के बाद, डुप्लिकेट कंटेंट से बचने के लिए मूल को [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) से हटाएँ। परिवर्तन से पहले लेगेसी आरेखों को एक एरे में एकत्रित करें ताकि शेप्स को जोड़ने या हटाने से इटरशन में बाधा न आए।

निम्नलिखित उदाहरण एक प्रस्तुति खोलता है, प्रत्येक स्लाइड को खोजता है, आरेखों को शेप्स के समूह में परिवर्तित करता है, और अपडेटेड प्रस्तुति को PPTX के रूप में सहेजता है।

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

सहेजी गई प्रस्तुति में परिवर्तित लेगेसी आरेखों की जगह संपादन योग्य शेप्स के समूह होते हैं, और साथ में कोई मूल आरेख नहीं रहता। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों जैसे टेक्स्ट, फिल या पोज़िशन को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। चयनित SmartArt लेआउट में रिवर्सल समर्थित होने पर, [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) प्रॉपर्टी आरेख की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ (या वापस) बदल देती है।

**मैं SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में फॉर्मेटिंग को संरक्षित रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [SmartArt शेप को क्लोन करें](/slides/hi/net/shape-manipulations/) के साथ [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) कर सकते हैं या SmartArt वाले पूरे स्लाइड को [पूरे स्लाइड को क्लोन करें](/slides/hi/net/clone-slides/) कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फॉर्मेटिंग संरक्षित रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/net/convert-powerpoint-to-png/) या पूरे प्रस्तुति को PNG या JPEG में। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर होता है।

**यदि कई SmartArt ऑब्जेक्ट हैं तो स्लाइड पर विशेष SmartArt ऑब्जेक्ट कैसे खोजूँ?**

SmartArt शेप पर एक विशिष्ट [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) या [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) मान सेट करें, इसे [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) में खोजें, और फिर जाँचें कि मिलते‑जुलते शेप [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) है या नहीं।
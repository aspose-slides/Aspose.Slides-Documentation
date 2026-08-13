---
title: Aspose.Slides for .NET 16.2.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकींग चेंजेस की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, और Aspose.Slides for .NET 16.2.0 API के साथ लाए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Properties UpdateDateTimeFields और UpdateSlideNumberFields को हटा दिया गया है**
Properties UpdateDateTimeFields और UpdateSlideNumberFields को Aspose.Slides.Presentation क्लास और Aspose.Slides.IPresentation इंटरफ़ेस से हटा दिया गया है।
Aspose.Slides.TextFrame, Paragraph, Portion क्लासेस और Aspose.Slides.ITextFrame, IParagraph, IPortion इंटरफ़ेसेस की Text प्रॉपर्टी अद्यतन "datetime" फ़ील्ड्स के साथ टेक्स्ट लौटाती है।
इसके अलावा Presentation.DocumentProperties.CreatedTime, LastSavedTime और LastPrinted प्रॉपर्टीज़ केवल-रिडेबल हो गई हैं।
#### **Enum Slides.Charts.CategoryAxisType को सार्वजनिक बना दिया गया है**
IAxis.CategoryAxisType और Axis.CategoryAxisType प्रॉपर्टीज़ में श्रेणी एक्सिस प्रकार निर्धारित करने के लिए उपयोग किया जाता है।
CategoryAxisType.Auto - श्रेणी एक्सिस प्रकार स्वचालित रूप से सीरियलाइज़ेशन के दौरान निर्धारित होगा (यह व्यवहार वर्तमान में लागू नहीं है)
CategoryAxisType.Text - श्रेणी एक्सिस प्रकार Text है
CategoryAxisType.Date - श्रेणी एक्सिस प्रकार DateTime है
#### **तेज़ टेक्स्ट निष्कर्षण**
Presentation क्लास में नया स्थैतिक मेथड GetPresentationText जोड़ा गया है। इस मेथड के दो ओवरलोड उपलब्ध हैं:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode enum आर्ग्युमेंट टेक्स्ट परिणाम के आउटपुट को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्नलिखित मानों पर सेट किया जा सकता है:
Unarranged - स्लाइड पर स्थिति की परवाह किए बिना कच्चा टेक्स्ट
Arranged - टेक्स्ट स्लाइड पर उसी क्रम में स्थित है

जब गति महत्वपूर्ण हो तो Unarranged मोड का उपयोग किया जा सकता है, यह Arranged मोड से तेज़ होता है।

PresentationText प्रस्तुति से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसमें Aspose.Slides.Util नेमस्पेस की SlidesText प्रॉपर्टी होती है जो ISlideText ऑब्जेक्ट्स की एक ऐरे लौटाती है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर टेक्स्ट दर्शाता है। ISlideText ऑब्जेक्ट में निम्नलिखित प्रॉपर्टीज़ होती हैं:
ISlideText.Text - स्लाइड के शेप्स पर टेक्स्ट
ISlideText.MasterText - इस स्लाइड के मास्टर पेज के शेप्स पर टेक्स्ट
ISlideText.LayoutText - इस स्लाइड के लेआउट पेज के शेप्स पर टेक्स्ट
ISlideText.NotesText - इस स्लाइड के नोट्स पेज के शेप्स पर टेक्स्ट

एक SlideText क्लास भी है जो ISlideText इंटरफ़ेस को इम्प्लीमेंट करती है।

नया API इस प्रकार उपयोग किया जा सकता है:

``` csharp
using System;
using Aspose.Slides;

// स्लाइड पर उसके स्थान की परवाह किए बिना टेक्स्ट निकालें (सबसे तेज़ मोड)।
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// स्लाइड पर उसी क्रम में स्थित टेक्स्ट निकालें।
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **ILegacyDiagram इंटरफ़ेस और LegacyDiagram क्लास जोड़ी गई हैं**
Interface Aspose.Slides.ILegacyDiagram और क्लास Aspose.Slides.LegacyDiagram को लेगेसी डायग्राम ऑब्जेक्ट को दर्शाने के लिए जोड़ा गया है। लेगेसी डायग्राम ऑब्जेक्ट PowerPoint 97-2003 के पुराने फ़ॉर्मेट का डायग्राम है।
नई क्लास लेगेसी डायग्राम को आधुनिक संपादन योग्य SmartArt ऑब्जेक्ट या संपादन योग्य GroupShape में बदलने के लिए मेथड्स प्रदान करती है।
#### **नया Aspose.Slides.TextAlignment enum सदस्य जोड़ा गया (JustifyLow)**
TextAlignment enum में नया सदस्य जोड़ा गया: JustifyLow - Kashida low जस्टिफ़िकेशन।
#### **Aspose.Slides.IOleObjectFrame और OleObjectFrame के लिए नई प्रॉपर्टीज़**
IOleObjectFrame इंटरफ़ेस और इसे इम्प्लीमेंट करने वाली OleObjectFrame क्लास में नई प्रॉपर्टीज़ जोड़ी गई हैं। इन प्रॉपर्टीज़ का उपयोग प्रस्तुति में एम्बेडेड ऑब्जेक्ट के बारे में जानकारी प्रदान करने के लिए किया जाता है:
EmbeddedFileExtension - वर्तमान एम्बेडेड ऑब्जेक्ट के फ़ाइल एक्सटेंशन को लौटाती है या यदि ऑब्जेक्ट लिंक नहीं है तो खाली स्ट्रिंग लौटाती है
EmbeddedFileLabel - एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल नाम लौटाती है
EmbeddedFileName - एम्बेडेड OLE ऑब्जेक्ट का पथ लौटाती है
#### **IAxis और Axis क्लासेज़ में नई प्रॉपर्टी CategoryAxisType जोड़ी गई**
प्रॉपर्टी CategoryAxisType श्रेणी अक्ष का प्रकार निर्दिष्ट करती है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **DataLabelFormat क्लास और IDataLabelFormat इंटरफ़ेस में नई प्रॉपर्टी ShowLabelAsDataCallout जोड़ी गई**
प्रॉपर्टी ShowLabelAsDataCallout निर्धारित करती है कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में दिखेगा या डेटा लेबल के रूप में।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **PdfOptions और XpsOptions में नई प्रॉपर्टी DrawSlidesFrame जोड़ी गई**
बूलियन प्रॉपर्टी DrawSlidesFrame को इंटरफ़ेस Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions और संबंधित क्लासेज़ Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions में जोड़ा गया है। यदि इस प्रॉपर्टी को 'true' सेट किया जाता है, तो प्रत्येक स्लाइड के चारों ओर काला फ्रेम ड्रॉ किया जाएगा।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```
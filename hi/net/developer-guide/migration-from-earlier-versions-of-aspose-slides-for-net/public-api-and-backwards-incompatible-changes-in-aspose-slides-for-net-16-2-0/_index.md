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
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि, तथा Aspose.Slides for .NET 16.2.0 API के साथ पेश किए गए अन्य परिवर्तनों को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **प्रॉपर्टीज़ UpdateDateTimeFields और UpdateSlideNumberFields हटा दिए गए हैं**
प्रॉपर्टीज़ UpdateDateTimeFields और UpdateSlideNumberFields को Aspose.Slides.Presentation क्लास और Aspose.Slides.IPresentation इंटरफ़ेस से हटा दिया गया है।  
Aspose.Slides.TextFrame, Paragraph, Portion क्लासों और Aspose.Slides.ITextFrame, IParagraph, IPortion इंटरफ़ेस की Text प्रॉपर्टी अपडेटेड "datetime" फ़ील्ड्स के साथ टेक्स्ट लौटाती है।  
साथ ही प्रॉपर्टीज़ Presentation.DocumentProperties.CreatedTime, LastSavedTime और LastPrinted रीड‑ओनली हो गए हैं।  
#### **Enum Slides.Charts.CategoryAxisType सार्वजनिक बना दिया गया है**
यह IAxis.CategoryAxisType और Axis.CategoryAxisType प्रॉपर्टीज़ में श्रेणी अक्ष प्रकार निर्धारित करने के लिए उपयोग किया जाता है।  
CategoryAxisType.Auto - श्रेणी अक्ष प्रकार को सीरियलाइज़ेशन के दौरान स्वतः निर्धारित किया जाएगा (यह व्यवहार अभी लागू नहीं हुआ है)  
CategoryAxisType.Text - श्रेणी अक्ष प्रकार Text है।  
CategoryAxisType.Date - श्रेणी अक्ष प्रकार DateTime है।  
#### **तेज़ टेक्स्ट निष्कर्षण**
Presentation क्लास में नया स्थैतिक मेथड GetPresentationText जोड़ा गया है। इस मेथड के दो ओवरलोड उपलब्ध हैं:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode enum तर्क यह दर्शाता है कि टेक्स्ट परिणाम के आउटपुट को कैसे व्यवस्थित किया जाएगा और इसे निम्नलिखित मानों में सेट किया जा सकता है:  
Unarranged - स्लाइड पर स्थिति की परवाह किए बिना कच्चा टेक्स्ट  
Arranged - टेक्स्ट स्लाइड पर उसी क्रम में स्थित है जैसा कि स्लाइड पर है  

जब गति महत्वपूर्ण हो तो Unarranged मोड का उपयोग किया जा सकता है, यह Arranged मोड से तेज़ है।

PresentationText प्रस्तुति से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसमें Aspose.Slides.Util नेमस्पेस से SlidesText प्रॉपर्टी शामिल है जो ISlideText ऑब्जेक्ट्स की एक एरे लौटाती है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को दर्शाता है। ISlideText ऑब्जेक्ट में निम्नलिखित प्रॉपर्टीज़ होती हैं:

ISlideText.Text - स्लाइड की शैप्स पर टेक्स्ट  
ISlideText.MasterText - इस स्लाइड के लिए मास्टर पेज की शैप्स पर टेक्स्ट  
ISlideText.LayoutText - इस स्लाइड के लिए लेआउट पेज की शैप्स पर टेक्स्ट  
ISlideText.NotesText - इस स्लाइड के लिए नोट्स पेज की शैप्स पर टेक्स्ट  

इसके अलावा एक SlideText क्लास है जो ISlideText इंटरफ़ेस को लागू करती है।

नया API इस प्रकार उपयोग किया जा सकता है:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagram इंटरफ़ेस और LegacyDiagram क्लास जोड़े गए हैं**
Aspose.Slides.ILegacyDiagram इंटरफ़ेस और Aspose.Slides.LegacyDiagram क्लास को लेगेसी डायग्राम ऑब्जेक्ट को प्रतिनिधित्व करने के लिए जोड़ा गया है। लेगेसी डायग्राम ऑब्जेक्ट PowerPoint 97‑2003 के पुराने डायग्राम फ़ॉर्मेट का है। नई क्लास लेगेसी डायग्राम को आधुनिक संपादनीय SmartArt ऑब्जेक्ट या संपादनीय GroupShape में परिवर्तित करने के मेथड प्रदान करती है।  
#### **नया Aspose.Slides.TextAlignment Enum सदस्य जोड़ा गया (JustifyLow)**
TextAlignment enum में एक नया सदस्य जोड़ा गया है:  
JustifyLow - कम स्तर का कशीदा जस्टिफ़ाई।  
#### **Aspose.Slides.IOleObjectFrame और OleObjectFrame के लिए नई प्रॉपर्टीज़**
IOleObjectFrame इंटरफ़ेस और इसे लागू करने वाली OleObjectFrame क्लास में नई प्रॉपर्टीज़ जोड़ी गई हैं। ये प्रॉपर्टीज़ प्रस्तुति में एम्बेडेड ऑब्जेक्ट के बारे में जानकारी प्रदान करती हैं:  
EmbeddedFileExtension - वर्तमान एम्बेडेड ऑब्जेक्ट का फ़ाइल एक्सटेंशन लौटाती है या यदि ऑब्जेक्ट लिंक नहीं है तो खाली स्ट्रिंग देती है।  
EmbeddedFileLabel - एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल नाम लौटाती है।  
EmbeddedFileName - एम्बेडेड OLE ऑब्जेक्ट का पाथ लौटाती है।  
#### **IAxis और Axis क्लासेस में नया प्रॉपर्टी CategoryAxisType जोड़ा गया है**
CategoryAxisType प्रॉपर्टी श्रेणी अक्ष के प्रकार को निर्दिष्ट करती है।

``` csharp

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
#### **DataLabelFormat क्लास और IDataLabelFormat इंटरफ़ेस में नया प्रॉपर्टी ShowLabelAsDataCallout जोड़ा गया है**
ShowLabelAsDataCallout प्रॉपर्टी यह निर्धारित करती है कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में दिखाया जाएगा या डेटा लेबल के रूप में।

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **PdfOptions और XpsOptions में प्रॉपर्टी DrawSlidesFrame जोड़ा गया है**
Boolean प्रॉपर्टी DrawSlidesFrame को Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions इंटरफ़ेस और संबंधित Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions क्लासों में जोड़ा गया है।  
यदि यह प्रॉपर्टी 'true' सेट की जाती है तो प्रत्येक स्लाइड के चारों ओर काली फ्रेम खींची जाएगी।

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```
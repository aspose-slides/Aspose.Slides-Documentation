---
title: Aspose.Slides for .NET 14.8.0 में सार्वजनिक API और पिछड़ी असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- स्थानांतरण
- पुरानी कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और तोड़ने वाले बदलावों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधानों को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 
यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, और Aspose.Slides for .NET 14.8.0 API द्वारा प्रस्तुत अन्य परिवर्तनों की सूची देता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **बदले हुए प्रॉपर्टीज़**
#### **IVbaProject इंटरफ़ेस जोड़ा गया, Presentation.VbaProject प्रॉपर्टी बदली गई**
Presentation क्लास की VbaProject प्रॉपर्टी को बदल दिया गया है। VbaProject प्रॉपर्टी के VBA प्रोजेक्ट के कच्चे बाइट प्रतिनिधित्व की जगह, नया IVbaProject इंटरफ़ेस इम्प्लीमेंटेशन जोड़ा गया है।

एक प्रस्तुति में एम्बेड किए गए VBA प्रोजेक्ट्स को प्रबंधित करने के लिए IVbaProject प्रॉपर्टी का उपयोग करें। आप नए प्रोजेक्ट रेफ़रेंसेज जोड़ सकते हैं, मौजूदा मॉड्यूल्स को संपादित कर सकते हैं और नए बना सकते हैं।

इसके अलावा, आप VbaProject क्लास का उपयोग करके नया VBA प्रोजेक्ट बना सकते हैं, जो IVbaProject इंटरफ़ेस को लागू करता है।

निम्न उदाहरण एक सरल VBA प्रोजेक्ट बनाना दर्शाता है जिसमें एक मॉड्यूल होता है और लाइब्रेरीज़ में दो आवश्यक रेफ़रेंसेज जोड़ी गई हैं।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // नया VBA प्रोजेक्ट बनाएं
    pres.VbaProject = new VbaProject();

    // VBA प्रोजेक्ट में खाली मॉड्यूल जोड़ें
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // मॉड्यूल का स्रोत कोड सेट करें
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // <stdole> के लिए रेफ़रेंस बनाएं
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office के लिए रेफ़रेंस बनाएं
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA प्रोजेक्ट में रेफ़रेंसेज जोड़ें
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

यह उदाहरण दिखाता है कि मौजूदा प्रस्तुति से एक VBA प्रोजेक्ट को नई प्रस्तुति में कैसे कॉपी किया जाए।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **इंटरफ़ेस, प्रॉपर्टीज़ और एनोमरेशन विकल्प जोड़े गए**
#### **Aspose.Slides.Charts.IChartSeries.Overlap प्रॉपर्टी जोड़ी गई**
Aspose.Slides.Charts.IChartSeries.Overlap प्रॉपर्टी यह निर्दिष्ट करती है कि 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप करेंगे (रेंज -100 से 100 तक).

यह प्रॉपर्टी केवल इस सीरीज़ की ही नहीं, बल्कि पैरेंट सीरीज़ ग्रुप में सभी सीरीज़ की भी है - यह उपयुक्त ग्रुप प्रॉपर्टी का प्रोजेक्शन है। इसलिए यह प्रॉपर्टी केवल-रेड है।

- पैरेंट सीरीज़ ग्रुप तक पहुंचने के लिए ParentSeriesGroup प्रॉपर्टी का उपयोग करें।
- मान बदलने के लिए ParentSeriesGroup.Overlap पढ़ने/लिखने वाली प्रॉपर्टी का उपयोग करें।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Aspose.Slides.Charts.IChartSeriesGroup.Overlap प्रॉपर्टी जोड़ी गई**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap प्रॉपर्टी यह निर्धारित करती है कि 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप करेंगे (रेंज -100 से 100 तक).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **ShapeThumbnailBounds.Appearance एनम वैल्यू जोड़ी गई**
यह विधि आकार थंबनेल निर्माण की अनुमति देती है ताकि वह आकार की उपस्थिति के बाउंड्स में बना रहे। यह सभी आकार इफेक्ट्स को ध्यान में रखती है। उत्पन्न आकार थंबनेल स्लाइड बाउंड्स द्वारा सीमित होता है।

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```
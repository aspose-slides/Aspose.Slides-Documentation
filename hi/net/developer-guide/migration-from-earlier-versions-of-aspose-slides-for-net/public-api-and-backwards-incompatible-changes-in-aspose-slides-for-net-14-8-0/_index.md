---
title: Aspose.Slides for .NET 14.8.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- रूपांतरण
- पारम्परिक कोड
- आधुनिक कोड
- पारम्परिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अद्यतन और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा Aspose.Slides for .NET 14.8.0 API में प्रस्तुत किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Presentation क्लास की VbaProject प्रॉपर्टी को बदल दिया गया है। VbaProject प्रॉपर्टी के VBA प्रोजेक्ट के कच्चे बाइट प्रतिनिधित्व के बजाय, नया IVbaProject इंटरफ़ेस इम्प्लीमेंटेशन जोड़ा गया है।

IVbaProject प्रॉपर्टी का उपयोग करके आप प्रस्तुति में एम्बेडेड VBA प्रोजेक्ट को प्रबंधित कर सकते हैं। आप नए प्रोजेक्ट रेफ़रेंसेज़ जोड़ सकते हैं, मौजूदा मॉड्यूल्स को संपादित कर सकते हैं और नए मॉड्यूल बना सकते हैं।

इसके अलावा, आप VbaProject क्लास का उपयोग करके नया VBA प्रोजेक्ट बना सकते हैं जो IVbaProject इंटरफ़ेस को इम्प्लीमेंट करती है।

निम्न उदाहरण एक सरल VBA प्रोजेक्ट बनाता है जिसमें एक मॉड्यूल होता है और दो आवश्यक लाइब्रेरी रेफ़रेंसेज़ को जोड़ता है।

``` csharp

 using (Presentation pres = new Presentation())

{

    // नया VBA प्रोजेक्ट बनाएँ
    pres.VbaProject = new VbaProject();

    // VBA प्रोजेक्ट में खाली मॉड्यूल जोड़ें
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // मॉड्यूल सोर्स कोड सेट करें
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

    // VBA प्रोजेक्ट में रेफ़रेंस जोड़ें
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

यह उदाहरण दिखाता है कि कैसे एक मौजूदा प्रस्तुति से नया VBA प्रोजेक्ट कॉपी किया जाता है।

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Aspose.Slides.Charts.IChartSeries.Overlap प्रॉपर्टी निर्धारित करती है कि 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप करेंगे (रेंज -100 से 100 तक)।

यह प्रॉपर्टी केवल इस सीरीज़ की नहीं बल्कि पैरेंट सीरीज़ समूह की सभी सीरीज़ की है – यह उपयुक्त समूह प्रॉपर्टी का प्रोजेक्शन है। इसलिए यह प्रॉपर्टी केवल-रेड है।

- पैरेंट सीरीज़ समूह तक पहुंचने के लिए ParentSeriesGroup प्रॉपर्टी का उपयोग करें।
- मान बदलने के लिए ParentSeriesGroup.Overlap पढ़ने/लिखने योग्य प्रॉपर्टी का उपयोग करें।

``` csharp

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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap प्रॉपर्टी निर्धारित करती है कि 2D चार्ट्स पर बार और कॉलम कितनी ओवरलैप करेंगे (रेंज -100 से 100 तक)।

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
यह मेथड शैप थंबनेल निर्माण की अनुमति देता है जिससे शैप थंबनेल उसकी उपस्थिति की सीमाओं में उत्पन्न किया जाता है। यह सभी शैप इफ़ेक्ट्स को ध्यान में रखता है। उत्पन्न शैप थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित होता है।

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}
```
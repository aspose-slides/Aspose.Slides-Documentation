---
title: ".NET में प्रस्तुतियों में हेडर और फुटर कैसे जोड़ें"
linktitle: "हेडर और फुटर जोड़ें"
type: docs
weight: 20
url: /hi/net/how-to-add-header-footer-in-a-presentation/
keywords:
- "माइग्रेशन"
- "हेडर जोड़ें"
- "फ़ुटर जोड़ें"
- "लेगेसी कोड"
- "आधुनिक कोड"
- "लेगेसी दृष्टिकोण"
- "आधुनिक दृष्टिकोण"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET में PowerPoint PPT, PPTX और ODP प्रस्तुतियों में हेडर और फुटर जोड़ने के लिए लेगेसी और आधुनिक Aspose.Slides APIs दोनों का उपयोग कैसे करें, सीखें।"
---
{{% alert color="info" %}} 
एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद स्क्रैच से PowerPoint दस्तावेज़ बनाने और मौजूदा दस्तावेज़ों को संपादित करने की क्षमता को समर्थन देता है।
{{% /alert %}} 
## **लेगेसी कोड के लिए समर्थन**
Aspose.Slides for .NET के 13.x से पहले के संस्करणों के साथ विकसित लेगेसी कोड का उपयोग करने के लिए, आपको अपने कोड में कुछ छोटे परिवर्तन करने होंगे और कोड पहले की तरह काम करेगा। पुराने Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नेमस्पेस के तहत मौजूद सभी क्लासेज अब एकल Aspose.Slides नेमस्पेस में मिलाए गए हैं। कृपया निम्नलिखित सरल कोड स्निपेट देखें जो लेगेसी Aspose.Slides API में प्रस्तुति में हेडर फुटर जोड़ता है और नई मर्ज्ड API में माइग्रेट करने के चरणों का पालन करें।
## **लेगेसी Aspose.Slides for .NET दृष्टिकोण**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//प्रस्तुति बनाएँ
Presentation pres = new Presentation();

//पहली स्लाइड प्राप्त करें
Slide sld = pres.GetSlideByPosition(1);

//स्लाइड के हेडर / फुटर तक पहुँचें
HeaderFooter hf = sld.HeaderFooter;

//पेज नंबर की दृश्यता सेट करें
hf.PageNumberVisible = true;

//फुटर की दृश्यता सेट करें
hf.FooterVisible = true;

//हेडर की दृश्यता सेट करें
hf.HeaderVisible = true;

//तारीख समय की दृश्यता सेट करें
hf.DateTimeVisible = true;

//तारीख समय का फ़ॉर्मेट सेट करें
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//हेडर टेक्स्ट सेट करें
hf.HeaderText = "Header Text";

//फुटर टेक्स्ट सेट करें
hf.FooterText = "Footer Text";

//प्रस्तुति को डिस्क पर लिखें
pres.Write("HeadFoot.ppt");
```

## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //हेडर फुटर दृश्यता गुण सेट करना
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //डेट टाइम फ़ील्ड अपडेट करें
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //डेट टाइम प्लेसहोल्डर दिखाएँ
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //फ़ुटर प्लेसहोल्डर दिखाएँ
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //टाइटल स्लाइड पर हेडर फुटर दृश्यता सेट करें
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //प्रस्तुति को डिस्क पर लिखें
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
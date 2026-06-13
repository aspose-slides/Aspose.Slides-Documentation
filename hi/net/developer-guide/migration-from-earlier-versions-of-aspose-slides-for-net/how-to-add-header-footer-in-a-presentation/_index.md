---
title: ".NET में प्रस्तुतियों में हेडर और फुटर जोड़ने का तरीका"
linktitle: "हेडर और फुटर जोड़ें"
type: docs
weight: 20
url: /hi/net/how-to-add-header-footer-in-a-presentation/
keywords:
- माइग्रेशन
- हेडर जोड़ें
- फुटर जोड़ें
- पुराना कोड
- आधुनिक कोड
- पारम्परिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में PowerPoint PPT, PPTX और ODP प्रस्तुतियों में हेडर और फुटर कैसे जोड़ें, यह सीखें, लेगेसी और आधुनिक दोनों Aspose.Slides API का उपयोग करके।"
---
{{% alert color="primary" %}} 
एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद शून्य से PowerPoint दस्तावेज़ बनाने और मौजूदा दस्तावेज़ों को संपादित करने की क्षमता का समर्थन करता है।
{{% /alert %}} 
## **Legacy कोड के लिए समर्थन**
13.x से पहले की Aspose.Slides for .NET संस्करणों के साथ विकसित किए गए लेगेसी कोड का उपयोग करने के लिए, आपको अपने कोड में कुछ छोटे परिवर्तन करने की आवश्यकता है और कोड पहले की तरह कार्य करेगा। पुराने Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नेमस्पेसेस के अंतर्गत मौजूद सभी क्लासेज अब एकल Aspose.Slides नेमस्पेस में मर्ज कर दी गई हैं। कृपया नीचे दिए गए सरल कोड स्निपेट को देखें जो लेगेसी Aspose.Slides API में प्रस्तुति में हेडर फुटर जोड़ने के लिए है और नई मर्ज्ड API में माइग्रेट करने के चरणों का अनुसरण करें।
## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
PresentationEx sourcePres = new PresentationEx();

//हेडर फुटर दृश्यता गुण सेट कर रहा है
sourcePres.UpdateSlideNumberFields = true;

//डेट टाइम फ़ील्ड्स को अपडेट करें
sourcePres.UpdateDateTimeFields = true;

//डेट टाइम प्लेसहोल्डर दिखाएँ
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//फ़ुटर प्लेसहोल्डर दिखाएँ
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//स्लाइड नंबर दिखाएँ
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//टाइटल स्लाइड पर हेडर फुटर की दृश्यता सेट करें
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//प्रस्तुति को डिस्क पर लिखें
sourcePres.Write("NewSource.pptx");
```

```c#
//प्रस्तुति बनाएं
Presentation pres = new Presentation();

//पहली स्लाइड प्राप्त करें
Slide sld = pres.GetSlideByPosition(1);

//स्लाइड के हेडर / फुटर तक पहुंचें
HeaderFooter hf = sld.HeaderFooter;

//पेज नंबर दृश्यता सेट करें
hf.PageNumberVisible = true;

//फुटर दृश्यता सेट करें
hf.FooterVisible = true;

//हेडर दृश्यता सेट करें
hf.HeaderVisible = true;

//डेट टाइम दृश्यता सेट करें
hf.DateTimeVisible = true;

//डेट टाइम प्रारूप सेट करें
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//हेडर टेक्स्ट सेट करें
hf.HeaderText = "Header Text";

//फ़ुटर टेक्स्ट सेट करें
hf.FooterText = "Footer Text";

//प्रेजेंटेशन को डिस्क पर लिखें
pres.Write("HeadFoot.ppt");
```

## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //हेडर फुटर दृश्यता गुण सेट कर रहा है
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //डेट टाइम फ़ील्ड्स को अपडेट करें
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //डेट टाइम प्लेसहोल्डर दिखाएँ
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //फ़ुटर प्लेसहोल्डर दिखाएँ
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //टाइटल स्लाइड पर हेडर फुटर की दृश्यता सेट करें
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //प्रेजेंटेशन को डिस्क पर लिखें
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
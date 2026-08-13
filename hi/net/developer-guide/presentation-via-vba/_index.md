---
title: ".NET में प्रेजेंटेशन में VBA प्रोजेक्ट्स को प्रबंधित करें"
linktitle: "VBA के माध्यम से प्रेजेंटेशन"
type: docs
weight: 250
url: /hi/net/presentation-via-vba/
keywords:
- मैक्रो
- VBA
- VBA मैक्रो
- मैक्रो जोड़ें
- मैक्रो हटाएँ
- मैक्रो निकालें
- VBA जोड़ें
- VBA हटाएँ
- VBA निकालें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रेजेंटेशन बनाना और उन्हें संशोधित करना सीखें, जिससे आपका कार्यप्रवाह सुगम बन सके।"
---
## **परिचय**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

जब आप macros वाले प्रेजेंटेशन को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में कनवर्ट करते हैं, तो Aspose.Slides सभी macros को नजरअंदाज़ करता है (macros परिणामी फ़ाइल में नहीं रखे जाते)।

जब आप प्रेजेंटेशन में macros जोड़ते हैं या macros वाले प्रेजेंटेशन को पुनः सेव करते हैं, तो Aspose.Slides बस macros के बाइट्स लिख देता है।

Aspose.Slides **कभी भी** प्रेजेंटेशन में macros को नहीं चलाता।

{{% /alert %}}

## **VBA Macros जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट्स (और प्रोजेक्ट रेफ़रेंसेज़) बना सकते हैं और मौजूदा मॉड्यूल को संपादित कर सकते हैं। आप [IVbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/ivbaproject/) इंटरफ़ेस का उपयोग करके प्रेजेंटेशन में एम्बेडेड VBA को प्रबंधित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) कन्स्टरक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल का स्रोत कोड सेट करें।
1. <stdole> के रेफ़रेंसेज़ जोड़ें।
1. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें।
1. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ संबद्ध करें।
1. प्रेजेंटेशन को सेव करें।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// प्रेजेंटेशन क्लास का एक इंस्टेंस बनाता है
using (Presentation presentation = new Presentation())
{
    // एक नया VBA प्रोजेक्ट बनाता है
    presentation.VbaProject = new VbaProject();

    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // मॉड्यूल का स्रोत कोड सेट करता है
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole> के लिए रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office के लिए रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA प्रोजेक्ट में रेफ़रेंस जोड़ता है
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // प्रेजेंटेशन को सेव करता है
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) देख सकते हैं, जो एक मुफ्त वेब एप है जिसका उपयोग PowerPoint, Excel, और Word दस्तावेज़ों से macros को हटाने के लिए किया जाता है। 

{{% /alert %}} 

## **VBA Macros हटाएँ**
[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास के तहत [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/vbaproject/) प्रॉपर्टी का उपयोग करके आप VBA macro हटा सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ और macro वाली प्रेजेंटेशन लोड करें।
1. Macro मॉड्यूल को एक्सेस करें और उसे हटाएँ।
1. परिवर्तित प्रेजेंटेशन को सेव करें।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// मैक्रो वाले प्रेजेंटेशन को लोड करता है
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Vba मॉड्यूल तक पहुँचता है और उसे हटाता है
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // प्रेजेंटेशन को सेव करता है
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA Macros निकालें**
1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ और macro वाली प्रेजेंटेशन लोड करें।
2. जाँचें कि प्रेजेंटेशन में VBA Project मौजूद है या नहीं।
3. VBA Project में मौजूद सभी मॉड्यूल को लूप करके macros देखें।

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // मैक्रो वाले प्रेजेंटेशन को लोड करता है
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // जाँचता है कि प्रेजेंटेशन में VBA प्रोजेक्ट मौजूद है या नहीं
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **जाँचें कि VBA Project पासवर्ड-प्रोटेक्टेड है या नहीं**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) प्रॉपर्टी का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड-प्रोटेक्टेड हैं या नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ और macro वाली प्रेजेंटेशन लोड करें।
2. जाँचें कि प्रेजेंटेशन में [VBA project](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/) मौजूद है या नहीं।
3. VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं, यह जाँचें ताकि उसकी प्रॉपर्टीज़ देख सकें।

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // जाँचें कि प्रेजेंटेशन में VBA प्रोजेक्ट मौजूद है या नहीं।
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### यदि मैं प्रेजेंटेशन को PPTX के रूप में सेव करूँ तो macros का क्या होता है?

Macros हटा दिए जाएंगे क्योंकि PPTX VBA को सपोर्ट नहीं करता। Macros को रखने के लिए, PPTM, PPSM, या POTM चुनें।

### क्या Aspose.Slides प्रेजेंटेशन के भीतर macros चला सकता है, उदाहरण के लिए डेटा रिफ्रेश करने के लिए?

नहीं। यह लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint के भीतर उपयुक्त सुरक्षा सेटिंग्स के साथ संभव है।

### क्या VBA कोड से जुड़े ActiveX नियंत्रणों के साथ काम करना समर्थित है?

हां, आप मौजूदा [ActiveX controls](/slides/hi/net/activex/) को एक्सेस कर सकते हैं, उनकी प्रॉपर्टीज़ बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब macros ActiveX के साथ इंटरैक्ट करते हैं।
---
title: .NET में प्रस्तुतियों में VBA प्रोजेक्ट प्रबंधित करें
linktitle: VBA के माध्यम से प्रस्तुति
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
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ VBA के द्वारा PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और संशोधित करके अपने कार्यप्रवाह को सरल बनाएं।"
---
## **परिचय**

[Aspose.Slides.Vba](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/) नेमस्पेस में मैक्रो और VBA कोड के साथ काम करने के लिए क्लास और इंटरफ़ेस शामिल हैं।

{{% alert title="Note" color="warning" %}} 
जब आप मैक्रो वाले प्रस्तुति को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में बदलते हैं, तो Aspose.Slides सभी मैक्रो को अनदेखा करता है (मैक्रो परिणामस्वरूप फ़ाइल में नहीं ले जाते)।

जब आप प्रस्तुति में मैक्रो जोड़ते हैं या मैक्रो वाले प्रस्तुति को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रो नहीं चलाता है।
{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेस) बना सकते हैं और मौजूदा मॉड्यूल को संपादित कर सकते हैं। आप प्रस्तुति में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/ivbaproject/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं।
1. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) कंस्ट्रक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल का स्रोत कोड सेट करें।
1. <stdole> के रेफ़रेंस जोड़ें।
1. **Microsoft Office** के रेफ़रेंस जोड़ें।
1. रेफ़रेंस को VBA प्रोजेक्ट से जोड़ें।
1. प्रस्तुति सहेजें।

यह C# कोड आपको दिखाता है कि कैसे एक नई VBA मैक्रो को शून्य से प्रस्तुति में जोड़ा जाता है:

```c#
    // प्रेज़ेंटेशन क्लास का एक इंस्टैंस बनाता है
using (Presentation presentation = new Presentation())
{
    // नया VBA प्रोजेक्ट बनाता है
    presentation.VbaProject = new VbaProject();

    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // मॉड्यूल का स्रोत कोड सेट करता है
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole> के लिए एक रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office के लिए एक रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA प्रोजेक्ट में रेफ़रेंसेस जोड़ता है
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // प्रेज़ेंटेशन सहेजता है
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 
आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देखना चाहेंगे, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 
{{% /alert %}} 

## **VBA मैक्रो हटाएँ**
[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास के अंतर्गत [VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/vbaproject/) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो हटा सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं और मैक्रो वाली प्रस्तुति लोड करें।
1. Macro मॉड्यूल तक पहुंचें और उसे हटाएं।
1. परिवर्तित प्रस्तुति सहेजें।

यह C# कोड आपको दिखाता है कि कैसे एक VBA मैक्रो हटाई जाती है:

```c#
    // मैक्रो वाले प्रस्तुति को लोड करता है
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Vba मॉड्यूल तक पहुंचता है और उसे हटाता है
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // प्रस्तुति सहेजता है
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA मैक्रो निकालें**
1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं और मैक्रो वाली प्रस्तुति लोड करें।
2. जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल्स को लूप करके मैक्रो देखें।

यह C# कोड आपको दिखाता है कि कैसे मैक्रो वाले प्रस्तुति से VBA मैक्रो निकाली जाती हैं:

```c#
    // मैक्रो वाले प्रस्तुति को लोड करता है
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // जाँचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड‑प्रोटेक्टेड है या नहीं**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) प्रॉपर्टी का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टी पासवर्ड‑प्रोटेक्टेड है या नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं और मैक्रो वाली प्रस्तुति लोड करें।
2. जाँचें कि प्रस्तुति में [VBA project](https://reference.aspose.com/slides/hi/net/aspose.slides.vba/vbaproject/) है या नहीं।
3. जाँचें कि VBA प्रोजेक्ट पासवर्ड‑प्रोटेक्टेड है या नहीं, ताकि उसकी प्रॉपर्टी देखी जा सके।

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रो का क्या होता है?**

मैक्रो हटा दिए जाते हैं क्योंकि PPTX VBA को सपोर्ट नहीं करता। मैक्रो को रखने के लिए PPTM, PPSM या POTM चुनें।

**क्या Aspose.Slides प्रस्तुति में मैक्रो चला सकता है, उदाहरण के लिए डेटा रीफ़्रेश करने के लिए?**

नहीं। लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint में उचित सुरक्षा सेटिंग्स के साथ ही संभव है।

**क्या VBA कोड से जुड़े ActiveX कंट्रोल्स के साथ काम करना समर्थित है?**

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/net/activex/) तक पहुंच सकते हैं, उनकी प्रॉपर्टी बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।
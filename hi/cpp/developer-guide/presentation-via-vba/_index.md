---
title: प्रस्तुतीकरण में VBA प्रोजेक्ट्स को C++ के माध्यम से प्रबंधित करें
linktitle: VBA द्वारा प्रस्तुतीकरण
type: docs
weight: 250
url: /hi/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और संशोधित करने का तरीका जानें, जिससे आपका कार्यप्रवाह सुगम हो सके।"
---
## **परिचय**

Aspose.Slides.Vba नामस्थान में मैक्रो और VBA कोड के साथ काम करने के लिए क्लासेज़ और इंटरफेसेज़ होते हैं।  

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो वाले प्रेजेंटेशन को किसी अन्य फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में कन्वर्ट करते हैं, तो Aspose.Slides सभी मैक्रो को नजरअंदाज़ करता है (मैक्रो परिणामी फ़ाइल में नहीं ले जाए जाते)।

जब आप प्रेजेंटेशन में मैक्रो जोड़ते हैं या मैक्रो वाले प्रेजेंटेशन को पुनः सेव करते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides प्रस्तुति में मैक्रो **कभी** नहीं चलाता है।

{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.vba_project) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट्स (और प्रोजेक्ट रेफ़रेंस) बना सकते हैं और मौजूदा मॉड्यूल्स को संपादित कर सकते हैं। आप प्रस्तुति में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.i_vba_project/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।  
1. [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) कन्स्ट्रक्टर का उपयोग करके नया VBA प्रोजेक्ट जोड़ें।  
1. VbaProject में एक मॉड्यूल जोड़ें।  
1. मॉड्यूल का सोर्स कोड सेट करें।  
1. <stdole> के रेफ़रेंस जोड़ें।  
1. **Microsoft Office** के रेफ़रेंस जोड़ें।  
1. रेफ़रेंस को VBA प्रोजेक्ट से जोड़ें।  
1. प्रेजेंटेशन को सेव करें।  

यह C++ कोड दिखाता है कि कैसे स्क्रैच से VBA मैक्रो को प्रेजेंटेशन में जोड़ा जाए:  

```c++
// दस्तावेज़ डायरेक्टरी का पथ।
const String outPath = u"../out/AddVBAMacros_out.pptm";

// प्रस्तुतीकरण क्लास का एक इंस्टेंस बनाता है
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// एक नया VBA प्रोजेक्ट बनाता है
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// मॉड्यूल का सोर्स कोड सेट करता है
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole> के लिए रेफ़रेंस बनाता है
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office के लिए रेफ़रेंस बनाता है
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA प्रोजेक्ट में रेफ़रेंस जोड़ता है
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// प्रस्तुतीकरण को सेव करता है
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

आप **Aspose** के [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देखना चाह सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 

{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास के तहत [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो हटा सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाले प्रेजेंटेशन को लोड करें।  
1. Macro मॉड्यूल तक पहुंचें और उसे हटाएं।  
1. संशोधित प्रेजेंटेशन को सेव करें।  

```c++
// दस्तावेज़ डायरेक्टरी का पथ।
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// मैक्रो वाले प्रस्तुतीकरण को लोड करता है
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba मॉड्यूल तक पहुँचता है और इसे हटाता है 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// प्रस्तुतीकरण को सेव करता है
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाले प्रेजेंटेशन को लोड करें।  
2. जाँचें कि प्रेजेंटेशन में VBA प्रोजेक्ट है या नहीं।  
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल्स को लूप करके मैक्रो देखें।  

यह C++ कोड दिखाता है कि कैसे मैक्रो वाले प्रेजेंटेशन से VBA मैक्रो निकाले जाएँ:  

```c++

	// दस्तावेज़ डायरेक्टरी का पथ।
	const String templatePath = u"../templates/VBA.pptm";

	// मैक्रो वाले प्रस्तुतीकरण को लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // जांचता है कि प्रस्तुतीकरण में VBA प्रोजेक्ट है या नहीं
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **जांचें कि VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं**

[IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) प्रॉपर्टी का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड-प्रोटेक्टेड हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाला प्रेजेंटेशन लोड करें।  
2. जाँचें कि प्रेजेंटेशन में [VBA project](https://reference.aspose.com/slides/hi/cpp/aspose.slides.vba/vbaproject/) है या नहीं।  
3. VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं, यह जांचें ताकि उसकी प्रॉपर्टीज़ देख सकें।  

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // जांचें कि प्रस्तुतीकरण में VBA प्रोजेक्ट है या नहीं।
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**यदि मैं प्रेजेंटेशन को PPTX के रूप में सेव करूँ तो मैक्रो का क्या होता है?**  
मैक्रो हटा दिए जाएंगे क्योंकि PPTX VBA को सपोर्ट नहीं करता। मैक्रो रखने के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रेजेंटेशन के भीतर मैक्रो चलाकर, उदाहरण के तौर पर, डेटा रीफ़्रेश कर सकता है?**  
नहीं। यह लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint में उपयुक्त सुरक्षा सेटिंग के साथ ही संभव है।

**क्या VBA कोड से जुड़े ActiveX कंट्रोल्स के साथ काम करना समर्थित है?**  
हाँ, आप मौजूदा [ActiveX controls](/slides/hi/cpp/activex/) तक पहुँच सकते हैं, उनकी प्रॉपर्टीज़ बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।
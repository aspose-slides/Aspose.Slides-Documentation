---
title: VBA के माध्यम से प्रस्तुतियों का प्रबंधन C++ का उपयोग करके
linktitle: VBA द्वारा प्रस्तुति
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
- प्रस्तुति
- C++
- Aspose.Slides
description: "VBA के माध्यम से Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और संशोधित करने के तरीके की खोज करें ताकि आपका कार्यप्रवाह सुगम हो सके."
---
## **परिचय**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो वाली प्रस्तुति को किसी अन्य फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में बदलते हैं, तो Aspose.Slides सभी मैक्रो को अनदेखा करता है (मैक्रो परिणामी फ़ाइल में नहीं ले जाए जाते हैं)।

जब आप प्रस्तुति में मैक्रो जोड़ते हैं या मैक्रो वाली प्रस्तुति को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रो नहीं चलाता है.

{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.vba_project) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेज़) बना सकते हैं और मौजूदा मॉड्यूल संपादित कर सकते हैं। आप [IVbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.i_vba_project/) इंटरफ़ेस का उपयोग करके प्रस्तुति में एम्बेडेड VBA को प्रबंधित कर सकते हैं.

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएँ.
1. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) कंस्ट्रक्टर का उपयोग करें.
1. VbaProject में एक मॉड्यूल जोड़ें.
1. मॉड्यूल का स्रोत कोड सेट करें.
1. <stdole> के रेफ़रेंसेज़ जोड़ें.
1. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें.
1. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ संबद्ध करें.
1. प्रस्तुति सहेजें.

यह C++ कोड दिखाता है कि कैसे शून्य से प्रस्तुति में VBA मैक्रो जोड़ें: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// दस्तावेज़ निर्देशिका का पथ.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// प्रस्तुति क्लास का एक इंस्टेंस बनाता है
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// एक नया VBA प्रोजेक्ट बनाता है
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// मॉड्यूल का स्रोत कोड सेट करता है
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole> के लिए एक रेफ़रेंस बनाता है
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office के लिए एक रेफ़रेंस बनाता है
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA प्रोजेक्ट में रेफ़रेंसेज़ जोड़ता है
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// प्रस्तुति को सहेजता है
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

{{% alert color="info" %}} 

आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देख सकते हैं, जो एक मुफ्त वेब ऐप है जिसका उपयोग PowerPoint, Excel, और Word दस्तावेज़ों से मैक्रो हटाने के लिए किया जाता है. 

{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास के अंतर्गत [VbaProject](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो हटासकते हैं.

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएँ और मैक्रो वाली प्रस्तुति लोड करें.
1. मैक्रो मॉड्यूल तक पहुँचें और उसे हटाएँ.
1. संशोधित प्रस्तुति सहेजें.

यह C++ कोड दिखाता है कि कैसे VBA मैक्रो हटाएँ: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// दस्तावेज़ निर्देशिका का पथ.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// मैक्रो वाली प्रस्तुति को लोड करता है
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba मॉड्यूल तक पहुँचता है और उसे हटाता है
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// प्रस्तुति को सहेजता है
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएँ और मैक्रो वाली प्रस्तुति लोड करें.
2. जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं.
3. VBA प्रोजेक्ट में सभी मॉड्यूल को लूप करके मैक्रो देखें.

यह C++ कोड दिखाता है कि कैसे मैक्रो वाली प्रस्तुति से VBA मैक्रो निकालेँ: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// दस्तावेज़ निर्देशिका का पथ.
	const String templatePath = u"../templates/VBA.pptm";

	// मैक्रो वाली प्रस्तुति को लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // जाँचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
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

## **जाँचें कि क्या VBA प्रोजेक्ट पासवर्ड से सुरक्षित है**

[IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) प्रॉपर्टी का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड‑सुरक्षित हैं या नहीं.

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ और वह प्रस्तुति लोड करें जिसमें मैक्रो हो.
2. जाँचें कि प्रस्तुति में [VBA प्रोजेक्ट](https://reference.aspose.com/slides/hi/cpp/aspose.slides.vba/vbaproject/) है या नहीं.
3. प्रॉपर्टीज़ देखने के लिए जाँचें कि VBA प्रोजेक्ट पासवर्ड‑सुरक्षित है या नहीं.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### प्रस्तुति को PPTX के रूप में सहेजने पर मैक्रो का क्या होता है?

मैक्रो हटा दिए जाते हैं क्योंकि PPTX VBA का समर्थन नहीं करता. मैक्रो रखने के लिए PPTM, PPSM, या POTM चुनें.

### क्या Aspose.Slides प्रस्तुति में मैक्रो चलाकर उदाहरण के तौर पर डेटा रीफ़्रेश कर सकता है?

नहीं. लाइब्रेरी VBA कोड कभी नहीं चलाती; निष्पादन केवल PowerPoint के भीतर उचित सुरक्षा सेटिंग्स के साथ संभव है.

### क्या VBA कोड से जुड़े ActiveX कंट्रोल्स के साथ काम करना समर्थन प्राप्त है?

हां, आप मौजूदा [ActiveX controls](/slides/hi/cpp/activex/) तक पहुँच सकते हैं, उनके प्रॉपर्टीज़ बदल सकते हैं, और उन्हें हटा सकते हैं. यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं.
---
title: "Python के साथ प्रस्तुति गुण प्रबंधित करें"
linktitle: "प्रस्तुति गुण"
type: docs
weight: 70
url: /hi/python-net/presentation-properties/
keywords:
- "PowerPoint गुण"
- "प्रस्तुति गुण"
- "दस्तावेज़ गुण"
- "बिल्ट-इन गुण"
- "कस्टम गुण"
- "उन्नत गुण"
- "गुण प्रबंधित करें"
- "गुण संशोधित करें"
- "दस्तावेज़ मेटाडाटा"
- "मेटाडाटा संपादित करें"
- "प्रूफ़िंग भाषा"
- "डिफ़ॉल्ट भाषा"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET में प्रस्तुति गुणों पर पूर्ण नियंत्रण प्राप्त करें और अपने PowerPoint फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides for Python via .NET **built-in** और **custom** दस्तावेज़ गुणों को समर्थन देता है। इन गुणों का उपयोग प्रस्तुति मेटाडाटा को पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता-परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास का एक उदाहरण [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सेव करते समय एप्लिकेशन और प्रोड्यूसर मेटाडाटा को प्रबंधित करता है; ये फ़ील्ड आउटपुट बनाने वाले सॉफ़्टवेयर की पहचान करती हैं।
{{% /alert %}}

## **प्रस्तुति गुण प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **Built-in properties** मानक मेटाडाटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **Custom properties** उपयोगकर्ता-परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for Python via .NET दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडाटा की जांच के लिए **File → Info → Properties → Advanced Properties** चुनें। डायलॉग जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता-परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब किसी प्रस्तुति को [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) को `False` पर सेट करके एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। तब कोई एप्लिकेशन [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) को `True` पर सेट कर सकता है और ओपनिंग पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडाटा पढ़ सकता है।

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना लोड करना विफल होता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो विकल्प को नजरअंदाज किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण के लिए एक एन्क्रिप्टेड प्रस्तुति आवश्यक है जिसके दस्तावेज़ गुण सार्वजनिक छोड़ दिए गए हों। यह लोडिंग मोड को [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) के माध्यम से सत्यापित करता है और फिर [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) के माध्यम से बिल्ट-इन गुण पढ़ता है:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

इस मोड में, स्लाइड सामग्री लोड नहीं होती है। स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया और अन्य प्रस्तुति वस्तुएँ अनुपलब्ध रहती हैं। एप्लिकेशन को हमेशा [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) जाँचनी चाहिए इससे पहले कि वह ऐसी क्रिया करे जिसे पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडाटा में लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणियाँ, और कस्टम मान उजागर हो सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-मैनेजमेंट सिस्टम को पासवर्ड के बिना पहुँच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) के साथ लोड की गई प्रस्तुति सार्वजनिक मेटाडाटा पढ़ने के लिए होती है। Aspose.Slides उस केवल-मेटाडाटा ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर के संबंधित डेटा के साथ संगत रहना आवश्यक है। इसलिए उन्हें अपडेट करने के लिए सही ओपनिंग पासवर्ड और पूर्ण लोड आवश्यक है।

उदाहरण के लिए एक एन्क्रिप्टेड PPTX प्रस्तुति आवश्यक है जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात ओपनिंग पासवर्ड हो। यह [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) के साथ पूरी प्रस्तुति खोलता है, सार्वजनिक बिल्ट-इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) का उपयोग करके एन्क्रिप्शन के बनाए रखने की पुष्टि करता है और पासवर्ड के बिना सार्वजनिक मेटाडाटा को पुनः खोलकर नए मानों की जाँच करता है:
```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

यदि किसी एप्लिकेशन को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल-पढ़ने योग्य मानना चाहिए।

## **बिल्ट-इन गुणों तक पहुँच**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) क्लास टाइप्ड प्रॉपर्टीज़ के माध्यम से बिल्ट-इन मेटाडाटा को उजागर करती है, जिसमें [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), और [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसके संग्रहित मेटाडाटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।
```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **बिल्ट-इन गुणों को संशोधित करें**

बिल्ट-इन मेटाडाटा को अपडेट करने के लिए, [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) द्वारा उजागर लिखने योग्य प्रॉपर्टीज़ को मान प्रदान करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), और [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) सेट करता है, फिर अपडेट की गई प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) से सहेजता है। सहेजे गए PPTX में नया मेटाडाटा होता है।
```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **हायपरलिंक बेस का प्रबंधन**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) सापेक्ष हायपरलिंक के लिए दस्तावेज़-स्तर बेस को संग्रहीत करता है। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक वाली फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हायपरलिंक के [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) से अलग है: बेस बदलने से संग्रहीत लिंक पते नहीं बदलते और न ही निरपेक्ष गंतव्य बदलते हैं।

उदाहरण के लिए एक ऐसी प्रस्तुति आवश्यक है जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक निरपेक्ष लिंक फ़ाइल या वेबसाइट के लिए हो। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मान की जाँच के लिए प्रस्तुति को सहेज कर पुनः खोलता है। फिर यह बेस को `""` से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक फ़ाइलों के स्थान से बदलें।
```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

दो सत्यापन संदेशों को `True` प्रिंट करना चाहिए। बेस को साफ़ करने से व्यक्तिगत हायपरलिंक पते अपरिवर्तित रहते हैं।

`target.pptx` के सापेक्ष लिंक ने `old/target.pptx` खोल रखा जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलते रहता है। प्रस्तुति को स्थानांतरित करने या इसका बेस बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडाटा को संग्रहीत करते हैं जिनका कोई संबंधित बिल्ट-इन फ़ील्ड नहीं होता। [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) मेथड आपको प्रॉपर्टी नाम द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक इंटीजर वर्शन मान जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) से सहेजता है। मौजूदा नाम को मान असाइन करने से उस गुण का मान बदल जाता है।
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम गुणों तक पहुँच और संशोधन**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और उन पर इटररेट करने के लिए [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) का उपयोग करता है। [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) शून्य-आधारित इंडेक्स लेता है और वह नाम लौटाता है जो [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) द्वारा उपयोग किया गया था। उदाहरण के लिए ऐसी प्रस्तुति चाहिए जहाँ सभी कस्टम गुण स्ट्रिंग हों। यह प्रत्येक मूल नाम और मान को प्रिंट करता है, हर मान को एक क्रमांकित स्ट्रिंग से बदलता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई बदलाव नहीं करता।
```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) दूसरा तर्क के रूप में पास की गई एक-तत्वीय सूची के माध्यम से मान लौटाता है। प्लेसहोल्डर को संग्रहित गुण के प्रकार से मेल खाना चाहिए: स्ट्रिंग के लिए `[""]` या इंटीजर के लिए `[0]` उपयोग करें। प्रकार में असंगति `InvalidCastException` उत्पन्न करती है; अपने कस्टम-प्रॉपर्टी स्कीमा के अनुसार प्लेसहोल्डर चुनें।

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करने के लिए ऑनलाइन एप्लिकेशन [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) को आज़माएँ:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**मैं प्रस्तुति से बिल्ट-इन प्रॉपर्टी कैसे हटा सकता हूँ?**

बिल्ट-इन प्रॉपर्टी प्रस्तुति का अभिन्न भाग हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक मौजूदा कस्टम प्रॉपर्टी जोड़ूँ तो क्या होगा?**

यदि आप एक मौजूदा कस्टम प्रॉपर्टी जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले उस प्रॉपर्टी को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी का मान अपडेट करता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें और फिर [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) से बिना [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडाटा पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट-विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/python-net/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) को `False` पर सेट करके एन्क्रिप्ट किया होना चाहिए, और इसे [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) को `True` पर सेट करके लोड किया जाना चाहिए।

**क्या मैं डाक्यूमेंट-प्रॉपर्टीज़-केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड प्रॉपर्टी डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।
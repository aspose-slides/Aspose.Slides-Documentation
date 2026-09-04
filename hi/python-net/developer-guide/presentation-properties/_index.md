---
title: Python के साथ प्रेजेंटेशन गुण प्रबंधित करें
linktitle: प्रेजेंटेशन गुण
type: docs
weight: 70
url: /hi/python-net/presentation-properties/
keywords:
- PowerPoint गुण
- प्रेजेंटेशन गुण
- दस्तावेज़ गुण
- निर्मित गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में प्रेजेंटेशन गुणों को मास्टर करें और अपने PowerPoint फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार के दस्तावेज़ गुणों को समर्थन देता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को Aspose.Slides API का उपयोग करके आसानी से पहुंचा और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रेजेंटेशन दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है **[DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/)** क्लास के माध्यम से। इस क्लास का एक इंस्टेंस **[Presentation.document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/document_properties/)** प्रॉपर्टी द्वारा वापस किया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड्स के मान सेट नहीं कर सकते, क्योंकि Aspose Ltd. और Aspose.Slides for Python via .NET x.x.x इन फ़ील्ड्स में प्रदर्शित होंगे।
{{% /alert %}} 

## **प्रेजेंटेशन गुणों का प्रबंधन**

Microsoft PowerPoint प्रेजेंटेशन फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण उपयोगी जानकारी को दस्तावेज़ (प्रेजेंटेशन फ़ाइलों) के साथ संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुण हैं:

- सिस्टम द्वारा निर्धारित (Built-in) गुण
- उपयोगकर्ता द्वारा निर्धारित (Custom) गुण

**Built-in** गुण दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे कि दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ सांख्यिकी आदि। **Custom** गुण वे होते हैं जो उपयोगकर्ता द्वारा **नाम/मान** जोड़े के रूप में परिभाषित किए जाते हैं, जहाँ दोनों नाम और मान उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for Python via .NET का उपयोग करके, डेवलपर Built-in गुणों के साथ-साथ Custom गुणों के मानों को एक्सेस और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रेजेंटेशन फ़ाइलों के दस्तावेज़ गुणों का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करके आगे **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है। **Advanced Properties** आइटम चुनने पर एक डायलॉग प्रदर्शित होगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की सुविधा देता है। **Properties Dialog** में आप देखेंगे कि कई टैब पेज हैं जैसे **General, Summary, Statistics, Contents और Custom**। सभी ये टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

## **एन्क्रिप्टेड प्रेजेंटेशन से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड आमतौर पर प्रेजेंटेशन की सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब प्रेजेंटेशन को **[ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)** को `False` पर सेट करके एन्क्रिप्ट किया जाता है, तब इसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर कोई एप्लिकेशन **[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/only_load_document_properties/)** को `True` पर सेट करके ओपनिंग पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

`only_load_document_properties` यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल होगा। यदि प्रेजेंटेशन एन्क्रिप्टेड नहीं है, तो इस विकल्प को नजरअंदाज़ किया जाता है और पूरी प्रेजेंटेशन लोड हो जाती है।

निम्नलिखित उदाहरण **[ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)** के माध्यम से लोडिंग मोड की जाँच करता है और फिर **[Presentation.document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/document_properties/)** के माध्यम से Built-in गुणों को पढ़ता है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया, और अन्य प्रेजेंटेशन ऑब्जेक्ट्स उपलब्ध नहीं होते। एप्लिकेशन को हमेशा `is_only_document_properties_loaded` की जाँच करनी चाहिए इससे पहले कि वह ऐसी ऑपरेशन करे जिसके लिए पूर्ण प्रेजेंटेशन ऑब्जेक्ट मॉडल आवश्यक हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडेटा में लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान शामिल हो सकते हैं। संवेदनशील गुणों को प्रेजेंटेशन के साथ एन्क्रिप्ट करें। उन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन प्रणाली को पासवर्ड के बिना पहुंच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रेजेंटेशन के गुण अपडेट करें**

एन्क्रिप्टेड PPTX फ़ाइल के लिए, `only_load_document_properties` के साथ लोड किया गया प्रेजेंटेशन केवल सार्वजनिक मेटाडेटा पढ़ने के लिए माना जाता है। Aspose.Slides उस मेटाडेटा‑ओनली ऑब्जेक्ट से बदलें हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रेजेंटेशन के भीतर संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही ओपनिंग पासवर्ड और पूर्ण लोड आवश्यक है।

निम्नलिखित उदाहरण **[LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/)** के साथ प्रेजेंटेशन खोलता है, सार्वजनिक Built-in गुणों को अपडेट करता है, और परिणाम सहेजता है। फिर यह **[PresentationInfo.is_encrypted](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/is_encrypted/)** का उपयोग करके एन्क्रिप्शन बरकरार है यह सत्यापित करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को फिर से खोलकर नए मानों की जाँच करता है:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
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

यदि किसी एप्लिकेशन को प्रेजेंटेशन सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **Built-in गुणों तक पहुँचें**
इन गुणों को **IDocumentProperties** ऑब्जेक्ट द्वारा प्रदर्शित किया गया है, जिसमें शामिल हैं: **Creator(Author)**, **Description**, **Keywords**, **Created** (सृजन तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम मुद्रण तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**  
```py
import aspose.slides as slides

# प्रेजेंटेशन का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनायें
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation से संबंधित ऑब्जेक्ट का रेफ़रेंस बनायें
    documentProperties = pres.document_properties

    # बिल्ट‑इन गुण प्रदर्शित करें
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Built-in गुणों का संशोधन**

प्रेजेंटेशन फ़ाइलों के Built-in गुणों को संशोधित करना उतना ही आसान है जितना कि उन्हें एक्सेस करना। आप बस किसी भी इच्छित गुण को स्ट्रिंग मान असाइन कर सकते हैं और वह गुण मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे प्रेजेंटेशन फ़ाइल के Built-in दस्तावेज़ गुणों को संशोधित किया जा सकता है।

```py
import aspose.slides as slides

# प्रस्तुति को दर्शाने वाली Presentation क्लास का उदाहरण बनायें
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Presentation से संबंधित ऑब्जेक्ट का रेफ़रेंस बनायें
    documentProperties = presentation.document_properties

    # बिल्ट‑इन गुण सेट करें
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम प्रेजेंटेशन गुण जोड़ें**

Aspose.Slides for Python via .NET डेवलपर्स को प्रेजेंटेशन Document गुणों के लिए कस्टम मान जोड़ने की अनुमति भी देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि कैसे प्रेजेंटेशन के लिए कस्टम गुण सेट किए जाएँ।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनायें
with slides.Presentation() as presentation:
    # दस्तावेज़ गुण प्राप्त करना
    documentProperties = presentation.document_properties

    # कस्टम गुण जोड़ना
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # विशेष इंडेक्स पर गुण का नाम प्राप्त करना
    getPropertyName = documentProperties.get_custom_property_name(2)

    # चयनित गुण हटाना
    documentProperties.remove_custom_property(getPropertyName)

    # प्रस्तुति सहेजना
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम गुणों तक पहुँच और संशोधन**

Aspose.Slides for Python via .NET डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रेजेंटेशन के सभी कस्टम गुणों तक कैसे पहुँच और संशोधन कर सकते हैं।

```py
import aspose.slides as slides

# PPTX को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation से जुड़ी document_properties ऑब्जेक्ट का रेफ़रेंस बनाएं
    documentProperties = presentation.document_properties

    # कस्टम गुणों तक पहुँचें और उन्हें संशोधित करें
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # कस्टम गुणों के नाम और मान प्रदर्शित करें
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # कस्टम गुणों के मान संशोधित करें
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` दूसरे तर्क के रूप में पास की गई एक‑तत्वीय सूची के माध्यम से मान लौटाता है, और संग्रहीत मान को उस सूची में पहले से मौजूद तत्व के प्रकार में कास्ट किया जाता है। ऊपर का उदाहरण `[""]` का उपयोग करता है, इसलिए यह स्ट्रिंग गुण पढ़ता है; किसी संख्या के रूप में संग्रहीत गुण को पढ़ने के लिए, एक संख्यात्मक प्लेसहोल्डर जैसे `[0]` पास करें—अन्यथा कॉल `InvalidCastException` उठाता है।

## **प्रूफिंग भाषा निर्धारित करें**

Aspose.Slides **Language_Id** प्रॉपर्टी (जो **[PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/)** क्लास द्वारा उजागर की गई है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में स्पेलिंग और व्याकरण जाँच की जाती है।

यह Python कोड आपको दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट की जाए:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # प्रूफिंग भाषा का Id सेट करें
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **डिफ़ॉल्ट भाषा निर्धारित करें**

यह Python कोड आपको दिखाता है कि संपूर्ण PowerPoint प्रेजेंटेशन के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **लाइव उदाहरण**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन एप्लिकेशन को आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम किया जाता है, देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रेजेंटेशन से Built-in गुण को कैसे हटाया जा सकता है?**

Built-in गुण प्रेजेंटेशन का अभिन्न भाग होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान को बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही गुण के मान को अपडेट कर देता है।

**क्या मैं प्रेजेंटेशन को पूरी तरह लोड किए बिना गुणों तक पहुँच सकता हूँ?**

हाँ। **[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/)** का उपयोग करें और फिर **[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/)** से बिना **[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)** इंस्टेंस बनाए दस्तावेज़ मेटाडेटा पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट प्रतिबंधों के लिए **[Build a Lightweight Presentation Inventory](/slides/hi/python-net/examine-presentation/)** देखें।

**क्या मैं एन्क्रिप्टेड प्रेजेंटेशन के सार्वजनिक गुणों को उसके ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रेजेंटेशन को `encrypt_document_properties` को `False` पर सेट करके एन्क्रिप्ट किया गया होना चाहिए, और उसे `only_load_document_properties` को `True` पर सेट करके लोड किया जाना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही ओपनिंग पासवर्ड के साथ पूर्ण प्रेजेंटेशन लोड करना आवश्यक है।
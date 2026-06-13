---
title: Python के साथ प्रस्तुति प्रॉपर्टीज़ का प्रबंधन
linktitle: प्रेजेंटेशन प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/python-net/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रेजेंटेशन प्रॉपर्टीज़
- डॉक्यूमेंट प्रॉपर्टीज़
- बिल्ट‑इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- एडवांस्ड प्रॉपर्टीज़
- प्रॉपर्टीज़ प्रबंधित करें
- प्रॉपर्टीज़ संशोधित करें
- डॉक्यूमेंट मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में प्रस्तुति प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को सपोर्ट करता है: **Built-in** और **Custom**। इन दोनों प्रकार की प्रॉपर्टीज़ को Aspose.Slides API के माध्यम से आसानी से एक्सेस और मैनेज किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ को [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) क्लास के ज़रिए काम करने की अनुमति देता है। इस क्लास की एक इंस्टेंस [Presentation.document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/document_properties/) प्रॉपर्टी द्वारा रिटर्न की जाती है। नीचे दिए गए उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और मैनेज किया जाए।

{{% alert color="primary" %}} 
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड्स के मान सेट नहीं कर सकते, क्योंकि Aspose Ltd. और Aspose.Slides for Python via .NET x.x.x इन फ़ील्ड्स में प्रदर्शित किए जाएंगे।
{{% /alert %}} 

## **प्रेजेंटेशन प्रॉपर्टीज़ का प्रबंधन**

Microsoft PowerPoint में प्रस्तुति फ़ाइलों के साथ कुछ प्रॉपर्टीज़ जोड़ने की सुविधा होती है। ये दस्तावेज़ प्रॉपर्टीज़ दस्तावेज़ों (प्रेजेंटेशन फ़ाइलों) के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देती हैं। दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ हैं:

- सिस्टम परिभाषित (Built-in) प्रॉपर्टीज़
- उपयोगकर्ता परिभाषित (Custom) प्रॉपर्टीज़

**Built-in** प्रॉपर्टीज़ में दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ सांख्यिकी आदि जैसी सामान्य जानकारी होती है। **Custom** प्रॉपर्टीज़ वे हैं जो उपयोगकर्ता द्वारा **Name/Value** जोड़े के रूप में परिभाषित की जाती हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा तय किए जाते हैं। Aspose.Slides for Python via .NET का उपयोग करके डेवलपर्स बिल्ट‑इन और कस्टम दोनों प्रॉपर्टीज़ के मानों को एक्सेस और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ को मैनेज करने की सुविधा देता है। आपको केवल Office आइकन पर क्लिक करना है तथा **Prepare | Properties | Advanced Properties** मेन्यू आइटम चुनना है। **Advanced Properties** चुनने के बाद एक डायलॉग विज़िट होगा जिसमें आप PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टीज़ को मैनेज कर सकते हैं। **Properties Dialog** में कई टैब पेज होते हैं जैसे **General, Summary, Statistics, Contents और Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों की कस्टम प्रॉपर्टीज़ को मैनेज करने के लिए उपयोग किया जाता है।

## **Built-in प्रॉपर्टीज़ तक पहुंच**

**IDocumentProperties** ऑब्जेक्ट द्वारा एक्सपोज़ की गई ये प्रॉपर्टीज़ शामिल हैं: **Creator(Author)**, **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (आखिरी प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न प्रोड्यूसर के बीच साझा है?), **PresentationFormat**, **Subject** और **Title**
```py
import aspose.slides as slides

# प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Presentation से जुड़े ऑब्जेक्ट का रेफ़रेंस बनाएँ
    documentProperties = pres.document_properties

    # बिल्ट‑इन प्रॉपर्टीज़ दिखाएँ
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

## **Built-in प्रॉपर्टीज़ में संशोधन**

प्रेजेंटेशन फ़ाइलों की बिल्ट‑इन प्रॉपर्टीज़ को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस किसी भी इच्छित प्रॉपर्टी को स्ट्रिंग मान असाइन कर सकते हैं और प्रॉपर्टी का मान बदल जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे प्रेजेंटेशन फ़ाइल की बिल्ट‑इन डॉक्यूमेंट प्रॉपर्टीज़ को संशोधित किया जाता है।

```py
import aspose.slides as slides

# प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Presentation से जुड़े ऑब्जेक्ट का रेफ़रेंस बनाएँ
    documentProperties = presentation.document_properties

    # बिल्ट‑इन प्रॉपर्टीज़ सेट करें
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम प्रेजेंटेशन प्रॉपर्टीज़ जोड़ें**

Aspose.Slides for Python via .NET डेवलपर्स को प्रेजेंटेशन डॉक्यूमेंट प्रॉपर्टीज़ के लिए कस्टम मान जोड़ने की अनुमति भी देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रेजेंटेशन के लिए कस्टम प्रॉपर्टीज़ कैसे सेट की जाएँ।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाएं
with slides.Presentation() as presentation:
    # डॉक्यूमेंट प्रॉपर्टीज़ प्राप्त कर रहे हैं
    documentProperties = presentation.document_properties

    # कस्टम प्रॉपर्टीज़ जोड़ रहे हैं
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # विशिष्ट इंडेक्स पर प्रॉपर्टी का नाम प्राप्त कर रहे हैं
    getPropertyName = documentProperties.get_custom_property_name(2)

    # चयनित प्रॉपर्टी हटाएँ
    documentProperties.remove_custom_property(getPropertyName)

    # प्रेजेंटेशन सहेज रहे हैं
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम प्रॉपर्टीज़ तक पहुंच और संशोधन**

Aspose.Slides for Python via .NET डेवलपर्स को कस्टम प्रॉपर्टीज़ के मानों को एक्सेस करने की सुविधा भी देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रेजेंटेशन की सभी कस्टम प्रॉपर्टीज़ को कैसे एक्सेस और संशोधित कर सकते हैं।

```py
import aspose.slides as slides

# PPTX को प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Presentation से जुड़ी document_properties ऑब्जेक्ट का रेफ़रेंस बनाएं
    documentProperties = presentation.document_properties

    # कस्टम प्रॉपर्टीज़ तक पहुँचें और उन्हें संशोधित करें
    for i in range(documentProperties.count_of_custom_properties):
        # कस्टम प्रॉपर्टीज़ के नाम और मान दिखाएँ
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # कस्टम प्रॉपर्टीज़ के मान संशोधित करें
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides `Language_Id` प्रॉपर्टी (जो कि [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) क्लास द्वारा एक्सपोज़ की गई है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जांचे जाते हैं।

यह Python कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट की जाए:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # प्रूफ़िंग भाषा का Id सेट करें
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह Python कोड दिखाता है कि पूरे PowerPoint प्रेजेंटेशन के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप आज़माएँ और देखिए कि Aspose.Slides API के माध्यम से दस्तावेज़ प्रॉपर्टीज़ के साथ कैसे काम किया जाता है:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रेज़ेंटेशन से बिल्ट‑इन प्रॉपर्टी को कैसे हटा सकता हूँ?**

बिल्ट‑इन प्रॉपर्टीज़ प्रेज़ेंटेशन का अभिन्न हिस्सा हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई मौजूदा कस्टम प्रॉपर्टी जोड़ता हूँ तो क्या होता है?**

यदि आप कोई मौजूदा कस्टम प्रॉपर्टी जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको प्रॉपर्टी को हटाने या पहले से जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं प्रेज़ेंटेशन को पूरी तरह लोड किए बिना प्रॉपर्टीज़ तक पहुंच सकता हूँ?**

हाँ, आप प्रेज़ेंटेशन को पूरी तरह लोड किए बिना प्रॉपर्टीज़ तक पहुंच सकते हैं। इसके लिए आप [PresentationFactory](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/) क्लास की [get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) मेथड का उपयोग कर सकते हैं। फिर, [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) क्लास द्वारा प्रदान की गई [read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) मेथड का उपयोग करके आप प्रॉपर्टीज़ को कुशलता से पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।
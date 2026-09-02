---
title: Python के साथ प्रस्तुति गुणधर्म प्रबंधित करें
linktitle: प्रस्तुति गुणधर्म
type: docs
weight: 70
url: /hi/python-net/presentation-properties/
keywords:
- PowerPoint गुणधर्म
- प्रस्तुति गुणधर्म
- दस्तावेज़ गुणधर्म
- बिल्ट‑इन गुणधर्म
- कस्टम गुणधर्म
- उन्नत गुणधर्म
- गुणधर्म प्रबंधित करें
- गुणधर्म संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में प्रस्तुति गुणधर्मों को पूरी तरह नियंत्रित करें और अपने PowerPoint फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुगम बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणधर्मों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणधर्मों को Aspose.Slides API के माध्यम से आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणधर्मों के साथ काम करने की अनुमति देता है, जो कि [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) क्लास के माध्यम से किया जाता है। इस क्लास का एक उदाहरण [Presentation.document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/document_properties/) प्रॉपर्टी द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणधर्मों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड्स के मान सेट नहीं कर सकते, क्योंकि Aspose Ltd. और Aspose.Slides for Python via .NET x.x.x इन फ़ील्ड्स में प्रदर्शित होंगे।
{{% /alert %}} 

## **प्रस्तुति गुणधर्म प्रबंधन**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ गुणधर्म जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुणधर्म उपयोगी जानकारी को दस्तावेज़ों (प्रस्तुति फ़ाइलों) के साथ संग्रहीत करने की अनुमति देते हैं। दस्तावेज़ गुणधर्म दो प्रकार के होते हैं:

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** गुणधर्म दस्तावेज़ के सामान्य विवरण जैसे शीर्षक, लेखक का नाम, आँकड़े आदि को धारण करते हैं। **Custom** गुणधर्म वे होते हैं जिन्हें उपयोगकर्ता **Name/Value** जोड़े के रूप में परिभाषित करता है, जहाँ नाम और मान दोनों ही उपयोगकर्ता द्वारा तय किए जाते हैं। Aspose.Slides for Python via .NET का उपयोग करके डेवलपर्स बिल्ट‑इन और कस्टम दोनों प्रकार के गुणधर्मों के मानों को एक्सेस और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणधर्मों को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करके आगे **Prepare | Properties | Advanced Properties** मेन्यू विकल्प चुनना होता है। **Advanced Properties** विकल्प चुनने के बाद एक डायलॉग दिखेगा जहाँ आप PowerPoint फ़ाइल के दस्तावेज़ गुणधर्मों को प्रबंधित कर सकते हैं। **Properties Dialog** में आप कई टैब पेज देख सकते हैं जैसे **General, Summary, Statistics, Contents and Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की सुविधा देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणधर्मों को प्रबंधित करने के लिए उपयोग किया जाता है।

## **बिल्ट‑इन गुणधर्मों तक पहुँच**

इन गुणधर्मों को **IDocumentProperties** ऑब्जेक्ट द्वारा उजागर किया गया है, जिसमें शामिल हैं: **Creator(Author)**, **Description**, **Keywords**, **Created** (सृजन तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject**, और **Title**  
```py
import aspose.slides as slides

# प्रस्तुति को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation से जुड़ी ऑब्जेक्ट का संदर्भ बनाएं
    documentProperties = pres.document_properties

    # बिल्ट‑इन गुणधर्म प्रदर्शित करें
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

## **बिल्ट‑इन गुणधर्मों का संशोधन**

प्रेजेंटेशन फ़ाइलों के बिल्ट‑इन गुणधर्मों को संशोधित करना उन्हें एक्सेस करने जितना ही आसान है। आप किसी भी इच्छित गुणधर्म को स्ट्रिंग मान असाइन कर सकते हैं और वह मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दर्शाया है कि कैसे प्रेजेंटेशन फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणधर्मों को संशोधित किया जा सकता है।  
```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंसिएट करें जो Presentation का प्रतिनिधित्व करती है
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Presentation से जुड़ी ऑब्जेक्ट का संदर्भ बनाएं
    documentProperties = presentation.document_properties

    # बिल्ट‑इन गुणधर्म सेट करें
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम प्रस्तुति गुणधर्म जोड़ें**

Aspose.Slides for Python via .NET डेवलपर्स को प्रस्तुति दस्तावेज़ गुणधर्मों के लिए कस्टम मान जोड़ने की अनुमति भी देता है। नीचे एक उदाहरण दिया गया है जो प्रदर्शित करता है कि कैसे एक प्रस्तुति के लिए कस्टम गुणधर्म सेट किए जाते हैं।  
```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंसिएट करें
with slides.Presentation() as presentation:
    # दस्तावेज़ गुणधर्म प्राप्त कर रहे हैं
    documentProperties = presentation.document_properties

    # कस्टम गुणधर्म जोड़ रहे हैं
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # विशेष इंडेक्स पर गुणधर्म का नाम प्राप्त कर रहे हैं
    getPropertyName = documentProperties.get_custom_property_name(2)

    # चयनित गुणधर्म को हटा रहे हैं
    documentProperties.remove_custom_property(getPropertyName)

    # प्रस्तुति सहेज रहे हैं
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम गुणधर्मों तक पहुँच और संशोधन**

Aspose.Slides for Python via .NET डेवलपर्स को कस्टम गुणधर्मों के मानों को एक्सेस करने की भी सुविधा देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप एक प्रस्तुति के सभी कस्टम गुणधर्मों तक कैसे पहुँच सकते हैं और उन्हें कैसे संशोधित कर सकते हैं।  
```py
import aspose.slides as slides

# PPTX को दर्शाने वाली Presentation क्लास का इंस्टैंसिएट करें
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Presentation से जुड़ी document_properties ऑब्जेक्ट का संदर्भ बनाएं
    documentProperties = presentation.document_properties

    # कस्टम गुणधर्मों तक पहुँचें और उन्हें संशोधित करें
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # कस्टम गुणधर्मों के नाम और मान प्रदर्शित करें
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # कस्टम गुणधर्मों के मान संशोधित करें
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` दूसरे आर्गुमेंट के रूप में पास की गई एक‑तत्व वाली सूची के माध्यम से मान लौटाता है, और संग्रहीत मान उसी सूची में पहले से मौजूद तत्व के प्रकार में कास्ट किया जाता है। ऊपर दिया गया उदाहरण `[""]` का उपयोग करता है, इसलिए यह स्ट्रिंग गुणधर्म पढ़ता है; यदि किसी संख्या के रूप में संग्रहीत गुणधर्म को पढ़ना हो तो `[0]` जैसे संख्यात्मक प्लेसहोल्डर पास करें—अन्यथा कॉल `InvalidCastException` उठाता है।

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides `Language_Id` प्रॉपर्टी ([PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) क्लास द्वारा एक्सपोज़) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जांचे जाते हैं।  

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

    # प्रूफ़िंग भाषा का Id सेट करें
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह Python कोड दिखाता है कि कैसे पूरे PowerPoint प्रेजेंटेशन के लिए डिफ़ॉल्ट भाषा सेट की जा सकती है:  

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

Aspose.Slides की डॉक्यूमेंट प्रॉपर्टी के साथ काम करने के लिए ऑनलाइन एप्लिकेशन **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुणधर्म को कैसे हटा सकता हूँ?**

बिल्ट‑इन गुणधर्म प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुणधर्म अनुमति देता हो तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुणधर्म जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुणधर्म जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से हटाने या जांचने की आवश्यकता नहीं है; Aspose.Slides स्वचालित रूप से गुणधर्म के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसके गुणधर्मों तक पहुँच सकता हूँ?**

हाँ। आप [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करके और फिर [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) के माध्यम से बिना एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए दस्तावेज़ मेटाडेटा पढ़ सकते हैं। पूरी रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/python-net/examine-presentation/).
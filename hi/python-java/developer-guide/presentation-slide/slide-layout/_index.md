---
title: Python के माध्यम से Java में स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/python-java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- अप्रयुक्त लेआउट
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और वर्टिकल टेक्स्ट
- वर्टिकल शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से Java में स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता नियंत्रित करें।"
---
## **सारांश**

एक स्लाइड लेआउट शीर्षक, टेक्स्ट, चित्र, चार्ट और तालिका जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स में एक सुसंगत संरचना बनती है जबकि प्रत्येक स्लाइड अपनी सामग्री रख सकती है।

सबसे सामान्य लेआउट शामिल हैं:

- **शीर्षक स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल हैं।
- **शीर्षक और सामग्री**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य वाली सामग्री प्लेसहोल्डर शामिल है।
- **खाली**: कोई सामग्री प्लेसहोल्डर नहीं होते और यह उपयोगी है जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाता है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
2. एक [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/) एक मास्टर से जुड़ा होता है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करता है।
3. एक [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) एक लेआउट का प्रयोग करती है और उस स्लाइड के लिए दर्ज सामग्री को संग्रहीत करती है।

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण विरासत में प्राप्त करती है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। सामान्य स्लाइड पर सीधे निर्धारित मान उस स्तर पर विरासत मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज सामग्री सामान्य स्लाइड की ही होती है।

लेआउट को स्लाइड्स बनाने से पहले आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में कोई अतिरिक्त प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड्स में स्वचालित रूप से समान आकार नहीं बनता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से सभी निर्भर स्लाइड्स अपडेट हो सकती हैं। उपयोग में हो रहे लेआउट को संपादित करने से पहले, उसके निर्भर स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट में पुन: नियत करें, या केवल अप्रयुक्त लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें: [स्लाइड मास्टर](/slides/hi/python-java/slide-master/)।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादनीय होते हैं और लोकलाइज़ किए जा सकते हैं, इसलिए स्रोत टेम्पलेट पर नियंत्रण न होने पर नाम‑आधारित चयन भरोसेमंद नहीं रहता।

निम्नलिखित उदाहरण पहले मास्टर पर **शीर्षक और सामग्री** ढूँढ़ता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **खाली** पर फ़ॉल्‍बैक करता है। दूसरी जाँच `None` की आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setLayoutSlide) मेथड के माध्यम से लागू किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

लेआउट बदलने से स्लाइड में सीधे जोड़ी गई सामान्य आकृतियों को हटाया नहीं जाता। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का मिलान बदल सकता है, इसलिए बड़े अंतर वाले लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछला उदाहरण मौजूदा लेआउट का चयन करता है; यह नया नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर के लेआउट संग्रह पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterlayoutslidecollection/#add) मेथड को कॉल करें।

निम्नलिखित उदाहरण हमेशा एक नया **शीर्षक और सामग्री** लेआउट जिसका नाम `Report Title and Content` है, जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होने चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

केवल तभी लेआउट जोड़ें जब टेम्पलेट वास्तव में एक और पुन: उपयोगी संरचना की आवश्यकता रखता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो नया बनाकर दोहराव करने के बजाय उसे चुनें और पुन: उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड लेआउट में प्लेसहोल्डर आकार जोड़ने के लिए एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/) प्रदान करता है।

| PowerPoint प्लेसहोल्डर               | विधि |
| ----------------------------------- | ---- |
| ![सामग्री](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![सामग्री (वर्टिकल)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![टेक्स्ट](text.png)                | [addTextPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![टेक्स्ट (वर्टिकल)](textV.png)    | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![चित्र](picture.png)               | [addPicturePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![चार्ट](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![तालिका](table.png)                | [addTablePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![मीडिया](media.png)                | [addMediaPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ऑनलाइन इमेज](onlineImage.png)   | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्नलिखित उदाहरण सत्यापित करता है कि **खाली** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर्स जोड़ता है, और फिर संशोधित लेआउट का उपयोग करके एक सामान्य स्लाइड बनाता है। क्रम जानबूझकर इस प्रकार रखा गया है: प्लेसहोल्डर्स को सामान्य स्लाइड बनाने से पहले जोड़ दिया जाता है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर्स](add_placeholders.png)

{{% alert color="warning" title="चेतावनी" %}}
विरासत स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति को बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। हाल ही में जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में पीछे से नहीं भरता। लेआउट परिवर्तन को प्रस्तुति की प्रतिलिपि पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड का उपयोग करके उन लेआउट्स को हटाएँ जिनका कोई सामान्य स्लाइड संदर्भ नहीं रखता। यह मेथड उन लेआउट्स को जैसा का तैसा छोड़ देता है जो अभी भी उपयोग में हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

किसी विशिष्ट लेआउट को हटाने के लिए, पहले उसकी [hasDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getDependingSlides) मेथड का उपयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#remove) को कॉल करने से पहले सभी निर्भर स्लाइड्स को पुन: नियत करें। उपयोग में हो रहे लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर और तिथि‑समय प्लेसहोल्डर होता है। उन प्लेसहोल्डर्स को एक लेआउट के लिए नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) मेथड का प्रयोग करें। यह तब उपयोगी होता है जब उदाहरण के लिए सामग्री लेआउट को फुटर दिखाना चाहिए लेकिन शीर्षक लेआउट को नहीं।

निम्नलिखित उदाहरण सुरक्षित रूप से एक लेआउट चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मास्टर और उसकी चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम के across सुसंगत फुटर सेटिंग्स लागू करने के लिए, [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getHeaderFooterManager) मेथड का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslideheaderfootermanager/) की प्रोपीगेशन मेथड्स मास्टर, उसके निर्भर लेआउट स्लाइड्स और सामान्य स्लाइड्स पर कार्य करती हैं; वे केवल किसी एक सामान्य स्लाइड को लक्षित नहीं करतीं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति का थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की एक पुन: प्रयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां। गंतव्य संग्रह में कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/globallayoutslidecollection/#addClone) मेथड का उपयोग करें। दो प्रस्तुतियों के बीच कॉपी करते समय फ़ॉन्ट्स, थीम्स, इमेजेज और स्रोत लेआउट द्वारा प्रयुक्त अन्य संसाधनों की भी पुष्टि करें।

**यदि मैं एक उपयोग में हो रही लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं, जब तक कि उन्होंने स्थानीय स्तर पर प्रभावित स्वरूपण या वस्तुओं को ओवरराइड न किया हो। प्लेसहोल्डर ज्यामिति और विरासत शैली कई स्लाइड्स पर एक साथ बदल सकती है। संपादन से पहले प्रभावित स्लाइड्स की पहचान के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करें।

**यदि मैं अभी भी उपयोग में हो रहे लेआउट को हटाता हूँ तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुन: नियत करें, या केवल अप्रयुक्त लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें।
---
title: "Python के माध्यम से Java में स्लाइड लेआउट लागू करें या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/python-java/slide-layout/
keywords:
- "स्लाइड लेआउट"
- "सामग्री लेआउट"
- "प्लेसहोल्डर"
- "प्रस्तुति डिजाइन"
- "स्लाइड डिजाइन"
- "अनुपयोगी लेआउट"
- "फूटर दृश्यता"
- "शीर्षक स्लाइड"
- "शीर्षक और सामग्री"
- "सेक्शन शीर्षलेख"
- "दो सामग्री"
- "तुलना"
- "केवल शीर्षक"
- "खाली लेआउट"
- "कैप्शन के साथ सामग्री"
- "कैप्शन के साथ चित्र"
- "शीर्षक और ऊर्ध्वाधर पाठ"
- "ऊर्ध्वाधर शीर्षक और पाठ"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java में स्लाइड लेआउट को लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फूटर दृश्यता नियंत्रित करें।"
---
## **अवलोकन**

एक स्लाइड लेआउट प्लेसहोल्डर्स जैसे शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स की संरचना सुसंगत रहती है जबकि प्रत्येक स्लाइड को अपना स्वयं का सामग्री रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट्स में शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल होते हैं।
- **Title and Content**: शीर्षक प्लेसहोल्डर और एक सामान्य प्रयोजन सामग्री प्लेसहोल्डर शामिल होता है।
- **Blank**: कोई सामग्री प्लेसहोल्डर नहीं होते और यह तब उपयोगी होता है जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाएगा।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य ऑब्जेक्ट्स को परिभाषित करता है।
2. एक [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/) एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है।
3. एक [नॉर्मल स्लाइड](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करती है।

एक नॉर्मल स्लाइड अपने लेआउट से थीम और स्वरूपण विरासत में मिलती है, और लेआउट अपने मास्टर से विरासत में मिलता है। नॉर्मल स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड कर देता है। जब एक नॉर्मल स्लाइड बनाई जाती है, उसके प्लेसहोल्डर आकृतियों को चुने हुए लेआउट से जेनरेट किया जाता है, जबकि उन प्लेसहोल्डर्स में दर्ज की गई सामग्री नॉर्मल स्लाइड की ही होती है।

लेआउट से स्लाइड बनाने से पहले आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में एक और प्लेसहोल्डर जोड़ने से मौजूदा नॉर्मल स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं बनता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उन सभी स्लाइड्स को अपडेट किया जा सकता है जो उस पर निर्भर हैं। उपयोग में मौजूद लेआउट को संपादित करने से पहले, उसके निर्भर स्लाइड्स की जांच करें और उत्पन्न प्रस्तुति की समीक्षा करें।
- एक लेआउट जिसे अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, उसे हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अनउपयोगी लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [स्लाइड मास्टर](/slides/hi/python-java/slide-master/)।

एक स्लाइड पर या साझा लेआउट के माध्यम से विरासत में मिली लोगो या सजावटी मास्टर शैलियों को छिपाने के लिए देखें [मास्टर ग्राफिक्स की दृश्यता को नियंत्रित करें](/slides/hi/python-java/slide-master/)। उदाहरण एक ही मास्टर का उपयोग करने वाली दो स्लाइड्स की तुलना करता है।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तब लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता द्वारा संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम-आधारित चयन कम विश्वसनीय होता है जब तक आप स्रोत टेम्पलेट को नियंत्रित नहीं करते।

निम्न उदाहरण पहले मास्टर पर **Title and Content** लेआउट को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर वापस जाता है। `None` की दूसरी जाँच आवश्यक है क्योंकि एक प्रस्तुति में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट फिर पहले नॉर्मल स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setLayoutSlide) मेथड के माध्यम से लागू किया जाता है।

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

स्लाइड का लेआउट बदलने से स्लाइड में सीधे जोड़े गए सामान्य आकार नहीं हटते। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का मिलान बदल सकता है, इसलिए काफी विभिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जांच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग-अलग कार्य हैं। पिछले उदाहरण में एक मौजूदा लेआउट को चुना गया है; यह नया नहीं बनाता। लेआउट बनाने के लिए, लक्ष्य मास्टर के लेआउट संग्रह पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterlayoutslidecollection/#add) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक एक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक नॉर्मल स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होने चाहिए।

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

केवल तब लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक और पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो डुप्लिकेट बनाते बड़े बजाय उसे चुनें और पुनः उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/) प्रदान करता है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर | LayoutPlaceholderManager मेथड |
| ---------------------- | ----------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्न उदाहरण यह सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर एक नॉर्मल स्लाइड बनाता है जो संशोधित लेआउट का उपयोग करती है। क्रम जानबूझकर है: प्लेसहोल्डर नॉर्मल स्लाइड बनने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

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

{{% alert color="warning" title="Warning" %}}
विरासत में मिला स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर्स की ज्यामिति बदलने से निर्भर स्लाइट्स प्रभावित हो सकते हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा नॉर्मल स्लाइड्स में बैकफ़िल नहीं होता। प्रस्तुति की कॉपी पर लेआउट परिवर्तन परीक्षण करें और प्रत्येक निर्भर स्लाइड की जांच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड का उपयोग उन लेआउट्स को हटाने के लिए करें जिनका कोई नॉर्मल स्लाइड संदर्भ नहीं देता। यह मेथड उन लेआउट्स को जैसा है वैसा ही छोड़ देता है जो अभी भी उपयोग में हैं।

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

एक विशिष्ट लेआउट हटाने के लिए, पहले उसके [hasDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getDependingSlides) मेथड का उपयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#remove) को कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में मौजूद लेआउट को हटाने का प्रयास करने पर [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता को नियंत्रित करें**

एक लेआउट में अपना स्वयं का फुटर, स्लाइड-नंबर, और दिनांक‑समय प्लेसहोल्डर्स होते हैं। किसी एक लेआउट के लिए इन प्लेसहोल्डर्स को नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) मेथड का उपयोग करें। यह उपयोगी है जब उदाहरण के लिए कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन टाइटल लेआउट्स को नहीं।

निम्न उदाहरण एक लेआउट को सुरक्षित रूप से चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

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

## **मास्टर और उसकी चाइल्ड लेआउट्स पर फुटर दृश्यता को नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए, [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getHeaderFooterManager) मेथड का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslideheaderfootermanager/) की प्रसारण विधियां मास्टर, उसके निर्भर लेआउट स्लाइड्स और नॉर्मल स्लाइड्स पर कार्य करती हैं; वे केवल एक नॉर्मल स्लाइड को लक्षित नहीं करतीं।

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

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड के बीच अंतर क्या है?**

एक मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। एक लेआउट स्लाइड एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। नॉर्मल स्लाइड्स इन लेआउट्स का उपयोग करती हैं और स्लाइड-विशिष्ट सामग्री को संग्रहीत करती हैं।

**क्या मैं एक प्रस्तुति से दूसरे में लेआउट स्लाइड कॉपी कर सकता हूँ?**

हाँ। गंतव्य संग्रह में एक कॉपी को [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/globallayoutslidecollection/#addClone) मेथड से जोड़ें। प्रस्तुति के बीच कॉपी करते समय, स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं किसी उपयोग में मौज़ूद लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट में हुए परिवर्तन को विरासत में लेती हैं जब तक वे प्रभावित स्वरूपण या ऑब्जेक्ट्स को स्थानीय रूप से ओवरराइड नहीं करतीं। इसलिए कई स्लाइड्स पर प्लेसहोल्डर ज्यामिति और विरासत में मिला शैली एक साथ बदल सकती है। लेआउट को संपादित करने से पहले [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करके प्रभावित स्लाइड्स की पहचान करें।

**यदि मैं किसी प्रयोग में मौजूद लेआउट को हटाता हूँ तो क्या होगा?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनसंदर्भित लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें।
---
title: Python के माध्यम से Java में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/python-java/edit-pdf/
keywords:
- PDF संपादित करें
- PDF पाठ प्रतिस्थापित करें
- PDF से PPTX
- PPTX से PDF
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में Aspose.Slides में आयात करके, पाठ प्रतिस्थापित करके, और संशोधित प्रस्तुति को फिर से PDF के रूप में सहेजकर PDF दस्तावेज़ संपादित करें।"
---
## **सारांश**

Aspose.Slides for Python via Java आपको PDF सामग्री को संपादित करने देता है, इसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके, और इसे पुनः PDF के रूप में निर्यात करके। यह लेख एक सरल पाठ प्रतिस्थापन दिखाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में पाठ प्रतिस्थापित करें**

पृष्ठों को आयात करने के लिए [addFromPdf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromPdf), पाठ को अपडेट करने के लिए [replaceText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#replaceText), और परिणाम को निर्यात करने के लिए [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्न उदाहरण मानता है कि `input.pdf` आयात के बाद संपादन योग्य पाठ के रूप में शब्द "Draft" शामिल करता है। यह शब्द को "Final" से प्रतिस्थापित करता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में एक अतिरिक्त खाली पृष्ठ नहीं बनता। खोज पूरे शब्दों को समान अक्षर केस के साथ मिलाती है; `None` का अर्थ है कि कोई परिणाम कॉलबैक आवश्यक नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

और अधिक विकल्पों के लिए, देखें [पाठ खोजें और प्रतिस्थापित करें](/slides/hi/python-java/search-and-replace-text/) और [PowerPoint को PDF में बदलें](/slides/hi/python-java/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
पाठ प्रतिस्थापन आयातित पाठ पर कार्य करता है, स्कैन की गई छवियों के अंदर के पाठ पर नहीं। रूपांतरण लेआउट और स्वरूपण को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेषकर जब प्रतिस्थापित पाठ मूल पाठ से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजना आवश्यक है?**

नहीं। आप समान प्रस्तुति को मेमोरी में संपादित और निर्यात कर सकते हैं। केवल तब PPTX की प्रतिलिपि सहेजें जब आप इसे PowerPoint में आगे संपादित करना चाहते हों; देखें [प्रस्तुतीकरण सहेजें](/slides/hi/python-java/save-presentation/)।

**कुछ पाठ क्यों अपरिवर्तित रह सकता है?**

उदाहरण पूरे शब्द "Draft" को सटीक केस के साथ मिलाता है। छवि के रूप में आयात किया गया पाठ या अलग-अलग टेक्स्ट फ्रेम में विभाजित पाठ आवश्यक रूप से खोज से मेल नहीं खाएगा। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।
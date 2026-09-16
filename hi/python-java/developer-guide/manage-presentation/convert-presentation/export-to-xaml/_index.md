---
title: Python के माध्यम से Java में प्रस्तुतियों को XAML में निर्यात करें
linktitle: प्रेज़ेंटेशन से XAML
type: docs
weight: 30
url: /hi/python-java/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रेज़ेंटेशन निर्यात
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- PowerPoint से XAML
- OpenDocument से XAML
- प्रेज़ेंटेशन से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को XAML में निर्यात करें। डिफ़ॉल्ट विकल्पों का उपयोग करें या छिपी स्लाइडें शामिल करें।"
---
## **समीक्षा**

यह लेख बताता है कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को XAML में कैसे निर्यात किया जाए। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। लेख कुछ सामान्य प्रश्नों के उत्तर भी देता है, जैसे फॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार।

इन उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। `pres.pptx` को वर्तमान कार्य निर्देशिका में रखें। प्रत्येक उदाहरण JVM को तभी शुरू करता है जब वह पहले से चल रहा न हो।

## **XAML के बारे में**

XAML एक XML-आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसी फ्रेमवर्क में उपयोगकर्ता इंटरफ़ेस को वर्णित करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में उपयोग कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करना**

निम्नलिखित Python उदाहरण दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइडें प्रक्रिया की वर्तमान कार्य निर्देशिका के `pres` उपफ़ोल्डर में सहेजी जाती हैं। फ़ोल्डर स्वचालित रूप से बनाया जाता है, और आवश्यक चित्र भी वहीं सहेजे जाते हैं।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से बिना एक्सटेंशन के लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम की होंगी। यहां तक कि यदि आप इनपुट प्रस्तुति का पूर्ण पथ भी देते हैं, तो आउटपुट फ़ोल्डर वर्तमान कार्य निर्देशिका के सापेक्ष बनाया जाता है, ना कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करना**

XAML निर्यात को नियंत्रित करने के लिए [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) क्लास का उपयोग करें।

आउटपुट को कस्टम स्थान पर सहेजने के लिए `IXamlOutputSaver` को लागू करें और अपनी कार्यान्वयन की एक instance को [setOutputSaver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setOutputSaver) मेथड में [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) को पास करें।

छिपी स्लाइडों को XAML आउटपुट में शामिल करने के लिए, नीचे दिए गए Python उदाहरण की तरह `True` के साथ [setExportHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) को कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **सभी उत्पन्न XAML कलाकृतियों को कैप्चर करें**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़, अलग-अलग चित्र और सहायक संसाधन उत्पन्न कर सकता है। डिफ़ॉल्ट फ़ाइल‑सिस्टम स saver के बजाय इन कलाकृतियों को प्राप्त करने के लिए एक कस्टम `IXamlOutputSaver` को [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setOutputSaver) को असाइन करें। निर्यात को XAML‑विशिष्ट [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) ओवरलोड के साथ शुरू करें जो XAML विकल्पों को स्वीकार करता है।

Python में, Java `IXamlOutputSaver` इंटरफ़ेस को लागू करने के लिए `jpype.JProxy` का उपयोग करें। कॉलबैक पथ को `str` में परिवर्तित करें और वापस करने से पहले Java बाइट ऐरे को Python `bytes` में कॉपी करें, जैसा कि नीचे दर्शाया गया है।

### **कॉलबैक जीवनचक्र को समझें**

निर्यातक प्रत्येक उत्पन्न कलाकृति के लिए अलग‑अलग `IXamlOutputSaver.save` को कॉल करता है:

- `path` कलाकृति की पहचान करता है और इसमें सापेक्ष डायरेक्टरी हो सकती है। इस जानकारी को बनाए रखें क्योंकि XAML संसाधनों को सापेक्ष पथों से संदर्भित कर सकता है।
- `data` में कलाकृति के बाइट शामिल होते हैं। चित्र और अन्य बाइनरी संसाधनों को पाठ के रूप में डीकोड नहीं किया जाना चाहिए।
- स saver को डेटा को वापस करने से पहले बनाए रखने या स्थायी करने की ज़िम्मेदारी होती है। उदाहरण प्रत्येक बाइट ऐरे को एप्लिकेशन‑स्वामित्व वाली मेमोरी में कॉपी करते हैं।
- निर्यात को सफल तभी मानें जब प्रस्तुति सहेजने का ऑपरेशन लौटे और प्रत्येक कॉलबैक सफलतापूर्वक समाप्त हो गया हो। स्टोरेज त्रुटियों को उपेक्षित न करें या अनदेखी बैकग्राउंड राइट्स न शुरू करें। यदि स्थायित्व बाद में होता है, तो कुल सफलता की रिपोर्ट केवल तब करें जब वह चरण भी सफल हो।

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) कस्टम स saver पर भी लागू होता है। डिफ़ॉल्ट सेटिंग `False` छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर रखती है। `True` पास करने से वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गिनती प्रस्तुति पर निर्भर करती है; एक स्लाइड पर एक कॉलबैक या निश्चित कॉलबैक क्रम मानने से बचें।

### **स्मृति में निर्यात करें और कलाकृतियों का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, प्रत्येक कलाकृति को नाम और अपरिवर्तनीय `bytes` मान वाले Python शब्दकोश में इकट्ठा करता है, और उसका नाम, प्रकार, तथा बाइट काउंट प्रिंट करता है। यह प्रदान किए गए नामों को ठीक वैसा ही रखता है। दोहराए गए नाम संग्रह को अमान्य चिह्नित करते हैं, न कि चुपचाप कलाकृति को ओवरराइट करते हैं। उदाहरण परिणामों का उपयोग करने से पहले इस जाँच को करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # केवल XAML को डिकोड करें, और केवल तब जब पाठ्य निरीक्षण आवश्यक हो।
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

विस्तार जाँच निरीक्षण के लिए उपयोगी है; सभी कलाकृतियों को रखें, जिनमें अपरिचित संसाधन प्रकार भी शामिल हैं। बाइट्स को संग्रहीत या प्रेषित करते समय अपरिवर्तित रखें। केवल उन XAML के लिए जो पाठ प्रसंस्करण की आवश्यकता रखते हैं, `bytes.decode` को UTF‑8 के साथ उपयोग करें।

### **एक ZIP संग्रह में संग्रहीत कलाकृतियों को पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को इकट्ठा करता है, उसके नामों को मान्य करता है, और मूल बाइट्स को एक ZIP संग्रह में लिखता है। एक अनोखा संग्रह नाम समानांतर निर्यात कार्यों को अलग करता है। ZIP एंट्रीज़ फॉरवर्ड स्लैश का उपयोग करती हैं और सापेक्ष डायरेक्टरी को बरकरार रखती हैं। असुरक्षित नाम या सामान्यीकरण के बाद टकराए हुए नाम पूरे पैकेज को लिखे जाने से पहले अस्वीकार कर देते हैं।

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # बंद करना सफल रिपोर्ट होने से पहले ZIP निर्देशिका को अंतिम रूप देता है।
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

उदाहरण Python के `zipfile.ZipFile` का उपयोग करके एक स्थानीय संग्रह लिखता है; निर्यातकर्ता स्वयं ढीले XAML या चित्र फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, संग्रह‑लेखन चरण को इकट्ठा किए गए बाइट ऐरे की अपलोड्स से बदलें। निर्यात‑कार्य पहचानकर्ता के साथ पूर्ण सापेक्ष कलाकृति नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या कार्य पहचानकर्ता, सापेक्ष नाम, और बाइनरी डेटा को डेटाबेस पंक्ति में संग्रहीत करें। सभी अपलोड पूर्ण होने या डेटाबेस लेन‑देन कमिट होने के बाद ही कार्य प्रकाशित करें। यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, एक कस्टम स saver प्रत्येक कलाकृति को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है ताकि पूरे निर्यात की अतिरिक्त प्रति मेमोरी में न रहे। निर्यातकर्ता के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: केवल तब लौटें जब गंतव्य ने बाइट्स स्वीकार कर ली हों, और त्रुटियों को कॉलर तक पहुंचने दें।

### **संसाधन नामों को संरक्षित रखें और संदर्भों को सत्यापित करें**

- जब गंतव्य इसे आवश्यक समझे तो पथ विभाजकों को सामान्यीकृत करें, लेकिन सापेक्ष डायरेक्टरी को बरकरार रखें। केवल `pathlib.Path.name` का उपयोग न करें जब तक कि प्रत्येक उत्पन्न नाम अद्वितीय हो और संसाधन संदर्भ वैध रहें।
- गंतव्य‑विशिष्ट नाम मान्यता लागू करें। ढीली फ़ाइलें लिखते समय मूल पथ और ट्रैवर्सल खण्डों को अस्वीकार करें, गंतव्य को `pathlib.Path.resolve` से हल करें, और सुनिश्चित करें कि यह इच्छित निर्यात निर्देशिका के भीतर ही रहे, जिसमें containment जाँच में डायरेक्टरी विभाजक शामिल हो। सिम्बॉलिक लिंक वाले डायरेक्टरी का उपयोग न करें जो लिखने को पुनर्निर्देशित कर सकते हैं।
- प्रत्येक निर्यात कार्य के लिए अलग‑अलग स saver और स्टोरेज नेमस्पेस का प्रयोग करें। विभाजक सामान्यीकरण और गंतव्य की केस‑संवेदनशीलता नियमों के अनुसार टकरावों का पता लगाएँ।
- प्रकाशित करने से पहले, प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसके फ़ाइल‑आधारित संसाधन संदर्भों, जैसे चित्र `Source` या `ImageSource` एट्रिब्यूट्स, की जाँच करें। प्रत्येक सापेक्ष URI को सम्मिलित XAML कलाकृति की डायरेक्टरी के विरुद्ध हल करें, परिणामी स्टोरेज नाम को सामान्यीकृत करें, और पुष्टि करें कि संबंधित map key, ZIP एंट्री, या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के लिए, यदि `pres/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज के लिए, कार्य प्रीफ़िक्स के तहत समान लेआउट को बरकरार रखें और उन संसाधन URLs को XAML उपभोक्ता के लिए सुलभ बनाएं। पूर्ण ZIP को पुनः खोलकर एंट्री नाम और संसाधन बाइट्स की जाँच करें, और लक्ष्य XAML पर्यावरण में प्रतिनिधि स्लाइड्स लोड करके पुष्टि करें कि चित्र सही ढंग से हल हो रहे हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मशीन पर मूल फ़ॉन्ट उपलब्ध न होने पर भविष्यवाणी योग्य फ़ॉन्ट कैसे सुनिश्चित करूं?**

[XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) में `[setDefaultRegularFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)` को कॉल करें — यह निर्यात के दौरान मूल फ़ॉन्ट अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में उपयोग होता है। यह यह गारंटी नहीं देता कि उत्पन्न XAML फ़ॉन्ट को संदर्भित करेगा या फ़ॉन्ट लक्ष्य मशीन पर उपलब्ध होगा। XAML द्वारा संदर्भित फ़ॉन्ट को उस वातावरण में उपलब्ध कराना सुनिश्चित करें जहाँ यह प्रदर्शित होगा।

**क्या निर्यातित XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसे अन्य XAML स्टैक्स के साथ संगतता की गारंटी नहीं है। उत्पन्न मार्कअप को अपने लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकूँ?**

डिफ़ॉल्ट रूप से छिपी स्लाइडें शामिल नहीं होतीं। आप इस व्यवहार को [setExportHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) के माध्यम से [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) में नियंत्रित कर सकते हैं — यदि आपको उनकी निर्यात की आवश्यकता नहीं है तो इसे निष्क्रिय रखें।
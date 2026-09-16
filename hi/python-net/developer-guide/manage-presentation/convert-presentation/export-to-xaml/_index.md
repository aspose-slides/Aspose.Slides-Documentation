---
title: Python के साथ XAML में प्रस्तुतियों को निर्यात करें
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/python-net/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
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
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python से PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें—एक त्वरित, Office‑मुक्त समाधान जो लेआउट को अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने के बारे में बताता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। यह लेख कुछ सामान्य प्रश्नों के उत्तर भी देता है, जैसे फॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार।

## **XAML के बारे में**

XAML एक XML-आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ्रेमवर्क में उपयोगकर्ता इंटरफ़ेस वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में काम कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुति निर्यात**

निम्नलिखित Python उदाहरण डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में निर्यात करने को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइडें प्रक्रिया की वर्तमान कार्यनिर्देशिका (`os.getcwd` द्वारा प्राप्त) के एक `pres` उपफ़ोल्डर में सहेजी जाती हैं। फ़ोल्डर स्वतः बनाया जाता है, और आवश्यक छवियां भी वहीं सहेजी जाती हैं।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से उसके एक्सटेंशन के बिना लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम से बनती हैं। भले ही आप इनपुट प्रस्तुति के लिए एक पूर्ण पथ प्रदान करें, आउटपुट फ़ोल्डर वर्तमान कार्यनिर्देशिका के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रस्तुति निर्यात**

Aspose.Slides कैसे प्रस्तुति को XAML में निर्यात करता है, इसे नियंत्रित करने के लिए [XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) क्लास का उपयोग करें।

XAML आउटपुट में छिपी स्लाइडें शामिल करने के लिए, नीचे दिए गए Python उदाहरण की तरह `export_hidden_slides` प्रॉपर्टी को `True` सेट करें:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **सभी उत्पन्न XAML कलाकृतियों को कैप्चर करें**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़, साथ ही अलग-अलग छवियां और सहायक संसाधन बना सकता है। निर्यात को संग्रहीत या प्रसारित करते समय इन सभी फ़ाइलों को रखें।

नीचे दिए गए उदाहरण डिफ़ॉल्ट फ़ाइल‑सिस्टम स saver का उपयोग एक अस्थायी निर्देशिका में करते हैं, फिर उत्पन्न फ़ाइलों को एकत्र करते हैं।

### **निर्यात जीवनचक्र को समझें**

- XAML‑विशिष्ट `Presentation.save` ओवरलोड को XAML विकल्पों के साथ शुरू करें। केवल सफल रिटर्न के बाद ही उत्पन्न फ़ाइलें पढ़ें।
- प्रत्येक कलाकृति के सापेक्ष पथ को संरक्षित रखें, क्योंकि XAML सापेक्ष पथों से संसाधनों को संदर्भित कर सकता है।
- कलाकृतियों को बाइट्स के रूप में पढ़ें। छवियों और अन्य बाइनरी संसाधनों को टेक्स्ट के रूप में डिकोड नहीं किया जाना चाहिए।
- संग्रह और किसी भी बाद के संग्रहण कार्य पूरा होने के बाद ही कुल सफलता की रिपोर्ट दें। संग्रहण त्रुटियों को कॉलर तक पहुँचने दें, और यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

`XamlOptions.export_hidden_slides` का डिफ़ॉल्ट मान `False` है, जिससे छिपी‑स्लाइड XAML दस्तावेज़ बाहर रखे जाते हैं। इसे `True` करने पर वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गिनती प्रस्तुति पर निर्भर करती है; प्रत्येक स्लाइड के लिए एक फ़ाइल होने का अनुमान न लगाएँ।

{{% alert color="warning" title="Warning" %}}
उदाहरण अस्थायी रूप से प्रक्रिया की वर्तमान कार्यनिर्देशिका को बदलते हैं, जो सभी थ्रेड्स को प्रभावित करता है। प्रत्येक निर्यात को एक समर्पित वर्कर प्रक्रिया में चलाएँ, या सुनिश्चित करें कि निर्यात के दौरान प्रक्रिया में अन्य कोई कार्य वर्तमान निर्देशिका पर निर्भर न हो। केवल एक अद्वितीय अस्थायी निर्देशिका समान प्रक्रिया में समकालिक निर्यात को सुरक्षित नहीं बनाती।
{{% /alert %}}

### **स्मृति में निर्यात करें और कलाकृतियों का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, इसे एक अस्थायी निर्देशिका में निर्यात करता है, प्रत्येक कलाकृति को सापेक्ष नाम और बाइट्स के शब्दकोश में इकट्ठा करता है, और उसका नाम, प्रकार और बाइट गिनती प्रिंट करता है। यह उत्पन्न डायरेक्टरी संरचना को संरक्षित करता है और संग्रह के बाद अस्थायी फ़ाइलों को हटा देता है। इनपुट पथ को कार्यनिर्देशिका बदलने से पहले ही हल किया जाता है।

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # केवल XAML को डिकोड करें, और केवल तब जब पाठ्य निरीक्षण की आवश्यकता हो।
```

विस्तार जांच निरीक्षण के लिए उपयोगी है; सभी कलाकृतियों को रखें, जिसमें अपरिचित संसाधन प्रकार भी शामिल हैं। संग्रहीत या प्रसारित करते समय बाइट्स को अपरिवर्तित रखें। केवल उसी XAML को डिकोड करें जिसे टेक्स्ट प्रसंस्करण की आवश्यकता हो। यह दृष्टिकोण अस्थायी डिस्क स्पेस के साथ साथ संग्रहित निर्यात के लिए मेमोरी का भी उपयोग करता है।

### **संकलित कलाकृतियों को ZIP अभिलेख में पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को एकत्र करता है, उसके नामों को मान्य करता है, और मूल बाइट्स को एक ZIP अभिलेख में लिखता है। एक अद्वितीय अभिलेख नाम निर्यात कार्यों को अलग करता है। ZIP प्रविष्टियों में फ़ॉरवर्ड स्लैश का प्रयोग होता है और सापेक्ष डायरेक्टरी संरक्षित रहती है। असुरक्षित नाम या सामान्यीकरण के बाद टकराव करने वाले नाम पूरे पैकेज को लिखने से पहले अस्वीकार कर दिए जाते हैं।

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP निर्देशिका को सफलता की रिपोर्ट करने से पहले अंतिम रूप दिया गया है।
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

उदाहरण `ZipFile` ([डॉक्यूमेंटेशन](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile)) का उपयोग करके अस्थायी निर्यात को एकत्र करने के बाद एक स्थानीय अभिलेख लिखता है। रिमोट संग्रहण के लिए, अभिलेख‑लेखन चरण को संकलित बाइट्स के अपलोड से बदलें। निर्यात‑कार्य पहचानकर्ता और पूर्ण सापेक्ष कलाकृति नाम को ऑब्जेक्ट कुंजी के रूप में उपयोग करें, या डेटाबेस पंक्ति में कार्य‑पहचानकर्ता, सापेक्ष नाम, और बाइनरी डेटा को सहेजें। सभी अपलोड पूर्ण होने या डेटाबेस लेन‑देन कमिट होने के बाद ही कार्य प्रकाशित करें। यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, निर्यात के बाद अस्थायी फ़ाइलों को एक‑एक करके प्रोसेस करें, सभी बाइट्स को शब्दकोश में एकत्र करने के बजाय। इससे सम्पूर्ण निर्यात की अतिरिक्त इन‑मे‑मोरी कॉपी नहीं बनती, लेकिन निर्यातकर्ता की अपनी मेमोरी आवश्यकताएँ बनी रहती हैं।

### **संसाधन नामों को संरक्षित रखें और संदर्भों को सत्यापित करें**

- गंतव्य की आवश्यकता के अनुसार पथ विभाजकों को सामान्यीकृत करें, लेकिन सापेक्ष डायरेक्टरी संरक्षित रखें। केवल अंतिम फ़ाइल नाम न रखें जब तक कि प्रत्येक उत्पन्न नाम अद्वितीय हो और संसाधन संदर्भ वैध रहें।
- गंतव्य‑विशिष्ट नाम मान्यकरण लागू करें। ढीली फ़ाइलें लिखते समय पूर्ण पथ और traversal भागों को अस्वीकार करें, गंतव्य को हल करें, और सुनिश्चित करें कि वह इच्छित निर्यात फ़ोल्डर के नीचे ही रहे। प्रतीकात्मक लिंक रहित, अनुप्रयोग‑नियंत्रित डायरेक्टरी का उपयोग करें जो लेखन को पुनर्निर्देशित न करे।
- प्रत्येक निर्यात कार्य के लिए अलग संग्रहण नेमस्पेस उपयोग करें। विभाजक सामान्यीकरण और गंतव्य के केस‑संवेदनशील नियमों के अनुसार टकराव का पता लगाएँ।
- प्रकाशित करने से पहले, प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसकी फ़ाइल‑आधारित संसाधन संदर्भों (जैसे छवि `Source` या `ImageSource` गुण) की जाँच करें। प्रत्येक सापेक्ष URI को संबंधित XAML कलाकृति के डायरेक्टरी के सापेक्ष हल करें, परिणामी संग्रहण नाम को सामान्यीकृत करें, और पुष्टि करें कि संबंधित शब्दकोश कुंजी, ZIP प्रविष्टि, या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के लिए, यदि `pres/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखने से वह संबंध टूट जाएगा। ऑब्जेक्ट स्टोरेज के लिए, कार्य‑उपनाम के नीचे समान लेआउट बनाए रखें और उन संसाधन URL को XAML उपभोक्ता के लिए सुलभ बनाएं। पूर्ण ZIP को पुनः खोलकर प्रविष्टि नाम और संसाधन बाइट्स की जाँच करें, और लक्ष्य XAML वातावरण में नमूना स्लाइड लोड करके पुष्टि करें कि छवियां सही ढंग से हल हो रही हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वानुमेय फ़ॉन्ट कैसे सुनिश्चित करूँ?**

`XamlOptions` में `default_regular_font` सेट करें — यह निर्यात के दौरान मूल फ़ॉन्ट अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। इससे यह गारंटी नहीं मिलती कि उत्पन्न XAML फॉलबैक फ़ॉन्ट को संदर्भित करेगा या वह लक्ष्य मशीन पर उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट लक्ष्य पर्यावरण में उपलब्ध हों।

**क्या निर्यातित XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसी अन्य XAML स्टैक्स के साथ संगतता की कोई गारंटी नहीं है। उत्पन्न मार्कअप को अपने लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी स्लाइडों का समर्थन है, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोका जाए?**

डिफ़ॉल्ट रूप से छिपी स्लाइडें शामिल नहीं होतीं। आप इस व्यवहार को `XamlOptions` में `export_hidden_slides` के माध्यम से नियंत्रित कर सकते हैं — यदि आपको इन्हें निर्यात करने की आवश्यकता नहीं है तो इसे निष्क्रिय रखें।
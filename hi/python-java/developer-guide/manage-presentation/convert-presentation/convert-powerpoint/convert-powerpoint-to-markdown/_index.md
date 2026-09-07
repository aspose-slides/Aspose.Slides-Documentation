---
title: Python में Java के माध्यम से PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से MD
- प्रस्तुति से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रस्तुति को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रस्तुति
- Markdown
- Python
- Java
- Aspose.Slides
description: "PPT और PPTX प्रस्तुतियों को Python में Java के माध्यम से Markdown में बदलें और निर्यातित bitmap, metafile और SVG छवियों को कहाँ सहेजा और संदर्भित किया जाता है, इसे नियंत्रित करें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थैतिक‑साइट, सामग्री‑स्थानांतरण, और संस्करण‑नियंत्रण कार्यप्रवाहों के लिए मार्कडाउन में बदल सकता है। आप एक मार्कडाउन फ़्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडरिंग को नियंत्रित कर सकते हैं, और यह तय कर सकते हैं कि निर्यातित छवियों को कहाँ संग्रहीत किया जाए और उत्पन्न मार्कडाउन उन्हें कैसे संदर्भित करता है।

डिफ़ॉल्ट रूप से, Markdown export केवल पाठ आउटपुट उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, निर्यात प्रकार को [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setExportType) मेथड से [MarkdownExportType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownexporttype/) enumeration के `Sequential` या `Visual` मान पर सेट करें। `Sequential` स्लाइड वस्तुओं को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित वस्तुओं को साथ रखकर उनके दृश्य संबंध को बनाए रखता है। `TextOnly` मान छवि संसाधनों को उत्पन्न नहीं करता, इसलिए इस मोड में image‑saving कॉलबैक नहीं बुलाए जाते।

## **प्रस्तुति को मार्कडाउन में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) enumeration से `Md` मान के साथ कॉल करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

प्रत्येक उदाहरण वर्तमान कार्यशील निर्देशिका से `presentation.pptx` पढ़ता है। उदाहरण चलाने से पहले Aspose.Slides for Python via Java और एक संगत Java runtime स्थापित करें। प्रत्येक Python प्रक्रिया के लिए JVM को एक बार शुरू करें।

## **मार्कडाउन फ़्लेवर चुनें**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setFlavor) मेथड आउटपुट के लिए उपयोग की जाने वाली Markdown स्पेसिफिकेशन को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/flavor/) enumeration में CommonMark, GitHub Flavored Markdown, और अन्य समर्थित वैरिएंट शामिल हैं।

निम्न उदाहरण प्रस्तुति को CommonMark के रूप में निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने वाले व्यवहार का उपयोग करके छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/) क्लास दो मेथड प्रदान करता है जो स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करते हैं:

- [setBasePath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) मार्कडाउन दस्तावेज़ और उसकी संसाधनों के आधार निर्देशिका को निर्दिष्ट करता है।
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) छवि उपनिर्देशिका को निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और मार्कडाउन दस्तावेज़ में सापेक्ष छवि संदर्भ बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

यह व्यवहार तब फॉलबैक के रूप में भी कार्य करता है जब कोई कस्टम image‑saving हैंडलर `False` लौटाता है।

## **छवि सहेजना और Markdown लिंक को अनुकूलित करें**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/) मेथड का उपयोग करके आप non‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए कॉलबैक पंजीकृत कर सकते हैं जो Markdown export के दौरान उत्पन्न होते हैं। इसका `MarkdownImageSavingHandler` कॉलबैक छवि ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/) मान, और उत्पन्न Markdown लिंक को एक‑तत्वीय `String[]` पैरामीटर के रूप में प्राप्त करता है। प्रदान किए गए फ़ॉर्मेट के साथ छवि को सहेजें या अपलोड करें, और `link[0]` को उस संदर्भ से बदलें जो Markdown आउटपुट में दिखना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न होने वाले संसाधनों को अलग से संभाला जाता है। [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/) मेथड के साथ एक कॉलबैक पंजीकृत करें। इसका `MarkdownSvgImageSavingHandler` कॉलबैक एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) ऑब्जेक्ट और एक‑तत्वीय `String[] link` पैरामीटर प्राप्त करता है। SVG में कोई `ImageFormat` आर्ग्यूमेंट नहीं होता; उसके XML डेटा को [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/#getSvgData) मेथड से लिखें या अपलोड करें। निर्यात मोड और दृश्य समूहबद्धता के आधार पर, स्रोत प्रस्तुति में कोई SVG रास्टराइज़ या अन्य सामग्री के साथ जोड़ा जा सकता है; परिणामी non‑SVG संसाधन फिर image‑saving कॉलबैक को पास किया जाता है। जब प्रत्येक निर्यातित दृश्य संसाधन को कस्टम प्रोसेसिंग की आवश्यकता हो तो दोनों कॉलबैक पंजीकृत करें।

हैंडलर का रिटर्न वैल्यू तय करता है कि छवि को कौन प्रोसेस करता है:

- `True` लौटाएँ जब हैंडलर ने छवि को सहेज दिया हो, अपलोड किया हो, ट्रांसफ़ॉर्म किया हो, या किसी भी तरह से प्रोसेस किया हो और `link[0]` को वैध मान असाइन किया हो। Aspose.Slides वह मान मार्कडाउन दस्तावेज़ में लिखता है और डिफ़ॉल्ट स्थानीय सहेजना नहीं करता।
- `False` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेजे और लिंक को उन मानों के अनुसार उत्पन्न करे जो आप [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) से सेट कर चुके हैं।

{{% alert color="danger" title="Important" %}}
`True` लौटाने वाला हैंडलर छवि के लिए ज़िम्मेदारी लेता है। यदि वह `True` लौटाता है लेकिन वैध, गैर‑खाली लिंक असाइन नहीं करता, तो निर्यात `InvalidOperationException` के साथ विफल हो जाता है।
{{% /alert %}}

Python में आप इन कॉलबैक को `jpype.JProxy` के साथ पंजीकृत करते हैं, जो Java कॉलबैक इंटरफ़ेस को उसके `invoke` मेथड द्वारा लागू करता है। `link` आर्ग्यूमेंट एक mutable Java स्ट्रिंग एरे है: `link[0]` को प्रोसेस करने से पहले Python स्ट्रिंग में बदलें, फिर प्रतिस्थापन URL को वापस `link[0]` में असाइन करें।

### **CDN मूल निर्देशिका में छवियों को सहेजें और बाहरी URLs का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को माउंट या सिंक्रनाइज़्ड CDN मूल निर्देशिका मानता है। प्रत्येक हैंडलर निर्मित फ़ाइल नाम निकालता है, छवि को उस कस्टम निर्देशिका में सहेजता है, और निर्मित स्थानीय संदर्भ को सार्वजनिक CDN URL से बदल देता है। स्वयं नमूना कोई नेटवर्क अपलोड नहीं करता: URL केवल तभी वैध होता है जब निर्देशिका को CDN मूल के रूप में माउंट किया जाता है या उसकी फ़ाइलें CDN पर प्रकाशित की जाती हैं। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम लिखने को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और अपलोड सफल होने पर ही `link[0]` असाइन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

बिटमैप हैंडलर दृढ़तापूर्वक `False` लौटाता है उन छवियों के लिए जो 128 × 128 पिक्सेल से छोटी हैं, इसलिए Aspose.Slides उन छवियों को `output/fallback-images` में डिफ़ॉल्ट व्यवहार से सहेजता है। बड़े बिटमैप और मेटाफाइल संसाधन, साथ ही SVG संसाधन, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, निर्मित स्थानीय संदर्भ `fallback-images/image1.png` बन जाता है `https://cdn.example.com/presentations/quarterly-report/image1.png`। हैंडलर फ़ाइल‑सिस्टम पाथ केवल फ़ाइलें लिखते समय उपयोग करते हैं; Markdown में लिखे गए लिंक फ़ॉरवर्ड स्लैश और URL‑escaped फ़ाइल नाम होते हैं। सापेक्ष लिंक बनाते समय भी वही नियम अपनाएँ: `/` उपयोग करें, प्लेटफ़ॉर्म‑विशिष्ट डिरेक्टरी सेपरेटर नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक ही हैंडलर रास्टर छवियों और SVG छवियों दोनों को प्रोसेस कर सकता है?**

नहीं। उत्पन्न बिटमैप और मेटाफाइल संसाधनों के लिए [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/) उपयोग करें और SVG के रूप में उत्पन्न संसाधनों के लिए [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/) उपयोग करें। पहला एक छवि ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/) मान प्रदान करता है; दूसरा एक [SvgImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) ऑब्जेक्ट प्रदान करता है जिसका SVG डेटा आप [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/#getSvgData) से पढ़ सकते हैं। निर्यात के दौरान रास्टराइज़ किया गया स्रोत SVG छवि image‑saving कॉलबैक द्वारा प्रोसेस किया जाता है।

**जब कोई image‑saving हैंडलर `False` लौटाता है तो क्या होता है?**

Aspose.Slides अपना डिफ़ॉल्ट स्थानीय‑सहेजने वाला व्यवहार उपयोग करता है। छवि का स्थान और निर्मित संदर्भ उन मानों द्वारा नियंत्रित होते हैं जो आप [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) से सेट किए हैं।

**क्या कोई हैंडलर छवि को स्थानीय रूप से सहेजे बिना URL प्रदान कर सकता है?**

हां। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को पास कर सकता है, resulting URL को `link[0]` में असाइन कर सकता है, और `True` लौटाता है। हैंडलर को पूरी प्रोसेसिंग स्वयं करनी होगी; `True` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रोका जाता है।

**Markdown export के दौरान हैंडलर से `InvalidOperationException` क्यों फेंका जाता है?**

यह तब होता है जब हैंडलर `True` लौटाता है लेकिन वैध लिंक प्रदान नहीं करता। `True` लौटाने से पहले वह रिलेटिव पाथ या बाहरी URL असाइन कर दें जो Markdown में लिखा जाना चाहिए।

**छवि लिंक में कौन सा पाथ सेपरेटर उपयोग किया जाना चाहिए?**

Markdown लिंक और URLs में फ़ॉरवर्ड स्लैश (`/`) का उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `pathlib.Path` का उपयोग करें, फिर Markdown संदर्भ को अलग से बनाएँ या सामान्यीकृत करें।

**क्या Hyperlinks Markdown export के दौरान संरक्षित रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/python-java/manage-hyperlinks/) को सामान्य Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/python-java/slide-transition/) और [animations](/slides/hi/python-java/powerpoint-animation/) को नहीं बदला जाता।

**क्या प्रस्तुतियों को समानांतर में Markdown में बदला जा सकता है?**

आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा नहीं करें। [multithreading guidelines](/slides/hi/python-java/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए अलग इंस्टेंस उपयोग करें।
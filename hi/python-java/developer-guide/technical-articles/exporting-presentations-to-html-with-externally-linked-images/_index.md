---
title: बाहरी रूप से लिंक्ड छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint से HTML
- OpenDocument से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- लिंक्ड छवि
- बाहरी रूप से लिंक्ड छवि
- लिंक्ड संसाधन
- बाहरी संसाधन
- Python
- Java
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ छवियां और अन्य संसाधनों को बाहरी लिंक्ड फ़ाइलों के रूप में सहेजा जाता है।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्व-निहित HTML फ़ाइल में निर्यात करता है। छवियों और अन्य संसाधनों को सीधे HTML में लिखा जाता है, सामान्यतः Base64 डेटा के रूप में। यह तब सुविधाजनक होता है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेब साइट, CMS, या सर्वर-साइड रूपांतरण पाइपलाइन के लिए सर्वश्रेष्ठ फ़ॉर्मेट नहीं होता।

बाहरी रूप से लिंक्ड संसाधनों का उपयोग तब करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करना;
- छवियों, फ़ॉन्ट्स, ऑडियो, या वीडियो को ब्राउज़र या CDN में अलग-अलग कैश करना;
- निर्यात के बाद उत्पन्न संसाधनों की जाँच, प्रतिस्थापन, संपीड़न, या पोस्ट-प्रोसेस करना;
- आउटपुट संरचना को वेब अनुप्रयोग की अपेक्षा के करीब रखना।

सामान्य HTML रूपांतरण वर्कफ़्लो के लिए, देखें [PowerPoint प्रस्तुतीकरण को HTML में बदलें](/slides/hi/python-java/convert-powerpoint-to-html/)। यह लेख निर्यात के संसाधन-लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड संसाधन निर्यात कैसे काम करता है**

`ILinkEmbedController` आपके अनुप्रयोग को संसाधन-दर-संसाधन यह तय करने देता है कि निर्यातकर्ता डेटा को HTML में एम्बेड करे या उसे बाहरी रूप से सहेज कर एक लिंक लिखे।

इंटरफ़ेस में तीन मेथड हैं:

- `ILinkEmbedController.getObjectStoringLocation` निर्धारित करता है कि किसी संसाधन को लिंक करना है या एम्बेड करना।
- `ILinkEmbedController.getUrl` जेनरेटेड HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाने वाला URL लौटाता है।
- `ILinkEmbedController.saveExternal` लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज टारगेट पर लिखता है।

फ़ाइल सिस्टम पथ और ब्राउज़र URL अलग-अलग विचार होते हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलों को डिस्क पर `html-output/assets` में लिखता है, जबकि HTML में `assets/resource-1.svg` जैसे सापेक्ष URL होते हैं। ब्राउज़र इन URL को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक शामिल है। इसलिए, `presentation.html` से एक SVG फ़ाइल का लिंक `assets/resource-1.svg` का उपयोग करता है, जबकि उसी SVG फ़ाइल से उसी `assets` फ़ोल्डर में सहेजी गई छवि का लिंक `resource-4.jpg` का उपयोग करता है।

## **लिंक्ड संसाधनों के साथ HTML निर्यात**

निम्नलिखित Python उदाहरण एक आउटपुट निर्देशिका बनाता है, HTML फ़ाइल को वहीं सहेजता है, और लिंक्ड संसाधनों को `assets` उपनिर्देशिका में संग्रहीत करता है। जब Aspose.Slides एक सुरक्षित फ़ाइल एक्सटेंशन प्रदान करता है या उसका अनुमान लगा सकता है, तब कंट्रोलर सामान्य छवि, फ़ॉन्ट, ऑडियो, वीडियो, और CSS संसाधनों को लिंक करता है। जो संसाधन पहचाने नहीं जाते वे एम्बेडेड ही रहते हैं।

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

निर्यात के बाद, आउटपुट फ़ोल्डर की संरचना इस प्रकार है:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर छवियों को आमतौर पर JPEG या PNG के रूप में निर्यात किया जाता है। जब वह छोटा या अधिक उपयुक्त फ़ाइल बनाता है, तो Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए कोडेक से अलग छवि कोडेक चुन सकता है। पारदर्शिता वाली छवियों को PNG के रूप में निर्यात किया जाता है।

## **डिप्लॉयमेंट के लिए URL चुनना**

नमूना एक सापेक्ष URL उपसर्ग उपयोग करता है: `assets/`। यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड संसाधन दूसरे लिंक्ड संसाधन का संदर्भ देता है, तो नमूना `ILinkEmbedController.getUrl` में `referrer` पैरामीटर का उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलें कहीं और डिप्लॉय की जाएँ तो अलग URL उपसर्ग उपयोग करें:

- `assets/` का उपयोग करें जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो।
- `../assets/` का उपयोग करें जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो।
- `https://cdn.example.com/presentations/job-123/assets/` का उपयोग करें जब फ़ाइलें CDN या स्थिर फ़ाइल सर्वर पर अपलोड की गई हों।

`ILinkEmbedController.getUrl` द्वारा लौटाया गया URL, `ILinkEmbedController.saveExternal` द्वारा लिखी गई फ़ाइल के अंतिम डिप्लॉयमेंट स्थान से मेल खाता होना चाहिए। सर्वर अनुप्रयोगों में, प्रत्येक रूपांतरण कार्य के लिए एक अनोखा आउटपुट डायरेक्टरी या ऑब्जेक्ट-स्टोरेज प्रीफ़िक्स उपयोग करें ताकि किसी अन्य निर्यात की फ़ाइलों पर ओवरराइट से बचा जा सके।

## **कब एम्बेड करना चाहिए**

एम्बेडेड Base64 HTML अभी भी उपयोगी है जब आउटपुट को एक ही फ़ाइल होना चाहिए, जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या वह दस्तावेज़ जिसे बिना समर्थन एसेट फ़ोल्डर के स्थानांतरित किया जाएगा। लिंक्ड संसाधन अधिक उपयुक्त होते हैं जब HTML को वेब अनुप्रयोग द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा अनुकूलित किया जाएगा, या ब्राउज़र द्वारा HTML से स्वतंत्र रूप से कैश किया जाएगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल छवियों को बाहरी बना सकता हूँ और अन्य संसाधनों को एम्बेडेड रख सकता हूँ?**

हाँ। `ILinkEmbedController.getObjectStoringLocation` में, उन सामग्री प्रकारों के लिए केवल [LinkEmbedDecision.Link](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linkembeddecision/#Link) लौटाएँ जिन्हें आप अलग फ़ाइलों के रूप में सहेजना चाहते हैं, और बाकी सभी के लिए [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linkembeddecision/#Embed) लौटाएँ।

**निर्यातित छवि एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों होता है?**

Aspose.Slides HTML निर्यात के दौरान आकार या ब्राउज़र संगतता में सुधार के लिए रास्टर छवियों को पुनः एन्कोड कर सकता है। उदाहरण के लिए, स्रोत फ़ाइल की एक छवि को रेंडर किए गए परिणाम के आधार पर JPEG या PNG के रूप में लिखा जा सकता है।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URL काम करेंगे?**

सापेक्ष URL तभी काम करते हैं जब समान सापेक्ष फ़ोल्डर संरचना बनी रहती है। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में रहना चाहिए, जब तक आप कोई अलग URL उपसर्ग न बनाएं।

**क्या सर्वर अनुप्रयोगों को वही आउटपुट फ़ोल्डर पुनः उपयोग करना चाहिए?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक अनोखा आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। यह फ़ाइलनाम टकराव से बचाता है और एक निर्यात द्वारा उत्पन्न संसाधनों को दूसरे निर्यात द्वारा ओवरराइट होने से रोकता है।
---
title: Python में बाहरी रूप से लिंक किए गए चित्रों के साथ प्रस्तुतियों को HTML में निर्यात करें
linktitle: बाहरी रूप से लिंक किए गए चित्रों के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- लिंक्ड इमेज
- बाहरी रूप से लिंक्ड इमेज
- लिंक्ड रिसोर्स
- बाहरी रिसोर्स
- Python
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ चित्र बाहरी लिंक वाली फ़ाइलों के रूप में सहेजे जाते हैं।"
---
## **सारांश**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्वनिहित HTML फ़ाइल में निर्यात करता है। चित्र और अन्य संसाधन सीधे HTML में लिखे जाते हैं, आमतौर पर Base64 डेटा के रूप में। यह तब उपयोगी है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेब साइट, CMS, या सर्वर‑साइड परिवर्तन पाइपलाइन के लिए सर्वोत्तम फ़ॉर्मेट नहीं होता।

बाहरी रूप से लिंक किए गए चित्रों का उपयोग तब करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करें;
- ब्राउज़र या CDN में चित्रों को अलग से कैश करें;
- निर्यात के बाद उत्पन्न चित्रों को जांचें, बदलें, संपीड़ित करें या पोस्ट‑प्रोसेस करें;
- आउटपुट संरचना को वेब एप्लिकेशन की अपेक्षा के करीब रखें।

सामान्य HTML परिवर्तन कार्यप्रवाह के लिए, देखें [Convert PowerPoint Presentations to HTML](/slides/hi/python-net/convert-powerpoint-to-html/)। यह लेख निर्यात के चित्र‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड इमेज एक्सपोर्ट कैसे काम करता है**

.NET और Java में, [ILinkEmbedController](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/ilinkembedcontroller/) वह कॉलबैक इंटरफ़ेस दर्शाता है जिसका उपयोग एक्सपोर्टर यह तय करने के लिए करता है कि कोई संसाधन एम्बेड किया जाए या लिंक किया जाए। Python via .NET में, Python क्लासेज़ अभी इस .NET कॉलबैक इंटरफ़ेस को सीधे लागू नहीं कर सकतीं, इसलिए व्यावहारिक कार्यप्रवाह इस प्रकार है:

1. प्रस्तुति को HTML में निर्यात करें [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) के साथ।
1. स्लाइड को HTML में SVG के रूप में प्रदर्शित करने के लिए [SlideImageFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/slideimageformat/) को [SVGOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/) के साथ उपयोग करें।
1. HTML `data:` URL से Base64 चित्र डेटा को अलग फ़ाइलों में स्थानांतरित करें।
1. मूल `data:` URL को सापेक्ष लिंक जैसे `assets/resource-1.jpg` से बदलें।

फ़ाइल सिस्टम पाथ और ब्राउज़र URL अलग‑अलग चिंताएँ हैं। उदाहरण के लिए, नीचे दिया गया नमूना चित्र फ़ाइलों को `html-output/assets` पर लिखता है, जबकि HTML में सापेक्ष URL जैसे `assets/resource-1.jpg` होते हैं। ब्राउज़र इन URL को उस HTML फ़ाइल के सापेक्ष हल करता है जिसमें लिंक मौजूद है।

## **लिंक्ड छवियों के साथ HTML निर्यात**

निम्नलिखित Python उदाहरण एक आउटपुट डायरेक्टरी बनाता है, HTML फ़ाइल को वहाँ सहेजता है, निकाले गए चित्रों को `assets` उप‑डायरेक्टरी में रखता है, और Base64 चित्र URL को सापेक्ष लिंक में परिवर्तित करता है। यह उदाहरण सामान्य Base64 चित्र फ़ॉर्मेट को निकालता है जब Aspose.Slides एक सुरक्षित फ़ाइल एक्सटेंशन प्रदान करता है। उन Data URL जो पहचाने नहीं जाते, वे एम्बेडेड बने रहते हैं।

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

निर्यात के बाद, आउटपुट फ़ोल्डर में यह संरचना हो सकती है:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर चित्र अक्सर JPEG या PNG के रूप में निर्यात होते हैं। Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए कोडेक से अलग कोडेक चुन सकता है यदि इससे फ़ाइल छोटा या अधिक उपयुक्त बनता है। पारदर्शिता वाले चित्र PNG के रूप में निर्यात होते हैं।

## **डिप्लॉयमेंट के लिए URLs का चयन**

नमूना सापेक्ष URL प्रीफ़िक्स `assets/` का उपयोग करता है। यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.jpg` लोड करता है।

फ़ाइलों को अन्य स्थान पर डिप्लॉय करते समय अलग एसेट डायरेक्टरी नाम का उपयोग करें या उत्पन्न लिंक को पुनः लिखें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो, तो `assets/` उपयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो, तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थैतिक फ़ाइल सर्वर पर अपलोड की गई हों, तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

सर्वर एप्लिकेशनों में, प्रत्येक परिवर्तन कार्य के लिए एक अनोखा आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज प्रीफ़िक्स उपयोग करें ताकि एक निर्यात दूसरे निर्यात की फ़ाइलों को ओवरराइट न कर सके।

## **एंबेड करने के बजाय कब?**

एंबेडेड Base64 HTML तब भी उपयोगी रहता है जब आउटपुट को एकल फ़ाइल के रूप में होना आवश्यक हो, जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या वह दस्तावेज़ जिसे सपोर्टिंग एसेट फ़ोल्डर के बिना स्थानांतरित किया जाएगा। लिंक्ड चित्र तब बेहतर होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा ऑप्टिमाइज़ किया जाएगा, या ब्राउज़र HTML से स्वतंत्र रूप से कैश करेगा।

## **FAQ**

**क्या मैं केवल चित्रों को बाहरी बना सकता हूँ और अन्य संसाधनों को एम्बेडेड रख सकता हूँ?**

हाँ। नमूना केवल `image/*` Base64 डेटा URL निकालता है जिनके कंटेंट टाइप `EXTENSIONS_BY_CONTENT_TYPE` में सूचीबद्ध हैं। अन्य डेटा URL एम्बेडेड ही रहते हैं।

**निर्यात किए गए चित्र का एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों होता है?**

Aspose.Slides HTML निर्यात के दौरान रैस्टर चित्रों को पुनः‑एन्कोड कर सकता है ताकि आकार या ब्राउज़र संगतता बेहतर हो। उदाहरण के लिए, स्रोत फ़ाइल का एक चित्र JPEG या PNG के रूप में लिखा जा सकता है, यह रेंडर परिणाम पर निर्भर करता है।

**HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URLs काम करेंगे?**

सापेक्ष URLs तभी काम करेंगे जब वही सापेक्ष फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में रहना चाहिए जब तक आप अलग URL प्रीफ़िक्स न बनाएं।

**क्या सर्वर एप्लिकेशन एक ही आउटपुट फ़ोल्डर का पुन: उपयोग कर सकते हैं?**

नहीं। प्रत्येक परिवर्तन कार्य के लिए एक अनोखा आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। इससे फ़ाइलनाम टकराव नहीं होते और एक निर्यात दूसरे निर्यात द्वारा उत्पन्न संसाधनों को ओवरराइट नहीं करता।
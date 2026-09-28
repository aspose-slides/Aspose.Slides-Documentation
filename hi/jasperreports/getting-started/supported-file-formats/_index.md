---
title: समर्थित फ़ाइल स्वरूप
type: docs
weight: 20
url: /hi/jasperreports/supported-file-formats/
description: "Aspose.Slides for JasperReports द्वारा इनपुट क्या लिया जाता है और किन फ़ाइल स्वरूपों में यह रिपोर्ट निर्यात करता है, देखें।"
---
## **इनपुट**

Aspose.Slides for JasperReports रिपोर्ट निर्यात करता है; यह मौजूदा प्रस्तुतियों को बदलता नहीं है। इसके एक्सपोर्टर एक भरे हुए JasperReports रिपोर्ट (`JasperPrint`) को लेते हैं, जैसे कि `JasperFillManager` का परिणाम या *.jrprint* फ़ाइल से लोड किया गया भरा हुआ रिपोर्ट।

## **आउटपुट स्वरूप**

निम्न तालिका उन स्वरूपों को सूचीबद्ध करती है, जिन्हें Aspose.Slides for JasperReports रिपोर्ट निर्यात करता है, और वह एक्सपोर्टर क्लास जो प्रत्येक को लिखता है।

|**फ़ॉर्मेट**|**विवरण**|**एक्सपोर्टर**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 प्रस्तुति; प्रत्येक रिपोर्ट पृष्ठ पर एक स्लाइड|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint प्रस्तुति (Office Open XML); प्रत्येक रिपोर्ट पृष्ठ पर एक स्लाइड|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; प्रत्येक रिपोर्ट पृष्ठ पर एक PDF पृष्ठ|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|एक एकल HTML फ़ाइल जिसमें प्रत्येक रिपोर्ट पृष्ठ पर एक SVG छवि है|`ASHtmlExporter`|

PPS और PPSX स्लाइड शो स्वरूपों के लिए कोई एक्सपोर्टर नहीं है। PPTX निर्यात को *.ppsx* फ़ाइल नाम देने पर भी यह PPTX प्रस्तुति बनाता है, स्लाइड शो नहीं। यह देखने के लिए कि प्रत्येक एक्सपोर्टर कैसे उपयोग किया जाता है, देखें [PPT, PPTX, PDF and HTML Export](/slides/hi/jasperreports/ppt-pptx-pdf-and-html-export/).
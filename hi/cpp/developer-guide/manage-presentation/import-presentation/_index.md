---
title: PDF या HTML से C++ में प्रस्तुतियों को आयात करें
linktitle: प्रस्तुति आयात करें
type: docs
weight: 60
url: /hi/cpp/import-presentation/
keywords:
- प्रस्तुति आयात
- स्लाइड आयात
- PDF आयात
- HTML आयात
- PDF से प्रस्तुति
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रस्तुति
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PDF और HTML दस्तावेज़ों को सहजता से PowerPoint और OpenDocument प्रस्तुतियों में आयात करें, जिससे सुगम और उच्च‑प्रदर्शन वाली स्लाइड प्रोसेसिंग संभव हो।"
---
## **परिचय**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/hi/cpp/) का उपयोग करके आप अन्य फ़ॉर्मेट की फ़ाइलों से प्रस्तुतियों को आयात कर सकते हैं। Aspose.Slides PDF, HTML दस्तावेज़ आदि से प्रस्तुतियों को आयात करने के लिए [SlideCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.slide_collection) क्लास प्रदान करता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप PDF को PowerPoint प्रस्तुतिकरण में परिवर्तित कर सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. प्रस्तुति क्लास का एक ऑब्जेक्ट बनाएं।  
2. [AddFromPdf()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) मेथड को कॉल करें और PDF फ़ाइल पास करें।  
3. फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजने के लिए [Save()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) मेथड का उपयोग करें।

यह C++ कोड PDF से PowerPoint ऑपरेशन को दर्शाता है:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="टिप" color="primary" %}} 

आप **Aspose मुफ्त** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप को देख सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन है। 

{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप HTML दस्तावेज़ को PowerPoint प्रस्तुतिकरण में परिवर्तित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. [AddFromHtml()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) मेथड को कॉल करें और HTML फ़ाइल पास करें।  
3. फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजने के लिए [Save()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) मेथड का उपयोग करें।

यह C++ कोड HTML से PowerPoint ऑपरेशन को दर्शाता है:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="नोट" color="warning" %}} 

आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल फ़ॉर्मेट में भी परिवर्तित कर सकते हैं: 

* [HTML to image](https://products.aspose.com/slides/hi/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hi/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hi/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hi/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF आयात करने पर तालिकाएँ संरक्षित रहती हैं, और क्या उनकी पहचान को बेहतर बनाया जा सकता है?**

आयात के दौरान तालिकाओं का पता लगाया जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/pdfimportoptions/) में मौजूद [set_DetectTables](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) मेथड तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।
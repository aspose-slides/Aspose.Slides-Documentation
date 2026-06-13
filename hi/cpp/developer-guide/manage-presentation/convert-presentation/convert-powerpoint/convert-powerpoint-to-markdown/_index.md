---
title: "C++ में PowerPoint प्रस्तुतियों को Markdown में बदलें"
linktitle: "PowerPoint को Markdown में"
type: docs
weight: 140
url: /hi/cpp/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint बदलें"
- "प्रेज़ेंटेशन बदलें"
- "स्लाइड बदलें"
- "PPT बदलें"
- "PPTX बदलें"
- "PowerPoint से MD"
- "प्रेज़ेंटेशन से MD"
- "स्लाइड से MD"
- "PPT से MD"
- "PPTX से MD"
- "PowerPoint को Markdown के रूप में सहेजें"
- "प्रेज़ेंटेशन को Markdown के रूप में सहेजें"
- "स्लाइड को Markdown के रूप में सहेजें"
- "PPT को MD के रूप में सहेजें"
- "PPTX को MD के रूप में सहेजें"
- "PPT को MD में निर्यात करें"
- "PPTX को MD में निर्यात करें"
- "PowerPoint"
- "प्रेज़ेंटेशन"
- "Markdown"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint स्लाइड्स—PPT, PPTX—को साफ़ Markdown में बदलें, दस्तावेज़ीकरण को स्वचालित करें और फॉर्मेटिंग बनाए रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में बदलने की अनुमति देता है, जो दस्तावेज़ीकरण वर्कफ़्लो, स्थैतिक साइट निर्माण, सामग्री माइग्रेशन, और संस्करण‑नियंत्रित टेक्स्ट प्रकाशन के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों को MD फ़ाइलों में सीधे निर्यात करने का समर्थन करता है और परिणामी Markdown दस्तावेज़ में स्लाइड सामग्री को कैसे प्रदर्शित किया जाए, इसे नियंत्रित करने के लिए अतिरिक्त विकल्प प्रदान करता है।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसी कई Markdown फ़्लेवर्स में से चुन सकते हैं, और निर्यात के दौरान छवियों के संचालन को कॉन्फ़िगर कर सकते हैं। उन प्रस्तुतियों के लिए जिनमें दृश्य सामग्री हो, Aspose.Slides आपको छवियों को एक अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका संदर्भ करने की भी सुविधा देता है।

{{% alert color="warning" %}} 
PowerPoint से markdown निर्यात डिफ़ॉल्ट रूप से **छवियों के बिना** होता है। यदि आप छवियों वाली PowerPoint दस्तावेज़ निर्यात करना चाहते हैं, तो आपको `SaveOptions::MarkdownExportType::Visual)` सेट करना होगा और साथ ही `BasePath` सेट करना होगा जहाँ markdown दस्तावेज़ में संदर्भित छवियों को सहेजा जाएगा।
{{% /alert %}} 

## **PowerPoint को Markdown में बदलें**

1. एक प्रस्तुति ऑब्जेक्ट का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं।
2. ऑब्जेक्ट को markdown फ़ाइल के रूप में सहेजने के लिए [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) मेथड का उपयोग करें।

यह C++ कोड दिखाता है कि PowerPoint को markdown में कैसे बदलें:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint को Markdown फ़्लेवर में बदलें**

Aspose.Slides आपको PowerPoint को markdown (बुनियादी सिंटैक्स सहित), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, और 17 अन्य markdown फ़्लेवर्स में बदलने की अनुमति देता है।

यह C++ कोड दिखाता है कि PowerPoint को CommonMark में कैसे बदलें:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 समर्थित markdown फ़्लेवर्स [Flavor enumeration के तहत सूचीबद्ध](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) हैं, जो [MarkdownSaveOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) क्लास से प्राप्त होते हैं।

## **छवियों वाली प्रस्तुति को Markdown में बदलें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) क्लास उन गुणों और एनेमरेशनों को प्रदान करती है जो आपको परिणामी markdown फ़ाइल के लिए विशिष्ट विकल्प या सेटिंग्स उपयोग करने देती हैं। उदाहरण के लिए, [MarkdownExportType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) एनीम को `Sequential`, `TextOnly`, `Visual` मानों में सेट किया जा सकता है, जो निर्धारित करता है कि छवियों को कैसे रेंडर या संभाला जाए।

### **छवियों को क्रमागत रूप से बदलें**

यदि आप चाहते हैं कि छवियां क्रमागत रूप से एक के बाद एक परिणामी markdown में दिखाई दें, तो आपको sequential विकल्प चुनना होगा। यह C++ कोड दिखाता है कि छवियों वाली प्रस्तुति को markdown में कैसे बदलें:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **छवियों को दृश्य रूप से बदलें**

यदि आप चाहते हैं कि छवियां परिणामी markdown में साथ‑साथ दिखाई दें, तो आपको visual विकल्प चुनना होगा। इस स्थिति में, छवियां एप्लिकेशन की वर्तमान डायरेक्टरी में सहेजी जाएंगी (और markdown दस्तावेज़ में उनके लिए एक सापेक्ष पथ बनाया जाएगा), या आप अपना इच्छित पथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

यह C++ कोड संचालन को दर्शाता है:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक्स Markdown में निर्यात होने पर भी बनाए रहते हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/cpp/manage-hyperlinks/) को मानक Markdown लिंक के रूप में रखा जाता है। स्लाइड [transitions](/slides/hi/cpp/slide-transition/) और [animations](/slides/hi/cpp/powerpoint-animation/) को परिवर्तित नहीं किया जाता है।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**

आप फ़ाइलों के बीच समानांतरता कर सकते हैं, लेकिन थ्रेड्स के बीच वही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) instance को [don’t share](/slides/hi/cpp/multithreading/) नहीं करना चाहिए। प्रत्येक फ़ाइल के लिए अलग-अलग instances/processes का उपयोग करें ताकि संघर्ष से बचा जा सके।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और क्या पथ सापेक्ष (relative) हैं?**

[Images](/slides/hi/cpp/image/) एक समर्पित फ़ोल्डर में निर्यात की जाती हैं, और Markdown फ़ाइल उनके संदर्भ को डिफ़ॉल्ट रूप से सापेक्ष पथों के साथ रखती है। आप बेस आउटपुट पथ और एसेट फ़ोल्डर का नाम कॉन्फ़िगर कर सकते हैं ताकि एक पूर्वानुमानित रिपोजिटरी संरचना बनी रहे।
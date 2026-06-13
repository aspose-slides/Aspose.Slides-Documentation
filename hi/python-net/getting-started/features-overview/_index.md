---
title: "विशेषताओं का अवलोकन"
type: docs
weight: 20
url: /hi/python-net/features-overview/
keywords:
- विशेषताएँ
- समर्थित प्लेटफ़ॉर्म
- फ़ाइल स्वरूप
- रूपांतरण
- रेंडरिंग
- प्रिंटिंग
- फ़ॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET को खोजें: PowerPoint और OpenDocument प्रस्तुतियों को कुशलतापूर्वक बनाने, संपादित करने, स्वचालित करने और रूपांतरित करने के लिए एक शक्तिशाली API."
---
## **समर्थित प्लेटफ़ॉर्म**
Aspose.Slides for Python via .NET को Windows x64 या x86 तथा विविध Linux वितरणों पर Python 3.5 या बाद का संस्करण स्थापित होने पर उपयोग किया जा सकता है। लक्ष्य Linux प्लेटफ़ॉर्म के लिए अतिरिक्त आवश्यकताएँ हैं:
- GCC-6 रनटाइम लाइब्रेरी (या बाद की)
- .NET Core Runtime की निर्भरताएँ। .NET Core Runtime स्वयं को स्थापित करना आवश्यक नहीं है
- Python 3.5‑3.7 के लिए: `pymalloc` बिल्ड की आवश्यकता है। `--with-pymalloc` Python बिल्ड विकल्प डिफ़ॉल्ट रूप से सक्षम है। आमतौर पर, `pymalloc` बिल्ड वाली Python फ़ाइलनाम में `m` प्रत्यय दिखता है।
- `libpython` साझा Python लाइब्रेरी। `--enable-shared` Python बिल्ड विकल्प डिफ़ॉल्ट रूप से अक्षम है, इसलिए कुछ Python वितरणों में `libpython` साझा लाइब्रेरी नहीं होती। कुछ Linux प्लेटफ़ॉर्म पर `libpython` साझा लाइब्ररी को पैकेज प्रबंधक से स्थापित किया जा सकता है, उदाहरण के लिए: `sudo apt-get install libpython3.7`। आम समस्या यह है कि `libpython` लाइब्रेरी मानक प्रणाली स्थान के बजाय किसी अन्य स्थान पर स्थापित होती है। इसे Python बिल्ड विकल्पों के माध्यम से वैकल्पिक लाइब्रेरी पथ निर्धारित करके या सिस्टम के मानक स्थान पर `libpython` फ़ाइल के लिए प्रतीकात्मक लिंक बनाकर ठीक किया जा सकता है। सामान्यतः, `libpython` साझा लाइब्रेरी फ़ाइलनाम Python 3.5‑3.7 के लिए `libpythonX.Ym.so.1.0` तथा Python 3.8 या बाद के लिए `libpythonX.Y.so.1.0` होता है (उदाहरण: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`)।

यदि आपको अधिक प्लेटफ़ॉर्म के लिए समर्थन चाहिए, तो “twin brother” उत्पाद Aspose.Slides for .NET या Aspose.Slides for Java देखें।

## **फ़ाइल स्वरूप और रूपांतरण**
Aspose.Slides for Python via .NET अधिकांश PowerPoint दस्तावेज़ स्वरूपों का समर्थन करता है। यह आपको उन फ़ाइलों को उन लोकप्रिय स्वरूपों में निर्यात करने की सुविधा भी देता है जो संस्थाएँ व्यापक रूप से उपयोग और साझा करती हैं। विवरण देखें:

|**फ़ीचर**|**विवरण**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/hi/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET इस प्रस्तुति दस्तावेज़ स्वरूप के लिए सबसे तेज़ प्रोसेसिंग प्रदान करता है।|
|[PPT to PPTX conversion](/slides/hi/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET PPT को PPTX में रूपांतरण का समर्थन करता है।|
|[Portable Document Format (PDF)](/slides/hi/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|आप सभी समर्थित फ़ाइल स्वरूपों को एक ही मेथड से Adobe Portable Document Format (PDF) दस्तावेज़ों में निर्यात कर सकते हैं।|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/hi/python-net/convert-powerpoint-to-xps/)|आप सभी समर्थित फ़ाइल स्वरूपों को एक ही मेथड से XML Parser Specification (XPS) दस्तावेज़ों में निर्यात कर सकते हैं।|
|[Tagged Image File Format (TIFF)](/slides/hi/python-net/convert-powerpoint-to-tiff/)|आप सभी समर्थित प्रस्तुति फ़ाइल स्वरूपों को Tagged Image File Format (TIFF) में निर्यात कर सकते हैं।|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/hi/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET PresentationEx को HTML स्वरूप में रूपांतरण का समर्थन करता है।|

## **रेंडरिंग और प्रिंटिंग**
Aspose.Slides for Python via .NET प्रस्तुति दस्तावेज़ों की स्लाइड्स को विभिन्न ग्राफ़िक स्वरूपों में उच्च फ़िडेलिटी रेंडर करने का समर्थन करता है। विवरण देखें:

|**फ़ीचर**|**विवरण**|
| :- | :- |
|.NET Supported Image Formats|Aspose.Slides for Python via .NET के साथ आप प्रस्तुति स्लाइड्स और स्लाइड्स पर छवियों को सभी .NET समर्थित ग्राफ़िक स्वरूपों जैसे TIFF, PNG, BMP, JPEG, GIF और मेटा‑फ़ाइलों में रेंडर कर सकते हैं।|
|SVG Format|Aspose.Slides for Python via .NET बिल्ट‑इन मेथड्स प्रदान करता है जो प्रस्तुति स्लाइड्स को Scalable Vector Graphics (SVG) स्वरूप में निर्यात करने की अनुमति देते हैं।|
|Presentation Printing|Aspose.Slides for Python via .NET के नवीनतम संस्करण विभिन्न विकल्पों के साथ बिल्ट‑इन प्रिंट मेथड्स प्रदान करते हैं।|

## **सामग्री सुविधाएँ**
Aspose.Slides for Python via .NET आपको प्रस्तुति दस्तावेज़ों के लगभग सभी आइटम या सामग्री तक पहुंच, संशोधन या निर्माण करने की अनुमति देता है। विवरण देखें:

|**फ़ीचर**|**विवरण**|
| :- | :- |
|Master Slides|मास्टर स्लाइड्स सामान्य स्लाइड्स की लेआउट निर्धारित करती हैं। Aspose.Slides for Python via .NET आपको प्रस्तुति दस्तावेज़ों की मास्टर स्लाइड्स तक पहुंचने और उन्हें संशोधित करने की सुविधा देता है।|
|Normal Slides|Aspose.Slides for Python via .NET के साथ आप विभिन्न प्रकार की नई स्लाइड्स बना सकते हैं; आप प्रस्तुति में मौजूदा स्लाइड्स तक भी पहुंच और संशोधन कर सकते हैं।|
|Cloning / Copying Slides|Aspose.Slides for Python via .NET द्वारा प्रदान किए गए बिल्ट‑इन मेथड्स आपको प्रस्तुति के भीतर मौजूदा स्लाइड्स को क्लोन या कॉपी करने की अनुमति देते हैं। आप एक प्रस्तुति से दूसरी में कॉपी या क्लोन की गई स्लाइड्स का उपयोग भी कर सकते हैं। क्योंकि एक स्लाइड अपना लेआउट मास्टर स्लाइड से विरासत में पाती है, क्लोनिंग के दौरान बिल्ट‑इन मेथड्स स्वचालित रूप से मास्टर को भी कॉपी करते हैं।|
|Managing Slides sections|प्रस्तुति के भीतर विभिन्न सेक्शन में स्लाइड्स को व्यवस्थित करने के मेथड्स।|
|Place Holders and Text Holders|आप स्लाइड में प्लेस‑होल्डर्स और टेक्स्ट‑होल्डर्स तक पहुंच सकते हैं। Moreover, आप उपयुक्त मेथड का उपयोग करके शून्य से टेक्स्ट‑होल्डर्स वाली स्लाइड बना सकते हैं।|
|Header and Footers|Aspose.Slides for Python via .NET स्लाइड्स में हेडर/फ़ुटर के प्रबंधन को सुविधाजनक बनाता है।|
|Notes in Slides|Aspose.Slides for Python via .NET के साथ आप स्लाइड से जुड़ी नोट्स तक पहुंच और उन्हें संशोधित कर सकते हैं तथा नई नोट्स जोड़ सकते हैं।|
|Finding a Shape|आप स्लाइड में किसी विशेष आकार को उस आकार के वैकल्पिक पाठ (alternative text) के आधार पर भी खोज सकते हैं।|
|Backgrounds|Aspose.Slides for Python via .NET आपको मास्टर या सामान्य स्लाइड से जुड़े बैकग्राउंड के साथ काम करने देता है।|
|Text Boxes|टेक्स्ट बॉक्स शून्य से बनाये जा सकते हैं। आप मौजूदा टेक्स्ट बॉक्स तक पहुंच सकते हैं। आप उनके पाठ को मूल फ़ॉर्मेट खोए बिना संशोधित भी कर सकते हैं।|
|Rectangle Shapes|Aspose.Slides for Python via .NET के साथ आप आयताकार आकार बना या संशोधित कर सकते हैं।|
|Poly Line Shapes|Aspose.Slides for Python via .NET के साथ आप बहु‑रेखा आकार बना या संशोधित कर सकते हैं।|
|Ellipse Shapes|Aspose.Slides for Python via .NET के साथ आप दीर्घवृत्त आकार बना या संशोधित कर सकते हैं।|
|Group Shapes|Aspose.Slides for Python via .NET ग्रुप शैप्स का समर्थन करता है।|
|Auto Shapes|Aspose.Slides for Python via .NET ऑटो शैप्स का समर्थन करता है।|
|SmartArt|Aspose.Slides for Python via .NET MS PowerPoint में SmartArt शैप्स का समर्थन प्रदान करता है।|
|Charts|Aspose.Slides for Python via .NET PowerPoint में MSO चार्ट्स का समर्थन प्रदान करता है।|
|Shapes Serialization|Aspose.Slides for Python via .NET बड़ी संख्या में शैप्स का समर्थन करता है। जब कोई शैप समर्थित नहीं है, तो आप सीरियलाइज़ेशन मेथड का उपयोग करके उस शैप को मौजूदा स्लाइड से सीरियलाइज़ कर सकते हैं और आगे अपनी आवश्यकता अनुसार उपयोग कर सकते हैं।|
|Picture Frames|Aspose.Slides for Python via .NET के साथ आप पिक्चर फ्रेम में चित्रों का प्रबंधन कर सकते हैं।|
|Audio Frames|Aspose.Slides for Python via .NET के साथ आप ऑडियो फ्रेम में ऑडियो फ़ाइलों को लिंक या एम्बेड कर सकते हैं।|
|Video Frames|आप वीडियो फ्रेम में वीडियो फ़ाइलों को संभाल सकते हैं। Aspose.Slides for Python via .NET लिंक्ड और एम्बेडेड दोनों प्रकार के वीडियो का समर्थन भी प्रदान करता है।|
|OLE Frame|Aspose.Slides for Python via .NET के साथ आप OLE फ्रेम में OLE ऑब्जेक्ट्स का प्रबंधन कर सकते हैं।|
|Tables|Aspose.Slides for Python via .NET स्लाइड्स में टेबल्स का समर्थन करता है।|
|ActiveX Controls|ActiveX कंट्रोल्स का समर्थन।|
|VBA Macros|प्रस्तुति में VBA मैक्रोज़ के प्रबंधन का समर्थन।|
|Text Frame|आप किसी भी शैप के टेक्स्ट फ्रेम के माध्यम से उस शैप के टेक्स्ट तक पहुंच सकते हैं।|
|Text Scanning|आप बिल्ट‑इन स्कैनिंग मेथड्स के माध्यम से प्रस्तुति या स्लाइड स्तर पर टेक्स्ट स्कैन कर सकते हैं।|
|Animations|आप शैप्स पर एनीमेशन लागू कर सकते हैं।|
|Slide Shows|Aspose.Slides for Python via .NET स्लाइड शो और स्लाइड ट्रांज़िशन का समर्थन करता है।|

## **फ़ॉर्मेटिंग सुविधाएँ**
Aspose.Slides for Python via .NET के साथ आप प्रस्तुति में स्लाइड्स पर टेक्स्ट और शैप्स को फ़ॉर्मेट कर सकते हैं। विवरण देखें:

|**फ़ीचर**|**विवरण**|
| :- | :- |
|Text Formatting|<p>Aspose.Slides for Python via .NET में आप शैप्स से जुड़े टेक्स्ट फ्रेम के माध्यम से टेक्स्ट का प्रबंधन कर सकते हैं। इस प्रकार आप पैराग्राफ और टेक्स्ट फ्रेम से जुड़े भागों का उपयोग करके टेक्स्ट को फ़ॉर्मेट कर सकते हैं। इन टेक्स्ट तत्वों को Aspose.Slides for Python via .NET द्वारा फ़ॉर्मेट किया जा सकता है।</p><p>- फ़ॉन्ट प्रकार</p><p>- फ़ॉन्ट आकार</p><p>- फ़ॉन्ट रंग</p><p>- फ़ॉन्ट शेड्स</p><p>- पैराग्राफ संरेखण</p><p>- पैराग्राफ बुलेटिंग</p><p>- पैराग्राफ अभिविन्यास</p>|
|Shape Formatting|<p>Aspose.Slides for Python via .NET में स्लाइड का मूल तत्व शैप है। आप इन शैप तत्वों को निम्नलिखित गुणों के साथ फ़ॉर्मेट कर सकते हैं:</p><p>- स्थिति</p><p>- आकार</p><p>- रेखा</p><p>- भराव (Pattern, Gradient, Solid सहित)</p><p>- टेक्स्ट</p><p>- इमेज</p>|

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लाइब्रेरी के काम करने के लिये सर्वर/PC पर Microsoft PowerPoint स्थापित करना आवश्यक है?**

नहीं। PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्टैंड‑अलोन इंजन है जो प्रस्तुतियों को बनाने, संपादित करने, रूपांतरित करने और रेंडर करने के लिए प्रयोग किया जाता है।

**멀्टिथ्रेडिंग कैसे काम करती है? क्या प्रोसेसिंग को समानांतर किया जा सकता है?**

विभिन्न थ्रेड्स में विभिन्न दस्तावेज़ों को प्रोसेस करना सुरक्षित है; वही [presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट कई थ्रेड्स (/slides/hi/python-net/multithreading/) द्वारा एक साथ उपयोग नहीं किया जाना चाहिए।

**क्या फ़ाइल पासवर्ड और एन्क्रिप्शन समर्थित हैं?**

हां। आप एन्क्रिप्टेड प्रस्तुतियों को खोल सकते हैं, खोलने और लिखने के पासवर्ड सेट या हटाए जा सकते हैं, और सुरक्षा स्थिति की जाँच कर सकते हैं। ([आप कर सकते हैं](/slides/hi/python-net/password-protected-presentation/))

**क्या Linux कंटेनरों में फ़ॉन्ट पैकेजों की चिंता करनी चाहिए?**

हां। अप्रत्याशित फ़ॉन्ट प्रतिस्थापन से बचने हेतु सामान्य फ़ॉन्ट पैकेज स्थापित करना और/या अपने अनुप्रयोग में स्पष्ट रूप से [फ़ॉन्ट डायरेक्टरी निर्दिष्ट](/slides/hi/python-net/custom-font/) करना अनुशंसित है।

**क्या एवालुएशन संस्करण में कोई प्रतिबंध हैं?**

[एवालुएशन मोड](/slides/hi/python-net/licensing/) में आउटपुट पर वॉटरमार्क जोड़ा जाता है और कुछ प्रतिबंध लागू होते हैं; पूर्ण‑फ़ीचर परीक्षण के लिये एक [30‑दिन का टेम्पररी लाइसेंस](https://purchase.aspose.com/temporary-license/) उपलब्ध है।

**क्या प्रस्तुति में बाहरी स्वरूप (PDF/HTML → PPTX) आयात करना समर्थित है?**

हां। आप [PDF पेज और HTML सामग्री](/slides/hi/python-net/import-presentation/) को प्रस्तुति में जोड़ सकते हैं, जिससे वे स्लाइड्स में परिवर्तित हो जाते हैं।
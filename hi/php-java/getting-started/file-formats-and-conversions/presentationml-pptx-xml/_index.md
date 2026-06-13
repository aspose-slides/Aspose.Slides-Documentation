---
title: प्रेज़ेंटेशनएमएल (PPTX, XML)
type: docs
weight: 20
url: /hi/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML नाम XML‑आधारित प्रारूपों के एक परिवार के लिए उपयोग किया जाता है। Office OpenXML (OOXML) वह XML‑आधारित प्रारूप है जिसे Microsoft Office 2007 अनुप्रयोगों में पेश किया गया था। Office OpenXML कई विशिष्ट XML‑आधारित मार्कअप भाषाओं के लिए एक कंटेनर प्रारूप है। PresentationML वह मार्कअप भाषा है जिसका उपयोग Microsoft Office PowerPoint 2007 दस्तावेज़ों को संग्रहीत करने के लिए करता है।

{{% /alert %}} 

## **PHP के लिए Aspose.Slides via Java में PresentationML**
OOXML PresentationML दस्तावेज़ PPTX फ़ाइलों के रूप में आते हैं, जो XML पैकेजों के ज़िप्ड स्वरूप होते हैं और [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) विनिर्देशन का पालन करते हैं। Aspose.Slides for PHP via Java व्यापक रूप से PresentationML दस्तावेज़ों का निर्माण, पढ़ना, संशोधन और लेखन समर्थन करता है। इसके अतिरिक्त, Aspose.Slides for PHP via Java PresentationML दस्तावेज़ों को व्यापक रूप से प्रयुक्त दस्तावेज़ स्वरूप जैसे PDF में निर्यात करने में सक्षम है। यह इसलिए संभव है क्योंकि Aspose.Slides for PHP via Java को प्रस्तुतीकरण दस्तावेज़ों को समग्र रूप से संभालने के उद्देश्य से डिज़ाइन किया गया है और PresentationML मूल रूप से दस्तावेज़ों की आंतरिक प्रस्तुति को ज़िप्ड XML पैकेज के रूप में रखता है।

**Aspose.Slides for PHP via Java द्वारा उत्पन्न PPTX दस्तावेज़ और Microsoft PowerPoint में खोला गया**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for PHP via Java द्वारा उत्पन्न समान PPTX दस्तावेज़ को ZIP में देखना**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML खुला है, फिर भी PHP के लिए Aspose.Slides via Java का उपयोग क्यों करें?**
चूँकि PresentationML XML‑आधारित है, XML वर्गों का उपयोग करके PresentationML दस्तावेज़ों को प्रोसेस और जनरेट करने के लिए अनुप्रयोग बनाना संभव है, बिना Aspose.Slides for PHP via Java जैसे तृतीय‑पक्ष लाइब्रेरी पर निर्भर हुए। हालांकि, PresentationML दस्तावेज़ों के साथ काम करते समय XML वर्गों की तुलना में Aspose.Slides for PHP via Java का उपयोग करने के कई लाभ हैं।

OOXML विनिर्देशन कई हजार पृष्ठ लंबा है, इसलिए PresentationML दस्तावेज़ों को सही ढंग से संभालने के लिए आपको प्रारूप को समझने में बहुत समय और प्रयास निवेश करना पड़ता है। दूसरी ओर, Aspose.Slides for PHP via Java के साथ आप केवल वर्गों और उनके मेथड व प्रॉपर्टी का उपयोग करके उन ऑपरेशनों को कर सकते हैं जो XML वर्गों द्वारा किए जाने पर जटिल लगते हैं।

Aspose.Slides द्वारा प्रदान की गई कुछ सुविधाएँ XML वर्गों से PresentationML दस्तावेज़ों को संभालते समय उपलब्ध ही नहीं हैं:

- PPT दस्तावेज़ों को PDF स्वरूप में निर्यात करना।
- स्लाइड को Java फ़्रेमवर्क द्वारा समर्थित किसी भी छवि स्वरूप में रेंडर करना।
- क्लोनिंग सुविधा का उपयोग करके स्रोत प्रस्तुति से मास्टर स्वचालित रूप से कॉपी करना।
- आकारों (shapes) पर सुरक्षा लागू करना।

नीचे एक PresentationML दस्तावेज़ का उदाहरण दिया गया है जिसमें एक स्लाइड है जिसमें “Hello World” पाठ वाला एक टेक्स्ट बॉक्स है। XML वर्गों का उपयोग करके इस पाठ को पढ़ने के लिए आपको एक प्रोग्राम लिखना होगा जो निम्नलिखित अंश से इस सरल पाठ को पार्स कर सके। Aspose.Slides यह काम आपके लिए करता है।

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```php
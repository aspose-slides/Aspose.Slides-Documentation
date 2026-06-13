---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hi/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML प्रस्तुति दस्तावेज़ों के लिए XML‑आधारित फ़ॉर्मैटों के परिवार का नाम है। Office OpenXML (OOXML) वह XML‑आधारित फ़ॉर्मैट है जिसे Microsoft Office 2007 अनुप्रयोगों ने पेश किया था। Office OpenXML कई विशिष्ट XML‑आधारित मार्कअप भाषाओं के लिए एक कंटेनर फ़ॉर्मैट है। PresentationML वह मार्कअप भाषा है जिसे Microsoft Office PowerPoint 2007 दस्तावेजों को संग्रहीत करने के लिए उपयोग करता है।

{{% /alert %}} 

## **PresentationML in Aspose.Slides for Java**
OOXML PresentationML दस्तावेज़ PPTX फ़ाइलों के रूप में आते हैं, जो ज़िप किए हुए XML पैकेज होते हैं जो [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) विनिर्देश का पालन करते हैं। Aspose.Slides for Java व्यापक रूप से PresentationML दस्तावेज़ों को बनाने, पढ़ने, संशोधित करने और लिखने का समर्थन करता है। अतिरिक्त रूप से, Aspose.Slides for Java PresentationML दस्तावेज़ों को व्यापक रूप से उपयोग किए जाने वाले दस्तावेज़ फ़ॉर्मेट जैसे PDF में निर्यात करने में सक्षम है। यह संभव है क्योंकि Aspose.Slides for Java को प्रस्तुति दस्तावेज़ों को समग्र रूप से संभालने के उद्देश्य से डिजाइन किया गया है और PresentationML मूल रूप से दस्तावेज़ों की आंतरिक प्रस्तुति को ज़िप किए हुए XML पैकेज के रूप में रखती है।

**Aspose.Slides for Java द्वारा उत्पन्न एक PPTX दस्तावेज़ और इसे Microsoft PowerPoint में खोला गया** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for Java द्वारा उत्पन्न उसी PPTX दस्तावेज़ को ZIP में देखना** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML खुला है, तो Aspose.Slides for Java क्यों उपयोग करें?**
चूँकि PresentationML XML‑आधारित है, इसलिए XML क्लासों का उपयोग करके किसी थर्ड‑पार्टी लाइब्रेरी जैसे Aspose.Slides for Java पर निर्भर हुए बिना PresentationML दस्तावेज़ों को प्रोसेस और जनरेट करने के लिए एप्लिकेशन बनाना संभव है। हालांकि, PresentationML दस्तावेज़ों के साथ काम करते समय XML क्लासों की तुलना में Aspose.Slides for Java उपयोग करने के कई फायदे हैं।

OOXML विनिर्देश कई हजार पृष्ठों का है, इसलिए PresentationML दस्तावेज़ों को सही ढंग से संभालने के लिए आपको फॉर्मेट को समझने में बहुत समय और प्रयास लगाना पड़ता है। दूसरी ओर, Aspose.Slides for Java के साथ आप केवल क्लास और उनके मेथड एवं प्रॉपर्टी का उपयोग करके उन ऑपरेशनों को कर सकते हैं जो XML क्लासों से करना जटिल हो सकता है।

कुछ सुविधाएँ जो Aspose.Slides प्रदान करता है, XML क्लासों के माध्यम से PresentationML दस्तावेज़ों के साथ काम करते समय उपलब्ध ही नहीं हैं:

- PPT दस्तावेज़ों को PDF फ़ॉर्मेट में निर्यात करना।
- स्लाइड को Java फ़्रेमवर्क द्वारा समर्थित किसी भी इमेज फ़ॉर्मेट में रेंडर करना।
- क्लोनिंग सुविधा का उपयोग करके स्रोत प्रस्तुति से मास्टर को स्वचालित रूप से कॉपी करना।
- शैलियों पर सुरक्षा लागू करना।

नीचे एक PresentationML दस्तावेज़ का उदाहरण दिया गया है जिसमें एक स्लाइड है जिसमें "Hello World" टेक्स्ट वाला टेक्स्ट बॉक्स है। XML क्लासों का उपयोग करके टेक्स्ट पढ़ने के लिए आपको इस सरल टेक्स्ट को निम्नलिखित फ्रैगमेंट से पार्स करने वाला प्रोग्राम लिखना पड़ेगा। Aspose.Slides यह आपके लिए कर देता है।

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
```
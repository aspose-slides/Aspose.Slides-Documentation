---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hi/java/presentationml-pptx-xml/
---

{{% alert color="info" %}} 
PresentationML प्रस्तुति दस्तावेज़ों के लिए XML‑आधारित फ़ॉर्मेट के परिवार का नाम है। Office OpenXML (OOXML) वह XML‑आधारित फ़ॉर्मेट है जो Microsoft Office 2007 अनुप्रयोगों में पेश किया गया था। Office OpenXML कई विशिष्ट XML‑आधारित मार्कअप भाषाओं के लिए एक कंटेनर फ़ॉर्मेट है। PresentationML वह मार्कअप भाषा है जिसका उपयोग Microsoft Office PowerPoint 2007 द्वारा दस्तावेज़ों को संग्रहीत करने के लिए किया जाता है।
{{% /alert %}} 

## **Aspose.Slides for Java में PresentationML**

OOXML PresentationML दस्तावेज़ PPTX फ़ाइलों के रूप में आते हैं, जो संपीड़ित XML पैकेज होते हैं जो [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) विशिष्टता का पालन करते हैं। Aspose.Slides for Java व्यापक रूप से PresentationML दस्तावेज़ों को बनाने, पढ़ने, हेर‑फेर करने और लिखने का समर्थन करता है। इसके अतिरिक्त, Aspose.Slides for Java PresentationML दस्तावेज़ों को PDF जैसे व्यापक रूप से उपयोग किए जाने वाले दस्तावेज़ फ़ॉर्मेट में निर्यात करने में सक्षम है। यह संभव है क्योंकि Aspose.Slides for Java को प्रस्तुति दस्तावेज़ों को व्यापक रूप से संभालने के उद्देश्य से डिज़ाइन किया गया था और PresentationML मूल रूप से दस्तावेज़ों की आंतरिक प्रस्तुति को संपीड़ित XML पैकेज के रूप में रखता है।

**Aspose.Slides for Java द्वारा उत्पन्न एक PPTX दस्तावेज़ और Microsoft PowerPoint में खोला गया** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)

**Aspose.Slides for Java द्वारा उत्पन्न वही PPTX दस्तावेज़ को ZIP में देखना** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)

## **PresentationML ओपन है, Aspose.Slides for Java का उपयोग क्यों करें?**

चूँकि PresentationML XML‑आधारित है, XML वर्गों का उपयोग करके PresentationML दस्तावेज़ों को प्रोसेस और जेनरेट करने वाले अनुप्रयोग बनाना संभव है, बिना Aspose.Slides for Java जैसे तृतीय‑पक्ष क्लास लाइब्रेरी पर निर्भर हुए। हालांकि, PresentationML दस्तावेज़ों के साथ काम करते समय XML वर्गों की तुलना में Aspose.Slides for Java का उपयोग करने के कई लाभ हैं।

OOXML विशेषता कई हजार पृष्ठों की है, इसलिए PresentationML दस्तावेज़ों को सही ढंग से संभालने के लिए आपको फ़ॉर्मेट को समझने में बहुत समय और प्रयास लगाना पड़ता है। दूसरी ओर, Aspose.Slides for Java के साथ, आप केवल क्लासों और उनके मेथड्स तथा प्रॉपर्टीज़ का उपयोग करके उन ऑपरेशनों को कर सकते हैं जो XML वर्गों के माध्यम से करने पर जटिल लगते हैं।

Aspose.Slides द्वारा प्राप्त कुछ सुविधाएँ तब भी उपलब्ध नहीं हैं जब आप PresentationML दस्तावेज़ों को XML वर्गों के माध्यम से काम करते हैं:

- PPT दस्तावेज़ों को PDF फ़ॉर्मेट में निर्यात करें।
- Java फ्रेमवर्क द्वारा समर्थित किसी भी इमेज फ़ॉर्मेट में स्लाइड को रेंडर करें।
- क्लोनिंग सुविधा का उपयोग करके स्रोत प्रस्तुतियों से मास्टर को स्वचालित रूप से कॉपी करें।
- शेप्स पर संरक्षण लागू करें।

नीचे एक PresentationML दस्तावेज़ का उदाहरण है जिसमें एक एकल स्लाइड है जिसमें “Hello World” पाठ वाला टेक्स्ट बॉक्स है। XML वर्गों का उपयोग करके पाठ पढ़ने के लिए, आपको एक प्रोग्राम लिखना पड़ेगा जो निम्नलिखित भाग से इस सरल पाठ को पार्स कर सके। Aspose.Slides यह आपके लिए करता है।

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
---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hi/cpp/presentationml-pptx-xml/
---
## **PresentationML के बारे में**
PresentationML एक नाम है जो प्रस्तुति दस्तावेज़ों के लिए XML-आधारित फ़ॉर्मैट परिवार को दर्शाता है। Office OpenXML (OOXML) Microsoft Office 2007 एप्लिकेशन में पेश किया गया XML-आधारित फ़ॉर्मैट है। Office OpenXML कई विशिष्ट XML-आधारित मार्कअप भाषाओं के लिए कंटेनर फ़ॉर्मैट है। PresentationML वह मार्कअप भाषा है जिसे Microsoft Office PowerPoint 2007 अपने दस्तावेज़ों को संग्रहीत करने के लिए उपयोग करता है। 
## **Aspose.Slides for C++ में PresentationML**
OOXML PresentationML दस्तावेज़ PPTX फ़ाइलों के रूप में आते हैं जो [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) विशिष्टताओं का पालन करने वाले ज़िप्ड XML पैकेज होते हैं। Aspose.Slides for C++ PresentationML दस्तावेज़ों को बनाने, पढ़ने, बदलने और लिखने में व्यापक समर्थन प्रदान करता है। अतिरिक्त रूप से, Aspose.Slides for C++ PresentationML दस्तावेज़ों को PDF, TIFF और XPS जैसी विभिन्न व्यापक रूप से उपयोग किए जाने वाले दस्तावेज़ फ़ॉर्मैट में निर्यात करने में सक्षम है। यह संभव है क्योंकि Aspose.Slides for C++ को प्रस्तुति दस्तावेज़ों को व्यापक रूप से संभालने के लक्ष्य से डिज़ाइन किया गया था और PresentationML मूल रूप से दस्तावेज़ों की आंतरिक प्रस्तुति को ज़िप्ड XML पैकेज के रूप में रखता है। 

## **PresentationML ओपन है, क्यों उपयोग करें Aspose.Slides for C++**
चूंकि PresentationML XML‑आधारित है, इसलिए XML क्लासों का उपयोग करके PresentationML दस्तावेज़ों को प्रोसेस करने और बनाने के लिए एप्लिकेशन बनाना संभव है, बिना Aspose.Slides for C++ जैसी थर्ड‑पार्टी क्लास लाइब्रेरी पर निर्भर हुए। हालांकि, PresentationML दस्तावेज़ों के साथ काम करते समय XML क्लासों की तुलना में Aspose.Slides for C++ का उपयोग करने के कई लाभ हैं। 

OOXML विशिष्टता कई हजार पन्नों की है। इसका मतलब है कि PresentationML दस्तावेज़ों को उचित रूप से संभालने के लिए आपको इस फ़ॉर्मैट को समझने में काफी समय और प्रयास लगाना पड़ेगा। दूसरी ओर, Aspose.Slides for C++ का उपयोग करते हुए, आपको केवल संबंधित क्लासों और उनके उचित मेथड / प्रॉपर्टी को उपयोग करना है जो XML क्लासों के माध्यम से करने पर काफी जटिल लग सकते हैं। 

निम्नलिखित कुछ विशेषताएँ हैं जो XML क्लासों के माध्यम से PresentationML दस्तावेज़ों को संभालते समय उपलब्ध नहीं हैं: 

- PPT दस्तावेज़ों को PDF, TIFF, XPS फ़ॉर्मैट में निर्यात करना
- PPT दस्तावेज़ों में स्लाइड्स को SVG फ़ॉर्मैट में निर्यात करना
- स्लाइड को C++ फ्रेमवर्क द्वारा समर्थित किसी भी इमेज फ़ॉर्मैट में रेंडर करना
- क्लोनिंग फीचर का उपयोग करके स्रोत प्रस्तुतियों से मास्टर को स्वचालित रूप से कॉपी करना
- शेप्स पर प्रोटेक्शन लागू करना

आइए एक उदाहरण लेते हैं जिसमें एकल स्लाइड वाला PresentationML दस्तावेज़ है, जिसमें एक टेक्स्ट बॉक्स में “Hello World” पाठ है। XML क्लासों के माध्यम से टेक्स्ट पढ़ने के लिए, आपको एक प्रोग्राम लिखना होगा जो निम्नलिखित फ्रैगमेंट से इस सरल पाठ को पार्स कर सके: 
## **उदाहरण**


``` cpp

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
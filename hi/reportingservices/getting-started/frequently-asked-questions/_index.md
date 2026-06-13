---
title: अक्सर पूछे जाने वाले प्रश्न
type: docs
weight: 110
url: /hi/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

यह पृष्ठ निम्नलिखित के बारे में अक्सर पूछे जाने वाले प्रश्नों को एकत्र करता है:

- [समर्थित फ़ाइल फ़ॉर्मेट](#Supported-File-Formats).
- [Power BI रिपोर्टिंग सेवाओं के लिए समर्थन](#Support-for-Power-BI-Reporting-services).
- [स्थापना](#Installation).
- [निर्यात कॉन्फ़िगरेशन](#Export-Configuration).

{{% /alert %}} 
### **समर्थित फ़ाइल फ़ॉर्मेट**
#### **Q: Aspose.Slides for Reporting Services का उपयोग करके आप किस फ़ॉर्मेट में रिपोर्ट निर्यात कर सकते हैं?**
**A**: Aspose.Slides for Reporting Services किसी भी रिपोर्ट को PPT, PPS, PPTX, PPSX, XPS या RPL फ़ॉर्मेट में निर्यात करने की सुविधा प्रदान करता है।
### **Power BI रिपोर्टिंग सेवाओं के लिए समर्थन**
#### **Q: क्या Aspose.Slides for Reporting Services Power BI को सपोर्ट करता है?**
**A**: हां। Aspose.Slides for Reporting Services Power BI में पृष्ठांकित रिपोर्ट (RDL) को निर्यात करने का समर्थन करता है।
### **स्थापना**
#### **Q: इंस्टॉलेशन प्रोग्राम शुरू नहीं होता है। मैनुअल इंस्टॉलेशन वांछित परिणाम नहीं देता है।**
**A** : .NET Framework 3.5 आपके सिस्टम पर स्थापित है, यह सुनिश्चित करें।
#### **Q: Aspose.Slides for Reporting Services की इंस्टॉलेशन के बाद निर्यात विकल्प नहीं दिख रहे हैं।**
**A**: यदि rssrvpolicy.config में कोई CodeGroup सही ढंग से काम नहीं करता है, तो कॉन्फ़िगरेशन फ़ाइल पार्सर समूह के अंतिम अनुभागों को छोड़ सकता है। इसलिए Aspose.Slides for Reporting Services से जुड़े सभी CodeGroups को उस ब्लॉक के शीर्ष पर ले जाएँ जिसमें Aspose.Slides for Reporting Services CodeGroups हैं।
#### **Q: फ़ाइल या असेंबली Aspose.Slides.ReportingServices लोड नहीं हो सका (एक्जीक्यूशन अनुमति प्राप्त नहीं की जा सकी \ Exception from HRESULT: 0x80131418).**
**A**: त्रुटि कोड (0x80131418) दर्शाता है कि dll मॉड्यूल के पास पर्याप्त अधिकार नहीं हैं। यह किसी सुरक्षा सुविधा के कारण हो सकता है जिसने .dll फ़ाइल की पूरी पहुंच को ब्लॉक कर दिया हो यदि वह दूसरे कंप्यूटर से प्राप्त हुई हो। इसे ठीक करने के लिए dll फ़ाइल की प्रॉपर्टीज़ विंडो खोलें और "Security" पैनल में "Unblock" बटन पर क्लिक करें।
#### **Q: लाइसेंस 'Aspose.Slides.Reporting.Services.lic' नहीं मिला।**
**A**: लाइसेंस फ़ाइल dll के पास या Program Files(x86)\Aspose\Slides\ डायरेक्टरी में होनी चाहिए।
### **निर्यात कॉन्फ़िगरेशन**
#### **Q: निर्यातित रिपोर्ट में हाइपरलिंक का रंग कैसे बदलूँ?**
**A**: rsreportserver.config में प्रत्येक Aspose.Slides for Reporting Services रेंडरिंग एक्सटेंशन की अपनी कॉन्फ़िगरेशन होती है। हाइपरलिंक का रंग बदलने के लिए, <HyperlinkColor> सेक्शन में आवश्यक मान सेट करें।
#### **Q: निर्यातित प्रेजेंटेशन में, तालिका के पाठ को वर्टिकली खींचा गया दिखता है।**
**A**: यह दस्तावेज़ को पढ़ने में आसान बनाने के लिए किया जाता है। तालिका में पाठ को रिपोर्ट जैसा दिखाने के लिए, rsreportserver.config कॉन्फ़िगरेशन फ़ाइल में संबंधित Aspose.Slides for Reporting Services एक्सटेंशन को "Normal" सेट करें।
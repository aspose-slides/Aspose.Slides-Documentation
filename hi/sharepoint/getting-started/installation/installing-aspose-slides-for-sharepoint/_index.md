---
title: Aspose.Slides for SharePoint स्थापित करना
type: docs
weight: 10
url: /hi/sharepoint/installing-aspose-slides-for-sharepoint/
description: "SharePoint फ़ार्म पर Aspose.Slides for SharePoint स्थापित करें: अपने SharePoint संस्करण के लिए सेटअप प्रोग्राम चुनें, सिस्टम जांच चलाएँ, और समाधान को तैनात व सक्रिय करें।"
---
## **पैकेज सामग्री**

Aspose.Slides for SharePoint को ZIP संग्रह के रूप में [download page](https://releases.aspose.com/slides/hi/sharepoint/) से डाउनलोड किया जाता है। संग्रह में एक SharePoint समाधान पैकेज (WSP) और प्रत्येक समर्थित SharePoint संस्करण के लिए एक सेटअप प्रोग्राम होता है:

| SharePoint संस्करण | सेटअप प्रोग्राम | समाधान पैकेज |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

प्रत्येक सेटअप प्रोग्राम के बगल में एक कॉन्फ़िगरेशन फ़ाइल होती है (उदाहरण के लिए, *Setup2019.exe.config*), जो स्थापित करने वाले समाधान पैकेज का नाम बताती है। *License* फ़ोल्डर में अंतिम‑उपयोगकर्ता लाइसेंस समझौते और तृतीय‑पक्ष लाइसेंस नोटिसों का लिंक होता है।

Aspose.Slides for SharePoint को एक SharePoint समाधान के रूप में पैकेज किया गया है, जिसे SharePoint सर्वर फ़ार्म में तैनात करता है। इसका फीचर फिर प्रत्येक साइट संग्रह के अनुसार सक्रिय या निष्क्रिय किया जाता है।

## **इंस्टॉलेशन प्रक्रिया**

स्थापना से पहले, सेटअप प्रोग्राम एक सिस्टम जांच चलाता है। यह सत्यापित करता है कि:

- सर्वर पर SharePoint स्थापित है।
- वर्तमान उपयोगकर्ता के पास SharePoint समाधान स्थापित करने और तैनात करने की अनुमति है।
- SharePoint Administration सेवा चल रही है।
- SharePoint Timer सेवा चल रही है।
- कॉन्फ़िगरेशन फ़ाइल में नामित समाधान पैकेज मौजूद है।

Administration और Timer सेवाओं की आवश्यकता इसलिए है क्योंकि कुछ सेटअप कार्य टाइमर जॉब के रूप में चलते हैं जो समाधान को फ़ार्म के सभी सर्वरों में वितरित करते हैं।

### **इंस्टॉलेशन चलाना**

Aspose.Slides for SharePoint स्थापित करने के लिए:

1. SharePoint फ़ार्म के किसी सर्वर पर ZIP संग्रह को स्थानीय ड्राइव पर अनज़िप करें।
2. अपने SharePoint संस्करण से मेल खाने वाले सेटअप प्रोग्राम को चलाएँ (ऊपर तालिका देखें) और स्क्रीन पर दिखाए गए निर्देशों का पालन करें। सेटअप प्रोग्राम:
   1. सिस्टम जांच चलाता है। यदि कोई जांच विफल होती है तो सेटअप जारी नहीं रहता।

      **सिस्टम जांच चलाना**

      ![सेटअप प्रोग्राम की सिस्टम जांच स्क्रीन](installing-aspose-slides-for-sharepoint_1.png)

   2. अंतिम‑उपयोगकर्ता लाइसेंस समझौता प्रदर्शित करता है। जारी रखने के लिए आपको इसे स्वीकार करना होगा।

      **लाइसेंस समझौता**

      ![सेटअप प्रोग्राम की लाइसेंस समझौता स्क्रीन](installing-aspose-slides-for-sharepoint_2.png)

   3. परिनियोजन लक्ष्य प्रदर्शित करता है। फीचर को सक्रिय करने के लिये वेब एप्लिकेशन और साइट संग्रह चुनें।

      **परिनियोजन लक्ष्य चुनना**

      ![सेटअप प्रोग्राम की साइट संग्रह परिनियोजन लक्ष्य स्क्रीन](installing-aspose-slides-for-sharepoint_3.png)

   4. समाधान को फ़ार्म में तैनात करता है।

      **इंस्टॉलेशन प्रगति**

      ![सेटअप प्रोग्राम की इंस्टॉलेशन प्रगति स्क्रीन](installing-aspose-slides-for-sharepoint_4.png)

   5. चयनित साइट संग्रहों पर Aspose.Slides for SharePoint को सक्रिय करता है।
   6. उन वेब एप्लिकेशन और साइट संग्रहों की सूची दिखाता है जहाँ समाधान तैनात एवं सक्रिय किया गया है।

      **सफल इंस्टॉलेशन**

      ![सेटअप प्रोग्राम की इंस्टॉलेशन पूर्ण स्क्रीन](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
स्क्रीनशॉट्स SharePoint 2007 पर लिए गए थे। बाद के संस्करणों के सेटअप प्रोग्राम भी समान स्क्रीन दिखाते हैं।
{{% /alert %}}

यदि वही संस्करण का Aspose.Slides for SharePoint पहले से स्थापित है, तो सेटअप प्रोग्राम उसे मरम्मत या हटाने का विकल्प देता है। यदि अन्य संस्करण स्थापित है, तो वह अपग्रेड या हटाने का विकल्प देता है।

स्थापना के बाद, चयनित साइट संग्रहों के दस्तावेज़ लाइब्रेरी में फ़ाइल मेनू में **Convert via Aspose.Slides** आइटम दिखाई देता है (SharePoint 2007 पर **Convert with Aspose.Slides**)। पहला प्रेज़ेंटेशन रूपांतरित करने के लिए देखें [Converting Microsoft PowerPoint Documents into Other Formats](/slides/hi/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/)। फ़ार्म में समाधान द्वारा जोड़ा गया क्या है, यह [Deployment and Activation](/slides/hi/sharepoint/deployment-and-activation/) में वर्णित है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कौन सा सेटअप प्रोग्राम चलाऊँ?**

अपने SharePoint संस्करण से मेल खाने वाला नाम वाला प्रोग्राम चलाएँ। उदाहरण के लिए, SharePoint Server 2016 फ़ार्म पर *Setup2016.exe* चलाएँ। प्रत्येक सेटअप प्रोग्राम केवल अपना समाधान पैकेज स्थापित करता है।

**क्या लाइसेंस्ड संस्करण के लिए अलग डाउनलोड की आवश्यकता है?**

नहीं। वही पैकेज मूल्यांकन मोड में काम करता है जब तक आप लाइसेंस समाधान स्थापित नहीं करते; देखें [Installing Aspose.Slides for SharePoint License](/slides/hi/sharepoint/installing-aspose-slides-for-sharepoint-license/)।

**मैं उत्पाद को कैसे हटाऊँ?**

उसी सेटअप प्रोग्राम को फिर से चलाएँ और **Remove** चुनें; देखें [Uninstalling Aspose.Slides for SharePoint](/slides/hi/sharepoint/uninstalling-aspose-slides-for-sharepoint/).
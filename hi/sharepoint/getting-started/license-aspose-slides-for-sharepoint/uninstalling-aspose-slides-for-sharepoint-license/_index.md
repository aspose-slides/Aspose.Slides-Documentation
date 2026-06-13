---
title: शैयरपॉइंट के लिए Aspose.Slides लाइसेंस को अनइंस्टॉल करना
type: docs
weight: 20
url: /hi/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
लाइसेंस को अनइंस्टॉल करने के लिए, कृपया सर्वर कंसोल से नीचे दिए गए चरणों का उपयोग करें।

1. लाइसेंस समाधान को फॉर्म से वापस लें: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. पुनः प्राप्ति को तुरंत पूरा करने के लिए प्रशासनिक टाइमर जॉब्स चलाएँ: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. पुनः प्राप्ति के पूरा होने की प्रतीक्षा करें। आप **Central Administration** का उपयोग करके यह जांच सकते हैं कि पुनः प्राप्ति पूरी हुई है या नहीं, फिर **Operations** और **Solution Management** के तहत।

4. SharePoint समाधान स्टोर से समाधान को हटाएँ: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```
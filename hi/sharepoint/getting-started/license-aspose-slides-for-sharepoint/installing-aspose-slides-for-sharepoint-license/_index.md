---
title: Aspose.Slides for SharePoint लाइसेंस स्थापित करना
type: docs
weight: 10
url: /hi/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "SharePoint फार्म पर Aspose.Slides for SharePoint लाइसेंस स्थापित करें: लाइसेंस समाधान को सॉल्यूशन स्टोर में जोड़ें, इसे तैनात करें, और जाँचें कि परिवर्तित फ़ाइलों में अब मूल्यांकन वॉटरमार्क नहीं है।"
---
{{% alert color="info" title="ध्यान दें" %}}

एक बार जब आप अपने मूल्यांकन से संतुष्ट हों, तो आप [लाइसेंस खरीद सकते हैं](https://purchase.aspose.com/pricing/slides/sharepoint/). खरीदारी से पहले, कृपया लाइसेंस सब्सक्रिप्शन शर्तों को समझें और उनसे सहमत हों। भुगतान होने के बाद लाइसेंस आपको ईमेल किया जाएगा।

लाइसेंस एक ZIP अभिलेख है जिसमें एक नियमित SharePoint समाधान पैकेज होता है। अभिलेख में शामिल हैं:

- Aspose.Slides.SharePoint.License.wsp – SharePoint समाधान पैकेज फ़ाइल। लाइसेंस को SharePoint समाधान के रूप में पैकेज किया गया है जिससे सर्वर फार्म में तैनाती और रिट्रैक्शन आसान हो जाता है।
- readme.txt – लाइसेंस स्थापना निर्देश।

{{% /alert %}}

## **लाइसेंस को तैनात करना**

लाइसेंस स्थापना सर्वर कंसोल से **stsadm.exe** के माध्यम से की जाती है।

{{% alert color="info" title="ध्यान दें" %}}

स्पष्टता के लिए नीचे के खंड में पथ को छोड़ दिया गया है।

{{% /alert %}}

Aspose.Slides for SharePoint लाइसेंस को तैनात करने के लिए निम्न कदम उठाएँ:

1. समाधान को SharePoint समाधान स्टोर में जोड़ने के लिए stsadm चलाएँ:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. फार्म के सभी सर्वरों पर समाधान तैनात करें:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. तैनाती को तुरंत पूर्ण करने के लिए प्रशासनिक टाइमर जॉब्स निष्पादित करें:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` ऑपरेशन में `-filename` में समाधान फ़ाइल का पथ दिया जाता है; `deploysolution` ऑपरेशन में पहले से समाधान स्टोर में मौजूद समाधान का `-name` दिया जाता है।

{{% alert color="info" title="ध्यान दें" %}}

यदि SharePoint Administration सेवा नहीं चल रही है तो तैनाती चरण चलाते समय आपको एक चेतावनी मिलेगी। **stsadm.exe** इस सेवा और SharePoint Timer सेवा पर निर्भर करता है ताकि समाधान डेटा को फार्म में प्रतिलिपित किया जा सके। यदि ये सेवाएँ आपके सर्वर फार्म में चालू नहीं हैं, तो आपको लाइसेंस को प्रत्येक सर्वर पर तैनात करना पड़ सकता है।

{{% /alert %}}

{{% alert color="info" title="ध्यान दें" %}}

SharePoint 2010 और बाद के संस्करणों में, SharePoint Management Shell cmdlets `Add-SPSolution`, `Install-SPSolution` और `Start-SPAdminJob` क्रमशः `addsolution`, `deploysolution` और `execadmsvcjobs` ऑपरेशनों के अनुरूप हैं। देखें [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping)।

{{% /alert %}}

## **लाइसेंस का परीक्षण करें**

यह सुनिश्चित करने के लिए कि लाइसेंस सही तरीके से स्थापित हो गया है, किसी भी प्रस्तुति को नई फ़ॉर्मेट में परिवर्तित करें। यदि परिवर्तित फ़ाइल में कोई मूल्यांकन वॉटरमार्क नहीं है, तो लाइसेंस सक्रिय है।